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
    public interface IStoreShippingApi
    {
        ShippingItem CreateShippingItemData { get; }

        ItemTemplateResource CreateShippingTemplateData { get; }

        ShippingItem GetShippingItemData { get; }

        ItemTemplateResource GetShippingTemplateData { get; }

        PageResourceItemTemplateResource GetShippingTemplatesData { get; }

        ShippingItem UpdateShippingItemData { get; }

        ItemTemplateResource UpdateShippingTemplateData { get; }

        
        /// <summary>
        /// Create a shipping item A shipping item represents a shipping option and cost. SKUs have to be unique in the entire store.
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="shippingItem">The shipping item object</param>
        void CreateShippingItem(bool? cascade, ShippingItem shippingItem);

        /// <summary>
        /// Create a shipping template Shipping Templates define a type of shipping and the properties they have.
        /// </summary>
        /// <param name="shippingTemplateResource">The new shipping template</param>
        void CreateShippingTemplate(ItemTemplateResource shippingTemplateResource);

        /// <summary>
        /// Delete a shipping item 
        /// </summary>
        /// <param name="id">The id of the shipping item</param>
        void DeleteShippingItem(int? id);

        /// <summary>
        /// Delete a shipping template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        void DeleteShippingTemplate(string id, string cascade);

        /// <summary>
        /// Get a single shipping item 
        /// </summary>
        /// <param name="id">The id of the shipping item</param>
        void GetShippingItem(int? id);

        /// <summary>
        /// Get a single shipping template Shipping Templates define a type of shipping and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetShippingTemplate(string id);

        /// <summary>
        /// List and search shipping templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetShippingTemplates(int? size, int? page, string order);

        /// <summary>
        /// Update a shipping item 
        /// </summary>
        /// <param name="id">The id of the shipping item</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="shippingItem">The shipping item object</param>
        void UpdateShippingItem(int? id, bool? cascade, ShippingItem shippingItem);

        /// <summary>
        /// Update a shipping template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="shippingTemplateResource">The shipping template resource object</param>
        void UpdateShippingTemplate(string id, ItemTemplateResource shippingTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StoreShippingApi : IStoreShippingApi
    {
        private readonly KnetikCoroutine mCreateShippingItemCoroutine;
        private DateTime mCreateShippingItemStartTime;
        private string mCreateShippingItemPath;
        private readonly KnetikCoroutine mCreateShippingTemplateCoroutine;
        private DateTime mCreateShippingTemplateStartTime;
        private string mCreateShippingTemplatePath;
        private readonly KnetikCoroutine mDeleteShippingItemCoroutine;
        private DateTime mDeleteShippingItemStartTime;
        private string mDeleteShippingItemPath;
        private readonly KnetikCoroutine mDeleteShippingTemplateCoroutine;
        private DateTime mDeleteShippingTemplateStartTime;
        private string mDeleteShippingTemplatePath;
        private readonly KnetikCoroutine mGetShippingItemCoroutine;
        private DateTime mGetShippingItemStartTime;
        private string mGetShippingItemPath;
        private readonly KnetikCoroutine mGetShippingTemplateCoroutine;
        private DateTime mGetShippingTemplateStartTime;
        private string mGetShippingTemplatePath;
        private readonly KnetikCoroutine mGetShippingTemplatesCoroutine;
        private DateTime mGetShippingTemplatesStartTime;
        private string mGetShippingTemplatesPath;
        private readonly KnetikCoroutine mUpdateShippingItemCoroutine;
        private DateTime mUpdateShippingItemStartTime;
        private string mUpdateShippingItemPath;
        private readonly KnetikCoroutine mUpdateShippingTemplateCoroutine;
        private DateTime mUpdateShippingTemplateStartTime;
        private string mUpdateShippingTemplatePath;

        public ShippingItem CreateShippingItemData { get; private set; }
        public delegate void CreateShippingItemCompleteDelegate(ShippingItem response);
        public CreateShippingItemCompleteDelegate CreateShippingItemComplete;

        public ItemTemplateResource CreateShippingTemplateData { get; private set; }
        public delegate void CreateShippingTemplateCompleteDelegate(ItemTemplateResource response);
        public CreateShippingTemplateCompleteDelegate CreateShippingTemplateComplete;

        public delegate void DeleteShippingItemCompleteDelegate();
        public DeleteShippingItemCompleteDelegate DeleteShippingItemComplete;

        public delegate void DeleteShippingTemplateCompleteDelegate();
        public DeleteShippingTemplateCompleteDelegate DeleteShippingTemplateComplete;

        public ShippingItem GetShippingItemData { get; private set; }
        public delegate void GetShippingItemCompleteDelegate(ShippingItem response);
        public GetShippingItemCompleteDelegate GetShippingItemComplete;

        public ItemTemplateResource GetShippingTemplateData { get; private set; }
        public delegate void GetShippingTemplateCompleteDelegate(ItemTemplateResource response);
        public GetShippingTemplateCompleteDelegate GetShippingTemplateComplete;

        public PageResourceItemTemplateResource GetShippingTemplatesData { get; private set; }
        public delegate void GetShippingTemplatesCompleteDelegate(PageResourceItemTemplateResource response);
        public GetShippingTemplatesCompleteDelegate GetShippingTemplatesComplete;

        public ShippingItem UpdateShippingItemData { get; private set; }
        public delegate void UpdateShippingItemCompleteDelegate(ShippingItem response);
        public UpdateShippingItemCompleteDelegate UpdateShippingItemComplete;

        public ItemTemplateResource UpdateShippingTemplateData { get; private set; }
        public delegate void UpdateShippingTemplateCompleteDelegate(ItemTemplateResource response);
        public UpdateShippingTemplateCompleteDelegate UpdateShippingTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreShippingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreShippingApi()
        {
            mCreateShippingItemCoroutine = new KnetikCoroutine();
            mCreateShippingTemplateCoroutine = new KnetikCoroutine();
            mDeleteShippingItemCoroutine = new KnetikCoroutine();
            mDeleteShippingTemplateCoroutine = new KnetikCoroutine();
            mGetShippingItemCoroutine = new KnetikCoroutine();
            mGetShippingTemplateCoroutine = new KnetikCoroutine();
            mGetShippingTemplatesCoroutine = new KnetikCoroutine();
            mUpdateShippingItemCoroutine = new KnetikCoroutine();
            mUpdateShippingTemplateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a shipping item A shipping item represents a shipping option and cost. SKUs have to be unique in the entire store.
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="shippingItem">The shipping item object</param>
        public void CreateShippingItem(bool? cascade, ShippingItem shippingItem)
        {
            
            mCreateShippingItemPath = "/store/shipping";
            if (!string.IsNullOrEmpty(mCreateShippingItemPath))
            {
                mCreateShippingItemPath = mCreateShippingItemPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            postBody = KnetikClient.DefaultClient.Serialize(shippingItem); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateShippingItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateShippingItemStartTime, mCreateShippingItemPath, "Sending server request...");

            // make the HTTP request
            mCreateShippingItemCoroutine.ResponseReceived += CreateShippingItemCallback;
            mCreateShippingItemCoroutine.Start(mCreateShippingItemPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateShippingItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateShippingItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateShippingItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateShippingItemData = (ShippingItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ShippingItem), response.Headers);
            KnetikLogger.LogResponse(mCreateShippingItemStartTime, mCreateShippingItemPath, string.Format("Response received successfully:\n{0}", CreateShippingItemData.ToString()));

            if (CreateShippingItemComplete != null)
            {
                CreateShippingItemComplete(CreateShippingItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a shipping template Shipping Templates define a type of shipping and the properties they have.
        /// </summary>
        /// <param name="shippingTemplateResource">The new shipping template</param>
        public void CreateShippingTemplate(ItemTemplateResource shippingTemplateResource)
        {
            
            mCreateShippingTemplatePath = "/store/shipping/templates";
            if (!string.IsNullOrEmpty(mCreateShippingTemplatePath))
            {
                mCreateShippingTemplatePath = mCreateShippingTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(shippingTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateShippingTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateShippingTemplateStartTime, mCreateShippingTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateShippingTemplateCoroutine.ResponseReceived += CreateShippingTemplateCallback;
            mCreateShippingTemplateCoroutine.Start(mCreateShippingTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateShippingTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateShippingTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateShippingTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateShippingTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateShippingTemplateStartTime, mCreateShippingTemplatePath, string.Format("Response received successfully:\n{0}", CreateShippingTemplateData.ToString()));

            if (CreateShippingTemplateComplete != null)
            {
                CreateShippingTemplateComplete(CreateShippingTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a shipping item 
        /// </summary>
        /// <param name="id">The id of the shipping item</param>
        public void DeleteShippingItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteShippingItem");
            }
            
            mDeleteShippingItemPath = "/store/shipping/{id}";
            if (!string.IsNullOrEmpty(mDeleteShippingItemPath))
            {
                mDeleteShippingItemPath = mDeleteShippingItemPath.Replace("{format}", "json");
            }
            mDeleteShippingItemPath = mDeleteShippingItemPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteShippingItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteShippingItemStartTime, mDeleteShippingItemPath, "Sending server request...");

            // make the HTTP request
            mDeleteShippingItemCoroutine.ResponseReceived += DeleteShippingItemCallback;
            mDeleteShippingItemCoroutine.Start(mDeleteShippingItemPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteShippingItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteShippingItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteShippingItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteShippingItemStartTime, mDeleteShippingItemPath, "Response received successfully.");
            if (DeleteShippingItemComplete != null)
            {
                DeleteShippingItemComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a shipping template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        public void DeleteShippingTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteShippingTemplate");
            }
            
            mDeleteShippingTemplatePath = "/store/shipping/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteShippingTemplatePath))
            {
                mDeleteShippingTemplatePath = mDeleteShippingTemplatePath.Replace("{format}", "json");
            }
            mDeleteShippingTemplatePath = mDeleteShippingTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mDeleteShippingTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteShippingTemplateStartTime, mDeleteShippingTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteShippingTemplateCoroutine.ResponseReceived += DeleteShippingTemplateCallback;
            mDeleteShippingTemplateCoroutine.Start(mDeleteShippingTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteShippingTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteShippingTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteShippingTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteShippingTemplateStartTime, mDeleteShippingTemplatePath, "Response received successfully.");
            if (DeleteShippingTemplateComplete != null)
            {
                DeleteShippingTemplateComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single shipping item 
        /// </summary>
        /// <param name="id">The id of the shipping item</param>
        public void GetShippingItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetShippingItem");
            }
            
            mGetShippingItemPath = "/store/shipping/{id}";
            if (!string.IsNullOrEmpty(mGetShippingItemPath))
            {
                mGetShippingItemPath = mGetShippingItemPath.Replace("{format}", "json");
            }
            mGetShippingItemPath = mGetShippingItemPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mGetShippingItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetShippingItemStartTime, mGetShippingItemPath, "Sending server request...");

            // make the HTTP request
            mGetShippingItemCoroutine.ResponseReceived += GetShippingItemCallback;
            mGetShippingItemCoroutine.Start(mGetShippingItemPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetShippingItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetShippingItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetShippingItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetShippingItemData = (ShippingItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ShippingItem), response.Headers);
            KnetikLogger.LogResponse(mGetShippingItemStartTime, mGetShippingItemPath, string.Format("Response received successfully:\n{0}", GetShippingItemData.ToString()));

            if (GetShippingItemComplete != null)
            {
                GetShippingItemComplete(GetShippingItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single shipping template Shipping Templates define a type of shipping and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetShippingTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetShippingTemplate");
            }
            
            mGetShippingTemplatePath = "/store/shipping/templates/{id}";
            if (!string.IsNullOrEmpty(mGetShippingTemplatePath))
            {
                mGetShippingTemplatePath = mGetShippingTemplatePath.Replace("{format}", "json");
            }
            mGetShippingTemplatePath = mGetShippingTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetShippingTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetShippingTemplateStartTime, mGetShippingTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetShippingTemplateCoroutine.ResponseReceived += GetShippingTemplateCallback;
            mGetShippingTemplateCoroutine.Start(mGetShippingTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetShippingTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetShippingTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetShippingTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetShippingTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetShippingTemplateStartTime, mGetShippingTemplatePath, string.Format("Response received successfully:\n{0}", GetShippingTemplateData.ToString()));

            if (GetShippingTemplateComplete != null)
            {
                GetShippingTemplateComplete(GetShippingTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search shipping templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetShippingTemplates(int? size, int? page, string order)
        {
            
            mGetShippingTemplatesPath = "/store/shipping/templates";
            if (!string.IsNullOrEmpty(mGetShippingTemplatesPath))
            {
                mGetShippingTemplatesPath = mGetShippingTemplatesPath.Replace("{format}", "json");
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

            mGetShippingTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetShippingTemplatesStartTime, mGetShippingTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetShippingTemplatesCoroutine.ResponseReceived += GetShippingTemplatesCallback;
            mGetShippingTemplatesCoroutine.Start(mGetShippingTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetShippingTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetShippingTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetShippingTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetShippingTemplatesData = (PageResourceItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetShippingTemplatesStartTime, mGetShippingTemplatesPath, string.Format("Response received successfully:\n{0}", GetShippingTemplatesData.ToString()));

            if (GetShippingTemplatesComplete != null)
            {
                GetShippingTemplatesComplete(GetShippingTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a shipping item 
        /// </summary>
        /// <param name="id">The id of the shipping item</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="shippingItem">The shipping item object</param>
        public void UpdateShippingItem(int? id, bool? cascade, ShippingItem shippingItem)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateShippingItem");
            }
            
            mUpdateShippingItemPath = "/store/shipping/{id}";
            if (!string.IsNullOrEmpty(mUpdateShippingItemPath))
            {
                mUpdateShippingItemPath = mUpdateShippingItemPath.Replace("{format}", "json");
            }
            mUpdateShippingItemPath = mUpdateShippingItemPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            postBody = KnetikClient.DefaultClient.Serialize(shippingItem); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateShippingItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateShippingItemStartTime, mUpdateShippingItemPath, "Sending server request...");

            // make the HTTP request
            mUpdateShippingItemCoroutine.ResponseReceived += UpdateShippingItemCallback;
            mUpdateShippingItemCoroutine.Start(mUpdateShippingItemPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateShippingItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateShippingItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateShippingItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateShippingItemData = (ShippingItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ShippingItem), response.Headers);
            KnetikLogger.LogResponse(mUpdateShippingItemStartTime, mUpdateShippingItemPath, string.Format("Response received successfully:\n{0}", UpdateShippingItemData.ToString()));

            if (UpdateShippingItemComplete != null)
            {
                UpdateShippingItemComplete(UpdateShippingItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a shipping template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="shippingTemplateResource">The shipping template resource object</param>
        public void UpdateShippingTemplate(string id, ItemTemplateResource shippingTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateShippingTemplate");
            }
            
            mUpdateShippingTemplatePath = "/store/shipping/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateShippingTemplatePath))
            {
                mUpdateShippingTemplatePath = mUpdateShippingTemplatePath.Replace("{format}", "json");
            }
            mUpdateShippingTemplatePath = mUpdateShippingTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(shippingTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateShippingTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateShippingTemplateStartTime, mUpdateShippingTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateShippingTemplateCoroutine.ResponseReceived += UpdateShippingTemplateCallback;
            mUpdateShippingTemplateCoroutine.Start(mUpdateShippingTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateShippingTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateShippingTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateShippingTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateShippingTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateShippingTemplateStartTime, mUpdateShippingTemplatePath, string.Format("Response received successfully:\n{0}", UpdateShippingTemplateData.ToString()));

            if (UpdateShippingTemplateComplete != null)
            {
                UpdateShippingTemplateComplete(UpdateShippingTemplateData);
            }
        }

    }
}
