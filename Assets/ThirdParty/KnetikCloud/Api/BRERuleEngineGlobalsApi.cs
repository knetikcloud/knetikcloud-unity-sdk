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
    public interface IBRERuleEngineGlobalsApi
    {
        BreGlobalResource CreateBREGlobalData { get; }

        BreGlobalResource GetBREGlobalData { get; }

        PageResourceBreGlobalResource GetBREGlobalsData { get; }

        BreGlobalResource UpdateBREGlobalData { get; }

        
        /// <summary>
        /// Create a global definition Once created you can then use in a custom rule. Note that global definitions cannot be modified or deleted if in use.
        /// </summary>
        /// <param name="breGlobalResource">The BRE global resource object</param>
        void CreateBREGlobal(BreGlobalResource breGlobalResource);

        /// <summary>
        /// Delete a global May fail if there are existing rules against it. Cannot delete core globals
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        void DeleteBREGlobal(string id);

        /// <summary>
        /// Get a single global definition 
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        void GetBREGlobal(string id);

        /// <summary>
        /// List global definitions 
        /// </summary>
        /// <param name="filterSystem">Filter for globals that are system globals when true, or not when false. Leave off for both mixed</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetBREGlobals(bool? filterSystem, int? size, int? page);

        /// <summary>
        /// Update a global definition May fail if new parameters mismatch requirements of existing rules. Cannot update core globals
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        /// <param name="breGlobalResource">The BRE global resource object</param>
        void UpdateBREGlobal(string id, BreGlobalResource breGlobalResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineGlobalsApi : IBRERuleEngineGlobalsApi
    {
        private readonly KnetikCoroutine mCreateBREGlobalCoroutine;
        private DateTime mCreateBREGlobalStartTime;
        private string mCreateBREGlobalPath;
        private readonly KnetikCoroutine mDeleteBREGlobalCoroutine;
        private DateTime mDeleteBREGlobalStartTime;
        private string mDeleteBREGlobalPath;
        private readonly KnetikCoroutine mGetBREGlobalCoroutine;
        private DateTime mGetBREGlobalStartTime;
        private string mGetBREGlobalPath;
        private readonly KnetikCoroutine mGetBREGlobalsCoroutine;
        private DateTime mGetBREGlobalsStartTime;
        private string mGetBREGlobalsPath;
        private readonly KnetikCoroutine mUpdateBREGlobalCoroutine;
        private DateTime mUpdateBREGlobalStartTime;
        private string mUpdateBREGlobalPath;

        public BreGlobalResource CreateBREGlobalData { get; private set; }
        public delegate void CreateBREGlobalCompleteDelegate(BreGlobalResource response);
        public CreateBREGlobalCompleteDelegate CreateBREGlobalComplete;

        public delegate void DeleteBREGlobalCompleteDelegate();
        public DeleteBREGlobalCompleteDelegate DeleteBREGlobalComplete;

        public BreGlobalResource GetBREGlobalData { get; private set; }
        public delegate void GetBREGlobalCompleteDelegate(BreGlobalResource response);
        public GetBREGlobalCompleteDelegate GetBREGlobalComplete;

        public PageResourceBreGlobalResource GetBREGlobalsData { get; private set; }
        public delegate void GetBREGlobalsCompleteDelegate(PageResourceBreGlobalResource response);
        public GetBREGlobalsCompleteDelegate GetBREGlobalsComplete;

        public BreGlobalResource UpdateBREGlobalData { get; private set; }
        public delegate void UpdateBREGlobalCompleteDelegate(BreGlobalResource response);
        public UpdateBREGlobalCompleteDelegate UpdateBREGlobalComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineGlobalsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineGlobalsApi()
        {
            mCreateBREGlobalCoroutine = new KnetikCoroutine();
            mDeleteBREGlobalCoroutine = new KnetikCoroutine();
            mGetBREGlobalCoroutine = new KnetikCoroutine();
            mGetBREGlobalsCoroutine = new KnetikCoroutine();
            mUpdateBREGlobalCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a global definition Once created you can then use in a custom rule. Note that global definitions cannot be modified or deleted if in use.
        /// </summary>
        /// <param name="breGlobalResource">The BRE global resource object</param>
        public void CreateBREGlobal(BreGlobalResource breGlobalResource)
        {
            
            mCreateBREGlobalPath = "/bre/globals/definitions";
            if (!string.IsNullOrEmpty(mCreateBREGlobalPath))
            {
                mCreateBREGlobalPath = mCreateBREGlobalPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(breGlobalResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateBREGlobalStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateBREGlobalStartTime, mCreateBREGlobalPath, "Sending server request...");

            // make the HTTP request
            mCreateBREGlobalCoroutine.ResponseReceived += CreateBREGlobalCallback;
            mCreateBREGlobalCoroutine.Start(mCreateBREGlobalPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateBREGlobalCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateBREGlobal: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateBREGlobal: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateBREGlobalData = (BreGlobalResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(BreGlobalResource), response.Headers);
            KnetikLogger.LogResponse(mCreateBREGlobalStartTime, mCreateBREGlobalPath, string.Format("Response received successfully:\n{0}", CreateBREGlobalData.ToString()));

            if (CreateBREGlobalComplete != null)
            {
                CreateBREGlobalComplete(CreateBREGlobalData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Delete a global May fail if there are existing rules against it. Cannot delete core globals
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        public void DeleteBREGlobal(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteBREGlobal");
            }
            
            mDeleteBREGlobalPath = "/bre/globals/definitions/{id}";
            if (!string.IsNullOrEmpty(mDeleteBREGlobalPath))
            {
                mDeleteBREGlobalPath = mDeleteBREGlobalPath.Replace("{format}", "json");
            }
            mDeleteBREGlobalPath = mDeleteBREGlobalPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteBREGlobalStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteBREGlobalStartTime, mDeleteBREGlobalPath, "Sending server request...");

            // make the HTTP request
            mDeleteBREGlobalCoroutine.ResponseReceived += DeleteBREGlobalCallback;
            mDeleteBREGlobalCoroutine.Start(mDeleteBREGlobalPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteBREGlobalCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteBREGlobal: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteBREGlobal: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteBREGlobalStartTime, mDeleteBREGlobalPath, "Response received successfully.");
            if (DeleteBREGlobalComplete != null)
            {
                DeleteBREGlobalComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Get a single global definition 
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        public void GetBREGlobal(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBREGlobal");
            }
            
            mGetBREGlobalPath = "/bre/globals/definitions/{id}";
            if (!string.IsNullOrEmpty(mGetBREGlobalPath))
            {
                mGetBREGlobalPath = mGetBREGlobalPath.Replace("{format}", "json");
            }
            mGetBREGlobalPath = mGetBREGlobalPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBREGlobalStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBREGlobalStartTime, mGetBREGlobalPath, "Sending server request...");

            // make the HTTP request
            mGetBREGlobalCoroutine.ResponseReceived += GetBREGlobalCallback;
            mGetBREGlobalCoroutine.Start(mGetBREGlobalPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBREGlobalCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREGlobal: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREGlobal: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBREGlobalData = (BreGlobalResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(BreGlobalResource), response.Headers);
            KnetikLogger.LogResponse(mGetBREGlobalStartTime, mGetBREGlobalPath, string.Format("Response received successfully:\n{0}", GetBREGlobalData.ToString()));

            if (GetBREGlobalComplete != null)
            {
                GetBREGlobalComplete(GetBREGlobalData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// List global definitions 
        /// </summary>
        /// <param name="filterSystem">Filter for globals that are system globals when true, or not when false. Leave off for both mixed</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetBREGlobals(bool? filterSystem, int? size, int? page)
        {
            
            mGetBREGlobalsPath = "/bre/globals/definitions";
            if (!string.IsNullOrEmpty(mGetBREGlobalsPath))
            {
                mGetBREGlobalsPath = mGetBREGlobalsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterSystem != null)
            {
                queryParams.Add("filter_system", KnetikClient.DefaultClient.ParameterToString(filterSystem));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBREGlobalsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBREGlobalsStartTime, mGetBREGlobalsPath, "Sending server request...");

            // make the HTTP request
            mGetBREGlobalsCoroutine.ResponseReceived += GetBREGlobalsCallback;
            mGetBREGlobalsCoroutine.Start(mGetBREGlobalsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBREGlobalsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREGlobals: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREGlobals: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBREGlobalsData = (PageResourceBreGlobalResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceBreGlobalResource), response.Headers);
            KnetikLogger.LogResponse(mGetBREGlobalsStartTime, mGetBREGlobalsPath, string.Format("Response received successfully:\n{0}", GetBREGlobalsData.ToString()));

            if (GetBREGlobalsComplete != null)
            {
                GetBREGlobalsComplete(GetBREGlobalsData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Update a global definition May fail if new parameters mismatch requirements of existing rules. Cannot update core globals
        /// </summary>
        /// <param name="id">The id of the global definition</param>
        /// <param name="breGlobalResource">The BRE global resource object</param>
        public void UpdateBREGlobal(string id, BreGlobalResource breGlobalResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateBREGlobal");
            }
            
            mUpdateBREGlobalPath = "/bre/globals/definitions/{id}";
            if (!string.IsNullOrEmpty(mUpdateBREGlobalPath))
            {
                mUpdateBREGlobalPath = mUpdateBREGlobalPath.Replace("{format}", "json");
            }
            mUpdateBREGlobalPath = mUpdateBREGlobalPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(breGlobalResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateBREGlobalStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateBREGlobalStartTime, mUpdateBREGlobalPath, "Sending server request...");

            // make the HTTP request
            mUpdateBREGlobalCoroutine.ResponseReceived += UpdateBREGlobalCallback;
            mUpdateBREGlobalCoroutine.Start(mUpdateBREGlobalPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateBREGlobalCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBREGlobal: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBREGlobal: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateBREGlobalData = (BreGlobalResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(BreGlobalResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateBREGlobalStartTime, mUpdateBREGlobalPath, string.Format("Response received successfully:\n{0}", UpdateBREGlobalData.ToString()));

            if (UpdateBREGlobalComplete != null)
            {
                UpdateBREGlobalComplete(UpdateBREGlobalData);
            }
        }
    }
}
