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
    public interface IBRERuleEngineActionsApi
    {
        List<ActionResource> GetBREActionsData { get; }

        
        /// <summary>
        /// Get a list of available actions 
        /// </summary>
        /// <param name="filterCategory">Filter for actions that are within a specific category</param>
        /// <param name="filterName">Filter for actions that have names containing the given string</param>
        /// <param name="filterTags">Filter for actions that have all of the given tags (comma separated list)</param>
        /// <param name="filterSearch">Filter for actions containing the given words somewhere within name, description and tags</param>
        void GetBREActions(string filterCategory, string filterName, string filterTags, string filterSearch);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineActionsApi : IBRERuleEngineActionsApi
    {
        private readonly KnetikCoroutine mGetBREActionsCoroutine;
        private DateTime mGetBREActionsStartTime;
        private string mGetBREActionsPath;

        public List<ActionResource> GetBREActionsData { get; private set; }
        public delegate void GetBREActionsCompleteDelegate(List<ActionResource> response);
        public GetBREActionsCompleteDelegate GetBREActionsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineActionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineActionsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
            mGetBREActionsCoroutine = new KnetikCoroutine(KnetikClient);
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient { get; private set; }

        /// <summary>
        /// Get a list of available actions 
        /// </summary>
        /// <param name="filterCategory">Filter for actions that are within a specific category</param>
        /// <param name="filterName">Filter for actions that have names containing the given string</param>
        /// <param name="filterTags">Filter for actions that have all of the given tags (comma separated list)</param>
        /// <param name="filterSearch">Filter for actions containing the given words somewhere within name, description and tags</param>
        public void GetBREActions(string filterCategory, string filterName, string filterTags, string filterSearch)
        {
            
            mGetBREActionsPath = "/bre/actions";
            if (!string.IsNullOrEmpty(mGetBREActionsPath))
            {
                mGetBREActionsPath = mGetBREActionsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.ParameterToString(filterCategory));
            }

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.ParameterToString(filterName));
            }

            if (filterTags != null)
            {
                queryParams.Add("filter_tags", KnetikClient.ParameterToString(filterTags));
            }

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.ParameterToString(filterSearch));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBREActionsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBREActionsStartTime, mGetBREActionsPath, "Sending server request...");

            // make the HTTP request
            mGetBREActionsCoroutine.ResponseReceived += GetBREActionsCallback;
            mGetBREActionsCoroutine.Start(mGetBREActionsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBREActionsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREActions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREActions: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBREActionsData = (List<ActionResource>) KnetikClient.Deserialize(response.Content, typeof(List<ActionResource>), response.Headers);
            KnetikLogger.LogResponse(mGetBREActionsStartTime, mGetBREActionsPath, string.Format("Response received successfully:\n{0}", GetBREActionsData.ToString()));

            if (GetBREActionsComplete != null)
            {
                GetBREActionsComplete(GetBREActionsData);
            }
        }
    }
}
