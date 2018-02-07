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
    public interface IUtilVersionApi
    {
        Version GetVersionData { get; }

        /// <summary>
        /// Get current version info 
        /// </summary>
        void GetVersion();

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UtilVersionApi : IUtilVersionApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetVersionResponseContext;
        private DateTime mGetVersionStartTime;

        public Version GetVersionData { get; private set; }
        public delegate void GetVersionCompleteDelegate(long responseCode, Version response);
        public GetVersionCompleteDelegate GetVersionComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilVersionApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UtilVersionApi()
        {
            mGetVersionResponseContext = new KnetikResponseContext();
            mGetVersionResponseContext.ResponseReceived += OnGetVersionResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get current version info 
        /// </summary>
        public void GetVersion()
        {
            
            mWebCallEvent.WebPath = "/version";
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
            mGetVersionStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetVersionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetVersionStartTime, "GetVersion", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetVersionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetVersion: " + response.Error);
            }

            GetVersionData = (Version) KnetikClient.Deserialize(response.Content, typeof(Version), response.Headers);
            KnetikLogger.LogResponse(mGetVersionStartTime, "GetVersion", string.Format("Response received successfully:\n{0}", GetVersionData));

            if (GetVersionComplete != null)
            {
                GetVersionComplete(response.ResponseCode, GetVersionData);
            }
        }

    }
}
