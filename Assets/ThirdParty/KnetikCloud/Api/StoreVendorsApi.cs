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
    public interface IStoreVendorsApi
    {
        VendorResource CreateVendorData { get; }

        /// <summary>
        /// Create a vendor &lt;b&gt;Permissions Needed:&lt;/b&gt; VENDORS_ADMIN
        /// </summary>
        /// <param name="vendor">The vendor</param>
        void CreateVendor(VendorResource vendor);

        ItemTemplateResource CreateVendorTemplateData { get; }

        /// <summary>
        /// Create a vendor template Vendor Templates define a type of vendor and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="vendorTemplateResource">The new vendor template</param>
        void CreateVendorTemplate(ItemTemplateResource vendorTemplateResource);

        

        /// <summary>
        /// Delete a vendor &lt;b&gt;Permissions Needed:&lt;/b&gt; VENDORS_ADMIN
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        void DeleteVendor(int? id);

        

        /// <summary>
        /// Delete a vendor template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        void DeleteVendorTemplate(string id, string cascade);

        VendorResource GetVendorData { get; }

        /// <summary>
        /// Get a single vendor &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        void GetVendor(int? id);

        ItemTemplateResource GetVendorTemplateData { get; }

        /// <summary>
        /// Get a single vendor template Vendor Templates define a type of vendor and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetVendorTemplate(string id);

        PageResourceItemTemplateResource GetVendorTemplatesData { get; }

        /// <summary>
        /// List and search vendor templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetVendorTemplates(int? size, int? page, string order);

        PageResourceVendorResource GetVendorsData { get; }

        /// <summary>
        /// List and search vendors &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterName">Filters vendors by name starting with the text provided in the filter</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetVendors(string filterName, int? size, int? page, string order);

        VendorResource UpdateVendorData { get; }

        /// <summary>
        /// Update a vendor &lt;b&gt;Permissions Needed:&lt;/b&gt; VENDORS_ADMIN
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        /// <param name="vendor">The vendor</param>
        void UpdateVendor(int? id, VendorResource vendor);

        ItemTemplateResource UpdateVendorTemplateData { get; }

        /// <summary>
        /// Update a vendor template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateVendorResponseContext;
        private DateTime mCreateVendorStartTime;
        private readonly KnetikResponseContext mCreateVendorTemplateResponseContext;
        private DateTime mCreateVendorTemplateStartTime;
        private readonly KnetikResponseContext mDeleteVendorResponseContext;
        private DateTime mDeleteVendorStartTime;
        private readonly KnetikResponseContext mDeleteVendorTemplateResponseContext;
        private DateTime mDeleteVendorTemplateStartTime;
        private readonly KnetikResponseContext mGetVendorResponseContext;
        private DateTime mGetVendorStartTime;
        private readonly KnetikResponseContext mGetVendorTemplateResponseContext;
        private DateTime mGetVendorTemplateStartTime;
        private readonly KnetikResponseContext mGetVendorTemplatesResponseContext;
        private DateTime mGetVendorTemplatesStartTime;
        private readonly KnetikResponseContext mGetVendorsResponseContext;
        private DateTime mGetVendorsStartTime;
        private readonly KnetikResponseContext mUpdateVendorResponseContext;
        private DateTime mUpdateVendorStartTime;
        private readonly KnetikResponseContext mUpdateVendorTemplateResponseContext;
        private DateTime mUpdateVendorTemplateStartTime;

        public VendorResource CreateVendorData { get; private set; }
        public delegate void CreateVendorCompleteDelegate(long responseCode, VendorResource response);
        public CreateVendorCompleteDelegate CreateVendorComplete;

        public ItemTemplateResource CreateVendorTemplateData { get; private set; }
        public delegate void CreateVendorTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public CreateVendorTemplateCompleteDelegate CreateVendorTemplateComplete;

        public delegate void DeleteVendorCompleteDelegate(long responseCode);
        public DeleteVendorCompleteDelegate DeleteVendorComplete;

        public delegate void DeleteVendorTemplateCompleteDelegate(long responseCode);
        public DeleteVendorTemplateCompleteDelegate DeleteVendorTemplateComplete;

        public VendorResource GetVendorData { get; private set; }
        public delegate void GetVendorCompleteDelegate(long responseCode, VendorResource response);
        public GetVendorCompleteDelegate GetVendorComplete;

        public ItemTemplateResource GetVendorTemplateData { get; private set; }
        public delegate void GetVendorTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public GetVendorTemplateCompleteDelegate GetVendorTemplateComplete;

        public PageResourceItemTemplateResource GetVendorTemplatesData { get; private set; }
        public delegate void GetVendorTemplatesCompleteDelegate(long responseCode, PageResourceItemTemplateResource response);
        public GetVendorTemplatesCompleteDelegate GetVendorTemplatesComplete;

        public PageResourceVendorResource GetVendorsData { get; private set; }
        public delegate void GetVendorsCompleteDelegate(long responseCode, PageResourceVendorResource response);
        public GetVendorsCompleteDelegate GetVendorsComplete;

        public VendorResource UpdateVendorData { get; private set; }
        public delegate void UpdateVendorCompleteDelegate(long responseCode, VendorResource response);
        public UpdateVendorCompleteDelegate UpdateVendorComplete;

        public ItemTemplateResource UpdateVendorTemplateData { get; private set; }
        public delegate void UpdateVendorTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public UpdateVendorTemplateCompleteDelegate UpdateVendorTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreVendorsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreVendorsApi()
        {
            mCreateVendorResponseContext = new KnetikResponseContext();
            mCreateVendorResponseContext.ResponseReceived += OnCreateVendorResponse;
            mCreateVendorTemplateResponseContext = new KnetikResponseContext();
            mCreateVendorTemplateResponseContext.ResponseReceived += OnCreateVendorTemplateResponse;
            mDeleteVendorResponseContext = new KnetikResponseContext();
            mDeleteVendorResponseContext.ResponseReceived += OnDeleteVendorResponse;
            mDeleteVendorTemplateResponseContext = new KnetikResponseContext();
            mDeleteVendorTemplateResponseContext.ResponseReceived += OnDeleteVendorTemplateResponse;
            mGetVendorResponseContext = new KnetikResponseContext();
            mGetVendorResponseContext.ResponseReceived += OnGetVendorResponse;
            mGetVendorTemplateResponseContext = new KnetikResponseContext();
            mGetVendorTemplateResponseContext.ResponseReceived += OnGetVendorTemplateResponse;
            mGetVendorTemplatesResponseContext = new KnetikResponseContext();
            mGetVendorTemplatesResponseContext.ResponseReceived += OnGetVendorTemplatesResponse;
            mGetVendorsResponseContext = new KnetikResponseContext();
            mGetVendorsResponseContext.ResponseReceived += OnGetVendorsResponse;
            mUpdateVendorResponseContext = new KnetikResponseContext();
            mUpdateVendorResponseContext.ResponseReceived += OnUpdateVendorResponse;
            mUpdateVendorTemplateResponseContext = new KnetikResponseContext();
            mUpdateVendorTemplateResponseContext.ResponseReceived += OnUpdateVendorTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a vendor &lt;b&gt;Permissions Needed:&lt;/b&gt; VENDORS_ADMIN
        /// </summary>
        /// <param name="vendor">The vendor</param>
        public void CreateVendor(VendorResource vendor)
        {
            
            mWebCallEvent.WebPath = "/vendors";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(vendor); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateVendorStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateVendorResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateVendorStartTime, "CreateVendor", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateVendorResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateVendor: " + response.Error);
            }

            CreateVendorData = (VendorResource) KnetikClient.Deserialize(response.Content, typeof(VendorResource), response.Headers);
            KnetikLogger.LogResponse(mCreateVendorStartTime, "CreateVendor", string.Format("Response received successfully:\n{0}", CreateVendorData));

            if (CreateVendorComplete != null)
            {
                CreateVendorComplete(response.ResponseCode, CreateVendorData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a vendor template Vendor Templates define a type of vendor and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="vendorTemplateResource">The new vendor template</param>
        public void CreateVendorTemplate(ItemTemplateResource vendorTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/vendors/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(vendorTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateVendorTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateVendorTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateVendorTemplateStartTime, "CreateVendorTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateVendorTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateVendorTemplate: " + response.Error);
            }

            CreateVendorTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateVendorTemplateStartTime, "CreateVendorTemplate", string.Format("Response received successfully:\n{0}", CreateVendorTemplateData));

            if (CreateVendorTemplateComplete != null)
            {
                CreateVendorTemplateComplete(response.ResponseCode, CreateVendorTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a vendor &lt;b&gt;Permissions Needed:&lt;/b&gt; VENDORS_ADMIN
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        public void DeleteVendor(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteVendor");
            }
            
            mWebCallEvent.WebPath = "/vendors/{id}";
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
            mDeleteVendorStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteVendorResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteVendorStartTime, "DeleteVendor", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteVendorResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteVendor: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteVendorStartTime, "DeleteVendor", "Response received successfully.");
            if (DeleteVendorComplete != null)
            {
                DeleteVendorComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a vendor template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
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
            
            mWebCallEvent.WebPath = "/vendors/templates/{id}";
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
            mDeleteVendorTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteVendorTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteVendorTemplateStartTime, "DeleteVendorTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteVendorTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteVendorTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteVendorTemplateStartTime, "DeleteVendorTemplate", "Response received successfully.");
            if (DeleteVendorTemplateComplete != null)
            {
                DeleteVendorTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single vendor &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id of the vendor</param>
        public void GetVendor(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetVendor");
            }
            
            mWebCallEvent.WebPath = "/vendors/{id}";
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
            mGetVendorStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetVendorResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetVendorStartTime, "GetVendor", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetVendorResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetVendor: " + response.Error);
            }

            GetVendorData = (VendorResource) KnetikClient.Deserialize(response.Content, typeof(VendorResource), response.Headers);
            KnetikLogger.LogResponse(mGetVendorStartTime, "GetVendor", string.Format("Response received successfully:\n{0}", GetVendorData));

            if (GetVendorComplete != null)
            {
                GetVendorComplete(response.ResponseCode, GetVendorData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single vendor template Vendor Templates define a type of vendor and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetVendorTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetVendorTemplate");
            }
            
            mWebCallEvent.WebPath = "/vendors/templates/{id}";
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
            mGetVendorTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetVendorTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetVendorTemplateStartTime, "GetVendorTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetVendorTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetVendorTemplate: " + response.Error);
            }

            GetVendorTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetVendorTemplateStartTime, "GetVendorTemplate", string.Format("Response received successfully:\n{0}", GetVendorTemplateData));

            if (GetVendorTemplateComplete != null)
            {
                GetVendorTemplateComplete(response.ResponseCode, GetVendorTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search vendor templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetVendorTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/vendors/templates";
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
            mGetVendorTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetVendorTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetVendorTemplatesStartTime, "GetVendorTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetVendorTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetVendorTemplates: " + response.Error);
            }

            GetVendorTemplatesData = (PageResourceItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetVendorTemplatesStartTime, "GetVendorTemplates", string.Format("Response received successfully:\n{0}", GetVendorTemplatesData));

            if (GetVendorTemplatesComplete != null)
            {
                GetVendorTemplatesComplete(response.ResponseCode, GetVendorTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search vendors &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterName">Filters vendors by name starting with the text provided in the filter</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetVendors(string filterName, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/vendors";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterName != null)
            {
                mWebCallEvent.QueryParams["filter_name"] = KnetikClient.ParameterToString(filterName);
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
            mGetVendorsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetVendorsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetVendorsStartTime, "GetVendors", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetVendorsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetVendors: " + response.Error);
            }

            GetVendorsData = (PageResourceVendorResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceVendorResource), response.Headers);
            KnetikLogger.LogResponse(mGetVendorsStartTime, "GetVendors", string.Format("Response received successfully:\n{0}", GetVendorsData));

            if (GetVendorsComplete != null)
            {
                GetVendorsComplete(response.ResponseCode, GetVendorsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a vendor &lt;b&gt;Permissions Needed:&lt;/b&gt; VENDORS_ADMIN
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
            
            mWebCallEvent.WebPath = "/vendors/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(vendor); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateVendorStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateVendorResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateVendorStartTime, "UpdateVendor", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateVendorResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateVendor: " + response.Error);
            }

            UpdateVendorData = (VendorResource) KnetikClient.Deserialize(response.Content, typeof(VendorResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateVendorStartTime, "UpdateVendor", string.Format("Response received successfully:\n{0}", UpdateVendorData));

            if (UpdateVendorComplete != null)
            {
                UpdateVendorComplete(response.ResponseCode, UpdateVendorData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a vendor template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
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
            
            mWebCallEvent.WebPath = "/vendors/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(vendorTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateVendorTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateVendorTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateVendorTemplateStartTime, "UpdateVendorTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateVendorTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateVendorTemplate: " + response.Error);
            }

            UpdateVendorTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateVendorTemplateStartTime, "UpdateVendorTemplate", string.Format("Response received successfully:\n{0}", UpdateVendorTemplateData));

            if (UpdateVendorTemplateComplete != null)
            {
                UpdateVendorTemplateComplete(response.ResponseCode, UpdateVendorTemplateData);
            }
        }

    }
}
