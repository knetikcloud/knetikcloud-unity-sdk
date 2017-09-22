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
    public interface IObjectsApi
    {
        ObjectResource CreateObjectItemData { get; }

        ItemTemplateResource CreateObjectTemplateData { get; }

        ObjectResource GetObjectItemData { get; }

        PageResourceObjectResource GetObjectItemsData { get; }

        ItemTemplateResource GetObjectTemplateData { get; }

        PageResourceItemTemplateResource GetObjectTemplatesData { get; }

        ItemTemplateResource UpdateObjectTemplateData { get; }

        
        /// <summary>
        /// Create an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is to be part of</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="objectItem">The object item object</param>
        void CreateObjectItem(string templateId, bool? cascade, ObjectResource objectItem);

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

        /// <summary>
        /// Get a single object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param>
        /// <param name="objectId">The id of the object</param>
        void GetObjectItem(string templateId, int? objectId);

        /// <summary>
        /// List and search objects 
        /// </summary>
        /// <param name="templateId">The id of the template to get objects for</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetObjectItems(string templateId, int? size, int? page, string order);

        /// <summary>
        /// Get a single entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetObjectTemplate(string id);

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
        /// <param name="entitlementId">The id of the entitlement</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="objectItem">The object item object</param>
        void UpdateObjectItem(string templateId, int? entitlementId, bool? cascade, EntitlementItem objectItem);

        /// <summary>
        /// Update an entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template</param>
        void UpdateObjectTemplate(string id, ItemTemplateResource template);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ObjectsApi : IObjectsApi
    {
        private readonly KnetikCoroutine mCreateObjectItemCoroutine;
        private DateTime mCreateObjectItemStartTime;
        private string mCreateObjectItemPath;
        private readonly KnetikCoroutine mCreateObjectTemplateCoroutine;
        private DateTime mCreateObjectTemplateStartTime;
        private string mCreateObjectTemplatePath;
        private readonly KnetikCoroutine mDeleteObjectItemCoroutine;
        private DateTime mDeleteObjectItemStartTime;
        private string mDeleteObjectItemPath;
        private readonly KnetikCoroutine mDeleteObjectTemplateCoroutine;
        private DateTime mDeleteObjectTemplateStartTime;
        private string mDeleteObjectTemplatePath;
        private readonly KnetikCoroutine mGetObjectItemCoroutine;
        private DateTime mGetObjectItemStartTime;
        private string mGetObjectItemPath;
        private readonly KnetikCoroutine mGetObjectItemsCoroutine;
        private DateTime mGetObjectItemsStartTime;
        private string mGetObjectItemsPath;
        private readonly KnetikCoroutine mGetObjectTemplateCoroutine;
        private DateTime mGetObjectTemplateStartTime;
        private string mGetObjectTemplatePath;
        private readonly KnetikCoroutine mGetObjectTemplatesCoroutine;
        private DateTime mGetObjectTemplatesStartTime;
        private string mGetObjectTemplatesPath;
        private readonly KnetikCoroutine mUpdateObjectItemCoroutine;
        private DateTime mUpdateObjectItemStartTime;
        private string mUpdateObjectItemPath;
        private readonly KnetikCoroutine mUpdateObjectTemplateCoroutine;
        private DateTime mUpdateObjectTemplateStartTime;
        private string mUpdateObjectTemplatePath;

        public ObjectResource CreateObjectItemData { get; private set; }
        public delegate void CreateObjectItemCompleteDelegate(ObjectResource response);
        public CreateObjectItemCompleteDelegate CreateObjectItemComplete;

        public ItemTemplateResource CreateObjectTemplateData { get; private set; }
        public delegate void CreateObjectTemplateCompleteDelegate(ItemTemplateResource response);
        public CreateObjectTemplateCompleteDelegate CreateObjectTemplateComplete;

        public delegate void DeleteObjectItemCompleteDelegate();
        public DeleteObjectItemCompleteDelegate DeleteObjectItemComplete;

        public delegate void DeleteObjectTemplateCompleteDelegate();
        public DeleteObjectTemplateCompleteDelegate DeleteObjectTemplateComplete;

        public ObjectResource GetObjectItemData { get; private set; }
        public delegate void GetObjectItemCompleteDelegate(ObjectResource response);
        public GetObjectItemCompleteDelegate GetObjectItemComplete;

        public PageResourceObjectResource GetObjectItemsData { get; private set; }
        public delegate void GetObjectItemsCompleteDelegate(PageResourceObjectResource response);
        public GetObjectItemsCompleteDelegate GetObjectItemsComplete;

        public ItemTemplateResource GetObjectTemplateData { get; private set; }
        public delegate void GetObjectTemplateCompleteDelegate(ItemTemplateResource response);
        public GetObjectTemplateCompleteDelegate GetObjectTemplateComplete;

        public PageResourceItemTemplateResource GetObjectTemplatesData { get; private set; }
        public delegate void GetObjectTemplatesCompleteDelegate(PageResourceItemTemplateResource response);
        public GetObjectTemplatesCompleteDelegate GetObjectTemplatesComplete;

        public delegate void UpdateObjectItemCompleteDelegate();
        public UpdateObjectItemCompleteDelegate UpdateObjectItemComplete;

        public ItemTemplateResource UpdateObjectTemplateData { get; private set; }
        public delegate void UpdateObjectTemplateCompleteDelegate(ItemTemplateResource response);
        public UpdateObjectTemplateCompleteDelegate UpdateObjectTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ObjectsApi()
        {
            mCreateObjectItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mCreateObjectTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mDeleteObjectItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mDeleteObjectTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetObjectItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetObjectItemsCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetObjectTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetObjectTemplatesCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateObjectItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateObjectTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
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
            
            mCreateObjectItemPath = "/objects/{template_id}";
            if (!string.IsNullOrEmpty(mCreateObjectItemPath))
            {
                mCreateObjectItemPath = mCreateObjectItemPath.Replace("{format}", "json");
            }
            mCreateObjectItemPath = mCreateObjectItemPath.Replace("{" + "template_id" + "}", KnetikClient.DefaultClient.ParameterToString(templateId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            postBody = KnetikClient.DefaultClient.Serialize(objectItem); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateObjectItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateObjectItemStartTime, mCreateObjectItemPath, "Sending server request...");

            // make the HTTP request
            mCreateObjectItemCoroutine.ResponseReceived += CreateObjectItemCallback;
            mCreateObjectItemCoroutine.Start(mCreateObjectItemPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateObjectItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateObjectItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateObjectItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateObjectItemData = (ObjectResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ObjectResource), response.Headers);
            KnetikLogger.LogResponse(mCreateObjectItemStartTime, mCreateObjectItemPath, string.Format("Response received successfully:\n{0}", CreateObjectItemData.ToString()));

            if (CreateObjectItemComplete != null)
            {
                CreateObjectItemComplete(CreateObjectItemData);
            }
        }
        /// <summary>
        /// Create an object template Object templates define a type of entitlement and the properties they have
        /// </summary>
        /// <param name="template">The entitlement template to be created</param>
        public void CreateObjectTemplate(ItemTemplateResource template)
        {
            
            mCreateObjectTemplatePath = "/objects/templates";
            if (!string.IsNullOrEmpty(mCreateObjectTemplatePath))
            {
                mCreateObjectTemplatePath = mCreateObjectTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mCreateObjectTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateObjectTemplateStartTime, mCreateObjectTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateObjectTemplateCoroutine.ResponseReceived += CreateObjectTemplateCallback;
            mCreateObjectTemplateCoroutine.Start(mCreateObjectTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateObjectTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateObjectTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateObjectTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateObjectTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateObjectTemplateStartTime, mCreateObjectTemplatePath, string.Format("Response received successfully:\n{0}", CreateObjectTemplateData.ToString()));

            if (CreateObjectTemplateComplete != null)
            {
                CreateObjectTemplateComplete(CreateObjectTemplateData);
            }
        }
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
            
            mDeleteObjectItemPath = "/objects/{template_id}/{object_id}";
            if (!string.IsNullOrEmpty(mDeleteObjectItemPath))
            {
                mDeleteObjectItemPath = mDeleteObjectItemPath.Replace("{format}", "json");
            }
            mDeleteObjectItemPath = mDeleteObjectItemPath.Replace("{" + "template_id" + "}", KnetikClient.DefaultClient.ParameterToString(templateId));
mDeleteObjectItemPath = mDeleteObjectItemPath.Replace("{" + "object_id" + "}", KnetikClient.DefaultClient.ParameterToString(objectId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteObjectItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteObjectItemStartTime, mDeleteObjectItemPath, "Sending server request...");

            // make the HTTP request
            mDeleteObjectItemCoroutine.ResponseReceived += DeleteObjectItemCallback;
            mDeleteObjectItemCoroutine.Start(mDeleteObjectItemPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteObjectItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteObjectItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteObjectItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteObjectItemStartTime, mDeleteObjectItemPath, "Response received successfully.");
            if (DeleteObjectItemComplete != null)
            {
                DeleteObjectItemComplete();
            }
        }
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
            
            mDeleteObjectTemplatePath = "/objects/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteObjectTemplatePath))
            {
                mDeleteObjectTemplatePath = mDeleteObjectTemplatePath.Replace("{format}", "json");
            }
            mDeleteObjectTemplatePath = mDeleteObjectTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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
            string[] authSettings = new string[] {  };

            mDeleteObjectTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteObjectTemplateStartTime, mDeleteObjectTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteObjectTemplateCoroutine.ResponseReceived += DeleteObjectTemplateCallback;
            mDeleteObjectTemplateCoroutine.Start(mDeleteObjectTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteObjectTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteObjectTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteObjectTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteObjectTemplateStartTime, mDeleteObjectTemplatePath, "Response received successfully.");
            if (DeleteObjectTemplateComplete != null)
            {
                DeleteObjectTemplateComplete();
            }
        }
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
            
            mGetObjectItemPath = "/objects/{template_id}/{object_id}";
            if (!string.IsNullOrEmpty(mGetObjectItemPath))
            {
                mGetObjectItemPath = mGetObjectItemPath.Replace("{format}", "json");
            }
            mGetObjectItemPath = mGetObjectItemPath.Replace("{" + "template_id" + "}", KnetikClient.DefaultClient.ParameterToString(templateId));
mGetObjectItemPath = mGetObjectItemPath.Replace("{" + "object_id" + "}", KnetikClient.DefaultClient.ParameterToString(objectId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetObjectItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetObjectItemStartTime, mGetObjectItemPath, "Sending server request...");

            // make the HTTP request
            mGetObjectItemCoroutine.ResponseReceived += GetObjectItemCallback;
            mGetObjectItemCoroutine.Start(mGetObjectItemPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetObjectItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetObjectItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetObjectItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetObjectItemData = (ObjectResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ObjectResource), response.Headers);
            KnetikLogger.LogResponse(mGetObjectItemStartTime, mGetObjectItemPath, string.Format("Response received successfully:\n{0}", GetObjectItemData.ToString()));

            if (GetObjectItemComplete != null)
            {
                GetObjectItemComplete(GetObjectItemData);
            }
        }
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
            
            mGetObjectItemsPath = "/objects/{template_id}";
            if (!string.IsNullOrEmpty(mGetObjectItemsPath))
            {
                mGetObjectItemsPath = mGetObjectItemsPath.Replace("{format}", "json");
            }
            mGetObjectItemsPath = mGetObjectItemsPath.Replace("{" + "template_id" + "}", KnetikClient.DefaultClient.ParameterToString(templateId));

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
            string[] authSettings = new string[] {  };

            mGetObjectItemsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetObjectItemsStartTime, mGetObjectItemsPath, "Sending server request...");

            // make the HTTP request
            mGetObjectItemsCoroutine.ResponseReceived += GetObjectItemsCallback;
            mGetObjectItemsCoroutine.Start(mGetObjectItemsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetObjectItemsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetObjectItems: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetObjectItems: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetObjectItemsData = (PageResourceObjectResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceObjectResource), response.Headers);
            KnetikLogger.LogResponse(mGetObjectItemsStartTime, mGetObjectItemsPath, string.Format("Response received successfully:\n{0}", GetObjectItemsData.ToString()));

            if (GetObjectItemsComplete != null)
            {
                GetObjectItemsComplete(GetObjectItemsData);
            }
        }
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
            
            mGetObjectTemplatePath = "/objects/templates/{id}";
            if (!string.IsNullOrEmpty(mGetObjectTemplatePath))
            {
                mGetObjectTemplatePath = mGetObjectTemplatePath.Replace("{format}", "json");
            }
            mGetObjectTemplatePath = mGetObjectTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetObjectTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetObjectTemplateStartTime, mGetObjectTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetObjectTemplateCoroutine.ResponseReceived += GetObjectTemplateCallback;
            mGetObjectTemplateCoroutine.Start(mGetObjectTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetObjectTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetObjectTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetObjectTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetObjectTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetObjectTemplateStartTime, mGetObjectTemplatePath, string.Format("Response received successfully:\n{0}", GetObjectTemplateData.ToString()));

            if (GetObjectTemplateComplete != null)
            {
                GetObjectTemplateComplete(GetObjectTemplateData);
            }
        }
        /// <summary>
        /// List and search entitlement templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetObjectTemplates(int? size, int? page, string order)
        {
            
            mGetObjectTemplatesPath = "/objects/templates";
            if (!string.IsNullOrEmpty(mGetObjectTemplatesPath))
            {
                mGetObjectTemplatesPath = mGetObjectTemplatesPath.Replace("{format}", "json");
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
            string[] authSettings = new string[] {  };

            mGetObjectTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetObjectTemplatesStartTime, mGetObjectTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetObjectTemplatesCoroutine.ResponseReceived += GetObjectTemplatesCallback;
            mGetObjectTemplatesCoroutine.Start(mGetObjectTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetObjectTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetObjectTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetObjectTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetObjectTemplatesData = (PageResourceItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetObjectTemplatesStartTime, mGetObjectTemplatesPath, string.Format("Response received successfully:\n{0}", GetObjectTemplatesData.ToString()));

            if (GetObjectTemplatesComplete != null)
            {
                GetObjectTemplatesComplete(GetObjectTemplatesData);
            }
        }
        /// <summary>
        /// Update an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param>
        /// <param name="entitlementId">The id of the entitlement</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="objectItem">The object item object</param>
        public void UpdateObjectItem(string templateId, int? entitlementId, bool? cascade, EntitlementItem objectItem)
        {
            // verify the required parameter 'templateId' is set
            if (templateId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'templateId' when calling UpdateObjectItem");
            }
            // verify the required parameter 'entitlementId' is set
            if (entitlementId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'entitlementId' when calling UpdateObjectItem");
            }
            
            mUpdateObjectItemPath = "/objects/{template_id}/{object_id}";
            if (!string.IsNullOrEmpty(mUpdateObjectItemPath))
            {
                mUpdateObjectItemPath = mUpdateObjectItemPath.Replace("{format}", "json");
            }
            mUpdateObjectItemPath = mUpdateObjectItemPath.Replace("{" + "template_id" + "}", KnetikClient.DefaultClient.ParameterToString(templateId));
mUpdateObjectItemPath = mUpdateObjectItemPath.Replace("{" + "entitlement_id" + "}", KnetikClient.DefaultClient.ParameterToString(entitlementId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            postBody = KnetikClient.DefaultClient.Serialize(objectItem); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateObjectItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateObjectItemStartTime, mUpdateObjectItemPath, "Sending server request...");

            // make the HTTP request
            mUpdateObjectItemCoroutine.ResponseReceived += UpdateObjectItemCallback;
            mUpdateObjectItemCoroutine.Start(mUpdateObjectItemPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateObjectItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateObjectItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateObjectItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateObjectItemStartTime, mUpdateObjectItemPath, "Response received successfully.");
            if (UpdateObjectItemComplete != null)
            {
                UpdateObjectItemComplete();
            }
        }
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
            
            mUpdateObjectTemplatePath = "/objects/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateObjectTemplatePath))
            {
                mUpdateObjectTemplatePath = mUpdateObjectTemplatePath.Replace("{format}", "json");
            }
            mUpdateObjectTemplatePath = mUpdateObjectTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mUpdateObjectTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateObjectTemplateStartTime, mUpdateObjectTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateObjectTemplateCoroutine.ResponseReceived += UpdateObjectTemplateCallback;
            mUpdateObjectTemplateCoroutine.Start(mUpdateObjectTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateObjectTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateObjectTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateObjectTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateObjectTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateObjectTemplateStartTime, mUpdateObjectTemplatePath, string.Format("Response received successfully:\n{0}", UpdateObjectTemplateData.ToString()));

            if (UpdateObjectTemplateComplete != null)
            {
                UpdateObjectTemplateComplete(UpdateObjectTemplateData);
            }
        }
    }
}
