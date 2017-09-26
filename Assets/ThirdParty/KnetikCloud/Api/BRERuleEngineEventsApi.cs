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
    public interface IBRERuleEngineEventsApi
    {
        string SendBREEventData { get; }

        
        /// <summary>
        /// Fire a new event, based on an existing trigger Parameters within the event must match names and types from the trigger. Actual rule execution is asynchornous.  Returns request id, which will be used as the event id
        /// </summary>
        /// <param name="breEvent">The BRE event object</param>
        void SendBREEvent(BreEvent breEvent);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineEventsApi : IBRERuleEngineEventsApi
    {
        private readonly KnetikCoroutine mSendBREEventCoroutine;
        private DateTime mSendBREEventStartTime;
        private string mSendBREEventPath;

        public string SendBREEventData { get; private set; }
        public delegate void SendBREEventCompleteDelegate(string response);
        public SendBREEventCompleteDelegate SendBREEventComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineEventsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineEventsApi()
        {
            mSendBREEventCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Fire a new event, based on an existing trigger Parameters within the event must match names and types from the trigger. Actual rule execution is asynchornous.  Returns request id, which will be used as the event id
        /// </summary>
        /// <param name="breEvent">The BRE event object</param>
        public void SendBREEvent(BreEvent breEvent)
        {
            
            mSendBREEventPath = "/bre/events";
            if (!string.IsNullOrEmpty(mSendBREEventPath))
            {
                mSendBREEventPath = mSendBREEventPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(breEvent); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSendBREEventStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSendBREEventStartTime, mSendBREEventPath, "Sending server request...");

            // make the HTTP request
            mSendBREEventCoroutine.ResponseReceived += SendBREEventCallback;
            mSendBREEventCoroutine.Start(mSendBREEventPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SendBREEventCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendBREEvent: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendBREEvent: " + response.ErrorMessage, response.ErrorMessage);
            }

            SendBREEventData = (string) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mSendBREEventStartTime, mSendBREEventPath, string.Format("Response received successfully:\n{0}", SendBREEventData.ToString()));

            if (SendBREEventComplete != null)
            {
                SendBREEventComplete(SendBREEventData);
            }
        }
    }
}
