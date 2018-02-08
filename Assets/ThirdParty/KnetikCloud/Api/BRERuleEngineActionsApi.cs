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
    public interface IBRERuleEngineActionsApi
    {
        List<ActionResource> GetBREActionsData { get; }

        /// <summary>
        /// Get a list of available actions &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_ACTIONS_USER
        /// </summary>
        /// <param name="filterCategory">Filter for actions that are within a specific category</param>
        /// <param name="filterName">Filter for actions that have names containing the given string</param>
        /// <param name="filterTags">Filter for actions that have all of the given tags (comma separated list)</param>
        /// <param name="filterSearch">Filter for actions containing the given words somewhere within name, description and tags</param>
        void GetBREActions(string filterCategory, string filterName, string filterTags, string filterSearch);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineActionsApi : IBRERuleEngineActionsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetBREActionsResponseContext;
        private DateTime mGetBREActionsStartTime;

        public List<ActionResource> GetBREActionsData { get; private set; }
        public delegate void GetBREActionsCompleteDelegate(long responseCode, List<ActionResource> response);
        public GetBREActionsCompleteDelegate GetBREActionsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineActionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineActionsApi()
        {
            mGetBREActionsResponseContext = new KnetikResponseContext();
            mGetBREActionsResponseContext.ResponseReceived += OnGetBREActionsResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get a list of available actions &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_ACTIONS_USER
        /// </summary>
        /// <param name="filterCategory">Filter for actions that are within a specific category</param>
        /// <param name="filterName">Filter for actions that have names containing the given string</param>
        /// <param name="filterTags">Filter for actions that have all of the given tags (comma separated list)</param>
        /// <param name="filterSearch">Filter for actions containing the given words somewhere within name, description and tags</param>
        public void GetBREActions(string filterCategory, string filterName, string filterTags, string filterSearch)
        {
            
            mWebCallEvent.WebPath = "/bre/actions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterCategory != null)
            {
                mWebCallEvent.QueryParams["filter_category"] = KnetikClient.ParameterToString(filterCategory);
            }

            if (filterName != null)
            {
                mWebCallEvent.QueryParams["filter_name"] = KnetikClient.ParameterToString(filterName);
            }

            if (filterTags != null)
            {
                mWebCallEvent.QueryParams["filter_tags"] = KnetikClient.ParameterToString(filterTags);
            }

            if (filterSearch != null)
            {
                mWebCallEvent.QueryParams["filter_search"] = KnetikClient.ParameterToString(filterSearch);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetBREActionsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBREActionsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBREActionsStartTime, "GetBREActions", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBREActionsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBREActions: " + response.Error);
            }

            GetBREActionsData = (List<ActionResource>) KnetikClient.Deserialize(response.Content, typeof(List<ActionResource>), response.Headers);
            KnetikLogger.LogResponse(mGetBREActionsStartTime, "GetBREActions", string.Format("Response received successfully:\n{0}", GetBREActionsData));

            if (GetBREActionsComplete != null)
            {
                GetBREActionsComplete(response.ResponseCode, GetBREActionsData);
            }
        }

    }
}
