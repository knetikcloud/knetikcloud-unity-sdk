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
    public interface IGamificationLevelingApi
    {
        LevelingResource CreateLevelData { get; }

        LevelingResource GetLevelData { get; }

        List<BreTriggerResource> GetLevelTriggersData { get; }

        PageResourceLevelingResource GetLevelsData { get; }

        UserLevelingResource GetUserLevelData { get; }

        PageResourceUserLevelingResource GetUserLevelsData { get; }

        LevelingResource UpdateLevelData { get; }

        
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

        /// <summary>
        /// Retrieve a level 
        /// </summary>
        /// <param name="name">The level schema name</param>
        void GetLevel(string name);

        /// <summary>
        /// Get the list of triggers that can be used to trigger a leveling progress update 
        /// </summary>
        void GetLevelTriggers();

        /// <summary>
        /// List and search levels Get a list of levels schemas with optional filtering
        /// </summary>
        /// <param name="filterName">Filter for level schemas whose name contains a given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetLevels(string filterName, int? size, int? page, string order);

        /// <summary>
        /// Get a user&#39;s progress for a given level schema 
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39;</param>
        /// <param name="name">The level schema name</param>
        void GetUserLevel(string userId, string name);

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
        private readonly KnetikCoroutine mCreateLevelCoroutine;
        private DateTime mCreateLevelStartTime;
        private string mCreateLevelPath;
        private readonly KnetikCoroutine mDeleteLevelCoroutine;
        private DateTime mDeleteLevelStartTime;
        private string mDeleteLevelPath;
        private readonly KnetikCoroutine mGetLevelCoroutine;
        private DateTime mGetLevelStartTime;
        private string mGetLevelPath;
        private readonly KnetikCoroutine mGetLevelTriggersCoroutine;
        private DateTime mGetLevelTriggersStartTime;
        private string mGetLevelTriggersPath;
        private readonly KnetikCoroutine mGetLevelsCoroutine;
        private DateTime mGetLevelsStartTime;
        private string mGetLevelsPath;
        private readonly KnetikCoroutine mGetUserLevelCoroutine;
        private DateTime mGetUserLevelStartTime;
        private string mGetUserLevelPath;
        private readonly KnetikCoroutine mGetUserLevelsCoroutine;
        private DateTime mGetUserLevelsStartTime;
        private string mGetUserLevelsPath;
        private readonly KnetikCoroutine mIncrementProgressCoroutine;
        private DateTime mIncrementProgressStartTime;
        private string mIncrementProgressPath;
        private readonly KnetikCoroutine mSetProgressCoroutine;
        private DateTime mSetProgressStartTime;
        private string mSetProgressPath;
        private readonly KnetikCoroutine mUpdateLevelCoroutine;
        private DateTime mUpdateLevelStartTime;
        private string mUpdateLevelPath;

        public LevelingResource CreateLevelData { get; private set; }
        public delegate void CreateLevelCompleteDelegate(LevelingResource response);
        public CreateLevelCompleteDelegate CreateLevelComplete;

        public delegate void DeleteLevelCompleteDelegate();
        public DeleteLevelCompleteDelegate DeleteLevelComplete;

        public LevelingResource GetLevelData { get; private set; }
        public delegate void GetLevelCompleteDelegate(LevelingResource response);
        public GetLevelCompleteDelegate GetLevelComplete;

        public List<BreTriggerResource> GetLevelTriggersData { get; private set; }
        public delegate void GetLevelTriggersCompleteDelegate(List<BreTriggerResource> response);
        public GetLevelTriggersCompleteDelegate GetLevelTriggersComplete;

        public PageResourceLevelingResource GetLevelsData { get; private set; }
        public delegate void GetLevelsCompleteDelegate(PageResourceLevelingResource response);
        public GetLevelsCompleteDelegate GetLevelsComplete;

        public UserLevelingResource GetUserLevelData { get; private set; }
        public delegate void GetUserLevelCompleteDelegate(UserLevelingResource response);
        public GetUserLevelCompleteDelegate GetUserLevelComplete;

        public PageResourceUserLevelingResource GetUserLevelsData { get; private set; }
        public delegate void GetUserLevelsCompleteDelegate(PageResourceUserLevelingResource response);
        public GetUserLevelsCompleteDelegate GetUserLevelsComplete;

        public delegate void IncrementProgressCompleteDelegate();
        public IncrementProgressCompleteDelegate IncrementProgressComplete;

        public delegate void SetProgressCompleteDelegate();
        public SetProgressCompleteDelegate SetProgressComplete;

        public LevelingResource UpdateLevelData { get; private set; }
        public delegate void UpdateLevelCompleteDelegate(LevelingResource response);
        public UpdateLevelCompleteDelegate UpdateLevelComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamificationLevelingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GamificationLevelingApi()
        {
            mCreateLevelCoroutine = new KnetikCoroutine();
            mDeleteLevelCoroutine = new KnetikCoroutine();
            mGetLevelCoroutine = new KnetikCoroutine();
            mGetLevelTriggersCoroutine = new KnetikCoroutine();
            mGetLevelsCoroutine = new KnetikCoroutine();
            mGetUserLevelCoroutine = new KnetikCoroutine();
            mGetUserLevelsCoroutine = new KnetikCoroutine();
            mIncrementProgressCoroutine = new KnetikCoroutine();
            mSetProgressCoroutine = new KnetikCoroutine();
            mUpdateLevelCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a level schema 
        /// </summary>
        /// <param name="level">The level schema definition</param>
        public void CreateLevel(LevelingResource level)
        {
            
            mCreateLevelPath = "/leveling";
            if (!string.IsNullOrEmpty(mCreateLevelPath))
            {
                mCreateLevelPath = mCreateLevelPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(level); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateLevelStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateLevelStartTime, mCreateLevelPath, "Sending server request...");

            // make the HTTP request
            mCreateLevelCoroutine.ResponseReceived += CreateLevelCallback;
            mCreateLevelCoroutine.Start(mCreateLevelPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateLevelCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateLevel: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateLevel: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateLevelData = (LevelingResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(LevelingResource), response.Headers);
            KnetikLogger.LogResponse(mCreateLevelStartTime, mCreateLevelPath, string.Format("Response received successfully:\n{0}", CreateLevelData.ToString()));

            if (CreateLevelComplete != null)
            {
                CreateLevelComplete(CreateLevelData);
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
            
            mDeleteLevelPath = "/leveling/{name}";
            if (!string.IsNullOrEmpty(mDeleteLevelPath))
            {
                mDeleteLevelPath = mDeleteLevelPath.Replace("{format}", "json");
            }
            mDeleteLevelPath = mDeleteLevelPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteLevelStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteLevelStartTime, mDeleteLevelPath, "Sending server request...");

            // make the HTTP request
            mDeleteLevelCoroutine.ResponseReceived += DeleteLevelCallback;
            mDeleteLevelCoroutine.Start(mDeleteLevelPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteLevelCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteLevel: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteLevel: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteLevelStartTime, mDeleteLevelPath, "Response received successfully.");
            if (DeleteLevelComplete != null)
            {
                DeleteLevelComplete();
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
            
            mGetLevelPath = "/leveling/{name}";
            if (!string.IsNullOrEmpty(mGetLevelPath))
            {
                mGetLevelPath = mGetLevelPath.Replace("{format}", "json");
            }
            mGetLevelPath = mGetLevelPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetLevelStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetLevelStartTime, mGetLevelPath, "Sending server request...");

            // make the HTTP request
            mGetLevelCoroutine.ResponseReceived += GetLevelCallback;
            mGetLevelCoroutine.Start(mGetLevelPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetLevelCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetLevel: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetLevel: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetLevelData = (LevelingResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(LevelingResource), response.Headers);
            KnetikLogger.LogResponse(mGetLevelStartTime, mGetLevelPath, string.Format("Response received successfully:\n{0}", GetLevelData.ToString()));

            if (GetLevelComplete != null)
            {
                GetLevelComplete(GetLevelData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Get the list of triggers that can be used to trigger a leveling progress update 
        /// </summary>
        public void GetLevelTriggers()
        {
            
            mGetLevelTriggersPath = "/leveling/triggers";
            if (!string.IsNullOrEmpty(mGetLevelTriggersPath))
            {
                mGetLevelTriggersPath = mGetLevelTriggersPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetLevelTriggersStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetLevelTriggersStartTime, mGetLevelTriggersPath, "Sending server request...");

            // make the HTTP request
            mGetLevelTriggersCoroutine.ResponseReceived += GetLevelTriggersCallback;
            mGetLevelTriggersCoroutine.Start(mGetLevelTriggersPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetLevelTriggersCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetLevelTriggers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetLevelTriggers: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetLevelTriggersData = (List<BreTriggerResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<BreTriggerResource>), response.Headers);
            KnetikLogger.LogResponse(mGetLevelTriggersStartTime, mGetLevelTriggersPath, string.Format("Response received successfully:\n{0}", GetLevelTriggersData.ToString()));

            if (GetLevelTriggersComplete != null)
            {
                GetLevelTriggersComplete(GetLevelTriggersData);
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
            
            mGetLevelsPath = "/leveling";
            if (!string.IsNullOrEmpty(mGetLevelsPath))
            {
                mGetLevelsPath = mGetLevelsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.DefaultClient.ParameterToString(filterName));
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetLevelsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetLevelsStartTime, mGetLevelsPath, "Sending server request...");

            // make the HTTP request
            mGetLevelsCoroutine.ResponseReceived += GetLevelsCallback;
            mGetLevelsCoroutine.Start(mGetLevelsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetLevelsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetLevels: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetLevels: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetLevelsData = (PageResourceLevelingResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceLevelingResource), response.Headers);
            KnetikLogger.LogResponse(mGetLevelsStartTime, mGetLevelsPath, string.Format("Response received successfully:\n{0}", GetLevelsData.ToString()));

            if (GetLevelsComplete != null)
            {
                GetLevelsComplete(GetLevelsData);
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
            
            mGetUserLevelPath = "/users/{user_id}/leveling/{name}";
            if (!string.IsNullOrEmpty(mGetUserLevelPath))
            {
                mGetUserLevelPath = mGetUserLevelPath.Replace("{format}", "json");
            }
            mGetUserLevelPath = mGetUserLevelPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mGetUserLevelPath = mGetUserLevelPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserLevelStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserLevelStartTime, mGetUserLevelPath, "Sending server request...");

            // make the HTTP request
            mGetUserLevelCoroutine.ResponseReceived += GetUserLevelCallback;
            mGetUserLevelCoroutine.Start(mGetUserLevelPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserLevelCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserLevel: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserLevel: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserLevelData = (UserLevelingResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(UserLevelingResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserLevelStartTime, mGetUserLevelPath, string.Format("Response received successfully:\n{0}", GetUserLevelData.ToString()));

            if (GetUserLevelComplete != null)
            {
                GetUserLevelComplete(GetUserLevelData);
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
            
            mGetUserLevelsPath = "/users/{user_id}/leveling";
            if (!string.IsNullOrEmpty(mGetUserLevelsPath))
            {
                mGetUserLevelsPath = mGetUserLevelsPath.Replace("{format}", "json");
            }
            mGetUserLevelsPath = mGetUserLevelsPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.DefaultClient.ParameterToString(filterName));
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserLevelsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserLevelsStartTime, mGetUserLevelsPath, "Sending server request...");

            // make the HTTP request
            mGetUserLevelsCoroutine.ResponseReceived += GetUserLevelsCallback;
            mGetUserLevelsCoroutine.Start(mGetUserLevelsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserLevelsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserLevels: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserLevels: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserLevelsData = (PageResourceUserLevelingResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUserLevelingResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserLevelsStartTime, mGetUserLevelsPath, string.Format("Response received successfully:\n{0}", GetUserLevelsData.ToString()));

            if (GetUserLevelsComplete != null)
            {
                GetUserLevelsComplete(GetUserLevelsData);
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
            
            mIncrementProgressPath = "/users/{user_id}/leveling/{name}/progress";
            if (!string.IsNullOrEmpty(mIncrementProgressPath))
            {
                mIncrementProgressPath = mIncrementProgressPath.Replace("{format}", "json");
            }
            mIncrementProgressPath = mIncrementProgressPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mIncrementProgressPath = mIncrementProgressPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(progress); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mIncrementProgressStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mIncrementProgressStartTime, mIncrementProgressPath, "Sending server request...");

            // make the HTTP request
            mIncrementProgressCoroutine.ResponseReceived += IncrementProgressCallback;
            mIncrementProgressCoroutine.Start(mIncrementProgressPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void IncrementProgressCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling IncrementProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling IncrementProgress: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mIncrementProgressStartTime, mIncrementProgressPath, "Response received successfully.");
            if (IncrementProgressComplete != null)
            {
                IncrementProgressComplete();
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
            
            mSetProgressPath = "/users/{user_id}/leveling/{name}/progress";
            if (!string.IsNullOrEmpty(mSetProgressPath))
            {
                mSetProgressPath = mSetProgressPath.Replace("{format}", "json");
            }
            mSetProgressPath = mSetProgressPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mSetProgressPath = mSetProgressPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(progress); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetProgressStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetProgressStartTime, mSetProgressPath, "Sending server request...");

            // make the HTTP request
            mSetProgressCoroutine.ResponseReceived += SetProgressCallback;
            mSetProgressCoroutine.Start(mSetProgressPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetProgressCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetProgress: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetProgressStartTime, mSetProgressPath, "Response received successfully.");
            if (SetProgressComplete != null)
            {
                SetProgressComplete();
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
            
            mUpdateLevelPath = "/leveling/{name}";
            if (!string.IsNullOrEmpty(mUpdateLevelPath))
            {
                mUpdateLevelPath = mUpdateLevelPath.Replace("{format}", "json");
            }
            mUpdateLevelPath = mUpdateLevelPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(newLevel); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateLevelStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateLevelStartTime, mUpdateLevelPath, "Sending server request...");

            // make the HTTP request
            mUpdateLevelCoroutine.ResponseReceived += UpdateLevelCallback;
            mUpdateLevelCoroutine.Start(mUpdateLevelPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateLevelCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateLevel: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateLevel: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateLevelData = (LevelingResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(LevelingResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateLevelStartTime, mUpdateLevelPath, string.Format("Response received successfully:\n{0}", UpdateLevelData.ToString()));

            if (UpdateLevelComplete != null)
            {
                UpdateLevelComplete(UpdateLevelData);
            }
        }
    }
}
