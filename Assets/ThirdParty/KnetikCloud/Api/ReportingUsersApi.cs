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
    public interface IReportingUsersApi
    {
        PageResourceAggregateCountResource GetUserRegistrationsData { get; }

        /// <summary>
        /// Get user registration info Get user registration counts grouped by time range. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; REPORTING_USER_ADMIN
        /// </summary>
        /// <param name="granularity">The time duration to aggregate by</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUserRegistrations(string granularity, long? startDate, long? endDate, int? size, int? page);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingUsersApi : IReportingUsersApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetUserRegistrationsResponseContext;
        private DateTime mGetUserRegistrationsStartTime;

        public PageResourceAggregateCountResource GetUserRegistrationsData { get; private set; }
        public delegate void GetUserRegistrationsCompleteDelegate(long responseCode, PageResourceAggregateCountResource response);
        public GetUserRegistrationsCompleteDelegate GetUserRegistrationsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingUsersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingUsersApi()
        {
            mGetUserRegistrationsResponseContext = new KnetikResponseContext();
            mGetUserRegistrationsResponseContext.ResponseReceived += OnGetUserRegistrationsResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get user registration info Get user registration counts grouped by time range. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; REPORTING_USER_ADMIN
        /// </summary>
        /// <param name="granularity">The time duration to aggregate by</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetUserRegistrations(string granularity, long? startDate, long? endDate, int? size, int? page)
        {
            
            mWebCallEvent.WebPath = "/reporting/users/registrations";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (granularity != null)
            {
                mWebCallEvent.QueryParams["granularity"] = KnetikClient.ParameterToString(granularity);
            }

            if (startDate != null)
            {
                mWebCallEvent.QueryParams["start_date"] = KnetikClient.ParameterToString(startDate);
            }

            if (endDate != null)
            {
                mWebCallEvent.QueryParams["end_date"] = KnetikClient.ParameterToString(endDate);
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
            mGetUserRegistrationsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserRegistrationsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserRegistrationsStartTime, "GetUserRegistrations", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserRegistrationsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserRegistrations: " + response.Error);
            }

            GetUserRegistrationsData = (PageResourceAggregateCountResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceAggregateCountResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserRegistrationsStartTime, "GetUserRegistrations", string.Format("Response received successfully:\n{0}", GetUserRegistrationsData));

            if (GetUserRegistrationsComplete != null)
            {
                GetUserRegistrationsComplete(response.ResponseCode, GetUserRegistrationsData);
            }
        }

    }
}
