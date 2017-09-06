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
    public interface ILocationsApi
    {
        /// <summary>
        /// Get a list of countries 
        /// </summary>
        /// <returns>List&lt;CountryResource&gt;</returns>
        List<CountryResource> GetCountries ();
        /// <summary>
        /// Get the iso3 code of your country Determined by geo ip location
        /// </summary>
        /// <returns>string</returns>
        string GetCountryByGeoLocation ();
        /// <summary>
        /// Get a list of a country&#39;s states 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <returns>List&lt;StateResource&gt;</returns>
        List<StateResource> GetCountryStates (string countryCodeIso3);
        /// <summary>
        /// Get the currency information of your country Determined by geo ip location, currency to country mapping and a fallback setting
        /// </summary>
        /// <returns>CurrencyResource</returns>
        CurrencyResource GetCurrencyByGeoLocation ();
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class LocationsApi : ILocationsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LocationsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Get a list of countries 
        /// </summary>
        /// <returns>List&lt;CountryResource&gt;</returns>            
        public List<CountryResource> GetCountries()
        {
            
            string urlPath = "/location/countries";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCountries: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCountries: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<CountryResource>) KnetikClient.Deserialize(response.Content, typeof(List<CountryResource>), response.Headers);
        }
        /// <summary>
        /// Get the iso3 code of your country Determined by geo ip location
        /// </summary>
        /// <returns>string</returns>            
        public string GetCountryByGeoLocation()
        {
            
            string urlPath = "/location/geolocation/country";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCountryByGeoLocation: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCountryByGeoLocation: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
        }
        /// <summary>
        /// Get a list of a country&#39;s states 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param> 
        /// <returns>List&lt;StateResource&gt;</returns>            
        public List<StateResource> GetCountryStates(string countryCodeIso3)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling GetCountryStates");
            }
            
            
            string urlPath = "/location/countries/{country_code_iso3}/states";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCountryStates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCountryStates: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<StateResource>) KnetikClient.Deserialize(response.Content, typeof(List<StateResource>), response.Headers);
        }
        /// <summary>
        /// Get the currency information of your country Determined by geo ip location, currency to country mapping and a fallback setting
        /// </summary>
        /// <returns>CurrencyResource</returns>            
        public CurrencyResource GetCurrencyByGeoLocation()
        {
            
            string urlPath = "/location/geolocation/currency";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCurrencyByGeoLocation: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetCurrencyByGeoLocation: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (CurrencyResource) KnetikClient.Deserialize(response.Content, typeof(CurrencyResource), response.Headers);
        }
    }
}
