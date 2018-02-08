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
    public interface IPaymentsStripeApi
    {
        PaymentMethodResource CreateStripePaymentMethodData { get; }

        /// <summary>
        /// Create a Stripe payment method for a user Obtain a token from Stripe, following their examples and documentation. Stores customer information and creates a payment method that can be used to pay invoices through the payments endpoints. Ensure that Stripe itself has been configured with the webhook so that invoices are marked paid. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; STRIPE_ADMIN or owner
        /// </summary>
        /// <param name="request">The request to create a Stripe customer with payment info</param>
        void CreateStripePaymentMethod(StripeCreatePaymentMethod request);

        

        /// <summary>
        /// Pay with a single use token Obtain a token from Stripe, following their examples and documentation. Pays an invoice without creating a payment method. Ensure that Stripe itself has been configured with the webhook so that invoices are marked paid. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateStripePaymentMethodResponseContext;
        private DateTime mCreateStripePaymentMethodStartTime;
        private readonly KnetikResponseContext mPayStripeInvoiceResponseContext;
        private DateTime mPayStripeInvoiceStartTime;

        public PaymentMethodResource CreateStripePaymentMethodData { get; private set; }
        public delegate void CreateStripePaymentMethodCompleteDelegate(long responseCode, PaymentMethodResource response);
        public CreateStripePaymentMethodCompleteDelegate CreateStripePaymentMethodComplete;

        public delegate void PayStripeInvoiceCompleteDelegate(long responseCode);
        public PayStripeInvoiceCompleteDelegate PayStripeInvoiceComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsStripeApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsStripeApi()
        {
            mCreateStripePaymentMethodResponseContext = new KnetikResponseContext();
            mCreateStripePaymentMethodResponseContext.ResponseReceived += OnCreateStripePaymentMethodResponse;
            mPayStripeInvoiceResponseContext = new KnetikResponseContext();
            mPayStripeInvoiceResponseContext.ResponseReceived += OnPayStripeInvoiceResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a Stripe payment method for a user Obtain a token from Stripe, following their examples and documentation. Stores customer information and creates a payment method that can be used to pay invoices through the payments endpoints. Ensure that Stripe itself has been configured with the webhook so that invoices are marked paid. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; STRIPE_ADMIN or owner
        /// </summary>
        /// <param name="request">The request to create a Stripe customer with payment info</param>
        public void CreateStripePaymentMethod(StripeCreatePaymentMethod request)
        {
            
            mWebCallEvent.WebPath = "/payment/provider/stripe/payment-methods";
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
            mCreateStripePaymentMethodStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateStripePaymentMethodResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateStripePaymentMethodStartTime, "CreateStripePaymentMethod", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateStripePaymentMethodResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateStripePaymentMethod: " + response.Error);
            }

            CreateStripePaymentMethodData = (PaymentMethodResource) KnetikClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
            KnetikLogger.LogResponse(mCreateStripePaymentMethodStartTime, "CreateStripePaymentMethod", string.Format("Response received successfully:\n{0}", CreateStripePaymentMethodData));

            if (CreateStripePaymentMethodComplete != null)
            {
                CreateStripePaymentMethodComplete(response.ResponseCode, CreateStripePaymentMethodData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Pay with a single use token Obtain a token from Stripe, following their examples and documentation. Pays an invoice without creating a payment method. Ensure that Stripe itself has been configured with the webhook so that invoices are marked paid. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="request">The request to pay an invoice</param>
        public void PayStripeInvoice(StripePaymentRequest request)
        {
            
            mWebCallEvent.WebPath = "/payment/provider/stripe/payments";
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
            mPayStripeInvoiceStartTime = DateTime.Now;
            mWebCallEvent.Context = mPayStripeInvoiceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mPayStripeInvoiceStartTime, "PayStripeInvoice", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnPayStripeInvoiceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling PayStripeInvoice: " + response.Error);
            }

            KnetikLogger.LogResponse(mPayStripeInvoiceStartTime, "PayStripeInvoice", "Response received successfully.");
            if (PayStripeInvoiceComplete != null)
            {
                PayStripeInvoiceComplete(response.ResponseCode);
            }
        }

    }
}
