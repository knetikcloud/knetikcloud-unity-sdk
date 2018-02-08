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
    public interface IBRERuleEngineCategoriesApi
    {
        TemplateResource CreateBRECategoryTemplateData { get; }

        /// <summary>
        /// Create a BRE category template Templates define a type of BRE category and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="template">The category template to create</param>
        void CreateBRECategoryTemplate(TemplateResource template);

        

        /// <summary>
        /// Delete a BRE category template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteBRECategoryTemplate(string id, string cascade);

        PageResourceBreCategoryResource GetBRECategoriesData { get; }

        /// <summary>
        /// List categories &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_CATEGORIES_USER
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetBRECategories(int? size, int? page);

        BreCategoryResource GetBRECategoryData { get; }

        /// <summary>
        /// Get a single category &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_CATEGORIES_USER
        /// </summary>
        /// <param name="name">The category name</param>
        void GetBRECategory(string name);

        TemplateResource GetBRECategoryTemplateData { get; }

        /// <summary>
        /// Get a single BRE category template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or BRE_RULE_ENGINE_CATEGORIES_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetBRECategoryTemplate(string id);

        PageResourceTemplateResource GetBRECategoryTemplatesData { get; }

        /// <summary>
        /// List and search BRE category templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or BRE_RULE_ENGINE_CATEGORIES_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetBRECategoryTemplates(int? size, int? page, string order);

        BreCategoryResource UpdateBRECategoryData { get; }

        /// <summary>
        /// Update a category &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_CATEGORIES_ADMIN
        /// </summary>
        /// <param name="name">The category name</param>
        /// <param name="category">The updated BRE category information</param>
        void UpdateBRECategory(string name, BreCategoryResource category);

        TemplateResource UpdateBRECategoryTemplateData { get; }

        /// <summary>
        /// Update a BRE category template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated category template definition</param>
        void UpdateBRECategoryTemplate(string id, TemplateResource template);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineCategoriesApi : IBRERuleEngineCategoriesApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateBRECategoryTemplateResponseContext;
        private DateTime mCreateBRECategoryTemplateStartTime;
        private readonly KnetikResponseContext mDeleteBRECategoryTemplateResponseContext;
        private DateTime mDeleteBRECategoryTemplateStartTime;
        private readonly KnetikResponseContext mGetBRECategoriesResponseContext;
        private DateTime mGetBRECategoriesStartTime;
        private readonly KnetikResponseContext mGetBRECategoryResponseContext;
        private DateTime mGetBRECategoryStartTime;
        private readonly KnetikResponseContext mGetBRECategoryTemplateResponseContext;
        private DateTime mGetBRECategoryTemplateStartTime;
        private readonly KnetikResponseContext mGetBRECategoryTemplatesResponseContext;
        private DateTime mGetBRECategoryTemplatesStartTime;
        private readonly KnetikResponseContext mUpdateBRECategoryResponseContext;
        private DateTime mUpdateBRECategoryStartTime;
        private readonly KnetikResponseContext mUpdateBRECategoryTemplateResponseContext;
        private DateTime mUpdateBRECategoryTemplateStartTime;

        public TemplateResource CreateBRECategoryTemplateData { get; private set; }
        public delegate void CreateBRECategoryTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateBRECategoryTemplateCompleteDelegate CreateBRECategoryTemplateComplete;

        public delegate void DeleteBRECategoryTemplateCompleteDelegate(long responseCode);
        public DeleteBRECategoryTemplateCompleteDelegate DeleteBRECategoryTemplateComplete;

        public PageResourceBreCategoryResource GetBRECategoriesData { get; private set; }
        public delegate void GetBRECategoriesCompleteDelegate(long responseCode, PageResourceBreCategoryResource response);
        public GetBRECategoriesCompleteDelegate GetBRECategoriesComplete;

        public BreCategoryResource GetBRECategoryData { get; private set; }
        public delegate void GetBRECategoryCompleteDelegate(long responseCode, BreCategoryResource response);
        public GetBRECategoryCompleteDelegate GetBRECategoryComplete;

        public TemplateResource GetBRECategoryTemplateData { get; private set; }
        public delegate void GetBRECategoryTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetBRECategoryTemplateCompleteDelegate GetBRECategoryTemplateComplete;

        public PageResourceTemplateResource GetBRECategoryTemplatesData { get; private set; }
        public delegate void GetBRECategoryTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetBRECategoryTemplatesCompleteDelegate GetBRECategoryTemplatesComplete;

        public BreCategoryResource UpdateBRECategoryData { get; private set; }
        public delegate void UpdateBRECategoryCompleteDelegate(long responseCode, BreCategoryResource response);
        public UpdateBRECategoryCompleteDelegate UpdateBRECategoryComplete;

        public TemplateResource UpdateBRECategoryTemplateData { get; private set; }
        public delegate void UpdateBRECategoryTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateBRECategoryTemplateCompleteDelegate UpdateBRECategoryTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineCategoriesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineCategoriesApi()
        {
            mCreateBRECategoryTemplateResponseContext = new KnetikResponseContext();
            mCreateBRECategoryTemplateResponseContext.ResponseReceived += OnCreateBRECategoryTemplateResponse;
            mDeleteBRECategoryTemplateResponseContext = new KnetikResponseContext();
            mDeleteBRECategoryTemplateResponseContext.ResponseReceived += OnDeleteBRECategoryTemplateResponse;
            mGetBRECategoriesResponseContext = new KnetikResponseContext();
            mGetBRECategoriesResponseContext.ResponseReceived += OnGetBRECategoriesResponse;
            mGetBRECategoryResponseContext = new KnetikResponseContext();
            mGetBRECategoryResponseContext.ResponseReceived += OnGetBRECategoryResponse;
            mGetBRECategoryTemplateResponseContext = new KnetikResponseContext();
            mGetBRECategoryTemplateResponseContext.ResponseReceived += OnGetBRECategoryTemplateResponse;
            mGetBRECategoryTemplatesResponseContext = new KnetikResponseContext();
            mGetBRECategoryTemplatesResponseContext.ResponseReceived += OnGetBRECategoryTemplatesResponse;
            mUpdateBRECategoryResponseContext = new KnetikResponseContext();
            mUpdateBRECategoryResponseContext.ResponseReceived += OnUpdateBRECategoryResponse;
            mUpdateBRECategoryTemplateResponseContext = new KnetikResponseContext();
            mUpdateBRECategoryTemplateResponseContext.ResponseReceived += OnUpdateBRECategoryTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a BRE category template Templates define a type of BRE category and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="template">The category template to create</param>
        public void CreateBRECategoryTemplate(TemplateResource template)
        {
            
            mWebCallEvent.WebPath = "/bre/categories/templates";
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
            mCreateBRECategoryTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateBRECategoryTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateBRECategoryTemplateStartTime, "CreateBRECategoryTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateBRECategoryTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateBRECategoryTemplate: " + response.Error);
            }

            CreateBRECategoryTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateBRECategoryTemplateStartTime, "CreateBRECategoryTemplate", string.Format("Response received successfully:\n{0}", CreateBRECategoryTemplateData));

            if (CreateBRECategoryTemplateComplete != null)
            {
                CreateBRECategoryTemplateComplete(response.ResponseCode, CreateBRECategoryTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a BRE category template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteBRECategoryTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteBRECategoryTemplate");
            }
            
            mWebCallEvent.WebPath = "/bre/categories/templates/{id}";
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
            mDeleteBRECategoryTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteBRECategoryTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteBRECategoryTemplateStartTime, "DeleteBRECategoryTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteBRECategoryTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteBRECategoryTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteBRECategoryTemplateStartTime, "DeleteBRECategoryTemplate", "Response received successfully.");
            if (DeleteBRECategoryTemplateComplete != null)
            {
                DeleteBRECategoryTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List categories &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_CATEGORIES_USER
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetBRECategories(int? size, int? page)
        {
            
            mWebCallEvent.WebPath = "/bre/categories";
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

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetBRECategoriesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBRECategoriesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBRECategoriesStartTime, "GetBRECategories", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBRECategoriesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBRECategories: " + response.Error);
            }

            GetBRECategoriesData = (PageResourceBreCategoryResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceBreCategoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetBRECategoriesStartTime, "GetBRECategories", string.Format("Response received successfully:\n{0}", GetBRECategoriesData));

            if (GetBRECategoriesComplete != null)
            {
                GetBRECategoriesComplete(response.ResponseCode, GetBRECategoriesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single category &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_CATEGORIES_USER
        /// </summary>
        /// <param name="name">The category name</param>
        public void GetBRECategory(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetBRECategory");
            }
            
            mWebCallEvent.WebPath = "/bre/categories/{name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetBRECategoryStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBRECategoryResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBRECategoryStartTime, "GetBRECategory", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBRECategoryResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBRECategory: " + response.Error);
            }

            GetBRECategoryData = (BreCategoryResource) KnetikClient.Deserialize(response.Content, typeof(BreCategoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetBRECategoryStartTime, "GetBRECategory", string.Format("Response received successfully:\n{0}", GetBRECategoryData));

            if (GetBRECategoryComplete != null)
            {
                GetBRECategoryComplete(response.ResponseCode, GetBRECategoryData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single BRE category template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or BRE_RULE_ENGINE_CATEGORIES_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetBRECategoryTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBRECategoryTemplate");
            }
            
            mWebCallEvent.WebPath = "/bre/categories/templates/{id}";
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
            mGetBRECategoryTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBRECategoryTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBRECategoryTemplateStartTime, "GetBRECategoryTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBRECategoryTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBRECategoryTemplate: " + response.Error);
            }

            GetBRECategoryTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetBRECategoryTemplateStartTime, "GetBRECategoryTemplate", string.Format("Response received successfully:\n{0}", GetBRECategoryTemplateData));

            if (GetBRECategoryTemplateComplete != null)
            {
                GetBRECategoryTemplateComplete(response.ResponseCode, GetBRECategoryTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search BRE category templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or BRE_RULE_ENGINE_CATEGORIES_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetBRECategoryTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/bre/categories/templates";
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
            mGetBRECategoryTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBRECategoryTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBRECategoryTemplatesStartTime, "GetBRECategoryTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBRECategoryTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBRECategoryTemplates: " + response.Error);
            }

            GetBRECategoryTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetBRECategoryTemplatesStartTime, "GetBRECategoryTemplates", string.Format("Response received successfully:\n{0}", GetBRECategoryTemplatesData));

            if (GetBRECategoryTemplatesComplete != null)
            {
                GetBRECategoryTemplatesComplete(response.ResponseCode, GetBRECategoryTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a category &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_CATEGORIES_ADMIN
        /// </summary>
        /// <param name="name">The category name</param>
        /// <param name="category">The updated BRE category information</param>
        public void UpdateBRECategory(string name, BreCategoryResource category)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling UpdateBRECategory");
            }
            
            mWebCallEvent.WebPath = "/bre/categories/{name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(category); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateBRECategoryStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateBRECategoryResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateBRECategoryStartTime, "UpdateBRECategory", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateBRECategoryResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateBRECategory: " + response.Error);
            }

            UpdateBRECategoryData = (BreCategoryResource) KnetikClient.Deserialize(response.Content, typeof(BreCategoryResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateBRECategoryStartTime, "UpdateBRECategory", string.Format("Response received successfully:\n{0}", UpdateBRECategoryData));

            if (UpdateBRECategoryComplete != null)
            {
                UpdateBRECategoryComplete(response.ResponseCode, UpdateBRECategoryData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a BRE category template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated category template definition</param>
        public void UpdateBRECategoryTemplate(string id, TemplateResource template)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateBRECategoryTemplate");
            }
            
            mWebCallEvent.WebPath = "/bre/categories/templates/{id}";
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
            mUpdateBRECategoryTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateBRECategoryTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateBRECategoryTemplateStartTime, "UpdateBRECategoryTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateBRECategoryTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateBRECategoryTemplate: " + response.Error);
            }

            UpdateBRECategoryTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateBRECategoryTemplateStartTime, "UpdateBRECategoryTemplate", string.Format("Response received successfully:\n{0}", UpdateBRECategoryTemplateData));

            if (UpdateBRECategoryTemplateComplete != null)
            {
                UpdateBRECategoryTemplateComplete(response.ResponseCode, UpdateBRECategoryTemplateData);
            }
        }

    }
}
