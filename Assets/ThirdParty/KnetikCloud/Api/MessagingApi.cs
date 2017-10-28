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
        private readonly KnetikCoroutine mSendRawEmailCoroutine;
        private DateTime mSendRawEmailStartTime;
        private string mSendRawEmailPath;
        private readonly KnetikCoroutine mSendRawPushCoroutine;
        private DateTime mSendRawPushStartTime;
        private string mSendRawPushPath;
        private readonly KnetikCoroutine mSendRawSMSCoroutine;
        private DateTime mSendRawSMSStartTime;
        private string mSendRawSMSPath;
        private readonly KnetikCoroutine mSendTemplatedEmailCoroutine;
        private DateTime mSendTemplatedEmailStartTime;
        private string mSendTemplatedEmailPath;
        private readonly KnetikCoroutine mSendTemplatedPushCoroutine;
        private DateTime mSendTemplatedPushStartTime;
        private string mSendTemplatedPushPath;
        private readonly KnetikCoroutine mSendTemplatedSMSCoroutine;
        private DateTime mSendTemplatedSMSStartTime;
        private string mSendTemplatedSMSPath;

        public delegate void SendRawEmailCompleteDelegate();
        public SendRawEmailCompleteDelegate SendRawEmailComplete;

        public delegate void SendRawPushCompleteDelegate();
        public SendRawPushCompleteDelegate SendRawPushComplete;

        public delegate void SendRawSMSCompleteDelegate();
        public SendRawSMSCompleteDelegate SendRawSMSComplete;

        public delegate void SendTemplatedEmailCompleteDelegate();
        public SendTemplatedEmailCompleteDelegate SendTemplatedEmailComplete;

        public delegate void SendTemplatedPushCompleteDelegate();
        public SendTemplatedPushCompleteDelegate SendTemplatedPushComplete;

        public delegate void SendTemplatedSMSCompleteDelegate();
        public SendTemplatedSMSCompleteDelegate SendTemplatedSMSComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MessagingApi()
        {
            mSendRawEmailCoroutine = new KnetikCoroutine();
            mSendRawPushCoroutine = new KnetikCoroutine();
            mSendRawSMSCoroutine = new KnetikCoroutine();
            mSendTemplatedEmailCoroutine = new KnetikCoroutine();
            mSendTemplatedPushCoroutine = new KnetikCoroutine();
            mSendTemplatedSMSCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Send a raw email to one or more users 
        /// </summary>
        /// <param name="rawEmailResource">The new raw email to be sent</param>
        public void SendRawEmail(RawEmailResource rawEmailResource)
        {
            
            mSendRawEmailPath = "/messaging/raw-email";
            if (!string.IsNullOrEmpty(mSendRawEmailPath))
            {
                mSendRawEmailPath = mSendRawEmailPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(rawEmailResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSendRawEmailStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSendRawEmailStartTime, mSendRawEmailPath, "Sending server request...");

            // make the HTTP request
            mSendRawEmailCoroutine.ResponseReceived += SendRawEmailCallback;
            mSendRawEmailCoroutine.Start(mSendRawEmailPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SendRawEmailCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendRawEmail: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendRawEmail: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSendRawEmailStartTime, mSendRawEmailPath, "Response received successfully.");
            if (SendRawEmailComplete != null)
            {
                SendRawEmailComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a raw push notification Sends a raw push notification message to one or more users. User&#39;s without registered mobile device for the application will be skipped.
        /// </summary>
        /// <param name="rawPushResource">The new raw push notification to be sent</param>
        public void SendRawPush(RawPushResource rawPushResource)
        {
            
            mSendRawPushPath = "/messaging/raw-push";
            if (!string.IsNullOrEmpty(mSendRawPushPath))
            {
                mSendRawPushPath = mSendRawPushPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(rawPushResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSendRawPushStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSendRawPushStartTime, mSendRawPushPath, "Sending server request...");

            // make the HTTP request
            mSendRawPushCoroutine.ResponseReceived += SendRawPushCallback;
            mSendRawPushCoroutine.Start(mSendRawPushPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SendRawPushCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendRawPush: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendRawPush: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSendRawPushStartTime, mSendRawPushPath, "Response received successfully.");
            if (SendRawPushComplete != null)
            {
                SendRawPushComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a raw SMS Sends a raw SMS text message to one or more users. User&#39;s without registered mobile numbers will be skipped.
        /// </summary>
        /// <param name="rawSMSResource">The new raw SMS to be sent</param>
        public void SendRawSMS(RawSMSResource rawSMSResource)
        {
            
            mSendRawSMSPath = "/messaging/raw-sms";
            if (!string.IsNullOrEmpty(mSendRawSMSPath))
            {
                mSendRawSMSPath = mSendRawSMSPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(rawSMSResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSendRawSMSStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSendRawSMSStartTime, mSendRawSMSPath, "Sending server request...");

            // make the HTTP request
            mSendRawSMSCoroutine.ResponseReceived += SendRawSMSCallback;
            mSendRawSMSCoroutine.Start(mSendRawSMSPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SendRawSMSCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendRawSMS: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendRawSMS: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSendRawSMSStartTime, mSendRawSMSPath, "Response received successfully.");
            if (SendRawSMSComplete != null)
            {
                SendRawSMSComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a templated email to one or more users 
        /// </summary>
        /// <param name="messageResource">The new template email to be sent</param>
        public void SendTemplatedEmail(TemplateEmailResource messageResource)
        {
            
            mSendTemplatedEmailPath = "/messaging/templated-email";
            if (!string.IsNullOrEmpty(mSendTemplatedEmailPath))
            {
                mSendTemplatedEmailPath = mSendTemplatedEmailPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(messageResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSendTemplatedEmailStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSendTemplatedEmailStartTime, mSendTemplatedEmailPath, "Sending server request...");

            // make the HTTP request
            mSendTemplatedEmailCoroutine.ResponseReceived += SendTemplatedEmailCallback;
            mSendTemplatedEmailCoroutine.Start(mSendTemplatedEmailPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SendTemplatedEmailCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendTemplatedEmail: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendTemplatedEmail: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSendTemplatedEmailStartTime, mSendTemplatedEmailPath, "Response received successfully.");
            if (SendTemplatedEmailComplete != null)
            {
                SendTemplatedEmailComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a templated push notification Sends a templated push notification message to one or more users. User&#39;s without registered mobile device for the application will be skipped.
        /// </summary>
        /// <param name="templatePushResource">The new templated push notification to be sent</param>
        public void SendTemplatedPush(TemplatePushResource templatePushResource)
        {
            
            mSendTemplatedPushPath = "/messaging/templated-push";
            if (!string.IsNullOrEmpty(mSendTemplatedPushPath))
            {
                mSendTemplatedPushPath = mSendTemplatedPushPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(templatePushResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSendTemplatedPushStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSendTemplatedPushStartTime, mSendTemplatedPushPath, "Sending server request...");

            // make the HTTP request
            mSendTemplatedPushCoroutine.ResponseReceived += SendTemplatedPushCallback;
            mSendTemplatedPushCoroutine.Start(mSendTemplatedPushPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SendTemplatedPushCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendTemplatedPush: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendTemplatedPush: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSendTemplatedPushStartTime, mSendTemplatedPushPath, "Response received successfully.");
            if (SendTemplatedPushComplete != null)
            {
                SendTemplatedPushComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a new templated SMS Sends a templated SMS text message to one or more users. User&#39;s without registered mobile numbers will be skipped.
        /// </summary>
        /// <param name="templateSMSResource">The new template SMS to be sent</param>
        public void SendTemplatedSMS(TemplateSMSResource templateSMSResource)
        {
            
            mSendTemplatedSMSPath = "/messaging/templated-sms";
            if (!string.IsNullOrEmpty(mSendTemplatedSMSPath))
            {
                mSendTemplatedSMSPath = mSendTemplatedSMSPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(templateSMSResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSendTemplatedSMSStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSendTemplatedSMSStartTime, mSendTemplatedSMSPath, "Sending server request...");

            // make the HTTP request
            mSendTemplatedSMSCoroutine.ResponseReceived += SendTemplatedSMSCallback;
            mSendTemplatedSMSCoroutine.Start(mSendTemplatedSMSPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SendTemplatedSMSCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendTemplatedSMS: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendTemplatedSMS: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSendTemplatedSMSStartTime, mSendTemplatedSMSPath, "Response received successfully.");
            if (SendTemplatedSMSComplete != null)
            {
                SendTemplatedSMSComplete();
            }
        }

    }
}
