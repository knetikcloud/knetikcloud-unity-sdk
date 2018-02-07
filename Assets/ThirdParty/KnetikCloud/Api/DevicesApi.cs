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
    public interface IDevicesApi
    {
        DeviceResource AddDeviceUsersData { get; }

        /// <summary>
        /// Add device users 
        /// </summary>
        /// <param name="userResources">userResources</param>
        /// <param name="id">id</param>
        void AddDeviceUsers(List<SimpleUserResource> userResources, string id);

        DeviceResource CreateDeviceData { get; }

        /// <summary>
        /// Create a device 
        /// </summary>
        /// <param name="device">device</param>
        void CreateDevice(DeviceResource device);

        TemplateResource CreateDeviceTemplateData { get; }

        /// <summary>
        /// Create a device template Device Templates define a type of device and the properties they have
        /// </summary>
        /// <param name="deviceTemplateResource">The device template resource object</param>
        void CreateDeviceTemplate(TemplateResource deviceTemplateResource);

        

        /// <summary>
        /// Delete a device 
        /// </summary>
        /// <param name="id">id</param>
        void DeleteDevice(string id);

        

        /// <summary>
        /// Delete an device template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteDeviceTemplate(string id, string cascade);

        

        /// <summary>
        /// Delete a device user 
        /// </summary>
        /// <param name="id">The id of the device</param>
        /// <param name="userId">The user id of the device user</param>
        void DeleteDeviceUser(string id, int? userId);

        

        /// <summary>
        /// Delete all device users 
        /// </summary>
        /// <param name="id">The id of the device</param>
        /// <param name="filterId">Filter for device users to delete with a user id in a given comma separated list of ids</param>
        void DeleteDeviceUsers(string id, string filterId);

        DeviceResource GetDeviceData { get; }

        /// <summary>
        /// Get a single device 
        /// </summary>
        /// <param name="id">id</param>
        void GetDevice(string id);

        TemplateResource GetDeviceTemplateData { get; }

        /// <summary>
        /// Get a single device template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetDeviceTemplate(string id);

        PageResourceTemplateResource GetDeviceTemplatesData { get; }

        /// <summary>
        /// List and search device templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetDeviceTemplates(int? size, int? page, string order);

        PageResourceDeviceResource GetDevicesData { get; }

        /// <summary>
        /// List and search devices Get a list of devices with optional filtering
        /// </summary>
        /// <param name="filterMake">Filter for devices with specified make</param>
        /// <param name="filterModel">Filter for devices with specified model</param>
        /// <param name="filterOs">Filter for devices with specified OS</param>
        /// <param name="filterSerial">Filter for devices with specified serial</param>
        /// <param name="filterType">Filter for devices with specified type</param>
        /// <param name="filterTag">A comma separated list without spaces to filter for devices with specified tags (matches any)</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetDevices(string filterMake, string filterModel, string filterOs, string filterSerial, string filterType, string filterTag, int? size, int? page, string order);

        DeviceResource UpdateDeviceData { get; }

        /// <summary>
        /// Update a device 
        /// </summary>
        /// <param name="device">device</param>
        /// <param name="id">id</param>
        void UpdateDevice(DeviceResource device, string id);

        TemplateResource UpdateDeviceTemplateData { get; }

        /// <summary>
        /// Update an device template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="deviceTemplateResource">The device template resource object</param>
        void UpdateDeviceTemplate(string id, TemplateResource deviceTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DevicesApi : IDevicesApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddDeviceUsersResponseContext;
        private DateTime mAddDeviceUsersStartTime;
        private readonly KnetikResponseContext mCreateDeviceResponseContext;
        private DateTime mCreateDeviceStartTime;
        private readonly KnetikResponseContext mCreateDeviceTemplateResponseContext;
        private DateTime mCreateDeviceTemplateStartTime;
        private readonly KnetikResponseContext mDeleteDeviceResponseContext;
        private DateTime mDeleteDeviceStartTime;
        private readonly KnetikResponseContext mDeleteDeviceTemplateResponseContext;
        private DateTime mDeleteDeviceTemplateStartTime;
        private readonly KnetikResponseContext mDeleteDeviceUserResponseContext;
        private DateTime mDeleteDeviceUserStartTime;
        private readonly KnetikResponseContext mDeleteDeviceUsersResponseContext;
        private DateTime mDeleteDeviceUsersStartTime;
        private readonly KnetikResponseContext mGetDeviceResponseContext;
        private DateTime mGetDeviceStartTime;
        private readonly KnetikResponseContext mGetDeviceTemplateResponseContext;
        private DateTime mGetDeviceTemplateStartTime;
        private readonly KnetikResponseContext mGetDeviceTemplatesResponseContext;
        private DateTime mGetDeviceTemplatesStartTime;
        private readonly KnetikResponseContext mGetDevicesResponseContext;
        private DateTime mGetDevicesStartTime;
        private readonly KnetikResponseContext mUpdateDeviceResponseContext;
        private DateTime mUpdateDeviceStartTime;
        private readonly KnetikResponseContext mUpdateDeviceTemplateResponseContext;
        private DateTime mUpdateDeviceTemplateStartTime;

        public DeviceResource AddDeviceUsersData { get; private set; }
        public delegate void AddDeviceUsersCompleteDelegate(long responseCode, DeviceResource response);
        public AddDeviceUsersCompleteDelegate AddDeviceUsersComplete;

        public DeviceResource CreateDeviceData { get; private set; }
        public delegate void CreateDeviceCompleteDelegate(long responseCode, DeviceResource response);
        public CreateDeviceCompleteDelegate CreateDeviceComplete;

        public TemplateResource CreateDeviceTemplateData { get; private set; }
        public delegate void CreateDeviceTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateDeviceTemplateCompleteDelegate CreateDeviceTemplateComplete;

        public delegate void DeleteDeviceCompleteDelegate(long responseCode);
        public DeleteDeviceCompleteDelegate DeleteDeviceComplete;

        public delegate void DeleteDeviceTemplateCompleteDelegate(long responseCode);
        public DeleteDeviceTemplateCompleteDelegate DeleteDeviceTemplateComplete;

        public delegate void DeleteDeviceUserCompleteDelegate(long responseCode);
        public DeleteDeviceUserCompleteDelegate DeleteDeviceUserComplete;

        public delegate void DeleteDeviceUsersCompleteDelegate(long responseCode);
        public DeleteDeviceUsersCompleteDelegate DeleteDeviceUsersComplete;

        public DeviceResource GetDeviceData { get; private set; }
        public delegate void GetDeviceCompleteDelegate(long responseCode, DeviceResource response);
        public GetDeviceCompleteDelegate GetDeviceComplete;

        public TemplateResource GetDeviceTemplateData { get; private set; }
        public delegate void GetDeviceTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetDeviceTemplateCompleteDelegate GetDeviceTemplateComplete;

        public PageResourceTemplateResource GetDeviceTemplatesData { get; private set; }
        public delegate void GetDeviceTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetDeviceTemplatesCompleteDelegate GetDeviceTemplatesComplete;

        public PageResourceDeviceResource GetDevicesData { get; private set; }
        public delegate void GetDevicesCompleteDelegate(long responseCode, PageResourceDeviceResource response);
        public GetDevicesCompleteDelegate GetDevicesComplete;

        public DeviceResource UpdateDeviceData { get; private set; }
        public delegate void UpdateDeviceCompleteDelegate(long responseCode, DeviceResource response);
        public UpdateDeviceCompleteDelegate UpdateDeviceComplete;

        public TemplateResource UpdateDeviceTemplateData { get; private set; }
        public delegate void UpdateDeviceTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateDeviceTemplateCompleteDelegate UpdateDeviceTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="DevicesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DevicesApi()
        {
            mAddDeviceUsersResponseContext = new KnetikResponseContext();
            mAddDeviceUsersResponseContext.ResponseReceived += OnAddDeviceUsersResponse;
            mCreateDeviceResponseContext = new KnetikResponseContext();
            mCreateDeviceResponseContext.ResponseReceived += OnCreateDeviceResponse;
            mCreateDeviceTemplateResponseContext = new KnetikResponseContext();
            mCreateDeviceTemplateResponseContext.ResponseReceived += OnCreateDeviceTemplateResponse;
            mDeleteDeviceResponseContext = new KnetikResponseContext();
            mDeleteDeviceResponseContext.ResponseReceived += OnDeleteDeviceResponse;
            mDeleteDeviceTemplateResponseContext = new KnetikResponseContext();
            mDeleteDeviceTemplateResponseContext.ResponseReceived += OnDeleteDeviceTemplateResponse;
            mDeleteDeviceUserResponseContext = new KnetikResponseContext();
            mDeleteDeviceUserResponseContext.ResponseReceived += OnDeleteDeviceUserResponse;
            mDeleteDeviceUsersResponseContext = new KnetikResponseContext();
            mDeleteDeviceUsersResponseContext.ResponseReceived += OnDeleteDeviceUsersResponse;
            mGetDeviceResponseContext = new KnetikResponseContext();
            mGetDeviceResponseContext.ResponseReceived += OnGetDeviceResponse;
            mGetDeviceTemplateResponseContext = new KnetikResponseContext();
            mGetDeviceTemplateResponseContext.ResponseReceived += OnGetDeviceTemplateResponse;
            mGetDeviceTemplatesResponseContext = new KnetikResponseContext();
            mGetDeviceTemplatesResponseContext.ResponseReceived += OnGetDeviceTemplatesResponse;
            mGetDevicesResponseContext = new KnetikResponseContext();
            mGetDevicesResponseContext.ResponseReceived += OnGetDevicesResponse;
            mUpdateDeviceResponseContext = new KnetikResponseContext();
            mUpdateDeviceResponseContext.ResponseReceived += OnUpdateDeviceResponse;
            mUpdateDeviceTemplateResponseContext = new KnetikResponseContext();
            mUpdateDeviceTemplateResponseContext.ResponseReceived += OnUpdateDeviceTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add device users 
        /// </summary>
        /// <param name="userResources">userResources</param>
        /// <param name="id">id</param>
        public void AddDeviceUsers(List<SimpleUserResource> userResources, string id)
        {
            // verify the required parameter 'userResources' is set
            if (userResources == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userResources' when calling AddDeviceUsers");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddDeviceUsers");
            }
            
            mWebCallEvent.WebPath = "/devices/{id}/users";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(userResources); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddDeviceUsersStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddDeviceUsersResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddDeviceUsersStartTime, "AddDeviceUsers", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddDeviceUsersResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddDeviceUsers: " + response.Error);
            }

            AddDeviceUsersData = (DeviceResource) KnetikClient.Deserialize(response.Content, typeof(DeviceResource), response.Headers);
            KnetikLogger.LogResponse(mAddDeviceUsersStartTime, "AddDeviceUsers", string.Format("Response received successfully:\n{0}", AddDeviceUsersData));

            if (AddDeviceUsersComplete != null)
            {
                AddDeviceUsersComplete(response.ResponseCode, AddDeviceUsersData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a device 
        /// </summary>
        /// <param name="device">device</param>
        public void CreateDevice(DeviceResource device)
        {
            // verify the required parameter 'device' is set
            if (device == null)
            {
                throw new KnetikException(400, "Missing required parameter 'device' when calling CreateDevice");
            }
            
            mWebCallEvent.WebPath = "/devices";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(device); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateDeviceStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateDeviceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateDeviceStartTime, "CreateDevice", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateDeviceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateDevice: " + response.Error);
            }

            CreateDeviceData = (DeviceResource) KnetikClient.Deserialize(response.Content, typeof(DeviceResource), response.Headers);
            KnetikLogger.LogResponse(mCreateDeviceStartTime, "CreateDevice", string.Format("Response received successfully:\n{0}", CreateDeviceData));

            if (CreateDeviceComplete != null)
            {
                CreateDeviceComplete(response.ResponseCode, CreateDeviceData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a device template Device Templates define a type of device and the properties they have
        /// </summary>
        /// <param name="deviceTemplateResource">The device template resource object</param>
        public void CreateDeviceTemplate(TemplateResource deviceTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/devices/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(deviceTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateDeviceTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateDeviceTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateDeviceTemplateStartTime, "CreateDeviceTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateDeviceTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateDeviceTemplate: " + response.Error);
            }

            CreateDeviceTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateDeviceTemplateStartTime, "CreateDeviceTemplate", string.Format("Response received successfully:\n{0}", CreateDeviceTemplateData));

            if (CreateDeviceTemplateComplete != null)
            {
                CreateDeviceTemplateComplete(response.ResponseCode, CreateDeviceTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a device 
        /// </summary>
        /// <param name="id">id</param>
        public void DeleteDevice(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteDevice");
            }
            
            mWebCallEvent.WebPath = "/devices/{id}";
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
            mDeleteDeviceStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteDeviceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteDeviceStartTime, "DeleteDevice", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteDeviceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteDevice: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteDeviceStartTime, "DeleteDevice", "Response received successfully.");
            if (DeleteDeviceComplete != null)
            {
                DeleteDeviceComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an device template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteDeviceTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteDeviceTemplate");
            }
            
            mWebCallEvent.WebPath = "/devices/templates/{id}";
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
            mDeleteDeviceTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteDeviceTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteDeviceTemplateStartTime, "DeleteDeviceTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteDeviceTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteDeviceTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteDeviceTemplateStartTime, "DeleteDeviceTemplate", "Response received successfully.");
            if (DeleteDeviceTemplateComplete != null)
            {
                DeleteDeviceTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a device user 
        /// </summary>
        /// <param name="id">The id of the device</param>
        /// <param name="userId">The user id of the device user</param>
        public void DeleteDeviceUser(string id, int? userId)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteDeviceUser");
            }
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling DeleteDeviceUser");
            }
            
            mWebCallEvent.WebPath = "/devices/{id}/users/{user_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
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
            mDeleteDeviceUserStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteDeviceUserResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteDeviceUserStartTime, "DeleteDeviceUser", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteDeviceUserResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteDeviceUser: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteDeviceUserStartTime, "DeleteDeviceUser", "Response received successfully.");
            if (DeleteDeviceUserComplete != null)
            {
                DeleteDeviceUserComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete all device users 
        /// </summary>
        /// <param name="id">The id of the device</param>
        /// <param name="filterId">Filter for device users to delete with a user id in a given comma separated list of ids</param>
        public void DeleteDeviceUsers(string id, string filterId)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteDeviceUsers");
            }
            
            mWebCallEvent.WebPath = "/devices/{id}/users";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterId != null)
            {
                mWebCallEvent.QueryParams["filter_id"] = KnetikClient.ParameterToString(filterId);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteDeviceUsersStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteDeviceUsersResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteDeviceUsersStartTime, "DeleteDeviceUsers", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteDeviceUsersResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteDeviceUsers: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteDeviceUsersStartTime, "DeleteDeviceUsers", "Response received successfully.");
            if (DeleteDeviceUsersComplete != null)
            {
                DeleteDeviceUsersComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single device 
        /// </summary>
        /// <param name="id">id</param>
        public void GetDevice(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetDevice");
            }
            
            mWebCallEvent.WebPath = "/devices/{id}";
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
            mGetDeviceStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetDeviceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetDeviceStartTime, "GetDevice", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetDeviceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetDevice: " + response.Error);
            }

            GetDeviceData = (DeviceResource) KnetikClient.Deserialize(response.Content, typeof(DeviceResource), response.Headers);
            KnetikLogger.LogResponse(mGetDeviceStartTime, "GetDevice", string.Format("Response received successfully:\n{0}", GetDeviceData));

            if (GetDeviceComplete != null)
            {
                GetDeviceComplete(response.ResponseCode, GetDeviceData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single device template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetDeviceTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetDeviceTemplate");
            }
            
            mWebCallEvent.WebPath = "/devices/templates/{id}";
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
            mGetDeviceTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetDeviceTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetDeviceTemplateStartTime, "GetDeviceTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetDeviceTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetDeviceTemplate: " + response.Error);
            }

            GetDeviceTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetDeviceTemplateStartTime, "GetDeviceTemplate", string.Format("Response received successfully:\n{0}", GetDeviceTemplateData));

            if (GetDeviceTemplateComplete != null)
            {
                GetDeviceTemplateComplete(response.ResponseCode, GetDeviceTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search device templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetDeviceTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/devices/templates";
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
            mGetDeviceTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetDeviceTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetDeviceTemplatesStartTime, "GetDeviceTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetDeviceTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetDeviceTemplates: " + response.Error);
            }

            GetDeviceTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetDeviceTemplatesStartTime, "GetDeviceTemplates", string.Format("Response received successfully:\n{0}", GetDeviceTemplatesData));

            if (GetDeviceTemplatesComplete != null)
            {
                GetDeviceTemplatesComplete(response.ResponseCode, GetDeviceTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search devices Get a list of devices with optional filtering
        /// </summary>
        /// <param name="filterMake">Filter for devices with specified make</param>
        /// <param name="filterModel">Filter for devices with specified model</param>
        /// <param name="filterOs">Filter for devices with specified OS</param>
        /// <param name="filterSerial">Filter for devices with specified serial</param>
        /// <param name="filterType">Filter for devices with specified type</param>
        /// <param name="filterTag">A comma separated list without spaces to filter for devices with specified tags (matches any)</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetDevices(string filterMake, string filterModel, string filterOs, string filterSerial, string filterType, string filterTag, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/devices";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterMake != null)
            {
                mWebCallEvent.QueryParams["filter_make"] = KnetikClient.ParameterToString(filterMake);
            }

            if (filterModel != null)
            {
                mWebCallEvent.QueryParams["filter_model"] = KnetikClient.ParameterToString(filterModel);
            }

            if (filterOs != null)
            {
                mWebCallEvent.QueryParams["filter_os"] = KnetikClient.ParameterToString(filterOs);
            }

            if (filterSerial != null)
            {
                mWebCallEvent.QueryParams["filter_serial"] = KnetikClient.ParameterToString(filterSerial);
            }

            if (filterType != null)
            {
                mWebCallEvent.QueryParams["filter_type"] = KnetikClient.ParameterToString(filterType);
            }

            if (filterTag != null)
            {
                mWebCallEvent.QueryParams["filter_tag"] = KnetikClient.ParameterToString(filterTag);
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
            mGetDevicesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetDevicesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetDevicesStartTime, "GetDevices", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetDevicesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetDevices: " + response.Error);
            }

            GetDevicesData = (PageResourceDeviceResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceDeviceResource), response.Headers);
            KnetikLogger.LogResponse(mGetDevicesStartTime, "GetDevices", string.Format("Response received successfully:\n{0}", GetDevicesData));

            if (GetDevicesComplete != null)
            {
                GetDevicesComplete(response.ResponseCode, GetDevicesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a device 
        /// </summary>
        /// <param name="device">device</param>
        /// <param name="id">id</param>
        public void UpdateDevice(DeviceResource device, string id)
        {
            // verify the required parameter 'device' is set
            if (device == null)
            {
                throw new KnetikException(400, "Missing required parameter 'device' when calling UpdateDevice");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateDevice");
            }
            
            mWebCallEvent.WebPath = "/devices/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(device); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateDeviceStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateDeviceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateDeviceStartTime, "UpdateDevice", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateDeviceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateDevice: " + response.Error);
            }

            UpdateDeviceData = (DeviceResource) KnetikClient.Deserialize(response.Content, typeof(DeviceResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateDeviceStartTime, "UpdateDevice", string.Format("Response received successfully:\n{0}", UpdateDeviceData));

            if (UpdateDeviceComplete != null)
            {
                UpdateDeviceComplete(response.ResponseCode, UpdateDeviceData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an device template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="deviceTemplateResource">The device template resource object</param>
        public void UpdateDeviceTemplate(string id, TemplateResource deviceTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateDeviceTemplate");
            }
            
            mWebCallEvent.WebPath = "/devices/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(deviceTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateDeviceTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateDeviceTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateDeviceTemplateStartTime, "UpdateDeviceTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateDeviceTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateDeviceTemplate: " + response.Error);
            }

            UpdateDeviceTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateDeviceTemplateStartTime, "UpdateDeviceTemplate", string.Format("Response received successfully:\n{0}", UpdateDeviceTemplateData));

            if (UpdateDeviceTemplateComplete != null)
            {
                UpdateDeviceTemplateComplete(response.ResponseCode, UpdateDeviceTemplateData);
            }
        }

    }
}
