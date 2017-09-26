using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using com.knetikcloud.Api;
using com.knetikcloud.Credentials;
using com.knetikcloud.Events;
using com.knetikcloud.Model;
using com.knetikcloud.Utils;
using Newtonsoft.Json;
using RestSharp;
using UnityEngine;
using Object = System.Object;


namespace com.knetikcloud.Client
{
    /// <inheritdoc />
    /// <summary>
    /// The Unity client that is responsible for making HTTP calls to the backend.
    /// </summary>
    public class KnetikClient  : MonoBehaviour
    {
        private KnetikProjectSettings mProjectSettings;
        private readonly Dictionary<string, string> mDefaultHeaderMap = new Dictionary<string, string>();
        private static string mDateTimeFormat = IsoDatetimeFormat;

        private RestClient mRestClient;
        private AccessTokenApi mAccessTokenApi;

        private const string IsoDatetimeFormat = "o";

        public const string GrantTypeClientCredentials = "client_credentials";
        public const string GrantTypeUserPassword = "password";
        public const string GrantTypeFacebook = "facebook";
        public const string GrantTypeGoogle = "google";
        public const string GrantTypeRefreshToken = "refresh_token";

        /// <summary>
        /// The default API client for making HTTP calls.
        /// </summary>
        public static KnetikClient DefaultClient { get; private set; }

        public OAuth2Resource AuthToken { get; private set; }

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
                return mDateTimeFormat;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    mDateTimeFormat = IsoDatetimeFormat;
                    return;
                }

                // Caution, no validation when you choose date time format other than ISO 8601
                // Take a look at the above links
                mDateTimeFormat = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnetikClient" /> class.
        /// </summary>
        public KnetikClient()
        {
            ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;
        }

        public void AuthenticateWithUserCredentials(KnetikUserCredentials userCredentials)
        {
            if (userCredentials == null)
            {
                KnetikLogger.LogError("The 'userCredentials' cannot be null!");
                return;
            }

            if (!userCredentials.IsConfigured)
            {
                KnetikLogger.LogError("The user credentials are not configured properly.  Please set them up in the editor window!");
                return;
            }

            try
            {
                // Get access token
                mAccessTokenApi.GetOAuthToken(userCredentials.GrantType, mProjectSettings.ClientId, null, userCredentials.UserId, userCredentials.Password, null, null);
            }
            catch (KnetikException)
            {
                // Error is already logged
            }
        }

        public void AuthenticateWithClientCredentials(KnetikClientCredentials clientCredentials)
        {
            if (clientCredentials == null)
            {
                KnetikLogger.LogError("The 'clientCredentials' cannot be null!");
                return;
            }

            if (!clientCredentials.IsConfigured)
            {
                KnetikLogger.LogError("The client credentials are not configured properly.  Please set them up in the editor window!");
                return;
            }

            try
            {
                // Get access token
                mAccessTokenApi.GetOAuthToken(clientCredentials.GrantType, mProjectSettings.ClientId, clientCredentials.ClientSecret, null, null, null, null);
            }
            catch (KnetikException)
            {
                // Error is already logged
            }
        }

        /// <summary>
        /// Make a synchronous HTTP request.
        /// </summary>
        /// <param name="path">URL path.</param>
        /// <param name="method">HTTP method.</param>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="postBody">HTTP body (POST request).</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="formParams">Form parameters.</param>
        /// <param name="fileParams">File parameters.</param>
        /// <param name="authSettings">Authentication settings.</param>
        /// <returns>Object</returns>
        public Object CallApi(string path, Method method, Dictionary<string, string> queryParams, string postBody,
            Dictionary<string, string> headerParams, Dictionary<string, string> formParams, 
            Dictionary<string, FileParameter> fileParams, string[] authSettings)
        {
            RestRequest request = new RestRequest(path, method);
   
            UpdateParamsForAuth(queryParams, headerParams, authSettings);

            // add default header, if any
            foreach(var defaultHeader in mDefaultHeaderMap)
            {
                request.AddHeader(defaultHeader.Key, defaultHeader.Value);
            }

            // add header parameter, if any
            foreach(var param in headerParams)
            {
                request.AddHeader(param.Key, param.Value);
            }

            // add query parameter, if any
            foreach(var param in queryParams)
            {
                request.AddParameter(param.Key, param.Value, ParameterType.GetOrPost);
            }

            // add form parameter, if any
            foreach(var param in formParams)
            {
                request.AddParameter(param.Key, param.Value, ParameterType.GetOrPost);
            }

            // add file parameter, if any
            foreach(var param in fileParams)
            {
                request.AddFile(param.Value.Name, param.Value.Writer, param.Value.FileName, param.Value.ContentType);
            }

            if (postBody != null)
            {
                request.AddParameter("application/json", postBody, ParameterType.RequestBody);
            }

            return mRestClient.Execute(request);
        }

        /// <summary>
        /// If parameter is DateTime, output in a formatted string (default ISO 8601), customizable with KnetikConfiguration.DateTime.
        /// If parameter is a list of string, join the list with ",".
        /// Otherwise just return the string.
        /// </summary>
        /// <param name="obj">The parameter (header, path, query, form).</param>
        /// <returns>Formatted string.</returns>
        public string ParameterToString(object obj)
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
        public object Deserialize(string content, Type type, IList<Parameter> headers)
        {
            if (type == typeof(Object)) // return an object
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
                    Match match = regex.Match(headers.ToString());
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
                return DateTime.Parse(content,  null, DateTimeStyles.RoundtripKind);
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
        public string Serialize(object obj)
        {
            try
            {
                return obj != null ? JsonConvert.SerializeObject(obj) : null;
            }
            catch (Exception e)
            {
                throw new KnetikException(500, e.Message);
            }
        }

        /// <summary>
        /// Update parameters based on authentication.
        /// </summary>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="authSettings">Authentication settings.</param>
        public void UpdateParamsForAuth(Dictionary<string, string> queryParams, Dictionary<string, string> headerParams, string[] authSettings)
        {
            if (authSettings == null || authSettings.Length == 0)
            {
                return;
            }

            foreach (string auth in authSettings)
            {
                // determine which one to use
                switch(auth)
                {
                    case "oauth2_client_credentials_grant":
                        
                        //TODO support oauth
                        break;
                    case "oauth2_password_grant":
                        
                        //TODO support oauth
                        break;
                    default:
                        //TODO show warning about security definition not found
                        break;
                }
            }
        }

        /// <summary>
        /// Dynamically cast the object into target type.
        /// </summary>
        /// <param name="fromObject">Object to be casted</param>
        /// <param name="toObject">Target type</param>
        /// <returns>Casted object</returns>
        public static Object ConvertType(Object fromObject, Type toObject)
        {
            return Convert.ChangeType(fromObject, toObject);
        }

        private void Awake()
        {
            // Load project settings
            mProjectSettings = KnetikProjectSettings.Load();
            if (mProjectSettings == null)
            {
                KnetikLogger.LogError("Unable to load project settings - please set them up in the editor window!");
                return;
            }

            if (string.IsNullOrEmpty(mProjectSettings.BaseUrl))
            {
                KnetikLogger.LogError("You must set up the base URL in the editor window!");
                return;
            }

            mRestClient = new RestClient(mProjectSettings.BaseUrl);

            mAccessTokenApi = new AccessTokenApi();
            mAccessTokenApi.GetOAuthTokenComplete += GetOAuthTokenComplete;
            DefaultClient = this;

            KnetikGlobalEventSystem.Subscribe<KnetikClientReadyRequestEvent>(OnClientReadyRequest);

            KnetikGlobalEventSystem.Publish(KnetikClientReadyResponseEvent.GetInstance(null, true));
        }

        private void OnDestroy()
        {
            KnetikGlobalEventSystem.Unsubscribe<KnetikClientReadyRequestEvent>(OnClientReadyRequest);

            mAccessTokenApi = null;
            DefaultClient = null;
        }

        private void GetOAuthTokenComplete(OAuth2Resource response)
        {
            AuthToken = response;
            KnetikGlobalEventSystem.Publish(KnetikClientAuthenticatedEvent.GetInstance(AuthToken));
        }

        private static void OnClientReadyRequest(KnetikClientReadyRequestEvent e)
        {
            KnetikGlobalEventSystem.Publish(KnetikClientReadyResponseEvent.GetInstance(e.Requester, (DefaultClient != null)));
        }

        /// <summary>
        /// Handle MONO's incomplete certificate support: http://www.mono-project.com/archived/usingtrustedrootsrespectfully/
        /// </summary>
        private static bool RemoteCertificateValidationCallback(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
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
