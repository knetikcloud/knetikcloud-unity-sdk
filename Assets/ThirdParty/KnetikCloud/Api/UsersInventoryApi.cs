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
    public interface IUsersInventoryApi
    {
        InvoiceResource AddItemToUserInventoryData { get; }

        EntitlementItem CreateEntitlementItemData { get; }

        ItemTemplateResource CreateEntitlementTemplateData { get; }

        EntitlementItem GetEntitlementItemData { get; }

        PageResourceEntitlementItem GetEntitlementItemsData { get; }

        ItemTemplateResource GetEntitlementTemplateData { get; }

        PageResourceItemTemplateResource GetEntitlementTemplatesData { get; }

        PageResourceUserInventoryResource GetUserInventoriesData { get; }

        UserInventoryResource GetUserInventoryData { get; }

        PageResourceUserItemLogResource GetUserInventoryLogData { get; }

        PageResourceUserInventoryResource GetUsersInventoryData { get; }

        ItemTemplateResource UpdateEntitlementTemplateData { get; }

        
        /// <summary>
        /// Adds an item to the user inventory The inventory is fulfilled asynchronously UNLESS the invoice is explicitely skipped. Depending on the use case, it might require the client to verify that the entitlement was added after the fact or configure a BRE rule to get a notification in real time
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="userInventoryAddRequest">The user inventory add request object</param>
        void AddItemToUserInventory(int? id, UserInventoryAddRequest userInventoryAddRequest);

        /// <summary>
        /// Check for access to an item without consuming Useful for pre-check and accounts for all various buisness rules
        /// </summary>
        /// <param name="userId">The id of the user to check for or &#39;me&#39; for logged in user</param>
        /// <param name="itemId">The id of the item</param>
        /// <param name="sku">The specific sku of an entitlement list addition to check entitlement for. This is of very limited and specific use and should generally be left out</param>
        void CheckUserEntitlementItem(string userId, int? itemId, string sku);

        /// <summary>
        /// Create an entitlement item 
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="entitlementItem">The entitlement item object</param>
        void CreateEntitlementItem(bool? cascade, EntitlementItem entitlementItem);

        /// <summary>
        /// Create an entitlement template Entitlement templates define a type of entitlement and the properties they have
        /// </summary>
        /// <param name="template">The entitlement template to be created</param>
        void CreateEntitlementTemplate(ItemTemplateResource template);

        /// <summary>
        /// Delete an entitlement item 
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        void DeleteEntitlementItem(int? entitlementId);

        /// <summary>
        /// Delete an entitlement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteEntitlementTemplate(string id, string cascade);

        /// <summary>
        /// Get a single entitlement item 
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        void GetEntitlementItem(int? entitlementId);

        /// <summary>
        /// List and search entitlement items 
        /// </summary>
        /// <param name="filterTemplate">Filter for entitlements using a specified template</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetEntitlementItems(string filterTemplate, int? size, int? page, string order);

        /// <summary>
        /// Get a single entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetEntitlementTemplate(string id);

        /// <summary>
        /// List and search entitlement templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetEntitlementTemplates(int? size, int? page, string order);

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
        void GetUserInventories(int? id, bool? inactive, int? size, int? page, string filterItemName, int? filterItemId, string filterUsername, string filterGroup, string filterDate);

        /// <summary>
        /// Get an inventory entry 
        /// </summary>
        /// <param name="userId">The id of the inventory owner or &#39;me&#39; for the logged in user</param>
        /// <param name="id">The id of the user inventory</param>
        void GetUserInventory(int? userId, int? id);

        /// <summary>
        /// List the log entries for this inventory entry 
        /// </summary>
        /// <param name="userId">The id of the inventory owner or &#39;me&#39; for the logged in user</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUserInventoryLog(string userId, int? id, int? size, int? page);

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
        void GetUsersInventory(bool? inactive, int? size, int? page, string filterItemName, int? filterItemId, string filterUsername, string filterGroup, string filterDate);

        /// <summary>
        /// Grant an entitlement 
        /// </summary>
        /// <param name="userId">The id of the user to grant the entitlement to</param>
        /// <param name="grantRequest">grantRequest</param>
        void GrantUserEntitlement(int? userId, EntitlementGrantRequest grantRequest);

        /// <summary>
        /// Update an entitlement item 
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="entitlementItem">The entitlement item object</param>
        void UpdateEntitlementItem(int? entitlementId, bool? cascade, EntitlementItem entitlementItem);

        /// <summary>
        /// Update an entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template</param>
        void UpdateEntitlementTemplate(string id, ItemTemplateResource template);

        /// <summary>
        /// Set the behavior data for an inventory entry 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="data">The data map</param>
        void UpdateUserInventoryBehaviorData(int? userId, int? id, Object data);

        /// <summary>
        /// Set the expiration date Will change the current grace period for a subscription but not the bill date (possibly even ending before having the chance to re-bill)
        /// </summary>
        /// <param name="userId">user_id</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="timestamp">The new expiration date as a unix timestamp in seconds. May be null (no body).</param>
        void UpdateUserInventoryExpires(int? userId, int? id, long? timestamp);

        /// <summary>
        /// Set the status for an inventory entry 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="inventoryStatus">The inventory status object</param>
        void UpdateUserInventoryStatus(int? userId, int? id, string inventoryStatus);

        /// <summary>
        /// Use an item 
        /// </summary>
        /// <param name="userId">The id of the user to check for or &#39;me&#39; for logged in user</param>
        /// <param name="itemId">The id of the item</param>
        /// <param name="sku">The specific sku of an entitlement_list addition to check entitlement for. This is of very limited and specific use and should generally be left out</param>
        /// <param name="info">Any additional info to add to the log about this use</param>
        void UseUserEntitlementItem(string userId, int? itemId, string sku, string info);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UsersInventoryApi : IUsersInventoryApi
    {
        private readonly KnetikCoroutine mAddItemToUserInventoryCoroutine;
        private DateTime mAddItemToUserInventoryStartTime;
        private string mAddItemToUserInventoryPath;
        private readonly KnetikCoroutine mCheckUserEntitlementItemCoroutine;
        private DateTime mCheckUserEntitlementItemStartTime;
        private string mCheckUserEntitlementItemPath;
        private readonly KnetikCoroutine mCreateEntitlementItemCoroutine;
        private DateTime mCreateEntitlementItemStartTime;
        private string mCreateEntitlementItemPath;
        private readonly KnetikCoroutine mCreateEntitlementTemplateCoroutine;
        private DateTime mCreateEntitlementTemplateStartTime;
        private string mCreateEntitlementTemplatePath;
        private readonly KnetikCoroutine mDeleteEntitlementItemCoroutine;
        private DateTime mDeleteEntitlementItemStartTime;
        private string mDeleteEntitlementItemPath;
        private readonly KnetikCoroutine mDeleteEntitlementTemplateCoroutine;
        private DateTime mDeleteEntitlementTemplateStartTime;
        private string mDeleteEntitlementTemplatePath;
        private readonly KnetikCoroutine mGetEntitlementItemCoroutine;
        private DateTime mGetEntitlementItemStartTime;
        private string mGetEntitlementItemPath;
        private readonly KnetikCoroutine mGetEntitlementItemsCoroutine;
        private DateTime mGetEntitlementItemsStartTime;
        private string mGetEntitlementItemsPath;
        private readonly KnetikCoroutine mGetEntitlementTemplateCoroutine;
        private DateTime mGetEntitlementTemplateStartTime;
        private string mGetEntitlementTemplatePath;
        private readonly KnetikCoroutine mGetEntitlementTemplatesCoroutine;
        private DateTime mGetEntitlementTemplatesStartTime;
        private string mGetEntitlementTemplatesPath;
        private readonly KnetikCoroutine mGetUserInventoriesCoroutine;
        private DateTime mGetUserInventoriesStartTime;
        private string mGetUserInventoriesPath;
        private readonly KnetikCoroutine mGetUserInventoryCoroutine;
        private DateTime mGetUserInventoryStartTime;
        private string mGetUserInventoryPath;
        private readonly KnetikCoroutine mGetUserInventoryLogCoroutine;
        private DateTime mGetUserInventoryLogStartTime;
        private string mGetUserInventoryLogPath;
        private readonly KnetikCoroutine mGetUsersInventoryCoroutine;
        private DateTime mGetUsersInventoryStartTime;
        private string mGetUsersInventoryPath;
        private readonly KnetikCoroutine mGrantUserEntitlementCoroutine;
        private DateTime mGrantUserEntitlementStartTime;
        private string mGrantUserEntitlementPath;
        private readonly KnetikCoroutine mUpdateEntitlementItemCoroutine;
        private DateTime mUpdateEntitlementItemStartTime;
        private string mUpdateEntitlementItemPath;
        private readonly KnetikCoroutine mUpdateEntitlementTemplateCoroutine;
        private DateTime mUpdateEntitlementTemplateStartTime;
        private string mUpdateEntitlementTemplatePath;
        private readonly KnetikCoroutine mUpdateUserInventoryBehaviorDataCoroutine;
        private DateTime mUpdateUserInventoryBehaviorDataStartTime;
        private string mUpdateUserInventoryBehaviorDataPath;
        private readonly KnetikCoroutine mUpdateUserInventoryExpiresCoroutine;
        private DateTime mUpdateUserInventoryExpiresStartTime;
        private string mUpdateUserInventoryExpiresPath;
        private readonly KnetikCoroutine mUpdateUserInventoryStatusCoroutine;
        private DateTime mUpdateUserInventoryStatusStartTime;
        private string mUpdateUserInventoryStatusPath;
        private readonly KnetikCoroutine mUseUserEntitlementItemCoroutine;
        private DateTime mUseUserEntitlementItemStartTime;
        private string mUseUserEntitlementItemPath;

        public InvoiceResource AddItemToUserInventoryData { get; private set; }
        public delegate void AddItemToUserInventoryCompleteDelegate(InvoiceResource response);
        public AddItemToUserInventoryCompleteDelegate AddItemToUserInventoryComplete;

        public delegate void CheckUserEntitlementItemCompleteDelegate();
        public CheckUserEntitlementItemCompleteDelegate CheckUserEntitlementItemComplete;

        public EntitlementItem CreateEntitlementItemData { get; private set; }
        public delegate void CreateEntitlementItemCompleteDelegate(EntitlementItem response);
        public CreateEntitlementItemCompleteDelegate CreateEntitlementItemComplete;

        public ItemTemplateResource CreateEntitlementTemplateData { get; private set; }
        public delegate void CreateEntitlementTemplateCompleteDelegate(ItemTemplateResource response);
        public CreateEntitlementTemplateCompleteDelegate CreateEntitlementTemplateComplete;

        public delegate void DeleteEntitlementItemCompleteDelegate();
        public DeleteEntitlementItemCompleteDelegate DeleteEntitlementItemComplete;

        public delegate void DeleteEntitlementTemplateCompleteDelegate();
        public DeleteEntitlementTemplateCompleteDelegate DeleteEntitlementTemplateComplete;

        public EntitlementItem GetEntitlementItemData { get; private set; }
        public delegate void GetEntitlementItemCompleteDelegate(EntitlementItem response);
        public GetEntitlementItemCompleteDelegate GetEntitlementItemComplete;

        public PageResourceEntitlementItem GetEntitlementItemsData { get; private set; }
        public delegate void GetEntitlementItemsCompleteDelegate(PageResourceEntitlementItem response);
        public GetEntitlementItemsCompleteDelegate GetEntitlementItemsComplete;

        public ItemTemplateResource GetEntitlementTemplateData { get; private set; }
        public delegate void GetEntitlementTemplateCompleteDelegate(ItemTemplateResource response);
        public GetEntitlementTemplateCompleteDelegate GetEntitlementTemplateComplete;

        public PageResourceItemTemplateResource GetEntitlementTemplatesData { get; private set; }
        public delegate void GetEntitlementTemplatesCompleteDelegate(PageResourceItemTemplateResource response);
        public GetEntitlementTemplatesCompleteDelegate GetEntitlementTemplatesComplete;

        public PageResourceUserInventoryResource GetUserInventoriesData { get; private set; }
        public delegate void GetUserInventoriesCompleteDelegate(PageResourceUserInventoryResource response);
        public GetUserInventoriesCompleteDelegate GetUserInventoriesComplete;

        public UserInventoryResource GetUserInventoryData { get; private set; }
        public delegate void GetUserInventoryCompleteDelegate(UserInventoryResource response);
        public GetUserInventoryCompleteDelegate GetUserInventoryComplete;

        public PageResourceUserItemLogResource GetUserInventoryLogData { get; private set; }
        public delegate void GetUserInventoryLogCompleteDelegate(PageResourceUserItemLogResource response);
        public GetUserInventoryLogCompleteDelegate GetUserInventoryLogComplete;

        public PageResourceUserInventoryResource GetUsersInventoryData { get; private set; }
        public delegate void GetUsersInventoryCompleteDelegate(PageResourceUserInventoryResource response);
        public GetUsersInventoryCompleteDelegate GetUsersInventoryComplete;

        public delegate void GrantUserEntitlementCompleteDelegate();
        public GrantUserEntitlementCompleteDelegate GrantUserEntitlementComplete;

        public delegate void UpdateEntitlementItemCompleteDelegate();
        public UpdateEntitlementItemCompleteDelegate UpdateEntitlementItemComplete;

        public ItemTemplateResource UpdateEntitlementTemplateData { get; private set; }
        public delegate void UpdateEntitlementTemplateCompleteDelegate(ItemTemplateResource response);
        public UpdateEntitlementTemplateCompleteDelegate UpdateEntitlementTemplateComplete;

        public delegate void UpdateUserInventoryBehaviorDataCompleteDelegate();
        public UpdateUserInventoryBehaviorDataCompleteDelegate UpdateUserInventoryBehaviorDataComplete;

        public delegate void UpdateUserInventoryExpiresCompleteDelegate();
        public UpdateUserInventoryExpiresCompleteDelegate UpdateUserInventoryExpiresComplete;

        public delegate void UpdateUserInventoryStatusCompleteDelegate();
        public UpdateUserInventoryStatusCompleteDelegate UpdateUserInventoryStatusComplete;

        public delegate void UseUserEntitlementItemCompleteDelegate();
        public UseUserEntitlementItemCompleteDelegate UseUserEntitlementItemComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersInventoryApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersInventoryApi()
        {
            mAddItemToUserInventoryCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mCheckUserEntitlementItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mCreateEntitlementItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mCreateEntitlementTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mDeleteEntitlementItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mDeleteEntitlementTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetEntitlementItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetEntitlementItemsCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetEntitlementTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetEntitlementTemplatesCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetUserInventoriesCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetUserInventoryCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetUserInventoryLogCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetUsersInventoryCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGrantUserEntitlementCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateEntitlementItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateEntitlementTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateUserInventoryBehaviorDataCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateUserInventoryExpiresCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateUserInventoryStatusCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUseUserEntitlementItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
        /// <summary>
        /// Adds an item to the user inventory The inventory is fulfilled asynchronously UNLESS the invoice is explicitely skipped. Depending on the use case, it might require the client to verify that the entitlement was added after the fact or configure a BRE rule to get a notification in real time
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="userInventoryAddRequest">The user inventory add request object</param>
        public void AddItemToUserInventory(int? id, UserInventoryAddRequest userInventoryAddRequest)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddItemToUserInventory");
            }
            
            mAddItemToUserInventoryPath = "/users/{id}/inventory";
            if (!string.IsNullOrEmpty(mAddItemToUserInventoryPath))
            {
                mAddItemToUserInventoryPath = mAddItemToUserInventoryPath.Replace("{format}", "json");
            }
            mAddItemToUserInventoryPath = mAddItemToUserInventoryPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(userInventoryAddRequest); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddItemToUserInventoryStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddItemToUserInventoryStartTime, mAddItemToUserInventoryPath, "Sending server request...");

            // make the HTTP request
            mAddItemToUserInventoryCoroutine.ResponseReceived += AddItemToUserInventoryCallback;
            mAddItemToUserInventoryCoroutine.Start(mAddItemToUserInventoryPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddItemToUserInventoryCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddItemToUserInventory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddItemToUserInventory: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddItemToUserInventoryData = (InvoiceResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(InvoiceResource), response.Headers);
            KnetikLogger.LogResponse(mAddItemToUserInventoryStartTime, mAddItemToUserInventoryPath, string.Format("Response received successfully:\n{0}", AddItemToUserInventoryData.ToString()));

            if (AddItemToUserInventoryComplete != null)
            {
                AddItemToUserInventoryComplete(AddItemToUserInventoryData);
            }
        }
        /// <summary>
        /// Check for access to an item without consuming Useful for pre-check and accounts for all various buisness rules
        /// </summary>
        /// <param name="userId">The id of the user to check for or &#39;me&#39; for logged in user</param>
        /// <param name="itemId">The id of the item</param>
        /// <param name="sku">The specific sku of an entitlement list addition to check entitlement for. This is of very limited and specific use and should generally be left out</param>
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
            
            mCheckUserEntitlementItemPath = "/users/{user_id}/entitlements/{item_id}/check";
            if (!string.IsNullOrEmpty(mCheckUserEntitlementItemPath))
            {
                mCheckUserEntitlementItemPath = mCheckUserEntitlementItemPath.Replace("{format}", "json");
            }
            mCheckUserEntitlementItemPath = mCheckUserEntitlementItemPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mCheckUserEntitlementItemPath = mCheckUserEntitlementItemPath.Replace("{" + "item_id" + "}", KnetikClient.DefaultClient.ParameterToString(itemId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (sku != null)
            {
                queryParams.Add("sku", KnetikClient.DefaultClient.ParameterToString(sku));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCheckUserEntitlementItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCheckUserEntitlementItemStartTime, mCheckUserEntitlementItemPath, "Sending server request...");

            // make the HTTP request
            mCheckUserEntitlementItemCoroutine.ResponseReceived += CheckUserEntitlementItemCallback;
            mCheckUserEntitlementItemCoroutine.Start(mCheckUserEntitlementItemPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CheckUserEntitlementItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CheckUserEntitlementItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CheckUserEntitlementItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mCheckUserEntitlementItemStartTime, mCheckUserEntitlementItemPath, "Response received successfully.");
            if (CheckUserEntitlementItemComplete != null)
            {
                CheckUserEntitlementItemComplete();
            }
        }
        /// <summary>
        /// Create an entitlement item 
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="entitlementItem">The entitlement item object</param>
        public void CreateEntitlementItem(bool? cascade, EntitlementItem entitlementItem)
        {
            
            mCreateEntitlementItemPath = "/entitlements";
            if (!string.IsNullOrEmpty(mCreateEntitlementItemPath))
            {
                mCreateEntitlementItemPath = mCreateEntitlementItemPath.Replace("{format}", "json");
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

            postBody = KnetikClient.DefaultClient.Serialize(entitlementItem); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateEntitlementItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateEntitlementItemStartTime, mCreateEntitlementItemPath, "Sending server request...");

            // make the HTTP request
            mCreateEntitlementItemCoroutine.ResponseReceived += CreateEntitlementItemCallback;
            mCreateEntitlementItemCoroutine.Start(mCreateEntitlementItemPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateEntitlementItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateEntitlementItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateEntitlementItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateEntitlementItemData = (EntitlementItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(EntitlementItem), response.Headers);
            KnetikLogger.LogResponse(mCreateEntitlementItemStartTime, mCreateEntitlementItemPath, string.Format("Response received successfully:\n{0}", CreateEntitlementItemData.ToString()));

            if (CreateEntitlementItemComplete != null)
            {
                CreateEntitlementItemComplete(CreateEntitlementItemData);
            }
        }
        /// <summary>
        /// Create an entitlement template Entitlement templates define a type of entitlement and the properties they have
        /// </summary>
        /// <param name="template">The entitlement template to be created</param>
        public void CreateEntitlementTemplate(ItemTemplateResource template)
        {
            
            mCreateEntitlementTemplatePath = "/entitlements/templates";
            if (!string.IsNullOrEmpty(mCreateEntitlementTemplatePath))
            {
                mCreateEntitlementTemplatePath = mCreateEntitlementTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateEntitlementTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateEntitlementTemplateStartTime, mCreateEntitlementTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateEntitlementTemplateCoroutine.ResponseReceived += CreateEntitlementTemplateCallback;
            mCreateEntitlementTemplateCoroutine.Start(mCreateEntitlementTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateEntitlementTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateEntitlementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateEntitlementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateEntitlementTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateEntitlementTemplateStartTime, mCreateEntitlementTemplatePath, string.Format("Response received successfully:\n{0}", CreateEntitlementTemplateData.ToString()));

            if (CreateEntitlementTemplateComplete != null)
            {
                CreateEntitlementTemplateComplete(CreateEntitlementTemplateData);
            }
        }
        /// <summary>
        /// Delete an entitlement item 
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        public void DeleteEntitlementItem(int? entitlementId)
        {
            // verify the required parameter 'entitlementId' is set
            if (entitlementId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'entitlementId' when calling DeleteEntitlementItem");
            }
            
            mDeleteEntitlementItemPath = "/entitlements/{entitlement_id}";
            if (!string.IsNullOrEmpty(mDeleteEntitlementItemPath))
            {
                mDeleteEntitlementItemPath = mDeleteEntitlementItemPath.Replace("{format}", "json");
            }
            mDeleteEntitlementItemPath = mDeleteEntitlementItemPath.Replace("{" + "entitlement_id" + "}", KnetikClient.DefaultClient.ParameterToString(entitlementId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteEntitlementItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteEntitlementItemStartTime, mDeleteEntitlementItemPath, "Sending server request...");

            // make the HTTP request
            mDeleteEntitlementItemCoroutine.ResponseReceived += DeleteEntitlementItemCallback;
            mDeleteEntitlementItemCoroutine.Start(mDeleteEntitlementItemPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteEntitlementItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteEntitlementItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteEntitlementItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteEntitlementItemStartTime, mDeleteEntitlementItemPath, "Response received successfully.");
            if (DeleteEntitlementItemComplete != null)
            {
                DeleteEntitlementItemComplete();
            }
        }
        /// <summary>
        /// Delete an entitlement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteEntitlementTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteEntitlementTemplate");
            }
            
            mDeleteEntitlementTemplatePath = "/entitlements/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteEntitlementTemplatePath))
            {
                mDeleteEntitlementTemplatePath = mDeleteEntitlementTemplatePath.Replace("{format}", "json");
            }
            mDeleteEntitlementTemplatePath = mDeleteEntitlementTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mDeleteEntitlementTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteEntitlementTemplateStartTime, mDeleteEntitlementTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteEntitlementTemplateCoroutine.ResponseReceived += DeleteEntitlementTemplateCallback;
            mDeleteEntitlementTemplateCoroutine.Start(mDeleteEntitlementTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteEntitlementTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteEntitlementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteEntitlementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteEntitlementTemplateStartTime, mDeleteEntitlementTemplatePath, "Response received successfully.");
            if (DeleteEntitlementTemplateComplete != null)
            {
                DeleteEntitlementTemplateComplete();
            }
        }
        /// <summary>
        /// Get a single entitlement item 
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        public void GetEntitlementItem(int? entitlementId)
        {
            // verify the required parameter 'entitlementId' is set
            if (entitlementId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'entitlementId' when calling GetEntitlementItem");
            }
            
            mGetEntitlementItemPath = "/entitlements/{entitlement_id}";
            if (!string.IsNullOrEmpty(mGetEntitlementItemPath))
            {
                mGetEntitlementItemPath = mGetEntitlementItemPath.Replace("{format}", "json");
            }
            mGetEntitlementItemPath = mGetEntitlementItemPath.Replace("{" + "entitlement_id" + "}", KnetikClient.DefaultClient.ParameterToString(entitlementId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetEntitlementItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetEntitlementItemStartTime, mGetEntitlementItemPath, "Sending server request...");

            // make the HTTP request
            mGetEntitlementItemCoroutine.ResponseReceived += GetEntitlementItemCallback;
            mGetEntitlementItemCoroutine.Start(mGetEntitlementItemPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetEntitlementItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetEntitlementItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetEntitlementItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetEntitlementItemData = (EntitlementItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(EntitlementItem), response.Headers);
            KnetikLogger.LogResponse(mGetEntitlementItemStartTime, mGetEntitlementItemPath, string.Format("Response received successfully:\n{0}", GetEntitlementItemData.ToString()));

            if (GetEntitlementItemComplete != null)
            {
                GetEntitlementItemComplete(GetEntitlementItemData);
            }
        }
        /// <summary>
        /// List and search entitlement items 
        /// </summary>
        /// <param name="filterTemplate">Filter for entitlements using a specified template</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetEntitlementItems(string filterTemplate, int? size, int? page, string order)
        {
            
            mGetEntitlementItemsPath = "/entitlements";
            if (!string.IsNullOrEmpty(mGetEntitlementItemsPath))
            {
                mGetEntitlementItemsPath = mGetEntitlementItemsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterTemplate != null)
            {
                queryParams.Add("filter_template", KnetikClient.DefaultClient.ParameterToString(filterTemplate));
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

            mGetEntitlementItemsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetEntitlementItemsStartTime, mGetEntitlementItemsPath, "Sending server request...");

            // make the HTTP request
            mGetEntitlementItemsCoroutine.ResponseReceived += GetEntitlementItemsCallback;
            mGetEntitlementItemsCoroutine.Start(mGetEntitlementItemsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetEntitlementItemsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetEntitlementItems: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetEntitlementItems: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetEntitlementItemsData = (PageResourceEntitlementItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceEntitlementItem), response.Headers);
            KnetikLogger.LogResponse(mGetEntitlementItemsStartTime, mGetEntitlementItemsPath, string.Format("Response received successfully:\n{0}", GetEntitlementItemsData.ToString()));

            if (GetEntitlementItemsComplete != null)
            {
                GetEntitlementItemsComplete(GetEntitlementItemsData);
            }
        }
        /// <summary>
        /// Get a single entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetEntitlementTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetEntitlementTemplate");
            }
            
            mGetEntitlementTemplatePath = "/entitlements/templates/{id}";
            if (!string.IsNullOrEmpty(mGetEntitlementTemplatePath))
            {
                mGetEntitlementTemplatePath = mGetEntitlementTemplatePath.Replace("{format}", "json");
            }
            mGetEntitlementTemplatePath = mGetEntitlementTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetEntitlementTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetEntitlementTemplateStartTime, mGetEntitlementTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetEntitlementTemplateCoroutine.ResponseReceived += GetEntitlementTemplateCallback;
            mGetEntitlementTemplateCoroutine.Start(mGetEntitlementTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetEntitlementTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetEntitlementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetEntitlementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetEntitlementTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetEntitlementTemplateStartTime, mGetEntitlementTemplatePath, string.Format("Response received successfully:\n{0}", GetEntitlementTemplateData.ToString()));

            if (GetEntitlementTemplateComplete != null)
            {
                GetEntitlementTemplateComplete(GetEntitlementTemplateData);
            }
        }
        /// <summary>
        /// List and search entitlement templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetEntitlementTemplates(int? size, int? page, string order)
        {
            
            mGetEntitlementTemplatesPath = "/entitlements/templates";
            if (!string.IsNullOrEmpty(mGetEntitlementTemplatesPath))
            {
                mGetEntitlementTemplatesPath = mGetEntitlementTemplatesPath.Replace("{format}", "json");
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

            mGetEntitlementTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetEntitlementTemplatesStartTime, mGetEntitlementTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetEntitlementTemplatesCoroutine.ResponseReceived += GetEntitlementTemplatesCallback;
            mGetEntitlementTemplatesCoroutine.Start(mGetEntitlementTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetEntitlementTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetEntitlementTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetEntitlementTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetEntitlementTemplatesData = (PageResourceItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetEntitlementTemplatesStartTime, mGetEntitlementTemplatesPath, string.Format("Response received successfully:\n{0}", GetEntitlementTemplatesData.ToString()));

            if (GetEntitlementTemplatesComplete != null)
            {
                GetEntitlementTemplatesComplete(GetEntitlementTemplatesData);
            }
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
        public void GetUserInventories(int? id, bool? inactive, int? size, int? page, string filterItemName, int? filterItemId, string filterUsername, string filterGroup, string filterDate)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetUserInventories");
            }
            
            mGetUserInventoriesPath = "/users/{id}/inventory";
            if (!string.IsNullOrEmpty(mGetUserInventoriesPath))
            {
                mGetUserInventoriesPath = mGetUserInventoriesPath.Replace("{format}", "json");
            }
            mGetUserInventoriesPath = mGetUserInventoriesPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (inactive != null)
            {
                queryParams.Add("inactive", KnetikClient.DefaultClient.ParameterToString(inactive));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (filterItemName != null)
            {
                queryParams.Add("filter_item_name", KnetikClient.DefaultClient.ParameterToString(filterItemName));
            }

            if (filterItemId != null)
            {
                queryParams.Add("filter_item_id", KnetikClient.DefaultClient.ParameterToString(filterItemId));
            }

            if (filterUsername != null)
            {
                queryParams.Add("filter_username", KnetikClient.DefaultClient.ParameterToString(filterUsername));
            }

            if (filterGroup != null)
            {
                queryParams.Add("filter_group", KnetikClient.DefaultClient.ParameterToString(filterGroup));
            }

            if (filterDate != null)
            {
                queryParams.Add("filter_date", KnetikClient.DefaultClient.ParameterToString(filterDate));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserInventoriesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserInventoriesStartTime, mGetUserInventoriesPath, "Sending server request...");

            // make the HTTP request
            mGetUserInventoriesCoroutine.ResponseReceived += GetUserInventoriesCallback;
            mGetUserInventoriesCoroutine.Start(mGetUserInventoriesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserInventoriesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserInventories: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserInventories: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserInventoriesData = (PageResourceUserInventoryResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUserInventoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserInventoriesStartTime, mGetUserInventoriesPath, string.Format("Response received successfully:\n{0}", GetUserInventoriesData.ToString()));

            if (GetUserInventoriesComplete != null)
            {
                GetUserInventoriesComplete(GetUserInventoriesData);
            }
        }
        /// <summary>
        /// Get an inventory entry 
        /// </summary>
        /// <param name="userId">The id of the inventory owner or &#39;me&#39; for the logged in user</param>
        /// <param name="id">The id of the user inventory</param>
        public void GetUserInventory(int? userId, int? id)
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
            
            mGetUserInventoryPath = "/users/{user_id}/inventory/{id}";
            if (!string.IsNullOrEmpty(mGetUserInventoryPath))
            {
                mGetUserInventoryPath = mGetUserInventoryPath.Replace("{format}", "json");
            }
            mGetUserInventoryPath = mGetUserInventoryPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mGetUserInventoryPath = mGetUserInventoryPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserInventoryStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserInventoryStartTime, mGetUserInventoryPath, "Sending server request...");

            // make the HTTP request
            mGetUserInventoryCoroutine.ResponseReceived += GetUserInventoryCallback;
            mGetUserInventoryCoroutine.Start(mGetUserInventoryPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserInventoryCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserInventory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserInventory: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserInventoryData = (UserInventoryResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(UserInventoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserInventoryStartTime, mGetUserInventoryPath, string.Format("Response received successfully:\n{0}", GetUserInventoryData.ToString()));

            if (GetUserInventoryComplete != null)
            {
                GetUserInventoryComplete(GetUserInventoryData);
            }
        }
        /// <summary>
        /// List the log entries for this inventory entry 
        /// </summary>
        /// <param name="userId">The id of the inventory owner or &#39;me&#39; for the logged in user</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetUserInventoryLog(string userId, int? id, int? size, int? page)
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
            
            mGetUserInventoryLogPath = "/users/{user_id}/inventory/{id}/log";
            if (!string.IsNullOrEmpty(mGetUserInventoryLogPath))
            {
                mGetUserInventoryLogPath = mGetUserInventoryLogPath.Replace("{format}", "json");
            }
            mGetUserInventoryLogPath = mGetUserInventoryLogPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mGetUserInventoryLogPath = mGetUserInventoryLogPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserInventoryLogStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserInventoryLogStartTime, mGetUserInventoryLogPath, "Sending server request...");

            // make the HTTP request
            mGetUserInventoryLogCoroutine.ResponseReceived += GetUserInventoryLogCallback;
            mGetUserInventoryLogCoroutine.Start(mGetUserInventoryLogPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserInventoryLogCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserInventoryLog: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserInventoryLog: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserInventoryLogData = (PageResourceUserItemLogResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUserItemLogResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserInventoryLogStartTime, mGetUserInventoryLogPath, string.Format("Response received successfully:\n{0}", GetUserInventoryLogData.ToString()));

            if (GetUserInventoryLogComplete != null)
            {
                GetUserInventoryLogComplete(GetUserInventoryLogData);
            }
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
        public void GetUsersInventory(bool? inactive, int? size, int? page, string filterItemName, int? filterItemId, string filterUsername, string filterGroup, string filterDate)
        {
            
            mGetUsersInventoryPath = "/inventories";
            if (!string.IsNullOrEmpty(mGetUsersInventoryPath))
            {
                mGetUsersInventoryPath = mGetUsersInventoryPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (inactive != null)
            {
                queryParams.Add("inactive", KnetikClient.DefaultClient.ParameterToString(inactive));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (filterItemName != null)
            {
                queryParams.Add("filter_item_name", KnetikClient.DefaultClient.ParameterToString(filterItemName));
            }

            if (filterItemId != null)
            {
                queryParams.Add("filter_item_id", KnetikClient.DefaultClient.ParameterToString(filterItemId));
            }

            if (filterUsername != null)
            {
                queryParams.Add("filter_username", KnetikClient.DefaultClient.ParameterToString(filterUsername));
            }

            if (filterGroup != null)
            {
                queryParams.Add("filter_group", KnetikClient.DefaultClient.ParameterToString(filterGroup));
            }

            if (filterDate != null)
            {
                queryParams.Add("filter_date", KnetikClient.DefaultClient.ParameterToString(filterDate));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUsersInventoryStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUsersInventoryStartTime, mGetUsersInventoryPath, "Sending server request...");

            // make the HTTP request
            mGetUsersInventoryCoroutine.ResponseReceived += GetUsersInventoryCallback;
            mGetUsersInventoryCoroutine.Start(mGetUsersInventoryPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUsersInventoryCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsersInventory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsersInventory: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUsersInventoryData = (PageResourceUserInventoryResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUserInventoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetUsersInventoryStartTime, mGetUsersInventoryPath, string.Format("Response received successfully:\n{0}", GetUsersInventoryData.ToString()));

            if (GetUsersInventoryComplete != null)
            {
                GetUsersInventoryComplete(GetUsersInventoryData);
            }
        }
        /// <summary>
        /// Grant an entitlement 
        /// </summary>
        /// <param name="userId">The id of the user to grant the entitlement to</param>
        /// <param name="grantRequest">grantRequest</param>
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
            
            mGrantUserEntitlementPath = "/users/{user_id}/entitlements";
            if (!string.IsNullOrEmpty(mGrantUserEntitlementPath))
            {
                mGrantUserEntitlementPath = mGrantUserEntitlementPath.Replace("{format}", "json");
            }
            mGrantUserEntitlementPath = mGrantUserEntitlementPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(grantRequest); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGrantUserEntitlementStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGrantUserEntitlementStartTime, mGrantUserEntitlementPath, "Sending server request...");

            // make the HTTP request
            mGrantUserEntitlementCoroutine.ResponseReceived += GrantUserEntitlementCallback;
            mGrantUserEntitlementCoroutine.Start(mGrantUserEntitlementPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GrantUserEntitlementCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GrantUserEntitlement: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GrantUserEntitlement: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mGrantUserEntitlementStartTime, mGrantUserEntitlementPath, "Response received successfully.");
            if (GrantUserEntitlementComplete != null)
            {
                GrantUserEntitlementComplete();
            }
        }
        /// <summary>
        /// Update an entitlement item 
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="entitlementItem">The entitlement item object</param>
        public void UpdateEntitlementItem(int? entitlementId, bool? cascade, EntitlementItem entitlementItem)
        {
            // verify the required parameter 'entitlementId' is set
            if (entitlementId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'entitlementId' when calling UpdateEntitlementItem");
            }
            
            mUpdateEntitlementItemPath = "/entitlements/{entitlement_id}";
            if (!string.IsNullOrEmpty(mUpdateEntitlementItemPath))
            {
                mUpdateEntitlementItemPath = mUpdateEntitlementItemPath.Replace("{format}", "json");
            }
            mUpdateEntitlementItemPath = mUpdateEntitlementItemPath.Replace("{" + "entitlement_id" + "}", KnetikClient.DefaultClient.ParameterToString(entitlementId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            postBody = KnetikClient.DefaultClient.Serialize(entitlementItem); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateEntitlementItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateEntitlementItemStartTime, mUpdateEntitlementItemPath, "Sending server request...");

            // make the HTTP request
            mUpdateEntitlementItemCoroutine.ResponseReceived += UpdateEntitlementItemCallback;
            mUpdateEntitlementItemCoroutine.Start(mUpdateEntitlementItemPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateEntitlementItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateEntitlementItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateEntitlementItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateEntitlementItemStartTime, mUpdateEntitlementItemPath, "Response received successfully.");
            if (UpdateEntitlementItemComplete != null)
            {
                UpdateEntitlementItemComplete();
            }
        }
        /// <summary>
        /// Update an entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template</param>
        public void UpdateEntitlementTemplate(string id, ItemTemplateResource template)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateEntitlementTemplate");
            }
            
            mUpdateEntitlementTemplatePath = "/entitlements/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateEntitlementTemplatePath))
            {
                mUpdateEntitlementTemplatePath = mUpdateEntitlementTemplatePath.Replace("{format}", "json");
            }
            mUpdateEntitlementTemplatePath = mUpdateEntitlementTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateEntitlementTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateEntitlementTemplateStartTime, mUpdateEntitlementTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateEntitlementTemplateCoroutine.ResponseReceived += UpdateEntitlementTemplateCallback;
            mUpdateEntitlementTemplateCoroutine.Start(mUpdateEntitlementTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateEntitlementTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateEntitlementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateEntitlementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateEntitlementTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateEntitlementTemplateStartTime, mUpdateEntitlementTemplatePath, string.Format("Response received successfully:\n{0}", UpdateEntitlementTemplateData.ToString()));

            if (UpdateEntitlementTemplateComplete != null)
            {
                UpdateEntitlementTemplateComplete(UpdateEntitlementTemplateData);
            }
        }
        /// <summary>
        /// Set the behavior data for an inventory entry 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="data">The data map</param>
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
            
            mUpdateUserInventoryBehaviorDataPath = "/users/{user_id}/inventory/{id}/behavior-data";
            if (!string.IsNullOrEmpty(mUpdateUserInventoryBehaviorDataPath))
            {
                mUpdateUserInventoryBehaviorDataPath = mUpdateUserInventoryBehaviorDataPath.Replace("{format}", "json");
            }
            mUpdateUserInventoryBehaviorDataPath = mUpdateUserInventoryBehaviorDataPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mUpdateUserInventoryBehaviorDataPath = mUpdateUserInventoryBehaviorDataPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(data); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateUserInventoryBehaviorDataStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateUserInventoryBehaviorDataStartTime, mUpdateUserInventoryBehaviorDataPath, "Sending server request...");

            // make the HTTP request
            mUpdateUserInventoryBehaviorDataCoroutine.ResponseReceived += UpdateUserInventoryBehaviorDataCallback;
            mUpdateUserInventoryBehaviorDataCoroutine.Start(mUpdateUserInventoryBehaviorDataPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateUserInventoryBehaviorDataCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUserInventoryBehaviorData: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUserInventoryBehaviorData: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateUserInventoryBehaviorDataStartTime, mUpdateUserInventoryBehaviorDataPath, "Response received successfully.");
            if (UpdateUserInventoryBehaviorDataComplete != null)
            {
                UpdateUserInventoryBehaviorDataComplete();
            }
        }
        /// <summary>
        /// Set the expiration date Will change the current grace period for a subscription but not the bill date (possibly even ending before having the chance to re-bill)
        /// </summary>
        /// <param name="userId">user_id</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="timestamp">The new expiration date as a unix timestamp in seconds. May be null (no body).</param>
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
            
            mUpdateUserInventoryExpiresPath = "/users/{user_id}/inventory/{id}/expires";
            if (!string.IsNullOrEmpty(mUpdateUserInventoryExpiresPath))
            {
                mUpdateUserInventoryExpiresPath = mUpdateUserInventoryExpiresPath.Replace("{format}", "json");
            }
            mUpdateUserInventoryExpiresPath = mUpdateUserInventoryExpiresPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mUpdateUserInventoryExpiresPath = mUpdateUserInventoryExpiresPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(timestamp); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateUserInventoryExpiresStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateUserInventoryExpiresStartTime, mUpdateUserInventoryExpiresPath, "Sending server request...");

            // make the HTTP request
            mUpdateUserInventoryExpiresCoroutine.ResponseReceived += UpdateUserInventoryExpiresCallback;
            mUpdateUserInventoryExpiresCoroutine.Start(mUpdateUserInventoryExpiresPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateUserInventoryExpiresCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUserInventoryExpires: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUserInventoryExpires: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateUserInventoryExpiresStartTime, mUpdateUserInventoryExpiresPath, "Response received successfully.");
            if (UpdateUserInventoryExpiresComplete != null)
            {
                UpdateUserInventoryExpiresComplete();
            }
        }
        /// <summary>
        /// Set the status for an inventory entry 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="inventoryStatus">The inventory status object</param>
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
            
            mUpdateUserInventoryStatusPath = "/users/{user_id}/inventory/{id}/status";
            if (!string.IsNullOrEmpty(mUpdateUserInventoryStatusPath))
            {
                mUpdateUserInventoryStatusPath = mUpdateUserInventoryStatusPath.Replace("{format}", "json");
            }
            mUpdateUserInventoryStatusPath = mUpdateUserInventoryStatusPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mUpdateUserInventoryStatusPath = mUpdateUserInventoryStatusPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(inventoryStatus); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateUserInventoryStatusStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateUserInventoryStatusStartTime, mUpdateUserInventoryStatusPath, "Sending server request...");

            // make the HTTP request
            mUpdateUserInventoryStatusCoroutine.ResponseReceived += UpdateUserInventoryStatusCallback;
            mUpdateUserInventoryStatusCoroutine.Start(mUpdateUserInventoryStatusPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateUserInventoryStatusCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUserInventoryStatus: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUserInventoryStatus: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateUserInventoryStatusStartTime, mUpdateUserInventoryStatusPath, "Response received successfully.");
            if (UpdateUserInventoryStatusComplete != null)
            {
                UpdateUserInventoryStatusComplete();
            }
        }
        /// <summary>
        /// Use an item 
        /// </summary>
        /// <param name="userId">The id of the user to check for or &#39;me&#39; for logged in user</param>
        /// <param name="itemId">The id of the item</param>
        /// <param name="sku">The specific sku of an entitlement_list addition to check entitlement for. This is of very limited and specific use and should generally be left out</param>
        /// <param name="info">Any additional info to add to the log about this use</param>
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
            
            mUseUserEntitlementItemPath = "/users/{user_id}/entitlements/{item_id}/use";
            if (!string.IsNullOrEmpty(mUseUserEntitlementItemPath))
            {
                mUseUserEntitlementItemPath = mUseUserEntitlementItemPath.Replace("{format}", "json");
            }
            mUseUserEntitlementItemPath = mUseUserEntitlementItemPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mUseUserEntitlementItemPath = mUseUserEntitlementItemPath.Replace("{" + "item_id" + "}", KnetikClient.DefaultClient.ParameterToString(itemId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (sku != null)
            {
                queryParams.Add("sku", KnetikClient.DefaultClient.ParameterToString(sku));
            }

            if (info != null)
            {
                queryParams.Add("info", KnetikClient.DefaultClient.ParameterToString(info));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUseUserEntitlementItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUseUserEntitlementItemStartTime, mUseUserEntitlementItemPath, "Sending server request...");

            // make the HTTP request
            mUseUserEntitlementItemCoroutine.ResponseReceived += UseUserEntitlementItemCallback;
            mUseUserEntitlementItemCoroutine.Start(mUseUserEntitlementItemPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UseUserEntitlementItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UseUserEntitlementItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UseUserEntitlementItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUseUserEntitlementItemStartTime, mUseUserEntitlementItemPath, "Response received successfully.");
            if (UseUserEntitlementItemComplete != null)
            {
                UseUserEntitlementItemComplete();
            }
        }
    }
}
