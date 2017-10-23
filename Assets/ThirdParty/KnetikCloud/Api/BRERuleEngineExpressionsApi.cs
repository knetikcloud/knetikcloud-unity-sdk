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
    public interface IBRERuleEngineExpressionsApi
    {
        ExpressionResource GetBREExpressionData { get; }

        List<ExpressionResource> GetBREExpressionsData { get; }

        StringWrapper GetExpressionAsTextData { get; }

        
        /// <summary>
        /// Lookup a specific expression 
        /// </summary>
        /// <param name="type">Specifiy the type of expression as returned by the listing endpoint</param>
        void GetBREExpression(string type);

        /// <summary>
        /// Get a list of supported expressions to use in conditions or actions. Each resource contains a type and a definition that are read-only, all the other fields must be provided when using the expression in a rule.
        /// </summary>
        /// <param name="filterTypeGroup">Filter for expressions by type group</param>
        void GetBREExpressions(string filterTypeGroup);

        /// <summary>
        /// Returns the textual representation of an expression 
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
        private readonly KnetikCoroutine mGetBREExpressionCoroutine;
        private DateTime mGetBREExpressionStartTime;
        private string mGetBREExpressionPath;
        private readonly KnetikCoroutine mGetBREExpressionsCoroutine;
        private DateTime mGetBREExpressionsStartTime;
        private string mGetBREExpressionsPath;
        private readonly KnetikCoroutine mGetExpressionAsTextCoroutine;
        private DateTime mGetExpressionAsTextStartTime;
        private string mGetExpressionAsTextPath;

        public ExpressionResource GetBREExpressionData { get; private set; }
        public delegate void GetBREExpressionCompleteDelegate(ExpressionResource response);
        public GetBREExpressionCompleteDelegate GetBREExpressionComplete;

        public List<ExpressionResource> GetBREExpressionsData { get; private set; }
        public delegate void GetBREExpressionsCompleteDelegate(List<ExpressionResource> response);
        public GetBREExpressionsCompleteDelegate GetBREExpressionsComplete;

        public StringWrapper GetExpressionAsTextData { get; private set; }
        public delegate void GetExpressionAsTextCompleteDelegate(StringWrapper response);
        public GetExpressionAsTextCompleteDelegate GetExpressionAsTextComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineExpressionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineExpressionsApi()
        {
            mGetBREExpressionCoroutine = new KnetikCoroutine();
            mGetBREExpressionsCoroutine = new KnetikCoroutine();
            mGetExpressionAsTextCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Lookup a specific expression 
        /// </summary>
        /// <param name="type">Specifiy the type of expression as returned by the listing endpoint</param>
        public void GetBREExpression(string type)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling GetBREExpression");
            }
            
            mGetBREExpressionPath = "/bre/expressions/{type}";
            if (!string.IsNullOrEmpty(mGetBREExpressionPath))
            {
                mGetBREExpressionPath = mGetBREExpressionPath.Replace("{format}", "json");
            }
            mGetBREExpressionPath = mGetBREExpressionPath.Replace("{" + "type" + "}", KnetikClient.DefaultClient.ParameterToString(type));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBREExpressionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBREExpressionStartTime, mGetBREExpressionPath, "Sending server request...");

            // make the HTTP request
            mGetBREExpressionCoroutine.ResponseReceived += GetBREExpressionCallback;
            mGetBREExpressionCoroutine.Start(mGetBREExpressionPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBREExpressionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREExpression: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREExpression: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBREExpressionData = (ExpressionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ExpressionResource), response.Headers);
            KnetikLogger.LogResponse(mGetBREExpressionStartTime, mGetBREExpressionPath, string.Format("Response received successfully:\n{0}", GetBREExpressionData.ToString()));

            if (GetBREExpressionComplete != null)
            {
                GetBREExpressionComplete(GetBREExpressionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a list of supported expressions to use in conditions or actions. Each resource contains a type and a definition that are read-only, all the other fields must be provided when using the expression in a rule.
        /// </summary>
        /// <param name="filterTypeGroup">Filter for expressions by type group</param>
        public void GetBREExpressions(string filterTypeGroup)
        {
            
            mGetBREExpressionsPath = "/bre/expressions";
            if (!string.IsNullOrEmpty(mGetBREExpressionsPath))
            {
                mGetBREExpressionsPath = mGetBREExpressionsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterTypeGroup != null)
            {
                queryParams.Add("filter_type_group", KnetikClient.DefaultClient.ParameterToString(filterTypeGroup));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBREExpressionsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBREExpressionsStartTime, mGetBREExpressionsPath, "Sending server request...");

            // make the HTTP request
            mGetBREExpressionsCoroutine.ResponseReceived += GetBREExpressionsCallback;
            mGetBREExpressionsCoroutine.Start(mGetBREExpressionsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBREExpressionsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREExpressions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREExpressions: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBREExpressionsData = (List<ExpressionResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<ExpressionResource>), response.Headers);
            KnetikLogger.LogResponse(mGetBREExpressionsStartTime, mGetBREExpressionsPath, string.Format("Response received successfully:\n{0}", GetBREExpressionsData.ToString()));

            if (GetBREExpressionsComplete != null)
            {
                GetBREExpressionsComplete(GetBREExpressionsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the textual representation of an expression 
        /// </summary>
        /// <param name="expression">The expression resource to be converted</param>
        public void GetExpressionAsText(ExpressionResource expression)
        {
            
            mGetExpressionAsTextPath = "/bre/expressions";
            if (!string.IsNullOrEmpty(mGetExpressionAsTextPath))
            {
                mGetExpressionAsTextPath = mGetExpressionAsTextPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(expression); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetExpressionAsTextStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetExpressionAsTextStartTime, mGetExpressionAsTextPath, "Sending server request...");

            // make the HTTP request
            mGetExpressionAsTextCoroutine.ResponseReceived += GetExpressionAsTextCallback;
            mGetExpressionAsTextCoroutine.Start(mGetExpressionAsTextPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetExpressionAsTextCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetExpressionAsText: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetExpressionAsText: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetExpressionAsTextData = (StringWrapper) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(StringWrapper), response.Headers);
            KnetikLogger.LogResponse(mGetExpressionAsTextStartTime, mGetExpressionAsTextPath, string.Format("Response received successfully:\n{0}", GetExpressionAsTextData.ToString()));

            if (GetExpressionAsTextComplete != null)
            {
                GetExpressionAsTextComplete(GetExpressionAsTextData);
            }
        }

    }
}
