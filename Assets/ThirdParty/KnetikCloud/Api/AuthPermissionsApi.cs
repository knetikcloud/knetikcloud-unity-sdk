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
    public interface IAuthPermissionsApi
    {
        PermissionResource CreatePermissionData { get; }

        PermissionResource GetPermissionData { get; }

        PageResourcePermissionResource GetPermissionsData { get; }

        PermissionResource UpdatePermissionData { get; }

        
        /// <summary>
        /// Create a new permission 
        /// </summary>
        /// <param name="permissionResource">The permission resource object</param>
        void CreatePermission(PermissionResource permissionResource);

        /// <summary>
        /// Delete a permission 
        /// </summary>
        /// <param name="permission">The permission value</param>
        /// <param name="force">If true, removes permission assigned to roles</param>
        void DeletePermission(string permission, bool? force);

        /// <summary>
        /// Get a single permission 
        /// </summary>
        /// <param name="permission">The permission value</param>
        void GetPermission(string permission);

        /// <summary>
        /// List and search permissions 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetPermissions(int? size, int? page, string order);

        /// <summary>
        /// Update a permission 
        /// </summary>
        /// <param name="permission">The permission value</param>
        /// <param name="permissionResource">The permission resource object</param>
        void UpdatePermission(string permission, PermissionResource permissionResource);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthPermissionsApi : IAuthPermissionsApi
    {
        private readonly KnetikCoroutine mCreatePermissionCoroutine;
        private DateTime mCreatePermissionStartTime;
        private string mCreatePermissionPath;
        private readonly KnetikCoroutine mDeletePermissionCoroutine;
        private DateTime mDeletePermissionStartTime;
        private string mDeletePermissionPath;
        private readonly KnetikCoroutine mGetPermissionCoroutine;
        private DateTime mGetPermissionStartTime;
        private string mGetPermissionPath;
        private readonly KnetikCoroutine mGetPermissionsCoroutine;
        private DateTime mGetPermissionsStartTime;
        private string mGetPermissionsPath;
        private readonly KnetikCoroutine mUpdatePermissionCoroutine;
        private DateTime mUpdatePermissionStartTime;
        private string mUpdatePermissionPath;

        public PermissionResource CreatePermissionData { get; private set; }
        public delegate void CreatePermissionCompleteDelegate(PermissionResource response);
        public CreatePermissionCompleteDelegate CreatePermissionComplete;

        public delegate void DeletePermissionCompleteDelegate();
        public DeletePermissionCompleteDelegate DeletePermissionComplete;

        public PermissionResource GetPermissionData { get; private set; }
        public delegate void GetPermissionCompleteDelegate(PermissionResource response);
        public GetPermissionCompleteDelegate GetPermissionComplete;

        public PageResourcePermissionResource GetPermissionsData { get; private set; }
        public delegate void GetPermissionsCompleteDelegate(PageResourcePermissionResource response);
        public GetPermissionsCompleteDelegate GetPermissionsComplete;

        public PermissionResource UpdatePermissionData { get; private set; }
        public delegate void UpdatePermissionCompleteDelegate(PermissionResource response);
        public UpdatePermissionCompleteDelegate UpdatePermissionComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthPermissionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthPermissionsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
            mCreatePermissionCoroutine = new KnetikCoroutine(KnetikClient);
            mDeletePermissionCoroutine = new KnetikCoroutine(KnetikClient);
            mGetPermissionCoroutine = new KnetikCoroutine(KnetikClient);
            mGetPermissionsCoroutine = new KnetikCoroutine(KnetikClient);
            mUpdatePermissionCoroutine = new KnetikCoroutine(KnetikClient);
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient { get; private set; }

        /// <summary>
        /// Create a new permission 
        /// </summary>
        /// <param name="permissionResource">The permission resource object</param>
        public void CreatePermission(PermissionResource permissionResource)
        {
            
            mCreatePermissionPath = "/auth/permissions";
            if (!string.IsNullOrEmpty(mCreatePermissionPath))
            {
                mCreatePermissionPath = mCreatePermissionPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(permissionResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreatePermissionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreatePermissionStartTime, mCreatePermissionPath, "Sending server request...");

            // make the HTTP request
            mCreatePermissionCoroutine.ResponseReceived += CreatePermissionCallback;
            mCreatePermissionCoroutine.Start(mCreatePermissionPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreatePermissionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreatePermission: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreatePermission: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreatePermissionData = (PermissionResource) KnetikClient.Deserialize(response.Content, typeof(PermissionResource), response.Headers);
            KnetikLogger.LogResponse(mCreatePermissionStartTime, mCreatePermissionPath, string.Format("Response received successfully:\n{0}", CreatePermissionData.ToString()));

            if (CreatePermissionComplete != null)
            {
                CreatePermissionComplete(CreatePermissionData);
            }
        }
        /// <summary>
        /// Delete a permission 
        /// </summary>
        /// <param name="permission">The permission value</param>
        /// <param name="force">If true, removes permission assigned to roles</param>
        public void DeletePermission(string permission, bool? force)
        {
            // verify the required parameter 'permission' is set
            if (permission == null)
            {
                throw new KnetikException(400, "Missing required parameter 'permission' when calling DeletePermission");
            }
            
            mDeletePermissionPath = "/auth/permissions/{permission}";
            if (!string.IsNullOrEmpty(mDeletePermissionPath))
            {
                mDeletePermissionPath = mDeletePermissionPath.Replace("{format}", "json");
            }
            mDeletePermissionPath = mDeletePermissionPath.Replace("{" + "permission" + "}", KnetikClient.ParameterToString(permission));

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

            mDeletePermissionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeletePermissionStartTime, mDeletePermissionPath, "Sending server request...");

            // make the HTTP request
            mDeletePermissionCoroutine.ResponseReceived += DeletePermissionCallback;
            mDeletePermissionCoroutine.Start(mDeletePermissionPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeletePermissionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeletePermission: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeletePermission: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeletePermissionStartTime, mDeletePermissionPath, "Response received successfully.");
            if (DeletePermissionComplete != null)
            {
                DeletePermissionComplete();
            }
        }
        /// <summary>
        /// Get a single permission 
        /// </summary>
        /// <param name="permission">The permission value</param>
        public void GetPermission(string permission)
        {
            // verify the required parameter 'permission' is set
            if (permission == null)
            {
                throw new KnetikException(400, "Missing required parameter 'permission' when calling GetPermission");
            }
            
            mGetPermissionPath = "/auth/permissions/{permission}";
            if (!string.IsNullOrEmpty(mGetPermissionPath))
            {
                mGetPermissionPath = mGetPermissionPath.Replace("{format}", "json");
            }
            mGetPermissionPath = mGetPermissionPath.Replace("{" + "permission" + "}", KnetikClient.ParameterToString(permission));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetPermissionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetPermissionStartTime, mGetPermissionPath, "Sending server request...");

            // make the HTTP request
            mGetPermissionCoroutine.ResponseReceived += GetPermissionCallback;
            mGetPermissionCoroutine.Start(mGetPermissionPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetPermissionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPermission: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPermission: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetPermissionData = (PermissionResource) KnetikClient.Deserialize(response.Content, typeof(PermissionResource), response.Headers);
            KnetikLogger.LogResponse(mGetPermissionStartTime, mGetPermissionPath, string.Format("Response received successfully:\n{0}", GetPermissionData.ToString()));

            if (GetPermissionComplete != null)
            {
                GetPermissionComplete(GetPermissionData);
            }
        }
        /// <summary>
        /// List and search permissions 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetPermissions(int? size, int? page, string order)
        {
            
            mGetPermissionsPath = "/auth/permissions";
            if (!string.IsNullOrEmpty(mGetPermissionsPath))
            {
                mGetPermissionsPath = mGetPermissionsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

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

            mGetPermissionsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetPermissionsStartTime, mGetPermissionsPath, "Sending server request...");

            // make the HTTP request
            mGetPermissionsCoroutine.ResponseReceived += GetPermissionsCallback;
            mGetPermissionsCoroutine.Start(mGetPermissionsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetPermissionsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPermissions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPermissions: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetPermissionsData = (PageResourcePermissionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourcePermissionResource), response.Headers);
            KnetikLogger.LogResponse(mGetPermissionsStartTime, mGetPermissionsPath, string.Format("Response received successfully:\n{0}", GetPermissionsData.ToString()));

            if (GetPermissionsComplete != null)
            {
                GetPermissionsComplete(GetPermissionsData);
            }
        }
        /// <summary>
        /// Update a permission 
        /// </summary>
        /// <param name="permission">The permission value</param>
        /// <param name="permissionResource">The permission resource object</param>
        public void UpdatePermission(string permission, PermissionResource permissionResource)
        {
            // verify the required parameter 'permission' is set
            if (permission == null)
            {
                throw new KnetikException(400, "Missing required parameter 'permission' when calling UpdatePermission");
            }
            
            mUpdatePermissionPath = "/auth/permissions/{permission}";
            if (!string.IsNullOrEmpty(mUpdatePermissionPath))
            {
                mUpdatePermissionPath = mUpdatePermissionPath.Replace("{format}", "json");
            }
            mUpdatePermissionPath = mUpdatePermissionPath.Replace("{" + "permission" + "}", KnetikClient.ParameterToString(permission));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(permissionResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdatePermissionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdatePermissionStartTime, mUpdatePermissionPath, "Sending server request...");

            // make the HTTP request
            mUpdatePermissionCoroutine.ResponseReceived += UpdatePermissionCallback;
            mUpdatePermissionCoroutine.Start(mUpdatePermissionPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdatePermissionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdatePermission: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdatePermission: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdatePermissionData = (PermissionResource) KnetikClient.Deserialize(response.Content, typeof(PermissionResource), response.Headers);
            KnetikLogger.LogResponse(mUpdatePermissionStartTime, mUpdatePermissionPath, string.Format("Response received successfully:\n{0}", UpdatePermissionData.ToString()));

            if (UpdatePermissionComplete != null)
            {
                UpdatePermissionComplete(UpdatePermissionData);
            }
        }
    }
}
