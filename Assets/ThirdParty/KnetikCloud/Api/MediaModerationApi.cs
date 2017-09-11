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
        FlagReportResource GetModerationReportData { get; }

        PageResourceFlagReportResource GetModerationReportsData { get; }

        
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
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetModerationReports(bool? excludeResolved, string filterContext, int? size, int? page);

        /// <summary>
        /// Update a flag report Lets you set the resolution of a report. Resolution types is {banned,ignore} in case of &#39;banned&#39; you will need to pass the reason.
        /// </summary>
        /// <param name="id">The flag report id</param>
        /// <param name="flagReportResource">The new flag report</param>
        void UpdateModerationReport(long? id, FlagReportResource flagReportResource);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class MediaModerationApi : IMediaModerationApi
    {
        private readonly KnetikCoroutine mGetModerationReportCoroutine;
        private DateTime mGetModerationReportStartTime;
        private string mGetModerationReportPath;
        private readonly KnetikCoroutine mGetModerationReportsCoroutine;
        private DateTime mGetModerationReportsStartTime;
        private string mGetModerationReportsPath;
        private readonly KnetikCoroutine mUpdateModerationReportCoroutine;
        private DateTime mUpdateModerationReportStartTime;
        private string mUpdateModerationReportPath;

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
            KnetikClient = KnetikConfiguration.DefaultClient;
            mGetModerationReportCoroutine = new KnetikCoroutine(KnetikClient);
            mGetModerationReportsCoroutine = new KnetikCoroutine(KnetikClient);
            mUpdateModerationReportCoroutine = new KnetikCoroutine(KnetikClient);
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient { get; private set; }

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
            mGetModerationReportPath = mGetModerationReportPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

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

            GetModerationReportData = (FlagReportResource) KnetikClient.Deserialize(response.Content, typeof(FlagReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetModerationReportStartTime, mGetModerationReportPath, string.Format("Response received successfully:\n{0}", GetModerationReportData.ToString()));

            if (GetModerationReportComplete != null)
            {
                GetModerationReportComplete(GetModerationReportData);
            }
        }
        /// <summary>
        /// Returns a page of flag reports Context can be either a free-form string or a pre-defined context name
        /// </summary>
        /// <param name="excludeResolved">Ignore resolved context</param>
        /// <param name="filterContext">Filter by moderation context</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetModerationReports(bool? excludeResolved, string filterContext, int? size, int? page)
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
                queryParams.Add("exclude_resolved", KnetikClient.ParameterToString(excludeResolved));
            }

            if (filterContext != null)
            {
                queryParams.Add("filter_context", KnetikClient.ParameterToString(filterContext));
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

            GetModerationReportsData = (PageResourceFlagReportResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceFlagReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetModerationReportsStartTime, mGetModerationReportsPath, string.Format("Response received successfully:\n{0}", GetModerationReportsData.ToString()));

            if (GetModerationReportsComplete != null)
            {
                GetModerationReportsComplete(GetModerationReportsData);
            }
        }
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
            mUpdateModerationReportPath = mUpdateModerationReportPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(flagReportResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

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
