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
    public interface IBRERuleEngineTriggersApi
    {
        /// <summary>
        /// Create a trigger Customer added triggers will not be fired automatically or have rules associated with them by default. Custom rules must be added to get use from the trigger and it must then be fired from the outside. See the Bre Event services
        /// </summary>
        /// <param name="breTriggerResource">The BRE trigger resource object</param>
        /// <returns>BreTriggerResource</returns>
        BreTriggerResource CreateBRETrigger (BreTriggerResource breTriggerResource);
        /// <summary>
        /// Delete a trigger May fail if there are existing rules against it. Cannot delete core triggers
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        /// <returns></returns>
        void DeleteBRETrigger (string eventName);
        /// <summary>
        /// Get a single trigger 
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        /// <returns>BreTriggerResource</returns>
        BreTriggerResource GetBRETrigger (string eventName);
        /// <summary>
        /// List triggers 
        /// </summary>
        /// <param name="filterSystem">Filter for triggers that are system triggers when true, or not when false. Leave off for both mixed</param>
        /// <param name="filterCategory">Filter for triggers that are within a specific category</param>
        /// <param name="filterTags">Filter for triggers that have all of the given tags (comma separated list)</param>
        /// <param name="filterName">Filter for triggers that have names containing the given string</param>
        /// <param name="filterSearch">Filter for triggers containing the given words somewhere within name, description and tags</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceBreTriggerResource</returns>
        PageResourceBreTriggerResource GetBRETriggers (bool? filterSystem, string filterCategory, string filterTags, string filterName, string filterSearch, int? size, int? page);
        /// <summary>
        /// Update a trigger May fail if new parameters mismatch requirements of existing rules. Cannot update core triggers
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        /// <param name="breTriggerResource">The BRE trigger resource object</param>
        /// <returns>BreTriggerResource</returns>
        BreTriggerResource UpdateBRETrigger (string eventName, BreTriggerResource breTriggerResource);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineTriggersApi : IBRERuleEngineTriggersApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineTriggersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineTriggersApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a trigger Customer added triggers will not be fired automatically or have rules associated with them by default. Custom rules must be added to get use from the trigger and it must then be fired from the outside. See the Bre Event services
        /// </summary>
        /// <param name="breTriggerResource">The BRE trigger resource object</param> 
        /// <returns>BreTriggerResource</returns>            
        public BreTriggerResource CreateBRETrigger(BreTriggerResource breTriggerResource)
        {
            
            string urlPath = "/bre/triggers";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(breTriggerResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateBRETrigger: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateBRETrigger: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (BreTriggerResource) KnetikClient.Deserialize(response.Content, typeof(BreTriggerResource), response.Headers);
        }
        /// <summary>
        /// Delete a trigger May fail if there are existing rules against it. Cannot delete core triggers
        /// </summary>
        /// <param name="eventName">The trigger event name</param> 
        /// <returns></returns>            
        public void DeleteBRETrigger(string eventName)
        {
            // verify the required parameter 'eventName' is set
            if (eventName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'eventName' when calling DeleteBRETrigger");
            }
            
            
            string urlPath = "/bre/triggers/{event_name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "event_name" + "}", KnetikClient.ParameterToString(eventName));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteBRETrigger: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteBRETrigger: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get a single trigger 
        /// </summary>
        /// <param name="eventName">The trigger event name</param> 
        /// <returns>BreTriggerResource</returns>            
        public BreTriggerResource GetBRETrigger(string eventName)
        {
            // verify the required parameter 'eventName' is set
            if (eventName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'eventName' when calling GetBRETrigger");
            }
            
            
            string urlPath = "/bre/triggers/{event_name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "event_name" + "}", KnetikClient.ParameterToString(eventName));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBRETrigger: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBRETrigger: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (BreTriggerResource) KnetikClient.Deserialize(response.Content, typeof(BreTriggerResource), response.Headers);
        }
        /// <summary>
        /// List triggers 
        /// </summary>
        /// <param name="filterSystem">Filter for triggers that are system triggers when true, or not when false. Leave off for both mixed</param> 
        /// <param name="filterCategory">Filter for triggers that are within a specific category</param> 
        /// <param name="filterTags">Filter for triggers that have all of the given tags (comma separated list)</param> 
        /// <param name="filterName">Filter for triggers that have names containing the given string</param> 
        /// <param name="filterSearch">Filter for triggers containing the given words somewhere within name, description and tags</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceBreTriggerResource</returns>            
        public PageResourceBreTriggerResource GetBRETriggers(bool? filterSystem, string filterCategory, string filterTags, string filterName, string filterSearch, int? size, int? page)
        {
            
            string urlPath = "/bre/triggers";
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
            
            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.ParameterToString(filterCategory));
            }
            
            if (filterTags != null)
            {
                queryParams.Add("filter_tags", KnetikClient.ParameterToString(filterTags));
            }
            
            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.ParameterToString(filterName));
            }
            
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
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBRETriggers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBRETriggers: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceBreTriggerResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceBreTriggerResource), response.Headers);
        }
        /// <summary>
        /// Update a trigger May fail if new parameters mismatch requirements of existing rules. Cannot update core triggers
        /// </summary>
        /// <param name="eventName">The trigger event name</param> 
        /// <param name="breTriggerResource">The BRE trigger resource object</param> 
        /// <returns>BreTriggerResource</returns>            
        public BreTriggerResource UpdateBRETrigger(string eventName, BreTriggerResource breTriggerResource)
        {
            // verify the required parameter 'eventName' is set
            if (eventName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'eventName' when calling UpdateBRETrigger");
            }
            
            
            string urlPath = "/bre/triggers/{event_name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "event_name" + "}", KnetikClient.ParameterToString(eventName));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(breTriggerResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateBRETrigger: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateBRETrigger: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (BreTriggerResource) KnetikClient.Deserialize(response.Content, typeof(BreTriggerResource), response.Headers);
        }
    }
}
