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
    public interface IUtilHealthApi
    {
        Object GetHealthData { get; }

        
        /// <summary>
        /// Get health info 
        /// </summary>
        void GetHealth();

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UtilHealthApi : IUtilHealthApi
    {
        private readonly KnetikCoroutine mGetHealthCoroutine;
        private DateTime mGetHealthStartTime;
        private string mGetHealthPath;

        public Object GetHealthData { get; private set; }
        public delegate void GetHealthCompleteDelegate(Object response);
        public GetHealthCompleteDelegate GetHealthComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilHealthApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UtilHealthApi()
        {
            mGetHealthCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get health info 
        /// </summary>
        public void GetHealth()
        {
            
            mGetHealthPath = "/health";
            if (!string.IsNullOrEmpty(mGetHealthPath))
            {
                mGetHealthPath = mGetHealthPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetHealthStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetHealthStartTime, mGetHealthPath, "Sending server request...");

            // make the HTTP request
            mGetHealthCoroutine.ResponseReceived += GetHealthCallback;
            mGetHealthCoroutine.Start(mGetHealthPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetHealthCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetHealth: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetHealth: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetHealthData = (Object) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mGetHealthStartTime, mGetHealthPath, string.Format("Response received successfully:\n{0}", GetHealthData.ToString()));

            if (GetHealthComplete != null)
            {
                GetHealthComplete(GetHealthData);
            }
        }

    }
}
