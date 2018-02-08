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
    public interface IConfigsApi
    {
        Config CreateConfigData { get; }

        /// <summary>
        /// Create a new config &lt;b&gt;Permissions Needed:&lt;/b&gt; TOPICS_ADMIN
        /// </summary>
        /// <param name="config">The config object</param>
        void CreateConfig(Config config);

        

        /// <summary>
        /// Delete an existing config &lt;b&gt;Permissions Needed:&lt;/b&gt; CONFIGS_ADMIN
        /// </summary>
        /// <param name="name">The config name</param>
        void DeleteConfig(string name);

        Config GetConfigData { get; }

        /// <summary>
        /// Get a single config Only configs that are public readable will be shown without admin access. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="name">The config name</param>
        void GetConfig(string name);

        PageResourceConfig GetConfigsData { get; }

        /// <summary>
        /// List and search configs &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterSearch">Filter for configs whose name contains the given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetConfigs(string filterSearch, int? size, int? page, string order);

        

        /// <summary>
        /// Update an existing config &lt;b&gt;Permissions Needed:&lt;/b&gt; CONFIGS_ADMIN
        /// </summary>
        /// <param name="name">The config name</param>
        /// <param name="config">The config object</param>
        void UpdateConfig(string name, Config config);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ConfigsApi : IConfigsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateConfigResponseContext;
        private DateTime mCreateConfigStartTime;
        private readonly KnetikResponseContext mDeleteConfigResponseContext;
        private DateTime mDeleteConfigStartTime;
        private readonly KnetikResponseContext mGetConfigResponseContext;
        private DateTime mGetConfigStartTime;
        private readonly KnetikResponseContext mGetConfigsResponseContext;
        private DateTime mGetConfigsStartTime;
        private readonly KnetikResponseContext mUpdateConfigResponseContext;
        private DateTime mUpdateConfigStartTime;

        public Config CreateConfigData { get; private set; }
        public delegate void CreateConfigCompleteDelegate(long responseCode, Config response);
        public CreateConfigCompleteDelegate CreateConfigComplete;

        public delegate void DeleteConfigCompleteDelegate(long responseCode);
        public DeleteConfigCompleteDelegate DeleteConfigComplete;

        public Config GetConfigData { get; private set; }
        public delegate void GetConfigCompleteDelegate(long responseCode, Config response);
        public GetConfigCompleteDelegate GetConfigComplete;

        public PageResourceConfig GetConfigsData { get; private set; }
        public delegate void GetConfigsCompleteDelegate(long responseCode, PageResourceConfig response);
        public GetConfigsCompleteDelegate GetConfigsComplete;

        public delegate void UpdateConfigCompleteDelegate(long responseCode);
        public UpdateConfigCompleteDelegate UpdateConfigComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ConfigsApi()
        {
            mCreateConfigResponseContext = new KnetikResponseContext();
            mCreateConfigResponseContext.ResponseReceived += OnCreateConfigResponse;
            mDeleteConfigResponseContext = new KnetikResponseContext();
            mDeleteConfigResponseContext.ResponseReceived += OnDeleteConfigResponse;
            mGetConfigResponseContext = new KnetikResponseContext();
            mGetConfigResponseContext.ResponseReceived += OnGetConfigResponse;
            mGetConfigsResponseContext = new KnetikResponseContext();
            mGetConfigsResponseContext.ResponseReceived += OnGetConfigsResponse;
            mUpdateConfigResponseContext = new KnetikResponseContext();
            mUpdateConfigResponseContext.ResponseReceived += OnUpdateConfigResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a new config &lt;b&gt;Permissions Needed:&lt;/b&gt; TOPICS_ADMIN
        /// </summary>
        /// <param name="config">The config object</param>
        public void CreateConfig(Config config)
        {
            
            mWebCallEvent.WebPath = "/configs";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(config); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateConfigStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateConfigResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateConfigStartTime, "CreateConfig", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateConfigResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateConfig: " + response.Error);
            }

            CreateConfigData = (Config) KnetikClient.Deserialize(response.Content, typeof(Config), response.Headers);
            KnetikLogger.LogResponse(mCreateConfigStartTime, "CreateConfig", string.Format("Response received successfully:\n{0}", CreateConfigData));

            if (CreateConfigComplete != null)
            {
                CreateConfigComplete(response.ResponseCode, CreateConfigData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an existing config &lt;b&gt;Permissions Needed:&lt;/b&gt; CONFIGS_ADMIN
        /// </summary>
        /// <param name="name">The config name</param>
        public void DeleteConfig(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling DeleteConfig");
            }
            
            mWebCallEvent.WebPath = "/configs/{name}";
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
            mDeleteConfigStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteConfigResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteConfigStartTime, "DeleteConfig", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteConfigResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteConfig: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteConfigStartTime, "DeleteConfig", "Response received successfully.");
            if (DeleteConfigComplete != null)
            {
                DeleteConfigComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single config Only configs that are public readable will be shown without admin access. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="name">The config name</param>
        public void GetConfig(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetConfig");
            }
            
            mWebCallEvent.WebPath = "/configs/{name}";
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
            mGetConfigStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetConfigResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetConfigStartTime, "GetConfig", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetConfigResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetConfig: " + response.Error);
            }

            GetConfigData = (Config) KnetikClient.Deserialize(response.Content, typeof(Config), response.Headers);
            KnetikLogger.LogResponse(mGetConfigStartTime, "GetConfig", string.Format("Response received successfully:\n{0}", GetConfigData));

            if (GetConfigComplete != null)
            {
                GetConfigComplete(response.ResponseCode, GetConfigData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search configs &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterSearch">Filter for configs whose name contains the given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetConfigs(string filterSearch, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/configs";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

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
            mGetConfigsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetConfigsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetConfigsStartTime, "GetConfigs", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetConfigsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetConfigs: " + response.Error);
            }

            GetConfigsData = (PageResourceConfig) KnetikClient.Deserialize(response.Content, typeof(PageResourceConfig), response.Headers);
            KnetikLogger.LogResponse(mGetConfigsStartTime, "GetConfigs", string.Format("Response received successfully:\n{0}", GetConfigsData));

            if (GetConfigsComplete != null)
            {
                GetConfigsComplete(response.ResponseCode, GetConfigsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an existing config &lt;b&gt;Permissions Needed:&lt;/b&gt; CONFIGS_ADMIN
        /// </summary>
        /// <param name="name">The config name</param>
        /// <param name="config">The config object</param>
        public void UpdateConfig(string name, Config config)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling UpdateConfig");
            }
            
            mWebCallEvent.WebPath = "/configs/{name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(config); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateConfigStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateConfigResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateConfigStartTime, "UpdateConfig", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateConfigResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateConfig: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateConfigStartTime, "UpdateConfig", "Response received successfully.");
            if (UpdateConfigComplete != null)
            {
                UpdateConfigComplete(response.ResponseCode);
            }
        }

    }
}
