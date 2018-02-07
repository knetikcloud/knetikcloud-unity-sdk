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
    public interface IStoreSubscriptionsApi
    {
        SubscriptionResource CreateSubscriptionData { get; }

        /// <summary>
        /// Creates a subscription item and associated plans 
        /// </summary>
        /// <param name="subscriptionResource">The subscription to be created</param>
        void CreateSubscription(SubscriptionResource subscriptionResource);

        SubscriptionTemplateResource CreateSubscriptionTemplateData { get; }

        /// <summary>
        /// Create a subscription template Subscription Templates define a type of subscription and the properties they have.
        /// </summary>
        /// <param name="subscriptionTemplateResource">The new subscription template</param>
        void CreateSubscriptionTemplate(SubscriptionTemplateResource subscriptionTemplateResource);

        

        /// <summary>
        /// Delete a subscription plan Must not be locked or a migration target
        /// </summary>
        /// <param name="id">The id of the subscription</param>
        /// <param name="planId">The id of the plan</param>
        void DeleteSubscription(int? id, string planId);

        

        /// <summary>
        /// Delete a subscription template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        void DeleteSubscriptionTemplate(string id, string cascade);

        SubscriptionResource GetSubscriptionData { get; }

        /// <summary>
        /// Retrieve a single subscription item and associated plans 
        /// </summary>
        /// <param name="id">The id of the subscription</param>
        void GetSubscription(int? id);

        SubscriptionTemplateResource GetSubscriptionTemplateData { get; }

        /// <summary>
        /// Get a single subscription template Subscription Templates define a type of subscription and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetSubscriptionTemplate(string id);

        PageResourceSubscriptionTemplateResource GetSubscriptionTemplatesData { get; }

        /// <summary>
        /// List and search subscription templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetSubscriptionTemplates(int? size, int? page, string order);

        PageResourceSubscriptionResource GetSubscriptionsData { get; }

        /// <summary>
        /// List available subscription items and associated plans 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetSubscriptions(int? size, int? page, string order);

        

        /// <summary>
        /// Processes subscriptions and charge dues 
        /// </summary>
        void ProcessSubscriptions();

        

        /// <summary>
        /// Updates a subscription item and associated plans Will not remove plans left out
        /// </summary>
        /// <param name="id">The id of the subscription</param>
        /// <param name="subscriptionResource">The subscription resource object</param>
        void UpdateSubscription(int? id, SubscriptionResource subscriptionResource);

        SubscriptionTemplateResource UpdateSubscriptionTemplateData { get; }

        /// <summary>
        /// Update a subscription template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="subscriptionTemplateResource">The subscription template resource object</param>
        void UpdateSubscriptionTemplate(string id, SubscriptionTemplateResource subscriptionTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StoreSubscriptionsApi : IStoreSubscriptionsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateSubscriptionResponseContext;
        private DateTime mCreateSubscriptionStartTime;
        private readonly KnetikResponseContext mCreateSubscriptionTemplateResponseContext;
        private DateTime mCreateSubscriptionTemplateStartTime;
        private readonly KnetikResponseContext mDeleteSubscriptionResponseContext;
        private DateTime mDeleteSubscriptionStartTime;
        private readonly KnetikResponseContext mDeleteSubscriptionTemplateResponseContext;
        private DateTime mDeleteSubscriptionTemplateStartTime;
        private readonly KnetikResponseContext mGetSubscriptionResponseContext;
        private DateTime mGetSubscriptionStartTime;
        private readonly KnetikResponseContext mGetSubscriptionTemplateResponseContext;
        private DateTime mGetSubscriptionTemplateStartTime;
        private readonly KnetikResponseContext mGetSubscriptionTemplatesResponseContext;
        private DateTime mGetSubscriptionTemplatesStartTime;
        private readonly KnetikResponseContext mGetSubscriptionsResponseContext;
        private DateTime mGetSubscriptionsStartTime;
        private readonly KnetikResponseContext mProcessSubscriptionsResponseContext;
        private DateTime mProcessSubscriptionsStartTime;
        private readonly KnetikResponseContext mUpdateSubscriptionResponseContext;
        private DateTime mUpdateSubscriptionStartTime;
        private readonly KnetikResponseContext mUpdateSubscriptionTemplateResponseContext;
        private DateTime mUpdateSubscriptionTemplateStartTime;

        public SubscriptionResource CreateSubscriptionData { get; private set; }
        public delegate void CreateSubscriptionCompleteDelegate(long responseCode, SubscriptionResource response);
        public CreateSubscriptionCompleteDelegate CreateSubscriptionComplete;

        public SubscriptionTemplateResource CreateSubscriptionTemplateData { get; private set; }
        public delegate void CreateSubscriptionTemplateCompleteDelegate(long responseCode, SubscriptionTemplateResource response);
        public CreateSubscriptionTemplateCompleteDelegate CreateSubscriptionTemplateComplete;

        public delegate void DeleteSubscriptionCompleteDelegate(long responseCode);
        public DeleteSubscriptionCompleteDelegate DeleteSubscriptionComplete;

        public delegate void DeleteSubscriptionTemplateCompleteDelegate(long responseCode);
        public DeleteSubscriptionTemplateCompleteDelegate DeleteSubscriptionTemplateComplete;

        public SubscriptionResource GetSubscriptionData { get; private set; }
        public delegate void GetSubscriptionCompleteDelegate(long responseCode, SubscriptionResource response);
        public GetSubscriptionCompleteDelegate GetSubscriptionComplete;

        public SubscriptionTemplateResource GetSubscriptionTemplateData { get; private set; }
        public delegate void GetSubscriptionTemplateCompleteDelegate(long responseCode, SubscriptionTemplateResource response);
        public GetSubscriptionTemplateCompleteDelegate GetSubscriptionTemplateComplete;

        public PageResourceSubscriptionTemplateResource GetSubscriptionTemplatesData { get; private set; }
        public delegate void GetSubscriptionTemplatesCompleteDelegate(long responseCode, PageResourceSubscriptionTemplateResource response);
        public GetSubscriptionTemplatesCompleteDelegate GetSubscriptionTemplatesComplete;

        public PageResourceSubscriptionResource GetSubscriptionsData { get; private set; }
        public delegate void GetSubscriptionsCompleteDelegate(long responseCode, PageResourceSubscriptionResource response);
        public GetSubscriptionsCompleteDelegate GetSubscriptionsComplete;

        public delegate void ProcessSubscriptionsCompleteDelegate(long responseCode);
        public ProcessSubscriptionsCompleteDelegate ProcessSubscriptionsComplete;

        public delegate void UpdateSubscriptionCompleteDelegate(long responseCode);
        public UpdateSubscriptionCompleteDelegate UpdateSubscriptionComplete;

        public SubscriptionTemplateResource UpdateSubscriptionTemplateData { get; private set; }
        public delegate void UpdateSubscriptionTemplateCompleteDelegate(long responseCode, SubscriptionTemplateResource response);
        public UpdateSubscriptionTemplateCompleteDelegate UpdateSubscriptionTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreSubscriptionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreSubscriptionsApi()
        {
            mCreateSubscriptionResponseContext = new KnetikResponseContext();
            mCreateSubscriptionResponseContext.ResponseReceived += OnCreateSubscriptionResponse;
            mCreateSubscriptionTemplateResponseContext = new KnetikResponseContext();
            mCreateSubscriptionTemplateResponseContext.ResponseReceived += OnCreateSubscriptionTemplateResponse;
            mDeleteSubscriptionResponseContext = new KnetikResponseContext();
            mDeleteSubscriptionResponseContext.ResponseReceived += OnDeleteSubscriptionResponse;
            mDeleteSubscriptionTemplateResponseContext = new KnetikResponseContext();
            mDeleteSubscriptionTemplateResponseContext.ResponseReceived += OnDeleteSubscriptionTemplateResponse;
            mGetSubscriptionResponseContext = new KnetikResponseContext();
            mGetSubscriptionResponseContext.ResponseReceived += OnGetSubscriptionResponse;
            mGetSubscriptionTemplateResponseContext = new KnetikResponseContext();
            mGetSubscriptionTemplateResponseContext.ResponseReceived += OnGetSubscriptionTemplateResponse;
            mGetSubscriptionTemplatesResponseContext = new KnetikResponseContext();
            mGetSubscriptionTemplatesResponseContext.ResponseReceived += OnGetSubscriptionTemplatesResponse;
            mGetSubscriptionsResponseContext = new KnetikResponseContext();
            mGetSubscriptionsResponseContext.ResponseReceived += OnGetSubscriptionsResponse;
            mProcessSubscriptionsResponseContext = new KnetikResponseContext();
            mProcessSubscriptionsResponseContext.ResponseReceived += OnProcessSubscriptionsResponse;
            mUpdateSubscriptionResponseContext = new KnetikResponseContext();
            mUpdateSubscriptionResponseContext.ResponseReceived += OnUpdateSubscriptionResponse;
            mUpdateSubscriptionTemplateResponseContext = new KnetikResponseContext();
            mUpdateSubscriptionTemplateResponseContext.ResponseReceived += OnUpdateSubscriptionTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Creates a subscription item and associated plans 
        /// </summary>
        /// <param name="subscriptionResource">The subscription to be created</param>
        public void CreateSubscription(SubscriptionResource subscriptionResource)
        {
            
            mWebCallEvent.WebPath = "/subscriptions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(subscriptionResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateSubscriptionStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateSubscriptionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateSubscriptionStartTime, "CreateSubscription", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateSubscriptionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateSubscription: " + response.Error);
            }

            CreateSubscriptionData = (SubscriptionResource) KnetikClient.Deserialize(response.Content, typeof(SubscriptionResource), response.Headers);
            KnetikLogger.LogResponse(mCreateSubscriptionStartTime, "CreateSubscription", string.Format("Response received successfully:\n{0}", CreateSubscriptionData));

            if (CreateSubscriptionComplete != null)
            {
                CreateSubscriptionComplete(response.ResponseCode, CreateSubscriptionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a subscription template Subscription Templates define a type of subscription and the properties they have.
        /// </summary>
        /// <param name="subscriptionTemplateResource">The new subscription template</param>
        public void CreateSubscriptionTemplate(SubscriptionTemplateResource subscriptionTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/subscriptions/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(subscriptionTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateSubscriptionTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateSubscriptionTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateSubscriptionTemplateStartTime, "CreateSubscriptionTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateSubscriptionTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateSubscriptionTemplate: " + response.Error);
            }

            CreateSubscriptionTemplateData = (SubscriptionTemplateResource) KnetikClient.Deserialize(response.Content, typeof(SubscriptionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateSubscriptionTemplateStartTime, "CreateSubscriptionTemplate", string.Format("Response received successfully:\n{0}", CreateSubscriptionTemplateData));

            if (CreateSubscriptionTemplateComplete != null)
            {
                CreateSubscriptionTemplateComplete(response.ResponseCode, CreateSubscriptionTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a subscription plan Must not be locked or a migration target
        /// </summary>
        /// <param name="id">The id of the subscription</param>
        /// <param name="planId">The id of the plan</param>
        public void DeleteSubscription(int? id, string planId)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteSubscription");
            }
            // verify the required parameter 'planId' is set
            if (planId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'planId' when calling DeleteSubscription");
            }
            
            mWebCallEvent.WebPath = "/subscriptions/{id}/plans/{plan_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "plan_id" + "}", KnetikClient.ParameterToString(planId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteSubscriptionStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteSubscriptionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteSubscriptionStartTime, "DeleteSubscription", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteSubscriptionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteSubscription: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteSubscriptionStartTime, "DeleteSubscription", "Response received successfully.");
            if (DeleteSubscriptionComplete != null)
            {
                DeleteSubscriptionComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a subscription template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        public void DeleteSubscriptionTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteSubscriptionTemplate");
            }
            
            mWebCallEvent.WebPath = "/subscriptions/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (cascade != null)
            {
                mWebCallEvent.QueryParams["cascade"] = KnetikClient.ParameterToString(cascade);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteSubscriptionTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteSubscriptionTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteSubscriptionTemplateStartTime, "DeleteSubscriptionTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteSubscriptionTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteSubscriptionTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteSubscriptionTemplateStartTime, "DeleteSubscriptionTemplate", "Response received successfully.");
            if (DeleteSubscriptionTemplateComplete != null)
            {
                DeleteSubscriptionTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve a single subscription item and associated plans 
        /// </summary>
        /// <param name="id">The id of the subscription</param>
        public void GetSubscription(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetSubscription");
            }
            
            mWebCallEvent.WebPath = "/subscriptions/{id}";
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
            mGetSubscriptionStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetSubscriptionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetSubscriptionStartTime, "GetSubscription", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetSubscriptionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetSubscription: " + response.Error);
            }

            GetSubscriptionData = (SubscriptionResource) KnetikClient.Deserialize(response.Content, typeof(SubscriptionResource), response.Headers);
            KnetikLogger.LogResponse(mGetSubscriptionStartTime, "GetSubscription", string.Format("Response received successfully:\n{0}", GetSubscriptionData));

            if (GetSubscriptionComplete != null)
            {
                GetSubscriptionComplete(response.ResponseCode, GetSubscriptionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single subscription template Subscription Templates define a type of subscription and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetSubscriptionTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetSubscriptionTemplate");
            }
            
            mWebCallEvent.WebPath = "/subscriptions/templates/{id}";
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
            mGetSubscriptionTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetSubscriptionTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetSubscriptionTemplateStartTime, "GetSubscriptionTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetSubscriptionTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetSubscriptionTemplate: " + response.Error);
            }

            GetSubscriptionTemplateData = (SubscriptionTemplateResource) KnetikClient.Deserialize(response.Content, typeof(SubscriptionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetSubscriptionTemplateStartTime, "GetSubscriptionTemplate", string.Format("Response received successfully:\n{0}", GetSubscriptionTemplateData));

            if (GetSubscriptionTemplateComplete != null)
            {
                GetSubscriptionTemplateComplete(response.ResponseCode, GetSubscriptionTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search subscription templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetSubscriptionTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/subscriptions/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

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
            mGetSubscriptionTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetSubscriptionTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetSubscriptionTemplatesStartTime, "GetSubscriptionTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetSubscriptionTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetSubscriptionTemplates: " + response.Error);
            }

            GetSubscriptionTemplatesData = (PageResourceSubscriptionTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceSubscriptionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetSubscriptionTemplatesStartTime, "GetSubscriptionTemplates", string.Format("Response received successfully:\n{0}", GetSubscriptionTemplatesData));

            if (GetSubscriptionTemplatesComplete != null)
            {
                GetSubscriptionTemplatesComplete(response.ResponseCode, GetSubscriptionTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List available subscription items and associated plans 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetSubscriptions(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/subscriptions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

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
            mGetSubscriptionsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetSubscriptionsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetSubscriptionsStartTime, "GetSubscriptions", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetSubscriptionsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetSubscriptions: " + response.Error);
            }

            GetSubscriptionsData = (PageResourceSubscriptionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceSubscriptionResource), response.Headers);
            KnetikLogger.LogResponse(mGetSubscriptionsStartTime, "GetSubscriptions", string.Format("Response received successfully:\n{0}", GetSubscriptionsData));

            if (GetSubscriptionsComplete != null)
            {
                GetSubscriptionsComplete(response.ResponseCode, GetSubscriptionsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Processes subscriptions and charge dues 
        /// </summary>
        public void ProcessSubscriptions()
        {
            
            mWebCallEvent.WebPath = "/subscriptions/process";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mProcessSubscriptionsStartTime = DateTime.Now;
            mWebCallEvent.Context = mProcessSubscriptionsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mProcessSubscriptionsStartTime, "ProcessSubscriptions", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnProcessSubscriptionsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling ProcessSubscriptions: " + response.Error);
            }

            KnetikLogger.LogResponse(mProcessSubscriptionsStartTime, "ProcessSubscriptions", "Response received successfully.");
            if (ProcessSubscriptionsComplete != null)
            {
                ProcessSubscriptionsComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Updates a subscription item and associated plans Will not remove plans left out
        /// </summary>
        /// <param name="id">The id of the subscription</param>
        /// <param name="subscriptionResource">The subscription resource object</param>
        public void UpdateSubscription(int? id, SubscriptionResource subscriptionResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateSubscription");
            }
            
            mWebCallEvent.WebPath = "/subscriptions/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(subscriptionResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateSubscriptionStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateSubscriptionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateSubscriptionStartTime, "UpdateSubscription", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateSubscriptionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateSubscription: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateSubscriptionStartTime, "UpdateSubscription", "Response received successfully.");
            if (UpdateSubscriptionComplete != null)
            {
                UpdateSubscriptionComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a subscription template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="subscriptionTemplateResource">The subscription template resource object</param>
        public void UpdateSubscriptionTemplate(string id, SubscriptionTemplateResource subscriptionTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateSubscriptionTemplate");
            }
            
            mWebCallEvent.WebPath = "/subscriptions/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(subscriptionTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateSubscriptionTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateSubscriptionTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateSubscriptionTemplateStartTime, "UpdateSubscriptionTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateSubscriptionTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateSubscriptionTemplate: " + response.Error);
            }

            UpdateSubscriptionTemplateData = (SubscriptionTemplateResource) KnetikClient.Deserialize(response.Content, typeof(SubscriptionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateSubscriptionTemplateStartTime, "UpdateSubscriptionTemplate", string.Format("Response received successfully:\n{0}", UpdateSubscriptionTemplateData));

            if (UpdateSubscriptionTemplateComplete != null)
            {
                UpdateSubscriptionTemplateComplete(response.ResponseCode, UpdateSubscriptionTemplateData);
            }
        }

    }
}
