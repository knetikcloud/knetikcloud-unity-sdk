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
    public interface IAuthRolesApi
    {
        RoleResource CreateRoleData { get; }

        /// <summary>
        /// Create a new role 
        /// </summary>
        /// <param name="roleResource">The role resource object</param>
        void CreateRole(RoleResource roleResource);

        

        /// <summary>
        /// Delete a role 
        /// </summary>
        /// <param name="role">The role value</param>
        /// <param name="force">If true, removes role from users/clients</param>
        void DeleteRole(string role, bool? force);

        List<RoleResource> GetClientRolesData { get; }

        /// <summary>
        /// Get roles for a client 
        /// </summary>
        /// <param name="clientKey">The client key</param>
        void GetClientRoles(string clientKey);

        RoleResource GetRoleData { get; }

        /// <summary>
        /// Get a single role 
        /// </summary>
        /// <param name="role">The role value</param>
        void GetRole(string role);

        PageResourceRoleResource GetRolesData { get; }

        /// <summary>
        /// List and search roles 
        /// </summary>
        /// <param name="filterName">Filter for roles that have a name starting with specified string</param>
        /// <param name="filterRole">Filter for roles that have a role starting with specified string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetRoles(string filterName, string filterRole, int? size, int? page, string order);

        List<RoleResource> GetUserRolesData { get; }

        /// <summary>
        /// Get roles for a user 
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        void GetUserRoles(int? userId);

        ClientResource SetClientRolesData { get; }

        /// <summary>
        /// Set roles for a client 
        /// </summary>
        /// <param name="clientKey">The client key</param>
        /// <param name="rolesList">The list of unique roles</param>
        void SetClientRoles(string clientKey, List<string> rolesList);

        RoleResource SetPermissionsForRoleData { get; }

        /// <summary>
        /// Set permissions for a role 
        /// </summary>
        /// <param name="role">The role value</param>
        /// <param name="permissionsList">The list of unique permissions</param>
        void SetPermissionsForRole(string role, List<string> permissionsList);

        UserResource SetUserRolesData { get; }

        /// <summary>
        /// Set roles for a user 
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="rolesList">The list of unique roles</param>
        void SetUserRoles(int? userId, List<string> rolesList);

        RoleResource UpdateRoleData { get; }

        /// <summary>
        /// Update a role 
        /// </summary>
        /// <param name="role">The role value</param>
        /// <param name="roleResource">The role resource object</param>
        void UpdateRole(string role, RoleResource roleResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthRolesApi : IAuthRolesApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateRoleResponseContext;
        private DateTime mCreateRoleStartTime;
        private readonly KnetikResponseContext mDeleteRoleResponseContext;
        private DateTime mDeleteRoleStartTime;
        private readonly KnetikResponseContext mGetClientRolesResponseContext;
        private DateTime mGetClientRolesStartTime;
        private readonly KnetikResponseContext mGetRoleResponseContext;
        private DateTime mGetRoleStartTime;
        private readonly KnetikResponseContext mGetRolesResponseContext;
        private DateTime mGetRolesStartTime;
        private readonly KnetikResponseContext mGetUserRolesResponseContext;
        private DateTime mGetUserRolesStartTime;
        private readonly KnetikResponseContext mSetClientRolesResponseContext;
        private DateTime mSetClientRolesStartTime;
        private readonly KnetikResponseContext mSetPermissionsForRoleResponseContext;
        private DateTime mSetPermissionsForRoleStartTime;
        private readonly KnetikResponseContext mSetUserRolesResponseContext;
        private DateTime mSetUserRolesStartTime;
        private readonly KnetikResponseContext mUpdateRoleResponseContext;
        private DateTime mUpdateRoleStartTime;

        public RoleResource CreateRoleData { get; private set; }
        public delegate void CreateRoleCompleteDelegate(long responseCode, RoleResource response);
        public CreateRoleCompleteDelegate CreateRoleComplete;

        public delegate void DeleteRoleCompleteDelegate(long responseCode);
        public DeleteRoleCompleteDelegate DeleteRoleComplete;

        public List<RoleResource> GetClientRolesData { get; private set; }
        public delegate void GetClientRolesCompleteDelegate(long responseCode, List<RoleResource> response);
        public GetClientRolesCompleteDelegate GetClientRolesComplete;

        public RoleResource GetRoleData { get; private set; }
        public delegate void GetRoleCompleteDelegate(long responseCode, RoleResource response);
        public GetRoleCompleteDelegate GetRoleComplete;

        public PageResourceRoleResource GetRolesData { get; private set; }
        public delegate void GetRolesCompleteDelegate(long responseCode, PageResourceRoleResource response);
        public GetRolesCompleteDelegate GetRolesComplete;

        public List<RoleResource> GetUserRolesData { get; private set; }
        public delegate void GetUserRolesCompleteDelegate(long responseCode, List<RoleResource> response);
        public GetUserRolesCompleteDelegate GetUserRolesComplete;

        public ClientResource SetClientRolesData { get; private set; }
        public delegate void SetClientRolesCompleteDelegate(long responseCode, ClientResource response);
        public SetClientRolesCompleteDelegate SetClientRolesComplete;

        public RoleResource SetPermissionsForRoleData { get; private set; }
        public delegate void SetPermissionsForRoleCompleteDelegate(long responseCode, RoleResource response);
        public SetPermissionsForRoleCompleteDelegate SetPermissionsForRoleComplete;

        public UserResource SetUserRolesData { get; private set; }
        public delegate void SetUserRolesCompleteDelegate(long responseCode, UserResource response);
        public SetUserRolesCompleteDelegate SetUserRolesComplete;

        public RoleResource UpdateRoleData { get; private set; }
        public delegate void UpdateRoleCompleteDelegate(long responseCode, RoleResource response);
        public UpdateRoleCompleteDelegate UpdateRoleComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRolesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthRolesApi()
        {
            mCreateRoleResponseContext = new KnetikResponseContext();
            mCreateRoleResponseContext.ResponseReceived += OnCreateRoleResponse;
            mDeleteRoleResponseContext = new KnetikResponseContext();
            mDeleteRoleResponseContext.ResponseReceived += OnDeleteRoleResponse;
            mGetClientRolesResponseContext = new KnetikResponseContext();
            mGetClientRolesResponseContext.ResponseReceived += OnGetClientRolesResponse;
            mGetRoleResponseContext = new KnetikResponseContext();
            mGetRoleResponseContext.ResponseReceived += OnGetRoleResponse;
            mGetRolesResponseContext = new KnetikResponseContext();
            mGetRolesResponseContext.ResponseReceived += OnGetRolesResponse;
            mGetUserRolesResponseContext = new KnetikResponseContext();
            mGetUserRolesResponseContext.ResponseReceived += OnGetUserRolesResponse;
            mSetClientRolesResponseContext = new KnetikResponseContext();
            mSetClientRolesResponseContext.ResponseReceived += OnSetClientRolesResponse;
            mSetPermissionsForRoleResponseContext = new KnetikResponseContext();
            mSetPermissionsForRoleResponseContext.ResponseReceived += OnSetPermissionsForRoleResponse;
            mSetUserRolesResponseContext = new KnetikResponseContext();
            mSetUserRolesResponseContext.ResponseReceived += OnSetUserRolesResponse;
            mUpdateRoleResponseContext = new KnetikResponseContext();
            mUpdateRoleResponseContext.ResponseReceived += OnUpdateRoleResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a new role 
        /// </summary>
        /// <param name="roleResource">The role resource object</param>
        public void CreateRole(RoleResource roleResource)
        {
            
            mWebCallEvent.WebPath = "/auth/roles";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(roleResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateRoleStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateRoleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateRoleStartTime, "CreateRole", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateRoleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateRole: " + response.Error);
            }

            CreateRoleData = (RoleResource) KnetikClient.Deserialize(response.Content, typeof(RoleResource), response.Headers);
            KnetikLogger.LogResponse(mCreateRoleStartTime, "CreateRole", string.Format("Response received successfully:\n{0}", CreateRoleData));

            if (CreateRoleComplete != null)
            {
                CreateRoleComplete(response.ResponseCode, CreateRoleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a role 
        /// </summary>
        /// <param name="role">The role value</param>
        /// <param name="force">If true, removes role from users/clients</param>
        public void DeleteRole(string role, bool? force)
        {
            // verify the required parameter 'role' is set
            if (role == null)
            {
                throw new KnetikException(400, "Missing required parameter 'role' when calling DeleteRole");
            }
            
            mWebCallEvent.WebPath = "/auth/roles/{role}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "role" + "}", KnetikClient.ParameterToString(role));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (force != null)
            {
                mWebCallEvent.QueryParams["force"] = KnetikClient.ParameterToString(force);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteRoleStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteRoleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteRoleStartTime, "DeleteRole", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteRoleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteRole: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteRoleStartTime, "DeleteRole", "Response received successfully.");
            if (DeleteRoleComplete != null)
            {
                DeleteRoleComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get roles for a client 
        /// </summary>
        /// <param name="clientKey">The client key</param>
        public void GetClientRoles(string clientKey)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling GetClientRoles");
            }
            
            mWebCallEvent.WebPath = "/auth/clients/{client_key}/roles";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetClientRolesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetClientRolesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetClientRolesStartTime, "GetClientRoles", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetClientRolesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetClientRoles: " + response.Error);
            }

            GetClientRolesData = (List<RoleResource>) KnetikClient.Deserialize(response.Content, typeof(List<RoleResource>), response.Headers);
            KnetikLogger.LogResponse(mGetClientRolesStartTime, "GetClientRoles", string.Format("Response received successfully:\n{0}", GetClientRolesData));

            if (GetClientRolesComplete != null)
            {
                GetClientRolesComplete(response.ResponseCode, GetClientRolesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single role 
        /// </summary>
        /// <param name="role">The role value</param>
        public void GetRole(string role)
        {
            // verify the required parameter 'role' is set
            if (role == null)
            {
                throw new KnetikException(400, "Missing required parameter 'role' when calling GetRole");
            }
            
            mWebCallEvent.WebPath = "/auth/roles/{role}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "role" + "}", KnetikClient.ParameterToString(role));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetRoleStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetRoleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetRoleStartTime, "GetRole", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetRoleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetRole: " + response.Error);
            }

            GetRoleData = (RoleResource) KnetikClient.Deserialize(response.Content, typeof(RoleResource), response.Headers);
            KnetikLogger.LogResponse(mGetRoleStartTime, "GetRole", string.Format("Response received successfully:\n{0}", GetRoleData));

            if (GetRoleComplete != null)
            {
                GetRoleComplete(response.ResponseCode, GetRoleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search roles 
        /// </summary>
        /// <param name="filterName">Filter for roles that have a name starting with specified string</param>
        /// <param name="filterRole">Filter for roles that have a role starting with specified string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetRoles(string filterName, string filterRole, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/auth/roles";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterName != null)
            {
                mWebCallEvent.QueryParams["filter_name"] = KnetikClient.ParameterToString(filterName);
            }

            if (filterRole != null)
            {
                mWebCallEvent.QueryParams["filter_role"] = KnetikClient.ParameterToString(filterRole);
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
            mGetRolesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetRolesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetRolesStartTime, "GetRoles", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetRolesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetRoles: " + response.Error);
            }

            GetRolesData = (PageResourceRoleResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceRoleResource), response.Headers);
            KnetikLogger.LogResponse(mGetRolesStartTime, "GetRoles", string.Format("Response received successfully:\n{0}", GetRolesData));

            if (GetRolesComplete != null)
            {
                GetRolesComplete(response.ResponseCode, GetRolesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get roles for a user 
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        public void GetUserRoles(int? userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserRoles");
            }
            
            mWebCallEvent.WebPath = "/auth/users/{user_id}/roles";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUserRolesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserRolesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserRolesStartTime, "GetUserRoles", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserRolesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserRoles: " + response.Error);
            }

            GetUserRolesData = (List<RoleResource>) KnetikClient.Deserialize(response.Content, typeof(List<RoleResource>), response.Headers);
            KnetikLogger.LogResponse(mGetUserRolesStartTime, "GetUserRoles", string.Format("Response received successfully:\n{0}", GetUserRolesData));

            if (GetUserRolesComplete != null)
            {
                GetUserRolesComplete(response.ResponseCode, GetUserRolesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set roles for a client 
        /// </summary>
        /// <param name="clientKey">The client key</param>
        /// <param name="rolesList">The list of unique roles</param>
        public void SetClientRoles(string clientKey, List<string> rolesList)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling SetClientRoles");
            }
            
            mWebCallEvent.WebPath = "/auth/clients/{client_key}/roles";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(rolesList); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetClientRolesStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetClientRolesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetClientRolesStartTime, "SetClientRoles", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetClientRolesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetClientRoles: " + response.Error);
            }

            SetClientRolesData = (ClientResource) KnetikClient.Deserialize(response.Content, typeof(ClientResource), response.Headers);
            KnetikLogger.LogResponse(mSetClientRolesStartTime, "SetClientRoles", string.Format("Response received successfully:\n{0}", SetClientRolesData));

            if (SetClientRolesComplete != null)
            {
                SetClientRolesComplete(response.ResponseCode, SetClientRolesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set permissions for a role 
        /// </summary>
        /// <param name="role">The role value</param>
        /// <param name="permissionsList">The list of unique permissions</param>
        public void SetPermissionsForRole(string role, List<string> permissionsList)
        {
            // verify the required parameter 'role' is set
            if (role == null)
            {
                throw new KnetikException(400, "Missing required parameter 'role' when calling SetPermissionsForRole");
            }
            
            mWebCallEvent.WebPath = "/auth/roles/{role}/permissions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "role" + "}", KnetikClient.ParameterToString(role));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(permissionsList); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetPermissionsForRoleStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetPermissionsForRoleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetPermissionsForRoleStartTime, "SetPermissionsForRole", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetPermissionsForRoleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetPermissionsForRole: " + response.Error);
            }

            SetPermissionsForRoleData = (RoleResource) KnetikClient.Deserialize(response.Content, typeof(RoleResource), response.Headers);
            KnetikLogger.LogResponse(mSetPermissionsForRoleStartTime, "SetPermissionsForRole", string.Format("Response received successfully:\n{0}", SetPermissionsForRoleData));

            if (SetPermissionsForRoleComplete != null)
            {
                SetPermissionsForRoleComplete(response.ResponseCode, SetPermissionsForRoleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set roles for a user 
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="rolesList">The list of unique roles</param>
        public void SetUserRoles(int? userId, List<string> rolesList)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling SetUserRoles");
            }
            
            mWebCallEvent.WebPath = "/auth/users/{user_id}/roles";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(rolesList); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetUserRolesStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetUserRolesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetUserRolesStartTime, "SetUserRoles", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetUserRolesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetUserRoles: " + response.Error);
            }

            SetUserRolesData = (UserResource) KnetikClient.Deserialize(response.Content, typeof(UserResource), response.Headers);
            KnetikLogger.LogResponse(mSetUserRolesStartTime, "SetUserRoles", string.Format("Response received successfully:\n{0}", SetUserRolesData));

            if (SetUserRolesComplete != null)
            {
                SetUserRolesComplete(response.ResponseCode, SetUserRolesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a role 
        /// </summary>
        /// <param name="role">The role value</param>
        /// <param name="roleResource">The role resource object</param>
        public void UpdateRole(string role, RoleResource roleResource)
        {
            // verify the required parameter 'role' is set
            if (role == null)
            {
                throw new KnetikException(400, "Missing required parameter 'role' when calling UpdateRole");
            }
            
            mWebCallEvent.WebPath = "/auth/roles/{role}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "role" + "}", KnetikClient.ParameterToString(role));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(roleResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateRoleStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateRoleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateRoleStartTime, "UpdateRole", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateRoleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateRole: " + response.Error);
            }

            UpdateRoleData = (RoleResource) KnetikClient.Deserialize(response.Content, typeof(RoleResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateRoleStartTime, "UpdateRole", string.Format("Response received successfully:\n{0}", UpdateRoleData));

            if (UpdateRoleComplete != null)
            {
                UpdateRoleComplete(response.ResponseCode, UpdateRoleData);
            }
        }

    }
}
