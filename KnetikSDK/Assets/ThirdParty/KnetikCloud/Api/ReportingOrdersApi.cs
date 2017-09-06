using System;
using System.Collections.Generic;
using RestSharp;
using com.knetikcloud.Client;
using com.knetikcloud.Model;
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
        /// <returns>PageResourceAggregateInvoiceReportResource</returns>
        PageResourceAggregateInvoiceReportResource GetInvoiceReports (string currencyCode, string granularity, string filterPaymentStatus, string filterFulfillmentStatus, long? startDate, long? endDate, int? size, int? page);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingOrdersApi : IReportingOrdersApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingOrdersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingOrdersApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

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
        /// <returns>PageResourceAggregateInvoiceReportResource</returns>            
        public PageResourceAggregateInvoiceReportResource GetInvoiceReports(string currencyCode, string granularity, string filterPaymentStatus, string filterFulfillmentStatus, long? startDate, long? endDate, int? size, int? page)
        {
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetInvoiceReports");
            }
            
            
            string urlPath = "/reporting/orders/count/{currency_code}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (granularity != null)
            {
                queryParams.Add("granularity", KnetikClient.ParameterToString(granularity));
            }
            
            if (filterPaymentStatus != null)
            {
                queryParams.Add("filter_payment_status", KnetikClient.ParameterToString(filterPaymentStatus));
            }
            
            if (filterFulfillmentStatus != null)
            {
                queryParams.Add("filter_fulfillment_status", KnetikClient.ParameterToString(filterFulfillmentStatus));
            }
            
            if (startDate != null)
            {
                queryParams.Add("start_date", KnetikClient.ParameterToString(startDate));
            }
            
            if (endDate != null)
            {
                queryParams.Add("end_date", KnetikClient.ParameterToString(endDate));
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
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetInvoiceReports: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetInvoiceReports: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceAggregateInvoiceReportResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceAggregateInvoiceReportResource), response.Headers);
        }
    }
}
