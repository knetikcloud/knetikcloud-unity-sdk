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
    public interface IReportingUsageApi
    {
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
        /// <returns>PageResourceUsageInfo</returns>
        PageResourceUsageInfo GetUsageByDay (long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);
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
        /// <returns>PageResourceUsageInfo</returns>
        PageResourceUsageInfo GetUsageByHour (long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);
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
        /// <returns>PageResourceUsageInfo</returns>
        PageResourceUsageInfo GetUsageByMinute (long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);
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
        /// <returns>PageResourceUsageInfo</returns>
        PageResourceUsageInfo GetUsageByMonth (long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);
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
        /// <returns>PageResourceUsageInfo</returns>
        PageResourceUsageInfo GetUsageByYear (long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page);
        /// <summary>
        /// Returns list of endpoints called (method and url) 
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param>
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetUsageEndpoints (long? startDate, long? endDate);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingUsageApi : IReportingUsageApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingUsageApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingUsageApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

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
        /// <returns>PageResourceUsageInfo</returns>            
        public PageResourceUsageInfo GetUsageByDay(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page)
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
            
            
            string urlPath = "/reporting/usage/day";
            //urlPath = urlPath.Replace("{format}", "json");
                
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
            
            if (combineEndpoints != null)
            {
                queryParams.Add("combine_endpoints", KnetikClient.ParameterToString(combineEndpoints));
            }
            
            if (method != null)
            {
                queryParams.Add("method", KnetikClient.ParameterToString(method));
            }
            
            if (url != null)
            {
                queryParams.Add("url", KnetikClient.ParameterToString(url));
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsageByDay: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsageByDay: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceUsageInfo) KnetikClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
        }
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
        /// <returns>PageResourceUsageInfo</returns>            
        public PageResourceUsageInfo GetUsageByHour(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page)
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
            
            
            string urlPath = "/reporting/usage/hour";
            //urlPath = urlPath.Replace("{format}", "json");
                
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
            
            if (combineEndpoints != null)
            {
                queryParams.Add("combine_endpoints", KnetikClient.ParameterToString(combineEndpoints));
            }
            
            if (method != null)
            {
                queryParams.Add("method", KnetikClient.ParameterToString(method));
            }
            
            if (url != null)
            {
                queryParams.Add("url", KnetikClient.ParameterToString(url));
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsageByHour: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsageByHour: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceUsageInfo) KnetikClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
        }
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
        /// <returns>PageResourceUsageInfo</returns>            
        public PageResourceUsageInfo GetUsageByMinute(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page)
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
            
            
            string urlPath = "/reporting/usage/minute";
            //urlPath = urlPath.Replace("{format}", "json");
                
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
            
            if (combineEndpoints != null)
            {
                queryParams.Add("combine_endpoints", KnetikClient.ParameterToString(combineEndpoints));
            }
            
            if (method != null)
            {
                queryParams.Add("method", KnetikClient.ParameterToString(method));
            }
            
            if (url != null)
            {
                queryParams.Add("url", KnetikClient.ParameterToString(url));
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsageByMinute: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsageByMinute: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceUsageInfo) KnetikClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
        }
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
        /// <returns>PageResourceUsageInfo</returns>            
        public PageResourceUsageInfo GetUsageByMonth(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page)
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
            
            
            string urlPath = "/reporting/usage/month";
            //urlPath = urlPath.Replace("{format}", "json");
                
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
            
            if (combineEndpoints != null)
            {
                queryParams.Add("combine_endpoints", KnetikClient.ParameterToString(combineEndpoints));
            }
            
            if (method != null)
            {
                queryParams.Add("method", KnetikClient.ParameterToString(method));
            }
            
            if (url != null)
            {
                queryParams.Add("url", KnetikClient.ParameterToString(url));
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsageByMonth: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsageByMonth: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceUsageInfo) KnetikClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
        }
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
        /// <returns>PageResourceUsageInfo</returns>            
        public PageResourceUsageInfo GetUsageByYear(long? startDate, long? endDate, bool? combineEndpoints, string method, string url, int? size, int? page)
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
            
            
            string urlPath = "/reporting/usage/year";
            //urlPath = urlPath.Replace("{format}", "json");
                
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
            
            if (combineEndpoints != null)
            {
                queryParams.Add("combine_endpoints", KnetikClient.ParameterToString(combineEndpoints));
            }
            
            if (method != null)
            {
                queryParams.Add("method", KnetikClient.ParameterToString(method));
            }
            
            if (url != null)
            {
                queryParams.Add("url", KnetikClient.ParameterToString(url));
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsageByYear: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsageByYear: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceUsageInfo) KnetikClient.Deserialize(response.Content, typeof(PageResourceUsageInfo), response.Headers);
        }
        /// <summary>
        /// Returns list of endpoints called (method and url) 
        /// </summary>
        /// <param name="startDate">The beginning of the range being requested, unix timestamp in seconds</param> 
        /// <param name="endDate">The ending of the range being requested, unix timestamp in seconds</param> 
        /// <returns>List&lt;string&gt;</returns>            
        public List<string> GetUsageEndpoints(long? startDate, long? endDate)
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
            
            
            string urlPath = "/reporting/usage/endpoints";
            //urlPath = urlPath.Replace("{format}", "json");
                
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsageEndpoints: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsageEndpoints: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
        }
    }
}
