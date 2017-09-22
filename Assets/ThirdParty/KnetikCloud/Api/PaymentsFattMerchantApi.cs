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
    public interface IPaymentsFattMerchantApi
    {
        PaymentMethodResource CreateOrUpdateFattMerchantPaymentMethodData { get; }

        
        /// <summary>
        /// Create or update a FattMerchant payment method for a user Stores customer information and creates a payment method that can be used to pay invoices through the payments endpoints.
        /// </summary>
        /// <param name="request">Request containing payment method information for user</param>
        void CreateOrUpdateFattMerchantPaymentMethod(FattMerchantPaymentMethodRequest request);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsFattMerchantApi : IPaymentsFattMerchantApi
    {
        private readonly KnetikCoroutine mCreateOrUpdateFattMerchantPaymentMethodCoroutine;
        private DateTime mCreateOrUpdateFattMerchantPaymentMethodStartTime;
        private string mCreateOrUpdateFattMerchantPaymentMethodPath;

        public PaymentMethodResource CreateOrUpdateFattMerchantPaymentMethodData { get; private set; }
        public delegate void CreateOrUpdateFattMerchantPaymentMethodCompleteDelegate(PaymentMethodResource response);
        public CreateOrUpdateFattMerchantPaymentMethodCompleteDelegate CreateOrUpdateFattMerchantPaymentMethodComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsFattMerchantApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsFattMerchantApi()
        {
            mCreateOrUpdateFattMerchantPaymentMethodCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
        /// <summary>
        /// Create or update a FattMerchant payment method for a user Stores customer information and creates a payment method that can be used to pay invoices through the payments endpoints.
        /// </summary>
        /// <param name="request">Request containing payment method information for user</param>
        public void CreateOrUpdateFattMerchantPaymentMethod(FattMerchantPaymentMethodRequest request)
        {
            
            mCreateOrUpdateFattMerchantPaymentMethodPath = "/payment/provider/fattmerchant/payment-methods";
            if (!string.IsNullOrEmpty(mCreateOrUpdateFattMerchantPaymentMethodPath))
            {
                mCreateOrUpdateFattMerchantPaymentMethodPath = mCreateOrUpdateFattMerchantPaymentMethodPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateOrUpdateFattMerchantPaymentMethodStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateOrUpdateFattMerchantPaymentMethodStartTime, mCreateOrUpdateFattMerchantPaymentMethodPath, "Sending server request...");

            // make the HTTP request
            mCreateOrUpdateFattMerchantPaymentMethodCoroutine.ResponseReceived += CreateOrUpdateFattMerchantPaymentMethodCallback;
            mCreateOrUpdateFattMerchantPaymentMethodCoroutine.Start(mCreateOrUpdateFattMerchantPaymentMethodPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateOrUpdateFattMerchantPaymentMethodCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateOrUpdateFattMerchantPaymentMethod: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateOrUpdateFattMerchantPaymentMethod: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateOrUpdateFattMerchantPaymentMethodData = (PaymentMethodResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
            KnetikLogger.LogResponse(mCreateOrUpdateFattMerchantPaymentMethodStartTime, mCreateOrUpdateFattMerchantPaymentMethodPath, string.Format("Response received successfully:\n{0}", CreateOrUpdateFattMerchantPaymentMethodData.ToString()));

            if (CreateOrUpdateFattMerchantPaymentMethodComplete != null)
            {
                CreateOrUpdateFattMerchantPaymentMethodComplete(CreateOrUpdateFattMerchantPaymentMethodData);
            }
        }
    }
}
