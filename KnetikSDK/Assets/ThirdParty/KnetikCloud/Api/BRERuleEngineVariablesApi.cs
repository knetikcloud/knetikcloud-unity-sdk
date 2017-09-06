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
    public interface IBRERuleEngineVariablesApi
    {
        /// <summary>
        /// Get a list of variable types available Types include integer, string, user and invoice. These are used to qualify trigger parameters and action variables with strong typing.
        /// </summary>
        /// <returns>List&lt;VariableTypeResource&gt;</returns>
        List<VariableTypeResource> GetBREVariableTypes ();
        /// <summary>
        /// List valid values for a type Used to lookup users to fill in a user constant for example. Only types marked as enumerable are suppoorted here.
        /// </summary>
        /// <param name="name">The name of the type</param>
        /// <param name="filterName">Filter results by those with names starting with this string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceSimpleReferenceResourceobject</returns>
        PageResourceSimpleReferenceResourceobject GetBREVariableValues (string name, string filterName, int? size, int? page);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineVariablesApi : IBRERuleEngineVariablesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineVariablesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineVariablesApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Get a list of variable types available Types include integer, string, user and invoice. These are used to qualify trigger parameters and action variables with strong typing.
        /// </summary>
        /// <returns>List&lt;VariableTypeResource&gt;</returns>            
        public List<VariableTypeResource> GetBREVariableTypes()
        {
            
            string urlPath = "/bre/variable-types";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBREVariableTypes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBREVariableTypes: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<VariableTypeResource>) KnetikClient.Deserialize(response.Content, typeof(List<VariableTypeResource>), response.Headers);
        }
        /// <summary>
        /// List valid values for a type Used to lookup users to fill in a user constant for example. Only types marked as enumerable are suppoorted here.
        /// </summary>
        /// <param name="name">The name of the type</param> 
        /// <param name="filterName">Filter results by those with names starting with this string</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceSimpleReferenceResourceobject</returns>            
        public PageResourceSimpleReferenceResourceobject GetBREVariableValues(string name, string filterName, int? size, int? page)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetBREVariableValues");
            }
            
            
            string urlPath = "/bre/variable-types/{name}/values";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.ParameterToString(filterName));
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBREVariableValues: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBREVariableValues: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceSimpleReferenceResourceobject) KnetikClient.Deserialize(response.Content, typeof(PageResourceSimpleReferenceResourceobject), response.Headers);
        }
    }
}
