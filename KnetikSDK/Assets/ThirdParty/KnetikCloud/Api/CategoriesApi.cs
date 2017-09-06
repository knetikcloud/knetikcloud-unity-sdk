using System;
using System.Collections.Generic;
using RestSharp;
using com.knetikcloud.Client;
using com.knetikcloud.Model;
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
        /// <summary>
        /// Create a new category 
        /// </summary>
        /// <param name="category">The category to create</param>
        /// <returns>CategoryResource</returns>
        CategoryResource CreateCategory (CategoryResource category);
        /// <summary>
        /// Create a category template Templates define a type of category and the properties they have
        /// </summary>
        /// <param name="template">The template to create</param>
        /// <returns>TemplateResource</returns>
        TemplateResource CreateCategoryTemplate (TemplateResource template);
        /// <summary>
        /// Delete an existing category 
        /// </summary>
        /// <param name="id">The id of the category to be deleted</param>
        /// <returns></returns>
        void DeleteCategory (string id);
        /// <summary>
        /// Delete a category template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        /// <returns></returns>
        void DeleteCategoryTemplate (string id, string cascade);
        /// <summary>
        /// List and search categories with optional filters 
        /// </summary>
        /// <param name="filterSearch">Filter for categories whose names begin with provided string</param>
        /// <param name="filterActive">Filter for categories that are specifically active or inactive</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceCategoryResource</returns>
        PageResourceCategoryResource GetCategories (string filterSearch, bool? filterActive, int? size, int? page, string order);
        /// <summary>
        /// Get a single category 
        /// </summary>
        /// <param name="id">The id of the category to retrieve</param>
        /// <returns>CategoryResource</returns>
        CategoryResource GetCategory (string id);
        /// <summary>
        /// Get a single category template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <returns>TemplateResource</returns>
        TemplateResource GetCategoryTemplate (string id);
        /// <summary>
        /// List and search category templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceTemplateResource</returns>
        PageResourceTemplateResource GetCategoryTemplates (int? size, int? page, string order);
        /// <summary>
        /// List all trivia tags in the system 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourcestring</returns>
        PageResourcestring GetTags (int? size, int? page);
        /// <summary>
        /// Update an existing category 
        /// </summary>
        /// <param name="id">The id of the category</param>
        /// <param name="category">The category to update</param>
        /// <returns>CategoryResource</returns>
        CategoryResource UpdateCategory (string id, CategoryResource category);
        /// <summary>
        /// Update a category template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template information</param>
        /// <returns>TemplateResource</returns>
        TemplateResource UpdateCategoryTemplate (string id, TemplateResource template);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class CategoriesApi : ICategoriesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CategoriesApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a new category 
        /// </summary>
        /// <param name="category">The category to create</param> 
        /// <returns>CategoryResource</returns>            
        public CategoryResource CreateCategory(CategoryResource category)
        {
            
            string urlPath = "/categories";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(category); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateCategory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateCategory: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (CategoryResource) KnetikClient.Deserialize(response.Content, typeof(CategoryResource), response.Headers);
        }
        /// <summary>
        /// Create a category template Templates define a type of category and the properties they have
        /// </summary>
        /// <param name="template">The template to create</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource CreateCategoryTemplate(TemplateResource template)
        {
            
            string urlPath = "/categories/templates";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateCategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateCategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
        /// <summary>
        /// Delete an existing category 
        /// </summary>
        /// <param name="id">The id of the category to be deleted</param> 
        /// <returns></returns>            
        public void DeleteCategory(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteCategory");
            }
            
            
            string urlPath = "/categories/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteCategory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteCategory: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete a category template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="cascade">The value needed to delete used templates</param> 
        /// <returns></returns>            
        public void DeleteCategoryTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteCategoryTemplate");
            }
            
            
            string urlPath = "/categories/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.ParameterToString(cascade));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteCategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteCategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// List and search categories with optional filters 
        /// </summary>
        /// <param name="filterSearch">Filter for categories whose names begin with provided string</param> 
        /// <param name="filterActive">Filter for categories that are specifically active or inactive</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceCategoryResource</returns>            
        public PageResourceCategoryResource GetCategories(string filterSearch, bool? filterActive, int? size, int? page, string order)
        {
            
            string urlPath = "/categories";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.ParameterToString(filterSearch));
            }
            
            if (filterActive != null)
            {
                queryParams.Add("filter_active", KnetikClient.ParameterToString(filterActive));
            }
            
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
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCategories: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCategories: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceCategoryResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceCategoryResource), response.Headers);
        }
        /// <summary>
        /// Get a single category 
        /// </summary>
        /// <param name="id">The id of the category to retrieve</param> 
        /// <returns>CategoryResource</returns>            
        public CategoryResource GetCategory(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCategory");
            }
            
            
            string urlPath = "/categories/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCategory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCategory: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (CategoryResource) KnetikClient.Deserialize(response.Content, typeof(CategoryResource), response.Headers);
        }
        /// <summary>
        /// Get a single category template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource GetCategoryTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCategoryTemplate");
            }
            
            
            string urlPath = "/categories/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
        /// <summary>
        /// List and search category templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceTemplateResource</returns>            
        public PageResourceTemplateResource GetCategoryTemplates(int? size, int? page, string order)
        {
            
            string urlPath = "/categories/templates";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

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
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCategoryTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCategoryTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
        }
        /// <summary>
        /// List all trivia tags in the system 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourcestring</returns>            
        public PageResourcestring GetTags(int? size, int? page)
        {
            
            string urlPath = "/tags";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetTags: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetTags: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourcestring) KnetikClient.Deserialize(response.Content, typeof(PageResourcestring), response.Headers);
        }
        /// <summary>
        /// Update an existing category 
        /// </summary>
        /// <param name="id">The id of the category</param> 
        /// <param name="category">The category to update</param> 
        /// <returns>CategoryResource</returns>            
        public CategoryResource UpdateCategory(string id, CategoryResource category)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateCategory");
            }
            
            
            string urlPath = "/categories/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(category); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateCategory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateCategory: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (CategoryResource) KnetikClient.Deserialize(response.Content, typeof(CategoryResource), response.Headers);
        }
        /// <summary>
        /// Update a category template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="template">The updated template information</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource UpdateCategoryTemplate(string id, TemplateResource template)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateCategoryTemplate");
            }
            
            
            string urlPath = "/categories/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateCategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateCategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
    }
}
