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
    public interface IReportingSubscriptionsApi
    {
        PageResourceBillingReport GetSubscriptionReportsData { get; }

        /// <summary>
        /// Get a list of available subscription reports in most recent first order &lt;b&gt;Permissions Needed:&lt;/b&gt; SUBSCRIPTIONS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetSubscriptionReports(int? size, int? page);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingSubscriptionsApi : IReportingSubscriptionsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetSubscriptionReportsResponseContext;
        private DateTime mGetSubscriptionReportsStartTime;

        public PageResourceBillingReport GetSubscriptionReportsData { get; private set; }
        public delegate void GetSubscriptionReportsCompleteDelegate(long responseCode, PageResourceBillingReport response);
        public GetSubscriptionReportsCompleteDelegate GetSubscriptionReportsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingSubscriptionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingSubscriptionsApi()
        {
            mGetSubscriptionReportsResponseContext = new KnetikResponseContext();
            mGetSubscriptionReportsResponseContext.ResponseReceived += OnGetSubscriptionReportsResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get a list of available subscription reports in most recent first order &lt;b&gt;Permissions Needed:&lt;/b&gt; SUBSCRIPTIONS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetSubscriptionReports(int? size, int? page)
        {
            
            mWebCallEvent.WebPath = "/reporting/subscription";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

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
            mGetSubscriptionReportsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetSubscriptionReportsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetSubscriptionReportsStartTime, "GetSubscriptionReports", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetSubscriptionReportsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetSubscriptionReports: " + response.Error);
            }

            GetSubscriptionReportsData = (PageResourceBillingReport) KnetikClient.Deserialize(response.Content, typeof(PageResourceBillingReport), response.Headers);
            KnetikLogger.LogResponse(mGetSubscriptionReportsStartTime, "GetSubscriptionReports", string.Format("Response received successfully:\n{0}", GetSubscriptionReportsData));

            if (GetSubscriptionReportsComplete != null)
            {
                GetSubscriptionReportsComplete(response.ResponseCode, GetSubscriptionReportsData);
            }
        }

    }
}
