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
    public interface ILocationsApi
    {
        List<CountryResource> GetCountriesData { get; }

        string GetCountryByGeoLocationData { get; }

        List<StateResource> GetCountryStatesData { get; }

        CurrencyResource GetCurrencyByGeoLocationData { get; }

        
        /// <summary>
        /// Get a list of countries 
        /// </summary>
        void GetCountries();

        /// <summary>
        /// Get the iso3 code of your country Determined by geo ip location
        /// </summary>
        void GetCountryByGeoLocation();

        /// <summary>
        /// Get a list of a country&#39;s states 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        void GetCountryStates(string countryCodeIso3);

        /// <summary>
        /// Get the currency information of your country Determined by geo ip location, currency to country mapping and a fallback setting
        /// </summary>
        void GetCurrencyByGeoLocation();

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class LocationsApi : ILocationsApi
    {
        private readonly KnetikCoroutine mGetCountriesCoroutine;
        private DateTime mGetCountriesStartTime;
        private string mGetCountriesPath;
        private readonly KnetikCoroutine mGetCountryByGeoLocationCoroutine;
        private DateTime mGetCountryByGeoLocationStartTime;
        private string mGetCountryByGeoLocationPath;
        private readonly KnetikCoroutine mGetCountryStatesCoroutine;
        private DateTime mGetCountryStatesStartTime;
        private string mGetCountryStatesPath;
        private readonly KnetikCoroutine mGetCurrencyByGeoLocationCoroutine;
        private DateTime mGetCurrencyByGeoLocationStartTime;
        private string mGetCurrencyByGeoLocationPath;

        public List<CountryResource> GetCountriesData { get; private set; }
        public delegate void GetCountriesCompleteDelegate(List<CountryResource> response);
        public GetCountriesCompleteDelegate GetCountriesComplete;

        public string GetCountryByGeoLocationData { get; private set; }
        public delegate void GetCountryByGeoLocationCompleteDelegate(string response);
        public GetCountryByGeoLocationCompleteDelegate GetCountryByGeoLocationComplete;

        public List<StateResource> GetCountryStatesData { get; private set; }
        public delegate void GetCountryStatesCompleteDelegate(List<StateResource> response);
        public GetCountryStatesCompleteDelegate GetCountryStatesComplete;

        public CurrencyResource GetCurrencyByGeoLocationData { get; private set; }
        public delegate void GetCurrencyByGeoLocationCompleteDelegate(CurrencyResource response);
        public GetCurrencyByGeoLocationCompleteDelegate GetCurrencyByGeoLocationComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LocationsApi()
        {
            mGetCountriesCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetCountryByGeoLocationCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetCountryStatesCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetCurrencyByGeoLocationCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
        /// <summary>
        /// Get a list of countries 
        /// </summary>
        public void GetCountries()
        {
            
            mGetCountriesPath = "/location/countries";
            if (!string.IsNullOrEmpty(mGetCountriesPath))
            {
                mGetCountriesPath = mGetCountriesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetCountriesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCountriesStartTime, mGetCountriesPath, "Sending server request...");

            // make the HTTP request
            mGetCountriesCoroutine.ResponseReceived += GetCountriesCallback;
            mGetCountriesCoroutine.Start(mGetCountriesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCountriesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCountries: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCountries: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCountriesData = (List<CountryResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<CountryResource>), response.Headers);
            KnetikLogger.LogResponse(mGetCountriesStartTime, mGetCountriesPath, string.Format("Response received successfully:\n{0}", GetCountriesData.ToString()));

            if (GetCountriesComplete != null)
            {
                GetCountriesComplete(GetCountriesData);
            }
        }
        /// <summary>
        /// Get the iso3 code of your country Determined by geo ip location
        /// </summary>
        public void GetCountryByGeoLocation()
        {
            
            mGetCountryByGeoLocationPath = "/location/geolocation/country";
            if (!string.IsNullOrEmpty(mGetCountryByGeoLocationPath))
            {
                mGetCountryByGeoLocationPath = mGetCountryByGeoLocationPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetCountryByGeoLocationStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCountryByGeoLocationStartTime, mGetCountryByGeoLocationPath, "Sending server request...");

            // make the HTTP request
            mGetCountryByGeoLocationCoroutine.ResponseReceived += GetCountryByGeoLocationCallback;
            mGetCountryByGeoLocationCoroutine.Start(mGetCountryByGeoLocationPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCountryByGeoLocationCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCountryByGeoLocation: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCountryByGeoLocation: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCountryByGeoLocationData = (string) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mGetCountryByGeoLocationStartTime, mGetCountryByGeoLocationPath, string.Format("Response received successfully:\n{0}", GetCountryByGeoLocationData.ToString()));

            if (GetCountryByGeoLocationComplete != null)
            {
                GetCountryByGeoLocationComplete(GetCountryByGeoLocationData);
            }
        }
        /// <summary>
        /// Get a list of a country&#39;s states 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        public void GetCountryStates(string countryCodeIso3)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling GetCountryStates");
            }
            
            mGetCountryStatesPath = "/location/countries/{country_code_iso3}/states";
            if (!string.IsNullOrEmpty(mGetCountryStatesPath))
            {
                mGetCountryStatesPath = mGetCountryStatesPath.Replace("{format}", "json");
            }
            mGetCountryStatesPath = mGetCountryStatesPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.DefaultClient.ParameterToString(countryCodeIso3));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetCountryStatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCountryStatesStartTime, mGetCountryStatesPath, "Sending server request...");

            // make the HTTP request
            mGetCountryStatesCoroutine.ResponseReceived += GetCountryStatesCallback;
            mGetCountryStatesCoroutine.Start(mGetCountryStatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCountryStatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCountryStates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCountryStates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCountryStatesData = (List<StateResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<StateResource>), response.Headers);
            KnetikLogger.LogResponse(mGetCountryStatesStartTime, mGetCountryStatesPath, string.Format("Response received successfully:\n{0}", GetCountryStatesData.ToString()));

            if (GetCountryStatesComplete != null)
            {
                GetCountryStatesComplete(GetCountryStatesData);
            }
        }
        /// <summary>
        /// Get the currency information of your country Determined by geo ip location, currency to country mapping and a fallback setting
        /// </summary>
        public void GetCurrencyByGeoLocation()
        {
            
            mGetCurrencyByGeoLocationPath = "/location/geolocation/currency";
            if (!string.IsNullOrEmpty(mGetCurrencyByGeoLocationPath))
            {
                mGetCurrencyByGeoLocationPath = mGetCurrencyByGeoLocationPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetCurrencyByGeoLocationStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCurrencyByGeoLocationStartTime, mGetCurrencyByGeoLocationPath, "Sending server request...");

            // make the HTTP request
            mGetCurrencyByGeoLocationCoroutine.ResponseReceived += GetCurrencyByGeoLocationCallback;
            mGetCurrencyByGeoLocationCoroutine.Start(mGetCurrencyByGeoLocationPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCurrencyByGeoLocationCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCurrencyByGeoLocation: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCurrencyByGeoLocation: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCurrencyByGeoLocationData = (CurrencyResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CurrencyResource), response.Headers);
            KnetikLogger.LogResponse(mGetCurrencyByGeoLocationStartTime, mGetCurrencyByGeoLocationPath, string.Format("Response received successfully:\n{0}", GetCurrencyByGeoLocationData.ToString()));

            if (GetCurrencyByGeoLocationComplete != null)
            {
                GetCurrencyByGeoLocationComplete(GetCurrencyByGeoLocationData);
            }
        }
    }
}
