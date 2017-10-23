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
    public interface IStoreApi
    {
        StoreItemTemplateResource CreateItemTemplateData { get; }

        StoreItem CreateStoreItemData { get; }

        List<BehaviorDefinitionResource> GetBehaviorsData { get; }

        StoreItemTemplateResource GetItemTemplateData { get; }

        PageResourceStoreItemTemplateResource GetItemTemplatesData { get; }

        StoreItem GetStoreItemData { get; }

        PageResourceStoreItem GetStoreItemsData { get; }

        InvoiceResource QuickBuyData { get; }

        StoreItemTemplateResource UpdateItemTemplateData { get; }

        StoreItem UpdateStoreItemData { get; }

        
        /// <summary>
        /// Create an item template Item Templates define a type of item and the properties they have.
        /// </summary>
        /// <param name="itemTemplateResource">The new item template</param>
        void CreateItemTemplate(StoreItemTemplateResource itemTemplateResource);

        /// <summary>
        /// Create a store item SKUs have to be unique in the entire store. If a duplicate SKU is found, a 400 error is generated and the response will have a \&quot;parameters\&quot; field that is a list of duplicates. A duplicate is an object like {item_id, offending_sku_list}. Ex:&lt;br /&gt; {..., parameters: [[{item: 1, skus: [\&quot;SKU-1\&quot;]}]]}&lt;br /&gt; If an item is brand new and has duplicate SKUs within itself, the item ID will be 0.  Item subclasses are not allowed here, you will have to use their respective endpoints.
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="storeItem">The store item object</param>
        void CreateStoreItem(bool? cascade, StoreItem storeItem);

        /// <summary>
        /// Delete an item template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        void DeleteItemTemplate(string id, string cascade);

        /// <summary>
        /// Delete a store item 
        /// </summary>
        /// <param name="id">The id of the item</param>
        void DeleteStoreItem(int? id);

        /// <summary>
        /// List available item behaviors 
        /// </summary>
        void GetBehaviors();

        /// <summary>
        /// Get a single item template Item Templates define a type of item and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetItemTemplate(string id);

        /// <summary>
        /// List and search item templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetItemTemplates(int? size, int? page, string order);

        /// <summary>
        /// Get a single store item 
        /// </summary>
        /// <param name="id">The id of the item</param>
        void GetStoreItem(int? id);

        /// <summary>
        /// List and search store items If called without permission STORE_ADMIN the only items marked displayable, whose start and end date are null or appropriate to the current date, and whose geo policy allows the caller&#39;s country will be returned. Similarly skus will be filtered, possibly resulting in an item returned with no skus the user can purchase.
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

        /// <summary>
        /// One-step purchase and pay for a single SKU item from a user&#39;s wallet Used to create and automatically pay an invoice for a single unit of a single SKU from a user&#39;s wallet. SKU must be priced in virtual currency and must not be an item that requires shipping. PAYMENTS_ADMIN permission is required if user ID is specified and is not the ID of the currently logged in user. If invoice price does not match expected price, purchase is aborted
        /// </summary>
        /// <param name="quickBuyRequest">Quick buy details</param>
        void QuickBuy(QuickBuyRequest quickBuyRequest);

        /// <summary>
        /// Update an item template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="itemTemplateResource">The item template resource object</param>
        void UpdateItemTemplate(string id, StoreItemTemplateResource itemTemplateResource);

        /// <summary>
        /// Update a store item 
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
        private readonly KnetikCoroutine mCreateItemTemplateCoroutine;
        private DateTime mCreateItemTemplateStartTime;
        private string mCreateItemTemplatePath;
        private readonly KnetikCoroutine mCreateStoreItemCoroutine;
        private DateTime mCreateStoreItemStartTime;
        private string mCreateStoreItemPath;
        private readonly KnetikCoroutine mDeleteItemTemplateCoroutine;
        private DateTime mDeleteItemTemplateStartTime;
        private string mDeleteItemTemplatePath;
        private readonly KnetikCoroutine mDeleteStoreItemCoroutine;
        private DateTime mDeleteStoreItemStartTime;
        private string mDeleteStoreItemPath;
        private readonly KnetikCoroutine mGetBehaviorsCoroutine;
        private DateTime mGetBehaviorsStartTime;
        private string mGetBehaviorsPath;
        private readonly KnetikCoroutine mGetItemTemplateCoroutine;
        private DateTime mGetItemTemplateStartTime;
        private string mGetItemTemplatePath;
        private readonly KnetikCoroutine mGetItemTemplatesCoroutine;
        private DateTime mGetItemTemplatesStartTime;
        private string mGetItemTemplatesPath;
        private readonly KnetikCoroutine mGetStoreItemCoroutine;
        private DateTime mGetStoreItemStartTime;
        private string mGetStoreItemPath;
        private readonly KnetikCoroutine mGetStoreItemsCoroutine;
        private DateTime mGetStoreItemsStartTime;
        private string mGetStoreItemsPath;
        private readonly KnetikCoroutine mQuickBuyCoroutine;
        private DateTime mQuickBuyStartTime;
        private string mQuickBuyPath;
        private readonly KnetikCoroutine mUpdateItemTemplateCoroutine;
        private DateTime mUpdateItemTemplateStartTime;
        private string mUpdateItemTemplatePath;
        private readonly KnetikCoroutine mUpdateStoreItemCoroutine;
        private DateTime mUpdateStoreItemStartTime;
        private string mUpdateStoreItemPath;

        public StoreItemTemplateResource CreateItemTemplateData { get; private set; }
        public delegate void CreateItemTemplateCompleteDelegate(StoreItemTemplateResource response);
        public CreateItemTemplateCompleteDelegate CreateItemTemplateComplete;

        public StoreItem CreateStoreItemData { get; private set; }
        public delegate void CreateStoreItemCompleteDelegate(StoreItem response);
        public CreateStoreItemCompleteDelegate CreateStoreItemComplete;

        public delegate void DeleteItemTemplateCompleteDelegate();
        public DeleteItemTemplateCompleteDelegate DeleteItemTemplateComplete;

        public delegate void DeleteStoreItemCompleteDelegate();
        public DeleteStoreItemCompleteDelegate DeleteStoreItemComplete;

        public List<BehaviorDefinitionResource> GetBehaviorsData { get; private set; }
        public delegate void GetBehaviorsCompleteDelegate(List<BehaviorDefinitionResource> response);
        public GetBehaviorsCompleteDelegate GetBehaviorsComplete;

        public StoreItemTemplateResource GetItemTemplateData { get; private set; }
        public delegate void GetItemTemplateCompleteDelegate(StoreItemTemplateResource response);
        public GetItemTemplateCompleteDelegate GetItemTemplateComplete;

        public PageResourceStoreItemTemplateResource GetItemTemplatesData { get; private set; }
        public delegate void GetItemTemplatesCompleteDelegate(PageResourceStoreItemTemplateResource response);
        public GetItemTemplatesCompleteDelegate GetItemTemplatesComplete;

        public StoreItem GetStoreItemData { get; private set; }
        public delegate void GetStoreItemCompleteDelegate(StoreItem response);
        public GetStoreItemCompleteDelegate GetStoreItemComplete;

        public PageResourceStoreItem GetStoreItemsData { get; private set; }
        public delegate void GetStoreItemsCompleteDelegate(PageResourceStoreItem response);
        public GetStoreItemsCompleteDelegate GetStoreItemsComplete;

        public InvoiceResource QuickBuyData { get; private set; }
        public delegate void QuickBuyCompleteDelegate(InvoiceResource response);
        public QuickBuyCompleteDelegate QuickBuyComplete;

        public StoreItemTemplateResource UpdateItemTemplateData { get; private set; }
        public delegate void UpdateItemTemplateCompleteDelegate(StoreItemTemplateResource response);
        public UpdateItemTemplateCompleteDelegate UpdateItemTemplateComplete;

        public StoreItem UpdateStoreItemData { get; private set; }
        public delegate void UpdateStoreItemCompleteDelegate(StoreItem response);
        public UpdateStoreItemCompleteDelegate UpdateStoreItemComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreApi()
        {
            mCreateItemTemplateCoroutine = new KnetikCoroutine();
            mCreateStoreItemCoroutine = new KnetikCoroutine();
            mDeleteItemTemplateCoroutine = new KnetikCoroutine();
            mDeleteStoreItemCoroutine = new KnetikCoroutine();
            mGetBehaviorsCoroutine = new KnetikCoroutine();
            mGetItemTemplateCoroutine = new KnetikCoroutine();
            mGetItemTemplatesCoroutine = new KnetikCoroutine();
            mGetStoreItemCoroutine = new KnetikCoroutine();
            mGetStoreItemsCoroutine = new KnetikCoroutine();
            mQuickBuyCoroutine = new KnetikCoroutine();
            mUpdateItemTemplateCoroutine = new KnetikCoroutine();
            mUpdateStoreItemCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create an item template Item Templates define a type of item and the properties they have.
        /// </summary>
        /// <param name="itemTemplateResource">The new item template</param>
        public void CreateItemTemplate(StoreItemTemplateResource itemTemplateResource)
        {
            
            mCreateItemTemplatePath = "/store/items/templates";
            if (!string.IsNullOrEmpty(mCreateItemTemplatePath))
            {
                mCreateItemTemplatePath = mCreateItemTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(itemTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateItemTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateItemTemplateStartTime, mCreateItemTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateItemTemplateCoroutine.ResponseReceived += CreateItemTemplateCallback;
            mCreateItemTemplateCoroutine.Start(mCreateItemTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateItemTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateItemTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateItemTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateItemTemplateData = (StoreItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(StoreItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateItemTemplateStartTime, mCreateItemTemplatePath, string.Format("Response received successfully:\n{0}", CreateItemTemplateData.ToString()));

            if (CreateItemTemplateComplete != null)
            {
                CreateItemTemplateComplete(CreateItemTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a store item SKUs have to be unique in the entire store. If a duplicate SKU is found, a 400 error is generated and the response will have a \&quot;parameters\&quot; field that is a list of duplicates. A duplicate is an object like {item_id, offending_sku_list}. Ex:&lt;br /&gt; {..., parameters: [[{item: 1, skus: [\&quot;SKU-1\&quot;]}]]}&lt;br /&gt; If an item is brand new and has duplicate SKUs within itself, the item ID will be 0.  Item subclasses are not allowed here, you will have to use their respective endpoints.
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="storeItem">The store item object</param>
        public void CreateStoreItem(bool? cascade, StoreItem storeItem)
        {
            
            mCreateStoreItemPath = "/store/items";
            if (!string.IsNullOrEmpty(mCreateStoreItemPath))
            {
                mCreateStoreItemPath = mCreateStoreItemPath.Replace("{format}", "json");
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

            postBody = KnetikClient.DefaultClient.Serialize(storeItem); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateStoreItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateStoreItemStartTime, mCreateStoreItemPath, "Sending server request...");

            // make the HTTP request
            mCreateStoreItemCoroutine.ResponseReceived += CreateStoreItemCallback;
            mCreateStoreItemCoroutine.Start(mCreateStoreItemPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateStoreItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateStoreItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateStoreItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateStoreItemData = (StoreItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(StoreItem), response.Headers);
            KnetikLogger.LogResponse(mCreateStoreItemStartTime, mCreateStoreItemPath, string.Format("Response received successfully:\n{0}", CreateStoreItemData.ToString()));

            if (CreateStoreItemComplete != null)
            {
                CreateStoreItemComplete(CreateStoreItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an item template 
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
            
            mDeleteItemTemplatePath = "/store/items/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteItemTemplatePath))
            {
                mDeleteItemTemplatePath = mDeleteItemTemplatePath.Replace("{format}", "json");
            }
            mDeleteItemTemplatePath = mDeleteItemTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteItemTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteItemTemplateStartTime, mDeleteItemTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteItemTemplateCoroutine.ResponseReceived += DeleteItemTemplateCallback;
            mDeleteItemTemplateCoroutine.Start(mDeleteItemTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteItemTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteItemTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteItemTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteItemTemplateStartTime, mDeleteItemTemplatePath, "Response received successfully.");
            if (DeleteItemTemplateComplete != null)
            {
                DeleteItemTemplateComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a store item 
        /// </summary>
        /// <param name="id">The id of the item</param>
        public void DeleteStoreItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteStoreItem");
            }
            
            mDeleteStoreItemPath = "/store/items/{id}";
            if (!string.IsNullOrEmpty(mDeleteStoreItemPath))
            {
                mDeleteStoreItemPath = mDeleteStoreItemPath.Replace("{format}", "json");
            }
            mDeleteStoreItemPath = mDeleteStoreItemPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteStoreItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteStoreItemStartTime, mDeleteStoreItemPath, "Sending server request...");

            // make the HTTP request
            mDeleteStoreItemCoroutine.ResponseReceived += DeleteStoreItemCallback;
            mDeleteStoreItemCoroutine.Start(mDeleteStoreItemPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteStoreItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteStoreItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteStoreItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteStoreItemStartTime, mDeleteStoreItemPath, "Response received successfully.");
            if (DeleteStoreItemComplete != null)
            {
                DeleteStoreItemComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List available item behaviors 
        /// </summary>
        public void GetBehaviors()
        {
            
            mGetBehaviorsPath = "/store/items/behaviors";
            if (!string.IsNullOrEmpty(mGetBehaviorsPath))
            {
                mGetBehaviorsPath = mGetBehaviorsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBehaviorsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBehaviorsStartTime, mGetBehaviorsPath, "Sending server request...");

            // make the HTTP request
            mGetBehaviorsCoroutine.ResponseReceived += GetBehaviorsCallback;
            mGetBehaviorsCoroutine.Start(mGetBehaviorsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBehaviorsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBehaviors: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBehaviors: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBehaviorsData = (List<BehaviorDefinitionResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<BehaviorDefinitionResource>), response.Headers);
            KnetikLogger.LogResponse(mGetBehaviorsStartTime, mGetBehaviorsPath, string.Format("Response received successfully:\n{0}", GetBehaviorsData.ToString()));

            if (GetBehaviorsComplete != null)
            {
                GetBehaviorsComplete(GetBehaviorsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single item template Item Templates define a type of item and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetItemTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetItemTemplate");
            }
            
            mGetItemTemplatePath = "/store/items/templates/{id}";
            if (!string.IsNullOrEmpty(mGetItemTemplatePath))
            {
                mGetItemTemplatePath = mGetItemTemplatePath.Replace("{format}", "json");
            }
            mGetItemTemplatePath = mGetItemTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetItemTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetItemTemplateStartTime, mGetItemTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetItemTemplateCoroutine.ResponseReceived += GetItemTemplateCallback;
            mGetItemTemplateCoroutine.Start(mGetItemTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetItemTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetItemTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetItemTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetItemTemplateData = (StoreItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(StoreItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetItemTemplateStartTime, mGetItemTemplatePath, string.Format("Response received successfully:\n{0}", GetItemTemplateData.ToString()));

            if (GetItemTemplateComplete != null)
            {
                GetItemTemplateComplete(GetItemTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search item templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetItemTemplates(int? size, int? page, string order)
        {
            
            mGetItemTemplatesPath = "/store/items/templates";
            if (!string.IsNullOrEmpty(mGetItemTemplatesPath))
            {
                mGetItemTemplatesPath = mGetItemTemplatesPath.Replace("{format}", "json");
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetItemTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetItemTemplatesStartTime, mGetItemTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetItemTemplatesCoroutine.ResponseReceived += GetItemTemplatesCallback;
            mGetItemTemplatesCoroutine.Start(mGetItemTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetItemTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetItemTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetItemTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetItemTemplatesData = (PageResourceStoreItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceStoreItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetItemTemplatesStartTime, mGetItemTemplatesPath, string.Format("Response received successfully:\n{0}", GetItemTemplatesData.ToString()));

            if (GetItemTemplatesComplete != null)
            {
                GetItemTemplatesComplete(GetItemTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single store item 
        /// </summary>
        /// <param name="id">The id of the item</param>
        public void GetStoreItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetStoreItem");
            }
            
            mGetStoreItemPath = "/store/items/{id}";
            if (!string.IsNullOrEmpty(mGetStoreItemPath))
            {
                mGetStoreItemPath = mGetStoreItemPath.Replace("{format}", "json");
            }
            mGetStoreItemPath = mGetStoreItemPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetStoreItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetStoreItemStartTime, mGetStoreItemPath, "Sending server request...");

            // make the HTTP request
            mGetStoreItemCoroutine.ResponseReceived += GetStoreItemCallback;
            mGetStoreItemCoroutine.Start(mGetStoreItemPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetStoreItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetStoreItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetStoreItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetStoreItemData = (StoreItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(StoreItem), response.Headers);
            KnetikLogger.LogResponse(mGetStoreItemStartTime, mGetStoreItemPath, string.Format("Response received successfully:\n{0}", GetStoreItemData.ToString()));

            if (GetStoreItemComplete != null)
            {
                GetStoreItemComplete(GetStoreItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search store items If called without permission STORE_ADMIN the only items marked displayable, whose start and end date are null or appropriate to the current date, and whose geo policy allows the caller&#39;s country will be returned. Similarly skus will be filtered, possibly resulting in an item returned with no skus the user can purchase.
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
            
            mGetStoreItemsPath = "/store/items";
            if (!string.IsNullOrEmpty(mGetStoreItemsPath))
            {
                mGetStoreItemsPath = mGetStoreItemsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterNameSearch != null)
            {
                queryParams.Add("filter_name_search", KnetikClient.DefaultClient.ParameterToString(filterNameSearch));
            }

            if (filterUniqueKey != null)
            {
                queryParams.Add("filter_unique_key", KnetikClient.DefaultClient.ParameterToString(filterUniqueKey));
            }

            if (filterPublished != null)
            {
                queryParams.Add("filter_published", KnetikClient.DefaultClient.ParameterToString(filterPublished));
            }

            if (filterDisplayable != null)
            {
                queryParams.Add("filter_displayable", KnetikClient.DefaultClient.ParameterToString(filterDisplayable));
            }

            if (filterStart != null)
            {
                queryParams.Add("filter_start", KnetikClient.DefaultClient.ParameterToString(filterStart));
            }

            if (filterEnd != null)
            {
                queryParams.Add("filter_end", KnetikClient.DefaultClient.ParameterToString(filterEnd));
            }

            if (filterStartDate != null)
            {
                queryParams.Add("filter_start_date", KnetikClient.DefaultClient.ParameterToString(filterStartDate));
            }

            if (filterStopDate != null)
            {
                queryParams.Add("filter_stop_date", KnetikClient.DefaultClient.ParameterToString(filterStopDate));
            }

            if (filterSku != null)
            {
                queryParams.Add("filter_sku", KnetikClient.DefaultClient.ParameterToString(filterSku));
            }

            if (filterPrice != null)
            {
                queryParams.Add("filter_price", KnetikClient.DefaultClient.ParameterToString(filterPrice));
            }

            if (filterTag != null)
            {
                queryParams.Add("filter_tag", KnetikClient.DefaultClient.ParameterToString(filterTag));
            }

            if (filterItemsByType != null)
            {
                queryParams.Add("filter_items_by_type", KnetikClient.DefaultClient.ParameterToString(filterItemsByType));
            }

            if (filterBundledSkus != null)
            {
                queryParams.Add("filter_bundled_skus", KnetikClient.DefaultClient.ParameterToString(filterBundledSkus));
            }

            if (filterVendor != null)
            {
                queryParams.Add("filter_vendor", KnetikClient.DefaultClient.ParameterToString(filterVendor));
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

            mGetStoreItemsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetStoreItemsStartTime, mGetStoreItemsPath, "Sending server request...");

            // make the HTTP request
            mGetStoreItemsCoroutine.ResponseReceived += GetStoreItemsCallback;
            mGetStoreItemsCoroutine.Start(mGetStoreItemsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetStoreItemsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetStoreItems: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetStoreItems: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetStoreItemsData = (PageResourceStoreItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceStoreItem), response.Headers);
            KnetikLogger.LogResponse(mGetStoreItemsStartTime, mGetStoreItemsPath, string.Format("Response received successfully:\n{0}", GetStoreItemsData.ToString()));

            if (GetStoreItemsComplete != null)
            {
                GetStoreItemsComplete(GetStoreItemsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// One-step purchase and pay for a single SKU item from a user&#39;s wallet Used to create and automatically pay an invoice for a single unit of a single SKU from a user&#39;s wallet. SKU must be priced in virtual currency and must not be an item that requires shipping. PAYMENTS_ADMIN permission is required if user ID is specified and is not the ID of the currently logged in user. If invoice price does not match expected price, purchase is aborted
        /// </summary>
        /// <param name="quickBuyRequest">Quick buy details</param>
        public void QuickBuy(QuickBuyRequest quickBuyRequest)
        {
            
            mQuickBuyPath = "/store/quick-buy";
            if (!string.IsNullOrEmpty(mQuickBuyPath))
            {
                mQuickBuyPath = mQuickBuyPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(quickBuyRequest); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mQuickBuyStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mQuickBuyStartTime, mQuickBuyPath, "Sending server request...");

            // make the HTTP request
            mQuickBuyCoroutine.ResponseReceived += QuickBuyCallback;
            mQuickBuyCoroutine.Start(mQuickBuyPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void QuickBuyCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling QuickBuy: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling QuickBuy: " + response.ErrorMessage, response.ErrorMessage);
            }

            QuickBuyData = (InvoiceResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(InvoiceResource), response.Headers);
            KnetikLogger.LogResponse(mQuickBuyStartTime, mQuickBuyPath, string.Format("Response received successfully:\n{0}", QuickBuyData.ToString()));

            if (QuickBuyComplete != null)
            {
                QuickBuyComplete(QuickBuyData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an item template 
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
            
            mUpdateItemTemplatePath = "/store/items/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateItemTemplatePath))
            {
                mUpdateItemTemplatePath = mUpdateItemTemplatePath.Replace("{format}", "json");
            }
            mUpdateItemTemplatePath = mUpdateItemTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(itemTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateItemTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateItemTemplateStartTime, mUpdateItemTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateItemTemplateCoroutine.ResponseReceived += UpdateItemTemplateCallback;
            mUpdateItemTemplateCoroutine.Start(mUpdateItemTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateItemTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateItemTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateItemTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateItemTemplateData = (StoreItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(StoreItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateItemTemplateStartTime, mUpdateItemTemplatePath, string.Format("Response received successfully:\n{0}", UpdateItemTemplateData.ToString()));

            if (UpdateItemTemplateComplete != null)
            {
                UpdateItemTemplateComplete(UpdateItemTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a store item 
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
            
            mUpdateStoreItemPath = "/store/items/{id}";
            if (!string.IsNullOrEmpty(mUpdateStoreItemPath))
            {
                mUpdateStoreItemPath = mUpdateStoreItemPath.Replace("{format}", "json");
            }
            mUpdateStoreItemPath = mUpdateStoreItemPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            postBody = KnetikClient.DefaultClient.Serialize(storeItem); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateStoreItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateStoreItemStartTime, mUpdateStoreItemPath, "Sending server request...");

            // make the HTTP request
            mUpdateStoreItemCoroutine.ResponseReceived += UpdateStoreItemCallback;
            mUpdateStoreItemCoroutine.Start(mUpdateStoreItemPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateStoreItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateStoreItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateStoreItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateStoreItemData = (StoreItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(StoreItem), response.Headers);
            KnetikLogger.LogResponse(mUpdateStoreItemStartTime, mUpdateStoreItemPath, string.Format("Response received successfully:\n{0}", UpdateStoreItemData.ToString()));

            if (UpdateStoreItemComplete != null)
            {
                UpdateStoreItemComplete(UpdateStoreItemData);
            }
        }

    }
}
