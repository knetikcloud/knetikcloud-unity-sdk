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
    public interface IUtilBatchApi
    {
        List<BatchReturn> GetBatchData { get; }

        List<BatchReturn> SendBatchData { get; }

        
        /// <summary>
        /// Get batch result with token Tokens expire in 24 hours
        /// </summary>
        /// <param name="token">token</param>
        void GetBatch(string token);

        /// <summary>
        /// Request to run API call given the method, content type, path url, and body of request Should the request take longer than one of the alloted timeout parameters, a token will be returned instead, which can be used on the token endpoint in this service
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
        private readonly KnetikCoroutine mGetBatchCoroutine;
        private DateTime mGetBatchStartTime;
        private string mGetBatchPath;
        private readonly KnetikCoroutine mSendBatchCoroutine;
        private DateTime mSendBatchStartTime;
        private string mSendBatchPath;

        public List<BatchReturn> GetBatchData { get; private set; }
        public delegate void GetBatchCompleteDelegate(List<BatchReturn> response);
        public GetBatchCompleteDelegate GetBatchComplete;

        public List<BatchReturn> SendBatchData { get; private set; }
        public delegate void SendBatchCompleteDelegate(List<BatchReturn> response);
        public SendBatchCompleteDelegate SendBatchComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilBatchApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UtilBatchApi()
        {
            mGetBatchCoroutine = new KnetikCoroutine();
            mSendBatchCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get batch result with token Tokens expire in 24 hours
        /// </summary>
        /// <param name="token">token</param>
        public void GetBatch(string token)
        {
            // verify the required parameter 'token' is set
            if (token == null)
            {
                throw new KnetikException(400, "Missing required parameter 'token' when calling GetBatch");
            }
            
            mGetBatchPath = "/batch/{token}";
            if (!string.IsNullOrEmpty(mGetBatchPath))
            {
                mGetBatchPath = mGetBatchPath.Replace("{format}", "json");
            }
            mGetBatchPath = mGetBatchPath.Replace("{" + "token" + "}", KnetikClient.DefaultClient.ParameterToString(token));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBatchStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBatchStartTime, mGetBatchPath, "Sending server request...");

            // make the HTTP request
            mGetBatchCoroutine.ResponseReceived += GetBatchCallback;
            mGetBatchCoroutine.Start(mGetBatchPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBatchCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBatch: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBatch: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBatchData = (List<BatchReturn>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<BatchReturn>), response.Headers);
            KnetikLogger.LogResponse(mGetBatchStartTime, mGetBatchPath, string.Format("Response received successfully:\n{0}", GetBatchData.ToString()));

            if (GetBatchComplete != null)
            {
                GetBatchComplete(GetBatchData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Request to run API call given the method, content type, path url, and body of request Should the request take longer than one of the alloted timeout parameters, a token will be returned instead, which can be used on the token endpoint in this service
        /// </summary>
        /// <param name="batch">The batch object</param>
        public void SendBatch(Batch batch)
        {
            
            mSendBatchPath = "/batch";
            if (!string.IsNullOrEmpty(mSendBatchPath))
            {
                mSendBatchPath = mSendBatchPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(batch); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSendBatchStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSendBatchStartTime, mSendBatchPath, "Sending server request...");

            // make the HTTP request
            mSendBatchCoroutine.ResponseReceived += SendBatchCallback;
            mSendBatchCoroutine.Start(mSendBatchPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SendBatchCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendBatch: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SendBatch: " + response.ErrorMessage, response.ErrorMessage);
            }

            SendBatchData = (List<BatchReturn>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<BatchReturn>), response.Headers);
            KnetikLogger.LogResponse(mSendBatchStartTime, mSendBatchPath, string.Format("Response received successfully:\n{0}", SendBatchData.ToString()));

            if (SendBatchComplete != null)
            {
                SendBatchComplete(SendBatchData);
            }
        }

    }
}
