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
    public interface ITemplatesPropertiesApi
    {
        PropertyFieldListResource GetTemplatePropertyTypeData { get; }

        List<PropertyFieldListResource> GetTemplatePropertyTypesData { get; }

        
        /// <summary>
        /// Get details for a template property type 
        /// </summary>
        /// <param name="type">type</param>
        void GetTemplatePropertyType(string type);

        /// <summary>
        /// List template property types 
        /// </summary>
        void GetTemplatePropertyTypes();

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TemplatesPropertiesApi : ITemplatesPropertiesApi
    {
        private readonly KnetikCoroutine mGetTemplatePropertyTypeCoroutine;
        private DateTime mGetTemplatePropertyTypeStartTime;
        private string mGetTemplatePropertyTypePath;
        private readonly KnetikCoroutine mGetTemplatePropertyTypesCoroutine;
        private DateTime mGetTemplatePropertyTypesStartTime;
        private string mGetTemplatePropertyTypesPath;

        public PropertyFieldListResource GetTemplatePropertyTypeData { get; private set; }
        public delegate void GetTemplatePropertyTypeCompleteDelegate(PropertyFieldListResource response);
        public GetTemplatePropertyTypeCompleteDelegate GetTemplatePropertyTypeComplete;

        public List<PropertyFieldListResource> GetTemplatePropertyTypesData { get; private set; }
        public delegate void GetTemplatePropertyTypesCompleteDelegate(List<PropertyFieldListResource> response);
        public GetTemplatePropertyTypesCompleteDelegate GetTemplatePropertyTypesComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplatesPropertiesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TemplatesPropertiesApi()
        {
            mGetTemplatePropertyTypeCoroutine = new KnetikCoroutine();
            mGetTemplatePropertyTypesCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get details for a template property type 
        /// </summary>
        /// <param name="type">type</param>
        public void GetTemplatePropertyType(string type)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling GetTemplatePropertyType");
            }
            
            mGetTemplatePropertyTypePath = "/templates/properties/{type}";
            if (!string.IsNullOrEmpty(mGetTemplatePropertyTypePath))
            {
                mGetTemplatePropertyTypePath = mGetTemplatePropertyTypePath.Replace("{format}", "json");
            }
            mGetTemplatePropertyTypePath = mGetTemplatePropertyTypePath.Replace("{" + "type" + "}", KnetikClient.DefaultClient.ParameterToString(type));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mGetTemplatePropertyTypeStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetTemplatePropertyTypeStartTime, mGetTemplatePropertyTypePath, "Sending server request...");

            // make the HTTP request
            mGetTemplatePropertyTypeCoroutine.ResponseReceived += GetTemplatePropertyTypeCallback;
            mGetTemplatePropertyTypeCoroutine.Start(mGetTemplatePropertyTypePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetTemplatePropertyTypeCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetTemplatePropertyType: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetTemplatePropertyType: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetTemplatePropertyTypeData = (PropertyFieldListResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PropertyFieldListResource), response.Headers);
            KnetikLogger.LogResponse(mGetTemplatePropertyTypeStartTime, mGetTemplatePropertyTypePath, string.Format("Response received successfully:\n{0}", GetTemplatePropertyTypeData.ToString()));

            if (GetTemplatePropertyTypeComplete != null)
            {
                GetTemplatePropertyTypeComplete(GetTemplatePropertyTypeData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List template property types 
        /// </summary>
        public void GetTemplatePropertyTypes()
        {
            
            mGetTemplatePropertyTypesPath = "/templates/properties";
            if (!string.IsNullOrEmpty(mGetTemplatePropertyTypesPath))
            {
                mGetTemplatePropertyTypesPath = mGetTemplatePropertyTypesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mGetTemplatePropertyTypesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetTemplatePropertyTypesStartTime, mGetTemplatePropertyTypesPath, "Sending server request...");

            // make the HTTP request
            mGetTemplatePropertyTypesCoroutine.ResponseReceived += GetTemplatePropertyTypesCallback;
            mGetTemplatePropertyTypesCoroutine.Start(mGetTemplatePropertyTypesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetTemplatePropertyTypesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetTemplatePropertyTypes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetTemplatePropertyTypes: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetTemplatePropertyTypesData = (List<PropertyFieldListResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<PropertyFieldListResource>), response.Headers);
            KnetikLogger.LogResponse(mGetTemplatePropertyTypesStartTime, mGetTemplatePropertyTypesPath, string.Format("Response received successfully:\n{0}", GetTemplatePropertyTypesData.ToString()));

            if (GetTemplatePropertyTypesComplete != null)
            {
                GetTemplatePropertyTypesComplete(GetTemplatePropertyTypesData);
            }
        }

    }
}
