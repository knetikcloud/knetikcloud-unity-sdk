using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using com.knetikcloud.Api;
using com.knetikcloud.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Extensions;
using UnityEngine;

namespace com.knetikcloud.Client
{
    /// <summary>
    /// API client is mainly responible for making the HTTP call to the API backend.
    /// </summary>
    public class KnetikClient  : MonoBehaviour
    {
        private KnetikProjectSettings _projectSettings;
        private KnetikUserCredentials _userCredentials;
        private readonly Dictionary<String, String> _defaultHeaderMap = new Dictionary<String, String>();
        private string _basePath;
        private RestClient _restClient;

        public const string GrantTypeClientCredentials = "client_credentials";
        public const string GrantTypeUserPassword = "password";
        public const string GrantTypeFacebook = "facebook";
        public const string GrantTypeGoogle = "google";
        public const string GrantTypeRefreshToken = "refresh_token";

        public OAuth2Resource AuthToken { get; private set; }

        /// <summary>
        /// Gets or sets the base path.
        /// </summary>
        /// <value>The base path</value>
        public string BasePath
        {
            get
            {
                return _basePath;
            }
            set
            {
                _basePath = value;
                _restClient = new RestClient(_basePath);
            }
        }
    
        /// <summary>
        /// Gets the RestClient.
        /// </summary>
        /// <value>An instance of the RestClient</value>
        public RestClient RestClient
        {
            get
            {
                return _restClient;
            }
        }
    
        /// <summary>
        /// Gets the default header.
        /// </summary>
        public Dictionary<String, String> DefaultHeader
        {
            get { return _defaultHeaderMap; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnetikClient" /> class.
        /// </summary>
        /// <param name="basePath">The base path.</param>
        public KnetikClient(String basePath)
        {
            BasePath = basePath;
            ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;
        }

        public KnetikClient()
        {
            ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;
        }

        /// <summary>
        /// Makes the HTTP request (Sync).
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
        public System.Object CallApi(String path, RestSharp.Method method, Dictionary<String, String> queryParams, String postBody,
            Dictionary<String, String> headerParams, Dictionary<String, String> formParams, 
            Dictionary<String, FileParameter> fileParams, String[] authSettings)
        {
            var request = new RestRequest(path, method);
   
            UpdateParamsForAuth(queryParams, headerParams, authSettings);

            // add default header, if any
            foreach(var defaultHeader in _defaultHeaderMap)
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

            return (System.Object)RestClient.Execute(request);
        }
    
        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        public void AddDefaultHeader(string key, string value)
        {
            _defaultHeaderMap.Add(key, value);
        }
    
        /// <summary>
        /// Escape string (url-encoded).
        /// </summary>
        /// <param name="str">String to be escaped.</param>
        /// <returns>Escaped string.</returns>
        public string EscapeString(string str)
        {
            return RestSharp.Contrib.HttpUtility.UrlEncode(str);
        }
    
        /// <summary>
        /// Create FileParameter based on Stream.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="stream">Input stream.</param>
        /// <returns>FileParameter.</returns>
        public FileParameter ParameterToFile(string name, Stream stream)
        {
            if (stream is FileStream)
            {
                return FileParameter.Create(name, stream.ReadAsBytes(), Path.GetFileName(((FileStream)stream).Name));
            }
            else
            {
                return FileParameter.Create(name, stream.ReadAsBytes(), "no_file_name_provided");
            }
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
                return ((DateTime)obj).ToString (KnetikConfiguration.DateTimeFormat);
            }
            else if (obj is List<string>)
            {
                return String.Join(",", (obj as List<string>).ToArray());
            }
            else
            {
                return Convert.ToString (obj);
            }
        }
    
        /// <summary>
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="content">HTTP body (e.g. string, JSON).</param>
        /// <param name="type">Object type.</param>
        /// <param name="headers">HTTP headers.</param>
        /// <returns>Object representation of the JSON string.</returns>
        public object Deserialize(string content, Type type, IList<Parameter> headers=null)
        {
            if (type == typeof(System.Object)) // return an object
            {
                return content;
            }

            if (type == typeof(Stream))
            {
                var filePath = String.IsNullOrEmpty(KnetikConfiguration.TempFolderPath)
                    ? Path.GetTempPath()
                    : KnetikConfiguration.TempFolderPath;

                var fileName = filePath + Guid.NewGuid();
                if (headers != null)
                {
                    var regex = new Regex(@"Content-Disposition:.*filename=['""]?([^'""\s]+)['""]?$");
                    var match = regex.Match(headers.ToString());
                    if (match.Success)
                        fileName = filePath + match.Value.Replace("\"", "").Replace("'", "");
                }
                File.WriteAllText(fileName, content);
                return new FileStream(fileName, FileMode.Open);
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a datetime object
            {
                return DateTime.Parse(content,  null, System.Globalization.DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(String) || type.Name.StartsWith("System.Nullable")) // return primitive type
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
        /// Get the API key with prefix.
        /// </summary>
        /// <param name="apiKeyIdentifier">API key identifier (authentication scheme).</param>
        /// <returns>API key with prefix.</returns>
        public string GetApiKeyWithPrefix(string apiKeyIdentifier)
        {
            string apiKeyValue = string.Empty;
            KnetikConfiguration.ApiKey.TryGetValue (apiKeyIdentifier, out apiKeyValue);
            string apiKeyPrefix = string.Empty;

            if (KnetikConfiguration.ApiKeyPrefix.TryGetValue (apiKeyIdentifier, out apiKeyPrefix))
            {
                return apiKeyPrefix + " " + apiKeyValue;
            }
            else
            {
                return apiKeyValue;
            }
        }
    
        /// <summary>
        /// Update parameters based on authentication.
        /// </summary>
        /// <param name="queryParams">Query parameters.</param>
        /// <param name="headerParams">Header parameters.</param>
        /// <param name="authSettings">Authentication settings.</param>
        public void UpdateParamsForAuth(Dictionary<String, String> queryParams, Dictionary<String, String> headerParams, string[] authSettings)
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
        /// Encode string in base64 format.
        /// </summary>
        /// <param name="text">String to be encoded.</param>
        /// <returns>Encoded string.</returns>
        public static string Base64Encode(string text)
        {
            var textByte = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(textByte);
        }
    
        /// <summary>
        /// Dynamically cast the object into target type.
        /// </summary>
        /// <param name="fromObject">Object to be casted</param>
        /// <param name="toObject">Target type</param>
        /// <returns>Casted object</returns>
        public static System.Object ConvertType(System.Object fromObject, Type toObject)
        {
            return Convert.ChangeType(fromObject, toObject);
        }

        private void Start()
        {
            // Load project settings
            _projectSettings = KnetikProjectSettings.Load();
            if (_projectSettings == null)
            {
                Debug.LogError("Knetik Cloud: unable to load project settings - please set them up in the editor window!");
                return;
            }

            if (string.IsNullOrEmpty(_projectSettings.BaseUrl))
            {
                Debug.LogError("Knetik Cloud: You must set up the base URL in the editor window!");
                return;
            }

            BasePath = _projectSettings.BaseUrl;
            KnetikConfiguration.DefaultClient = this;

            // Load optional user credentials
            _userCredentials = KnetikUserCredentials.Load();

            // Attempt to login
            switch (_projectSettings.GrantType)
            {
                case GrantTypeClientCredentials:
                    GrantClientCredentials();
                    break;

                case GrantTypeUserPassword:
                    GrantUserPassword();
                    break;

                case GrantTypeFacebook:
                    break;

                case GrantTypeGoogle:
                    break;

                case GrantTypeRefreshToken:
                    break;

                default:
                    Debug.LogErrorFormat("Knetik Cloud: Unrecognized 'grant_type' - please verify that you have selected one of: {0}, {1}, {2}, {3}, {4}.",
                        GrantTypeClientCredentials, GrantTypeUserPassword, GrantTypeFacebook, GrantTypeGoogle, GrantTypeRefreshToken);
                    break;
            }

            //string clientSecret = null;  // string | The secret key of the client.  Used only with a grant_type of client_credentials (optional) 
            //string username = "george.hornmoen";  // string | The username of the client. Used only with a grant_type of password (optional) 
            //string password = "meowmeow";  // string | The password of the client. Used only with a grant_type of password (optional) 
            //string token = null;  // string | The 3rd party authentication token. Used only with a grant_type of facebook, google, etc (social plugins) (optional) 
            //string refreshToken = null;  // string | The refresh token obtained during prior authentication. Used only with a grant_type of refresh_token (optional) 
        }

        private void GrantClientCredentials()
        {
            if (string.IsNullOrEmpty(_projectSettings.ClientSecret))
            {
                Debug.LogError("Knetik Cloud: The 'client secret' is not configured properly - please set it in the editor window!");
                return;
            }

            try
            {
                // Get access token
                var apiInstance = new AccessTokenApi();
                AuthToken = apiInstance.GetOAuthToken(_projectSettings.GrantType, _projectSettings.ClientId, _projectSettings.ClientSecret, null, null, null, null);
                Debug.Log(AuthToken);
            }
            catch (Exception e)
            {
                Debug.LogError("Exception when calling AccessTokenApi.GetOAuthToken: " + e.Message);
            }
        }

        private void GrantUserPassword()
        {
            if (string.IsNullOrEmpty(_userCredentials.UserId) || string.IsNullOrEmpty(_userCredentials.Password))
            {
                Debug.LogError("Knetik Cloud: User credentials are not configured properly - please set them up in the editor window!");
                return;
            }

            try
            {
                // Get access token
                var apiInstance = new AccessTokenApi();
                AuthToken = apiInstance.GetOAuthToken(_projectSettings.GrantType, _projectSettings.ClientId, null, _userCredentials.UserId, _userCredentials.Password, null, null);
                Debug.Log(AuthToken);
            }
            catch (Exception e)
            {
                Debug.LogError("Exception when calling AccessTokenApi.GetOAuthToken: " + e.Message);
            }
        }

        private void GrantToken()
        {

        }

        /// <summary>
        /// Handle MONO's incomplete certificate support: http://www.mono-project.com/archived/usingtrustedrootsrespectfully/
        /// </summary>
        public static bool RemoteCertificateValidationCallback(System.Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
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