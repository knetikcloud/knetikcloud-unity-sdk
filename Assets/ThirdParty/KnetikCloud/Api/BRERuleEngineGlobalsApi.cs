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
    public interface IBRERuleEngineGlobalsApi
    {
        /// <summary>
        /// Create a global definition Once created you can then use in a custom rule. Note that global definitions cannot be modified or deleted if in use.
        /// </summary>
        /// <param name="breGlobalResource">The BRE global resource object</param>
        /// <returns>BreGlobalResource</returns>
        BreGlobalResource CreateBREGlobal (BreGlobalResource breGlobalResource);
        /// <summary>
        /// Delete a global May fail if there are existing rules against it. Cannot delete core globals
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        /// <returns></returns>
        void DeleteBREGlobal (string id);
        /// <summary>
        /// Get a single global definition 
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        /// <returns>BreGlobalResource</returns>
        BreGlobalResource GetBREGlobal (string id);
        /// <summary>
        /// List global definitions 
        /// </summary>
        /// <param name="filterSystem">Filter for globals that are system globals when true, or not when false. Leave off for both mixed</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceBreGlobalResource</returns>
        PageResourceBreGlobalResource GetBREGlobals (bool? filterSystem, int? size, int? page);
        /// <summary>
        /// Update a global definition May fail if new parameters mismatch requirements of existing rules. Cannot update core globals
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        /// <param name="breGlobalResource">The BRE global resource object</param>
        /// <returns>BreGlobalResource</returns>
        BreGlobalResource UpdateBREGlobal (string id, BreGlobalResource breGlobalResource);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineGlobalsApi : IBRERuleEngineGlobalsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineGlobalsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineGlobalsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a global definition Once created you can then use in a custom rule. Note that global definitions cannot be modified or deleted if in use.
        /// </summary>
        /// <param name="breGlobalResource">The BRE global resource object</param> 
        /// <returns>BreGlobalResource</returns>            
        public BreGlobalResource CreateBREGlobal(BreGlobalResource breGlobalResource)
        {
            
            string urlPath = "/bre/globals/definitions";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(breGlobalResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateBREGlobal: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateBREGlobal: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (BreGlobalResource) KnetikClient.Deserialize(response.Content, typeof(BreGlobalResource), response.Headers);
        }
        /// <summary>
        /// Delete a global May fail if there are existing rules against it. Cannot delete core globals
        /// </summary>
        /// <param name="id">The id of the global definition</param> 
        /// <returns></returns>            
        public void DeleteBREGlobal(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteBREGlobal");
            }
            
            
            string urlPath = "/bre/globals/definitions/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteBREGlobal: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteBREGlobal: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get a single global definition 
        /// </summary>
        /// <param name="id">The id of the global definition</param> 
        /// <returns>BreGlobalResource</returns>            
        public BreGlobalResource GetBREGlobal(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBREGlobal");
            }
            
            
            string urlPath = "/bre/globals/definitions/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBREGlobal: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBREGlobal: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (BreGlobalResource) KnetikClient.Deserialize(response.Content, typeof(BreGlobalResource), response.Headers);
        }
        /// <summary>
        /// List global definitions 
        /// </summary>
        /// <param name="filterSystem">Filter for globals that are system globals when true, or not when false. Leave off for both mixed</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceBreGlobalResource</returns>            
        public PageResourceBreGlobalResource GetBREGlobals(bool? filterSystem, int? size, int? page)
        {
            
            string urlPath = "/bre/globals/definitions";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterSystem != null)
            {
                queryParams.Add("filter_system", KnetikClient.ParameterToString(filterSystem));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBREGlobals: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBREGlobals: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceBreGlobalResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceBreGlobalResource), response.Headers);
        }
        /// <summary>
        /// Update a global definition May fail if new parameters mismatch requirements of existing rules. Cannot update core globals
        /// </summary>
        /// <param name="id">The id of the global definition</param> 
        /// <param name="breGlobalResource">The BRE global resource object</param> 
        /// <returns>BreGlobalResource</returns>            
        public BreGlobalResource UpdateBREGlobal(string id, BreGlobalResource breGlobalResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateBREGlobal");
            }
            
            
            string urlPath = "/bre/globals/definitions/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(breGlobalResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateBREGlobal: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateBREGlobal: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (BreGlobalResource) KnetikClient.Deserialize(response.Content, typeof(BreGlobalResource), response.Headers);
        }
    }
}
