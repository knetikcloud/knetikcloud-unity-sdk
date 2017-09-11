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
    public interface IBRERuleEngineExpressionsApi
    {
        List<LookupTypeResource> GetBREExpressionsData { get; }

        
        /// <summary>
        /// Get a list of &#39;lookup&#39; type expressions These are expression types that take a second expression as input and produce a value. These can be used in addition to the standard types, like parameter, global and constant (see BRE documentation for details).
        /// </summary>
        void GetBREExpressions();

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineExpressionsApi : IBRERuleEngineExpressionsApi
    {
        private readonly KnetikCoroutine mGetBREExpressionsCoroutine;
        private DateTime mGetBREExpressionsStartTime;
        private string mGetBREExpressionsPath;

        public List<LookupTypeResource> GetBREExpressionsData { get; private set; }
        public delegate void GetBREExpressionsCompleteDelegate(List<LookupTypeResource> response);
        public GetBREExpressionsCompleteDelegate GetBREExpressionsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineExpressionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineExpressionsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
            mGetBREExpressionsCoroutine = new KnetikCoroutine(KnetikClient);
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient { get; private set; }

        /// <summary>
        /// Get a list of &#39;lookup&#39; type expressions These are expression types that take a second expression as input and produce a value. These can be used in addition to the standard types, like parameter, global and constant (see BRE documentation for details).
        /// </summary>
        public void GetBREExpressions()
        {
            
            mGetBREExpressionsPath = "/bre/expressions/lookup";
            if (!string.IsNullOrEmpty(mGetBREExpressionsPath))
            {
                mGetBREExpressionsPath = mGetBREExpressionsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBREExpressionsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBREExpressionsStartTime, mGetBREExpressionsPath, "Sending server request...");

            // make the HTTP request
            mGetBREExpressionsCoroutine.ResponseReceived += GetBREExpressionsCallback;
            mGetBREExpressionsCoroutine.Start(mGetBREExpressionsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBREExpressionsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREExpressions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREExpressions: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBREExpressionsData = (List<LookupTypeResource>) KnetikClient.Deserialize(response.Content, typeof(List<LookupTypeResource>), response.Headers);
            KnetikLogger.LogResponse(mGetBREExpressionsStartTime, mGetBREExpressionsPath, string.Format("Response received successfully:\n{0}", GetBREExpressionsData.ToString()));

            if (GetBREExpressionsComplete != null)
            {
                GetBREExpressionsComplete(GetBREExpressionsData);
            }
        }
    }
}
