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
    public interface IAuthRolesApi
    {
        RoleResource CreateRoleData { get; }

        List<RoleResource> GetClientRolesData { get; }

        RoleResource GetRoleData { get; }

        PageResourceRoleResource GetRolesData { get; }

        List<RoleResource> GetUserRolesData { get; }

        ClientResource SetClientRolesData { get; }

        RoleResource SetPermissionsForRoleData { get; }

        UserResource SetUserRolesData { get; }

        RoleResource UpdateRoleData { get; }

        
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

        /// <summary>
        /// Get roles for a client 
        /// </summary>
        /// <param name="clientKey">The client key</param>
        void GetClientRoles(string clientKey);

        /// <summary>
        /// Get a single role 
        /// </summary>
        /// <param name="role">The role value</param>
        void GetRole(string role);

        /// <summary>
        /// List and search roles 
        /// </summary>
        /// <param name="filterName">Filter for roles that have a name starting with specified string</param>
        /// <param name="filterRole">Filter for roles that have a role starting with specified string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetRoles(string filterName, string filterRole, int? size, int? page, string order);

        /// <summary>
        /// Get roles for a user 
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        void GetUserRoles(int? userId);

        /// <summary>
        /// Set roles for a client 
        /// </summary>
        /// <param name="clientKey">The client key</param>
        /// <param name="rolesList">The list of unique roles</param>
        void SetClientRoles(string clientKey, List<string> rolesList);

        /// <summary>
        /// Set permissions for a role 
        /// </summary>
        /// <param name="role">The role value</param>
        /// <param name="permissionsList">The list of unique permissions</param>
        void SetPermissionsForRole(string role, List<string> permissionsList);

        /// <summary>
        /// Set roles for a user 
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="rolesList">The list of unique roles</param>
        void SetUserRoles(int? userId, List<string> rolesList);

        /// <summary>
        /// Update a role 
        /// </summary>
        /// <param name="role">The role value</param>
        /// <param name="roleResource">The role resource object</param>
        void UpdateRole(string role, RoleResource roleResource);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthRolesApi : IAuthRolesApi
    {
        private readonly KnetikCoroutine mCreateRoleCoroutine;
        private DateTime mCreateRoleStartTime;
        private string mCreateRolePath;
        private readonly KnetikCoroutine mDeleteRoleCoroutine;
        private DateTime mDeleteRoleStartTime;
        private string mDeleteRolePath;
        private readonly KnetikCoroutine mGetClientRolesCoroutine;
        private DateTime mGetClientRolesStartTime;
        private string mGetClientRolesPath;
        private readonly KnetikCoroutine mGetRoleCoroutine;
        private DateTime mGetRoleStartTime;
        private string mGetRolePath;
        private readonly KnetikCoroutine mGetRolesCoroutine;
        private DateTime mGetRolesStartTime;
        private string mGetRolesPath;
        private readonly KnetikCoroutine mGetUserRolesCoroutine;
        private DateTime mGetUserRolesStartTime;
        private string mGetUserRolesPath;
        private readonly KnetikCoroutine mSetClientRolesCoroutine;
        private DateTime mSetClientRolesStartTime;
        private string mSetClientRolesPath;
        private readonly KnetikCoroutine mSetPermissionsForRoleCoroutine;
        private DateTime mSetPermissionsForRoleStartTime;
        private string mSetPermissionsForRolePath;
        private readonly KnetikCoroutine mSetUserRolesCoroutine;
        private DateTime mSetUserRolesStartTime;
        private string mSetUserRolesPath;
        private readonly KnetikCoroutine mUpdateRoleCoroutine;
        private DateTime mUpdateRoleStartTime;
        private string mUpdateRolePath;

        public RoleResource CreateRoleData { get; private set; }
        public delegate void CreateRoleCompleteDelegate(RoleResource response);
        public CreateRoleCompleteDelegate CreateRoleComplete;

        public delegate void DeleteRoleCompleteDelegate();
        public DeleteRoleCompleteDelegate DeleteRoleComplete;

        public List<RoleResource> GetClientRolesData { get; private set; }
        public delegate void GetClientRolesCompleteDelegate(List<RoleResource> response);
        public GetClientRolesCompleteDelegate GetClientRolesComplete;

        public RoleResource GetRoleData { get; private set; }
        public delegate void GetRoleCompleteDelegate(RoleResource response);
        public GetRoleCompleteDelegate GetRoleComplete;

        public PageResourceRoleResource GetRolesData { get; private set; }
        public delegate void GetRolesCompleteDelegate(PageResourceRoleResource response);
        public GetRolesCompleteDelegate GetRolesComplete;

        public List<RoleResource> GetUserRolesData { get; private set; }
        public delegate void GetUserRolesCompleteDelegate(List<RoleResource> response);
        public GetUserRolesCompleteDelegate GetUserRolesComplete;

        public ClientResource SetClientRolesData { get; private set; }
        public delegate void SetClientRolesCompleteDelegate(ClientResource response);
        public SetClientRolesCompleteDelegate SetClientRolesComplete;

        public RoleResource SetPermissionsForRoleData { get; private set; }
        public delegate void SetPermissionsForRoleCompleteDelegate(RoleResource response);
        public SetPermissionsForRoleCompleteDelegate SetPermissionsForRoleComplete;

        public UserResource SetUserRolesData { get; private set; }
        public delegate void SetUserRolesCompleteDelegate(UserResource response);
        public SetUserRolesCompleteDelegate SetUserRolesComplete;

        public RoleResource UpdateRoleData { get; private set; }
        public delegate void UpdateRoleCompleteDelegate(RoleResource response);
        public UpdateRoleCompleteDelegate UpdateRoleComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRolesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthRolesApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
            mCreateRoleCoroutine = new KnetikCoroutine(KnetikClient);
            mDeleteRoleCoroutine = new KnetikCoroutine(KnetikClient);
            mGetClientRolesCoroutine = new KnetikCoroutine(KnetikClient);
            mGetRoleCoroutine = new KnetikCoroutine(KnetikClient);
            mGetRolesCoroutine = new KnetikCoroutine(KnetikClient);
            mGetUserRolesCoroutine = new KnetikCoroutine(KnetikClient);
            mSetClientRolesCoroutine = new KnetikCoroutine(KnetikClient);
            mSetPermissionsForRoleCoroutine = new KnetikCoroutine(KnetikClient);
            mSetUserRolesCoroutine = new KnetikCoroutine(KnetikClient);
            mUpdateRoleCoroutine = new KnetikCoroutine(KnetikClient);
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient { get; private set; }

        /// <summary>
        /// Create a new role 
        /// </summary>
        /// <param name="roleResource">The role resource object</param>
        public void CreateRole(RoleResource roleResource)
        {
            
            mCreateRolePath = "/auth/roles";
            if (!string.IsNullOrEmpty(mCreateRolePath))
            {
                mCreateRolePath = mCreateRolePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(roleResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateRoleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateRoleStartTime, mCreateRolePath, "Sending server request...");

            // make the HTTP request
            mCreateRoleCoroutine.ResponseReceived += CreateRoleCallback;
            mCreateRoleCoroutine.Start(mCreateRolePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateRoleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateRole: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateRole: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateRoleData = (RoleResource) KnetikClient.Deserialize(response.Content, typeof(RoleResource), response.Headers);
            KnetikLogger.LogResponse(mCreateRoleStartTime, mCreateRolePath, string.Format("Response received successfully:\n{0}", CreateRoleData.ToString()));

            if (CreateRoleComplete != null)
            {
                CreateRoleComplete(CreateRoleData);
            }
        }
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
            
            mDeleteRolePath = "/auth/roles/{role}";
            if (!string.IsNullOrEmpty(mDeleteRolePath))
            {
                mDeleteRolePath = mDeleteRolePath.Replace("{format}", "json");
            }
            mDeleteRolePath = mDeleteRolePath.Replace("{" + "role" + "}", KnetikClient.ParameterToString(role));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (force != null)
            {
                queryParams.Add("force", KnetikClient.ParameterToString(force));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteRoleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteRoleStartTime, mDeleteRolePath, "Sending server request...");

            // make the HTTP request
            mDeleteRoleCoroutine.ResponseReceived += DeleteRoleCallback;
            mDeleteRoleCoroutine.Start(mDeleteRolePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteRoleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteRole: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteRole: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteRoleStartTime, mDeleteRolePath, "Response received successfully.");
            if (DeleteRoleComplete != null)
            {
                DeleteRoleComplete();
            }
        }
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
            
            mGetClientRolesPath = "/auth/clients/{client_key}/roles";
            if (!string.IsNullOrEmpty(mGetClientRolesPath))
            {
                mGetClientRolesPath = mGetClientRolesPath.Replace("{format}", "json");
            }
            mGetClientRolesPath = mGetClientRolesPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetClientRolesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetClientRolesStartTime, mGetClientRolesPath, "Sending server request...");

            // make the HTTP request
            mGetClientRolesCoroutine.ResponseReceived += GetClientRolesCallback;
            mGetClientRolesCoroutine.Start(mGetClientRolesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetClientRolesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetClientRoles: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetClientRoles: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetClientRolesData = (List<RoleResource>) KnetikClient.Deserialize(response.Content, typeof(List<RoleResource>), response.Headers);
            KnetikLogger.LogResponse(mGetClientRolesStartTime, mGetClientRolesPath, string.Format("Response received successfully:\n{0}", GetClientRolesData.ToString()));

            if (GetClientRolesComplete != null)
            {
                GetClientRolesComplete(GetClientRolesData);
            }
        }
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
            
            mGetRolePath = "/auth/roles/{role}";
            if (!string.IsNullOrEmpty(mGetRolePath))
            {
                mGetRolePath = mGetRolePath.Replace("{format}", "json");
            }
            mGetRolePath = mGetRolePath.Replace("{" + "role" + "}", KnetikClient.ParameterToString(role));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetRoleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetRoleStartTime, mGetRolePath, "Sending server request...");

            // make the HTTP request
            mGetRoleCoroutine.ResponseReceived += GetRoleCallback;
            mGetRoleCoroutine.Start(mGetRolePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetRoleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRole: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRole: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetRoleData = (RoleResource) KnetikClient.Deserialize(response.Content, typeof(RoleResource), response.Headers);
            KnetikLogger.LogResponse(mGetRoleStartTime, mGetRolePath, string.Format("Response received successfully:\n{0}", GetRoleData.ToString()));

            if (GetRoleComplete != null)
            {
                GetRoleComplete(GetRoleData);
            }
        }
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
            
            mGetRolesPath = "/auth/roles";
            if (!string.IsNullOrEmpty(mGetRolesPath))
            {
                mGetRolesPath = mGetRolesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.ParameterToString(filterName));
            }

            if (filterRole != null)
            {
                queryParams.Add("filter_role", KnetikClient.ParameterToString(filterRole));
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetRolesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetRolesStartTime, mGetRolesPath, "Sending server request...");

            // make the HTTP request
            mGetRolesCoroutine.ResponseReceived += GetRolesCallback;
            mGetRolesCoroutine.Start(mGetRolesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetRolesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRoles: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRoles: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetRolesData = (PageResourceRoleResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceRoleResource), response.Headers);
            KnetikLogger.LogResponse(mGetRolesStartTime, mGetRolesPath, string.Format("Response received successfully:\n{0}", GetRolesData.ToString()));

            if (GetRolesComplete != null)
            {
                GetRolesComplete(GetRolesData);
            }
        }
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
            
            mGetUserRolesPath = "/auth/users/{user_id}/roles";
            if (!string.IsNullOrEmpty(mGetUserRolesPath))
            {
                mGetUserRolesPath = mGetUserRolesPath.Replace("{format}", "json");
            }
            mGetUserRolesPath = mGetUserRolesPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserRolesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserRolesStartTime, mGetUserRolesPath, "Sending server request...");

            // make the HTTP request
            mGetUserRolesCoroutine.ResponseReceived += GetUserRolesCallback;
            mGetUserRolesCoroutine.Start(mGetUserRolesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserRolesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserRoles: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserRoles: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserRolesData = (List<RoleResource>) KnetikClient.Deserialize(response.Content, typeof(List<RoleResource>), response.Headers);
            KnetikLogger.LogResponse(mGetUserRolesStartTime, mGetUserRolesPath, string.Format("Response received successfully:\n{0}", GetUserRolesData.ToString()));

            if (GetUserRolesComplete != null)
            {
                GetUserRolesComplete(GetUserRolesData);
            }
        }
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
            
            mSetClientRolesPath = "/auth/clients/{client_key}/roles";
            if (!string.IsNullOrEmpty(mSetClientRolesPath))
            {
                mSetClientRolesPath = mSetClientRolesPath.Replace("{format}", "json");
            }
            mSetClientRolesPath = mSetClientRolesPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(rolesList); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetClientRolesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetClientRolesStartTime, mSetClientRolesPath, "Sending server request...");

            // make the HTTP request
            mSetClientRolesCoroutine.ResponseReceived += SetClientRolesCallback;
            mSetClientRolesCoroutine.Start(mSetClientRolesPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetClientRolesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetClientRoles: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetClientRoles: " + response.ErrorMessage, response.ErrorMessage);
            }

            SetClientRolesData = (ClientResource) KnetikClient.Deserialize(response.Content, typeof(ClientResource), response.Headers);
            KnetikLogger.LogResponse(mSetClientRolesStartTime, mSetClientRolesPath, string.Format("Response received successfully:\n{0}", SetClientRolesData.ToString()));

            if (SetClientRolesComplete != null)
            {
                SetClientRolesComplete(SetClientRolesData);
            }
        }
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
            
            mSetPermissionsForRolePath = "/auth/roles/{role}/permissions";
            if (!string.IsNullOrEmpty(mSetPermissionsForRolePath))
            {
                mSetPermissionsForRolePath = mSetPermissionsForRolePath.Replace("{format}", "json");
            }
            mSetPermissionsForRolePath = mSetPermissionsForRolePath.Replace("{" + "role" + "}", KnetikClient.ParameterToString(role));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(permissionsList); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetPermissionsForRoleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetPermissionsForRoleStartTime, mSetPermissionsForRolePath, "Sending server request...");

            // make the HTTP request
            mSetPermissionsForRoleCoroutine.ResponseReceived += SetPermissionsForRoleCallback;
            mSetPermissionsForRoleCoroutine.Start(mSetPermissionsForRolePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetPermissionsForRoleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetPermissionsForRole: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetPermissionsForRole: " + response.ErrorMessage, response.ErrorMessage);
            }

            SetPermissionsForRoleData = (RoleResource) KnetikClient.Deserialize(response.Content, typeof(RoleResource), response.Headers);
            KnetikLogger.LogResponse(mSetPermissionsForRoleStartTime, mSetPermissionsForRolePath, string.Format("Response received successfully:\n{0}", SetPermissionsForRoleData.ToString()));

            if (SetPermissionsForRoleComplete != null)
            {
                SetPermissionsForRoleComplete(SetPermissionsForRoleData);
            }
        }
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
            
            mSetUserRolesPath = "/auth/users/{user_id}/roles";
            if (!string.IsNullOrEmpty(mSetUserRolesPath))
            {
                mSetUserRolesPath = mSetUserRolesPath.Replace("{format}", "json");
            }
            mSetUserRolesPath = mSetUserRolesPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(rolesList); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetUserRolesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetUserRolesStartTime, mSetUserRolesPath, "Sending server request...");

            // make the HTTP request
            mSetUserRolesCoroutine.ResponseReceived += SetUserRolesCallback;
            mSetUserRolesCoroutine.Start(mSetUserRolesPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetUserRolesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetUserRoles: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetUserRoles: " + response.ErrorMessage, response.ErrorMessage);
            }

            SetUserRolesData = (UserResource) KnetikClient.Deserialize(response.Content, typeof(UserResource), response.Headers);
            KnetikLogger.LogResponse(mSetUserRolesStartTime, mSetUserRolesPath, string.Format("Response received successfully:\n{0}", SetUserRolesData.ToString()));

            if (SetUserRolesComplete != null)
            {
                SetUserRolesComplete(SetUserRolesData);
            }
        }
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
            
            mUpdateRolePath = "/auth/roles/{role}";
            if (!string.IsNullOrEmpty(mUpdateRolePath))
            {
                mUpdateRolePath = mUpdateRolePath.Replace("{format}", "json");
            }
            mUpdateRolePath = mUpdateRolePath.Replace("{" + "role" + "}", KnetikClient.ParameterToString(role));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(roleResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateRoleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateRoleStartTime, mUpdateRolePath, "Sending server request...");

            // make the HTTP request
            mUpdateRoleCoroutine.ResponseReceived += UpdateRoleCallback;
            mUpdateRoleCoroutine.Start(mUpdateRolePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateRoleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateRole: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateRole: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateRoleData = (RoleResource) KnetikClient.Deserialize(response.Content, typeof(RoleResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateRoleStartTime, mUpdateRolePath, string.Format("Response received successfully:\n{0}", UpdateRoleData.ToString()));

            if (UpdateRoleComplete != null)
            {
                UpdateRoleComplete(UpdateRoleData);
            }
        }
    }
}
