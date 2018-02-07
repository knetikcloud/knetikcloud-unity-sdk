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
    public interface IPaymentsPayPalClassicApi
    {
        string CreatePayPalBillingAgreementUrlData { get; }

        /// <summary>
        /// Create a PayPal Classic billing agreement for the user Returns the token that should be used to forward the user to PayPal so they can accept the agreement.
        /// </summary>
        /// <param name="request">The request to create a PayPal billing agreement</param>
        void CreatePayPalBillingAgreementUrl(CreateBillingAgreementRequest request);

        string CreatePayPalExpressCheckoutData { get; }

        /// <summary>
        /// Create a payment token for PayPal express checkout Returns the token that should be used to forward the user to PayPal so they can complete the checkout.
        /// </summary>
        /// <param name="request">The request to create a PayPal payment token</param>
        void CreatePayPalExpressCheckout(CreatePayPalPaymentRequest request);

        int? FinalizePayPalBillingAgreementData { get; }

        /// <summary>
        /// Finalizes a billing agreement after the user has accepted through PayPal Returns the ID of the new payment method created for the user for the billing agreement.
        /// </summary>
        /// <param name="request">The request to finalize a PayPal billing agreement</param>
        void FinalizePayPalBillingAgreement(FinalizeBillingAgreementRequest request);

        

        /// <summary>
        /// Finalizes a payment after the user has completed checkout with PayPal The invoice will be marked paid/failed by asynchronous IPN callback.
        /// </summary>
        /// <param name="request">The request to finalize the payment</param>
        void FinalizePayPalCheckout(FinalizePayPalPaymentRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsPayPalClassicApi : IPaymentsPayPalClassicApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreatePayPalBillingAgreementUrlResponseContext;
        private DateTime mCreatePayPalBillingAgreementUrlStartTime;
        private readonly KnetikResponseContext mCreatePayPalExpressCheckoutResponseContext;
        private DateTime mCreatePayPalExpressCheckoutStartTime;
        private readonly KnetikResponseContext mFinalizePayPalBillingAgreementResponseContext;
        private DateTime mFinalizePayPalBillingAgreementStartTime;
        private readonly KnetikResponseContext mFinalizePayPalCheckoutResponseContext;
        private DateTime mFinalizePayPalCheckoutStartTime;

        public string CreatePayPalBillingAgreementUrlData { get; private set; }
        public delegate void CreatePayPalBillingAgreementUrlCompleteDelegate(long responseCode, string response);
        public CreatePayPalBillingAgreementUrlCompleteDelegate CreatePayPalBillingAgreementUrlComplete;

        public string CreatePayPalExpressCheckoutData { get; private set; }
        public delegate void CreatePayPalExpressCheckoutCompleteDelegate(long responseCode, string response);
        public CreatePayPalExpressCheckoutCompleteDelegate CreatePayPalExpressCheckoutComplete;

        public int? FinalizePayPalBillingAgreementData { get; private set; }
        public delegate void FinalizePayPalBillingAgreementCompleteDelegate(long responseCode, int? response);
        public FinalizePayPalBillingAgreementCompleteDelegate FinalizePayPalBillingAgreementComplete;

        public delegate void FinalizePayPalCheckoutCompleteDelegate(long responseCode);
        public FinalizePayPalCheckoutCompleteDelegate FinalizePayPalCheckoutComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsPayPalClassicApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsPayPalClassicApi()
        {
            mCreatePayPalBillingAgreementUrlResponseContext = new KnetikResponseContext();
            mCreatePayPalBillingAgreementUrlResponseContext.ResponseReceived += OnCreatePayPalBillingAgreementUrlResponse;
            mCreatePayPalExpressCheckoutResponseContext = new KnetikResponseContext();
            mCreatePayPalExpressCheckoutResponseContext.ResponseReceived += OnCreatePayPalExpressCheckoutResponse;
            mFinalizePayPalBillingAgreementResponseContext = new KnetikResponseContext();
            mFinalizePayPalBillingAgreementResponseContext.ResponseReceived += OnFinalizePayPalBillingAgreementResponse;
            mFinalizePayPalCheckoutResponseContext = new KnetikResponseContext();
            mFinalizePayPalCheckoutResponseContext.ResponseReceived += OnFinalizePayPalCheckoutResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a PayPal Classic billing agreement for the user Returns the token that should be used to forward the user to PayPal so they can accept the agreement.
        /// </summary>
        /// <param name="request">The request to create a PayPal billing agreement</param>
        public void CreatePayPalBillingAgreementUrl(CreateBillingAgreementRequest request)
        {
            
            mWebCallEvent.WebPath = "/payment/provider/paypal/classic/agreements/start";
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
            mCreatePayPalBillingAgreementUrlStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreatePayPalBillingAgreementUrlResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreatePayPalBillingAgreementUrlStartTime, "CreatePayPalBillingAgreementUrl", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreatePayPalBillingAgreementUrlResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreatePayPalBillingAgreementUrl: " + response.Error);
            }

            CreatePayPalBillingAgreementUrlData = (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mCreatePayPalBillingAgreementUrlStartTime, "CreatePayPalBillingAgreementUrl", string.Format("Response received successfully:\n{0}", CreatePayPalBillingAgreementUrlData));

            if (CreatePayPalBillingAgreementUrlComplete != null)
            {
                CreatePayPalBillingAgreementUrlComplete(response.ResponseCode, CreatePayPalBillingAgreementUrlData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a payment token for PayPal express checkout Returns the token that should be used to forward the user to PayPal so they can complete the checkout.
        /// </summary>
        /// <param name="request">The request to create a PayPal payment token</param>
        public void CreatePayPalExpressCheckout(CreatePayPalPaymentRequest request)
        {
            
            mWebCallEvent.WebPath = "/payment/provider/paypal/classic/checkout/start";
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
            mCreatePayPalExpressCheckoutStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreatePayPalExpressCheckoutResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreatePayPalExpressCheckoutStartTime, "CreatePayPalExpressCheckout", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreatePayPalExpressCheckoutResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreatePayPalExpressCheckout: " + response.Error);
            }

            CreatePayPalExpressCheckoutData = (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mCreatePayPalExpressCheckoutStartTime, "CreatePayPalExpressCheckout", string.Format("Response received successfully:\n{0}", CreatePayPalExpressCheckoutData));

            if (CreatePayPalExpressCheckoutComplete != null)
            {
                CreatePayPalExpressCheckoutComplete(response.ResponseCode, CreatePayPalExpressCheckoutData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Finalizes a billing agreement after the user has accepted through PayPal Returns the ID of the new payment method created for the user for the billing agreement.
        /// </summary>
        /// <param name="request">The request to finalize a PayPal billing agreement</param>
        public void FinalizePayPalBillingAgreement(FinalizeBillingAgreementRequest request)
        {
            
            mWebCallEvent.WebPath = "/payment/provider/paypal/classic/agreements/finish";
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
            mFinalizePayPalBillingAgreementStartTime = DateTime.Now;
            mWebCallEvent.Context = mFinalizePayPalBillingAgreementResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mFinalizePayPalBillingAgreementStartTime, "FinalizePayPalBillingAgreement", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnFinalizePayPalBillingAgreementResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling FinalizePayPalBillingAgreement: " + response.Error);
            }

            FinalizePayPalBillingAgreementData = (int?) KnetikClient.Deserialize(response.Content, typeof(int?), response.Headers);
            KnetikLogger.LogResponse(mFinalizePayPalBillingAgreementStartTime, "FinalizePayPalBillingAgreement", string.Format("Response received successfully:\n{0}", FinalizePayPalBillingAgreementData));

            if (FinalizePayPalBillingAgreementComplete != null)
            {
                FinalizePayPalBillingAgreementComplete(response.ResponseCode, FinalizePayPalBillingAgreementData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Finalizes a payment after the user has completed checkout with PayPal The invoice will be marked paid/failed by asynchronous IPN callback.
        /// </summary>
        /// <param name="request">The request to finalize the payment</param>
        public void FinalizePayPalCheckout(FinalizePayPalPaymentRequest request)
        {
            
            mWebCallEvent.WebPath = "/payment/provider/paypal/classic/checkout/finish";
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
            mFinalizePayPalCheckoutStartTime = DateTime.Now;
            mWebCallEvent.Context = mFinalizePayPalCheckoutResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mFinalizePayPalCheckoutStartTime, "FinalizePayPalCheckout", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnFinalizePayPalCheckoutResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling FinalizePayPalCheckout: " + response.Error);
            }

            KnetikLogger.LogResponse(mFinalizePayPalCheckoutStartTime, "FinalizePayPalCheckout", "Response received successfully.");
            if (FinalizePayPalCheckoutComplete != null)
            {
                FinalizePayPalCheckoutComplete(response.ResponseCode);
            }
        }

    }
}
