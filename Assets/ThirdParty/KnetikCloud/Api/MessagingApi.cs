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
    public interface IMessagingApi
    {
        

        /// <summary>
        /// Send a raw email to one or more users 
        /// </summary>
        /// <param name="rawEmailResource">The new raw email to be sent</param>
        void SendRawEmail(RawEmailResource rawEmailResource);

        

        /// <summary>
        /// Send a raw push notification Sends a raw push notification message to one or more users. User&#39;s without registered mobile device for the application will be skipped.
        /// </summary>
        /// <param name="rawPushResource">The new raw push notification to be sent</param>
        void SendRawPush(RawPushResource rawPushResource);

        

        /// <summary>
        /// Send a raw SMS Sends a raw SMS text message to one or more users. User&#39;s without registered mobile numbers will be skipped.
        /// </summary>
        /// <param name="rawSMSResource">The new raw SMS to be sent</param>
        void SendRawSMS(RawSMSResource rawSMSResource);

        

        /// <summary>
        /// Send a templated email to one or more users 
        /// </summary>
        /// <param name="messageResource">The new template email to be sent</param>
        void SendTemplatedEmail(TemplateEmailResource messageResource);

        

        /// <summary>
        /// Send a templated push notification Sends a templated push notification message to one or more users. User&#39;s without registered mobile device for the application will be skipped.
        /// </summary>
        /// <param name="templatePushResource">The new templated push notification to be sent</param>
        void SendTemplatedPush(TemplatePushResource templatePushResource);

        

        /// <summary>
        /// Send a new templated SMS Sends a templated SMS text message to one or more users. User&#39;s without registered mobile numbers will be skipped.
        /// </summary>
        /// <param name="templateSMSResource">The new template SMS to be sent</param>
        void SendTemplatedSMS(TemplateSMSResource templateSMSResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class MessagingApi : IMessagingApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mSendRawEmailResponseContext;
        private DateTime mSendRawEmailStartTime;
        private readonly KnetikResponseContext mSendRawPushResponseContext;
        private DateTime mSendRawPushStartTime;
        private readonly KnetikResponseContext mSendRawSMSResponseContext;
        private DateTime mSendRawSMSStartTime;
        private readonly KnetikResponseContext mSendTemplatedEmailResponseContext;
        private DateTime mSendTemplatedEmailStartTime;
        private readonly KnetikResponseContext mSendTemplatedPushResponseContext;
        private DateTime mSendTemplatedPushStartTime;
        private readonly KnetikResponseContext mSendTemplatedSMSResponseContext;
        private DateTime mSendTemplatedSMSStartTime;

        public delegate void SendRawEmailCompleteDelegate(long responseCode);
        public SendRawEmailCompleteDelegate SendRawEmailComplete;

        public delegate void SendRawPushCompleteDelegate(long responseCode);
        public SendRawPushCompleteDelegate SendRawPushComplete;

        public delegate void SendRawSMSCompleteDelegate(long responseCode);
        public SendRawSMSCompleteDelegate SendRawSMSComplete;

        public delegate void SendTemplatedEmailCompleteDelegate(long responseCode);
        public SendTemplatedEmailCompleteDelegate SendTemplatedEmailComplete;

        public delegate void SendTemplatedPushCompleteDelegate(long responseCode);
        public SendTemplatedPushCompleteDelegate SendTemplatedPushComplete;

        public delegate void SendTemplatedSMSCompleteDelegate(long responseCode);
        public SendTemplatedSMSCompleteDelegate SendTemplatedSMSComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MessagingApi()
        {
            mSendRawEmailResponseContext = new KnetikResponseContext();
            mSendRawEmailResponseContext.ResponseReceived += OnSendRawEmailResponse;
            mSendRawPushResponseContext = new KnetikResponseContext();
            mSendRawPushResponseContext.ResponseReceived += OnSendRawPushResponse;
            mSendRawSMSResponseContext = new KnetikResponseContext();
            mSendRawSMSResponseContext.ResponseReceived += OnSendRawSMSResponse;
            mSendTemplatedEmailResponseContext = new KnetikResponseContext();
            mSendTemplatedEmailResponseContext.ResponseReceived += OnSendTemplatedEmailResponse;
            mSendTemplatedPushResponseContext = new KnetikResponseContext();
            mSendTemplatedPushResponseContext.ResponseReceived += OnSendTemplatedPushResponse;
            mSendTemplatedSMSResponseContext = new KnetikResponseContext();
            mSendTemplatedSMSResponseContext.ResponseReceived += OnSendTemplatedSMSResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Send a raw email to one or more users 
        /// </summary>
        /// <param name="rawEmailResource">The new raw email to be sent</param>
        public void SendRawEmail(RawEmailResource rawEmailResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/raw-email";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(rawEmailResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendRawEmailStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendRawEmailResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendRawEmailStartTime, "SendRawEmail", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendRawEmailResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendRawEmail: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendRawEmailStartTime, "SendRawEmail", "Response received successfully.");
            if (SendRawEmailComplete != null)
            {
                SendRawEmailComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a raw push notification Sends a raw push notification message to one or more users. User&#39;s without registered mobile device for the application will be skipped.
        /// </summary>
        /// <param name="rawPushResource">The new raw push notification to be sent</param>
        public void SendRawPush(RawPushResource rawPushResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/raw-push";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(rawPushResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendRawPushStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendRawPushResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendRawPushStartTime, "SendRawPush", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendRawPushResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendRawPush: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendRawPushStartTime, "SendRawPush", "Response received successfully.");
            if (SendRawPushComplete != null)
            {
                SendRawPushComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a raw SMS Sends a raw SMS text message to one or more users. User&#39;s without registered mobile numbers will be skipped.
        /// </summary>
        /// <param name="rawSMSResource">The new raw SMS to be sent</param>
        public void SendRawSMS(RawSMSResource rawSMSResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/raw-sms";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(rawSMSResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendRawSMSStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendRawSMSResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendRawSMSStartTime, "SendRawSMS", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendRawSMSResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendRawSMS: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendRawSMSStartTime, "SendRawSMS", "Response received successfully.");
            if (SendRawSMSComplete != null)
            {
                SendRawSMSComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a templated email to one or more users 
        /// </summary>
        /// <param name="messageResource">The new template email to be sent</param>
        public void SendTemplatedEmail(TemplateEmailResource messageResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/templated-email";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(messageResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendTemplatedEmailStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendTemplatedEmailResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendTemplatedEmailStartTime, "SendTemplatedEmail", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendTemplatedEmailResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendTemplatedEmail: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendTemplatedEmailStartTime, "SendTemplatedEmail", "Response received successfully.");
            if (SendTemplatedEmailComplete != null)
            {
                SendTemplatedEmailComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a templated push notification Sends a templated push notification message to one or more users. User&#39;s without registered mobile device for the application will be skipped.
        /// </summary>
        /// <param name="templatePushResource">The new templated push notification to be sent</param>
        public void SendTemplatedPush(TemplatePushResource templatePushResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/templated-push";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(templatePushResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendTemplatedPushStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendTemplatedPushResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendTemplatedPushStartTime, "SendTemplatedPush", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendTemplatedPushResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendTemplatedPush: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendTemplatedPushStartTime, "SendTemplatedPush", "Response received successfully.");
            if (SendTemplatedPushComplete != null)
            {
                SendTemplatedPushComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a new templated SMS Sends a templated SMS text message to one or more users. User&#39;s without registered mobile numbers will be skipped.
        /// </summary>
        /// <param name="templateSMSResource">The new template SMS to be sent</param>
        public void SendTemplatedSMS(TemplateSMSResource templateSMSResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/templated-sms";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(templateSMSResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendTemplatedSMSStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendTemplatedSMSResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendTemplatedSMSStartTime, "SendTemplatedSMS", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendTemplatedSMSResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendTemplatedSMS: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendTemplatedSMSStartTime, "SendTemplatedSMS", "Response received successfully.");
            if (SendTemplatedSMSComplete != null)
            {
                SendTemplatedSMSComplete(response.ResponseCode);
            }
        }

    }
}
