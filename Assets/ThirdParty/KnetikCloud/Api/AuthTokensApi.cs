using System;
using System.Collections.Generic;
using RestSharp;
using com.knetikcloud.Client;
using com.knetikcloud.Model;
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
        /// <summary>
        /// Delete tokens by username, client id, or both 
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="clientId">The id of the client</param>
        /// <returns></returns>
        void DeleteTokens (string username, string clientId);
        /// <summary>
        /// Get a single token by username and client id 
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="clientId">The id of the client</param>
        /// <returns>OauthAccessTokenResource</returns>
        OauthAccessTokenResource GetToken (string username, string clientId);
        /// <summary>
        /// List usernames and client ids Token value not shown
        /// </summary>
        /// <param name="filterClientId">Filters for token whose client id matches provided string</param>
        /// <param name="filterUsername">Filters for token whose username matches provided string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceOauthAccessTokenResource</returns>
        PageResourceOauthAccessTokenResource GetTokens (string filterClientId, string filterUsername, int? size, int? page, string order);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthTokensApi : IAuthTokensApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthTokensApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthTokensApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Delete tokens by username, client id, or both 
        /// </summary>
        /// <param name="username">The username of the user</param> 
        /// <param name="clientId">The id of the client</param> 
        /// <returns></returns>            
        public void DeleteTokens(string username, string clientId)
        {
            
            string urlPath = "/auth/tokens";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (username != null)
            {
                queryParams.Add("username", KnetikClient.ParameterToString(username));
            }
            
            if (clientId != null)
            {
                queryParams.Add("client_id", KnetikClient.ParameterToString(clientId));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteTokens: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteTokens: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get a single token by username and client id 
        /// </summary>
        /// <param name="username">The username of the user</param> 
        /// <param name="clientId">The id of the client</param> 
        /// <returns>OauthAccessTokenResource</returns>            
        public OauthAccessTokenResource GetToken(string username, string clientId)
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
            
            
            string urlPath = "/auth/tokens/{username}/{client_id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "username" + "}", KnetikClient.ParameterToString(username));
urlPath = urlPath.Replace("{" + "client_id" + "}", KnetikClient.ParameterToString(clientId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetToken: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetToken: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (OauthAccessTokenResource) KnetikClient.Deserialize(response.Content, typeof(OauthAccessTokenResource), response.Headers);
        }
        /// <summary>
        /// List usernames and client ids Token value not shown
        /// </summary>
        /// <param name="filterClientId">Filters for token whose client id matches provided string</param> 
        /// <param name="filterUsername">Filters for token whose username matches provided string</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceOauthAccessTokenResource</returns>            
        public PageResourceOauthAccessTokenResource GetTokens(string filterClientId, string filterUsername, int? size, int? page, string order)
        {
            
            string urlPath = "/auth/tokens";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterClientId != null)
            {
                queryParams.Add("filter_client_id", KnetikClient.ParameterToString(filterClientId));
            }
            
            if (filterUsername != null)
            {
                queryParams.Add("filter_username", KnetikClient.ParameterToString(filterUsername));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetTokens: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetTokens: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceOauthAccessTokenResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceOauthAccessTokenResource), response.Headers);
        }
    }
}
