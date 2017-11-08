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
    public interface IPaymentsStripeApi
    {
        PaymentMethodResource CreateStripePaymentMethodData { get; }

        
        /// <summary>
        /// Create a Stripe payment method for a user Obtain a token from Stripe, following their examples and documentation. Stores customer information and creates a payment method that can be used to pay invoices through the payments endpoints. Ensure that Stripe itself has been configured with the webhook so that invoices are marked paid.
        /// </summary>
        /// <param name="request">The request to create a Stripe customer with payment info</param>
        void CreateStripePaymentMethod(StripeCreatePaymentMethod request);

        /// <summary>
        /// Pay with a single use token Obtain a token from Stripe, following their examples and documentation. Pays an invoice without creating a payment method. Ensure that Stripe itself has been configured with the webhook so that invoices are marked paid.
        /// </summary>
        /// <param name="request">The request to pay an invoice</param>
        void PayStripeInvoice(StripePaymentRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsStripeApi : IPaymentsStripeApi
    {
        private readonly KnetikCoroutine mCreateStripePaymentMethodCoroutine;
        private DateTime mCreateStripePaymentMethodStartTime;
        private string mCreateStripePaymentMethodPath;
        private readonly KnetikCoroutine mPayStripeInvoiceCoroutine;
        private DateTime mPayStripeInvoiceStartTime;
        private string mPayStripeInvoicePath;

        public PaymentMethodResource CreateStripePaymentMethodData { get; private set; }
        public delegate void CreateStripePaymentMethodCompleteDelegate(PaymentMethodResource response);
        public CreateStripePaymentMethodCompleteDelegate CreateStripePaymentMethodComplete;

        public delegate void PayStripeInvoiceCompleteDelegate();
        public PayStripeInvoiceCompleteDelegate PayStripeInvoiceComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsStripeApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsStripeApi()
        {
            mCreateStripePaymentMethodCoroutine = new KnetikCoroutine();
            mPayStripeInvoiceCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a Stripe payment method for a user Obtain a token from Stripe, following their examples and documentation. Stores customer information and creates a payment method that can be used to pay invoices through the payments endpoints. Ensure that Stripe itself has been configured with the webhook so that invoices are marked paid.
        /// </summary>
        /// <param name="request">The request to create a Stripe customer with payment info</param>
        public void CreateStripePaymentMethod(StripeCreatePaymentMethod request)
        {
            
            mCreateStripePaymentMethodPath = "/payment/provider/stripe/payment-methods";
            if (!string.IsNullOrEmpty(mCreateStripePaymentMethodPath))
            {
                mCreateStripePaymentMethodPath = mCreateStripePaymentMethodPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateStripePaymentMethodStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateStripePaymentMethodStartTime, mCreateStripePaymentMethodPath, "Sending server request...");

            // make the HTTP request
            mCreateStripePaymentMethodCoroutine.ResponseReceived += CreateStripePaymentMethodCallback;
            mCreateStripePaymentMethodCoroutine.Start(mCreateStripePaymentMethodPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateStripePaymentMethodCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateStripePaymentMethod: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateStripePaymentMethod: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateStripePaymentMethodData = (PaymentMethodResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
            KnetikLogger.LogResponse(mCreateStripePaymentMethodStartTime, mCreateStripePaymentMethodPath, string.Format("Response received successfully:\n{0}", CreateStripePaymentMethodData.ToString()));

            if (CreateStripePaymentMethodComplete != null)
            {
                CreateStripePaymentMethodComplete(CreateStripePaymentMethodData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Pay with a single use token Obtain a token from Stripe, following their examples and documentation. Pays an invoice without creating a payment method. Ensure that Stripe itself has been configured with the webhook so that invoices are marked paid.
        /// </summary>
        /// <param name="request">The request to pay an invoice</param>
        public void PayStripeInvoice(StripePaymentRequest request)
        {
            
            mPayStripeInvoicePath = "/payment/provider/stripe/payments";
            if (!string.IsNullOrEmpty(mPayStripeInvoicePath))
            {
                mPayStripeInvoicePath = mPayStripeInvoicePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mPayStripeInvoiceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mPayStripeInvoiceStartTime, mPayStripeInvoicePath, "Sending server request...");

            // make the HTTP request
            mPayStripeInvoiceCoroutine.ResponseReceived += PayStripeInvoiceCallback;
            mPayStripeInvoiceCoroutine.Start(mPayStripeInvoicePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void PayStripeInvoiceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling PayStripeInvoice: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling PayStripeInvoice: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mPayStripeInvoiceStartTime, mPayStripeInvoicePath, "Response received successfully.");
            if (PayStripeInvoiceComplete != null)
            {
                PayStripeInvoiceComplete();
            }
        }

    }
}
