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
    public interface IGamificationMetricsApi
    {
        
        /// <summary>
        /// Add a metric Post a new score/stat for an activity occurrence without ending the occurrence itself
        /// </summary>
        /// <param name="metric">The new metric</param>
        void AddMetric(MetricResource metric);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class GamificationMetricsApi : IGamificationMetricsApi
    {
        private readonly KnetikCoroutine mAddMetricCoroutine;
        private DateTime mAddMetricStartTime;
        private string mAddMetricPath;

        public delegate void AddMetricCompleteDelegate();
        public AddMetricCompleteDelegate AddMetricComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamificationMetricsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GamificationMetricsApi()
        {
            mAddMetricCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a metric Post a new score/stat for an activity occurrence without ending the occurrence itself
        /// </summary>
        /// <param name="metric">The new metric</param>
        public void AddMetric(MetricResource metric)
        {
            
            mAddMetricPath = "/metrics";
            if (!string.IsNullOrEmpty(mAddMetricPath))
            {
                mAddMetricPath = mAddMetricPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(metric); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddMetricStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddMetricStartTime, mAddMetricPath, "Sending server request...");

            // make the HTTP request
            mAddMetricCoroutine.ResponseReceived += AddMetricCallback;
            mAddMetricCoroutine.Start(mAddMetricPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddMetricCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddMetric: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddMetric: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mAddMetricStartTime, mAddMetricPath, "Response received successfully.");
            if (AddMetricComplete != null)
            {
                AddMetricComplete();
            }
        }

    }
}
