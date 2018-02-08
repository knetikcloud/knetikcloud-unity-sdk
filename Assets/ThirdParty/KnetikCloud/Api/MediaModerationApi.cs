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
    public interface IMediaModerationApi
    {
        FlagResource AddFlagData { get; }

        /// <summary>
        /// Add a flag &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="flagResource">The flag resource object</param>
        void AddFlag(FlagResource flagResource);

        

        /// <summary>
        /// Delete a flag &lt;b&gt;Permissions Needed:&lt;/b&gt; MODERATION_ADMIN or owner
        /// </summary>
        /// <param name="contextName">The name of the context</param>
        /// <param name="contextId">The id of the context</param>
        /// <param name="userId">The id of the user</param>
        void DeleteFlag(string contextName, string contextId, int? userId);

        PageResourceFlagResource GetFlagsData { get; }

        /// <summary>
        /// Returns a page of flags &lt;b&gt;Permissions Needed:&lt;/b&gt; MODERATION_ADMIN or owner
        /// </summary>
        /// <param name="filterContext">Filter by flag context</param>
        /// <param name="filterContextId">Filter by flag context ID</param>
        /// <param name="filterUserId">Filter by user ID</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetFlags(string filterContext, string filterContextId, int? filterUserId, int? size, int? page);

        FlagReportResource GetModerationReportData { get; }

        /// <summary>
        /// Get a flag report &lt;b&gt;Permissions Needed:&lt;/b&gt; MODERATION_ADMIN
        /// </summary>
        /// <param name="id">The flag report id</param>
        void GetModerationReport(long? id);

        PageResourceFlagReportResource GetModerationReportsData { get; }

        /// <summary>
        /// Returns a page of flag reports Context can be either a free-form string or a pre-defined context name. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MODERATION_ADMIN
        /// </summary>
        /// <param name="excludeResolved">Ignore resolved context</param>
        /// <param name="filterContext">Filter by moderation context</param>
        /// <param name="filterContextId">Filter by moderation context ID</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetModerationReports(bool? excludeResolved, string filterContext, string filterContextId, int? size, int? page);

        

        /// <summary>
        /// Update a flag report Lets you set the resolution of a report. Resolution types is {banned,ignore} in case of &#39;banned&#39; you will need to pass the reason. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MODERATION_ADMIN
        /// </summary>
        /// <param name="id">The flag report id</param>
        /// <param name="flagReportResource">The new flag report</param>
        void UpdateModerationReport(long? id, FlagReportResource flagReportResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class MediaModerationApi : IMediaModerationApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddFlagResponseContext;
        private DateTime mAddFlagStartTime;
        private readonly KnetikResponseContext mDeleteFlagResponseContext;
        private DateTime mDeleteFlagStartTime;
        private readonly KnetikResponseContext mGetFlagsResponseContext;
        private DateTime mGetFlagsStartTime;
        private readonly KnetikResponseContext mGetModerationReportResponseContext;
        private DateTime mGetModerationReportStartTime;
        private readonly KnetikResponseContext mGetModerationReportsResponseContext;
        private DateTime mGetModerationReportsStartTime;
        private readonly KnetikResponseContext mUpdateModerationReportResponseContext;
        private DateTime mUpdateModerationReportStartTime;

        public FlagResource AddFlagData { get; private set; }
        public delegate void AddFlagCompleteDelegate(long responseCode, FlagResource response);
        public AddFlagCompleteDelegate AddFlagComplete;

        public delegate void DeleteFlagCompleteDelegate(long responseCode);
        public DeleteFlagCompleteDelegate DeleteFlagComplete;

        public PageResourceFlagResource GetFlagsData { get; private set; }
        public delegate void GetFlagsCompleteDelegate(long responseCode, PageResourceFlagResource response);
        public GetFlagsCompleteDelegate GetFlagsComplete;

        public FlagReportResource GetModerationReportData { get; private set; }
        public delegate void GetModerationReportCompleteDelegate(long responseCode, FlagReportResource response);
        public GetModerationReportCompleteDelegate GetModerationReportComplete;

        public PageResourceFlagReportResource GetModerationReportsData { get; private set; }
        public delegate void GetModerationReportsCompleteDelegate(long responseCode, PageResourceFlagReportResource response);
        public GetModerationReportsCompleteDelegate GetModerationReportsComplete;

        public delegate void UpdateModerationReportCompleteDelegate(long responseCode);
        public UpdateModerationReportCompleteDelegate UpdateModerationReportComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaModerationApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MediaModerationApi()
        {
            mAddFlagResponseContext = new KnetikResponseContext();
            mAddFlagResponseContext.ResponseReceived += OnAddFlagResponse;
            mDeleteFlagResponseContext = new KnetikResponseContext();
            mDeleteFlagResponseContext.ResponseReceived += OnDeleteFlagResponse;
            mGetFlagsResponseContext = new KnetikResponseContext();
            mGetFlagsResponseContext.ResponseReceived += OnGetFlagsResponse;
            mGetModerationReportResponseContext = new KnetikResponseContext();
            mGetModerationReportResponseContext.ResponseReceived += OnGetModerationReportResponse;
            mGetModerationReportsResponseContext = new KnetikResponseContext();
            mGetModerationReportsResponseContext.ResponseReceived += OnGetModerationReportsResponse;
            mUpdateModerationReportResponseContext = new KnetikResponseContext();
            mUpdateModerationReportResponseContext.ResponseReceived += OnUpdateModerationReportResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a flag &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="flagResource">The flag resource object</param>
        public void AddFlag(FlagResource flagResource)
        {
            
            mWebCallEvent.WebPath = "/moderation/flags";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(flagResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddFlagStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddFlagResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddFlagStartTime, "AddFlag", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddFlagResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddFlag: " + response.Error);
            }

            AddFlagData = (FlagResource) KnetikClient.Deserialize(response.Content, typeof(FlagResource), response.Headers);
            KnetikLogger.LogResponse(mAddFlagStartTime, "AddFlag", string.Format("Response received successfully:\n{0}", AddFlagData));

            if (AddFlagComplete != null)
            {
                AddFlagComplete(response.ResponseCode, AddFlagData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a flag &lt;b&gt;Permissions Needed:&lt;/b&gt; MODERATION_ADMIN or owner
        /// </summary>
        /// <param name="contextName">The name of the context</param>
        /// <param name="contextId">The id of the context</param>
        /// <param name="userId">The id of the user</param>
        public void DeleteFlag(string contextName, string contextId, int? userId)
        {
            
            mWebCallEvent.WebPath = "/moderation/flags";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (contextName != null)
            {
                mWebCallEvent.QueryParams["context_name"] = KnetikClient.ParameterToString(contextName);
            }

            if (contextId != null)
            {
                mWebCallEvent.QueryParams["context_id"] = KnetikClient.ParameterToString(contextId);
            }

            if (userId != null)
            {
                mWebCallEvent.QueryParams["user_id"] = KnetikClient.ParameterToString(userId);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteFlagStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteFlagResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteFlagStartTime, "DeleteFlag", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteFlagResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteFlag: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteFlagStartTime, "DeleteFlag", "Response received successfully.");
            if (DeleteFlagComplete != null)
            {
                DeleteFlagComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a page of flags &lt;b&gt;Permissions Needed:&lt;/b&gt; MODERATION_ADMIN or owner
        /// </summary>
        /// <param name="filterContext">Filter by flag context</param>
        /// <param name="filterContextId">Filter by flag context ID</param>
        /// <param name="filterUserId">Filter by user ID</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetFlags(string filterContext, string filterContextId, int? filterUserId, int? size, int? page)
        {
            
            mWebCallEvent.WebPath = "/moderation/flags";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterContext != null)
            {
                mWebCallEvent.QueryParams["filter_context"] = KnetikClient.ParameterToString(filterContext);
            }

            if (filterContextId != null)
            {
                mWebCallEvent.QueryParams["filter_context_id"] = KnetikClient.ParameterToString(filterContextId);
            }

            if (filterUserId != null)
            {
                mWebCallEvent.QueryParams["filter_user_id"] = KnetikClient.ParameterToString(filterUserId);
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
            mGetFlagsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetFlagsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetFlagsStartTime, "GetFlags", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetFlagsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetFlags: " + response.Error);
            }

            GetFlagsData = (PageResourceFlagResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceFlagResource), response.Headers);
            KnetikLogger.LogResponse(mGetFlagsStartTime, "GetFlags", string.Format("Response received successfully:\n{0}", GetFlagsData));

            if (GetFlagsComplete != null)
            {
                GetFlagsComplete(response.ResponseCode, GetFlagsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a flag report &lt;b&gt;Permissions Needed:&lt;/b&gt; MODERATION_ADMIN
        /// </summary>
        /// <param name="id">The flag report id</param>
        public void GetModerationReport(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetModerationReport");
            }
            
            mWebCallEvent.WebPath = "/moderation/reports/{id}";
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
            mGetModerationReportStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetModerationReportResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetModerationReportStartTime, "GetModerationReport", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetModerationReportResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetModerationReport: " + response.Error);
            }

            GetModerationReportData = (FlagReportResource) KnetikClient.Deserialize(response.Content, typeof(FlagReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetModerationReportStartTime, "GetModerationReport", string.Format("Response received successfully:\n{0}", GetModerationReportData));

            if (GetModerationReportComplete != null)
            {
                GetModerationReportComplete(response.ResponseCode, GetModerationReportData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a page of flag reports Context can be either a free-form string or a pre-defined context name. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MODERATION_ADMIN
        /// </summary>
        /// <param name="excludeResolved">Ignore resolved context</param>
        /// <param name="filterContext">Filter by moderation context</param>
        /// <param name="filterContextId">Filter by moderation context ID</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetModerationReports(bool? excludeResolved, string filterContext, string filterContextId, int? size, int? page)
        {
            
            mWebCallEvent.WebPath = "/moderation/reports";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (excludeResolved != null)
            {
                mWebCallEvent.QueryParams["exclude_resolved"] = KnetikClient.ParameterToString(excludeResolved);
            }

            if (filterContext != null)
            {
                mWebCallEvent.QueryParams["filter_context"] = KnetikClient.ParameterToString(filterContext);
            }

            if (filterContextId != null)
            {
                mWebCallEvent.QueryParams["filter_context_id"] = KnetikClient.ParameterToString(filterContextId);
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
            mGetModerationReportsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetModerationReportsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetModerationReportsStartTime, "GetModerationReports", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetModerationReportsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetModerationReports: " + response.Error);
            }

            GetModerationReportsData = (PageResourceFlagReportResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceFlagReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetModerationReportsStartTime, "GetModerationReports", string.Format("Response received successfully:\n{0}", GetModerationReportsData));

            if (GetModerationReportsComplete != null)
            {
                GetModerationReportsComplete(response.ResponseCode, GetModerationReportsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a flag report Lets you set the resolution of a report. Resolution types is {banned,ignore} in case of &#39;banned&#39; you will need to pass the reason. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MODERATION_ADMIN
        /// </summary>
        /// <param name="id">The flag report id</param>
        /// <param name="flagReportResource">The new flag report</param>
        public void UpdateModerationReport(long? id, FlagReportResource flagReportResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateModerationReport");
            }
            
            mWebCallEvent.WebPath = "/moderation/reports/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(flagReportResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateModerationReportStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateModerationReportResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateModerationReportStartTime, "UpdateModerationReport", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateModerationReportResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateModerationReport: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateModerationReportStartTime, "UpdateModerationReport", "Response received successfully.");
            if (UpdateModerationReportComplete != null)
            {
                UpdateModerationReportComplete(response.ResponseCode);
            }
        }

    }
}
