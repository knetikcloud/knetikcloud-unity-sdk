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
    public interface IFulfillmentApi
    {
        FulfillmentType CreateFulfillmentTypeData { get; }

        FulfillmentType GetFulfillmentTypeData { get; }

        PageResourceFulfillmentType GetFulfillmentTypesData { get; }

        
        /// <summary>
        /// Create a fulfillment type 
        /// </summary>
        /// <param name="type">The fulfillment type</param>
        void CreateFulfillmentType(FulfillmentType type);

        /// <summary>
        /// Delete a fulfillment type 
        /// </summary>
        /// <param name="id">The id</param>
        void DeleteFulfillmentType(int? id);

        /// <summary>
        /// Get a single fulfillment type 
        /// </summary>
        /// <param name="id">The id</param>
        void GetFulfillmentType(int? id);

        /// <summary>
        /// List and search fulfillment types 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetFulfillmentTypes(int? size, int? page, string order);

        /// <summary>
        /// Update a fulfillment type 
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
        private readonly KnetikCoroutine mCreateFulfillmentTypeCoroutine;
        private DateTime mCreateFulfillmentTypeStartTime;
        private string mCreateFulfillmentTypePath;
        private readonly KnetikCoroutine mDeleteFulfillmentTypeCoroutine;
        private DateTime mDeleteFulfillmentTypeStartTime;
        private string mDeleteFulfillmentTypePath;
        private readonly KnetikCoroutine mGetFulfillmentTypeCoroutine;
        private DateTime mGetFulfillmentTypeStartTime;
        private string mGetFulfillmentTypePath;
        private readonly KnetikCoroutine mGetFulfillmentTypesCoroutine;
        private DateTime mGetFulfillmentTypesStartTime;
        private string mGetFulfillmentTypesPath;
        private readonly KnetikCoroutine mUpdateFulfillmentTypeCoroutine;
        private DateTime mUpdateFulfillmentTypeStartTime;
        private string mUpdateFulfillmentTypePath;

        public FulfillmentType CreateFulfillmentTypeData { get; private set; }
        public delegate void CreateFulfillmentTypeCompleteDelegate(FulfillmentType response);
        public CreateFulfillmentTypeCompleteDelegate CreateFulfillmentTypeComplete;

        public delegate void DeleteFulfillmentTypeCompleteDelegate();
        public DeleteFulfillmentTypeCompleteDelegate DeleteFulfillmentTypeComplete;

        public FulfillmentType GetFulfillmentTypeData { get; private set; }
        public delegate void GetFulfillmentTypeCompleteDelegate(FulfillmentType response);
        public GetFulfillmentTypeCompleteDelegate GetFulfillmentTypeComplete;

        public PageResourceFulfillmentType GetFulfillmentTypesData { get; private set; }
        public delegate void GetFulfillmentTypesCompleteDelegate(PageResourceFulfillmentType response);
        public GetFulfillmentTypesCompleteDelegate GetFulfillmentTypesComplete;

        public delegate void UpdateFulfillmentTypeCompleteDelegate();
        public UpdateFulfillmentTypeCompleteDelegate UpdateFulfillmentTypeComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="FulfillmentApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FulfillmentApi()
        {
            mCreateFulfillmentTypeCoroutine = new KnetikCoroutine();
            mDeleteFulfillmentTypeCoroutine = new KnetikCoroutine();
            mGetFulfillmentTypeCoroutine = new KnetikCoroutine();
            mGetFulfillmentTypesCoroutine = new KnetikCoroutine();
            mUpdateFulfillmentTypeCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a fulfillment type 
        /// </summary>
        /// <param name="type">The fulfillment type</param>
        public void CreateFulfillmentType(FulfillmentType type)
        {
            
            mCreateFulfillmentTypePath = "/store/fulfillment/types";
            if (!string.IsNullOrEmpty(mCreateFulfillmentTypePath))
            {
                mCreateFulfillmentTypePath = mCreateFulfillmentTypePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(type); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateFulfillmentTypeStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateFulfillmentTypeStartTime, mCreateFulfillmentTypePath, "Sending server request...");

            // make the HTTP request
            mCreateFulfillmentTypeCoroutine.ResponseReceived += CreateFulfillmentTypeCallback;
            mCreateFulfillmentTypeCoroutine.Start(mCreateFulfillmentTypePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateFulfillmentTypeCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateFulfillmentType: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateFulfillmentType: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateFulfillmentTypeData = (FulfillmentType) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(FulfillmentType), response.Headers);
            KnetikLogger.LogResponse(mCreateFulfillmentTypeStartTime, mCreateFulfillmentTypePath, string.Format("Response received successfully:\n{0}", CreateFulfillmentTypeData.ToString()));

            if (CreateFulfillmentTypeComplete != null)
            {
                CreateFulfillmentTypeComplete(CreateFulfillmentTypeData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a fulfillment type 
        /// </summary>
        /// <param name="id">The id</param>
        public void DeleteFulfillmentType(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteFulfillmentType");
            }
            
            mDeleteFulfillmentTypePath = "/store/fulfillment/types/{id}";
            if (!string.IsNullOrEmpty(mDeleteFulfillmentTypePath))
            {
                mDeleteFulfillmentTypePath = mDeleteFulfillmentTypePath.Replace("{format}", "json");
            }
            mDeleteFulfillmentTypePath = mDeleteFulfillmentTypePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteFulfillmentTypeStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteFulfillmentTypeStartTime, mDeleteFulfillmentTypePath, "Sending server request...");

            // make the HTTP request
            mDeleteFulfillmentTypeCoroutine.ResponseReceived += DeleteFulfillmentTypeCallback;
            mDeleteFulfillmentTypeCoroutine.Start(mDeleteFulfillmentTypePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteFulfillmentTypeCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteFulfillmentType: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteFulfillmentType: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteFulfillmentTypeStartTime, mDeleteFulfillmentTypePath, "Response received successfully.");
            if (DeleteFulfillmentTypeComplete != null)
            {
                DeleteFulfillmentTypeComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single fulfillment type 
        /// </summary>
        /// <param name="id">The id</param>
        public void GetFulfillmentType(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetFulfillmentType");
            }
            
            mGetFulfillmentTypePath = "/store/fulfillment/types/{id}";
            if (!string.IsNullOrEmpty(mGetFulfillmentTypePath))
            {
                mGetFulfillmentTypePath = mGetFulfillmentTypePath.Replace("{format}", "json");
            }
            mGetFulfillmentTypePath = mGetFulfillmentTypePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mGetFulfillmentTypeStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetFulfillmentTypeStartTime, mGetFulfillmentTypePath, "Sending server request...");

            // make the HTTP request
            mGetFulfillmentTypeCoroutine.ResponseReceived += GetFulfillmentTypeCallback;
            mGetFulfillmentTypeCoroutine.Start(mGetFulfillmentTypePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetFulfillmentTypeCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetFulfillmentType: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetFulfillmentType: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetFulfillmentTypeData = (FulfillmentType) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(FulfillmentType), response.Headers);
            KnetikLogger.LogResponse(mGetFulfillmentTypeStartTime, mGetFulfillmentTypePath, string.Format("Response received successfully:\n{0}", GetFulfillmentTypeData.ToString()));

            if (GetFulfillmentTypeComplete != null)
            {
                GetFulfillmentTypeComplete(GetFulfillmentTypeData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search fulfillment types 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetFulfillmentTypes(int? size, int? page, string order)
        {
            
            mGetFulfillmentTypesPath = "/store/fulfillment/types";
            if (!string.IsNullOrEmpty(mGetFulfillmentTypesPath))
            {
                mGetFulfillmentTypesPath = mGetFulfillmentTypesPath.Replace("{format}", "json");
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
            List<string> authSettings = new List<string> {  };

            mGetFulfillmentTypesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetFulfillmentTypesStartTime, mGetFulfillmentTypesPath, "Sending server request...");

            // make the HTTP request
            mGetFulfillmentTypesCoroutine.ResponseReceived += GetFulfillmentTypesCallback;
            mGetFulfillmentTypesCoroutine.Start(mGetFulfillmentTypesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetFulfillmentTypesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetFulfillmentTypes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetFulfillmentTypes: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetFulfillmentTypesData = (PageResourceFulfillmentType) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceFulfillmentType), response.Headers);
            KnetikLogger.LogResponse(mGetFulfillmentTypesStartTime, mGetFulfillmentTypesPath, string.Format("Response received successfully:\n{0}", GetFulfillmentTypesData.ToString()));

            if (GetFulfillmentTypesComplete != null)
            {
                GetFulfillmentTypesComplete(GetFulfillmentTypesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a fulfillment type 
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
            
            mUpdateFulfillmentTypePath = "/store/fulfillment/types/{id}";
            if (!string.IsNullOrEmpty(mUpdateFulfillmentTypePath))
            {
                mUpdateFulfillmentTypePath = mUpdateFulfillmentTypePath.Replace("{format}", "json");
            }
            mUpdateFulfillmentTypePath = mUpdateFulfillmentTypePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(fulfillmentType); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateFulfillmentTypeStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateFulfillmentTypeStartTime, mUpdateFulfillmentTypePath, "Sending server request...");

            // make the HTTP request
            mUpdateFulfillmentTypeCoroutine.ResponseReceived += UpdateFulfillmentTypeCallback;
            mUpdateFulfillmentTypeCoroutine.Start(mUpdateFulfillmentTypePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateFulfillmentTypeCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateFulfillmentType: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateFulfillmentType: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateFulfillmentTypeStartTime, mUpdateFulfillmentTypePath, "Response received successfully.");
            if (UpdateFulfillmentTypeComplete != null)
            {
                UpdateFulfillmentTypeComplete();
            }
        }

    }
}
