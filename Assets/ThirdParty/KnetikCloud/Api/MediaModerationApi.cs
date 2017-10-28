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
    public interface IMediaModerationApi
    {
        FlagResource AddFlagData { get; }

        PageResourceFlagResource GetFlagsData { get; }

        FlagReportResource GetModerationReportData { get; }

        PageResourceFlagReportResource GetModerationReportsData { get; }

        
        /// <summary>
        /// Add a flag 
        /// </summary>
        /// <param name="flagResource">The flag resource object</param>
        void AddFlag(FlagResource flagResource);

        /// <summary>
        /// Delete a flag 
        /// </summary>
        /// <param name="contextName">The name of the context</param>
        /// <param name="contextId">The id of the context</param>
        /// <param name="userId">The id of the user</param>
        void DeleteFlag(string contextName, string contextId, int? userId);

        /// <summary>
        /// Returns a page of flags 
        /// </summary>
        /// <param name="filterContext">Filter by flag context</param>
        /// <param name="filterContextId">Filter by flag context ID</param>
        /// <param name="filterUserId">Filter by user ID</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetFlags(string filterContext, string filterContextId, int? filterUserId, int? size, int? page);

        /// <summary>
        /// Get a flag report 
        /// </summary>
        /// <param name="id">The flag report id</param>
        void GetModerationReport(long? id);

        /// <summary>
        /// Returns a page of flag reports Context can be either a free-form string or a pre-defined context name
        /// </summary>
        /// <param name="excludeResolved">Ignore resolved context</param>
        /// <param name="filterContext">Filter by moderation context</param>
        /// <param name="filterContextId">Filter by moderation context ID</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetModerationReports(bool? excludeResolved, string filterContext, string filterContextId, int? size, int? page);

        /// <summary>
        /// Update a flag report Lets you set the resolution of a report. Resolution types is {banned,ignore} in case of &#39;banned&#39; you will need to pass the reason.
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
        private readonly KnetikCoroutine mAddFlagCoroutine;
        private DateTime mAddFlagStartTime;
        private string mAddFlagPath;
        private readonly KnetikCoroutine mDeleteFlagCoroutine;
        private DateTime mDeleteFlagStartTime;
        private string mDeleteFlagPath;
        private readonly KnetikCoroutine mGetFlagsCoroutine;
        private DateTime mGetFlagsStartTime;
        private string mGetFlagsPath;
        private readonly KnetikCoroutine mGetModerationReportCoroutine;
        private DateTime mGetModerationReportStartTime;
        private string mGetModerationReportPath;
        private readonly KnetikCoroutine mGetModerationReportsCoroutine;
        private DateTime mGetModerationReportsStartTime;
        private string mGetModerationReportsPath;
        private readonly KnetikCoroutine mUpdateModerationReportCoroutine;
        private DateTime mUpdateModerationReportStartTime;
        private string mUpdateModerationReportPath;

        public FlagResource AddFlagData { get; private set; }
        public delegate void AddFlagCompleteDelegate(FlagResource response);
        public AddFlagCompleteDelegate AddFlagComplete;

        public delegate void DeleteFlagCompleteDelegate();
        public DeleteFlagCompleteDelegate DeleteFlagComplete;

        public PageResourceFlagResource GetFlagsData { get; private set; }
        public delegate void GetFlagsCompleteDelegate(PageResourceFlagResource response);
        public GetFlagsCompleteDelegate GetFlagsComplete;

        public FlagReportResource GetModerationReportData { get; private set; }
        public delegate void GetModerationReportCompleteDelegate(FlagReportResource response);
        public GetModerationReportCompleteDelegate GetModerationReportComplete;

        public PageResourceFlagReportResource GetModerationReportsData { get; private set; }
        public delegate void GetModerationReportsCompleteDelegate(PageResourceFlagReportResource response);
        public GetModerationReportsCompleteDelegate GetModerationReportsComplete;

        public delegate void UpdateModerationReportCompleteDelegate();
        public UpdateModerationReportCompleteDelegate UpdateModerationReportComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaModerationApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MediaModerationApi()
        {
            mAddFlagCoroutine = new KnetikCoroutine();
            mDeleteFlagCoroutine = new KnetikCoroutine();
            mGetFlagsCoroutine = new KnetikCoroutine();
            mGetModerationReportCoroutine = new KnetikCoroutine();
            mGetModerationReportsCoroutine = new KnetikCoroutine();
            mUpdateModerationReportCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a flag 
        /// </summary>
        /// <param name="flagResource">The flag resource object</param>
        public void AddFlag(FlagResource flagResource)
        {
            
            mAddFlagPath = "/moderation/flags";
            if (!string.IsNullOrEmpty(mAddFlagPath))
            {
                mAddFlagPath = mAddFlagPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(flagResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddFlagStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddFlagStartTime, mAddFlagPath, "Sending server request...");

            // make the HTTP request
            mAddFlagCoroutine.ResponseReceived += AddFlagCallback;
            mAddFlagCoroutine.Start(mAddFlagPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddFlagCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddFlag: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddFlag: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddFlagData = (FlagResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(FlagResource), response.Headers);
            KnetikLogger.LogResponse(mAddFlagStartTime, mAddFlagPath, string.Format("Response received successfully:\n{0}", AddFlagData.ToString()));

            if (AddFlagComplete != null)
            {
                AddFlagComplete(AddFlagData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a flag 
        /// </summary>
        /// <param name="contextName">The name of the context</param>
        /// <param name="contextId">The id of the context</param>
        /// <param name="userId">The id of the user</param>
        public void DeleteFlag(string contextName, string contextId, int? userId)
        {
            
            mDeleteFlagPath = "/moderation/flags";
            if (!string.IsNullOrEmpty(mDeleteFlagPath))
            {
                mDeleteFlagPath = mDeleteFlagPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (contextName != null)
            {
                queryParams.Add("context_name", KnetikClient.DefaultClient.ParameterToString(contextName));
            }

            if (contextId != null)
            {
                queryParams.Add("context_id", KnetikClient.DefaultClient.ParameterToString(contextId));
            }

            if (userId != null)
            {
                queryParams.Add("user_id", KnetikClient.DefaultClient.ParameterToString(userId));
            }

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteFlagStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteFlagStartTime, mDeleteFlagPath, "Sending server request...");

            // make the HTTP request
            mDeleteFlagCoroutine.ResponseReceived += DeleteFlagCallback;
            mDeleteFlagCoroutine.Start(mDeleteFlagPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteFlagCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteFlag: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteFlag: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteFlagStartTime, mDeleteFlagPath, "Response received successfully.");
            if (DeleteFlagComplete != null)
            {
                DeleteFlagComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a page of flags 
        /// </summary>
        /// <param name="filterContext">Filter by flag context</param>
        /// <param name="filterContextId">Filter by flag context ID</param>
        /// <param name="filterUserId">Filter by user ID</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetFlags(string filterContext, string filterContextId, int? filterUserId, int? size, int? page)
        {
            
            mGetFlagsPath = "/moderation/flags";
            if (!string.IsNullOrEmpty(mGetFlagsPath))
            {
                mGetFlagsPath = mGetFlagsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterContext != null)
            {
                queryParams.Add("filter_context", KnetikClient.DefaultClient.ParameterToString(filterContext));
            }

            if (filterContextId != null)
            {
                queryParams.Add("filter_context_id", KnetikClient.DefaultClient.ParameterToString(filterContextId));
            }

            if (filterUserId != null)
            {
                queryParams.Add("filter_user_id", KnetikClient.DefaultClient.ParameterToString(filterUserId));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetFlagsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetFlagsStartTime, mGetFlagsPath, "Sending server request...");

            // make the HTTP request
            mGetFlagsCoroutine.ResponseReceived += GetFlagsCallback;
            mGetFlagsCoroutine.Start(mGetFlagsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetFlagsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetFlags: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetFlags: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetFlagsData = (PageResourceFlagResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceFlagResource), response.Headers);
            KnetikLogger.LogResponse(mGetFlagsStartTime, mGetFlagsPath, string.Format("Response received successfully:\n{0}", GetFlagsData.ToString()));

            if (GetFlagsComplete != null)
            {
                GetFlagsComplete(GetFlagsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a flag report 
        /// </summary>
        /// <param name="id">The flag report id</param>
        public void GetModerationReport(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetModerationReport");
            }
            
            mGetModerationReportPath = "/moderation/reports/{id}";
            if (!string.IsNullOrEmpty(mGetModerationReportPath))
            {
                mGetModerationReportPath = mGetModerationReportPath.Replace("{format}", "json");
            }
            mGetModerationReportPath = mGetModerationReportPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetModerationReportStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetModerationReportStartTime, mGetModerationReportPath, "Sending server request...");

            // make the HTTP request
            mGetModerationReportCoroutine.ResponseReceived += GetModerationReportCallback;
            mGetModerationReportCoroutine.Start(mGetModerationReportPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetModerationReportCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetModerationReport: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetModerationReport: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetModerationReportData = (FlagReportResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(FlagReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetModerationReportStartTime, mGetModerationReportPath, string.Format("Response received successfully:\n{0}", GetModerationReportData.ToString()));

            if (GetModerationReportComplete != null)
            {
                GetModerationReportComplete(GetModerationReportData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a page of flag reports Context can be either a free-form string or a pre-defined context name
        /// </summary>
        /// <param name="excludeResolved">Ignore resolved context</param>
        /// <param name="filterContext">Filter by moderation context</param>
        /// <param name="filterContextId">Filter by moderation context ID</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetModerationReports(bool? excludeResolved, string filterContext, string filterContextId, int? size, int? page)
        {
            
            mGetModerationReportsPath = "/moderation/reports";
            if (!string.IsNullOrEmpty(mGetModerationReportsPath))
            {
                mGetModerationReportsPath = mGetModerationReportsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (excludeResolved != null)
            {
                queryParams.Add("exclude_resolved", KnetikClient.DefaultClient.ParameterToString(excludeResolved));
            }

            if (filterContext != null)
            {
                queryParams.Add("filter_context", KnetikClient.DefaultClient.ParameterToString(filterContext));
            }

            if (filterContextId != null)
            {
                queryParams.Add("filter_context_id", KnetikClient.DefaultClient.ParameterToString(filterContextId));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetModerationReportsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetModerationReportsStartTime, mGetModerationReportsPath, "Sending server request...");

            // make the HTTP request
            mGetModerationReportsCoroutine.ResponseReceived += GetModerationReportsCallback;
            mGetModerationReportsCoroutine.Start(mGetModerationReportsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetModerationReportsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetModerationReports: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetModerationReports: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetModerationReportsData = (PageResourceFlagReportResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceFlagReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetModerationReportsStartTime, mGetModerationReportsPath, string.Format("Response received successfully:\n{0}", GetModerationReportsData.ToString()));

            if (GetModerationReportsComplete != null)
            {
                GetModerationReportsComplete(GetModerationReportsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a flag report Lets you set the resolution of a report. Resolution types is {banned,ignore} in case of &#39;banned&#39; you will need to pass the reason.
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
            
            mUpdateModerationReportPath = "/moderation/reports/{id}";
            if (!string.IsNullOrEmpty(mUpdateModerationReportPath))
            {
                mUpdateModerationReportPath = mUpdateModerationReportPath.Replace("{format}", "json");
            }
            mUpdateModerationReportPath = mUpdateModerationReportPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(flagReportResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateModerationReportStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateModerationReportStartTime, mUpdateModerationReportPath, "Sending server request...");

            // make the HTTP request
            mUpdateModerationReportCoroutine.ResponseReceived += UpdateModerationReportCallback;
            mUpdateModerationReportCoroutine.Start(mUpdateModerationReportPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateModerationReportCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateModerationReport: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateModerationReport: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateModerationReportStartTime, mUpdateModerationReportPath, "Response received successfully.");
            if (UpdateModerationReportComplete != null)
            {
                UpdateModerationReportComplete();
            }
        }

    }
}
