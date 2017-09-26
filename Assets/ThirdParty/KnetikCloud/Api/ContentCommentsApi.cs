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
    public interface IContentCommentsApi
    {
        CommentResource AddCommentData { get; }

        CommentResource GetCommentData { get; }

        PageResourceCommentResource GetCommentsData { get; }

        PageResourceCommentResource SearchCommentsData { get; }

        
        /// <summary>
        /// Add a new comment 
        /// </summary>
        /// <param name="commentResource">The comment to be added</param>
        void AddComment(CommentResource commentResource);

        /// <summary>
        /// Delete a comment 
        /// </summary>
        /// <param name="id">The comment id</param>
        void DeleteComment(long? id);

        /// <summary>
        /// Return a comment 
        /// </summary>
        /// <param name="id">The comment id</param>
        void GetComment(long? id);

        /// <summary>
        /// Returns a page of comments 
        /// </summary>
        /// <param name="context">Get comments by context type</param>
        /// <param name="contextId">Get comments by context id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetComments(string context, int? contextId, int? size, int? page);

        /// <summary>
        /// Search the comment index The body is an ElasticSearch query json. Please see their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/index.html&#39;&gt;documentation&lt;/a&gt; for details on the format and search options
        /// </summary>
        /// <param name="query">The search query</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void SearchComments(Object query, int? size, int? page);

        /// <summary>
        /// Update a comment 
        /// </summary>
        /// <param name="id">The comment id</param>
        /// <param name="content">The comment content</param>
        void UpdateComment(long? id, StringWrapper content);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ContentCommentsApi : IContentCommentsApi
    {
        private readonly KnetikCoroutine mAddCommentCoroutine;
        private DateTime mAddCommentStartTime;
        private string mAddCommentPath;
        private readonly KnetikCoroutine mDeleteCommentCoroutine;
        private DateTime mDeleteCommentStartTime;
        private string mDeleteCommentPath;
        private readonly KnetikCoroutine mGetCommentCoroutine;
        private DateTime mGetCommentStartTime;
        private string mGetCommentPath;
        private readonly KnetikCoroutine mGetCommentsCoroutine;
        private DateTime mGetCommentsStartTime;
        private string mGetCommentsPath;
        private readonly KnetikCoroutine mSearchCommentsCoroutine;
        private DateTime mSearchCommentsStartTime;
        private string mSearchCommentsPath;
        private readonly KnetikCoroutine mUpdateCommentCoroutine;
        private DateTime mUpdateCommentStartTime;
        private string mUpdateCommentPath;

        public CommentResource AddCommentData { get; private set; }
        public delegate void AddCommentCompleteDelegate(CommentResource response);
        public AddCommentCompleteDelegate AddCommentComplete;

        public delegate void DeleteCommentCompleteDelegate();
        public DeleteCommentCompleteDelegate DeleteCommentComplete;

        public CommentResource GetCommentData { get; private set; }
        public delegate void GetCommentCompleteDelegate(CommentResource response);
        public GetCommentCompleteDelegate GetCommentComplete;

        public PageResourceCommentResource GetCommentsData { get; private set; }
        public delegate void GetCommentsCompleteDelegate(PageResourceCommentResource response);
        public GetCommentsCompleteDelegate GetCommentsComplete;

        public PageResourceCommentResource SearchCommentsData { get; private set; }
        public delegate void SearchCommentsCompleteDelegate(PageResourceCommentResource response);
        public SearchCommentsCompleteDelegate SearchCommentsComplete;

        public delegate void UpdateCommentCompleteDelegate();
        public UpdateCommentCompleteDelegate UpdateCommentComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentCommentsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ContentCommentsApi()
        {
            mAddCommentCoroutine = new KnetikCoroutine();
            mDeleteCommentCoroutine = new KnetikCoroutine();
            mGetCommentCoroutine = new KnetikCoroutine();
            mGetCommentsCoroutine = new KnetikCoroutine();
            mSearchCommentsCoroutine = new KnetikCoroutine();
            mUpdateCommentCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a new comment 
        /// </summary>
        /// <param name="commentResource">The comment to be added</param>
        public void AddComment(CommentResource commentResource)
        {
            
            mAddCommentPath = "/comments";
            if (!string.IsNullOrEmpty(mAddCommentPath))
            {
                mAddCommentPath = mAddCommentPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(commentResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddCommentStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddCommentStartTime, mAddCommentPath, "Sending server request...");

            // make the HTTP request
            mAddCommentCoroutine.ResponseReceived += AddCommentCallback;
            mAddCommentCoroutine.Start(mAddCommentPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddCommentCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddComment: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddComment: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddCommentData = (CommentResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CommentResource), response.Headers);
            KnetikLogger.LogResponse(mAddCommentStartTime, mAddCommentPath, string.Format("Response received successfully:\n{0}", AddCommentData.ToString()));

            if (AddCommentComplete != null)
            {
                AddCommentComplete(AddCommentData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Delete a comment 
        /// </summary>
        /// <param name="id">The comment id</param>
        public void DeleteComment(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteComment");
            }
            
            mDeleteCommentPath = "/comments/{id}";
            if (!string.IsNullOrEmpty(mDeleteCommentPath))
            {
                mDeleteCommentPath = mDeleteCommentPath.Replace("{format}", "json");
            }
            mDeleteCommentPath = mDeleteCommentPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteCommentStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteCommentStartTime, mDeleteCommentPath, "Sending server request...");

            // make the HTTP request
            mDeleteCommentCoroutine.ResponseReceived += DeleteCommentCallback;
            mDeleteCommentCoroutine.Start(mDeleteCommentPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteCommentCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteComment: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteComment: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteCommentStartTime, mDeleteCommentPath, "Response received successfully.");
            if (DeleteCommentComplete != null)
            {
                DeleteCommentComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Return a comment 
        /// </summary>
        /// <param name="id">The comment id</param>
        public void GetComment(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetComment");
            }
            
            mGetCommentPath = "/comments/{id}";
            if (!string.IsNullOrEmpty(mGetCommentPath))
            {
                mGetCommentPath = mGetCommentPath.Replace("{format}", "json");
            }
            mGetCommentPath = mGetCommentPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetCommentStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCommentStartTime, mGetCommentPath, "Sending server request...");

            // make the HTTP request
            mGetCommentCoroutine.ResponseReceived += GetCommentCallback;
            mGetCommentCoroutine.Start(mGetCommentPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCommentCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetComment: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetComment: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCommentData = (CommentResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CommentResource), response.Headers);
            KnetikLogger.LogResponse(mGetCommentStartTime, mGetCommentPath, string.Format("Response received successfully:\n{0}", GetCommentData.ToString()));

            if (GetCommentComplete != null)
            {
                GetCommentComplete(GetCommentData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Returns a page of comments 
        /// </summary>
        /// <param name="context">Get comments by context type</param>
        /// <param name="contextId">Get comments by context id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetComments(string context, int? contextId, int? size, int? page)
        {
            // verify the required parameter 'context' is set
            if (context == null)
            {
                throw new KnetikException(400, "Missing required parameter 'context' when calling GetComments");
            }
            // verify the required parameter 'contextId' is set
            if (contextId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'contextId' when calling GetComments");
            }
            
            mGetCommentsPath = "/comments";
            if (!string.IsNullOrEmpty(mGetCommentsPath))
            {
                mGetCommentsPath = mGetCommentsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (context != null)
            {
                queryParams.Add("context", KnetikClient.DefaultClient.ParameterToString(context));
            }

            if (contextId != null)
            {
                queryParams.Add("context_id", KnetikClient.DefaultClient.ParameterToString(contextId));
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
            string[] authSettings = new string[] {  };

            mGetCommentsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCommentsStartTime, mGetCommentsPath, "Sending server request...");

            // make the HTTP request
            mGetCommentsCoroutine.ResponseReceived += GetCommentsCallback;
            mGetCommentsCoroutine.Start(mGetCommentsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCommentsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetComments: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetComments: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCommentsData = (PageResourceCommentResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceCommentResource), response.Headers);
            KnetikLogger.LogResponse(mGetCommentsStartTime, mGetCommentsPath, string.Format("Response received successfully:\n{0}", GetCommentsData.ToString()));

            if (GetCommentsComplete != null)
            {
                GetCommentsComplete(GetCommentsData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Search the comment index The body is an ElasticSearch query json. Please see their &lt;a href&#x3D;&#39;https://www.elastic.co/guide/en/elasticsearch/reference/current/index.html&#39;&gt;documentation&lt;/a&gt; for details on the format and search options
        /// </summary>
        /// <param name="query">The search query</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void SearchComments(Object query, int? size, int? page)
        {
            
            mSearchCommentsPath = "/comments/search";
            if (!string.IsNullOrEmpty(mSearchCommentsPath))
            {
                mSearchCommentsPath = mSearchCommentsPath.Replace("{format}", "json");
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

            postBody = KnetikClient.DefaultClient.Serialize(query); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mSearchCommentsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSearchCommentsStartTime, mSearchCommentsPath, "Sending server request...");

            // make the HTTP request
            mSearchCommentsCoroutine.ResponseReceived += SearchCommentsCallback;
            mSearchCommentsCoroutine.Start(mSearchCommentsPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SearchCommentsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SearchComments: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SearchComments: " + response.ErrorMessage, response.ErrorMessage);
            }

            SearchCommentsData = (PageResourceCommentResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceCommentResource), response.Headers);
            KnetikLogger.LogResponse(mSearchCommentsStartTime, mSearchCommentsPath, string.Format("Response received successfully:\n{0}", SearchCommentsData.ToString()));

            if (SearchCommentsComplete != null)
            {
                SearchCommentsComplete(SearchCommentsData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Update a comment 
        /// </summary>
        /// <param name="id">The comment id</param>
        /// <param name="content">The comment content</param>
        public void UpdateComment(long? id, StringWrapper content)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateComment");
            }
            
            mUpdateCommentPath = "/comments/{id}/content";
            if (!string.IsNullOrEmpty(mUpdateCommentPath))
            {
                mUpdateCommentPath = mUpdateCommentPath.Replace("{format}", "json");
            }
            mUpdateCommentPath = mUpdateCommentPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(content); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateCommentStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateCommentStartTime, mUpdateCommentPath, "Sending server request...");

            // make the HTTP request
            mUpdateCommentCoroutine.ResponseReceived += UpdateCommentCallback;
            mUpdateCommentCoroutine.Start(mUpdateCommentPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateCommentCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateComment: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateComment: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateCommentStartTime, mUpdateCommentPath, "Response received successfully.");
            if (UpdateCommentComplete != null)
            {
                UpdateCommentComplete();
            }
        }
    }
}
