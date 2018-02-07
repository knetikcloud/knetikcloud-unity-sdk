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
    public interface IGamificationLeaderboardsApi
    {
        LeaderboardResource GetLeaderboardData { get; }

        /// <summary>
        /// Retrieves leaderboard details and paginated entries The context type identifies the type of entity (i.e., &#39;activity&#39;) being tracked on the leaderboard. The context ID is the unique ID of the actual entity tracked by the leaderboard. Sorting is based on the fields of LeaderboardEntryResource rather than the returned LeaderboardResource.
        /// </summary>
        /// <param name="contextType">The context type for the leaderboard</param>
        /// <param name="contextId">The context id for the leaderboard</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetLeaderboard(string contextType, string contextId, int? size, int? page, string order);

        LeaderboardEntryResource GetLeaderboardRankData { get; }

        /// <summary>
        /// Retrieves a specific user entry with rank The context type identifies the type of entity (i.e., &#39;activity&#39;) being tracked on the leaderboard. The context ID is the unique ID of the actual entity tracked by the leaderboard
        /// </summary>
        /// <param name="contextType">The context type for the leaderboard</param>
        /// <param name="contextId">The context id for the leaderboard</param>
        /// <param name="id">The id of a user</param>
        void GetLeaderboardRank(string contextType, string contextId, string id);

        List<string> GetLeaderboardStrategiesData { get; }

        /// <summary>
        /// Get a list of available leaderboard strategy names 
        /// </summary>
        void GetLeaderboardStrategies();

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class GamificationLeaderboardsApi : IGamificationLeaderboardsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetLeaderboardResponseContext;
        private DateTime mGetLeaderboardStartTime;
        private readonly KnetikResponseContext mGetLeaderboardRankResponseContext;
        private DateTime mGetLeaderboardRankStartTime;
        private readonly KnetikResponseContext mGetLeaderboardStrategiesResponseContext;
        private DateTime mGetLeaderboardStrategiesStartTime;

        public LeaderboardResource GetLeaderboardData { get; private set; }
        public delegate void GetLeaderboardCompleteDelegate(long responseCode, LeaderboardResource response);
        public GetLeaderboardCompleteDelegate GetLeaderboardComplete;

        public LeaderboardEntryResource GetLeaderboardRankData { get; private set; }
        public delegate void GetLeaderboardRankCompleteDelegate(long responseCode, LeaderboardEntryResource response);
        public GetLeaderboardRankCompleteDelegate GetLeaderboardRankComplete;

        public List<string> GetLeaderboardStrategiesData { get; private set; }
        public delegate void GetLeaderboardStrategiesCompleteDelegate(long responseCode, List<string> response);
        public GetLeaderboardStrategiesCompleteDelegate GetLeaderboardStrategiesComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamificationLeaderboardsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GamificationLeaderboardsApi()
        {
            mGetLeaderboardResponseContext = new KnetikResponseContext();
            mGetLeaderboardResponseContext.ResponseReceived += OnGetLeaderboardResponse;
            mGetLeaderboardRankResponseContext = new KnetikResponseContext();
            mGetLeaderboardRankResponseContext.ResponseReceived += OnGetLeaderboardRankResponse;
            mGetLeaderboardStrategiesResponseContext = new KnetikResponseContext();
            mGetLeaderboardStrategiesResponseContext.ResponseReceived += OnGetLeaderboardStrategiesResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Retrieves leaderboard details and paginated entries The context type identifies the type of entity (i.e., &#39;activity&#39;) being tracked on the leaderboard. The context ID is the unique ID of the actual entity tracked by the leaderboard. Sorting is based on the fields of LeaderboardEntryResource rather than the returned LeaderboardResource.
        /// </summary>
        /// <param name="contextType">The context type for the leaderboard</param>
        /// <param name="contextId">The context id for the leaderboard</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetLeaderboard(string contextType, string contextId, int? size, int? page, string order)
        {
            // verify the required parameter 'contextType' is set
            if (contextType == null)
            {
                throw new KnetikException(400, "Missing required parameter 'contextType' when calling GetLeaderboard");
            }
            // verify the required parameter 'contextId' is set
            if (contextId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'contextId' when calling GetLeaderboard");
            }
            
            mWebCallEvent.WebPath = "/leaderboards/{context_type}/{context_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "context_type" + "}", KnetikClient.ParameterToString(contextType));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "context_id" + "}", KnetikClient.ParameterToString(contextId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

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
            mGetLeaderboardStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetLeaderboardResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetLeaderboardStartTime, "GetLeaderboard", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetLeaderboardResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetLeaderboard: " + response.Error);
            }

            GetLeaderboardData = (LeaderboardResource) KnetikClient.Deserialize(response.Content, typeof(LeaderboardResource), response.Headers);
            KnetikLogger.LogResponse(mGetLeaderboardStartTime, "GetLeaderboard", string.Format("Response received successfully:\n{0}", GetLeaderboardData));

            if (GetLeaderboardComplete != null)
            {
                GetLeaderboardComplete(response.ResponseCode, GetLeaderboardData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieves a specific user entry with rank The context type identifies the type of entity (i.e., &#39;activity&#39;) being tracked on the leaderboard. The context ID is the unique ID of the actual entity tracked by the leaderboard
        /// </summary>
        /// <param name="contextType">The context type for the leaderboard</param>
        /// <param name="contextId">The context id for the leaderboard</param>
        /// <param name="id">The id of a user</param>
        public void GetLeaderboardRank(string contextType, string contextId, string id)
        {
            // verify the required parameter 'contextType' is set
            if (contextType == null)
            {
                throw new KnetikException(400, "Missing required parameter 'contextType' when calling GetLeaderboardRank");
            }
            // verify the required parameter 'contextId' is set
            if (contextId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'contextId' when calling GetLeaderboardRank");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetLeaderboardRank");
            }
            
            mWebCallEvent.WebPath = "/leaderboards/{context_type}/{context_id}/users/{id}/rank";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "context_type" + "}", KnetikClient.ParameterToString(contextType));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "context_id" + "}", KnetikClient.ParameterToString(contextId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetLeaderboardRankStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetLeaderboardRankResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetLeaderboardRankStartTime, "GetLeaderboardRank", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetLeaderboardRankResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetLeaderboardRank: " + response.Error);
            }

            GetLeaderboardRankData = (LeaderboardEntryResource) KnetikClient.Deserialize(response.Content, typeof(LeaderboardEntryResource), response.Headers);
            KnetikLogger.LogResponse(mGetLeaderboardRankStartTime, "GetLeaderboardRank", string.Format("Response received successfully:\n{0}", GetLeaderboardRankData));

            if (GetLeaderboardRankComplete != null)
            {
                GetLeaderboardRankComplete(response.ResponseCode, GetLeaderboardRankData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a list of available leaderboard strategy names 
        /// </summary>
        public void GetLeaderboardStrategies()
        {
            
            mWebCallEvent.WebPath = "/leaderboards/strategies";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetLeaderboardStrategiesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetLeaderboardStrategiesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetLeaderboardStrategiesStartTime, "GetLeaderboardStrategies", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetLeaderboardStrategiesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetLeaderboardStrategies: " + response.Error);
            }

            GetLeaderboardStrategiesData = (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetLeaderboardStrategiesStartTime, "GetLeaderboardStrategies", string.Format("Response received successfully:\n{0}", GetLeaderboardStrategiesData));

            if (GetLeaderboardStrategiesComplete != null)
            {
                GetLeaderboardStrategiesComplete(response.ResponseCode, GetLeaderboardStrategiesData);
            }
        }

    }
}
