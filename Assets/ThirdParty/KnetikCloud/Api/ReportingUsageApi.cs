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
    public interface IReportingUsageApi
    {
        PageResourceUsageInfo GetUsageByDayData { get; }

        /// <summary>
        /// Returns aggregated endpoint usage information by day &lt;b&gt;Permissions Needed:&lt;/b&gt; USAGE_ADMIN
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoint. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsageByDay(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);

        PageResourceUsageInfo GetUsageByHourData { get; }

        /// <summary>
        /// Returns aggregated endpoint usage information by hour &lt;b&gt;Permissions Needed:&lt;/b&gt; USAGE_ADMIN
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoint. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsageByHour(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);

        PageResourceUsageInfo GetUsageByMinuteData { get; }

        /// <summary>
        /// Returns aggregated endpoint usage information by minute &lt;b&gt;Permissions Needed:&lt;/b&gt; USAGE_ADMIN
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoint. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsageByMinute(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);

        PageResourceUsageInfo GetUsageByMonthData { get; }

        /// <summary>
        /// Returns aggregated endpoint usage information by month &lt;b&gt;Permissions Needed:&lt;/b&gt; USAGE_ADMIN
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoint. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsageByMonth(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);

        PageResourceUsageInfo GetUsageByYearData { get; }

        /// <summary>
        /// Returns aggregated endpoint usage information by year &lt;b&gt;Permissions Needed:&lt;/b&gt; USAGE_ADMIN
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoints. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsageByYear(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);

        List<string> GetUsageEndpointsData { get; }

        /// <summary>
        /// Returns list of endpoints called (method and url) &lt;b&gt;Permissions Needed:&lt;/b&gt; USAGE_ADMIN
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        void GetUsageEndpoints(long? startDate, long? endDate);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingUsageApi : IReportingUsageApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetUsageByDayResponseContext;
        private DateTime mGetUsageByDayStartTime;
        private readonly KnetikResponseContext mGetUsageByHourResponseContext;
        private DateTime mGetUsageByHourStartTime;
        private readonly KnetikResponseContext mGetUsageByMinuteResponseContext;
        private DateTime mGetUsageByMinuteStartTime;
        private readonly KnetikResponseContext mGetUsageByMonthResponseContext;
        private DateTime mGetUsageByMonthStartTime;
        private readonly KnetikResponseContext mGetUsageByYearResponseContext;
        private DateTime mGetUsageByYearStartTime;
        private readonly KnetikResponseContext mGetUsageEndpointsResponseContext;
        private DateTime mGetUsageEndpointsStartTime;

        public PageResourceUsageInfo GetUsageByDayData { get; private set; }
        public delegate void GetUsageByDayCompleteDelegate(long responseCode, PageResourceUsageInfo response);
        public GetUsageByDayCompleteDelegate GetUsageByDayComplete;

        public PageResourceUsageInfo GetUsageByHourData { get; private set; }
        public delegate void GetUsageByHourCompleteDelegate(long responseCode, PageResourceUsageInfo response);
        public GetUsageByHourCompleteDelegate GetUsageByHourComplete;

        public PageResourceUsageInfo GetUsageByMinuteData { get; private set; }
        public delegate void GetUsageByMinuteCompleteDelegate(long responseCode, PageResourceUsageInfo response);
        public GetUsageByMinuteCompleteDelegate GetUsageByMinuteComplete;

        public PageResourceUsageInfo GetUsageByMonthData { get; private set; }
        public delegate void GetUsageByMonthCompleteDelegate(long responseCode, PageResourceUsageInfo response);
        public GetUsageByMonthCompleteDelegate GetUsageByMonthComplete;

        public PageResourceUsageInfo GetUsageByYearData { get; private set; }
        public delegate void GetUsageByYearCompleteDelegate(long responseCode, PageResourceUsageInfo response);
        public GetUsageByYearCompleteDelegate GetUsageByYearComplete;

        public List<string> GetUsageEndpointsData { get; private set; }
        public delegate void GetUsageEndpointsCompleteDelegate(long responseCode, List<string> response);
        public GetUsageEndpointsCompleteDelegate GetUsageEndpointsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingUsageApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingUsageApi()
        {
            mGetUsageByDayResponseContext = new KnetikResponseContext();
            mGetUsageByDayResponseContext.ResponseReceived += OnGetUsageByDayResponse;
            mGetUsageByHourResponseContext = new KnetikResponseContext();
            mGetUsageByHourResponseContext.ResponseReceived += OnGetUsageByHourResponse;
            mGetUsageByMinuteResponseContext = new KnetikResponseContext();
            mGetUsageByMinuteResponseContext.ResponseReceived += OnGetUsageByMinuteResponse;
            mGetUsageByMonthResponseContext = new KnetikResponseContext();
            mGetUsageByMonthResponseContext.ResponseReceived += OnGetUsageByMonthResponse;
            mGetUsageByYearResponseContext = new KnetikResponseContext();
            mGetUsageByYearResponseContext.ResponseReceived += OnGetUsageByYearResponse;
            mGetUsageEndpointsResponseContext = new KnetikResponseContext();
            mGetUsageEndpointsResponseContext.ResponseReceived += OnGetUsageEndpointsResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Returns aggregated endpoint usage information by day &lt;b&gt;Permissions Needed:&lt;/b&gt; USAGE_ADMIN
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoint. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetUsageByDay(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page)
        {
            // verify the required parameter 'startDate' is set
            if (startDate == null)
            {
                throw new KnetikException(400, "Missing required parameter 'startDate' when calling GetUsageByDay");
            }
            // verify the required parameter 'endDate' is set
            if (endDate == null)
            {
                throw new KnetikException(400, "Missing required parameter 'endDate' when calling GetUsageByDay");
            }
            
            mWebCallEvent.WebPath = "/reporting/usage/day";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
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

            if (combineEndpoints != null)
            {
                mWebCallEvent.QueryParams["combine_endpoints"] = KnetikClient.ParameterToString(combineEndpoints);
            }

            if (method != null)
            {
                mWebCallEvent.QueryParams["method"] = KnetikClient.ParameterToString(method);
            }

            if (url != null)
            {
                mWebCallEvent.QueryParams["url"] = KnetikClient.ParameterToString(url);
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
            mGetUsageByDayStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUsageByDayResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUsageByDayStartTime, "GetUsageByDay", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUsageByDayResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUsageByDay: " + response.Error);
            }

            GetUsageByDayData = (PageResourceUsageInfo) KnetikClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
            KnetikLogger.LogResponse(mGetUsageByDayStartTime, "GetUsageByDay", string.Format("Response received successfully:\n{0}", GetUsageByDayData));

            if (GetUsageByDayComplete != null)
            {
                GetUsageByDayComplete(response.ResponseCode, GetUsageByDayData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns aggregated endpoint usage information by hour &lt;b&gt;Permissions Needed:&lt;/b&gt; USAGE_ADMIN
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoint. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetUsageByHour(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page)
        {
            // verify the required parameter 'startDate' is set
            if (startDate == null)
            {
                throw new KnetikException(400, "Missing required parameter 'startDate' when calling GetUsageByHour");
            }
            // verify the required parameter 'endDate' is set
            if (endDate == null)
            {
                throw new KnetikException(400, "Missing required parameter 'endDate' when calling GetUsageByHour");
            }
            
            mWebCallEvent.WebPath = "/reporting/usage/hour";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
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

            if (combineEndpoints != null)
            {
                mWebCallEvent.QueryParams["combine_endpoints"] = KnetikClient.ParameterToString(combineEndpoints);
            }

            if (method != null)
            {
                mWebCallEvent.QueryParams["method"] = KnetikClient.ParameterToString(method);
            }

            if (url != null)
            {
                mWebCallEvent.QueryParams["url"] = KnetikClient.ParameterToString(url);
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
            mGetUsageByHourStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUsageByHourResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUsageByHourStartTime, "GetUsageByHour", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUsageByHourResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUsageByHour: " + response.Error);
            }

            GetUsageByHourData = (PageResourceUsageInfo) KnetikClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
            KnetikLogger.LogResponse(mGetUsageByHourStartTime, "GetUsageByHour", string.Format("Response received successfully:\n{0}", GetUsageByHourData));

            if (GetUsageByHourComplete != null)
            {
                GetUsageByHourComplete(response.ResponseCode, GetUsageByHourData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns aggregated endpoint usage information by minute &lt;b&gt;Permissions Needed:&lt;/b&gt; USAGE_ADMIN
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoint. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetUsageByMinute(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page)
        {
            // verify the required parameter 'startDate' is set
            if (startDate == null)
            {
                throw new KnetikException(400, "Missing required parameter 'startDate' when calling GetUsageByMinute");
            }
            // verify the required parameter 'endDate' is set
            if (endDate == null)
            {
                throw new KnetikException(400, "Missing required parameter 'endDate' when calling GetUsageByMinute");
            }
            
            mWebCallEvent.WebPath = "/reporting/usage/minute";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
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

            if (combineEndpoints != null)
            {
                mWebCallEvent.QueryParams["combine_endpoints"] = KnetikClient.ParameterToString(combineEndpoints);
            }

            if (method != null)
            {
                mWebCallEvent.QueryParams["method"] = KnetikClient.ParameterToString(method);
            }

            if (url != null)
            {
                mWebCallEvent.QueryParams["url"] = KnetikClient.ParameterToString(url);
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
            mGetUsageByMinuteStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUsageByMinuteResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUsageByMinuteStartTime, "GetUsageByMinute", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUsageByMinuteResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUsageByMinute: " + response.Error);
            }

            GetUsageByMinuteData = (PageResourceUsageInfo) KnetikClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
            KnetikLogger.LogResponse(mGetUsageByMinuteStartTime, "GetUsageByMinute", string.Format("Response received successfully:\n{0}", GetUsageByMinuteData));

            if (GetUsageByMinuteComplete != null)
            {
                GetUsageByMinuteComplete(response.ResponseCode, GetUsageByMinuteData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns aggregated endpoint usage information by month &lt;b&gt;Permissions Needed:&lt;/b&gt; USAGE_ADMIN
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoint. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetUsageByMonth(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page)
        {
            // verify the required parameter 'startDate' is set
            if (startDate == null)
            {
                throw new KnetikException(400, "Missing required parameter 'startDate' when calling GetUsageByMonth");
            }
            // verify the required parameter 'endDate' is set
            if (endDate == null)
            {
                throw new KnetikException(400, "Missing required parameter 'endDate' when calling GetUsageByMonth");
            }
            
            mWebCallEvent.WebPath = "/reporting/usage/month";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
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

            if (combineEndpoints != null)
            {
                mWebCallEvent.QueryParams["combine_endpoints"] = KnetikClient.ParameterToString(combineEndpoints);
            }

            if (method != null)
            {
                mWebCallEvent.QueryParams["method"] = KnetikClient.ParameterToString(method);
            }

            if (url != null)
            {
                mWebCallEvent.QueryParams["url"] = KnetikClient.ParameterToString(url);
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
            mGetUsageByMonthStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUsageByMonthResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUsageByMonthStartTime, "GetUsageByMonth", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUsageByMonthResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUsageByMonth: " + response.Error);
            }

            GetUsageByMonthData = (PageResourceUsageInfo) KnetikClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
            KnetikLogger.LogResponse(mGetUsageByMonthStartTime, "GetUsageByMonth", string.Format("Response received successfully:\n{0}", GetUsageByMonthData));

            if (GetUsageByMonthComplete != null)
            {
                GetUsageByMonthComplete(response.ResponseCode, GetUsageByMonthData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns aggregated endpoint usage information by year &lt;b&gt;Permissions Needed:&lt;/b&gt; USAGE_ADMIN
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoints. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetUsageByYear(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page)
        {
            // verify the required parameter 'startDate' is set
            if (startDate == null)
            {
                throw new KnetikException(400, "Missing required parameter 'startDate' when calling GetUsageByYear");
            }
            // verify the required parameter 'endDate' is set
            if (endDate == null)
            {
                throw new KnetikException(400, "Missing required parameter 'endDate' when calling GetUsageByYear");
            }
            
            mWebCallEvent.WebPath = "/reporting/usage/year";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
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

            if (combineEndpoints != null)
            {
                mWebCallEvent.QueryParams["combine_endpoints"] = KnetikClient.ParameterToString(combineEndpoints);
            }

            if (method != null)
            {
                mWebCallEvent.QueryParams["method"] = KnetikClient.ParameterToString(method);
            }

            if (url != null)
            {
                mWebCallEvent.QueryParams["url"] = KnetikClient.ParameterToString(url);
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
            mGetUsageByYearStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUsageByYearResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUsageByYearStartTime, "GetUsageByYear", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUsageByYearResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUsageByYear: " + response.Error);
            }

            GetUsageByYearData = (PageResourceUsageInfo) KnetikClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
            KnetikLogger.LogResponse(mGetUsageByYearStartTime, "GetUsageByYear", string.Format("Response received successfully:\n{0}", GetUsageByYearData));

            if (GetUsageByYearComplete != null)
            {
                GetUsageByYearComplete(response.ResponseCode, GetUsageByYearData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns list of endpoints called (method and url) &lt;b&gt;Permissions Needed:&lt;/b&gt; USAGE_ADMIN
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        public void GetUsageEndpoints(long? startDate, long? endDate)
        {
            // verify the required parameter 'startDate' is set
            if (startDate == null)
            {
                throw new KnetikException(400, "Missing required parameter 'startDate' when calling GetUsageEndpoints");
            }
            // verify the required parameter 'endDate' is set
            if (endDate == null)
            {
                throw new KnetikException(400, "Missing required parameter 'endDate' when calling GetUsageEndpoints");
            }
            
            mWebCallEvent.WebPath = "/reporting/usage/endpoints";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
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
            mGetUsageEndpointsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUsageEndpointsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUsageEndpointsStartTime, "GetUsageEndpoints", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUsageEndpointsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUsageEndpoints: " + response.Error);
            }

            GetUsageEndpointsData = (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetUsageEndpointsStartTime, "GetUsageEndpoints", string.Format("Response received successfully:\n{0}", GetUsageEndpointsData));

            if (GetUsageEndpointsComplete != null)
            {
                GetUsageEndpointsComplete(response.ResponseCode, GetUsageEndpointsData);
            }
        }

    }
}
