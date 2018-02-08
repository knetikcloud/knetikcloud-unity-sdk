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
    public interface IStoreBundlesApi
    {
        BundleItem CreateBundleItemData { get; }

        /// <summary>
        /// Create a bundle item The SKU for the bundle itself must be unique and there can only be one SKU.  Extra notes for price_override:  The price of all the items (multiplied by the quantity) must equal the price of the bundle.  With individual prices set, items will be processed individually and can be refunded as such.  However, if all prices are set to null, the price of the bundle will be used and will be treated as one item. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BUNDLES_ADMIN
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="bundleItem">The bundle item object</param>
        void CreateBundleItem(bool? cascade, BundleItem bundleItem);

        ItemTemplateResource CreateBundleTemplateData { get; }

        /// <summary>
        /// Create a bundle template Bundle Templates define a type of bundle and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BUNDLES_ADMIN
        /// </summary>
        /// <param name="bundleTemplateResource">The new bundle template</param>
        void CreateBundleTemplate(ItemTemplateResource bundleTemplateResource);

        

        /// <summary>
        /// Delete a bundle item &lt;b&gt;Permissions Needed:&lt;/b&gt; BUNDLES_ADMIN
        /// </summary>
        /// <param name="id">The id of the bundle</param>
        void DeleteBundleItem(int? id);

        

        /// <summary>
        /// Delete a bundle template &lt;b&gt;Permissions Needed:&lt;/b&gt; BUNDLES_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        void DeleteBundleTemplate(string id, string cascade);

        BundleItem GetBundleItemData { get; }

        /// <summary>
        /// Get a single bundle item &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id of the bundle</param>
        void GetBundleItem(int? id);

        ItemTemplateResource GetBundleTemplateData { get; }

        /// <summary>
        /// Get a single bundle template Bundle Templates define a type of bundle and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetBundleTemplate(string id);

        PageResourceItemTemplateResource GetBundleTemplatesData { get; }

        /// <summary>
        /// List and search bundle templates &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetBundleTemplates(int? size, int? page, string order);

        BundleItem UpdateBundleItemData { get; }

        /// <summary>
        /// Update a bundle item &lt;b&gt;Permissions Needed:&lt;/b&gt; BUNDLES_ADMIN
        /// </summary>
        /// <param name="id">The id of the bundle</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="bundleItem">The bundle item object</param>
        void UpdateBundleItem(int? id, bool? cascade, BundleItem bundleItem);

        ItemTemplateResource UpdateBundleTemplateData { get; }

        /// <summary>
        /// Update a bundle template &lt;b&gt;Permissions Needed:&lt;/b&gt; BUNDLES_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="bundleTemplateResource">The bundle template resource object</param>
        void UpdateBundleTemplate(string id, ItemTemplateResource bundleTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StoreBundlesApi : IStoreBundlesApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateBundleItemResponseContext;
        private DateTime mCreateBundleItemStartTime;
        private readonly KnetikResponseContext mCreateBundleTemplateResponseContext;
        private DateTime mCreateBundleTemplateStartTime;
        private readonly KnetikResponseContext mDeleteBundleItemResponseContext;
        private DateTime mDeleteBundleItemStartTime;
        private readonly KnetikResponseContext mDeleteBundleTemplateResponseContext;
        private DateTime mDeleteBundleTemplateStartTime;
        private readonly KnetikResponseContext mGetBundleItemResponseContext;
        private DateTime mGetBundleItemStartTime;
        private readonly KnetikResponseContext mGetBundleTemplateResponseContext;
        private DateTime mGetBundleTemplateStartTime;
        private readonly KnetikResponseContext mGetBundleTemplatesResponseContext;
        private DateTime mGetBundleTemplatesStartTime;
        private readonly KnetikResponseContext mUpdateBundleItemResponseContext;
        private DateTime mUpdateBundleItemStartTime;
        private readonly KnetikResponseContext mUpdateBundleTemplateResponseContext;
        private DateTime mUpdateBundleTemplateStartTime;

        public BundleItem CreateBundleItemData { get; private set; }
        public delegate void CreateBundleItemCompleteDelegate(long responseCode, BundleItem response);
        public CreateBundleItemCompleteDelegate CreateBundleItemComplete;

        public ItemTemplateResource CreateBundleTemplateData { get; private set; }
        public delegate void CreateBundleTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public CreateBundleTemplateCompleteDelegate CreateBundleTemplateComplete;

        public delegate void DeleteBundleItemCompleteDelegate(long responseCode);
        public DeleteBundleItemCompleteDelegate DeleteBundleItemComplete;

        public delegate void DeleteBundleTemplateCompleteDelegate(long responseCode);
        public DeleteBundleTemplateCompleteDelegate DeleteBundleTemplateComplete;

        public BundleItem GetBundleItemData { get; private set; }
        public delegate void GetBundleItemCompleteDelegate(long responseCode, BundleItem response);
        public GetBundleItemCompleteDelegate GetBundleItemComplete;

        public ItemTemplateResource GetBundleTemplateData { get; private set; }
        public delegate void GetBundleTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public GetBundleTemplateCompleteDelegate GetBundleTemplateComplete;

        public PageResourceItemTemplateResource GetBundleTemplatesData { get; private set; }
        public delegate void GetBundleTemplatesCompleteDelegate(long responseCode, PageResourceItemTemplateResource response);
        public GetBundleTemplatesCompleteDelegate GetBundleTemplatesComplete;

        public BundleItem UpdateBundleItemData { get; private set; }
        public delegate void UpdateBundleItemCompleteDelegate(long responseCode, BundleItem response);
        public UpdateBundleItemCompleteDelegate UpdateBundleItemComplete;

        public ItemTemplateResource UpdateBundleTemplateData { get; private set; }
        public delegate void UpdateBundleTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public UpdateBundleTemplateCompleteDelegate UpdateBundleTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreBundlesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreBundlesApi()
        {
            mCreateBundleItemResponseContext = new KnetikResponseContext();
            mCreateBundleItemResponseContext.ResponseReceived += OnCreateBundleItemResponse;
            mCreateBundleTemplateResponseContext = new KnetikResponseContext();
            mCreateBundleTemplateResponseContext.ResponseReceived += OnCreateBundleTemplateResponse;
            mDeleteBundleItemResponseContext = new KnetikResponseContext();
            mDeleteBundleItemResponseContext.ResponseReceived += OnDeleteBundleItemResponse;
            mDeleteBundleTemplateResponseContext = new KnetikResponseContext();
            mDeleteBundleTemplateResponseContext.ResponseReceived += OnDeleteBundleTemplateResponse;
            mGetBundleItemResponseContext = new KnetikResponseContext();
            mGetBundleItemResponseContext.ResponseReceived += OnGetBundleItemResponse;
            mGetBundleTemplateResponseContext = new KnetikResponseContext();
            mGetBundleTemplateResponseContext.ResponseReceived += OnGetBundleTemplateResponse;
            mGetBundleTemplatesResponseContext = new KnetikResponseContext();
            mGetBundleTemplatesResponseContext.ResponseReceived += OnGetBundleTemplatesResponse;
            mUpdateBundleItemResponseContext = new KnetikResponseContext();
            mUpdateBundleItemResponseContext.ResponseReceived += OnUpdateBundleItemResponse;
            mUpdateBundleTemplateResponseContext = new KnetikResponseContext();
            mUpdateBundleTemplateResponseContext.ResponseReceived += OnUpdateBundleTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a bundle item The SKU for the bundle itself must be unique and there can only be one SKU.  Extra notes for price_override:  The price of all the items (multiplied by the quantity) must equal the price of the bundle.  With individual prices set, items will be processed individually and can be refunded as such.  However, if all prices are set to null, the price of the bundle will be used and will be treated as one item. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BUNDLES_ADMIN
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="bundleItem">The bundle item object</param>
        public void CreateBundleItem(bool? cascade, BundleItem bundleItem)
        {
            
            mWebCallEvent.WebPath = "/store/bundles";
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

            mWebCallEvent.PostBody = KnetikClient.Serialize(bundleItem); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateBundleItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateBundleItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateBundleItemStartTime, "CreateBundleItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateBundleItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateBundleItem: " + response.Error);
            }

            CreateBundleItemData = (BundleItem) KnetikClient.Deserialize(response.Content, typeof(BundleItem), response.Headers);
            KnetikLogger.LogResponse(mCreateBundleItemStartTime, "CreateBundleItem", string.Format("Response received successfully:\n{0}", CreateBundleItemData));

            if (CreateBundleItemComplete != null)
            {
                CreateBundleItemComplete(response.ResponseCode, CreateBundleItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a bundle template Bundle Templates define a type of bundle and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BUNDLES_ADMIN
        /// </summary>
        /// <param name="bundleTemplateResource">The new bundle template</param>
        public void CreateBundleTemplate(ItemTemplateResource bundleTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/store/bundles/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(bundleTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateBundleTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateBundleTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateBundleTemplateStartTime, "CreateBundleTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateBundleTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateBundleTemplate: " + response.Error);
            }

            CreateBundleTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateBundleTemplateStartTime, "CreateBundleTemplate", string.Format("Response received successfully:\n{0}", CreateBundleTemplateData));

            if (CreateBundleTemplateComplete != null)
            {
                CreateBundleTemplateComplete(response.ResponseCode, CreateBundleTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a bundle item &lt;b&gt;Permissions Needed:&lt;/b&gt; BUNDLES_ADMIN
        /// </summary>
        /// <param name="id">The id of the bundle</param>
        public void DeleteBundleItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteBundleItem");
            }
            
            mWebCallEvent.WebPath = "/store/bundles/{id}";
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
            mDeleteBundleItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteBundleItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteBundleItemStartTime, "DeleteBundleItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteBundleItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteBundleItem: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteBundleItemStartTime, "DeleteBundleItem", "Response received successfully.");
            if (DeleteBundleItemComplete != null)
            {
                DeleteBundleItemComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a bundle template &lt;b&gt;Permissions Needed:&lt;/b&gt; BUNDLES_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        public void DeleteBundleTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteBundleTemplate");
            }
            
            mWebCallEvent.WebPath = "/store/bundles/templates/{id}";
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
            mDeleteBundleTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteBundleTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteBundleTemplateStartTime, "DeleteBundleTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteBundleTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteBundleTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteBundleTemplateStartTime, "DeleteBundleTemplate", "Response received successfully.");
            if (DeleteBundleTemplateComplete != null)
            {
                DeleteBundleTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single bundle item &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id of the bundle</param>
        public void GetBundleItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBundleItem");
            }
            
            mWebCallEvent.WebPath = "/store/bundles/{id}";
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
            mGetBundleItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBundleItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBundleItemStartTime, "GetBundleItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBundleItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBundleItem: " + response.Error);
            }

            GetBundleItemData = (BundleItem) KnetikClient.Deserialize(response.Content, typeof(BundleItem), response.Headers);
            KnetikLogger.LogResponse(mGetBundleItemStartTime, "GetBundleItem", string.Format("Response received successfully:\n{0}", GetBundleItemData));

            if (GetBundleItemComplete != null)
            {
                GetBundleItemComplete(response.ResponseCode, GetBundleItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single bundle template Bundle Templates define a type of bundle and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetBundleTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBundleTemplate");
            }
            
            mWebCallEvent.WebPath = "/store/bundles/templates/{id}";
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
            mGetBundleTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBundleTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBundleTemplateStartTime, "GetBundleTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBundleTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBundleTemplate: " + response.Error);
            }

            GetBundleTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetBundleTemplateStartTime, "GetBundleTemplate", string.Format("Response received successfully:\n{0}", GetBundleTemplateData));

            if (GetBundleTemplateComplete != null)
            {
                GetBundleTemplateComplete(response.ResponseCode, GetBundleTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search bundle templates &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetBundleTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/store/bundles/templates";
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
            mGetBundleTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBundleTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBundleTemplatesStartTime, "GetBundleTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBundleTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBundleTemplates: " + response.Error);
            }

            GetBundleTemplatesData = (PageResourceItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetBundleTemplatesStartTime, "GetBundleTemplates", string.Format("Response received successfully:\n{0}", GetBundleTemplatesData));

            if (GetBundleTemplatesComplete != null)
            {
                GetBundleTemplatesComplete(response.ResponseCode, GetBundleTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a bundle item &lt;b&gt;Permissions Needed:&lt;/b&gt; BUNDLES_ADMIN
        /// </summary>
        /// <param name="id">The id of the bundle</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="bundleItem">The bundle item object</param>
        public void UpdateBundleItem(int? id, bool? cascade, BundleItem bundleItem)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateBundleItem");
            }
            
            mWebCallEvent.WebPath = "/store/bundles/{id}";
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

            mWebCallEvent.PostBody = KnetikClient.Serialize(bundleItem); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateBundleItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateBundleItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateBundleItemStartTime, "UpdateBundleItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateBundleItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateBundleItem: " + response.Error);
            }

            UpdateBundleItemData = (BundleItem) KnetikClient.Deserialize(response.Content, typeof(BundleItem), response.Headers);
            KnetikLogger.LogResponse(mUpdateBundleItemStartTime, "UpdateBundleItem", string.Format("Response received successfully:\n{0}", UpdateBundleItemData));

            if (UpdateBundleItemComplete != null)
            {
                UpdateBundleItemComplete(response.ResponseCode, UpdateBundleItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a bundle template &lt;b&gt;Permissions Needed:&lt;/b&gt; BUNDLES_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="bundleTemplateResource">The bundle template resource object</param>
        public void UpdateBundleTemplate(string id, ItemTemplateResource bundleTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateBundleTemplate");
            }
            
            mWebCallEvent.WebPath = "/store/bundles/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(bundleTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateBundleTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateBundleTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateBundleTemplateStartTime, "UpdateBundleTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateBundleTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateBundleTemplate: " + response.Error);
            }

            UpdateBundleTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateBundleTemplateStartTime, "UpdateBundleTemplate", string.Format("Response received successfully:\n{0}", UpdateBundleTemplateData));

            if (UpdateBundleTemplateComplete != null)
            {
                UpdateBundleTemplateComplete(response.ResponseCode, UpdateBundleTemplateData);
            }
        }

    }
}
