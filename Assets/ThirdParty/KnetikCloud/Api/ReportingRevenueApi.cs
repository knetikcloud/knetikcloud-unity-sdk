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
    public interface IReportingRevenueApi
    {
        /// <summary>
        /// Get item revenue info Get basic info about revenue from sales of items and bundles (not subscriptions, shipping, etc), summed up within a time range
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <returns>RevenueReportResource</returns>
        RevenueReportResource GetItemRevenue (string currencyCode, long? startDate, long? endDate);
        /// <summary>
        /// Get refund revenue info Get basic info about revenue loss from refunds (for all item types), summed up within a time range.
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get refund data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <returns>RevenueReportResource</returns>
        RevenueReportResource GetRefundRevenue (string currencyCode, long? startDate, long? endDate);
        /// <summary>
        /// Get revenue info by country Get basic info about revenue from sales of all types, summed up within a time range and split out by country. Sorted for largest revenue at the top
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceRevenueCountryReportResource</returns>
        PageResourceRevenueCountryReportResource GetRevenueByCountry (string currencyCode, long? startDate, long? endDate, int? size, int? page);
        /// <summary>
        /// Get revenue info by item Get basic info about revenue from sales of all types, summed up within a time range and split out by specific item. Sorted for largest revenue at the top
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceRevenueProductReportResource</returns>
        PageResourceRevenueProductReportResource GetRevenueByItem (string currencyCode, long? startDate, long? endDate, int? size, int? page);
        /// <summary>
        /// Get subscription revenue info Get basic info about revenue from sales of new subscriptions as well as recurring payemnts, summed up within a time range
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <returns>RevenueReportResource</returns>
        RevenueReportResource GetSubscriptionRevenue (string currencyCode, long? startDate, long? endDate);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingRevenueApi : IReportingRevenueApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingRevenueApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingRevenueApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Get item revenue info Get basic info about revenue from sales of items and bundles (not subscriptions, shipping, etc), summed up within a time range
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param> 
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param> 
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param> 
        /// <returns>RevenueReportResource</returns>            
        public RevenueReportResource GetItemRevenue(string currencyCode, long? startDate, long? endDate)
        {
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetItemRevenue");
            }
            
            
            string urlPath = "/reporting/revenue/item-sales/{currency_code}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (startDate != null)
            {
                queryParams.Add("start_date", KnetikClient.ParameterToString(startDate));
            }
            
            if (endDate != null)
            {
                queryParams.Add("end_date", KnetikClient.ParameterToString(endDate));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetItemRevenue: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetItemRevenue: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (RevenueReportResource) KnetikClient.Deserialize(response.Content, typeof(RevenueReportResource), response.Headers);
        }
        /// <summary>
        /// Get refund revenue info Get basic info about revenue loss from refunds (for all item types), summed up within a time range.
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get refund data for</param> 
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param> 
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param> 
        /// <returns>RevenueReportResource</returns>            
        public RevenueReportResource GetRefundRevenue(string currencyCode, long? startDate, long? endDate)
        {
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetRefundRevenue");
            }
            
            
            string urlPath = "/reporting/revenue/refunds/{currency_code}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (startDate != null)
            {
                queryParams.Add("start_date", KnetikClient.ParameterToString(startDate));
            }
            
            if (endDate != null)
            {
                queryParams.Add("end_date", KnetikClient.ParameterToString(endDate));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetRefundRevenue: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetRefundRevenue: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (RevenueReportResource) KnetikClient.Deserialize(response.Content, typeof(RevenueReportResource), response.Headers);
        }
        /// <summary>
        /// Get revenue info by country Get basic info about revenue from sales of all types, summed up within a time range and split out by country. Sorted for largest revenue at the top
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param> 
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param> 
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceRevenueCountryReportResource</returns>            
        public PageResourceRevenueCountryReportResource GetRevenueByCountry(string currencyCode, long? startDate, long? endDate, int? size, int? page)
        {
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetRevenueByCountry");
            }
            
            
            string urlPath = "/reporting/revenue/countries/{currency_code}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetRevenueByCountry: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetRevenueByCountry: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceRevenueCountryReportResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceRevenueCountryReportResource), response.Headers);
        }
        /// <summary>
        /// Get revenue info by item Get basic info about revenue from sales of all types, summed up within a time range and split out by specific item. Sorted for largest revenue at the top
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param> 
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param> 
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceRevenueProductReportResource</returns>            
        public PageResourceRevenueProductReportResource GetRevenueByItem(string currencyCode, long? startDate, long? endDate, int? size, int? page)
        {
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetRevenueByItem");
            }
            
            
            string urlPath = "/reporting/revenue/products/{currency_code}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetRevenueByItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetRevenueByItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceRevenueProductReportResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceRevenueProductReportResource), response.Headers);
        }
        /// <summary>
        /// Get subscription revenue info Get basic info about revenue from sales of new subscriptions as well as recurring payemnts, summed up within a time range
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param> 
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param> 
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param> 
        /// <returns>RevenueReportResource</returns>            
        public RevenueReportResource GetSubscriptionRevenue(string currencyCode, long? startDate, long? endDate)
        {
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetSubscriptionRevenue");
            }
            
            
            string urlPath = "/reporting/revenue/subscription-sales/{currency_code}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (startDate != null)
            {
                queryParams.Add("start_date", KnetikClient.ParameterToString(startDate));
            }
            
            if (endDate != null)
            {
                queryParams.Add("end_date", KnetikClient.ParameterToString(endDate));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetSubscriptionRevenue: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetSubscriptionRevenue: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (RevenueReportResource) KnetikClient.Deserialize(response.Content, typeof(RevenueReportResource), response.Headers);
        }
    }
}
