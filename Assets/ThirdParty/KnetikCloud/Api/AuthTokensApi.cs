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
    public interface IAuthTokensApi
    {
        

        /// <summary>
        /// Delete tokens by username, client id, or both 
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="clientId">The id of the client</param>
        void DeleteTokens(string username, string clientId);

        OauthAccessTokenResource GetTokenData { get; }

        /// <summary>
        /// Get a single token by username and client id 
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="clientId">The id of the client</param>
        void GetToken(string username, string clientId);

        PageResourceOauthAccessTokenResource GetTokensData { get; }

        /// <summary>
        /// List usernames and client ids Token value not shown
        /// </summary>
        /// <param name="filterClientId">Filters for token whose client id matches provided string</param>
        /// <param name="filterUsername">Filters for token whose username matches provided string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetTokens(string filterClientId, string filterUsername, int? size, int? page, string order);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthTokensApi : IAuthTokensApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mDeleteTokensResponseContext;
        private DateTime mDeleteTokensStartTime;
        private readonly KnetikResponseContext mGetTokenResponseContext;
        private DateTime mGetTokenStartTime;
        private readonly KnetikResponseContext mGetTokensResponseContext;
        private DateTime mGetTokensStartTime;

        public delegate void DeleteTokensCompleteDelegate(long responseCode);
        public DeleteTokensCompleteDelegate DeleteTokensComplete;

        public OauthAccessTokenResource GetTokenData { get; private set; }
        public delegate void GetTokenCompleteDelegate(long responseCode, OauthAccessTokenResource response);
        public GetTokenCompleteDelegate GetTokenComplete;

        public PageResourceOauthAccessTokenResource GetTokensData { get; private set; }
        public delegate void GetTokensCompleteDelegate(long responseCode, PageResourceOauthAccessTokenResource response);
        public GetTokensCompleteDelegate GetTokensComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthTokensApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthTokensApi()
        {
            mDeleteTokensResponseContext = new KnetikResponseContext();
            mDeleteTokensResponseContext.ResponseReceived += OnDeleteTokensResponse;
            mGetTokenResponseContext = new KnetikResponseContext();
            mGetTokenResponseContext.ResponseReceived += OnGetTokenResponse;
            mGetTokensResponseContext = new KnetikResponseContext();
            mGetTokensResponseContext.ResponseReceived += OnGetTokensResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Delete tokens by username, client id, or both 
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="clientId">The id of the client</param>
        public void DeleteTokens(string username, string clientId)
        {
            
            mWebCallEvent.WebPath = "/auth/tokens";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (username != null)
            {
                mWebCallEvent.QueryParams["username"] = KnetikClient.ParameterToString(username);
            }

            if (clientId != null)
            {
                mWebCallEvent.QueryParams["client_id"] = KnetikClient.ParameterToString(clientId);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteTokensStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteTokensResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteTokensStartTime, "DeleteTokens", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteTokensResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteTokens: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteTokensStartTime, "DeleteTokens", "Response received successfully.");
            if (DeleteTokensComplete != null)
            {
                DeleteTokensComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single token by username and client id 
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="clientId">The id of the client</param>
        public void GetToken(string username, string clientId)
        {
            // verify the required parameter 'username' is set
            if (username == null)
            {
                throw new KnetikException(400, "Missing required parameter 'username' when calling GetToken");
            }
            // verify the required parameter 'clientId' is set
            if (clientId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientId' when calling GetToken");
            }
            
            mWebCallEvent.WebPath = "/auth/tokens/{username}/{client_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "username" + "}", KnetikClient.ParameterToString(username));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "client_id" + "}", KnetikClient.ParameterToString(clientId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetTokenStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetTokenResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetTokenStartTime, "GetToken", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetTokenResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetToken: " + response.Error);
            }

            GetTokenData = (OauthAccessTokenResource) KnetikClient.Deserialize(response.Content, typeof(OauthAccessTokenResource), response.Headers);
            KnetikLogger.LogResponse(mGetTokenStartTime, "GetToken", string.Format("Response received successfully:\n{0}", GetTokenData));

            if (GetTokenComplete != null)
            {
                GetTokenComplete(response.ResponseCode, GetTokenData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List usernames and client ids Token value not shown
        /// </summary>
        /// <param name="filterClientId">Filters for token whose client id matches provided string</param>
        /// <param name="filterUsername">Filters for token whose username matches provided string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetTokens(string filterClientId, string filterUsername, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/auth/tokens";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterClientId != null)
            {
                mWebCallEvent.QueryParams["filter_client_id"] = KnetikClient.ParameterToString(filterClientId);
            }

            if (filterUsername != null)
            {
                mWebCallEvent.QueryParams["filter_username"] = KnetikClient.ParameterToString(filterUsername);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (order != null)
            {
                mWebCallEvent.QueryParams["order"] = KnetikClient.ParameterToString(order);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetTokensStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetTokensResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetTokensStartTime, "GetTokens", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetTokensResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetTokens: " + response.Error);
            }

            GetTokensData = (PageResourceOauthAccessTokenResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceOauthAccessTokenResource), response.Headers);
            KnetikLogger.LogResponse(mGetTokensStartTime, "GetTokens", string.Format("Response received successfully:\n{0}", GetTokensData));

            if (GetTokensComplete != null)
            {
                GetTokensComplete(response.ResponseCode, GetTokensData);
            }
        }

    }
}
