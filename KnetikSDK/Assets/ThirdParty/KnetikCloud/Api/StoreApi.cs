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
    public interface IStoreApi
    {
        /// <summary>
        /// Create an item template Item Templates define a type of item and the properties they have.
        /// </summary>
        /// <param name="itemTemplateResource">The new item template</param>
        /// <returns>StoreItemTemplateResource</returns>
        StoreItemTemplateResource CreateItemTemplate (StoreItemTemplateResource itemTemplateResource);
        /// <summary>
        /// Create a store item SKUs have to be unique in the entire store. If a duplicate SKU is found, a 400 error is generated and the response will have a \&quot;parameters\&quot; field that is a list of duplicates. A duplicate is an object like {item_id, offending_sku_list}. Ex:&lt;br /&gt; {..., parameters: [[{item: 1, skus: [\&quot;SKU-1\&quot;]}]]}&lt;br /&gt; If an item is brand new and has duplicate SKUs within itself, the item ID will be 0.  Item subclasses are not allowed here, you will have to use their respective endpoints.
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="storeItem">The store item object</param>
        /// <returns>StoreItem</returns>
        StoreItem CreateStoreItem (bool? cascade, StoreItem storeItem);
        /// <summary>
        /// Delete an item template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        /// <returns></returns>
        void DeleteItemTemplate (string id, string cascade);
        /// <summary>
        /// Delete a store item 
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <returns></returns>
        void DeleteStoreItem (int? id);
        /// <summary>
        /// List available item behaviors 
        /// </summary>
        /// <returns>List&lt;BehaviorDefinitionResource&gt;</returns>
        List<BehaviorDefinitionResource> GetBehaviors ();
        /// <summary>
        /// Get a single item template Item Templates define a type of item and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <returns>StoreItemTemplateResource</returns>
        StoreItemTemplateResource GetItemTemplate (string id);
        /// <summary>
        /// List and search item templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceStoreItemTemplateResource</returns>
        PageResourceStoreItemTemplateResource GetItemTemplates (int? size, int? page, string order);
        /// <summary>
        /// Get a listing of store items The exact structure of each items may differ to include fields specific to the type. The same is true for behaviors.
        /// </summary>
        /// <param name="limit">The amount of items returned</param>
        /// <param name="page">The page of the request</param>
        /// <param name="useCatalog">Whether to remove items that are not intended for display or not in date</param>
        /// <param name="ignoreLocation">Whether to ignore country restrictions based on the caller&#39;s location</param>
        /// <param name="inStockOnly">Whether only in-stock items should be returned.  Default value is false</param>
        /// <returns>PageResourceStoreItem</returns>
        PageResourceStoreItem GetStore (int? limit, int? page, bool? useCatalog, bool? ignoreLocation, bool? inStockOnly);
        /// <summary>
        /// Get a single store item 
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <returns>StoreItem</returns>
        StoreItem GetStoreItem (int? id);
        /// <summary>
        /// List and search store items 
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
        /// <returns>PageResourceStoreItem</returns>
        PageResourceStoreItem GetStoreItems (string filterNameSearch, string filterUniqueKey, bool? filterPublished, bool? filterDisplayable, string filterStart, string filterEnd, string filterStartDate, string filterStopDate, string filterSku, string filterPrice, string filterTag, string filterItemsByType, string filterBundledSkus, int? filterVendor, int? size, int? page, string order);
        /// <summary>
        /// One-step purchase and pay for a single SKU item from a user&#39;s wallet Used to create and automatically pay an invoice for a single unit of a single SKU from a user&#39;s wallet. SKU must be priced in virtual currency and must not be an item that requires shipping. PAYMENTS_ADMIN permission is required if user ID is specified and is not the ID of the currently logged in user. If invoice price does not match expected price, purchase is aborted
        /// </summary>
        /// <param name="quickBuyRequest">Quick buy details</param>
        /// <returns>InvoiceResource</returns>
        InvoiceResource QuickBuy (QuickBuyRequest quickBuyRequest);
        /// <summary>
        /// Update an item template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="itemTemplateResource">The item template resource object</param>
        /// <returns>StoreItemTemplateResource</returns>
        StoreItemTemplateResource UpdateItemTemplate (string id, StoreItemTemplateResource itemTemplateResource);
        /// <summary>
        /// Update a store item 
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="storeItem">The store item object</param>
        /// <returns>StoreItem</returns>
        StoreItem UpdateStoreItem (int? id, bool? cascade, StoreItem storeItem);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StoreApi : IStoreApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create an item template Item Templates define a type of item and the properties they have.
        /// </summary>
        /// <param name="itemTemplateResource">The new item template</param> 
        /// <returns>StoreItemTemplateResource</returns>            
        public StoreItemTemplateResource CreateItemTemplate(StoreItemTemplateResource itemTemplateResource)
        {
            
            string urlPath = "/store/items/templates";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(itemTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateItemTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateItemTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (StoreItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(StoreItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// Create a store item SKUs have to be unique in the entire store. If a duplicate SKU is found, a 400 error is generated and the response will have a \&quot;parameters\&quot; field that is a list of duplicates. A duplicate is an object like {item_id, offending_sku_list}. Ex:&lt;br /&gt; {..., parameters: [[{item: 1, skus: [\&quot;SKU-1\&quot;]}]]}&lt;br /&gt; If an item is brand new and has duplicate SKUs within itself, the item ID will be 0.  Item subclasses are not allowed here, you will have to use their respective endpoints.
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param> 
        /// <param name="storeItem">The store item object</param> 
        /// <returns>StoreItem</returns>            
        public StoreItem CreateStoreItem(bool? cascade, StoreItem storeItem)
        {
            
            string urlPath = "/store/items";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.ParameterToString(cascade));
            }
            
            postBody = KnetikClient.Serialize(storeItem); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateStoreItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateStoreItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (StoreItem) KnetikClient.Deserialize(response.Content, typeof(StoreItem), response.Headers);
        }
        /// <summary>
        /// Delete an item template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param> 
        /// <returns></returns>            
        public void DeleteItemTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteItemTemplate");
            }
            
            
            string urlPath = "/store/items/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.ParameterToString(cascade));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteItemTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteItemTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete a store item 
        /// </summary>
        /// <param name="id">The id of the item</param> 
        /// <returns></returns>            
        public void DeleteStoreItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteStoreItem");
            }
            
            
            string urlPath = "/store/items/{id}";
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
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteStoreItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteStoreItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// List available item behaviors 
        /// </summary>
        /// <returns>List&lt;BehaviorDefinitionResource&gt;</returns>            
        public List<BehaviorDefinitionResource> GetBehaviors()
        {
            
            string urlPath = "/store/items/behaviors";
            //urlPath = urlPath.Replace("{format}", "json");
                
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBehaviors: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBehaviors: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<BehaviorDefinitionResource>) KnetikClient.Deserialize(response.Content, typeof(List<BehaviorDefinitionResource>), response.Headers);
        }
        /// <summary>
        /// Get a single item template Item Templates define a type of item and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <returns>StoreItemTemplateResource</returns>            
        public StoreItemTemplateResource GetItemTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetItemTemplate");
            }
            
            
            string urlPath = "/store/items/templates/{id}";
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
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetItemTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetItemTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (StoreItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(StoreItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// List and search item templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceStoreItemTemplateResource</returns>            
        public PageResourceStoreItemTemplateResource GetItemTemplates(int? size, int? page, string order)
        {
            
            string urlPath = "/store/items/templates";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetItemTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetItemTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceStoreItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceStoreItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// Get a listing of store items The exact structure of each items may differ to include fields specific to the type. The same is true for behaviors.
        /// </summary>
        /// <param name="limit">The amount of items returned</param> 
        /// <param name="page">The page of the request</param> 
        /// <param name="useCatalog">Whether to remove items that are not intended for display or not in date</param> 
        /// <param name="ignoreLocation">Whether to ignore country restrictions based on the caller&#39;s location</param> 
        /// <param name="inStockOnly">Whether only in-stock items should be returned.  Default value is false</param> 
        /// <returns>PageResourceStoreItem</returns>            
        public PageResourceStoreItem GetStore(int? limit, int? page, bool? useCatalog, bool? ignoreLocation, bool? inStockOnly)
        {
            
            string urlPath = "/store";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (limit != null)
            {
                queryParams.Add("limit", KnetikClient.ParameterToString(limit));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (useCatalog != null)
            {
                queryParams.Add("use_catalog", KnetikClient.ParameterToString(useCatalog));
            }
            
            if (ignoreLocation != null)
            {
                queryParams.Add("ignore_location", KnetikClient.ParameterToString(ignoreLocation));
            }
            
            if (inStockOnly != null)
            {
                queryParams.Add("in_stock_only", KnetikClient.ParameterToString(inStockOnly));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetStore: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetStore: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceStoreItem) KnetikClient.Deserialize(response.Content, typeof(PageResourceStoreItem), response.Headers);
        }
        /// <summary>
        /// Get a single store item 
        /// </summary>
        /// <param name="id">The id of the item</param> 
        /// <returns>StoreItem</returns>            
        public StoreItem GetStoreItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetStoreItem");
            }
            
            
            string urlPath = "/store/items/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetStoreItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetStoreItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (StoreItem) KnetikClient.Deserialize(response.Content, typeof(StoreItem), response.Headers);
        }
        /// <summary>
        /// List and search store items 
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
        /// <returns>PageResourceStoreItem</returns>            
        public PageResourceStoreItem GetStoreItems(string filterNameSearch, string filterUniqueKey, bool? filterPublished, bool? filterDisplayable, string filterStart, string filterEnd, string filterStartDate, string filterStopDate, string filterSku, string filterPrice, string filterTag, string filterItemsByType, string filterBundledSkus, int? filterVendor, int? size, int? page, string order)
        {
            
            string urlPath = "/store/items";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterNameSearch != null)
            {
                queryParams.Add("filter_name_search", KnetikClient.ParameterToString(filterNameSearch));
            }
            
            if (filterUniqueKey != null)
            {
                queryParams.Add("filter_unique_key", KnetikClient.ParameterToString(filterUniqueKey));
            }
            
            if (filterPublished != null)
            {
                queryParams.Add("filter_published", KnetikClient.ParameterToString(filterPublished));
            }
            
            if (filterDisplayable != null)
            {
                queryParams.Add("filter_displayable", KnetikClient.ParameterToString(filterDisplayable));
            }
            
            if (filterStart != null)
            {
                queryParams.Add("filter_start", KnetikClient.ParameterToString(filterStart));
            }
            
            if (filterEnd != null)
            {
                queryParams.Add("filter_end", KnetikClient.ParameterToString(filterEnd));
            }
            
            if (filterStartDate != null)
            {
                queryParams.Add("filter_start_date", KnetikClient.ParameterToString(filterStartDate));
            }
            
            if (filterStopDate != null)
            {
                queryParams.Add("filter_stop_date", KnetikClient.ParameterToString(filterStopDate));
            }
            
            if (filterSku != null)
            {
                queryParams.Add("filter_sku", KnetikClient.ParameterToString(filterSku));
            }
            
            if (filterPrice != null)
            {
                queryParams.Add("filter_price", KnetikClient.ParameterToString(filterPrice));
            }
            
            if (filterTag != null)
            {
                queryParams.Add("filter_tag", KnetikClient.ParameterToString(filterTag));
            }
            
            if (filterItemsByType != null)
            {
                queryParams.Add("filter_items_by_type", KnetikClient.ParameterToString(filterItemsByType));
            }
            
            if (filterBundledSkus != null)
            {
                queryParams.Add("filter_bundled_skus", KnetikClient.ParameterToString(filterBundledSkus));
            }
            
            if (filterVendor != null)
            {
                queryParams.Add("filter_vendor", KnetikClient.ParameterToString(filterVendor));
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetStoreItems: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetStoreItems: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceStoreItem) KnetikClient.Deserialize(response.Content, typeof(PageResourceStoreItem), response.Headers);
        }
        /// <summary>
        /// One-step purchase and pay for a single SKU item from a user&#39;s wallet Used to create and automatically pay an invoice for a single unit of a single SKU from a user&#39;s wallet. SKU must be priced in virtual currency and must not be an item that requires shipping. PAYMENTS_ADMIN permission is required if user ID is specified and is not the ID of the currently logged in user. If invoice price does not match expected price, purchase is aborted
        /// </summary>
        /// <param name="quickBuyRequest">Quick buy details</param> 
        /// <returns>InvoiceResource</returns>            
        public InvoiceResource QuickBuy(QuickBuyRequest quickBuyRequest)
        {
            
            string urlPath = "/store/quick-buy";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(quickBuyRequest); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling QuickBuy: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling QuickBuy: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (InvoiceResource) KnetikClient.Deserialize(response.Content, typeof(InvoiceResource), response.Headers);
        }
        /// <summary>
        /// Update an item template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="itemTemplateResource">The item template resource object</param> 
        /// <returns>StoreItemTemplateResource</returns>            
        public StoreItemTemplateResource UpdateItemTemplate(string id, StoreItemTemplateResource itemTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateItemTemplate");
            }
            
            
            string urlPath = "/store/items/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(itemTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateItemTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateItemTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (StoreItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(StoreItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// Update a store item 
        /// </summary>
        /// <param name="id">The id of the item</param> 
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param> 
        /// <param name="storeItem">The store item object</param> 
        /// <returns>StoreItem</returns>            
        public StoreItem UpdateStoreItem(int? id, bool? cascade, StoreItem storeItem)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateStoreItem");
            }
            
            
            string urlPath = "/store/items/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.ParameterToString(cascade));
            }
            
            postBody = KnetikClient.Serialize(storeItem); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateStoreItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateStoreItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (StoreItem) KnetikClient.Deserialize(response.Content, typeof(StoreItem), response.Headers);
        }
    }
}
