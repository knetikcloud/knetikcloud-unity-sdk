using System;
using System.Collections.Generic;
using RestSharp;
using com.knetikcloud.Client;
using com.knetikcloud.Model;
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
        /// <summary>
        /// Get details for a template property type 
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>PropertyFieldListResource</returns>
        PropertyFieldListResource GetTemplatePropertyType (string type);
        /// <summary>
        /// List template property types 
        /// </summary>
        /// <returns>List&lt;PropertyFieldListResource&gt;</returns>
        List<PropertyFieldListResource> GetTemplatePropertyTypes ();
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TemplatesPropertiesApi : ITemplatesPropertiesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplatesPropertiesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TemplatesPropertiesApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Get details for a template property type 
        /// </summary>
        /// <param name="type">type</param> 
        /// <returns>PropertyFieldListResource</returns>            
        public PropertyFieldListResource GetTemplatePropertyType(string type)
        {
            // verify the required parameter 'type' is set
            if (type == null)
            {
                throw new KnetikException(400, "Missing required parameter 'type' when calling GetTemplatePropertyType");
            }
            
            
            string urlPath = "/templates/properties/{type}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "type" + "}", KnetikClient.ParameterToString(type));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetTemplatePropertyType: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetTemplatePropertyType: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PropertyFieldListResource) KnetikClient.Deserialize(response.Content, typeof(PropertyFieldListResource), response.Headers);
        }
        /// <summary>
        /// List template property types 
        /// </summary>
        /// <returns>List&lt;PropertyFieldListResource&gt;</returns>            
        public List<PropertyFieldListResource> GetTemplatePropertyTypes()
        {
            
            string urlPath = "/templates/properties";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetTemplatePropertyTypes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetTemplatePropertyTypes: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<PropertyFieldListResource>) KnetikClient.Deserialize(response.Content, typeof(List<PropertyFieldListResource>), response.Headers);
        }
    }
}
