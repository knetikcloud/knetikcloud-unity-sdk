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
    public interface IReportingRevenueApi
    {
        RevenueReportResource GetItemRevenueData { get; }

        RevenueReportResource GetRefundRevenueData { get; }

        PageResourceRevenueCountryReportResource GetRevenueByCountryData { get; }

        PageResourceRevenueProductReportResource GetRevenueByItemData { get; }

        RevenueReportResource GetSubscriptionRevenueData { get; }

        
        /// <summary>
        /// Get item revenue info Get basic info about revenue from sales of items and bundles (not subscriptions, shipping, etc), summed up within a time range
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        void GetItemRevenue(string currencyCode, long? startDate, long? endDate);

        /// <summary>
        /// Get refund revenue info Get basic info about revenue loss from refunds (for all item types), summed up within a time range.
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get refund data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        void GetRefundRevenue(string currencyCode, long? startDate, long? endDate);

        /// <summary>
        /// Get revenue info by country Get basic info about revenue from sales of all types, summed up within a time range and split out by country. Sorted for largest revenue at the top
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetRevenueByCountry(string currencyCode, long? startDate, long? endDate, int? size, int? page);

        /// <summary>
        /// Get revenue info by item Get basic info about revenue from sales of all types, summed up within a time range and split out by specific item. Sorted for largest revenue at the top
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetRevenueByItem(string currencyCode, long? startDate, long? endDate, int? size, int? page);

        /// <summary>
        /// Get subscription revenue info Get basic info about revenue from sales of new subscriptions as well as recurring payemnts, summed up within a time range
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        void GetSubscriptionRevenue(string currencyCode, long? startDate, long? endDate);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingRevenueApi : IReportingRevenueApi
    {
        private readonly KnetikCoroutine mGetItemRevenueCoroutine;
        private DateTime mGetItemRevenueStartTime;
        private string mGetItemRevenuePath;
        private readonly KnetikCoroutine mGetRefundRevenueCoroutine;
        private DateTime mGetRefundRevenueStartTime;
        private string mGetRefundRevenuePath;
        private readonly KnetikCoroutine mGetRevenueByCountryCoroutine;
        private DateTime mGetRevenueByCountryStartTime;
        private string mGetRevenueByCountryPath;
        private readonly KnetikCoroutine mGetRevenueByItemCoroutine;
        private DateTime mGetRevenueByItemStartTime;
        private string mGetRevenueByItemPath;
        private readonly KnetikCoroutine mGetSubscriptionRevenueCoroutine;
        private DateTime mGetSubscriptionRevenueStartTime;
        private string mGetSubscriptionRevenuePath;

        public RevenueReportResource GetItemRevenueData { get; private set; }
        public delegate void GetItemRevenueCompleteDelegate(RevenueReportResource response);
        public GetItemRevenueCompleteDelegate GetItemRevenueComplete;

        public RevenueReportResource GetRefundRevenueData { get; private set; }
        public delegate void GetRefundRevenueCompleteDelegate(RevenueReportResource response);
        public GetRefundRevenueCompleteDelegate GetRefundRevenueComplete;

        public PageResourceRevenueCountryReportResource GetRevenueByCountryData { get; private set; }
        public delegate void GetRevenueByCountryCompleteDelegate(PageResourceRevenueCountryReportResource response);
        public GetRevenueByCountryCompleteDelegate GetRevenueByCountryComplete;

        public PageResourceRevenueProductReportResource GetRevenueByItemData { get; private set; }
        public delegate void GetRevenueByItemCompleteDelegate(PageResourceRevenueProductReportResource response);
        public GetRevenueByItemCompleteDelegate GetRevenueByItemComplete;

        public RevenueReportResource GetSubscriptionRevenueData { get; private set; }
        public delegate void GetSubscriptionRevenueCompleteDelegate(RevenueReportResource response);
        public GetSubscriptionRevenueCompleteDelegate GetSubscriptionRevenueComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingRevenueApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingRevenueApi()
        {
            mGetItemRevenueCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetRefundRevenueCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetRevenueByCountryCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetRevenueByItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetSubscriptionRevenueCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
        /// <summary>
        /// Get item revenue info Get basic info about revenue from sales of items and bundles (not subscriptions, shipping, etc), summed up within a time range
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        public void GetItemRevenue(string currencyCode, long? startDate, long? endDate)
        {
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetItemRevenue");
            }
            
            mGetItemRevenuePath = "/reporting/revenue/item-sales/{currency_code}";
            if (!string.IsNullOrEmpty(mGetItemRevenuePath))
            {
                mGetItemRevenuePath = mGetItemRevenuePath.Replace("{format}", "json");
            }
            mGetItemRevenuePath = mGetItemRevenuePath.Replace("{" + "currency_code" + "}", KnetikClient.DefaultClient.ParameterToString(currencyCode));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (startDate != null)
            {
                queryParams.Add("start_date", KnetikClient.DefaultClient.ParameterToString(startDate));
            }

            if (endDate != null)
            {
                queryParams.Add("end_date", KnetikClient.DefaultClient.ParameterToString(endDate));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetItemRevenueStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetItemRevenueStartTime, mGetItemRevenuePath, "Sending server request...");

            // make the HTTP request
            mGetItemRevenueCoroutine.ResponseReceived += GetItemRevenueCallback;
            mGetItemRevenueCoroutine.Start(mGetItemRevenuePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetItemRevenueCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetItemRevenue: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetItemRevenue: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetItemRevenueData = (RevenueReportResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(RevenueReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetItemRevenueStartTime, mGetItemRevenuePath, string.Format("Response received successfully:\n{0}", GetItemRevenueData.ToString()));

            if (GetItemRevenueComplete != null)
            {
                GetItemRevenueComplete(GetItemRevenueData);
            }
        }
        /// <summary>
        /// Get refund revenue info Get basic info about revenue loss from refunds (for all item types), summed up within a time range.
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get refund data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        public void GetRefundRevenue(string currencyCode, long? startDate, long? endDate)
        {
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetRefundRevenue");
            }
            
            mGetRefundRevenuePath = "/reporting/revenue/refunds/{currency_code}";
            if (!string.IsNullOrEmpty(mGetRefundRevenuePath))
            {
                mGetRefundRevenuePath = mGetRefundRevenuePath.Replace("{format}", "json");
            }
            mGetRefundRevenuePath = mGetRefundRevenuePath.Replace("{" + "currency_code" + "}", KnetikClient.DefaultClient.ParameterToString(currencyCode));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (startDate != null)
            {
                queryParams.Add("start_date", KnetikClient.DefaultClient.ParameterToString(startDate));
            }

            if (endDate != null)
            {
                queryParams.Add("end_date", KnetikClient.DefaultClient.ParameterToString(endDate));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetRefundRevenueStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetRefundRevenueStartTime, mGetRefundRevenuePath, "Sending server request...");

            // make the HTTP request
            mGetRefundRevenueCoroutine.ResponseReceived += GetRefundRevenueCallback;
            mGetRefundRevenueCoroutine.Start(mGetRefundRevenuePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetRefundRevenueCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRefundRevenue: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRefundRevenue: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetRefundRevenueData = (RevenueReportResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(RevenueReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetRefundRevenueStartTime, mGetRefundRevenuePath, string.Format("Response received successfully:\n{0}", GetRefundRevenueData.ToString()));

            if (GetRefundRevenueComplete != null)
            {
                GetRefundRevenueComplete(GetRefundRevenueData);
            }
        }
        /// <summary>
        /// Get revenue info by country Get basic info about revenue from sales of all types, summed up within a time range and split out by country. Sorted for largest revenue at the top
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetRevenueByCountry(string currencyCode, long? startDate, long? endDate, int? size, int? page)
        {
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetRevenueByCountry");
            }
            
            mGetRevenueByCountryPath = "/reporting/revenue/countries/{currency_code}";
            if (!string.IsNullOrEmpty(mGetRevenueByCountryPath))
            {
                mGetRevenueByCountryPath = mGetRevenueByCountryPath.Replace("{format}", "json");
            }
            mGetRevenueByCountryPath = mGetRevenueByCountryPath.Replace("{" + "currency_code" + "}", KnetikClient.DefaultClient.ParameterToString(currencyCode));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

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

            mGetRevenueByCountryStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetRevenueByCountryStartTime, mGetRevenueByCountryPath, "Sending server request...");

            // make the HTTP request
            mGetRevenueByCountryCoroutine.ResponseReceived += GetRevenueByCountryCallback;
            mGetRevenueByCountryCoroutine.Start(mGetRevenueByCountryPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetRevenueByCountryCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRevenueByCountry: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRevenueByCountry: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetRevenueByCountryData = (PageResourceRevenueCountryReportResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceRevenueCountryReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetRevenueByCountryStartTime, mGetRevenueByCountryPath, string.Format("Response received successfully:\n{0}", GetRevenueByCountryData.ToString()));

            if (GetRevenueByCountryComplete != null)
            {
                GetRevenueByCountryComplete(GetRevenueByCountryData);
            }
        }
        /// <summary>
        /// Get revenue info by item Get basic info about revenue from sales of all types, summed up within a time range and split out by specific item. Sorted for largest revenue at the top
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetRevenueByItem(string currencyCode, long? startDate, long? endDate, int? size, int? page)
        {
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetRevenueByItem");
            }
            
            mGetRevenueByItemPath = "/reporting/revenue/products/{currency_code}";
            if (!string.IsNullOrEmpty(mGetRevenueByItemPath))
            {
                mGetRevenueByItemPath = mGetRevenueByItemPath.Replace("{format}", "json");
            }
            mGetRevenueByItemPath = mGetRevenueByItemPath.Replace("{" + "currency_code" + "}", KnetikClient.DefaultClient.ParameterToString(currencyCode));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

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

            mGetRevenueByItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetRevenueByItemStartTime, mGetRevenueByItemPath, "Sending server request...");

            // make the HTTP request
            mGetRevenueByItemCoroutine.ResponseReceived += GetRevenueByItemCallback;
            mGetRevenueByItemCoroutine.Start(mGetRevenueByItemPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetRevenueByItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRevenueByItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRevenueByItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetRevenueByItemData = (PageResourceRevenueProductReportResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceRevenueProductReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetRevenueByItemStartTime, mGetRevenueByItemPath, string.Format("Response received successfully:\n{0}", GetRevenueByItemData.ToString()));

            if (GetRevenueByItemComplete != null)
            {
                GetRevenueByItemComplete(GetRevenueByItemData);
            }
        }
        /// <summary>
        /// Get subscription revenue info Get basic info about revenue from sales of new subscriptions as well as recurring payemnts, summed up within a time range
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        public void GetSubscriptionRevenue(string currencyCode, long? startDate, long? endDate)
        {
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetSubscriptionRevenue");
            }
            
            mGetSubscriptionRevenuePath = "/reporting/revenue/subscription-sales/{currency_code}";
            if (!string.IsNullOrEmpty(mGetSubscriptionRevenuePath))
            {
                mGetSubscriptionRevenuePath = mGetSubscriptionRevenuePath.Replace("{format}", "json");
            }
            mGetSubscriptionRevenuePath = mGetSubscriptionRevenuePath.Replace("{" + "currency_code" + "}", KnetikClient.DefaultClient.ParameterToString(currencyCode));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (startDate != null)
            {
                queryParams.Add("start_date", KnetikClient.DefaultClient.ParameterToString(startDate));
            }

            if (endDate != null)
            {
                queryParams.Add("end_date", KnetikClient.DefaultClient.ParameterToString(endDate));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetSubscriptionRevenueStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetSubscriptionRevenueStartTime, mGetSubscriptionRevenuePath, "Sending server request...");

            // make the HTTP request
            mGetSubscriptionRevenueCoroutine.ResponseReceived += GetSubscriptionRevenueCallback;
            mGetSubscriptionRevenueCoroutine.Start(mGetSubscriptionRevenuePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetSubscriptionRevenueCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSubscriptionRevenue: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSubscriptionRevenue: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetSubscriptionRevenueData = (RevenueReportResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(RevenueReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetSubscriptionRevenueStartTime, mGetSubscriptionRevenuePath, string.Format("Response received successfully:\n{0}", GetSubscriptionRevenueData.ToString()));

            if (GetSubscriptionRevenueComplete != null)
            {
                GetSubscriptionRevenueComplete(GetSubscriptionRevenueData);
            }
        }
    }
}
