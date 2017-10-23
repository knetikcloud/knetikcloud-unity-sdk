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
    public interface IDispositionsApi
    {
        DispositionResource AddDispositionData { get; }

        DispositionResource GetDispositionData { get; }

        List<DispositionCount> GetDispositionCountsData { get; }

        PageResourceDispositionResource GetDispositionsData { get; }

        
        /// <summary>
        /// Add a new disposition 
        /// </summary>
        /// <param name="disposition">The new disposition record</param>
        void AddDisposition(DispositionResource disposition);

        /// <summary>
        /// Delete a disposition 
        /// </summary>
        /// <param name="id">The id of the disposition record</param>
        void DeleteDisposition(long? id);

        /// <summary>
        /// Returns a disposition 
        /// </summary>
        /// <param name="id">The id of the disposition record</param>
        void GetDisposition(long? id);

        /// <summary>
        /// Returns a list of disposition counts 
        /// </summary>
        /// <param name="filterContext">Filter for dispositions within a context type (games, articles, polls, etc). Optionally with a specific id like filter_context&#x3D;video:47</param>
        /// <param name="filterOwner">Filter for dispositions from a specific user by id or &#39;me&#39;</param>
        void GetDispositionCounts(string filterContext, string filterOwner);

        /// <summary>
        /// Returns a page of dispositions 
        /// </summary>
        /// <param name="filterContext">Filter for dispositions within a context type (games, articles, polls, etc). Optionally with a specific id like filter_context&#x3D;video:47</param>
        /// <param name="filterOwner">Filter for dispositions from a specific user by id or &#39;me&#39;</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetDispositions(string filterContext, string filterOwner, int? size, int? page, string order);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DispositionsApi : IDispositionsApi
    {
        private readonly KnetikCoroutine mAddDispositionCoroutine;
        private DateTime mAddDispositionStartTime;
        private string mAddDispositionPath;
        private readonly KnetikCoroutine mDeleteDispositionCoroutine;
        private DateTime mDeleteDispositionStartTime;
        private string mDeleteDispositionPath;
        private readonly KnetikCoroutine mGetDispositionCoroutine;
        private DateTime mGetDispositionStartTime;
        private string mGetDispositionPath;
        private readonly KnetikCoroutine mGetDispositionCountsCoroutine;
        private DateTime mGetDispositionCountsStartTime;
        private string mGetDispositionCountsPath;
        private readonly KnetikCoroutine mGetDispositionsCoroutine;
        private DateTime mGetDispositionsStartTime;
        private string mGetDispositionsPath;

        public DispositionResource AddDispositionData { get; private set; }
        public delegate void AddDispositionCompleteDelegate(DispositionResource response);
        public AddDispositionCompleteDelegate AddDispositionComplete;

        public delegate void DeleteDispositionCompleteDelegate();
        public DeleteDispositionCompleteDelegate DeleteDispositionComplete;

        public DispositionResource GetDispositionData { get; private set; }
        public delegate void GetDispositionCompleteDelegate(DispositionResource response);
        public GetDispositionCompleteDelegate GetDispositionComplete;

        public List<DispositionCount> GetDispositionCountsData { get; private set; }
        public delegate void GetDispositionCountsCompleteDelegate(List<DispositionCount> response);
        public GetDispositionCountsCompleteDelegate GetDispositionCountsComplete;

        public PageResourceDispositionResource GetDispositionsData { get; private set; }
        public delegate void GetDispositionsCompleteDelegate(PageResourceDispositionResource response);
        public GetDispositionsCompleteDelegate GetDispositionsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="DispositionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DispositionsApi()
        {
            mAddDispositionCoroutine = new KnetikCoroutine();
            mDeleteDispositionCoroutine = new KnetikCoroutine();
            mGetDispositionCoroutine = new KnetikCoroutine();
            mGetDispositionCountsCoroutine = new KnetikCoroutine();
            mGetDispositionsCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a new disposition 
        /// </summary>
        /// <param name="disposition">The new disposition record</param>
        public void AddDisposition(DispositionResource disposition)
        {
            
            mAddDispositionPath = "/dispositions";
            if (!string.IsNullOrEmpty(mAddDispositionPath))
            {
                mAddDispositionPath = mAddDispositionPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(disposition); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddDispositionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddDispositionStartTime, mAddDispositionPath, "Sending server request...");

            // make the HTTP request
            mAddDispositionCoroutine.ResponseReceived += AddDispositionCallback;
            mAddDispositionCoroutine.Start(mAddDispositionPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddDispositionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddDisposition: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddDisposition: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddDispositionData = (DispositionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(DispositionResource), response.Headers);
            KnetikLogger.LogResponse(mAddDispositionStartTime, mAddDispositionPath, string.Format("Response received successfully:\n{0}", AddDispositionData.ToString()));

            if (AddDispositionComplete != null)
            {
                AddDispositionComplete(AddDispositionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a disposition 
        /// </summary>
        /// <param name="id">The id of the disposition record</param>
        public void DeleteDisposition(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteDisposition");
            }
            
            mDeleteDispositionPath = "/dispositions/{id}";
            if (!string.IsNullOrEmpty(mDeleteDispositionPath))
            {
                mDeleteDispositionPath = mDeleteDispositionPath.Replace("{format}", "json");
            }
            mDeleteDispositionPath = mDeleteDispositionPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteDispositionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteDispositionStartTime, mDeleteDispositionPath, "Sending server request...");

            // make the HTTP request
            mDeleteDispositionCoroutine.ResponseReceived += DeleteDispositionCallback;
            mDeleteDispositionCoroutine.Start(mDeleteDispositionPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteDispositionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteDisposition: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteDisposition: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteDispositionStartTime, mDeleteDispositionPath, "Response received successfully.");
            if (DeleteDispositionComplete != null)
            {
                DeleteDispositionComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a disposition 
        /// </summary>
        /// <param name="id">The id of the disposition record</param>
        public void GetDisposition(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetDisposition");
            }
            
            mGetDispositionPath = "/dispositions/{id}";
            if (!string.IsNullOrEmpty(mGetDispositionPath))
            {
                mGetDispositionPath = mGetDispositionPath.Replace("{format}", "json");
            }
            mGetDispositionPath = mGetDispositionPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetDispositionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetDispositionStartTime, mGetDispositionPath, "Sending server request...");

            // make the HTTP request
            mGetDispositionCoroutine.ResponseReceived += GetDispositionCallback;
            mGetDispositionCoroutine.Start(mGetDispositionPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetDispositionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDisposition: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDisposition: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetDispositionData = (DispositionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(DispositionResource), response.Headers);
            KnetikLogger.LogResponse(mGetDispositionStartTime, mGetDispositionPath, string.Format("Response received successfully:\n{0}", GetDispositionData.ToString()));

            if (GetDispositionComplete != null)
            {
                GetDispositionComplete(GetDispositionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a list of disposition counts 
        /// </summary>
        /// <param name="filterContext">Filter for dispositions within a context type (games, articles, polls, etc). Optionally with a specific id like filter_context&#x3D;video:47</param>
        /// <param name="filterOwner">Filter for dispositions from a specific user by id or &#39;me&#39;</param>
        public void GetDispositionCounts(string filterContext, string filterOwner)
        {
            
            mGetDispositionCountsPath = "/dispositions/count";
            if (!string.IsNullOrEmpty(mGetDispositionCountsPath))
            {
                mGetDispositionCountsPath = mGetDispositionCountsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterContext != null)
            {
                queryParams.Add("filter_context", KnetikClient.DefaultClient.ParameterToString(filterContext));
            }

            if (filterOwner != null)
            {
                queryParams.Add("filter_owner", KnetikClient.DefaultClient.ParameterToString(filterOwner));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetDispositionCountsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetDispositionCountsStartTime, mGetDispositionCountsPath, "Sending server request...");

            // make the HTTP request
            mGetDispositionCountsCoroutine.ResponseReceived += GetDispositionCountsCallback;
            mGetDispositionCountsCoroutine.Start(mGetDispositionCountsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetDispositionCountsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDispositionCounts: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDispositionCounts: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetDispositionCountsData = (List<DispositionCount>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<DispositionCount>), response.Headers);
            KnetikLogger.LogResponse(mGetDispositionCountsStartTime, mGetDispositionCountsPath, string.Format("Response received successfully:\n{0}", GetDispositionCountsData.ToString()));

            if (GetDispositionCountsComplete != null)
            {
                GetDispositionCountsComplete(GetDispositionCountsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a page of dispositions 
        /// </summary>
        /// <param name="filterContext">Filter for dispositions within a context type (games, articles, polls, etc). Optionally with a specific id like filter_context&#x3D;video:47</param>
        /// <param name="filterOwner">Filter for dispositions from a specific user by id or &#39;me&#39;</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetDispositions(string filterContext, string filterOwner, int? size, int? page, string order)
        {
            
            mGetDispositionsPath = "/dispositions";
            if (!string.IsNullOrEmpty(mGetDispositionsPath))
            {
                mGetDispositionsPath = mGetDispositionsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterContext != null)
            {
                queryParams.Add("filter_context", KnetikClient.DefaultClient.ParameterToString(filterContext));
            }

            if (filterOwner != null)
            {
                queryParams.Add("filter_owner", KnetikClient.DefaultClient.ParameterToString(filterOwner));
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetDispositionsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetDispositionsStartTime, mGetDispositionsPath, "Sending server request...");

            // make the HTTP request
            mGetDispositionsCoroutine.ResponseReceived += GetDispositionsCallback;
            mGetDispositionsCoroutine.Start(mGetDispositionsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetDispositionsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDispositions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDispositions: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetDispositionsData = (PageResourceDispositionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceDispositionResource), response.Headers);
            KnetikLogger.LogResponse(mGetDispositionsStartTime, mGetDispositionsPath, string.Format("Response received successfully:\n{0}", GetDispositionsData.ToString()));

            if (GetDispositionsComplete != null)
            {
                GetDispositionsComplete(GetDispositionsData);
            }
        }

    }
}
