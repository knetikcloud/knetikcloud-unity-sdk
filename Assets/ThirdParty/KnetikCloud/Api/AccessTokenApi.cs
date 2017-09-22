using System;
using System.Collections.Generic;
using RestSharp;
using com.knetikcloud.Client;
using com.knetikcloud.Model;
using com.knetikcloud.Utils;
using UnityEngine;

using Object = System.Object;
using Version = com.knetikcloud.Model.Version;


namespace com.knetikcloud.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAccessTokenApi
    {
        OAuth2Resource GetOAuthTokenData { get; }

        
        /// <summary>
        /// Get access token 
        /// </summary>
        /// <param name="grantType">Grant type</param>
        /// <param name="clientId">The id of the client</param>
        /// <param name="clientSecret">The secret key of the client.  Used only with a grant_type of client_credentials</param>
        /// <param name="username">The username of the client. Used only with a grant_type of password</param>
        /// <param name="password">The password of the client. Used only with a grant_type of password</param>
        /// <param name="token">The 3rd party authentication token. Used only with a grant_type of facebook, google, etc (social plugins)</param>
        /// <param name="refreshToken">The refresh token obtained during prior authentication. Used only with a grant_type of refresh_token</param>
        void GetOAuthToken(string grantType, string clientId, string clientSecret, string username, string password, string token, string refreshToken);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AccessTokenApi : IAccessTokenApi
    {
        private readonly KnetikCoroutine mGetOAuthTokenCoroutine;
        private DateTime mGetOAuthTokenStartTime;
        private string mGetOAuthTokenPath;

        public OAuth2Resource GetOAuthTokenData { get; private set; }
        public delegate void GetOAuthTokenCompleteDelegate(OAuth2Resource response);
        public GetOAuthTokenCompleteDelegate GetOAuthTokenComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AccessTokenApi()
        {
            mGetOAuthTokenCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get access token 
        /// </summary>
        /// <param name="grantType">Grant type</param>
        /// <param name="clientId">The id of the client</param>
        /// <param name="clientSecret">The secret key of the client.  Used only with a grant_type of client_credentials</param>
        /// <param name="username">The username of the client. Used only with a grant_type of password</param>
        /// <param name="password">The password of the client. Used only with a grant_type of password</param>
        /// <param name="token">The 3rd party authentication token. Used only with a grant_type of facebook, google, etc (social plugins)</param>
        /// <param name="refreshToken">The refresh token obtained during prior authentication. Used only with a grant_type of refresh_token</param>
        public void GetOAuthToken(string grantType, string clientId, string clientSecret, string username, string password, string token, string refreshToken)
        {
            // verify the required parameter 'grantType' is set
            if (grantType == null)
            {
                throw new KnetikException(400, "Missing required parameter 'grantType' when calling GetOAuthToken");
            }
            // verify the required parameter 'clientId' is set
            if (clientId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientId' when calling GetOAuthToken");
            }
            
            mGetOAuthTokenPath = "/oauth/token";
            if (!string.IsNullOrEmpty(mGetOAuthTokenPath))
            {
                mGetOAuthTokenPath = mGetOAuthTokenPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (grantType != null)
            {
                formParams.Add("grant_type", KnetikClient.DefaultClient.ParameterToString(grantType)); // form parameter
            }			

            if (clientId != null)
            {
                formParams.Add("client_id", KnetikClient.DefaultClient.ParameterToString(clientId)); // form parameter
            }			

            if (clientSecret != null)
            {
                formParams.Add("client_secret", KnetikClient.DefaultClient.ParameterToString(clientSecret)); // form parameter
            }			

            if (username != null)
            {
                formParams.Add("username", KnetikClient.DefaultClient.ParameterToString(username)); // form parameter
            }			

            if (password != null)
            {
                formParams.Add("password", KnetikClient.DefaultClient.ParameterToString(password)); // form parameter
            }			

            if (token != null)
            {
                formParams.Add("token", KnetikClient.DefaultClient.ParameterToString(token)); // form parameter
            }			

            if (refreshToken != null)
            {
                formParams.Add("refresh_token", KnetikClient.DefaultClient.ParameterToString(refreshToken)); // form parameter
            }			

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetOAuthTokenStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetOAuthTokenStartTime, mGetOAuthTokenPath, "Sending server request...");

            // make the HTTP request
            mGetOAuthTokenCoroutine.ResponseReceived += GetOAuthTokenCallback;
            mGetOAuthTokenCoroutine.Start(mGetOAuthTokenPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetOAuthTokenCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetOAuthToken: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetOAuthToken: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetOAuthTokenData = (OAuth2Resource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(OAuth2Resource), response.Headers);
            KnetikLogger.LogResponse(mGetOAuthTokenStartTime, mGetOAuthTokenPath, string.Format("Response received successfully:\n{0}", GetOAuthTokenData.ToString()));

            if (GetOAuthTokenComplete != null)
            {
                GetOAuthTokenComplete(GetOAuthTokenData);
            }
        }
    }
}
