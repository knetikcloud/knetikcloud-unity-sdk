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
    public interface ISocialGoogleApi
    {
        

        /// <summary>
        /// Link google account Links the current user account to a google account, using the acccess token from google. Can also be used to update the access token after it has expired. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; Non-google user token
        /// </summary>
        /// <param name="googleToken">The token from google</param>
        void LinkAccounts1(GoogleToken googleToken);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class SocialGoogleApi : ISocialGoogleApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mLinkAccounts1ResponseContext;
        private DateTime mLinkAccounts1StartTime;

        public delegate void LinkAccounts1CompleteDelegate(long responseCode);
        public LinkAccounts1CompleteDelegate LinkAccounts1Complete;

        /// <summary>
        /// Initializes a new instance of the <see cref="SocialGoogleApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SocialGoogleApi()
        {
            mLinkAccounts1ResponseContext = new KnetikResponseContext();
            mLinkAccounts1ResponseContext.ResponseReceived += OnLinkAccounts1Response;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Link google account Links the current user account to a google account, using the acccess token from google. Can also be used to update the access token after it has expired. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; Non-google user token
        /// </summary>
        /// <param name="googleToken">The token from google</param>
        public void LinkAccounts1(GoogleToken googleToken)
        {
            
            mWebCallEvent.WebPath = "/social/google/users";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(googleToken); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mLinkAccounts1StartTime = DateTime.Now;
            mWebCallEvent.Context = mLinkAccounts1ResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mLinkAccounts1StartTime, "LinkAccounts1", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnLinkAccounts1Response(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling LinkAccounts1: " + response.Error);
            }

            KnetikLogger.LogResponse(mLinkAccounts1StartTime, "LinkAccounts1", "Response received successfully.");
            if (LinkAccounts1Complete != null)
            {
                LinkAccounts1Complete(response.ResponseCode);
            }
        }

    }
}
