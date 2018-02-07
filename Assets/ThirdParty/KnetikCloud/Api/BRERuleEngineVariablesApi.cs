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
    public interface IBRERuleEngineVariablesApi
    {
        List<VariableTypeResource> GetBREVariableTypesData { get; }

        /// <summary>
        /// Get a list of variable types available Types include integer, string, user and invoice. These are used to qualify trigger parameters and action variables with strong typing.
        /// </summary>
        void GetBREVariableTypes();

        PageResourceSimpleReferenceResourceobject GetBREVariableValuesData { get; }

        /// <summary>
        /// List valid values for a type Used to lookup users to fill in a user constant for example. Only types marked as enumerable are suppoorted here.
        /// </summary>
        /// <param name="name">The name of the type</param>
        /// <param name="filterName">Filter results by those with names starting with this string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetBREVariableValues(string name, string filterName, int? size, int? page);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class BRERuleEngineVariablesApi : IBRERuleEngineVariablesApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetBREVariableTypesResponseContext;
        private DateTime mGetBREVariableTypesStartTime;
        private readonly KnetikResponseContext mGetBREVariableValuesResponseContext;
        private DateTime mGetBREVariableValuesStartTime;

        public List<VariableTypeResource> GetBREVariableTypesData { get; private set; }
        public delegate void GetBREVariableTypesCompleteDelegate(long responseCode, List<VariableTypeResource> response);
        public GetBREVariableTypesCompleteDelegate GetBREVariableTypesComplete;

        public PageResourceSimpleReferenceResourceobject GetBREVariableValuesData { get; private set; }
        public delegate void GetBREVariableValuesCompleteDelegate(long responseCode, PageResourceSimpleReferenceResourceobject response);
        public GetBREVariableValuesCompleteDelegate GetBREVariableValuesComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="BRERuleEngineVariablesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BRERuleEngineVariablesApi()
        {
            mGetBREVariableTypesResponseContext = new KnetikResponseContext();
            mGetBREVariableTypesResponseContext.ResponseReceived += OnGetBREVariableTypesResponse;
            mGetBREVariableValuesResponseContext = new KnetikResponseContext();
            mGetBREVariableValuesResponseContext.ResponseReceived += OnGetBREVariableValuesResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get a list of variable types available Types include integer, string, user and invoice. These are used to qualify trigger parameters and action variables with strong typing.
        /// </summary>
        public void GetBREVariableTypes()
        {
            
            mWebCallEvent.WebPath = "/bre/variable-types";
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
            mGetBREVariableTypesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBREVariableTypesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBREVariableTypesStartTime, "GetBREVariableTypes", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBREVariableTypesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBREVariableTypes: " + response.Error);
            }

            GetBREVariableTypesData = (List<VariableTypeResource>) KnetikClient.Deserialize(response.Content, typeof(List<VariableTypeResource>), response.Headers);
            KnetikLogger.LogResponse(mGetBREVariableTypesStartTime, "GetBREVariableTypes", string.Format("Response received successfully:\n{0}", GetBREVariableTypesData));

            if (GetBREVariableTypesComplete != null)
            {
                GetBREVariableTypesComplete(response.ResponseCode, GetBREVariableTypesData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/bre/variable-types/{name}/values";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

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

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetBREVariableValuesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBREVariableValuesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBREVariableValuesStartTime, "GetBREVariableValues", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBREVariableValuesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBREVariableValues: " + response.Error);
            }

            GetBREVariableValuesData = (PageResourceSimpleReferenceResourceobject) KnetikClient.Deserialize(response.Content, typeof(PageResourceSimpleReferenceResourceobject), response.Headers);
            KnetikLogger.LogResponse(mGetBREVariableValuesStartTime, "GetBREVariableValues", string.Format("Response received successfully:\n{0}", GetBREVariableValuesData));

            if (GetBREVariableValuesComplete != null)
            {
                GetBREVariableValuesComplete(response.ResponseCode, GetBREVariableValuesData);
            }
        }

    }
}
