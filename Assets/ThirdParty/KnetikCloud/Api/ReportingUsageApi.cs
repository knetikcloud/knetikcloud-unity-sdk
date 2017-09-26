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
    public interface IReportingUsageApi
    {
        PageResourceUsageInfo GetUsageByDayData { get; }

        PageResourceUsageInfo GetUsageByHourData { get; }

        PageResourceUsageInfo GetUsageByMinuteData { get; }

        PageResourceUsageInfo GetUsageByMonthData { get; }

        PageResourceUsageInfo GetUsageByYearData { get; }

        List<string> GetUsageEndpointsData { get; }

        
        /// <summary>
        /// Returns aggregated endpoint usage information by day 
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoint. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsageByDay(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);

        /// <summary>
        /// Returns aggregated endpoint usage information by hour 
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoint. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsageByHour(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);

        /// <summary>
        /// Returns aggregated endpoint usage information by minute 
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoint. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsageByMinute(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);

        /// <summary>
        /// Returns aggregated endpoint usage information by month 
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoint. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsageByMonth(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);

        /// <summary>
        /// Returns aggregated endpoint usage information by year 
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <param name="combineEndpoints">Whether to combine counts from different endpoints. Removes the url and method from the result object</param>
        /// <param name="method">Filter for a certain endpoint method.  Must include url as well to work</param>
        /// <param name="url">Filter for a certain endpoint.  Must include method as well to work</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsageByYear(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);

        /// <summary>
        /// Returns list of endpoints called (method and url) 
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
        private readonly KnetikCoroutine mGetUsageByDayCoroutine;
        private DateTime mGetUsageByDayStartTime;
        private string mGetUsageByDayPath;
        private readonly KnetikCoroutine mGetUsageByHourCoroutine;
        private DateTime mGetUsageByHourStartTime;
        private string mGetUsageByHourPath;
        private readonly KnetikCoroutine mGetUsageByMinuteCoroutine;
        private DateTime mGetUsageByMinuteStartTime;
        private string mGetUsageByMinutePath;
        private readonly KnetikCoroutine mGetUsageByMonthCoroutine;
        private DateTime mGetUsageByMonthStartTime;
        private string mGetUsageByMonthPath;
        private readonly KnetikCoroutine mGetUsageByYearCoroutine;
        private DateTime mGetUsageByYearStartTime;
        private string mGetUsageByYearPath;
        private readonly KnetikCoroutine mGetUsageEndpointsCoroutine;
        private DateTime mGetUsageEndpointsStartTime;
        private string mGetUsageEndpointsPath;

        public PageResourceUsageInfo GetUsageByDayData { get; private set; }
        public delegate void GetUsageByDayCompleteDelegate(PageResourceUsageInfo response);
        public GetUsageByDayCompleteDelegate GetUsageByDayComplete;

        public PageResourceUsageInfo GetUsageByHourData { get; private set; }
        public delegate void GetUsageByHourCompleteDelegate(PageResourceUsageInfo response);
        public GetUsageByHourCompleteDelegate GetUsageByHourComplete;

        public PageResourceUsageInfo GetUsageByMinuteData { get; private set; }
        public delegate void GetUsageByMinuteCompleteDelegate(PageResourceUsageInfo response);
        public GetUsageByMinuteCompleteDelegate GetUsageByMinuteComplete;

        public PageResourceUsageInfo GetUsageByMonthData { get; private set; }
        public delegate void GetUsageByMonthCompleteDelegate(PageResourceUsageInfo response);
        public GetUsageByMonthCompleteDelegate GetUsageByMonthComplete;

        public PageResourceUsageInfo GetUsageByYearData { get; private set; }
        public delegate void GetUsageByYearCompleteDelegate(PageResourceUsageInfo response);
        public GetUsageByYearCompleteDelegate GetUsageByYearComplete;

        public List<string> GetUsageEndpointsData { get; private set; }
        public delegate void GetUsageEndpointsCompleteDelegate(List<string> response);
        public GetUsageEndpointsCompleteDelegate GetUsageEndpointsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingUsageApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingUsageApi()
        {
            mGetUsageByDayCoroutine = new KnetikCoroutine();
            mGetUsageByHourCoroutine = new KnetikCoroutine();
            mGetUsageByMinuteCoroutine = new KnetikCoroutine();
            mGetUsageByMonthCoroutine = new KnetikCoroutine();
            mGetUsageByYearCoroutine = new KnetikCoroutine();
            mGetUsageEndpointsCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Returns aggregated endpoint usage information by day 
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
            
            mGetUsageByDayPath = "/reporting/usage/day";
            if (!string.IsNullOrEmpty(mGetUsageByDayPath))
            {
                mGetUsageByDayPath = mGetUsageByDayPath.Replace("{format}", "json");
            }
            
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

            if (combineEndpoints != null)
            {
                queryParams.Add("combine_endpoints", KnetikClient.DefaultClient.ParameterToString(combineEndpoints));
            }

            if (method != null)
            {
                queryParams.Add("method", KnetikClient.DefaultClient.ParameterToString(method));
            }

            if (url != null)
            {
                queryParams.Add("url", KnetikClient.DefaultClient.ParameterToString(url));
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

            mGetUsageByDayStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUsageByDayStartTime, mGetUsageByDayPath, "Sending server request...");

            // make the HTTP request
            mGetUsageByDayCoroutine.ResponseReceived += GetUsageByDayCallback;
            mGetUsageByDayCoroutine.Start(mGetUsageByDayPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUsageByDayCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsageByDay: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsageByDay: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUsageByDayData = (PageResourceUsageInfo) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
            KnetikLogger.LogResponse(mGetUsageByDayStartTime, mGetUsageByDayPath, string.Format("Response received successfully:\n{0}", GetUsageByDayData.ToString()));

            if (GetUsageByDayComplete != null)
            {
                GetUsageByDayComplete(GetUsageByDayData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Returns aggregated endpoint usage information by hour 
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
            
            mGetUsageByHourPath = "/reporting/usage/hour";
            if (!string.IsNullOrEmpty(mGetUsageByHourPath))
            {
                mGetUsageByHourPath = mGetUsageByHourPath.Replace("{format}", "json");
            }
            
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

            if (combineEndpoints != null)
            {
                queryParams.Add("combine_endpoints", KnetikClient.DefaultClient.ParameterToString(combineEndpoints));
            }

            if (method != null)
            {
                queryParams.Add("method", KnetikClient.DefaultClient.ParameterToString(method));
            }

            if (url != null)
            {
                queryParams.Add("url", KnetikClient.DefaultClient.ParameterToString(url));
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

            mGetUsageByHourStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUsageByHourStartTime, mGetUsageByHourPath, "Sending server request...");

            // make the HTTP request
            mGetUsageByHourCoroutine.ResponseReceived += GetUsageByHourCallback;
            mGetUsageByHourCoroutine.Start(mGetUsageByHourPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUsageByHourCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsageByHour: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsageByHour: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUsageByHourData = (PageResourceUsageInfo) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
            KnetikLogger.LogResponse(mGetUsageByHourStartTime, mGetUsageByHourPath, string.Format("Response received successfully:\n{0}", GetUsageByHourData.ToString()));

            if (GetUsageByHourComplete != null)
            {
                GetUsageByHourComplete(GetUsageByHourData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Returns aggregated endpoint usage information by minute 
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
            
            mGetUsageByMinutePath = "/reporting/usage/minute";
            if (!string.IsNullOrEmpty(mGetUsageByMinutePath))
            {
                mGetUsageByMinutePath = mGetUsageByMinutePath.Replace("{format}", "json");
            }
            
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

            if (combineEndpoints != null)
            {
                queryParams.Add("combine_endpoints", KnetikClient.DefaultClient.ParameterToString(combineEndpoints));
            }

            if (method != null)
            {
                queryParams.Add("method", KnetikClient.DefaultClient.ParameterToString(method));
            }

            if (url != null)
            {
                queryParams.Add("url", KnetikClient.DefaultClient.ParameterToString(url));
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

            mGetUsageByMinuteStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUsageByMinuteStartTime, mGetUsageByMinutePath, "Sending server request...");

            // make the HTTP request
            mGetUsageByMinuteCoroutine.ResponseReceived += GetUsageByMinuteCallback;
            mGetUsageByMinuteCoroutine.Start(mGetUsageByMinutePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUsageByMinuteCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsageByMinute: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsageByMinute: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUsageByMinuteData = (PageResourceUsageInfo) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
            KnetikLogger.LogResponse(mGetUsageByMinuteStartTime, mGetUsageByMinutePath, string.Format("Response received successfully:\n{0}", GetUsageByMinuteData.ToString()));

            if (GetUsageByMinuteComplete != null)
            {
                GetUsageByMinuteComplete(GetUsageByMinuteData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Returns aggregated endpoint usage information by month 
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
            
            mGetUsageByMonthPath = "/reporting/usage/month";
            if (!string.IsNullOrEmpty(mGetUsageByMonthPath))
            {
                mGetUsageByMonthPath = mGetUsageByMonthPath.Replace("{format}", "json");
            }
            
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

            if (combineEndpoints != null)
            {
                queryParams.Add("combine_endpoints", KnetikClient.DefaultClient.ParameterToString(combineEndpoints));
            }

            if (method != null)
            {
                queryParams.Add("method", KnetikClient.DefaultClient.ParameterToString(method));
            }

            if (url != null)
            {
                queryParams.Add("url", KnetikClient.DefaultClient.ParameterToString(url));
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

            mGetUsageByMonthStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUsageByMonthStartTime, mGetUsageByMonthPath, "Sending server request...");

            // make the HTTP request
            mGetUsageByMonthCoroutine.ResponseReceived += GetUsageByMonthCallback;
            mGetUsageByMonthCoroutine.Start(mGetUsageByMonthPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUsageByMonthCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsageByMonth: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsageByMonth: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUsageByMonthData = (PageResourceUsageInfo) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
            KnetikLogger.LogResponse(mGetUsageByMonthStartTime, mGetUsageByMonthPath, string.Format("Response received successfully:\n{0}", GetUsageByMonthData.ToString()));

            if (GetUsageByMonthComplete != null)
            {
                GetUsageByMonthComplete(GetUsageByMonthData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Returns aggregated endpoint usage information by year 
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
            
            mGetUsageByYearPath = "/reporting/usage/year";
            if (!string.IsNullOrEmpty(mGetUsageByYearPath))
            {
                mGetUsageByYearPath = mGetUsageByYearPath.Replace("{format}", "json");
            }
            
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

            if (combineEndpoints != null)
            {
                queryParams.Add("combine_endpoints", KnetikClient.DefaultClient.ParameterToString(combineEndpoints));
            }

            if (method != null)
            {
                queryParams.Add("method", KnetikClient.DefaultClient.ParameterToString(method));
            }

            if (url != null)
            {
                queryParams.Add("url", KnetikClient.DefaultClient.ParameterToString(url));
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

            mGetUsageByYearStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUsageByYearStartTime, mGetUsageByYearPath, "Sending server request...");

            // make the HTTP request
            mGetUsageByYearCoroutine.ResponseReceived += GetUsageByYearCallback;
            mGetUsageByYearCoroutine.Start(mGetUsageByYearPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUsageByYearCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsageByYear: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsageByYear: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUsageByYearData = (PageResourceUsageInfo) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
            KnetikLogger.LogResponse(mGetUsageByYearStartTime, mGetUsageByYearPath, string.Format("Response received successfully:\n{0}", GetUsageByYearData.ToString()));

            if (GetUsageByYearComplete != null)
            {
                GetUsageByYearComplete(GetUsageByYearData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Returns list of endpoints called (method and url) 
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
            
            mGetUsageEndpointsPath = "/reporting/usage/endpoints";
            if (!string.IsNullOrEmpty(mGetUsageEndpointsPath))
            {
                mGetUsageEndpointsPath = mGetUsageEndpointsPath.Replace("{format}", "json");
            }
            
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

            mGetUsageEndpointsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUsageEndpointsStartTime, mGetUsageEndpointsPath, "Sending server request...");

            // make the HTTP request
            mGetUsageEndpointsCoroutine.ResponseReceived += GetUsageEndpointsCallback;
            mGetUsageEndpointsCoroutine.Start(mGetUsageEndpointsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUsageEndpointsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsageEndpoints: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsageEndpoints: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUsageEndpointsData = (List<string>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetUsageEndpointsStartTime, mGetUsageEndpointsPath, string.Format("Response received successfully:\n{0}", GetUsageEndpointsData.ToString()));

            if (GetUsageEndpointsComplete != null)
            {
                GetUsageEndpointsComplete(GetUsageEndpointsData);
            }
        }
    }
}
