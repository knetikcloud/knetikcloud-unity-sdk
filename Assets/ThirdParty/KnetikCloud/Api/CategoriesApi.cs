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
    public interface ICategoriesApi
    {
        CategoryResource CreateCategoryData { get; }

        /// <summary>
        /// Create a new category &lt;b&gt;Permissions Needed:&lt;/b&gt; CATEGORIES_ADMIN
        /// </summary>
        /// <param name="category">The category to create</param>
        void CreateCategory(CategoryResource category);

        TemplateResource CreateCategoryTemplateData { get; }

        /// <summary>
        /// Create a category template Templates define a type of category and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="template">The template to create</param>
        void CreateCategoryTemplate(TemplateResource template);

        

        /// <summary>
        /// Delete an existing category &lt;b&gt;Permissions Needed:&lt;/b&gt; CATEGORIES_ADMIN
        /// </summary>
        /// <param name="id">The id of the category to be deleted</param>
        void DeleteCategory(string id);

        

        /// <summary>
        /// Delete a category template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteCategoryTemplate(string id, string cascade);

        PageResourceCategoryResource GetCategoriesData { get; }

        /// <summary>
        /// List and search categories with optional filters &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterSearch">Filter for categories whose names begin with provided string</param>
        /// <param name="filterActive">Filter for categories that are specifically active or inactive</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCategories(string filterSearch, bool? filterActive, int? size, int? page, string order);

        CategoryResource GetCategoryData { get; }

        /// <summary>
        /// Get a single category &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id of the category to retrieve</param>
        void GetCategory(string id);

        TemplateResource GetCategoryTemplateData { get; }

        /// <summary>
        /// Get a single category template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or CATEGORIES_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetCategoryTemplate(string id);

        PageResourceTemplateResource GetCategoryTemplatesData { get; }

        /// <summary>
        /// List and search category templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or CATEGORIES_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCategoryTemplates(int? size, int? page, string order);

        PageResourcestring GetTagsData { get; }

        /// <summary>
        /// List all trivia tags in the system &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetTags(int? size, int? page);

        CategoryResource UpdateCategoryData { get; }

        /// <summary>
        /// Update an existing category &lt;b&gt;Permissions Needed:&lt;/b&gt; CATEGORIES_ADMIN
        /// </summary>
        /// <param name="id">The id of the category</param>
        /// <param name="category">The category to update</param>
        void UpdateCategory(string id, CategoryResource category);

        TemplateResource UpdateCategoryTemplateData { get; }

        /// <summary>
        /// Update a category template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template information</param>
        void UpdateCategoryTemplate(string id, TemplateResource template);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class CategoriesApi : ICategoriesApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateCategoryResponseContext;
        private DateTime mCreateCategoryStartTime;
        private readonly KnetikResponseContext mCreateCategoryTemplateResponseContext;
        private DateTime mCreateCategoryTemplateStartTime;
        private readonly KnetikResponseContext mDeleteCategoryResponseContext;
        private DateTime mDeleteCategoryStartTime;
        private readonly KnetikResponseContext mDeleteCategoryTemplateResponseContext;
        private DateTime mDeleteCategoryTemplateStartTime;
        private readonly KnetikResponseContext mGetCategoriesResponseContext;
        private DateTime mGetCategoriesStartTime;
        private readonly KnetikResponseContext mGetCategoryResponseContext;
        private DateTime mGetCategoryStartTime;
        private readonly KnetikResponseContext mGetCategoryTemplateResponseContext;
        private DateTime mGetCategoryTemplateStartTime;
        private readonly KnetikResponseContext mGetCategoryTemplatesResponseContext;
        private DateTime mGetCategoryTemplatesStartTime;
        private readonly KnetikResponseContext mGetTagsResponseContext;
        private DateTime mGetTagsStartTime;
        private readonly KnetikResponseContext mUpdateCategoryResponseContext;
        private DateTime mUpdateCategoryStartTime;
        private readonly KnetikResponseContext mUpdateCategoryTemplateResponseContext;
        private DateTime mUpdateCategoryTemplateStartTime;

        public CategoryResource CreateCategoryData { get; private set; }
        public delegate void CreateCategoryCompleteDelegate(long responseCode, CategoryResource response);
        public CreateCategoryCompleteDelegate CreateCategoryComplete;

        public TemplateResource CreateCategoryTemplateData { get; private set; }
        public delegate void CreateCategoryTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateCategoryTemplateCompleteDelegate CreateCategoryTemplateComplete;

        public delegate void DeleteCategoryCompleteDelegate(long responseCode);
        public DeleteCategoryCompleteDelegate DeleteCategoryComplete;

        public delegate void DeleteCategoryTemplateCompleteDelegate(long responseCode);
        public DeleteCategoryTemplateCompleteDelegate DeleteCategoryTemplateComplete;

        public PageResourceCategoryResource GetCategoriesData { get; private set; }
        public delegate void GetCategoriesCompleteDelegate(long responseCode, PageResourceCategoryResource response);
        public GetCategoriesCompleteDelegate GetCategoriesComplete;

        public CategoryResource GetCategoryData { get; private set; }
        public delegate void GetCategoryCompleteDelegate(long responseCode, CategoryResource response);
        public GetCategoryCompleteDelegate GetCategoryComplete;

        public TemplateResource GetCategoryTemplateData { get; private set; }
        public delegate void GetCategoryTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetCategoryTemplateCompleteDelegate GetCategoryTemplateComplete;

        public PageResourceTemplateResource GetCategoryTemplatesData { get; private set; }
        public delegate void GetCategoryTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetCategoryTemplatesCompleteDelegate GetCategoryTemplatesComplete;

        public PageResourcestring GetTagsData { get; private set; }
        public delegate void GetTagsCompleteDelegate(long responseCode, PageResourcestring response);
        public GetTagsCompleteDelegate GetTagsComplete;

        public CategoryResource UpdateCategoryData { get; private set; }
        public delegate void UpdateCategoryCompleteDelegate(long responseCode, CategoryResource response);
        public UpdateCategoryCompleteDelegate UpdateCategoryComplete;

        public TemplateResource UpdateCategoryTemplateData { get; private set; }
        public delegate void UpdateCategoryTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateCategoryTemplateCompleteDelegate UpdateCategoryTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CategoriesApi()
        {
            mCreateCategoryResponseContext = new KnetikResponseContext();
            mCreateCategoryResponseContext.ResponseReceived += OnCreateCategoryResponse;
            mCreateCategoryTemplateResponseContext = new KnetikResponseContext();
            mCreateCategoryTemplateResponseContext.ResponseReceived += OnCreateCategoryTemplateResponse;
            mDeleteCategoryResponseContext = new KnetikResponseContext();
            mDeleteCategoryResponseContext.ResponseReceived += OnDeleteCategoryResponse;
            mDeleteCategoryTemplateResponseContext = new KnetikResponseContext();
            mDeleteCategoryTemplateResponseContext.ResponseReceived += OnDeleteCategoryTemplateResponse;
            mGetCategoriesResponseContext = new KnetikResponseContext();
            mGetCategoriesResponseContext.ResponseReceived += OnGetCategoriesResponse;
            mGetCategoryResponseContext = new KnetikResponseContext();
            mGetCategoryResponseContext.ResponseReceived += OnGetCategoryResponse;
            mGetCategoryTemplateResponseContext = new KnetikResponseContext();
            mGetCategoryTemplateResponseContext.ResponseReceived += OnGetCategoryTemplateResponse;
            mGetCategoryTemplatesResponseContext = new KnetikResponseContext();
            mGetCategoryTemplatesResponseContext.ResponseReceived += OnGetCategoryTemplatesResponse;
            mGetTagsResponseContext = new KnetikResponseContext();
            mGetTagsResponseContext.ResponseReceived += OnGetTagsResponse;
            mUpdateCategoryResponseContext = new KnetikResponseContext();
            mUpdateCategoryResponseContext.ResponseReceived += OnUpdateCategoryResponse;
            mUpdateCategoryTemplateResponseContext = new KnetikResponseContext();
            mUpdateCategoryTemplateResponseContext.ResponseReceived += OnUpdateCategoryTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a new category &lt;b&gt;Permissions Needed:&lt;/b&gt; CATEGORIES_ADMIN
        /// </summary>
        /// <param name="category">The category to create</param>
        public void CreateCategory(CategoryResource category)
        {
            
            mWebCallEvent.WebPath = "/categories";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
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
            mCreateCategoryStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateCategoryResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateCategoryStartTime, "CreateCategory", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateCategoryResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateCategory: " + response.Error);
            }

            CreateCategoryData = (CategoryResource) KnetikClient.Deserialize(response.Content, typeof(CategoryResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCategoryStartTime, "CreateCategory", string.Format("Response received successfully:\n{0}", CreateCategoryData));

            if (CreateCategoryComplete != null)
            {
                CreateCategoryComplete(response.ResponseCode, CreateCategoryData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a category template Templates define a type of category and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="template">The template to create</param>
        public void CreateCategoryTemplate(TemplateResource template)
        {
            
            mWebCallEvent.WebPath = "/categories/templates";
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
            mCreateCategoryTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateCategoryTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateCategoryTemplateStartTime, "CreateCategoryTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateCategoryTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateCategoryTemplate: " + response.Error);
            }

            CreateCategoryTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCategoryTemplateStartTime, "CreateCategoryTemplate", string.Format("Response received successfully:\n{0}", CreateCategoryTemplateData));

            if (CreateCategoryTemplateComplete != null)
            {
                CreateCategoryTemplateComplete(response.ResponseCode, CreateCategoryTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an existing category &lt;b&gt;Permissions Needed:&lt;/b&gt; CATEGORIES_ADMIN
        /// </summary>
        /// <param name="id">The id of the category to be deleted</param>
        public void DeleteCategory(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteCategory");
            }
            
            mWebCallEvent.WebPath = "/categories/{id}";
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
            mDeleteCategoryStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteCategoryResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteCategoryStartTime, "DeleteCategory", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteCategoryResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteCategory: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteCategoryStartTime, "DeleteCategory", "Response received successfully.");
            if (DeleteCategoryComplete != null)
            {
                DeleteCategoryComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a category template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteCategoryTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteCategoryTemplate");
            }
            
            mWebCallEvent.WebPath = "/categories/templates/{id}";
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
            mDeleteCategoryTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteCategoryTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteCategoryTemplateStartTime, "DeleteCategoryTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteCategoryTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteCategoryTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteCategoryTemplateStartTime, "DeleteCategoryTemplate", "Response received successfully.");
            if (DeleteCategoryTemplateComplete != null)
            {
                DeleteCategoryTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search categories with optional filters &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterSearch">Filter for categories whose names begin with provided string</param>
        /// <param name="filterActive">Filter for categories that are specifically active or inactive</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCategories(string filterSearch, bool? filterActive, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/categories";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterSearch != null)
            {
                mWebCallEvent.QueryParams["filter_search"] = KnetikClient.ParameterToString(filterSearch);
            }

            if (filterActive != null)
            {
                mWebCallEvent.QueryParams["filter_active"] = KnetikClient.ParameterToString(filterActive);
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
            mGetCategoriesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCategoriesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCategoriesStartTime, "GetCategories", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCategoriesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCategories: " + response.Error);
            }

            GetCategoriesData = (PageResourceCategoryResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceCategoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetCategoriesStartTime, "GetCategories", string.Format("Response received successfully:\n{0}", GetCategoriesData));

            if (GetCategoriesComplete != null)
            {
                GetCategoriesComplete(response.ResponseCode, GetCategoriesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single category &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id of the category to retrieve</param>
        public void GetCategory(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCategory");
            }
            
            mWebCallEvent.WebPath = "/categories/{id}";
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
            mGetCategoryStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCategoryResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCategoryStartTime, "GetCategory", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCategoryResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCategory: " + response.Error);
            }

            GetCategoryData = (CategoryResource) KnetikClient.Deserialize(response.Content, typeof(CategoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetCategoryStartTime, "GetCategory", string.Format("Response received successfully:\n{0}", GetCategoryData));

            if (GetCategoryComplete != null)
            {
                GetCategoryComplete(response.ResponseCode, GetCategoryData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single category template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or CATEGORIES_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetCategoryTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCategoryTemplate");
            }
            
            mWebCallEvent.WebPath = "/categories/templates/{id}";
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
            mGetCategoryTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCategoryTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCategoryTemplateStartTime, "GetCategoryTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCategoryTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCategoryTemplate: " + response.Error);
            }

            GetCategoryTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetCategoryTemplateStartTime, "GetCategoryTemplate", string.Format("Response received successfully:\n{0}", GetCategoryTemplateData));

            if (GetCategoryTemplateComplete != null)
            {
                GetCategoryTemplateComplete(response.ResponseCode, GetCategoryTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search category templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or CATEGORIES_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCategoryTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/categories/templates";
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
            mGetCategoryTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCategoryTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCategoryTemplatesStartTime, "GetCategoryTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCategoryTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCategoryTemplates: " + response.Error);
            }

            GetCategoryTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetCategoryTemplatesStartTime, "GetCategoryTemplates", string.Format("Response received successfully:\n{0}", GetCategoryTemplatesData));

            if (GetCategoryTemplatesComplete != null)
            {
                GetCategoryTemplatesComplete(response.ResponseCode, GetCategoryTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List all trivia tags in the system &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetTags(int? size, int? page)
        {
            
            mWebCallEvent.WebPath = "/tags";
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
            mGetTagsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetTagsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetTagsStartTime, "GetTags", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetTagsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetTags: " + response.Error);
            }

            GetTagsData = (PageResourcestring) KnetikClient.Deserialize(response.Content, typeof(PageResourcestring), response.Headers);
            KnetikLogger.LogResponse(mGetTagsStartTime, "GetTags", string.Format("Response received successfully:\n{0}", GetTagsData));

            if (GetTagsComplete != null)
            {
                GetTagsComplete(response.ResponseCode, GetTagsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an existing category &lt;b&gt;Permissions Needed:&lt;/b&gt; CATEGORIES_ADMIN
        /// </summary>
        /// <param name="id">The id of the category</param>
        /// <param name="category">The category to update</param>
        public void UpdateCategory(string id, CategoryResource category)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateCategory");
            }
            
            mWebCallEvent.WebPath = "/categories/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

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
            mUpdateCategoryStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateCategoryResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateCategoryStartTime, "UpdateCategory", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateCategoryResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateCategory: " + response.Error);
            }

            UpdateCategoryData = (CategoryResource) KnetikClient.Deserialize(response.Content, typeof(CategoryResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateCategoryStartTime, "UpdateCategory", string.Format("Response received successfully:\n{0}", UpdateCategoryData));

            if (UpdateCategoryComplete != null)
            {
                UpdateCategoryComplete(response.ResponseCode, UpdateCategoryData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a category template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template information</param>
        public void UpdateCategoryTemplate(string id, TemplateResource template)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateCategoryTemplate");
            }
            
            mWebCallEvent.WebPath = "/categories/templates/{id}";
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
            mUpdateCategoryTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateCategoryTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateCategoryTemplateStartTime, "UpdateCategoryTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateCategoryTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateCategoryTemplate: " + response.Error);
            }

            UpdateCategoryTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateCategoryTemplateStartTime, "UpdateCategoryTemplate", string.Format("Response received successfully:\n{0}", UpdateCategoryTemplateData));

            if (UpdateCategoryTemplateComplete != null)
            {
                UpdateCategoryTemplateComplete(response.ResponseCode, UpdateCategoryTemplateData);
            }
        }

    }
}
