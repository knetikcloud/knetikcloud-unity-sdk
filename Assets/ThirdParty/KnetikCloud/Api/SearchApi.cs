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
    public interface ISearchApi
    {
        PageResourceMapstringobject SearchIndexData { get; }

        
        /// <summary>
        /// Add a new object to an index Mainly intended for internal use.
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The ID of the object</param>
        /// <param name="_object">The object to add</param>
        void AddSearchIndex(string type, string id, Object _object);

        /// <summary>
        /// Register reference mappings Add a new type mapping to connect data from one index to another, or discover an exsting one. Mainly intended for internal use.
        /// </summary>
        /// <param name="mappings">The mappings to add</param>
        void AddSearchMappings(List<SearchReferenceMapping> mappings);

        /// <summary>
        /// Delete an object Mainly intended for internal use. Requires SEARCH_ADMIN.
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The ID of the object to delete</param>
        void DeleteSearchIndex(string type, string id);

        /// <summary>
        /// Delete all objects in an index Mainly intended for internal use
        /// </summary>
        /// <param name="type">The index type</param>
        void DeleteSearchIndexes(string type);

        /// <summary>
        /// Search an index The body is an ElasticSearch query in JSON format. Please see their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/query-dsl.html&#39;&gt;documentation&lt;/a&gt; for details on the format and search options. The searchable object&#39;s format depends on on the type. See individual search endpoints on other resources for details on their format.
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="query">The query to be used for the search</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void SearchIndex(string type, Object query, int? size, int? page);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class SearchApi : ISearchApi
    {
        private readonly KnetikCoroutine mAddSearchIndexCoroutine;
        private DateTime mAddSearchIndexStartTime;
        private string mAddSearchIndexPath;
        private readonly KnetikCoroutine mAddSearchMappingsCoroutine;
        private DateTime mAddSearchMappingsStartTime;
        private string mAddSearchMappingsPath;
        private readonly KnetikCoroutine mDeleteSearchIndexCoroutine;
        private DateTime mDeleteSearchIndexStartTime;
        private string mDeleteSearchIndexPath;
        private readonly KnetikCoroutine mDeleteSearchIndexesCoroutine;
        private DateTime mDeleteSearchIndexesStartTime;
        private string mDeleteSearchIndexesPath;
        private readonly KnetikCoroutine mSearchIndexCoroutine;
        private DateTime mSearchIndexStartTime;
        private string mSearchIndexPath;

        public delegate void AddSearchIndexCompleteDelegate();
        public AddSearchIndexCompleteDelegate AddSearchIndexComplete;

        public delegate void AddSearchMappingsCompleteDelegate();
        public AddSearchMappingsCompleteDelegate AddSearchMappingsComplete;

        public delegate void DeleteSearchIndexCompleteDelegate();
        public DeleteSearchIndexCompleteDelegate DeleteSearchIndexComplete;

        public delegate void DeleteSearchIndexesCompleteDelegate();
        public DeleteSearchIndexesCompleteDelegate DeleteSearchIndexesComplete;

        public PageResourceMapstringobject SearchIndexData { get; private set; }
        public delegate void SearchIndexCompleteDelegate(PageResourceMapstringobject response);
        public SearchIndexCompleteDelegate SearchIndexComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SearchApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
            mAddSearchIndexCoroutine = new KnetikCoroutine(KnetikClient);
            mAddSearchMappingsCoroutine = new KnetikCoroutine(KnetikClient);
            mDeleteSearchIndexCoroutine = new KnetikCoroutine(KnetikClient);
            mDeleteSearchIndexesCoroutine = new KnetikCoroutine(KnetikClient);
            mSearchIndexCoroutine = new KnetikCoroutine(KnetikClient);
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient { get; private set; }

        /// <summary>
        /// Add a new object to an index Mainly intended for internal use.
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The ID of the object</param>
        /// <param name="_object">The object to add</param>
        public void AddSearchIndex(string type, string id, Object _object)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling AddSearchIndex");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddSearchIndex");
            }
            
            mAddSearchIndexPath = "/search/index/{type}/{id}";
            if (!string.IsNullOrEmpty(mAddSearchIndexPath))
            {
                mAddSearchIndexPath = mAddSearchIndexPath.Replace("{format}", "json");
            }
            mAddSearchIndexPath = mAddSearchIndexPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
mAddSearchIndexPath = mAddSearchIndexPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(_object); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddSearchIndexStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddSearchIndexStartTime, mAddSearchIndexPath, "Sending server request...");

            // make the HTTP request
            mAddSearchIndexCoroutine.ResponseReceived += AddSearchIndexCallback;
            mAddSearchIndexCoroutine.Start(mAddSearchIndexPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddSearchIndexCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddSearchIndex: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddSearchIndex: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mAddSearchIndexStartTime, mAddSearchIndexPath, "Response received successfully.");
            if (AddSearchIndexComplete != null)
            {
                AddSearchIndexComplete();
            }
        }
        /// <summary>
        /// Register reference mappings Add a new type mapping to connect data from one index to another, or discover an exsting one. Mainly intended for internal use.
        /// </summary>
        /// <param name="mappings">The mappings to add</param>
        public void AddSearchMappings(List<SearchReferenceMapping> mappings)
        {
            
            mAddSearchMappingsPath = "/search/mappings";
            if (!string.IsNullOrEmpty(mAddSearchMappingsPath))
            {
                mAddSearchMappingsPath = mAddSearchMappingsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(mappings); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddSearchMappingsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddSearchMappingsStartTime, mAddSearchMappingsPath, "Sending server request...");

            // make the HTTP request
            mAddSearchMappingsCoroutine.ResponseReceived += AddSearchMappingsCallback;
            mAddSearchMappingsCoroutine.Start(mAddSearchMappingsPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddSearchMappingsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddSearchMappings: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddSearchMappings: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mAddSearchMappingsStartTime, mAddSearchMappingsPath, "Response received successfully.");
            if (AddSearchMappingsComplete != null)
            {
                AddSearchMappingsComplete();
            }
        }
        /// <summary>
        /// Delete an object Mainly intended for internal use. Requires SEARCH_ADMIN.
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The ID of the object to delete</param>
        public void DeleteSearchIndex(string type, string id)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling DeleteSearchIndex");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteSearchIndex");
            }
            
            mDeleteSearchIndexPath = "/search/index/{type}/{id}";
            if (!string.IsNullOrEmpty(mDeleteSearchIndexPath))
            {
                mDeleteSearchIndexPath = mDeleteSearchIndexPath.Replace("{format}", "json");
            }
            mDeleteSearchIndexPath = mDeleteSearchIndexPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
mDeleteSearchIndexPath = mDeleteSearchIndexPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteSearchIndexStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteSearchIndexStartTime, mDeleteSearchIndexPath, "Sending server request...");

            // make the HTTP request
            mDeleteSearchIndexCoroutine.ResponseReceived += DeleteSearchIndexCallback;
            mDeleteSearchIndexCoroutine.Start(mDeleteSearchIndexPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteSearchIndexCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteSearchIndex: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteSearchIndex: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteSearchIndexStartTime, mDeleteSearchIndexPath, "Response received successfully.");
            if (DeleteSearchIndexComplete != null)
            {
                DeleteSearchIndexComplete();
            }
        }
        /// <summary>
        /// Delete all objects in an index Mainly intended for internal use
        /// </summary>
        /// <param name="type">The index type</param>
        public void DeleteSearchIndexes(string type)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling DeleteSearchIndexes");
            }
            
            mDeleteSearchIndexesPath = "/search/index/{type}";
            if (!string.IsNullOrEmpty(mDeleteSearchIndexesPath))
            {
                mDeleteSearchIndexesPath = mDeleteSearchIndexesPath.Replace("{format}", "json");
            }
            mDeleteSearchIndexesPath = mDeleteSearchIndexesPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteSearchIndexesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteSearchIndexesStartTime, mDeleteSearchIndexesPath, "Sending server request...");

            // make the HTTP request
            mDeleteSearchIndexesCoroutine.ResponseReceived += DeleteSearchIndexesCallback;
            mDeleteSearchIndexesCoroutine.Start(mDeleteSearchIndexesPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteSearchIndexesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteSearchIndexes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteSearchIndexes: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteSearchIndexesStartTime, mDeleteSearchIndexesPath, "Response received successfully.");
            if (DeleteSearchIndexesComplete != null)
            {
                DeleteSearchIndexesComplete();
            }
        }
        /// <summary>
        /// Search an index The body is an ElasticSearch query in JSON format. Please see their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/query-dsl.html&#39;&gt;documentation&lt;/a&gt; for details on the format and search options. The searchable object&#39;s format depends on on the type. See individual search endpoints on other resources for details on their format.
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="query">The query to be used for the search</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void SearchIndex(string type, Object query, int? size, int? page)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchIndex");
            }
            
            mSearchIndexPath = "/search/index/{type}";
            if (!string.IsNullOrEmpty(mSearchIndexPath))
            {
                mSearchIndexPath = mSearchIndexPath.Replace("{format}", "json");
            }
            mSearchIndexPath = mSearchIndexPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }

            postBody = KnetikClient.Serialize(query); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mSearchIndexStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSearchIndexStartTime, mSearchIndexPath, "Sending server request...");

            // make the HTTP request
            mSearchIndexCoroutine.ResponseReceived += SearchIndexCallback;
            mSearchIndexCoroutine.Start(mSearchIndexPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SearchIndexCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SearchIndex: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SearchIndex: " + response.ErrorMessage, response.ErrorMessage);
            }

            SearchIndexData = (PageResourceMapstringobject) KnetikClient.Deserialize(response.Content, typeof(PageResourceMapstringobject), response.Headers);
            KnetikLogger.LogResponse(mSearchIndexStartTime, mSearchIndexPath, string.Format("Response received successfully:\n{0}", SearchIndexData.ToString()));

            if (SearchIndexComplete != null)
            {
                SearchIndexComplete(SearchIndexData);
            }
        }
    }
}
