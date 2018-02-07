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
    public interface IPaymentsAppleApi
    {
        string VerifyAppleReceiptData { get; }

        /// <summary>
        /// Pay invoice with Apple receipt Mark an invoice paid using Apple payment receipt. A receipt will only be accepted once and the details of the transaction must match the invoice, including the product_id matching the sku text of the item in the invoice. Returns the transaction ID if successful.
        /// </summary>
        /// <param name="request">The request for paying an invoice through an Apple receipt</param>
        void VerifyAppleReceipt(ApplyPaymentRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsAppleApi : IPaymentsAppleApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mVerifyAppleReceiptResponseContext;
        private DateTime mVerifyAppleReceiptStartTime;

        public string VerifyAppleReceiptData { get; private set; }
        public delegate void VerifyAppleReceiptCompleteDelegate(long responseCode, string response);
        public VerifyAppleReceiptCompleteDelegate VerifyAppleReceiptComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsAppleApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsAppleApi()
        {
            mVerifyAppleReceiptResponseContext = new KnetikResponseContext();
            mVerifyAppleReceiptResponseContext.ResponseReceived += OnVerifyAppleReceiptResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Pay invoice with Apple receipt Mark an invoice paid using Apple payment receipt. A receipt will only be accepted once and the details of the transaction must match the invoice, including the product_id matching the sku text of the item in the invoice. Returns the transaction ID if successful.
        /// </summary>
        /// <param name="request">The request for paying an invoice through an Apple receipt</param>
        public void VerifyAppleReceipt(ApplyPaymentRequest request)
        {
            
            mWebCallEvent.WebPath = "/payment/provider/apple/receipt";
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
            mVerifyAppleReceiptStartTime = DateTime.Now;
            mWebCallEvent.Context = mVerifyAppleReceiptResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mVerifyAppleReceiptStartTime, "VerifyAppleReceipt", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnVerifyAppleReceiptResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling VerifyAppleReceipt: " + response.Error);
            }

            VerifyAppleReceiptData = (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mVerifyAppleReceiptStartTime, "VerifyAppleReceipt", string.Format("Response received successfully:\n{0}", VerifyAppleReceiptData));

            if (VerifyAppleReceiptComplete != null)
            {
                VerifyAppleReceiptComplete(response.ResponseCode, VerifyAppleReceiptData);
            }
        }

    }
}
