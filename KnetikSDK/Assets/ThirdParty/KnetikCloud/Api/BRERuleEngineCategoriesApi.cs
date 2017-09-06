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
    public interface IBRERuleEngineCategoriesApi
    {
        /// <summary>
        /// Create a BRE category template Templates define a type of BRE category and the properties they have
        /// </summary>
        /// <param name="template">The category template to create</param>
        /// <returns>TemplateResource</returns>
        TemplateResource CreateBRECategoryTemplate (TemplateResource template);
        /// <summary>
        /// Delete a BRE category template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        /// <returns></returns>
        void DeleteBRECategoryTemplate (string id, string cascade);
        /// <summary>
        /// List categories 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceBreCategoryResource</returns>
        PageResourceBreCategoryResource GetBRECategories (int? size, int? page);
        /// <summary>
        /// Get a single category 
        /// </summary>
        /// <param name="name">The category name</param>
        /// <returns>BreCategoryResource</returns>
        BreCategoryResource GetBRECategory (string name);
        /// <summary>
        /// Get a single BRE category template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <returns>TemplateResource</returns>
        TemplateResource GetBRECategoryTemplate (string id);
        /// <summary>
        /// List and search BRE category templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceTemplateResource</returns>
        PageResourceTemplateResource GetBRECategoryTemplates (int? size, int? page, string order);
        /// <summary>
        /// Update a category 
        /// </summary>
        /// <param name="name">The category name</param>
        /// <param name="category">The updated BRE category information</param>
        /// <returns>BreCategoryResource</returns>
        BreCategoryResource UpdateBRECategory (string name, BreCategoryResource category);
        /// <summary>
        /// Update a BRE category template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated category template definition</param>
        /// <returns>TemplateResource</returns>
        TemplateResource UpdateBRECategoryTemplate (string id, TemplateResource template);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineCategoriesApi : IBRERuleEngineCategoriesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineCategoriesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineCategoriesApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a BRE category template Templates define a type of BRE category and the properties they have
        /// </summary>
        /// <param name="template">The category template to create</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource CreateBRECategoryTemplate(TemplateResource template)
        {
            
            string urlPath = "/bre/categories/templates";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateBRECategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateBRECategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
        /// <summary>
        /// Delete a BRE category template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="cascade">The value needed to delete used templates</param> 
        /// <returns></returns>            
        public void DeleteBRECategoryTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteBRECategoryTemplate");
            }
            
            
            string urlPath = "/bre/categories/templates/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteBRECategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteBRECategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// List categories 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceBreCategoryResource</returns>            
        public PageResourceBreCategoryResource GetBRECategories(int? size, int? page)
        {
            
            string urlPath = "/bre/categories";
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
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBRECategories: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBRECategories: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceBreCategoryResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceBreCategoryResource), response.Headers);
        }
        /// <summary>
        /// Get a single category 
        /// </summary>
        /// <param name="name">The category name</param> 
        /// <returns>BreCategoryResource</returns>            
        public BreCategoryResource GetBRECategory(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetBRECategory");
            }
            
            
            string urlPath = "/bre/categories/{name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBRECategory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBRECategory: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (BreCategoryResource) KnetikClient.Deserialize(response.Content, typeof(BreCategoryResource), response.Headers);
        }
        /// <summary>
        /// Get a single BRE category template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource GetBRECategoryTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBRECategoryTemplate");
            }
            
            
            string urlPath = "/bre/categories/templates/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBRECategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBRECategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
        /// <summary>
        /// List and search BRE category templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceTemplateResource</returns>            
        public PageResourceTemplateResource GetBRECategoryTemplates(int? size, int? page, string order)
        {
            
            string urlPath = "/bre/categories/templates";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBRECategoryTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetBRECategoryTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
        }
        /// <summary>
        /// Update a category 
        /// </summary>
        /// <param name="name">The category name</param> 
        /// <param name="category">The updated BRE category information</param> 
        /// <returns>BreCategoryResource</returns>            
        public BreCategoryResource UpdateBRECategory(string name, BreCategoryResource category)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling UpdateBRECategory");
            }
            
            
            string urlPath = "/bre/categories/{name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateBRECategory: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateBRECategory: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (BreCategoryResource) KnetikClient.Deserialize(response.Content, typeof(BreCategoryResource), response.Headers);
        }
        /// <summary>
        /// Update a BRE category template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="template">The updated category template definition</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource UpdateBRECategoryTemplate(string id, TemplateResource template)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateBRECategoryTemplate");
            }
            
            
            string urlPath = "/bre/categories/templates/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateBRECategoryTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateBRECategoryTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
    }
}
