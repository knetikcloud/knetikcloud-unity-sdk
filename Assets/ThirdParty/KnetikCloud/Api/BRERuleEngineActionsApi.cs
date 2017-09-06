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
    public interface IBRERuleEngineActionsApi
    {
        /// <summary>
        /// Get a list of available actions 
        /// </summary>
        /// <param name="filterCategory">Filter for actions that are within a specific category</param>
        /// <param name="filterName">Filter for actions that have names containing the given string</param>
        /// <param name="filterTags">Filter for actions that have all of the given tags (comma separated list)</param>
        /// <param name="filterSearch">Filter for actions containing the given words somewhere within name, description and tags</param>
        /// <returns>List&lt;ActionResource&gt;</returns>
        List<ActionResource> GetBREActions (string filterCategory, string filterName, string filterTags, string filterSearch);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineActionsApi : IBRERuleEngineActionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineActionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineActionsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Get a list of available actions 
        /// </summary>
        /// <param name="filterCategory">Filter for actions that are within a specific category</param> 
        /// <param name="filterName">Filter for actions that have names containing the given string</param> 
        /// <param name="filterTags">Filter for actions that have all of the given tags (comma separated list)</param> 
        /// <param name="filterSearch">Filter for actions containing the given words somewhere within name, description and tags</param> 
        /// <returns>List&lt;ActionResource&gt;</returns>            
        public List<ActionResource> GetBREActions(string filterCategory, string filterName, string filterTags, string filterSearch)
        {
            
            string urlPath = "/bre/actions";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.ParameterToString(filterCategory));
            }
            
            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.ParameterToString(filterName));
            }
            
            if (filterTags != null)
            {
                queryParams.Add("filter_tags", KnetikClient.ParameterToString(filterTags));
            }
            
            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.ParameterToString(filterSearch));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBREActions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBREActions: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<ActionResource>) KnetikClient.Deserialize(response.Content, typeof(List<ActionResource>), response.Headers);
        }
    }
}
