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
    public interface IGamificationLeaderboardsApi
    {
        /// <summary>
        /// Retrieves leaderboard details and paginated entries The context type identifies the type of entity (i.e., &#39;activity&#39;) being tracked on the leaderboard. The context ID is the unique ID of the actual entity tracked by the leaderboard. Sorting is based on the fields of LeaderboardEntryResource rather than the returned LeaderboardResource.
        /// </summary>
        /// <param name="contextType">The context type for the leaderboard</param>
        /// <param name="contextId">The context id for the leaderboard</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>LeaderboardResource</returns>
        LeaderboardResource GetLeaderboard (string contextType, string contextId, int? size, int? page, string order);
        /// <summary>
        /// Retrieves a specific user entry with rank The context type identifies the type of entity (i.e., &#39;activity&#39;) being tracked on the leaderboard. The context ID is the unique ID of the actual entity tracked by the leaderboard
        /// </summary>
        /// <param name="contextType">The context type for the leaderboard</param>
        /// <param name="contextId">The context id for the leaderboard</param>
        /// <param name="id">The id of a user</param>
        /// <returns>LeaderboardEntryResource</returns>
        LeaderboardEntryResource GetLeaderboardRank (string contextType, string contextId, string id);
        /// <summary>
        /// Get a list of available leaderboard strategy names 
        /// </summary>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetLeaderboardStrategies ();
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class GamificationLeaderboardsApi : IGamificationLeaderboardsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GamificationLeaderboardsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GamificationLeaderboardsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Retrieves leaderboard details and paginated entries The context type identifies the type of entity (i.e., &#39;activity&#39;) being tracked on the leaderboard. The context ID is the unique ID of the actual entity tracked by the leaderboard. Sorting is based on the fields of LeaderboardEntryResource rather than the returned LeaderboardResource.
        /// </summary>
        /// <param name="contextType">The context type for the leaderboard</param> 
        /// <param name="contextId">The context id for the leaderboard</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>LeaderboardResource</returns>            
        public LeaderboardResource GetLeaderboard(string contextType, string contextId, int? size, int? page, string order)
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
            
            
            string urlPath = "/leaderboards/{context_type}/{context_id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "context_type" + "}", KnetikClient.ParameterToString(contextType));
urlPath = urlPath.Replace("{" + "context_id" + "}", KnetikClient.ParameterToString(contextId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

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
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetLeaderboard: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetLeaderboard: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (LeaderboardResource) KnetikClient.Deserialize(response.Content, typeof(LeaderboardResource), response.Headers);
        }
        /// <summary>
        /// Retrieves a specific user entry with rank The context type identifies the type of entity (i.e., &#39;activity&#39;) being tracked on the leaderboard. The context ID is the unique ID of the actual entity tracked by the leaderboard
        /// </summary>
        /// <param name="contextType">The context type for the leaderboard</param> 
        /// <param name="contextId">The context id for the leaderboard</param> 
        /// <param name="id">The id of a user</param> 
        /// <returns>LeaderboardEntryResource</returns>            
        public LeaderboardEntryResource GetLeaderboardRank(string contextType, string contextId, string id)
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
            
            
            string urlPath = "/leaderboards/{context_type}/{context_id}/users/{id}/rank";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "context_type" + "}", KnetikClient.ParameterToString(contextType));
urlPath = urlPath.Replace("{" + "context_id" + "}", KnetikClient.ParameterToString(contextId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetLeaderboardRank: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetLeaderboardRank: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (LeaderboardEntryResource) KnetikClient.Deserialize(response.Content, typeof(LeaderboardEntryResource), response.Headers);
        }
        /// <summary>
        /// Get a list of available leaderboard strategy names 
        /// </summary>
        /// <returns>List&lt;string&gt;</returns>            
        public List<string> GetLeaderboardStrategies()
        {
            
            string urlPath = "/leaderboards/strategies";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetLeaderboardStrategies: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetLeaderboardStrategies: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
        }
    }
}
