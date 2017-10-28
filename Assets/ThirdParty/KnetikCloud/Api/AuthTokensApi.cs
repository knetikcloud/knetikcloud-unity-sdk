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
    public interface IAuthTokensApi
    {
        OauthAccessTokenResource GetTokenData { get; }

        PageResourceOauthAccessTokenResource GetTokensData { get; }

        
        /// <summary>
        /// Delete tokens by username, client id, or both 
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="clientId">The id of the client</param>
        void DeleteTokens(string username, string clientId);

        /// <summary>
        /// Get a single token by username and client id 
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="clientId">The id of the client</param>
        void GetToken(string username, string clientId);

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
        private readonly KnetikCoroutine mDeleteTokensCoroutine;
        private DateTime mDeleteTokensStartTime;
        private string mDeleteTokensPath;
        private readonly KnetikCoroutine mGetTokenCoroutine;
        private DateTime mGetTokenStartTime;
        private string mGetTokenPath;
        private readonly KnetikCoroutine mGetTokensCoroutine;
        private DateTime mGetTokensStartTime;
        private string mGetTokensPath;

        public delegate void DeleteTokensCompleteDelegate();
        public DeleteTokensCompleteDelegate DeleteTokensComplete;

        public OauthAccessTokenResource GetTokenData { get; private set; }
        public delegate void GetTokenCompleteDelegate(OauthAccessTokenResource response);
        public GetTokenCompleteDelegate GetTokenComplete;

        public PageResourceOauthAccessTokenResource GetTokensData { get; private set; }
        public delegate void GetTokensCompleteDelegate(PageResourceOauthAccessTokenResource response);
        public GetTokensCompleteDelegate GetTokensComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthTokensApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthTokensApi()
        {
            mDeleteTokensCoroutine = new KnetikCoroutine();
            mGetTokenCoroutine = new KnetikCoroutine();
            mGetTokensCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Delete tokens by username, client id, or both 
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="clientId">The id of the client</param>
        public void DeleteTokens(string username, string clientId)
        {
            
            mDeleteTokensPath = "/auth/tokens";
            if (!string.IsNullOrEmpty(mDeleteTokensPath))
            {
                mDeleteTokensPath = mDeleteTokensPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (username != null)
            {
                queryParams.Add("username", KnetikClient.DefaultClient.ParameterToString(username));
            }

            if (clientId != null)
            {
                queryParams.Add("client_id", KnetikClient.DefaultClient.ParameterToString(clientId));
            }

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteTokensStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteTokensStartTime, mDeleteTokensPath, "Sending server request...");

            // make the HTTP request
            mDeleteTokensCoroutine.ResponseReceived += DeleteTokensCallback;
            mDeleteTokensCoroutine.Start(mDeleteTokensPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteTokensCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteTokens: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteTokens: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteTokensStartTime, mDeleteTokensPath, "Response received successfully.");
            if (DeleteTokensComplete != null)
            {
                DeleteTokensComplete();
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
            
            mGetTokenPath = "/auth/tokens/{username}/{client_id}";
            if (!string.IsNullOrEmpty(mGetTokenPath))
            {
                mGetTokenPath = mGetTokenPath.Replace("{format}", "json");
            }
            mGetTokenPath = mGetTokenPath.Replace("{" + "username" + "}", KnetikClient.DefaultClient.ParameterToString(username));
mGetTokenPath = mGetTokenPath.Replace("{" + "client_id" + "}", KnetikClient.DefaultClient.ParameterToString(clientId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetTokenStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetTokenStartTime, mGetTokenPath, "Sending server request...");

            // make the HTTP request
            mGetTokenCoroutine.ResponseReceived += GetTokenCallback;
            mGetTokenCoroutine.Start(mGetTokenPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetTokenCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetToken: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetToken: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetTokenData = (OauthAccessTokenResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(OauthAccessTokenResource), response.Headers);
            KnetikLogger.LogResponse(mGetTokenStartTime, mGetTokenPath, string.Format("Response received successfully:\n{0}", GetTokenData.ToString()));

            if (GetTokenComplete != null)
            {
                GetTokenComplete(GetTokenData);
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
            
            mGetTokensPath = "/auth/tokens";
            if (!string.IsNullOrEmpty(mGetTokensPath))
            {
                mGetTokensPath = mGetTokensPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterClientId != null)
            {
                queryParams.Add("filter_client_id", KnetikClient.DefaultClient.ParameterToString(filterClientId));
            }

            if (filterUsername != null)
            {
                queryParams.Add("filter_username", KnetikClient.DefaultClient.ParameterToString(filterUsername));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.DefaultClient.ParameterToString(order));
            }

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetTokensStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetTokensStartTime, mGetTokensPath, "Sending server request...");

            // make the HTTP request
            mGetTokensCoroutine.ResponseReceived += GetTokensCallback;
            mGetTokensCoroutine.Start(mGetTokensPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetTokensCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetTokens: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetTokens: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetTokensData = (PageResourceOauthAccessTokenResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceOauthAccessTokenResource), response.Headers);
            KnetikLogger.LogResponse(mGetTokensStartTime, mGetTokensPath, string.Format("Response received successfully:\n{0}", GetTokensData.ToString()));

            if (GetTokensComplete != null)
            {
                GetTokensComplete(GetTokensData);
            }
        }

    }
}
