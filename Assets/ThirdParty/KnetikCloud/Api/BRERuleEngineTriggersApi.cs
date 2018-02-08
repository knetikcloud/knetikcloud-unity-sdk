using System;
using System.Collections.Generic;
using com.knetikcloud.Model;
using KnetikUnity.Client;
using KnetikUnity.Events;
using KnetikUnity.Exceptions;
using KnetikUnity.Utils;

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

        /// <summary>
        /// Create a trigger Customer added triggers will not be fired automatically or have rules associated with them by default. Custom rules must be added to get use from the trigger and it must then be fired from the outside. See the Bre Event services. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_TRIGGERS_ADMIN
        /// </summary>
        /// <param name="breTriggerResource">The BRE trigger resource object</param>
        void CreateBRETrigger(BreTriggerResource breTriggerResource);

        

        /// <summary>
        /// Delete a trigger May fail if there are existing rules against it. Cannot delete core triggers. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_TRIGGERS_ADMIN
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        void DeleteBRETrigger(string eventName);

        BreTriggerResource GetBRETriggerData { get; }

        /// <summary>
        /// Get a single trigger &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_TRIGGERS_USER
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        void GetBRETrigger(string eventName);

        PageResourceBreTriggerResource GetBRETriggersData { get; }

        /// <summary>
        /// List triggers &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_TRIGGERS_USER
        /// </summary>
        /// <param name="filterSystem">Filter for triggers that are system triggers when true, or not when false. Leave off for both mixed</param>
        /// <param name="filterCategory">Filter for triggers that are within a specific category</param>
        /// <param name="filterTags">Filter for triggers that have all of the given tags (comma separated list)</param>
        /// <param name="filterName">Filter for triggers that have names containing the given string</param>
        /// <param name="filterSearch">Filter for triggers containing the given words somewhere within name, description and tags</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetBRETriggers(bool? filterSystem, string filterCategory, string filterTags, string filterName, string filterSearch, int? size, int? page);

        BreTriggerResource UpdateBRETriggerData { get; }

        /// <summary>
        /// Update a trigger May fail if new parameters mismatch requirements of existing rules. Cannot update core triggers. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_TRIGGERS_ADMIN
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        /// <param name="breTriggerResource">The BRE trigger resource object</param>
        void UpdateBRETrigger(string eventName, BreTriggerResource breTriggerResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineTriggersApi : IBRERuleEngineTriggersApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateBRETriggerResponseContext;
        private DateTime mCreateBRETriggerStartTime;
        private readonly KnetikResponseContext mDeleteBRETriggerResponseContext;
        private DateTime mDeleteBRETriggerStartTime;
        private readonly KnetikResponseContext mGetBRETriggerResponseContext;
        private DateTime mGetBRETriggerStartTime;
        private readonly KnetikResponseContext mGetBRETriggersResponseContext;
        private DateTime mGetBRETriggersStartTime;
        private readonly KnetikResponseContext mUpdateBRETriggerResponseContext;
        private DateTime mUpdateBRETriggerStartTime;

        public BreTriggerResource CreateBRETriggerData { get; private set; }
        public delegate void CreateBRETriggerCompleteDelegate(long responseCode, BreTriggerResource response);
        public CreateBRETriggerCompleteDelegate CreateBRETriggerComplete;

        public delegate void DeleteBRETriggerCompleteDelegate(long responseCode);
        public DeleteBRETriggerCompleteDelegate DeleteBRETriggerComplete;

        public BreTriggerResource GetBRETriggerData { get; private set; }
        public delegate void GetBRETriggerCompleteDelegate(long responseCode, BreTriggerResource response);
        public GetBRETriggerCompleteDelegate GetBRETriggerComplete;

        public PageResourceBreTriggerResource GetBRETriggersData { get; private set; }
        public delegate void GetBRETriggersCompleteDelegate(long responseCode, PageResourceBreTriggerResource response);
        public GetBRETriggersCompleteDelegate GetBRETriggersComplete;

        public BreTriggerResource UpdateBRETriggerData { get; private set; }
        public delegate void UpdateBRETriggerCompleteDelegate(long responseCode, BreTriggerResource response);
        public UpdateBRETriggerCompleteDelegate UpdateBRETriggerComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineTriggersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineTriggersApi()
        {
            mCreateBRETriggerResponseContext = new KnetikResponseContext();
            mCreateBRETriggerResponseContext.ResponseReceived += OnCreateBRETriggerResponse;
            mDeleteBRETriggerResponseContext = new KnetikResponseContext();
            mDeleteBRETriggerResponseContext.ResponseReceived += OnDeleteBRETriggerResponse;
            mGetBRETriggerResponseContext = new KnetikResponseContext();
            mGetBRETriggerResponseContext.ResponseReceived += OnGetBRETriggerResponse;
            mGetBRETriggersResponseContext = new KnetikResponseContext();
            mGetBRETriggersResponseContext.ResponseReceived += OnGetBRETriggersResponse;
            mUpdateBRETriggerResponseContext = new KnetikResponseContext();
            mUpdateBRETriggerResponseContext.ResponseReceived += OnUpdateBRETriggerResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a trigger Customer added triggers will not be fired automatically or have rules associated with them by default. Custom rules must be added to get use from the trigger and it must then be fired from the outside. See the Bre Event services. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_TRIGGERS_ADMIN
        /// </summary>
        /// <param name="breTriggerResource">The BRE trigger resource object</param>
        public void CreateBRETrigger(BreTriggerResource breTriggerResource)
        {
            
            mWebCallEvent.WebPath = "/bre/triggers";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(breTriggerResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateBRETriggerStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateBRETriggerResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateBRETriggerStartTime, "CreateBRETrigger", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateBRETriggerResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateBRETrigger: " + response.Error);
            }

            CreateBRETriggerData = (BreTriggerResource) KnetikClient.Deserialize(response.Content, typeof(BreTriggerResource), response.Headers);
            KnetikLogger.LogResponse(mCreateBRETriggerStartTime, "CreateBRETrigger", string.Format("Response received successfully:\n{0}", CreateBRETriggerData));

            if (CreateBRETriggerComplete != null)
            {
                CreateBRETriggerComplete(response.ResponseCode, CreateBRETriggerData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a trigger May fail if there are existing rules against it. Cannot delete core triggers. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_TRIGGERS_ADMIN
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        public void DeleteBRETrigger(string eventName)
        {
            // verify the required parameter 'eventName' is set
            if (eventName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'eventName' when calling DeleteBRETrigger");
            }
            
            mWebCallEvent.WebPath = "/bre/triggers/{event_name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "event_name" + "}", KnetikClient.ParameterToString(eventName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteBRETriggerStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteBRETriggerResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteBRETriggerStartTime, "DeleteBRETrigger", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteBRETriggerResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteBRETrigger: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteBRETriggerStartTime, "DeleteBRETrigger", "Response received successfully.");
            if (DeleteBRETriggerComplete != null)
            {
                DeleteBRETriggerComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single trigger &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_TRIGGERS_USER
        /// </summary>
        /// <param name="eventName">The trigger event name</param>
        public void GetBRETrigger(string eventName)
        {
            // verify the required parameter 'eventName' is set
            if (eventName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'eventName' when calling GetBRETrigger");
            }
            
            mWebCallEvent.WebPath = "/bre/triggers/{event_name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "event_name" + "}", KnetikClient.ParameterToString(eventName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetBRETriggerStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBRETriggerResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBRETriggerStartTime, "GetBRETrigger", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBRETriggerResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBRETrigger: " + response.Error);
            }

            GetBRETriggerData = (BreTriggerResource) KnetikClient.Deserialize(response.Content, typeof(BreTriggerResource), response.Headers);
            KnetikLogger.LogResponse(mGetBRETriggerStartTime, "GetBRETrigger", string.Format("Response received successfully:\n{0}", GetBRETriggerData));

            if (GetBRETriggerComplete != null)
            {
                GetBRETriggerComplete(response.ResponseCode, GetBRETriggerData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List triggers &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_TRIGGERS_USER
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
            
            mWebCallEvent.WebPath = "/bre/triggers";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterSystem != null)
            {
                mWebCallEvent.QueryParams["filter_system"] = KnetikClient.ParameterToString(filterSystem);
            }

            if (filterCategory != null)
            {
                mWebCallEvent.QueryParams["filter_category"] = KnetikClient.ParameterToString(filterCategory);
            }

            if (filterTags != null)
            {
                mWebCallEvent.QueryParams["filter_tags"] = KnetikClient.ParameterToString(filterTags);
            }

            if (filterName != null)
            {
                mWebCallEvent.QueryParams["filter_name"] = KnetikClient.ParameterToString(filterName);
            }

            if (filterSearch != null)
            {
                mWebCallEvent.QueryParams["filter_search"] = KnetikClient.ParameterToString(filterSearch);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetBRETriggersStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBRETriggersResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBRETriggersStartTime, "GetBRETriggers", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBRETriggersResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBRETriggers: " + response.Error);
            }

            GetBRETriggersData = (PageResourceBreTriggerResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceBreTriggerResource), response.Headers);
            KnetikLogger.LogResponse(mGetBRETriggersStartTime, "GetBRETriggers", string.Format("Response received successfully:\n{0}", GetBRETriggersData));

            if (GetBRETriggersComplete != null)
            {
                GetBRETriggersComplete(response.ResponseCode, GetBRETriggersData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a trigger May fail if new parameters mismatch requirements of existing rules. Cannot update core triggers. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_TRIGGERS_ADMIN
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
            
            mWebCallEvent.WebPath = "/bre/triggers/{event_name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "event_name" + "}", KnetikClient.ParameterToString(eventName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(breTriggerResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateBRETriggerStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateBRETriggerResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateBRETriggerStartTime, "UpdateBRETrigger", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateBRETriggerResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateBRETrigger: " + response.Error);
            }

            UpdateBRETriggerData = (BreTriggerResource) KnetikClient.Deserialize(response.Content, typeof(BreTriggerResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateBRETriggerStartTime, "UpdateBRETrigger", string.Format("Response received successfully:\n{0}", UpdateBRETriggerData));

            if (UpdateBRETriggerComplete != null)
            {
                UpdateBRETriggerComplete(response.ResponseCode, UpdateBRETriggerData);
            }
        }

    }
}
