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
    public interface IUtilVersionApi
    {
        Version GetVersionData { get; }

        
        /// <summary>
        /// Get current version info 
        /// </summary>
        void GetVersion();

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UtilVersionApi : IUtilVersionApi
    {
        private readonly KnetikCoroutine mGetVersionCoroutine;
        private DateTime mGetVersionStartTime;
        private string mGetVersionPath;

        public Version GetVersionData { get; private set; }
        public delegate void GetVersionCompleteDelegate(Version response);
        public GetVersionCompleteDelegate GetVersionComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilVersionApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UtilVersionApi()
        {
            mGetVersionCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
        /// <summary>
        /// Get current version info 
        /// </summary>
        public void GetVersion()
        {
            
            mGetVersionPath = "/version";
            if (!string.IsNullOrEmpty(mGetVersionPath))
            {
                mGetVersionPath = mGetVersionPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetVersionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetVersionStartTime, mGetVersionPath, "Sending server request...");

            // make the HTTP request
            mGetVersionCoroutine.ResponseReceived += GetVersionCallback;
            mGetVersionCoroutine.Start(mGetVersionPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetVersionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVersion: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVersion: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetVersionData = (Version) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(Version), response.Headers);
            KnetikLogger.LogResponse(mGetVersionStartTime, mGetVersionPath, string.Format("Response received successfully:\n{0}", GetVersionData.ToString()));

            if (GetVersionComplete != null)
            {
                GetVersionComplete(GetVersionData);
            }
        }
    }
}
