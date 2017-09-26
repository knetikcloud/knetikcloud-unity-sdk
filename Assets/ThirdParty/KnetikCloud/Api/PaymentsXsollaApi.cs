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
        private readonly KnetikCoroutine mCreateXsollaTokenUrlCoroutine;
        private DateTime mCreateXsollaTokenUrlStartTime;
        private string mCreateXsollaTokenUrlPath;

        public string CreateXsollaTokenUrlData { get; private set; }
        public delegate void CreateXsollaTokenUrlCompleteDelegate(string response);
        public CreateXsollaTokenUrlCompleteDelegate CreateXsollaTokenUrlComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsXsollaApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsXsollaApi()
        {
            mCreateXsollaTokenUrlCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a payment token that should be used to forward the user to Xsolla so they can complete payment 
        /// </summary>
        /// <param name="request">The payment request to be sent to XSolla</param>
        public void CreateXsollaTokenUrl(XsollaPaymentRequest request)
        {
            
            mCreateXsollaTokenUrlPath = "/payment/provider/xsolla/payment";
            if (!string.IsNullOrEmpty(mCreateXsollaTokenUrlPath))
            {
                mCreateXsollaTokenUrlPath = mCreateXsollaTokenUrlPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateXsollaTokenUrlStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateXsollaTokenUrlStartTime, mCreateXsollaTokenUrlPath, "Sending server request...");

            // make the HTTP request
            mCreateXsollaTokenUrlCoroutine.ResponseReceived += CreateXsollaTokenUrlCallback;
            mCreateXsollaTokenUrlCoroutine.Start(mCreateXsollaTokenUrlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateXsollaTokenUrlCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateXsollaTokenUrl: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateXsollaTokenUrl: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateXsollaTokenUrlData = (string) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mCreateXsollaTokenUrlStartTime, mCreateXsollaTokenUrlPath, string.Format("Response received successfully:\n{0}", CreateXsollaTokenUrlData.ToString()));

            if (CreateXsollaTokenUrlComplete != null)
            {
                CreateXsollaTokenUrlComplete(CreateXsollaTokenUrlData);
            }
        }
    }
}
