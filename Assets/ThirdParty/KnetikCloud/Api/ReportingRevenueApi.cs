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
    public interface IReportingRevenueApi
    {
        RevenueReportResource GetItemRevenueData { get; }

        /// <summary>
        /// Get item revenue info Get basic info about revenue from sales of items and bundles (not subscriptions, shipping, etc), summed up within a time range
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        void GetItemRevenue(string currencyCode, long? startDate, long? endDate);

        RevenueReportResource GetRefundRevenueData { get; }

        /// <summary>
        /// Get refund revenue info Get basic info about revenue loss from refunds (for all item types), summed up within a time range.
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get refund data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        void GetRefundRevenue(string currencyCode, long? startDate, long? endDate);

        PageResourceRevenueCountryReportResource GetRevenueByCountryData { get; }

        /// <summary>
        /// Get revenue info by country Get basic info about revenue from sales of all types, summed up within a time range and split out by country. Sorted for largest revenue at the top
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetRevenueByCountry(string currencyCode, long? startDate, long? endDate, int? size, int? page);

        PageResourceRevenueProductReportResource GetRevenueByItemData { get; }

        /// <summary>
        /// Get revenue info by item Get basic info about revenue from sales of all types, summed up within a time range and split out by specific item. Sorted for largest revenue at the top
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetRevenueByItem(string currencyCode, long? startDate, long? endDate, int? size, int? page);

        RevenueReportResource GetSubscriptionRevenueData { get; }

        /// <summary>
        /// Get subscription revenue info Get basic info about revenue from sales of new subscriptions as well as recurring payemnts, summed up within a time range
        /// </summary>
        /// <param name="currencyCode">The code for a currency to get sales data for</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        void GetSubscriptionRevenue(string currencyCode, long? startDate, long? endDate);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingRevenueApi : IReportingRevenueApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetItemRevenueResponseContext;
        private DateTime mGetItemRevenueStartTime;
        private readonly KnetikResponseContext mGetRefundRevenueResponseContext;
        private DateTime mGetRefundRevenueStartTime;
        private readonly KnetikResponseContext mGetRevenueByCountryResponseContext;
        private DateTime mGetRevenueByCountryStartTime;
        private readonly KnetikResponseContext mGetRevenueByItemResponseContext;
        private DateTime mGetRevenueByItemStartTime;
        private readonly KnetikResponseContext mGetSubscriptionRevenueResponseContext;
        private DateTime mGetSubscriptionRevenueStartTime;

        public RevenueReportResource GetItemRevenueData { get; private set; }
        public delegate void GetItemRevenueCompleteDelegate(long responseCode, RevenueReportResource response);
        public GetItemRevenueCompleteDelegate GetItemRevenueComplete;

        public RevenueReportResource GetRefundRevenueData { get; private set; }
        public delegate void GetRefundRevenueCompleteDelegate(long responseCode, RevenueReportResource response);
        public GetRefundRevenueCompleteDelegate GetRefundRevenueComplete;

        public PageResourceRevenueCountryReportResource GetRevenueByCountryData { get; private set; }
        public delegate void GetRevenueByCountryCompleteDelegate(long responseCode, PageResourceRevenueCountryReportResource response);
        public GetRevenueByCountryCompleteDelegate GetRevenueByCountryComplete;

        public PageResourceRevenueProductReportResource GetRevenueByItemData { get; private set; }
        public delegate void GetRevenueByItemCompleteDelegate(long responseCode, PageResourceRevenueProductReportResource response);
        public GetRevenueByItemCompleteDelegate GetRevenueByItemComplete;

        public RevenueReportResource GetSubscriptionRevenueData { get; private set; }
        public delegate void GetSubscriptionRevenueCompleteDelegate(long responseCode, RevenueReportResource response);
        public GetSubscriptionRevenueCompleteDelegate GetSubscriptionRevenueComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingRevenueApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingRevenueApi()
        {
            mGetItemRevenueResponseContext = new KnetikResponseContext();
            mGetItemRevenueResponseContext.ResponseReceived += OnGetItemRevenueResponse;
            mGetRefundRevenueResponseContext = new KnetikResponseContext();
            mGetRefundRevenueResponseContext.ResponseReceived += OnGetRefundRevenueResponse;
            mGetRevenueByCountryResponseContext = new KnetikResponseContext();
            mGetRevenueByCountryResponseContext.ResponseReceived += OnGetRevenueByCountryResponse;
            mGetRevenueByItemResponseContext = new KnetikResponseContext();
            mGetRevenueByItemResponseContext.ResponseReceived += OnGetRevenueByItemResponse;
            mGetSubscriptionRevenueResponseContext = new KnetikResponseContext();
            mGetSubscriptionRevenueResponseContext.ResponseReceived += OnGetSubscriptionRevenueResponse;
        }
    
        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/reporting/revenue/item-sales/{currency_code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (startDate != null)
            {
                mWebCallEvent.QueryParams["start_date"] = KnetikClient.ParameterToString(startDate);
            }

            if (endDate != null)
            {
                mWebCallEvent.QueryParams["end_date"] = KnetikClient.ParameterToString(endDate);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetItemRevenueStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetItemRevenueResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetItemRevenueStartTime, "GetItemRevenue", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetItemRevenueResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetItemRevenue: " + response.Error);
            }

            GetItemRevenueData = (RevenueReportResource) KnetikClient.Deserialize(response.Content, typeof(RevenueReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetItemRevenueStartTime, "GetItemRevenue", string.Format("Response received successfully:\n{0}", GetItemRevenueData));

            if (GetItemRevenueComplete != null)
            {
                GetItemRevenueComplete(response.ResponseCode, GetItemRevenueData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/reporting/revenue/refunds/{currency_code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (startDate != null)
            {
                mWebCallEvent.QueryParams["start_date"] = KnetikClient.ParameterToString(startDate);
            }

            if (endDate != null)
            {
                mWebCallEvent.QueryParams["end_date"] = KnetikClient.ParameterToString(endDate);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetRefundRevenueStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetRefundRevenueResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetRefundRevenueStartTime, "GetRefundRevenue", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetRefundRevenueResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetRefundRevenue: " + response.Error);
            }

            GetRefundRevenueData = (RevenueReportResource) KnetikClient.Deserialize(response.Content, typeof(RevenueReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetRefundRevenueStartTime, "GetRefundRevenue", string.Format("Response received successfully:\n{0}", GetRefundRevenueData));

            if (GetRefundRevenueComplete != null)
            {
                GetRefundRevenueComplete(response.ResponseCode, GetRefundRevenueData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/reporting/revenue/countries/{currency_code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

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
            mGetRevenueByCountryStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetRevenueByCountryResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetRevenueByCountryStartTime, "GetRevenueByCountry", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetRevenueByCountryResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetRevenueByCountry: " + response.Error);
            }

            GetRevenueByCountryData = (PageResourceRevenueCountryReportResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceRevenueCountryReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetRevenueByCountryStartTime, "GetRevenueByCountry", string.Format("Response received successfully:\n{0}", GetRevenueByCountryData));

            if (GetRevenueByCountryComplete != null)
            {
                GetRevenueByCountryComplete(response.ResponseCode, GetRevenueByCountryData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/reporting/revenue/products/{currency_code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

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
            mGetRevenueByItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetRevenueByItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetRevenueByItemStartTime, "GetRevenueByItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetRevenueByItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetRevenueByItem: " + response.Error);
            }

            GetRevenueByItemData = (PageResourceRevenueProductReportResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceRevenueProductReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetRevenueByItemStartTime, "GetRevenueByItem", string.Format("Response received successfully:\n{0}", GetRevenueByItemData));

            if (GetRevenueByItemComplete != null)
            {
                GetRevenueByItemComplete(response.ResponseCode, GetRevenueByItemData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/reporting/revenue/subscription-sales/{currency_code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (startDate != null)
            {
                mWebCallEvent.QueryParams["start_date"] = KnetikClient.ParameterToString(startDate);
            }

            if (endDate != null)
            {
                mWebCallEvent.QueryParams["end_date"] = KnetikClient.ParameterToString(endDate);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetSubscriptionRevenueStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetSubscriptionRevenueResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetSubscriptionRevenueStartTime, "GetSubscriptionRevenue", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetSubscriptionRevenueResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetSubscriptionRevenue: " + response.Error);
            }

            GetSubscriptionRevenueData = (RevenueReportResource) KnetikClient.Deserialize(response.Content, typeof(RevenueReportResource), response.Headers);
            KnetikLogger.LogResponse(mGetSubscriptionRevenueStartTime, "GetSubscriptionRevenue", string.Format("Response received successfully:\n{0}", GetSubscriptionRevenueData));

            if (GetSubscriptionRevenueComplete != null)
            {
                GetSubscriptionRevenueComplete(response.ResponseCode, GetSubscriptionRevenueData);
            }
        }

    }
}
