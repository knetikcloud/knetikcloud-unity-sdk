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
    public interface ISocialFacebookApi
    {
        /// <summary>
        /// Link facebook account Links the current user account to a facebook account, using the acccess token from facebook. Can also be used to update the access token after it has expired.
        /// </summary>
        /// <param name="facebookToken">The token from facebook</param>
        /// <returns></returns>
        void LinkAccounts (FacebookToken facebookToken);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class SocialFacebookApi : ISocialFacebookApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SocialFacebookApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SocialFacebookApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Link facebook account Links the current user account to a facebook account, using the acccess token from facebook. Can also be used to update the access token after it has expired.
        /// </summary>
        /// <param name="facebookToken">The token from facebook</param> 
        /// <returns></returns>            
        public void LinkAccounts(FacebookToken facebookToken)
        {
            
            string urlPath = "/social/facebook/users";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(facebookToken); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling LinkAccounts: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling LinkAccounts: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
    }
}
