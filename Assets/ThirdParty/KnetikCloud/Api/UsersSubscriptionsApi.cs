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
    public interface IUsersSubscriptionsApi
    {
        InventorySubscriptionResource GetUserSubscriptionDetailsData { get; }

        List<InventorySubscriptionResource> GetUsersSubscriptionDetailsData { get; }

        InvoiceResource ReactivateUserSubscriptionData { get; }

        
        /// <summary>
        /// Get details about a user&#39;s subscription 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        void GetUserSubscriptionDetails(int? userId, int? inventoryId);

        /// <summary>
        /// Get details about a user&#39;s subscriptions 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        void GetUsersSubscriptionDetails(int? userId);

        /// <summary>
        /// Reactivate a subscription and charge fee 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="reactivateSubscriptionRequest">The reactivate subscription request object inventory</param>
        void ReactivateUserSubscription(int? userId, int? inventoryId, ReactivateSubscriptionRequest reactivateSubscriptionRequest);

        /// <summary>
        /// Set a new date to bill a subscription on 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="billDate">The new bill date. Unix timestamp in seconds</param>
        void SetSubscriptionBillDate(int? userId, int? inventoryId, long? billDate);

        /// <summary>
        /// Set the payment method to use for a subscription May send null to use floating default
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="paymentMethodId">The id of the payment method</param>
        void SetSubscriptionPaymentMethod(int? userId, int? inventoryId, IntWrapper paymentMethodId);

        /// <summary>
        /// Set the status of a subscription Note that the new status may be blocked if the system is not configured to allow the current status to be changed to the new, to enforce proper flow. The default options for statuses are shown below but may be altered for special use cases
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="status">The new status for the subscription. Actual options may differ from the indicated set if the invoice status type data has been altered.  Allowable values: (&#39;current&#39;, &#39;canceled&#39;, &#39;stopped&#39;, &#39;payment_failed&#39;, &#39;suspended&#39;)</param>
        void SetSubscriptionStatus(int? userId, int? inventoryId, StringWrapper status);

        /// <summary>
        /// Set a new subscription plan for a user 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="planId">The id of the new plan. Must be from the same subscription</param>
        void SetUserSubscriptionPlan(int? userId, int? inventoryId, StringWrapper planId);

        /// <summary>
        /// Set a new subscription price for a user This new price will be what the user is charged at the begining of each new period. This override is specific to the current subscription and will not carry over if they end and later re-subscribe. It will persist if the plan is changed using the setUserSubscriptionPlan endpoint.
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="theOverrideDetails">override</param>
        void SetUserSubscriptionPrice(int? userId, int? inventoryId, SubscriptionPriceOverrideRequest theOverrideDetails);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UsersSubscriptionsApi : IUsersSubscriptionsApi
    {
        private readonly KnetikCoroutine mGetUserSubscriptionDetailsCoroutine;
        private DateTime mGetUserSubscriptionDetailsStartTime;
        private string mGetUserSubscriptionDetailsPath;
        private readonly KnetikCoroutine mGetUsersSubscriptionDetailsCoroutine;
        private DateTime mGetUsersSubscriptionDetailsStartTime;
        private string mGetUsersSubscriptionDetailsPath;
        private readonly KnetikCoroutine mReactivateUserSubscriptionCoroutine;
        private DateTime mReactivateUserSubscriptionStartTime;
        private string mReactivateUserSubscriptionPath;
        private readonly KnetikCoroutine mSetSubscriptionBillDateCoroutine;
        private DateTime mSetSubscriptionBillDateStartTime;
        private string mSetSubscriptionBillDatePath;
        private readonly KnetikCoroutine mSetSubscriptionPaymentMethodCoroutine;
        private DateTime mSetSubscriptionPaymentMethodStartTime;
        private string mSetSubscriptionPaymentMethodPath;
        private readonly KnetikCoroutine mSetSubscriptionStatusCoroutine;
        private DateTime mSetSubscriptionStatusStartTime;
        private string mSetSubscriptionStatusPath;
        private readonly KnetikCoroutine mSetUserSubscriptionPlanCoroutine;
        private DateTime mSetUserSubscriptionPlanStartTime;
        private string mSetUserSubscriptionPlanPath;
        private readonly KnetikCoroutine mSetUserSubscriptionPriceCoroutine;
        private DateTime mSetUserSubscriptionPriceStartTime;
        private string mSetUserSubscriptionPricePath;

        public InventorySubscriptionResource GetUserSubscriptionDetailsData { get; private set; }
        public delegate void GetUserSubscriptionDetailsCompleteDelegate(InventorySubscriptionResource response);
        public GetUserSubscriptionDetailsCompleteDelegate GetUserSubscriptionDetailsComplete;

        public List<InventorySubscriptionResource> GetUsersSubscriptionDetailsData { get; private set; }
        public delegate void GetUsersSubscriptionDetailsCompleteDelegate(List<InventorySubscriptionResource> response);
        public GetUsersSubscriptionDetailsCompleteDelegate GetUsersSubscriptionDetailsComplete;

        public InvoiceResource ReactivateUserSubscriptionData { get; private set; }
        public delegate void ReactivateUserSubscriptionCompleteDelegate(InvoiceResource response);
        public ReactivateUserSubscriptionCompleteDelegate ReactivateUserSubscriptionComplete;

        public delegate void SetSubscriptionBillDateCompleteDelegate();
        public SetSubscriptionBillDateCompleteDelegate SetSubscriptionBillDateComplete;

        public delegate void SetSubscriptionPaymentMethodCompleteDelegate();
        public SetSubscriptionPaymentMethodCompleteDelegate SetSubscriptionPaymentMethodComplete;

        public delegate void SetSubscriptionStatusCompleteDelegate();
        public SetSubscriptionStatusCompleteDelegate SetSubscriptionStatusComplete;

        public delegate void SetUserSubscriptionPlanCompleteDelegate();
        public SetUserSubscriptionPlanCompleteDelegate SetUserSubscriptionPlanComplete;

        public delegate void SetUserSubscriptionPriceCompleteDelegate();
        public SetUserSubscriptionPriceCompleteDelegate SetUserSubscriptionPriceComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersSubscriptionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersSubscriptionsApi()
        {
            mGetUserSubscriptionDetailsCoroutine = new KnetikCoroutine();
            mGetUsersSubscriptionDetailsCoroutine = new KnetikCoroutine();
            mReactivateUserSubscriptionCoroutine = new KnetikCoroutine();
            mSetSubscriptionBillDateCoroutine = new KnetikCoroutine();
            mSetSubscriptionPaymentMethodCoroutine = new KnetikCoroutine();
            mSetSubscriptionStatusCoroutine = new KnetikCoroutine();
            mSetUserSubscriptionPlanCoroutine = new KnetikCoroutine();
            mSetUserSubscriptionPriceCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get details about a user&#39;s subscription 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        public void GetUserSubscriptionDetails(int? userId, int? inventoryId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserSubscriptionDetails");
            }
            // verify the required parameter 'inventoryId' is set
            if (inventoryId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'inventoryId' when calling GetUserSubscriptionDetails");
            }
            
            mGetUserSubscriptionDetailsPath = "/users/{user_id}/subscriptions/{inventory_id}";
            if (!string.IsNullOrEmpty(mGetUserSubscriptionDetailsPath))
            {
                mGetUserSubscriptionDetailsPath = mGetUserSubscriptionDetailsPath.Replace("{format}", "json");
            }
            mGetUserSubscriptionDetailsPath = mGetUserSubscriptionDetailsPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mGetUserSubscriptionDetailsPath = mGetUserSubscriptionDetailsPath.Replace("{" + "inventory_id" + "}", KnetikClient.DefaultClient.ParameterToString(inventoryId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserSubscriptionDetailsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserSubscriptionDetailsStartTime, mGetUserSubscriptionDetailsPath, "Sending server request...");

            // make the HTTP request
            mGetUserSubscriptionDetailsCoroutine.ResponseReceived += GetUserSubscriptionDetailsCallback;
            mGetUserSubscriptionDetailsCoroutine.Start(mGetUserSubscriptionDetailsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserSubscriptionDetailsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserSubscriptionDetails: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserSubscriptionDetails: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserSubscriptionDetailsData = (InventorySubscriptionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(InventorySubscriptionResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserSubscriptionDetailsStartTime, mGetUserSubscriptionDetailsPath, string.Format("Response received successfully:\n{0}", GetUserSubscriptionDetailsData.ToString()));

            if (GetUserSubscriptionDetailsComplete != null)
            {
                GetUserSubscriptionDetailsComplete(GetUserSubscriptionDetailsData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Get details about a user&#39;s subscriptions 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        public void GetUsersSubscriptionDetails(int? userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUsersSubscriptionDetails");
            }
            
            mGetUsersSubscriptionDetailsPath = "/users/{user_id}/subscriptions";
            if (!string.IsNullOrEmpty(mGetUsersSubscriptionDetailsPath))
            {
                mGetUsersSubscriptionDetailsPath = mGetUsersSubscriptionDetailsPath.Replace("{format}", "json");
            }
            mGetUsersSubscriptionDetailsPath = mGetUsersSubscriptionDetailsPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUsersSubscriptionDetailsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUsersSubscriptionDetailsStartTime, mGetUsersSubscriptionDetailsPath, "Sending server request...");

            // make the HTTP request
            mGetUsersSubscriptionDetailsCoroutine.ResponseReceived += GetUsersSubscriptionDetailsCallback;
            mGetUsersSubscriptionDetailsCoroutine.Start(mGetUsersSubscriptionDetailsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUsersSubscriptionDetailsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsersSubscriptionDetails: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsersSubscriptionDetails: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUsersSubscriptionDetailsData = (List<InventorySubscriptionResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<InventorySubscriptionResource>), response.Headers);
            KnetikLogger.LogResponse(mGetUsersSubscriptionDetailsStartTime, mGetUsersSubscriptionDetailsPath, string.Format("Response received successfully:\n{0}", GetUsersSubscriptionDetailsData.ToString()));

            if (GetUsersSubscriptionDetailsComplete != null)
            {
                GetUsersSubscriptionDetailsComplete(GetUsersSubscriptionDetailsData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Reactivate a subscription and charge fee 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="reactivateSubscriptionRequest">The reactivate subscription request object inventory</param>
        public void ReactivateUserSubscription(int? userId, int? inventoryId, ReactivateSubscriptionRequest reactivateSubscriptionRequest)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling ReactivateUserSubscription");
            }
            // verify the required parameter 'inventoryId' is set
            if (inventoryId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'inventoryId' when calling ReactivateUserSubscription");
            }
            
            mReactivateUserSubscriptionPath = "/users/{user_id}/subscriptions/{inventory_id}/reactivate";
            if (!string.IsNullOrEmpty(mReactivateUserSubscriptionPath))
            {
                mReactivateUserSubscriptionPath = mReactivateUserSubscriptionPath.Replace("{format}", "json");
            }
            mReactivateUserSubscriptionPath = mReactivateUserSubscriptionPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mReactivateUserSubscriptionPath = mReactivateUserSubscriptionPath.Replace("{" + "inventory_id" + "}", KnetikClient.DefaultClient.ParameterToString(inventoryId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(reactivateSubscriptionRequest); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mReactivateUserSubscriptionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mReactivateUserSubscriptionStartTime, mReactivateUserSubscriptionPath, "Sending server request...");

            // make the HTTP request
            mReactivateUserSubscriptionCoroutine.ResponseReceived += ReactivateUserSubscriptionCallback;
            mReactivateUserSubscriptionCoroutine.Start(mReactivateUserSubscriptionPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void ReactivateUserSubscriptionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling ReactivateUserSubscription: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling ReactivateUserSubscription: " + response.ErrorMessage, response.ErrorMessage);
            }

            ReactivateUserSubscriptionData = (InvoiceResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(InvoiceResource), response.Headers);
            KnetikLogger.LogResponse(mReactivateUserSubscriptionStartTime, mReactivateUserSubscriptionPath, string.Format("Response received successfully:\n{0}", ReactivateUserSubscriptionData.ToString()));

            if (ReactivateUserSubscriptionComplete != null)
            {
                ReactivateUserSubscriptionComplete(ReactivateUserSubscriptionData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Set a new date to bill a subscription on 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="billDate">The new bill date. Unix timestamp in seconds</param>
        public void SetSubscriptionBillDate(int? userId, int? inventoryId, long? billDate)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling SetSubscriptionBillDate");
            }
            // verify the required parameter 'inventoryId' is set
            if (inventoryId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'inventoryId' when calling SetSubscriptionBillDate");
            }
            // verify the required parameter 'billDate' is set
            if (billDate == null)
            {
                throw new KnetikException(400, "Missing required parameter 'billDate' when calling SetSubscriptionBillDate");
            }
            
            mSetSubscriptionBillDatePath = "/users/{user_id}/subscriptions/{inventory_id}/bill-date";
            if (!string.IsNullOrEmpty(mSetSubscriptionBillDatePath))
            {
                mSetSubscriptionBillDatePath = mSetSubscriptionBillDatePath.Replace("{format}", "json");
            }
            mSetSubscriptionBillDatePath = mSetSubscriptionBillDatePath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mSetSubscriptionBillDatePath = mSetSubscriptionBillDatePath.Replace("{" + "inventory_id" + "}", KnetikClient.DefaultClient.ParameterToString(inventoryId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(billDate); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetSubscriptionBillDateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetSubscriptionBillDateStartTime, mSetSubscriptionBillDatePath, "Sending server request...");

            // make the HTTP request
            mSetSubscriptionBillDateCoroutine.ResponseReceived += SetSubscriptionBillDateCallback;
            mSetSubscriptionBillDateCoroutine.Start(mSetSubscriptionBillDatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetSubscriptionBillDateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetSubscriptionBillDate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetSubscriptionBillDate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetSubscriptionBillDateStartTime, mSetSubscriptionBillDatePath, "Response received successfully.");
            if (SetSubscriptionBillDateComplete != null)
            {
                SetSubscriptionBillDateComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Set the payment method to use for a subscription May send null to use floating default
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="paymentMethodId">The id of the payment method</param>
        public void SetSubscriptionPaymentMethod(int? userId, int? inventoryId, IntWrapper paymentMethodId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling SetSubscriptionPaymentMethod");
            }
            // verify the required parameter 'inventoryId' is set
            if (inventoryId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'inventoryId' when calling SetSubscriptionPaymentMethod");
            }
            
            mSetSubscriptionPaymentMethodPath = "/users/{user_id}/subscriptions/{inventory_id}/payment-method";
            if (!string.IsNullOrEmpty(mSetSubscriptionPaymentMethodPath))
            {
                mSetSubscriptionPaymentMethodPath = mSetSubscriptionPaymentMethodPath.Replace("{format}", "json");
            }
            mSetSubscriptionPaymentMethodPath = mSetSubscriptionPaymentMethodPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mSetSubscriptionPaymentMethodPath = mSetSubscriptionPaymentMethodPath.Replace("{" + "inventory_id" + "}", KnetikClient.DefaultClient.ParameterToString(inventoryId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(paymentMethodId); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetSubscriptionPaymentMethodStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetSubscriptionPaymentMethodStartTime, mSetSubscriptionPaymentMethodPath, "Sending server request...");

            // make the HTTP request
            mSetSubscriptionPaymentMethodCoroutine.ResponseReceived += SetSubscriptionPaymentMethodCallback;
            mSetSubscriptionPaymentMethodCoroutine.Start(mSetSubscriptionPaymentMethodPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetSubscriptionPaymentMethodCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetSubscriptionPaymentMethod: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetSubscriptionPaymentMethod: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetSubscriptionPaymentMethodStartTime, mSetSubscriptionPaymentMethodPath, "Response received successfully.");
            if (SetSubscriptionPaymentMethodComplete != null)
            {
                SetSubscriptionPaymentMethodComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Set the status of a subscription Note that the new status may be blocked if the system is not configured to allow the current status to be changed to the new, to enforce proper flow. The default options for statuses are shown below but may be altered for special use cases
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="status">The new status for the subscription. Actual options may differ from the indicated set if the invoice status type data has been altered.  Allowable values: (&#39;current&#39;, &#39;canceled&#39;, &#39;stopped&#39;, &#39;payment_failed&#39;, &#39;suspended&#39;)</param>
        public void SetSubscriptionStatus(int? userId, int? inventoryId, StringWrapper status)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling SetSubscriptionStatus");
            }
            // verify the required parameter 'inventoryId' is set
            if (inventoryId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'inventoryId' when calling SetSubscriptionStatus");
            }
            // verify the required parameter 'status' is set
            if (status == null)
            {
                throw new KnetikException(400, "Missing required parameter 'status' when calling SetSubscriptionStatus");
            }
            
            mSetSubscriptionStatusPath = "/users/{user_id}/subscriptions/{inventory_id}/status";
            if (!string.IsNullOrEmpty(mSetSubscriptionStatusPath))
            {
                mSetSubscriptionStatusPath = mSetSubscriptionStatusPath.Replace("{format}", "json");
            }
            mSetSubscriptionStatusPath = mSetSubscriptionStatusPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mSetSubscriptionStatusPath = mSetSubscriptionStatusPath.Replace("{" + "inventory_id" + "}", KnetikClient.DefaultClient.ParameterToString(inventoryId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(status); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetSubscriptionStatusStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetSubscriptionStatusStartTime, mSetSubscriptionStatusPath, "Sending server request...");

            // make the HTTP request
            mSetSubscriptionStatusCoroutine.ResponseReceived += SetSubscriptionStatusCallback;
            mSetSubscriptionStatusCoroutine.Start(mSetSubscriptionStatusPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetSubscriptionStatusCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetSubscriptionStatus: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetSubscriptionStatus: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetSubscriptionStatusStartTime, mSetSubscriptionStatusPath, "Response received successfully.");
            if (SetSubscriptionStatusComplete != null)
            {
                SetSubscriptionStatusComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Set a new subscription plan for a user 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="planId">The id of the new plan. Must be from the same subscription</param>
        public void SetUserSubscriptionPlan(int? userId, int? inventoryId, StringWrapper planId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling SetUserSubscriptionPlan");
            }
            // verify the required parameter 'inventoryId' is set
            if (inventoryId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'inventoryId' when calling SetUserSubscriptionPlan");
            }
            
            mSetUserSubscriptionPlanPath = "/users/{user_id}/subscriptions/{inventory_id}/plan";
            if (!string.IsNullOrEmpty(mSetUserSubscriptionPlanPath))
            {
                mSetUserSubscriptionPlanPath = mSetUserSubscriptionPlanPath.Replace("{format}", "json");
            }
            mSetUserSubscriptionPlanPath = mSetUserSubscriptionPlanPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mSetUserSubscriptionPlanPath = mSetUserSubscriptionPlanPath.Replace("{" + "inventory_id" + "}", KnetikClient.DefaultClient.ParameterToString(inventoryId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(planId); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetUserSubscriptionPlanStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetUserSubscriptionPlanStartTime, mSetUserSubscriptionPlanPath, "Sending server request...");

            // make the HTTP request
            mSetUserSubscriptionPlanCoroutine.ResponseReceived += SetUserSubscriptionPlanCallback;
            mSetUserSubscriptionPlanCoroutine.Start(mSetUserSubscriptionPlanPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetUserSubscriptionPlanCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetUserSubscriptionPlan: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetUserSubscriptionPlan: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetUserSubscriptionPlanStartTime, mSetUserSubscriptionPlanPath, "Response received successfully.");
            if (SetUserSubscriptionPlanComplete != null)
            {
                SetUserSubscriptionPlanComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Set a new subscription price for a user This new price will be what the user is charged at the begining of each new period. This override is specific to the current subscription and will not carry over if they end and later re-subscribe. It will persist if the plan is changed using the setUserSubscriptionPlan endpoint.
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="theOverrideDetails">override</param>
        public void SetUserSubscriptionPrice(int? userId, int? inventoryId, SubscriptionPriceOverrideRequest theOverrideDetails)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling SetUserSubscriptionPrice");
            }
            // verify the required parameter 'inventoryId' is set
            if (inventoryId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'inventoryId' when calling SetUserSubscriptionPrice");
            }
            
            mSetUserSubscriptionPricePath = "/users/{user_id}/subscriptions/{inventory_id}/price-override";
            if (!string.IsNullOrEmpty(mSetUserSubscriptionPricePath))
            {
                mSetUserSubscriptionPricePath = mSetUserSubscriptionPricePath.Replace("{format}", "json");
            }
            mSetUserSubscriptionPricePath = mSetUserSubscriptionPricePath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mSetUserSubscriptionPricePath = mSetUserSubscriptionPricePath.Replace("{" + "inventory_id" + "}", KnetikClient.DefaultClient.ParameterToString(inventoryId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(theOverrideDetails); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetUserSubscriptionPriceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetUserSubscriptionPriceStartTime, mSetUserSubscriptionPricePath, "Sending server request...");

            // make the HTTP request
            mSetUserSubscriptionPriceCoroutine.ResponseReceived += SetUserSubscriptionPriceCallback;
            mSetUserSubscriptionPriceCoroutine.Start(mSetUserSubscriptionPricePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetUserSubscriptionPriceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetUserSubscriptionPrice: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetUserSubscriptionPrice: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetUserSubscriptionPriceStartTime, mSetUserSubscriptionPricePath, "Response received successfully.");
            if (SetUserSubscriptionPriceComplete != null)
            {
                SetUserSubscriptionPriceComplete();
            }
        }
    }
}
