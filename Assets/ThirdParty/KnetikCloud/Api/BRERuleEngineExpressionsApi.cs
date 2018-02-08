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
    public interface IBRERuleEngineExpressionsApi
    {
        ExpressionResource GetBREExpressionData { get; }

        /// <summary>
        /// Lookup a specific expression &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_EXPRESSIONS_USER
        /// </summary>
        /// <param name="type">Specifiy the type of expression as returned by the listing endpoint</param>
        void GetBREExpression(string type);

        List<ExpressionResource> GetBREExpressionsData { get; }

        /// <summary>
        /// Get a list of supported expressions to use in conditions or actions Each resource contains a type and a definition that are read-only, all the other fields must be provided when using the expression in a rule. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_EXPRESSIONS_USER
        /// </summary>
        /// <param name="filterTypeGroup">Filter for expressions by type group</param>
        void GetBREExpressions(string filterTypeGroup);

        StringWrapper GetExpressionAsTextData { get; }

        /// <summary>
        /// Returns the textual representation of an expression &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_EXPRESSIONS_USER
        /// </summary>
        /// <param name="expression">The expression resource to be converted</param>
        void GetExpressionAsText(ExpressionResource expression);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineExpressionsApi : IBRERuleEngineExpressionsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetBREExpressionResponseContext;
        private DateTime mGetBREExpressionStartTime;
        private readonly KnetikResponseContext mGetBREExpressionsResponseContext;
        private DateTime mGetBREExpressionsStartTime;
        private readonly KnetikResponseContext mGetExpressionAsTextResponseContext;
        private DateTime mGetExpressionAsTextStartTime;

        public ExpressionResource GetBREExpressionData { get; private set; }
        public delegate void GetBREExpressionCompleteDelegate(long responseCode, ExpressionResource response);
        public GetBREExpressionCompleteDelegate GetBREExpressionComplete;

        public List<ExpressionResource> GetBREExpressionsData { get; private set; }
        public delegate void GetBREExpressionsCompleteDelegate(long responseCode, List<ExpressionResource> response);
        public GetBREExpressionsCompleteDelegate GetBREExpressionsComplete;

        public StringWrapper GetExpressionAsTextData { get; private set; }
        public delegate void GetExpressionAsTextCompleteDelegate(long responseCode, StringWrapper response);
        public GetExpressionAsTextCompleteDelegate GetExpressionAsTextComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineExpressionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineExpressionsApi()
        {
            mGetBREExpressionResponseContext = new KnetikResponseContext();
            mGetBREExpressionResponseContext.ResponseReceived += OnGetBREExpressionResponse;
            mGetBREExpressionsResponseContext = new KnetikResponseContext();
            mGetBREExpressionsResponseContext.ResponseReceived += OnGetBREExpressionsResponse;
            mGetExpressionAsTextResponseContext = new KnetikResponseContext();
            mGetExpressionAsTextResponseContext.ResponseReceived += OnGetExpressionAsTextResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Lookup a specific expression &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_EXPRESSIONS_USER
        /// </summary>
        /// <param name="type">Specifiy the type of expression as returned by the listing endpoint</param>
        public void GetBREExpression(string type)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling GetBREExpression");
            }
            
            mWebCallEvent.WebPath = "/bre/expressions/{type}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetBREExpressionStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBREExpressionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBREExpressionStartTime, "GetBREExpression", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBREExpressionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBREExpression: " + response.Error);
            }

            GetBREExpressionData = (ExpressionResource) KnetikClient.Deserialize(response.Content, typeof(ExpressionResource), response.Headers);
            KnetikLogger.LogResponse(mGetBREExpressionStartTime, "GetBREExpression", string.Format("Response received successfully:\n{0}", GetBREExpressionData));

            if (GetBREExpressionComplete != null)
            {
                GetBREExpressionComplete(response.ResponseCode, GetBREExpressionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a list of supported expressions to use in conditions or actions Each resource contains a type and a definition that are read-only, all the other fields must be provided when using the expression in a rule. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_EXPRESSIONS_USER
        /// </summary>
        /// <param name="filterTypeGroup">Filter for expressions by type group</param>
        public void GetBREExpressions(string filterTypeGroup)
        {
            
            mWebCallEvent.WebPath = "/bre/expressions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterTypeGroup != null)
            {
                mWebCallEvent.QueryParams["filter_type_group"] = KnetikClient.ParameterToString(filterTypeGroup);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetBREExpressionsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBREExpressionsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBREExpressionsStartTime, "GetBREExpressions", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBREExpressionsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBREExpressions: " + response.Error);
            }

            GetBREExpressionsData = (List<ExpressionResource>) KnetikClient.Deserialize(response.Content, typeof(List<ExpressionResource>), response.Headers);
            KnetikLogger.LogResponse(mGetBREExpressionsStartTime, "GetBREExpressions", string.Format("Response received successfully:\n{0}", GetBREExpressionsData));

            if (GetBREExpressionsComplete != null)
            {
                GetBREExpressionsComplete(response.ResponseCode, GetBREExpressionsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the textual representation of an expression &lt;b&gt;Permissions Needed:&lt;/b&gt; BRE_RULE_ENGINE_EXPRESSIONS_USER
        /// </summary>
        /// <param name="expression">The expression resource to be converted</param>
        public void GetExpressionAsText(ExpressionResource expression)
        {
            
            mWebCallEvent.WebPath = "/bre/expressions";
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
            mGetExpressionAsTextStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetExpressionAsTextResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mGetExpressionAsTextStartTime, "GetExpressionAsText", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetExpressionAsTextResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetExpressionAsText: " + response.Error);
            }

            GetExpressionAsTextData = (StringWrapper) KnetikClient.Deserialize(response.Content, typeof(StringWrapper), response.Headers);
            KnetikLogger.LogResponse(mGetExpressionAsTextStartTime, "GetExpressionAsText", string.Format("Response received successfully:\n{0}", GetExpressionAsTextData));

            if (GetExpressionAsTextComplete != null)
            {
                GetExpressionAsTextComplete(response.ResponseCode, GetExpressionAsTextData);
            }
        }

    }
}
