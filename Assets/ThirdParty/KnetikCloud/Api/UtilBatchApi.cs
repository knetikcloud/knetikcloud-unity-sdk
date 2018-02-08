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
    public interface IUtilBatchApi
    {
        List<BatchReturn> GetBatchData { get; }

        /// <summary>
        /// Get batch result with token Tokens expire in 24 hours. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="token">token</param>
        void GetBatch(string token);

        List<BatchReturn> SendBatchData { get; }

        /// <summary>
        /// Request to run API call given the method, content type, path url, and body of request Should the request take longer than one of the alloted timeout parameters, a token will be returned instead, which can be used on the token endpoint in this service. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="batch">The batch object</param>
        void SendBatch(Batch batch);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UtilBatchApi : IUtilBatchApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetBatchResponseContext;
        private DateTime mGetBatchStartTime;
        private readonly KnetikResponseContext mSendBatchResponseContext;
        private DateTime mSendBatchStartTime;

        public List<BatchReturn> GetBatchData { get; private set; }
        public delegate void GetBatchCompleteDelegate(long responseCode, List<BatchReturn> response);
        public GetBatchCompleteDelegate GetBatchComplete;

        public List<BatchReturn> SendBatchData { get; private set; }
        public delegate void SendBatchCompleteDelegate(long responseCode, List<BatchReturn> response);
        public SendBatchCompleteDelegate SendBatchComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilBatchApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UtilBatchApi()
        {
            mGetBatchResponseContext = new KnetikResponseContext();
            mGetBatchResponseContext.ResponseReceived += OnGetBatchResponse;
            mSendBatchResponseContext = new KnetikResponseContext();
            mSendBatchResponseContext.ResponseReceived += OnSendBatchResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get batch result with token Tokens expire in 24 hours. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="token">token</param>
        public void GetBatch(string token)
        {
            // verify the required parameter 'token' is set
            if (token == null)
            {
                throw new KnetikException(400, "Missing required parameter 'token' when calling GetBatch");
            }
            
            mWebCallEvent.WebPath = "/batch/{token}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "token" + "}", KnetikClient.ParameterToString(token));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetBatchStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBatchResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBatchStartTime, "GetBatch", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBatchResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBatch: " + response.Error);
            }

            GetBatchData = (List<BatchReturn>) KnetikClient.Deserialize(response.Content, typeof(List<BatchReturn>), response.Headers);
            KnetikLogger.LogResponse(mGetBatchStartTime, "GetBatch", string.Format("Response received successfully:\n{0}", GetBatchData));

            if (GetBatchComplete != null)
            {
                GetBatchComplete(response.ResponseCode, GetBatchData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Request to run API call given the method, content type, path url, and body of request Should the request take longer than one of the alloted timeout parameters, a token will be returned instead, which can be used on the token endpoint in this service. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="batch">The batch object</param>
        public void SendBatch(Batch batch)
        {
            
            mWebCallEvent.WebPath = "/batch";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(batch); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendBatchStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendBatchResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendBatchStartTime, "SendBatch", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendBatchResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendBatch: " + response.Error);
            }

            SendBatchData = (List<BatchReturn>) KnetikClient.Deserialize(response.Content, typeof(List<BatchReturn>), response.Headers);
            KnetikLogger.LogResponse(mSendBatchStartTime, "SendBatch", string.Format("Response received successfully:\n{0}", SendBatchData));

            if (SendBatchComplete != null)
            {
                SendBatchComplete(response.ResponseCode, SendBatchData);
            }
        }

    }
}
