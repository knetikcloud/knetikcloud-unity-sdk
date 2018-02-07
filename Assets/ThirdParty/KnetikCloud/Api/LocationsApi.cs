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
    public interface ILocationsApi
    {
        List<CountryResource> GetCountriesData { get; }

        /// <summary>
        /// Get a list of countries 
        /// </summary>
        void GetCountries();

        string GetCountryByGeoLocationData { get; }

        /// <summary>
        /// Get the iso3 code of your country Determined by geo ip location
        /// </summary>
        void GetCountryByGeoLocation();

        List<StateResource> GetCountryStatesData { get; }

        /// <summary>
        /// Get a list of a country&#39;s states 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        void GetCountryStates(string countryCodeIso3);

        CurrencyResource GetCurrencyByGeoLocationData { get; }

        /// <summary>
        /// Get the currency information of your country Determined by geo ip location, currency to country mapping and a fallback setting
        /// </summary>
        void GetCurrencyByGeoLocation();

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class LocationsApi : ILocationsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetCountriesResponseContext;
        private DateTime mGetCountriesStartTime;
        private readonly KnetikResponseContext mGetCountryByGeoLocationResponseContext;
        private DateTime mGetCountryByGeoLocationStartTime;
        private readonly KnetikResponseContext mGetCountryStatesResponseContext;
        private DateTime mGetCountryStatesStartTime;
        private readonly KnetikResponseContext mGetCurrencyByGeoLocationResponseContext;
        private DateTime mGetCurrencyByGeoLocationStartTime;

        public List<CountryResource> GetCountriesData { get; private set; }
        public delegate void GetCountriesCompleteDelegate(long responseCode, List<CountryResource> response);
        public GetCountriesCompleteDelegate GetCountriesComplete;

        public string GetCountryByGeoLocationData { get; private set; }
        public delegate void GetCountryByGeoLocationCompleteDelegate(long responseCode, string response);
        public GetCountryByGeoLocationCompleteDelegate GetCountryByGeoLocationComplete;

        public List<StateResource> GetCountryStatesData { get; private set; }
        public delegate void GetCountryStatesCompleteDelegate(long responseCode, List<StateResource> response);
        public GetCountryStatesCompleteDelegate GetCountryStatesComplete;

        public CurrencyResource GetCurrencyByGeoLocationData { get; private set; }
        public delegate void GetCurrencyByGeoLocationCompleteDelegate(long responseCode, CurrencyResource response);
        public GetCurrencyByGeoLocationCompleteDelegate GetCurrencyByGeoLocationComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LocationsApi()
        {
            mGetCountriesResponseContext = new KnetikResponseContext();
            mGetCountriesResponseContext.ResponseReceived += OnGetCountriesResponse;
            mGetCountryByGeoLocationResponseContext = new KnetikResponseContext();
            mGetCountryByGeoLocationResponseContext.ResponseReceived += OnGetCountryByGeoLocationResponse;
            mGetCountryStatesResponseContext = new KnetikResponseContext();
            mGetCountryStatesResponseContext.ResponseReceived += OnGetCountryStatesResponse;
            mGetCurrencyByGeoLocationResponseContext = new KnetikResponseContext();
            mGetCurrencyByGeoLocationResponseContext.ResponseReceived += OnGetCurrencyByGeoLocationResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get a list of countries 
        /// </summary>
        public void GetCountries()
        {
            
            mWebCallEvent.WebPath = "/location/countries";
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
            mGetCountriesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCountriesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCountriesStartTime, "GetCountries", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCountriesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCountries: " + response.Error);
            }

            GetCountriesData = (List<CountryResource>) KnetikClient.Deserialize(response.Content, typeof(List<CountryResource>), response.Headers);
            KnetikLogger.LogResponse(mGetCountriesStartTime, "GetCountries", string.Format("Response received successfully:\n{0}", GetCountriesData));

            if (GetCountriesComplete != null)
            {
                GetCountriesComplete(response.ResponseCode, GetCountriesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get the iso3 code of your country Determined by geo ip location
        /// </summary>
        public void GetCountryByGeoLocation()
        {
            
            mWebCallEvent.WebPath = "/location/geolocation/country";
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
            mGetCountryByGeoLocationStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCountryByGeoLocationResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCountryByGeoLocationStartTime, "GetCountryByGeoLocation", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCountryByGeoLocationResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCountryByGeoLocation: " + response.Error);
            }

            GetCountryByGeoLocationData = (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mGetCountryByGeoLocationStartTime, "GetCountryByGeoLocation", string.Format("Response received successfully:\n{0}", GetCountryByGeoLocationData));

            if (GetCountryByGeoLocationComplete != null)
            {
                GetCountryByGeoLocationComplete(response.ResponseCode, GetCountryByGeoLocationData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/location/countries/{country_code_iso3}/states";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetCountryStatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCountryStatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCountryStatesStartTime, "GetCountryStates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCountryStatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCountryStates: " + response.Error);
            }

            GetCountryStatesData = (List<StateResource>) KnetikClient.Deserialize(response.Content, typeof(List<StateResource>), response.Headers);
            KnetikLogger.LogResponse(mGetCountryStatesStartTime, "GetCountryStates", string.Format("Response received successfully:\n{0}", GetCountryStatesData));

            if (GetCountryStatesComplete != null)
            {
                GetCountryStatesComplete(response.ResponseCode, GetCountryStatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get the currency information of your country Determined by geo ip location, currency to country mapping and a fallback setting
        /// </summary>
        public void GetCurrencyByGeoLocation()
        {
            
            mWebCallEvent.WebPath = "/location/geolocation/currency";
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
            mGetCurrencyByGeoLocationStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCurrencyByGeoLocationResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCurrencyByGeoLocationStartTime, "GetCurrencyByGeoLocation", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCurrencyByGeoLocationResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCurrencyByGeoLocation: " + response.Error);
            }

            GetCurrencyByGeoLocationData = (CurrencyResource) KnetikClient.Deserialize(response.Content, typeof(CurrencyResource), response.Headers);
            KnetikLogger.LogResponse(mGetCurrencyByGeoLocationStartTime, "GetCurrencyByGeoLocation", string.Format("Response received successfully:\n{0}", GetCurrencyByGeoLocationData));

            if (GetCurrencyByGeoLocationComplete != null)
            {
                GetCurrencyByGeoLocationComplete(response.ResponseCode, GetCurrencyByGeoLocationData);
            }
        }

    }
}
