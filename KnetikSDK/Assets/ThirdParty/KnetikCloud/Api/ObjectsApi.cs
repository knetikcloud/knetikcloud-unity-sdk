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
    public interface IObjectsApi
    {
        /// <summary>
        /// Create an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is to be part of</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="objectItem">The object item object</param>
        /// <returns>ObjectResource</returns>
        ObjectResource CreateObjectItem (string templateId, bool? cascade, ObjectResource objectItem);
        /// <summary>
        /// Create an object template Object templates define a type of entitlement and the properties they have
        /// </summary>
        /// <param name="template">The entitlement template to be created</param>
        /// <returns>ItemTemplateResource</returns>
        ItemTemplateResource CreateObjectTemplate (ItemTemplateResource template);
        /// <summary>
        /// Delete an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param>
        /// <param name="objectId">The id of the object</param>
        /// <returns></returns>
        void DeleteObjectItem (string templateId, int? objectId);
        /// <summary>
        /// Delete an entitlement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        /// <returns></returns>
        void DeleteObjectTemplate (string id, string cascade);
        /// <summary>
        /// Get a single object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param>
        /// <param name="objectId">The id of the object</param>
        /// <returns>ObjectResource</returns>
        ObjectResource GetObjectItem (string templateId, int? objectId);
        /// <summary>
        /// List and search objects 
        /// </summary>
        /// <param name="templateId">The id of the template to get objects for</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceObjectResource</returns>
        PageResourceObjectResource GetObjectItems (string templateId, int? size, int? page, string order);
        /// <summary>
        /// Get a single entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <returns>ItemTemplateResource</returns>
        ItemTemplateResource GetObjectTemplate (string id);
        /// <summary>
        /// List and search entitlement templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceItemTemplateResource</returns>
        PageResourceItemTemplateResource GetObjectTemplates (int? size, int? page, string order);
        /// <summary>
        /// Update an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param>
        /// <param name="entitlementId">The id of the entitlement</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="objectItem">The object item object</param>
        /// <returns></returns>
        void UpdateObjectItem (string templateId, int? entitlementId, bool? cascade, EntitlementItem objectItem);
        /// <summary>
        /// Update an entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template</param>
        /// <returns>ItemTemplateResource</returns>
        ItemTemplateResource UpdateObjectTemplate (string id, ItemTemplateResource template);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ObjectsApi : IObjectsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ObjectsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is to be part of</param> 
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param> 
        /// <param name="objectItem">The object item object</param> 
        /// <returns>ObjectResource</returns>            
        public ObjectResource CreateObjectItem(string templateId, bool? cascade, ObjectResource objectItem)
        {
            // verify the required parameter 'templateId' is set
            if (templateId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'templateId' when calling CreateObjectItem");
            }
            
            
            string urlPath = "/objects/{template_id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "template_id" + "}", KnetikClient.ParameterToString(templateId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.ParameterToString(cascade));
            }
            
            postBody = KnetikClient.Serialize(objectItem); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateObjectItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateObjectItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ObjectResource) KnetikClient.Deserialize(response.Content, typeof(ObjectResource), response.Headers);
        }
        /// <summary>
        /// Create an object template Object templates define a type of entitlement and the properties they have
        /// </summary>
        /// <param name="template">The entitlement template to be created</param> 
        /// <returns>ItemTemplateResource</returns>            
        public ItemTemplateResource CreateObjectTemplate(ItemTemplateResource template)
        {
            
            string urlPath = "/objects/templates";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateObjectTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateObjectTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// Delete an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param> 
        /// <param name="objectId">The id of the object</param> 
        /// <returns></returns>            
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
            
            
            string urlPath = "/objects/{template_id}/{object_id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "template_id" + "}", KnetikClient.ParameterToString(templateId));
urlPath = urlPath.Replace("{" + "object_id" + "}", KnetikClient.ParameterToString(objectId));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteObjectItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteObjectItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete an entitlement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="cascade">The value needed to delete used templates</param> 
        /// <returns></returns>            
        public void DeleteObjectTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteObjectTemplate");
            }
            
            
            string urlPath = "/objects/templates/{id}";
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
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteObjectTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteObjectTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get a single object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param> 
        /// <param name="objectId">The id of the object</param> 
        /// <returns>ObjectResource</returns>            
        public ObjectResource GetObjectItem(string templateId, int? objectId)
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
            
            
            string urlPath = "/objects/{template_id}/{object_id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "template_id" + "}", KnetikClient.ParameterToString(templateId));
urlPath = urlPath.Replace("{" + "object_id" + "}", KnetikClient.ParameterToString(objectId));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetObjectItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetObjectItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ObjectResource) KnetikClient.Deserialize(response.Content, typeof(ObjectResource), response.Headers);
        }
        /// <summary>
        /// List and search objects 
        /// </summary>
        /// <param name="templateId">The id of the template to get objects for</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceObjectResource</returns>            
        public PageResourceObjectResource GetObjectItems(string templateId, int? size, int? page, string order)
        {
            // verify the required parameter 'templateId' is set
            if (templateId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'templateId' when calling GetObjectItems");
            }
            
            
            string urlPath = "/objects/{template_id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "template_id" + "}", KnetikClient.ParameterToString(templateId));
    
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
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetObjectItems: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetObjectItems: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceObjectResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceObjectResource), response.Headers);
        }
        /// <summary>
        /// Get a single entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <returns>ItemTemplateResource</returns>            
        public ItemTemplateResource GetObjectTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetObjectTemplate");
            }
            
            
            string urlPath = "/objects/templates/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetObjectTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetObjectTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// List and search entitlement templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceItemTemplateResource</returns>            
        public PageResourceItemTemplateResource GetObjectTemplates(int? size, int? page, string order)
        {
            
            string urlPath = "/objects/templates";
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
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetObjectTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetObjectTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// Update an object 
        /// </summary>
        /// <param name="templateId">The id of the template this object is part of</param> 
        /// <param name="entitlementId">The id of the entitlement</param> 
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param> 
        /// <param name="objectItem">The object item object</param> 
        /// <returns></returns>            
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
            
            
            string urlPath = "/objects/{template_id}/{object_id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "template_id" + "}", KnetikClient.ParameterToString(templateId));
urlPath = urlPath.Replace("{" + "entitlement_id" + "}", KnetikClient.ParameterToString(entitlementId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.ParameterToString(cascade));
            }
            
            postBody = KnetikClient.Serialize(objectItem); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateObjectItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateObjectItem: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Update an entitlement template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="template">The updated template</param> 
        /// <returns>ItemTemplateResource</returns>            
        public ItemTemplateResource UpdateObjectTemplate(string id, ItemTemplateResource template)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateObjectTemplate");
            }
            
            
            string urlPath = "/objects/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateObjectTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateObjectTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
        }
    }
}
