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
    public interface IAuthPermissionsApi
    {
        PermissionResource CreatePermissionData { get; }

        /// <summary>
        /// Create a new permission &lt;b&gt;Permissions Needed:&lt;/b&gt; PERMISSIONS_ADMIN
        /// </summary>
        /// <param name="permissionResource">The permission resource object</param>
        void CreatePermission(PermissionResource permissionResource);

        

        /// <summary>
        /// Delete a permission &lt;b&gt;Permissions Needed:&lt;/b&gt; PERMISSIONS_ADMIN
        /// </summary>
        /// <param name="permission">The permission value</param>
        /// <param name="force">If true, removes permission assigned to roles</param>
        void DeletePermission(string permission, bool? force);

        PermissionResource GetPermissionData { get; }

        /// <summary>
        /// Get a single permission &lt;b&gt;Permissions Needed:&lt;/b&gt; PERMISSIONS_ADMIN
        /// </summary>
        /// <param name="permission">The permission value</param>
        void GetPermission(string permission);

        PageResourcePermissionResource GetPermissionsData { get; }

        /// <summary>
        /// List and search permissions &lt;b&gt;Permissions Needed:&lt;/b&gt; PERMISSIONS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetPermissions(int? size, int? page, string order);

        PermissionResource UpdatePermissionData { get; }

        /// <summary>
        /// Update a permission &lt;b&gt;Permissions Needed:&lt;/b&gt; PERMISSIONS_ADMIN
        /// </summary>
        /// <param name="permission">The permission value</param>
        /// <param name="permissionResource">The permission resource object</param>
        void UpdatePermission(string permission, PermissionResource permissionResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthPermissionsApi : IAuthPermissionsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreatePermissionResponseContext;
        private DateTime mCreatePermissionStartTime;
        private readonly KnetikResponseContext mDeletePermissionResponseContext;
        private DateTime mDeletePermissionStartTime;
        private readonly KnetikResponseContext mGetPermissionResponseContext;
        private DateTime mGetPermissionStartTime;
        private readonly KnetikResponseContext mGetPermissionsResponseContext;
        private DateTime mGetPermissionsStartTime;
        private readonly KnetikResponseContext mUpdatePermissionResponseContext;
        private DateTime mUpdatePermissionStartTime;

        public PermissionResource CreatePermissionData { get; private set; }
        public delegate void CreatePermissionCompleteDelegate(long responseCode, PermissionResource response);
        public CreatePermissionCompleteDelegate CreatePermissionComplete;

        public delegate void DeletePermissionCompleteDelegate(long responseCode);
        public DeletePermissionCompleteDelegate DeletePermissionComplete;

        public PermissionResource GetPermissionData { get; private set; }
        public delegate void GetPermissionCompleteDelegate(long responseCode, PermissionResource response);
        public GetPermissionCompleteDelegate GetPermissionComplete;

        public PageResourcePermissionResource GetPermissionsData { get; private set; }
        public delegate void GetPermissionsCompleteDelegate(long responseCode, PageResourcePermissionResource response);
        public GetPermissionsCompleteDelegate GetPermissionsComplete;

        public PermissionResource UpdatePermissionData { get; private set; }
        public delegate void UpdatePermissionCompleteDelegate(long responseCode, PermissionResource response);
        public UpdatePermissionCompleteDelegate UpdatePermissionComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthPermissionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthPermissionsApi()
        {
            mCreatePermissionResponseContext = new KnetikResponseContext();
            mCreatePermissionResponseContext.ResponseReceived += OnCreatePermissionResponse;
            mDeletePermissionResponseContext = new KnetikResponseContext();
            mDeletePermissionResponseContext.ResponseReceived += OnDeletePermissionResponse;
            mGetPermissionResponseContext = new KnetikResponseContext();
            mGetPermissionResponseContext.ResponseReceived += OnGetPermissionResponse;
            mGetPermissionsResponseContext = new KnetikResponseContext();
            mGetPermissionsResponseContext.ResponseReceived += OnGetPermissionsResponse;
            mUpdatePermissionResponseContext = new KnetikResponseContext();
            mUpdatePermissionResponseContext.ResponseReceived += OnUpdatePermissionResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a new permission &lt;b&gt;Permissions Needed:&lt;/b&gt; PERMISSIONS_ADMIN
        /// </summary>
        /// <param name="permissionResource">The permission resource object</param>
        public void CreatePermission(PermissionResource permissionResource)
        {
            
            mWebCallEvent.WebPath = "/auth/permissions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(permissionResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreatePermissionStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreatePermissionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreatePermissionStartTime, "CreatePermission", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreatePermissionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreatePermission: " + response.Error);
            }

            CreatePermissionData = (PermissionResource) KnetikClient.Deserialize(response.Content, typeof(PermissionResource), response.Headers);
            KnetikLogger.LogResponse(mCreatePermissionStartTime, "CreatePermission", string.Format("Response received successfully:\n{0}", CreatePermissionData));

            if (CreatePermissionComplete != null)
            {
                CreatePermissionComplete(response.ResponseCode, CreatePermissionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a permission &lt;b&gt;Permissions Needed:&lt;/b&gt; PERMISSIONS_ADMIN
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
            
            mWebCallEvent.WebPath = "/auth/permissions/{permission}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "permission" + "}", KnetikClient.ParameterToString(permission));

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
            mDeletePermissionStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeletePermissionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeletePermissionStartTime, "DeletePermission", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeletePermissionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeletePermission: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeletePermissionStartTime, "DeletePermission", "Response received successfully.");
            if (DeletePermissionComplete != null)
            {
                DeletePermissionComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single permission &lt;b&gt;Permissions Needed:&lt;/b&gt; PERMISSIONS_ADMIN
        /// </summary>
        /// <param name="permission">The permission value</param>
        public void GetPermission(string permission)
        {
            // verify the required parameter 'permission' is set
            if (permission == null)
            {
                throw new KnetikException(400, "Missing required parameter 'permission' when calling GetPermission");
            }
            
            mWebCallEvent.WebPath = "/auth/permissions/{permission}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "permission" + "}", KnetikClient.ParameterToString(permission));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetPermissionStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetPermissionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetPermissionStartTime, "GetPermission", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetPermissionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetPermission: " + response.Error);
            }

            GetPermissionData = (PermissionResource) KnetikClient.Deserialize(response.Content, typeof(PermissionResource), response.Headers);
            KnetikLogger.LogResponse(mGetPermissionStartTime, "GetPermission", string.Format("Response received successfully:\n{0}", GetPermissionData));

            if (GetPermissionComplete != null)
            {
                GetPermissionComplete(response.ResponseCode, GetPermissionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search permissions &lt;b&gt;Permissions Needed:&lt;/b&gt; PERMISSIONS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetPermissions(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/auth/permissions";
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
            mGetPermissionsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetPermissionsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetPermissionsStartTime, "GetPermissions", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetPermissionsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetPermissions: " + response.Error);
            }

            GetPermissionsData = (PageResourcePermissionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourcePermissionResource), response.Headers);
            KnetikLogger.LogResponse(mGetPermissionsStartTime, "GetPermissions", string.Format("Response received successfully:\n{0}", GetPermissionsData));

            if (GetPermissionsComplete != null)
            {
                GetPermissionsComplete(response.ResponseCode, GetPermissionsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a permission &lt;b&gt;Permissions Needed:&lt;/b&gt; PERMISSIONS_ADMIN
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
            
            mWebCallEvent.WebPath = "/auth/permissions/{permission}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "permission" + "}", KnetikClient.ParameterToString(permission));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(permissionResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdatePermissionStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdatePermissionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdatePermissionStartTime, "UpdatePermission", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdatePermissionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdatePermission: " + response.Error);
            }

            UpdatePermissionData = (PermissionResource) KnetikClient.Deserialize(response.Content, typeof(PermissionResource), response.Headers);
            KnetikLogger.LogResponse(mUpdatePermissionStartTime, "UpdatePermission", string.Format("Response received successfully:\n{0}", UpdatePermissionData));

            if (UpdatePermissionComplete != null)
            {
                UpdatePermissionComplete(response.ResponseCode, UpdatePermissionData);
            }
        }

    }
}
