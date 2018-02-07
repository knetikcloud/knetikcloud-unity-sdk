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
    public interface IContentCommentsApi
    {
        CommentResource AddCommentData { get; }

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

        CommentResource GetCommentData { get; }

        /// <summary>
        /// Return a comment 
        /// </summary>
        /// <param name="id">The comment id</param>
        void GetComment(long? id);

        PageResourceCommentResource GetCommentsData { get; }

        /// <summary>
        /// Returns a page of comments 
        /// </summary>
        /// <param name="context">Get comments by context type</param>
        /// <param name="contextId">Get comments by context id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetComments(string context, int? contextId, int? size, int? page);

        

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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddCommentResponseContext;
        private DateTime mAddCommentStartTime;
        private readonly KnetikResponseContext mDeleteCommentResponseContext;
        private DateTime mDeleteCommentStartTime;
        private readonly KnetikResponseContext mGetCommentResponseContext;
        private DateTime mGetCommentStartTime;
        private readonly KnetikResponseContext mGetCommentsResponseContext;
        private DateTime mGetCommentsStartTime;
        private readonly KnetikResponseContext mUpdateCommentResponseContext;
        private DateTime mUpdateCommentStartTime;

        public CommentResource AddCommentData { get; private set; }
        public delegate void AddCommentCompleteDelegate(long responseCode, CommentResource response);
        public AddCommentCompleteDelegate AddCommentComplete;

        public delegate void DeleteCommentCompleteDelegate(long responseCode);
        public DeleteCommentCompleteDelegate DeleteCommentComplete;

        public CommentResource GetCommentData { get; private set; }
        public delegate void GetCommentCompleteDelegate(long responseCode, CommentResource response);
        public GetCommentCompleteDelegate GetCommentComplete;

        public PageResourceCommentResource GetCommentsData { get; private set; }
        public delegate void GetCommentsCompleteDelegate(long responseCode, PageResourceCommentResource response);
        public GetCommentsCompleteDelegate GetCommentsComplete;

        public delegate void UpdateCommentCompleteDelegate(long responseCode);
        public UpdateCommentCompleteDelegate UpdateCommentComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentCommentsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ContentCommentsApi()
        {
            mAddCommentResponseContext = new KnetikResponseContext();
            mAddCommentResponseContext.ResponseReceived += OnAddCommentResponse;
            mDeleteCommentResponseContext = new KnetikResponseContext();
            mDeleteCommentResponseContext.ResponseReceived += OnDeleteCommentResponse;
            mGetCommentResponseContext = new KnetikResponseContext();
            mGetCommentResponseContext.ResponseReceived += OnGetCommentResponse;
            mGetCommentsResponseContext = new KnetikResponseContext();
            mGetCommentsResponseContext.ResponseReceived += OnGetCommentsResponse;
            mUpdateCommentResponseContext = new KnetikResponseContext();
            mUpdateCommentResponseContext.ResponseReceived += OnUpdateCommentResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a new comment 
        /// </summary>
        /// <param name="commentResource">The comment to be added</param>
        public void AddComment(CommentResource commentResource)
        {
            
            mWebCallEvent.WebPath = "/comments";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(commentResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddCommentStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddCommentResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddCommentStartTime, "AddComment", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddCommentResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddComment: " + response.Error);
            }

            AddCommentData = (CommentResource) KnetikClient.Deserialize(response.Content, typeof(CommentResource), response.Headers);
            KnetikLogger.LogResponse(mAddCommentStartTime, "AddComment", string.Format("Response received successfully:\n{0}", AddCommentData));

            if (AddCommentComplete != null)
            {
                AddCommentComplete(response.ResponseCode, AddCommentData);
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
            
            mWebCallEvent.WebPath = "/comments/{id}";
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
            mDeleteCommentStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteCommentResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteCommentStartTime, "DeleteComment", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteCommentResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteComment: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteCommentStartTime, "DeleteComment", "Response received successfully.");
            if (DeleteCommentComplete != null)
            {
                DeleteCommentComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/comments/{id}";
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
            mGetCommentStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCommentResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCommentStartTime, "GetComment", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCommentResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetComment: " + response.Error);
            }

            GetCommentData = (CommentResource) KnetikClient.Deserialize(response.Content, typeof(CommentResource), response.Headers);
            KnetikLogger.LogResponse(mGetCommentStartTime, "GetComment", string.Format("Response received successfully:\n{0}", GetCommentData));

            if (GetCommentComplete != null)
            {
                GetCommentComplete(response.ResponseCode, GetCommentData);
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
            
            mWebCallEvent.WebPath = "/comments";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (context != null)
            {
                mWebCallEvent.QueryParams["context"] = KnetikClient.ParameterToString(context);
            }

            if (contextId != null)
            {
                mWebCallEvent.QueryParams["context_id"] = KnetikClient.ParameterToString(contextId);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetCommentsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCommentsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCommentsStartTime, "GetComments", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCommentsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetComments: " + response.Error);
            }

            GetCommentsData = (PageResourceCommentResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceCommentResource), response.Headers);
            KnetikLogger.LogResponse(mGetCommentsStartTime, "GetComments", string.Format("Response received successfully:\n{0}", GetCommentsData));

            if (GetCommentsComplete != null)
            {
                GetCommentsComplete(response.ResponseCode, GetCommentsData);
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
            
            mWebCallEvent.WebPath = "/comments/{id}/content";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(content); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateCommentStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateCommentResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateCommentStartTime, "UpdateComment", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateCommentResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateComment: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateCommentStartTime, "UpdateComment", "Response received successfully.");
            if (UpdateCommentComplete != null)
            {
                UpdateCommentComplete(response.ResponseCode);
            }
        }

    }
}
