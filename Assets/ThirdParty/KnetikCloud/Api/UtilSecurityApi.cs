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
    public interface IUtilSecurityApi
    {
        PageResourceLocationLogResource GetUserLocationLogData { get; }

        TokenDetailsResource GetUserTokenDetailsData { get; }

        
        /// <summary>
        /// Returns the authentication log for a user A log entry is recorded everytime a user requests a new token. Standard pagination available
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetUserLocationLog(int? userId, int? size, int? page, string order);

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
        private readonly KnetikCoroutine mGetUserLocationLogCoroutine;
        private DateTime mGetUserLocationLogStartTime;
        private string mGetUserLocationLogPath;
        private readonly KnetikCoroutine mGetUserTokenDetailsCoroutine;
        private DateTime mGetUserTokenDetailsStartTime;
        private string mGetUserTokenDetailsPath;

        public PageResourceLocationLogResource GetUserLocationLogData { get; private set; }
        public delegate void GetUserLocationLogCompleteDelegate(PageResourceLocationLogResource response);
        public GetUserLocationLogCompleteDelegate GetUserLocationLogComplete;

        public TokenDetailsResource GetUserTokenDetailsData { get; private set; }
        public delegate void GetUserTokenDetailsCompleteDelegate(TokenDetailsResource response);
        public GetUserTokenDetailsCompleteDelegate GetUserTokenDetailsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilSecurityApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UtilSecurityApi()
        {
            mGetUserLocationLogCoroutine = new KnetikCoroutine();
            mGetUserTokenDetailsCoroutine = new KnetikCoroutine();
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
            
            mGetUserLocationLogPath = "/security/country-log";
            if (!string.IsNullOrEmpty(mGetUserLocationLogPath))
            {
                mGetUserLocationLogPath = mGetUserLocationLogPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (userId != null)
            {
                queryParams.Add("user_id", KnetikClient.DefaultClient.ParameterToString(userId));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.DefaultClient.ParameterToString(order));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserLocationLogStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserLocationLogStartTime, mGetUserLocationLogPath, "Sending server request...");

            // make the HTTP request
            mGetUserLocationLogCoroutine.ResponseReceived += GetUserLocationLogCallback;
            mGetUserLocationLogCoroutine.Start(mGetUserLocationLogPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserLocationLogCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserLocationLog: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserLocationLog: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserLocationLogData = (PageResourceLocationLogResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceLocationLogResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserLocationLogStartTime, mGetUserLocationLogPath, string.Format("Response received successfully:\n{0}", GetUserLocationLogData.ToString()));

            if (GetUserLocationLogComplete != null)
            {
                GetUserLocationLogComplete(GetUserLocationLogData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Returns the authentication token details. Use /users endpoint for detailed user&#39;s info 
        /// </summary>
        public void GetUserTokenDetails()
        {
            
            mGetUserTokenDetailsPath = "/me";
            if (!string.IsNullOrEmpty(mGetUserTokenDetailsPath))
            {
                mGetUserTokenDetailsPath = mGetUserTokenDetailsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserTokenDetailsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserTokenDetailsStartTime, mGetUserTokenDetailsPath, "Sending server request...");

            // make the HTTP request
            mGetUserTokenDetailsCoroutine.ResponseReceived += GetUserTokenDetailsCallback;
            mGetUserTokenDetailsCoroutine.Start(mGetUserTokenDetailsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserTokenDetailsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserTokenDetails: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserTokenDetails: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserTokenDetailsData = (TokenDetailsResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TokenDetailsResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserTokenDetailsStartTime, mGetUserTokenDetailsPath, string.Format("Response received successfully:\n{0}", GetUserTokenDetailsData.ToString()));

            if (GetUserTokenDetailsComplete != null)
            {
                GetUserTokenDetailsComplete(GetUserTokenDetailsData);
            }
        }
    }
}
