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
        /// Search an index The body is an ElasticSearch query in JSON format. Please see their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/query-dsl.html&#39;&gt;documentation&lt;/a&gt; for details on the format and search options. The searchable object&#39;s format depends on on the type but mostly matches the resource from it&#39;s main endpoint. Exceptions include referenced objects (like user) being replaced with the full user resource to allow deeper searching.
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="query">The query to be used for the search</param>
        /// <param name="size">The number of documents returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void SearchIndex(string type, Object query, int? size, int? page);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class SearchApi : ISearchApi
    {
        private readonly KnetikCoroutine mSearchIndexCoroutine;
        private DateTime mSearchIndexStartTime;
        private string mSearchIndexPath;

        public PageResourceMapstringobject SearchIndexData { get; private set; }
        public delegate void SearchIndexCompleteDelegate(PageResourceMapstringobject response);
        public SearchIndexCompleteDelegate SearchIndexComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SearchApi()
        {
            mSearchIndexCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Search an index The body is an ElasticSearch query in JSON format. Please see their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/query-dsl.html&#39;&gt;documentation&lt;/a&gt; for details on the format and search options. The searchable object&#39;s format depends on on the type but mostly matches the resource from it&#39;s main endpoint. Exceptions include referenced objects (like user) being replaced with the full user resource to allow deeper searching.
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="query">The query to be used for the search</param>
        /// <param name="size">The number of documents returned per page</param>
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
            mSearchIndexPath = mSearchIndexPath.Replace("{" + "type" + "}", KnetikClient.DefaultClient.ParameterToString(type));

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

            postBody = KnetikClient.DefaultClient.Serialize(query); // http body (model) parameter
 
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

            SearchIndexData = (PageResourceMapstringobject) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceMapstringobject), response.Headers);
            KnetikLogger.LogResponse(mSearchIndexStartTime, mSearchIndexPath, string.Format("Response received successfully:\n{0}", SearchIndexData.ToString()));

            if (SearchIndexComplete != null)
            {
                SearchIndexComplete(SearchIndexData);
            }
        }
    }
}
