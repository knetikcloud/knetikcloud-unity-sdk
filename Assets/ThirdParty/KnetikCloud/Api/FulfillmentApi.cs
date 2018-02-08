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
    public interface IFulfillmentApi
    {
        FulfillmentType CreateFulfillmentTypeData { get; }

        /// <summary>
        /// Create a fulfillment type &lt;b&gt;Permissions Needed:&lt;/b&gt; FULFILLMENT_ADMIN
        /// </summary>
        /// <param name="type">The fulfillment type</param>
        void CreateFulfillmentType(FulfillmentType type);

        

        /// <summary>
        /// Delete a fulfillment type &lt;b&gt;Permissions Needed:&lt;/b&gt; FULFILLMENT_ADMIN
        /// </summary>
        /// <param name="id">The id</param>
        void DeleteFulfillmentType(int? id);

        FulfillmentType GetFulfillmentTypeData { get; }

        /// <summary>
        /// Get a single fulfillment type &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id</param>
        void GetFulfillmentType(int? id);

        PageResourceFulfillmentType GetFulfillmentTypesData { get; }

        /// <summary>
        /// List and search fulfillment types &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetFulfillmentTypes(int? size, int? page, string order);

        

        /// <summary>
        /// Update a fulfillment type &lt;b&gt;Permissions Needed:&lt;/b&gt; FULFILLMENT_ADMIN
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="fulfillmentType">The fulfillment type</param>
        void UpdateFulfillmentType(int? id, FulfillmentType fulfillmentType);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class FulfillmentApi : IFulfillmentApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateFulfillmentTypeResponseContext;
        private DateTime mCreateFulfillmentTypeStartTime;
        private readonly KnetikResponseContext mDeleteFulfillmentTypeResponseContext;
        private DateTime mDeleteFulfillmentTypeStartTime;
        private readonly KnetikResponseContext mGetFulfillmentTypeResponseContext;
        private DateTime mGetFulfillmentTypeStartTime;
        private readonly KnetikResponseContext mGetFulfillmentTypesResponseContext;
        private DateTime mGetFulfillmentTypesStartTime;
        private readonly KnetikResponseContext mUpdateFulfillmentTypeResponseContext;
        private DateTime mUpdateFulfillmentTypeStartTime;

        public FulfillmentType CreateFulfillmentTypeData { get; private set; }
        public delegate void CreateFulfillmentTypeCompleteDelegate(long responseCode, FulfillmentType response);
        public CreateFulfillmentTypeCompleteDelegate CreateFulfillmentTypeComplete;

        public delegate void DeleteFulfillmentTypeCompleteDelegate(long responseCode);
        public DeleteFulfillmentTypeCompleteDelegate DeleteFulfillmentTypeComplete;

        public FulfillmentType GetFulfillmentTypeData { get; private set; }
        public delegate void GetFulfillmentTypeCompleteDelegate(long responseCode, FulfillmentType response);
        public GetFulfillmentTypeCompleteDelegate GetFulfillmentTypeComplete;

        public PageResourceFulfillmentType GetFulfillmentTypesData { get; private set; }
        public delegate void GetFulfillmentTypesCompleteDelegate(long responseCode, PageResourceFulfillmentType response);
        public GetFulfillmentTypesCompleteDelegate GetFulfillmentTypesComplete;

        public delegate void UpdateFulfillmentTypeCompleteDelegate(long responseCode);
        public UpdateFulfillmentTypeCompleteDelegate UpdateFulfillmentTypeComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="FulfillmentApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FulfillmentApi()
        {
            mCreateFulfillmentTypeResponseContext = new KnetikResponseContext();
            mCreateFulfillmentTypeResponseContext.ResponseReceived += OnCreateFulfillmentTypeResponse;
            mDeleteFulfillmentTypeResponseContext = new KnetikResponseContext();
            mDeleteFulfillmentTypeResponseContext.ResponseReceived += OnDeleteFulfillmentTypeResponse;
            mGetFulfillmentTypeResponseContext = new KnetikResponseContext();
            mGetFulfillmentTypeResponseContext.ResponseReceived += OnGetFulfillmentTypeResponse;
            mGetFulfillmentTypesResponseContext = new KnetikResponseContext();
            mGetFulfillmentTypesResponseContext.ResponseReceived += OnGetFulfillmentTypesResponse;
            mUpdateFulfillmentTypeResponseContext = new KnetikResponseContext();
            mUpdateFulfillmentTypeResponseContext.ResponseReceived += OnUpdateFulfillmentTypeResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a fulfillment type &lt;b&gt;Permissions Needed:&lt;/b&gt; FULFILLMENT_ADMIN
        /// </summary>
        /// <param name="type">The fulfillment type</param>
        public void CreateFulfillmentType(FulfillmentType type)
        {
            
            mWebCallEvent.WebPath = "/store/fulfillment/types";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(type); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateFulfillmentTypeStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateFulfillmentTypeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateFulfillmentTypeStartTime, "CreateFulfillmentType", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateFulfillmentTypeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateFulfillmentType: " + response.Error);
            }

            CreateFulfillmentTypeData = (FulfillmentType) KnetikClient.Deserialize(response.Content, typeof(FulfillmentType), response.Headers);
            KnetikLogger.LogResponse(mCreateFulfillmentTypeStartTime, "CreateFulfillmentType", string.Format("Response received successfully:\n{0}", CreateFulfillmentTypeData));

            if (CreateFulfillmentTypeComplete != null)
            {
                CreateFulfillmentTypeComplete(response.ResponseCode, CreateFulfillmentTypeData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a fulfillment type &lt;b&gt;Permissions Needed:&lt;/b&gt; FULFILLMENT_ADMIN
        /// </summary>
        /// <param name="id">The id</param>
        public void DeleteFulfillmentType(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteFulfillmentType");
            }
            
            mWebCallEvent.WebPath = "/store/fulfillment/types/{id}";
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
            mDeleteFulfillmentTypeStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteFulfillmentTypeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteFulfillmentTypeStartTime, "DeleteFulfillmentType", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteFulfillmentTypeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteFulfillmentType: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteFulfillmentTypeStartTime, "DeleteFulfillmentType", "Response received successfully.");
            if (DeleteFulfillmentTypeComplete != null)
            {
                DeleteFulfillmentTypeComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single fulfillment type &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id</param>
        public void GetFulfillmentType(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetFulfillmentType");
            }
            
            mWebCallEvent.WebPath = "/store/fulfillment/types/{id}";
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
            mGetFulfillmentTypeStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetFulfillmentTypeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetFulfillmentTypeStartTime, "GetFulfillmentType", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetFulfillmentTypeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetFulfillmentType: " + response.Error);
            }

            GetFulfillmentTypeData = (FulfillmentType) KnetikClient.Deserialize(response.Content, typeof(FulfillmentType), response.Headers);
            KnetikLogger.LogResponse(mGetFulfillmentTypeStartTime, "GetFulfillmentType", string.Format("Response received successfully:\n{0}", GetFulfillmentTypeData));

            if (GetFulfillmentTypeComplete != null)
            {
                GetFulfillmentTypeComplete(response.ResponseCode, GetFulfillmentTypeData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search fulfillment types &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetFulfillmentTypes(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/store/fulfillment/types";
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
            mGetFulfillmentTypesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetFulfillmentTypesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetFulfillmentTypesStartTime, "GetFulfillmentTypes", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetFulfillmentTypesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetFulfillmentTypes: " + response.Error);
            }

            GetFulfillmentTypesData = (PageResourceFulfillmentType) KnetikClient.Deserialize(response.Content, typeof(PageResourceFulfillmentType), response.Headers);
            KnetikLogger.LogResponse(mGetFulfillmentTypesStartTime, "GetFulfillmentTypes", string.Format("Response received successfully:\n{0}", GetFulfillmentTypesData));

            if (GetFulfillmentTypesComplete != null)
            {
                GetFulfillmentTypesComplete(response.ResponseCode, GetFulfillmentTypesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a fulfillment type &lt;b&gt;Permissions Needed:&lt;/b&gt; FULFILLMENT_ADMIN
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="fulfillmentType">The fulfillment type</param>
        public void UpdateFulfillmentType(int? id, FulfillmentType fulfillmentType)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateFulfillmentType");
            }
            
            mWebCallEvent.WebPath = "/store/fulfillment/types/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(fulfillmentType); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateFulfillmentTypeStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateFulfillmentTypeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateFulfillmentTypeStartTime, "UpdateFulfillmentType", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateFulfillmentTypeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateFulfillmentType: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateFulfillmentTypeStartTime, "UpdateFulfillmentType", "Response received successfully.");
            if (UpdateFulfillmentTypeComplete != null)
            {
                UpdateFulfillmentTypeComplete(response.ResponseCode);
            }
        }

    }
}
