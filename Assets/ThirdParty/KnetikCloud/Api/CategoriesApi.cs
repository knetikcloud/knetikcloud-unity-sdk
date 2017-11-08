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
    public interface ICategoriesApi
    {
        CategoryResource CreateCategoryData { get; }

        TemplateResource CreateCategoryTemplateData { get; }

        PageResourceCategoryResource GetCategoriesData { get; }

        CategoryResource GetCategoryData { get; }

        TemplateResource GetCategoryTemplateData { get; }

        PageResourceTemplateResource GetCategoryTemplatesData { get; }

        PageResourcestring GetTagsData { get; }

        CategoryResource UpdateCategoryData { get; }

        TemplateResource UpdateCategoryTemplateData { get; }

        
        /// <summary>
        /// Create a new category 
        /// </summary>
        /// <param name="category">The category to create</param>
        void CreateCategory(CategoryResource category);

        /// <summary>
        /// Create a category template Templates define a type of category and the properties they have
        /// </summary>
        /// <param name="template">The template to create</param>
        void CreateCategoryTemplate(TemplateResource template);

        /// <summary>
        /// Delete an existing category 
        /// </summary>
        /// <param name="id">The id of the category to be deleted</param>
        void DeleteCategory(string id);

        /// <summary>
        /// Delete a category template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteCategoryTemplate(string id, string cascade);

        /// <summary>
        /// List and search categories with optional filters 
        /// </summary>
        /// <param name="filterSearch">Filter for categories whose names begin with provided string</param>
        /// <param name="filterActive">Filter for categories that are specifically active or inactive</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCategories(string filterSearch, bool? filterActive, int? size, int? page, string order);

        /// <summary>
        /// Get a single category 
        /// </summary>
        /// <param name="id">The id of the category to retrieve</param>
        void GetCategory(string id);

        /// <summary>
        /// Get a single category template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetCategoryTemplate(string id);

        /// <summary>
        /// List and search category templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCategoryTemplates(int? size, int? page, string order);

        /// <summary>
        /// List all trivia tags in the system 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetTags(int? size, int? page);

        /// <summary>
        /// Update an existing category 
        /// </summary>
        /// <param name="id">The id of the category</param>
        /// <param name="category">The category to update</param>
        void UpdateCategory(string id, CategoryResource category);

        /// <summary>
        /// Update a category template 
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
        private readonly KnetikCoroutine mCreateCategoryCoroutine;
        private DateTime mCreateCategoryStartTime;
        private string mCreateCategoryPath;
        private readonly KnetikCoroutine mCreateCategoryTemplateCoroutine;
        private DateTime mCreateCategoryTemplateStartTime;
        private string mCreateCategoryTemplatePath;
        private readonly KnetikCoroutine mDeleteCategoryCoroutine;
        private DateTime mDeleteCategoryStartTime;
        private string mDeleteCategoryPath;
        private readonly KnetikCoroutine mDeleteCategoryTemplateCoroutine;
        private DateTime mDeleteCategoryTemplateStartTime;
        private string mDeleteCategoryTemplatePath;
        private readonly KnetikCoroutine mGetCategoriesCoroutine;
        private DateTime mGetCategoriesStartTime;
        private string mGetCategoriesPath;
        private readonly KnetikCoroutine mGetCategoryCoroutine;
        private DateTime mGetCategoryStartTime;
        private string mGetCategoryPath;
        private readonly KnetikCoroutine mGetCategoryTemplateCoroutine;
        private DateTime mGetCategoryTemplateStartTime;
        private string mGetCategoryTemplatePath;
        private readonly KnetikCoroutine mGetCategoryTemplatesCoroutine;
        private DateTime mGetCategoryTemplatesStartTime;
        private string mGetCategoryTemplatesPath;
        private readonly KnetikCoroutine mGetTagsCoroutine;
        private DateTime mGetTagsStartTime;
        private string mGetTagsPath;
        private readonly KnetikCoroutine mUpdateCategoryCoroutine;
        private DateTime mUpdateCategoryStartTime;
        private string mUpdateCategoryPath;
        private readonly KnetikCoroutine mUpdateCategoryTemplateCoroutine;
        private DateTime mUpdateCategoryTemplateStartTime;
        private string mUpdateCategoryTemplatePath;

        public CategoryResource CreateCategoryData { get; private set; }
        public delegate void CreateCategoryCompleteDelegate(CategoryResource response);
        public CreateCategoryCompleteDelegate CreateCategoryComplete;

        public TemplateResource CreateCategoryTemplateData { get; private set; }
        public delegate void CreateCategoryTemplateCompleteDelegate(TemplateResource response);
        public CreateCategoryTemplateCompleteDelegate CreateCategoryTemplateComplete;

        public delegate void DeleteCategoryCompleteDelegate();
        public DeleteCategoryCompleteDelegate DeleteCategoryComplete;

        public delegate void DeleteCategoryTemplateCompleteDelegate();
        public DeleteCategoryTemplateCompleteDelegate DeleteCategoryTemplateComplete;

        public PageResourceCategoryResource GetCategoriesData { get; private set; }
        public delegate void GetCategoriesCompleteDelegate(PageResourceCategoryResource response);
        public GetCategoriesCompleteDelegate GetCategoriesComplete;

        public CategoryResource GetCategoryData { get; private set; }
        public delegate void GetCategoryCompleteDelegate(CategoryResource response);
        public GetCategoryCompleteDelegate GetCategoryComplete;

        public TemplateResource GetCategoryTemplateData { get; private set; }
        public delegate void GetCategoryTemplateCompleteDelegate(TemplateResource response);
        public GetCategoryTemplateCompleteDelegate GetCategoryTemplateComplete;

        public PageResourceTemplateResource GetCategoryTemplatesData { get; private set; }
        public delegate void GetCategoryTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetCategoryTemplatesCompleteDelegate GetCategoryTemplatesComplete;

        public PageResourcestring GetTagsData { get; private set; }
        public delegate void GetTagsCompleteDelegate(PageResourcestring response);
        public GetTagsCompleteDelegate GetTagsComplete;

        public CategoryResource UpdateCategoryData { get; private set; }
        public delegate void UpdateCategoryCompleteDelegate(CategoryResource response);
        public UpdateCategoryCompleteDelegate UpdateCategoryComplete;

        public TemplateResource UpdateCategoryTemplateData { get; private set; }
        public delegate void UpdateCategoryTemplateCompleteDelegate(TemplateResource response);
        public UpdateCategoryTemplateCompleteDelegate UpdateCategoryTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CategoriesApi()
        {
            mCreateCategoryCoroutine = new KnetikCoroutine();
            mCreateCategoryTemplateCoroutine = new KnetikCoroutine();
            mDeleteCategoryCoroutine = new KnetikCoroutine();
            mDeleteCategoryTemplateCoroutine = new KnetikCoroutine();
            mGetCategoriesCoroutine = new KnetikCoroutine();
            mGetCategoryCoroutine = new KnetikCoroutine();
            mGetCategoryTemplateCoroutine = new KnetikCoroutine();
            mGetCategoryTemplatesCoroutine = new KnetikCoroutine();
            mGetTagsCoroutine = new KnetikCoroutine();
            mUpdateCategoryCoroutine = new KnetikCoroutine();
            mUpdateCategoryTemplateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a new category 
        /// </summary>
        /// <param name="category">The category to create</param>
        public void CreateCategory(CategoryResource category)
        {
            
            mCreateCategoryPath = "/categories";
            if (!string.IsNullOrEmpty(mCreateCategoryPath))
            {
                mCreateCategoryPath = mCreateCategoryPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(category); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateCategoryStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateCategoryStartTime, mCreateCategoryPath, "Sending server request...");

            // make the HTTP request
            mCreateCategoryCoroutine.ResponseReceived += CreateCategoryCallback;
            mCreateCategoryCoroutine.Start(mCreateCategoryPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateCategoryCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCategory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCategory: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateCategoryData = (CategoryResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CategoryResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCategoryStartTime, mCreateCategoryPath, string.Format("Response received successfully:\n{0}", CreateCategoryData.ToString()));

            if (CreateCategoryComplete != null)
            {
                CreateCategoryComplete(CreateCategoryData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a category template Templates define a type of category and the properties they have
        /// </summary>
        /// <param name="template">The template to create</param>
        public void CreateCategoryTemplate(TemplateResource template)
        {
            
            mCreateCategoryTemplatePath = "/categories/templates";
            if (!string.IsNullOrEmpty(mCreateCategoryTemplatePath))
            {
                mCreateCategoryTemplatePath = mCreateCategoryTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateCategoryTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateCategoryTemplateStartTime, mCreateCategoryTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateCategoryTemplateCoroutine.ResponseReceived += CreateCategoryTemplateCallback;
            mCreateCategoryTemplateCoroutine.Start(mCreateCategoryTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateCategoryTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateCategoryTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCategoryTemplateStartTime, mCreateCategoryTemplatePath, string.Format("Response received successfully:\n{0}", CreateCategoryTemplateData.ToString()));

            if (CreateCategoryTemplateComplete != null)
            {
                CreateCategoryTemplateComplete(CreateCategoryTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an existing category 
        /// </summary>
        /// <param name="id">The id of the category to be deleted</param>
        public void DeleteCategory(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteCategory");
            }
            
            mDeleteCategoryPath = "/categories/{id}";
            if (!string.IsNullOrEmpty(mDeleteCategoryPath))
            {
                mDeleteCategoryPath = mDeleteCategoryPath.Replace("{format}", "json");
            }
            mDeleteCategoryPath = mDeleteCategoryPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteCategoryStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteCategoryStartTime, mDeleteCategoryPath, "Sending server request...");

            // make the HTTP request
            mDeleteCategoryCoroutine.ResponseReceived += DeleteCategoryCallback;
            mDeleteCategoryCoroutine.Start(mDeleteCategoryPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteCategoryCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCategory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCategory: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteCategoryStartTime, mDeleteCategoryPath, "Response received successfully.");
            if (DeleteCategoryComplete != null)
            {
                DeleteCategoryComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a category template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
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
            
            mDeleteCategoryTemplatePath = "/categories/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteCategoryTemplatePath))
            {
                mDeleteCategoryTemplatePath = mDeleteCategoryTemplatePath.Replace("{format}", "json");
            }
            mDeleteCategoryTemplatePath = mDeleteCategoryTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteCategoryTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteCategoryTemplateStartTime, mDeleteCategoryTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteCategoryTemplateCoroutine.ResponseReceived += DeleteCategoryTemplateCallback;
            mDeleteCategoryTemplateCoroutine.Start(mDeleteCategoryTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteCategoryTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteCategoryTemplateStartTime, mDeleteCategoryTemplatePath, "Response received successfully.");
            if (DeleteCategoryTemplateComplete != null)
            {
                DeleteCategoryTemplateComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search categories with optional filters 
        /// </summary>
        /// <param name="filterSearch">Filter for categories whose names begin with provided string</param>
        /// <param name="filterActive">Filter for categories that are specifically active or inactive</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCategories(string filterSearch, bool? filterActive, int? size, int? page, string order)
        {
            
            mGetCategoriesPath = "/categories";
            if (!string.IsNullOrEmpty(mGetCategoriesPath))
            {
                mGetCategoriesPath = mGetCategoriesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.DefaultClient.ParameterToString(filterSearch));
            }

            if (filterActive != null)
            {
                queryParams.Add("filter_active", KnetikClient.DefaultClient.ParameterToString(filterActive));
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
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetCategoriesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCategoriesStartTime, mGetCategoriesPath, "Sending server request...");

            // make the HTTP request
            mGetCategoriesCoroutine.ResponseReceived += GetCategoriesCallback;
            mGetCategoriesCoroutine.Start(mGetCategoriesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCategoriesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCategories: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCategories: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCategoriesData = (PageResourceCategoryResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceCategoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetCategoriesStartTime, mGetCategoriesPath, string.Format("Response received successfully:\n{0}", GetCategoriesData.ToString()));

            if (GetCategoriesComplete != null)
            {
                GetCategoriesComplete(GetCategoriesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single category 
        /// </summary>
        /// <param name="id">The id of the category to retrieve</param>
        public void GetCategory(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCategory");
            }
            
            mGetCategoryPath = "/categories/{id}";
            if (!string.IsNullOrEmpty(mGetCategoryPath))
            {
                mGetCategoryPath = mGetCategoryPath.Replace("{format}", "json");
            }
            mGetCategoryPath = mGetCategoryPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetCategoryStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCategoryStartTime, mGetCategoryPath, "Sending server request...");

            // make the HTTP request
            mGetCategoryCoroutine.ResponseReceived += GetCategoryCallback;
            mGetCategoryCoroutine.Start(mGetCategoryPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCategoryCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCategory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCategory: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCategoryData = (CategoryResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CategoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetCategoryStartTime, mGetCategoryPath, string.Format("Response received successfully:\n{0}", GetCategoryData.ToString()));

            if (GetCategoryComplete != null)
            {
                GetCategoryComplete(GetCategoryData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single category template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetCategoryTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCategoryTemplate");
            }
            
            mGetCategoryTemplatePath = "/categories/templates/{id}";
            if (!string.IsNullOrEmpty(mGetCategoryTemplatePath))
            {
                mGetCategoryTemplatePath = mGetCategoryTemplatePath.Replace("{format}", "json");
            }
            mGetCategoryTemplatePath = mGetCategoryTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetCategoryTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCategoryTemplateStartTime, mGetCategoryTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetCategoryTemplateCoroutine.ResponseReceived += GetCategoryTemplateCallback;
            mGetCategoryTemplateCoroutine.Start(mGetCategoryTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCategoryTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCategoryTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetCategoryTemplateStartTime, mGetCategoryTemplatePath, string.Format("Response received successfully:\n{0}", GetCategoryTemplateData.ToString()));

            if (GetCategoryTemplateComplete != null)
            {
                GetCategoryTemplateComplete(GetCategoryTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search category templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCategoryTemplates(int? size, int? page, string order)
        {
            
            mGetCategoryTemplatesPath = "/categories/templates";
            if (!string.IsNullOrEmpty(mGetCategoryTemplatesPath))
            {
                mGetCategoryTemplatesPath = mGetCategoryTemplatesPath.Replace("{format}", "json");
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
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetCategoryTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCategoryTemplatesStartTime, mGetCategoryTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetCategoryTemplatesCoroutine.ResponseReceived += GetCategoryTemplatesCallback;
            mGetCategoryTemplatesCoroutine.Start(mGetCategoryTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCategoryTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCategoryTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCategoryTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCategoryTemplatesData = (PageResourceTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetCategoryTemplatesStartTime, mGetCategoryTemplatesPath, string.Format("Response received successfully:\n{0}", GetCategoryTemplatesData.ToString()));

            if (GetCategoryTemplatesComplete != null)
            {
                GetCategoryTemplatesComplete(GetCategoryTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List all trivia tags in the system 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetTags(int? size, int? page)
        {
            
            mGetTagsPath = "/tags";
            if (!string.IsNullOrEmpty(mGetTagsPath))
            {
                mGetTagsPath = mGetTagsPath.Replace("{format}", "json");
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

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetTagsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetTagsStartTime, mGetTagsPath, "Sending server request...");

            // make the HTTP request
            mGetTagsCoroutine.ResponseReceived += GetTagsCallback;
            mGetTagsCoroutine.Start(mGetTagsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetTagsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetTags: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetTags: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetTagsData = (PageResourcestring) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourcestring), response.Headers);
            KnetikLogger.LogResponse(mGetTagsStartTime, mGetTagsPath, string.Format("Response received successfully:\n{0}", GetTagsData.ToString()));

            if (GetTagsComplete != null)
            {
                GetTagsComplete(GetTagsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an existing category 
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
            
            mUpdateCategoryPath = "/categories/{id}";
            if (!string.IsNullOrEmpty(mUpdateCategoryPath))
            {
                mUpdateCategoryPath = mUpdateCategoryPath.Replace("{format}", "json");
            }
            mUpdateCategoryPath = mUpdateCategoryPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(category); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateCategoryStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateCategoryStartTime, mUpdateCategoryPath, "Sending server request...");

            // make the HTTP request
            mUpdateCategoryCoroutine.ResponseReceived += UpdateCategoryCallback;
            mUpdateCategoryCoroutine.Start(mUpdateCategoryPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateCategoryCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCategory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCategory: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateCategoryData = (CategoryResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CategoryResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateCategoryStartTime, mUpdateCategoryPath, string.Format("Response received successfully:\n{0}", UpdateCategoryData.ToString()));

            if (UpdateCategoryComplete != null)
            {
                UpdateCategoryComplete(UpdateCategoryData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a category template 
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
            
            mUpdateCategoryTemplatePath = "/categories/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateCategoryTemplatePath))
            {
                mUpdateCategoryTemplatePath = mUpdateCategoryTemplatePath.Replace("{format}", "json");
            }
            mUpdateCategoryTemplatePath = mUpdateCategoryTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateCategoryTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateCategoryTemplateStartTime, mUpdateCategoryTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateCategoryTemplateCoroutine.ResponseReceived += UpdateCategoryTemplateCallback;
            mUpdateCategoryTemplateCoroutine.Start(mUpdateCategoryTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateCategoryTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateCategoryTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateCategoryTemplateStartTime, mUpdateCategoryTemplatePath, string.Format("Response received successfully:\n{0}", UpdateCategoryTemplateData.ToString()));

            if (UpdateCategoryTemplateComplete != null)
            {
                UpdateCategoryTemplateComplete(UpdateCategoryTemplateData);
            }
        }

    }
}
