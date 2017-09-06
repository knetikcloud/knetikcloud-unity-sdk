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
    public interface ITaxesApi
    {
        /// <summary>
        /// Create a country tax 
        /// </summary>
        /// <param name="taxResource">The tax object</param>
        /// <returns>CountryTaxResource</returns>
        CountryTaxResource CreateCountryTax (CountryTaxResource taxResource);
        /// <summary>
        /// Create a state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="taxResource">The tax object</param>
        /// <returns>StateTaxResource</returns>
        StateTaxResource CreateStateTax (string countryCodeIso3, StateTaxResource taxResource);
        /// <summary>
        /// Delete an existing tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <returns></returns>
        void DeleteCountryTax (string countryCodeIso3);
        /// <summary>
        /// Delete an existing state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="stateCode">The code of the state</param>
        /// <returns></returns>
        void DeleteStateTax (string countryCodeIso3, string stateCode);
        /// <summary>
        /// Get a single tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <returns>CountryTaxResource</returns>
        CountryTaxResource GetCountryTax (string countryCodeIso3);
        /// <summary>
        /// List and search taxes Get a list of taxes
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceCountryTaxResource</returns>
        PageResourceCountryTaxResource GetCountryTaxes (int? size, int? page, string order);
        /// <summary>
        /// Get a single state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="stateCode">The code of the state</param>
        /// <returns>StateTaxResource</returns>
        StateTaxResource GetStateTax (string countryCodeIso3, string stateCode);
        /// <summary>
        /// List and search taxes across all countries Get a list of taxes
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceStateTaxResource</returns>
        PageResourceStateTaxResource GetStateTaxesForCountries (int? size, int? page, string order);
        /// <summary>
        /// List and search taxes within a country Get a list of taxes
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceStateTaxResource</returns>
        PageResourceStateTaxResource GetStateTaxesForCountry (string countryCodeIso3, int? size, int? page, string order);
        /// <summary>
        /// Create or update a tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="taxResource">The tax object</param>
        /// <returns>CountryTaxResource</returns>
        CountryTaxResource UpdateCountryTax (string countryCodeIso3, CountryTaxResource taxResource);
        /// <summary>
        /// Create or update a state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="stateCode">The code of the state</param>
        /// <param name="taxResource">The tax object</param>
        /// <returns>StateTaxResource</returns>
        StateTaxResource UpdateStateTax (string countryCodeIso3, string stateCode, StateTaxResource taxResource);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TaxesApi : ITaxesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TaxesApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a country tax 
        /// </summary>
        /// <param name="taxResource">The tax object</param> 
        /// <returns>CountryTaxResource</returns>            
        public CountryTaxResource CreateCountryTax(CountryTaxResource taxResource)
        {
            
            string urlPath = "/tax/countries";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(taxResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateCountryTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateCountryTax: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (CountryTaxResource) KnetikClient.Deserialize(response.Content, typeof(CountryTaxResource), response.Headers);
        }
        /// <summary>
        /// Create a state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param> 
        /// <param name="taxResource">The tax object</param> 
        /// <returns>StateTaxResource</returns>            
        public StateTaxResource CreateStateTax(string countryCodeIso3, StateTaxResource taxResource)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling CreateStateTax");
            }
            
            
            string urlPath = "/tax/countries/{country_code_iso3}/states";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(taxResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateStateTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateStateTax: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (StateTaxResource) KnetikClient.Deserialize(response.Content, typeof(StateTaxResource), response.Headers);
        }
        /// <summary>
        /// Delete an existing tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param> 
        /// <returns></returns>            
        public void DeleteCountryTax(string countryCodeIso3)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling DeleteCountryTax");
            }
            
            
            string urlPath = "/tax/countries/{country_code_iso3}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteCountryTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteCountryTax: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete an existing state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param> 
        /// <param name="stateCode">The code of the state</param> 
        /// <returns></returns>            
        public void DeleteStateTax(string countryCodeIso3, string stateCode)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling DeleteStateTax");
            }
            
            // verify the required parameter 'stateCode' is set
            if (stateCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'stateCode' when calling DeleteStateTax");
            }
            
            
            string urlPath = "/tax/countries/{country_code_iso3}/states/{state_code}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
urlPath = urlPath.Replace("{" + "state_code" + "}", KnetikClient.ParameterToString(stateCode));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteStateTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteStateTax: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get a single tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param> 
        /// <returns>CountryTaxResource</returns>            
        public CountryTaxResource GetCountryTax(string countryCodeIso3)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling GetCountryTax");
            }
            
            
            string urlPath = "/tax/countries/{country_code_iso3}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCountryTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCountryTax: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (CountryTaxResource) KnetikClient.Deserialize(response.Content, typeof(CountryTaxResource), response.Headers);
        }
        /// <summary>
        /// List and search taxes Get a list of taxes
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceCountryTaxResource</returns>            
        public PageResourceCountryTaxResource GetCountryTaxes(int? size, int? page, string order)
        {
            
            string urlPath = "/tax/countries";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCountryTaxes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCountryTaxes: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceCountryTaxResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceCountryTaxResource), response.Headers);
        }
        /// <summary>
        /// Get a single state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param> 
        /// <param name="stateCode">The code of the state</param> 
        /// <returns>StateTaxResource</returns>            
        public StateTaxResource GetStateTax(string countryCodeIso3, string stateCode)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling GetStateTax");
            }
            
            // verify the required parameter 'stateCode' is set
            if (stateCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'stateCode' when calling GetStateTax");
            }
            
            
            string urlPath = "/tax/countries/{country_code_iso3}/states/{state_code}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
urlPath = urlPath.Replace("{" + "state_code" + "}", KnetikClient.ParameterToString(stateCode));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetStateTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetStateTax: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (StateTaxResource) KnetikClient.Deserialize(response.Content, typeof(StateTaxResource), response.Headers);
        }
        /// <summary>
        /// List and search taxes across all countries Get a list of taxes
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceStateTaxResource</returns>            
        public PageResourceStateTaxResource GetStateTaxesForCountries(int? size, int? page, string order)
        {
            
            string urlPath = "/tax/states";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetStateTaxesForCountries: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetStateTaxesForCountries: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceStateTaxResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceStateTaxResource), response.Headers);
        }
        /// <summary>
        /// List and search taxes within a country Get a list of taxes
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceStateTaxResource</returns>            
        public PageResourceStateTaxResource GetStateTaxesForCountry(string countryCodeIso3, int? size, int? page, string order)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling GetStateTaxesForCountry");
            }
            
            
            string urlPath = "/tax/countries/{country_code_iso3}/states";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetStateTaxesForCountry: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetStateTaxesForCountry: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceStateTaxResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceStateTaxResource), response.Headers);
        }
        /// <summary>
        /// Create or update a tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param> 
        /// <param name="taxResource">The tax object</param> 
        /// <returns>CountryTaxResource</returns>            
        public CountryTaxResource UpdateCountryTax(string countryCodeIso3, CountryTaxResource taxResource)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling UpdateCountryTax");
            }
            
            
            string urlPath = "/tax/countries/{country_code_iso3}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(taxResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateCountryTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateCountryTax: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (CountryTaxResource) KnetikClient.Deserialize(response.Content, typeof(CountryTaxResource), response.Headers);
        }
        /// <summary>
        /// Create or update a state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param> 
        /// <param name="stateCode">The code of the state</param> 
        /// <param name="taxResource">The tax object</param> 
        /// <returns>StateTaxResource</returns>            
        public StateTaxResource UpdateStateTax(string countryCodeIso3, string stateCode, StateTaxResource taxResource)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling UpdateStateTax");
            }
            
            // verify the required parameter 'stateCode' is set
            if (stateCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'stateCode' when calling UpdateStateTax");
            }
            
            
            string urlPath = "/tax/countries/{country_code_iso3}/states/{state_code}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
urlPath = urlPath.Replace("{" + "state_code" + "}", KnetikClient.ParameterToString(stateCode));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(taxResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateStateTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateStateTax: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (StateTaxResource) KnetikClient.Deserialize(response.Content, typeof(StateTaxResource), response.Headers);
        }
    }
}
