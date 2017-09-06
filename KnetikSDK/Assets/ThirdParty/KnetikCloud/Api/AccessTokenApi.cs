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
    public interface IAccessTokenApi
    {
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
        /// <returns>OAuth2Resource</returns>
        OAuth2Resource GetOAuthToken (string grantType, string clientId, string clientSecret, string username, string password, string token, string refreshToken);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AccessTokenApi : IAccessTokenApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AccessTokenApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

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
        /// <returns>OAuth2Resource</returns>            
        public OAuth2Resource GetOAuthToken(string grantType, string clientId, string clientSecret, string username, string password, string token, string refreshToken)
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
            
            
            string urlPath = "/oauth/token";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (grantType != null)
            {
                formParams.Add("grant_type", KnetikClient.ParameterToString(grantType)); // form parameter
            }			

            if (clientId != null)
            {
                formParams.Add("client_id", KnetikClient.ParameterToString(clientId)); // form parameter
            }			

            if (clientSecret != null)
            {
                formParams.Add("client_secret", KnetikClient.ParameterToString(clientSecret)); // form parameter
            }			

            if (username != null)
            {
                formParams.Add("username", KnetikClient.ParameterToString(username)); // form parameter
            }			

            if (password != null)
            {
                formParams.Add("password", KnetikClient.ParameterToString(password)); // form parameter
            }			

            if (token != null)
            {
                formParams.Add("token", KnetikClient.ParameterToString(token)); // form parameter
            }			

            if (refreshToken != null)
            {
                formParams.Add("refresh_token", KnetikClient.ParameterToString(refreshToken)); // form parameter
            }			

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetOAuthToken: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetOAuthToken: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (OAuth2Resource) KnetikClient.Deserialize(response.Content, typeof(OAuth2Resource), response.Headers);
        }
    }
}
