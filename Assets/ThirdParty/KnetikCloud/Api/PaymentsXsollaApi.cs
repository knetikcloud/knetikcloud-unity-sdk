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
    public interface IPaymentsXsollaApi
    {
        string CreateXsollaTokenUrlData { get; }

        /// <summary>
        /// Create a payment token that should be used to forward the user to Xsolla so they can complete payment 
        /// </summary>
        /// <param name="request">The payment request to be sent to XSolla</param>
        void CreateXsollaTokenUrl(XsollaPaymentRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsXsollaApi : IPaymentsXsollaApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateXsollaTokenUrlResponseContext;
        private DateTime mCreateXsollaTokenUrlStartTime;

        public string CreateXsollaTokenUrlData { get; private set; }
        public delegate void CreateXsollaTokenUrlCompleteDelegate(long responseCode, string response);
        public CreateXsollaTokenUrlCompleteDelegate CreateXsollaTokenUrlComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsXsollaApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsXsollaApi()
        {
            mCreateXsollaTokenUrlResponseContext = new KnetikResponseContext();
            mCreateXsollaTokenUrlResponseContext.ResponseReceived += OnCreateXsollaTokenUrlResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a payment token that should be used to forward the user to Xsolla so they can complete payment 
        /// </summary>
        /// <param name="request">The payment request to be sent to XSolla</param>
        public void CreateXsollaTokenUrl(XsollaPaymentRequest request)
        {
            
            mWebCallEvent.WebPath = "/payment/provider/xsolla/payment";
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
            mCreateXsollaTokenUrlStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateXsollaTokenUrlResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateXsollaTokenUrlStartTime, "CreateXsollaTokenUrl", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateXsollaTokenUrlResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateXsollaTokenUrl: " + response.Error);
            }

            CreateXsollaTokenUrlData = (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mCreateXsollaTokenUrlStartTime, "CreateXsollaTokenUrl", string.Format("Response received successfully:\n{0}", CreateXsollaTokenUrlData));

            if (CreateXsollaTokenUrlComplete != null)
            {
                CreateXsollaTokenUrlComplete(response.ResponseCode, CreateXsollaTokenUrlData);
            }
        }

    }
}
