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
    public interface IStoreShippingApi
    {
        ShippingItem CreateShippingItemData { get; }

        /// <summary>
        /// Create a shipping item A shipping item represents a shipping option and cost. SKUs have to be unique in the entire store.
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="shippingItem">The shipping item object</param>
        void CreateShippingItem(bool? cascade, ShippingItem shippingItem);

        ItemTemplateResource CreateShippingTemplateData { get; }

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

        ShippingItem GetShippingItemData { get; }

        /// <summary>
        /// Get a single shipping item 
        /// </summary>
        /// <param name="id">The id of the shipping item</param>
        void GetShippingItem(int? id);

        ItemTemplateResource GetShippingTemplateData { get; }

        /// <summary>
        /// Get a single shipping template Shipping Templates define a type of shipping and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetShippingTemplate(string id);

        PageResourceItemTemplateResource GetShippingTemplatesData { get; }

        /// <summary>
        /// List and search shipping templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetShippingTemplates(int? size, int? page, string order);

        ShippingItem UpdateShippingItemData { get; }

        /// <summary>
        /// Update a shipping item 
        /// </summary>
        /// <param name="id">The id of the shipping item</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="shippingItem">The shipping item object</param>
        void UpdateShippingItem(int? id, bool? cascade, ShippingItem shippingItem);

        ItemTemplateResource UpdateShippingTemplateData { get; }

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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateShippingItemResponseContext;
        private DateTime mCreateShippingItemStartTime;
        private readonly KnetikResponseContext mCreateShippingTemplateResponseContext;
        private DateTime mCreateShippingTemplateStartTime;
        private readonly KnetikResponseContext mDeleteShippingItemResponseContext;
        private DateTime mDeleteShippingItemStartTime;
        private readonly KnetikResponseContext mDeleteShippingTemplateResponseContext;
        private DateTime mDeleteShippingTemplateStartTime;
        private readonly KnetikResponseContext mGetShippingItemResponseContext;
        private DateTime mGetShippingItemStartTime;
        private readonly KnetikResponseContext mGetShippingTemplateResponseContext;
        private DateTime mGetShippingTemplateStartTime;
        private readonly KnetikResponseContext mGetShippingTemplatesResponseContext;
        private DateTime mGetShippingTemplatesStartTime;
        private readonly KnetikResponseContext mUpdateShippingItemResponseContext;
        private DateTime mUpdateShippingItemStartTime;
        private readonly KnetikResponseContext mUpdateShippingTemplateResponseContext;
        private DateTime mUpdateShippingTemplateStartTime;

        public ShippingItem CreateShippingItemData { get; private set; }
        public delegate void CreateShippingItemCompleteDelegate(long responseCode, ShippingItem response);
        public CreateShippingItemCompleteDelegate CreateShippingItemComplete;

        public ItemTemplateResource CreateShippingTemplateData { get; private set; }
        public delegate void CreateShippingTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public CreateShippingTemplateCompleteDelegate CreateShippingTemplateComplete;

        public delegate void DeleteShippingItemCompleteDelegate(long responseCode);
        public DeleteShippingItemCompleteDelegate DeleteShippingItemComplete;

        public delegate void DeleteShippingTemplateCompleteDelegate(long responseCode);
        public DeleteShippingTemplateCompleteDelegate DeleteShippingTemplateComplete;

        public ShippingItem GetShippingItemData { get; private set; }
        public delegate void GetShippingItemCompleteDelegate(long responseCode, ShippingItem response);
        public GetShippingItemCompleteDelegate GetShippingItemComplete;

        public ItemTemplateResource GetShippingTemplateData { get; private set; }
        public delegate void GetShippingTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public GetShippingTemplateCompleteDelegate GetShippingTemplateComplete;

        public PageResourceItemTemplateResource GetShippingTemplatesData { get; private set; }
        public delegate void GetShippingTemplatesCompleteDelegate(long responseCode, PageResourceItemTemplateResource response);
        public GetShippingTemplatesCompleteDelegate GetShippingTemplatesComplete;

        public ShippingItem UpdateShippingItemData { get; private set; }
        public delegate void UpdateShippingItemCompleteDelegate(long responseCode, ShippingItem response);
        public UpdateShippingItemCompleteDelegate UpdateShippingItemComplete;

        public ItemTemplateResource UpdateShippingTemplateData { get; private set; }
        public delegate void UpdateShippingTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public UpdateShippingTemplateCompleteDelegate UpdateShippingTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreShippingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreShippingApi()
        {
            mCreateShippingItemResponseContext = new KnetikResponseContext();
            mCreateShippingItemResponseContext.ResponseReceived += OnCreateShippingItemResponse;
            mCreateShippingTemplateResponseContext = new KnetikResponseContext();
            mCreateShippingTemplateResponseContext.ResponseReceived += OnCreateShippingTemplateResponse;
            mDeleteShippingItemResponseContext = new KnetikResponseContext();
            mDeleteShippingItemResponseContext.ResponseReceived += OnDeleteShippingItemResponse;
            mDeleteShippingTemplateResponseContext = new KnetikResponseContext();
            mDeleteShippingTemplateResponseContext.ResponseReceived += OnDeleteShippingTemplateResponse;
            mGetShippingItemResponseContext = new KnetikResponseContext();
            mGetShippingItemResponseContext.ResponseReceived += OnGetShippingItemResponse;
            mGetShippingTemplateResponseContext = new KnetikResponseContext();
            mGetShippingTemplateResponseContext.ResponseReceived += OnGetShippingTemplateResponse;
            mGetShippingTemplatesResponseContext = new KnetikResponseContext();
            mGetShippingTemplatesResponseContext.ResponseReceived += OnGetShippingTemplatesResponse;
            mUpdateShippingItemResponseContext = new KnetikResponseContext();
            mUpdateShippingItemResponseContext.ResponseReceived += OnUpdateShippingItemResponse;
            mUpdateShippingTemplateResponseContext = new KnetikResponseContext();
            mUpdateShippingTemplateResponseContext.ResponseReceived += OnUpdateShippingTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a shipping item A shipping item represents a shipping option and cost. SKUs have to be unique in the entire store.
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="shippingItem">The shipping item object</param>
        public void CreateShippingItem(bool? cascade, ShippingItem shippingItem)
        {
            
            mWebCallEvent.WebPath = "/store/shipping";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (cascade != null)
            {
                mWebCallEvent.QueryParams["cascade"] = KnetikClient.ParameterToString(cascade);
            }

            mWebCallEvent.PostBody = KnetikClient.Serialize(shippingItem); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateShippingItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateShippingItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateShippingItemStartTime, "CreateShippingItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateShippingItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateShippingItem: " + response.Error);
            }

            CreateShippingItemData = (ShippingItem) KnetikClient.Deserialize(response.Content, typeof(ShippingItem), response.Headers);
            KnetikLogger.LogResponse(mCreateShippingItemStartTime, "CreateShippingItem", string.Format("Response received successfully:\n{0}", CreateShippingItemData));

            if (CreateShippingItemComplete != null)
            {
                CreateShippingItemComplete(response.ResponseCode, CreateShippingItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a shipping template Shipping Templates define a type of shipping and the properties they have.
        /// </summary>
        /// <param name="shippingTemplateResource">The new shipping template</param>
        public void CreateShippingTemplate(ItemTemplateResource shippingTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/store/shipping/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(shippingTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateShippingTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateShippingTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateShippingTemplateStartTime, "CreateShippingTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateShippingTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateShippingTemplate: " + response.Error);
            }

            CreateShippingTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateShippingTemplateStartTime, "CreateShippingTemplate", string.Format("Response received successfully:\n{0}", CreateShippingTemplateData));

            if (CreateShippingTemplateComplete != null)
            {
                CreateShippingTemplateComplete(response.ResponseCode, CreateShippingTemplateData);
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
            
            mWebCallEvent.WebPath = "/store/shipping/{id}";
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
            mDeleteShippingItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteShippingItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteShippingItemStartTime, "DeleteShippingItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteShippingItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteShippingItem: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteShippingItemStartTime, "DeleteShippingItem", "Response received successfully.");
            if (DeleteShippingItemComplete != null)
            {
                DeleteShippingItemComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/store/shipping/templates/{id}";
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
            mDeleteShippingTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteShippingTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteShippingTemplateStartTime, "DeleteShippingTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteShippingTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteShippingTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteShippingTemplateStartTime, "DeleteShippingTemplate", "Response received successfully.");
            if (DeleteShippingTemplateComplete != null)
            {
                DeleteShippingTemplateComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/store/shipping/{id}";
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
            mGetShippingItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetShippingItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetShippingItemStartTime, "GetShippingItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetShippingItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetShippingItem: " + response.Error);
            }

            GetShippingItemData = (ShippingItem) KnetikClient.Deserialize(response.Content, typeof(ShippingItem), response.Headers);
            KnetikLogger.LogResponse(mGetShippingItemStartTime, "GetShippingItem", string.Format("Response received successfully:\n{0}", GetShippingItemData));

            if (GetShippingItemComplete != null)
            {
                GetShippingItemComplete(response.ResponseCode, GetShippingItemData);
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
            
            mWebCallEvent.WebPath = "/store/shipping/templates/{id}";
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
            mGetShippingTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetShippingTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetShippingTemplateStartTime, "GetShippingTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetShippingTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetShippingTemplate: " + response.Error);
            }

            GetShippingTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetShippingTemplateStartTime, "GetShippingTemplate", string.Format("Response received successfully:\n{0}", GetShippingTemplateData));

            if (GetShippingTemplateComplete != null)
            {
                GetShippingTemplateComplete(response.ResponseCode, GetShippingTemplateData);
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
            
            mWebCallEvent.WebPath = "/store/shipping/templates";
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
            mGetShippingTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetShippingTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetShippingTemplatesStartTime, "GetShippingTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetShippingTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetShippingTemplates: " + response.Error);
            }

            GetShippingTemplatesData = (PageResourceItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetShippingTemplatesStartTime, "GetShippingTemplates", string.Format("Response received successfully:\n{0}", GetShippingTemplatesData));

            if (GetShippingTemplatesComplete != null)
            {
                GetShippingTemplatesComplete(response.ResponseCode, GetShippingTemplatesData);
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
            
            mWebCallEvent.WebPath = "/store/shipping/{id}";
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

            mWebCallEvent.PostBody = KnetikClient.Serialize(shippingItem); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateShippingItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateShippingItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateShippingItemStartTime, "UpdateShippingItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateShippingItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateShippingItem: " + response.Error);
            }

            UpdateShippingItemData = (ShippingItem) KnetikClient.Deserialize(response.Content, typeof(ShippingItem), response.Headers);
            KnetikLogger.LogResponse(mUpdateShippingItemStartTime, "UpdateShippingItem", string.Format("Response received successfully:\n{0}", UpdateShippingItemData));

            if (UpdateShippingItemComplete != null)
            {
                UpdateShippingItemComplete(response.ResponseCode, UpdateShippingItemData);
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
            
            mWebCallEvent.WebPath = "/store/shipping/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(shippingTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateShippingTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateShippingTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateShippingTemplateStartTime, "UpdateShippingTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateShippingTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateShippingTemplate: " + response.Error);
            }

            UpdateShippingTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateShippingTemplateStartTime, "UpdateShippingTemplate", string.Format("Response received successfully:\n{0}", UpdateShippingTemplateData));

            if (UpdateShippingTemplateComplete != null)
            {
                UpdateShippingTemplateComplete(response.ResponseCode, UpdateShippingTemplateData);
            }
        }

    }
}
