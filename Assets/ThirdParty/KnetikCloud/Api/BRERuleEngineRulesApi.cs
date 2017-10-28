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
    public interface IBRERuleEngineRulesApi
    {
        BreRule CreateBRERuleData { get; }

        string GetBREExpressionAsStringData { get; }

        BreRule GetBRERuleData { get; }

        PageResourceBreRule GetBRERulesData { get; }

        BreRule UpdateBRERuleData { get; }

        
        /// <summary>
        /// Create a rule Rules define which actions to run when a given event verifies the specified condition. Full list of predicates and other type of expressions can be found at GET /bre/expressions/
        /// </summary>
        /// <param name="breRule">The BRE rule object</param>
        void CreateBRERule(BreRule breRule);

        /// <summary>
        /// Delete a rule May fail if there are existing rules against it. Cannot delete core rules
        /// </summary>
        /// <param name="id">The id of the rule</param>
        void DeleteBRERule(string id);

        /// <summary>
        /// Returns a string representation of the provided expression 
        /// </summary>
        /// <param name="expression">The expression</param>
        void GetBREExpressionAsString(Expressionobject expression);

        /// <summary>
        /// Get a single rule 
        /// </summary>
        /// <param name="id">The id of the rule</param>
        void GetBRERule(string id);

        /// <summary>
        /// List rules 
        /// </summary>
        /// <param name="filterName">Filter for rules containing the given name</param>
        /// <param name="filterEnabled">Filter for rules by active status, null for both</param>
        /// <param name="filterSystem">Filter for rules that are system rules when true, or not when false. Leave off for both mixed</param>
        /// <param name="filterTrigger">Filter for rules that are for the trigger with the given name</param>
        /// <param name="filterAction">Filter for rules that use the action with the given name</param>
        /// <param name="filterCondition">Filter for rules that have a condition containing the given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetBRERules(string filterName, bool? filterEnabled, bool? filterSystem, string filterTrigger, string filterAction, string filterCondition, int? size, int? page);

        /// <summary>
        /// Enable or disable a rule This is helpful for turning off systems rules which cannot be deleted or modified otherwise
        /// </summary>
        /// <param name="id">The id of the rule</param>
        /// <param name="enabled">The boolean value</param>
        void SetBRERule(string id, BooleanResource enabled);

        /// <summary>
        /// Update a rule Cannot update system rules
        /// </summary>
        /// <param name="id">The id of the rule</param>
        /// <param name="breRule">The BRE rule object</param>
        void UpdateBRERule(string id, BreRule breRule);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineRulesApi : IBRERuleEngineRulesApi
    {
        private readonly KnetikCoroutine mCreateBRERuleCoroutine;
        private DateTime mCreateBRERuleStartTime;
        private string mCreateBRERulePath;
        private readonly KnetikCoroutine mDeleteBRERuleCoroutine;
        private DateTime mDeleteBRERuleStartTime;
        private string mDeleteBRERulePath;
        private readonly KnetikCoroutine mGetBREExpressionAsStringCoroutine;
        private DateTime mGetBREExpressionAsStringStartTime;
        private string mGetBREExpressionAsStringPath;
        private readonly KnetikCoroutine mGetBRERuleCoroutine;
        private DateTime mGetBRERuleStartTime;
        private string mGetBRERulePath;
        private readonly KnetikCoroutine mGetBRERulesCoroutine;
        private DateTime mGetBRERulesStartTime;
        private string mGetBRERulesPath;
        private readonly KnetikCoroutine mSetBRERuleCoroutine;
        private DateTime mSetBRERuleStartTime;
        private string mSetBRERulePath;
        private readonly KnetikCoroutine mUpdateBRERuleCoroutine;
        private DateTime mUpdateBRERuleStartTime;
        private string mUpdateBRERulePath;

        public BreRule CreateBRERuleData { get; private set; }
        public delegate void CreateBRERuleCompleteDelegate(BreRule response);
        public CreateBRERuleCompleteDelegate CreateBRERuleComplete;

        public delegate void DeleteBRERuleCompleteDelegate();
        public DeleteBRERuleCompleteDelegate DeleteBRERuleComplete;

        public string GetBREExpressionAsStringData { get; private set; }
        public delegate void GetBREExpressionAsStringCompleteDelegate(string response);
        public GetBREExpressionAsStringCompleteDelegate GetBREExpressionAsStringComplete;

        public BreRule GetBRERuleData { get; private set; }
        public delegate void GetBRERuleCompleteDelegate(BreRule response);
        public GetBRERuleCompleteDelegate GetBRERuleComplete;

        public PageResourceBreRule GetBRERulesData { get; private set; }
        public delegate void GetBRERulesCompleteDelegate(PageResourceBreRule response);
        public GetBRERulesCompleteDelegate GetBRERulesComplete;

        public delegate void SetBRERuleCompleteDelegate();
        public SetBRERuleCompleteDelegate SetBRERuleComplete;

        public BreRule UpdateBRERuleData { get; private set; }
        public delegate void UpdateBRERuleCompleteDelegate(BreRule response);
        public UpdateBRERuleCompleteDelegate UpdateBRERuleComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineRulesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineRulesApi()
        {
            mCreateBRERuleCoroutine = new KnetikCoroutine();
            mDeleteBRERuleCoroutine = new KnetikCoroutine();
            mGetBREExpressionAsStringCoroutine = new KnetikCoroutine();
            mGetBRERuleCoroutine = new KnetikCoroutine();
            mGetBRERulesCoroutine = new KnetikCoroutine();
            mSetBRERuleCoroutine = new KnetikCoroutine();
            mUpdateBRERuleCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a rule Rules define which actions to run when a given event verifies the specified condition. Full list of predicates and other type of expressions can be found at GET /bre/expressions/
        /// </summary>
        /// <param name="breRule">The BRE rule object</param>
        public void CreateBRERule(BreRule breRule)
        {
            
            mCreateBRERulePath = "/bre/rules";
            if (!string.IsNullOrEmpty(mCreateBRERulePath))
            {
                mCreateBRERulePath = mCreateBRERulePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(breRule); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateBRERuleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateBRERuleStartTime, mCreateBRERulePath, "Sending server request...");

            // make the HTTP request
            mCreateBRERuleCoroutine.ResponseReceived += CreateBRERuleCallback;
            mCreateBRERuleCoroutine.Start(mCreateBRERulePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateBRERuleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateBRERule: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateBRERule: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateBRERuleData = (BreRule) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(BreRule), response.Headers);
            KnetikLogger.LogResponse(mCreateBRERuleStartTime, mCreateBRERulePath, string.Format("Response received successfully:\n{0}", CreateBRERuleData.ToString()));

            if (CreateBRERuleComplete != null)
            {
                CreateBRERuleComplete(CreateBRERuleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a rule May fail if there are existing rules against it. Cannot delete core rules
        /// </summary>
        /// <param name="id">The id of the rule</param>
        public void DeleteBRERule(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteBRERule");
            }
            
            mDeleteBRERulePath = "/bre/rules/{id}";
            if (!string.IsNullOrEmpty(mDeleteBRERulePath))
            {
                mDeleteBRERulePath = mDeleteBRERulePath.Replace("{format}", "json");
            }
            mDeleteBRERulePath = mDeleteBRERulePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteBRERuleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteBRERuleStartTime, mDeleteBRERulePath, "Sending server request...");

            // make the HTTP request
            mDeleteBRERuleCoroutine.ResponseReceived += DeleteBRERuleCallback;
            mDeleteBRERuleCoroutine.Start(mDeleteBRERulePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteBRERuleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteBRERule: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteBRERule: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteBRERuleStartTime, mDeleteBRERulePath, "Response received successfully.");
            if (DeleteBRERuleComplete != null)
            {
                DeleteBRERuleComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a string representation of the provided expression 
        /// </summary>
        /// <param name="expression">The expression</param>
        public void GetBREExpressionAsString(Expressionobject expression)
        {
            
            mGetBREExpressionAsStringPath = "/bre/rules/expression-as-string";
            if (!string.IsNullOrEmpty(mGetBREExpressionAsStringPath))
            {
                mGetBREExpressionAsStringPath = mGetBREExpressionAsStringPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(expression); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBREExpressionAsStringStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBREExpressionAsStringStartTime, mGetBREExpressionAsStringPath, "Sending server request...");

            // make the HTTP request
            mGetBREExpressionAsStringCoroutine.ResponseReceived += GetBREExpressionAsStringCallback;
            mGetBREExpressionAsStringCoroutine.Start(mGetBREExpressionAsStringPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBREExpressionAsStringCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREExpressionAsString: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREExpressionAsString: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBREExpressionAsStringData = (string) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mGetBREExpressionAsStringStartTime, mGetBREExpressionAsStringPath, string.Format("Response received successfully:\n{0}", GetBREExpressionAsStringData.ToString()));

            if (GetBREExpressionAsStringComplete != null)
            {
                GetBREExpressionAsStringComplete(GetBREExpressionAsStringData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single rule 
        /// </summary>
        /// <param name="id">The id of the rule</param>
        public void GetBRERule(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBRERule");
            }
            
            mGetBRERulePath = "/bre/rules/{id}";
            if (!string.IsNullOrEmpty(mGetBRERulePath))
            {
                mGetBRERulePath = mGetBRERulePath.Replace("{format}", "json");
            }
            mGetBRERulePath = mGetBRERulePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBRERuleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBRERuleStartTime, mGetBRERulePath, "Sending server request...");

            // make the HTTP request
            mGetBRERuleCoroutine.ResponseReceived += GetBRERuleCallback;
            mGetBRERuleCoroutine.Start(mGetBRERulePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBRERuleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRERule: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRERule: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBRERuleData = (BreRule) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(BreRule), response.Headers);
            KnetikLogger.LogResponse(mGetBRERuleStartTime, mGetBRERulePath, string.Format("Response received successfully:\n{0}", GetBRERuleData.ToString()));

            if (GetBRERuleComplete != null)
            {
                GetBRERuleComplete(GetBRERuleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List rules 
        /// </summary>
        /// <param name="filterName">Filter for rules containing the given name</param>
        /// <param name="filterEnabled">Filter for rules by active status, null for both</param>
        /// <param name="filterSystem">Filter for rules that are system rules when true, or not when false. Leave off for both mixed</param>
        /// <param name="filterTrigger">Filter for rules that are for the trigger with the given name</param>
        /// <param name="filterAction">Filter for rules that use the action with the given name</param>
        /// <param name="filterCondition">Filter for rules that have a condition containing the given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetBRERules(string filterName, bool? filterEnabled, bool? filterSystem, string filterTrigger, string filterAction, string filterCondition, int? size, int? page)
        {
            
            mGetBRERulesPath = "/bre/rules";
            if (!string.IsNullOrEmpty(mGetBRERulesPath))
            {
                mGetBRERulesPath = mGetBRERulesPath.Replace("{format}", "json");
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

            if (filterEnabled != null)
            {
                queryParams.Add("filter_enabled", KnetikClient.DefaultClient.ParameterToString(filterEnabled));
            }

            if (filterSystem != null)
            {
                queryParams.Add("filter_system", KnetikClient.DefaultClient.ParameterToString(filterSystem));
            }

            if (filterTrigger != null)
            {
                queryParams.Add("filter_trigger", KnetikClient.DefaultClient.ParameterToString(filterTrigger));
            }

            if (filterAction != null)
            {
                queryParams.Add("filter_action", KnetikClient.DefaultClient.ParameterToString(filterAction));
            }

            if (filterCondition != null)
            {
                queryParams.Add("filter_condition", KnetikClient.DefaultClient.ParameterToString(filterCondition));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBRERulesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBRERulesStartTime, mGetBRERulesPath, "Sending server request...");

            // make the HTTP request
            mGetBRERulesCoroutine.ResponseReceived += GetBRERulesCallback;
            mGetBRERulesCoroutine.Start(mGetBRERulesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBRERulesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRERules: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBRERules: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBRERulesData = (PageResourceBreRule) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceBreRule), response.Headers);
            KnetikLogger.LogResponse(mGetBRERulesStartTime, mGetBRERulesPath, string.Format("Response received successfully:\n{0}", GetBRERulesData.ToString()));

            if (GetBRERulesComplete != null)
            {
                GetBRERulesComplete(GetBRERulesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Enable or disable a rule This is helpful for turning off systems rules which cannot be deleted or modified otherwise
        /// </summary>
        /// <param name="id">The id of the rule</param>
        /// <param name="enabled">The boolean value</param>
        public void SetBRERule(string id, BooleanResource enabled)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SetBRERule");
            }
            
            mSetBRERulePath = "/bre/rules/{id}/enabled";
            if (!string.IsNullOrEmpty(mSetBRERulePath))
            {
                mSetBRERulePath = mSetBRERulePath.Replace("{format}", "json");
            }
            mSetBRERulePath = mSetBRERulePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(enabled); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetBRERuleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetBRERuleStartTime, mSetBRERulePath, "Sending server request...");

            // make the HTTP request
            mSetBRERuleCoroutine.ResponseReceived += SetBRERuleCallback;
            mSetBRERuleCoroutine.Start(mSetBRERulePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetBRERuleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetBRERule: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetBRERule: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetBRERuleStartTime, mSetBRERulePath, "Response received successfully.");
            if (SetBRERuleComplete != null)
            {
                SetBRERuleComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a rule Cannot update system rules
        /// </summary>
        /// <param name="id">The id of the rule</param>
        /// <param name="breRule">The BRE rule object</param>
        public void UpdateBRERule(string id, BreRule breRule)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateBRERule");
            }
            
            mUpdateBRERulePath = "/bre/rules/{id}";
            if (!string.IsNullOrEmpty(mUpdateBRERulePath))
            {
                mUpdateBRERulePath = mUpdateBRERulePath.Replace("{format}", "json");
            }
            mUpdateBRERulePath = mUpdateBRERulePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(breRule); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateBRERuleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateBRERuleStartTime, mUpdateBRERulePath, "Sending server request...");

            // make the HTTP request
            mUpdateBRERuleCoroutine.ResponseReceived += UpdateBRERuleCallback;
            mUpdateBRERuleCoroutine.Start(mUpdateBRERulePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateBRERuleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBRERule: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBRERule: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateBRERuleData = (BreRule) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(BreRule), response.Headers);
            KnetikLogger.LogResponse(mUpdateBRERuleStartTime, mUpdateBRERulePath, string.Format("Response received successfully:\n{0}", UpdateBRERuleData.ToString()));

            if (UpdateBRERuleComplete != null)
            {
                UpdateBRERuleComplete(UpdateBRERuleData);
            }
        }

    }
}
