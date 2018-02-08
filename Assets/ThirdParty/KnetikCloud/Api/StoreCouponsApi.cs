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
    public interface IStoreCouponsApi
    {
        CouponItem CreateCouponItemData { get; }

        /// <summary>
        /// Create a coupon item SKUs have to be unique in the entire store. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; COUPONS_ADMIN
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="couponItem">The coupon item object</param>
        void CreateCouponItem(bool? cascade, CouponItem couponItem);

        ItemTemplateResource CreateCouponTemplateData { get; }

        /// <summary>
        /// Create a coupon template Coupon Templates define a type of coupon and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="couponTemplateResource">The new coupon template</param>
        void CreateCouponTemplate(ItemTemplateResource couponTemplateResource);

        

        /// <summary>
        /// Delete a coupon item &lt;b&gt;Permissions Needed:&lt;/b&gt; COUPONS_ADMIN
        /// </summary>
        /// <param name="id">The id of the coupon</param>
        void DeleteCouponItem(int? id);

        

        /// <summary>
        /// Delete a coupon template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        void DeleteCouponTemplate(string id, string cascade);

        CouponItem GetCouponItemData { get; }

        /// <summary>
        /// Get a single coupon item &lt;b&gt;Permissions Needed:&lt;/b&gt; COUPONS_ADMIN
        /// </summary>
        /// <param name="id">The id of the coupon</param>
        void GetCouponItem(int? id);

        CouponItem GetCouponItemBySkuData { get; }

        /// <summary>
        /// Get a coupon by sku &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="sku">A sku of the coupon</param>
        void GetCouponItemBySku(string sku);

        ItemTemplateResource GetCouponTemplateData { get; }

        /// <summary>
        /// Get a single coupon template Coupon Templates define a type of coupon and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or COUPONS_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetCouponTemplate(string id);

        PageResourceItemTemplateResource GetCouponTemplatesData { get; }

        /// <summary>
        /// List and search coupon templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or COUPONS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCouponTemplates(int? size, int? page, string order);

        CouponItem UpdateCouponItemData { get; }

        /// <summary>
        /// Update a coupon item &lt;b&gt;Permissions Needed:&lt;/b&gt; COUPONS_ADMIN
        /// </summary>
        /// <param name="id">The id of the coupon</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="couponItem">The coupon item object</param>
        void UpdateCouponItem(int? id, bool? cascade, CouponItem couponItem);

        ItemTemplateResource UpdateCouponTemplateData { get; }

        /// <summary>
        /// Update a coupon template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="couponTemplateResource">The coupon template resource object</param>
        void UpdateCouponTemplate(string id, ItemTemplateResource couponTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StoreCouponsApi : IStoreCouponsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateCouponItemResponseContext;
        private DateTime mCreateCouponItemStartTime;
        private readonly KnetikResponseContext mCreateCouponTemplateResponseContext;
        private DateTime mCreateCouponTemplateStartTime;
        private readonly KnetikResponseContext mDeleteCouponItemResponseContext;
        private DateTime mDeleteCouponItemStartTime;
        private readonly KnetikResponseContext mDeleteCouponTemplateResponseContext;
        private DateTime mDeleteCouponTemplateStartTime;
        private readonly KnetikResponseContext mGetCouponItemResponseContext;
        private DateTime mGetCouponItemStartTime;
        private readonly KnetikResponseContext mGetCouponItemBySkuResponseContext;
        private DateTime mGetCouponItemBySkuStartTime;
        private readonly KnetikResponseContext mGetCouponTemplateResponseContext;
        private DateTime mGetCouponTemplateStartTime;
        private readonly KnetikResponseContext mGetCouponTemplatesResponseContext;
        private DateTime mGetCouponTemplatesStartTime;
        private readonly KnetikResponseContext mUpdateCouponItemResponseContext;
        private DateTime mUpdateCouponItemStartTime;
        private readonly KnetikResponseContext mUpdateCouponTemplateResponseContext;
        private DateTime mUpdateCouponTemplateStartTime;

        public CouponItem CreateCouponItemData { get; private set; }
        public delegate void CreateCouponItemCompleteDelegate(long responseCode, CouponItem response);
        public CreateCouponItemCompleteDelegate CreateCouponItemComplete;

        public ItemTemplateResource CreateCouponTemplateData { get; private set; }
        public delegate void CreateCouponTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public CreateCouponTemplateCompleteDelegate CreateCouponTemplateComplete;

        public delegate void DeleteCouponItemCompleteDelegate(long responseCode);
        public DeleteCouponItemCompleteDelegate DeleteCouponItemComplete;

        public delegate void DeleteCouponTemplateCompleteDelegate(long responseCode);
        public DeleteCouponTemplateCompleteDelegate DeleteCouponTemplateComplete;

        public CouponItem GetCouponItemData { get; private set; }
        public delegate void GetCouponItemCompleteDelegate(long responseCode, CouponItem response);
        public GetCouponItemCompleteDelegate GetCouponItemComplete;

        public CouponItem GetCouponItemBySkuData { get; private set; }
        public delegate void GetCouponItemBySkuCompleteDelegate(long responseCode, CouponItem response);
        public GetCouponItemBySkuCompleteDelegate GetCouponItemBySkuComplete;

        public ItemTemplateResource GetCouponTemplateData { get; private set; }
        public delegate void GetCouponTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public GetCouponTemplateCompleteDelegate GetCouponTemplateComplete;

        public PageResourceItemTemplateResource GetCouponTemplatesData { get; private set; }
        public delegate void GetCouponTemplatesCompleteDelegate(long responseCode, PageResourceItemTemplateResource response);
        public GetCouponTemplatesCompleteDelegate GetCouponTemplatesComplete;

        public CouponItem UpdateCouponItemData { get; private set; }
        public delegate void UpdateCouponItemCompleteDelegate(long responseCode, CouponItem response);
        public UpdateCouponItemCompleteDelegate UpdateCouponItemComplete;

        public ItemTemplateResource UpdateCouponTemplateData { get; private set; }
        public delegate void UpdateCouponTemplateCompleteDelegate(long responseCode, ItemTemplateResource response);
        public UpdateCouponTemplateCompleteDelegate UpdateCouponTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreCouponsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreCouponsApi()
        {
            mCreateCouponItemResponseContext = new KnetikResponseContext();
            mCreateCouponItemResponseContext.ResponseReceived += OnCreateCouponItemResponse;
            mCreateCouponTemplateResponseContext = new KnetikResponseContext();
            mCreateCouponTemplateResponseContext.ResponseReceived += OnCreateCouponTemplateResponse;
            mDeleteCouponItemResponseContext = new KnetikResponseContext();
            mDeleteCouponItemResponseContext.ResponseReceived += OnDeleteCouponItemResponse;
            mDeleteCouponTemplateResponseContext = new KnetikResponseContext();
            mDeleteCouponTemplateResponseContext.ResponseReceived += OnDeleteCouponTemplateResponse;
            mGetCouponItemResponseContext = new KnetikResponseContext();
            mGetCouponItemResponseContext.ResponseReceived += OnGetCouponItemResponse;
            mGetCouponItemBySkuResponseContext = new KnetikResponseContext();
            mGetCouponItemBySkuResponseContext.ResponseReceived += OnGetCouponItemBySkuResponse;
            mGetCouponTemplateResponseContext = new KnetikResponseContext();
            mGetCouponTemplateResponseContext.ResponseReceived += OnGetCouponTemplateResponse;
            mGetCouponTemplatesResponseContext = new KnetikResponseContext();
            mGetCouponTemplatesResponseContext.ResponseReceived += OnGetCouponTemplatesResponse;
            mUpdateCouponItemResponseContext = new KnetikResponseContext();
            mUpdateCouponItemResponseContext.ResponseReceived += OnUpdateCouponItemResponse;
            mUpdateCouponTemplateResponseContext = new KnetikResponseContext();
            mUpdateCouponTemplateResponseContext.ResponseReceived += OnUpdateCouponTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a coupon item SKUs have to be unique in the entire store. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; COUPONS_ADMIN
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="couponItem">The coupon item object</param>
        public void CreateCouponItem(bool? cascade, CouponItem couponItem)
        {
            
            mWebCallEvent.WebPath = "/store/coupons";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (cascade != null)
            {
                mWebCallEvent.QueryParams["cascade"] = KnetikClient.ParameterToString(cascade);
            }

            mWebCallEvent.PostBody = KnetikClient.Serialize(couponItem); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateCouponItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateCouponItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateCouponItemStartTime, "CreateCouponItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateCouponItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateCouponItem: " + response.Error);
            }

            CreateCouponItemData = (CouponItem) KnetikClient.Deserialize(response.Content, typeof(CouponItem), response.Headers);
            KnetikLogger.LogResponse(mCreateCouponItemStartTime, "CreateCouponItem", string.Format("Response received successfully:\n{0}", CreateCouponItemData));

            if (CreateCouponItemComplete != null)
            {
                CreateCouponItemComplete(response.ResponseCode, CreateCouponItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a coupon template Coupon Templates define a type of coupon and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="couponTemplateResource">The new coupon template</param>
        public void CreateCouponTemplate(ItemTemplateResource couponTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/store/coupons/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(couponTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateCouponTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateCouponTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateCouponTemplateStartTime, "CreateCouponTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateCouponTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateCouponTemplate: " + response.Error);
            }

            CreateCouponTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCouponTemplateStartTime, "CreateCouponTemplate", string.Format("Response received successfully:\n{0}", CreateCouponTemplateData));

            if (CreateCouponTemplateComplete != null)
            {
                CreateCouponTemplateComplete(response.ResponseCode, CreateCouponTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a coupon item &lt;b&gt;Permissions Needed:&lt;/b&gt; COUPONS_ADMIN
        /// </summary>
        /// <param name="id">The id of the coupon</param>
        public void DeleteCouponItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteCouponItem");
            }
            
            mWebCallEvent.WebPath = "/store/coupons/{id}";
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
            mDeleteCouponItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteCouponItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteCouponItemStartTime, "DeleteCouponItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteCouponItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteCouponItem: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteCouponItemStartTime, "DeleteCouponItem", "Response received successfully.");
            if (DeleteCouponItemComplete != null)
            {
                DeleteCouponItemComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a coupon template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        public void DeleteCouponTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteCouponTemplate");
            }
            
            mWebCallEvent.WebPath = "/store/coupons/templates/{id}";
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
            mDeleteCouponTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteCouponTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteCouponTemplateStartTime, "DeleteCouponTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteCouponTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteCouponTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteCouponTemplateStartTime, "DeleteCouponTemplate", "Response received successfully.");
            if (DeleteCouponTemplateComplete != null)
            {
                DeleteCouponTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single coupon item &lt;b&gt;Permissions Needed:&lt;/b&gt; COUPONS_ADMIN
        /// </summary>
        /// <param name="id">The id of the coupon</param>
        public void GetCouponItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCouponItem");
            }
            
            mWebCallEvent.WebPath = "/store/coupons/{id}";
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
            mGetCouponItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCouponItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCouponItemStartTime, "GetCouponItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCouponItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCouponItem: " + response.Error);
            }

            GetCouponItemData = (CouponItem) KnetikClient.Deserialize(response.Content, typeof(CouponItem), response.Headers);
            KnetikLogger.LogResponse(mGetCouponItemStartTime, "GetCouponItem", string.Format("Response received successfully:\n{0}", GetCouponItemData));

            if (GetCouponItemComplete != null)
            {
                GetCouponItemComplete(response.ResponseCode, GetCouponItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a coupon by sku &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="sku">A sku of the coupon</param>
        public void GetCouponItemBySku(string sku)
        {
            // verify the required parameter 'sku' is set
            if (sku == null)
            {
                throw new KnetikException(400, "Missing required parameter 'sku' when calling GetCouponItemBySku");
            }
            
            mWebCallEvent.WebPath = "/store/coupons/skus/{sku}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "sku" + "}", KnetikClient.ParameterToString(sku));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetCouponItemBySkuStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCouponItemBySkuResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCouponItemBySkuStartTime, "GetCouponItemBySku", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCouponItemBySkuResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCouponItemBySku: " + response.Error);
            }

            GetCouponItemBySkuData = (CouponItem) KnetikClient.Deserialize(response.Content, typeof(CouponItem), response.Headers);
            KnetikLogger.LogResponse(mGetCouponItemBySkuStartTime, "GetCouponItemBySku", string.Format("Response received successfully:\n{0}", GetCouponItemBySkuData));

            if (GetCouponItemBySkuComplete != null)
            {
                GetCouponItemBySkuComplete(response.ResponseCode, GetCouponItemBySkuData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single coupon template Coupon Templates define a type of coupon and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or COUPONS_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetCouponTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCouponTemplate");
            }
            
            mWebCallEvent.WebPath = "/store/coupons/templates/{id}";
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
            mGetCouponTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCouponTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCouponTemplateStartTime, "GetCouponTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCouponTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCouponTemplate: " + response.Error);
            }

            GetCouponTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetCouponTemplateStartTime, "GetCouponTemplate", string.Format("Response received successfully:\n{0}", GetCouponTemplateData));

            if (GetCouponTemplateComplete != null)
            {
                GetCouponTemplateComplete(response.ResponseCode, GetCouponTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search coupon templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or COUPONS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCouponTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/store/coupons/templates";
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
            mGetCouponTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCouponTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCouponTemplatesStartTime, "GetCouponTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCouponTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCouponTemplates: " + response.Error);
            }

            GetCouponTemplatesData = (PageResourceItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetCouponTemplatesStartTime, "GetCouponTemplates", string.Format("Response received successfully:\n{0}", GetCouponTemplatesData));

            if (GetCouponTemplatesComplete != null)
            {
                GetCouponTemplatesComplete(response.ResponseCode, GetCouponTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a coupon item &lt;b&gt;Permissions Needed:&lt;/b&gt; COUPONS_ADMIN
        /// </summary>
        /// <param name="id">The id of the coupon</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="couponItem">The coupon item object</param>
        public void UpdateCouponItem(int? id, bool? cascade, CouponItem couponItem)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateCouponItem");
            }
            
            mWebCallEvent.WebPath = "/store/coupons/{id}";
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

            mWebCallEvent.PostBody = KnetikClient.Serialize(couponItem); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateCouponItemStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateCouponItemResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateCouponItemStartTime, "UpdateCouponItem", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateCouponItemResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateCouponItem: " + response.Error);
            }

            UpdateCouponItemData = (CouponItem) KnetikClient.Deserialize(response.Content, typeof(CouponItem), response.Headers);
            KnetikLogger.LogResponse(mUpdateCouponItemStartTime, "UpdateCouponItem", string.Format("Response received successfully:\n{0}", UpdateCouponItemData));

            if (UpdateCouponItemComplete != null)
            {
                UpdateCouponItemComplete(response.ResponseCode, UpdateCouponItemData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a coupon template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="couponTemplateResource">The coupon template resource object</param>
        public void UpdateCouponTemplate(string id, ItemTemplateResource couponTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateCouponTemplate");
            }
            
            mWebCallEvent.WebPath = "/store/coupons/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(couponTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateCouponTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateCouponTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateCouponTemplateStartTime, "UpdateCouponTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateCouponTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateCouponTemplate: " + response.Error);
            }

            UpdateCouponTemplateData = (ItemTemplateResource) KnetikClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateCouponTemplateStartTime, "UpdateCouponTemplate", string.Format("Response received successfully:\n{0}", UpdateCouponTemplateData));

            if (UpdateCouponTemplateComplete != null)
            {
                UpdateCouponTemplateComplete(response.ResponseCode, UpdateCouponTemplateData);
            }
        }

    }
}
