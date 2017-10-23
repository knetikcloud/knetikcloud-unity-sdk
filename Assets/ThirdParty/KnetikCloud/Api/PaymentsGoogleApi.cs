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
    public interface IPaymentsGoogleApi
    {
        int? HandleGooglePaymentData { get; }

        
        /// <summary>
        /// Mark an invoice paid with Google Mark an invoice paid with Google. Verifies signature from Google and treats the developerPayload field inside the json payload as the id of the invoice to pay. Returns the transaction ID if successful.
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
        private readonly KnetikCoroutine mHandleGooglePaymentCoroutine;
        private DateTime mHandleGooglePaymentStartTime;
        private string mHandleGooglePaymentPath;

        public int? HandleGooglePaymentData { get; private set; }
        public delegate void HandleGooglePaymentCompleteDelegate(int? response);
        public HandleGooglePaymentCompleteDelegate HandleGooglePaymentComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsGoogleApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsGoogleApi()
        {
            mHandleGooglePaymentCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Mark an invoice paid with Google Mark an invoice paid with Google. Verifies signature from Google and treats the developerPayload field inside the json payload as the id of the invoice to pay. Returns the transaction ID if successful.
        /// </summary>
        /// <param name="request">The request for paying an invoice through a Google in-app payment</param>
        public void HandleGooglePayment(GooglePaymentRequest request)
        {
            
            mHandleGooglePaymentPath = "/payment/provider/google/payments";
            if (!string.IsNullOrEmpty(mHandleGooglePaymentPath))
            {
                mHandleGooglePaymentPath = mHandleGooglePaymentPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mHandleGooglePaymentStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mHandleGooglePaymentStartTime, mHandleGooglePaymentPath, "Sending server request...");

            // make the HTTP request
            mHandleGooglePaymentCoroutine.ResponseReceived += HandleGooglePaymentCallback;
            mHandleGooglePaymentCoroutine.Start(mHandleGooglePaymentPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void HandleGooglePaymentCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling HandleGooglePayment: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling HandleGooglePayment: " + response.ErrorMessage, response.ErrorMessage);
            }

            HandleGooglePaymentData = (int?) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(int?), response.Headers);
            KnetikLogger.LogResponse(mHandleGooglePaymentStartTime, mHandleGooglePaymentPath, string.Format("Response received successfully:\n{0}", HandleGooglePaymentData.ToString()));

            if (HandleGooglePaymentComplete != null)
            {
                HandleGooglePaymentComplete(HandleGooglePaymentData);
            }
        }

    }
}
