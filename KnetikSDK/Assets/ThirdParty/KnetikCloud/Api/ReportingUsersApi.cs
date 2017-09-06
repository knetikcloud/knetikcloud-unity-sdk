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
    public interface IReportingUsersApi
    {
        /// <summary>
        /// Get user registration info Get user registration counts grouped by time range
        /// </summary>
        /// <param name="granularity">The time duration to aggregate by</param>
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param>
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceAggregateCountResource</returns>
        PageResourceAggregateCountResource GetUserRegistrations (string granularity, long? startDate, long? endDate, int? size, int? page);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingUsersApi : IReportingUsersApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingUsersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingUsersApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Get user registration info Get user registration counts grouped by time range
        /// </summary>
        /// <param name="granularity">The time duration to aggregate by</param> 
        /// <param name="startDate">The start of the time range to aggregate, unix timestamp in seconds. Default is beginning of time</param> 
        /// <param name="endDate">The end of the time range to aggregate, unix timestamp in seconds. Default is end of time</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceAggregateCountResource</returns>            
        public PageResourceAggregateCountResource GetUserRegistrations(string granularity, long? startDate, long? endDate, int? size, int? page)
        {
            
            string urlPath = "/reporting/users/registrations";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (granularity != null)
            {
                queryParams.Add("granularity", KnetikClient.ParameterToString(granularity));
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserRegistrations: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserRegistrations: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceAggregateCountResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceAggregateCountResource), response.Headers);
        }
    }
}
