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
        private readonly KnetikCoroutine mVerifyAppleReceiptCoroutine;
        private DateTime mVerifyAppleReceiptStartTime;
        private string mVerifyAppleReceiptPath;

        public string VerifyAppleReceiptData { get; private set; }
        public delegate void VerifyAppleReceiptCompleteDelegate(string response);
        public VerifyAppleReceiptCompleteDelegate VerifyAppleReceiptComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsAppleApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsAppleApi()
        {
            mVerifyAppleReceiptCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Pay invoice with Apple receipt Mark an invoice paid using Apple payment receipt. A receipt will only be accepted once and the details of the transaction must match the invoice, including the product_id matching the sku text of the item in the invoice. Returns the transaction ID if successful.
        /// </summary>
        /// <param name="request">The request for paying an invoice through an Apple receipt</param>
        public void VerifyAppleReceipt(ApplyPaymentRequest request)
        {
            
            mVerifyAppleReceiptPath = "/payment/provider/apple/receipt";
            if (!string.IsNullOrEmpty(mVerifyAppleReceiptPath))
            {
                mVerifyAppleReceiptPath = mVerifyAppleReceiptPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mVerifyAppleReceiptStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mVerifyAppleReceiptStartTime, mVerifyAppleReceiptPath, "Sending server request...");

            // make the HTTP request
            mVerifyAppleReceiptCoroutine.ResponseReceived += VerifyAppleReceiptCallback;
            mVerifyAppleReceiptCoroutine.Start(mVerifyAppleReceiptPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void VerifyAppleReceiptCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling VerifyAppleReceipt: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling VerifyAppleReceipt: " + response.ErrorMessage, response.ErrorMessage);
            }

            VerifyAppleReceiptData = (string) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mVerifyAppleReceiptStartTime, mVerifyAppleReceiptPath, string.Format("Response received successfully:\n{0}", VerifyAppleReceiptData.ToString()));

            if (VerifyAppleReceiptComplete != null)
            {
                VerifyAppleReceiptComplete(VerifyAppleReceiptData);
            }
        }

    }
}
