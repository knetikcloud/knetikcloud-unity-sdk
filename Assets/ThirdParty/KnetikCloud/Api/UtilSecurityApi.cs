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
    public interface IUtilSecurityApi
    {
        PageResourceLocationLogResource GetUserLocationLogData { get; }

        /// <summary>
        /// Returns the authentication log for a user A log entry is recorded everytime a user requests a new token. Standard pagination available
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetUserLocationLog(int? userId, int? size, int? page, string order);

        TokenDetailsResource GetUserTokenDetailsData { get; }

        /// <summary>
        /// Returns the authentication token details. Use /users endpoint for detailed user&#39;s info 
        /// </summary>
        void GetUserTokenDetails();

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UtilSecurityApi : IUtilSecurityApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetUserLocationLogResponseContext;
        private DateTime mGetUserLocationLogStartTime;
        private readonly KnetikResponseContext mGetUserTokenDetailsResponseContext;
        private DateTime mGetUserTokenDetailsStartTime;

        public PageResourceLocationLogResource GetUserLocationLogData { get; private set; }
        public delegate void GetUserLocationLogCompleteDelegate(long responseCode, PageResourceLocationLogResource response);
        public GetUserLocationLogCompleteDelegate GetUserLocationLogComplete;

        public TokenDetailsResource GetUserTokenDetailsData { get; private set; }
        public delegate void GetUserTokenDetailsCompleteDelegate(long responseCode, TokenDetailsResource response);
        public GetUserTokenDetailsCompleteDelegate GetUserTokenDetailsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilSecurityApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UtilSecurityApi()
        {
            mGetUserLocationLogResponseContext = new KnetikResponseContext();
            mGetUserLocationLogResponseContext.ResponseReceived += OnGetUserLocationLogResponse;
            mGetUserTokenDetailsResponseContext = new KnetikResponseContext();
            mGetUserTokenDetailsResponseContext.ResponseReceived += OnGetUserTokenDetailsResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Returns the authentication log for a user A log entry is recorded everytime a user requests a new token. Standard pagination available
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetUserLocationLog(int? userId, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/security/country-log";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (userId != null)
            {
                mWebCallEvent.QueryParams["user_id"] = KnetikClient.ParameterToString(userId);
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
            mGetUserLocationLogStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserLocationLogResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserLocationLogStartTime, "GetUserLocationLog", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserLocationLogResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserLocationLog: " + response.Error);
            }

            GetUserLocationLogData = (PageResourceLocationLogResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceLocationLogResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserLocationLogStartTime, "GetUserLocationLog", string.Format("Response received successfully:\n{0}", GetUserLocationLogData));

            if (GetUserLocationLogComplete != null)
            {
                GetUserLocationLogComplete(response.ResponseCode, GetUserLocationLogData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the authentication token details. Use /users endpoint for detailed user&#39;s info 
        /// </summary>
        public void GetUserTokenDetails()
        {
            
            mWebCallEvent.WebPath = "/me";
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
            mGetUserTokenDetailsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserTokenDetailsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserTokenDetailsStartTime, "GetUserTokenDetails", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserTokenDetailsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserTokenDetails: " + response.Error);
            }

            GetUserTokenDetailsData = (TokenDetailsResource) KnetikClient.Deserialize(response.Content, typeof(TokenDetailsResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserTokenDetailsStartTime, "GetUserTokenDetails", string.Format("Response received successfully:\n{0}", GetUserTokenDetailsData));

            if (GetUserTokenDetailsComplete != null)
            {
                GetUserTokenDetailsComplete(response.ResponseCode, GetUserTokenDetailsData);
            }
        }

    }
}
