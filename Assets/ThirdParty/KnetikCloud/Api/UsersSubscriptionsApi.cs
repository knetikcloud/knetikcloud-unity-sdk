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
    public interface IUsersSubscriptionsApi
    {
        InventorySubscriptionResource GetUserSubscriptionDetailsData { get; }

        /// <summary>
        /// Get details about a user&#39;s subscription &lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN or owner
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        void GetUserSubscriptionDetails(int? userId, int? inventoryId);

        List<InventorySubscriptionResource> GetUsersSubscriptionDetailsData { get; }

        /// <summary>
        /// Get details about a user&#39;s subscriptions &lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN or owner
        /// </summary>
        /// <param name="userId">The id of the user</param>
        void GetUsersSubscriptionDetails(int? userId);

        InvoiceResource ReactivateUserSubscriptionData { get; }

        /// <summary>
        /// Reactivate a subscription and charge fee &lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="reactivateSubscriptionRequest">The reactivate subscription request object inventory</param>
        void ReactivateUserSubscription(int? userId, int? inventoryId, ReactivateSubscriptionRequest reactivateSubscriptionRequest);

        

        /// <summary>
        /// Set a new date to bill a subscription on &lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="billDate">The new bill date. Unix timestamp in seconds</param>
        void SetSubscriptionBillDate(int? userId, int? inventoryId, long? billDate);

        

        /// <summary>
        /// Set the payment method to use for a subscription May send null to use floating default. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN or owner
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="paymentMethodId">The id of the payment method</param>
        void SetSubscriptionPaymentMethod(int? userId, int? inventoryId, IntWrapper paymentMethodId);

        

        /// <summary>
        /// Set the status of a subscription Note that the new status may be blocked if the system is not configured to allow the current status to be changed to the new, to enforce proper flow. The default options for statuses are shown below but may be altered for special use cases. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN or owner
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="status">The new status for the subscription. Actual options may differ from the indicated set if the invoice status type data has been altered.  Allowable values: (&#39;current&#39;, &#39;canceled&#39;, &#39;stopped&#39;, &#39;payment_failed&#39;, &#39;suspended&#39;)</param>
        void SetSubscriptionStatus(int? userId, int? inventoryId, StringWrapper status);

        

        /// <summary>
        /// Set a new subscription plan for a user &lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="inventoryId">The id of the user&#39;s inventory</param>
        /// <param name="planId">The id of the new plan. Must be from the same subscription</param>
        void SetUserSubscriptionPlan(int? userId, int? inventoryId, StringWrapper planId);

        

        /// <summary>
        /// Set a new subscription price for a user This new price will be what the user is charged at the begining of each new period. This override is specific to the current subscription and will not carry over if they end and later re-subscribe. It will persist if the plan is changed using the setUserSubscriptionPlan endpoint. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN
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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetUserSubscriptionDetailsResponseContext;
        private DateTime mGetUserSubscriptionDetailsStartTime;
        private readonly KnetikResponseContext mGetUsersSubscriptionDetailsResponseContext;
        private DateTime mGetUsersSubscriptionDetailsStartTime;
        private readonly KnetikResponseContext mReactivateUserSubscriptionResponseContext;
        private DateTime mReactivateUserSubscriptionStartTime;
        private readonly KnetikResponseContext mSetSubscriptionBillDateResponseContext;
        private DateTime mSetSubscriptionBillDateStartTime;
        private readonly KnetikResponseContext mSetSubscriptionPaymentMethodResponseContext;
        private DateTime mSetSubscriptionPaymentMethodStartTime;
        private readonly KnetikResponseContext mSetSubscriptionStatusResponseContext;
        private DateTime mSetSubscriptionStatusStartTime;
        private readonly KnetikResponseContext mSetUserSubscriptionPlanResponseContext;
        private DateTime mSetUserSubscriptionPlanStartTime;
        private readonly KnetikResponseContext mSetUserSubscriptionPriceResponseContext;
        private DateTime mSetUserSubscriptionPriceStartTime;

        public InventorySubscriptionResource GetUserSubscriptionDetailsData { get; private set; }
        public delegate void GetUserSubscriptionDetailsCompleteDelegate(long responseCode, InventorySubscriptionResource response);
        public GetUserSubscriptionDetailsCompleteDelegate GetUserSubscriptionDetailsComplete;

        public List<InventorySubscriptionResource> GetUsersSubscriptionDetailsData { get; private set; }
        public delegate void GetUsersSubscriptionDetailsCompleteDelegate(long responseCode, List<InventorySubscriptionResource> response);
        public GetUsersSubscriptionDetailsCompleteDelegate GetUsersSubscriptionDetailsComplete;

        public InvoiceResource ReactivateUserSubscriptionData { get; private set; }
        public delegate void ReactivateUserSubscriptionCompleteDelegate(long responseCode, InvoiceResource response);
        public ReactivateUserSubscriptionCompleteDelegate ReactivateUserSubscriptionComplete;

        public delegate void SetSubscriptionBillDateCompleteDelegate(long responseCode);
        public SetSubscriptionBillDateCompleteDelegate SetSubscriptionBillDateComplete;

        public delegate void SetSubscriptionPaymentMethodCompleteDelegate(long responseCode);
        public SetSubscriptionPaymentMethodCompleteDelegate SetSubscriptionPaymentMethodComplete;

        public delegate void SetSubscriptionStatusCompleteDelegate(long responseCode);
        public SetSubscriptionStatusCompleteDelegate SetSubscriptionStatusComplete;

        public delegate void SetUserSubscriptionPlanCompleteDelegate(long responseCode);
        public SetUserSubscriptionPlanCompleteDelegate SetUserSubscriptionPlanComplete;

        public delegate void SetUserSubscriptionPriceCompleteDelegate(long responseCode);
        public SetUserSubscriptionPriceCompleteDelegate SetUserSubscriptionPriceComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersSubscriptionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersSubscriptionsApi()
        {
            mGetUserSubscriptionDetailsResponseContext = new KnetikResponseContext();
            mGetUserSubscriptionDetailsResponseContext.ResponseReceived += OnGetUserSubscriptionDetailsResponse;
            mGetUsersSubscriptionDetailsResponseContext = new KnetikResponseContext();
            mGetUsersSubscriptionDetailsResponseContext.ResponseReceived += OnGetUsersSubscriptionDetailsResponse;
            mReactivateUserSubscriptionResponseContext = new KnetikResponseContext();
            mReactivateUserSubscriptionResponseContext.ResponseReceived += OnReactivateUserSubscriptionResponse;
            mSetSubscriptionBillDateResponseContext = new KnetikResponseContext();
            mSetSubscriptionBillDateResponseContext.ResponseReceived += OnSetSubscriptionBillDateResponse;
            mSetSubscriptionPaymentMethodResponseContext = new KnetikResponseContext();
            mSetSubscriptionPaymentMethodResponseContext.ResponseReceived += OnSetSubscriptionPaymentMethodResponse;
            mSetSubscriptionStatusResponseContext = new KnetikResponseContext();
            mSetSubscriptionStatusResponseContext.ResponseReceived += OnSetSubscriptionStatusResponse;
            mSetUserSubscriptionPlanResponseContext = new KnetikResponseContext();
            mSetUserSubscriptionPlanResponseContext.ResponseReceived += OnSetUserSubscriptionPlanResponse;
            mSetUserSubscriptionPriceResponseContext = new KnetikResponseContext();
            mSetUserSubscriptionPriceResponseContext.ResponseReceived += OnSetUserSubscriptionPriceResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get details about a user&#39;s subscription &lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/subscriptions/{inventory_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "inventory_id" + "}", KnetikClient.ParameterToString(inventoryId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUserSubscriptionDetailsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserSubscriptionDetailsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserSubscriptionDetailsStartTime, "GetUserSubscriptionDetails", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserSubscriptionDetailsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserSubscriptionDetails: " + response.Error);
            }

            GetUserSubscriptionDetailsData = (InventorySubscriptionResource) KnetikClient.Deserialize(response.Content, typeof(InventorySubscriptionResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserSubscriptionDetailsStartTime, "GetUserSubscriptionDetails", string.Format("Response received successfully:\n{0}", GetUserSubscriptionDetailsData));

            if (GetUserSubscriptionDetailsComplete != null)
            {
                GetUserSubscriptionDetailsComplete(response.ResponseCode, GetUserSubscriptionDetailsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get details about a user&#39;s subscriptions &lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN or owner
        /// </summary>
        /// <param name="userId">The id of the user</param>
        public void GetUsersSubscriptionDetails(int? userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUsersSubscriptionDetails");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/subscriptions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUsersSubscriptionDetailsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUsersSubscriptionDetailsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUsersSubscriptionDetailsStartTime, "GetUsersSubscriptionDetails", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUsersSubscriptionDetailsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUsersSubscriptionDetails: " + response.Error);
            }

            GetUsersSubscriptionDetailsData = (List<InventorySubscriptionResource>) KnetikClient.Deserialize(response.Content, typeof(List<InventorySubscriptionResource>), response.Headers);
            KnetikLogger.LogResponse(mGetUsersSubscriptionDetailsStartTime, "GetUsersSubscriptionDetails", string.Format("Response received successfully:\n{0}", GetUsersSubscriptionDetailsData));

            if (GetUsersSubscriptionDetailsComplete != null)
            {
                GetUsersSubscriptionDetailsComplete(response.ResponseCode, GetUsersSubscriptionDetailsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Reactivate a subscription and charge fee &lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/subscriptions/{inventory_id}/reactivate";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "inventory_id" + "}", KnetikClient.ParameterToString(inventoryId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(reactivateSubscriptionRequest); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mReactivateUserSubscriptionStartTime = DateTime.Now;
            mWebCallEvent.Context = mReactivateUserSubscriptionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mReactivateUserSubscriptionStartTime, "ReactivateUserSubscription", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnReactivateUserSubscriptionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling ReactivateUserSubscription: " + response.Error);
            }

            ReactivateUserSubscriptionData = (InvoiceResource) KnetikClient.Deserialize(response.Content, typeof(InvoiceResource), response.Headers);
            KnetikLogger.LogResponse(mReactivateUserSubscriptionStartTime, "ReactivateUserSubscription", string.Format("Response received successfully:\n{0}", ReactivateUserSubscriptionData));

            if (ReactivateUserSubscriptionComplete != null)
            {
                ReactivateUserSubscriptionComplete(response.ResponseCode, ReactivateUserSubscriptionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set a new date to bill a subscription on &lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/subscriptions/{inventory_id}/bill-date";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "inventory_id" + "}", KnetikClient.ParameterToString(inventoryId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(billDate); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetSubscriptionBillDateStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetSubscriptionBillDateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetSubscriptionBillDateStartTime, "SetSubscriptionBillDate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetSubscriptionBillDateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetSubscriptionBillDate: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetSubscriptionBillDateStartTime, "SetSubscriptionBillDate", "Response received successfully.");
            if (SetSubscriptionBillDateComplete != null)
            {
                SetSubscriptionBillDateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set the payment method to use for a subscription May send null to use floating default. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/subscriptions/{inventory_id}/payment-method";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "inventory_id" + "}", KnetikClient.ParameterToString(inventoryId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(paymentMethodId); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetSubscriptionPaymentMethodStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetSubscriptionPaymentMethodResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetSubscriptionPaymentMethodStartTime, "SetSubscriptionPaymentMethod", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetSubscriptionPaymentMethodResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetSubscriptionPaymentMethod: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetSubscriptionPaymentMethodStartTime, "SetSubscriptionPaymentMethod", "Response received successfully.");
            if (SetSubscriptionPaymentMethodComplete != null)
            {
                SetSubscriptionPaymentMethodComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set the status of a subscription Note that the new status may be blocked if the system is not configured to allow the current status to be changed to the new, to enforce proper flow. The default options for statuses are shown below but may be altered for special use cases. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/subscriptions/{inventory_id}/status";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "inventory_id" + "}", KnetikClient.ParameterToString(inventoryId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(status); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetSubscriptionStatusStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetSubscriptionStatusResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetSubscriptionStatusStartTime, "SetSubscriptionStatus", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetSubscriptionStatusResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetSubscriptionStatus: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetSubscriptionStatusStartTime, "SetSubscriptionStatus", "Response received successfully.");
            if (SetSubscriptionStatusComplete != null)
            {
                SetSubscriptionStatusComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set a new subscription plan for a user &lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/subscriptions/{inventory_id}/plan";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "inventory_id" + "}", KnetikClient.ParameterToString(inventoryId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(planId); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetUserSubscriptionPlanStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetUserSubscriptionPlanResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetUserSubscriptionPlanStartTime, "SetUserSubscriptionPlan", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetUserSubscriptionPlanResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetUserSubscriptionPlan: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetUserSubscriptionPlanStartTime, "SetUserSubscriptionPlan", "Response received successfully.");
            if (SetUserSubscriptionPlanComplete != null)
            {
                SetUserSubscriptionPlanComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set a new subscription price for a user This new price will be what the user is charged at the begining of each new period. This override is specific to the current subscription and will not carry over if they end and later re-subscribe. It will persist if the plan is changed using the setUserSubscriptionPlan endpoint. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; USERS_SUBSCRIPTIONS_ADMIN
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/subscriptions/{inventory_id}/price-override";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "inventory_id" + "}", KnetikClient.ParameterToString(inventoryId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(theOverrideDetails); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetUserSubscriptionPriceStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetUserSubscriptionPriceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetUserSubscriptionPriceStartTime, "SetUserSubscriptionPrice", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetUserSubscriptionPriceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetUserSubscriptionPrice: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetUserSubscriptionPriceStartTime, "SetUserSubscriptionPrice", "Response received successfully.");
            if (SetUserSubscriptionPriceComplete != null)
            {
                SetUserSubscriptionPriceComplete(response.ResponseCode);
            }
        }

    }
}
