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
    public interface IStoreCouponsApi
    {
        CouponItem CreateCouponItemData { get; }

        ItemTemplateResource CreateCouponTemplateData { get; }

        CouponItem GetCouponItemData { get; }

        ItemTemplateResource GetCouponTemplateData { get; }

        PageResourceItemTemplateResource GetCouponTemplatesData { get; }

        CouponItem UpdateCouponItemData { get; }

        ItemTemplateResource UpdateCouponTemplateData { get; }

        
        /// <summary>
        /// Create a coupon item SKUs have to be unique in the entire store.
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="couponItem">The coupon item object</param>
        void CreateCouponItem(bool? cascade, CouponItem couponItem);

        /// <summary>
        /// Create a coupon template Coupon Templates define a type of coupon and the properties they have.
        /// </summary>
        /// <param name="couponTemplateResource">The new coupon template</param>
        void CreateCouponTemplate(ItemTemplateResource couponTemplateResource);

        /// <summary>
        /// Delete a coupon item 
        /// </summary>
        /// <param name="id">The id of the coupon</param>
        void DeleteCouponItem(int? id);

        /// <summary>
        /// Delete a coupon template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        void DeleteCouponTemplate(string id, string cascade);

        /// <summary>
        /// Get a single coupon item 
        /// </summary>
        /// <param name="id">The id of the coupon</param>
        void GetCouponItem(int? id);

        /// <summary>
        /// Get a single coupon template Coupon Templates define a type of coupon and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetCouponTemplate(string id);

        /// <summary>
        /// List and search coupon templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCouponTemplates(int? size, int? page, string order);

        /// <summary>
        /// Update a coupon item 
        /// </summary>
        /// <param name="id">The id of the coupon</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="couponItem">The coupon item object</param>
        void UpdateCouponItem(int? id, bool? cascade, CouponItem couponItem);

        /// <summary>
        /// Update a coupon template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="couponTemplateResource">The coupon template resource object</param>
        void UpdateCouponTemplate(string id, ItemTemplateResource couponTemplateResource);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StoreCouponsApi : IStoreCouponsApi
    {
        private readonly KnetikCoroutine mCreateCouponItemCoroutine;
        private DateTime mCreateCouponItemStartTime;
        private string mCreateCouponItemPath;
        private readonly KnetikCoroutine mCreateCouponTemplateCoroutine;
        private DateTime mCreateCouponTemplateStartTime;
        private string mCreateCouponTemplatePath;
        private readonly KnetikCoroutine mDeleteCouponItemCoroutine;
        private DateTime mDeleteCouponItemStartTime;
        private string mDeleteCouponItemPath;
        private readonly KnetikCoroutine mDeleteCouponTemplateCoroutine;
        private DateTime mDeleteCouponTemplateStartTime;
        private string mDeleteCouponTemplatePath;
        private readonly KnetikCoroutine mGetCouponItemCoroutine;
        private DateTime mGetCouponItemStartTime;
        private string mGetCouponItemPath;
        private readonly KnetikCoroutine mGetCouponTemplateCoroutine;
        private DateTime mGetCouponTemplateStartTime;
        private string mGetCouponTemplatePath;
        private readonly KnetikCoroutine mGetCouponTemplatesCoroutine;
        private DateTime mGetCouponTemplatesStartTime;
        private string mGetCouponTemplatesPath;
        private readonly KnetikCoroutine mUpdateCouponItemCoroutine;
        private DateTime mUpdateCouponItemStartTime;
        private string mUpdateCouponItemPath;
        private readonly KnetikCoroutine mUpdateCouponTemplateCoroutine;
        private DateTime mUpdateCouponTemplateStartTime;
        private string mUpdateCouponTemplatePath;

        public CouponItem CreateCouponItemData { get; private set; }
        public delegate void CreateCouponItemCompleteDelegate(CouponItem response);
        public CreateCouponItemCompleteDelegate CreateCouponItemComplete;

        public ItemTemplateResource CreateCouponTemplateData { get; private set; }
        public delegate void CreateCouponTemplateCompleteDelegate(ItemTemplateResource response);
        public CreateCouponTemplateCompleteDelegate CreateCouponTemplateComplete;

        public delegate void DeleteCouponItemCompleteDelegate();
        public DeleteCouponItemCompleteDelegate DeleteCouponItemComplete;

        public delegate void DeleteCouponTemplateCompleteDelegate();
        public DeleteCouponTemplateCompleteDelegate DeleteCouponTemplateComplete;

        public CouponItem GetCouponItemData { get; private set; }
        public delegate void GetCouponItemCompleteDelegate(CouponItem response);
        public GetCouponItemCompleteDelegate GetCouponItemComplete;

        public ItemTemplateResource GetCouponTemplateData { get; private set; }
        public delegate void GetCouponTemplateCompleteDelegate(ItemTemplateResource response);
        public GetCouponTemplateCompleteDelegate GetCouponTemplateComplete;

        public PageResourceItemTemplateResource GetCouponTemplatesData { get; private set; }
        public delegate void GetCouponTemplatesCompleteDelegate(PageResourceItemTemplateResource response);
        public GetCouponTemplatesCompleteDelegate GetCouponTemplatesComplete;

        public CouponItem UpdateCouponItemData { get; private set; }
        public delegate void UpdateCouponItemCompleteDelegate(CouponItem response);
        public UpdateCouponItemCompleteDelegate UpdateCouponItemComplete;

        public ItemTemplateResource UpdateCouponTemplateData { get; private set; }
        public delegate void UpdateCouponTemplateCompleteDelegate(ItemTemplateResource response);
        public UpdateCouponTemplateCompleteDelegate UpdateCouponTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreCouponsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreCouponsApi()
        {
            mCreateCouponItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mCreateCouponTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mDeleteCouponItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mDeleteCouponTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetCouponItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetCouponTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetCouponTemplatesCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateCouponItemCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateCouponTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
        /// <summary>
        /// Create a coupon item SKUs have to be unique in the entire store.
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="couponItem">The coupon item object</param>
        public void CreateCouponItem(bool? cascade, CouponItem couponItem)
        {
            
            mCreateCouponItemPath = "/store/coupons";
            if (!string.IsNullOrEmpty(mCreateCouponItemPath))
            {
                mCreateCouponItemPath = mCreateCouponItemPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            postBody = KnetikClient.DefaultClient.Serialize(couponItem); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateCouponItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateCouponItemStartTime, mCreateCouponItemPath, "Sending server request...");

            // make the HTTP request
            mCreateCouponItemCoroutine.ResponseReceived += CreateCouponItemCallback;
            mCreateCouponItemCoroutine.Start(mCreateCouponItemPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateCouponItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCouponItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCouponItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateCouponItemData = (CouponItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CouponItem), response.Headers);
            KnetikLogger.LogResponse(mCreateCouponItemStartTime, mCreateCouponItemPath, string.Format("Response received successfully:\n{0}", CreateCouponItemData.ToString()));

            if (CreateCouponItemComplete != null)
            {
                CreateCouponItemComplete(CreateCouponItemData);
            }
        }
        /// <summary>
        /// Create a coupon template Coupon Templates define a type of coupon and the properties they have.
        /// </summary>
        /// <param name="couponTemplateResource">The new coupon template</param>
        public void CreateCouponTemplate(ItemTemplateResource couponTemplateResource)
        {
            
            mCreateCouponTemplatePath = "/store/coupons/templates";
            if (!string.IsNullOrEmpty(mCreateCouponTemplatePath))
            {
                mCreateCouponTemplatePath = mCreateCouponTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(couponTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateCouponTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateCouponTemplateStartTime, mCreateCouponTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateCouponTemplateCoroutine.ResponseReceived += CreateCouponTemplateCallback;
            mCreateCouponTemplateCoroutine.Start(mCreateCouponTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateCouponTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCouponTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCouponTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateCouponTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCouponTemplateStartTime, mCreateCouponTemplatePath, string.Format("Response received successfully:\n{0}", CreateCouponTemplateData.ToString()));

            if (CreateCouponTemplateComplete != null)
            {
                CreateCouponTemplateComplete(CreateCouponTemplateData);
            }
        }
        /// <summary>
        /// Delete a coupon item 
        /// </summary>
        /// <param name="id">The id of the coupon</param>
        public void DeleteCouponItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteCouponItem");
            }
            
            mDeleteCouponItemPath = "/store/coupons/{id}";
            if (!string.IsNullOrEmpty(mDeleteCouponItemPath))
            {
                mDeleteCouponItemPath = mDeleteCouponItemPath.Replace("{format}", "json");
            }
            mDeleteCouponItemPath = mDeleteCouponItemPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteCouponItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteCouponItemStartTime, mDeleteCouponItemPath, "Sending server request...");

            // make the HTTP request
            mDeleteCouponItemCoroutine.ResponseReceived += DeleteCouponItemCallback;
            mDeleteCouponItemCoroutine.Start(mDeleteCouponItemPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteCouponItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCouponItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCouponItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteCouponItemStartTime, mDeleteCouponItemPath, "Response received successfully.");
            if (DeleteCouponItemComplete != null)
            {
                DeleteCouponItemComplete();
            }
        }
        /// <summary>
        /// Delete a coupon template 
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
            
            mDeleteCouponTemplatePath = "/store/coupons/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteCouponTemplatePath))
            {
                mDeleteCouponTemplatePath = mDeleteCouponTemplatePath.Replace("{format}", "json");
            }
            mDeleteCouponTemplatePath = mDeleteCouponTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mDeleteCouponTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteCouponTemplateStartTime, mDeleteCouponTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteCouponTemplateCoroutine.ResponseReceived += DeleteCouponTemplateCallback;
            mDeleteCouponTemplateCoroutine.Start(mDeleteCouponTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteCouponTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCouponTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCouponTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteCouponTemplateStartTime, mDeleteCouponTemplatePath, "Response received successfully.");
            if (DeleteCouponTemplateComplete != null)
            {
                DeleteCouponTemplateComplete();
            }
        }
        /// <summary>
        /// Get a single coupon item 
        /// </summary>
        /// <param name="id">The id of the coupon</param>
        public void GetCouponItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCouponItem");
            }
            
            mGetCouponItemPath = "/store/coupons/{id}";
            if (!string.IsNullOrEmpty(mGetCouponItemPath))
            {
                mGetCouponItemPath = mGetCouponItemPath.Replace("{format}", "json");
            }
            mGetCouponItemPath = mGetCouponItemPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetCouponItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCouponItemStartTime, mGetCouponItemPath, "Sending server request...");

            // make the HTTP request
            mGetCouponItemCoroutine.ResponseReceived += GetCouponItemCallback;
            mGetCouponItemCoroutine.Start(mGetCouponItemPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCouponItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCouponItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCouponItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCouponItemData = (CouponItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CouponItem), response.Headers);
            KnetikLogger.LogResponse(mGetCouponItemStartTime, mGetCouponItemPath, string.Format("Response received successfully:\n{0}", GetCouponItemData.ToString()));

            if (GetCouponItemComplete != null)
            {
                GetCouponItemComplete(GetCouponItemData);
            }
        }
        /// <summary>
        /// Get a single coupon template Coupon Templates define a type of coupon and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetCouponTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCouponTemplate");
            }
            
            mGetCouponTemplatePath = "/store/coupons/templates/{id}";
            if (!string.IsNullOrEmpty(mGetCouponTemplatePath))
            {
                mGetCouponTemplatePath = mGetCouponTemplatePath.Replace("{format}", "json");
            }
            mGetCouponTemplatePath = mGetCouponTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetCouponTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCouponTemplateStartTime, mGetCouponTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetCouponTemplateCoroutine.ResponseReceived += GetCouponTemplateCallback;
            mGetCouponTemplateCoroutine.Start(mGetCouponTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCouponTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCouponTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCouponTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCouponTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetCouponTemplateStartTime, mGetCouponTemplatePath, string.Format("Response received successfully:\n{0}", GetCouponTemplateData.ToString()));

            if (GetCouponTemplateComplete != null)
            {
                GetCouponTemplateComplete(GetCouponTemplateData);
            }
        }
        /// <summary>
        /// List and search coupon templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCouponTemplates(int? size, int? page, string order)
        {
            
            mGetCouponTemplatesPath = "/store/coupons/templates";
            if (!string.IsNullOrEmpty(mGetCouponTemplatesPath))
            {
                mGetCouponTemplatesPath = mGetCouponTemplatesPath.Replace("{format}", "json");
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

            mGetCouponTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCouponTemplatesStartTime, mGetCouponTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetCouponTemplatesCoroutine.ResponseReceived += GetCouponTemplatesCallback;
            mGetCouponTemplatesCoroutine.Start(mGetCouponTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCouponTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCouponTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCouponTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCouponTemplatesData = (PageResourceItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetCouponTemplatesStartTime, mGetCouponTemplatesPath, string.Format("Response received successfully:\n{0}", GetCouponTemplatesData.ToString()));

            if (GetCouponTemplatesComplete != null)
            {
                GetCouponTemplatesComplete(GetCouponTemplatesData);
            }
        }
        /// <summary>
        /// Update a coupon item 
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
            
            mUpdateCouponItemPath = "/store/coupons/{id}";
            if (!string.IsNullOrEmpty(mUpdateCouponItemPath))
            {
                mUpdateCouponItemPath = mUpdateCouponItemPath.Replace("{format}", "json");
            }
            mUpdateCouponItemPath = mUpdateCouponItemPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            postBody = KnetikClient.DefaultClient.Serialize(couponItem); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateCouponItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateCouponItemStartTime, mUpdateCouponItemPath, "Sending server request...");

            // make the HTTP request
            mUpdateCouponItemCoroutine.ResponseReceived += UpdateCouponItemCallback;
            mUpdateCouponItemCoroutine.Start(mUpdateCouponItemPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateCouponItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCouponItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCouponItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateCouponItemData = (CouponItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CouponItem), response.Headers);
            KnetikLogger.LogResponse(mUpdateCouponItemStartTime, mUpdateCouponItemPath, string.Format("Response received successfully:\n{0}", UpdateCouponItemData.ToString()));

            if (UpdateCouponItemComplete != null)
            {
                UpdateCouponItemComplete(UpdateCouponItemData);
            }
        }
        /// <summary>
        /// Update a coupon template 
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
            
            mUpdateCouponTemplatePath = "/store/coupons/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateCouponTemplatePath))
            {
                mUpdateCouponTemplatePath = mUpdateCouponTemplatePath.Replace("{format}", "json");
            }
            mUpdateCouponTemplatePath = mUpdateCouponTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(couponTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateCouponTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateCouponTemplateStartTime, mUpdateCouponTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateCouponTemplateCoroutine.ResponseReceived += UpdateCouponTemplateCallback;
            mUpdateCouponTemplateCoroutine.Start(mUpdateCouponTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateCouponTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCouponTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCouponTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateCouponTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateCouponTemplateStartTime, mUpdateCouponTemplatePath, string.Format("Response received successfully:\n{0}", UpdateCouponTemplateData.ToString()));

            if (UpdateCouponTemplateComplete != null)
            {
                UpdateCouponTemplateComplete(UpdateCouponTemplateData);
            }
        }
    }
}
