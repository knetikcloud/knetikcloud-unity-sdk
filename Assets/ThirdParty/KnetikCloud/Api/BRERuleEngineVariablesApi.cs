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
    public interface IBRERuleEngineVariablesApi
    {
        List<VariableTypeResource> GetBREVariableTypesData { get; }

        PageResourceSimpleReferenceResourceobject GetBREVariableValuesData { get; }

        
        /// <summary>
        /// Get a list of variable types available Types include integer, string, user and invoice. These are used to qualify trigger parameters and action variables with strong typing.
        /// </summary>
        void GetBREVariableTypes();

        /// <summary>
        /// List valid values for a type Used to lookup users to fill in a user constant for example. Only types marked as enumerable are suppoorted here.
        /// </summary>
        /// <param name="name">The name of the type</param>
        /// <param name="filterName">Filter results by those with names starting with this string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetBREVariableValues(string name, string filterName, int? size, int? page);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineVariablesApi : IBRERuleEngineVariablesApi
    {
        private readonly KnetikCoroutine mGetBREVariableTypesCoroutine;
        private DateTime mGetBREVariableTypesStartTime;
        private string mGetBREVariableTypesPath;
        private readonly KnetikCoroutine mGetBREVariableValuesCoroutine;
        private DateTime mGetBREVariableValuesStartTime;
        private string mGetBREVariableValuesPath;

        public List<VariableTypeResource> GetBREVariableTypesData { get; private set; }
        public delegate void GetBREVariableTypesCompleteDelegate(List<VariableTypeResource> response);
        public GetBREVariableTypesCompleteDelegate GetBREVariableTypesComplete;

        public PageResourceSimpleReferenceResourceobject GetBREVariableValuesData { get; private set; }
        public delegate void GetBREVariableValuesCompleteDelegate(PageResourceSimpleReferenceResourceobject response);
        public GetBREVariableValuesCompleteDelegate GetBREVariableValuesComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineVariablesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineVariablesApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
            mGetBREVariableTypesCoroutine = new KnetikCoroutine(KnetikClient);
            mGetBREVariableValuesCoroutine = new KnetikCoroutine(KnetikClient);
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient { get; private set; }

        /// <summary>
        /// Get a list of variable types available Types include integer, string, user and invoice. These are used to qualify trigger parameters and action variables with strong typing.
        /// </summary>
        public void GetBREVariableTypes()
        {
            
            mGetBREVariableTypesPath = "/bre/variable-types";
            if (!string.IsNullOrEmpty(mGetBREVariableTypesPath))
            {
                mGetBREVariableTypesPath = mGetBREVariableTypesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBREVariableTypesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBREVariableTypesStartTime, mGetBREVariableTypesPath, "Sending server request...");

            // make the HTTP request
            mGetBREVariableTypesCoroutine.ResponseReceived += GetBREVariableTypesCallback;
            mGetBREVariableTypesCoroutine.Start(mGetBREVariableTypesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBREVariableTypesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREVariableTypes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREVariableTypes: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBREVariableTypesData = (List<VariableTypeResource>) KnetikClient.Deserialize(response.Content, typeof(List<VariableTypeResource>), response.Headers);
            KnetikLogger.LogResponse(mGetBREVariableTypesStartTime, mGetBREVariableTypesPath, string.Format("Response received successfully:\n{0}", GetBREVariableTypesData.ToString()));

            if (GetBREVariableTypesComplete != null)
            {
                GetBREVariableTypesComplete(GetBREVariableTypesData);
            }
        }
        /// <summary>
        /// List valid values for a type Used to lookup users to fill in a user constant for example. Only types marked as enumerable are suppoorted here.
        /// </summary>
        /// <param name="name">The name of the type</param>
        /// <param name="filterName">Filter results by those with names starting with this string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetBREVariableValues(string name, string filterName, int? size, int? page)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetBREVariableValues");
            }
            
            mGetBREVariableValuesPath = "/bre/variable-types/{name}/values";
            if (!string.IsNullOrEmpty(mGetBREVariableValuesPath))
            {
                mGetBREVariableValuesPath = mGetBREVariableValuesPath.Replace("{format}", "json");
            }
            mGetBREVariableValuesPath = mGetBREVariableValuesPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.ParameterToString(filterName));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBREVariableValuesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBREVariableValuesStartTime, mGetBREVariableValuesPath, "Sending server request...");

            // make the HTTP request
            mGetBREVariableValuesCoroutine.ResponseReceived += GetBREVariableValuesCallback;
            mGetBREVariableValuesCoroutine.Start(mGetBREVariableValuesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBREVariableValuesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREVariableValues: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREVariableValues: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBREVariableValuesData = (PageResourceSimpleReferenceResourceobject) KnetikClient.Deserialize(response.Content, typeof(PageResourceSimpleReferenceResourceobject), response.Headers);
            KnetikLogger.LogResponse(mGetBREVariableValuesStartTime, mGetBREVariableValuesPath, string.Format("Response received successfully:\n{0}", GetBREVariableValuesData.ToString()));

            if (GetBREVariableValuesComplete != null)
            {
                GetBREVariableValuesComplete(GetBREVariableValuesData);
            }
        }
    }
}
