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
    public interface ITaxesApi
    {
        CountryTaxResource CreateCountryTaxData { get; }

        StateTaxResource CreateStateTaxData { get; }

        CountryTaxResource GetCountryTaxData { get; }

        PageResourceCountryTaxResource GetCountryTaxesData { get; }

        StateTaxResource GetStateTaxData { get; }

        PageResourceStateTaxResource GetStateTaxesForCountriesData { get; }

        PageResourceStateTaxResource GetStateTaxesForCountryData { get; }

        CountryTaxResource UpdateCountryTaxData { get; }

        StateTaxResource UpdateStateTaxData { get; }

        
        /// <summary>
        /// Create a country tax 
        /// </summary>
        /// <param name="taxResource">The tax object</param>
        void CreateCountryTax(CountryTaxResource taxResource);

        /// <summary>
        /// Create a state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="taxResource">The tax object</param>
        void CreateStateTax(string countryCodeIso3, StateTaxResource taxResource);

        /// <summary>
        /// Delete an existing tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        void DeleteCountryTax(string countryCodeIso3);

        /// <summary>
        /// Delete an existing state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="stateCode">The code of the state</param>
        void DeleteStateTax(string countryCodeIso3, string stateCode);

        /// <summary>
        /// Get a single tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        void GetCountryTax(string countryCodeIso3);

        /// <summary>
        /// List and search taxes Get a list of taxes
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCountryTaxes(int? size, int? page, string order);

        /// <summary>
        /// Get a single state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="stateCode">The code of the state</param>
        void GetStateTax(string countryCodeIso3, string stateCode);

        /// <summary>
        /// List and search taxes across all countries Get a list of taxes
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetStateTaxesForCountries(int? size, int? page, string order);

        /// <summary>
        /// List and search taxes within a country Get a list of taxes
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetStateTaxesForCountry(string countryCodeIso3, int? size, int? page, string order);

        /// <summary>
        /// Create or update a tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="taxResource">The tax object</param>
        void UpdateCountryTax(string countryCodeIso3, CountryTaxResource taxResource);

        /// <summary>
        /// Create or update a state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="stateCode">The code of the state</param>
        /// <param name="taxResource">The tax object</param>
        void UpdateStateTax(string countryCodeIso3, string stateCode, StateTaxResource taxResource);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TaxesApi : ITaxesApi
    {
        private readonly KnetikCoroutine mCreateCountryTaxCoroutine;
        private DateTime mCreateCountryTaxStartTime;
        private string mCreateCountryTaxPath;
        private readonly KnetikCoroutine mCreateStateTaxCoroutine;
        private DateTime mCreateStateTaxStartTime;
        private string mCreateStateTaxPath;
        private readonly KnetikCoroutine mDeleteCountryTaxCoroutine;
        private DateTime mDeleteCountryTaxStartTime;
        private string mDeleteCountryTaxPath;
        private readonly KnetikCoroutine mDeleteStateTaxCoroutine;
        private DateTime mDeleteStateTaxStartTime;
        private string mDeleteStateTaxPath;
        private readonly KnetikCoroutine mGetCountryTaxCoroutine;
        private DateTime mGetCountryTaxStartTime;
        private string mGetCountryTaxPath;
        private readonly KnetikCoroutine mGetCountryTaxesCoroutine;
        private DateTime mGetCountryTaxesStartTime;
        private string mGetCountryTaxesPath;
        private readonly KnetikCoroutine mGetStateTaxCoroutine;
        private DateTime mGetStateTaxStartTime;
        private string mGetStateTaxPath;
        private readonly KnetikCoroutine mGetStateTaxesForCountriesCoroutine;
        private DateTime mGetStateTaxesForCountriesStartTime;
        private string mGetStateTaxesForCountriesPath;
        private readonly KnetikCoroutine mGetStateTaxesForCountryCoroutine;
        private DateTime mGetStateTaxesForCountryStartTime;
        private string mGetStateTaxesForCountryPath;
        private readonly KnetikCoroutine mUpdateCountryTaxCoroutine;
        private DateTime mUpdateCountryTaxStartTime;
        private string mUpdateCountryTaxPath;
        private readonly KnetikCoroutine mUpdateStateTaxCoroutine;
        private DateTime mUpdateStateTaxStartTime;
        private string mUpdateStateTaxPath;

        public CountryTaxResource CreateCountryTaxData { get; private set; }
        public delegate void CreateCountryTaxCompleteDelegate(CountryTaxResource response);
        public CreateCountryTaxCompleteDelegate CreateCountryTaxComplete;

        public StateTaxResource CreateStateTaxData { get; private set; }
        public delegate void CreateStateTaxCompleteDelegate(StateTaxResource response);
        public CreateStateTaxCompleteDelegate CreateStateTaxComplete;

        public delegate void DeleteCountryTaxCompleteDelegate();
        public DeleteCountryTaxCompleteDelegate DeleteCountryTaxComplete;

        public delegate void DeleteStateTaxCompleteDelegate();
        public DeleteStateTaxCompleteDelegate DeleteStateTaxComplete;

        public CountryTaxResource GetCountryTaxData { get; private set; }
        public delegate void GetCountryTaxCompleteDelegate(CountryTaxResource response);
        public GetCountryTaxCompleteDelegate GetCountryTaxComplete;

        public PageResourceCountryTaxResource GetCountryTaxesData { get; private set; }
        public delegate void GetCountryTaxesCompleteDelegate(PageResourceCountryTaxResource response);
        public GetCountryTaxesCompleteDelegate GetCountryTaxesComplete;

        public StateTaxResource GetStateTaxData { get; private set; }
        public delegate void GetStateTaxCompleteDelegate(StateTaxResource response);
        public GetStateTaxCompleteDelegate GetStateTaxComplete;

        public PageResourceStateTaxResource GetStateTaxesForCountriesData { get; private set; }
        public delegate void GetStateTaxesForCountriesCompleteDelegate(PageResourceStateTaxResource response);
        public GetStateTaxesForCountriesCompleteDelegate GetStateTaxesForCountriesComplete;

        public PageResourceStateTaxResource GetStateTaxesForCountryData { get; private set; }
        public delegate void GetStateTaxesForCountryCompleteDelegate(PageResourceStateTaxResource response);
        public GetStateTaxesForCountryCompleteDelegate GetStateTaxesForCountryComplete;

        public CountryTaxResource UpdateCountryTaxData { get; private set; }
        public delegate void UpdateCountryTaxCompleteDelegate(CountryTaxResource response);
        public UpdateCountryTaxCompleteDelegate UpdateCountryTaxComplete;

        public StateTaxResource UpdateStateTaxData { get; private set; }
        public delegate void UpdateStateTaxCompleteDelegate(StateTaxResource response);
        public UpdateStateTaxCompleteDelegate UpdateStateTaxComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TaxesApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
            mCreateCountryTaxCoroutine = new KnetikCoroutine(KnetikClient);
            mCreateStateTaxCoroutine = new KnetikCoroutine(KnetikClient);
            mDeleteCountryTaxCoroutine = new KnetikCoroutine(KnetikClient);
            mDeleteStateTaxCoroutine = new KnetikCoroutine(KnetikClient);
            mGetCountryTaxCoroutine = new KnetikCoroutine(KnetikClient);
            mGetCountryTaxesCoroutine = new KnetikCoroutine(KnetikClient);
            mGetStateTaxCoroutine = new KnetikCoroutine(KnetikClient);
            mGetStateTaxesForCountriesCoroutine = new KnetikCoroutine(KnetikClient);
            mGetStateTaxesForCountryCoroutine = new KnetikCoroutine(KnetikClient);
            mUpdateCountryTaxCoroutine = new KnetikCoroutine(KnetikClient);
            mUpdateStateTaxCoroutine = new KnetikCoroutine(KnetikClient);
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient { get; private set; }

        /// <summary>
        /// Create a country tax 
        /// </summary>
        /// <param name="taxResource">The tax object</param>
        public void CreateCountryTax(CountryTaxResource taxResource)
        {
            
            mCreateCountryTaxPath = "/tax/countries";
            if (!string.IsNullOrEmpty(mCreateCountryTaxPath))
            {
                mCreateCountryTaxPath = mCreateCountryTaxPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(taxResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateCountryTaxStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateCountryTaxStartTime, mCreateCountryTaxPath, "Sending server request...");

            // make the HTTP request
            mCreateCountryTaxCoroutine.ResponseReceived += CreateCountryTaxCallback;
            mCreateCountryTaxCoroutine.Start(mCreateCountryTaxPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateCountryTaxCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCountryTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCountryTax: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateCountryTaxData = (CountryTaxResource) KnetikClient.Deserialize(response.Content, typeof(CountryTaxResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCountryTaxStartTime, mCreateCountryTaxPath, string.Format("Response received successfully:\n{0}", CreateCountryTaxData.ToString()));

            if (CreateCountryTaxComplete != null)
            {
                CreateCountryTaxComplete(CreateCountryTaxData);
            }
        }
        /// <summary>
        /// Create a state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="taxResource">The tax object</param>
        public void CreateStateTax(string countryCodeIso3, StateTaxResource taxResource)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling CreateStateTax");
            }
            
            mCreateStateTaxPath = "/tax/countries/{country_code_iso3}/states";
            if (!string.IsNullOrEmpty(mCreateStateTaxPath))
            {
                mCreateStateTaxPath = mCreateStateTaxPath.Replace("{format}", "json");
            }
            mCreateStateTaxPath = mCreateStateTaxPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(taxResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateStateTaxStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateStateTaxStartTime, mCreateStateTaxPath, "Sending server request...");

            // make the HTTP request
            mCreateStateTaxCoroutine.ResponseReceived += CreateStateTaxCallback;
            mCreateStateTaxCoroutine.Start(mCreateStateTaxPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateStateTaxCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateStateTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateStateTax: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateStateTaxData = (StateTaxResource) KnetikClient.Deserialize(response.Content, typeof(StateTaxResource), response.Headers);
            KnetikLogger.LogResponse(mCreateStateTaxStartTime, mCreateStateTaxPath, string.Format("Response received successfully:\n{0}", CreateStateTaxData.ToString()));

            if (CreateStateTaxComplete != null)
            {
                CreateStateTaxComplete(CreateStateTaxData);
            }
        }
        /// <summary>
        /// Delete an existing tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        public void DeleteCountryTax(string countryCodeIso3)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling DeleteCountryTax");
            }
            
            mDeleteCountryTaxPath = "/tax/countries/{country_code_iso3}";
            if (!string.IsNullOrEmpty(mDeleteCountryTaxPath))
            {
                mDeleteCountryTaxPath = mDeleteCountryTaxPath.Replace("{format}", "json");
            }
            mDeleteCountryTaxPath = mDeleteCountryTaxPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteCountryTaxStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteCountryTaxStartTime, mDeleteCountryTaxPath, "Sending server request...");

            // make the HTTP request
            mDeleteCountryTaxCoroutine.ResponseReceived += DeleteCountryTaxCallback;
            mDeleteCountryTaxCoroutine.Start(mDeleteCountryTaxPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteCountryTaxCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCountryTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCountryTax: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteCountryTaxStartTime, mDeleteCountryTaxPath, "Response received successfully.");
            if (DeleteCountryTaxComplete != null)
            {
                DeleteCountryTaxComplete();
            }
        }
        /// <summary>
        /// Delete an existing state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="stateCode">The code of the state</param>
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
            
            mDeleteStateTaxPath = "/tax/countries/{country_code_iso3}/states/{state_code}";
            if (!string.IsNullOrEmpty(mDeleteStateTaxPath))
            {
                mDeleteStateTaxPath = mDeleteStateTaxPath.Replace("{format}", "json");
            }
            mDeleteStateTaxPath = mDeleteStateTaxPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
mDeleteStateTaxPath = mDeleteStateTaxPath.Replace("{" + "state_code" + "}", KnetikClient.ParameterToString(stateCode));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteStateTaxStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteStateTaxStartTime, mDeleteStateTaxPath, "Sending server request...");

            // make the HTTP request
            mDeleteStateTaxCoroutine.ResponseReceived += DeleteStateTaxCallback;
            mDeleteStateTaxCoroutine.Start(mDeleteStateTaxPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteStateTaxCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteStateTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteStateTax: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteStateTaxStartTime, mDeleteStateTaxPath, "Response received successfully.");
            if (DeleteStateTaxComplete != null)
            {
                DeleteStateTaxComplete();
            }
        }
        /// <summary>
        /// Get a single tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        public void GetCountryTax(string countryCodeIso3)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling GetCountryTax");
            }
            
            mGetCountryTaxPath = "/tax/countries/{country_code_iso3}";
            if (!string.IsNullOrEmpty(mGetCountryTaxPath))
            {
                mGetCountryTaxPath = mGetCountryTaxPath.Replace("{format}", "json");
            }
            mGetCountryTaxPath = mGetCountryTaxPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetCountryTaxStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCountryTaxStartTime, mGetCountryTaxPath, "Sending server request...");

            // make the HTTP request
            mGetCountryTaxCoroutine.ResponseReceived += GetCountryTaxCallback;
            mGetCountryTaxCoroutine.Start(mGetCountryTaxPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCountryTaxCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCountryTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCountryTax: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCountryTaxData = (CountryTaxResource) KnetikClient.Deserialize(response.Content, typeof(CountryTaxResource), response.Headers);
            KnetikLogger.LogResponse(mGetCountryTaxStartTime, mGetCountryTaxPath, string.Format("Response received successfully:\n{0}", GetCountryTaxData.ToString()));

            if (GetCountryTaxComplete != null)
            {
                GetCountryTaxComplete(GetCountryTaxData);
            }
        }
        /// <summary>
        /// List and search taxes Get a list of taxes
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCountryTaxes(int? size, int? page, string order)
        {
            
            mGetCountryTaxesPath = "/tax/countries";
            if (!string.IsNullOrEmpty(mGetCountryTaxesPath))
            {
                mGetCountryTaxesPath = mGetCountryTaxesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

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
            string[] authSettings = new string[] {  };

            mGetCountryTaxesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCountryTaxesStartTime, mGetCountryTaxesPath, "Sending server request...");

            // make the HTTP request
            mGetCountryTaxesCoroutine.ResponseReceived += GetCountryTaxesCallback;
            mGetCountryTaxesCoroutine.Start(mGetCountryTaxesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCountryTaxesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCountryTaxes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCountryTaxes: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCountryTaxesData = (PageResourceCountryTaxResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceCountryTaxResource), response.Headers);
            KnetikLogger.LogResponse(mGetCountryTaxesStartTime, mGetCountryTaxesPath, string.Format("Response received successfully:\n{0}", GetCountryTaxesData.ToString()));

            if (GetCountryTaxesComplete != null)
            {
                GetCountryTaxesComplete(GetCountryTaxesData);
            }
        }
        /// <summary>
        /// Get a single state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="stateCode">The code of the state</param>
        public void GetStateTax(string countryCodeIso3, string stateCode)
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
            
            mGetStateTaxPath = "/tax/countries/{country_code_iso3}/states/{state_code}";
            if (!string.IsNullOrEmpty(mGetStateTaxPath))
            {
                mGetStateTaxPath = mGetStateTaxPath.Replace("{format}", "json");
            }
            mGetStateTaxPath = mGetStateTaxPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
mGetStateTaxPath = mGetStateTaxPath.Replace("{" + "state_code" + "}", KnetikClient.ParameterToString(stateCode));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetStateTaxStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetStateTaxStartTime, mGetStateTaxPath, "Sending server request...");

            // make the HTTP request
            mGetStateTaxCoroutine.ResponseReceived += GetStateTaxCallback;
            mGetStateTaxCoroutine.Start(mGetStateTaxPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetStateTaxCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetStateTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetStateTax: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetStateTaxData = (StateTaxResource) KnetikClient.Deserialize(response.Content, typeof(StateTaxResource), response.Headers);
            KnetikLogger.LogResponse(mGetStateTaxStartTime, mGetStateTaxPath, string.Format("Response received successfully:\n{0}", GetStateTaxData.ToString()));

            if (GetStateTaxComplete != null)
            {
                GetStateTaxComplete(GetStateTaxData);
            }
        }
        /// <summary>
        /// List and search taxes across all countries Get a list of taxes
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetStateTaxesForCountries(int? size, int? page, string order)
        {
            
            mGetStateTaxesForCountriesPath = "/tax/states";
            if (!string.IsNullOrEmpty(mGetStateTaxesForCountriesPath))
            {
                mGetStateTaxesForCountriesPath = mGetStateTaxesForCountriesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

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
            string[] authSettings = new string[] {  };

            mGetStateTaxesForCountriesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetStateTaxesForCountriesStartTime, mGetStateTaxesForCountriesPath, "Sending server request...");

            // make the HTTP request
            mGetStateTaxesForCountriesCoroutine.ResponseReceived += GetStateTaxesForCountriesCallback;
            mGetStateTaxesForCountriesCoroutine.Start(mGetStateTaxesForCountriesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetStateTaxesForCountriesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetStateTaxesForCountries: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetStateTaxesForCountries: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetStateTaxesForCountriesData = (PageResourceStateTaxResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceStateTaxResource), response.Headers);
            KnetikLogger.LogResponse(mGetStateTaxesForCountriesStartTime, mGetStateTaxesForCountriesPath, string.Format("Response received successfully:\n{0}", GetStateTaxesForCountriesData.ToString()));

            if (GetStateTaxesForCountriesComplete != null)
            {
                GetStateTaxesForCountriesComplete(GetStateTaxesForCountriesData);
            }
        }
        /// <summary>
        /// List and search taxes within a country Get a list of taxes
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetStateTaxesForCountry(string countryCodeIso3, int? size, int? page, string order)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling GetStateTaxesForCountry");
            }
            
            mGetStateTaxesForCountryPath = "/tax/countries/{country_code_iso3}/states";
            if (!string.IsNullOrEmpty(mGetStateTaxesForCountryPath))
            {
                mGetStateTaxesForCountryPath = mGetStateTaxesForCountryPath.Replace("{format}", "json");
            }
            mGetStateTaxesForCountryPath = mGetStateTaxesForCountryPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

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
            string[] authSettings = new string[] {  };

            mGetStateTaxesForCountryStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetStateTaxesForCountryStartTime, mGetStateTaxesForCountryPath, "Sending server request...");

            // make the HTTP request
            mGetStateTaxesForCountryCoroutine.ResponseReceived += GetStateTaxesForCountryCallback;
            mGetStateTaxesForCountryCoroutine.Start(mGetStateTaxesForCountryPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetStateTaxesForCountryCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetStateTaxesForCountry: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetStateTaxesForCountry: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetStateTaxesForCountryData = (PageResourceStateTaxResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceStateTaxResource), response.Headers);
            KnetikLogger.LogResponse(mGetStateTaxesForCountryStartTime, mGetStateTaxesForCountryPath, string.Format("Response received successfully:\n{0}", GetStateTaxesForCountryData.ToString()));

            if (GetStateTaxesForCountryComplete != null)
            {
                GetStateTaxesForCountryComplete(GetStateTaxesForCountryData);
            }
        }
        /// <summary>
        /// Create or update a tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="taxResource">The tax object</param>
        public void UpdateCountryTax(string countryCodeIso3, CountryTaxResource taxResource)
        {
            // verify the required parameter 'countryCodeIso3' is set
            if (countryCodeIso3 == null)
            {
                throw new KnetikException(400, "Missing required parameter 'countryCodeIso3' when calling UpdateCountryTax");
            }
            
            mUpdateCountryTaxPath = "/tax/countries/{country_code_iso3}";
            if (!string.IsNullOrEmpty(mUpdateCountryTaxPath))
            {
                mUpdateCountryTaxPath = mUpdateCountryTaxPath.Replace("{format}", "json");
            }
            mUpdateCountryTaxPath = mUpdateCountryTaxPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(taxResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateCountryTaxStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateCountryTaxStartTime, mUpdateCountryTaxPath, "Sending server request...");

            // make the HTTP request
            mUpdateCountryTaxCoroutine.ResponseReceived += UpdateCountryTaxCallback;
            mUpdateCountryTaxCoroutine.Start(mUpdateCountryTaxPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateCountryTaxCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCountryTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCountryTax: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateCountryTaxData = (CountryTaxResource) KnetikClient.Deserialize(response.Content, typeof(CountryTaxResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateCountryTaxStartTime, mUpdateCountryTaxPath, string.Format("Response received successfully:\n{0}", UpdateCountryTaxData.ToString()));

            if (UpdateCountryTaxComplete != null)
            {
                UpdateCountryTaxComplete(UpdateCountryTaxData);
            }
        }
        /// <summary>
        /// Create or update a state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="stateCode">The code of the state</param>
        /// <param name="taxResource">The tax object</param>
        public void UpdateStateTax(string countryCodeIso3, string stateCode, StateTaxResource taxResource)
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
            
            mUpdateStateTaxPath = "/tax/countries/{country_code_iso3}/states/{state_code}";
            if (!string.IsNullOrEmpty(mUpdateStateTaxPath))
            {
                mUpdateStateTaxPath = mUpdateStateTaxPath.Replace("{format}", "json");
            }
            mUpdateStateTaxPath = mUpdateStateTaxPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
mUpdateStateTaxPath = mUpdateStateTaxPath.Replace("{" + "state_code" + "}", KnetikClient.ParameterToString(stateCode));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(taxResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateStateTaxStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateStateTaxStartTime, mUpdateStateTaxPath, "Sending server request...");

            // make the HTTP request
            mUpdateStateTaxCoroutine.ResponseReceived += UpdateStateTaxCallback;
            mUpdateStateTaxCoroutine.Start(mUpdateStateTaxPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateStateTaxCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateStateTax: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateStateTax: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateStateTaxData = (StateTaxResource) KnetikClient.Deserialize(response.Content, typeof(StateTaxResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateStateTaxStartTime, mUpdateStateTaxPath, string.Format("Response received successfully:\n{0}", UpdateStateTaxData.ToString()));

            if (UpdateStateTaxComplete != null)
            {
                UpdateStateTaxComplete(UpdateStateTaxData);
            }
        }
    }
}
