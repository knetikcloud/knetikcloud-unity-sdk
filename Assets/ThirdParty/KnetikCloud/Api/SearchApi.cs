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
    public interface ISearchApi
    {
        Object SearchCountGETData { get; }

        /// <summary>
        /// Count matches with no template This is a 1 to 1 mapping of a ElasticSearch call to _count.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        void SearchCountGET(string type);

        Object SearchCountPOSTData { get; }

        /// <summary>
        /// Count matches with no template This is a 1 to 1 mapping of a ElasticSearch call to _count.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="query">The query to be used for the search</param>
        void SearchCountPOST(string type, Object query);

        Object SearchCountWithTemplateGETData { get; }

        /// <summary>
        /// Count matches with a template This is a 1 to 1 mapping of a ElasticSearch call to _count.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        void SearchCountWithTemplateGET(string type, string template);

        Object SearchCountWithTemplatePOSTData { get; }

        /// <summary>
        /// Count matches with a template This is a 1 to 1 mapping of a ElasticSearch call to _count.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        /// <param name="query">The query to be used for the search</param>
        void SearchCountWithTemplatePOST(string type, string template, Object query);

        Object SearchDocumentGETData { get; }

        /// <summary>
        /// Get document with no template This is a 1 to 1 mapping of a ElasticSearch call.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The index id</param>
        void SearchDocumentGET(string type, string id);

        Object SearchDocumentWithTemplateGETData { get; }

        /// <summary>
        /// Get document with a template This is a 1 to 1 mapping of a ElasticSearch call.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The index id</param>
        /// <param name="template">The index template</param>
        void SearchDocumentWithTemplateGET(string type, string id, string template);

        Object SearchExplainGETData { get; }

        /// <summary>
        /// Explain matches with no template This is a 1 to 1 mapping of a ElasticSearch call to _explain.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The index id</param>
        void SearchExplainGET(string type, string id);

        Object SearchExplainPOSTData { get; }

        /// <summary>
        /// Explain matches with no template This is a 1 to 1 mapping of a ElasticSearch call to _explain.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The index id</param>
        /// <param name="query">The query to be used for the search</param>
        void SearchExplainPOST(string type, string id, Object query);

        Object SearchExplainWithTemplateGETData { get; }

        /// <summary>
        /// Explain matches with a template This is a 1 to 1 mapping of a ElasticSearch call to _explain.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The index id</param>
        /// <param name="template">The index template</param>
        void SearchExplainWithTemplateGET(string type, string id, string template);

        Object SearchExplainWithTemplatePOSTData { get; }

        /// <summary>
        /// Explain matches with a template This is a 1 to 1 mapping of a ElasticSearch call to _explain.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The index id</param>
        /// <param name="template">The index template</param>
        /// <param name="query">The query to be used for the search</param>
        void SearchExplainWithTemplatePOST(string type, string id, string template, Object query);

        Object SearchIndexData { get; }

        /// <summary>
        /// Search an index with no template This is a 1 to 1 mapping of a ElasticSearch call to _search.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="query">The query to be used for the search</param>
        void SearchIndex(string type, Object query);

        Object SearchIndexGETData { get; }

        /// <summary>
        /// Search an index with no template This is a 1 to 1 mapping of a ElasticSearch call to _search.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        void SearchIndexGET(string type);

        Object SearchIndexWithTemplateGETData { get; }

        /// <summary>
        /// Search an index with a template This is a 1 to 1 mapping of a ElasticSearch call to _search.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        void SearchIndexWithTemplateGET(string type, string template);

        Object SearchIndexWithTemplatePOSTData { get; }

        /// <summary>
        /// Search an index with a template This is a 1 to 1 mapping of a ElasticSearch call to _search.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        /// <param name="query">The query to be used for the search</param>
        void SearchIndexWithTemplatePOST(string type, string template, Object query);

        Object SearchIndicesGETData { get; }

        /// <summary>
        /// Get indices This is a 1 to 1 mapping of a ElasticSearch call to _cat/indices for indices.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/indices-get-mapping.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        void SearchIndicesGET();

        Object SearchMappingsGETData { get; }

        /// <summary>
        /// Get mapping with no template This is a 1 to 1 mapping of a ElasticSearch call to _mapping.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/indices-get-mapping.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        void SearchMappingsGET(string type);

        Object SearchMappingsWithTemplateGETData { get; }

        /// <summary>
        /// Get mapping with a template This is a 1 to 1 mapping of a ElasticSearch call to _mapping.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/indices-get-mapping.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        void SearchMappingsWithTemplateGET(string type, string template);

        Object SearchValidateGETData { get; }

        /// <summary>
        /// Validate matches with no template This is a 1 to 1 mapping of a ElasticSearch call to _validate/query.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-validate.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        void SearchValidateGET(string type);

        Object SearchValidatePOSTData { get; }

        /// <summary>
        /// Validate matches with no template This is a 1 to 1 mapping of a ElasticSearch call to _validate/query.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-validate.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="query">The query to be used for the search</param>
        void SearchValidatePOST(string type, Object query);

        Object SearchValidateWithTemplateGETData { get; }

        /// <summary>
        /// Validate matches with a template This is a 1 to 1 mapping of a ElasticSearch call to _validate/query.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-validate.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        void SearchValidateWithTemplateGET(string type, string template);

        Object SearchValidateWithTemplatePOSTData { get; }

        /// <summary>
        /// Validate matches with a template This is a 1 to 1 mapping of a ElasticSearch call to _validate/query.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-validate.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        /// <param name="query">The query to be used for the search</param>
        void SearchValidateWithTemplatePOST(string type, string template, Object query);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class SearchApi : ISearchApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mSearchCountGETResponseContext;
        private DateTime mSearchCountGETStartTime;
        private readonly KnetikResponseContext mSearchCountPOSTResponseContext;
        private DateTime mSearchCountPOSTStartTime;
        private readonly KnetikResponseContext mSearchCountWithTemplateGETResponseContext;
        private DateTime mSearchCountWithTemplateGETStartTime;
        private readonly KnetikResponseContext mSearchCountWithTemplatePOSTResponseContext;
        private DateTime mSearchCountWithTemplatePOSTStartTime;
        private readonly KnetikResponseContext mSearchDocumentGETResponseContext;
        private DateTime mSearchDocumentGETStartTime;
        private readonly KnetikResponseContext mSearchDocumentWithTemplateGETResponseContext;
        private DateTime mSearchDocumentWithTemplateGETStartTime;
        private readonly KnetikResponseContext mSearchExplainGETResponseContext;
        private DateTime mSearchExplainGETStartTime;
        private readonly KnetikResponseContext mSearchExplainPOSTResponseContext;
        private DateTime mSearchExplainPOSTStartTime;
        private readonly KnetikResponseContext mSearchExplainWithTemplateGETResponseContext;
        private DateTime mSearchExplainWithTemplateGETStartTime;
        private readonly KnetikResponseContext mSearchExplainWithTemplatePOSTResponseContext;
        private DateTime mSearchExplainWithTemplatePOSTStartTime;
        private readonly KnetikResponseContext mSearchIndexResponseContext;
        private DateTime mSearchIndexStartTime;
        private readonly KnetikResponseContext mSearchIndexGETResponseContext;
        private DateTime mSearchIndexGETStartTime;
        private readonly KnetikResponseContext mSearchIndexWithTemplateGETResponseContext;
        private DateTime mSearchIndexWithTemplateGETStartTime;
        private readonly KnetikResponseContext mSearchIndexWithTemplatePOSTResponseContext;
        private DateTime mSearchIndexWithTemplatePOSTStartTime;
        private readonly KnetikResponseContext mSearchIndicesGETResponseContext;
        private DateTime mSearchIndicesGETStartTime;
        private readonly KnetikResponseContext mSearchMappingsGETResponseContext;
        private DateTime mSearchMappingsGETStartTime;
        private readonly KnetikResponseContext mSearchMappingsWithTemplateGETResponseContext;
        private DateTime mSearchMappingsWithTemplateGETStartTime;
        private readonly KnetikResponseContext mSearchValidateGETResponseContext;
        private DateTime mSearchValidateGETStartTime;
        private readonly KnetikResponseContext mSearchValidatePOSTResponseContext;
        private DateTime mSearchValidatePOSTStartTime;
        private readonly KnetikResponseContext mSearchValidateWithTemplateGETResponseContext;
        private DateTime mSearchValidateWithTemplateGETStartTime;
        private readonly KnetikResponseContext mSearchValidateWithTemplatePOSTResponseContext;
        private DateTime mSearchValidateWithTemplatePOSTStartTime;

        public Object SearchCountGETData { get; private set; }
        public delegate void SearchCountGETCompleteDelegate(long responseCode, Object response);
        public SearchCountGETCompleteDelegate SearchCountGETComplete;

        public Object SearchCountPOSTData { get; private set; }
        public delegate void SearchCountPOSTCompleteDelegate(long responseCode, Object response);
        public SearchCountPOSTCompleteDelegate SearchCountPOSTComplete;

        public Object SearchCountWithTemplateGETData { get; private set; }
        public delegate void SearchCountWithTemplateGETCompleteDelegate(long responseCode, Object response);
        public SearchCountWithTemplateGETCompleteDelegate SearchCountWithTemplateGETComplete;

        public Object SearchCountWithTemplatePOSTData { get; private set; }
        public delegate void SearchCountWithTemplatePOSTCompleteDelegate(long responseCode, Object response);
        public SearchCountWithTemplatePOSTCompleteDelegate SearchCountWithTemplatePOSTComplete;

        public Object SearchDocumentGETData { get; private set; }
        public delegate void SearchDocumentGETCompleteDelegate(long responseCode, Object response);
        public SearchDocumentGETCompleteDelegate SearchDocumentGETComplete;

        public Object SearchDocumentWithTemplateGETData { get; private set; }
        public delegate void SearchDocumentWithTemplateGETCompleteDelegate(long responseCode, Object response);
        public SearchDocumentWithTemplateGETCompleteDelegate SearchDocumentWithTemplateGETComplete;

        public Object SearchExplainGETData { get; private set; }
        public delegate void SearchExplainGETCompleteDelegate(long responseCode, Object response);
        public SearchExplainGETCompleteDelegate SearchExplainGETComplete;

        public Object SearchExplainPOSTData { get; private set; }
        public delegate void SearchExplainPOSTCompleteDelegate(long responseCode, Object response);
        public SearchExplainPOSTCompleteDelegate SearchExplainPOSTComplete;

        public Object SearchExplainWithTemplateGETData { get; private set; }
        public delegate void SearchExplainWithTemplateGETCompleteDelegate(long responseCode, Object response);
        public SearchExplainWithTemplateGETCompleteDelegate SearchExplainWithTemplateGETComplete;

        public Object SearchExplainWithTemplatePOSTData { get; private set; }
        public delegate void SearchExplainWithTemplatePOSTCompleteDelegate(long responseCode, Object response);
        public SearchExplainWithTemplatePOSTCompleteDelegate SearchExplainWithTemplatePOSTComplete;

        public Object SearchIndexData { get; private set; }
        public delegate void SearchIndexCompleteDelegate(long responseCode, Object response);
        public SearchIndexCompleteDelegate SearchIndexComplete;

        public Object SearchIndexGETData { get; private set; }
        public delegate void SearchIndexGETCompleteDelegate(long responseCode, Object response);
        public SearchIndexGETCompleteDelegate SearchIndexGETComplete;

        public Object SearchIndexWithTemplateGETData { get; private set; }
        public delegate void SearchIndexWithTemplateGETCompleteDelegate(long responseCode, Object response);
        public SearchIndexWithTemplateGETCompleteDelegate SearchIndexWithTemplateGETComplete;

        public Object SearchIndexWithTemplatePOSTData { get; private set; }
        public delegate void SearchIndexWithTemplatePOSTCompleteDelegate(long responseCode, Object response);
        public SearchIndexWithTemplatePOSTCompleteDelegate SearchIndexWithTemplatePOSTComplete;

        public Object SearchIndicesGETData { get; private set; }
        public delegate void SearchIndicesGETCompleteDelegate(long responseCode, Object response);
        public SearchIndicesGETCompleteDelegate SearchIndicesGETComplete;

        public Object SearchMappingsGETData { get; private set; }
        public delegate void SearchMappingsGETCompleteDelegate(long responseCode, Object response);
        public SearchMappingsGETCompleteDelegate SearchMappingsGETComplete;

        public Object SearchMappingsWithTemplateGETData { get; private set; }
        public delegate void SearchMappingsWithTemplateGETCompleteDelegate(long responseCode, Object response);
        public SearchMappingsWithTemplateGETCompleteDelegate SearchMappingsWithTemplateGETComplete;

        public Object SearchValidateGETData { get; private set; }
        public delegate void SearchValidateGETCompleteDelegate(long responseCode, Object response);
        public SearchValidateGETCompleteDelegate SearchValidateGETComplete;

        public Object SearchValidatePOSTData { get; private set; }
        public delegate void SearchValidatePOSTCompleteDelegate(long responseCode, Object response);
        public SearchValidatePOSTCompleteDelegate SearchValidatePOSTComplete;

        public Object SearchValidateWithTemplateGETData { get; private set; }
        public delegate void SearchValidateWithTemplateGETCompleteDelegate(long responseCode, Object response);
        public SearchValidateWithTemplateGETCompleteDelegate SearchValidateWithTemplateGETComplete;

        public Object SearchValidateWithTemplatePOSTData { get; private set; }
        public delegate void SearchValidateWithTemplatePOSTCompleteDelegate(long responseCode, Object response);
        public SearchValidateWithTemplatePOSTCompleteDelegate SearchValidateWithTemplatePOSTComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SearchApi()
        {
            mSearchCountGETResponseContext = new KnetikResponseContext();
            mSearchCountGETResponseContext.ResponseReceived += OnSearchCountGETResponse;
            mSearchCountPOSTResponseContext = new KnetikResponseContext();
            mSearchCountPOSTResponseContext.ResponseReceived += OnSearchCountPOSTResponse;
            mSearchCountWithTemplateGETResponseContext = new KnetikResponseContext();
            mSearchCountWithTemplateGETResponseContext.ResponseReceived += OnSearchCountWithTemplateGETResponse;
            mSearchCountWithTemplatePOSTResponseContext = new KnetikResponseContext();
            mSearchCountWithTemplatePOSTResponseContext.ResponseReceived += OnSearchCountWithTemplatePOSTResponse;
            mSearchDocumentGETResponseContext = new KnetikResponseContext();
            mSearchDocumentGETResponseContext.ResponseReceived += OnSearchDocumentGETResponse;
            mSearchDocumentWithTemplateGETResponseContext = new KnetikResponseContext();
            mSearchDocumentWithTemplateGETResponseContext.ResponseReceived += OnSearchDocumentWithTemplateGETResponse;
            mSearchExplainGETResponseContext = new KnetikResponseContext();
            mSearchExplainGETResponseContext.ResponseReceived += OnSearchExplainGETResponse;
            mSearchExplainPOSTResponseContext = new KnetikResponseContext();
            mSearchExplainPOSTResponseContext.ResponseReceived += OnSearchExplainPOSTResponse;
            mSearchExplainWithTemplateGETResponseContext = new KnetikResponseContext();
            mSearchExplainWithTemplateGETResponseContext.ResponseReceived += OnSearchExplainWithTemplateGETResponse;
            mSearchExplainWithTemplatePOSTResponseContext = new KnetikResponseContext();
            mSearchExplainWithTemplatePOSTResponseContext.ResponseReceived += OnSearchExplainWithTemplatePOSTResponse;
            mSearchIndexResponseContext = new KnetikResponseContext();
            mSearchIndexResponseContext.ResponseReceived += OnSearchIndexResponse;
            mSearchIndexGETResponseContext = new KnetikResponseContext();
            mSearchIndexGETResponseContext.ResponseReceived += OnSearchIndexGETResponse;
            mSearchIndexWithTemplateGETResponseContext = new KnetikResponseContext();
            mSearchIndexWithTemplateGETResponseContext.ResponseReceived += OnSearchIndexWithTemplateGETResponse;
            mSearchIndexWithTemplatePOSTResponseContext = new KnetikResponseContext();
            mSearchIndexWithTemplatePOSTResponseContext.ResponseReceived += OnSearchIndexWithTemplatePOSTResponse;
            mSearchIndicesGETResponseContext = new KnetikResponseContext();
            mSearchIndicesGETResponseContext.ResponseReceived += OnSearchIndicesGETResponse;
            mSearchMappingsGETResponseContext = new KnetikResponseContext();
            mSearchMappingsGETResponseContext.ResponseReceived += OnSearchMappingsGETResponse;
            mSearchMappingsWithTemplateGETResponseContext = new KnetikResponseContext();
            mSearchMappingsWithTemplateGETResponseContext.ResponseReceived += OnSearchMappingsWithTemplateGETResponse;
            mSearchValidateGETResponseContext = new KnetikResponseContext();
            mSearchValidateGETResponseContext.ResponseReceived += OnSearchValidateGETResponse;
            mSearchValidatePOSTResponseContext = new KnetikResponseContext();
            mSearchValidatePOSTResponseContext.ResponseReceived += OnSearchValidatePOSTResponse;
            mSearchValidateWithTemplateGETResponseContext = new KnetikResponseContext();
            mSearchValidateWithTemplateGETResponseContext.ResponseReceived += OnSearchValidateWithTemplateGETResponse;
            mSearchValidateWithTemplatePOSTResponseContext = new KnetikResponseContext();
            mSearchValidateWithTemplatePOSTResponseContext.ResponseReceived += OnSearchValidateWithTemplatePOSTResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Count matches with no template This is a 1 to 1 mapping of a ElasticSearch call to _count.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        public void SearchCountGET(string type)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchCountGET");
            }
            
            mWebCallEvent.WebPath = "/search/count/{type}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchCountGETStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchCountGETResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchCountGETStartTime, "SearchCountGET", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchCountGETResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchCountGET: " + response.Error);
            }

            SearchCountGETData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchCountGETStartTime, "SearchCountGET", string.Format("Response received successfully:\n{0}", SearchCountGETData));

            if (SearchCountGETComplete != null)
            {
                SearchCountGETComplete(response.ResponseCode, SearchCountGETData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Count matches with no template This is a 1 to 1 mapping of a ElasticSearch call to _count.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="query">The query to be used for the search</param>
        public void SearchCountPOST(string type, Object query)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchCountPOST");
            }
            
            mWebCallEvent.WebPath = "/search/count/{type}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(query); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchCountPOSTStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchCountPOSTResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSearchCountPOSTStartTime, "SearchCountPOST", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchCountPOSTResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchCountPOST: " + response.Error);
            }

            SearchCountPOSTData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchCountPOSTStartTime, "SearchCountPOST", string.Format("Response received successfully:\n{0}", SearchCountPOSTData));

            if (SearchCountPOSTComplete != null)
            {
                SearchCountPOSTComplete(response.ResponseCode, SearchCountPOSTData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Count matches with a template This is a 1 to 1 mapping of a ElasticSearch call to _count.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        public void SearchCountWithTemplateGET(string type, string template)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchCountWithTemplateGET");
            }
            // verify the required parameter 'template' is set
            if (template == null)
            {
                throw new KnetikException(400, "Missing required parameter 'template' when calling SearchCountWithTemplateGET");
            }
            
            mWebCallEvent.WebPath = "/search/count/{type}/{template}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template" + "}", KnetikClient.ParameterToString(template));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchCountWithTemplateGETStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchCountWithTemplateGETResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchCountWithTemplateGETStartTime, "SearchCountWithTemplateGET", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchCountWithTemplateGETResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchCountWithTemplateGET: " + response.Error);
            }

            SearchCountWithTemplateGETData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchCountWithTemplateGETStartTime, "SearchCountWithTemplateGET", string.Format("Response received successfully:\n{0}", SearchCountWithTemplateGETData));

            if (SearchCountWithTemplateGETComplete != null)
            {
                SearchCountWithTemplateGETComplete(response.ResponseCode, SearchCountWithTemplateGETData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Count matches with a template This is a 1 to 1 mapping of a ElasticSearch call to _count.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        /// <param name="query">The query to be used for the search</param>
        public void SearchCountWithTemplatePOST(string type, string template, Object query)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchCountWithTemplatePOST");
            }
            // verify the required parameter 'template' is set
            if (template == null)
            {
                throw new KnetikException(400, "Missing required parameter 'template' when calling SearchCountWithTemplatePOST");
            }
            
            mWebCallEvent.WebPath = "/search/count/{type}/{template}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template" + "}", KnetikClient.ParameterToString(template));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(query); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchCountWithTemplatePOSTStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchCountWithTemplatePOSTResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSearchCountWithTemplatePOSTStartTime, "SearchCountWithTemplatePOST", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchCountWithTemplatePOSTResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchCountWithTemplatePOST: " + response.Error);
            }

            SearchCountWithTemplatePOSTData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchCountWithTemplatePOSTStartTime, "SearchCountWithTemplatePOST", string.Format("Response received successfully:\n{0}", SearchCountWithTemplatePOSTData));

            if (SearchCountWithTemplatePOSTComplete != null)
            {
                SearchCountWithTemplatePOSTComplete(response.ResponseCode, SearchCountWithTemplatePOSTData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get document with no template This is a 1 to 1 mapping of a ElasticSearch call.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The index id</param>
        public void SearchDocumentGET(string type, string id)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchDocumentGET");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SearchDocumentGET");
            }
            
            mWebCallEvent.WebPath = "/search/documents/{type}/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
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
            mSearchDocumentGETStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchDocumentGETResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchDocumentGETStartTime, "SearchDocumentGET", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchDocumentGETResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchDocumentGET: " + response.Error);
            }

            SearchDocumentGETData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchDocumentGETStartTime, "SearchDocumentGET", string.Format("Response received successfully:\n{0}", SearchDocumentGETData));

            if (SearchDocumentGETComplete != null)
            {
                SearchDocumentGETComplete(response.ResponseCode, SearchDocumentGETData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get document with a template This is a 1 to 1 mapping of a ElasticSearch call.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The index id</param>
        /// <param name="template">The index template</param>
        public void SearchDocumentWithTemplateGET(string type, string id, string template)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchDocumentWithTemplateGET");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SearchDocumentWithTemplateGET");
            }
            // verify the required parameter 'template' is set
            if (template == null)
            {
                throw new KnetikException(400, "Missing required parameter 'template' when calling SearchDocumentWithTemplateGET");
            }
            
            mWebCallEvent.WebPath = "/search/documents/{type}/{template}/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template" + "}", KnetikClient.ParameterToString(template));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchDocumentWithTemplateGETStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchDocumentWithTemplateGETResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchDocumentWithTemplateGETStartTime, "SearchDocumentWithTemplateGET", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchDocumentWithTemplateGETResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchDocumentWithTemplateGET: " + response.Error);
            }

            SearchDocumentWithTemplateGETData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchDocumentWithTemplateGETStartTime, "SearchDocumentWithTemplateGET", string.Format("Response received successfully:\n{0}", SearchDocumentWithTemplateGETData));

            if (SearchDocumentWithTemplateGETComplete != null)
            {
                SearchDocumentWithTemplateGETComplete(response.ResponseCode, SearchDocumentWithTemplateGETData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Explain matches with no template This is a 1 to 1 mapping of a ElasticSearch call to _explain.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The index id</param>
        public void SearchExplainGET(string type, string id)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchExplainGET");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SearchExplainGET");
            }
            
            mWebCallEvent.WebPath = "/search/explain/{type}/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
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
            mSearchExplainGETStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchExplainGETResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchExplainGETStartTime, "SearchExplainGET", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchExplainGETResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchExplainGET: " + response.Error);
            }

            SearchExplainGETData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchExplainGETStartTime, "SearchExplainGET", string.Format("Response received successfully:\n{0}", SearchExplainGETData));

            if (SearchExplainGETComplete != null)
            {
                SearchExplainGETComplete(response.ResponseCode, SearchExplainGETData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Explain matches with no template This is a 1 to 1 mapping of a ElasticSearch call to _explain.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The index id</param>
        /// <param name="query">The query to be used for the search</param>
        public void SearchExplainPOST(string type, string id, Object query)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchExplainPOST");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SearchExplainPOST");
            }
            
            mWebCallEvent.WebPath = "/search/explain/{type}/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(query); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchExplainPOSTStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchExplainPOSTResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSearchExplainPOSTStartTime, "SearchExplainPOST", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchExplainPOSTResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchExplainPOST: " + response.Error);
            }

            SearchExplainPOSTData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchExplainPOSTStartTime, "SearchExplainPOST", string.Format("Response received successfully:\n{0}", SearchExplainPOSTData));

            if (SearchExplainPOSTComplete != null)
            {
                SearchExplainPOSTComplete(response.ResponseCode, SearchExplainPOSTData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Explain matches with a template This is a 1 to 1 mapping of a ElasticSearch call to _explain.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The index id</param>
        /// <param name="template">The index template</param>
        public void SearchExplainWithTemplateGET(string type, string id, string template)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchExplainWithTemplateGET");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SearchExplainWithTemplateGET");
            }
            // verify the required parameter 'template' is set
            if (template == null)
            {
                throw new KnetikException(400, "Missing required parameter 'template' when calling SearchExplainWithTemplateGET");
            }
            
            mWebCallEvent.WebPath = "/search/explain/{type}/{template}/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template" + "}", KnetikClient.ParameterToString(template));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchExplainWithTemplateGETStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchExplainWithTemplateGETResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchExplainWithTemplateGETStartTime, "SearchExplainWithTemplateGET", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchExplainWithTemplateGETResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchExplainWithTemplateGET: " + response.Error);
            }

            SearchExplainWithTemplateGETData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchExplainWithTemplateGETStartTime, "SearchExplainWithTemplateGET", string.Format("Response received successfully:\n{0}", SearchExplainWithTemplateGETData));

            if (SearchExplainWithTemplateGETComplete != null)
            {
                SearchExplainWithTemplateGETComplete(response.ResponseCode, SearchExplainWithTemplateGETData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Explain matches with a template This is a 1 to 1 mapping of a ElasticSearch call to _explain.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-count.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="id">The index id</param>
        /// <param name="template">The index template</param>
        /// <param name="query">The query to be used for the search</param>
        public void SearchExplainWithTemplatePOST(string type, string id, string template, Object query)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchExplainWithTemplatePOST");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SearchExplainWithTemplatePOST");
            }
            // verify the required parameter 'template' is set
            if (template == null)
            {
                throw new KnetikException(400, "Missing required parameter 'template' when calling SearchExplainWithTemplatePOST");
            }
            
            mWebCallEvent.WebPath = "/search/explain/{type}/{template}/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template" + "}", KnetikClient.ParameterToString(template));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(query); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchExplainWithTemplatePOSTStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchExplainWithTemplatePOSTResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSearchExplainWithTemplatePOSTStartTime, "SearchExplainWithTemplatePOST", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchExplainWithTemplatePOSTResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchExplainWithTemplatePOST: " + response.Error);
            }

            SearchExplainWithTemplatePOSTData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchExplainWithTemplatePOSTStartTime, "SearchExplainWithTemplatePOST", string.Format("Response received successfully:\n{0}", SearchExplainWithTemplatePOSTData));

            if (SearchExplainWithTemplatePOSTComplete != null)
            {
                SearchExplainWithTemplatePOSTComplete(response.ResponseCode, SearchExplainWithTemplatePOSTData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Search an index with no template This is a 1 to 1 mapping of a ElasticSearch call to _search.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="query">The query to be used for the search</param>
        public void SearchIndex(string type, Object query)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchIndex");
            }
            
            mWebCallEvent.WebPath = "/search/index/{type}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(query); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchIndexStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchIndexResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSearchIndexStartTime, "SearchIndex", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchIndexResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchIndex: " + response.Error);
            }

            SearchIndexData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchIndexStartTime, "SearchIndex", string.Format("Response received successfully:\n{0}", SearchIndexData));

            if (SearchIndexComplete != null)
            {
                SearchIndexComplete(response.ResponseCode, SearchIndexData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Search an index with no template This is a 1 to 1 mapping of a ElasticSearch call to _search.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        public void SearchIndexGET(string type)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchIndexGET");
            }
            
            mWebCallEvent.WebPath = "/search/index/{type}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchIndexGETStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchIndexGETResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchIndexGETStartTime, "SearchIndexGET", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchIndexGETResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchIndexGET: " + response.Error);
            }

            SearchIndexGETData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchIndexGETStartTime, "SearchIndexGET", string.Format("Response received successfully:\n{0}", SearchIndexGETData));

            if (SearchIndexGETComplete != null)
            {
                SearchIndexGETComplete(response.ResponseCode, SearchIndexGETData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Search an index with a template This is a 1 to 1 mapping of a ElasticSearch call to _search.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        public void SearchIndexWithTemplateGET(string type, string template)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchIndexWithTemplateGET");
            }
            // verify the required parameter 'template' is set
            if (template == null)
            {
                throw new KnetikException(400, "Missing required parameter 'template' when calling SearchIndexWithTemplateGET");
            }
            
            mWebCallEvent.WebPath = "/search/index/{type}/{template}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template" + "}", KnetikClient.ParameterToString(template));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchIndexWithTemplateGETStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchIndexWithTemplateGETResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchIndexWithTemplateGETStartTime, "SearchIndexWithTemplateGET", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchIndexWithTemplateGETResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchIndexWithTemplateGET: " + response.Error);
            }

            SearchIndexWithTemplateGETData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchIndexWithTemplateGETStartTime, "SearchIndexWithTemplateGET", string.Format("Response received successfully:\n{0}", SearchIndexWithTemplateGETData));

            if (SearchIndexWithTemplateGETComplete != null)
            {
                SearchIndexWithTemplateGETComplete(response.ResponseCode, SearchIndexWithTemplateGETData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Search an index with a template This is a 1 to 1 mapping of a ElasticSearch call to _search.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        /// <param name="query">The query to be used for the search</param>
        public void SearchIndexWithTemplatePOST(string type, string template, Object query)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchIndexWithTemplatePOST");
            }
            // verify the required parameter 'template' is set
            if (template == null)
            {
                throw new KnetikException(400, "Missing required parameter 'template' when calling SearchIndexWithTemplatePOST");
            }
            
            mWebCallEvent.WebPath = "/search/index/{type}/{template}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template" + "}", KnetikClient.ParameterToString(template));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(query); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchIndexWithTemplatePOSTStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchIndexWithTemplatePOSTResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSearchIndexWithTemplatePOSTStartTime, "SearchIndexWithTemplatePOST", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchIndexWithTemplatePOSTResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchIndexWithTemplatePOST: " + response.Error);
            }

            SearchIndexWithTemplatePOSTData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchIndexWithTemplatePOSTStartTime, "SearchIndexWithTemplatePOST", string.Format("Response received successfully:\n{0}", SearchIndexWithTemplatePOSTData));

            if (SearchIndexWithTemplatePOSTComplete != null)
            {
                SearchIndexWithTemplatePOSTComplete(response.ResponseCode, SearchIndexWithTemplatePOSTData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get indices This is a 1 to 1 mapping of a ElasticSearch call to _cat/indices for indices.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/indices-get-mapping.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        public void SearchIndicesGET()
        {
            
            mWebCallEvent.WebPath = "/search/indices";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchIndicesGETStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchIndicesGETResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchIndicesGETStartTime, "SearchIndicesGET", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchIndicesGETResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchIndicesGET: " + response.Error);
            }

            SearchIndicesGETData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchIndicesGETStartTime, "SearchIndicesGET", string.Format("Response received successfully:\n{0}", SearchIndicesGETData));

            if (SearchIndicesGETComplete != null)
            {
                SearchIndicesGETComplete(response.ResponseCode, SearchIndicesGETData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get mapping with no template This is a 1 to 1 mapping of a ElasticSearch call to _mapping.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/indices-get-mapping.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        public void SearchMappingsGET(string type)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchMappingsGET");
            }
            
            mWebCallEvent.WebPath = "/search/mappings/{type}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchMappingsGETStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchMappingsGETResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchMappingsGETStartTime, "SearchMappingsGET", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchMappingsGETResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchMappingsGET: " + response.Error);
            }

            SearchMappingsGETData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchMappingsGETStartTime, "SearchMappingsGET", string.Format("Response received successfully:\n{0}", SearchMappingsGETData));

            if (SearchMappingsGETComplete != null)
            {
                SearchMappingsGETComplete(response.ResponseCode, SearchMappingsGETData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get mapping with a template This is a 1 to 1 mapping of a ElasticSearch call to _mapping.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/indices-get-mapping.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        public void SearchMappingsWithTemplateGET(string type, string template)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchMappingsWithTemplateGET");
            }
            // verify the required parameter 'template' is set
            if (template == null)
            {
                throw new KnetikException(400, "Missing required parameter 'template' when calling SearchMappingsWithTemplateGET");
            }
            
            mWebCallEvent.WebPath = "/search/mappings/{type}/{template}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template" + "}", KnetikClient.ParameterToString(template));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchMappingsWithTemplateGETStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchMappingsWithTemplateGETResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchMappingsWithTemplateGETStartTime, "SearchMappingsWithTemplateGET", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchMappingsWithTemplateGETResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchMappingsWithTemplateGET: " + response.Error);
            }

            SearchMappingsWithTemplateGETData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchMappingsWithTemplateGETStartTime, "SearchMappingsWithTemplateGET", string.Format("Response received successfully:\n{0}", SearchMappingsWithTemplateGETData));

            if (SearchMappingsWithTemplateGETComplete != null)
            {
                SearchMappingsWithTemplateGETComplete(response.ResponseCode, SearchMappingsWithTemplateGETData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Validate matches with no template This is a 1 to 1 mapping of a ElasticSearch call to _validate/query.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-validate.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        public void SearchValidateGET(string type)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchValidateGET");
            }
            
            mWebCallEvent.WebPath = "/search/validate/{type}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchValidateGETStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchValidateGETResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchValidateGETStartTime, "SearchValidateGET", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchValidateGETResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchValidateGET: " + response.Error);
            }

            SearchValidateGETData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchValidateGETStartTime, "SearchValidateGET", string.Format("Response received successfully:\n{0}", SearchValidateGETData));

            if (SearchValidateGETComplete != null)
            {
                SearchValidateGETComplete(response.ResponseCode, SearchValidateGETData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Validate matches with no template This is a 1 to 1 mapping of a ElasticSearch call to _validate/query.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-validate.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="query">The query to be used for the search</param>
        public void SearchValidatePOST(string type, Object query)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchValidatePOST");
            }
            
            mWebCallEvent.WebPath = "/search/validate/{type}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(query); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchValidatePOSTStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchValidatePOSTResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSearchValidatePOSTStartTime, "SearchValidatePOST", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchValidatePOSTResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchValidatePOST: " + response.Error);
            }

            SearchValidatePOSTData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchValidatePOSTStartTime, "SearchValidatePOST", string.Format("Response received successfully:\n{0}", SearchValidatePOSTData));

            if (SearchValidatePOSTComplete != null)
            {
                SearchValidatePOSTComplete(response.ResponseCode, SearchValidatePOSTData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Validate matches with a template This is a 1 to 1 mapping of a ElasticSearch call to _validate/query.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-validate.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        public void SearchValidateWithTemplateGET(string type, string template)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchValidateWithTemplateGET");
            }
            // verify the required parameter 'template' is set
            if (template == null)
            {
                throw new KnetikException(400, "Missing required parameter 'template' when calling SearchValidateWithTemplateGET");
            }
            
            mWebCallEvent.WebPath = "/search/validate/{type}/{template}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template" + "}", KnetikClient.ParameterToString(template));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchValidateWithTemplateGETStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchValidateWithTemplateGETResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchValidateWithTemplateGETStartTime, "SearchValidateWithTemplateGET", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchValidateWithTemplateGETResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchValidateWithTemplateGET: " + response.Error);
            }

            SearchValidateWithTemplateGETData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchValidateWithTemplateGETStartTime, "SearchValidateWithTemplateGET", string.Format("Response received successfully:\n{0}", SearchValidateWithTemplateGETData));

            if (SearchValidateWithTemplateGETComplete != null)
            {
                SearchValidateWithTemplateGETComplete(response.ResponseCode, SearchValidateWithTemplateGETData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Validate matches with a template This is a 1 to 1 mapping of a ElasticSearch call to _validate/query.  Further information can be found at their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/search-validate.html&#39;&gt;API guide&lt;/a&gt;
        /// </summary>
        /// <param name="type">The index type</param>
        /// <param name="template">The index template</param>
        /// <param name="query">The query to be used for the search</param>
        public void SearchValidateWithTemplatePOST(string type, string template, Object query)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling SearchValidateWithTemplatePOST");
            }
            // verify the required parameter 'template' is set
            if (template == null)
            {
                throw new KnetikException(400, "Missing required parameter 'template' when calling SearchValidateWithTemplatePOST");
            }
            
            mWebCallEvent.WebPath = "/search/validate/{type}/{template}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "template" + "}", KnetikClient.ParameterToString(template));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(query); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchValidateWithTemplatePOSTStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchValidateWithTemplatePOSTResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSearchValidateWithTemplatePOSTStartTime, "SearchValidateWithTemplatePOST", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchValidateWithTemplatePOSTResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchValidateWithTemplatePOST: " + response.Error);
            }

            SearchValidateWithTemplatePOSTData = (Object) KnetikClient.Deserialize(response.Content, typeof(Object), response.Headers);
            KnetikLogger.LogResponse(mSearchValidateWithTemplatePOSTStartTime, "SearchValidateWithTemplatePOST", string.Format("Response received successfully:\n{0}", SearchValidateWithTemplatePOSTData));

            if (SearchValidateWithTemplatePOSTComplete != null)
            {
                SearchValidateWithTemplatePOSTComplete(response.ResponseCode, SearchValidateWithTemplatePOSTData);
            }
        }

    }
}
