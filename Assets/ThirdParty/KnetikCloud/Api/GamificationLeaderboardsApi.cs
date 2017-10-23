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
    public interface IGamificationLeaderboardsApi
    {
        LeaderboardResource GetLeaderboardData { get; }

        LeaderboardEntryResource GetLeaderboardRankData { get; }

        List<string> GetLeaderboardStrategiesData { get; }

        
        /// <summary>
        /// Retrieves leaderboard details and paginated entries The context type identifies the type of entity (i.e., &#39;activity&#39;) being tracked on the leaderboard. The context ID is the unique ID of the actual entity tracked by the leaderboard. Sorting is based on the fields of LeaderboardEntryResource rather than the returned LeaderboardResource.
        /// </summary>
        /// <param name="contextType">The context type for the leaderboard</param>
        /// <param name="contextId">The context id for the leaderboard</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetLeaderboard(string contextType, string contextId, int? size, int? page, string order);

        /// <summary>
        /// Retrieves a specific user entry with rank The context type identifies the type of entity (i.e., &#39;activity&#39;) being tracked on the leaderboard. The context ID is the unique ID of the actual entity tracked by the leaderboard
        /// </summary>
        /// <param name="contextType">The context type for the leaderboard</param>
        /// <param name="contextId">The context id for the leaderboard</param>
        /// <param name="id">The id of a user</param>
        void GetLeaderboardRank(string contextType, string contextId, string id);

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
        private readonly KnetikCoroutine mGetLeaderboardCoroutine;
        private DateTime mGetLeaderboardStartTime;
        private string mGetLeaderboardPath;
        private readonly KnetikCoroutine mGetLeaderboardRankCoroutine;
        private DateTime mGetLeaderboardRankStartTime;
        private string mGetLeaderboardRankPath;
        private readonly KnetikCoroutine mGetLeaderboardStrategiesCoroutine;
        private DateTime mGetLeaderboardStrategiesStartTime;
        private string mGetLeaderboardStrategiesPath;

        public LeaderboardResource GetLeaderboardData { get; private set; }
        public delegate void GetLeaderboardCompleteDelegate(LeaderboardResource response);
        public GetLeaderboardCompleteDelegate GetLeaderboardComplete;

        public LeaderboardEntryResource GetLeaderboardRankData { get; private set; }
        public delegate void GetLeaderboardRankCompleteDelegate(LeaderboardEntryResource response);
        public GetLeaderboardRankCompleteDelegate GetLeaderboardRankComplete;

        public List<string> GetLeaderboardStrategiesData { get; private set; }
        public delegate void GetLeaderboardStrategiesCompleteDelegate(List<string> response);
        public GetLeaderboardStrategiesCompleteDelegate GetLeaderboardStrategiesComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamificationLeaderboardsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GamificationLeaderboardsApi()
        {
            mGetLeaderboardCoroutine = new KnetikCoroutine();
            mGetLeaderboardRankCoroutine = new KnetikCoroutine();
            mGetLeaderboardStrategiesCoroutine = new KnetikCoroutine();
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
            
            mGetLeaderboardPath = "/leaderboards/{context_type}/{context_id}";
            if (!string.IsNullOrEmpty(mGetLeaderboardPath))
            {
                mGetLeaderboardPath = mGetLeaderboardPath.Replace("{format}", "json");
            }
            mGetLeaderboardPath = mGetLeaderboardPath.Replace("{" + "context_type" + "}", KnetikClient.DefaultClient.ParameterToString(contextType));
mGetLeaderboardPath = mGetLeaderboardPath.Replace("{" + "context_id" + "}", KnetikClient.DefaultClient.ParameterToString(contextId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

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
            string[] authSettings = new string[] {  };

            mGetLeaderboardStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetLeaderboardStartTime, mGetLeaderboardPath, "Sending server request...");

            // make the HTTP request
            mGetLeaderboardCoroutine.ResponseReceived += GetLeaderboardCallback;
            mGetLeaderboardCoroutine.Start(mGetLeaderboardPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetLeaderboardCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetLeaderboard: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetLeaderboard: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetLeaderboardData = (LeaderboardResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(LeaderboardResource), response.Headers);
            KnetikLogger.LogResponse(mGetLeaderboardStartTime, mGetLeaderboardPath, string.Format("Response received successfully:\n{0}", GetLeaderboardData.ToString()));

            if (GetLeaderboardComplete != null)
            {
                GetLeaderboardComplete(GetLeaderboardData);
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
            
            mGetLeaderboardRankPath = "/leaderboards/{context_type}/{context_id}/users/{id}/rank";
            if (!string.IsNullOrEmpty(mGetLeaderboardRankPath))
            {
                mGetLeaderboardRankPath = mGetLeaderboardRankPath.Replace("{format}", "json");
            }
            mGetLeaderboardRankPath = mGetLeaderboardRankPath.Replace("{" + "context_type" + "}", KnetikClient.DefaultClient.ParameterToString(contextType));
mGetLeaderboardRankPath = mGetLeaderboardRankPath.Replace("{" + "context_id" + "}", KnetikClient.DefaultClient.ParameterToString(contextId));
mGetLeaderboardRankPath = mGetLeaderboardRankPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetLeaderboardRankStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetLeaderboardRankStartTime, mGetLeaderboardRankPath, "Sending server request...");

            // make the HTTP request
            mGetLeaderboardRankCoroutine.ResponseReceived += GetLeaderboardRankCallback;
            mGetLeaderboardRankCoroutine.Start(mGetLeaderboardRankPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetLeaderboardRankCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetLeaderboardRank: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetLeaderboardRank: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetLeaderboardRankData = (LeaderboardEntryResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(LeaderboardEntryResource), response.Headers);
            KnetikLogger.LogResponse(mGetLeaderboardRankStartTime, mGetLeaderboardRankPath, string.Format("Response received successfully:\n{0}", GetLeaderboardRankData.ToString()));

            if (GetLeaderboardRankComplete != null)
            {
                GetLeaderboardRankComplete(GetLeaderboardRankData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a list of available leaderboard strategy names 
        /// </summary>
        public void GetLeaderboardStrategies()
        {
            
            mGetLeaderboardStrategiesPath = "/leaderboards/strategies";
            if (!string.IsNullOrEmpty(mGetLeaderboardStrategiesPath))
            {
                mGetLeaderboardStrategiesPath = mGetLeaderboardStrategiesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetLeaderboardStrategiesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetLeaderboardStrategiesStartTime, mGetLeaderboardStrategiesPath, "Sending server request...");

            // make the HTTP request
            mGetLeaderboardStrategiesCoroutine.ResponseReceived += GetLeaderboardStrategiesCallback;
            mGetLeaderboardStrategiesCoroutine.Start(mGetLeaderboardStrategiesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetLeaderboardStrategiesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetLeaderboardStrategies: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetLeaderboardStrategies: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetLeaderboardStrategiesData = (List<string>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetLeaderboardStrategiesStartTime, mGetLeaderboardStrategiesPath, string.Format("Response received successfully:\n{0}", GetLeaderboardStrategiesData.ToString()));

            if (GetLeaderboardStrategiesComplete != null)
            {
                GetLeaderboardStrategiesComplete(GetLeaderboardStrategiesData);
            }
        }

    }
}
