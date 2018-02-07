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
    public interface IGamificationLevelingApi
    {
        LevelingResource CreateLevelData { get; }

        /// <summary>
        /// Create a level schema 
        /// </summary>
        /// <param name="level">The level schema definition</param>
        void CreateLevel(LevelingResource level);

        

        /// <summary>
        /// Delete a level 
        /// </summary>
        /// <param name="name">The level schema name</param>
        void DeleteLevel(string name);

        LevelingResource GetLevelData { get; }

        /// <summary>
        /// Retrieve a level 
        /// </summary>
        /// <param name="name">The level schema name</param>
        void GetLevel(string name);

        List<BreTriggerResource> GetLevelTriggersData { get; }

        /// <summary>
        /// Get the list of triggers that can be used to trigger a leveling progress update 
        /// </summary>
        void GetLevelTriggers();

        PageResourceLevelingResource GetLevelsData { get; }

        /// <summary>
        /// List and search levels Get a list of levels schemas with optional filtering
        /// </summary>
        /// <param name="filterName">Filter for level schemas whose name contains a given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetLevels(string filterName, int? size, int? page, string order);

        UserLevelingResource GetUserLevelData { get; }

        /// <summary>
        /// Get a user&#39;s progress for a given level schema 
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39;</param>
        /// <param name="name">The level schema name</param>
        void GetUserLevel(string userId, string name);

        PageResourceUserLevelingResource GetUserLevelsData { get; }

        /// <summary>
        /// Get a user&#39;s progress for all level schemas Filtering and sorting is based on the LevelingResource object, not the UserLevelingResource that is returned here.
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39;</param>
        /// <param name="filterName">Filter for level schemas whose name contains a given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetUserLevels(string userId, string filterName, int? size, int? page, string order);

        

        /// <summary>
        /// Update or create a leveling progress record for a user If no progress record yet exists for the user, it will be created. Otherwise the provided value will be added to it. May be negative. If progress meets or exceeds the level&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;.
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="name">The level schema name</param>
        /// <param name="progress">The amount of progress to add</param>
        void IncrementProgress(int? userId, string name, IntWrapper progress);

        

        /// <summary>
        /// Set leveling progress for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated to the provided value. If progress meets or exceeds the level&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;.
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="name">The level schema name</param>
        /// <param name="progress">The new progress amount</param>
        void SetProgress(int? userId, string name, IntWrapper progress);

        LevelingResource UpdateLevelData { get; }

        /// <summary>
        /// Update a level 
        /// </summary>
        /// <param name="name">The level schema name</param>
        /// <param name="newLevel">The level schema definition</param>
        void UpdateLevel(string name, LevelingResource newLevel);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class GamificationLevelingApi : IGamificationLevelingApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateLevelResponseContext;
        private DateTime mCreateLevelStartTime;
        private readonly KnetikResponseContext mDeleteLevelResponseContext;
        private DateTime mDeleteLevelStartTime;
        private readonly KnetikResponseContext mGetLevelResponseContext;
        private DateTime mGetLevelStartTime;
        private readonly KnetikResponseContext mGetLevelTriggersResponseContext;
        private DateTime mGetLevelTriggersStartTime;
        private readonly KnetikResponseContext mGetLevelsResponseContext;
        private DateTime mGetLevelsStartTime;
        private readonly KnetikResponseContext mGetUserLevelResponseContext;
        private DateTime mGetUserLevelStartTime;
        private readonly KnetikResponseContext mGetUserLevelsResponseContext;
        private DateTime mGetUserLevelsStartTime;
        private readonly KnetikResponseContext mIncrementProgressResponseContext;
        private DateTime mIncrementProgressStartTime;
        private readonly KnetikResponseContext mSetProgressResponseContext;
        private DateTime mSetProgressStartTime;
        private readonly KnetikResponseContext mUpdateLevelResponseContext;
        private DateTime mUpdateLevelStartTime;

        public LevelingResource CreateLevelData { get; private set; }
        public delegate void CreateLevelCompleteDelegate(long responseCode, LevelingResource response);
        public CreateLevelCompleteDelegate CreateLevelComplete;

        public delegate void DeleteLevelCompleteDelegate(long responseCode);
        public DeleteLevelCompleteDelegate DeleteLevelComplete;

        public LevelingResource GetLevelData { get; private set; }
        public delegate void GetLevelCompleteDelegate(long responseCode, LevelingResource response);
        public GetLevelCompleteDelegate GetLevelComplete;

        public List<BreTriggerResource> GetLevelTriggersData { get; private set; }
        public delegate void GetLevelTriggersCompleteDelegate(long responseCode, List<BreTriggerResource> response);
        public GetLevelTriggersCompleteDelegate GetLevelTriggersComplete;

        public PageResourceLevelingResource GetLevelsData { get; private set; }
        public delegate void GetLevelsCompleteDelegate(long responseCode, PageResourceLevelingResource response);
        public GetLevelsCompleteDelegate GetLevelsComplete;

        public UserLevelingResource GetUserLevelData { get; private set; }
        public delegate void GetUserLevelCompleteDelegate(long responseCode, UserLevelingResource response);
        public GetUserLevelCompleteDelegate GetUserLevelComplete;

        public PageResourceUserLevelingResource GetUserLevelsData { get; private set; }
        public delegate void GetUserLevelsCompleteDelegate(long responseCode, PageResourceUserLevelingResource response);
        public GetUserLevelsCompleteDelegate GetUserLevelsComplete;

        public delegate void IncrementProgressCompleteDelegate(long responseCode);
        public IncrementProgressCompleteDelegate IncrementProgressComplete;

        public delegate void SetProgressCompleteDelegate(long responseCode);
        public SetProgressCompleteDelegate SetProgressComplete;

        public LevelingResource UpdateLevelData { get; private set; }
        public delegate void UpdateLevelCompleteDelegate(long responseCode, LevelingResource response);
        public UpdateLevelCompleteDelegate UpdateLevelComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamificationLevelingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GamificationLevelingApi()
        {
            mCreateLevelResponseContext = new KnetikResponseContext();
            mCreateLevelResponseContext.ResponseReceived += OnCreateLevelResponse;
            mDeleteLevelResponseContext = new KnetikResponseContext();
            mDeleteLevelResponseContext.ResponseReceived += OnDeleteLevelResponse;
            mGetLevelResponseContext = new KnetikResponseContext();
            mGetLevelResponseContext.ResponseReceived += OnGetLevelResponse;
            mGetLevelTriggersResponseContext = new KnetikResponseContext();
            mGetLevelTriggersResponseContext.ResponseReceived += OnGetLevelTriggersResponse;
            mGetLevelsResponseContext = new KnetikResponseContext();
            mGetLevelsResponseContext.ResponseReceived += OnGetLevelsResponse;
            mGetUserLevelResponseContext = new KnetikResponseContext();
            mGetUserLevelResponseContext.ResponseReceived += OnGetUserLevelResponse;
            mGetUserLevelsResponseContext = new KnetikResponseContext();
            mGetUserLevelsResponseContext.ResponseReceived += OnGetUserLevelsResponse;
            mIncrementProgressResponseContext = new KnetikResponseContext();
            mIncrementProgressResponseContext.ResponseReceived += OnIncrementProgressResponse;
            mSetProgressResponseContext = new KnetikResponseContext();
            mSetProgressResponseContext.ResponseReceived += OnSetProgressResponse;
            mUpdateLevelResponseContext = new KnetikResponseContext();
            mUpdateLevelResponseContext.ResponseReceived += OnUpdateLevelResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a level schema 
        /// </summary>
        /// <param name="level">The level schema definition</param>
        public void CreateLevel(LevelingResource level)
        {
            
            mWebCallEvent.WebPath = "/leveling";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(level); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateLevelStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateLevelResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateLevelStartTime, "CreateLevel", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateLevelResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateLevel: " + response.Error);
            }

            CreateLevelData = (LevelingResource) KnetikClient.Deserialize(response.Content, typeof(LevelingResource), response.Headers);
            KnetikLogger.LogResponse(mCreateLevelStartTime, "CreateLevel", string.Format("Response received successfully:\n{0}", CreateLevelData));

            if (CreateLevelComplete != null)
            {
                CreateLevelComplete(response.ResponseCode, CreateLevelData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a level 
        /// </summary>
        /// <param name="name">The level schema name</param>
        public void DeleteLevel(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling DeleteLevel");
            }
            
            mWebCallEvent.WebPath = "/leveling/{name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteLevelStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteLevelResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteLevelStartTime, "DeleteLevel", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteLevelResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteLevel: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteLevelStartTime, "DeleteLevel", "Response received successfully.");
            if (DeleteLevelComplete != null)
            {
                DeleteLevelComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve a level 
        /// </summary>
        /// <param name="name">The level schema name</param>
        public void GetLevel(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetLevel");
            }
            
            mWebCallEvent.WebPath = "/leveling/{name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetLevelStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetLevelResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetLevelStartTime, "GetLevel", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetLevelResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetLevel: " + response.Error);
            }

            GetLevelData = (LevelingResource) KnetikClient.Deserialize(response.Content, typeof(LevelingResource), response.Headers);
            KnetikLogger.LogResponse(mGetLevelStartTime, "GetLevel", string.Format("Response received successfully:\n{0}", GetLevelData));

            if (GetLevelComplete != null)
            {
                GetLevelComplete(response.ResponseCode, GetLevelData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get the list of triggers that can be used to trigger a leveling progress update 
        /// </summary>
        public void GetLevelTriggers()
        {
            
            mWebCallEvent.WebPath = "/leveling/triggers";
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
            mGetLevelTriggersStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetLevelTriggersResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetLevelTriggersStartTime, "GetLevelTriggers", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetLevelTriggersResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetLevelTriggers: " + response.Error);
            }

            GetLevelTriggersData = (List<BreTriggerResource>) KnetikClient.Deserialize(response.Content, typeof(List<BreTriggerResource>), response.Headers);
            KnetikLogger.LogResponse(mGetLevelTriggersStartTime, "GetLevelTriggers", string.Format("Response received successfully:\n{0}", GetLevelTriggersData));

            if (GetLevelTriggersComplete != null)
            {
                GetLevelTriggersComplete(response.ResponseCode, GetLevelTriggersData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search levels Get a list of levels schemas with optional filtering
        /// </summary>
        /// <param name="filterName">Filter for level schemas whose name contains a given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetLevels(string filterName, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/leveling";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterName != null)
            {
                mWebCallEvent.QueryParams["filter_name"] = KnetikClient.ParameterToString(filterName);
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
            mGetLevelsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetLevelsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetLevelsStartTime, "GetLevels", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetLevelsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetLevels: " + response.Error);
            }

            GetLevelsData = (PageResourceLevelingResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceLevelingResource), response.Headers);
            KnetikLogger.LogResponse(mGetLevelsStartTime, "GetLevels", string.Format("Response received successfully:\n{0}", GetLevelsData));

            if (GetLevelsComplete != null)
            {
                GetLevelsComplete(response.ResponseCode, GetLevelsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a user&#39;s progress for a given level schema 
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39;</param>
        /// <param name="name">The level schema name</param>
        public void GetUserLevel(string userId, string name)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserLevel");
            }
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetUserLevel");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/leveling/{name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUserLevelStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserLevelResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserLevelStartTime, "GetUserLevel", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserLevelResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserLevel: " + response.Error);
            }

            GetUserLevelData = (UserLevelingResource) KnetikClient.Deserialize(response.Content, typeof(UserLevelingResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserLevelStartTime, "GetUserLevel", string.Format("Response received successfully:\n{0}", GetUserLevelData));

            if (GetUserLevelComplete != null)
            {
                GetUserLevelComplete(response.ResponseCode, GetUserLevelData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a user&#39;s progress for all level schemas Filtering and sorting is based on the LevelingResource object, not the UserLevelingResource that is returned here.
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39;</param>
        /// <param name="filterName">Filter for level schemas whose name contains a given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetUserLevels(string userId, string filterName, int? size, int? page, string order)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserLevels");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/leveling";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterName != null)
            {
                mWebCallEvent.QueryParams["filter_name"] = KnetikClient.ParameterToString(filterName);
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
            mGetUserLevelsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserLevelsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserLevelsStartTime, "GetUserLevels", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserLevelsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserLevels: " + response.Error);
            }

            GetUserLevelsData = (PageResourceUserLevelingResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserLevelingResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserLevelsStartTime, "GetUserLevels", string.Format("Response received successfully:\n{0}", GetUserLevelsData));

            if (GetUserLevelsComplete != null)
            {
                GetUserLevelsComplete(response.ResponseCode, GetUserLevelsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update or create a leveling progress record for a user If no progress record yet exists for the user, it will be created. Otherwise the provided value will be added to it. May be negative. If progress meets or exceeds the level&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;.
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="name">The level schema name</param>
        /// <param name="progress">The amount of progress to add</param>
        public void IncrementProgress(int? userId, string name, IntWrapper progress)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling IncrementProgress");
            }
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling IncrementProgress");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/leveling/{name}/progress";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(progress); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mIncrementProgressStartTime = DateTime.Now;
            mWebCallEvent.Context = mIncrementProgressResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mIncrementProgressStartTime, "IncrementProgress", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnIncrementProgressResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling IncrementProgress: " + response.Error);
            }

            KnetikLogger.LogResponse(mIncrementProgressStartTime, "IncrementProgress", "Response received successfully.");
            if (IncrementProgressComplete != null)
            {
                IncrementProgressComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set leveling progress for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated to the provided value. If progress meets or exceeds the level&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;.
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="name">The level schema name</param>
        /// <param name="progress">The new progress amount</param>
        public void SetProgress(int? userId, string name, IntWrapper progress)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling SetProgress");
            }
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling SetProgress");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/leveling/{name}/progress";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(progress); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetProgressStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetProgressResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetProgressStartTime, "SetProgress", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetProgressResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetProgress: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetProgressStartTime, "SetProgress", "Response received successfully.");
            if (SetProgressComplete != null)
            {
                SetProgressComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a level 
        /// </summary>
        /// <param name="name">The level schema name</param>
        /// <param name="newLevel">The level schema definition</param>
        public void UpdateLevel(string name, LevelingResource newLevel)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling UpdateLevel");
            }
            
            mWebCallEvent.WebPath = "/leveling/{name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(newLevel); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateLevelStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateLevelResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateLevelStartTime, "UpdateLevel", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateLevelResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateLevel: " + response.Error);
            }

            UpdateLevelData = (LevelingResource) KnetikClient.Deserialize(response.Content, typeof(LevelingResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateLevelStartTime, "UpdateLevel", string.Format("Response received successfully:\n{0}", UpdateLevelData));

            if (UpdateLevelComplete != null)
            {
                UpdateLevelComplete(response.ResponseCode, UpdateLevelData);
            }
        }

    }
}
