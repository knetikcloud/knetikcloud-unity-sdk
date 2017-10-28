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
    public interface IReportingChallengesApi
    {
        PageResourceChallengeEventParticipantResource GetChallengeEventLeaderboardData { get; }

        PageResourceChallengeEventParticipantResource GetChallengeEventParticipantsData { get; }

        
        /// <summary>
        /// Retrieve a challenge event leaderboard details Lists all leaderboard entries with additional user details
        /// </summary>
        /// <param name="filterEvent">A sepecific challenge event id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetChallengeEventLeaderboard(long? filterEvent, int? size, int? page, string order);

        /// <summary>
        /// Retrieve a challenge event participant details Lists all user submitted scores sorted by value, including those that do not apear in the leaderboard due to value or aggregation
        /// </summary>
        /// <param name="filterEvent">A sepecific challenge event id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetChallengeEventParticipants(long? filterEvent, int? size, int? page, string order);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ReportingChallengesApi : IReportingChallengesApi
    {
        private readonly KnetikCoroutine mGetChallengeEventLeaderboardCoroutine;
        private DateTime mGetChallengeEventLeaderboardStartTime;
        private string mGetChallengeEventLeaderboardPath;
        private readonly KnetikCoroutine mGetChallengeEventParticipantsCoroutine;
        private DateTime mGetChallengeEventParticipantsStartTime;
        private string mGetChallengeEventParticipantsPath;

        public PageResourceChallengeEventParticipantResource GetChallengeEventLeaderboardData { get; private set; }
        public delegate void GetChallengeEventLeaderboardCompleteDelegate(PageResourceChallengeEventParticipantResource response);
        public GetChallengeEventLeaderboardCompleteDelegate GetChallengeEventLeaderboardComplete;

        public PageResourceChallengeEventParticipantResource GetChallengeEventParticipantsData { get; private set; }
        public delegate void GetChallengeEventParticipantsCompleteDelegate(PageResourceChallengeEventParticipantResource response);
        public GetChallengeEventParticipantsCompleteDelegate GetChallengeEventParticipantsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingChallengesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingChallengesApi()
        {
            mGetChallengeEventLeaderboardCoroutine = new KnetikCoroutine();
            mGetChallengeEventParticipantsCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Retrieve a challenge event leaderboard details Lists all leaderboard entries with additional user details
        /// </summary>
        /// <param name="filterEvent">A sepecific challenge event id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetChallengeEventLeaderboard(long? filterEvent, int? size, int? page, string order)
        {
            
            mGetChallengeEventLeaderboardPath = "/reporting/events/leaderboard";
            if (!string.IsNullOrEmpty(mGetChallengeEventLeaderboardPath))
            {
                mGetChallengeEventLeaderboardPath = mGetChallengeEventLeaderboardPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterEvent != null)
            {
                queryParams.Add("filter_event", KnetikClient.DefaultClient.ParameterToString(filterEvent));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.DefaultClient.ParameterToString(order));
            }

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetChallengeEventLeaderboardStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetChallengeEventLeaderboardStartTime, mGetChallengeEventLeaderboardPath, "Sending server request...");

            // make the HTTP request
            mGetChallengeEventLeaderboardCoroutine.ResponseReceived += GetChallengeEventLeaderboardCallback;
            mGetChallengeEventLeaderboardCoroutine.Start(mGetChallengeEventLeaderboardPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetChallengeEventLeaderboardCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeEventLeaderboard: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeEventLeaderboard: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetChallengeEventLeaderboardData = (PageResourceChallengeEventParticipantResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceChallengeEventParticipantResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeEventLeaderboardStartTime, mGetChallengeEventLeaderboardPath, string.Format("Response received successfully:\n{0}", GetChallengeEventLeaderboardData.ToString()));

            if (GetChallengeEventLeaderboardComplete != null)
            {
                GetChallengeEventLeaderboardComplete(GetChallengeEventLeaderboardData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve a challenge event participant details Lists all user submitted scores sorted by value, including those that do not apear in the leaderboard due to value or aggregation
        /// </summary>
        /// <param name="filterEvent">A sepecific challenge event id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetChallengeEventParticipants(long? filterEvent, int? size, int? page, string order)
        {
            
            mGetChallengeEventParticipantsPath = "/reporting/events/participants";
            if (!string.IsNullOrEmpty(mGetChallengeEventParticipantsPath))
            {
                mGetChallengeEventParticipantsPath = mGetChallengeEventParticipantsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterEvent != null)
            {
                queryParams.Add("filter_event", KnetikClient.DefaultClient.ParameterToString(filterEvent));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.DefaultClient.ParameterToString(order));
            }

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetChallengeEventParticipantsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetChallengeEventParticipantsStartTime, mGetChallengeEventParticipantsPath, "Sending server request...");

            // make the HTTP request
            mGetChallengeEventParticipantsCoroutine.ResponseReceived += GetChallengeEventParticipantsCallback;
            mGetChallengeEventParticipantsCoroutine.Start(mGetChallengeEventParticipantsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetChallengeEventParticipantsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeEventParticipants: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeEventParticipants: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetChallengeEventParticipantsData = (PageResourceChallengeEventParticipantResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceChallengeEventParticipantResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeEventParticipantsStartTime, mGetChallengeEventParticipantsPath, string.Format("Response received successfully:\n{0}", GetChallengeEventParticipantsData.ToString()));

            if (GetChallengeEventParticipantsComplete != null)
            {
                GetChallengeEventParticipantsComplete(GetChallengeEventParticipantsData);
            }
        }

    }
}
