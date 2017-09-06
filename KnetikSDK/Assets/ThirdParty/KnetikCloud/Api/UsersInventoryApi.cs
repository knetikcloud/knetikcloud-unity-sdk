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
    public interface IUsersInventoryApi
    {
        /// <summary>
        /// Adds an item to the user inventory The inventory is fulfilled asynchronously UNLESS the invoice is explicitely skipped. Depending on the use case, it might require the client to verify that the entitlement was added after the fact or configure a BRE rule to get a notification in real time
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="userInventoryAddRequest">The user inventory add request object</param>
        /// <returns>InvoiceResource</returns>
        InvoiceResource AddItemToUserInventory (int? id, UserInventoryAddRequest userInventoryAddRequest);
        /// <summary>
        /// Check for access to an item without consuming Useful for pre-check and accounts for all various buisness rules
        /// </summary>
        /// <param name="userId">The id of the user to check for or &#39;me&#39; for logged in user</param>
        /// <param name="itemId">The id of the item</param>
        /// <param name="sku">The specific sku of an entitlement list addition to check entitlement for. This is of very limited and specific use and should generally be left out</param>
        /// <returns></returns>
        void CheckUserEntitlementItem (string userId, int? itemId, string sku);
        /// <summary>
        /// Create an entitlement item 
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="entitlementItem">The entitlement item object</param>
        /// <returns>EntitlementItem</returns>
        EntitlementItem CreateEntitlementItem (bool? cascade, EntitlementItem entitlementItem);
        /// <summary>
        /// Create an entitlement template Entitlement templates define a type of entitlement and the properties they have
        /// </summary>
        /// <param name="template">The entitlement template to be created</param>
        /// <returns>ItemTemplateResource</returns>
        ItemTemplateResource CreateEntitlementTemplate (ItemTemplateResource template);
        /// <summary>
        /// Delete an entitlement item 
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        /// <returns></returns>
        void DeleteEntitlementItem (int? entitlementId);
        /// <summary>
        /// Delete an entitlement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        /// <returns></returns>
        void DeleteEntitlementTemplate (string id, string cascade);
        /// <summary>
        /// Get a single entitlement item 
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        /// <returns>EntitlementItem</returns>
        EntitlementItem GetEntitlementItem (int? entitlementId);
        /// <summary>
        /// List and search entitlement items 
        /// </summary>
        /// <param name="filterTemplate">Filter for entitlements using a specified template</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceEntitlementItem</returns>
        PageResourceEntitlementItem GetEntitlementItems (string filterTemplate, int? size, int? page, string order);
        /// <summary>
        /// Get a single entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <returns>ItemTemplateResource</returns>
        ItemTemplateResource GetEntitlementTemplate (string id);
        /// <summary>
        /// List and search entitlement templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceItemTemplateResource</returns>
        PageResourceItemTemplateResource GetEntitlementTemplates (int? size, int? page, string order);
        /// <summary>
        /// List the user inventory entries for a given user 
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="inactive">If true, accepts inactive user inventories</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="filterItemName">Filter by items whose name starts with a string</param>
        /// <param name="filterItemId">Filter by item id</param>
        /// <param name="filterUsername">Filter by entries owned by the user with the specified username</param>
        /// <param name="filterGroup">Filter by entries owned by the users in a given group, by unique name</param>
        /// <param name="filterDate">A comma separated string without spaces.  First value is the operator to search on, second value is the log start date, a unix timestamp in seconds. Can be repeated for a range, eg: GT,123,LT,456  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <returns>PageResourceUserInventoryResource</returns>
        PageResourceUserInventoryResource GetUserInventories (int? id, bool? inactive, int? size, int? page, string filterItemName, int? filterItemId, string filterUsername, string filterGroup, string filterDate);
        /// <summary>
        /// Get an inventory entry 
        /// </summary>
        /// <param name="userId">The id of the inventory owner or &#39;me&#39; for the logged in user</param>
        /// <param name="id">The id of the user inventory</param>
        /// <returns>UserInventoryResource</returns>
        UserInventoryResource GetUserInventory (int? userId, int? id);
        /// <summary>
        /// List the log entries for this inventory entry 
        /// </summary>
        /// <param name="userId">The id of the inventory owner or &#39;me&#39; for the logged in user</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceUserItemLogResource</returns>
        PageResourceUserItemLogResource GetUserInventoryLog (string userId, int? id, int? size, int? page);
        /// <summary>
        /// List the user inventory entries for all users 
        /// </summary>
        /// <param name="inactive">If true, accepts inactive user inventories</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="filterItemName">Filter by items whose name starts with a string</param>
        /// <param name="filterItemId">Filter by item id</param>
        /// <param name="filterUsername">Filter by entries owned by the user with the specified username</param>
        /// <param name="filterGroup">Filter by entries owned by the users in a given group, by unique name</param>
        /// <param name="filterDate">A comma separated string without spaces.  First value is the operator to search on, second value is the log start date, a unix timestamp in seconds. Can be repeated for a range, eg: GT,123,LT,456  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <returns>PageResourceUserInventoryResource</returns>
        PageResourceUserInventoryResource GetUsersInventory (bool? inactive, int? size, int? page, string filterItemName, int? filterItemId, string filterUsername, string filterGroup, string filterDate);
        /// <summary>
        /// Grant an entitlement 
        /// </summary>
        /// <param name="userId">The id of the user to grant the entitlement to</param>
        /// <param name="grantRequest">grantRequest</param>
        /// <returns></returns>
        void GrantUserEntitlement (int? userId, EntitlementGrantRequest grantRequest);
        /// <summary>
        /// Update an entitlement item 
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="entitlementItem">The entitlement item object</param>
        /// <returns></returns>
        void UpdateEntitlementItem (int? entitlementId, bool? cascade, EntitlementItem entitlementItem);
        /// <summary>
        /// Update an entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template</param>
        /// <returns>ItemTemplateResource</returns>
        ItemTemplateResource UpdateEntitlementTemplate (string id, ItemTemplateResource template);
        /// <summary>
        /// Set the behavior data for an inventory entry 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="data">The data map</param>
        /// <returns></returns>
        void UpdateUserInventoryBehaviorData (int? userId, int? id, Object data);
        /// <summary>
        /// Set the expiration date Will change the current grace period for a subscription but not the bill date (possibly even ending before having the chance to re-bill)
        /// </summary>
        /// <param name="userId">user_id</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="timestamp">The new expiration date as a unix timestamp in seconds. May be null (no body).</param>
        /// <returns></returns>
        void UpdateUserInventoryExpires (int? userId, int? id, long? timestamp);
        /// <summary>
        /// Set the status for an inventory entry 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="inventoryStatus">The inventory status object</param>
        /// <returns></returns>
        void UpdateUserInventoryStatus (int? userId, int? id, string inventoryStatus);
        /// <summary>
        /// Use an item 
        /// </summary>
        /// <param name="userId">The id of the user to check for or &#39;me&#39; for logged in user</param>
        /// <param name="itemId">The id of the item</param>
        /// <param name="sku">The specific sku of an entitlement_list addition to check entitlement for. This is of very limited and specific use and should generally be left out</param>
        /// <param name="info">Any additional info to add to the log about this use</param>
        /// <returns></returns>
        void UseUserEntitlementItem (string userId, int? itemId, string sku, string info);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UsersInventoryApi : IUsersInventoryApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersInventoryApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersInventoryApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Adds an item to the user inventory The inventory is fulfilled asynchronously UNLESS the invoice is explicitely skipped. Depending on the use case, it might require the client to verify that the entitlement was added after the fact or configure a BRE rule to get a notification in real time
        /// </summary>
        /// <param name="id">The id of the user</param> 
        /// <param name="userInventoryAddRequest">The user inventory add request object</param> 
        /// <returns>InvoiceResource</returns>            
        public InvoiceResource AddItemToUserInventory(int? id, UserInventoryAddRequest userInventoryAddRequest)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddItemToUserInventory");
            }
            
            
            string urlPath = "/users/{id}/inventory";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(userInventoryAddRequest); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddItemToUserInventory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddItemToUserInventory: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (InvoiceResource) KnetikClient.Deserialize(response.Content, typeof(InvoiceResource), response.Headers);
        }
        /// <summary>
        /// Check for access to an item without consuming Useful for pre-check and accounts for all various buisness rules
        /// </summary>
        /// <param name="userId">The id of the user to check for or &#39;me&#39; for logged in user</param> 
        /// <param name="itemId">The id of the item</param> 
        /// <param name="sku">The specific sku of an entitlement list addition to check entitlement for. This is of very limited and specific use and should generally be left out</param> 
        /// <returns></returns>            
        public void CheckUserEntitlementItem(string userId, int? itemId, string sku)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling CheckUserEntitlementItem");
            }
            
            // verify the required parameter 'itemId' is set
            if (itemId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'itemId' when calling CheckUserEntitlementItem");
            }
            
            
            string urlPath = "/users/{user_id}/entitlements/{item_id}/check";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
urlPath = urlPath.Replace("{" + "item_id" + "}", KnetikClient.ParameterToString(itemId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (sku != null)
            {
                queryParams.Add("sku", KnetikClient.ParameterToString(sku));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CheckUserEntitlementItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CheckUserEntitlementItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Create an entitlement item 
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param> 
        /// <param name="entitlementItem">The entitlement item object</param> 
        /// <returns>EntitlementItem</returns>            
        public EntitlementItem CreateEntitlementItem(bool? cascade, EntitlementItem entitlementItem)
        {
            
            string urlPath = "/entitlements";
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
            
            postBody = KnetikClient.Serialize(entitlementItem); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateEntitlementItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateEntitlementItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (EntitlementItem) KnetikClient.Deserialize(response.Content, typeof(EntitlementItem), response.Headers);
        }
        /// <summary>
        /// Create an entitlement template Entitlement templates define a type of entitlement and the properties they have
        /// </summary>
        /// <param name="template">The entitlement template to be created</param> 
        /// <returns>ItemTemplateResource</returns>            
        public ItemTemplateResource CreateEntitlementTemplate(ItemTemplateResource template)
        {
            
            string urlPath = "/entitlements/templates";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateEntitlementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateEntitlementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// Delete an entitlement item 
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param> 
        /// <returns></returns>            
        public void DeleteEntitlementItem(int? entitlementId)
        {
            // verify the required parameter 'entitlementId' is set
            if (entitlementId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'entitlementId' when calling DeleteEntitlementItem");
            }
            
            
            string urlPath = "/entitlements/{entitlement_id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "entitlement_id" + "}", KnetikClient.ParameterToString(entitlementId));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteEntitlementItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteEntitlementItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete an entitlement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="cascade">The value needed to delete used templates</param> 
        /// <returns></returns>            
        public void DeleteEntitlementTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteEntitlementTemplate");
            }
            
            
            string urlPath = "/entitlements/templates/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteEntitlementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteEntitlementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get a single entitlement item 
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param> 
        /// <returns>EntitlementItem</returns>            
        public EntitlementItem GetEntitlementItem(int? entitlementId)
        {
            // verify the required parameter 'entitlementId' is set
            if (entitlementId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'entitlementId' when calling GetEntitlementItem");
            }
            
            
            string urlPath = "/entitlements/{entitlement_id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "entitlement_id" + "}", KnetikClient.ParameterToString(entitlementId));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetEntitlementItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetEntitlementItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (EntitlementItem) KnetikClient.Deserialize(response.Content, typeof(EntitlementItem), response.Headers);
        }
        /// <summary>
        /// List and search entitlement items 
        /// </summary>
        /// <param name="filterTemplate">Filter for entitlements using a specified template</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceEntitlementItem</returns>            
        public PageResourceEntitlementItem GetEntitlementItems(string filterTemplate, int? size, int? page, string order)
        {
            
            string urlPath = "/entitlements";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterTemplate != null)
            {
                queryParams.Add("filter_template", KnetikClient.ParameterToString(filterTemplate));
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetEntitlementItems: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetEntitlementItems: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceEntitlementItem) KnetikClient.Deserialize(response.Content, typeof(PageResourceEntitlementItem), response.Headers);
        }
        /// <summary>
        /// Get a single entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <returns>ItemTemplateResource</returns>            
        public ItemTemplateResource GetEntitlementTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetEntitlementTemplate");
            }
            
            
            string urlPath = "/entitlements/templates/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetEntitlementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetEntitlementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// List and search entitlement templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceItemTemplateResource</returns>            
        public PageResourceItemTemplateResource GetEntitlementTemplates(int? size, int? page, string order)
        {
            
            string urlPath = "/entitlements/templates";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetEntitlementTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetEntitlementTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// List the user inventory entries for a given user 
        /// </summary>
        /// <param name="id">The id of the user</param> 
        /// <param name="inactive">If true, accepts inactive user inventories</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="filterItemName">Filter by items whose name starts with a string</param> 
        /// <param name="filterItemId">Filter by item id</param> 
        /// <param name="filterUsername">Filter by entries owned by the user with the specified username</param> 
        /// <param name="filterGroup">Filter by entries owned by the users in a given group, by unique name</param> 
        /// <param name="filterDate">A comma separated string without spaces.  First value is the operator to search on, second value is the log start date, a unix timestamp in seconds. Can be repeated for a range, eg: GT,123,LT,456  Allowed operators: (GT, LT, EQ, GOE, LOE).</param> 
        /// <returns>PageResourceUserInventoryResource</returns>            
        public PageResourceUserInventoryResource GetUserInventories(int? id, bool? inactive, int? size, int? page, string filterItemName, int? filterItemId, string filterUsername, string filterGroup, string filterDate)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetUserInventories");
            }
            
            
            string urlPath = "/users/{id}/inventory";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (inactive != null)
            {
                queryParams.Add("inactive", KnetikClient.ParameterToString(inactive));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (filterItemName != null)
            {
                queryParams.Add("filter_item_name", KnetikClient.ParameterToString(filterItemName));
            }
            
            if (filterItemId != null)
            {
                queryParams.Add("filter_item_id", KnetikClient.ParameterToString(filterItemId));
            }
            
            if (filterUsername != null)
            {
                queryParams.Add("filter_username", KnetikClient.ParameterToString(filterUsername));
            }
            
            if (filterGroup != null)
            {
                queryParams.Add("filter_group", KnetikClient.ParameterToString(filterGroup));
            }
            
            if (filterDate != null)
            {
                queryParams.Add("filter_date", KnetikClient.ParameterToString(filterDate));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserInventories: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserInventories: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceUserInventoryResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserInventoryResource), response.Headers);
        }
        /// <summary>
        /// Get an inventory entry 
        /// </summary>
        /// <param name="userId">The id of the inventory owner or &#39;me&#39; for the logged in user</param> 
        /// <param name="id">The id of the user inventory</param> 
        /// <returns>UserInventoryResource</returns>            
        public UserInventoryResource GetUserInventory(int? userId, int? id)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserInventory");
            }
            
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetUserInventory");
            }
            
            
            string urlPath = "/users/{user_id}/inventory/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserInventory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserInventory: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (UserInventoryResource) KnetikClient.Deserialize(response.Content, typeof(UserInventoryResource), response.Headers);
        }
        /// <summary>
        /// List the log entries for this inventory entry 
        /// </summary>
        /// <param name="userId">The id of the inventory owner or &#39;me&#39; for the logged in user</param> 
        /// <param name="id">The id of the user inventory</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceUserItemLogResource</returns>            
        public PageResourceUserItemLogResource GetUserInventoryLog(string userId, int? id, int? size, int? page)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserInventoryLog");
            }
            
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetUserInventoryLog");
            }
            
            
            string urlPath = "/users/{user_id}/inventory/{id}/log";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
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
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserInventoryLog: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserInventoryLog: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceUserItemLogResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserItemLogResource), response.Headers);
        }
        /// <summary>
        /// List the user inventory entries for all users 
        /// </summary>
        /// <param name="inactive">If true, accepts inactive user inventories</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="filterItemName">Filter by items whose name starts with a string</param> 
        /// <param name="filterItemId">Filter by item id</param> 
        /// <param name="filterUsername">Filter by entries owned by the user with the specified username</param> 
        /// <param name="filterGroup">Filter by entries owned by the users in a given group, by unique name</param> 
        /// <param name="filterDate">A comma separated string without spaces.  First value is the operator to search on, second value is the log start date, a unix timestamp in seconds. Can be repeated for a range, eg: GT,123,LT,456  Allowed operators: (GT, LT, EQ, GOE, LOE).</param> 
        /// <returns>PageResourceUserInventoryResource</returns>            
        public PageResourceUserInventoryResource GetUsersInventory(bool? inactive, int? size, int? page, string filterItemName, int? filterItemId, string filterUsername, string filterGroup, string filterDate)
        {
            
            string urlPath = "/inventories";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (inactive != null)
            {
                queryParams.Add("inactive", KnetikClient.ParameterToString(inactive));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (filterItemName != null)
            {
                queryParams.Add("filter_item_name", KnetikClient.ParameterToString(filterItemName));
            }
            
            if (filterItemId != null)
            {
                queryParams.Add("filter_item_id", KnetikClient.ParameterToString(filterItemId));
            }
            
            if (filterUsername != null)
            {
                queryParams.Add("filter_username", KnetikClient.ParameterToString(filterUsername));
            }
            
            if (filterGroup != null)
            {
                queryParams.Add("filter_group", KnetikClient.ParameterToString(filterGroup));
            }
            
            if (filterDate != null)
            {
                queryParams.Add("filter_date", KnetikClient.ParameterToString(filterDate));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsersInventory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsersInventory: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceUserInventoryResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserInventoryResource), response.Headers);
        }
        /// <summary>
        /// Grant an entitlement 
        /// </summary>
        /// <param name="userId">The id of the user to grant the entitlement to</param> 
        /// <param name="grantRequest">grantRequest</param> 
        /// <returns></returns>            
        public void GrantUserEntitlement(int? userId, EntitlementGrantRequest grantRequest)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GrantUserEntitlement");
            }
            
            // verify the required parameter 'grantRequest' is set
            if (grantRequest == null)
            {
                throw new KnetikException(400, "Missing required parameter 'grantRequest' when calling GrantUserEntitlement");
            }
            
            
            string urlPath = "/users/{user_id}/entitlements";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(grantRequest); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GrantUserEntitlement: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GrantUserEntitlement: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Update an entitlement item 
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param> 
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param> 
        /// <param name="entitlementItem">The entitlement item object</param> 
        /// <returns></returns>            
        public void UpdateEntitlementItem(int? entitlementId, bool? cascade, EntitlementItem entitlementItem)
        {
            // verify the required parameter 'entitlementId' is set
            if (entitlementId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'entitlementId' when calling UpdateEntitlementItem");
            }
            
            
            string urlPath = "/entitlements/{entitlement_id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "entitlement_id" + "}", KnetikClient.ParameterToString(entitlementId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.ParameterToString(cascade));
            }
            
            postBody = KnetikClient.Serialize(entitlementItem); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateEntitlementItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateEntitlementItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Update an entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="template">The updated template</param> 
        /// <returns>ItemTemplateResource</returns>            
        public ItemTemplateResource UpdateEntitlementTemplate(string id, ItemTemplateResource template)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateEntitlementTemplate");
            }
            
            
            string urlPath = "/entitlements/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateEntitlementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateEntitlementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// Set the behavior data for an inventory entry 
        /// </summary>
        /// <param name="userId">The id of the user</param> 
        /// <param name="id">The id of the user inventory</param> 
        /// <param name="data">The data map</param> 
        /// <returns></returns>            
        public void UpdateUserInventoryBehaviorData(int? userId, int? id, Object data)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling UpdateUserInventoryBehaviorData");
            }
            
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateUserInventoryBehaviorData");
            }
            
            
            string urlPath = "/users/{user_id}/inventory/{id}/behavior-data";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(data); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateUserInventoryBehaviorData: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateUserInventoryBehaviorData: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Set the expiration date Will change the current grace period for a subscription but not the bill date (possibly even ending before having the chance to re-bill)
        /// </summary>
        /// <param name="userId">user_id</param> 
        /// <param name="id">The id of the user inventory</param> 
        /// <param name="timestamp">The new expiration date as a unix timestamp in seconds. May be null (no body).</param> 
        /// <returns></returns>            
        public void UpdateUserInventoryExpires(int? userId, int? id, long? timestamp)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling UpdateUserInventoryExpires");
            }
            
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateUserInventoryExpires");
            }
            
            
            string urlPath = "/users/{user_id}/inventory/{id}/expires";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(timestamp); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateUserInventoryExpires: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateUserInventoryExpires: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Set the status for an inventory entry 
        /// </summary>
        /// <param name="userId">The id of the user</param> 
        /// <param name="id">The id of the user inventory</param> 
        /// <param name="inventoryStatus">The inventory status object</param> 
        /// <returns></returns>            
        public void UpdateUserInventoryStatus(int? userId, int? id, string inventoryStatus)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling UpdateUserInventoryStatus");
            }
            
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateUserInventoryStatus");
            }
            
            
            string urlPath = "/users/{user_id}/inventory/{id}/status";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(inventoryStatus); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateUserInventoryStatus: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateUserInventoryStatus: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Use an item 
        /// </summary>
        /// <param name="userId">The id of the user to check for or &#39;me&#39; for logged in user</param> 
        /// <param name="itemId">The id of the item</param> 
        /// <param name="sku">The specific sku of an entitlement_list addition to check entitlement for. This is of very limited and specific use and should generally be left out</param> 
        /// <param name="info">Any additional info to add to the log about this use</param> 
        /// <returns></returns>            
        public void UseUserEntitlementItem(string userId, int? itemId, string sku, string info)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling UseUserEntitlementItem");
            }
            
            // verify the required parameter 'itemId' is set
            if (itemId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'itemId' when calling UseUserEntitlementItem");
            }
            
            
            string urlPath = "/users/{user_id}/entitlements/{item_id}/use";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
urlPath = urlPath.Replace("{" + "item_id" + "}", KnetikClient.ParameterToString(itemId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (sku != null)
            {
                queryParams.Add("sku", KnetikClient.ParameterToString(sku));
            }
            
            if (info != null)
            {
                queryParams.Add("info", KnetikClient.ParameterToString(info));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UseUserEntitlementItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UseUserEntitlementItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
    }
}
