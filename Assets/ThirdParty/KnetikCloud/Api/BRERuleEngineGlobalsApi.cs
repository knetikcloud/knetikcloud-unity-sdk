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
    public interface IBRERuleEngineGlobalsApi
    {
        BreGlobalResource CreateBREGlobalData { get; }

        /// <summary>
        /// Create a global definition Once created you can then use in a custom rule. Note that global definitions cannot be modified or deleted if in use. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_GLOBALS_ADMIN
        /// </summary>
        /// <param name="breGlobalResource">The BRE global resource object</param>
        void CreateBREGlobal(BreGlobalResource breGlobalResource);

        

        /// <summary>
        /// Delete a global May fail if there are existing rules against it. Cannot delete core globals. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_GLOBALS_ADMIN
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        void DeleteBREGlobal(string id);

        BreGlobalResource GetBREGlobalData { get; }

        /// <summary>
        /// Get a single global definition &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_GLOBALS_USER
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        void GetBREGlobal(string id);

        PageResourceBreGlobalResource GetBREGlobalsData { get; }

        /// <summary>
        /// List global definitions &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_GLOBALS_USER
        /// </summary>
        /// <param name="filterSystem">Filter for globals that are system globals when true, or not when false. Leave off for both mixed</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetBREGlobals(bool? filterSystem, int? size, int? page);

        BreGlobalResource UpdateBREGlobalData { get; }

        /// <summary>
        /// Update a global definition May fail if new parameters mismatch requirements of existing rules. Cannot update core globals. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_GLOBALS_ADMIN
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        /// <param name="breGlobalResource">The BRE global resource object</param>
        void UpdateBREGlobal(string id, BreGlobalResource breGlobalResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineGlobalsApi : IBRERuleEngineGlobalsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateBREGlobalResponseContext;
        private DateTime mCreateBREGlobalStartTime;
        private readonly KnetikResponseContext mDeleteBREGlobalResponseContext;
        private DateTime mDeleteBREGlobalStartTime;
        private readonly KnetikResponseContext mGetBREGlobalResponseContext;
        private DateTime mGetBREGlobalStartTime;
        private readonly KnetikResponseContext mGetBREGlobalsResponseContext;
        private DateTime mGetBREGlobalsStartTime;
        private readonly KnetikResponseContext mUpdateBREGlobalResponseContext;
        private DateTime mUpdateBREGlobalStartTime;

        public BreGlobalResource CreateBREGlobalData { get; private set; }
        public delegate void CreateBREGlobalCompleteDelegate(long responseCode, BreGlobalResource response);
        public CreateBREGlobalCompleteDelegate CreateBREGlobalComplete;

        public delegate void DeleteBREGlobalCompleteDelegate(long responseCode);
        public DeleteBREGlobalCompleteDelegate DeleteBREGlobalComplete;

        public BreGlobalResource GetBREGlobalData { get; private set; }
        public delegate void GetBREGlobalCompleteDelegate(long responseCode, BreGlobalResource response);
        public GetBREGlobalCompleteDelegate GetBREGlobalComplete;

        public PageResourceBreGlobalResource GetBREGlobalsData { get; private set; }
        public delegate void GetBREGlobalsCompleteDelegate(long responseCode, PageResourceBreGlobalResource response);
        public GetBREGlobalsCompleteDelegate GetBREGlobalsComplete;

        public BreGlobalResource UpdateBREGlobalData { get; private set; }
        public delegate void UpdateBREGlobalCompleteDelegate(long responseCode, BreGlobalResource response);
        public UpdateBREGlobalCompleteDelegate UpdateBREGlobalComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineGlobalsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineGlobalsApi()
        {
            mCreateBREGlobalResponseContext = new KnetikResponseContext();
            mCreateBREGlobalResponseContext.ResponseReceived += OnCreateBREGlobalResponse;
            mDeleteBREGlobalResponseContext = new KnetikResponseContext();
            mDeleteBREGlobalResponseContext.ResponseReceived += OnDeleteBREGlobalResponse;
            mGetBREGlobalResponseContext = new KnetikResponseContext();
            mGetBREGlobalResponseContext.ResponseReceived += OnGetBREGlobalResponse;
            mGetBREGlobalsResponseContext = new KnetikResponseContext();
            mGetBREGlobalsResponseContext.ResponseReceived += OnGetBREGlobalsResponse;
            mUpdateBREGlobalResponseContext = new KnetikResponseContext();
            mUpdateBREGlobalResponseContext.ResponseReceived += OnUpdateBREGlobalResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a global definition Once created you can then use in a custom rule. Note that global definitions cannot be modified or deleted if in use. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_GLOBALS_ADMIN
        /// </summary>
        /// <param name="breGlobalResource">The BRE global resource object</param>
        public void CreateBREGlobal(BreGlobalResource breGlobalResource)
        {
            
            mWebCallEvent.WebPath = "/bre/globals/definitions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(breGlobalResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateBREGlobalStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateBREGlobalResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateBREGlobalStartTime, "CreateBREGlobal", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateBREGlobalResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateBREGlobal: " + response.Error);
            }

            CreateBREGlobalData = (BreGlobalResource) KnetikClient.Deserialize(response.Content, typeof(BreGlobalResource), response.Headers);
            KnetikLogger.LogResponse(mCreateBREGlobalStartTime, "CreateBREGlobal", string.Format("Response received successfully:\n{0}", CreateBREGlobalData));

            if (CreateBREGlobalComplete != null)
            {
                CreateBREGlobalComplete(response.ResponseCode, CreateBREGlobalData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a global May fail if there are existing rules against it. Cannot delete core globals. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_GLOBALS_ADMIN
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        public void DeleteBREGlobal(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteBREGlobal");
            }
            
            mWebCallEvent.WebPath = "/bre/globals/definitions/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteBREGlobalStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteBREGlobalResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteBREGlobalStartTime, "DeleteBREGlobal", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteBREGlobalResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteBREGlobal: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteBREGlobalStartTime, "DeleteBREGlobal", "Response received successfully.");
            if (DeleteBREGlobalComplete != null)
            {
                DeleteBREGlobalComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single global definition &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_GLOBALS_USER
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        public void GetBREGlobal(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBREGlobal");
            }
            
            mWebCallEvent.WebPath = "/bre/globals/definitions/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetBREGlobalStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBREGlobalResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBREGlobalStartTime, "GetBREGlobal", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBREGlobalResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBREGlobal: " + response.Error);
            }

            GetBREGlobalData = (BreGlobalResource) KnetikClient.Deserialize(response.Content, typeof(BreGlobalResource), response.Headers);
            KnetikLogger.LogResponse(mGetBREGlobalStartTime, "GetBREGlobal", string.Format("Response received successfully:\n{0}", GetBREGlobalData));

            if (GetBREGlobalComplete != null)
            {
                GetBREGlobalComplete(response.ResponseCode, GetBREGlobalData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List global definitions &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_GLOBALS_USER
        /// </summary>
        /// <param name="filterSystem">Filter for globals that are system globals when true, or not when false. Leave off for both mixed</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetBREGlobals(bool? filterSystem, int? size, int? page)
        {
            
            mWebCallEvent.WebPath = "/bre/globals/definitions";
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
            mGetBREGlobalsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBREGlobalsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBREGlobalsStartTime, "GetBREGlobals", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBREGlobalsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBREGlobals: " + response.Error);
            }

            GetBREGlobalsData = (PageResourceBreGlobalResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceBreGlobalResource), response.Headers);
            KnetikLogger.LogResponse(mGetBREGlobalsStartTime, "GetBREGlobals", string.Format("Response received successfully:\n{0}", GetBREGlobalsData));

            if (GetBREGlobalsComplete != null)
            {
                GetBREGlobalsComplete(response.ResponseCode, GetBREGlobalsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a global definition May fail if new parameters mismatch requirements of existing rules. Cannot update core globals. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_GLOBALS_ADMIN
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        /// <param name="breGlobalResource">The BRE global resource object</param>
        public void UpdateBREGlobal(string id, BreGlobalResource breGlobalResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateBREGlobal");
            }
            
            mWebCallEvent.WebPath = "/bre/globals/definitions/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(breGlobalResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateBREGlobalStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateBREGlobalResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateBREGlobalStartTime, "UpdateBREGlobal", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateBREGlobalResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateBREGlobal: " + response.Error);
            }

            UpdateBREGlobalData = (BreGlobalResource) KnetikClient.Deserialize(response.Content, typeof(BreGlobalResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateBREGlobalStartTime, "UpdateBREGlobal", string.Format("Response received successfully:\n{0}", UpdateBREGlobalData));

            if (UpdateBREGlobalComplete != null)
            {
                UpdateBREGlobalComplete(response.ResponseCode, UpdateBREGlobalData);
            }
        }

    }
}
