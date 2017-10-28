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
    public interface IStoreVendorsApi
    {
        VendorResource CreateVendorData { get; }

        ItemTemplateResource CreateVendorTemplateData { get; }

        VendorResource GetVendorData { get; }

        ItemTemplateResource GetVendorTemplateData { get; }

        PageResourceItemTemplateResource GetVendorTemplatesData { get; }

        PageResourceVendorResource GetVendorsData { get; }

        VendorResource UpdateVendorData { get; }

        ItemTemplateResource UpdateVendorTemplateData { get; }

        
        /// <summary>
        /// Create a vendor 
        /// </summary>
        /// <param name="vendor">The vendor</param>
        void CreateVendor(VendorResource vendor);

        /// <summary>
        /// Create a vendor template Vendor Templates define a type of vendor and the properties they have.
        /// </summary>
        /// <param name="vendorTemplateResource">The new vendor template</param>
        void CreateVendorTemplate(ItemTemplateResource vendorTemplateResource);

        /// <summary>
        /// Delete a vendor 
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        void DeleteVendor(int? id);

        /// <summary>
        /// Delete a vendor template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        void DeleteVendorTemplate(string id, string cascade);

        /// <summary>
        /// Get a single vendor 
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        void GetVendor(int? id);

        /// <summary>
        /// Get a single vendor template Vendor Templates define a type of vendor and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetVendorTemplate(string id);

        /// <summary>
        /// List and search vendor templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetVendorTemplates(int? size, int? page, string order);

        /// <summary>
        /// List and search vendors 
        /// </summary>
        /// <param name="filterName">Filters vendors by name starting with the text provided in the filter</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetVendors(string filterName, int? size, int? page, string order);

        /// <summary>
        /// Update a vendor 
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        /// <param name="vendor">The vendor</param>
        void UpdateVendor(int? id, VendorResource vendor);

        /// <summary>
        /// Update a vendor template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="vendorTemplateResource">The vendor template resource object</param>
        void UpdateVendorTemplate(string id, ItemTemplateResource vendorTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StoreVendorsApi : IStoreVendorsApi
    {
        private readonly KnetikCoroutine mCreateVendorCoroutine;
        private DateTime mCreateVendorStartTime;
        private string mCreateVendorPath;
        private readonly KnetikCoroutine mCreateVendorTemplateCoroutine;
        private DateTime mCreateVendorTemplateStartTime;
        private string mCreateVendorTemplatePath;
        private readonly KnetikCoroutine mDeleteVendorCoroutine;
        private DateTime mDeleteVendorStartTime;
        private string mDeleteVendorPath;
        private readonly KnetikCoroutine mDeleteVendorTemplateCoroutine;
        private DateTime mDeleteVendorTemplateStartTime;
        private string mDeleteVendorTemplatePath;
        private readonly KnetikCoroutine mGetVendorCoroutine;
        private DateTime mGetVendorStartTime;
        private string mGetVendorPath;
        private readonly KnetikCoroutine mGetVendorTemplateCoroutine;
        private DateTime mGetVendorTemplateStartTime;
        private string mGetVendorTemplatePath;
        private readonly KnetikCoroutine mGetVendorTemplatesCoroutine;
        private DateTime mGetVendorTemplatesStartTime;
        private string mGetVendorTemplatesPath;
        private readonly KnetikCoroutine mGetVendorsCoroutine;
        private DateTime mGetVendorsStartTime;
        private string mGetVendorsPath;
        private readonly KnetikCoroutine mUpdateVendorCoroutine;
        private DateTime mUpdateVendorStartTime;
        private string mUpdateVendorPath;
        private readonly KnetikCoroutine mUpdateVendorTemplateCoroutine;
        private DateTime mUpdateVendorTemplateStartTime;
        private string mUpdateVendorTemplatePath;

        public VendorResource CreateVendorData { get; private set; }
        public delegate void CreateVendorCompleteDelegate(VendorResource response);
        public CreateVendorCompleteDelegate CreateVendorComplete;

        public ItemTemplateResource CreateVendorTemplateData { get; private set; }
        public delegate void CreateVendorTemplateCompleteDelegate(ItemTemplateResource response);
        public CreateVendorTemplateCompleteDelegate CreateVendorTemplateComplete;

        public delegate void DeleteVendorCompleteDelegate();
        public DeleteVendorCompleteDelegate DeleteVendorComplete;

        public delegate void DeleteVendorTemplateCompleteDelegate();
        public DeleteVendorTemplateCompleteDelegate DeleteVendorTemplateComplete;

        public VendorResource GetVendorData { get; private set; }
        public delegate void GetVendorCompleteDelegate(VendorResource response);
        public GetVendorCompleteDelegate GetVendorComplete;

        public ItemTemplateResource GetVendorTemplateData { get; private set; }
        public delegate void GetVendorTemplateCompleteDelegate(ItemTemplateResource response);
        public GetVendorTemplateCompleteDelegate GetVendorTemplateComplete;

        public PageResourceItemTemplateResource GetVendorTemplatesData { get; private set; }
        public delegate void GetVendorTemplatesCompleteDelegate(PageResourceItemTemplateResource response);
        public GetVendorTemplatesCompleteDelegate GetVendorTemplatesComplete;

        public PageResourceVendorResource GetVendorsData { get; private set; }
        public delegate void GetVendorsCompleteDelegate(PageResourceVendorResource response);
        public GetVendorsCompleteDelegate GetVendorsComplete;

        public VendorResource UpdateVendorData { get; private set; }
        public delegate void UpdateVendorCompleteDelegate(VendorResource response);
        public UpdateVendorCompleteDelegate UpdateVendorComplete;

        public ItemTemplateResource UpdateVendorTemplateData { get; private set; }
        public delegate void UpdateVendorTemplateCompleteDelegate(ItemTemplateResource response);
        public UpdateVendorTemplateCompleteDelegate UpdateVendorTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreVendorsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreVendorsApi()
        {
            mCreateVendorCoroutine = new KnetikCoroutine();
            mCreateVendorTemplateCoroutine = new KnetikCoroutine();
            mDeleteVendorCoroutine = new KnetikCoroutine();
            mDeleteVendorTemplateCoroutine = new KnetikCoroutine();
            mGetVendorCoroutine = new KnetikCoroutine();
            mGetVendorTemplateCoroutine = new KnetikCoroutine();
            mGetVendorTemplatesCoroutine = new KnetikCoroutine();
            mGetVendorsCoroutine = new KnetikCoroutine();
            mUpdateVendorCoroutine = new KnetikCoroutine();
            mUpdateVendorTemplateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a vendor 
        /// </summary>
        /// <param name="vendor">The vendor</param>
        public void CreateVendor(VendorResource vendor)
        {
            
            mCreateVendorPath = "/vendors";
            if (!string.IsNullOrEmpty(mCreateVendorPath))
            {
                mCreateVendorPath = mCreateVendorPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(vendor); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateVendorStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateVendorStartTime, mCreateVendorPath, "Sending server request...");

            // make the HTTP request
            mCreateVendorCoroutine.ResponseReceived += CreateVendorCallback;
            mCreateVendorCoroutine.Start(mCreateVendorPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateVendorCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateVendor: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateVendor: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateVendorData = (VendorResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(VendorResource), response.Headers);
            KnetikLogger.LogResponse(mCreateVendorStartTime, mCreateVendorPath, string.Format("Response received successfully:\n{0}", CreateVendorData.ToString()));

            if (CreateVendorComplete != null)
            {
                CreateVendorComplete(CreateVendorData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a vendor template Vendor Templates define a type of vendor and the properties they have.
        /// </summary>
        /// <param name="vendorTemplateResource">The new vendor template</param>
        public void CreateVendorTemplate(ItemTemplateResource vendorTemplateResource)
        {
            
            mCreateVendorTemplatePath = "/vendors/templates";
            if (!string.IsNullOrEmpty(mCreateVendorTemplatePath))
            {
                mCreateVendorTemplatePath = mCreateVendorTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(vendorTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateVendorTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateVendorTemplateStartTime, mCreateVendorTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateVendorTemplateCoroutine.ResponseReceived += CreateVendorTemplateCallback;
            mCreateVendorTemplateCoroutine.Start(mCreateVendorTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateVendorTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateVendorTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateVendorTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateVendorTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateVendorTemplateStartTime, mCreateVendorTemplatePath, string.Format("Response received successfully:\n{0}", CreateVendorTemplateData.ToString()));

            if (CreateVendorTemplateComplete != null)
            {
                CreateVendorTemplateComplete(CreateVendorTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a vendor 
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        public void DeleteVendor(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteVendor");
            }
            
            mDeleteVendorPath = "/vendors/{id}";
            if (!string.IsNullOrEmpty(mDeleteVendorPath))
            {
                mDeleteVendorPath = mDeleteVendorPath.Replace("{format}", "json");
            }
            mDeleteVendorPath = mDeleteVendorPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteVendorStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteVendorStartTime, mDeleteVendorPath, "Sending server request...");

            // make the HTTP request
            mDeleteVendorCoroutine.ResponseReceived += DeleteVendorCallback;
            mDeleteVendorCoroutine.Start(mDeleteVendorPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteVendorCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVendor: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVendor: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteVendorStartTime, mDeleteVendorPath, "Response received successfully.");
            if (DeleteVendorComplete != null)
            {
                DeleteVendorComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a vendor template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        public void DeleteVendorTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteVendorTemplate");
            }
            
            mDeleteVendorTemplatePath = "/vendors/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteVendorTemplatePath))
            {
                mDeleteVendorTemplatePath = mDeleteVendorTemplatePath.Replace("{format}", "json");
            }
            mDeleteVendorTemplatePath = mDeleteVendorTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mDeleteVendorTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteVendorTemplateStartTime, mDeleteVendorTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteVendorTemplateCoroutine.ResponseReceived += DeleteVendorTemplateCallback;
            mDeleteVendorTemplateCoroutine.Start(mDeleteVendorTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteVendorTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVendorTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVendorTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteVendorTemplateStartTime, mDeleteVendorTemplatePath, "Response received successfully.");
            if (DeleteVendorTemplateComplete != null)
            {
                DeleteVendorTemplateComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single vendor 
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        public void GetVendor(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetVendor");
            }
            
            mGetVendorPath = "/vendors/{id}";
            if (!string.IsNullOrEmpty(mGetVendorPath))
            {
                mGetVendorPath = mGetVendorPath.Replace("{format}", "json");
            }
            mGetVendorPath = mGetVendorPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mGetVendorStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetVendorStartTime, mGetVendorPath, "Sending server request...");

            // make the HTTP request
            mGetVendorCoroutine.ResponseReceived += GetVendorCallback;
            mGetVendorCoroutine.Start(mGetVendorPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetVendorCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVendor: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVendor: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetVendorData = (VendorResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(VendorResource), response.Headers);
            KnetikLogger.LogResponse(mGetVendorStartTime, mGetVendorPath, string.Format("Response received successfully:\n{0}", GetVendorData.ToString()));

            if (GetVendorComplete != null)
            {
                GetVendorComplete(GetVendorData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single vendor template Vendor Templates define a type of vendor and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetVendorTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetVendorTemplate");
            }
            
            mGetVendorTemplatePath = "/vendors/templates/{id}";
            if (!string.IsNullOrEmpty(mGetVendorTemplatePath))
            {
                mGetVendorTemplatePath = mGetVendorTemplatePath.Replace("{format}", "json");
            }
            mGetVendorTemplatePath = mGetVendorTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetVendorTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetVendorTemplateStartTime, mGetVendorTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetVendorTemplateCoroutine.ResponseReceived += GetVendorTemplateCallback;
            mGetVendorTemplateCoroutine.Start(mGetVendorTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetVendorTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVendorTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVendorTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetVendorTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetVendorTemplateStartTime, mGetVendorTemplatePath, string.Format("Response received successfully:\n{0}", GetVendorTemplateData.ToString()));

            if (GetVendorTemplateComplete != null)
            {
                GetVendorTemplateComplete(GetVendorTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search vendor templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetVendorTemplates(int? size, int? page, string order)
        {
            
            mGetVendorTemplatesPath = "/vendors/templates";
            if (!string.IsNullOrEmpty(mGetVendorTemplatesPath))
            {
                mGetVendorTemplatesPath = mGetVendorTemplatesPath.Replace("{format}", "json");
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

            mGetVendorTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetVendorTemplatesStartTime, mGetVendorTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetVendorTemplatesCoroutine.ResponseReceived += GetVendorTemplatesCallback;
            mGetVendorTemplatesCoroutine.Start(mGetVendorTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetVendorTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVendorTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVendorTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetVendorTemplatesData = (PageResourceItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetVendorTemplatesStartTime, mGetVendorTemplatesPath, string.Format("Response received successfully:\n{0}", GetVendorTemplatesData.ToString()));

            if (GetVendorTemplatesComplete != null)
            {
                GetVendorTemplatesComplete(GetVendorTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search vendors 
        /// </summary>
        /// <param name="filterName">Filters vendors by name starting with the text provided in the filter</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetVendors(string filterName, int? size, int? page, string order)
        {
            
            mGetVendorsPath = "/vendors";
            if (!string.IsNullOrEmpty(mGetVendorsPath))
            {
                mGetVendorsPath = mGetVendorsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.DefaultClient.ParameterToString(filterName));
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
            List<string> authSettings = new List<string> {  };

            mGetVendorsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetVendorsStartTime, mGetVendorsPath, "Sending server request...");

            // make the HTTP request
            mGetVendorsCoroutine.ResponseReceived += GetVendorsCallback;
            mGetVendorsCoroutine.Start(mGetVendorsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetVendorsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVendors: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVendors: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetVendorsData = (PageResourceVendorResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceVendorResource), response.Headers);
            KnetikLogger.LogResponse(mGetVendorsStartTime, mGetVendorsPath, string.Format("Response received successfully:\n{0}", GetVendorsData.ToString()));

            if (GetVendorsComplete != null)
            {
                GetVendorsComplete(GetVendorsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a vendor 
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        /// <param name="vendor">The vendor</param>
        public void UpdateVendor(int? id, VendorResource vendor)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateVendor");
            }
            
            mUpdateVendorPath = "/vendors/{id}";
            if (!string.IsNullOrEmpty(mUpdateVendorPath))
            {
                mUpdateVendorPath = mUpdateVendorPath.Replace("{format}", "json");
            }
            mUpdateVendorPath = mUpdateVendorPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(vendor); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateVendorStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateVendorStartTime, mUpdateVendorPath, "Sending server request...");

            // make the HTTP request
            mUpdateVendorCoroutine.ResponseReceived += UpdateVendorCallback;
            mUpdateVendorCoroutine.Start(mUpdateVendorPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateVendorCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateVendor: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateVendor: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateVendorData = (VendorResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(VendorResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateVendorStartTime, mUpdateVendorPath, string.Format("Response received successfully:\n{0}", UpdateVendorData.ToString()));

            if (UpdateVendorComplete != null)
            {
                UpdateVendorComplete(UpdateVendorData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a vendor template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="vendorTemplateResource">The vendor template resource object</param>
        public void UpdateVendorTemplate(string id, ItemTemplateResource vendorTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateVendorTemplate");
            }
            
            mUpdateVendorTemplatePath = "/vendors/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateVendorTemplatePath))
            {
                mUpdateVendorTemplatePath = mUpdateVendorTemplatePath.Replace("{format}", "json");
            }
            mUpdateVendorTemplatePath = mUpdateVendorTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(vendorTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateVendorTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateVendorTemplateStartTime, mUpdateVendorTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateVendorTemplateCoroutine.ResponseReceived += UpdateVendorTemplateCallback;
            mUpdateVendorTemplateCoroutine.Start(mUpdateVendorTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateVendorTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateVendorTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateVendorTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateVendorTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateVendorTemplateStartTime, mUpdateVendorTemplatePath, string.Format("Response received successfully:\n{0}", UpdateVendorTemplateData.ToString()));

            if (UpdateVendorTemplateComplete != null)
            {
                UpdateVendorTemplateComplete(UpdateVendorTemplateData);
            }
        }

    }
}
