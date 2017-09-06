using System;
using System.Collections.Generic;
using RestSharp;
using com.knetikcloud.Client;
using com.knetikcloud.Model;
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
        /// <summary>
        /// Create or update a FattMerchant payment method for a user Stores customer information and creates a payment method that can be used to pay invoices through the payments endpoints.
        /// </summary>
        /// <param name="request">Request containing payment method information for user</param>
        /// <returns>PaymentMethodResource</returns>
        PaymentMethodResource CreateOrUpdateFattMerchantPaymentMethod (FattMerchantPaymentMethodRequest request);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsFattMerchantApi : IPaymentsFattMerchantApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsFattMerchantApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsFattMerchantApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create or update a FattMerchant payment method for a user Stores customer information and creates a payment method that can be used to pay invoices through the payments endpoints.
        /// </summary>
        /// <param name="request">Request containing payment method information for user</param> 
        /// <returns>PaymentMethodResource</returns>            
        public PaymentMethodResource CreateOrUpdateFattMerchantPaymentMethod(FattMerchantPaymentMethodRequest request)
        {
            
            string urlPath = "/payment/provider/fattmerchant/payment-methods";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateOrUpdateFattMerchantPaymentMethod: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateOrUpdateFattMerchantPaymentMethod: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PaymentMethodResource) KnetikClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
        }
    }
}
