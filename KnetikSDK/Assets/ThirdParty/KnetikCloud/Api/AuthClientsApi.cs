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
    public interface IAuthClientsApi
    {
        /// <summary>
        /// Create a new client 
        /// </summary>
        /// <param name="clientResource">The client resource object</param>
        /// <returns>ClientResource</returns>
        ClientResource CreateClient (ClientResource clientResource);
        /// <summary>
        /// Delete a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        /// <returns></returns>
        void DeleteClient (string clientKey);
        /// <summary>
        /// Get a single client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        /// <returns>ClientResource</returns>
        ClientResource GetClient (string clientKey);
        /// <summary>
        /// List available client grant types 
        /// </summary>
        /// <returns>List&lt;GrantTypeResource&gt;</returns>
        List<GrantTypeResource> GetClientGrantTypes ();
        /// <summary>
        /// List and search clients 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceClientResource</returns>
        PageResourceClientResource GetClients (int? size, int? page, string order);
        /// <summary>
        /// Set grant types for a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        /// <param name="grantList">A list of unique grant types</param>
        /// <returns></returns>
        void SetClientGrantTypes (string clientKey, List<string> grantList);
        /// <summary>
        /// Set redirect uris for a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        /// <param name="redirectList">A list of unique redirect uris</param>
        /// <returns></returns>
        void SetClientRedirectUris (string clientKey, List<string> redirectList);
        /// <summary>
        /// Update a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        /// <param name="clientResource">The client resource object</param>
        /// <returns>ClientResource</returns>
        ClientResource UpdateClient (string clientKey, ClientResource clientResource);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthClientsApi : IAuthClientsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthClientsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthClientsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a new client 
        /// </summary>
        /// <param name="clientResource">The client resource object</param> 
        /// <returns>ClientResource</returns>            
        public ClientResource CreateClient(ClientResource clientResource)
        {
            
            string urlPath = "/auth/clients";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(clientResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateClient: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateClient: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ClientResource) KnetikClient.Deserialize(response.Content, typeof(ClientResource), response.Headers);
        }
        /// <summary>
        /// Delete a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param> 
        /// <returns></returns>            
        public void DeleteClient(string clientKey)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling DeleteClient");
            }
            
            
            string urlPath = "/auth/clients/{client_key}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteClient: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteClient: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get a single client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param> 
        /// <returns>ClientResource</returns>            
        public ClientResource GetClient(string clientKey)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling GetClient");
            }
            
            
            string urlPath = "/auth/clients/{client_key}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetClient: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetClient: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ClientResource) KnetikClient.Deserialize(response.Content, typeof(ClientResource), response.Headers);
        }
        /// <summary>
        /// List available client grant types 
        /// </summary>
        /// <returns>List&lt;GrantTypeResource&gt;</returns>            
        public List<GrantTypeResource> GetClientGrantTypes()
        {
            
            string urlPath = "/auth/clients/grant-types";
            //urlPath = urlPath.Replace("{format}", "json");
                
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetClientGrantTypes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetClientGrantTypes: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<GrantTypeResource>) KnetikClient.Deserialize(response.Content, typeof(List<GrantTypeResource>), response.Headers);
        }
        /// <summary>
        /// List and search clients 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceClientResource</returns>            
        public PageResourceClientResource GetClients(int? size, int? page, string order)
        {
            
            string urlPath = "/auth/clients";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetClients: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetClients: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceClientResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceClientResource), response.Headers);
        }
        /// <summary>
        /// Set grant types for a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param> 
        /// <param name="grantList">A list of unique grant types</param> 
        /// <returns></returns>            
        public void SetClientGrantTypes(string clientKey, List<string> grantList)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling SetClientGrantTypes");
            }
            
            
            string urlPath = "/auth/clients/{client_key}/grant-types";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(grantList); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetClientGrantTypes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetClientGrantTypes: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Set redirect uris for a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param> 
        /// <param name="redirectList">A list of unique redirect uris</param> 
        /// <returns></returns>            
        public void SetClientRedirectUris(string clientKey, List<string> redirectList)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling SetClientRedirectUris");
            }
            
            
            string urlPath = "/auth/clients/{client_key}/redirect-uris";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(redirectList); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetClientRedirectUris: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetClientRedirectUris: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Update a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param> 
        /// <param name="clientResource">The client resource object</param> 
        /// <returns>ClientResource</returns>            
        public ClientResource UpdateClient(string clientKey, ClientResource clientResource)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling UpdateClient");
            }
            
            
            string urlPath = "/auth/clients/{client_key}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(clientResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateClient: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateClient: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ClientResource) KnetikClient.Deserialize(response.Content, typeof(ClientResource), response.Headers);
        }
    }
}
