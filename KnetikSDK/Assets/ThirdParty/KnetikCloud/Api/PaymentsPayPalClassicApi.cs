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
    public interface IPaymentsPayPalClassicApi
    {
        /// <summary>
        /// Create a PayPal Classic billing agreement for the user Returns the token that should be used to forward the user to PayPal so they can accept the agreement.
        /// </summary>
        /// <param name="request">The request to create a PayPal billing agreement</param>
        /// <returns>string</returns>
        string CreatePayPalBillingAgreementUrl (CreateBillingAgreementRequest request);
        /// <summary>
        /// Create a payment token for PayPal express checkout Returns the token that should be used to forward the user to PayPal so they can complete the checkout.
        /// </summary>
        /// <param name="request">The request to create a PayPal payment token</param>
        /// <returns>string</returns>
        string CreatePayPalExpressCheckout (CreatePayPalPaymentRequest request);
        /// <summary>
        /// Finalizes a billing agreement after the user has accepted through PayPal Returns the ID of the new payment method created for the user for the billing agreement.
        /// </summary>
        /// <param name="request">The request to finalize a PayPal billing agreement</param>
        /// <returns>int?</returns>
        int? FinalizePayPalBillingAgreement (FinalizeBillingAgreementRequest request);
        /// <summary>
        /// Finalizes a payment after the user has completed checkout with PayPal The invoice will be marked paid/failed by asynchronous IPN callback.
        /// </summary>
        /// <param name="request">The request to finalize the payment</param>
        /// <returns></returns>
        void FinalizePayPalCheckout (FinalizePayPalPaymentRequest request);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsPayPalClassicApi : IPaymentsPayPalClassicApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsPayPalClassicApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsPayPalClassicApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a PayPal Classic billing agreement for the user Returns the token that should be used to forward the user to PayPal so they can accept the agreement.
        /// </summary>
        /// <param name="request">The request to create a PayPal billing agreement</param> 
        /// <returns>string</returns>            
        public string CreatePayPalBillingAgreementUrl(CreateBillingAgreementRequest request)
        {
            
            string urlPath = "/payment/provider/paypal/classic/agreements/start";
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
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreatePayPalBillingAgreementUrl: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreatePayPalBillingAgreementUrl: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
        }
        /// <summary>
        /// Create a payment token for PayPal express checkout Returns the token that should be used to forward the user to PayPal so they can complete the checkout.
        /// </summary>
        /// <param name="request">The request to create a PayPal payment token</param> 
        /// <returns>string</returns>            
        public string CreatePayPalExpressCheckout(CreatePayPalPaymentRequest request)
        {
            
            string urlPath = "/payment/provider/paypal/classic/checkout/start";
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
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreatePayPalExpressCheckout: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreatePayPalExpressCheckout: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
        }
        /// <summary>
        /// Finalizes a billing agreement after the user has accepted through PayPal Returns the ID of the new payment method created for the user for the billing agreement.
        /// </summary>
        /// <param name="request">The request to finalize a PayPal billing agreement</param> 
        /// <returns>int?</returns>            
        public int? FinalizePayPalBillingAgreement(FinalizeBillingAgreementRequest request)
        {
            
            string urlPath = "/payment/provider/paypal/classic/agreements/finish";
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
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling FinalizePayPalBillingAgreement: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling FinalizePayPalBillingAgreement: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (int?) KnetikClient.Deserialize(response.Content, typeof(int?), response.Headers);
        }
        /// <summary>
        /// Finalizes a payment after the user has completed checkout with PayPal The invoice will be marked paid/failed by asynchronous IPN callback.
        /// </summary>
        /// <param name="request">The request to finalize the payment</param> 
        /// <returns></returns>            
        public void FinalizePayPalCheckout(FinalizePayPalPaymentRequest request)
        {
            
            string urlPath = "/payment/provider/paypal/classic/checkout/finish";
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
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling FinalizePayPalCheckout: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling FinalizePayPalCheckout: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
    }
}
