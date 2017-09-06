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
    public interface IAuthPermissionsApi
    {
        /// <summary>
        /// Create a new permission 
        /// </summary>
        /// <param name="permissionResource">The permission resource object</param>
        /// <returns>PermissionResource</returns>
        PermissionResource CreatePermission (PermissionResource permissionResource);
        /// <summary>
        /// Delete a permission 
        /// </summary>
        /// <param name="permission">The permission value</param>
        /// <param name="force">If true, removes permission assigned to roles</param>
        /// <returns></returns>
        void DeletePermission (string permission, bool? force);
        /// <summary>
        /// Get a single permission 
        /// </summary>
        /// <param name="permission">The permission value</param>
        /// <returns>PermissionResource</returns>
        PermissionResource GetPermission (string permission);
        /// <summary>
        /// List and search permissions 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourcePermissionResource</returns>
        PageResourcePermissionResource GetPermissions (int? size, int? page, string order);
        /// <summary>
        /// Update a permission 
        /// </summary>
        /// <param name="permission">The permission value</param>
        /// <param name="permissionResource">The permission resource object</param>
        /// <returns>PermissionResource</returns>
        PermissionResource UpdatePermission (string permission, PermissionResource permissionResource);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthPermissionsApi : IAuthPermissionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthPermissionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthPermissionsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a new permission 
        /// </summary>
        /// <param name="permissionResource">The permission resource object</param> 
        /// <returns>PermissionResource</returns>            
        public PermissionResource CreatePermission(PermissionResource permissionResource)
        {
            
            string urlPath = "/auth/permissions";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(permissionResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreatePermission: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreatePermission: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PermissionResource) KnetikClient.Deserialize(response.Content, typeof(PermissionResource), response.Headers);
        }
        /// <summary>
        /// Delete a permission 
        /// </summary>
        /// <param name="permission">The permission value</param> 
        /// <param name="force">If true, removes permission assigned to roles</param> 
        /// <returns></returns>            
        public void DeletePermission(string permission, bool? force)
        {
            // verify the required parameter 'permission' is set
            if (permission == null)
            {
                throw new KnetikException(400, "Missing required parameter 'permission' when calling DeletePermission");
            }
            
            
            string urlPath = "/auth/permissions/{permission}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "permission" + "}", KnetikClient.ParameterToString(permission));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeletePermission: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeletePermission: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get a single permission 
        /// </summary>
        /// <param name="permission">The permission value</param> 
        /// <returns>PermissionResource</returns>            
        public PermissionResource GetPermission(string permission)
        {
            // verify the required parameter 'permission' is set
            if (permission == null)
            {
                throw new KnetikException(400, "Missing required parameter 'permission' when calling GetPermission");
            }
            
            
            string urlPath = "/auth/permissions/{permission}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "permission" + "}", KnetikClient.ParameterToString(permission));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPermission: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPermission: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PermissionResource) KnetikClient.Deserialize(response.Content, typeof(PermissionResource), response.Headers);
        }
        /// <summary>
        /// List and search permissions 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourcePermissionResource</returns>            
        public PageResourcePermissionResource GetPermissions(int? size, int? page, string order)
        {
            
            string urlPath = "/auth/permissions";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPermissions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPermissions: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourcePermissionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourcePermissionResource), response.Headers);
        }
        /// <summary>
        /// Update a permission 
        /// </summary>
        /// <param name="permission">The permission value</param> 
        /// <param name="permissionResource">The permission resource object</param> 
        /// <returns>PermissionResource</returns>            
        public PermissionResource UpdatePermission(string permission, PermissionResource permissionResource)
        {
            // verify the required parameter 'permission' is set
            if (permission == null)
            {
                throw new KnetikException(400, "Missing required parameter 'permission' when calling UpdatePermission");
            }
            
            
            string urlPath = "/auth/permissions/{permission}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "permission" + "}", KnetikClient.ParameterToString(permission));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(permissionResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdatePermission: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdatePermission: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PermissionResource) KnetikClient.Deserialize(response.Content, typeof(PermissionResource), response.Headers);
        }
    }
}
