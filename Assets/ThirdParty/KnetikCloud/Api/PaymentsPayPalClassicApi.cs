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
    public interface IPaymentsPayPalClassicApi
    {
        string CreatePayPalBillingAgreementUrlData { get; }

        string CreatePayPalExpressCheckoutData { get; }

        int? FinalizePayPalBillingAgreementData { get; }

        
        /// <summary>
        /// Create a PayPal Classic billing agreement for the user Returns the token that should be used to forward the user to PayPal so they can accept the agreement.
        /// </summary>
        /// <param name="request">The request to create a PayPal billing agreement</param>
        void CreatePayPalBillingAgreementUrl(CreateBillingAgreementRequest request);

        /// <summary>
        /// Create a payment token for PayPal express checkout Returns the token that should be used to forward the user to PayPal so they can complete the checkout.
        /// </summary>
        /// <param name="request">The request to create a PayPal payment token</param>
        void CreatePayPalExpressCheckout(CreatePayPalPaymentRequest request);

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
        private readonly KnetikCoroutine mCreatePayPalBillingAgreementUrlCoroutine;
        private DateTime mCreatePayPalBillingAgreementUrlStartTime;
        private string mCreatePayPalBillingAgreementUrlPath;
        private readonly KnetikCoroutine mCreatePayPalExpressCheckoutCoroutine;
        private DateTime mCreatePayPalExpressCheckoutStartTime;
        private string mCreatePayPalExpressCheckoutPath;
        private readonly KnetikCoroutine mFinalizePayPalBillingAgreementCoroutine;
        private DateTime mFinalizePayPalBillingAgreementStartTime;
        private string mFinalizePayPalBillingAgreementPath;
        private readonly KnetikCoroutine mFinalizePayPalCheckoutCoroutine;
        private DateTime mFinalizePayPalCheckoutStartTime;
        private string mFinalizePayPalCheckoutPath;

        public string CreatePayPalBillingAgreementUrlData { get; private set; }
        public delegate void CreatePayPalBillingAgreementUrlCompleteDelegate(string response);
        public CreatePayPalBillingAgreementUrlCompleteDelegate CreatePayPalBillingAgreementUrlComplete;

        public string CreatePayPalExpressCheckoutData { get; private set; }
        public delegate void CreatePayPalExpressCheckoutCompleteDelegate(string response);
        public CreatePayPalExpressCheckoutCompleteDelegate CreatePayPalExpressCheckoutComplete;

        public int? FinalizePayPalBillingAgreementData { get; private set; }
        public delegate void FinalizePayPalBillingAgreementCompleteDelegate(int? response);
        public FinalizePayPalBillingAgreementCompleteDelegate FinalizePayPalBillingAgreementComplete;

        public delegate void FinalizePayPalCheckoutCompleteDelegate();
        public FinalizePayPalCheckoutCompleteDelegate FinalizePayPalCheckoutComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsPayPalClassicApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsPayPalClassicApi()
        {
            mCreatePayPalBillingAgreementUrlCoroutine = new KnetikCoroutine();
            mCreatePayPalExpressCheckoutCoroutine = new KnetikCoroutine();
            mFinalizePayPalBillingAgreementCoroutine = new KnetikCoroutine();
            mFinalizePayPalCheckoutCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a PayPal Classic billing agreement for the user Returns the token that should be used to forward the user to PayPal so they can accept the agreement.
        /// </summary>
        /// <param name="request">The request to create a PayPal billing agreement</param>
        public void CreatePayPalBillingAgreementUrl(CreateBillingAgreementRequest request)
        {
            
            mCreatePayPalBillingAgreementUrlPath = "/payment/provider/paypal/classic/agreements/start";
            if (!string.IsNullOrEmpty(mCreatePayPalBillingAgreementUrlPath))
            {
                mCreatePayPalBillingAgreementUrlPath = mCreatePayPalBillingAgreementUrlPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreatePayPalBillingAgreementUrlStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreatePayPalBillingAgreementUrlStartTime, mCreatePayPalBillingAgreementUrlPath, "Sending server request...");

            // make the HTTP request
            mCreatePayPalBillingAgreementUrlCoroutine.ResponseReceived += CreatePayPalBillingAgreementUrlCallback;
            mCreatePayPalBillingAgreementUrlCoroutine.Start(mCreatePayPalBillingAgreementUrlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreatePayPalBillingAgreementUrlCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreatePayPalBillingAgreementUrl: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreatePayPalBillingAgreementUrl: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreatePayPalBillingAgreementUrlData = (string) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mCreatePayPalBillingAgreementUrlStartTime, mCreatePayPalBillingAgreementUrlPath, string.Format("Response received successfully:\n{0}", CreatePayPalBillingAgreementUrlData.ToString()));

            if (CreatePayPalBillingAgreementUrlComplete != null)
            {
                CreatePayPalBillingAgreementUrlComplete(CreatePayPalBillingAgreementUrlData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a payment token for PayPal express checkout Returns the token that should be used to forward the user to PayPal so they can complete the checkout.
        /// </summary>
        /// <param name="request">The request to create a PayPal payment token</param>
        public void CreatePayPalExpressCheckout(CreatePayPalPaymentRequest request)
        {
            
            mCreatePayPalExpressCheckoutPath = "/payment/provider/paypal/classic/checkout/start";
            if (!string.IsNullOrEmpty(mCreatePayPalExpressCheckoutPath))
            {
                mCreatePayPalExpressCheckoutPath = mCreatePayPalExpressCheckoutPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreatePayPalExpressCheckoutStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreatePayPalExpressCheckoutStartTime, mCreatePayPalExpressCheckoutPath, "Sending server request...");

            // make the HTTP request
            mCreatePayPalExpressCheckoutCoroutine.ResponseReceived += CreatePayPalExpressCheckoutCallback;
            mCreatePayPalExpressCheckoutCoroutine.Start(mCreatePayPalExpressCheckoutPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreatePayPalExpressCheckoutCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreatePayPalExpressCheckout: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreatePayPalExpressCheckout: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreatePayPalExpressCheckoutData = (string) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mCreatePayPalExpressCheckoutStartTime, mCreatePayPalExpressCheckoutPath, string.Format("Response received successfully:\n{0}", CreatePayPalExpressCheckoutData.ToString()));

            if (CreatePayPalExpressCheckoutComplete != null)
            {
                CreatePayPalExpressCheckoutComplete(CreatePayPalExpressCheckoutData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Finalizes a billing agreement after the user has accepted through PayPal Returns the ID of the new payment method created for the user for the billing agreement.
        /// </summary>
        /// <param name="request">The request to finalize a PayPal billing agreement</param>
        public void FinalizePayPalBillingAgreement(FinalizeBillingAgreementRequest request)
        {
            
            mFinalizePayPalBillingAgreementPath = "/payment/provider/paypal/classic/agreements/finish";
            if (!string.IsNullOrEmpty(mFinalizePayPalBillingAgreementPath))
            {
                mFinalizePayPalBillingAgreementPath = mFinalizePayPalBillingAgreementPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mFinalizePayPalBillingAgreementStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mFinalizePayPalBillingAgreementStartTime, mFinalizePayPalBillingAgreementPath, "Sending server request...");

            // make the HTTP request
            mFinalizePayPalBillingAgreementCoroutine.ResponseReceived += FinalizePayPalBillingAgreementCallback;
            mFinalizePayPalBillingAgreementCoroutine.Start(mFinalizePayPalBillingAgreementPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void FinalizePayPalBillingAgreementCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling FinalizePayPalBillingAgreement: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling FinalizePayPalBillingAgreement: " + response.ErrorMessage, response.ErrorMessage);
            }

            FinalizePayPalBillingAgreementData = (int?) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(int?), response.Headers);
            KnetikLogger.LogResponse(mFinalizePayPalBillingAgreementStartTime, mFinalizePayPalBillingAgreementPath, string.Format("Response received successfully:\n{0}", FinalizePayPalBillingAgreementData.ToString()));

            if (FinalizePayPalBillingAgreementComplete != null)
            {
                FinalizePayPalBillingAgreementComplete(FinalizePayPalBillingAgreementData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Finalizes a payment after the user has completed checkout with PayPal The invoice will be marked paid/failed by asynchronous IPN callback.
        /// </summary>
        /// <param name="request">The request to finalize the payment</param>
        public void FinalizePayPalCheckout(FinalizePayPalPaymentRequest request)
        {
            
            mFinalizePayPalCheckoutPath = "/payment/provider/paypal/classic/checkout/finish";
            if (!string.IsNullOrEmpty(mFinalizePayPalCheckoutPath))
            {
                mFinalizePayPalCheckoutPath = mFinalizePayPalCheckoutPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mFinalizePayPalCheckoutStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mFinalizePayPalCheckoutStartTime, mFinalizePayPalCheckoutPath, "Sending server request...");

            // make the HTTP request
            mFinalizePayPalCheckoutCoroutine.ResponseReceived += FinalizePayPalCheckoutCallback;
            mFinalizePayPalCheckoutCoroutine.Start(mFinalizePayPalCheckoutPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void FinalizePayPalCheckoutCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling FinalizePayPalCheckout: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling FinalizePayPalCheckout: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mFinalizePayPalCheckoutStartTime, mFinalizePayPalCheckoutPath, "Response received successfully.");
            if (FinalizePayPalCheckoutComplete != null)
            {
                FinalizePayPalCheckoutComplete();
            }
        }

    }
}
