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
    public interface IUsersApi
    {
        

        /// <summary>
        /// Add a tag to a user 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="tag">tag</param>
        void AddUserTag(int? userId, StringWrapper tag);

        TemplateResource CreateUserTemplateData { get; }

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

        UserResource GetUserData { get; }

        /// <summary>
        /// Get a single user Additional private info is included as USERS_ADMIN
        /// </summary>
        /// <param name="id">The id of the user or &#39;me&#39;</param>
        void GetUser(string id);

        List<string> GetUserTagsData { get; }

        /// <summary>
        /// List tags for a user 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        void GetUserTags(int? userId);

        TemplateResource GetUserTemplateData { get; }

        /// <summary>
        /// Get a single user template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetUserTemplate(string id);

        PageResourceTemplateResource GetUserTemplatesData { get; }

        /// <summary>
        /// List and search user templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetUserTemplates(int? size, int? page, string order);

        PageResourceUserBaseResource GetUsersData { get; }

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
        /// <param name="filterLastActivity">A comma separated string without spaces.  First value is the operator to search on, second value is the date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterIdList">A comma separated list of ids.</param>
        /// <param name="filterSearch">Filter for users whose display_name starts with the provided string, or username if display_name is null</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetUsers(string filterDisplayname, string filterEmail, string filterFirstname, string filterFullname, string filterLastname, string filterUsername, string filterTag, string filterGroup, string filterRole, string filterLastActivity, string filterIdList, string filterSearch, int? size, int? page, string order);

        

        /// <summary>
        /// Choose a new password after a reset Finish resetting a user&#39;s password using the secret provided from the password-reset endpoint.  Password should be in plain text and will be encrypted on receipt. Use SSL for security.
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <param name="newPasswordRequest">The new password request object</param>
        void PasswordReset(int? id, NewPasswordRequest newPasswordRequest);

        UserResource RegisterUserData { get; }

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

        TemplateResource UpdateUserTemplateData { get; }

        /// <summary>
        /// Update a user template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="userTemplateResource">The user template resource object</param>
        void UpdateUserTemplate(string id, TemplateResource userTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UsersApi : IUsersApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddUserTagResponseContext;
        private DateTime mAddUserTagStartTime;
        private readonly KnetikResponseContext mCreateUserTemplateResponseContext;
        private DateTime mCreateUserTemplateStartTime;
        private readonly KnetikResponseContext mDeleteUserTemplateResponseContext;
        private DateTime mDeleteUserTemplateStartTime;
        private readonly KnetikResponseContext mGetUserResponseContext;
        private DateTime mGetUserStartTime;
        private readonly KnetikResponseContext mGetUserTagsResponseContext;
        private DateTime mGetUserTagsStartTime;
        private readonly KnetikResponseContext mGetUserTemplateResponseContext;
        private DateTime mGetUserTemplateStartTime;
        private readonly KnetikResponseContext mGetUserTemplatesResponseContext;
        private DateTime mGetUserTemplatesStartTime;
        private readonly KnetikResponseContext mGetUsersResponseContext;
        private DateTime mGetUsersStartTime;
        private readonly KnetikResponseContext mPasswordResetResponseContext;
        private DateTime mPasswordResetStartTime;
        private readonly KnetikResponseContext mRegisterUserResponseContext;
        private DateTime mRegisterUserStartTime;
        private readonly KnetikResponseContext mRemoveUserTagResponseContext;
        private DateTime mRemoveUserTagStartTime;
        private readonly KnetikResponseContext mSetPasswordResponseContext;
        private DateTime mSetPasswordStartTime;
        private readonly KnetikResponseContext mStartPasswordResetResponseContext;
        private DateTime mStartPasswordResetStartTime;
        private readonly KnetikResponseContext mSubmitPasswordResetResponseContext;
        private DateTime mSubmitPasswordResetStartTime;
        private readonly KnetikResponseContext mUpdateUserResponseContext;
        private DateTime mUpdateUserStartTime;
        private readonly KnetikResponseContext mUpdateUserTemplateResponseContext;
        private DateTime mUpdateUserTemplateStartTime;

        public delegate void AddUserTagCompleteDelegate(long responseCode);
        public AddUserTagCompleteDelegate AddUserTagComplete;

        public TemplateResource CreateUserTemplateData { get; private set; }
        public delegate void CreateUserTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateUserTemplateCompleteDelegate CreateUserTemplateComplete;

        public delegate void DeleteUserTemplateCompleteDelegate(long responseCode);
        public DeleteUserTemplateCompleteDelegate DeleteUserTemplateComplete;

        public UserResource GetUserData { get; private set; }
        public delegate void GetUserCompleteDelegate(long responseCode, UserResource response);
        public GetUserCompleteDelegate GetUserComplete;

        public List<string> GetUserTagsData { get; private set; }
        public delegate void GetUserTagsCompleteDelegate(long responseCode, List<string> response);
        public GetUserTagsCompleteDelegate GetUserTagsComplete;

        public TemplateResource GetUserTemplateData { get; private set; }
        public delegate void GetUserTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetUserTemplateCompleteDelegate GetUserTemplateComplete;

        public PageResourceTemplateResource GetUserTemplatesData { get; private set; }
        public delegate void GetUserTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetUserTemplatesCompleteDelegate GetUserTemplatesComplete;

        public PageResourceUserBaseResource GetUsersData { get; private set; }
        public delegate void GetUsersCompleteDelegate(long responseCode, PageResourceUserBaseResource response);
        public GetUsersCompleteDelegate GetUsersComplete;

        public delegate void PasswordResetCompleteDelegate(long responseCode);
        public PasswordResetCompleteDelegate PasswordResetComplete;

        public UserResource RegisterUserData { get; private set; }
        public delegate void RegisterUserCompleteDelegate(long responseCode, UserResource response);
        public RegisterUserCompleteDelegate RegisterUserComplete;

        public delegate void RemoveUserTagCompleteDelegate(long responseCode);
        public RemoveUserTagCompleteDelegate RemoveUserTagComplete;

        public delegate void SetPasswordCompleteDelegate(long responseCode);
        public SetPasswordCompleteDelegate SetPasswordComplete;

        public delegate void StartPasswordResetCompleteDelegate(long responseCode);
        public StartPasswordResetCompleteDelegate StartPasswordResetComplete;

        public delegate void SubmitPasswordResetCompleteDelegate(long responseCode);
        public SubmitPasswordResetCompleteDelegate SubmitPasswordResetComplete;

        public delegate void UpdateUserCompleteDelegate(long responseCode);
        public UpdateUserCompleteDelegate UpdateUserComplete;

        public TemplateResource UpdateUserTemplateData { get; private set; }
        public delegate void UpdateUserTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateUserTemplateCompleteDelegate UpdateUserTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersApi()
        {
            mAddUserTagResponseContext = new KnetikResponseContext();
            mAddUserTagResponseContext.ResponseReceived += OnAddUserTagResponse;
            mCreateUserTemplateResponseContext = new KnetikResponseContext();
            mCreateUserTemplateResponseContext.ResponseReceived += OnCreateUserTemplateResponse;
            mDeleteUserTemplateResponseContext = new KnetikResponseContext();
            mDeleteUserTemplateResponseContext.ResponseReceived += OnDeleteUserTemplateResponse;
            mGetUserResponseContext = new KnetikResponseContext();
            mGetUserResponseContext.ResponseReceived += OnGetUserResponse;
            mGetUserTagsResponseContext = new KnetikResponseContext();
            mGetUserTagsResponseContext.ResponseReceived += OnGetUserTagsResponse;
            mGetUserTemplateResponseContext = new KnetikResponseContext();
            mGetUserTemplateResponseContext.ResponseReceived += OnGetUserTemplateResponse;
            mGetUserTemplatesResponseContext = new KnetikResponseContext();
            mGetUserTemplatesResponseContext.ResponseReceived += OnGetUserTemplatesResponse;
            mGetUsersResponseContext = new KnetikResponseContext();
            mGetUsersResponseContext.ResponseReceived += OnGetUsersResponse;
            mPasswordResetResponseContext = new KnetikResponseContext();
            mPasswordResetResponseContext.ResponseReceived += OnPasswordResetResponse;
            mRegisterUserResponseContext = new KnetikResponseContext();
            mRegisterUserResponseContext.ResponseReceived += OnRegisterUserResponse;
            mRemoveUserTagResponseContext = new KnetikResponseContext();
            mRemoveUserTagResponseContext.ResponseReceived += OnRemoveUserTagResponse;
            mSetPasswordResponseContext = new KnetikResponseContext();
            mSetPasswordResponseContext.ResponseReceived += OnSetPasswordResponse;
            mStartPasswordResetResponseContext = new KnetikResponseContext();
            mStartPasswordResetResponseContext.ResponseReceived += OnStartPasswordResetResponse;
            mSubmitPasswordResetResponseContext = new KnetikResponseContext();
            mSubmitPasswordResetResponseContext.ResponseReceived += OnSubmitPasswordResetResponse;
            mUpdateUserResponseContext = new KnetikResponseContext();
            mUpdateUserResponseContext.ResponseReceived += OnUpdateUserResponse;
            mUpdateUserTemplateResponseContext = new KnetikResponseContext();
            mUpdateUserTemplateResponseContext.ResponseReceived += OnUpdateUserTemplateResponse;
        }
    
        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/tags";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(tag); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddUserTagStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddUserTagResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddUserTagStartTime, "AddUserTag", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddUserTagResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddUserTag: " + response.Error);
            }

            KnetikLogger.LogResponse(mAddUserTagStartTime, "AddUserTag", "Response received successfully.");
            if (AddUserTagComplete != null)
            {
                AddUserTagComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a user template User Templates define a type of user and the properties they have
        /// </summary>
        /// <param name="userTemplateResource">The user template resource object</param>
        public void CreateUserTemplate(TemplateResource userTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/users/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(userTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateUserTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateUserTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateUserTemplateStartTime, "CreateUserTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateUserTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateUserTemplate: " + response.Error);
            }

            CreateUserTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateUserTemplateStartTime, "CreateUserTemplate", string.Format("Response received successfully:\n{0}", CreateUserTemplateData));

            if (CreateUserTemplateComplete != null)
            {
                CreateUserTemplateComplete(response.ResponseCode, CreateUserTemplateData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/templates/{id}";
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
            mDeleteUserTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteUserTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteUserTemplateStartTime, "DeleteUserTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteUserTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteUserTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteUserTemplateStartTime, "DeleteUserTemplate", "Response received successfully.");
            if (DeleteUserTemplateComplete != null)
            {
                DeleteUserTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/{id}";
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
            mGetUserStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserStartTime, "GetUser", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUser: " + response.Error);
            }

            GetUserData = (UserResource) KnetikClient.Deserialize(response.Content, typeof(UserResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserStartTime, "GetUser", string.Format("Response received successfully:\n{0}", GetUserData));

            if (GetUserComplete != null)
            {
                GetUserComplete(response.ResponseCode, GetUserData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/tags";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUserTagsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserTagsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserTagsStartTime, "GetUserTags", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserTagsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserTags: " + response.Error);
            }

            GetUserTagsData = (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetUserTagsStartTime, "GetUserTags", string.Format("Response received successfully:\n{0}", GetUserTagsData));

            if (GetUserTagsComplete != null)
            {
                GetUserTagsComplete(response.ResponseCode, GetUserTagsData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/templates/{id}";
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
            mGetUserTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserTemplateStartTime, "GetUserTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserTemplate: " + response.Error);
            }

            GetUserTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserTemplateStartTime, "GetUserTemplate", string.Format("Response received successfully:\n{0}", GetUserTemplateData));

            if (GetUserTemplateComplete != null)
            {
                GetUserTemplateComplete(response.ResponseCode, GetUserTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search user templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetUserTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/users/templates";
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
            mGetUserTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserTemplatesStartTime, "GetUserTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserTemplates: " + response.Error);
            }

            GetUserTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserTemplatesStartTime, "GetUserTemplates", string.Format("Response received successfully:\n{0}", GetUserTemplatesData));

            if (GetUserTemplatesComplete != null)
            {
                GetUserTemplatesComplete(response.ResponseCode, GetUserTemplatesData);
            }
        }

        /// <inheritdoc />
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
        /// <param name="filterLastActivity">A comma separated string without spaces.  First value is the operator to search on, second value is the date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterIdList">A comma separated list of ids.</param>
        /// <param name="filterSearch">Filter for users whose display_name starts with the provided string, or username if display_name is null</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetUsers(string filterDisplayname, string filterEmail, string filterFirstname, string filterFullname, string filterLastname, string filterUsername, string filterTag, string filterGroup, string filterRole, string filterLastActivity, string filterIdList, string filterSearch, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/users";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterDisplayname != null)
            {
                mWebCallEvent.QueryParams["filter_displayname"] = KnetikClient.ParameterToString(filterDisplayname);
            }

            if (filterEmail != null)
            {
                mWebCallEvent.QueryParams["filter_email"] = KnetikClient.ParameterToString(filterEmail);
            }

            if (filterFirstname != null)
            {
                mWebCallEvent.QueryParams["filter_firstname"] = KnetikClient.ParameterToString(filterFirstname);
            }

            if (filterFullname != null)
            {
                mWebCallEvent.QueryParams["filter_fullname"] = KnetikClient.ParameterToString(filterFullname);
            }

            if (filterLastname != null)
            {
                mWebCallEvent.QueryParams["filter_lastname"] = KnetikClient.ParameterToString(filterLastname);
            }

            if (filterUsername != null)
            {
                mWebCallEvent.QueryParams["filter_username"] = KnetikClient.ParameterToString(filterUsername);
            }

            if (filterTag != null)
            {
                mWebCallEvent.QueryParams["filter_tag"] = KnetikClient.ParameterToString(filterTag);
            }

            if (filterGroup != null)
            {
                mWebCallEvent.QueryParams["filter_group"] = KnetikClient.ParameterToString(filterGroup);
            }

            if (filterRole != null)
            {
                mWebCallEvent.QueryParams["filter_role"] = KnetikClient.ParameterToString(filterRole);
            }

            if (filterLastActivity != null)
            {
                mWebCallEvent.QueryParams["filter_last_activity"] = KnetikClient.ParameterToString(filterLastActivity);
            }

            if (filterIdList != null)
            {
                mWebCallEvent.QueryParams["filter_id_list"] = KnetikClient.ParameterToString(filterIdList);
            }

            if (filterSearch != null)
            {
                mWebCallEvent.QueryParams["filter_search"] = KnetikClient.ParameterToString(filterSearch);
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
            mGetUsersStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUsersResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUsersStartTime, "GetUsers", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUsersResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUsers: " + response.Error);
            }

            GetUsersData = (PageResourceUserBaseResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserBaseResource), response.Headers);
            KnetikLogger.LogResponse(mGetUsersStartTime, "GetUsers", string.Format("Response received successfully:\n{0}", GetUsersData));

            if (GetUsersComplete != null)
            {
                GetUsersComplete(response.ResponseCode, GetUsersData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/{id}/password-reset";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(newPasswordRequest); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mPasswordResetStartTime = DateTime.Now;
            mWebCallEvent.Context = mPasswordResetResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mPasswordResetStartTime, "PasswordReset", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnPasswordResetResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling PasswordReset: " + response.Error);
            }

            KnetikLogger.LogResponse(mPasswordResetStartTime, "PasswordReset", "Response received successfully.");
            if (PasswordResetComplete != null)
            {
                PasswordResetComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Register a new user Password should be in plain text and will be encrypted on receipt. Use SSL for security
        /// </summary>
        /// <param name="userResource">The user resource object</param>
        public void RegisterUser(UserResource userResource)
        {
            
            mWebCallEvent.WebPath = "/users";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(userResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mRegisterUserStartTime = DateTime.Now;
            mWebCallEvent.Context = mRegisterUserResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mRegisterUserStartTime, "RegisterUser", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnRegisterUserResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling RegisterUser: " + response.Error);
            }

            RegisterUserData = (UserResource) KnetikClient.Deserialize(response.Content, typeof(UserResource), response.Headers);
            KnetikLogger.LogResponse(mRegisterUserStartTime, "RegisterUser", string.Format("Response received successfully:\n{0}", RegisterUserData));

            if (RegisterUserComplete != null)
            {
                RegisterUserComplete(response.ResponseCode, RegisterUserData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/tags/{tag}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "tag" + "}", KnetikClient.ParameterToString(tag));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mRemoveUserTagStartTime = DateTime.Now;
            mWebCallEvent.Context = mRemoveUserTagResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mRemoveUserTagStartTime, "RemoveUserTag", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnRemoveUserTagResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling RemoveUserTag: " + response.Error);
            }

            KnetikLogger.LogResponse(mRemoveUserTagStartTime, "RemoveUserTag", "Response received successfully.");
            if (RemoveUserTagComplete != null)
            {
                RemoveUserTagComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/{id}/password";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(password); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetPasswordStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetPasswordResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetPasswordStartTime, "SetPassword", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetPasswordResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetPassword: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetPasswordStartTime, "SetPassword", "Response received successfully.");
            if (SetPasswordComplete != null)
            {
                SetPasswordComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/{id}/password-reset";
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
            mStartPasswordResetStartTime = DateTime.Now;
            mWebCallEvent.Context = mStartPasswordResetResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mStartPasswordResetStartTime, "StartPasswordReset", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnStartPasswordResetResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling StartPasswordReset: " + response.Error);
            }

            KnetikLogger.LogResponse(mStartPasswordResetStartTime, "StartPasswordReset", "Response received successfully.");
            if (StartPasswordResetComplete != null)
            {
                StartPasswordResetComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Reset a user&#39;s password without user id A reset code will be generated and a &#39;forgot_password&#39; BRE event will be fired with that code.  The default system rule will send an email to the selected user if an email service has been setup. You can modify that rule in BRE to send an SMS instead or any other type of notification as you see fit.  Must submit their email, username, or mobile phone number
        /// </summary>
        /// <param name="passwordReset">An object containing one of three methods to look up a user</param>
        public void SubmitPasswordReset(PasswordResetRequest passwordReset)
        {
            
            mWebCallEvent.WebPath = "/users/password-reset";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(passwordReset); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSubmitPasswordResetStartTime = DateTime.Now;
            mWebCallEvent.Context = mSubmitPasswordResetResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSubmitPasswordResetStartTime, "SubmitPasswordReset", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSubmitPasswordResetResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SubmitPasswordReset: " + response.Error);
            }

            KnetikLogger.LogResponse(mSubmitPasswordResetStartTime, "SubmitPasswordReset", "Response received successfully.");
            if (SubmitPasswordResetComplete != null)
            {
                SubmitPasswordResetComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(userResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateUserStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateUserResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateUserStartTime, "UpdateUser", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateUserResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateUser: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateUserStartTime, "UpdateUser", "Response received successfully.");
            if (UpdateUserComplete != null)
            {
                UpdateUserComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(userTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateUserTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateUserTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateUserTemplateStartTime, "UpdateUserTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateUserTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateUserTemplate: " + response.Error);
            }

            UpdateUserTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateUserTemplateStartTime, "UpdateUserTemplate", string.Format("Response received successfully:\n{0}", UpdateUserTemplateData));

            if (UpdateUserTemplateComplete != null)
            {
                UpdateUserTemplateComplete(response.ResponseCode, UpdateUserTemplateData);
            }
        }

    }
}
