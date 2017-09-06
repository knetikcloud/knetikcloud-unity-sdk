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
    public interface IStoreVendorsApi
    {
        /// <summary>
        /// Create a vendor 
        /// </summary>
        /// <param name="vendor">The vendor</param>
        /// <returns>VendorResource</returns>
        VendorResource CreateVendor (VendorResource vendor);
        /// <summary>
        /// Create a vendor template Vendor Templates define a type of vendor and the properties they have.
        /// </summary>
        /// <param name="vendorTemplateResource">The new vendor template</param>
        /// <returns>ItemTemplateResource</returns>
        ItemTemplateResource CreateVendorTemplate (ItemTemplateResource vendorTemplateResource);
        /// <summary>
        /// Delete a vendor 
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        /// <returns></returns>
        void DeleteVendor (int? id);
        /// <summary>
        /// Delete a vendor template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        /// <returns></returns>
        void DeleteVendorTemplate (string id, string cascade);
        /// <summary>
        /// Get a single vendor 
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        /// <returns>VendorResource</returns>
        VendorResource GetVendor (int? id);
        /// <summary>
        /// Get a single vendor template Vendor Templates define a type of vendor and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <returns>ItemTemplateResource</returns>
        ItemTemplateResource GetVendorTemplate (string id);
        /// <summary>
        /// List and search vendor templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceItemTemplateResource</returns>
        PageResourceItemTemplateResource GetVendorTemplates (int? size, int? page, string order);
        /// <summary>
        /// List and search vendors 
        /// </summary>
        /// <param name="filterName">Filters vendors by name starting with the text provided in the filter</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceVendorResource</returns>
        PageResourceVendorResource GetVendors (string filterName, int? size, int? page, string order);
        /// <summary>
        /// Update a vendor 
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        /// <param name="vendor">The vendor</param>
        /// <returns>VendorResource</returns>
        VendorResource UpdateVendor (int? id, VendorResource vendor);
        /// <summary>
        /// Update a vendor template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="vendorTemplateResource">The vendor template resource object</param>
        /// <returns>ItemTemplateResource</returns>
        ItemTemplateResource UpdateVendorTemplate (string id, ItemTemplateResource vendorTemplateResource);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StoreVendorsApi : IStoreVendorsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreVendorsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreVendorsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a vendor 
        /// </summary>
        /// <param name="vendor">The vendor</param> 
        /// <returns>VendorResource</returns>            
        public VendorResource CreateVendor(VendorResource vendor)
        {
            
            string urlPath = "/vendors";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(vendor); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateVendor: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateVendor: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (VendorResource) KnetikClient.Deserialize(response.Content, typeof(VendorResource), response.Headers);
        }
        /// <summary>
        /// Create a vendor template Vendor Templates define a type of vendor and the properties they have.
        /// </summary>
        /// <param name="vendorTemplateResource">The new vendor template</param> 
        /// <returns>ItemTemplateResource</returns>            
        public ItemTemplateResource CreateVendorTemplate(ItemTemplateResource vendorTemplateResource)
        {
            
            string urlPath = "/vendors/templates";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(vendorTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateVendorTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateVendorTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// Delete a vendor 
        /// </summary>
        /// <param name="id">The id of the vendor</param> 
        /// <returns></returns>            
        public void DeleteVendor(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteVendor");
            }
            
            
            string urlPath = "/vendors/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVendor: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVendor: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete a vendor template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param> 
        /// <returns></returns>            
        public void DeleteVendorTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteVendorTemplate");
            }
            
            
            string urlPath = "/vendors/templates/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVendorTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVendorTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get a single vendor 
        /// </summary>
        /// <param name="id">The id of the vendor</param> 
        /// <returns>VendorResource</returns>            
        public VendorResource GetVendor(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetVendor");
            }
            
            
            string urlPath = "/vendors/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVendor: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVendor: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (VendorResource) KnetikClient.Deserialize(response.Content, typeof(VendorResource), response.Headers);
        }
        /// <summary>
        /// Get a single vendor template Vendor Templates define a type of vendor and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <returns>ItemTemplateResource</returns>            
        public ItemTemplateResource GetVendorTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetVendorTemplate");
            }
            
            
            string urlPath = "/vendors/templates/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVendorTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVendorTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// List and search vendor templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceItemTemplateResource</returns>            
        public PageResourceItemTemplateResource GetVendorTemplates(int? size, int? page, string order)
        {
            
            string urlPath = "/vendors/templates";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVendorTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVendorTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
        }
        /// <summary>
        /// List and search vendors 
        /// </summary>
        /// <param name="filterName">Filters vendors by name starting with the text provided in the filter</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceVendorResource</returns>            
        public PageResourceVendorResource GetVendors(string filterName, int? size, int? page, string order)
        {
            
            string urlPath = "/vendors";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.ParameterToString(filterName));
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVendors: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVendors: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceVendorResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceVendorResource), response.Headers);
        }
        /// <summary>
        /// Update a vendor 
        /// </summary>
        /// <param name="id">The id of the vendor</param> 
        /// <param name="vendor">The vendor</param> 
        /// <returns>VendorResource</returns>            
        public VendorResource UpdateVendor(int? id, VendorResource vendor)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateVendor");
            }
            
            
            string urlPath = "/vendors/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(vendor); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateVendor: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateVendor: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (VendorResource) KnetikClient.Deserialize(response.Content, typeof(VendorResource), response.Headers);
        }
        /// <summary>
        /// Update a vendor template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="vendorTemplateResource">The vendor template resource object</param> 
        /// <returns>ItemTemplateResource</returns>            
        public ItemTemplateResource UpdateVendorTemplate(string id, ItemTemplateResource vendorTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateVendorTemplate");
            }
            
            
            string urlPath = "/vendors/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(vendorTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateVendorTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateVendorTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
        }
    }
}
