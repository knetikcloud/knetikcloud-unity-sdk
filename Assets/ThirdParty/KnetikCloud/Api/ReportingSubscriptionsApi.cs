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
    public interface IReportingSubscriptionsApi
    {
        PageResourceBillingReport GetSubscriptionReportsData { get; }

        
        /// <summary>
        /// Get a list of available subscription reports in most recent first order 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetSubscriptionReports(int? size, int? page);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingSubscriptionsApi : IReportingSubscriptionsApi
    {
        private readonly KnetikCoroutine mGetSubscriptionReportsCoroutine;
        private DateTime mGetSubscriptionReportsStartTime;
        private string mGetSubscriptionReportsPath;

        public PageResourceBillingReport GetSubscriptionReportsData { get; private set; }
        public delegate void GetSubscriptionReportsCompleteDelegate(PageResourceBillingReport response);
        public GetSubscriptionReportsCompleteDelegate GetSubscriptionReportsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingSubscriptionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingSubscriptionsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
            mGetSubscriptionReportsCoroutine = new KnetikCoroutine(KnetikClient);
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient { get; private set; }

        /// <summary>
        /// Get a list of available subscription reports in most recent first order 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetSubscriptionReports(int? size, int? page)
        {
            
            mGetSubscriptionReportsPath = "/reporting/subscription";
            if (!string.IsNullOrEmpty(mGetSubscriptionReportsPath))
            {
                mGetSubscriptionReportsPath = mGetSubscriptionReportsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

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

            mGetSubscriptionReportsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetSubscriptionReportsStartTime, mGetSubscriptionReportsPath, "Sending server request...");

            // make the HTTP request
            mGetSubscriptionReportsCoroutine.ResponseReceived += GetSubscriptionReportsCallback;
            mGetSubscriptionReportsCoroutine.Start(mGetSubscriptionReportsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetSubscriptionReportsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSubscriptionReports: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSubscriptionReports: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetSubscriptionReportsData = (PageResourceBillingReport) KnetikClient.Deserialize(response.Content, typeof(PageResourceBillingReport), response.Headers);
            KnetikLogger.LogResponse(mGetSubscriptionReportsStartTime, mGetSubscriptionReportsPath, string.Format("Response received successfully:\n{0}", GetSubscriptionReportsData.ToString()));

            if (GetSubscriptionReportsComplete != null)
            {
                GetSubscriptionReportsComplete(GetSubscriptionReportsData);
            }
        }
    }
}
