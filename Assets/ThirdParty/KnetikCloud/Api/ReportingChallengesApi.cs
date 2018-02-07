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
    public interface IReportingChallengesApi
    {
        PageResourceChallengeEventParticipantResource GetChallengeEventLeaderboardData { get; }

        /// <summary>
        /// Retrieve a challenge event leaderboard details Lists all leaderboard entries with additional user details
        /// </summary>
        /// <param name="filterEvent">A sepecific challenge event id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetChallengeEventLeaderboard(long? filterEvent, int? size, int? page, string order);

        PageResourceChallengeEventParticipantResource GetChallengeEventParticipantsData { get; }

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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetChallengeEventLeaderboardResponseContext;
        private DateTime mGetChallengeEventLeaderboardStartTime;
        private readonly KnetikResponseContext mGetChallengeEventParticipantsResponseContext;
        private DateTime mGetChallengeEventParticipantsStartTime;

        public PageResourceChallengeEventParticipantResource GetChallengeEventLeaderboardData { get; private set; }
        public delegate void GetChallengeEventLeaderboardCompleteDelegate(long responseCode, PageResourceChallengeEventParticipantResource response);
        public GetChallengeEventLeaderboardCompleteDelegate GetChallengeEventLeaderboardComplete;

        public PageResourceChallengeEventParticipantResource GetChallengeEventParticipantsData { get; private set; }
        public delegate void GetChallengeEventParticipantsCompleteDelegate(long responseCode, PageResourceChallengeEventParticipantResource response);
        public GetChallengeEventParticipantsCompleteDelegate GetChallengeEventParticipantsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportingChallengesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ReportingChallengesApi()
        {
            mGetChallengeEventLeaderboardResponseContext = new KnetikResponseContext();
            mGetChallengeEventLeaderboardResponseContext.ResponseReceived += OnGetChallengeEventLeaderboardResponse;
            mGetChallengeEventParticipantsResponseContext = new KnetikResponseContext();
            mGetChallengeEventParticipantsResponseContext.ResponseReceived += OnGetChallengeEventParticipantsResponse;
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
            
            mWebCallEvent.WebPath = "/reporting/events/leaderboard";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterEvent != null)
            {
                mWebCallEvent.QueryParams["filter_event"] = KnetikClient.ParameterToString(filterEvent);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (order != null)
            {
                mWebCallEvent.QueryParams["order"] = KnetikClient.ParameterToString(order);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetChallengeEventLeaderboardStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChallengeEventLeaderboardResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChallengeEventLeaderboardStartTime, "GetChallengeEventLeaderboard", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChallengeEventLeaderboardResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChallengeEventLeaderboard: " + response.Error);
            }

            GetChallengeEventLeaderboardData = (PageResourceChallengeEventParticipantResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceChallengeEventParticipantResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeEventLeaderboardStartTime, "GetChallengeEventLeaderboard", string.Format("Response received successfully:\n{0}", GetChallengeEventLeaderboardData));

            if (GetChallengeEventLeaderboardComplete != null)
            {
                GetChallengeEventLeaderboardComplete(response.ResponseCode, GetChallengeEventLeaderboardData);
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
            
            mWebCallEvent.WebPath = "/reporting/events/participants";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterEvent != null)
            {
                mWebCallEvent.QueryParams["filter_event"] = KnetikClient.ParameterToString(filterEvent);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (order != null)
            {
                mWebCallEvent.QueryParams["order"] = KnetikClient.ParameterToString(order);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetChallengeEventParticipantsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChallengeEventParticipantsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChallengeEventParticipantsStartTime, "GetChallengeEventParticipants", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChallengeEventParticipantsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChallengeEventParticipants: " + response.Error);
            }

            GetChallengeEventParticipantsData = (PageResourceChallengeEventParticipantResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceChallengeEventParticipantResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeEventParticipantsStartTime, "GetChallengeEventParticipants", string.Format("Response received successfully:\n{0}", GetChallengeEventParticipantsData));

            if (GetChallengeEventParticipantsComplete != null)
            {
                GetChallengeEventParticipantsComplete(response.ResponseCode, GetChallengeEventParticipantsData);
            }
        }

    }
}
