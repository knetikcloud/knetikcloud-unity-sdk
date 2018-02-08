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
    public interface IStoreApi
    {
        StoreItemTemplateResource CreateItemTemplateData { get; }

        /// <summary>
        /// Create an item template Item Templates define a type of item and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="itemTemplateResource">The new item template</param>
        void CreateItemTemplate(StoreItemTemplateResource itemTemplateResource);

        StoreItem CreateStoreItemData { get; }

        /// <summary>
        /// Create a store item SKUs have to be unique in the entire store. If a duplicate SKU is found, a 400 error is generated and the response will have a \&quot;parameters\&quot; field that is a list of duplicates. A duplicate is an object like {item_id, offending_sku_list}. Ex:&lt;br /&gt; {..., parameters: [[{item: 1, skus: [\&quot;SKU-1\&quot;]}]]}&lt;br /&gt; If an item is brand new and has duplicate SKUs within itself, the item ID will be 0.  Item subclasses are not allowed here, you will have to use their respective endpoints. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; STORE_ADMIN
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="storeItem">The store item object</param>
        void CreateStoreItem(bool? cascade, StoreItem storeItem);

        

        /// <summary>
        /// Delete an item template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        void DeleteItemTemplate(string id, string cascade);

        

        /// <summary>
        /// Delete a store item &lt;b&gt;Permissions Needed:&lt;/b&gt; STORE_ADMIN
        /// </summary>
        /// <param name="id">The id of the item</param>
        void DeleteStoreItem(int? id);

        List<BehaviorDefinitionResource> GetBehaviorsData { get; }

        /// <summary>
        /// List available item behaviors &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        void GetBehaviors();

        StoreItemTemplateResource GetItemTemplateData { get; }

        /// <summary>
        /// Get a single item template Item Templates define a type of item and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetItemTemplate(string id);

        PageResourceStoreItemTemplateResource GetItemTemplatesData { get; }

        /// <summary>
        /// List and search item templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetItemTemplates(int? size, int? page, string order);

        StoreItem GetStoreItemData { get; }

        /// <summary>
        /// Get a single store item &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id of the item</param>
        void GetStoreItem(int? id);

        PageResourceStoreItem GetStoreItemsData { get; }

        /// <summary>
        /// List and search store items If called without permission STORE_ADMIN the only items marked displayable, whose start and end date are null or appropriate to the current date, and whose geo policy allows the caller&#39;s country will be returned. Similarly skus will be filtered, possibly resulting in an item returned with no skus the user can purchase. br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterNameSearch">Filter for items whose name starts with a given string.</param>
        /// <param name="filterUniqueKey">Filter for items whose unique_key is a given string.</param>
        /// <param name="filterPublished">Filter for skus that have been published.</param>
        /// <param name="filterDisplayable">Filter for items that are displayable.</param>
        /// <param name="filterStart">A comma separated string without spaces.  First value is the operator to search on, second value is the store start date, a unix timestamp in seconds.  Allowed operators: (LT, GT, LTE, GTE, EQ).</param>
        /// <param name="filterEnd">A comma separated string without spaces.  First value is the operator to search on, second value is the store end date, a unix timestamp in seconds.  Allowed operators: (LT, GT, LTE, GTE, EQ).</param>
        /// <param name="filterStartDate">A comma separated string without spaces.  First value is the operator to search on, second value is the sku start date, a unix timestamp in seconds.  Allowed operators: (LT, GT, LTE, GTE, EQ).</param>
        /// <param name="filterStopDate">A comma separated string without spaces.  First value is the operator to search on, second value is the sku end date, a unix timestamp in seconds.  Allowed operators: (LT, GT, LTE, GTE, EQ).</param>
        /// <param name="filterSku">Filter for skus whose name starts with a given string.</param>
        /// <param name="filterPrice">A colon separated string without spaces.  First value is the operator to search on, second value is the price of a sku.  Allowed operators: (LT, GT, LTE, GTE, EQ).</param>
        /// <param name="filterTag">A comma separated list without spaces of the names of tags. Will only return items with at least one of the tags.</param>
        /// <param name="filterItemsByType">Filter for item type based on its type hint.</param>
        /// <param name="filterBundledSkus">Filter for skus inside bundles whose name starts with a given string.  Used only when type hint is &#39;bundle_item&#39;</param>
        /// <param name="filterVendor">Filter for items from a given vendor, by id.</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetStoreItems(string filterNameSearch, string filterUniqueKey, bool? filterPublished, bool? filterDisplayable, string filterStart, string filterEnd, string filterStartDate, string filterStopDate, string filterSku, string filterPrice, string filterTag, string filterItemsByType, string filterBundledSkus, int? filterVendor, int? size, int? page, string order);

        InvoiceResource QuickBuyData { get; }

        /// <summary>
        /// One-step purchase and pay for a single SKU item from a user&#39;s wallet Used to create and automatically pay an invoice for a single unit of a single SKU from a user&#39;s wallet. SKU must be priced in virtual currency and must not be an item that requires shipping. PAYMENTS_ADMIN permission is required if user ID is specified and is not the ID of the currently logged in user. If invoice price does not match expected price, purchase is aborted. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; PAYMENTS_USER and owner, or PAYMENTS_ADMIN
        /// </summary>
        /// <param name="quickBuyRequest">Quick buy details</param>
        void QuickBuy(QuickBuyRequest quickBuyRequest);

        StoreItemTemplateResource UpdateItemTemplateData { get; }

        /// <summary>
        /// Update an item template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="itemTemplateResource">The item template resource object</param>
        void UpdateItemTemplate(string id, StoreItemTemplateResource itemTemplateResource);

        StoreItem UpdateStoreItemData { get; }

        /// <summary>
        /// Update a store item &lt;b&gt;Permissions Needed:&lt;/b&gt; STORE_ADMIN
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="storeItem">The store item object</param>
        void UpdateStoreItem(int? id, bool? cascade, StoreItem storeItem);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StoreApi : IStoreApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateItemTemplateResponseContext;
        private DateTime mCreateItemTemplateStartTime;
        private readonly KnetikResponseContext mCreateStoreItemResponseContext;
        private DateTime mCreateStoreItemStartTime;
        private readonly KnetikResponseContext mDeleteItemTemplateResponseContext;
        private DateTime mDeleteItemTemplateStartTime;
        private readonly KnetikResponseContext mDeleteStoreItemResponseContext;
        private DateTime mDeleteStoreItemStartTime;
        private readonly KnetikResponseContext mGetBehaviorsResponseContext;
        private DateTime mGetBehaviorsStartTime;
        private readonly KnetikResponseContext mGetItemTemplateResponseContext;
        private DateTime mGetItemTemplateStartTime;
        private readonly KnetikResponseContext mGetItemTemplatesResponseContext;
        private DateTime mGetItemTemplatesStartTime;
        private readonly KnetikResponseContext mGetStoreItemResponseContext;
        private DateTime mGetStoreItemStartTime;
        private readonly KnetikResponseContext mGetStoreItemsResponseContext;
        private DateTime mGetStoreItemsStartTime;
        private readonly KnetikResponseContext mQuickBuyResponseContext;
        private DateTime mQuickBuyStartTime;
        private readonly KnetikResponseContext mUpdateItemTemplateResponseContext;
        private DateTime mUpdateItemTemplateStartTime;
        private readonly KnetikResponseContext mUpdateStoreItemResponseContext;
        private DateTime mUpdateStoreItemStartTime;

        public StoreItemTemplateResource CreateItemTemplateData { get; private set; }
        public delegate void CreateItemTemplateCompleteDelegate(long responseCode, StoreItemTemplateResource response);
        public CreateItemTemplateCompleteDelegate CreateItemTemplateComplete;

        public StoreItem CreateStoreItemData { get; private set; }
        public delegate void CreateStoreItemCompleteDelegate(long responseCode, StoreItem response);
        public CreateStoreItemCompleteDelegate CreateStoreItemComplete;

        public delegate void DeleteItemTemplateCompleteDelegate(long responseCode);
        public DeleteItemTemplateCompleteDelegate DeleteItemTemplateComplete;

        public delegate void DeleteStoreItemCompleteDelegate(long responseCode);
        public DeleteStoreItemCompleteDelegate DeleteStoreItemComplete;

        public List<BehaviorDefinitionResource> GetBehaviorsData { get; private set; }
        public delegate void GetBehaviorsCompleteDelegate(long responseCode, List<BehaviorDefinitionResource> response);
        public GetBehaviorsCompleteDelegate GetBehaviorsComplete;

        public StoreItemTemplateResource GetItemTemplateData { get; private set; }
        public delegate void GetItemTemplateCompleteDelegate(long responseCode, StoreItemTemplateResource response);
        public GetItemTemplateCompleteDelegate GetItemTemplateComplete;

        public PageResourceStoreItemTemplateResource GetItemTemplatesData { get; private set; }
        public delegate void GetItemTemplatesCompleteDelegate(long responseCode, PageResourceStoreItemTemplateResource response);
        public GetItemTemplatesCompleteDelegate GetItemTemplatesComplete;

        public StoreItem GetStoreItemData { get; private set; }
        public delegate void GetStoreItemCompleteDelegate(long responseCode, StoreItem response);
        public GetStoreItemCompleteDelegate GetStoreItemComplete;

        public PageResourceStoreItem GetStoreItemsData { get; private set; }
        public delegate void GetStoreItemsCompleteDelegate(long responseCode, PageResourceStoreItem response);
        public GetStoreItemsCompleteDelegate GetStoreItemsComplete;

        public InvoiceResource QuickBuyData { get; private set; }
        public delegate void QuickBuyCompleteDelegate(long responseCode, InvoiceResource response);
        public QuickBuyCompleteDelegate QuickBuyComplete;

        public StoreItemTemplateResource UpdateItemTemplateData { get; private set; }
        public delegate void UpdateItemTemplateCompleteDelegate(long responseCode, StoreItemTemplateResource response);
        public UpdateItemTemplateCompleteDelegate UpdateItemTemplateComplete;

        public StoreItem UpdateStoreItemData { get; private set; }
        public delegate void UpdateStoreItemCompleteDelegate(long responseCode, StoreItem response);
        public UpdateStoreItemCompleteDelegate UpdateStoreItemComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreApi()
        {
            mCreateItemTemplateResponseContext = new KnetikResponseContext();
            mCreateItemTemplateResponseContext.ResponseReceived += OnCreateItemTemplateResponse;
            mCreateStoreItemResponseContext = new KnetikResponseContext();
            mCreateStoreItemResponseContext.ResponseReceived += OnCreateStoreItemResponse;
            mDeleteItemTemplateResponseContext = new KnetikResponseContext();
            mDeleteItemTemplateResponseContext.ResponseReceived += OnDeleteItemTemplateResponse;
            mDeleteStoreItemResponseContext = new KnetikResponseContext();
            mDeleteStoreItemResponseContext.ResponseReceived += OnDeleteStoreItemResponse;
            mGetBehaviorsResponseContext = new KnetikResponseContext();
            mGetBehaviorsResponseContext.ResponseReceived += OnGetBehaviorsResponse;
            mGetItemTemplateResponseContext = new KnetikResponseContext();
            mGetItemTemplateResponseContext.ResponseReceived += OnGetItemTemplateResponse;
            mGetItemTemplatesResponseContext = new KnetikResponseContext();
            mGetItemTemplatesResponseContext.ResponseReceived += OnGetItemTemplatesResponse;
            mGetStoreItemResponseContext = new KnetikResponseContext();
            mGetStoreItemResponseContext.ResponseReceived += OnGetStoreItemResponse;
            mGetStoreItemsResponseContext = new KnetikResponseContext();
            mGetStoreItemsResponseContext.ResponseReceived += OnGetStoreItemsResponse;
            mQuickBuyResponseContext = new KnetikResponseContext();
            mQuickBuyResponseContext.ResponseReceived += OnQuickBuyResponse;
            mUpdateItemTemplateResponseContext = new KnetikResponseContext();
            mUpdateItemTemplateResponseContext.ResponseReceived += OnUpdateItemTemplateResponse;
            mUpdateStoreItemResponseContext = new KnetikResponseContext();
            mUpdateStoreItemResponseContext.ResponseReceived += OnUpdateStoreItemResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create an item template Item Templates define a type of item and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="itemTemplateResource">The new item template</param>
        public void CreateItemTemplate(StoreItemTemplateResource itemTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/store/items/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(itemTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateItemTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateItemTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateItemTemplateStartTime, "CreateItemTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateItemTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateItemTemplate: " + response.Error);
            }

            CreateItemTemplateData = (StoreItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(StoreItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateItemTemplateStartTime, "CreateItemTemplate", string.Format("Response received successfully:\n{0}", CreateItemTemplateData));

            if (CreateItemTemplateComplete != null)
            {
                CreateItemTemplateComplete(response.ResponseCode, CreateItemTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a store item SKUs have to be unique in the entire store. If a duplicate SKU is found, a 400 error is generated and the response will have a \&quot;parameters\&quot; field that is a list of duplicates. A duplicate is an object like {item_id, offending_sku_list}. Ex:&lt;br /&gt; {..., parameters: [[{item: 1, skus: [\&quot;SKU-1\&quot;]}]]}&lt;br /&gt; If an item is brand new and has duplicate SKUs within itself, the item ID will be 0.  Item subclasses are not allowed here, you will have to use their respective endpoints. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; STORE_ADMIN
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="storeItem">The store item object</param>
        public void CreateStoreItem(bool? cascade, StoreItem storeItem)
        {
            
            mWebCallEvent.WebPath = "/store/items";
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

            mWebCallEvent.PostBody = KnetikClient.Serialize(storeItem); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateStoreItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateStoreItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateStoreItemStartTime, "CreateStoreItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateStoreItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateStoreItem: " + response.Error);
            }

            CreateStoreItemData = (StoreItem) KnetikClient.Deserialize(response.Content, typeof(StoreItem), response.Headers);
            KnetikLogger.LogResponse(mCreateStoreItemStartTime, "CreateStoreItem", string.Format("Response received successfully:\n{0}", CreateStoreItemData));

            if (CreateStoreItemComplete != null)
            {
                CreateStoreItemComplete(response.ResponseCode, CreateStoreItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an item template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        public void DeleteItemTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteItemTemplate");
            }
            
            mWebCallEvent.WebPath = "/store/items/templates/{id}";
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
            mDeleteItemTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteItemTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteItemTemplateStartTime, "DeleteItemTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteItemTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteItemTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteItemTemplateStartTime, "DeleteItemTemplate", "Response received successfully.");
            if (DeleteItemTemplateComplete != null)
            {
                DeleteItemTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a store item &lt;b&gt;Permissions Needed:&lt;/b&gt; STORE_ADMIN
        /// </summary>
        /// <param name="id">The id of the item</param>
        public void DeleteStoreItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteStoreItem");
            }
            
            mWebCallEvent.WebPath = "/store/items/{id}";
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
            mDeleteStoreItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteStoreItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteStoreItemStartTime, "DeleteStoreItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteStoreItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteStoreItem: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteStoreItemStartTime, "DeleteStoreItem", "Response received successfully.");
            if (DeleteStoreItemComplete != null)
            {
                DeleteStoreItemComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List available item behaviors &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        public void GetBehaviors()
        {
            
            mWebCallEvent.WebPath = "/store/items/behaviors";
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
            mGetBehaviorsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBehaviorsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBehaviorsStartTime, "GetBehaviors", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBehaviorsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBehaviors: " + response.Error);
            }

            GetBehaviorsData = (List<BehaviorDefinitionResource>) KnetikClient.Deserialize(response.Content, typeof(List<BehaviorDefinitionResource>), response.Headers);
            KnetikLogger.LogResponse(mGetBehaviorsStartTime, "GetBehaviors", string.Format("Response received successfully:\n{0}", GetBehaviorsData));

            if (GetBehaviorsComplete != null)
            {
                GetBehaviorsComplete(response.ResponseCode, GetBehaviorsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single item template Item Templates define a type of item and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetItemTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetItemTemplate");
            }
            
            mWebCallEvent.WebPath = "/store/items/templates/{id}";
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
            mGetItemTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetItemTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetItemTemplateStartTime, "GetItemTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetItemTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetItemTemplate: " + response.Error);
            }

            GetItemTemplateData = (StoreItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(StoreItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetItemTemplateStartTime, "GetItemTemplate", string.Format("Response received successfully:\n{0}", GetItemTemplateData));

            if (GetItemTemplateComplete != null)
            {
                GetItemTemplateComplete(response.ResponseCode, GetItemTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search item templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetItemTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/store/items/templates";
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
            mGetItemTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetItemTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetItemTemplatesStartTime, "GetItemTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetItemTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetItemTemplates: " + response.Error);
            }

            GetItemTemplatesData = (PageResourceStoreItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceStoreItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetItemTemplatesStartTime, "GetItemTemplates", string.Format("Response received successfully:\n{0}", GetItemTemplatesData));

            if (GetItemTemplatesComplete != null)
            {
                GetItemTemplatesComplete(response.ResponseCode, GetItemTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single store item &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id of the item</param>
        public void GetStoreItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetStoreItem");
            }
            
            mWebCallEvent.WebPath = "/store/items/{id}";
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
            mGetStoreItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetStoreItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetStoreItemStartTime, "GetStoreItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetStoreItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetStoreItem: " + response.Error);
            }

            GetStoreItemData = (StoreItem) KnetikClient.Deserialize(response.Content, typeof(StoreItem), response.Headers);
            KnetikLogger.LogResponse(mGetStoreItemStartTime, "GetStoreItem", string.Format("Response received successfully:\n{0}", GetStoreItemData));

            if (GetStoreItemComplete != null)
            {
                GetStoreItemComplete(response.ResponseCode, GetStoreItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search store items If called without permission STORE_ADMIN the only items marked displayable, whose start and end date are null or appropriate to the current date, and whose geo policy allows the caller&#39;s country will be returned. Similarly skus will be filtered, possibly resulting in an item returned with no skus the user can purchase. br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterNameSearch">Filter for items whose name starts with a given string.</param>
        /// <param name="filterUniqueKey">Filter for items whose unique_key is a given string.</param>
        /// <param name="filterPublished">Filter for skus that have been published.</param>
        /// <param name="filterDisplayable">Filter for items that are displayable.</param>
        /// <param name="filterStart">A comma separated string without spaces.  First value is the operator to search on, second value is the store start date, a unix timestamp in seconds.  Allowed operators: (LT, GT, LTE, GTE, EQ).</param>
        /// <param name="filterEnd">A comma separated string without spaces.  First value is the operator to search on, second value is the store end date, a unix timestamp in seconds.  Allowed operators: (LT, GT, LTE, GTE, EQ).</param>
        /// <param name="filterStartDate">A comma separated string without spaces.  First value is the operator to search on, second value is the sku start date, a unix timestamp in seconds.  Allowed operators: (LT, GT, LTE, GTE, EQ).</param>
        /// <param name="filterStopDate">A comma separated string without spaces.  First value is the operator to search on, second value is the sku end date, a unix timestamp in seconds.  Allowed operators: (LT, GT, LTE, GTE, EQ).</param>
        /// <param name="filterSku">Filter for skus whose name starts with a given string.</param>
        /// <param name="filterPrice">A colon separated string without spaces.  First value is the operator to search on, second value is the price of a sku.  Allowed operators: (LT, GT, LTE, GTE, EQ).</param>
        /// <param name="filterTag">A comma separated list without spaces of the names of tags. Will only return items with at least one of the tags.</param>
        /// <param name="filterItemsByType">Filter for item type based on its type hint.</param>
        /// <param name="filterBundledSkus">Filter for skus inside bundles whose name starts with a given string.  Used only when type hint is &#39;bundle_item&#39;</param>
        /// <param name="filterVendor">Filter for items from a given vendor, by id.</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetStoreItems(string filterNameSearch, string filterUniqueKey, bool? filterPublished, bool? filterDisplayable, string filterStart, string filterEnd, string filterStartDate, string filterStopDate, string filterSku, string filterPrice, string filterTag, string filterItemsByType, string filterBundledSkus, int? filterVendor, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/store/items";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterNameSearch != null)
            {
                mWebCallEvent.QueryParams["filter_name_search"] = KnetikClient.ParameterToString(filterNameSearch);
            }

            if (filterUniqueKey != null)
            {
                mWebCallEvent.QueryParams["filter_unique_key"] = KnetikClient.ParameterToString(filterUniqueKey);
            }

            if (filterPublished != null)
            {
                mWebCallEvent.QueryParams["filter_published"] = KnetikClient.ParameterToString(filterPublished);
            }

            if (filterDisplayable != null)
            {
                mWebCallEvent.QueryParams["filter_displayable"] = KnetikClient.ParameterToString(filterDisplayable);
            }

            if (filterStart != null)
            {
                mWebCallEvent.QueryParams["filter_start"] = KnetikClient.ParameterToString(filterStart);
            }

            if (filterEnd != null)
            {
                mWebCallEvent.QueryParams["filter_end"] = KnetikClient.ParameterToString(filterEnd);
            }

            if (filterStartDate != null)
            {
                mWebCallEvent.QueryParams["filter_start_date"] = KnetikClient.ParameterToString(filterStartDate);
            }

            if (filterStopDate != null)
            {
                mWebCallEvent.QueryParams["filter_stop_date"] = KnetikClient.ParameterToString(filterStopDate);
            }

            if (filterSku != null)
            {
                mWebCallEvent.QueryParams["filter_sku"] = KnetikClient.ParameterToString(filterSku);
            }

            if (filterPrice != null)
            {
                mWebCallEvent.QueryParams["filter_price"] = KnetikClient.ParameterToString(filterPrice);
            }

            if (filterTag != null)
            {
                mWebCallEvent.QueryParams["filter_tag"] = KnetikClient.ParameterToString(filterTag);
            }

            if (filterItemsByType != null)
            {
                mWebCallEvent.QueryParams["filter_items_by_type"] = KnetikClient.ParameterToString(filterItemsByType);
            }

            if (filterBundledSkus != null)
            {
                mWebCallEvent.QueryParams["filter_bundled_skus"] = KnetikClient.ParameterToString(filterBundledSkus);
            }

            if (filterVendor != null)
            {
                mWebCallEvent.QueryParams["filter_vendor"] = KnetikClient.ParameterToString(filterVendor);
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
            mGetStoreItemsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetStoreItemsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetStoreItemsStartTime, "GetStoreItems", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetStoreItemsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetStoreItems: " + response.Error);
            }

            GetStoreItemsData = (PageResourceStoreItem) KnetikClient.Deserialize(response.Content, typeof(PageResourceStoreItem), response.Headers);
            KnetikLogger.LogResponse(mGetStoreItemsStartTime, "GetStoreItems", string.Format("Response received successfully:\n{0}", GetStoreItemsData));

            if (GetStoreItemsComplete != null)
            {
                GetStoreItemsComplete(response.ResponseCode, GetStoreItemsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// One-step purchase and pay for a single SKU item from a user&#39;s wallet Used to create and automatically pay an invoice for a single unit of a single SKU from a user&#39;s wallet. SKU must be priced in virtual currency and must not be an item that requires shipping. PAYMENTS_ADMIN permission is required if user ID is specified and is not the ID of the currently logged in user. If invoice price does not match expected price, purchase is aborted. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; PAYMENTS_USER and owner, or PAYMENTS_ADMIN
        /// </summary>
        /// <param name="quickBuyRequest">Quick buy details</param>
        public void QuickBuy(QuickBuyRequest quickBuyRequest)
        {
            
            mWebCallEvent.WebPath = "/store/quick-buy";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(quickBuyRequest); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mQuickBuyStartTime = DateTime.Now;
            mWebCallEvent.Context = mQuickBuyResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mQuickBuyStartTime, "QuickBuy", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnQuickBuyResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling QuickBuy: " + response.Error);
            }

            QuickBuyData = (InvoiceResource) KnetikClient.Deserialize(response.Content, typeof(InvoiceResource), response.Headers);
            KnetikLogger.LogResponse(mQuickBuyStartTime, "QuickBuy", string.Format("Response received successfully:\n{0}", QuickBuyData));

            if (QuickBuyComplete != null)
            {
                QuickBuyComplete(response.ResponseCode, QuickBuyData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an item template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="itemTemplateResource">The item template resource object</param>
        public void UpdateItemTemplate(string id, StoreItemTemplateResource itemTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateItemTemplate");
            }
            
            mWebCallEvent.WebPath = "/store/items/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(itemTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateItemTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateItemTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateItemTemplateStartTime, "UpdateItemTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateItemTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateItemTemplate: " + response.Error);
            }

            UpdateItemTemplateData = (StoreItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(StoreItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateItemTemplateStartTime, "UpdateItemTemplate", string.Format("Response received successfully:\n{0}", UpdateItemTemplateData));

            if (UpdateItemTemplateComplete != null)
            {
                UpdateItemTemplateComplete(response.ResponseCode, UpdateItemTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a store item &lt;b&gt;Permissions Needed:&lt;/b&gt; STORE_ADMIN
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="storeItem">The store item object</param>
        public void UpdateStoreItem(int? id, bool? cascade, StoreItem storeItem)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateStoreItem");
            }
            
            mWebCallEvent.WebPath = "/store/items/{id}";
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

            mWebCallEvent.PostBody = KnetikClient.Serialize(storeItem); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateStoreItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateStoreItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateStoreItemStartTime, "UpdateStoreItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateStoreItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateStoreItem: " + response.Error);
            }

            UpdateStoreItemData = (StoreItem) KnetikClient.Deserialize(response.Content, typeof(StoreItem), response.Headers);
            KnetikLogger.LogResponse(mUpdateStoreItemStartTime, "UpdateStoreItem", string.Format("Response received successfully:\n{0}", UpdateStoreItemData));

            if (UpdateStoreItemComplete != null)
            {
                UpdateStoreItemComplete(response.ResponseCode, UpdateStoreItemData);
            }
        }

    }
}
