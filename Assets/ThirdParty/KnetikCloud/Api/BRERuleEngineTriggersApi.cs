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
    public interface IBRERuleEngineTriggersApi
    {
        BreTriggerResource CreateBRETriggerData { get; }

        BreTriggerResource GetBRETriggerData { get; }

        PageResourceBreTriggerResource GetBRETriggersData { get; }

        BreTriggerResource UpdateBRETriggerData { get; }

        
        /// <summary>
        /// Create a trigger Customer added triggers will not be fired automatically or have rules associated with them by default. Custom rules must be added to get use from the trigger and it must then be fired from the outside. See the Bre Event services
        /// </summary>
        /// <param name="breTriggerResource">The BRE trigger resource object</param>
        void CreateBRETrigger(BreTriggerResource breTriggerResource);

        /// <summary>
        /// Delete a trigger May fail if there are existing rules against it. Cannot delete core triggers
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        void DeleteBRETrigger(string eventName);

        /// <summary>
        /// Get a single trigger 
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        void GetBRETrigger(string eventName);

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
        void GetBRETriggers(bool? filterSystem, string filterCategory, string filterTags, string filterName, string filterSearch, int? size, int? page);

        /// <summary>
        /// Update a trigger May fail if new parameters mismatch requirements of existing rules. Cannot update core triggers
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        /// <param name="breTriggerResource">The BRE trigger resource object</param>
        void UpdateBRETrigger(string eventName, BreTriggerResource breTriggerResource);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineTriggersApi : IBRERuleEngineTriggersApi
    {
        private readonly KnetikCoroutine mCreateBRETriggerCoroutine;
        private DateTime mCreateBRETriggerStartTime;
        private string mCreateBRETriggerPath;
        private readonly KnetikCoroutine mDeleteBRETriggerCoroutine;
        private DateTime mDeleteBRETriggerStartTime;
        private string mDeleteBRETriggerPath;
        private readonly KnetikCoroutine mGetBRETriggerCoroutine;
        private DateTime mGetBRETriggerStartTime;
        private string mGetBRETriggerPath;
        private readonly KnetikCoroutine mGetBRETriggersCoroutine;
        private DateTime mGetBRETriggersStartTime;
        private string mGetBRETriggersPath;
        private readonly KnetikCoroutine mUpdateBRETriggerCoroutine;
        private DateTime mUpdateBRETriggerStartTime;
        private string mUpdateBRETriggerPath;

        public BreTriggerResource CreateBRETriggerData { get; private set; }
        public delegate void CreateBRETriggerCompleteDelegate(BreTriggerResource response);
        public CreateBRETriggerCompleteDelegate CreateBRETriggerComplete;

        public delegate void DeleteBRETriggerCompleteDelegate();
        public DeleteBRETriggerCompleteDelegate DeleteBRETriggerComplete;

        public BreTriggerResource GetBRETriggerData { get; private set; }
        public delegate void GetBRETriggerCompleteDelegate(BreTriggerResource response);
        public GetBRETriggerCompleteDelegate GetBRETriggerComplete;

        public PageResourceBreTriggerResource GetBRETriggersData { get; private set; }
        public delegate void GetBRETriggersCompleteDelegate(PageResourceBreTriggerResource response);
        public GetBRETriggersCompleteDelegate GetBRETriggersComplete;

        public BreTriggerResource UpdateBRETriggerData { get; private set; }
        public delegate void UpdateBRETriggerCompleteDelegate(BreTriggerResource response);
        public UpdateBRETriggerCompleteDelegate UpdateBRETriggerComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineTriggersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineTriggersApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
            mCreateBRETriggerCoroutine = new KnetikCoroutine(KnetikClient);
            mDeleteBRETriggerCoroutine = new KnetikCoroutine(KnetikClient);
            mGetBRETriggerCoroutine = new KnetikCoroutine(KnetikClient);
            mGetBRETriggersCoroutine = new KnetikCoroutine(KnetikClient);
            mUpdateBRETriggerCoroutine = new KnetikCoroutine(KnetikClient);
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient { get; private set; }

        /// <summary>
        /// Create a trigger Customer added triggers will not be fired automatically or have rules associated with them by default. Custom rules must be added to get use from the trigger and it must then be fired from the outside. See the Bre Event services
        /// </summary>
        /// <param name="breTriggerResource">The BRE trigger resource object</param>
        public void CreateBRETrigger(BreTriggerResource breTriggerResource)
        {
            
            mCreateBRETriggerPath = "/bre/triggers";
            if (!string.IsNullOrEmpty(mCreateBRETriggerPath))
            {
                mCreateBRETriggerPath = mCreateBRETriggerPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(breTriggerResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateBRETriggerStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateBRETriggerStartTime, mCreateBRETriggerPath, "Sending server request...");

            // make the HTTP request
            mCreateBRETriggerCoroutine.ResponseReceived += CreateBRETriggerCallback;
            mCreateBRETriggerCoroutine.Start(mCreateBRETriggerPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateBRETriggerCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateBRETrigger: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateBRETrigger: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateBRETriggerData = (BreTriggerResource) KnetikClient.Deserialize(response.Content, typeof(BreTriggerResource), response.Headers);
            KnetikLogger.LogResponse(mCreateBRETriggerStartTime, mCreateBRETriggerPath, string.Format("Response received successfully:\n{0}", CreateBRETriggerData.ToString()));

            if (CreateBRETriggerComplete != null)
            {
                CreateBRETriggerComplete(CreateBRETriggerData);
            }
        }
        /// <summary>
        /// Delete a trigger May fail if there are existing rules against it. Cannot delete core triggers
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        public void DeleteBRETrigger(string eventName)
        {
            // verify the required parameter 'eventName' is set
            if (eventName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'eventName' when calling DeleteBRETrigger");
            }
            
            mDeleteBRETriggerPath = "/bre/triggers/{event_name}";
            if (!string.IsNullOrEmpty(mDeleteBRETriggerPath))
            {
                mDeleteBRETriggerPath = mDeleteBRETriggerPath.Replace("{format}", "json");
            }
            mDeleteBRETriggerPath = mDeleteBRETriggerPath.Replace("{" + "event_name" + "}", KnetikClient.ParameterToString(eventName));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteBRETriggerStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteBRETriggerStartTime, mDeleteBRETriggerPath, "Sending server request...");

            // make the HTTP request
            mDeleteBRETriggerCoroutine.ResponseReceived += DeleteBRETriggerCallback;
            mDeleteBRETriggerCoroutine.Start(mDeleteBRETriggerPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteBRETriggerCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteBRETrigger: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteBRETrigger: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteBRETriggerStartTime, mDeleteBRETriggerPath, "Response received successfully.");
            if (DeleteBRETriggerComplete != null)
            {
                DeleteBRETriggerComplete();
            }
        }
        /// <summary>
        /// Get a single trigger 
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        public void GetBRETrigger(string eventName)
        {
            // verify the required parameter 'eventName' is set
            if (eventName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'eventName' when calling GetBRETrigger");
            }
            
            mGetBRETriggerPath = "/bre/triggers/{event_name}";
            if (!string.IsNullOrEmpty(mGetBRETriggerPath))
            {
                mGetBRETriggerPath = mGetBRETriggerPath.Replace("{format}", "json");
            }
            mGetBRETriggerPath = mGetBRETriggerPath.Replace("{" + "event_name" + "}", KnetikClient.ParameterToString(eventName));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBRETriggerStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBRETriggerStartTime, mGetBRETriggerPath, "Sending server request...");

            // make the HTTP request
            mGetBRETriggerCoroutine.ResponseReceived += GetBRETriggerCallback;
            mGetBRETriggerCoroutine.Start(mGetBRETriggerPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBRETriggerCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRETrigger: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRETrigger: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBRETriggerData = (BreTriggerResource) KnetikClient.Deserialize(response.Content, typeof(BreTriggerResource), response.Headers);
            KnetikLogger.LogResponse(mGetBRETriggerStartTime, mGetBRETriggerPath, string.Format("Response received successfully:\n{0}", GetBRETriggerData.ToString()));

            if (GetBRETriggerComplete != null)
            {
                GetBRETriggerComplete(GetBRETriggerData);
            }
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
        public void GetBRETriggers(bool? filterSystem, string filterCategory, string filterTags, string filterName, string filterSearch, int? size, int? page)
        {
            
            mGetBRETriggersPath = "/bre/triggers";
            if (!string.IsNullOrEmpty(mGetBRETriggersPath))
            {
                mGetBRETriggersPath = mGetBRETriggersPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBRETriggersStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBRETriggersStartTime, mGetBRETriggersPath, "Sending server request...");

            // make the HTTP request
            mGetBRETriggersCoroutine.ResponseReceived += GetBRETriggersCallback;
            mGetBRETriggersCoroutine.Start(mGetBRETriggersPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBRETriggersCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRETriggers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRETriggers: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBRETriggersData = (PageResourceBreTriggerResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceBreTriggerResource), response.Headers);
            KnetikLogger.LogResponse(mGetBRETriggersStartTime, mGetBRETriggersPath, string.Format("Response received successfully:\n{0}", GetBRETriggersData.ToString()));

            if (GetBRETriggersComplete != null)
            {
                GetBRETriggersComplete(GetBRETriggersData);
            }
        }
        /// <summary>
        /// Update a trigger May fail if new parameters mismatch requirements of existing rules. Cannot update core triggers
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        /// <param name="breTriggerResource">The BRE trigger resource object</param>
        public void UpdateBRETrigger(string eventName, BreTriggerResource breTriggerResource)
        {
            // verify the required parameter 'eventName' is set
            if (eventName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'eventName' when calling UpdateBRETrigger");
            }
            
            mUpdateBRETriggerPath = "/bre/triggers/{event_name}";
            if (!string.IsNullOrEmpty(mUpdateBRETriggerPath))
            {
                mUpdateBRETriggerPath = mUpdateBRETriggerPath.Replace("{format}", "json");
            }
            mUpdateBRETriggerPath = mUpdateBRETriggerPath.Replace("{" + "event_name" + "}", KnetikClient.ParameterToString(eventName));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(breTriggerResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateBRETriggerStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateBRETriggerStartTime, mUpdateBRETriggerPath, "Sending server request...");

            // make the HTTP request
            mUpdateBRETriggerCoroutine.ResponseReceived += UpdateBRETriggerCallback;
            mUpdateBRETriggerCoroutine.Start(mUpdateBRETriggerPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateBRETriggerCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBRETrigger: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBRETrigger: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateBRETriggerData = (BreTriggerResource) KnetikClient.Deserialize(response.Content, typeof(BreTriggerResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateBRETriggerStartTime, mUpdateBRETriggerPath, string.Format("Response received successfully:\n{0}", UpdateBRETriggerData.ToString()));

            if (UpdateBRETriggerComplete != null)
            {
                UpdateBRETriggerComplete(UpdateBRETriggerData);
            }
        }
    }
}
