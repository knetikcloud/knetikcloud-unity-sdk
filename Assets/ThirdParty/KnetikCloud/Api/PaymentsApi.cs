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
    public interface IPaymentsApi
    {
        PaymentMethodResource CreatePaymentMethodData { get; }

        /// <summary>
        /// Create a new payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being created</param>
        /// <param name="paymentMethod">Payment method being created</param>
        void CreatePaymentMethod(int? userId, PaymentMethodResource paymentMethod);

        

        /// <summary>
        /// Delete an existing payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being updated</param>
        /// <param name="id">ID of the payment method being deleted</param>
        void DeletePaymentMethod(int? userId, int? id);

        PaymentMethodResource GetPaymentMethodData { get; }

        /// <summary>
        /// Get a single payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being retrieved</param>
        /// <param name="id">ID of the payment method being retrieved</param>
        void GetPaymentMethod(int? userId, int? id);

        PaymentMethodTypeResource GetPaymentMethodTypeData { get; }

        /// <summary>
        /// Get a single payment method type 
        /// </summary>
        /// <param name="id">ID of the payment method type being retrieved</param>
        void GetPaymentMethodType(int? id);

        PageResourcePaymentMethodTypeResource GetPaymentMethodTypesData { get; }

        /// <summary>
        /// Get all payment method types 
        /// </summary>
        /// <param name="filterName">Filter for payment method types whose name matches a given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">a comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetPaymentMethodTypes(string filterName, int? size, int? page, string order);

        List<PaymentMethodResource> GetPaymentMethodsData { get; }

        /// <summary>
        /// Get all payment methods for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment methods are being retrieved</param>
        /// <param name="filterName">Filter for payment methods whose name starts with a given string</param>
        /// <param name="filterPaymentType">Filter for payment methods with a specific payment type</param>
        /// <param name="filterPaymentMethodTypeId">Filter for payment methods with a specific payment method type by id</param>
        /// <param name="filterPaymentMethodTypeName">Filter for payment methods whose payment method type name starts with a given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">a comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetPaymentMethods(int? userId, string filterName, string filterPaymentType, int? filterPaymentMethodTypeId, string filterPaymentMethodTypeName, int? size, int? page, string order);

        PaymentAuthorizationResource PaymentAuthorizationData { get; }

        /// <summary>
        /// Authorize payment of an invoice for later capture 
        /// </summary>
        /// <param name="request">Payment authorization request</param>
        void PaymentAuthorization(PaymentAuthorizationResource request);

        

        /// <summary>
        /// Capture an existing invoice payment authorization 
        /// </summary>
        /// <param name="id">ID of the payment authorization to capture</param>
        void PaymentCapture(int? id);

        PaymentMethodResource UpdatePaymentMethodData { get; }

        /// <summary>
        /// Update an existing payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being updated</param>
        /// <param name="id">ID of the payment method being updated</param>
        /// <param name="paymentMethod">The updated payment method data</param>
        void UpdatePaymentMethod(int? userId, int? id, PaymentMethodResource paymentMethod);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsApi : IPaymentsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreatePaymentMethodResponseContext;
        private DateTime mCreatePaymentMethodStartTime;
        private readonly KnetikResponseContext mDeletePaymentMethodResponseContext;
        private DateTime mDeletePaymentMethodStartTime;
        private readonly KnetikResponseContext mGetPaymentMethodResponseContext;
        private DateTime mGetPaymentMethodStartTime;
        private readonly KnetikResponseContext mGetPaymentMethodTypeResponseContext;
        private DateTime mGetPaymentMethodTypeStartTime;
        private readonly KnetikResponseContext mGetPaymentMethodTypesResponseContext;
        private DateTime mGetPaymentMethodTypesStartTime;
        private readonly KnetikResponseContext mGetPaymentMethodsResponseContext;
        private DateTime mGetPaymentMethodsStartTime;
        private readonly KnetikResponseContext mPaymentAuthorizationResponseContext;
        private DateTime mPaymentAuthorizationStartTime;
        private readonly KnetikResponseContext mPaymentCaptureResponseContext;
        private DateTime mPaymentCaptureStartTime;
        private readonly KnetikResponseContext mUpdatePaymentMethodResponseContext;
        private DateTime mUpdatePaymentMethodStartTime;

        public PaymentMethodResource CreatePaymentMethodData { get; private set; }
        public delegate void CreatePaymentMethodCompleteDelegate(long responseCode, PaymentMethodResource response);
        public CreatePaymentMethodCompleteDelegate CreatePaymentMethodComplete;

        public delegate void DeletePaymentMethodCompleteDelegate(long responseCode);
        public DeletePaymentMethodCompleteDelegate DeletePaymentMethodComplete;

        public PaymentMethodResource GetPaymentMethodData { get; private set; }
        public delegate void GetPaymentMethodCompleteDelegate(long responseCode, PaymentMethodResource response);
        public GetPaymentMethodCompleteDelegate GetPaymentMethodComplete;

        public PaymentMethodTypeResource GetPaymentMethodTypeData { get; private set; }
        public delegate void GetPaymentMethodTypeCompleteDelegate(long responseCode, PaymentMethodTypeResource response);
        public GetPaymentMethodTypeCompleteDelegate GetPaymentMethodTypeComplete;

        public PageResourcePaymentMethodTypeResource GetPaymentMethodTypesData { get; private set; }
        public delegate void GetPaymentMethodTypesCompleteDelegate(long responseCode, PageResourcePaymentMethodTypeResource response);
        public GetPaymentMethodTypesCompleteDelegate GetPaymentMethodTypesComplete;

        public List<PaymentMethodResource> GetPaymentMethodsData { get; private set; }
        public delegate void GetPaymentMethodsCompleteDelegate(long responseCode, List<PaymentMethodResource> response);
        public GetPaymentMethodsCompleteDelegate GetPaymentMethodsComplete;

        public PaymentAuthorizationResource PaymentAuthorizationData { get; private set; }
        public delegate void PaymentAuthorizationCompleteDelegate(long responseCode, PaymentAuthorizationResource response);
        public PaymentAuthorizationCompleteDelegate PaymentAuthorizationComplete;

        public delegate void PaymentCaptureCompleteDelegate(long responseCode);
        public PaymentCaptureCompleteDelegate PaymentCaptureComplete;

        public PaymentMethodResource UpdatePaymentMethodData { get; private set; }
        public delegate void UpdatePaymentMethodCompleteDelegate(long responseCode, PaymentMethodResource response);
        public UpdatePaymentMethodCompleteDelegate UpdatePaymentMethodComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsApi()
        {
            mCreatePaymentMethodResponseContext = new KnetikResponseContext();
            mCreatePaymentMethodResponseContext.ResponseReceived += OnCreatePaymentMethodResponse;
            mDeletePaymentMethodResponseContext = new KnetikResponseContext();
            mDeletePaymentMethodResponseContext.ResponseReceived += OnDeletePaymentMethodResponse;
            mGetPaymentMethodResponseContext = new KnetikResponseContext();
            mGetPaymentMethodResponseContext.ResponseReceived += OnGetPaymentMethodResponse;
            mGetPaymentMethodTypeResponseContext = new KnetikResponseContext();
            mGetPaymentMethodTypeResponseContext.ResponseReceived += OnGetPaymentMethodTypeResponse;
            mGetPaymentMethodTypesResponseContext = new KnetikResponseContext();
            mGetPaymentMethodTypesResponseContext.ResponseReceived += OnGetPaymentMethodTypesResponse;
            mGetPaymentMethodsResponseContext = new KnetikResponseContext();
            mGetPaymentMethodsResponseContext.ResponseReceived += OnGetPaymentMethodsResponse;
            mPaymentAuthorizationResponseContext = new KnetikResponseContext();
            mPaymentAuthorizationResponseContext.ResponseReceived += OnPaymentAuthorizationResponse;
            mPaymentCaptureResponseContext = new KnetikResponseContext();
            mPaymentCaptureResponseContext.ResponseReceived += OnPaymentCaptureResponse;
            mUpdatePaymentMethodResponseContext = new KnetikResponseContext();
            mUpdatePaymentMethodResponseContext.ResponseReceived += OnUpdatePaymentMethodResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a new payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being created</param>
        /// <param name="paymentMethod">Payment method being created</param>
        public void CreatePaymentMethod(int? userId, PaymentMethodResource paymentMethod)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling CreatePaymentMethod");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/payment-methods";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(paymentMethod); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreatePaymentMethodStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreatePaymentMethodResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreatePaymentMethodStartTime, "CreatePaymentMethod", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreatePaymentMethodResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreatePaymentMethod: " + response.Error);
            }

            CreatePaymentMethodData = (PaymentMethodResource) KnetikClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
            KnetikLogger.LogResponse(mCreatePaymentMethodStartTime, "CreatePaymentMethod", string.Format("Response received successfully:\n{0}", CreatePaymentMethodData));

            if (CreatePaymentMethodComplete != null)
            {
                CreatePaymentMethodComplete(response.ResponseCode, CreatePaymentMethodData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an existing payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being updated</param>
        /// <param name="id">ID of the payment method being deleted</param>
        public void DeletePaymentMethod(int? userId, int? id)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling DeletePaymentMethod");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeletePaymentMethod");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/payment-methods/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeletePaymentMethodStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeletePaymentMethodResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeletePaymentMethodStartTime, "DeletePaymentMethod", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeletePaymentMethodResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeletePaymentMethod: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeletePaymentMethodStartTime, "DeletePaymentMethod", "Response received successfully.");
            if (DeletePaymentMethodComplete != null)
            {
                DeletePaymentMethodComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being retrieved</param>
        /// <param name="id">ID of the payment method being retrieved</param>
        public void GetPaymentMethod(int? userId, int? id)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetPaymentMethod");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetPaymentMethod");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/payment-methods/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetPaymentMethodStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetPaymentMethodResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetPaymentMethodStartTime, "GetPaymentMethod", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetPaymentMethodResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetPaymentMethod: " + response.Error);
            }

            GetPaymentMethodData = (PaymentMethodResource) KnetikClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
            KnetikLogger.LogResponse(mGetPaymentMethodStartTime, "GetPaymentMethod", string.Format("Response received successfully:\n{0}", GetPaymentMethodData));

            if (GetPaymentMethodComplete != null)
            {
                GetPaymentMethodComplete(response.ResponseCode, GetPaymentMethodData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single payment method type 
        /// </summary>
        /// <param name="id">ID of the payment method type being retrieved</param>
        public void GetPaymentMethodType(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetPaymentMethodType");
            }
            
            mWebCallEvent.WebPath = "/payment/types/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetPaymentMethodTypeStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetPaymentMethodTypeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetPaymentMethodTypeStartTime, "GetPaymentMethodType", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetPaymentMethodTypeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetPaymentMethodType: " + response.Error);
            }

            GetPaymentMethodTypeData = (PaymentMethodTypeResource) KnetikClient.Deserialize(response.Content, typeof(PaymentMethodTypeResource), response.Headers);
            KnetikLogger.LogResponse(mGetPaymentMethodTypeStartTime, "GetPaymentMethodType", string.Format("Response received successfully:\n{0}", GetPaymentMethodTypeData));

            if (GetPaymentMethodTypeComplete != null)
            {
                GetPaymentMethodTypeComplete(response.ResponseCode, GetPaymentMethodTypeData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get all payment method types 
        /// </summary>
        /// <param name="filterName">Filter for payment method types whose name matches a given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">a comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetPaymentMethodTypes(string filterName, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/payment/types";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterName != null)
            {
                mWebCallEvent.QueryParams["filter_name"] = KnetikClient.ParameterToString(filterName);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (order != null)
            {
                mWebCallEvent.QueryParams["order"] = KnetikClient.ParameterToString(order);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetPaymentMethodTypesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetPaymentMethodTypesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetPaymentMethodTypesStartTime, "GetPaymentMethodTypes", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetPaymentMethodTypesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetPaymentMethodTypes: " + response.Error);
            }

            GetPaymentMethodTypesData = (PageResourcePaymentMethodTypeResource) KnetikClient.Deserialize(response.Content, typeof(PageResourcePaymentMethodTypeResource), response.Headers);
            KnetikLogger.LogResponse(mGetPaymentMethodTypesStartTime, "GetPaymentMethodTypes", string.Format("Response received successfully:\n{0}", GetPaymentMethodTypesData));

            if (GetPaymentMethodTypesComplete != null)
            {
                GetPaymentMethodTypesComplete(response.ResponseCode, GetPaymentMethodTypesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get all payment methods for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment methods are being retrieved</param>
        /// <param name="filterName">Filter for payment methods whose name starts with a given string</param>
        /// <param name="filterPaymentType">Filter for payment methods with a specific payment type</param>
        /// <param name="filterPaymentMethodTypeId">Filter for payment methods with a specific payment method type by id</param>
        /// <param name="filterPaymentMethodTypeName">Filter for payment methods whose payment method type name starts with a given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">a comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetPaymentMethods(int? userId, string filterName, string filterPaymentType, int? filterPaymentMethodTypeId, string filterPaymentMethodTypeName, int? size, int? page, string order)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetPaymentMethods");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/payment-methods";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterName != null)
            {
                mWebCallEvent.QueryParams["filter_name"] = KnetikClient.ParameterToString(filterName);
            }

            if (filterPaymentType != null)
            {
                mWebCallEvent.QueryParams["filter_payment_type"] = KnetikClient.ParameterToString(filterPaymentType);
            }

            if (filterPaymentMethodTypeId != null)
            {
                mWebCallEvent.QueryParams["filter_payment_method_type_id"] = KnetikClient.ParameterToString(filterPaymentMethodTypeId);
            }

            if (filterPaymentMethodTypeName != null)
            {
                mWebCallEvent.QueryParams["filter_payment_method_type_name"] = KnetikClient.ParameterToString(filterPaymentMethodTypeName);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (order != null)
            {
                mWebCallEvent.QueryParams["order"] = KnetikClient.ParameterToString(order);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetPaymentMethodsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetPaymentMethodsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetPaymentMethodsStartTime, "GetPaymentMethods", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetPaymentMethodsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetPaymentMethods: " + response.Error);
            }

            GetPaymentMethodsData = (List<PaymentMethodResource>) KnetikClient.Deserialize(response.Content, typeof(List<PaymentMethodResource>), response.Headers);
            KnetikLogger.LogResponse(mGetPaymentMethodsStartTime, "GetPaymentMethods", string.Format("Response received successfully:\n{0}", GetPaymentMethodsData));

            if (GetPaymentMethodsComplete != null)
            {
                GetPaymentMethodsComplete(response.ResponseCode, GetPaymentMethodsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Authorize payment of an invoice for later capture 
        /// </summary>
        /// <param name="request">Payment authorization request</param>
        public void PaymentAuthorization(PaymentAuthorizationResource request)
        {
            
            mWebCallEvent.WebPath = "/payment/authorizations";
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
            mPaymentAuthorizationStartTime = DateTime.Now;
            mWebCallEvent.Context = mPaymentAuthorizationResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mPaymentAuthorizationStartTime, "PaymentAuthorization", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnPaymentAuthorizationResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling PaymentAuthorization: " + response.Error);
            }

            PaymentAuthorizationData = (PaymentAuthorizationResource) KnetikClient.Deserialize(response.Content, typeof(PaymentAuthorizationResource), response.Headers);
            KnetikLogger.LogResponse(mPaymentAuthorizationStartTime, "PaymentAuthorization", string.Format("Response received successfully:\n{0}", PaymentAuthorizationData));

            if (PaymentAuthorizationComplete != null)
            {
                PaymentAuthorizationComplete(response.ResponseCode, PaymentAuthorizationData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Capture an existing invoice payment authorization 
        /// </summary>
        /// <param name="id">ID of the payment authorization to capture</param>
        public void PaymentCapture(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling PaymentCapture");
            }
            
            mWebCallEvent.WebPath = "/payment/authorizations/{id}/capture";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mPaymentCaptureStartTime = DateTime.Now;
            mWebCallEvent.Context = mPaymentCaptureResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mPaymentCaptureStartTime, "PaymentCapture", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnPaymentCaptureResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling PaymentCapture: " + response.Error);
            }

            KnetikLogger.LogResponse(mPaymentCaptureStartTime, "PaymentCapture", "Response received successfully.");
            if (PaymentCaptureComplete != null)
            {
                PaymentCaptureComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an existing payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being updated</param>
        /// <param name="id">ID of the payment method being updated</param>
        /// <param name="paymentMethod">The updated payment method data</param>
        public void UpdatePaymentMethod(int? userId, int? id, PaymentMethodResource paymentMethod)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling UpdatePaymentMethod");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdatePaymentMethod");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/payment-methods/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(paymentMethod); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdatePaymentMethodStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdatePaymentMethodResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdatePaymentMethodStartTime, "UpdatePaymentMethod", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdatePaymentMethodResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdatePaymentMethod: " + response.Error);
            }

            UpdatePaymentMethodData = (PaymentMethodResource) KnetikClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
            KnetikLogger.LogResponse(mUpdatePaymentMethodStartTime, "UpdatePaymentMethod", string.Format("Response received successfully:\n{0}", UpdatePaymentMethodData));

            if (UpdatePaymentMethodComplete != null)
            {
                UpdatePaymentMethodComplete(response.ResponseCode, UpdatePaymentMethodData);
            }
        }

    }
}
