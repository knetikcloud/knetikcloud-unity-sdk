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
    public interface IUtilHealthApi
    {
        Object GetHealthData { get; }

        /// <summary>
        /// Get health info &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        void GetHealth();

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UtilHealthApi : IUtilHealthApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetHealthResponseContext;
        private DateTime mGetHealthStartTime;

        public Object GetHealthData { get; private set; }
        public delegate void GetHealthCompleteDelegate(long responseCode, Object response);
        public GetHealthCompleteDelegate GetHealthComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilHealthApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UtilHealthApi()
        {
            mGetHealthResponseContext = new KnetikResponseContext();
            mGetHealthResponseContext.ResponseReceived += OnGetHealthResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get health info &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        public void GetHealth()
        {
            
            mWebCallEvent.WebPath = "/health";
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
            mGetHealthStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetHealthResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetHealthStartTime, "GetHealth", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetHealthResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetHealth: " + response.Error);
            }

            GetHealthData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mGetHealthStartTime, "GetHealth", string.Format("Response received successfully:\n{0}", GetHealthData));

            if (GetHealthComplete != null)
            {
                GetHealthComplete(response.ResponseCode, GetHealthData);
            }
        }

    }
}
