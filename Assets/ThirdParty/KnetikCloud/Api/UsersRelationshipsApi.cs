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
    public interface IUsersRelationshipsApi
    {
        UserRelationshipResource CreateUserRelationshipData { get; }

        /// <summary>
        /// Create a user relationship &lt;b&gt;Permissions Needed:&lt;/b&gt; RELATIONSHIPS_ADMIN
        /// </summary>
        /// <param name="relationship">The new relationship</param>
        void CreateUserRelationship(UserRelationshipResource relationship);

        

        /// <summary>
        /// Delete a user relationship &lt;b&gt;Permissions Needed:&lt;/b&gt; RELATIONSHIPS_ADMIN
        /// </summary>
        /// <param name="id">The id of the relationship</param>
        void DeleteUserRelationship(long? id);

        UserRelationshipResource GetUserRelationshipData { get; }

        /// <summary>
        /// Get a user relationship &lt;b&gt;Permissions Needed:&lt;/b&gt; RELATIONSHIPS_USER or RELATIONSHIPS_ADMIN
        /// </summary>
        /// <param name="id">The id of the relationship</param>
        void GetUserRelationship(long? id);

        PageResourceUserRelationshipResource GetUserRelationshipsData { get; }

        /// <summary>
        /// Get a list of user relationships &lt;b&gt;Permissions Needed:&lt;/b&gt; RELATIONSHIPS_USER or RELATIONSHIPS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetUserRelationships(int? size, int? page, string order);

        UserRelationshipResource UpdateUserRelationshipData { get; }

        /// <summary>
        /// Update a user relationship &lt;b&gt;Permissions Needed:&lt;/b&gt; RELATIONSHIPS_ADMIN
        /// </summary>
        /// <param name="id">The id of the relationship</param>
        /// <param name="relationship">The new relationship</param>
        void UpdateUserRelationship(long? id, UserRelationshipResource relationship);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UsersRelationshipsApi : IUsersRelationshipsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateUserRelationshipResponseContext;
        private DateTime mCreateUserRelationshipStartTime;
        private readonly KnetikResponseContext mDeleteUserRelationshipResponseContext;
        private DateTime mDeleteUserRelationshipStartTime;
        private readonly KnetikResponseContext mGetUserRelationshipResponseContext;
        private DateTime mGetUserRelationshipStartTime;
        private readonly KnetikResponseContext mGetUserRelationshipsResponseContext;
        private DateTime mGetUserRelationshipsStartTime;
        private readonly KnetikResponseContext mUpdateUserRelationshipResponseContext;
        private DateTime mUpdateUserRelationshipStartTime;

        public UserRelationshipResource CreateUserRelationshipData { get; private set; }
        public delegate void CreateUserRelationshipCompleteDelegate(long responseCode, UserRelationshipResource response);
        public CreateUserRelationshipCompleteDelegate CreateUserRelationshipComplete;

        public delegate void DeleteUserRelationshipCompleteDelegate(long responseCode);
        public DeleteUserRelationshipCompleteDelegate DeleteUserRelationshipComplete;

        public UserRelationshipResource GetUserRelationshipData { get; private set; }
        public delegate void GetUserRelationshipCompleteDelegate(long responseCode, UserRelationshipResource response);
        public GetUserRelationshipCompleteDelegate GetUserRelationshipComplete;

        public PageResourceUserRelationshipResource GetUserRelationshipsData { get; private set; }
        public delegate void GetUserRelationshipsCompleteDelegate(long responseCode, PageResourceUserRelationshipResource response);
        public GetUserRelationshipsCompleteDelegate GetUserRelationshipsComplete;

        public UserRelationshipResource UpdateUserRelationshipData { get; private set; }
        public delegate void UpdateUserRelationshipCompleteDelegate(long responseCode, UserRelationshipResource response);
        public UpdateUserRelationshipCompleteDelegate UpdateUserRelationshipComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersRelationshipsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersRelationshipsApi()
        {
            mCreateUserRelationshipResponseContext = new KnetikResponseContext();
            mCreateUserRelationshipResponseContext.ResponseReceived += OnCreateUserRelationshipResponse;
            mDeleteUserRelationshipResponseContext = new KnetikResponseContext();
            mDeleteUserRelationshipResponseContext.ResponseReceived += OnDeleteUserRelationshipResponse;
            mGetUserRelationshipResponseContext = new KnetikResponseContext();
            mGetUserRelationshipResponseContext.ResponseReceived += OnGetUserRelationshipResponse;
            mGetUserRelationshipsResponseContext = new KnetikResponseContext();
            mGetUserRelationshipsResponseContext.ResponseReceived += OnGetUserRelationshipsResponse;
            mUpdateUserRelationshipResponseContext = new KnetikResponseContext();
            mUpdateUserRelationshipResponseContext.ResponseReceived += OnUpdateUserRelationshipResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a user relationship &lt;b&gt;Permissions Needed:&lt;/b&gt; RELATIONSHIPS_ADMIN
        /// </summary>
        /// <param name="relationship">The new relationship</param>
        public void CreateUserRelationship(UserRelationshipResource relationship)
        {
            
            mWebCallEvent.WebPath = "/users/relationships";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(relationship); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateUserRelationshipStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateUserRelationshipResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateUserRelationshipStartTime, "CreateUserRelationship", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateUserRelationshipResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateUserRelationship: " + response.Error);
            }

            CreateUserRelationshipData = (UserRelationshipResource) KnetikClient.Deserialize(response.Content, typeof(UserRelationshipResource), response.Headers);
            KnetikLogger.LogResponse(mCreateUserRelationshipStartTime, "CreateUserRelationship", string.Format("Response received successfully:\n{0}", CreateUserRelationshipData));

            if (CreateUserRelationshipComplete != null)
            {
                CreateUserRelationshipComplete(response.ResponseCode, CreateUserRelationshipData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a user relationship &lt;b&gt;Permissions Needed:&lt;/b&gt; RELATIONSHIPS_ADMIN
        /// </summary>
        /// <param name="id">The id of the relationship</param>
        public void DeleteUserRelationship(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteUserRelationship");
            }
            
            mWebCallEvent.WebPath = "/users/relationships/{id}";
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
            mDeleteUserRelationshipStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteUserRelationshipResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteUserRelationshipStartTime, "DeleteUserRelationship", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteUserRelationshipResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteUserRelationship: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteUserRelationshipStartTime, "DeleteUserRelationship", "Response received successfully.");
            if (DeleteUserRelationshipComplete != null)
            {
                DeleteUserRelationshipComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a user relationship &lt;b&gt;Permissions Needed:&lt;/b&gt; RELATIONSHIPS_USER or RELATIONSHIPS_ADMIN
        /// </summary>
        /// <param name="id">The id of the relationship</param>
        public void GetUserRelationship(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetUserRelationship");
            }
            
            mWebCallEvent.WebPath = "/users/relationships/{id}";
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
            mGetUserRelationshipStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserRelationshipResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserRelationshipStartTime, "GetUserRelationship", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserRelationshipResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserRelationship: " + response.Error);
            }

            GetUserRelationshipData = (UserRelationshipResource) KnetikClient.Deserialize(response.Content, typeof(UserRelationshipResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserRelationshipStartTime, "GetUserRelationship", string.Format("Response received successfully:\n{0}", GetUserRelationshipData));

            if (GetUserRelationshipComplete != null)
            {
                GetUserRelationshipComplete(response.ResponseCode, GetUserRelationshipData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a list of user relationships &lt;b&gt;Permissions Needed:&lt;/b&gt; RELATIONSHIPS_USER or RELATIONSHIPS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetUserRelationships(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/users/relationships";
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
            mGetUserRelationshipsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserRelationshipsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserRelationshipsStartTime, "GetUserRelationships", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserRelationshipsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserRelationships: " + response.Error);
            }

            GetUserRelationshipsData = (PageResourceUserRelationshipResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserRelationshipResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserRelationshipsStartTime, "GetUserRelationships", string.Format("Response received successfully:\n{0}", GetUserRelationshipsData));

            if (GetUserRelationshipsComplete != null)
            {
                GetUserRelationshipsComplete(response.ResponseCode, GetUserRelationshipsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a user relationship &lt;b&gt;Permissions Needed:&lt;/b&gt; RELATIONSHIPS_ADMIN
        /// </summary>
        /// <param name="id">The id of the relationship</param>
        /// <param name="relationship">The new relationship</param>
        public void UpdateUserRelationship(long? id, UserRelationshipResource relationship)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateUserRelationship");
            }
            
            mWebCallEvent.WebPath = "/users/relationships/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(relationship); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateUserRelationshipStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateUserRelationshipResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateUserRelationshipStartTime, "UpdateUserRelationship", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateUserRelationshipResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateUserRelationship: " + response.Error);
            }

            UpdateUserRelationshipData = (UserRelationshipResource) KnetikClient.Deserialize(response.Content, typeof(UserRelationshipResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateUserRelationshipStartTime, "UpdateUserRelationship", string.Format("Response received successfully:\n{0}", UpdateUserRelationshipData));

            if (UpdateUserRelationshipComplete != null)
            {
                UpdateUserRelationshipComplete(response.ResponseCode, UpdateUserRelationshipData);
            }
        }

    }
}
