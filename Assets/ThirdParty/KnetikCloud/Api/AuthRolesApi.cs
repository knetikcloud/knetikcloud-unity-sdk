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
    public interface IAuthRolesApi
    {
        /// <summary>
        /// Create a new role 
        /// </summary>
        /// <param name="roleResource">The role resource object</param>
        /// <returns>RoleResource</returns>
        RoleResource CreateRole (RoleResource roleResource);
        /// <summary>
        /// Delete a role 
        /// </summary>
        /// <param name="role">The role value</param>
        /// <param name="force">If true, removes role from users/clients</param>
        /// <returns></returns>
        void DeleteRole (string role, bool? force);
        /// <summary>
        /// Get roles for a client 
        /// </summary>
        /// <param name="clientKey">The client key</param>
        /// <returns>List&lt;RoleResource&gt;</returns>
        List<RoleResource> GetClientRoles (string clientKey);
        /// <summary>
        /// Get a single role 
        /// </summary>
        /// <param name="role">The role value</param>
        /// <returns>RoleResource</returns>
        RoleResource GetRole (string role);
        /// <summary>
        /// List and search roles 
        /// </summary>
        /// <param name="filterName">Filter for roles that have a name starting with specified string</param>
        /// <param name="filterRole">Filter for roles that have a role starting with specified string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceRoleResource</returns>
        PageResourceRoleResource GetRoles (string filterName, string filterRole, int? size, int? page, string order);
        /// <summary>
        /// Get roles for a user 
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <returns>List&lt;RoleResource&gt;</returns>
        List<RoleResource> GetUserRoles (int? userId);
        /// <summary>
        /// Set roles for a client 
        /// </summary>
        /// <param name="clientKey">The client key</param>
        /// <param name="rolesList">The list of unique roles</param>
        /// <returns>ClientResource</returns>
        ClientResource SetClientRoles (string clientKey, List<string> rolesList);
        /// <summary>
        /// Set permissions for a role 
        /// </summary>
        /// <param name="role">The role value</param>
        /// <param name="permissionsList">The list of unique permissions</param>
        /// <returns>RoleResource</returns>
        RoleResource SetPermissionsForRole (string role, List<string> permissionsList);
        /// <summary>
        /// Set roles for a user 
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="rolesList">The list of unique roles</param>
        /// <returns>UserResource</returns>
        UserResource SetUserRoles (int? userId, List<string> rolesList);
        /// <summary>
        /// Update a role 
        /// </summary>
        /// <param name="role">The role value</param>
        /// <param name="roleResource">The role resource object</param>
        /// <returns>RoleResource</returns>
        RoleResource UpdateRole (string role, RoleResource roleResource);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthRolesApi : IAuthRolesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthRolesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthRolesApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a new role 
        /// </summary>
        /// <param name="roleResource">The role resource object</param> 
        /// <returns>RoleResource</returns>            
        public RoleResource CreateRole(RoleResource roleResource)
        {
            
            string urlPath = "/auth/roles";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(roleResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateRole: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateRole: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (RoleResource) KnetikClient.Deserialize(response.Content, typeof(RoleResource), response.Headers);
        }
        /// <summary>
        /// Delete a role 
        /// </summary>
        /// <param name="role">The role value</param> 
        /// <param name="force">If true, removes role from users/clients</param> 
        /// <returns></returns>            
        public void DeleteRole(string role, bool? force)
        {
            // verify the required parameter 'role' is set
            if (role == null)
            {
                throw new KnetikException(400, "Missing required parameter 'role' when calling DeleteRole");
            }
            
            
            string urlPath = "/auth/roles/{role}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "role" + "}", KnetikClient.ParameterToString(role));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (force != null)
            {
                queryParams.Add("force", KnetikClient.ParameterToString(force));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteRole: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteRole: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get roles for a client 
        /// </summary>
        /// <param name="clientKey">The client key</param> 
        /// <returns>List&lt;RoleResource&gt;</returns>            
        public List<RoleResource> GetClientRoles(string clientKey)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling GetClientRoles");
            }
            
            
            string urlPath = "/auth/clients/{client_key}/roles";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetClientRoles: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetClientRoles: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<RoleResource>) KnetikClient.Deserialize(response.Content, typeof(List<RoleResource>), response.Headers);
        }
        /// <summary>
        /// Get a single role 
        /// </summary>
        /// <param name="role">The role value</param> 
        /// <returns>RoleResource</returns>            
        public RoleResource GetRole(string role)
        {
            // verify the required parameter 'role' is set
            if (role == null)
            {
                throw new KnetikException(400, "Missing required parameter 'role' when calling GetRole");
            }
            
            
            string urlPath = "/auth/roles/{role}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "role" + "}", KnetikClient.ParameterToString(role));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetRole: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetRole: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (RoleResource) KnetikClient.Deserialize(response.Content, typeof(RoleResource), response.Headers);
        }
        /// <summary>
        /// List and search roles 
        /// </summary>
        /// <param name="filterName">Filter for roles that have a name starting with specified string</param> 
        /// <param name="filterRole">Filter for roles that have a role starting with specified string</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceRoleResource</returns>            
        public PageResourceRoleResource GetRoles(string filterName, string filterRole, int? size, int? page, string order)
        {
            
            string urlPath = "/auth/roles";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

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
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetRoles: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetRoles: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceRoleResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceRoleResource), response.Headers);
        }
        /// <summary>
        /// Get roles for a user 
        /// </summary>
        /// <param name="userId">The user&#39;s id</param> 
        /// <returns>List&lt;RoleResource&gt;</returns>            
        public List<RoleResource> GetUserRoles(int? userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserRoles");
            }
            
            
            string urlPath = "/auth/users/{user_id}/roles";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserRoles: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserRoles: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<RoleResource>) KnetikClient.Deserialize(response.Content, typeof(List<RoleResource>), response.Headers);
        }
        /// <summary>
        /// Set roles for a client 
        /// </summary>
        /// <param name="clientKey">The client key</param> 
        /// <param name="rolesList">The list of unique roles</param> 
        /// <returns>ClientResource</returns>            
        public ClientResource SetClientRoles(string clientKey, List<string> rolesList)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling SetClientRoles");
            }
            
            
            string urlPath = "/auth/clients/{client_key}/roles";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(rolesList); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetClientRoles: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetClientRoles: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ClientResource) KnetikClient.Deserialize(response.Content, typeof(ClientResource), response.Headers);
        }
        /// <summary>
        /// Set permissions for a role 
        /// </summary>
        /// <param name="role">The role value</param> 
        /// <param name="permissionsList">The list of unique permissions</param> 
        /// <returns>RoleResource</returns>            
        public RoleResource SetPermissionsForRole(string role, List<string> permissionsList)
        {
            // verify the required parameter 'role' is set
            if (role == null)
            {
                throw new KnetikException(400, "Missing required parameter 'role' when calling SetPermissionsForRole");
            }
            
            
            string urlPath = "/auth/roles/{role}/permissions";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "role" + "}", KnetikClient.ParameterToString(role));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(permissionsList); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetPermissionsForRole: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetPermissionsForRole: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (RoleResource) KnetikClient.Deserialize(response.Content, typeof(RoleResource), response.Headers);
        }
        /// <summary>
        /// Set roles for a user 
        /// </summary>
        /// <param name="userId">The user&#39;s id</param> 
        /// <param name="rolesList">The list of unique roles</param> 
        /// <returns>UserResource</returns>            
        public UserResource SetUserRoles(int? userId, List<string> rolesList)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling SetUserRoles");
            }
            
            
            string urlPath = "/auth/users/{user_id}/roles";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(rolesList); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetUserRoles: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetUserRoles: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (UserResource) KnetikClient.Deserialize(response.Content, typeof(UserResource), response.Headers);
        }
        /// <summary>
        /// Update a role 
        /// </summary>
        /// <param name="role">The role value</param> 
        /// <param name="roleResource">The role resource object</param> 
        /// <returns>RoleResource</returns>            
        public RoleResource UpdateRole(string role, RoleResource roleResource)
        {
            // verify the required parameter 'role' is set
            if (role == null)
            {
                throw new KnetikException(400, "Missing required parameter 'role' when calling UpdateRole");
            }
            
            
            string urlPath = "/auth/roles/{role}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "role" + "}", KnetikClient.ParameterToString(role));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(roleResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateRole: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateRole: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (RoleResource) KnetikClient.Deserialize(response.Content, typeof(RoleResource), response.Headers);
        }
    }
}
