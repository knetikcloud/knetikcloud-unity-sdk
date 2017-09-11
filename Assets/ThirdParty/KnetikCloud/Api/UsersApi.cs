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
    public interface IUsersApi
    {
        TemplateResource CreateUserTemplateData { get; }

        UserResource GetUserData { get; }

        List<string> GetUserTagsData { get; }

        TemplateResource GetUserTemplateData { get; }

        PageResourceTemplateResource GetUserTemplatesData { get; }

        PageResourceUserBaseResource GetUsersData { get; }

        UserResource RegisterUserData { get; }

        TemplateResource UpdateUserTemplateData { get; }

        
        /// <summary>
        /// Add a tag to a user 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="tag">tag</param>
        void AddUserTag(int? userId, StringWrapper tag);

        /// <summary>
        /// Create a user template User Templates define a type of user and the properties they have
        /// </summary>
        /// <param name="userTemplateResource">The user template resource object</param>
        void CreateUserTemplate(TemplateResource userTemplateResource);

        /// <summary>
        /// Delete a user template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteUserTemplate(string id, string cascade);

        /// <summary>
        /// Get a single user Additional private info is included as USERS_ADMIN
        /// </summary>
        /// <param name="id">The id of the user or &#39;me&#39;</param>
        void GetUser(string id);

        /// <summary>
        /// List tags for a user 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        void GetUserTags(int? userId);

        /// <summary>
        /// Get a single user template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetUserTemplate(string id);

        /// <summary>
        /// List and search user templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetUserTemplates(int? size, int? page, string order);

        /// <summary>
        /// List and search users Additional private info is included as USERS_ADMIN
        /// </summary>
        /// <param name="filterDisplayname">Filter for users whose display name starts with provided string.</param>
        /// <param name="filterEmail">Filter for users whose email starts with provided string. Requires USERS_ADMIN permission</param>
        /// <param name="filterFirstname">Filter for users whose first name starts with provided string. Requires USERS_ADMIN permission</param>
        /// <param name="filterFullname">Filter for users whose full name starts with provided string. Requires USERS_ADMIN permission</param>
        /// <param name="filterLastname">Filter for users whose last name starts with provided string. Requires USERS_ADMIN permission</param>
        /// <param name="filterUsername">Filter for users whose username starts with the provided string. Requires USERS_ADMIN permission</param>
        /// <param name="filterTag">Filter for users who have a given tag</param>
        /// <param name="filterGroup">Filter for users in a given group, by unique name</param>
        /// <param name="filterRole">Filter for users with a given role</param>
        /// <param name="filterSearch">Filter for users whose display_name starts with the provided string, or username if display_name is null</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetUsers(string filterDisplayname, string filterEmail, string filterFirstname, string filterFullname, string filterLastname, string filterUsername, string filterTag, string filterGroup, string filterRole, string filterSearch, int? size, int? page, string order);

        /// <summary>
        /// Choose a new password after a reset Finish resetting a user&#39;s password using the secret provided from the password-reset endpoint.  Password should be in plain text and will be encrypted on receipt. Use SSL for security.
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="newPasswordRequest">The new password request object</param>
        void PasswordReset(int? id, NewPasswordRequest newPasswordRequest);

        /// <summary>
        /// Register a new user Password should be in plain text and will be encrypted on receipt. Use SSL for security
        /// </summary>
        /// <param name="userResource">The user resource object</param>
        void RegisterUser(UserResource userResource);

        /// <summary>
        /// Remove a tag from a user 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="tag">The tag to remove</param>
        void RemoveUserTag(int? userId, string tag);

        /// <summary>
        /// Set a user&#39;s password Password should be in plain text and will be encrypted on receipt. Use SSL for security.
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="password">The new plain text password</param>
        void SetPassword(int? id, StringWrapper password);

        /// <summary>
        /// Reset a user&#39;s password A reset code will be generated and a &#39;forgot_password&#39; BRE event will be fired with that code.  The default system rule will send an email to the selected user if an email service has been setup. You can modify that rule in BRE to send an SMS instead or any other type of notification as you see fit
        /// </summary>
        /// <param name="id">The id of the user</param>
        void StartPasswordReset(int? id);

        /// <summary>
        /// Reset a user&#39;s password without user id A reset code will be generated and a &#39;forgot_password&#39; BRE event will be fired with that code.  The default system rule will send an email to the selected user if an email service has been setup. You can modify that rule in BRE to send an SMS instead or any other type of notification as you see fit.  Must submit their email, username, or mobile phone number
        /// </summary>
        /// <param name="passwordReset">An object containing one of three methods to look up a user</param>
        void SubmitPasswordReset(PasswordResetRequest passwordReset);

        /// <summary>
        /// Update a user Password will not be edited on this endpoint, use password specific endpoints.
        /// </summary>
        /// <param name="id">The id of the user or &#39;me&#39;</param>
        /// <param name="userResource">The user resource object</param>
        void UpdateUser(string id, UserResource userResource);

        /// <summary>
        /// Update a user template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="userTemplateResource">The user template resource object</param>
        void UpdateUserTemplate(string id, TemplateResource userTemplateResource);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UsersApi : IUsersApi
    {
        private readonly KnetikCoroutine mAddUserTagCoroutine;
        private DateTime mAddUserTagStartTime;
        private string mAddUserTagPath;
        private readonly KnetikCoroutine mCreateUserTemplateCoroutine;
        private DateTime mCreateUserTemplateStartTime;
        private string mCreateUserTemplatePath;
        private readonly KnetikCoroutine mDeleteUserTemplateCoroutine;
        private DateTime mDeleteUserTemplateStartTime;
        private string mDeleteUserTemplatePath;
        private readonly KnetikCoroutine mGetUserCoroutine;
        private DateTime mGetUserStartTime;
        private string mGetUserPath;
        private readonly KnetikCoroutine mGetUserTagsCoroutine;
        private DateTime mGetUserTagsStartTime;
        private string mGetUserTagsPath;
        private readonly KnetikCoroutine mGetUserTemplateCoroutine;
        private DateTime mGetUserTemplateStartTime;
        private string mGetUserTemplatePath;
        private readonly KnetikCoroutine mGetUserTemplatesCoroutine;
        private DateTime mGetUserTemplatesStartTime;
        private string mGetUserTemplatesPath;
        private readonly KnetikCoroutine mGetUsersCoroutine;
        private DateTime mGetUsersStartTime;
        private string mGetUsersPath;
        private readonly KnetikCoroutine mPasswordResetCoroutine;
        private DateTime mPasswordResetStartTime;
        private string mPasswordResetPath;
        private readonly KnetikCoroutine mRegisterUserCoroutine;
        private DateTime mRegisterUserStartTime;
        private string mRegisterUserPath;
        private readonly KnetikCoroutine mRemoveUserTagCoroutine;
        private DateTime mRemoveUserTagStartTime;
        private string mRemoveUserTagPath;
        private readonly KnetikCoroutine mSetPasswordCoroutine;
        private DateTime mSetPasswordStartTime;
        private string mSetPasswordPath;
        private readonly KnetikCoroutine mStartPasswordResetCoroutine;
        private DateTime mStartPasswordResetStartTime;
        private string mStartPasswordResetPath;
        private readonly KnetikCoroutine mSubmitPasswordResetCoroutine;
        private DateTime mSubmitPasswordResetStartTime;
        private string mSubmitPasswordResetPath;
        private readonly KnetikCoroutine mUpdateUserCoroutine;
        private DateTime mUpdateUserStartTime;
        private string mUpdateUserPath;
        private readonly KnetikCoroutine mUpdateUserTemplateCoroutine;
        private DateTime mUpdateUserTemplateStartTime;
        private string mUpdateUserTemplatePath;

        public delegate void AddUserTagCompleteDelegate();
        public AddUserTagCompleteDelegate AddUserTagComplete;

        public TemplateResource CreateUserTemplateData { get; private set; }
        public delegate void CreateUserTemplateCompleteDelegate(TemplateResource response);
        public CreateUserTemplateCompleteDelegate CreateUserTemplateComplete;

        public delegate void DeleteUserTemplateCompleteDelegate();
        public DeleteUserTemplateCompleteDelegate DeleteUserTemplateComplete;

        public UserResource GetUserData { get; private set; }
        public delegate void GetUserCompleteDelegate(UserResource response);
        public GetUserCompleteDelegate GetUserComplete;

        public List<string> GetUserTagsData { get; private set; }
        public delegate void GetUserTagsCompleteDelegate(List<string> response);
        public GetUserTagsCompleteDelegate GetUserTagsComplete;

        public TemplateResource GetUserTemplateData { get; private set; }
        public delegate void GetUserTemplateCompleteDelegate(TemplateResource response);
        public GetUserTemplateCompleteDelegate GetUserTemplateComplete;

        public PageResourceTemplateResource GetUserTemplatesData { get; private set; }
        public delegate void GetUserTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetUserTemplatesCompleteDelegate GetUserTemplatesComplete;

        public PageResourceUserBaseResource GetUsersData { get; private set; }
        public delegate void GetUsersCompleteDelegate(PageResourceUserBaseResource response);
        public GetUsersCompleteDelegate GetUsersComplete;

        public delegate void PasswordResetCompleteDelegate();
        public PasswordResetCompleteDelegate PasswordResetComplete;

        public UserResource RegisterUserData { get; private set; }
        public delegate void RegisterUserCompleteDelegate(UserResource response);
        public RegisterUserCompleteDelegate RegisterUserComplete;

        public delegate void RemoveUserTagCompleteDelegate();
        public RemoveUserTagCompleteDelegate RemoveUserTagComplete;

        public delegate void SetPasswordCompleteDelegate();
        public SetPasswordCompleteDelegate SetPasswordComplete;

        public delegate void StartPasswordResetCompleteDelegate();
        public StartPasswordResetCompleteDelegate StartPasswordResetComplete;

        public delegate void SubmitPasswordResetCompleteDelegate();
        public SubmitPasswordResetCompleteDelegate SubmitPasswordResetComplete;

        public delegate void UpdateUserCompleteDelegate();
        public UpdateUserCompleteDelegate UpdateUserComplete;

        public TemplateResource UpdateUserTemplateData { get; private set; }
        public delegate void UpdateUserTemplateCompleteDelegate(TemplateResource response);
        public UpdateUserTemplateCompleteDelegate UpdateUserTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
            mAddUserTagCoroutine = new KnetikCoroutine(KnetikClient);
            mCreateUserTemplateCoroutine = new KnetikCoroutine(KnetikClient);
            mDeleteUserTemplateCoroutine = new KnetikCoroutine(KnetikClient);
            mGetUserCoroutine = new KnetikCoroutine(KnetikClient);
            mGetUserTagsCoroutine = new KnetikCoroutine(KnetikClient);
            mGetUserTemplateCoroutine = new KnetikCoroutine(KnetikClient);
            mGetUserTemplatesCoroutine = new KnetikCoroutine(KnetikClient);
            mGetUsersCoroutine = new KnetikCoroutine(KnetikClient);
            mPasswordResetCoroutine = new KnetikCoroutine(KnetikClient);
            mRegisterUserCoroutine = new KnetikCoroutine(KnetikClient);
            mRemoveUserTagCoroutine = new KnetikCoroutine(KnetikClient);
            mSetPasswordCoroutine = new KnetikCoroutine(KnetikClient);
            mStartPasswordResetCoroutine = new KnetikCoroutine(KnetikClient);
            mSubmitPasswordResetCoroutine = new KnetikCoroutine(KnetikClient);
            mUpdateUserCoroutine = new KnetikCoroutine(KnetikClient);
            mUpdateUserTemplateCoroutine = new KnetikCoroutine(KnetikClient);
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient { get; private set; }

        /// <summary>
        /// Add a tag to a user 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="tag">tag</param>
        public void AddUserTag(int? userId, StringWrapper tag)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling AddUserTag");
            }
            // verify the required parameter 'tag' is set
            if (tag == null)
            {
                throw new KnetikException(400, "Missing required parameter 'tag' when calling AddUserTag");
            }
            
            mAddUserTagPath = "/users/{user_id}/tags";
            if (!string.IsNullOrEmpty(mAddUserTagPath))
            {
                mAddUserTagPath = mAddUserTagPath.Replace("{format}", "json");
            }
            mAddUserTagPath = mAddUserTagPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(tag); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddUserTagStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddUserTagStartTime, mAddUserTagPath, "Sending server request...");

            // make the HTTP request
            mAddUserTagCoroutine.ResponseReceived += AddUserTagCallback;
            mAddUserTagCoroutine.Start(mAddUserTagPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddUserTagCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddUserTag: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddUserTag: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mAddUserTagStartTime, mAddUserTagPath, "Response received successfully.");
            if (AddUserTagComplete != null)
            {
                AddUserTagComplete();
            }
        }
        /// <summary>
        /// Create a user template User Templates define a type of user and the properties they have
        /// </summary>
        /// <param name="userTemplateResource">The user template resource object</param>
        public void CreateUserTemplate(TemplateResource userTemplateResource)
        {
            
            mCreateUserTemplatePath = "/users/templates";
            if (!string.IsNullOrEmpty(mCreateUserTemplatePath))
            {
                mCreateUserTemplatePath = mCreateUserTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(userTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateUserTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateUserTemplateStartTime, mCreateUserTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateUserTemplateCoroutine.ResponseReceived += CreateUserTemplateCallback;
            mCreateUserTemplateCoroutine.Start(mCreateUserTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateUserTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateUserTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateUserTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateUserTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateUserTemplateStartTime, mCreateUserTemplatePath, string.Format("Response received successfully:\n{0}", CreateUserTemplateData.ToString()));

            if (CreateUserTemplateComplete != null)
            {
                CreateUserTemplateComplete(CreateUserTemplateData);
            }
        }
        /// <summary>
        /// Delete a user template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteUserTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteUserTemplate");
            }
            
            mDeleteUserTemplatePath = "/users/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteUserTemplatePath))
            {
                mDeleteUserTemplatePath = mDeleteUserTemplatePath.Replace("{format}", "json");
            }
            mDeleteUserTemplatePath = mDeleteUserTemplatePath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.ParameterToString(cascade));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteUserTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteUserTemplateStartTime, mDeleteUserTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteUserTemplateCoroutine.ResponseReceived += DeleteUserTemplateCallback;
            mDeleteUserTemplateCoroutine.Start(mDeleteUserTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteUserTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteUserTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteUserTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteUserTemplateStartTime, mDeleteUserTemplatePath, "Response received successfully.");
            if (DeleteUserTemplateComplete != null)
            {
                DeleteUserTemplateComplete();
            }
        }
        /// <summary>
        /// Get a single user Additional private info is included as USERS_ADMIN
        /// </summary>
        /// <param name="id">The id of the user or &#39;me&#39;</param>
        public void GetUser(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetUser");
            }
            
            mGetUserPath = "/users/{id}";
            if (!string.IsNullOrEmpty(mGetUserPath))
            {
                mGetUserPath = mGetUserPath.Replace("{format}", "json");
            }
            mGetUserPath = mGetUserPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetUserStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserStartTime, mGetUserPath, "Sending server request...");

            // make the HTTP request
            mGetUserCoroutine.ResponseReceived += GetUserCallback;
            mGetUserCoroutine.Start(mGetUserPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUser: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUser: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserData = (UserResource) KnetikClient.Deserialize(response.Content, typeof(UserResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserStartTime, mGetUserPath, string.Format("Response received successfully:\n{0}", GetUserData.ToString()));

            if (GetUserComplete != null)
            {
                GetUserComplete(GetUserData);
            }
        }
        /// <summary>
        /// List tags for a user 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        public void GetUserTags(int? userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserTags");
            }
            
            mGetUserTagsPath = "/users/{user_id}/tags";
            if (!string.IsNullOrEmpty(mGetUserTagsPath))
            {
                mGetUserTagsPath = mGetUserTagsPath.Replace("{format}", "json");
            }
            mGetUserTagsPath = mGetUserTagsPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserTagsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserTagsStartTime, mGetUserTagsPath, "Sending server request...");

            // make the HTTP request
            mGetUserTagsCoroutine.ResponseReceived += GetUserTagsCallback;
            mGetUserTagsCoroutine.Start(mGetUserTagsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserTagsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserTags: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserTags: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserTagsData = (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetUserTagsStartTime, mGetUserTagsPath, string.Format("Response received successfully:\n{0}", GetUserTagsData.ToString()));

            if (GetUserTagsComplete != null)
            {
                GetUserTagsComplete(GetUserTagsData);
            }
        }
        /// <summary>
        /// Get a single user template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetUserTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetUserTemplate");
            }
            
            mGetUserTemplatePath = "/users/templates/{id}";
            if (!string.IsNullOrEmpty(mGetUserTemplatePath))
            {
                mGetUserTemplatePath = mGetUserTemplatePath.Replace("{format}", "json");
            }
            mGetUserTemplatePath = mGetUserTemplatePath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserTemplateStartTime, mGetUserTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetUserTemplateCoroutine.ResponseReceived += GetUserTemplateCallback;
            mGetUserTemplateCoroutine.Start(mGetUserTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserTemplateStartTime, mGetUserTemplatePath, string.Format("Response received successfully:\n{0}", GetUserTemplateData.ToString()));

            if (GetUserTemplateComplete != null)
            {
                GetUserTemplateComplete(GetUserTemplateData);
            }
        }
        /// <summary>
        /// List and search user templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetUserTemplates(int? size, int? page, string order)
        {
            
            mGetUserTemplatesPath = "/users/templates";
            if (!string.IsNullOrEmpty(mGetUserTemplatesPath))
            {
                mGetUserTemplatesPath = mGetUserTemplatesPath.Replace("{format}", "json");
            }
            
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

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserTemplatesStartTime, mGetUserTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetUserTemplatesCoroutine.ResponseReceived += GetUserTemplatesCallback;
            mGetUserTemplatesCoroutine.Start(mGetUserTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserTemplatesStartTime, mGetUserTemplatesPath, string.Format("Response received successfully:\n{0}", GetUserTemplatesData.ToString()));

            if (GetUserTemplatesComplete != null)
            {
                GetUserTemplatesComplete(GetUserTemplatesData);
            }
        }
        /// <summary>
        /// List and search users Additional private info is included as USERS_ADMIN
        /// </summary>
        /// <param name="filterDisplayname">Filter for users whose display name starts with provided string.</param>
        /// <param name="filterEmail">Filter for users whose email starts with provided string. Requires USERS_ADMIN permission</param>
        /// <param name="filterFirstname">Filter for users whose first name starts with provided string. Requires USERS_ADMIN permission</param>
        /// <param name="filterFullname">Filter for users whose full name starts with provided string. Requires USERS_ADMIN permission</param>
        /// <param name="filterLastname">Filter for users whose last name starts with provided string. Requires USERS_ADMIN permission</param>
        /// <param name="filterUsername">Filter for users whose username starts with the provided string. Requires USERS_ADMIN permission</param>
        /// <param name="filterTag">Filter for users who have a given tag</param>
        /// <param name="filterGroup">Filter for users in a given group, by unique name</param>
        /// <param name="filterRole">Filter for users with a given role</param>
        /// <param name="filterSearch">Filter for users whose display_name starts with the provided string, or username if display_name is null</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetUsers(string filterDisplayname, string filterEmail, string filterFirstname, string filterFullname, string filterLastname, string filterUsername, string filterTag, string filterGroup, string filterRole, string filterSearch, int? size, int? page, string order)
        {
            
            mGetUsersPath = "/users";
            if (!string.IsNullOrEmpty(mGetUsersPath))
            {
                mGetUsersPath = mGetUsersPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterDisplayname != null)
            {
                queryParams.Add("filter_displayname", KnetikClient.ParameterToString(filterDisplayname));
            }

            if (filterEmail != null)
            {
                queryParams.Add("filter_email", KnetikClient.ParameterToString(filterEmail));
            }

            if (filterFirstname != null)
            {
                queryParams.Add("filter_firstname", KnetikClient.ParameterToString(filterFirstname));
            }

            if (filterFullname != null)
            {
                queryParams.Add("filter_fullname", KnetikClient.ParameterToString(filterFullname));
            }

            if (filterLastname != null)
            {
                queryParams.Add("filter_lastname", KnetikClient.ParameterToString(filterLastname));
            }

            if (filterUsername != null)
            {
                queryParams.Add("filter_username", KnetikClient.ParameterToString(filterUsername));
            }

            if (filterTag != null)
            {
                queryParams.Add("filter_tag", KnetikClient.ParameterToString(filterTag));
            }

            if (filterGroup != null)
            {
                queryParams.Add("filter_group", KnetikClient.ParameterToString(filterGroup));
            }

            if (filterRole != null)
            {
                queryParams.Add("filter_role", KnetikClient.ParameterToString(filterRole));
            }

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.ParameterToString(filterSearch));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetUsersStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUsersStartTime, mGetUsersPath, "Sending server request...");

            // make the HTTP request
            mGetUsersCoroutine.ResponseReceived += GetUsersCallback;
            mGetUsersCoroutine.Start(mGetUsersPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUsersCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsers: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUsersData = (PageResourceUserBaseResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserBaseResource), response.Headers);
            KnetikLogger.LogResponse(mGetUsersStartTime, mGetUsersPath, string.Format("Response received successfully:\n{0}", GetUsersData.ToString()));

            if (GetUsersComplete != null)
            {
                GetUsersComplete(GetUsersData);
            }
        }
        /// <summary>
        /// Choose a new password after a reset Finish resetting a user&#39;s password using the secret provided from the password-reset endpoint.  Password should be in plain text and will be encrypted on receipt. Use SSL for security.
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="newPasswordRequest">The new password request object</param>
        public void PasswordReset(int? id, NewPasswordRequest newPasswordRequest)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling PasswordReset");
            }
            
            mPasswordResetPath = "/users/{id}/password-reset";
            if (!string.IsNullOrEmpty(mPasswordResetPath))
            {
                mPasswordResetPath = mPasswordResetPath.Replace("{format}", "json");
            }
            mPasswordResetPath = mPasswordResetPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(newPasswordRequest); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mPasswordResetStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mPasswordResetStartTime, mPasswordResetPath, "Sending server request...");

            // make the HTTP request
            mPasswordResetCoroutine.ResponseReceived += PasswordResetCallback;
            mPasswordResetCoroutine.Start(mPasswordResetPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void PasswordResetCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling PasswordReset: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling PasswordReset: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mPasswordResetStartTime, mPasswordResetPath, "Response received successfully.");
            if (PasswordResetComplete != null)
            {
                PasswordResetComplete();
            }
        }
        /// <summary>
        /// Register a new user Password should be in plain text and will be encrypted on receipt. Use SSL for security
        /// </summary>
        /// <param name="userResource">The user resource object</param>
        public void RegisterUser(UserResource userResource)
        {
            
            mRegisterUserPath = "/users";
            if (!string.IsNullOrEmpty(mRegisterUserPath))
            {
                mRegisterUserPath = mRegisterUserPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(userResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mRegisterUserStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mRegisterUserStartTime, mRegisterUserPath, "Sending server request...");

            // make the HTTP request
            mRegisterUserCoroutine.ResponseReceived += RegisterUserCallback;
            mRegisterUserCoroutine.Start(mRegisterUserPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void RegisterUserCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RegisterUser: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RegisterUser: " + response.ErrorMessage, response.ErrorMessage);
            }

            RegisterUserData = (UserResource) KnetikClient.Deserialize(response.Content, typeof(UserResource), response.Headers);
            KnetikLogger.LogResponse(mRegisterUserStartTime, mRegisterUserPath, string.Format("Response received successfully:\n{0}", RegisterUserData.ToString()));

            if (RegisterUserComplete != null)
            {
                RegisterUserComplete(RegisterUserData);
            }
        }
        /// <summary>
        /// Remove a tag from a user 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="tag">The tag to remove</param>
        public void RemoveUserTag(int? userId, string tag)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling RemoveUserTag");
            }
            // verify the required parameter 'tag' is set
            if (tag == null)
            {
                throw new KnetikException(400, "Missing required parameter 'tag' when calling RemoveUserTag");
            }
            
            mRemoveUserTagPath = "/users/{user_id}/tags/{tag}";
            if (!string.IsNullOrEmpty(mRemoveUserTagPath))
            {
                mRemoveUserTagPath = mRemoveUserTagPath.Replace("{format}", "json");
            }
            mRemoveUserTagPath = mRemoveUserTagPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mRemoveUserTagPath = mRemoveUserTagPath.Replace("{" + "tag" + "}", KnetikClient.ParameterToString(tag));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mRemoveUserTagStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mRemoveUserTagStartTime, mRemoveUserTagPath, "Sending server request...");

            // make the HTTP request
            mRemoveUserTagCoroutine.ResponseReceived += RemoveUserTagCallback;
            mRemoveUserTagCoroutine.Start(mRemoveUserTagPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void RemoveUserTagCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveUserTag: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveUserTag: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mRemoveUserTagStartTime, mRemoveUserTagPath, "Response received successfully.");
            if (RemoveUserTagComplete != null)
            {
                RemoveUserTagComplete();
            }
        }
        /// <summary>
        /// Set a user&#39;s password Password should be in plain text and will be encrypted on receipt. Use SSL for security.
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="password">The new plain text password</param>
        public void SetPassword(int? id, StringWrapper password)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SetPassword");
            }
            
            mSetPasswordPath = "/users/{id}/password";
            if (!string.IsNullOrEmpty(mSetPasswordPath))
            {
                mSetPasswordPath = mSetPasswordPath.Replace("{format}", "json");
            }
            mSetPasswordPath = mSetPasswordPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(password); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetPasswordStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetPasswordStartTime, mSetPasswordPath, "Sending server request...");

            // make the HTTP request
            mSetPasswordCoroutine.ResponseReceived += SetPasswordCallback;
            mSetPasswordCoroutine.Start(mSetPasswordPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetPasswordCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetPassword: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetPassword: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetPasswordStartTime, mSetPasswordPath, "Response received successfully.");
            if (SetPasswordComplete != null)
            {
                SetPasswordComplete();
            }
        }
        /// <summary>
        /// Reset a user&#39;s password A reset code will be generated and a &#39;forgot_password&#39; BRE event will be fired with that code.  The default system rule will send an email to the selected user if an email service has been setup. You can modify that rule in BRE to send an SMS instead or any other type of notification as you see fit
        /// </summary>
        /// <param name="id">The id of the user</param>
        public void StartPasswordReset(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling StartPasswordReset");
            }
            
            mStartPasswordResetPath = "/users/{id}/password-reset";
            if (!string.IsNullOrEmpty(mStartPasswordResetPath))
            {
                mStartPasswordResetPath = mStartPasswordResetPath.Replace("{format}", "json");
            }
            mStartPasswordResetPath = mStartPasswordResetPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mStartPasswordResetStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mStartPasswordResetStartTime, mStartPasswordResetPath, "Sending server request...");

            // make the HTTP request
            mStartPasswordResetCoroutine.ResponseReceived += StartPasswordResetCallback;
            mStartPasswordResetCoroutine.Start(mStartPasswordResetPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void StartPasswordResetCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling StartPasswordReset: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling StartPasswordReset: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mStartPasswordResetStartTime, mStartPasswordResetPath, "Response received successfully.");
            if (StartPasswordResetComplete != null)
            {
                StartPasswordResetComplete();
            }
        }
        /// <summary>
        /// Reset a user&#39;s password without user id A reset code will be generated and a &#39;forgot_password&#39; BRE event will be fired with that code.  The default system rule will send an email to the selected user if an email service has been setup. You can modify that rule in BRE to send an SMS instead or any other type of notification as you see fit.  Must submit their email, username, or mobile phone number
        /// </summary>
        /// <param name="passwordReset">An object containing one of three methods to look up a user</param>
        public void SubmitPasswordReset(PasswordResetRequest passwordReset)
        {
            
            mSubmitPasswordResetPath = "/users/password-reset";
            if (!string.IsNullOrEmpty(mSubmitPasswordResetPath))
            {
                mSubmitPasswordResetPath = mSubmitPasswordResetPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(passwordReset); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mSubmitPasswordResetStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSubmitPasswordResetStartTime, mSubmitPasswordResetPath, "Sending server request...");

            // make the HTTP request
            mSubmitPasswordResetCoroutine.ResponseReceived += SubmitPasswordResetCallback;
            mSubmitPasswordResetCoroutine.Start(mSubmitPasswordResetPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SubmitPasswordResetCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SubmitPasswordReset: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SubmitPasswordReset: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSubmitPasswordResetStartTime, mSubmitPasswordResetPath, "Response received successfully.");
            if (SubmitPasswordResetComplete != null)
            {
                SubmitPasswordResetComplete();
            }
        }
        /// <summary>
        /// Update a user Password will not be edited on this endpoint, use password specific endpoints.
        /// </summary>
        /// <param name="id">The id of the user or &#39;me&#39;</param>
        /// <param name="userResource">The user resource object</param>
        public void UpdateUser(string id, UserResource userResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateUser");
            }
            
            mUpdateUserPath = "/users/{id}";
            if (!string.IsNullOrEmpty(mUpdateUserPath))
            {
                mUpdateUserPath = mUpdateUserPath.Replace("{format}", "json");
            }
            mUpdateUserPath = mUpdateUserPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(userResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateUserStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateUserStartTime, mUpdateUserPath, "Sending server request...");

            // make the HTTP request
            mUpdateUserCoroutine.ResponseReceived += UpdateUserCallback;
            mUpdateUserCoroutine.Start(mUpdateUserPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateUserCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUser: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUser: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateUserStartTime, mUpdateUserPath, "Response received successfully.");
            if (UpdateUserComplete != null)
            {
                UpdateUserComplete();
            }
        }
        /// <summary>
        /// Update a user template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="userTemplateResource">The user template resource object</param>
        public void UpdateUserTemplate(string id, TemplateResource userTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateUserTemplate");
            }
            
            mUpdateUserTemplatePath = "/users/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateUserTemplatePath))
            {
                mUpdateUserTemplatePath = mUpdateUserTemplatePath.Replace("{format}", "json");
            }
            mUpdateUserTemplatePath = mUpdateUserTemplatePath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(userTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateUserTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateUserTemplateStartTime, mUpdateUserTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateUserTemplateCoroutine.ResponseReceived += UpdateUserTemplateCallback;
            mUpdateUserTemplateCoroutine.Start(mUpdateUserTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateUserTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUserTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateUserTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateUserTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateUserTemplateStartTime, mUpdateUserTemplatePath, string.Format("Response received successfully:\n{0}", UpdateUserTemplateData.ToString()));

            if (UpdateUserTemplateComplete != null)
            {
                UpdateUserTemplateComplete(UpdateUserTemplateData);
            }
        }
    }
}
