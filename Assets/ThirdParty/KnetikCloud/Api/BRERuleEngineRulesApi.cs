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
    public interface IBRERuleEngineRulesApi
    {
        BreRule CreateBRERuleData { get; }

        /// <summary>
        /// Create a rule Rules define which actions to run when a given event verifies the specified condition. Full list of predicates and other type of expressions can be found at GET /bre/expressions/. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
        /// </summary>
        /// <param name="breRule">The BRE rule object</param>
        void CreateBRERule(BreRule breRule);

        

        /// <summary>
        /// Delete a rule May fail if there are existing rules against it. Cannot delete core rules. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
        /// </summary>
        /// <param name="id">The id of the rule</param>
        void DeleteBRERule(string id);

        string GetBREExpressionAsStringData { get; }

        /// <summary>
        /// Returns a string representation of the provided expression &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
        /// </summary>
        /// <param name="expression">The expression</param>
        void GetBREExpressionAsString(Expressionobject expression);

        BreRule GetBRERuleData { get; }

        /// <summary>
        /// Get a single rule &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
        /// </summary>
        /// <param name="id">The id of the rule</param>
        void GetBRERule(string id);

        PageResourceBreRule GetBRERulesData { get; }

        /// <summary>
        /// List rules &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
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
        /// Enable or disable a rule This is helpful for turning off systems rules which cannot be deleted or modified otherwise. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
        /// </summary>
        /// <param name="id">The id of the rule</param>
        /// <param name="enabled">The boolean value</param>
        void SetBRERule(string id, BooleanResource enabled);

        BreRule UpdateBRERuleData { get; }

        /// <summary>
        /// Update a rule Cannot update system rules. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateBRERuleResponseContext;
        private DateTime mCreateBRERuleStartTime;
        private readonly KnetikResponseContext mDeleteBRERuleResponseContext;
        private DateTime mDeleteBRERuleStartTime;
        private readonly KnetikResponseContext mGetBREExpressionAsStringResponseContext;
        private DateTime mGetBREExpressionAsStringStartTime;
        private readonly KnetikResponseContext mGetBRERuleResponseContext;
        private DateTime mGetBRERuleStartTime;
        private readonly KnetikResponseContext mGetBRERulesResponseContext;
        private DateTime mGetBRERulesStartTime;
        private readonly KnetikResponseContext mSetBRERuleResponseContext;
        private DateTime mSetBRERuleStartTime;
        private readonly KnetikResponseContext mUpdateBRERuleResponseContext;
        private DateTime mUpdateBRERuleStartTime;

        public BreRule CreateBRERuleData { get; private set; }
        public delegate void CreateBRERuleCompleteDelegate(long responseCode, BreRule response);
        public CreateBRERuleCompleteDelegate CreateBRERuleComplete;

        public delegate void DeleteBRERuleCompleteDelegate(long responseCode);
        public DeleteBRERuleCompleteDelegate DeleteBRERuleComplete;

        public string GetBREExpressionAsStringData { get; private set; }
        public delegate void GetBREExpressionAsStringCompleteDelegate(long responseCode, string response);
        public GetBREExpressionAsStringCompleteDelegate GetBREExpressionAsStringComplete;

        public BreRule GetBRERuleData { get; private set; }
        public delegate void GetBRERuleCompleteDelegate(long responseCode, BreRule response);
        public GetBRERuleCompleteDelegate GetBRERuleComplete;

        public PageResourceBreRule GetBRERulesData { get; private set; }
        public delegate void GetBRERulesCompleteDelegate(long responseCode, PageResourceBreRule response);
        public GetBRERulesCompleteDelegate GetBRERulesComplete;

        public delegate void SetBRERuleCompleteDelegate(long responseCode);
        public SetBRERuleCompleteDelegate SetBRERuleComplete;

        public BreRule UpdateBRERuleData { get; private set; }
        public delegate void UpdateBRERuleCompleteDelegate(long responseCode, BreRule response);
        public UpdateBRERuleCompleteDelegate UpdateBRERuleComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineRulesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineRulesApi()
        {
            mCreateBRERuleResponseContext = new KnetikResponseContext();
            mCreateBRERuleResponseContext.ResponseReceived += OnCreateBRERuleResponse;
            mDeleteBRERuleResponseContext = new KnetikResponseContext();
            mDeleteBRERuleResponseContext.ResponseReceived += OnDeleteBRERuleResponse;
            mGetBREExpressionAsStringResponseContext = new KnetikResponseContext();
            mGetBREExpressionAsStringResponseContext.ResponseReceived += OnGetBREExpressionAsStringResponse;
            mGetBRERuleResponseContext = new KnetikResponseContext();
            mGetBRERuleResponseContext.ResponseReceived += OnGetBRERuleResponse;
            mGetBRERulesResponseContext = new KnetikResponseContext();
            mGetBRERulesResponseContext.ResponseReceived += OnGetBRERulesResponse;
            mSetBRERuleResponseContext = new KnetikResponseContext();
            mSetBRERuleResponseContext.ResponseReceived += OnSetBRERuleResponse;
            mUpdateBRERuleResponseContext = new KnetikResponseContext();
            mUpdateBRERuleResponseContext.ResponseReceived += OnUpdateBRERuleResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a rule Rules define which actions to run when a given event verifies the specified condition. Full list of predicates and other type of expressions can be found at GET /bre/expressions/. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
        /// </summary>
        /// <param name="breRule">The BRE rule object</param>
        public void CreateBRERule(BreRule breRule)
        {
            
            mWebCallEvent.WebPath = "/bre/rules";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(breRule); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateBRERuleStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateBRERuleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateBRERuleStartTime, "CreateBRERule", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateBRERuleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateBRERule: " + response.Error);
            }

            CreateBRERuleData = (BreRule) KnetikClient.Deserialize(response.Content, typeof(BreRule), response.Headers);
            KnetikLogger.LogResponse(mCreateBRERuleStartTime, "CreateBRERule", string.Format("Response received successfully:\n{0}", CreateBRERuleData));

            if (CreateBRERuleComplete != null)
            {
                CreateBRERuleComplete(response.ResponseCode, CreateBRERuleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a rule May fail if there are existing rules against it. Cannot delete core rules. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
        /// </summary>
        /// <param name="id">The id of the rule</param>
        public void DeleteBRERule(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteBRERule");
            }
            
            mWebCallEvent.WebPath = "/bre/rules/{id}";
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
            mDeleteBRERuleStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteBRERuleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteBRERuleStartTime, "DeleteBRERule", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteBRERuleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteBRERule: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteBRERuleStartTime, "DeleteBRERule", "Response received successfully.");
            if (DeleteBRERuleComplete != null)
            {
                DeleteBRERuleComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a string representation of the provided expression &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
        /// </summary>
        /// <param name="expression">The expression</param>
        public void GetBREExpressionAsString(Expressionobject expression)
        {
            
            mWebCallEvent.WebPath = "/bre/rules/expression-as-string";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(expression); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetBREExpressionAsStringStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBREExpressionAsStringResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mGetBREExpressionAsStringStartTime, "GetBREExpressionAsString", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBREExpressionAsStringResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBREExpressionAsString: " + response.Error);
            }

            GetBREExpressionAsStringData = (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mGetBREExpressionAsStringStartTime, "GetBREExpressionAsString", string.Format("Response received successfully:\n{0}", GetBREExpressionAsStringData));

            if (GetBREExpressionAsStringComplete != null)
            {
                GetBREExpressionAsStringComplete(response.ResponseCode, GetBREExpressionAsStringData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single rule &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
        /// </summary>
        /// <param name="id">The id of the rule</param>
        public void GetBRERule(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBRERule");
            }
            
            mWebCallEvent.WebPath = "/bre/rules/{id}";
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
            mGetBRERuleStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBRERuleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBRERuleStartTime, "GetBRERule", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBRERuleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBRERule: " + response.Error);
            }

            GetBRERuleData = (BreRule) KnetikClient.Deserialize(response.Content, typeof(BreRule), response.Headers);
            KnetikLogger.LogResponse(mGetBRERuleStartTime, "GetBRERule", string.Format("Response received successfully:\n{0}", GetBRERuleData));

            if (GetBRERuleComplete != null)
            {
                GetBRERuleComplete(response.ResponseCode, GetBRERuleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List rules &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
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
            
            mWebCallEvent.WebPath = "/bre/rules";
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

            if (filterEnabled != null)
            {
                mWebCallEvent.QueryParams["filter_enabled"] = KnetikClient.ParameterToString(filterEnabled);
            }

            if (filterSystem != null)
            {
                mWebCallEvent.QueryParams["filter_system"] = KnetikClient.ParameterToString(filterSystem);
            }

            if (filterTrigger != null)
            {
                mWebCallEvent.QueryParams["filter_trigger"] = KnetikClient.ParameterToString(filterTrigger);
            }

            if (filterAction != null)
            {
                mWebCallEvent.QueryParams["filter_action"] = KnetikClient.ParameterToString(filterAction);
            }

            if (filterCondition != null)
            {
                mWebCallEvent.QueryParams["filter_condition"] = KnetikClient.ParameterToString(filterCondition);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetBRERulesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBRERulesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBRERulesStartTime, "GetBRERules", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBRERulesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBRERules: " + response.Error);
            }

            GetBRERulesData = (PageResourceBreRule) KnetikClient.Deserialize(response.Content, typeof(PageResourceBreRule), response.Headers);
            KnetikLogger.LogResponse(mGetBRERulesStartTime, "GetBRERules", string.Format("Response received successfully:\n{0}", GetBRERulesData));

            if (GetBRERulesComplete != null)
            {
                GetBRERulesComplete(response.ResponseCode, GetBRERulesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Enable or disable a rule This is helpful for turning off systems rules which cannot be deleted or modified otherwise. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
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
            
            mWebCallEvent.WebPath = "/bre/rules/{id}/enabled";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(enabled); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetBRERuleStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetBRERuleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetBRERuleStartTime, "SetBRERule", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetBRERuleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetBRERule: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetBRERuleStartTime, "SetBRERule", "Response received successfully.");
            if (SetBRERuleComplete != null)
            {
                SetBRERuleComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a rule Cannot update system rules. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_RULES_ADMIN
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
            
            mWebCallEvent.WebPath = "/bre/rules/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(breRule); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateBRERuleStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateBRERuleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateBRERuleStartTime, "UpdateBRERule", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateBRERuleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateBRERule: " + response.Error);
            }

            UpdateBRERuleData = (BreRule) KnetikClient.Deserialize(response.Content, typeof(BreRule), response.Headers);
            KnetikLogger.LogResponse(mUpdateBRERuleStartTime, "UpdateBRERule", string.Format("Response received successfully:\n{0}", UpdateBRERuleData));

            if (UpdateBRERuleComplete != null)
            {
                UpdateBRERuleComplete(response.ResponseCode, UpdateBRERuleData);
            }
        }

    }
}
