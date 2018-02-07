using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using KnetikUnity.Events;
using KnetikUnity.Exceptions;
using KnetikUnity.Factory;
using KnetikUnity.Utils;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace KnetikUnity.Client
{
    /// <summary>
    /// Handler that is called when a web request is complete
    /// </summary>
    public delegate void KnetikResponseReceivedHandler(KnetikRestResponse response);

    /// <inheritdoc />
    /// <summary>
    /// Base class to call coroutines and REST API calls with.
    /// </summary>
    public abstract class KnetikClient : MonoBehaviour
    {
        private const string AcceptTypeHeader = "Accept";
        private const string ContentTypeHeader = "Content-Type";
        private const string ContentType = "application/json";
        private const string IsoDatetimeFormat = "o";

        private static string sDateTimeFormat = IsoDatetimeFormat;

        private bool mInitialized = false;

        /// <summary>
        /// The server environment to use.  This may affect the URL.
        /// </summary>
        public abstract KnetikServerEnvironment ServerEnvironment { get; }

        /// <summary>
        /// The base server URL for the client.  Honours the server environment (where possible)
        /// </summary>
        public abstract string BaseUrl { get; }

        /// <summary>
        /// Gets or sets the the date time format used when serializing in the KnetikClient
        /// By default, it's set to ISO 8601 - "o", for others see:
        /// https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx
        /// and https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
        /// No validation is done to ensure that the string you're providing is valid
        /// </summary>
        /// <value>The DateTimeFormat string</value>
        public static string DateTimeFormat
        {
            get
            {
                return sDateTimeFormat;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    sDateTimeFormat = IsoDatetimeFormat;
                    return;
                }

                // Caution, no validation when you choose date time format other than ISO 8601
                // Take a look at the above links
                sDateTimeFormat = value;
            }
        }

        /// <summary>
        /// If parameter is DateTime, output in a formatted string (default ISO 8601), customizable with KnetikConfiguration.DateTime.
        /// If parameter is a list of string, join the list with ",".
        /// Otherwise just return the string.
        /// </summary>
        /// <param name="obj">The parameter (header, path, query, form).</param>
        /// <returns>Formatted string.</returns>
        public static string ParameterToString(object obj)
        {
            if (obj is DateTime)
            {
                // Return a formatted date string - Can be customized with KnetikConfiguration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTime)obj).ToString(DateTimeFormat);
            }
            else if (obj is List<string>)
            {
                return string.Join(",", (obj as List<string>).ToArray());
            }
            else
            {
                return Convert.ToString(obj);
            }
        }

        /// <summary>
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="content">HTTP body (e.g. string, JSON).</param>
        /// <param name="type">Object type.</param>
        /// <param name="headers">HTTP headers.</param>
        /// <returns>Object representation of the JSON string.</returns>
        public static object Deserialize(string content, Type type, Dictionary<string, string> headers)
        {
            if (type == typeof(object)) // return an object
            {
                return content;
            }

            if (type == typeof(Stream))
            {
                string filePath = Application.temporaryCachePath;
                string fileName = Path.Combine(filePath, Guid.NewGuid().ToString());

                if (headers != null)
                {
                    Regex regex = new Regex(@"Content-Disposition:.*filename=['""]?([^'""\s]+)['""]?$");
                    Match match = regex.Match(headers.ToList().ToString());
                    if (match.Success)
                    {
                        fileName = filePath + match.Value.Replace("\"", "").Replace("'", "");
                    }
                }

                File.WriteAllText(fileName, content);
                return new FileStream(fileName, FileMode.Open);
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a datetime object
            {
                return DateTime.Parse(content, null, DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(string) || type.Name.StartsWith("System.Nullable")) // return primitive type
            {
                return ConvertType(content, type);
            }

            // at this point, it must be a model (json)
            try
            {
                return JsonConvert.DeserializeObject(content, type);
            }
            catch (IOException e)
            {
                throw new KnetikException(500, e.Message);
            }
        }

        /// <summary>
        /// Serialize an object into JSON string.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>JSON string.</returns>
        public static string Serialize(object obj)
        {
            try
            {
                return (obj != null) ? JsonConvert.SerializeObject(obj) : null;
            }
            catch (Exception e)
            {
                throw new KnetikException(500, e.Message);
            }
        }

        /// <summary>
        /// Dynamically cast the object into target type.
        /// </summary>
        /// <param name="fromObject">Object to be casted</param>
        /// <param name="toObject">Target type</param>
        /// <returns>Casted object</returns>
        public static object ConvertType(object fromObject, Type toObject)
        {
            return Convert.ChangeType(fromObject, toObject);
        }

        /// <summary>
        /// Update parameters based on authentication.
        /// </summary>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="authSettings">Authentication settings.</param>
        protected abstract void UpdateParamsForAuth(Dictionary<string, string> headerParams, List<string> authSettings);

        protected virtual void Awake()
        {
            KnetikFactory.Initialize();
            ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;

            KnetikGlobalEventSystem.Subscribe<KnetikWebCallEvent>(OnKnetikWebCall);
            KnetikGlobalEventSystem.Subscribe<KnetikClientReadyRequestEvent>(OnClientReadyRequest);

            mInitialized = true;
            KnetikGlobalEventSystem.Publish(new KnetikClientReadyResponseEvent(null, true, ServerEnvironment));
        }

        protected virtual void OnDestroy()
        {
            mInitialized = false;
            ServicePointManager.ServerCertificateValidationCallback = null;
            KnetikGlobalEventSystem.Unsubscribe<KnetikClientReadyRequestEvent>(OnClientReadyRequest);
            KnetikGlobalEventSystem.Unsubscribe<KnetikWebCallEvent>(OnKnetikWebCall);
        }

        private void OnClientReadyRequest(KnetikClientReadyRequestEvent e)
        {
            KnetikGlobalEventSystem.Publish(new KnetikClientReadyResponseEvent(e.Requester, mInitialized, ServerEnvironment));
        }

        private void OnKnetikWebCall(KnetikWebCallEvent e)
        {
            if (string.IsNullOrEmpty(BaseUrl))
            {
                throw new KnetikException("You must have a valid base URL for the REST Api!");
            }

            StringBuilder urlBuilder = new StringBuilder();
            urlBuilder.Append(BaseUrl);
            urlBuilder.Append(e.WebPath);

            if (e.QueryParams.Count > 0)
            {
                urlBuilder.Append("?");

                List<string> keys = e.QueryParams.Keys.ToList();

                for (int i = 0; i < keys.Count; ++i)
                {
                    urlBuilder.AppendFormat("{0}={1}", keys[i], e.QueryParams[keys[i]]);

                    if (i < (keys.Count - 1))
                    {
                        urlBuilder.Append("&");
                    }
                }
            }

            string fullUrl = urlBuilder.ToString();
            KnetikLogger.Log(string.Format("Sending request to URL {0}", fullUrl));

            UnityWebRequest webRequest = new UnityWebRequest(fullUrl, GetUnityVerbFromRequestType(e.RequestType));
            if (!string.IsNullOrEmpty(e.PostBody))
            {
                webRequest.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(e.PostBody))
                {
                    contentType = ContentType
                };
            }

            webRequest.downloadHandler = new DownloadHandlerBuffer();

            UpdateParamsForAuth(e.HeaderParams, e.AuthSettings);

            // add header parameters, if any
            foreach (KeyValuePair<string, string> param in e.HeaderParams)
            {
                webRequest.SetRequestHeader(param.Key, param.Value);
            }

            // Set the content type, always
            webRequest.SetRequestHeader(AcceptTypeHeader, ContentType);
            webRequest.SetRequestHeader(ContentTypeHeader, ContentType);

            StartCoroutine(HandleAsyncWebRequest(e.Context, webRequest));
        }

        /// <summary>
        /// Call the asynchronous web request in a blocking coroutine so we can fire events when it returns.
        /// </summary>
        private static IEnumerator HandleAsyncWebRequest(KnetikResponseContext context, UnityWebRequest webRequest)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }

            yield return webRequest.Send();

            KnetikRestResponse response = new KnetikRestResponse
            {
                ResponseCode = webRequest.responseCode,
                Headers = webRequest.GetResponseHeaders()
            };

            if (webRequest.isError)
            {
                response.Error = webRequest.error;
            }
            else if ((webRequest.responseCode >= 400) || (webRequest.responseCode == 0))
            {
                response.Error = webRequest.downloadHandler.text;
            }
            else
            {
                response.Content = webRequest.downloadHandler.text;
            }

            context.Response = response;

            if (context.ResponseReceived != null)
            {
                context.ResponseReceived(context.Response);
            }
        }

        /// <summary>
        /// Translate the request type to the web request verb
        /// </summary>
        private static string GetUnityVerbFromRequestType(KnetikRequestType type)
        {
            switch (type)
            {
                case KnetikRequestType.DELETE:
                    return UnityWebRequest.kHttpVerbDELETE;

                case KnetikRequestType.GET:
                    return UnityWebRequest.kHttpVerbGET;

                case KnetikRequestType.POST:
                    return UnityWebRequest.kHttpVerbPOST;

                case KnetikRequestType.PUT:
                    return UnityWebRequest.kHttpVerbPUT;

                default:
                    throw new KnetikException("Add support for the new KnetikRequestType!");
            }
        }

        /// <summary>
        /// Handle MONO's incomplete certificate support: http://www.mono-project.com/archived/usingtrustedrootsrespectfully/
        /// </summary>
        private static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            bool isOk = true;

            // If there are errors in the certificate chain then, look at each error to determine the cause.
            if (sslPolicyErrors != SslPolicyErrors.None)
            {
                for (int i = 0; i < chain.ChainStatus.Length; i++)
                {
                    if (chain.ChainStatus[i].Status == X509ChainStatusFlags.RevocationStatusUnknown)
                    {
                        continue;
                    }

                    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;

                    bool chainIsValid = chain.Build((X509Certificate2)certificate);

                    if (!chainIsValid)
                    {
                        isOk = false;
                        break;
                    }
                }
            }

            return isOk;
        }
    }
}
