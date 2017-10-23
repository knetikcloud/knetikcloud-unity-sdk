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
    public interface IUsersRelationshipsApi
    {
        UserRelationshipResource CreateUserRelationshipData { get; }

        UserRelationshipResource GetUserRelationshipData { get; }

        PageResourceUserRelationshipResource GetUserRelationshipsData { get; }

        UserRelationshipResource UpdateUserRelationshipData { get; }

        
        /// <summary>
        /// Create a user relationship 
        /// </summary>
        /// <param name="relationship">The new relationship</param>
        void CreateUserRelationship(UserRelationshipResource relationship);

        /// <summary>
        /// Delete a user relationship 
        /// </summary>
        /// <param name="id">The id of the relationship</param>
        void DeleteUserRelationship(long? id);

        /// <summary>
        /// Get a user relationship 
        /// </summary>
        /// <param name="id">The id of the relationship</param>
        void GetUserRelationship(long? id);

        /// <summary>
        /// Get a list of user relationships 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetUserRelationships(int? size, int? page, string order);

        /// <summary>
        /// Update a user relationship 
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
        private readonly KnetikCoroutine mCreateUserRelationshipCoroutine;
        private DateTime mCreateUserRelationshipStartTime;
        private string mCreateUserRelationshipPath;
        private readonly KnetikCoroutine mDeleteUserRelationshipCoroutine;
        private DateTime mDeleteUserRelationshipStartTime;
        private string mDeleteUserRelationshipPath;
        private readonly KnetikCoroutine mGetUserRelationshipCoroutine;
        private DateTime mGetUserRelationshipStartTime;
        private string mGetUserRelationshipPath;
        private readonly KnetikCoroutine mGetUserRelationshipsCoroutine;
        private DateTime mGetUserRelationshipsStartTime;
        private string mGetUserRelationshipsPath;
        private readonly KnetikCoroutine mUpdateUserRelationshipCoroutine;
        private DateTime mUpdateUserRelationshipStartTime;
        private string mUpdateUserRelationshipPath;

        public UserRelationshipResource CreateUserRelationshipData { get; private set; }
        public delegate void CreateUserRelationshipCompleteDelegate(UserRelationshipResource response);
        public CreateUserRelationshipCompleteDelegate CreateUserRelationshipComplete;

        public delegate void DeleteUserRelationshipCompleteDelegate();
        public DeleteUserRelationshipCompleteDelegate DeleteUserRelationshipComplete;

        public UserRelationshipResource GetUserRelationshipData { get; private set; }
        public delegate void GetUserRelationshipCompleteDelegate(UserRelationshipResource response);
        public GetUserRelationshipCompleteDelegate GetUserRelationshipComplete;

        public PageResourceUserRelationshipResource GetUserRelationshipsData { get; private set; }
        public delegate void GetUserRelationshipsCompleteDelegate(PageResourceUserRelationshipResource response);
        public GetUserRelationshipsCompleteDelegate GetUserRelationshipsComplete;

        public UserRelationshipResource UpdateUserRelationshipData { get; private set; }
        public delegate void UpdateUserRelationshipCompleteDelegate(UserRelationshipResource response);
        public UpdateUserRelationshipCompleteDelegate UpdateUserRelationshipComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersRelationshipsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersRelationshipsApi()
        {
            mCreateUserRelationshipCoroutine = new KnetikCoroutine();
            mDeleteUserRelationshipCoroutine = new KnetikCoroutine();
            mGetUserRelationshipCoroutine = new KnetikCoroutine();
            mGetUserRelationshipsCoroutine = new KnetikCoroutine();
            mUpdateUserRelationshipCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a user relationship 
        /// </summary>
        /// <param name="relationship">The new relationship</param>
        public void CreateUserRelationship(UserRelationshipResource relationship)
        {
            
            mCreateUserRelationshipPath = "/users/relationships";
            if (!string.IsNullOrEmpty(mCreateUserRelationshipPath))
            {
                mCreateUserRelationshipPath = mCreateUserRelationshipPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(relationship); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateUserRelationshipStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateUserRelationshipStartTime, mCreateUserRelationshipPath, "Sending server request...");

            // make the HTTP request
            mCreateUserRelationshipCoroutine.ResponseReceived += CreateUserRelationshipCallback;
            mCreateUserRelationshipCoroutine.Start(mCreateUserRelationshipPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateUserRelationshipCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateUserRelationship: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateUserRelationship: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateUserRelationshipData = (UserRelationshipResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(UserRelationshipResource), response.Headers);
            KnetikLogger.LogResponse(mCreateUserRelationshipStartTime, mCreateUserRelationshipPath, string.Format("Response received successfully:\n{0}", CreateUserRelationshipData.ToString()));

            if (CreateUserRelationshipComplete != null)
            {
                CreateUserRelationshipComplete(CreateUserRelationshipData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a user relationship 
        /// </summary>
        /// <param name="id">The id of the relationship</param>
        public void DeleteUserRelationship(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteUserRelationship");
            }
            
            mDeleteUserRelationshipPath = "/users/relationships/{id}";
            if (!string.IsNullOrEmpty(mDeleteUserRelationshipPath))
            {
                mDeleteUserRelationshipPath = mDeleteUserRelationshipPath.Replace("{format}", "json");
            }
            mDeleteUserRelationshipPath = mDeleteUserRelationshipPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteUserRelationshipStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteUserRelationshipStartTime, mDeleteUserRelationshipPath, "Sending server request...");

            // make the HTTP request
            mDeleteUserRelationshipCoroutine.ResponseReceived += DeleteUserRelationshipCallback;
            mDeleteUserRelationshipCoroutine.Start(mDeleteUserRelationshipPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteUserRelationshipCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteUserRelationship: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteUserRelationship: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteUserRelationshipStartTime, mDeleteUserRelationshipPath, "Response received successfully.");
            if (DeleteUserRelationshipComplete != null)
            {
                DeleteUserRelationshipComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a user relationship 
        /// </summary>
        /// <param name="id">The id of the relationship</param>
        public void GetUserRelationship(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetUserRelationship");
            }
            
            mGetUserRelationshipPath = "/users/relationships/{id}";
            if (!string.IsNullOrEmpty(mGetUserRelationshipPath))
            {
                mGetUserRelationshipPath = mGetUserRelationshipPath.Replace("{format}", "json");
            }
            mGetUserRelationshipPath = mGetUserRelationshipPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserRelationshipStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserRelationshipStartTime, mGetUserRelationshipPath, "Sending server request...");

            // make the HTTP request
            mGetUserRelationshipCoroutine.ResponseReceived += GetUserRelationshipCallback;
            mGetUserRelationshipCoroutine.Start(mGetUserRelationshipPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserRelationshipCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserRelationship: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserRelationship: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserRelationshipData = (UserRelationshipResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(UserRelationshipResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserRelationshipStartTime, mGetUserRelationshipPath, string.Format("Response received successfully:\n{0}", GetUserRelationshipData.ToString()));

            if (GetUserRelationshipComplete != null)
            {
                GetUserRelationshipComplete(GetUserRelationshipData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a list of user relationships 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetUserRelationships(int? size, int? page, string order)
        {
            
            mGetUserRelationshipsPath = "/users/relationships";
            if (!string.IsNullOrEmpty(mGetUserRelationshipsPath))
            {
                mGetUserRelationshipsPath = mGetUserRelationshipsPath.Replace("{format}", "json");
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserRelationshipsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserRelationshipsStartTime, mGetUserRelationshipsPath, "Sending server request...");

            // make the HTTP request
            mGetUserRelationshipsCoroutine.ResponseReceived += GetUserRelationshipsCallback;
            mGetUserRelationshipsCoroutine.Start(mGetUserRelationshipsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserRelationshipsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserRelationships: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserRelationships: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserRelationshipsData = (PageResourceUserRelationshipResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUserRelationshipResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserRelationshipsStartTime, mGetUserRelationshipsPath, string.Format("Response received successfully:\n{0}", GetUserRelationshipsData.ToString()));

            if (GetUserRelationshipsComplete != null)
            {
                GetUserRelationshipsComplete(GetUserRelationshipsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a user relationship 
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
            
            mUpdateUserRelationshipPath = "/users/relationships/{id}";
            if (!string.IsNullOrEmpty(mUpdateUserRelationshipPath))
            {
                mUpdateUserRelationshipPath = mUpdateUserRelationshipPath.Replace("{format}", "json");
            }
            mUpdateUserRelationshipPath = mUpdateUserRelationshipPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(relationship); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateUserRelationshipStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateUserRelationshipStartTime, mUpdateUserRelationshipPath, "Sending server request...");

            // make the HTTP request
            mUpdateUserRelationshipCoroutine.ResponseReceived += UpdateUserRelationshipCallback;
            mUpdateUserRelationshipCoroutine.Start(mUpdateUserRelationshipPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateUserRelationshipCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUserRelationship: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUserRelationship: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateUserRelationshipData = (UserRelationshipResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(UserRelationshipResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateUserRelationshipStartTime, mUpdateUserRelationshipPath, string.Format("Response received successfully:\n{0}", UpdateUserRelationshipData.ToString()));

            if (UpdateUserRelationshipComplete != null)
            {
                UpdateUserRelationshipComplete(UpdateUserRelationshipData);
            }
        }

    }
}
