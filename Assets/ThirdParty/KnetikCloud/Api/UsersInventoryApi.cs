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
    public interface IUsersInventoryApi
    {
        InvoiceResource AddItemToUserInventoryData { get; }

        /// <summary>
        /// Adds an item to the user inventory The inventory is fulfilled asynchronously UNLESS the invoice is explicitely skipped. Depending on the use case, it might require the client to verify that the entitlement was added after the fact or configure a BRE rule to get a notification in real time. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="userInventoryAddRequest">The user inventory add request object</param>
        void AddItemToUserInventory(int? id, UserInventoryAddRequest userInventoryAddRequest);

        

        /// <summary>
        /// Check for access to an item without consuming Useful for pre-check and accounts for all various buisness rules. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN or owner
        /// </summary>
        /// <param name="userId">The id of the user to check for or &#39;me&#39; for logged in user</param>
        /// <param name="itemId">The id of the item</param>
        /// <param name="sku">The specific sku of an entitlement list addition to check entitlement for. This is of very limited and specific use and should generally be left out</param>
        void CheckUserEntitlementItem(string userId, int? itemId, string sku);

        EntitlementItem CreateEntitlementItemData { get; }

        /// <summary>
        /// Create an entitlement item &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="entitlementItem">The entitlement item object</param>
        void CreateEntitlementItem(bool? cascade, EntitlementItem entitlementItem);

        ItemTemplateResource CreateEntitlementTemplateData { get; }

        /// <summary>
        /// Create an entitlement template Entitlement templates define a type of entitlement and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="template">The entitlement template to be created</param>
        void CreateEntitlementTemplate(ItemTemplateResource template);

        

        /// <summary>
        /// Delete an entitlement item &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        void DeleteEntitlementItem(int? entitlementId);

        

        /// <summary>
        /// Delete an entitlement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteEntitlementTemplate(string id, string cascade);

        EntitlementItem GetEntitlementItemData { get; }

        /// <summary>
        /// Get a single entitlement item &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        void GetEntitlementItem(int? entitlementId);

        PageResourceEntitlementItem GetEntitlementItemsData { get; }

        /// <summary>
        /// List and search entitlement items &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterTemplate">Filter for entitlements using a specified template</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetEntitlementItems(string filterTemplate, int? size, int? page, string order);

        ItemTemplateResource GetEntitlementTemplateData { get; }

        /// <summary>
        /// Get a single entitlement template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetEntitlementTemplate(string id);

        PageResourceItemTemplateResource GetEntitlementTemplatesData { get; }

        /// <summary>
        /// List and search entitlement templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetEntitlementTemplates(int? size, int? page, string order);

        PageResourceUserInventoryResource GetUserInventoriesData { get; }

        /// <summary>
        /// List the user inventory entries for a given user &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN or owner
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

        UserInventoryResource GetUserInventoryData { get; }

        /// <summary>
        /// Get an inventory entry &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
        /// </summary>
        /// <param name="userId">The id of the inventory owner or &#39;me&#39; for the logged in user</param>
        /// <param name="id">The id of the user inventory</param>
        void GetUserInventory(string userId, int? id);

        PageResourceUserItemLogResource GetUserInventoryLogData { get; }

        /// <summary>
        /// List the log entries for this inventory entry &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN or owner
        /// </summary>
        /// <param name="userId">The id of the inventory owner or &#39;me&#39; for the logged in user</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUserInventoryLog(string userId, int? id, int? size, int? page);

        PageResourceUserInventoryResource GetUsersInventoryData { get; }

        /// <summary>
        /// List the user inventory entries for all users &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
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
        /// Grant an entitlement &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
        /// </summary>
        /// <param name="userId">The id of the user to grant the entitlement to</param>
        /// <param name="grantRequest">grantRequest</param>
        void GrantUserEntitlement(int? userId, EntitlementGrantRequest grantRequest);

        

        /// <summary>
        /// Update an entitlement item &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="entitlementItem">The entitlement item object</param>
        void UpdateEntitlementItem(int? entitlementId, bool? cascade, EntitlementItem entitlementItem);

        ItemTemplateResource UpdateEntitlementTemplateData { get; }

        /// <summary>
        /// Update an entitlement template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template</param>
        void UpdateEntitlementTemplate(string id, ItemTemplateResource template);

        

        /// <summary>
        /// Set the behavior data for an inventory entry &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="data">The data map</param>
        void UpdateUserInventoryBehaviorData(int? userId, int? id, Object data);

        

        /// <summary>
        /// Set the expiration date Will change the current grace period for a subscription but not the bill date (possibly even ending before having the chance to re-bill). &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
        /// </summary>
        /// <param name="userId">user_id</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="timestamp">The new expiration date as a unix timestamp in seconds. May be null (no body).</param>
        void UpdateUserInventoryExpires(int? userId, int? id, long? timestamp);

        

        /// <summary>
        /// Set the status for an inventory entry &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the user inventory</param>
        /// <param name="inventoryStatus">The inventory status object</param>
        void UpdateUserInventoryStatus(int? userId, int? id, string inventoryStatus);

        

        /// <summary>
        /// Use an item &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN or owner
        /// </summary>
        /// <param name="userId">The id of the user to check for or &#39;me&#39; for logged in user</param>
        /// <param name="itemId">The id of the item</param>
        /// <param name="sku">The specific sku of an entitlement_list addition to check entitlement for. This is of very limited and specific use and should generally be left out</param>
        /// <param name="info">Any additional info to add to the log about this use</param>
        void UseUserEntitlementItem(string userId, int? itemId, string sku, string info);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UsersInventoryApi : IUsersInventoryApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddItemToUserInventoryResponseContext;
        private DateTime mAddItemToUserInventoryStartTime;
        private readonly KnetikResponseContext mCheckUserEntitlementItemResponseContext;
        private DateTime mCheckUserEntitlementItemStartTime;
        private readonly KnetikResponseContext mCreateEntitlementItemResponseContext;
        private DateTime mCreateEntitlementItemStartTime;
        private readonly KnetikResponseContext mCreateEntitlementTemplateResponseContext;
        private DateTime mCreateEntitlementTemplateStartTime;
        private readonly KnetikResponseContext mDeleteEntitlementItemResponseContext;
        private DateTime mDeleteEntitlementItemStartTime;
        private readonly KnetikResponseContext mDeleteEntitlementTemplateResponseContext;
        private DateTime mDeleteEntitlementTemplateStartTime;
        private readonly KnetikResponseContext mGetEntitlementItemResponseContext;
        private DateTime mGetEntitlementItemStartTime;
        private readonly KnetikResponseContext mGetEntitlementItemsResponseContext;
        private DateTime mGetEntitlementItemsStartTime;
        private readonly KnetikResponseContext mGetEntitlementTemplateResponseContext;
        private DateTime mGetEntitlementTemplateStartTime;
        private readonly KnetikResponseContext mGetEntitlementTemplatesResponseContext;
        private DateTime mGetEntitlementTemplatesStartTime;
        private readonly KnetikResponseContext mGetUserInventoriesResponseContext;
        private DateTime mGetUserInventoriesStartTime;
        private readonly KnetikResponseContext mGetUserInventoryResponseContext;
        private DateTime mGetUserInventoryStartTime;
        private readonly KnetikResponseContext mGetUserInventoryLogResponseContext;
        private DateTime mGetUserInventoryLogStartTime;
        private readonly KnetikResponseContext mGetUsersInventoryResponseContext;
        private DateTime mGetUsersInventoryStartTime;
        private readonly KnetikResponseContext mGrantUserEntitlementResponseContext;
        private DateTime mGrantUserEntitlementStartTime;
        private readonly KnetikResponseContext mUpdateEntitlementItemResponseContext;
        private DateTime mUpdateEntitlementItemStartTime;
        private readonly KnetikResponseContext mUpdateEntitlementTemplateResponseContext;
        private DateTime mUpdateEntitlementTemplateStartTime;
        private readonly KnetikResponseContext mUpdateUserInventoryBehaviorDataResponseContext;
        private DateTime mUpdateUserInventoryBehaviorDataStartTime;
        private readonly KnetikResponseContext mUpdateUserInventoryExpiresResponseContext;
        private DateTime mUpdateUserInventoryExpiresStartTime;
        private readonly KnetikResponseContext mUpdateUserInventoryStatusResponseContext;
        private DateTime mUpdateUserInventoryStatusStartTime;
        private readonly KnetikResponseContext mUseUserEntitlementItemResponseContext;
        private DateTime mUseUserEntitlementItemStartTime;

        public InvoiceResource AddItemToUserInventoryData { get; private set; }
        public delegate void AddItemToUserInventoryCompleteDelegate(long responseCode, InvoiceResource response);
        public AddItemToUserInventoryCompleteDelegate AddItemToUserInventoryComplete;

        public delegate void CheckUserEntitlementItemCompleteDelegate(long responseCode);
        public CheckUserEntitlementItemCompleteDelegate CheckUserEntitlementItemComplete;

        public EntitlementItem CreateEntitlementItemData { get; private set; }
        public delegate void CreateEntitlementItemCompleteDelegate(long responseCode, EntitlementItem response);
        public CreateEntitlementItemCompleteDelegate CreateEntitlementItemComplete;

        public ItemTemplateResource CreateEntitlementTemplateData { get; private set; }
        public delegate void CreateEntitlementTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public CreateEntitlementTemplateCompleteDelegate CreateEntitlementTemplateComplete;

        public delegate void DeleteEntitlementItemCompleteDelegate(long responseCode);
        public DeleteEntitlementItemCompleteDelegate DeleteEntitlementItemComplete;

        public delegate void DeleteEntitlementTemplateCompleteDelegate(long responseCode);
        public DeleteEntitlementTemplateCompleteDelegate DeleteEntitlementTemplateComplete;

        public EntitlementItem GetEntitlementItemData { get; private set; }
        public delegate void GetEntitlementItemCompleteDelegate(long responseCode, EntitlementItem response);
        public GetEntitlementItemCompleteDelegate GetEntitlementItemComplete;

        public PageResourceEntitlementItem GetEntitlementItemsData { get; private set; }
        public delegate void GetEntitlementItemsCompleteDelegate(long responseCode, PageResourceEntitlementItem response);
        public GetEntitlementItemsCompleteDelegate GetEntitlementItemsComplete;

        public ItemTemplateResource GetEntitlementTemplateData { get; private set; }
        public delegate void GetEntitlementTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public GetEntitlementTemplateCompleteDelegate GetEntitlementTemplateComplete;

        public PageResourceItemTemplateResource GetEntitlementTemplatesData { get; private set; }
        public delegate void GetEntitlementTemplatesCompleteDelegate(long responseCode, PageResourceItemTemplateResource response);
        public GetEntitlementTemplatesCompleteDelegate GetEntitlementTemplatesComplete;

        public PageResourceUserInventoryResource GetUserInventoriesData { get; private set; }
        public delegate void GetUserInventoriesCompleteDelegate(long responseCode, PageResourceUserInventoryResource response);
        public GetUserInventoriesCompleteDelegate GetUserInventoriesComplete;

        public UserInventoryResource GetUserInventoryData { get; private set; }
        public delegate void GetUserInventoryCompleteDelegate(long responseCode, UserInventoryResource response);
        public GetUserInventoryCompleteDelegate GetUserInventoryComplete;

        public PageResourceUserItemLogResource GetUserInventoryLogData { get; private set; }
        public delegate void GetUserInventoryLogCompleteDelegate(long responseCode, PageResourceUserItemLogResource response);
        public GetUserInventoryLogCompleteDelegate GetUserInventoryLogComplete;

        public PageResourceUserInventoryResource GetUsersInventoryData { get; private set; }
        public delegate void GetUsersInventoryCompleteDelegate(long responseCode, PageResourceUserInventoryResource response);
        public GetUsersInventoryCompleteDelegate GetUsersInventoryComplete;

        public delegate void GrantUserEntitlementCompleteDelegate(long responseCode);
        public GrantUserEntitlementCompleteDelegate GrantUserEntitlementComplete;

        public delegate void UpdateEntitlementItemCompleteDelegate(long responseCode);
        public UpdateEntitlementItemCompleteDelegate UpdateEntitlementItemComplete;

        public ItemTemplateResource UpdateEntitlementTemplateData { get; private set; }
        public delegate void UpdateEntitlementTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public UpdateEntitlementTemplateCompleteDelegate UpdateEntitlementTemplateComplete;

        public delegate void UpdateUserInventoryBehaviorDataCompleteDelegate(long responseCode);
        public UpdateUserInventoryBehaviorDataCompleteDelegate UpdateUserInventoryBehaviorDataComplete;

        public delegate void UpdateUserInventoryExpiresCompleteDelegate(long responseCode);
        public UpdateUserInventoryExpiresCompleteDelegate UpdateUserInventoryExpiresComplete;

        public delegate void UpdateUserInventoryStatusCompleteDelegate(long responseCode);
        public UpdateUserInventoryStatusCompleteDelegate UpdateUserInventoryStatusComplete;

        public delegate void UseUserEntitlementItemCompleteDelegate(long responseCode);
        public UseUserEntitlementItemCompleteDelegate UseUserEntitlementItemComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersInventoryApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersInventoryApi()
        {
            mAddItemToUserInventoryResponseContext = new KnetikResponseContext();
            mAddItemToUserInventoryResponseContext.ResponseReceived += OnAddItemToUserInventoryResponse;
            mCheckUserEntitlementItemResponseContext = new KnetikResponseContext();
            mCheckUserEntitlementItemResponseContext.ResponseReceived += OnCheckUserEntitlementItemResponse;
            mCreateEntitlementItemResponseContext = new KnetikResponseContext();
            mCreateEntitlementItemResponseContext.ResponseReceived += OnCreateEntitlementItemResponse;
            mCreateEntitlementTemplateResponseContext = new KnetikResponseContext();
            mCreateEntitlementTemplateResponseContext.ResponseReceived += OnCreateEntitlementTemplateResponse;
            mDeleteEntitlementItemResponseContext = new KnetikResponseContext();
            mDeleteEntitlementItemResponseContext.ResponseReceived += OnDeleteEntitlementItemResponse;
            mDeleteEntitlementTemplateResponseContext = new KnetikResponseContext();
            mDeleteEntitlementTemplateResponseContext.ResponseReceived += OnDeleteEntitlementTemplateResponse;
            mGetEntitlementItemResponseContext = new KnetikResponseContext();
            mGetEntitlementItemResponseContext.ResponseReceived += OnGetEntitlementItemResponse;
            mGetEntitlementItemsResponseContext = new KnetikResponseContext();
            mGetEntitlementItemsResponseContext.ResponseReceived += OnGetEntitlementItemsResponse;
            mGetEntitlementTemplateResponseContext = new KnetikResponseContext();
            mGetEntitlementTemplateResponseContext.ResponseReceived += OnGetEntitlementTemplateResponse;
            mGetEntitlementTemplatesResponseContext = new KnetikResponseContext();
            mGetEntitlementTemplatesResponseContext.ResponseReceived += OnGetEntitlementTemplatesResponse;
            mGetUserInventoriesResponseContext = new KnetikResponseContext();
            mGetUserInventoriesResponseContext.ResponseReceived += OnGetUserInventoriesResponse;
            mGetUserInventoryResponseContext = new KnetikResponseContext();
            mGetUserInventoryResponseContext.ResponseReceived += OnGetUserInventoryResponse;
            mGetUserInventoryLogResponseContext = new KnetikResponseContext();
            mGetUserInventoryLogResponseContext.ResponseReceived += OnGetUserInventoryLogResponse;
            mGetUsersInventoryResponseContext = new KnetikResponseContext();
            mGetUsersInventoryResponseContext.ResponseReceived += OnGetUsersInventoryResponse;
            mGrantUserEntitlementResponseContext = new KnetikResponseContext();
            mGrantUserEntitlementResponseContext.ResponseReceived += OnGrantUserEntitlementResponse;
            mUpdateEntitlementItemResponseContext = new KnetikResponseContext();
            mUpdateEntitlementItemResponseContext.ResponseReceived += OnUpdateEntitlementItemResponse;
            mUpdateEntitlementTemplateResponseContext = new KnetikResponseContext();
            mUpdateEntitlementTemplateResponseContext.ResponseReceived += OnUpdateEntitlementTemplateResponse;
            mUpdateUserInventoryBehaviorDataResponseContext = new KnetikResponseContext();
            mUpdateUserInventoryBehaviorDataResponseContext.ResponseReceived += OnUpdateUserInventoryBehaviorDataResponse;
            mUpdateUserInventoryExpiresResponseContext = new KnetikResponseContext();
            mUpdateUserInventoryExpiresResponseContext.ResponseReceived += OnUpdateUserInventoryExpiresResponse;
            mUpdateUserInventoryStatusResponseContext = new KnetikResponseContext();
            mUpdateUserInventoryStatusResponseContext.ResponseReceived += OnUpdateUserInventoryStatusResponse;
            mUseUserEntitlementItemResponseContext = new KnetikResponseContext();
            mUseUserEntitlementItemResponseContext.ResponseReceived += OnUseUserEntitlementItemResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Adds an item to the user inventory The inventory is fulfilled asynchronously UNLESS the invoice is explicitely skipped. Depending on the use case, it might require the client to verify that the entitlement was added after the fact or configure a BRE rule to get a notification in real time. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
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
            
            mWebCallEvent.WebPath = "/users/{id}/inventory";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(userInventoryAddRequest); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddItemToUserInventoryStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddItemToUserInventoryResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddItemToUserInventoryStartTime, "AddItemToUserInventory", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddItemToUserInventoryResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddItemToUserInventory: " + response.Error);
            }

            AddItemToUserInventoryData = (InvoiceResource) KnetikClient.Deserialize(response.Content, typeof(InvoiceResource), response.Headers);
            KnetikLogger.LogResponse(mAddItemToUserInventoryStartTime, "AddItemToUserInventory", string.Format("Response received successfully:\n{0}", AddItemToUserInventoryData));

            if (AddItemToUserInventoryComplete != null)
            {
                AddItemToUserInventoryComplete(response.ResponseCode, AddItemToUserInventoryData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Check for access to an item without consuming Useful for pre-check and accounts for all various buisness rules. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/entitlements/{item_id}/check";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "item_id" + "}", KnetikClient.ParameterToString(itemId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (sku != null)
            {
                mWebCallEvent.QueryParams["sku"] = KnetikClient.ParameterToString(sku);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCheckUserEntitlementItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mCheckUserEntitlementItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mCheckUserEntitlementItemStartTime, "CheckUserEntitlementItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCheckUserEntitlementItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CheckUserEntitlementItem: " + response.Error);
            }

            KnetikLogger.LogResponse(mCheckUserEntitlementItemStartTime, "CheckUserEntitlementItem", "Response received successfully.");
            if (CheckUserEntitlementItemComplete != null)
            {
                CheckUserEntitlementItemComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create an entitlement item &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="entitlementItem">The entitlement item object</param>
        public void CreateEntitlementItem(bool? cascade, EntitlementItem entitlementItem)
        {
            
            mWebCallEvent.WebPath = "/entitlements";
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

            mWebCallEvent.PostBody = KnetikClient.Serialize(entitlementItem); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateEntitlementItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateEntitlementItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateEntitlementItemStartTime, "CreateEntitlementItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateEntitlementItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateEntitlementItem: " + response.Error);
            }

            CreateEntitlementItemData = (EntitlementItem) KnetikClient.Deserialize(response.Content, typeof(EntitlementItem), response.Headers);
            KnetikLogger.LogResponse(mCreateEntitlementItemStartTime, "CreateEntitlementItem", string.Format("Response received successfully:\n{0}", CreateEntitlementItemData));

            if (CreateEntitlementItemComplete != null)
            {
                CreateEntitlementItemComplete(response.ResponseCode, CreateEntitlementItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create an entitlement template Entitlement templates define a type of entitlement and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="template">The entitlement template to be created</param>
        public void CreateEntitlementTemplate(ItemTemplateResource template)
        {
            
            mWebCallEvent.WebPath = "/entitlements/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(template); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateEntitlementTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateEntitlementTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateEntitlementTemplateStartTime, "CreateEntitlementTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateEntitlementTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateEntitlementTemplate: " + response.Error);
            }

            CreateEntitlementTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateEntitlementTemplateStartTime, "CreateEntitlementTemplate", string.Format("Response received successfully:\n{0}", CreateEntitlementTemplateData));

            if (CreateEntitlementTemplateComplete != null)
            {
                CreateEntitlementTemplateComplete(response.ResponseCode, CreateEntitlementTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an entitlement item &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        public void DeleteEntitlementItem(int? entitlementId)
        {
            // verify the required parameter 'entitlementId' is set
            if (entitlementId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'entitlementId' when calling DeleteEntitlementItem");
            }
            
            mWebCallEvent.WebPath = "/entitlements/{entitlement_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "entitlement_id" + "}", KnetikClient.ParameterToString(entitlementId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteEntitlementItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteEntitlementItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteEntitlementItemStartTime, "DeleteEntitlementItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteEntitlementItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteEntitlementItem: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteEntitlementItemStartTime, "DeleteEntitlementItem", "Response received successfully.");
            if (DeleteEntitlementItemComplete != null)
            {
                DeleteEntitlementItemComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an entitlement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
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
            
            mWebCallEvent.WebPath = "/entitlements/templates/{id}";
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
            mDeleteEntitlementTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteEntitlementTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteEntitlementTemplateStartTime, "DeleteEntitlementTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteEntitlementTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteEntitlementTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteEntitlementTemplateStartTime, "DeleteEntitlementTemplate", "Response received successfully.");
            if (DeleteEntitlementTemplateComplete != null)
            {
                DeleteEntitlementTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single entitlement item &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="entitlementId">The id of the entitlement</param>
        public void GetEntitlementItem(int? entitlementId)
        {
            // verify the required parameter 'entitlementId' is set
            if (entitlementId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'entitlementId' when calling GetEntitlementItem");
            }
            
            mWebCallEvent.WebPath = "/entitlements/{entitlement_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "entitlement_id" + "}", KnetikClient.ParameterToString(entitlementId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetEntitlementItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetEntitlementItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetEntitlementItemStartTime, "GetEntitlementItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetEntitlementItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetEntitlementItem: " + response.Error);
            }

            GetEntitlementItemData = (EntitlementItem) KnetikClient.Deserialize(response.Content, typeof(EntitlementItem), response.Headers);
            KnetikLogger.LogResponse(mGetEntitlementItemStartTime, "GetEntitlementItem", string.Format("Response received successfully:\n{0}", GetEntitlementItemData));

            if (GetEntitlementItemComplete != null)
            {
                GetEntitlementItemComplete(response.ResponseCode, GetEntitlementItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search entitlement items &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterTemplate">Filter for entitlements using a specified template</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetEntitlementItems(string filterTemplate, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/entitlements";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterTemplate != null)
            {
                mWebCallEvent.QueryParams["filter_template"] = KnetikClient.ParameterToString(filterTemplate);
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
            mGetEntitlementItemsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetEntitlementItemsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetEntitlementItemsStartTime, "GetEntitlementItems", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetEntitlementItemsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetEntitlementItems: " + response.Error);
            }

            GetEntitlementItemsData = (PageResourceEntitlementItem) KnetikClient.Deserialize(response.Content, typeof(PageResourceEntitlementItem), response.Headers);
            KnetikLogger.LogResponse(mGetEntitlementItemsStartTime, "GetEntitlementItems", string.Format("Response received successfully:\n{0}", GetEntitlementItemsData));

            if (GetEntitlementItemsComplete != null)
            {
                GetEntitlementItemsComplete(response.ResponseCode, GetEntitlementItemsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single entitlement template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetEntitlementTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetEntitlementTemplate");
            }
            
            mWebCallEvent.WebPath = "/entitlements/templates/{id}";
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
            mGetEntitlementTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetEntitlementTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetEntitlementTemplateStartTime, "GetEntitlementTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetEntitlementTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetEntitlementTemplate: " + response.Error);
            }

            GetEntitlementTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetEntitlementTemplateStartTime, "GetEntitlementTemplate", string.Format("Response received successfully:\n{0}", GetEntitlementTemplateData));

            if (GetEntitlementTemplateComplete != null)
            {
                GetEntitlementTemplateComplete(response.ResponseCode, GetEntitlementTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search entitlement templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetEntitlementTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/entitlements/templates";
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
            mGetEntitlementTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetEntitlementTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetEntitlementTemplatesStartTime, "GetEntitlementTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetEntitlementTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetEntitlementTemplates: " + response.Error);
            }

            GetEntitlementTemplatesData = (PageResourceItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetEntitlementTemplatesStartTime, "GetEntitlementTemplates", string.Format("Response received successfully:\n{0}", GetEntitlementTemplatesData));

            if (GetEntitlementTemplatesComplete != null)
            {
                GetEntitlementTemplatesComplete(response.ResponseCode, GetEntitlementTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List the user inventory entries for a given user &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/users/{id}/inventory";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (inactive != null)
            {
                mWebCallEvent.QueryParams["inactive"] = KnetikClient.ParameterToString(inactive);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (filterItemName != null)
            {
                mWebCallEvent.QueryParams["filter_item_name"] = KnetikClient.ParameterToString(filterItemName);
            }

            if (filterItemId != null)
            {
                mWebCallEvent.QueryParams["filter_item_id"] = KnetikClient.ParameterToString(filterItemId);
            }

            if (filterUsername != null)
            {
                mWebCallEvent.QueryParams["filter_username"] = KnetikClient.ParameterToString(filterUsername);
            }

            if (filterGroup != null)
            {
                mWebCallEvent.QueryParams["filter_group"] = KnetikClient.ParameterToString(filterGroup);
            }

            if (filterDate != null)
            {
                mWebCallEvent.QueryParams["filter_date"] = KnetikClient.ParameterToString(filterDate);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUserInventoriesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserInventoriesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserInventoriesStartTime, "GetUserInventories", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserInventoriesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserInventories: " + response.Error);
            }

            GetUserInventoriesData = (PageResourceUserInventoryResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserInventoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserInventoriesStartTime, "GetUserInventories", string.Format("Response received successfully:\n{0}", GetUserInventoriesData));

            if (GetUserInventoriesComplete != null)
            {
                GetUserInventoriesComplete(response.ResponseCode, GetUserInventoriesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get an inventory entry &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
        /// </summary>
        /// <param name="userId">The id of the inventory owner or &#39;me&#39; for the logged in user</param>
        /// <param name="id">The id of the user inventory</param>
        public void GetUserInventory(string userId, int? id)
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/inventory/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
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
            mGetUserInventoryStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserInventoryResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserInventoryStartTime, "GetUserInventory", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserInventoryResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserInventory: " + response.Error);
            }

            GetUserInventoryData = (UserInventoryResource) KnetikClient.Deserialize(response.Content, typeof(UserInventoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserInventoryStartTime, "GetUserInventory", string.Format("Response received successfully:\n{0}", GetUserInventoryData));

            if (GetUserInventoryComplete != null)
            {
                GetUserInventoryComplete(response.ResponseCode, GetUserInventoryData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List the log entries for this inventory entry &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/inventory/{id}/log";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

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

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUserInventoryLogStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserInventoryLogResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserInventoryLogStartTime, "GetUserInventoryLog", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserInventoryLogResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserInventoryLog: " + response.Error);
            }

            GetUserInventoryLogData = (PageResourceUserItemLogResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserItemLogResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserInventoryLogStartTime, "GetUserInventoryLog", string.Format("Response received successfully:\n{0}", GetUserInventoryLogData));

            if (GetUserInventoryLogComplete != null)
            {
                GetUserInventoryLogComplete(response.ResponseCode, GetUserInventoryLogData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List the user inventory entries for all users &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
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
            
            mWebCallEvent.WebPath = "/inventories";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (inactive != null)
            {
                mWebCallEvent.QueryParams["inactive"] = KnetikClient.ParameterToString(inactive);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (filterItemName != null)
            {
                mWebCallEvent.QueryParams["filter_item_name"] = KnetikClient.ParameterToString(filterItemName);
            }

            if (filterItemId != null)
            {
                mWebCallEvent.QueryParams["filter_item_id"] = KnetikClient.ParameterToString(filterItemId);
            }

            if (filterUsername != null)
            {
                mWebCallEvent.QueryParams["filter_username"] = KnetikClient.ParameterToString(filterUsername);
            }

            if (filterGroup != null)
            {
                mWebCallEvent.QueryParams["filter_group"] = KnetikClient.ParameterToString(filterGroup);
            }

            if (filterDate != null)
            {
                mWebCallEvent.QueryParams["filter_date"] = KnetikClient.ParameterToString(filterDate);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUsersInventoryStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUsersInventoryResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUsersInventoryStartTime, "GetUsersInventory", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUsersInventoryResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUsersInventory: " + response.Error);
            }

            GetUsersInventoryData = (PageResourceUserInventoryResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserInventoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetUsersInventoryStartTime, "GetUsersInventory", string.Format("Response received successfully:\n{0}", GetUsersInventoryData));

            if (GetUsersInventoryComplete != null)
            {
                GetUsersInventoryComplete(response.ResponseCode, GetUsersInventoryData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Grant an entitlement &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/entitlements";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(grantRequest); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGrantUserEntitlementStartTime = DateTime.Now;
            mWebCallEvent.Context = mGrantUserEntitlementResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mGrantUserEntitlementStartTime, "GrantUserEntitlement", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGrantUserEntitlementResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GrantUserEntitlement: " + response.Error);
            }

            KnetikLogger.LogResponse(mGrantUserEntitlementStartTime, "GrantUserEntitlement", "Response received successfully.");
            if (GrantUserEntitlementComplete != null)
            {
                GrantUserEntitlementComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an entitlement item &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
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
            
            mWebCallEvent.WebPath = "/entitlements/{entitlement_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "entitlement_id" + "}", KnetikClient.ParameterToString(entitlementId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (cascade != null)
            {
                mWebCallEvent.QueryParams["cascade"] = KnetikClient.ParameterToString(cascade);
            }

            mWebCallEvent.PostBody = KnetikClient.Serialize(entitlementItem); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateEntitlementItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateEntitlementItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateEntitlementItemStartTime, "UpdateEntitlementItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateEntitlementItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateEntitlementItem: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateEntitlementItemStartTime, "UpdateEntitlementItem", "Response received successfully.");
            if (UpdateEntitlementItemComplete != null)
            {
                UpdateEntitlementItemComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an entitlement template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
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
            
            mWebCallEvent.WebPath = "/entitlements/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(template); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateEntitlementTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateEntitlementTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateEntitlementTemplateStartTime, "UpdateEntitlementTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateEntitlementTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateEntitlementTemplate: " + response.Error);
            }

            UpdateEntitlementTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateEntitlementTemplateStartTime, "UpdateEntitlementTemplate", string.Format("Response received successfully:\n{0}", UpdateEntitlementTemplateData));

            if (UpdateEntitlementTemplateComplete != null)
            {
                UpdateEntitlementTemplateComplete(response.ResponseCode, UpdateEntitlementTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set the behavior data for an inventory entry &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/inventory/{id}/behavior-data";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(data); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateUserInventoryBehaviorDataStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateUserInventoryBehaviorDataResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateUserInventoryBehaviorDataStartTime, "UpdateUserInventoryBehaviorData", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateUserInventoryBehaviorDataResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateUserInventoryBehaviorData: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateUserInventoryBehaviorDataStartTime, "UpdateUserInventoryBehaviorData", "Response received successfully.");
            if (UpdateUserInventoryBehaviorDataComplete != null)
            {
                UpdateUserInventoryBehaviorDataComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set the expiration date Will change the current grace period for a subscription but not the bill date (possibly even ending before having the chance to re-bill). &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/inventory/{id}/expires";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(timestamp); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateUserInventoryExpiresStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateUserInventoryExpiresResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateUserInventoryExpiresStartTime, "UpdateUserInventoryExpires", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateUserInventoryExpiresResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateUserInventoryExpires: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateUserInventoryExpiresStartTime, "UpdateUserInventoryExpires", "Response received successfully.");
            if (UpdateUserInventoryExpiresComplete != null)
            {
                UpdateUserInventoryExpiresComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set the status for an inventory entry &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/inventory/{id}/status";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(inventoryStatus); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateUserInventoryStatusStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateUserInventoryStatusResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateUserInventoryStatusStartTime, "UpdateUserInventoryStatus", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateUserInventoryStatusResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateUserInventoryStatus: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateUserInventoryStatusStartTime, "UpdateUserInventoryStatus", "Response received successfully.");
            if (UpdateUserInventoryStatusComplete != null)
            {
                UpdateUserInventoryStatusComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Use an item &lt;b&gt;Permissions Needed:&lt;/b&gt; INVENTORY_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/entitlements/{item_id}/use";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "item_id" + "}", KnetikClient.ParameterToString(itemId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (sku != null)
            {
                mWebCallEvent.QueryParams["sku"] = KnetikClient.ParameterToString(sku);
            }

            if (info != null)
            {
                mWebCallEvent.QueryParams["info"] = KnetikClient.ParameterToString(info);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUseUserEntitlementItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mUseUserEntitlementItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mUseUserEntitlementItemStartTime, "UseUserEntitlementItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUseUserEntitlementItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UseUserEntitlementItem: " + response.Error);
            }

            KnetikLogger.LogResponse(mUseUserEntitlementItemStartTime, "UseUserEntitlementItem", "Response received successfully.");
            if (UseUserEntitlementItemComplete != null)
            {
                UseUserEntitlementItemComplete(response.ResponseCode);
            }
        }

    }
}
