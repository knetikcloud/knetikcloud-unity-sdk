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
    public interface IConfigsApi
    {
        Config CreateConfigData { get; }

        Config GetConfigData { get; }

        PageResourceConfig GetConfigsData { get; }

        
        /// <summary>
        /// Create a new config 
        /// </summary>
        /// <param name="config">The config object</param>
        void CreateConfig(Config config);

        /// <summary>
        /// Delete an existing config 
        /// </summary>
        /// <param name="name">The config name</param>
        void DeleteConfig(string name);

        /// <summary>
        /// Get a single config Only configs that are public readable will be shown without admin access
        /// </summary>
        /// <param name="name">The config name</param>
        void GetConfig(string name);

        /// <summary>
        /// List and search configs 
        /// </summary>
        /// <param name="filterSearch">Filter for configs whose name contains the given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetConfigs(string filterSearch, int? size, int? page, string order);

        /// <summary>
        /// Update an existing config 
        /// </summary>
        /// <param name="name">The config name</param>
        /// <param name="config">The config object</param>
        void UpdateConfig(string name, Config config);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ConfigsApi : IConfigsApi
    {
        private readonly KnetikCoroutine mCreateConfigCoroutine;
        private DateTime mCreateConfigStartTime;
        private string mCreateConfigPath;
        private readonly KnetikCoroutine mDeleteConfigCoroutine;
        private DateTime mDeleteConfigStartTime;
        private string mDeleteConfigPath;
        private readonly KnetikCoroutine mGetConfigCoroutine;
        private DateTime mGetConfigStartTime;
        private string mGetConfigPath;
        private readonly KnetikCoroutine mGetConfigsCoroutine;
        private DateTime mGetConfigsStartTime;
        private string mGetConfigsPath;
        private readonly KnetikCoroutine mUpdateConfigCoroutine;
        private DateTime mUpdateConfigStartTime;
        private string mUpdateConfigPath;

        public Config CreateConfigData { get; private set; }
        public delegate void CreateConfigCompleteDelegate(Config response);
        public CreateConfigCompleteDelegate CreateConfigComplete;

        public delegate void DeleteConfigCompleteDelegate();
        public DeleteConfigCompleteDelegate DeleteConfigComplete;

        public Config GetConfigData { get; private set; }
        public delegate void GetConfigCompleteDelegate(Config response);
        public GetConfigCompleteDelegate GetConfigComplete;

        public PageResourceConfig GetConfigsData { get; private set; }
        public delegate void GetConfigsCompleteDelegate(PageResourceConfig response);
        public GetConfigsCompleteDelegate GetConfigsComplete;

        public delegate void UpdateConfigCompleteDelegate();
        public UpdateConfigCompleteDelegate UpdateConfigComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ConfigsApi()
        {
            mCreateConfigCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mDeleteConfigCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetConfigCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetConfigsCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateConfigCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
        /// <summary>
        /// Create a new config 
        /// </summary>
        /// <param name="config">The config object</param>
        public void CreateConfig(Config config)
        {
            
            mCreateConfigPath = "/configs";
            if (!string.IsNullOrEmpty(mCreateConfigPath))
            {
                mCreateConfigPath = mCreateConfigPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(config); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateConfigStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateConfigStartTime, mCreateConfigPath, "Sending server request...");

            // make the HTTP request
            mCreateConfigCoroutine.ResponseReceived += CreateConfigCallback;
            mCreateConfigCoroutine.Start(mCreateConfigPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateConfigCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateConfig: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateConfig: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateConfigData = (Config) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(Config), response.Headers);
            KnetikLogger.LogResponse(mCreateConfigStartTime, mCreateConfigPath, string.Format("Response received successfully:\n{0}", CreateConfigData.ToString()));

            if (CreateConfigComplete != null)
            {
                CreateConfigComplete(CreateConfigData);
            }
        }
        /// <summary>
        /// Delete an existing config 
        /// </summary>
        /// <param name="name">The config name</param>
        public void DeleteConfig(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling DeleteConfig");
            }
            
            mDeleteConfigPath = "/configs/{name}";
            if (!string.IsNullOrEmpty(mDeleteConfigPath))
            {
                mDeleteConfigPath = mDeleteConfigPath.Replace("{format}", "json");
            }
            mDeleteConfigPath = mDeleteConfigPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteConfigStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteConfigStartTime, mDeleteConfigPath, "Sending server request...");

            // make the HTTP request
            mDeleteConfigCoroutine.ResponseReceived += DeleteConfigCallback;
            mDeleteConfigCoroutine.Start(mDeleteConfigPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteConfigCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteConfig: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteConfig: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteConfigStartTime, mDeleteConfigPath, "Response received successfully.");
            if (DeleteConfigComplete != null)
            {
                DeleteConfigComplete();
            }
        }
        /// <summary>
        /// Get a single config Only configs that are public readable will be shown without admin access
        /// </summary>
        /// <param name="name">The config name</param>
        public void GetConfig(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetConfig");
            }
            
            mGetConfigPath = "/configs/{name}";
            if (!string.IsNullOrEmpty(mGetConfigPath))
            {
                mGetConfigPath = mGetConfigPath.Replace("{format}", "json");
            }
            mGetConfigPath = mGetConfigPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetConfigStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetConfigStartTime, mGetConfigPath, "Sending server request...");

            // make the HTTP request
            mGetConfigCoroutine.ResponseReceived += GetConfigCallback;
            mGetConfigCoroutine.Start(mGetConfigPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetConfigCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetConfig: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetConfig: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetConfigData = (Config) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(Config), response.Headers);
            KnetikLogger.LogResponse(mGetConfigStartTime, mGetConfigPath, string.Format("Response received successfully:\n{0}", GetConfigData.ToString()));

            if (GetConfigComplete != null)
            {
                GetConfigComplete(GetConfigData);
            }
        }
        /// <summary>
        /// List and search configs 
        /// </summary>
        /// <param name="filterSearch">Filter for configs whose name contains the given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetConfigs(string filterSearch, int? size, int? page, string order)
        {
            
            mGetConfigsPath = "/configs";
            if (!string.IsNullOrEmpty(mGetConfigsPath))
            {
                mGetConfigsPath = mGetConfigsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.DefaultClient.ParameterToString(filterSearch));
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
            string[] authSettings = new string[] {  };

            mGetConfigsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetConfigsStartTime, mGetConfigsPath, "Sending server request...");

            // make the HTTP request
            mGetConfigsCoroutine.ResponseReceived += GetConfigsCallback;
            mGetConfigsCoroutine.Start(mGetConfigsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetConfigsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetConfigs: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetConfigs: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetConfigsData = (PageResourceConfig) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceConfig), response.Headers);
            KnetikLogger.LogResponse(mGetConfigsStartTime, mGetConfigsPath, string.Format("Response received successfully:\n{0}", GetConfigsData.ToString()));

            if (GetConfigsComplete != null)
            {
                GetConfigsComplete(GetConfigsData);
            }
        }
        /// <summary>
        /// Update an existing config 
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
            
            mUpdateConfigPath = "/configs/{name}";
            if (!string.IsNullOrEmpty(mUpdateConfigPath))
            {
                mUpdateConfigPath = mUpdateConfigPath.Replace("{format}", "json");
            }
            mUpdateConfigPath = mUpdateConfigPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(config); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateConfigStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateConfigStartTime, mUpdateConfigPath, "Sending server request...");

            // make the HTTP request
            mUpdateConfigCoroutine.ResponseReceived += UpdateConfigCallback;
            mUpdateConfigCoroutine.Start(mUpdateConfigPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateConfigCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateConfig: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateConfig: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateConfigStartTime, mUpdateConfigPath, "Response received successfully.");
            if (UpdateConfigComplete != null)
            {
                UpdateConfigComplete();
            }
        }
    }
}
