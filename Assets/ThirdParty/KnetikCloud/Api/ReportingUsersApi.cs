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
    public interface IReportingUsersApi
    {
        PageResourceAggregateCountResource GetUserRegistrationsData { get; }

        
        /// <summary>
        /// Get user registration info Get user registration counts grouped by time range
        /// </summary>
        /// <param name="granularity">The time duration to aggregate by</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUserRegistrations(string granularity, long? startDate, long? endDate, int? size, int? page);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingUsersApi : IReportingUsersApi
    {
        private readonly KnetikCoroutine mGetUserRegistrationsCoroutine;
        private DateTime mGetUserRegistrationsStartTime;
        private string mGetUserRegistrationsPath;

        public PageResourceAggregateCountResource GetUserRegistrationsData { get; private set; }
        public delegate void GetUserRegistrationsCompleteDelegate(PageResourceAggregateCountResource response);
        public GetUserRegistrationsCompleteDelegate GetUserRegistrationsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingUsersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingUsersApi()
        {
            mGetUserRegistrationsCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
        /// <summary>
        /// Get user registration info Get user registration counts grouped by time range
        /// </summary>
        /// <param name="granularity">The time duration to aggregate by</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetUserRegistrations(string granularity, long? startDate, long? endDate, int? size, int? page)
        {
            
            mGetUserRegistrationsPath = "/reporting/users/registrations";
            if (!string.IsNullOrEmpty(mGetUserRegistrationsPath))
            {
                mGetUserRegistrationsPath = mGetUserRegistrationsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (granularity != null)
            {
                queryParams.Add("granularity", KnetikClient.DefaultClient.ParameterToString(granularity));
            }

            if (startDate != null)
            {
                queryParams.Add("start_date", KnetikClient.DefaultClient.ParameterToString(startDate));
            }

            if (endDate != null)
            {
                queryParams.Add("end_date", KnetikClient.DefaultClient.ParameterToString(endDate));
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserRegistrationsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserRegistrationsStartTime, mGetUserRegistrationsPath, "Sending server request...");

            // make the HTTP request
            mGetUserRegistrationsCoroutine.ResponseReceived += GetUserRegistrationsCallback;
            mGetUserRegistrationsCoroutine.Start(mGetUserRegistrationsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserRegistrationsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserRegistrations: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserRegistrations: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserRegistrationsData = (PageResourceAggregateCountResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceAggregateCountResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserRegistrationsStartTime, mGetUserRegistrationsPath, string.Format("Response received successfully:\n{0}", GetUserRegistrationsData.ToString()));

            if (GetUserRegistrationsComplete != null)
            {
                GetUserRegistrationsComplete(GetUserRegistrationsData);
            }
        }
    }
}
