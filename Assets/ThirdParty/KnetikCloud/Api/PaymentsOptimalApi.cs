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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mSilentPostOptimalResponseContext;
        private DateTime mSilentPostOptimalStartTime;

        public string SilentPostOptimalData { get; private set; }
        public delegate void SilentPostOptimalCompleteDelegate(long responseCode, string response);
        public SilentPostOptimalCompleteDelegate SilentPostOptimalComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsOptimalApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsOptimalApi()
        {
            mSilentPostOptimalResponseContext = new KnetikResponseContext();
            mSilentPostOptimalResponseContext.ResponseReceived += OnSilentPostOptimalResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Initiate silent post with Optimal Will return the url for a hosted payment endpoint to post to. See Optimal documentation for details.
        /// </summary>
        /// <param name="request">The payment request to initiate</param>
        public void SilentPostOptimal(OptimalPaymentRequest request)
        {
            
            mWebCallEvent.WebPath = "/payment/provider/optimal/silent";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(request); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSilentPostOptimalStartTime = DateTime.Now;
            mWebCallEvent.Context = mSilentPostOptimalResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSilentPostOptimalStartTime, "SilentPostOptimal", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSilentPostOptimalResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SilentPostOptimal: " + response.Error);
            }

            SilentPostOptimalData = (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mSilentPostOptimalStartTime, "SilentPostOptimal", string.Format("Response received successfully:\n{0}", SilentPostOptimalData));

            if (SilentPostOptimalComplete != null)
            {
                SilentPostOptimalComplete(response.ResponseCode, SilentPostOptimalData);
            }
        }

    }
}
