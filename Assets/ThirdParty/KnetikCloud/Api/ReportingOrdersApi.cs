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
    public interface IReportingOrdersApi
    {
        PageResourceAggregateInvoiceReportResource GetInvoiceReportsData { get; }

        /// <summary>
        /// Retrieve invoice counts aggregated by time ranges 
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="granularity">The time duration to aggregate by</param>
        /// <param name="filterPaymentStatus">A payment status to filter results by, can be a comma separated list</param>
        /// <param name="filterFulfillmentStatus">An invoice fulfillment status to filter results by, can be a comma separated list</param>
        /// <param name="startDate">The start of the time range to return, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to return, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        void GetInvoiceReports(string currencyCode, string granularity, string filterPaymentStatus, string filterFulfillmentStatus, long? startDate, long? endDate, int? size, int? page);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingOrdersApi : IReportingOrdersApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetInvoiceReportsResponseContext;
        private DateTime mGetInvoiceReportsStartTime;

        public PageResourceAggregateInvoiceReportResource GetInvoiceReportsData { get; private set; }
        public delegate void GetInvoiceReportsCompleteDelegate(long responseCode, PageResourceAggregateInvoiceReportResource response);
        public GetInvoiceReportsCompleteDelegate GetInvoiceReportsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingOrdersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingOrdersApi()
        {
            mGetInvoiceReportsResponseContext = new KnetikResponseContext();
            mGetInvoiceReportsResponseContext.ResponseReceived += OnGetInvoiceReportsResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Retrieve invoice counts aggregated by time ranges 
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="granularity">The time duration to aggregate by</param>
        /// <param name="filterPaymentStatus">A payment status to filter results by, can be a comma separated list</param>
        /// <param name="filterFulfillmentStatus">An invoice fulfillment status to filter results by, can be a comma separated list</param>
        /// <param name="startDate">The start of the time range to return, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to return, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        public void GetInvoiceReports(string currencyCode, string granularity, string filterPaymentStatus, string filterFulfillmentStatus, long? startDate, long? endDate, int? size, int? page)
        {
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetInvoiceReports");
            }
            
            mWebCallEvent.WebPath = "/reporting/orders/count/{currency_code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (granularity != null)
            {
                mWebCallEvent.QueryParams["granularity"] = KnetikClient.ParameterToString(granularity);
            }

            if (filterPaymentStatus != null)
            {
                mWebCallEvent.QueryParams["filter_payment_status"] = KnetikClient.ParameterToString(filterPaymentStatus);
            }

            if (filterFulfillmentStatus != null)
            {
                mWebCallEvent.QueryParams["filter_fulfillment_status"] = KnetikClient.ParameterToString(filterFulfillmentStatus);
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
            mGetInvoiceReportsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetInvoiceReportsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetInvoiceReportsStartTime, "GetInvoiceReports", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetInvoiceReportsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetInvoiceReports: " + response.Error);
            }

            GetInvoiceReportsData = (PageResourceAggregateInvoiceReportResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceAggregateInvoiceReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetInvoiceReportsStartTime, "GetInvoiceReports", string.Format("Response received successfully:\n{0}", GetInvoiceReportsData));

            if (GetInvoiceReportsComplete != null)
            {
                GetInvoiceReportsComplete(response.ResponseCode, GetInvoiceReportsData);
            }
        }

    }
}
