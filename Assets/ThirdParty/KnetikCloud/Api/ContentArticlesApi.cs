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
    public interface IContentArticlesApi
    {
        ArticleResource CreateArticleData { get; }

        TemplateResource CreateArticleTemplateData { get; }

        ArticleResource GetArticleData { get; }

        TemplateResource GetArticleTemplateData { get; }

        PageResourceTemplateResource GetArticleTemplatesData { get; }

        PageResourceArticleResource GetArticlesData { get; }

        ArticleResource UpdateArticleData { get; }

        TemplateResource UpdateArticleTemplateData { get; }

        
        /// <summary>
        /// Create a new article Articles are blobs of text with titles, a category and assets. Formatting and display of the text is in the hands of the front end.
        /// </summary>
        /// <param name="articleResource">The new article</param>
        void CreateArticle(ArticleResource articleResource);

        /// <summary>
        /// Create an article template Article Templates define a type of article and the properties they have
        /// </summary>
        /// <param name="articleTemplateResource">The article template resource object</param>
        void CreateArticleTemplate(TemplateResource articleTemplateResource);

        /// <summary>
        /// Delete an existing article 
        /// </summary>
        /// <param name="id">The article id</param>
        void DeleteArticle(string id);

        /// <summary>
        /// Delete an article template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteArticleTemplate(string id, string cascade);

        /// <summary>
        /// Get a single article 
        /// </summary>
        /// <param name="id">The article id</param>
        void GetArticle(string id);

        /// <summary>
        /// Get a single article template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetArticleTemplate(string id);

        /// <summary>
        /// List and search article templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetArticleTemplates(int? size, int? page, string order);

        /// <summary>
        /// List and search articles Get a list of articles with optional filtering. Assets will not be filled in on the resources returned. Use &#39;Get a single article&#39; to retrieve the full resource with assets for a given item as needed.
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

        /// <summary>
        /// Update an existing article 
        /// </summary>
        /// <param name="id">The article id</param>
        /// <param name="articleResource">The article object</param>
        void UpdateArticle(string id, ArticleResource articleResource);

        /// <summary>
        /// Update an article template 
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
        private readonly KnetikCoroutine mCreateArticleCoroutine;
        private DateTime mCreateArticleStartTime;
        private string mCreateArticlePath;
        private readonly KnetikCoroutine mCreateArticleTemplateCoroutine;
        private DateTime mCreateArticleTemplateStartTime;
        private string mCreateArticleTemplatePath;
        private readonly KnetikCoroutine mDeleteArticleCoroutine;
        private DateTime mDeleteArticleStartTime;
        private string mDeleteArticlePath;
        private readonly KnetikCoroutine mDeleteArticleTemplateCoroutine;
        private DateTime mDeleteArticleTemplateStartTime;
        private string mDeleteArticleTemplatePath;
        private readonly KnetikCoroutine mGetArticleCoroutine;
        private DateTime mGetArticleStartTime;
        private string mGetArticlePath;
        private readonly KnetikCoroutine mGetArticleTemplateCoroutine;
        private DateTime mGetArticleTemplateStartTime;
        private string mGetArticleTemplatePath;
        private readonly KnetikCoroutine mGetArticleTemplatesCoroutine;
        private DateTime mGetArticleTemplatesStartTime;
        private string mGetArticleTemplatesPath;
        private readonly KnetikCoroutine mGetArticlesCoroutine;
        private DateTime mGetArticlesStartTime;
        private string mGetArticlesPath;
        private readonly KnetikCoroutine mUpdateArticleCoroutine;
        private DateTime mUpdateArticleStartTime;
        private string mUpdateArticlePath;
        private readonly KnetikCoroutine mUpdateArticleTemplateCoroutine;
        private DateTime mUpdateArticleTemplateStartTime;
        private string mUpdateArticleTemplatePath;

        public ArticleResource CreateArticleData { get; private set; }
        public delegate void CreateArticleCompleteDelegate(ArticleResource response);
        public CreateArticleCompleteDelegate CreateArticleComplete;

        public TemplateResource CreateArticleTemplateData { get; private set; }
        public delegate void CreateArticleTemplateCompleteDelegate(TemplateResource response);
        public CreateArticleTemplateCompleteDelegate CreateArticleTemplateComplete;

        public delegate void DeleteArticleCompleteDelegate();
        public DeleteArticleCompleteDelegate DeleteArticleComplete;

        public delegate void DeleteArticleTemplateCompleteDelegate();
        public DeleteArticleTemplateCompleteDelegate DeleteArticleTemplateComplete;

        public ArticleResource GetArticleData { get; private set; }
        public delegate void GetArticleCompleteDelegate(ArticleResource response);
        public GetArticleCompleteDelegate GetArticleComplete;

        public TemplateResource GetArticleTemplateData { get; private set; }
        public delegate void GetArticleTemplateCompleteDelegate(TemplateResource response);
        public GetArticleTemplateCompleteDelegate GetArticleTemplateComplete;

        public PageResourceTemplateResource GetArticleTemplatesData { get; private set; }
        public delegate void GetArticleTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetArticleTemplatesCompleteDelegate GetArticleTemplatesComplete;

        public PageResourceArticleResource GetArticlesData { get; private set; }
        public delegate void GetArticlesCompleteDelegate(PageResourceArticleResource response);
        public GetArticlesCompleteDelegate GetArticlesComplete;

        public ArticleResource UpdateArticleData { get; private set; }
        public delegate void UpdateArticleCompleteDelegate(ArticleResource response);
        public UpdateArticleCompleteDelegate UpdateArticleComplete;

        public TemplateResource UpdateArticleTemplateData { get; private set; }
        public delegate void UpdateArticleTemplateCompleteDelegate(TemplateResource response);
        public UpdateArticleTemplateCompleteDelegate UpdateArticleTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentArticlesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ContentArticlesApi()
        {
            mCreateArticleCoroutine = new KnetikCoroutine();
            mCreateArticleTemplateCoroutine = new KnetikCoroutine();
            mDeleteArticleCoroutine = new KnetikCoroutine();
            mDeleteArticleTemplateCoroutine = new KnetikCoroutine();
            mGetArticleCoroutine = new KnetikCoroutine();
            mGetArticleTemplateCoroutine = new KnetikCoroutine();
            mGetArticleTemplatesCoroutine = new KnetikCoroutine();
            mGetArticlesCoroutine = new KnetikCoroutine();
            mUpdateArticleCoroutine = new KnetikCoroutine();
            mUpdateArticleTemplateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a new article Articles are blobs of text with titles, a category and assets. Formatting and display of the text is in the hands of the front end.
        /// </summary>
        /// <param name="articleResource">The new article</param>
        public void CreateArticle(ArticleResource articleResource)
        {
            
            mCreateArticlePath = "/content/articles";
            if (!string.IsNullOrEmpty(mCreateArticlePath))
            {
                mCreateArticlePath = mCreateArticlePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(articleResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateArticleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateArticleStartTime, mCreateArticlePath, "Sending server request...");

            // make the HTTP request
            mCreateArticleCoroutine.ResponseReceived += CreateArticleCallback;
            mCreateArticleCoroutine.Start(mCreateArticlePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateArticleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateArticle: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateArticle: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateArticleData = (ArticleResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ArticleResource), response.Headers);
            KnetikLogger.LogResponse(mCreateArticleStartTime, mCreateArticlePath, string.Format("Response received successfully:\n{0}", CreateArticleData.ToString()));

            if (CreateArticleComplete != null)
            {
                CreateArticleComplete(CreateArticleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create an article template Article Templates define a type of article and the properties they have
        /// </summary>
        /// <param name="articleTemplateResource">The article template resource object</param>
        public void CreateArticleTemplate(TemplateResource articleTemplateResource)
        {
            
            mCreateArticleTemplatePath = "/content/articles/templates";
            if (!string.IsNullOrEmpty(mCreateArticleTemplatePath))
            {
                mCreateArticleTemplatePath = mCreateArticleTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(articleTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateArticleTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateArticleTemplateStartTime, mCreateArticleTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateArticleTemplateCoroutine.ResponseReceived += CreateArticleTemplateCallback;
            mCreateArticleTemplateCoroutine.Start(mCreateArticleTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateArticleTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateArticleTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateArticleTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateArticleTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateArticleTemplateStartTime, mCreateArticleTemplatePath, string.Format("Response received successfully:\n{0}", CreateArticleTemplateData.ToString()));

            if (CreateArticleTemplateComplete != null)
            {
                CreateArticleTemplateComplete(CreateArticleTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an existing article 
        /// </summary>
        /// <param name="id">The article id</param>
        public void DeleteArticle(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteArticle");
            }
            
            mDeleteArticlePath = "/content/articles/{id}";
            if (!string.IsNullOrEmpty(mDeleteArticlePath))
            {
                mDeleteArticlePath = mDeleteArticlePath.Replace("{format}", "json");
            }
            mDeleteArticlePath = mDeleteArticlePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteArticleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteArticleStartTime, mDeleteArticlePath, "Sending server request...");

            // make the HTTP request
            mDeleteArticleCoroutine.ResponseReceived += DeleteArticleCallback;
            mDeleteArticleCoroutine.Start(mDeleteArticlePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteArticleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteArticle: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteArticle: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteArticleStartTime, mDeleteArticlePath, "Response received successfully.");
            if (DeleteArticleComplete != null)
            {
                DeleteArticleComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an article template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
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
            
            mDeleteArticleTemplatePath = "/content/articles/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteArticleTemplatePath))
            {
                mDeleteArticleTemplatePath = mDeleteArticleTemplatePath.Replace("{format}", "json");
            }
            mDeleteArticleTemplatePath = mDeleteArticleTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteArticleTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteArticleTemplateStartTime, mDeleteArticleTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteArticleTemplateCoroutine.ResponseReceived += DeleteArticleTemplateCallback;
            mDeleteArticleTemplateCoroutine.Start(mDeleteArticleTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteArticleTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteArticleTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteArticleTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteArticleTemplateStartTime, mDeleteArticleTemplatePath, "Response received successfully.");
            if (DeleteArticleTemplateComplete != null)
            {
                DeleteArticleTemplateComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single article 
        /// </summary>
        /// <param name="id">The article id</param>
        public void GetArticle(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetArticle");
            }
            
            mGetArticlePath = "/content/articles/{id}";
            if (!string.IsNullOrEmpty(mGetArticlePath))
            {
                mGetArticlePath = mGetArticlePath.Replace("{format}", "json");
            }
            mGetArticlePath = mGetArticlePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetArticleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetArticleStartTime, mGetArticlePath, "Sending server request...");

            // make the HTTP request
            mGetArticleCoroutine.ResponseReceived += GetArticleCallback;
            mGetArticleCoroutine.Start(mGetArticlePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetArticleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArticle: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArticle: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetArticleData = (ArticleResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ArticleResource), response.Headers);
            KnetikLogger.LogResponse(mGetArticleStartTime, mGetArticlePath, string.Format("Response received successfully:\n{0}", GetArticleData.ToString()));

            if (GetArticleComplete != null)
            {
                GetArticleComplete(GetArticleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single article template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetArticleTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetArticleTemplate");
            }
            
            mGetArticleTemplatePath = "/content/articles/templates/{id}";
            if (!string.IsNullOrEmpty(mGetArticleTemplatePath))
            {
                mGetArticleTemplatePath = mGetArticleTemplatePath.Replace("{format}", "json");
            }
            mGetArticleTemplatePath = mGetArticleTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetArticleTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetArticleTemplateStartTime, mGetArticleTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetArticleTemplateCoroutine.ResponseReceived += GetArticleTemplateCallback;
            mGetArticleTemplateCoroutine.Start(mGetArticleTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetArticleTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArticleTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArticleTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetArticleTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetArticleTemplateStartTime, mGetArticleTemplatePath, string.Format("Response received successfully:\n{0}", GetArticleTemplateData.ToString()));

            if (GetArticleTemplateComplete != null)
            {
                GetArticleTemplateComplete(GetArticleTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search article templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetArticleTemplates(int? size, int? page, string order)
        {
            
            mGetArticleTemplatesPath = "/content/articles/templates";
            if (!string.IsNullOrEmpty(mGetArticleTemplatesPath))
            {
                mGetArticleTemplatesPath = mGetArticleTemplatesPath.Replace("{format}", "json");
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
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetArticleTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetArticleTemplatesStartTime, mGetArticleTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetArticleTemplatesCoroutine.ResponseReceived += GetArticleTemplatesCallback;
            mGetArticleTemplatesCoroutine.Start(mGetArticleTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetArticleTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArticleTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArticleTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetArticleTemplatesData = (PageResourceTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetArticleTemplatesStartTime, mGetArticleTemplatesPath, string.Format("Response received successfully:\n{0}", GetArticleTemplatesData.ToString()));

            if (GetArticleTemplatesComplete != null)
            {
                GetArticleTemplatesComplete(GetArticleTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search articles Get a list of articles with optional filtering. Assets will not be filled in on the resources returned. Use &#39;Get a single article&#39; to retrieve the full resource with assets for a given item as needed.
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
            
            mGetArticlesPath = "/content/articles";
            if (!string.IsNullOrEmpty(mGetArticlesPath))
            {
                mGetArticlesPath = mGetArticlesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterActiveOnly != null)
            {
                queryParams.Add("filter_active_only", KnetikClient.DefaultClient.ParameterToString(filterActiveOnly));
            }

            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.DefaultClient.ParameterToString(filterCategory));
            }

            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.DefaultClient.ParameterToString(filterTagset));
            }

            if (filterTagIntersection != null)
            {
                queryParams.Add("filter_tag_intersection", KnetikClient.DefaultClient.ParameterToString(filterTagIntersection));
            }

            if (filterTagExclusion != null)
            {
                queryParams.Add("filter_tag_exclusion", KnetikClient.DefaultClient.ParameterToString(filterTagExclusion));
            }

            if (filterTitle != null)
            {
                queryParams.Add("filter_title", KnetikClient.DefaultClient.ParameterToString(filterTitle));
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
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetArticlesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetArticlesStartTime, mGetArticlesPath, "Sending server request...");

            // make the HTTP request
            mGetArticlesCoroutine.ResponseReceived += GetArticlesCallback;
            mGetArticlesCoroutine.Start(mGetArticlesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetArticlesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArticles: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArticles: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetArticlesData = (PageResourceArticleResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceArticleResource), response.Headers);
            KnetikLogger.LogResponse(mGetArticlesStartTime, mGetArticlesPath, string.Format("Response received successfully:\n{0}", GetArticlesData.ToString()));

            if (GetArticlesComplete != null)
            {
                GetArticlesComplete(GetArticlesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an existing article 
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
            
            mUpdateArticlePath = "/content/articles/{id}";
            if (!string.IsNullOrEmpty(mUpdateArticlePath))
            {
                mUpdateArticlePath = mUpdateArticlePath.Replace("{format}", "json");
            }
            mUpdateArticlePath = mUpdateArticlePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(articleResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateArticleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateArticleStartTime, mUpdateArticlePath, "Sending server request...");

            // make the HTTP request
            mUpdateArticleCoroutine.ResponseReceived += UpdateArticleCallback;
            mUpdateArticleCoroutine.Start(mUpdateArticlePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateArticleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateArticle: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateArticle: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateArticleData = (ArticleResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ArticleResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateArticleStartTime, mUpdateArticlePath, string.Format("Response received successfully:\n{0}", UpdateArticleData.ToString()));

            if (UpdateArticleComplete != null)
            {
                UpdateArticleComplete(UpdateArticleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an article template 
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
            
            mUpdateArticleTemplatePath = "/content/articles/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateArticleTemplatePath))
            {
                mUpdateArticleTemplatePath = mUpdateArticleTemplatePath.Replace("{format}", "json");
            }
            mUpdateArticleTemplatePath = mUpdateArticleTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(articleTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateArticleTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateArticleTemplateStartTime, mUpdateArticleTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateArticleTemplateCoroutine.ResponseReceived += UpdateArticleTemplateCallback;
            mUpdateArticleTemplateCoroutine.Start(mUpdateArticleTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateArticleTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateArticleTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateArticleTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateArticleTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateArticleTemplateStartTime, mUpdateArticleTemplatePath, string.Format("Response received successfully:\n{0}", UpdateArticleTemplateData.ToString()));

            if (UpdateArticleTemplateComplete != null)
            {
                UpdateArticleTemplateComplete(UpdateArticleTemplateData);
            }
        }

    }
}
