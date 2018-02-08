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
    public interface IPaymentsGoogleApi
    {
        int? HandleGooglePaymentData { get; }

        /// <summary>
        /// Mark an invoice paid with Google Mark an invoice paid with Google. Verifies signature from Google and treats the developerPayload field inside the json payload as the id of the invoice to pay. Returns the transaction ID if successful. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="request">The request for paying an invoice through a Google in-app payment</param>
        void HandleGooglePayment(GooglePaymentRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsGoogleApi : IPaymentsGoogleApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mHandleGooglePaymentResponseContext;
        private DateTime mHandleGooglePaymentStartTime;

        public int? HandleGooglePaymentData { get; private set; }
        public delegate void HandleGooglePaymentCompleteDelegate(long responseCode, int? response);
        public HandleGooglePaymentCompleteDelegate HandleGooglePaymentComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsGoogleApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsGoogleApi()
        {
            mHandleGooglePaymentResponseContext = new KnetikResponseContext();
            mHandleGooglePaymentResponseContext.ResponseReceived += OnHandleGooglePaymentResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Mark an invoice paid with Google Mark an invoice paid with Google. Verifies signature from Google and treats the developerPayload field inside the json payload as the id of the invoice to pay. Returns the transaction ID if successful. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="request">The request for paying an invoice through a Google in-app payment</param>
        public void HandleGooglePayment(GooglePaymentRequest request)
        {
            
            mWebCallEvent.WebPath = "/payment/provider/google/payments";
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
            mHandleGooglePaymentStartTime = DateTime.Now;
            mWebCallEvent.Context = mHandleGooglePaymentResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mHandleGooglePaymentStartTime, "HandleGooglePayment", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnHandleGooglePaymentResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling HandleGooglePayment: " + response.Error);
            }

            HandleGooglePaymentData = (int?) KnetikClient.Deserialize(response.Content, typeof(int?), response.Headers);
            KnetikLogger.LogResponse(mHandleGooglePaymentStartTime, "HandleGooglePayment", string.Format("Response received successfully:\n{0}", HandleGooglePaymentData));

            if (HandleGooglePaymentComplete != null)
            {
                HandleGooglePaymentComplete(response.ResponseCode, HandleGooglePaymentData);
            }
        }

    }
}
