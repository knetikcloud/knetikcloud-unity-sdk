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
    public interface ITemplatesPropertiesApi
    {
        PropertyFieldListResource GetTemplatePropertyTypeData { get; }

        /// <summary>
        /// Get details for a template property type 
        /// </summary>
        /// <param name="type">type</param>
        void GetTemplatePropertyType(string type);

        List<PropertyFieldListResource> GetTemplatePropertyTypesData { get; }

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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetTemplatePropertyTypeResponseContext;
        private DateTime mGetTemplatePropertyTypeStartTime;
        private readonly KnetikResponseContext mGetTemplatePropertyTypesResponseContext;
        private DateTime mGetTemplatePropertyTypesStartTime;

        public PropertyFieldListResource GetTemplatePropertyTypeData { get; private set; }
        public delegate void GetTemplatePropertyTypeCompleteDelegate(long responseCode, PropertyFieldListResource response);
        public GetTemplatePropertyTypeCompleteDelegate GetTemplatePropertyTypeComplete;

        public List<PropertyFieldListResource> GetTemplatePropertyTypesData { get; private set; }
        public delegate void GetTemplatePropertyTypesCompleteDelegate(long responseCode, List<PropertyFieldListResource> response);
        public GetTemplatePropertyTypesCompleteDelegate GetTemplatePropertyTypesComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplatesPropertiesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TemplatesPropertiesApi()
        {
            mGetTemplatePropertyTypeResponseContext = new KnetikResponseContext();
            mGetTemplatePropertyTypeResponseContext.ResponseReceived += OnGetTemplatePropertyTypeResponse;
            mGetTemplatePropertyTypesResponseContext = new KnetikResponseContext();
            mGetTemplatePropertyTypesResponseContext.ResponseReceived += OnGetTemplatePropertyTypesResponse;
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
            
            mWebCallEvent.WebPath = "/templates/properties/{type}";
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
            mGetTemplatePropertyTypeStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetTemplatePropertyTypeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetTemplatePropertyTypeStartTime, "GetTemplatePropertyType", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetTemplatePropertyTypeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetTemplatePropertyType: " + response.Error);
            }

            GetTemplatePropertyTypeData = (PropertyFieldListResource) KnetikClient.Deserialize(response.Content, typeof(PropertyFieldListResource), response.Headers);
            KnetikLogger.LogResponse(mGetTemplatePropertyTypeStartTime, "GetTemplatePropertyType", string.Format("Response received successfully:\n{0}", GetTemplatePropertyTypeData));

            if (GetTemplatePropertyTypeComplete != null)
            {
                GetTemplatePropertyTypeComplete(response.ResponseCode, GetTemplatePropertyTypeData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List template property types 
        /// </summary>
        public void GetTemplatePropertyTypes()
        {
            
            mWebCallEvent.WebPath = "/templates/properties";
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
            mGetTemplatePropertyTypesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetTemplatePropertyTypesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetTemplatePropertyTypesStartTime, "GetTemplatePropertyTypes", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetTemplatePropertyTypesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetTemplatePropertyTypes: " + response.Error);
            }

            GetTemplatePropertyTypesData = (List<PropertyFieldListResource>) KnetikClient.Deserialize(response.Content, typeof(List<PropertyFieldListResource>), response.Headers);
            KnetikLogger.LogResponse(mGetTemplatePropertyTypesStartTime, "GetTemplatePropertyTypes", string.Format("Response received successfully:\n{0}", GetTemplatePropertyTypesData));

            if (GetTemplatePropertyTypesComplete != null)
            {
                GetTemplatePropertyTypesComplete(response.ResponseCode, GetTemplatePropertyTypesData);
            }
        }

    }
}
