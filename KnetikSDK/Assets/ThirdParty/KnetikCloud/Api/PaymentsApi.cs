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
    public interface IPaymentsApi
    {
        /// <summary>
        /// Create a new payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being created</param>
        /// <param name="paymentMethod">Payment method being created</param>
        /// <returns>PaymentMethodResource</returns>
        PaymentMethodResource CreatePaymentMethod (int? userId, PaymentMethodResource paymentMethod);
        /// <summary>
        /// Delete an existing payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being updated</param>
        /// <param name="id">ID of the payment method being deleted</param>
        /// <returns></returns>
        void DeletePaymentMethod (int? userId, int? id);
        /// <summary>
        /// Get a single payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being retrieved</param>
        /// <param name="id">ID of the payment method being retrieved</param>
        /// <returns>PaymentMethodResource</returns>
        PaymentMethodResource GetPaymentMethod (int? userId, int? id);
        /// <summary>
        /// Get a single payment method type 
        /// </summary>
        /// <param name="id">ID of the payment method type being retrieved</param>
        /// <returns>PaymentMethodTypeResource</returns>
        PaymentMethodTypeResource GetPaymentMethodType (int? id);
        /// <summary>
        /// Get all payment method types 
        /// </summary>
        /// <param name="filterName">Filter for payment method types whose name matches a given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">a comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourcePaymentMethodTypeResource</returns>
        PageResourcePaymentMethodTypeResource GetPaymentMethodTypes (string filterName, int? size, int? page, string order);
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
        /// <returns>List&lt;PaymentMethodResource&gt;</returns>
        List<PaymentMethodResource> GetPaymentMethods (int? userId, string filterName, string filterPaymentType, int? filterPaymentMethodTypeId, string filterPaymentMethodTypeName, int? size, int? page, string order);
        /// <summary>
        /// Authorize payment of an invoice for later capture 
        /// </summary>
        /// <param name="request">Payment authorization request</param>
        /// <returns>PaymentAuthorizationResource</returns>
        PaymentAuthorizationResource PaymentAuthorization (PaymentAuthorizationResource request);
        /// <summary>
        /// Capture an existing invoice payment authorization 
        /// </summary>
        /// <param name="id">ID of the payment authorization to capture</param>
        /// <returns></returns>
        void PaymentCapture (int? id);
        /// <summary>
        /// Update an existing payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being updated</param>
        /// <param name="id">ID of the payment method being updated</param>
        /// <param name="paymentMethod">The updated payment method data</param>
        /// <returns>PaymentMethodResource</returns>
        PaymentMethodResource UpdatePaymentMethod (int? userId, int? id, PaymentMethodResource paymentMethod);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsApi : IPaymentsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a new payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being created</param> 
        /// <param name="paymentMethod">Payment method being created</param> 
        /// <returns>PaymentMethodResource</returns>            
        public PaymentMethodResource CreatePaymentMethod(int? userId, PaymentMethodResource paymentMethod)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling CreatePaymentMethod");
            }
            
            
            string urlPath = "/users/{user_id}/payment-methods";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(paymentMethod); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreatePaymentMethod: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreatePaymentMethod: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PaymentMethodResource) KnetikClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
        }
        /// <summary>
        /// Delete an existing payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being updated</param> 
        /// <param name="id">ID of the payment method being deleted</param> 
        /// <returns></returns>            
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
            
            
            string urlPath = "/users/{user_id}/payment-methods/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeletePaymentMethod: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeletePaymentMethod: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get a single payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being retrieved</param> 
        /// <param name="id">ID of the payment method being retrieved</param> 
        /// <returns>PaymentMethodResource</returns>            
        public PaymentMethodResource GetPaymentMethod(int? userId, int? id)
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
            
            
            string urlPath = "/users/{user_id}/payment-methods/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPaymentMethod: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPaymentMethod: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PaymentMethodResource) KnetikClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
        }
        /// <summary>
        /// Get a single payment method type 
        /// </summary>
        /// <param name="id">ID of the payment method type being retrieved</param> 
        /// <returns>PaymentMethodTypeResource</returns>            
        public PaymentMethodTypeResource GetPaymentMethodType(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetPaymentMethodType");
            }
            
            
            string urlPath = "/payment/types/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPaymentMethodType: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPaymentMethodType: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PaymentMethodTypeResource) KnetikClient.Deserialize(response.Content, typeof(PaymentMethodTypeResource), response.Headers);
        }
        /// <summary>
        /// Get all payment method types 
        /// </summary>
        /// <param name="filterName">Filter for payment method types whose name matches a given string</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">a comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourcePaymentMethodTypeResource</returns>            
        public PageResourcePaymentMethodTypeResource GetPaymentMethodTypes(string filterName, int? size, int? page, string order)
        {
            
            string urlPath = "/payment/types";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.ParameterToString(filterName));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPaymentMethodTypes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPaymentMethodTypes: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourcePaymentMethodTypeResource) KnetikClient.Deserialize(response.Content, typeof(PageResourcePaymentMethodTypeResource), response.Headers);
        }
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
        /// <returns>List&lt;PaymentMethodResource&gt;</returns>            
        public List<PaymentMethodResource> GetPaymentMethods(int? userId, string filterName, string filterPaymentType, int? filterPaymentMethodTypeId, string filterPaymentMethodTypeName, int? size, int? page, string order)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetPaymentMethods");
            }
            
            
            string urlPath = "/users/{user_id}/payment-methods";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.ParameterToString(filterName));
            }
            
            if (filterPaymentType != null)
            {
                queryParams.Add("filter_payment_type", KnetikClient.ParameterToString(filterPaymentType));
            }
            
            if (filterPaymentMethodTypeId != null)
            {
                queryParams.Add("filter_payment_method_type_id", KnetikClient.ParameterToString(filterPaymentMethodTypeId));
            }
            
            if (filterPaymentMethodTypeName != null)
            {
                queryParams.Add("filter_payment_method_type_name", KnetikClient.ParameterToString(filterPaymentMethodTypeName));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPaymentMethods: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPaymentMethods: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<PaymentMethodResource>) KnetikClient.Deserialize(response.Content, typeof(List<PaymentMethodResource>), response.Headers);
        }
        /// <summary>
        /// Authorize payment of an invoice for later capture 
        /// </summary>
        /// <param name="request">Payment authorization request</param> 
        /// <returns>PaymentAuthorizationResource</returns>            
        public PaymentAuthorizationResource PaymentAuthorization(PaymentAuthorizationResource request)
        {
            
            string urlPath = "/payment/authorizations";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling PaymentAuthorization: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling PaymentAuthorization: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PaymentAuthorizationResource) KnetikClient.Deserialize(response.Content, typeof(PaymentAuthorizationResource), response.Headers);
        }
        /// <summary>
        /// Capture an existing invoice payment authorization 
        /// </summary>
        /// <param name="id">ID of the payment authorization to capture</param> 
        /// <returns></returns>            
        public void PaymentCapture(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling PaymentCapture");
            }
            
            
            string urlPath = "/payment/authorizations/{id}/capture";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling PaymentCapture: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling PaymentCapture: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Update an existing payment method for a user 
        /// </summary>
        /// <param name="userId">ID of the user for whom the payment method is being updated</param> 
        /// <param name="id">ID of the payment method being updated</param> 
        /// <param name="paymentMethod">The updated payment method data</param> 
        /// <returns>PaymentMethodResource</returns>            
        public PaymentMethodResource UpdatePaymentMethod(int? userId, int? id, PaymentMethodResource paymentMethod)
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
            
            
            string urlPath = "/users/{user_id}/payment-methods/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(paymentMethod); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdatePaymentMethod: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdatePaymentMethod: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PaymentMethodResource) KnetikClient.Deserialize(response.Content, typeof(PaymentMethodResource), response.Headers);
        }
    }
}
