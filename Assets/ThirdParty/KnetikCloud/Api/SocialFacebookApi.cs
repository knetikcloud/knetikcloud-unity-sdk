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
    public interface ISocialFacebookApi
    {
        
        /// <summary>
        /// Link facebook account Links the current user account to a facebook account, using the acccess token from facebook. Can also be used to update the access token after it has expired.
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
        private readonly KnetikCoroutine mLinkAccountsCoroutine;
        private DateTime mLinkAccountsStartTime;
        private string mLinkAccountsPath;

        public delegate void LinkAccountsCompleteDelegate();
        public LinkAccountsCompleteDelegate LinkAccountsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="SocialFacebookApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SocialFacebookApi()
        {
            mLinkAccountsCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Link facebook account Links the current user account to a facebook account, using the acccess token from facebook. Can also be used to update the access token after it has expired.
        /// </summary>
        /// <param name="facebookToken">The token from facebook</param>
        public void LinkAccounts(FacebookToken facebookToken)
        {
            
            mLinkAccountsPath = "/social/facebook/users";
            if (!string.IsNullOrEmpty(mLinkAccountsPath))
            {
                mLinkAccountsPath = mLinkAccountsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(facebookToken); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mLinkAccountsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mLinkAccountsStartTime, mLinkAccountsPath, "Sending server request...");

            // make the HTTP request
            mLinkAccountsCoroutine.ResponseReceived += LinkAccountsCallback;
            mLinkAccountsCoroutine.Start(mLinkAccountsPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void LinkAccountsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling LinkAccounts: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling LinkAccounts: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mLinkAccountsStartTime, mLinkAccountsPath, "Response received successfully.");
            if (LinkAccountsComplete != null)
            {
                LinkAccountsComplete();
            }
        }
    }
}
