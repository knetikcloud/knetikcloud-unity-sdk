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
    public interface IStoreSubscriptionsApi
    {
        SubscriptionResource CreateSubscriptionData { get; }

        SubscriptionTemplateResource CreateSubscriptionTemplateData { get; }

        SubscriptionResource GetSubscriptionData { get; }

        SubscriptionTemplateResource GetSubscriptionTemplateData { get; }

        PageResourceSubscriptionTemplateResource GetSubscriptionTemplatesData { get; }

        PageResourceSubscriptionResource GetSubscriptionsData { get; }

        SubscriptionTemplateResource UpdateSubscriptionTemplateData { get; }

        
        /// <summary>
        /// Creates a subscription item and associated plans 
        /// </summary>
        /// <param name="subscriptionResource">The subscription to be created</param>
        void CreateSubscription(SubscriptionResource subscriptionResource);

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

        /// <summary>
        /// Retrieve a single subscription item and associated plans 
        /// </summary>
        /// <param name="id">The id of the subscription</param>
        void GetSubscription(int? id);

        /// <summary>
        /// Get a single subscription template Subscription Templates define a type of subscription and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetSubscriptionTemplate(string id);

        /// <summary>
        /// List and search subscription templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetSubscriptionTemplates(int? size, int? page, string order);

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
        private readonly KnetikCoroutine mCreateSubscriptionCoroutine;
        private DateTime mCreateSubscriptionStartTime;
        private string mCreateSubscriptionPath;
        private readonly KnetikCoroutine mCreateSubscriptionTemplateCoroutine;
        private DateTime mCreateSubscriptionTemplateStartTime;
        private string mCreateSubscriptionTemplatePath;
        private readonly KnetikCoroutine mDeleteSubscriptionCoroutine;
        private DateTime mDeleteSubscriptionStartTime;
        private string mDeleteSubscriptionPath;
        private readonly KnetikCoroutine mDeleteSubscriptionTemplateCoroutine;
        private DateTime mDeleteSubscriptionTemplateStartTime;
        private string mDeleteSubscriptionTemplatePath;
        private readonly KnetikCoroutine mGetSubscriptionCoroutine;
        private DateTime mGetSubscriptionStartTime;
        private string mGetSubscriptionPath;
        private readonly KnetikCoroutine mGetSubscriptionTemplateCoroutine;
        private DateTime mGetSubscriptionTemplateStartTime;
        private string mGetSubscriptionTemplatePath;
        private readonly KnetikCoroutine mGetSubscriptionTemplatesCoroutine;
        private DateTime mGetSubscriptionTemplatesStartTime;
        private string mGetSubscriptionTemplatesPath;
        private readonly KnetikCoroutine mGetSubscriptionsCoroutine;
        private DateTime mGetSubscriptionsStartTime;
        private string mGetSubscriptionsPath;
        private readonly KnetikCoroutine mProcessSubscriptionsCoroutine;
        private DateTime mProcessSubscriptionsStartTime;
        private string mProcessSubscriptionsPath;
        private readonly KnetikCoroutine mUpdateSubscriptionCoroutine;
        private DateTime mUpdateSubscriptionStartTime;
        private string mUpdateSubscriptionPath;
        private readonly KnetikCoroutine mUpdateSubscriptionTemplateCoroutine;
        private DateTime mUpdateSubscriptionTemplateStartTime;
        private string mUpdateSubscriptionTemplatePath;

        public SubscriptionResource CreateSubscriptionData { get; private set; }
        public delegate void CreateSubscriptionCompleteDelegate(SubscriptionResource response);
        public CreateSubscriptionCompleteDelegate CreateSubscriptionComplete;

        public SubscriptionTemplateResource CreateSubscriptionTemplateData { get; private set; }
        public delegate void CreateSubscriptionTemplateCompleteDelegate(SubscriptionTemplateResource response);
        public CreateSubscriptionTemplateCompleteDelegate CreateSubscriptionTemplateComplete;

        public delegate void DeleteSubscriptionCompleteDelegate();
        public DeleteSubscriptionCompleteDelegate DeleteSubscriptionComplete;

        public delegate void DeleteSubscriptionTemplateCompleteDelegate();
        public DeleteSubscriptionTemplateCompleteDelegate DeleteSubscriptionTemplateComplete;

        public SubscriptionResource GetSubscriptionData { get; private set; }
        public delegate void GetSubscriptionCompleteDelegate(SubscriptionResource response);
        public GetSubscriptionCompleteDelegate GetSubscriptionComplete;

        public SubscriptionTemplateResource GetSubscriptionTemplateData { get; private set; }
        public delegate void GetSubscriptionTemplateCompleteDelegate(SubscriptionTemplateResource response);
        public GetSubscriptionTemplateCompleteDelegate GetSubscriptionTemplateComplete;

        public PageResourceSubscriptionTemplateResource GetSubscriptionTemplatesData { get; private set; }
        public delegate void GetSubscriptionTemplatesCompleteDelegate(PageResourceSubscriptionTemplateResource response);
        public GetSubscriptionTemplatesCompleteDelegate GetSubscriptionTemplatesComplete;

        public PageResourceSubscriptionResource GetSubscriptionsData { get; private set; }
        public delegate void GetSubscriptionsCompleteDelegate(PageResourceSubscriptionResource response);
        public GetSubscriptionsCompleteDelegate GetSubscriptionsComplete;

        public delegate void ProcessSubscriptionsCompleteDelegate();
        public ProcessSubscriptionsCompleteDelegate ProcessSubscriptionsComplete;

        public delegate void UpdateSubscriptionCompleteDelegate();
        public UpdateSubscriptionCompleteDelegate UpdateSubscriptionComplete;

        public SubscriptionTemplateResource UpdateSubscriptionTemplateData { get; private set; }
        public delegate void UpdateSubscriptionTemplateCompleteDelegate(SubscriptionTemplateResource response);
        public UpdateSubscriptionTemplateCompleteDelegate UpdateSubscriptionTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreSubscriptionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreSubscriptionsApi()
        {
            mCreateSubscriptionCoroutine = new KnetikCoroutine();
            mCreateSubscriptionTemplateCoroutine = new KnetikCoroutine();
            mDeleteSubscriptionCoroutine = new KnetikCoroutine();
            mDeleteSubscriptionTemplateCoroutine = new KnetikCoroutine();
            mGetSubscriptionCoroutine = new KnetikCoroutine();
            mGetSubscriptionTemplateCoroutine = new KnetikCoroutine();
            mGetSubscriptionTemplatesCoroutine = new KnetikCoroutine();
            mGetSubscriptionsCoroutine = new KnetikCoroutine();
            mProcessSubscriptionsCoroutine = new KnetikCoroutine();
            mUpdateSubscriptionCoroutine = new KnetikCoroutine();
            mUpdateSubscriptionTemplateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Creates a subscription item and associated plans 
        /// </summary>
        /// <param name="subscriptionResource">The subscription to be created</param>
        public void CreateSubscription(SubscriptionResource subscriptionResource)
        {
            
            mCreateSubscriptionPath = "/subscriptions";
            if (!string.IsNullOrEmpty(mCreateSubscriptionPath))
            {
                mCreateSubscriptionPath = mCreateSubscriptionPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(subscriptionResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateSubscriptionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateSubscriptionStartTime, mCreateSubscriptionPath, "Sending server request...");

            // make the HTTP request
            mCreateSubscriptionCoroutine.ResponseReceived += CreateSubscriptionCallback;
            mCreateSubscriptionCoroutine.Start(mCreateSubscriptionPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateSubscriptionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateSubscription: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateSubscription: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateSubscriptionData = (SubscriptionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(SubscriptionResource), response.Headers);
            KnetikLogger.LogResponse(mCreateSubscriptionStartTime, mCreateSubscriptionPath, string.Format("Response received successfully:\n{0}", CreateSubscriptionData.ToString()));

            if (CreateSubscriptionComplete != null)
            {
                CreateSubscriptionComplete(CreateSubscriptionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a subscription template Subscription Templates define a type of subscription and the properties they have.
        /// </summary>
        /// <param name="subscriptionTemplateResource">The new subscription template</param>
        public void CreateSubscriptionTemplate(SubscriptionTemplateResource subscriptionTemplateResource)
        {
            
            mCreateSubscriptionTemplatePath = "/subscriptions/templates";
            if (!string.IsNullOrEmpty(mCreateSubscriptionTemplatePath))
            {
                mCreateSubscriptionTemplatePath = mCreateSubscriptionTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(subscriptionTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateSubscriptionTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateSubscriptionTemplateStartTime, mCreateSubscriptionTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateSubscriptionTemplateCoroutine.ResponseReceived += CreateSubscriptionTemplateCallback;
            mCreateSubscriptionTemplateCoroutine.Start(mCreateSubscriptionTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateSubscriptionTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateSubscriptionTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateSubscriptionTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateSubscriptionTemplateData = (SubscriptionTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(SubscriptionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateSubscriptionTemplateStartTime, mCreateSubscriptionTemplatePath, string.Format("Response received successfully:\n{0}", CreateSubscriptionTemplateData.ToString()));

            if (CreateSubscriptionTemplateComplete != null)
            {
                CreateSubscriptionTemplateComplete(CreateSubscriptionTemplateData);
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
            
            mDeleteSubscriptionPath = "/subscriptions/{id}/plans/{plan_id}";
            if (!string.IsNullOrEmpty(mDeleteSubscriptionPath))
            {
                mDeleteSubscriptionPath = mDeleteSubscriptionPath.Replace("{format}", "json");
            }
            mDeleteSubscriptionPath = mDeleteSubscriptionPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));
mDeleteSubscriptionPath = mDeleteSubscriptionPath.Replace("{" + "plan_id" + "}", KnetikClient.DefaultClient.ParameterToString(planId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteSubscriptionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteSubscriptionStartTime, mDeleteSubscriptionPath, "Sending server request...");

            // make the HTTP request
            mDeleteSubscriptionCoroutine.ResponseReceived += DeleteSubscriptionCallback;
            mDeleteSubscriptionCoroutine.Start(mDeleteSubscriptionPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteSubscriptionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteSubscription: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteSubscription: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteSubscriptionStartTime, mDeleteSubscriptionPath, "Response received successfully.");
            if (DeleteSubscriptionComplete != null)
            {
                DeleteSubscriptionComplete();
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
            
            mDeleteSubscriptionTemplatePath = "/subscriptions/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteSubscriptionTemplatePath))
            {
                mDeleteSubscriptionTemplatePath = mDeleteSubscriptionTemplatePath.Replace("{format}", "json");
            }
            mDeleteSubscriptionTemplatePath = mDeleteSubscriptionTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteSubscriptionTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteSubscriptionTemplateStartTime, mDeleteSubscriptionTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteSubscriptionTemplateCoroutine.ResponseReceived += DeleteSubscriptionTemplateCallback;
            mDeleteSubscriptionTemplateCoroutine.Start(mDeleteSubscriptionTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteSubscriptionTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteSubscriptionTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteSubscriptionTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteSubscriptionTemplateStartTime, mDeleteSubscriptionTemplatePath, "Response received successfully.");
            if (DeleteSubscriptionTemplateComplete != null)
            {
                DeleteSubscriptionTemplateComplete();
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
            
            mGetSubscriptionPath = "/subscriptions/{id}";
            if (!string.IsNullOrEmpty(mGetSubscriptionPath))
            {
                mGetSubscriptionPath = mGetSubscriptionPath.Replace("{format}", "json");
            }
            mGetSubscriptionPath = mGetSubscriptionPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetSubscriptionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetSubscriptionStartTime, mGetSubscriptionPath, "Sending server request...");

            // make the HTTP request
            mGetSubscriptionCoroutine.ResponseReceived += GetSubscriptionCallback;
            mGetSubscriptionCoroutine.Start(mGetSubscriptionPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetSubscriptionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSubscription: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSubscription: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetSubscriptionData = (SubscriptionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(SubscriptionResource), response.Headers);
            KnetikLogger.LogResponse(mGetSubscriptionStartTime, mGetSubscriptionPath, string.Format("Response received successfully:\n{0}", GetSubscriptionData.ToString()));

            if (GetSubscriptionComplete != null)
            {
                GetSubscriptionComplete(GetSubscriptionData);
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
            
            mGetSubscriptionTemplatePath = "/subscriptions/templates/{id}";
            if (!string.IsNullOrEmpty(mGetSubscriptionTemplatePath))
            {
                mGetSubscriptionTemplatePath = mGetSubscriptionTemplatePath.Replace("{format}", "json");
            }
            mGetSubscriptionTemplatePath = mGetSubscriptionTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetSubscriptionTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetSubscriptionTemplateStartTime, mGetSubscriptionTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetSubscriptionTemplateCoroutine.ResponseReceived += GetSubscriptionTemplateCallback;
            mGetSubscriptionTemplateCoroutine.Start(mGetSubscriptionTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetSubscriptionTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSubscriptionTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSubscriptionTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetSubscriptionTemplateData = (SubscriptionTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(SubscriptionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetSubscriptionTemplateStartTime, mGetSubscriptionTemplatePath, string.Format("Response received successfully:\n{0}", GetSubscriptionTemplateData.ToString()));

            if (GetSubscriptionTemplateComplete != null)
            {
                GetSubscriptionTemplateComplete(GetSubscriptionTemplateData);
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
            
            mGetSubscriptionTemplatesPath = "/subscriptions/templates";
            if (!string.IsNullOrEmpty(mGetSubscriptionTemplatesPath))
            {
                mGetSubscriptionTemplatesPath = mGetSubscriptionTemplatesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

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
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetSubscriptionTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetSubscriptionTemplatesStartTime, mGetSubscriptionTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetSubscriptionTemplatesCoroutine.ResponseReceived += GetSubscriptionTemplatesCallback;
            mGetSubscriptionTemplatesCoroutine.Start(mGetSubscriptionTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetSubscriptionTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSubscriptionTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSubscriptionTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetSubscriptionTemplatesData = (PageResourceSubscriptionTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceSubscriptionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetSubscriptionTemplatesStartTime, mGetSubscriptionTemplatesPath, string.Format("Response received successfully:\n{0}", GetSubscriptionTemplatesData.ToString()));

            if (GetSubscriptionTemplatesComplete != null)
            {
                GetSubscriptionTemplatesComplete(GetSubscriptionTemplatesData);
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
            
            mGetSubscriptionsPath = "/subscriptions";
            if (!string.IsNullOrEmpty(mGetSubscriptionsPath))
            {
                mGetSubscriptionsPath = mGetSubscriptionsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

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
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetSubscriptionsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetSubscriptionsStartTime, mGetSubscriptionsPath, "Sending server request...");

            // make the HTTP request
            mGetSubscriptionsCoroutine.ResponseReceived += GetSubscriptionsCallback;
            mGetSubscriptionsCoroutine.Start(mGetSubscriptionsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetSubscriptionsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSubscriptions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSubscriptions: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetSubscriptionsData = (PageResourceSubscriptionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceSubscriptionResource), response.Headers);
            KnetikLogger.LogResponse(mGetSubscriptionsStartTime, mGetSubscriptionsPath, string.Format("Response received successfully:\n{0}", GetSubscriptionsData.ToString()));

            if (GetSubscriptionsComplete != null)
            {
                GetSubscriptionsComplete(GetSubscriptionsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Processes subscriptions and charge dues 
        /// </summary>
        public void ProcessSubscriptions()
        {
            
            mProcessSubscriptionsPath = "/subscriptions/process";
            if (!string.IsNullOrEmpty(mProcessSubscriptionsPath))
            {
                mProcessSubscriptionsPath = mProcessSubscriptionsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mProcessSubscriptionsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mProcessSubscriptionsStartTime, mProcessSubscriptionsPath, "Sending server request...");

            // make the HTTP request
            mProcessSubscriptionsCoroutine.ResponseReceived += ProcessSubscriptionsCallback;
            mProcessSubscriptionsCoroutine.Start(mProcessSubscriptionsPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void ProcessSubscriptionsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling ProcessSubscriptions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling ProcessSubscriptions: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mProcessSubscriptionsStartTime, mProcessSubscriptionsPath, "Response received successfully.");
            if (ProcessSubscriptionsComplete != null)
            {
                ProcessSubscriptionsComplete();
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
            
            mUpdateSubscriptionPath = "/subscriptions/{id}";
            if (!string.IsNullOrEmpty(mUpdateSubscriptionPath))
            {
                mUpdateSubscriptionPath = mUpdateSubscriptionPath.Replace("{format}", "json");
            }
            mUpdateSubscriptionPath = mUpdateSubscriptionPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(subscriptionResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateSubscriptionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateSubscriptionStartTime, mUpdateSubscriptionPath, "Sending server request...");

            // make the HTTP request
            mUpdateSubscriptionCoroutine.ResponseReceived += UpdateSubscriptionCallback;
            mUpdateSubscriptionCoroutine.Start(mUpdateSubscriptionPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateSubscriptionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateSubscription: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateSubscription: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateSubscriptionStartTime, mUpdateSubscriptionPath, "Response received successfully.");
            if (UpdateSubscriptionComplete != null)
            {
                UpdateSubscriptionComplete();
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
            
            mUpdateSubscriptionTemplatePath = "/subscriptions/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateSubscriptionTemplatePath))
            {
                mUpdateSubscriptionTemplatePath = mUpdateSubscriptionTemplatePath.Replace("{format}", "json");
            }
            mUpdateSubscriptionTemplatePath = mUpdateSubscriptionTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(subscriptionTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateSubscriptionTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateSubscriptionTemplateStartTime, mUpdateSubscriptionTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateSubscriptionTemplateCoroutine.ResponseReceived += UpdateSubscriptionTemplateCallback;
            mUpdateSubscriptionTemplateCoroutine.Start(mUpdateSubscriptionTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateSubscriptionTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateSubscriptionTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateSubscriptionTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateSubscriptionTemplateData = (SubscriptionTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(SubscriptionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateSubscriptionTemplateStartTime, mUpdateSubscriptionTemplatePath, string.Format("Response received successfully:\n{0}", UpdateSubscriptionTemplateData.ToString()));

            if (UpdateSubscriptionTemplateComplete != null)
            {
                UpdateSubscriptionTemplateComplete(UpdateSubscriptionTemplateData);
            }
        }

    }
}
