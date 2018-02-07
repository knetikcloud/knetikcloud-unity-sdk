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
    public interface IObjectsApi
    {
        ObjectResource CreateObjectItemData { get; }

        /// <summary>
        /// Create an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is to be part of</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="objectItem">The object item object</param>
        void CreateObjectItem(string templateId, bool? cascade, ObjectResource objectItem);

        ItemTemplateResource CreateObjectTemplateData { get; }

        /// <summary>
        /// Create an object template Object templates define a type of entitlement and the properties they have
        /// </summary>
        /// <param name="template">The entitlement template to be created</param>
        void CreateObjectTemplate(ItemTemplateResource template);

        

        /// <summary>
        /// Delete an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param>
        /// <param name="objectId">The id of the object</param>
        void DeleteObjectItem(string templateId, int? objectId);

        

        /// <summary>
        /// Delete an entitlement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteObjectTemplate(string id, string cascade);

        ObjectResource GetObjectItemData { get; }

        /// <summary>
        /// Get a single object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param>
        /// <param name="objectId">The id of the object</param>
        void GetObjectItem(string templateId, int? objectId);

        PageResourceObjectResource GetObjectItemsData { get; }

        /// <summary>
        /// List and search objects 
        /// </summary>
        /// <param name="templateId">The id of the template to get objects for</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetObjectItems(string templateId, int? size, int? page, string order);

        ItemTemplateResource GetObjectTemplateData { get; }

        /// <summary>
        /// Get a single entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetObjectTemplate(string id);

        PageResourceItemTemplateResource GetObjectTemplatesData { get; }

        /// <summary>
        /// List and search entitlement templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetObjectTemplates(int? size, int? page, string order);

        

        /// <summary>
        /// Update an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param>
        /// <param name="objectId">The id of the object</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="objectItem">The object item object</param>
        void UpdateObjectItem(string templateId, int? objectId, bool? cascade, ObjectResource objectItem);

        ItemTemplateResource UpdateObjectTemplateData { get; }

        /// <summary>
        /// Update an entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template</param>
        void UpdateObjectTemplate(string id, ItemTemplateResource template);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ObjectsApi : IObjectsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateObjectItemResponseContext;
        private DateTime mCreateObjectItemStartTime;
        private readonly KnetikResponseContext mCreateObjectTemplateResponseContext;
        private DateTime mCreateObjectTemplateStartTime;
        private readonly KnetikResponseContext mDeleteObjectItemResponseContext;
        private DateTime mDeleteObjectItemStartTime;
        private readonly KnetikResponseContext mDeleteObjectTemplateResponseContext;
        private DateTime mDeleteObjectTemplateStartTime;
        private readonly KnetikResponseContext mGetObjectItemResponseContext;
        private DateTime mGetObjectItemStartTime;
        private readonly KnetikResponseContext mGetObjectItemsResponseContext;
        private DateTime mGetObjectItemsStartTime;
        private readonly KnetikResponseContext mGetObjectTemplateResponseContext;
        private DateTime mGetObjectTemplateStartTime;
        private readonly KnetikResponseContext mGetObjectTemplatesResponseContext;
        private DateTime mGetObjectTemplatesStartTime;
        private readonly KnetikResponseContext mUpdateObjectItemResponseContext;
        private DateTime mUpdateObjectItemStartTime;
        private readonly KnetikResponseContext mUpdateObjectTemplateResponseContext;
        private DateTime mUpdateObjectTemplateStartTime;

        public ObjectResource CreateObjectItemData { get; private set; }
        public delegate void CreateObjectItemCompleteDelegate(long responseCode, ObjectResource response);
        public CreateObjectItemCompleteDelegate CreateObjectItemComplete;

        public ItemTemplateResource CreateObjectTemplateData { get; private set; }
        public delegate void CreateObjectTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public CreateObjectTemplateCompleteDelegate CreateObjectTemplateComplete;

        public delegate void DeleteObjectItemCompleteDelegate(long responseCode);
        public DeleteObjectItemCompleteDelegate DeleteObjectItemComplete;

        public delegate void DeleteObjectTemplateCompleteDelegate(long responseCode);
        public DeleteObjectTemplateCompleteDelegate DeleteObjectTemplateComplete;

        public ObjectResource GetObjectItemData { get; private set; }
        public delegate void GetObjectItemCompleteDelegate(long responseCode, ObjectResource response);
        public GetObjectItemCompleteDelegate GetObjectItemComplete;

        public PageResourceObjectResource GetObjectItemsData { get; private set; }
        public delegate void GetObjectItemsCompleteDelegate(long responseCode, PageResourceObjectResource response);
        public GetObjectItemsCompleteDelegate GetObjectItemsComplete;

        public ItemTemplateResource GetObjectTemplateData { get; private set; }
        public delegate void GetObjectTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public GetObjectTemplateCompleteDelegate GetObjectTemplateComplete;

        public PageResourceItemTemplateResource GetObjectTemplatesData { get; private set; }
        public delegate void GetObjectTemplatesCompleteDelegate(long responseCode, PageResourceItemTemplateResource response);
        public GetObjectTemplatesCompleteDelegate GetObjectTemplatesComplete;

        public delegate void UpdateObjectItemCompleteDelegate(long responseCode);
        public UpdateObjectItemCompleteDelegate UpdateObjectItemComplete;

        public ItemTemplateResource UpdateObjectTemplateData { get; private set; }
        public delegate void UpdateObjectTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public UpdateObjectTemplateCompleteDelegate UpdateObjectTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ObjectsApi()
        {
            mCreateObjectItemResponseContext = new KnetikResponseContext();
            mCreateObjectItemResponseContext.ResponseReceived += OnCreateObjectItemResponse;
            mCreateObjectTemplateResponseContext = new KnetikResponseContext();
            mCreateObjectTemplateResponseContext.ResponseReceived += OnCreateObjectTemplateResponse;
            mDeleteObjectItemResponseContext = new KnetikResponseContext();
            mDeleteObjectItemResponseContext.ResponseReceived += OnDeleteObjectItemResponse;
            mDeleteObjectTemplateResponseContext = new KnetikResponseContext();
            mDeleteObjectTemplateResponseContext.ResponseReceived += OnDeleteObjectTemplateResponse;
            mGetObjectItemResponseContext = new KnetikResponseContext();
            mGetObjectItemResponseContext.ResponseReceived += OnGetObjectItemResponse;
            mGetObjectItemsResponseContext = new KnetikResponseContext();
            mGetObjectItemsResponseContext.ResponseReceived += OnGetObjectItemsResponse;
            mGetObjectTemplateResponseContext = new KnetikResponseContext();
            mGetObjectTemplateResponseContext.ResponseReceived += OnGetObjectTemplateResponse;
            mGetObjectTemplatesResponseContext = new KnetikResponseContext();
            mGetObjectTemplatesResponseContext.ResponseReceived += OnGetObjectTemplatesResponse;
            mUpdateObjectItemResponseContext = new KnetikResponseContext();
            mUpdateObjectItemResponseContext.ResponseReceived += OnUpdateObjectItemResponse;
            mUpdateObjectTemplateResponseContext = new KnetikResponseContext();
            mUpdateObjectTemplateResponseContext.ResponseReceived += OnUpdateObjectTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is to be part of</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="objectItem">The object item object</param>
        public void CreateObjectItem(string templateId, bool? cascade, ObjectResource objectItem)
        {
            // verify the required parameter 'templateId' is set
            if (templateId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'templateId' when calling CreateObjectItem");
            }
            
            mWebCallEvent.WebPath = "/objects/{template_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template_id" + "}", KnetikClient.ParameterToString(templateId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (cascade != null)
            {
                mWebCallEvent.QueryParams["cascade"] = KnetikClient.ParameterToString(cascade);
            }

            mWebCallEvent.PostBody = KnetikClient.Serialize(objectItem); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateObjectItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateObjectItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateObjectItemStartTime, "CreateObjectItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateObjectItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateObjectItem: " + response.Error);
            }

            CreateObjectItemData = (ObjectResource) KnetikClient.Deserialize(response.Content, typeof(ObjectResource), response.Headers);
            KnetikLogger.LogResponse(mCreateObjectItemStartTime, "CreateObjectItem", string.Format("Response received successfully:\n{0}", CreateObjectItemData));

            if (CreateObjectItemComplete != null)
            {
                CreateObjectItemComplete(response.ResponseCode, CreateObjectItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create an object template Object templates define a type of entitlement and the properties they have
        /// </summary>
        /// <param name="template">The entitlement template to be created</param>
        public void CreateObjectTemplate(ItemTemplateResource template)
        {
            
            mWebCallEvent.WebPath = "/objects/templates";
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
            mCreateObjectTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateObjectTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateObjectTemplateStartTime, "CreateObjectTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateObjectTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateObjectTemplate: " + response.Error);
            }

            CreateObjectTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateObjectTemplateStartTime, "CreateObjectTemplate", string.Format("Response received successfully:\n{0}", CreateObjectTemplateData));

            if (CreateObjectTemplateComplete != null)
            {
                CreateObjectTemplateComplete(response.ResponseCode, CreateObjectTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param>
        /// <param name="objectId">The id of the object</param>
        public void DeleteObjectItem(string templateId, int? objectId)
        {
            // verify the required parameter 'templateId' is set
            if (templateId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'templateId' when calling DeleteObjectItem");
            }
            // verify the required parameter 'objectId' is set
            if (objectId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'objectId' when calling DeleteObjectItem");
            }
            
            mWebCallEvent.WebPath = "/objects/{template_id}/{object_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template_id" + "}", KnetikClient.ParameterToString(templateId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "object_id" + "}", KnetikClient.ParameterToString(objectId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteObjectItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteObjectItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteObjectItemStartTime, "DeleteObjectItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteObjectItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteObjectItem: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteObjectItemStartTime, "DeleteObjectItem", "Response received successfully.");
            if (DeleteObjectItemComplete != null)
            {
                DeleteObjectItemComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an entitlement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteObjectTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteObjectTemplate");
            }
            
            mWebCallEvent.WebPath = "/objects/templates/{id}";
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
            mDeleteObjectTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteObjectTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteObjectTemplateStartTime, "DeleteObjectTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteObjectTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteObjectTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteObjectTemplateStartTime, "DeleteObjectTemplate", "Response received successfully.");
            if (DeleteObjectTemplateComplete != null)
            {
                DeleteObjectTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param>
        /// <param name="objectId">The id of the object</param>
        public void GetObjectItem(string templateId, int? objectId)
        {
            // verify the required parameter 'templateId' is set
            if (templateId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'templateId' when calling GetObjectItem");
            }
            // verify the required parameter 'objectId' is set
            if (objectId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'objectId' when calling GetObjectItem");
            }
            
            mWebCallEvent.WebPath = "/objects/{template_id}/{object_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template_id" + "}", KnetikClient.ParameterToString(templateId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "object_id" + "}", KnetikClient.ParameterToString(objectId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetObjectItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetObjectItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetObjectItemStartTime, "GetObjectItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetObjectItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetObjectItem: " + response.Error);
            }

            GetObjectItemData = (ObjectResource) KnetikClient.Deserialize(response.Content, typeof(ObjectResource), response.Headers);
            KnetikLogger.LogResponse(mGetObjectItemStartTime, "GetObjectItem", string.Format("Response received successfully:\n{0}", GetObjectItemData));

            if (GetObjectItemComplete != null)
            {
                GetObjectItemComplete(response.ResponseCode, GetObjectItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search objects 
        /// </summary>
        /// <param name="templateId">The id of the template to get objects for</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetObjectItems(string templateId, int? size, int? page, string order)
        {
            // verify the required parameter 'templateId' is set
            if (templateId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'templateId' when calling GetObjectItems");
            }
            
            mWebCallEvent.WebPath = "/objects/{template_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template_id" + "}", KnetikClient.ParameterToString(templateId));

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
            mGetObjectItemsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetObjectItemsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetObjectItemsStartTime, "GetObjectItems", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetObjectItemsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetObjectItems: " + response.Error);
            }

            GetObjectItemsData = (PageResourceObjectResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceObjectResource), response.Headers);
            KnetikLogger.LogResponse(mGetObjectItemsStartTime, "GetObjectItems", string.Format("Response received successfully:\n{0}", GetObjectItemsData));

            if (GetObjectItemsComplete != null)
            {
                GetObjectItemsComplete(response.ResponseCode, GetObjectItemsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetObjectTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetObjectTemplate");
            }
            
            mWebCallEvent.WebPath = "/objects/templates/{id}";
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
            mGetObjectTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetObjectTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetObjectTemplateStartTime, "GetObjectTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetObjectTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetObjectTemplate: " + response.Error);
            }

            GetObjectTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetObjectTemplateStartTime, "GetObjectTemplate", string.Format("Response received successfully:\n{0}", GetObjectTemplateData));

            if (GetObjectTemplateComplete != null)
            {
                GetObjectTemplateComplete(response.ResponseCode, GetObjectTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search entitlement templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetObjectTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/objects/templates";
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
            mGetObjectTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetObjectTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetObjectTemplatesStartTime, "GetObjectTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetObjectTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetObjectTemplates: " + response.Error);
            }

            GetObjectTemplatesData = (PageResourceItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetObjectTemplatesStartTime, "GetObjectTemplates", string.Format("Response received successfully:\n{0}", GetObjectTemplatesData));

            if (GetObjectTemplatesComplete != null)
            {
                GetObjectTemplatesComplete(response.ResponseCode, GetObjectTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param>
        /// <param name="objectId">The id of the object</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="objectItem">The object item object</param>
        public void UpdateObjectItem(string templateId, int? objectId, bool? cascade, ObjectResource objectItem)
        {
            // verify the required parameter 'templateId' is set
            if (templateId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'templateId' when calling UpdateObjectItem");
            }
            // verify the required parameter 'objectId' is set
            if (objectId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'objectId' when calling UpdateObjectItem");
            }
            
            mWebCallEvent.WebPath = "/objects/{template_id}/{object_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template_id" + "}", KnetikClient.ParameterToString(templateId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "object_id" + "}", KnetikClient.ParameterToString(objectId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (cascade != null)
            {
                mWebCallEvent.QueryParams["cascade"] = KnetikClient.ParameterToString(cascade);
            }

            mWebCallEvent.PostBody = KnetikClient.Serialize(objectItem); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateObjectItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateObjectItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateObjectItemStartTime, "UpdateObjectItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateObjectItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateObjectItem: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateObjectItemStartTime, "UpdateObjectItem", "Response received successfully.");
            if (UpdateObjectItemComplete != null)
            {
                UpdateObjectItemComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template</param>
        public void UpdateObjectTemplate(string id, ItemTemplateResource template)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateObjectTemplate");
            }
            
            mWebCallEvent.WebPath = "/objects/templates/{id}";
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
            mUpdateObjectTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateObjectTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateObjectTemplateStartTime, "UpdateObjectTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateObjectTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateObjectTemplate: " + response.Error);
            }

            UpdateObjectTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateObjectTemplateStartTime, "UpdateObjectTemplate", string.Format("Response received successfully:\n{0}", UpdateObjectTemplateData));

            if (UpdateObjectTemplateComplete != null)
            {
                UpdateObjectTemplateComplete(response.ResponseCode, UpdateObjectTemplateData);
            }
        }

    }
}
