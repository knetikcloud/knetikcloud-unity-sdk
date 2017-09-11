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
    public interface ISocialGoogleApi
    {
        
        /// <summary>
        /// Link google account Links the current user account to a google account, using the acccess token from google. Can also be used to update the access token after it has expired.
        /// </summary>
        /// <param name="googleToken">The token from google</param>
        void LinkAccounts1(GoogleToken googleToken);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class SocialGoogleApi : ISocialGoogleApi
    {
        private readonly KnetikCoroutine mLinkAccounts1Coroutine;
        private DateTime mLinkAccounts1StartTime;
        private string mLinkAccounts1Path;

        public delegate void LinkAccounts1CompleteDelegate();
        public LinkAccounts1CompleteDelegate LinkAccounts1Complete;

        /// <summary>
        /// Initializes a new instance of the <see cref="SocialGoogleApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SocialGoogleApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
            mLinkAccounts1Coroutine = new KnetikCoroutine(KnetikClient);
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient { get; private set; }

        /// <summary>
        /// Link google account Links the current user account to a google account, using the acccess token from google. Can also be used to update the access token after it has expired.
        /// </summary>
        /// <param name="googleToken">The token from google</param>
        public void LinkAccounts1(GoogleToken googleToken)
        {
            
            mLinkAccounts1Path = "/social/google/users";
            if (!string.IsNullOrEmpty(mLinkAccounts1Path))
            {
                mLinkAccounts1Path = mLinkAccounts1Path.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(googleToken); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mLinkAccounts1StartTime = DateTime.Now;
            KnetikLogger.LogRequest(mLinkAccounts1StartTime, mLinkAccounts1Path, "Sending server request...");

            // make the HTTP request
            mLinkAccounts1Coroutine.ResponseReceived += LinkAccounts1Callback;
            mLinkAccounts1Coroutine.Start(mLinkAccounts1Path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void LinkAccounts1Callback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling LinkAccounts1: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling LinkAccounts1: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mLinkAccounts1StartTime, mLinkAccounts1Path, "Response received successfully.");
            if (LinkAccounts1Complete != null)
            {
                LinkAccounts1Complete();
            }
        }
    }
}
