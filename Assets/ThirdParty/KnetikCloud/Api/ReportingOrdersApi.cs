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
        private readonly KnetikCoroutine mGetInvoiceReportsCoroutine;
        private DateTime mGetInvoiceReportsStartTime;
        private string mGetInvoiceReportsPath;

        public PageResourceAggregateInvoiceReportResource GetInvoiceReportsData { get; private set; }
        public delegate void GetInvoiceReportsCompleteDelegate(PageResourceAggregateInvoiceReportResource response);
        public GetInvoiceReportsCompleteDelegate GetInvoiceReportsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingOrdersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingOrdersApi()
        {
            mGetInvoiceReportsCoroutine = new KnetikCoroutine();
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
            
            mGetInvoiceReportsPath = "/reporting/orders/count/{currency_code}";
            if (!string.IsNullOrEmpty(mGetInvoiceReportsPath))
            {
                mGetInvoiceReportsPath = mGetInvoiceReportsPath.Replace("{format}", "json");
            }
            mGetInvoiceReportsPath = mGetInvoiceReportsPath.Replace("{" + "currency_code" + "}", KnetikClient.DefaultClient.ParameterToString(currencyCode));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (granularity != null)
            {
                queryParams.Add("granularity", KnetikClient.DefaultClient.ParameterToString(granularity));
            }

            if (filterPaymentStatus != null)
            {
                queryParams.Add("filter_payment_status", KnetikClient.DefaultClient.ParameterToString(filterPaymentStatus));
            }

            if (filterFulfillmentStatus != null)
            {
                queryParams.Add("filter_fulfillment_status", KnetikClient.DefaultClient.ParameterToString(filterFulfillmentStatus));
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

            mGetInvoiceReportsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetInvoiceReportsStartTime, mGetInvoiceReportsPath, "Sending server request...");

            // make the HTTP request
            mGetInvoiceReportsCoroutine.ResponseReceived += GetInvoiceReportsCallback;
            mGetInvoiceReportsCoroutine.Start(mGetInvoiceReportsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetInvoiceReportsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetInvoiceReports: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetInvoiceReports: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetInvoiceReportsData = (PageResourceAggregateInvoiceReportResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceAggregateInvoiceReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetInvoiceReportsStartTime, mGetInvoiceReportsPath, string.Format("Response received successfully:\n{0}", GetInvoiceReportsData.ToString()));

            if (GetInvoiceReportsComplete != null)
            {
                GetInvoiceReportsComplete(GetInvoiceReportsData);
            }
        }

    }
}
