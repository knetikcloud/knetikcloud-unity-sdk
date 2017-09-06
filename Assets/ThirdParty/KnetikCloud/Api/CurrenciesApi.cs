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
    public interface ICurrenciesApi
    {
        /// <summary>
        /// Create a currency 
        /// </summary>
        /// <param name="currency">The currency object</param>
        /// <returns>CurrencyResource</returns>
        CurrencyResource CreateCurrency (CurrencyResource currency);
        /// <summary>
        /// Delete a currency 
        /// </summary>
        /// <param name="code">The currency code</param>
        /// <returns></returns>
        void DeleteCurrency (string code);
        /// <summary>
        /// List and search currencies 
        /// </summary>
        /// <param name="filterEnabledCurrencies">Filter for alternate currencies setup explicitely in system config</param>
        /// <param name="filterType">Filter currencies by type.  Allowable values: (&#39;virtual&#39;, &#39;real&#39;)</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceCurrencyResource</returns>
        PageResourceCurrencyResource GetCurrencies (bool? filterEnabledCurrencies, string filterType, int? size, int? page, string order);
        /// <summary>
        /// Get a single currency 
        /// </summary>
        /// <param name="code">The currency code</param>
        /// <returns>CurrencyResource</returns>
        CurrencyResource GetCurrency (string code);
        /// <summary>
        /// Update a currency 
        /// </summary>
        /// <param name="code">The currency code</param>
        /// <param name="currency">The currency object</param>
        /// <returns></returns>
        void UpdateCurrency (string code, CurrencyResource currency);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class CurrenciesApi : ICurrenciesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrenciesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CurrenciesApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a currency 
        /// </summary>
        /// <param name="currency">The currency object</param> 
        /// <returns>CurrencyResource</returns>            
        public CurrencyResource CreateCurrency(CurrencyResource currency)
        {
            
            string urlPath = "/currencies";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(currency); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateCurrency: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateCurrency: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (CurrencyResource) KnetikClient.Deserialize(response.Content, typeof(CurrencyResource), response.Headers);
        }
        /// <summary>
        /// Delete a currency 
        /// </summary>
        /// <param name="code">The currency code</param> 
        /// <returns></returns>            
        public void DeleteCurrency(string code)
        {
            // verify the required parameter 'code' is set
            if (code == null)
            {
                throw new KnetikException(400, "Missing required parameter 'code' when calling DeleteCurrency");
            }
            
            
            string urlPath = "/currencies/{code}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "code" + "}", KnetikClient.ParameterToString(code));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteCurrency: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteCurrency: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// List and search currencies 
        /// </summary>
        /// <param name="filterEnabledCurrencies">Filter for alternate currencies setup explicitely in system config</param> 
        /// <param name="filterType">Filter currencies by type.  Allowable values: (&#39;virtual&#39;, &#39;real&#39;)</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceCurrencyResource</returns>            
        public PageResourceCurrencyResource GetCurrencies(bool? filterEnabledCurrencies, string filterType, int? size, int? page, string order)
        {
            
            string urlPath = "/currencies";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterEnabledCurrencies != null)
            {
                queryParams.Add("filter_enabled_currencies", KnetikClient.ParameterToString(filterEnabledCurrencies));
            }
            
            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.ParameterToString(filterType));
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCurrencies: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCurrencies: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceCurrencyResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceCurrencyResource), response.Headers);
        }
        /// <summary>
        /// Get a single currency 
        /// </summary>
        /// <param name="code">The currency code</param> 
        /// <returns>CurrencyResource</returns>            
        public CurrencyResource GetCurrency(string code)
        {
            // verify the required parameter 'code' is set
            if (code == null)
            {
                throw new KnetikException(400, "Missing required parameter 'code' when calling GetCurrency");
            }
            
            
            string urlPath = "/currencies/{code}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "code" + "}", KnetikClient.ParameterToString(code));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCurrency: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCurrency: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (CurrencyResource) KnetikClient.Deserialize(response.Content, typeof(CurrencyResource), response.Headers);
        }
        /// <summary>
        /// Update a currency 
        /// </summary>
        /// <param name="code">The currency code</param> 
        /// <param name="currency">The currency object</param> 
        /// <returns></returns>            
        public void UpdateCurrency(string code, CurrencyResource currency)
        {
            // verify the required parameter 'code' is set
            if (code == null)
            {
                throw new KnetikException(400, "Missing required parameter 'code' when calling UpdateCurrency");
            }
            
            
            string urlPath = "/currencies/{code}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "code" + "}", KnetikClient.ParameterToString(code));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(currency); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateCurrency: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateCurrency: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
    }
}
