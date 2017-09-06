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
    public interface IConfigsApi
    {
        /// <summary>
        /// Create a new config 
        /// </summary>
        /// <param name="config">The config object</param>
        /// <returns>Config</returns>
        Config CreateConfig (Config config);
        /// <summary>
        /// Delete an existing config 
        /// </summary>
        /// <param name="name">The config name</param>
        /// <returns></returns>
        void DeleteConfig (string name);
        /// <summary>
        /// Get a single config Only configs that are public readable will be shown without admin access
        /// </summary>
        /// <param name="name">The config name</param>
        /// <returns>Config</returns>
        Config GetConfig (string name);
        /// <summary>
        /// List and search configs 
        /// </summary>
        /// <param name="filterSearch">Filter for configs whose name contains the given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceConfig</returns>
        PageResourceConfig GetConfigs (string filterSearch, int? size, int? page, string order);
        /// <summary>
        /// Update an existing config 
        /// </summary>
        /// <param name="name">The config name</param>
        /// <param name="config">The config object</param>
        /// <returns></returns>
        void UpdateConfig (string name, Config config);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ConfigsApi : IConfigsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ConfigsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a new config 
        /// </summary>
        /// <param name="config">The config object</param> 
        /// <returns>Config</returns>            
        public Config CreateConfig(Config config)
        {
            
            string urlPath = "/configs";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(config); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateConfig: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateConfig: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (Config) KnetikClient.Deserialize(response.Content, typeof(Config), response.Headers);
        }
        /// <summary>
        /// Delete an existing config 
        /// </summary>
        /// <param name="name">The config name</param> 
        /// <returns></returns>            
        public void DeleteConfig(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling DeleteConfig");
            }
            
            
            string urlPath = "/configs/{name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteConfig: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteConfig: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get a single config Only configs that are public readable will be shown without admin access
        /// </summary>
        /// <param name="name">The config name</param> 
        /// <returns>Config</returns>            
        public Config GetConfig(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetConfig");
            }
            
            
            string urlPath = "/configs/{name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetConfig: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetConfig: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (Config) KnetikClient.Deserialize(response.Content, typeof(Config), response.Headers);
        }
        /// <summary>
        /// List and search configs 
        /// </summary>
        /// <param name="filterSearch">Filter for configs whose name contains the given string</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceConfig</returns>            
        public PageResourceConfig GetConfigs(string filterSearch, int? size, int? page, string order)
        {
            
            string urlPath = "/configs";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.ParameterToString(filterSearch));
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
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetConfigs: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetConfigs: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceConfig) KnetikClient.Deserialize(response.Content, typeof(PageResourceConfig), response.Headers);
        }
        /// <summary>
        /// Update an existing config 
        /// </summary>
        /// <param name="name">The config name</param> 
        /// <param name="config">The config object</param> 
        /// <returns></returns>            
        public void UpdateConfig(string name, Config config)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling UpdateConfig");
            }
            
            
            string urlPath = "/configs/{name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(config); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateConfig: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateConfig: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
    }
}
