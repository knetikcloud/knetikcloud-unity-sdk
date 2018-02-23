using System;
using System.Collections.Generic;
using com.knetikcloud.Model;
using KnetikUnity.Client;
using KnetikUnity.Events;
using KnetikUnity.Exceptions;
using KnetikUnity.Utils;

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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetOAuthTokenResponseContext;
        private DateTime mGetOAuthTokenStartTime;

        public OAuth2Resource GetOAuthTokenData { get; private set; }
        public delegate void GetOAuthTokenCompleteDelegate(long responseCode, OAuth2Resource response);
        public GetOAuthTokenCompleteDelegate GetOAuthTokenComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AccessTokenApi()
        {
            mGetOAuthTokenResponseContext = new KnetikResponseContext();
            mGetOAuthTokenResponseContext.ResponseReceived += OnGetOAuthTokenResponse;
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
            
            mWebCallEvent.WebPath = "/oauth/token";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (grantType != null)
            {
                mWebCallEvent.QueryParams["grant_type"] = KnetikClient.ParameterToString(grantType);
            }

            if (clientId != null)
            {
                mWebCallEvent.QueryParams["client_id"] = KnetikClient.ParameterToString(clientId);
            }

            if (clientSecret != null)
            {
                mWebCallEvent.QueryParams["client_secret"] = KnetikClient.ParameterToString(clientSecret);
            }

            if (username != null)
            {
                mWebCallEvent.QueryParams["username"] = KnetikClient.ParameterToString(username);
            }

            if (password != null)
            {
                mWebCallEvent.QueryParams["password"] = KnetikClient.ParameterToString(password);
            }

            if (token != null)
            {
                mWebCallEvent.QueryParams["token"] = KnetikClient.ParameterToString(token);
            }

            if (refreshToken != null)
            {
                mWebCallEvent.QueryParams["refresh_token"] = KnetikClient.ParameterToString(refreshToken);
            }

            // make the HTTP request
            mGetOAuthTokenStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetOAuthTokenResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mGetOAuthTokenStartTime, "GetOAuthToken", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetOAuthTokenResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetOAuthToken: " + response.Error);
            }

            GetOAuthTokenData = (OAuth2Resource) KnetikClient.Deserialize(response.Content, typeof(OAuth2Resource), response.Headers);
            KnetikLogger.LogResponse(mGetOAuthTokenStartTime, "GetOAuthToken", string.Format("Response received successfully:\n{0}", GetOAuthTokenData));

            if (GetOAuthTokenComplete != null)
            {
                GetOAuthTokenComplete(response.ResponseCode, GetOAuthTokenData);
            }
        }

    }
}
