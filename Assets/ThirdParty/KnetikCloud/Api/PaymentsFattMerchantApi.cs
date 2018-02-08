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
    public interface IPaymentsFattMerchantApi
    {
        PaymentMethodResource CreateOrUpdateFattMerchantPaymentMethodData { get; }

        /// <summary>
        /// Create or update a FattMerchant payment method for a user Stores customer information and creates a payment method that can be used to pay invoices through the payments endpoints. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; FATTMERCHANT_ADMIN or owner
        /// </summary>
        /// <param name="request">Request containing payment method information for user</param>
        void CreateOrUpdateFattMerchantPaymentMethod(FattMerchantPaymentMethodRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsFattMerchantApi : IPaymentsFattMerchantApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateOrUpdateFattMerchantPaymentMethodResponseContext;
        private DateTime mCreateOrUpdateFattMerchantPaymentMethodStartTime;

        public PaymentMethodResource CreateOrUpdateFattMerchantPaymentMethodData { get; private set; }
        public delegate void CreateOrUpdateFattMerchantPaymentMethodCompleteDelegate(long responseCode, PaymentMethodResource response);
        public CreateOrUpdateFattMerchantPaymentMethodCompleteDelegate CreateOrUpdateFattMerchantPaymentMethodComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsFattMerchantApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsFattMerchantApi()
        {
            mCreateOrUpdateFattMerchantPaymentMethodResponseContext = new KnetikResponseContext();
            mCreateOrUpdateFattMerchantPaymentMethodResponseContext.ResponseReceived += OnCreateOrUpdateFattMerchantPaymentMethodResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create or update a FattMerchant payment method for a user Stores customer information and creates a payment method that can be used to pay invoices through the payments endpoints. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; FATTMERCHANT_ADMIN or owner
        /// </summary>
        /// <param name="request">Request containing payment method information for user</param>
        public void CreateOrUpdateFattMerchantPaymentMethod(FattMerchantPaymentMethodRequest request)
        {
            
            mWebCallEvent.WebPath = "/payment/provider/fattmerchant/payment-methods";
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
            mCreateOrUpdateFattMerchantPaymentMethodStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateOrUpdateFattMerchantPaymentMethodResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mCreateOrUpdateFattMerchantPaymentMethodStartTime, "CreateOrUpdateFattMerchantPaymentMethod", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateOrUpdateFattMerchantPaymentMethodResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateOrUpdateFattMerchantPaymentMethod: " + response.Error);
            }

            CreateOrUpdateFattMerchantPaymentMethodData = (PaymentMethodResource) KnetikClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
            KnetikLogger.LogResponse(mCreateOrUpdateFattMerchantPaymentMethodStartTime, "CreateOrUpdateFattMerchantPaymentMethod", string.Format("Response received successfully:\n{0}", CreateOrUpdateFattMerchantPaymentMethodData));

            if (CreateOrUpdateFattMerchantPaymentMethodComplete != null)
            {
                CreateOrUpdateFattMerchantPaymentMethodComplete(response.ResponseCode, CreateOrUpdateFattMerchantPaymentMethodData);
            }
        }

    }
}
