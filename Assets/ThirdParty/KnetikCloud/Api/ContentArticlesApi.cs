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
    public interface IContentArticlesApi
    {
        ArticleResource CreateArticleData { get; }

        /// <summary>
        /// Create a new article Articles are blobs of text with titles, a category and assets. Formatting and display of the text is in the hands of the front end.&lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="articleResource">The new article</param>
        void CreateArticle(ArticleResource articleResource);

        TemplateResource CreateArticleTemplateData { get; }

        /// <summary>
        /// Create an article template Article Templates define a type of article and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="articleTemplateResource">The article template resource object</param>
        void CreateArticleTemplate(TemplateResource articleTemplateResource);

        

        /// <summary>
        /// Delete an existing article &lt;b&gt;Permissions Needed:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="id">The article id</param>
        void DeleteArticle(string id);

        

        /// <summary>
        /// Delete an article template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteArticleTemplate(string id, string cascade);

        ArticleResource GetArticleData { get; }

        /// <summary>
        /// Get a single article &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The article id</param>
        void GetArticle(string id);

        TemplateResource GetArticleTemplateData { get; }

        /// <summary>
        /// Get a single article template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or ARTICLES_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetArticleTemplate(string id);

        PageResourceTemplateResource GetArticleTemplatesData { get; }

        /// <summary>
        /// List and search article templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or ARTICLES_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetArticleTemplates(int? size, int? page, string order);

        PageResourceArticleResource GetArticlesData { get; }

        /// <summary>
        /// List and search articles Get a list of articles with optional filtering. Assets will not be filled in on the resources returned. Use &#39;Get a single article&#39; to retrieve the full resource with assets for a given item as needed. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterActiveOnly">Filter for articles that are active (true) or inactive (false)</param>
        /// <param name="filterCategory">Filter for articles from a specific category by id</param>
        /// <param name="filterTagset">Filter for articles with at least one of a specified set of tags (separated by comma)</param>
        /// <param name="filterTagIntersection">Filter for articles with all of a specified set of tags (separated by comma)</param>
        /// <param name="filterTagExclusion">Filter for articles with none of a specified set of tags (separated by comma)</param>
        /// <param name="filterTitle">Filter for articles whose title contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetArticles(bool? filterActiveOnly, string filterCategory, string filterTagset, string filterTagIntersection, string filterTagExclusion, string filterTitle, int? size, int? page, string order);

        ArticleResource UpdateArticleData { get; }

        /// <summary>
        /// Update an existing article &lt;b&gt;Permissions Needed:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="id">The article id</param>
        /// <param name="articleResource">The article object</param>
        void UpdateArticle(string id, ArticleResource articleResource);

        TemplateResource UpdateArticleTemplateData { get; }

        /// <summary>
        /// Update an article template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="articleTemplateResource">The article template resource object</param>
        void UpdateArticleTemplate(string id, TemplateResource articleTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ContentArticlesApi : IContentArticlesApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateArticleResponseContext;
        private DateTime mCreateArticleStartTime;
        private readonly KnetikResponseContext mCreateArticleTemplateResponseContext;
        private DateTime mCreateArticleTemplateStartTime;
        private readonly KnetikResponseContext mDeleteArticleResponseContext;
        private DateTime mDeleteArticleStartTime;
        private readonly KnetikResponseContext mDeleteArticleTemplateResponseContext;
        private DateTime mDeleteArticleTemplateStartTime;
        private readonly KnetikResponseContext mGetArticleResponseContext;
        private DateTime mGetArticleStartTime;
        private readonly KnetikResponseContext mGetArticleTemplateResponseContext;
        private DateTime mGetArticleTemplateStartTime;
        private readonly KnetikResponseContext mGetArticleTemplatesResponseContext;
        private DateTime mGetArticleTemplatesStartTime;
        private readonly KnetikResponseContext mGetArticlesResponseContext;
        private DateTime mGetArticlesStartTime;
        private readonly KnetikResponseContext mUpdateArticleResponseContext;
        private DateTime mUpdateArticleStartTime;
        private readonly KnetikResponseContext mUpdateArticleTemplateResponseContext;
        private DateTime mUpdateArticleTemplateStartTime;

        public ArticleResource CreateArticleData { get; private set; }
        public delegate void CreateArticleCompleteDelegate(long responseCode, ArticleResource response);
        public CreateArticleCompleteDelegate CreateArticleComplete;

        public TemplateResource CreateArticleTemplateData { get; private set; }
        public delegate void CreateArticleTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateArticleTemplateCompleteDelegate CreateArticleTemplateComplete;

        public delegate void DeleteArticleCompleteDelegate(long responseCode);
        public DeleteArticleCompleteDelegate DeleteArticleComplete;

        public delegate void DeleteArticleTemplateCompleteDelegate(long responseCode);
        public DeleteArticleTemplateCompleteDelegate DeleteArticleTemplateComplete;

        public ArticleResource GetArticleData { get; private set; }
        public delegate void GetArticleCompleteDelegate(long responseCode, ArticleResource response);
        public GetArticleCompleteDelegate GetArticleComplete;

        public TemplateResource GetArticleTemplateData { get; private set; }
        public delegate void GetArticleTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetArticleTemplateCompleteDelegate GetArticleTemplateComplete;

        public PageResourceTemplateResource GetArticleTemplatesData { get; private set; }
        public delegate void GetArticleTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetArticleTemplatesCompleteDelegate GetArticleTemplatesComplete;

        public PageResourceArticleResource GetArticlesData { get; private set; }
        public delegate void GetArticlesCompleteDelegate(long responseCode, PageResourceArticleResource response);
        public GetArticlesCompleteDelegate GetArticlesComplete;

        public ArticleResource UpdateArticleData { get; private set; }
        public delegate void UpdateArticleCompleteDelegate(long responseCode, ArticleResource response);
        public UpdateArticleCompleteDelegate UpdateArticleComplete;

        public TemplateResource UpdateArticleTemplateData { get; private set; }
        public delegate void UpdateArticleTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateArticleTemplateCompleteDelegate UpdateArticleTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentArticlesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ContentArticlesApi()
        {
            mCreateArticleResponseContext = new KnetikResponseContext();
            mCreateArticleResponseContext.ResponseReceived += OnCreateArticleResponse;
            mCreateArticleTemplateResponseContext = new KnetikResponseContext();
            mCreateArticleTemplateResponseContext.ResponseReceived += OnCreateArticleTemplateResponse;
            mDeleteArticleResponseContext = new KnetikResponseContext();
            mDeleteArticleResponseContext.ResponseReceived += OnDeleteArticleResponse;
            mDeleteArticleTemplateResponseContext = new KnetikResponseContext();
            mDeleteArticleTemplateResponseContext.ResponseReceived += OnDeleteArticleTemplateResponse;
            mGetArticleResponseContext = new KnetikResponseContext();
            mGetArticleResponseContext.ResponseReceived += OnGetArticleResponse;
            mGetArticleTemplateResponseContext = new KnetikResponseContext();
            mGetArticleTemplateResponseContext.ResponseReceived += OnGetArticleTemplateResponse;
            mGetArticleTemplatesResponseContext = new KnetikResponseContext();
            mGetArticleTemplatesResponseContext.ResponseReceived += OnGetArticleTemplatesResponse;
            mGetArticlesResponseContext = new KnetikResponseContext();
            mGetArticlesResponseContext.ResponseReceived += OnGetArticlesResponse;
            mUpdateArticleResponseContext = new KnetikResponseContext();
            mUpdateArticleResponseContext.ResponseReceived += OnUpdateArticleResponse;
            mUpdateArticleTemplateResponseContext = new KnetikResponseContext();
            mUpdateArticleTemplateResponseContext.ResponseReceived += OnUpdateArticleTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a new article Articles are blobs of text with titles, a category and assets. Formatting and display of the text is in the hands of the front end.&lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="articleResource">The new article</param>
        public void CreateArticle(ArticleResource articleResource)
        {
            
            mWebCallEvent.WebPath = "/content/articles";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(articleResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateArticleStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateArticleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateArticleStartTime, "CreateArticle", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateArticleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateArticle: " + response.Error);
            }

            CreateArticleData = (ArticleResource) KnetikClient.Deserialize(response.Content, typeof(ArticleResource), response.Headers);
            KnetikLogger.LogResponse(mCreateArticleStartTime, "CreateArticle", string.Format("Response received successfully:\n{0}", CreateArticleData));

            if (CreateArticleComplete != null)
            {
                CreateArticleComplete(response.ResponseCode, CreateArticleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create an article template Article Templates define a type of article and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="articleTemplateResource">The article template resource object</param>
        public void CreateArticleTemplate(TemplateResource articleTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/content/articles/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(articleTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateArticleTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateArticleTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateArticleTemplateStartTime, "CreateArticleTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateArticleTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateArticleTemplate: " + response.Error);
            }

            CreateArticleTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateArticleTemplateStartTime, "CreateArticleTemplate", string.Format("Response received successfully:\n{0}", CreateArticleTemplateData));

            if (CreateArticleTemplateComplete != null)
            {
                CreateArticleTemplateComplete(response.ResponseCode, CreateArticleTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an existing article &lt;b&gt;Permissions Needed:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="id">The article id</param>
        public void DeleteArticle(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteArticle");
            }
            
            mWebCallEvent.WebPath = "/content/articles/{id}";
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
            mDeleteArticleStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteArticleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteArticleStartTime, "DeleteArticle", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteArticleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteArticle: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteArticleStartTime, "DeleteArticle", "Response received successfully.");
            if (DeleteArticleComplete != null)
            {
                DeleteArticleComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an article template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteArticleTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteArticleTemplate");
            }
            
            mWebCallEvent.WebPath = "/content/articles/templates/{id}";
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
            mDeleteArticleTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteArticleTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteArticleTemplateStartTime, "DeleteArticleTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteArticleTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteArticleTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteArticleTemplateStartTime, "DeleteArticleTemplate", "Response received successfully.");
            if (DeleteArticleTemplateComplete != null)
            {
                DeleteArticleTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single article &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The article id</param>
        public void GetArticle(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetArticle");
            }
            
            mWebCallEvent.WebPath = "/content/articles/{id}";
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
            mGetArticleStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetArticleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetArticleStartTime, "GetArticle", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetArticleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetArticle: " + response.Error);
            }

            GetArticleData = (ArticleResource) KnetikClient.Deserialize(response.Content, typeof(ArticleResource), response.Headers);
            KnetikLogger.LogResponse(mGetArticleStartTime, "GetArticle", string.Format("Response received successfully:\n{0}", GetArticleData));

            if (GetArticleComplete != null)
            {
                GetArticleComplete(response.ResponseCode, GetArticleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single article template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or ARTICLES_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetArticleTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetArticleTemplate");
            }
            
            mWebCallEvent.WebPath = "/content/articles/templates/{id}";
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
            mGetArticleTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetArticleTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetArticleTemplateStartTime, "GetArticleTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetArticleTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetArticleTemplate: " + response.Error);
            }

            GetArticleTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetArticleTemplateStartTime, "GetArticleTemplate", string.Format("Response received successfully:\n{0}", GetArticleTemplateData));

            if (GetArticleTemplateComplete != null)
            {
                GetArticleTemplateComplete(response.ResponseCode, GetArticleTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search article templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or ARTICLES_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetArticleTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/content/articles/templates";
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
            mGetArticleTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetArticleTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetArticleTemplatesStartTime, "GetArticleTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetArticleTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetArticleTemplates: " + response.Error);
            }

            GetArticleTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetArticleTemplatesStartTime, "GetArticleTemplates", string.Format("Response received successfully:\n{0}", GetArticleTemplatesData));

            if (GetArticleTemplatesComplete != null)
            {
                GetArticleTemplatesComplete(response.ResponseCode, GetArticleTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search articles Get a list of articles with optional filtering. Assets will not be filled in on the resources returned. Use &#39;Get a single article&#39; to retrieve the full resource with assets for a given item as needed. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterActiveOnly">Filter for articles that are active (true) or inactive (false)</param>
        /// <param name="filterCategory">Filter for articles from a specific category by id</param>
        /// <param name="filterTagset">Filter for articles with at least one of a specified set of tags (separated by comma)</param>
        /// <param name="filterTagIntersection">Filter for articles with all of a specified set of tags (separated by comma)</param>
        /// <param name="filterTagExclusion">Filter for articles with none of a specified set of tags (separated by comma)</param>
        /// <param name="filterTitle">Filter for articles whose title contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetArticles(bool? filterActiveOnly, string filterCategory, string filterTagset, string filterTagIntersection, string filterTagExclusion, string filterTitle, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/content/articles";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterActiveOnly != null)
            {
                mWebCallEvent.QueryParams["filter_active_only"] = KnetikClient.ParameterToString(filterActiveOnly);
            }

            if (filterCategory != null)
            {
                mWebCallEvent.QueryParams["filter_category"] = KnetikClient.ParameterToString(filterCategory);
            }

            if (filterTagset != null)
            {
                mWebCallEvent.QueryParams["filter_tagset"] = KnetikClient.ParameterToString(filterTagset);
            }

            if (filterTagIntersection != null)
            {
                mWebCallEvent.QueryParams["filter_tag_intersection"] = KnetikClient.ParameterToString(filterTagIntersection);
            }

            if (filterTagExclusion != null)
            {
                mWebCallEvent.QueryParams["filter_tag_exclusion"] = KnetikClient.ParameterToString(filterTagExclusion);
            }

            if (filterTitle != null)
            {
                mWebCallEvent.QueryParams["filter_title"] = KnetikClient.ParameterToString(filterTitle);
            }

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
            mGetArticlesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetArticlesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetArticlesStartTime, "GetArticles", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetArticlesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetArticles: " + response.Error);
            }

            GetArticlesData = (PageResourceArticleResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceArticleResource), response.Headers);
            KnetikLogger.LogResponse(mGetArticlesStartTime, "GetArticles", string.Format("Response received successfully:\n{0}", GetArticlesData));

            if (GetArticlesComplete != null)
            {
                GetArticlesComplete(response.ResponseCode, GetArticlesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an existing article &lt;b&gt;Permissions Needed:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="id">The article id</param>
        /// <param name="articleResource">The article object</param>
        public void UpdateArticle(string id, ArticleResource articleResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateArticle");
            }
            
            mWebCallEvent.WebPath = "/content/articles/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(articleResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateArticleStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateArticleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateArticleStartTime, "UpdateArticle", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateArticleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateArticle: " + response.Error);
            }

            UpdateArticleData = (ArticleResource) KnetikClient.Deserialize(response.Content, typeof(ArticleResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateArticleStartTime, "UpdateArticle", string.Format("Response received successfully:\n{0}", UpdateArticleData));

            if (UpdateArticleComplete != null)
            {
                UpdateArticleComplete(response.ResponseCode, UpdateArticleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an article template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="articleTemplateResource">The article template resource object</param>
        public void UpdateArticleTemplate(string id, TemplateResource articleTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateArticleTemplate");
            }
            
            mWebCallEvent.WebPath = "/content/articles/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(articleTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateArticleTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateArticleTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateArticleTemplateStartTime, "UpdateArticleTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateArticleTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateArticleTemplate: " + response.Error);
            }

            UpdateArticleTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateArticleTemplateStartTime, "UpdateArticleTemplate", string.Format("Response received successfully:\n{0}", UpdateArticleTemplateData));

            if (UpdateArticleTemplateComplete != null)
            {
                UpdateArticleTemplateComplete(response.ResponseCode, UpdateArticleTemplateData);
            }
        }

    }
}
