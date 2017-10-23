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
    public interface IDevicesApi
    {
        DeviceResource AddDeviceUsersData { get; }

        DeviceResource CreateDeviceData { get; }

        TemplateResource CreateDeviceTemplateData { get; }

        DeviceResource GetDeviceData { get; }

        TemplateResource GetDeviceTemplateData { get; }

        PageResourceTemplateResource GetDeviceTemplatesData { get; }

        PageResourceDeviceResource GetDevicesData { get; }

        DeviceResource UpdateDeviceData { get; }

        TemplateResource UpdateDeviceTemplateData { get; }

        
        /// <summary>
        /// Add device users 
        /// </summary>
        /// <param name="userResources">userResources</param>
        /// <param name="id">id</param>
        void AddDeviceUsers(List<SimpleUserResource> userResources, string id);

        /// <summary>
        /// Create a device 
        /// </summary>
        /// <param name="device">device</param>
        void CreateDevice(DeviceResource device);

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

        /// <summary>
        /// Get a single device 
        /// </summary>
        /// <param name="id">id</param>
        void GetDevice(string id);

        /// <summary>
        /// Get a single device template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetDeviceTemplate(string id);

        /// <summary>
        /// List and search device templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetDeviceTemplates(int? size, int? page, string order);

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

        /// <summary>
        /// Update a device 
        /// </summary>
        /// <param name="device">device</param>
        /// <param name="id">id</param>
        void UpdateDevice(DeviceResource device, string id);

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
        private readonly KnetikCoroutine mAddDeviceUsersCoroutine;
        private DateTime mAddDeviceUsersStartTime;
        private string mAddDeviceUsersPath;
        private readonly KnetikCoroutine mCreateDeviceCoroutine;
        private DateTime mCreateDeviceStartTime;
        private string mCreateDevicePath;
        private readonly KnetikCoroutine mCreateDeviceTemplateCoroutine;
        private DateTime mCreateDeviceTemplateStartTime;
        private string mCreateDeviceTemplatePath;
        private readonly KnetikCoroutine mDeleteDeviceCoroutine;
        private DateTime mDeleteDeviceStartTime;
        private string mDeleteDevicePath;
        private readonly KnetikCoroutine mDeleteDeviceTemplateCoroutine;
        private DateTime mDeleteDeviceTemplateStartTime;
        private string mDeleteDeviceTemplatePath;
        private readonly KnetikCoroutine mDeleteDeviceUserCoroutine;
        private DateTime mDeleteDeviceUserStartTime;
        private string mDeleteDeviceUserPath;
        private readonly KnetikCoroutine mDeleteDeviceUsersCoroutine;
        private DateTime mDeleteDeviceUsersStartTime;
        private string mDeleteDeviceUsersPath;
        private readonly KnetikCoroutine mGetDeviceCoroutine;
        private DateTime mGetDeviceStartTime;
        private string mGetDevicePath;
        private readonly KnetikCoroutine mGetDeviceTemplateCoroutine;
        private DateTime mGetDeviceTemplateStartTime;
        private string mGetDeviceTemplatePath;
        private readonly KnetikCoroutine mGetDeviceTemplatesCoroutine;
        private DateTime mGetDeviceTemplatesStartTime;
        private string mGetDeviceTemplatesPath;
        private readonly KnetikCoroutine mGetDevicesCoroutine;
        private DateTime mGetDevicesStartTime;
        private string mGetDevicesPath;
        private readonly KnetikCoroutine mUpdateDeviceCoroutine;
        private DateTime mUpdateDeviceStartTime;
        private string mUpdateDevicePath;
        private readonly KnetikCoroutine mUpdateDeviceTemplateCoroutine;
        private DateTime mUpdateDeviceTemplateStartTime;
        private string mUpdateDeviceTemplatePath;

        public DeviceResource AddDeviceUsersData { get; private set; }
        public delegate void AddDeviceUsersCompleteDelegate(DeviceResource response);
        public AddDeviceUsersCompleteDelegate AddDeviceUsersComplete;

        public DeviceResource CreateDeviceData { get; private set; }
        public delegate void CreateDeviceCompleteDelegate(DeviceResource response);
        public CreateDeviceCompleteDelegate CreateDeviceComplete;

        public TemplateResource CreateDeviceTemplateData { get; private set; }
        public delegate void CreateDeviceTemplateCompleteDelegate(TemplateResource response);
        public CreateDeviceTemplateCompleteDelegate CreateDeviceTemplateComplete;

        public delegate void DeleteDeviceCompleteDelegate();
        public DeleteDeviceCompleteDelegate DeleteDeviceComplete;

        public delegate void DeleteDeviceTemplateCompleteDelegate();
        public DeleteDeviceTemplateCompleteDelegate DeleteDeviceTemplateComplete;

        public delegate void DeleteDeviceUserCompleteDelegate();
        public DeleteDeviceUserCompleteDelegate DeleteDeviceUserComplete;

        public delegate void DeleteDeviceUsersCompleteDelegate();
        public DeleteDeviceUsersCompleteDelegate DeleteDeviceUsersComplete;

        public DeviceResource GetDeviceData { get; private set; }
        public delegate void GetDeviceCompleteDelegate(DeviceResource response);
        public GetDeviceCompleteDelegate GetDeviceComplete;

        public TemplateResource GetDeviceTemplateData { get; private set; }
        public delegate void GetDeviceTemplateCompleteDelegate(TemplateResource response);
        public GetDeviceTemplateCompleteDelegate GetDeviceTemplateComplete;

        public PageResourceTemplateResource GetDeviceTemplatesData { get; private set; }
        public delegate void GetDeviceTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetDeviceTemplatesCompleteDelegate GetDeviceTemplatesComplete;

        public PageResourceDeviceResource GetDevicesData { get; private set; }
        public delegate void GetDevicesCompleteDelegate(PageResourceDeviceResource response);
        public GetDevicesCompleteDelegate GetDevicesComplete;

        public DeviceResource UpdateDeviceData { get; private set; }
        public delegate void UpdateDeviceCompleteDelegate(DeviceResource response);
        public UpdateDeviceCompleteDelegate UpdateDeviceComplete;

        public TemplateResource UpdateDeviceTemplateData { get; private set; }
        public delegate void UpdateDeviceTemplateCompleteDelegate(TemplateResource response);
        public UpdateDeviceTemplateCompleteDelegate UpdateDeviceTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="DevicesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DevicesApi()
        {
            mAddDeviceUsersCoroutine = new KnetikCoroutine();
            mCreateDeviceCoroutine = new KnetikCoroutine();
            mCreateDeviceTemplateCoroutine = new KnetikCoroutine();
            mDeleteDeviceCoroutine = new KnetikCoroutine();
            mDeleteDeviceTemplateCoroutine = new KnetikCoroutine();
            mDeleteDeviceUserCoroutine = new KnetikCoroutine();
            mDeleteDeviceUsersCoroutine = new KnetikCoroutine();
            mGetDeviceCoroutine = new KnetikCoroutine();
            mGetDeviceTemplateCoroutine = new KnetikCoroutine();
            mGetDeviceTemplatesCoroutine = new KnetikCoroutine();
            mGetDevicesCoroutine = new KnetikCoroutine();
            mUpdateDeviceCoroutine = new KnetikCoroutine();
            mUpdateDeviceTemplateCoroutine = new KnetikCoroutine();
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
            
            mAddDeviceUsersPath = "/devices/{id}/users";
            if (!string.IsNullOrEmpty(mAddDeviceUsersPath))
            {
                mAddDeviceUsersPath = mAddDeviceUsersPath.Replace("{format}", "json");
            }
            mAddDeviceUsersPath = mAddDeviceUsersPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(userResources); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddDeviceUsersStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddDeviceUsersStartTime, mAddDeviceUsersPath, "Sending server request...");

            // make the HTTP request
            mAddDeviceUsersCoroutine.ResponseReceived += AddDeviceUsersCallback;
            mAddDeviceUsersCoroutine.Start(mAddDeviceUsersPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddDeviceUsersCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddDeviceUsers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddDeviceUsers: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddDeviceUsersData = (DeviceResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(DeviceResource), response.Headers);
            KnetikLogger.LogResponse(mAddDeviceUsersStartTime, mAddDeviceUsersPath, string.Format("Response received successfully:\n{0}", AddDeviceUsersData.ToString()));

            if (AddDeviceUsersComplete != null)
            {
                AddDeviceUsersComplete(AddDeviceUsersData);
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
            
            mCreateDevicePath = "/devices";
            if (!string.IsNullOrEmpty(mCreateDevicePath))
            {
                mCreateDevicePath = mCreateDevicePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(device); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateDeviceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateDeviceStartTime, mCreateDevicePath, "Sending server request...");

            // make the HTTP request
            mCreateDeviceCoroutine.ResponseReceived += CreateDeviceCallback;
            mCreateDeviceCoroutine.Start(mCreateDevicePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateDeviceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateDevice: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateDevice: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateDeviceData = (DeviceResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(DeviceResource), response.Headers);
            KnetikLogger.LogResponse(mCreateDeviceStartTime, mCreateDevicePath, string.Format("Response received successfully:\n{0}", CreateDeviceData.ToString()));

            if (CreateDeviceComplete != null)
            {
                CreateDeviceComplete(CreateDeviceData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a device template Device Templates define a type of device and the properties they have
        /// </summary>
        /// <param name="deviceTemplateResource">The device template resource object</param>
        public void CreateDeviceTemplate(TemplateResource deviceTemplateResource)
        {
            
            mCreateDeviceTemplatePath = "/devices/templates";
            if (!string.IsNullOrEmpty(mCreateDeviceTemplatePath))
            {
                mCreateDeviceTemplatePath = mCreateDeviceTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(deviceTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateDeviceTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateDeviceTemplateStartTime, mCreateDeviceTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateDeviceTemplateCoroutine.ResponseReceived += CreateDeviceTemplateCallback;
            mCreateDeviceTemplateCoroutine.Start(mCreateDeviceTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateDeviceTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateDeviceTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateDeviceTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateDeviceTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateDeviceTemplateStartTime, mCreateDeviceTemplatePath, string.Format("Response received successfully:\n{0}", CreateDeviceTemplateData.ToString()));

            if (CreateDeviceTemplateComplete != null)
            {
                CreateDeviceTemplateComplete(CreateDeviceTemplateData);
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
            
            mDeleteDevicePath = "/devices/{id}";
            if (!string.IsNullOrEmpty(mDeleteDevicePath))
            {
                mDeleteDevicePath = mDeleteDevicePath.Replace("{format}", "json");
            }
            mDeleteDevicePath = mDeleteDevicePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteDeviceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteDeviceStartTime, mDeleteDevicePath, "Sending server request...");

            // make the HTTP request
            mDeleteDeviceCoroutine.ResponseReceived += DeleteDeviceCallback;
            mDeleteDeviceCoroutine.Start(mDeleteDevicePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteDeviceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteDevice: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteDevice: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteDeviceStartTime, mDeleteDevicePath, "Response received successfully.");
            if (DeleteDeviceComplete != null)
            {
                DeleteDeviceComplete();
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
            
            mDeleteDeviceTemplatePath = "/devices/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteDeviceTemplatePath))
            {
                mDeleteDeviceTemplatePath = mDeleteDeviceTemplatePath.Replace("{format}", "json");
            }
            mDeleteDeviceTemplatePath = mDeleteDeviceTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mDeleteDeviceTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteDeviceTemplateStartTime, mDeleteDeviceTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteDeviceTemplateCoroutine.ResponseReceived += DeleteDeviceTemplateCallback;
            mDeleteDeviceTemplateCoroutine.Start(mDeleteDeviceTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteDeviceTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteDeviceTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteDeviceTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteDeviceTemplateStartTime, mDeleteDeviceTemplatePath, "Response received successfully.");
            if (DeleteDeviceTemplateComplete != null)
            {
                DeleteDeviceTemplateComplete();
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
            
            mDeleteDeviceUserPath = "/devices/{id}/users/{user_id}";
            if (!string.IsNullOrEmpty(mDeleteDeviceUserPath))
            {
                mDeleteDeviceUserPath = mDeleteDeviceUserPath.Replace("{format}", "json");
            }
            mDeleteDeviceUserPath = mDeleteDeviceUserPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));
mDeleteDeviceUserPath = mDeleteDeviceUserPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteDeviceUserStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteDeviceUserStartTime, mDeleteDeviceUserPath, "Sending server request...");

            // make the HTTP request
            mDeleteDeviceUserCoroutine.ResponseReceived += DeleteDeviceUserCallback;
            mDeleteDeviceUserCoroutine.Start(mDeleteDeviceUserPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteDeviceUserCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteDeviceUser: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteDeviceUser: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteDeviceUserStartTime, mDeleteDeviceUserPath, "Response received successfully.");
            if (DeleteDeviceUserComplete != null)
            {
                DeleteDeviceUserComplete();
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
            
            mDeleteDeviceUsersPath = "/devices/{id}/users";
            if (!string.IsNullOrEmpty(mDeleteDeviceUsersPath))
            {
                mDeleteDeviceUsersPath = mDeleteDeviceUsersPath.Replace("{format}", "json");
            }
            mDeleteDeviceUsersPath = mDeleteDeviceUsersPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterId != null)
            {
                queryParams.Add("filter_id", KnetikClient.DefaultClient.ParameterToString(filterId));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteDeviceUsersStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteDeviceUsersStartTime, mDeleteDeviceUsersPath, "Sending server request...");

            // make the HTTP request
            mDeleteDeviceUsersCoroutine.ResponseReceived += DeleteDeviceUsersCallback;
            mDeleteDeviceUsersCoroutine.Start(mDeleteDeviceUsersPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteDeviceUsersCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteDeviceUsers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteDeviceUsers: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteDeviceUsersStartTime, mDeleteDeviceUsersPath, "Response received successfully.");
            if (DeleteDeviceUsersComplete != null)
            {
                DeleteDeviceUsersComplete();
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
            
            mGetDevicePath = "/devices/{id}";
            if (!string.IsNullOrEmpty(mGetDevicePath))
            {
                mGetDevicePath = mGetDevicePath.Replace("{format}", "json");
            }
            mGetDevicePath = mGetDevicePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetDeviceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetDeviceStartTime, mGetDevicePath, "Sending server request...");

            // make the HTTP request
            mGetDeviceCoroutine.ResponseReceived += GetDeviceCallback;
            mGetDeviceCoroutine.Start(mGetDevicePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetDeviceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDevice: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDevice: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetDeviceData = (DeviceResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(DeviceResource), response.Headers);
            KnetikLogger.LogResponse(mGetDeviceStartTime, mGetDevicePath, string.Format("Response received successfully:\n{0}", GetDeviceData.ToString()));

            if (GetDeviceComplete != null)
            {
                GetDeviceComplete(GetDeviceData);
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
            
            mGetDeviceTemplatePath = "/devices/templates/{id}";
            if (!string.IsNullOrEmpty(mGetDeviceTemplatePath))
            {
                mGetDeviceTemplatePath = mGetDeviceTemplatePath.Replace("{format}", "json");
            }
            mGetDeviceTemplatePath = mGetDeviceTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetDeviceTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetDeviceTemplateStartTime, mGetDeviceTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetDeviceTemplateCoroutine.ResponseReceived += GetDeviceTemplateCallback;
            mGetDeviceTemplateCoroutine.Start(mGetDeviceTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetDeviceTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDeviceTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDeviceTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetDeviceTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetDeviceTemplateStartTime, mGetDeviceTemplatePath, string.Format("Response received successfully:\n{0}", GetDeviceTemplateData.ToString()));

            if (GetDeviceTemplateComplete != null)
            {
                GetDeviceTemplateComplete(GetDeviceTemplateData);
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
            
            mGetDeviceTemplatesPath = "/devices/templates";
            if (!string.IsNullOrEmpty(mGetDeviceTemplatesPath))
            {
                mGetDeviceTemplatesPath = mGetDeviceTemplatesPath.Replace("{format}", "json");
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

            mGetDeviceTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetDeviceTemplatesStartTime, mGetDeviceTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetDeviceTemplatesCoroutine.ResponseReceived += GetDeviceTemplatesCallback;
            mGetDeviceTemplatesCoroutine.Start(mGetDeviceTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetDeviceTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDeviceTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDeviceTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetDeviceTemplatesData = (PageResourceTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetDeviceTemplatesStartTime, mGetDeviceTemplatesPath, string.Format("Response received successfully:\n{0}", GetDeviceTemplatesData.ToString()));

            if (GetDeviceTemplatesComplete != null)
            {
                GetDeviceTemplatesComplete(GetDeviceTemplatesData);
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
            
            mGetDevicesPath = "/devices";
            if (!string.IsNullOrEmpty(mGetDevicesPath))
            {
                mGetDevicesPath = mGetDevicesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterMake != null)
            {
                queryParams.Add("filter_make", KnetikClient.DefaultClient.ParameterToString(filterMake));
            }

            if (filterModel != null)
            {
                queryParams.Add("filter_model", KnetikClient.DefaultClient.ParameterToString(filterModel));
            }

            if (filterOs != null)
            {
                queryParams.Add("filter_os", KnetikClient.DefaultClient.ParameterToString(filterOs));
            }

            if (filterSerial != null)
            {
                queryParams.Add("filter_serial", KnetikClient.DefaultClient.ParameterToString(filterSerial));
            }

            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.DefaultClient.ParameterToString(filterType));
            }

            if (filterTag != null)
            {
                queryParams.Add("filter_tag", KnetikClient.DefaultClient.ParameterToString(filterTag));
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetDevicesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetDevicesStartTime, mGetDevicesPath, "Sending server request...");

            // make the HTTP request
            mGetDevicesCoroutine.ResponseReceived += GetDevicesCallback;
            mGetDevicesCoroutine.Start(mGetDevicesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetDevicesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDevices: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDevices: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetDevicesData = (PageResourceDeviceResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceDeviceResource), response.Headers);
            KnetikLogger.LogResponse(mGetDevicesStartTime, mGetDevicesPath, string.Format("Response received successfully:\n{0}", GetDevicesData.ToString()));

            if (GetDevicesComplete != null)
            {
                GetDevicesComplete(GetDevicesData);
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
            
            mUpdateDevicePath = "/devices/{id}";
            if (!string.IsNullOrEmpty(mUpdateDevicePath))
            {
                mUpdateDevicePath = mUpdateDevicePath.Replace("{format}", "json");
            }
            mUpdateDevicePath = mUpdateDevicePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(device); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateDeviceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateDeviceStartTime, mUpdateDevicePath, "Sending server request...");

            // make the HTTP request
            mUpdateDeviceCoroutine.ResponseReceived += UpdateDeviceCallback;
            mUpdateDeviceCoroutine.Start(mUpdateDevicePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateDeviceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateDevice: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateDevice: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateDeviceData = (DeviceResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(DeviceResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateDeviceStartTime, mUpdateDevicePath, string.Format("Response received successfully:\n{0}", UpdateDeviceData.ToString()));

            if (UpdateDeviceComplete != null)
            {
                UpdateDeviceComplete(UpdateDeviceData);
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
            
            mUpdateDeviceTemplatePath = "/devices/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateDeviceTemplatePath))
            {
                mUpdateDeviceTemplatePath = mUpdateDeviceTemplatePath.Replace("{format}", "json");
            }
            mUpdateDeviceTemplatePath = mUpdateDeviceTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(deviceTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateDeviceTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateDeviceTemplateStartTime, mUpdateDeviceTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateDeviceTemplateCoroutine.ResponseReceived += UpdateDeviceTemplateCallback;
            mUpdateDeviceTemplateCoroutine.Start(mUpdateDeviceTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateDeviceTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateDeviceTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateDeviceTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateDeviceTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateDeviceTemplateStartTime, mUpdateDeviceTemplatePath, string.Format("Response received successfully:\n{0}", UpdateDeviceTemplateData.ToString()));

            if (UpdateDeviceTemplateComplete != null)
            {
                UpdateDeviceTemplateComplete(UpdateDeviceTemplateData);
            }
        }

    }
}
