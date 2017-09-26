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
    public interface IStoreBundlesApi
    {
        BundleItem CreateBundleItemData { get; }

        ItemTemplateResource CreateBundleTemplateData { get; }

        BundleItem GetBundleItemData { get; }

        ItemTemplateResource GetBundleTemplateData { get; }

        PageResourceItemTemplateResource GetBundleTemplatesData { get; }

        BundleItem UpdateBundleItemData { get; }

        ItemTemplateResource UpdateBundleTemplateData { get; }

        
        /// <summary>
        /// Create a bundle item The SKU for the bundle itself must be unique and there can only be one SKU.  Extra notes for price_override:  The price of all the items (multiplied by the quantity) must equal the price of the bundle.  With individual prices set, items will be processed individually and can be refunded as such.  However, if all prices are set to null, the price of the bundle will be used and will be treated as one item.
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="bundleItem">The bundle item object</param>
        void CreateBundleItem(bool? cascade, BundleItem bundleItem);

        /// <summary>
        /// Create a bundle template Bundle Templates define a type of bundle and the properties they have.
        /// </summary>
        /// <param name="bundleTemplateResource">The new bundle template</param>
        void CreateBundleTemplate(ItemTemplateResource bundleTemplateResource);

        /// <summary>
        /// Delete a bundle item 
        /// </summary>
        /// <param name="id">The id of the bundle</param>
        void DeleteBundleItem(int? id);

        /// <summary>
        /// Delete a bundle template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        void DeleteBundleTemplate(string id, string cascade);

        /// <summary>
        /// Get a single bundle item 
        /// </summary>
        /// <param name="id">The id of the bundle</param>
        void GetBundleItem(int? id);

        /// <summary>
        /// Get a single bundle template Bundle Templates define a type of bundle and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetBundleTemplate(string id);

        /// <summary>
        /// List and search bundle templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetBundleTemplates(int? size, int? page, string order);

        /// <summary>
        /// Update a bundle item 
        /// </summary>
        /// <param name="id">The id of the bundle</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="bundleItem">The bundle item object</param>
        void UpdateBundleItem(int? id, bool? cascade, BundleItem bundleItem);

        /// <summary>
        /// Update a bundle template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="bundleTemplateResource">The bundle template resource object</param>
        void UpdateBundleTemplate(string id, ItemTemplateResource bundleTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StoreBundlesApi : IStoreBundlesApi
    {
        private readonly KnetikCoroutine mCreateBundleItemCoroutine;
        private DateTime mCreateBundleItemStartTime;
        private string mCreateBundleItemPath;
        private readonly KnetikCoroutine mCreateBundleTemplateCoroutine;
        private DateTime mCreateBundleTemplateStartTime;
        private string mCreateBundleTemplatePath;
        private readonly KnetikCoroutine mDeleteBundleItemCoroutine;
        private DateTime mDeleteBundleItemStartTime;
        private string mDeleteBundleItemPath;
        private readonly KnetikCoroutine mDeleteBundleTemplateCoroutine;
        private DateTime mDeleteBundleTemplateStartTime;
        private string mDeleteBundleTemplatePath;
        private readonly KnetikCoroutine mGetBundleItemCoroutine;
        private DateTime mGetBundleItemStartTime;
        private string mGetBundleItemPath;
        private readonly KnetikCoroutine mGetBundleTemplateCoroutine;
        private DateTime mGetBundleTemplateStartTime;
        private string mGetBundleTemplatePath;
        private readonly KnetikCoroutine mGetBundleTemplatesCoroutine;
        private DateTime mGetBundleTemplatesStartTime;
        private string mGetBundleTemplatesPath;
        private readonly KnetikCoroutine mUpdateBundleItemCoroutine;
        private DateTime mUpdateBundleItemStartTime;
        private string mUpdateBundleItemPath;
        private readonly KnetikCoroutine mUpdateBundleTemplateCoroutine;
        private DateTime mUpdateBundleTemplateStartTime;
        private string mUpdateBundleTemplatePath;

        public BundleItem CreateBundleItemData { get; private set; }
        public delegate void CreateBundleItemCompleteDelegate(BundleItem response);
        public CreateBundleItemCompleteDelegate CreateBundleItemComplete;

        public ItemTemplateResource CreateBundleTemplateData { get; private set; }
        public delegate void CreateBundleTemplateCompleteDelegate(ItemTemplateResource response);
        public CreateBundleTemplateCompleteDelegate CreateBundleTemplateComplete;

        public delegate void DeleteBundleItemCompleteDelegate();
        public DeleteBundleItemCompleteDelegate DeleteBundleItemComplete;

        public delegate void DeleteBundleTemplateCompleteDelegate();
        public DeleteBundleTemplateCompleteDelegate DeleteBundleTemplateComplete;

        public BundleItem GetBundleItemData { get; private set; }
        public delegate void GetBundleItemCompleteDelegate(BundleItem response);
        public GetBundleItemCompleteDelegate GetBundleItemComplete;

        public ItemTemplateResource GetBundleTemplateData { get; private set; }
        public delegate void GetBundleTemplateCompleteDelegate(ItemTemplateResource response);
        public GetBundleTemplateCompleteDelegate GetBundleTemplateComplete;

        public PageResourceItemTemplateResource GetBundleTemplatesData { get; private set; }
        public delegate void GetBundleTemplatesCompleteDelegate(PageResourceItemTemplateResource response);
        public GetBundleTemplatesCompleteDelegate GetBundleTemplatesComplete;

        public BundleItem UpdateBundleItemData { get; private set; }
        public delegate void UpdateBundleItemCompleteDelegate(BundleItem response);
        public UpdateBundleItemCompleteDelegate UpdateBundleItemComplete;

        public ItemTemplateResource UpdateBundleTemplateData { get; private set; }
        public delegate void UpdateBundleTemplateCompleteDelegate(ItemTemplateResource response);
        public UpdateBundleTemplateCompleteDelegate UpdateBundleTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreBundlesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreBundlesApi()
        {
            mCreateBundleItemCoroutine = new KnetikCoroutine();
            mCreateBundleTemplateCoroutine = new KnetikCoroutine();
            mDeleteBundleItemCoroutine = new KnetikCoroutine();
            mDeleteBundleTemplateCoroutine = new KnetikCoroutine();
            mGetBundleItemCoroutine = new KnetikCoroutine();
            mGetBundleTemplateCoroutine = new KnetikCoroutine();
            mGetBundleTemplatesCoroutine = new KnetikCoroutine();
            mUpdateBundleItemCoroutine = new KnetikCoroutine();
            mUpdateBundleTemplateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a bundle item The SKU for the bundle itself must be unique and there can only be one SKU.  Extra notes for price_override:  The price of all the items (multiplied by the quantity) must equal the price of the bundle.  With individual prices set, items will be processed individually and can be refunded as such.  However, if all prices are set to null, the price of the bundle will be used and will be treated as one item.
        /// </summary>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="bundleItem">The bundle item object</param>
        public void CreateBundleItem(bool? cascade, BundleItem bundleItem)
        {
            
            mCreateBundleItemPath = "/store/bundles";
            if (!string.IsNullOrEmpty(mCreateBundleItemPath))
            {
                mCreateBundleItemPath = mCreateBundleItemPath.Replace("{format}", "json");
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

            postBody = KnetikClient.DefaultClient.Serialize(bundleItem); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateBundleItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateBundleItemStartTime, mCreateBundleItemPath, "Sending server request...");

            // make the HTTP request
            mCreateBundleItemCoroutine.ResponseReceived += CreateBundleItemCallback;
            mCreateBundleItemCoroutine.Start(mCreateBundleItemPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateBundleItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateBundleItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateBundleItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateBundleItemData = (BundleItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(BundleItem), response.Headers);
            KnetikLogger.LogResponse(mCreateBundleItemStartTime, mCreateBundleItemPath, string.Format("Response received successfully:\n{0}", CreateBundleItemData.ToString()));

            if (CreateBundleItemComplete != null)
            {
                CreateBundleItemComplete(CreateBundleItemData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Create a bundle template Bundle Templates define a type of bundle and the properties they have.
        /// </summary>
        /// <param name="bundleTemplateResource">The new bundle template</param>
        public void CreateBundleTemplate(ItemTemplateResource bundleTemplateResource)
        {
            
            mCreateBundleTemplatePath = "/store/bundles/templates";
            if (!string.IsNullOrEmpty(mCreateBundleTemplatePath))
            {
                mCreateBundleTemplatePath = mCreateBundleTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(bundleTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateBundleTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateBundleTemplateStartTime, mCreateBundleTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateBundleTemplateCoroutine.ResponseReceived += CreateBundleTemplateCallback;
            mCreateBundleTemplateCoroutine.Start(mCreateBundleTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateBundleTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateBundleTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateBundleTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateBundleTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateBundleTemplateStartTime, mCreateBundleTemplatePath, string.Format("Response received successfully:\n{0}", CreateBundleTemplateData.ToString()));

            if (CreateBundleTemplateComplete != null)
            {
                CreateBundleTemplateComplete(CreateBundleTemplateData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Delete a bundle item 
        /// </summary>
        /// <param name="id">The id of the bundle</param>
        public void DeleteBundleItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteBundleItem");
            }
            
            mDeleteBundleItemPath = "/store/bundles/{id}";
            if (!string.IsNullOrEmpty(mDeleteBundleItemPath))
            {
                mDeleteBundleItemPath = mDeleteBundleItemPath.Replace("{format}", "json");
            }
            mDeleteBundleItemPath = mDeleteBundleItemPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteBundleItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteBundleItemStartTime, mDeleteBundleItemPath, "Sending server request...");

            // make the HTTP request
            mDeleteBundleItemCoroutine.ResponseReceived += DeleteBundleItemCallback;
            mDeleteBundleItemCoroutine.Start(mDeleteBundleItemPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteBundleItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteBundleItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteBundleItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteBundleItemStartTime, mDeleteBundleItemPath, "Response received successfully.");
            if (DeleteBundleItemComplete != null)
            {
                DeleteBundleItemComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Delete a bundle template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">force deleting the template if it&#39;s attached to other objects, cascade &#x3D; detach</param>
        public void DeleteBundleTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteBundleTemplate");
            }
            
            mDeleteBundleTemplatePath = "/store/bundles/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteBundleTemplatePath))
            {
                mDeleteBundleTemplatePath = mDeleteBundleTemplatePath.Replace("{format}", "json");
            }
            mDeleteBundleTemplatePath = mDeleteBundleTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mDeleteBundleTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteBundleTemplateStartTime, mDeleteBundleTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteBundleTemplateCoroutine.ResponseReceived += DeleteBundleTemplateCallback;
            mDeleteBundleTemplateCoroutine.Start(mDeleteBundleTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteBundleTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteBundleTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteBundleTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteBundleTemplateStartTime, mDeleteBundleTemplatePath, "Response received successfully.");
            if (DeleteBundleTemplateComplete != null)
            {
                DeleteBundleTemplateComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Get a single bundle item 
        /// </summary>
        /// <param name="id">The id of the bundle</param>
        public void GetBundleItem(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBundleItem");
            }
            
            mGetBundleItemPath = "/store/bundles/{id}";
            if (!string.IsNullOrEmpty(mGetBundleItemPath))
            {
                mGetBundleItemPath = mGetBundleItemPath.Replace("{format}", "json");
            }
            mGetBundleItemPath = mGetBundleItemPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetBundleItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBundleItemStartTime, mGetBundleItemPath, "Sending server request...");

            // make the HTTP request
            mGetBundleItemCoroutine.ResponseReceived += GetBundleItemCallback;
            mGetBundleItemCoroutine.Start(mGetBundleItemPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBundleItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBundleItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBundleItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBundleItemData = (BundleItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(BundleItem), response.Headers);
            KnetikLogger.LogResponse(mGetBundleItemStartTime, mGetBundleItemPath, string.Format("Response received successfully:\n{0}", GetBundleItemData.ToString()));

            if (GetBundleItemComplete != null)
            {
                GetBundleItemComplete(GetBundleItemData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Get a single bundle template Bundle Templates define a type of bundle and the properties they have.
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetBundleTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBundleTemplate");
            }
            
            mGetBundleTemplatePath = "/store/bundles/templates/{id}";
            if (!string.IsNullOrEmpty(mGetBundleTemplatePath))
            {
                mGetBundleTemplatePath = mGetBundleTemplatePath.Replace("{format}", "json");
            }
            mGetBundleTemplatePath = mGetBundleTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetBundleTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBundleTemplateStartTime, mGetBundleTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetBundleTemplateCoroutine.ResponseReceived += GetBundleTemplateCallback;
            mGetBundleTemplateCoroutine.Start(mGetBundleTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBundleTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBundleTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBundleTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBundleTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetBundleTemplateStartTime, mGetBundleTemplatePath, string.Format("Response received successfully:\n{0}", GetBundleTemplateData.ToString()));

            if (GetBundleTemplateComplete != null)
            {
                GetBundleTemplateComplete(GetBundleTemplateData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// List and search bundle templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetBundleTemplates(int? size, int? page, string order)
        {
            
            mGetBundleTemplatesPath = "/store/bundles/templates";
            if (!string.IsNullOrEmpty(mGetBundleTemplatesPath))
            {
                mGetBundleTemplatesPath = mGetBundleTemplatesPath.Replace("{format}", "json");
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
            string[] authSettings = new string[] {  };

            mGetBundleTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBundleTemplatesStartTime, mGetBundleTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetBundleTemplatesCoroutine.ResponseReceived += GetBundleTemplatesCallback;
            mGetBundleTemplatesCoroutine.Start(mGetBundleTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBundleTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBundleTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBundleTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBundleTemplatesData = (PageResourceItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetBundleTemplatesStartTime, mGetBundleTemplatesPath, string.Format("Response received successfully:\n{0}", GetBundleTemplatesData.ToString()));

            if (GetBundleTemplatesComplete != null)
            {
                GetBundleTemplatesComplete(GetBundleTemplatesData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Update a bundle item 
        /// </summary>
        /// <param name="id">The id of the bundle</param>
        /// <param name="cascade">Whether to cascade group changes, such as in the limited gettable behavior. A 400 error will return otherwise if the group is already in use with different values.</param>
        /// <param name="bundleItem">The bundle item object</param>
        public void UpdateBundleItem(int? id, bool? cascade, BundleItem bundleItem)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateBundleItem");
            }
            
            mUpdateBundleItemPath = "/store/bundles/{id}";
            if (!string.IsNullOrEmpty(mUpdateBundleItemPath))
            {
                mUpdateBundleItemPath = mUpdateBundleItemPath.Replace("{format}", "json");
            }
            mUpdateBundleItemPath = mUpdateBundleItemPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            postBody = KnetikClient.DefaultClient.Serialize(bundleItem); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateBundleItemStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateBundleItemStartTime, mUpdateBundleItemPath, "Sending server request...");

            // make the HTTP request
            mUpdateBundleItemCoroutine.ResponseReceived += UpdateBundleItemCallback;
            mUpdateBundleItemCoroutine.Start(mUpdateBundleItemPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateBundleItemCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBundleItem: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBundleItem: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateBundleItemData = (BundleItem) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(BundleItem), response.Headers);
            KnetikLogger.LogResponse(mUpdateBundleItemStartTime, mUpdateBundleItemPath, string.Format("Response received successfully:\n{0}", UpdateBundleItemData.ToString()));

            if (UpdateBundleItemComplete != null)
            {
                UpdateBundleItemComplete(UpdateBundleItemData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Update a bundle template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="bundleTemplateResource">The bundle template resource object</param>
        public void UpdateBundleTemplate(string id, ItemTemplateResource bundleTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateBundleTemplate");
            }
            
            mUpdateBundleTemplatePath = "/store/bundles/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateBundleTemplatePath))
            {
                mUpdateBundleTemplatePath = mUpdateBundleTemplatePath.Replace("{format}", "json");
            }
            mUpdateBundleTemplatePath = mUpdateBundleTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(bundleTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateBundleTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateBundleTemplateStartTime, mUpdateBundleTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateBundleTemplateCoroutine.ResponseReceived += UpdateBundleTemplateCallback;
            mUpdateBundleTemplateCoroutine.Start(mUpdateBundleTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateBundleTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBundleTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBundleTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateBundleTemplateData = (ItemTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ItemTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateBundleTemplateStartTime, mUpdateBundleTemplatePath, string.Format("Response received successfully:\n{0}", UpdateBundleTemplateData.ToString()));

            if (UpdateBundleTemplateComplete != null)
            {
                UpdateBundleTemplateComplete(UpdateBundleTemplateData);
            }
        }
    }
}
