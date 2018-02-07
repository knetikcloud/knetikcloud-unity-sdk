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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddMetricResponseContext;
        private DateTime mAddMetricStartTime;

        public delegate void AddMetricCompleteDelegate(long responseCode);
        public AddMetricCompleteDelegate AddMetricComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamificationMetricsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GamificationMetricsApi()
        {
            mAddMetricResponseContext = new KnetikResponseContext();
            mAddMetricResponseContext.ResponseReceived += OnAddMetricResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a metric Post a new score/stat for an activity occurrence without ending the occurrence itself
        /// </summary>
        /// <param name="metric">The new metric</param>
        public void AddMetric(MetricResource metric)
        {
            
            mWebCallEvent.WebPath = "/metrics";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(metric); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddMetricStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddMetricResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddMetricStartTime, "AddMetric", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddMetricResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddMetric: " + response.Error);
            }

            KnetikLogger.LogResponse(mAddMetricStartTime, "AddMetric", "Response received successfully.");
            if (AddMetricComplete != null)
            {
                AddMetricComplete(response.ResponseCode);
            }
        }

    }
}
