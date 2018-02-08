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
    public interface IBRERuleEngineEventsApi
    {
        string SendBREEventData { get; }

        /// <summary>
        /// Fire a new event, based on an existing trigger Parameters within the event must match names and types from the trigger. Actual rule execution is asynchornous.  Returns request id, which will be used as the event id. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_EVENTS_USER
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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mSendBREEventResponseContext;
        private DateTime mSendBREEventStartTime;

        public string SendBREEventData { get; private set; }
        public delegate void SendBREEventCompleteDelegate(long responseCode, string response);
        public SendBREEventCompleteDelegate SendBREEventComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineEventsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineEventsApi()
        {
            mSendBREEventResponseContext = new KnetikResponseContext();
            mSendBREEventResponseContext.ResponseReceived += OnSendBREEventResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Fire a new event, based on an existing trigger Parameters within the event must match names and types from the trigger. Actual rule execution is asynchornous.  Returns request id, which will be used as the event id. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_EVENTS_USER
        /// </summary>
        /// <param name="breEvent">The BRE event object</param>
        public void SendBREEvent(BreEvent breEvent)
        {
            
            mWebCallEvent.WebPath = "/bre/events";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(breEvent); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendBREEventStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendBREEventResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendBREEventStartTime, "SendBREEvent", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendBREEventResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendBREEvent: " + response.Error);
            }

            SendBREEventData = (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mSendBREEventStartTime, "SendBREEvent", string.Format("Response received successfully:\n{0}", SendBREEventData));

            if (SendBREEventComplete != null)
            {
                SendBREEventComplete(response.ResponseCode, SendBREEventData);
            }
        }

    }
}
