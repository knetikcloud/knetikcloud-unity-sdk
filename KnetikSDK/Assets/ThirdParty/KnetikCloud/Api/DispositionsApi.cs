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
    public interface IDispositionsApi
    {
        /// <summary>
        /// Add a new disposition 
        /// </summary>
        /// <param name="disposition">The new disposition record</param>
        /// <returns>DispositionResource</returns>
        DispositionResource AddDisposition (DispositionResource disposition);
        /// <summary>
        /// Delete a disposition 
        /// </summary>
        /// <param name="id">The id of the disposition record</param>
        /// <returns></returns>
        void DeleteDisposition (long? id);
        /// <summary>
        /// Returns a disposition 
        /// </summary>
        /// <param name="id">The id of the disposition record</param>
        /// <returns>DispositionResource</returns>
        DispositionResource GetDisposition (long? id);
        /// <summary>
        /// Returns a list of disposition counts 
        /// </summary>
        /// <param name="filterContext">Filter for dispositions within a context type (games, articles, polls, etc). Optionally with a specific id like filter_context&#x3D;video:47</param>
        /// <param name="filterOwner">Filter for dispositions from a specific user by id or &#39;me&#39;</param>
        /// <returns>List&lt;DispositionCount&gt;</returns>
        List<DispositionCount> GetDispositionCounts (string filterContext, string filterOwner);
        /// <summary>
        /// Returns a page of dispositions 
        /// </summary>
        /// <param name="filterContext">Filter for dispositions within a context type (games, articles, polls, etc). Optionally with a specific id like filter_context&#x3D;video:47</param>
        /// <param name="filterOwner">Filter for dispositions from a specific user by id or &#39;me&#39;</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceDispositionResource</returns>
        PageResourceDispositionResource GetDispositions (string filterContext, string filterOwner, int? size, int? page, string order);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DispositionsApi : IDispositionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DispositionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DispositionsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Add a new disposition 
        /// </summary>
        /// <param name="disposition">The new disposition record</param> 
        /// <returns>DispositionResource</returns>            
        public DispositionResource AddDisposition(DispositionResource disposition)
        {
            
            string urlPath = "/dispositions";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(disposition); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddDisposition: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddDisposition: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (DispositionResource) KnetikClient.Deserialize(response.Content, typeof(DispositionResource), response.Headers);
        }
        /// <summary>
        /// Delete a disposition 
        /// </summary>
        /// <param name="id">The id of the disposition record</param> 
        /// <returns></returns>            
        public void DeleteDisposition(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteDisposition");
            }
            
            
            string urlPath = "/dispositions/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteDisposition: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteDisposition: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Returns a disposition 
        /// </summary>
        /// <param name="id">The id of the disposition record</param> 
        /// <returns>DispositionResource</returns>            
        public DispositionResource GetDisposition(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetDisposition");
            }
            
            
            string urlPath = "/dispositions/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetDisposition: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetDisposition: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (DispositionResource) KnetikClient.Deserialize(response.Content, typeof(DispositionResource), response.Headers);
        }
        /// <summary>
        /// Returns a list of disposition counts 
        /// </summary>
        /// <param name="filterContext">Filter for dispositions within a context type (games, articles, polls, etc). Optionally with a specific id like filter_context&#x3D;video:47</param> 
        /// <param name="filterOwner">Filter for dispositions from a specific user by id or &#39;me&#39;</param> 
        /// <returns>List&lt;DispositionCount&gt;</returns>            
        public List<DispositionCount> GetDispositionCounts(string filterContext, string filterOwner)
        {
            
            string urlPath = "/dispositions/count";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterContext != null)
            {
                queryParams.Add("filter_context", KnetikClient.ParameterToString(filterContext));
            }
            
            if (filterOwner != null)
            {
                queryParams.Add("filter_owner", KnetikClient.ParameterToString(filterOwner));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetDispositionCounts: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetDispositionCounts: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<DispositionCount>) KnetikClient.Deserialize(response.Content, typeof(List<DispositionCount>), response.Headers);
        }
        /// <summary>
        /// Returns a page of dispositions 
        /// </summary>
        /// <param name="filterContext">Filter for dispositions within a context type (games, articles, polls, etc). Optionally with a specific id like filter_context&#x3D;video:47</param> 
        /// <param name="filterOwner">Filter for dispositions from a specific user by id or &#39;me&#39;</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceDispositionResource</returns>            
        public PageResourceDispositionResource GetDispositions(string filterContext, string filterOwner, int? size, int? page, string order)
        {
            
            string urlPath = "/dispositions";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterContext != null)
            {
                queryParams.Add("filter_context", KnetikClient.ParameterToString(filterContext));
            }
            
            if (filterOwner != null)
            {
                queryParams.Add("filter_owner", KnetikClient.ParameterToString(filterOwner));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetDispositions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetDispositions: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceDispositionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceDispositionResource), response.Headers);
        }
    }
}
