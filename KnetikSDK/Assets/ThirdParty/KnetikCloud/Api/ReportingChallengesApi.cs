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
    public interface IReportingChallengesApi
    {
        /// <summary>
        /// Retrieve a challenge event leaderboard details Lists all leaderboard entries with additional user details
        /// </summary>
        /// <param name="filterEvent">A sepecific challenge event id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceChallengeEventParticipantResource</returns>
        PageResourceChallengeEventParticipantResource GetChallengeEventLeaderboard (long? filterEvent, int? size, int? page, string order);
        /// <summary>
        /// Retrieve a challenge event participant details Lists all user submitted scores sorted by value, including those that do not apear in the leaderboard due to value or aggregation
        /// </summary>
        /// <param name="filterEvent">A sepecific challenge event id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceChallengeEventParticipantResource</returns>
        PageResourceChallengeEventParticipantResource GetChallengeEventParticipants (long? filterEvent, int? size, int? page, string order);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingChallengesApi : IReportingChallengesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingChallengesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingChallengesApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Retrieve a challenge event leaderboard details Lists all leaderboard entries with additional user details
        /// </summary>
        /// <param name="filterEvent">A sepecific challenge event id</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceChallengeEventParticipantResource</returns>            
        public PageResourceChallengeEventParticipantResource GetChallengeEventLeaderboard(long? filterEvent, int? size, int? page, string order)
        {
            
            string urlPath = "/reporting/events/leaderboard";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterEvent != null)
            {
                queryParams.Add("filter_event", KnetikClient.ParameterToString(filterEvent));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetChallengeEventLeaderboard: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetChallengeEventLeaderboard: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceChallengeEventParticipantResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceChallengeEventParticipantResource), response.Headers);
        }
        /// <summary>
        /// Retrieve a challenge event participant details Lists all user submitted scores sorted by value, including those that do not apear in the leaderboard due to value or aggregation
        /// </summary>
        /// <param name="filterEvent">A sepecific challenge event id</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceChallengeEventParticipantResource</returns>            
        public PageResourceChallengeEventParticipantResource GetChallengeEventParticipants(long? filterEvent, int? size, int? page, string order)
        {
            
            string urlPath = "/reporting/events/participants";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterEvent != null)
            {
                queryParams.Add("filter_event", KnetikClient.ParameterToString(filterEvent));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetChallengeEventParticipants: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetChallengeEventParticipants: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceChallengeEventParticipantResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceChallengeEventParticipantResource), response.Headers);
        }
    }
}
