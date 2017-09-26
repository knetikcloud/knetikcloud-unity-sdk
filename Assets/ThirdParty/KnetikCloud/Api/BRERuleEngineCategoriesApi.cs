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
    public interface IBRERuleEngineCategoriesApi
    {
        TemplateResource CreateBRECategoryTemplateData { get; }

        PageResourceBreCategoryResource GetBRECategoriesData { get; }

        BreCategoryResource GetBRECategoryData { get; }

        TemplateResource GetBRECategoryTemplateData { get; }

        PageResourceTemplateResource GetBRECategoryTemplatesData { get; }

        BreCategoryResource UpdateBRECategoryData { get; }

        TemplateResource UpdateBRECategoryTemplateData { get; }

        
        /// <summary>
        /// Create a BRE category template Templates define a type of BRE category and the properties they have
        /// </summary>
        /// <param name="template">The category template to create</param>
        void CreateBRECategoryTemplate(TemplateResource template);

        /// <summary>
        /// Delete a BRE category template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteBRECategoryTemplate(string id, string cascade);

        /// <summary>
        /// List categories 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetBRECategories(int? size, int? page);

        /// <summary>
        /// Get a single category 
        /// </summary>
        /// <param name="name">The category name</param>
        void GetBRECategory(string name);

        /// <summary>
        /// Get a single BRE category template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetBRECategoryTemplate(string id);

        /// <summary>
        /// List and search BRE category templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetBRECategoryTemplates(int? size, int? page, string order);

        /// <summary>
        /// Update a category 
        /// </summary>
        /// <param name="name">The category name</param>
        /// <param name="category">The updated BRE category information</param>
        void UpdateBRECategory(string name, BreCategoryResource category);

        /// <summary>
        /// Update a BRE category template 
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
        private readonly KnetikCoroutine mCreateBRECategoryTemplateCoroutine;
        private DateTime mCreateBRECategoryTemplateStartTime;
        private string mCreateBRECategoryTemplatePath;
        private readonly KnetikCoroutine mDeleteBRECategoryTemplateCoroutine;
        private DateTime mDeleteBRECategoryTemplateStartTime;
        private string mDeleteBRECategoryTemplatePath;
        private readonly KnetikCoroutine mGetBRECategoriesCoroutine;
        private DateTime mGetBRECategoriesStartTime;
        private string mGetBRECategoriesPath;
        private readonly KnetikCoroutine mGetBRECategoryCoroutine;
        private DateTime mGetBRECategoryStartTime;
        private string mGetBRECategoryPath;
        private readonly KnetikCoroutine mGetBRECategoryTemplateCoroutine;
        private DateTime mGetBRECategoryTemplateStartTime;
        private string mGetBRECategoryTemplatePath;
        private readonly KnetikCoroutine mGetBRECategoryTemplatesCoroutine;
        private DateTime mGetBRECategoryTemplatesStartTime;
        private string mGetBRECategoryTemplatesPath;
        private readonly KnetikCoroutine mUpdateBRECategoryCoroutine;
        private DateTime mUpdateBRECategoryStartTime;
        private string mUpdateBRECategoryPath;
        private readonly KnetikCoroutine mUpdateBRECategoryTemplateCoroutine;
        private DateTime mUpdateBRECategoryTemplateStartTime;
        private string mUpdateBRECategoryTemplatePath;

        public TemplateResource CreateBRECategoryTemplateData { get; private set; }
        public delegate void CreateBRECategoryTemplateCompleteDelegate(TemplateResource response);
        public CreateBRECategoryTemplateCompleteDelegate CreateBRECategoryTemplateComplete;

        public delegate void DeleteBRECategoryTemplateCompleteDelegate();
        public DeleteBRECategoryTemplateCompleteDelegate DeleteBRECategoryTemplateComplete;

        public PageResourceBreCategoryResource GetBRECategoriesData { get; private set; }
        public delegate void GetBRECategoriesCompleteDelegate(PageResourceBreCategoryResource response);
        public GetBRECategoriesCompleteDelegate GetBRECategoriesComplete;

        public BreCategoryResource GetBRECategoryData { get; private set; }
        public delegate void GetBRECategoryCompleteDelegate(BreCategoryResource response);
        public GetBRECategoryCompleteDelegate GetBRECategoryComplete;

        public TemplateResource GetBRECategoryTemplateData { get; private set; }
        public delegate void GetBRECategoryTemplateCompleteDelegate(TemplateResource response);
        public GetBRECategoryTemplateCompleteDelegate GetBRECategoryTemplateComplete;

        public PageResourceTemplateResource GetBRECategoryTemplatesData { get; private set; }
        public delegate void GetBRECategoryTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetBRECategoryTemplatesCompleteDelegate GetBRECategoryTemplatesComplete;

        public BreCategoryResource UpdateBRECategoryData { get; private set; }
        public delegate void UpdateBRECategoryCompleteDelegate(BreCategoryResource response);
        public UpdateBRECategoryCompleteDelegate UpdateBRECategoryComplete;

        public TemplateResource UpdateBRECategoryTemplateData { get; private set; }
        public delegate void UpdateBRECategoryTemplateCompleteDelegate(TemplateResource response);
        public UpdateBRECategoryTemplateCompleteDelegate UpdateBRECategoryTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineCategoriesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineCategoriesApi()
        {
            mCreateBRECategoryTemplateCoroutine = new KnetikCoroutine();
            mDeleteBRECategoryTemplateCoroutine = new KnetikCoroutine();
            mGetBRECategoriesCoroutine = new KnetikCoroutine();
            mGetBRECategoryCoroutine = new KnetikCoroutine();
            mGetBRECategoryTemplateCoroutine = new KnetikCoroutine();
            mGetBRECategoryTemplatesCoroutine = new KnetikCoroutine();
            mUpdateBRECategoryCoroutine = new KnetikCoroutine();
            mUpdateBRECategoryTemplateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a BRE category template Templates define a type of BRE category and the properties they have
        /// </summary>
        /// <param name="template">The category template to create</param>
        public void CreateBRECategoryTemplate(TemplateResource template)
        {
            
            mCreateBRECategoryTemplatePath = "/bre/categories/templates";
            if (!string.IsNullOrEmpty(mCreateBRECategoryTemplatePath))
            {
                mCreateBRECategoryTemplatePath = mCreateBRECategoryTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateBRECategoryTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateBRECategoryTemplateStartTime, mCreateBRECategoryTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateBRECategoryTemplateCoroutine.ResponseReceived += CreateBRECategoryTemplateCallback;
            mCreateBRECategoryTemplateCoroutine.Start(mCreateBRECategoryTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateBRECategoryTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateBRECategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateBRECategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateBRECategoryTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateBRECategoryTemplateStartTime, mCreateBRECategoryTemplatePath, string.Format("Response received successfully:\n{0}", CreateBRECategoryTemplateData.ToString()));

            if (CreateBRECategoryTemplateComplete != null)
            {
                CreateBRECategoryTemplateComplete(CreateBRECategoryTemplateData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Delete a BRE category template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
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
            
            mDeleteBRECategoryTemplatePath = "/bre/categories/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteBRECategoryTemplatePath))
            {
                mDeleteBRECategoryTemplatePath = mDeleteBRECategoryTemplatePath.Replace("{format}", "json");
            }
            mDeleteBRECategoryTemplatePath = mDeleteBRECategoryTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mDeleteBRECategoryTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteBRECategoryTemplateStartTime, mDeleteBRECategoryTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteBRECategoryTemplateCoroutine.ResponseReceived += DeleteBRECategoryTemplateCallback;
            mDeleteBRECategoryTemplateCoroutine.Start(mDeleteBRECategoryTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteBRECategoryTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteBRECategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteBRECategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteBRECategoryTemplateStartTime, mDeleteBRECategoryTemplatePath, "Response received successfully.");
            if (DeleteBRECategoryTemplateComplete != null)
            {
                DeleteBRECategoryTemplateComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// List categories 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetBRECategories(int? size, int? page)
        {
            
            mGetBRECategoriesPath = "/bre/categories";
            if (!string.IsNullOrEmpty(mGetBRECategoriesPath))
            {
                mGetBRECategoriesPath = mGetBRECategoriesPath.Replace("{format}", "json");
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBRECategoriesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBRECategoriesStartTime, mGetBRECategoriesPath, "Sending server request...");

            // make the HTTP request
            mGetBRECategoriesCoroutine.ResponseReceived += GetBRECategoriesCallback;
            mGetBRECategoriesCoroutine.Start(mGetBRECategoriesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBRECategoriesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRECategories: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRECategories: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBRECategoriesData = (PageResourceBreCategoryResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceBreCategoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetBRECategoriesStartTime, mGetBRECategoriesPath, string.Format("Response received successfully:\n{0}", GetBRECategoriesData.ToString()));

            if (GetBRECategoriesComplete != null)
            {
                GetBRECategoriesComplete(GetBRECategoriesData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Get a single category 
        /// </summary>
        /// <param name="name">The category name</param>
        public void GetBRECategory(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetBRECategory");
            }
            
            mGetBRECategoryPath = "/bre/categories/{name}";
            if (!string.IsNullOrEmpty(mGetBRECategoryPath))
            {
                mGetBRECategoryPath = mGetBRECategoryPath.Replace("{format}", "json");
            }
            mGetBRECategoryPath = mGetBRECategoryPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBRECategoryStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBRECategoryStartTime, mGetBRECategoryPath, "Sending server request...");

            // make the HTTP request
            mGetBRECategoryCoroutine.ResponseReceived += GetBRECategoryCallback;
            mGetBRECategoryCoroutine.Start(mGetBRECategoryPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBRECategoryCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRECategory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRECategory: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBRECategoryData = (BreCategoryResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(BreCategoryResource), response.Headers);
            KnetikLogger.LogResponse(mGetBRECategoryStartTime, mGetBRECategoryPath, string.Format("Response received successfully:\n{0}", GetBRECategoryData.ToString()));

            if (GetBRECategoryComplete != null)
            {
                GetBRECategoryComplete(GetBRECategoryData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Get a single BRE category template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetBRECategoryTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBRECategoryTemplate");
            }
            
            mGetBRECategoryTemplatePath = "/bre/categories/templates/{id}";
            if (!string.IsNullOrEmpty(mGetBRECategoryTemplatePath))
            {
                mGetBRECategoryTemplatePath = mGetBRECategoryTemplatePath.Replace("{format}", "json");
            }
            mGetBRECategoryTemplatePath = mGetBRECategoryTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBRECategoryTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBRECategoryTemplateStartTime, mGetBRECategoryTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetBRECategoryTemplateCoroutine.ResponseReceived += GetBRECategoryTemplateCallback;
            mGetBRECategoryTemplateCoroutine.Start(mGetBRECategoryTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBRECategoryTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRECategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRECategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBRECategoryTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetBRECategoryTemplateStartTime, mGetBRECategoryTemplatePath, string.Format("Response received successfully:\n{0}", GetBRECategoryTemplateData.ToString()));

            if (GetBRECategoryTemplateComplete != null)
            {
                GetBRECategoryTemplateComplete(GetBRECategoryTemplateData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// List and search BRE category templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetBRECategoryTemplates(int? size, int? page, string order)
        {
            
            mGetBRECategoryTemplatesPath = "/bre/categories/templates";
            if (!string.IsNullOrEmpty(mGetBRECategoryTemplatesPath))
            {
                mGetBRECategoryTemplatesPath = mGetBRECategoryTemplatesPath.Replace("{format}", "json");
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

            mGetBRECategoryTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBRECategoryTemplatesStartTime, mGetBRECategoryTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetBRECategoryTemplatesCoroutine.ResponseReceived += GetBRECategoryTemplatesCallback;
            mGetBRECategoryTemplatesCoroutine.Start(mGetBRECategoryTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBRECategoryTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRECategoryTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRECategoryTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBRECategoryTemplatesData = (PageResourceTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetBRECategoryTemplatesStartTime, mGetBRECategoryTemplatesPath, string.Format("Response received successfully:\n{0}", GetBRECategoryTemplatesData.ToString()));

            if (GetBRECategoryTemplatesComplete != null)
            {
                GetBRECategoryTemplatesComplete(GetBRECategoryTemplatesData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Update a category 
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
            
            mUpdateBRECategoryPath = "/bre/categories/{name}";
            if (!string.IsNullOrEmpty(mUpdateBRECategoryPath))
            {
                mUpdateBRECategoryPath = mUpdateBRECategoryPath.Replace("{format}", "json");
            }
            mUpdateBRECategoryPath = mUpdateBRECategoryPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(category); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateBRECategoryStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateBRECategoryStartTime, mUpdateBRECategoryPath, "Sending server request...");

            // make the HTTP request
            mUpdateBRECategoryCoroutine.ResponseReceived += UpdateBRECategoryCallback;
            mUpdateBRECategoryCoroutine.Start(mUpdateBRECategoryPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateBRECategoryCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBRECategory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBRECategory: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateBRECategoryData = (BreCategoryResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(BreCategoryResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateBRECategoryStartTime, mUpdateBRECategoryPath, string.Format("Response received successfully:\n{0}", UpdateBRECategoryData.ToString()));

            if (UpdateBRECategoryComplete != null)
            {
                UpdateBRECategoryComplete(UpdateBRECategoryData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Update a BRE category template 
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
            
            mUpdateBRECategoryTemplatePath = "/bre/categories/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateBRECategoryTemplatePath))
            {
                mUpdateBRECategoryTemplatePath = mUpdateBRECategoryTemplatePath.Replace("{format}", "json");
            }
            mUpdateBRECategoryTemplatePath = mUpdateBRECategoryTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateBRECategoryTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateBRECategoryTemplateStartTime, mUpdateBRECategoryTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateBRECategoryTemplateCoroutine.ResponseReceived += UpdateBRECategoryTemplateCallback;
            mUpdateBRECategoryTemplateCoroutine.Start(mUpdateBRECategoryTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateBRECategoryTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBRECategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBRECategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateBRECategoryTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateBRECategoryTemplateStartTime, mUpdateBRECategoryTemplatePath, string.Format("Response received successfully:\n{0}", UpdateBRECategoryTemplateData.ToString()));

            if (UpdateBRECategoryTemplateComplete != null)
            {
                UpdateBRECategoryTemplateComplete(UpdateBRECategoryTemplateData);
            }
        }
    }
}
