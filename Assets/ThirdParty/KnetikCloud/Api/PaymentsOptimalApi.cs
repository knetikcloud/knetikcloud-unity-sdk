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
    public interface IPaymentsOptimalApi
    {
        string SilentPostOptimalData { get; }

        
        /// <summary>
        /// Initiate silent post with Optimal Will return the url for a hosted payment endpoint to post to. See Optimal documentation for details.
        /// </summary>
        /// <param name="request">The payment request to initiate</param>
        void SilentPostOptimal(OptimalPaymentRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsOptimalApi : IPaymentsOptimalApi
    {
        private readonly KnetikCoroutine mSilentPostOptimalCoroutine;
        private DateTime mSilentPostOptimalStartTime;
        private string mSilentPostOptimalPath;

        public string SilentPostOptimalData { get; private set; }
        public delegate void SilentPostOptimalCompleteDelegate(string response);
        public SilentPostOptimalCompleteDelegate SilentPostOptimalComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsOptimalApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsOptimalApi()
        {
            mSilentPostOptimalCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Initiate silent post with Optimal Will return the url for a hosted payment endpoint to post to. See Optimal documentation for details.
        /// </summary>
        /// <param name="request">The payment request to initiate</param>
        public void SilentPostOptimal(OptimalPaymentRequest request)
        {
            
            mSilentPostOptimalPath = "/payment/provider/optimal/silent";
            if (!string.IsNullOrEmpty(mSilentPostOptimalPath))
            {
                mSilentPostOptimalPath = mSilentPostOptimalPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSilentPostOptimalStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSilentPostOptimalStartTime, mSilentPostOptimalPath, "Sending server request...");

            // make the HTTP request
            mSilentPostOptimalCoroutine.ResponseReceived += SilentPostOptimalCallback;
            mSilentPostOptimalCoroutine.Start(mSilentPostOptimalPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SilentPostOptimalCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SilentPostOptimal: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SilentPostOptimal: " + response.ErrorMessage, response.ErrorMessage);
            }

            SilentPostOptimalData = (string) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mSilentPostOptimalStartTime, mSilentPostOptimalPath, string.Format("Response received successfully:\n{0}", SilentPostOptimalData.ToString()));

            if (SilentPostOptimalComplete != null)
            {
                SilentPostOptimalComplete(SilentPostOptimalData);
            }
        }

    }
}
