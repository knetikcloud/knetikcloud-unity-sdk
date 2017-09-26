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
    public interface IPaymentsApi
    {
        PaymentMethodResource CreatePaymentMethodData { get; }

        PaymentMethodResource GetPaymentMethodData { get; }

        PaymentMethodTypeResource GetPaymentMethodTypeData { get; }

        PageResourcePaymentMethodTypeResource GetPaymentMethodTypesData { get; }

        List<PaymentMethodResource> GetPaymentMethodsData { get; }

        PaymentAuthorizationResource PaymentAuthorizationData { get; }

        PaymentMethodResource UpdatePaymentMethodData { get; }

        
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

        /// <summary>
        /// Get a single payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being retrieved</param>
        /// <param name="id">ID of the payment method being retrieved</param>
        void GetPaymentMethod(int? userId, int? id);

        /// <summary>
        /// Get a single payment method type 
        /// </summary>
        /// <param name="id">ID of the payment method type being retrieved</param>
        void GetPaymentMethodType(int? id);

        /// <summary>
        /// Get all payment method types 
        /// </summary>
        /// <param name="filterName">Filter for payment method types whose name matches a given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">a comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetPaymentMethodTypes(string filterName, int? size, int? page, string order);

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
        private readonly KnetikCoroutine mCreatePaymentMethodCoroutine;
        private DateTime mCreatePaymentMethodStartTime;
        private string mCreatePaymentMethodPath;
        private readonly KnetikCoroutine mDeletePaymentMethodCoroutine;
        private DateTime mDeletePaymentMethodStartTime;
        private string mDeletePaymentMethodPath;
        private readonly KnetikCoroutine mGetPaymentMethodCoroutine;
        private DateTime mGetPaymentMethodStartTime;
        private string mGetPaymentMethodPath;
        private readonly KnetikCoroutine mGetPaymentMethodTypeCoroutine;
        private DateTime mGetPaymentMethodTypeStartTime;
        private string mGetPaymentMethodTypePath;
        private readonly KnetikCoroutine mGetPaymentMethodTypesCoroutine;
        private DateTime mGetPaymentMethodTypesStartTime;
        private string mGetPaymentMethodTypesPath;
        private readonly KnetikCoroutine mGetPaymentMethodsCoroutine;
        private DateTime mGetPaymentMethodsStartTime;
        private string mGetPaymentMethodsPath;
        private readonly KnetikCoroutine mPaymentAuthorizationCoroutine;
        private DateTime mPaymentAuthorizationStartTime;
        private string mPaymentAuthorizationPath;
        private readonly KnetikCoroutine mPaymentCaptureCoroutine;
        private DateTime mPaymentCaptureStartTime;
        private string mPaymentCapturePath;
        private readonly KnetikCoroutine mUpdatePaymentMethodCoroutine;
        private DateTime mUpdatePaymentMethodStartTime;
        private string mUpdatePaymentMethodPath;

        public PaymentMethodResource CreatePaymentMethodData { get; private set; }
        public delegate void CreatePaymentMethodCompleteDelegate(PaymentMethodResource response);
        public CreatePaymentMethodCompleteDelegate CreatePaymentMethodComplete;

        public delegate void DeletePaymentMethodCompleteDelegate();
        public DeletePaymentMethodCompleteDelegate DeletePaymentMethodComplete;

        public PaymentMethodResource GetPaymentMethodData { get; private set; }
        public delegate void GetPaymentMethodCompleteDelegate(PaymentMethodResource response);
        public GetPaymentMethodCompleteDelegate GetPaymentMethodComplete;

        public PaymentMethodTypeResource GetPaymentMethodTypeData { get; private set; }
        public delegate void GetPaymentMethodTypeCompleteDelegate(PaymentMethodTypeResource response);
        public GetPaymentMethodTypeCompleteDelegate GetPaymentMethodTypeComplete;

        public PageResourcePaymentMethodTypeResource GetPaymentMethodTypesData { get; private set; }
        public delegate void GetPaymentMethodTypesCompleteDelegate(PageResourcePaymentMethodTypeResource response);
        public GetPaymentMethodTypesCompleteDelegate GetPaymentMethodTypesComplete;

        public List<PaymentMethodResource> GetPaymentMethodsData { get; private set; }
        public delegate void GetPaymentMethodsCompleteDelegate(List<PaymentMethodResource> response);
        public GetPaymentMethodsCompleteDelegate GetPaymentMethodsComplete;

        public PaymentAuthorizationResource PaymentAuthorizationData { get; private set; }
        public delegate void PaymentAuthorizationCompleteDelegate(PaymentAuthorizationResource response);
        public PaymentAuthorizationCompleteDelegate PaymentAuthorizationComplete;

        public delegate void PaymentCaptureCompleteDelegate();
        public PaymentCaptureCompleteDelegate PaymentCaptureComplete;

        public PaymentMethodResource UpdatePaymentMethodData { get; private set; }
        public delegate void UpdatePaymentMethodCompleteDelegate(PaymentMethodResource response);
        public UpdatePaymentMethodCompleteDelegate UpdatePaymentMethodComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsApi()
        {
            mCreatePaymentMethodCoroutine = new KnetikCoroutine();
            mDeletePaymentMethodCoroutine = new KnetikCoroutine();
            mGetPaymentMethodCoroutine = new KnetikCoroutine();
            mGetPaymentMethodTypeCoroutine = new KnetikCoroutine();
            mGetPaymentMethodTypesCoroutine = new KnetikCoroutine();
            mGetPaymentMethodsCoroutine = new KnetikCoroutine();
            mPaymentAuthorizationCoroutine = new KnetikCoroutine();
            mPaymentCaptureCoroutine = new KnetikCoroutine();
            mUpdatePaymentMethodCoroutine = new KnetikCoroutine();
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
            
            mCreatePaymentMethodPath = "/users/{user_id}/payment-methods";
            if (!string.IsNullOrEmpty(mCreatePaymentMethodPath))
            {
                mCreatePaymentMethodPath = mCreatePaymentMethodPath.Replace("{format}", "json");
            }
            mCreatePaymentMethodPath = mCreatePaymentMethodPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(paymentMethod); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreatePaymentMethodStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreatePaymentMethodStartTime, mCreatePaymentMethodPath, "Sending server request...");

            // make the HTTP request
            mCreatePaymentMethodCoroutine.ResponseReceived += CreatePaymentMethodCallback;
            mCreatePaymentMethodCoroutine.Start(mCreatePaymentMethodPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreatePaymentMethodCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreatePaymentMethod: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreatePaymentMethod: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreatePaymentMethodData = (PaymentMethodResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
            KnetikLogger.LogResponse(mCreatePaymentMethodStartTime, mCreatePaymentMethodPath, string.Format("Response received successfully:\n{0}", CreatePaymentMethodData.ToString()));

            if (CreatePaymentMethodComplete != null)
            {
                CreatePaymentMethodComplete(CreatePaymentMethodData);
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
            
            mDeletePaymentMethodPath = "/users/{user_id}/payment-methods/{id}";
            if (!string.IsNullOrEmpty(mDeletePaymentMethodPath))
            {
                mDeletePaymentMethodPath = mDeletePaymentMethodPath.Replace("{format}", "json");
            }
            mDeletePaymentMethodPath = mDeletePaymentMethodPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mDeletePaymentMethodPath = mDeletePaymentMethodPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeletePaymentMethodStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeletePaymentMethodStartTime, mDeletePaymentMethodPath, "Sending server request...");

            // make the HTTP request
            mDeletePaymentMethodCoroutine.ResponseReceived += DeletePaymentMethodCallback;
            mDeletePaymentMethodCoroutine.Start(mDeletePaymentMethodPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeletePaymentMethodCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeletePaymentMethod: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeletePaymentMethod: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeletePaymentMethodStartTime, mDeletePaymentMethodPath, "Response received successfully.");
            if (DeletePaymentMethodComplete != null)
            {
                DeletePaymentMethodComplete();
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
            
            mGetPaymentMethodPath = "/users/{user_id}/payment-methods/{id}";
            if (!string.IsNullOrEmpty(mGetPaymentMethodPath))
            {
                mGetPaymentMethodPath = mGetPaymentMethodPath.Replace("{format}", "json");
            }
            mGetPaymentMethodPath = mGetPaymentMethodPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mGetPaymentMethodPath = mGetPaymentMethodPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetPaymentMethodStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetPaymentMethodStartTime, mGetPaymentMethodPath, "Sending server request...");

            // make the HTTP request
            mGetPaymentMethodCoroutine.ResponseReceived += GetPaymentMethodCallback;
            mGetPaymentMethodCoroutine.Start(mGetPaymentMethodPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetPaymentMethodCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPaymentMethod: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPaymentMethod: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetPaymentMethodData = (PaymentMethodResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
            KnetikLogger.LogResponse(mGetPaymentMethodStartTime, mGetPaymentMethodPath, string.Format("Response received successfully:\n{0}", GetPaymentMethodData.ToString()));

            if (GetPaymentMethodComplete != null)
            {
                GetPaymentMethodComplete(GetPaymentMethodData);
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
            
            mGetPaymentMethodTypePath = "/payment/types/{id}";
            if (!string.IsNullOrEmpty(mGetPaymentMethodTypePath))
            {
                mGetPaymentMethodTypePath = mGetPaymentMethodTypePath.Replace("{format}", "json");
            }
            mGetPaymentMethodTypePath = mGetPaymentMethodTypePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetPaymentMethodTypeStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetPaymentMethodTypeStartTime, mGetPaymentMethodTypePath, "Sending server request...");

            // make the HTTP request
            mGetPaymentMethodTypeCoroutine.ResponseReceived += GetPaymentMethodTypeCallback;
            mGetPaymentMethodTypeCoroutine.Start(mGetPaymentMethodTypePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetPaymentMethodTypeCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPaymentMethodType: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPaymentMethodType: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetPaymentMethodTypeData = (PaymentMethodTypeResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PaymentMethodTypeResource), response.Headers);
            KnetikLogger.LogResponse(mGetPaymentMethodTypeStartTime, mGetPaymentMethodTypePath, string.Format("Response received successfully:\n{0}", GetPaymentMethodTypeData.ToString()));

            if (GetPaymentMethodTypeComplete != null)
            {
                GetPaymentMethodTypeComplete(GetPaymentMethodTypeData);
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
            
            mGetPaymentMethodTypesPath = "/payment/types";
            if (!string.IsNullOrEmpty(mGetPaymentMethodTypesPath))
            {
                mGetPaymentMethodTypesPath = mGetPaymentMethodTypesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.DefaultClient.ParameterToString(filterName));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.DefaultClient.ParameterToString(order));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetPaymentMethodTypesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetPaymentMethodTypesStartTime, mGetPaymentMethodTypesPath, "Sending server request...");

            // make the HTTP request
            mGetPaymentMethodTypesCoroutine.ResponseReceived += GetPaymentMethodTypesCallback;
            mGetPaymentMethodTypesCoroutine.Start(mGetPaymentMethodTypesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetPaymentMethodTypesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPaymentMethodTypes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPaymentMethodTypes: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetPaymentMethodTypesData = (PageResourcePaymentMethodTypeResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourcePaymentMethodTypeResource), response.Headers);
            KnetikLogger.LogResponse(mGetPaymentMethodTypesStartTime, mGetPaymentMethodTypesPath, string.Format("Response received successfully:\n{0}", GetPaymentMethodTypesData.ToString()));

            if (GetPaymentMethodTypesComplete != null)
            {
                GetPaymentMethodTypesComplete(GetPaymentMethodTypesData);
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
            
            mGetPaymentMethodsPath = "/users/{user_id}/payment-methods";
            if (!string.IsNullOrEmpty(mGetPaymentMethodsPath))
            {
                mGetPaymentMethodsPath = mGetPaymentMethodsPath.Replace("{format}", "json");
            }
            mGetPaymentMethodsPath = mGetPaymentMethodsPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.DefaultClient.ParameterToString(filterName));
            }

            if (filterPaymentType != null)
            {
                queryParams.Add("filter_payment_type", KnetikClient.DefaultClient.ParameterToString(filterPaymentType));
            }

            if (filterPaymentMethodTypeId != null)
            {
                queryParams.Add("filter_payment_method_type_id", KnetikClient.DefaultClient.ParameterToString(filterPaymentMethodTypeId));
            }

            if (filterPaymentMethodTypeName != null)
            {
                queryParams.Add("filter_payment_method_type_name", KnetikClient.DefaultClient.ParameterToString(filterPaymentMethodTypeName));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.DefaultClient.ParameterToString(order));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetPaymentMethodsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetPaymentMethodsStartTime, mGetPaymentMethodsPath, "Sending server request...");

            // make the HTTP request
            mGetPaymentMethodsCoroutine.ResponseReceived += GetPaymentMethodsCallback;
            mGetPaymentMethodsCoroutine.Start(mGetPaymentMethodsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetPaymentMethodsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPaymentMethods: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPaymentMethods: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetPaymentMethodsData = (List<PaymentMethodResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<PaymentMethodResource>), response.Headers);
            KnetikLogger.LogResponse(mGetPaymentMethodsStartTime, mGetPaymentMethodsPath, string.Format("Response received successfully:\n{0}", GetPaymentMethodsData.ToString()));

            if (GetPaymentMethodsComplete != null)
            {
                GetPaymentMethodsComplete(GetPaymentMethodsData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Authorize payment of an invoice for later capture 
        /// </summary>
        /// <param name="request">Payment authorization request</param>
        public void PaymentAuthorization(PaymentAuthorizationResource request)
        {
            
            mPaymentAuthorizationPath = "/payment/authorizations";
            if (!string.IsNullOrEmpty(mPaymentAuthorizationPath))
            {
                mPaymentAuthorizationPath = mPaymentAuthorizationPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mPaymentAuthorizationStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mPaymentAuthorizationStartTime, mPaymentAuthorizationPath, "Sending server request...");

            // make the HTTP request
            mPaymentAuthorizationCoroutine.ResponseReceived += PaymentAuthorizationCallback;
            mPaymentAuthorizationCoroutine.Start(mPaymentAuthorizationPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void PaymentAuthorizationCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling PaymentAuthorization: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling PaymentAuthorization: " + response.ErrorMessage, response.ErrorMessage);
            }

            PaymentAuthorizationData = (PaymentAuthorizationResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PaymentAuthorizationResource), response.Headers);
            KnetikLogger.LogResponse(mPaymentAuthorizationStartTime, mPaymentAuthorizationPath, string.Format("Response received successfully:\n{0}", PaymentAuthorizationData.ToString()));

            if (PaymentAuthorizationComplete != null)
            {
                PaymentAuthorizationComplete(PaymentAuthorizationData);
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
            
            mPaymentCapturePath = "/payment/authorizations/{id}/capture";
            if (!string.IsNullOrEmpty(mPaymentCapturePath))
            {
                mPaymentCapturePath = mPaymentCapturePath.Replace("{format}", "json");
            }
            mPaymentCapturePath = mPaymentCapturePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mPaymentCaptureStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mPaymentCaptureStartTime, mPaymentCapturePath, "Sending server request...");

            // make the HTTP request
            mPaymentCaptureCoroutine.ResponseReceived += PaymentCaptureCallback;
            mPaymentCaptureCoroutine.Start(mPaymentCapturePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void PaymentCaptureCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling PaymentCapture: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling PaymentCapture: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mPaymentCaptureStartTime, mPaymentCapturePath, "Response received successfully.");
            if (PaymentCaptureComplete != null)
            {
                PaymentCaptureComplete();
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
            
            mUpdatePaymentMethodPath = "/users/{user_id}/payment-methods/{id}";
            if (!string.IsNullOrEmpty(mUpdatePaymentMethodPath))
            {
                mUpdatePaymentMethodPath = mUpdatePaymentMethodPath.Replace("{format}", "json");
            }
            mUpdatePaymentMethodPath = mUpdatePaymentMethodPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mUpdatePaymentMethodPath = mUpdatePaymentMethodPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(paymentMethod); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdatePaymentMethodStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdatePaymentMethodStartTime, mUpdatePaymentMethodPath, "Sending server request...");

            // make the HTTP request
            mUpdatePaymentMethodCoroutine.ResponseReceived += UpdatePaymentMethodCallback;
            mUpdatePaymentMethodCoroutine.Start(mUpdatePaymentMethodPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdatePaymentMethodCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdatePaymentMethod: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdatePaymentMethod: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdatePaymentMethodData = (PaymentMethodResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
            KnetikLogger.LogResponse(mUpdatePaymentMethodStartTime, mUpdatePaymentMethodPath, string.Format("Response received successfully:\n{0}", UpdatePaymentMethodData.ToString()));

            if (UpdatePaymentMethodComplete != null)
            {
                UpdatePaymentMethodComplete(UpdatePaymentMethodData);
            }
        }
    }
}
