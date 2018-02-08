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
    public interface ISocialFacebookApi
    {
        

        /// <summary>
        /// Link facebook account Links the current user account to a facebook account, using the acccess token from facebook. Can also be used to update the access token after it has expired. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; Non-facebook user token
        /// </summary>
        /// <param name="facebookToken">The token from facebook</param>
        void LinkAccounts(FacebookToken facebookToken);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class SocialFacebookApi : ISocialFacebookApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mLinkAccountsResponseContext;
        private DateTime mLinkAccountsStartTime;

        public delegate void LinkAccountsCompleteDelegate(long responseCode);
        public LinkAccountsCompleteDelegate LinkAccountsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="SocialFacebookApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SocialFacebookApi()
        {
            mLinkAccountsResponseContext = new KnetikResponseContext();
            mLinkAccountsResponseContext.ResponseReceived += OnLinkAccountsResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Link facebook account Links the current user account to a facebook account, using the acccess token from facebook. Can also be used to update the access token after it has expired. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; Non-facebook user token
        /// </summary>
        /// <param name="facebookToken">The token from facebook</param>
        public void LinkAccounts(FacebookToken facebookToken)
        {
            
            mWebCallEvent.WebPath = "/social/facebook/users";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(facebookToken); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mLinkAccountsStartTime = DateTime.Now;
            mWebCallEvent.Context = mLinkAccountsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mLinkAccountsStartTime, "LinkAccounts", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnLinkAccountsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling LinkAccounts: " + response.Error);
            }

            KnetikLogger.LogResponse(mLinkAccountsStartTime, "LinkAccounts", "Response received successfully.");
            if (LinkAccountsComplete != null)
            {
                LinkAccountsComplete(response.ResponseCode);
            }
        }

    }
}
