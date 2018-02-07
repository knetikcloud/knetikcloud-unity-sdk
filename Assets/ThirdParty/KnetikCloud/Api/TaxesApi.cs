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
    public interface ITaxesApi
    {
        CountryTaxResource CreateCountryTaxData { get; }

        /// <summary>
        /// Create a country tax 
        /// </summary>
        /// <param name="taxResource">The tax object</param>
        void CreateCountryTax(CountryTaxResource taxResource);

        StateTaxResource CreateStateTaxData { get; }

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

        CountryTaxResource GetCountryTaxData { get; }

        /// <summary>
        /// Get a single tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        void GetCountryTax(string countryCodeIso3);

        PageResourceCountryTaxResource GetCountryTaxesData { get; }

        /// <summary>
        /// List and search taxes Get a list of taxes
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCountryTaxes(int? size, int? page, string order);

        StateTaxResource GetStateTaxData { get; }

        /// <summary>
        /// Get a single state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="stateCode">The code of the state</param>
        void GetStateTax(string countryCodeIso3, string stateCode);

        PageResourceStateTaxResource GetStateTaxesForCountriesData { get; }

        /// <summary>
        /// List and search taxes across all countries Get a list of taxes
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetStateTaxesForCountries(int? size, int? page, string order);

        PageResourceStateTaxResource GetStateTaxesForCountryData { get; }

        /// <summary>
        /// List and search taxes within a country Get a list of taxes
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetStateTaxesForCountry(string countryCodeIso3, int? size, int? page, string order);

        CountryTaxResource UpdateCountryTaxData { get; }

        /// <summary>
        /// Create or update a tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="taxResource">The tax object</param>
        void UpdateCountryTax(string countryCodeIso3, CountryTaxResource taxResource);

        StateTaxResource UpdateStateTaxData { get; }

        /// <summary>
        /// Create or update a state tax 
        /// </summary>
        /// <param name="countryCodeIso3">The iso3 code of the country</param>
        /// <param name="stateCode">The code of the state</param>
        /// <param name="taxResource">The tax object</param>
        void UpdateStateTax(string countryCodeIso3, string stateCode, StateTaxResource taxResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TaxesApi : ITaxesApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateCountryTaxResponseContext;
        private DateTime mCreateCountryTaxStartTime;
        private readonly KnetikResponseContext mCreateStateTaxResponseContext;
        private DateTime mCreateStateTaxStartTime;
        private readonly KnetikResponseContext mDeleteCountryTaxResponseContext;
        private DateTime mDeleteCountryTaxStartTime;
        private readonly KnetikResponseContext mDeleteStateTaxResponseContext;
        private DateTime mDeleteStateTaxStartTime;
        private readonly KnetikResponseContext mGetCountryTaxResponseContext;
        private DateTime mGetCountryTaxStartTime;
        private readonly KnetikResponseContext mGetCountryTaxesResponseContext;
        private DateTime mGetCountryTaxesStartTime;
        private readonly KnetikResponseContext mGetStateTaxResponseContext;
        private DateTime mGetStateTaxStartTime;
        private readonly KnetikResponseContext mGetStateTaxesForCountriesResponseContext;
        private DateTime mGetStateTaxesForCountriesStartTime;
        private readonly KnetikResponseContext mGetStateTaxesForCountryResponseContext;
        private DateTime mGetStateTaxesForCountryStartTime;
        private readonly KnetikResponseContext mUpdateCountryTaxResponseContext;
        private DateTime mUpdateCountryTaxStartTime;
        private readonly KnetikResponseContext mUpdateStateTaxResponseContext;
        private DateTime mUpdateStateTaxStartTime;

        public CountryTaxResource CreateCountryTaxData { get; private set; }
        public delegate void CreateCountryTaxCompleteDelegate(long responseCode, CountryTaxResource response);
        public CreateCountryTaxCompleteDelegate CreateCountryTaxComplete;

        public StateTaxResource CreateStateTaxData { get; private set; }
        public delegate void CreateStateTaxCompleteDelegate(long responseCode, StateTaxResource response);
        public CreateStateTaxCompleteDelegate CreateStateTaxComplete;

        public delegate void DeleteCountryTaxCompleteDelegate(long responseCode);
        public DeleteCountryTaxCompleteDelegate DeleteCountryTaxComplete;

        public delegate void DeleteStateTaxCompleteDelegate(long responseCode);
        public DeleteStateTaxCompleteDelegate DeleteStateTaxComplete;

        public CountryTaxResource GetCountryTaxData { get; private set; }
        public delegate void GetCountryTaxCompleteDelegate(long responseCode, CountryTaxResource response);
        public GetCountryTaxCompleteDelegate GetCountryTaxComplete;

        public PageResourceCountryTaxResource GetCountryTaxesData { get; private set; }
        public delegate void GetCountryTaxesCompleteDelegate(long responseCode, PageResourceCountryTaxResource response);
        public GetCountryTaxesCompleteDelegate GetCountryTaxesComplete;

        public StateTaxResource GetStateTaxData { get; private set; }
        public delegate void GetStateTaxCompleteDelegate(long responseCode, StateTaxResource response);
        public GetStateTaxCompleteDelegate GetStateTaxComplete;

        public PageResourceStateTaxResource GetStateTaxesForCountriesData { get; private set; }
        public delegate void GetStateTaxesForCountriesCompleteDelegate(long responseCode, PageResourceStateTaxResource response);
        public GetStateTaxesForCountriesCompleteDelegate GetStateTaxesForCountriesComplete;

        public PageResourceStateTaxResource GetStateTaxesForCountryData { get; private set; }
        public delegate void GetStateTaxesForCountryCompleteDelegate(long responseCode, PageResourceStateTaxResource response);
        public GetStateTaxesForCountryCompleteDelegate GetStateTaxesForCountryComplete;

        public CountryTaxResource UpdateCountryTaxData { get; private set; }
        public delegate void UpdateCountryTaxCompleteDelegate(long responseCode, CountryTaxResource response);
        public UpdateCountryTaxCompleteDelegate UpdateCountryTaxComplete;

        public StateTaxResource UpdateStateTaxData { get; private set; }
        public delegate void UpdateStateTaxCompleteDelegate(long responseCode, StateTaxResource response);
        public UpdateStateTaxCompleteDelegate UpdateStateTaxComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TaxesApi()
        {
            mCreateCountryTaxResponseContext = new KnetikResponseContext();
            mCreateCountryTaxResponseContext.ResponseReceived += OnCreateCountryTaxResponse;
            mCreateStateTaxResponseContext = new KnetikResponseContext();
            mCreateStateTaxResponseContext.ResponseReceived += OnCreateStateTaxResponse;
            mDeleteCountryTaxResponseContext = new KnetikResponseContext();
            mDeleteCountryTaxResponseContext.ResponseReceived += OnDeleteCountryTaxResponse;
            mDeleteStateTaxResponseContext = new KnetikResponseContext();
            mDeleteStateTaxResponseContext.ResponseReceived += OnDeleteStateTaxResponse;
            mGetCountryTaxResponseContext = new KnetikResponseContext();
            mGetCountryTaxResponseContext.ResponseReceived += OnGetCountryTaxResponse;
            mGetCountryTaxesResponseContext = new KnetikResponseContext();
            mGetCountryTaxesResponseContext.ResponseReceived += OnGetCountryTaxesResponse;
            mGetStateTaxResponseContext = new KnetikResponseContext();
            mGetStateTaxResponseContext.ResponseReceived += OnGetStateTaxResponse;
            mGetStateTaxesForCountriesResponseContext = new KnetikResponseContext();
            mGetStateTaxesForCountriesResponseContext.ResponseReceived += OnGetStateTaxesForCountriesResponse;
            mGetStateTaxesForCountryResponseContext = new KnetikResponseContext();
            mGetStateTaxesForCountryResponseContext.ResponseReceived += OnGetStateTaxesForCountryResponse;
            mUpdateCountryTaxResponseContext = new KnetikResponseContext();
            mUpdateCountryTaxResponseContext.ResponseReceived += OnUpdateCountryTaxResponse;
            mUpdateStateTaxResponseContext = new KnetikResponseContext();
            mUpdateStateTaxResponseContext.ResponseReceived += OnUpdateStateTaxResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a country tax 
        /// </summary>
        /// <param name="taxResource">The tax object</param>
        public void CreateCountryTax(CountryTaxResource taxResource)
        {
            
            mWebCallEvent.WebPath = "/tax/countries";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(taxResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateCountryTaxStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateCountryTaxResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateCountryTaxStartTime, "CreateCountryTax", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateCountryTaxResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateCountryTax: " + response.Error);
            }

            CreateCountryTaxData = (CountryTaxResource) KnetikClient.Deserialize(response.Content, typeof(CountryTaxResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCountryTaxStartTime, "CreateCountryTax", string.Format("Response received successfully:\n{0}", CreateCountryTaxData));

            if (CreateCountryTaxComplete != null)
            {
                CreateCountryTaxComplete(response.ResponseCode, CreateCountryTaxData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/tax/countries/{country_code_iso3}/states";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(taxResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateStateTaxStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateStateTaxResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateStateTaxStartTime, "CreateStateTax", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateStateTaxResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateStateTax: " + response.Error);
            }

            CreateStateTaxData = (StateTaxResource) KnetikClient.Deserialize(response.Content, typeof(StateTaxResource), response.Headers);
            KnetikLogger.LogResponse(mCreateStateTaxStartTime, "CreateStateTax", string.Format("Response received successfully:\n{0}", CreateStateTaxData));

            if (CreateStateTaxComplete != null)
            {
                CreateStateTaxComplete(response.ResponseCode, CreateStateTaxData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/tax/countries/{country_code_iso3}";
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
            mDeleteCountryTaxStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteCountryTaxResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteCountryTaxStartTime, "DeleteCountryTax", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteCountryTaxResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteCountryTax: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteCountryTaxStartTime, "DeleteCountryTax", "Response received successfully.");
            if (DeleteCountryTaxComplete != null)
            {
                DeleteCountryTaxComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/tax/countries/{country_code_iso3}/states/{state_code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "state_code" + "}", KnetikClient.ParameterToString(stateCode));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteStateTaxStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteStateTaxResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteStateTaxStartTime, "DeleteStateTax", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteStateTaxResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteStateTax: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteStateTaxStartTime, "DeleteStateTax", "Response received successfully.");
            if (DeleteStateTaxComplete != null)
            {
                DeleteStateTaxComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/tax/countries/{country_code_iso3}";
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
            mGetCountryTaxStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCountryTaxResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCountryTaxStartTime, "GetCountryTax", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCountryTaxResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCountryTax: " + response.Error);
            }

            GetCountryTaxData = (CountryTaxResource) KnetikClient.Deserialize(response.Content, typeof(CountryTaxResource), response.Headers);
            KnetikLogger.LogResponse(mGetCountryTaxStartTime, "GetCountryTax", string.Format("Response received successfully:\n{0}", GetCountryTaxData));

            if (GetCountryTaxComplete != null)
            {
                GetCountryTaxComplete(response.ResponseCode, GetCountryTaxData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search taxes Get a list of taxes
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCountryTaxes(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/tax/countries";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (order != null)
            {
                mWebCallEvent.QueryParams["order"] = KnetikClient.ParameterToString(order);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetCountryTaxesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCountryTaxesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCountryTaxesStartTime, "GetCountryTaxes", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCountryTaxesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCountryTaxes: " + response.Error);
            }

            GetCountryTaxesData = (PageResourceCountryTaxResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceCountryTaxResource), response.Headers);
            KnetikLogger.LogResponse(mGetCountryTaxesStartTime, "GetCountryTaxes", string.Format("Response received successfully:\n{0}", GetCountryTaxesData));

            if (GetCountryTaxesComplete != null)
            {
                GetCountryTaxesComplete(response.ResponseCode, GetCountryTaxesData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/tax/countries/{country_code_iso3}/states/{state_code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "state_code" + "}", KnetikClient.ParameterToString(stateCode));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetStateTaxStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetStateTaxResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetStateTaxStartTime, "GetStateTax", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetStateTaxResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetStateTax: " + response.Error);
            }

            GetStateTaxData = (StateTaxResource) KnetikClient.Deserialize(response.Content, typeof(StateTaxResource), response.Headers);
            KnetikLogger.LogResponse(mGetStateTaxStartTime, "GetStateTax", string.Format("Response received successfully:\n{0}", GetStateTaxData));

            if (GetStateTaxComplete != null)
            {
                GetStateTaxComplete(response.ResponseCode, GetStateTaxData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search taxes across all countries Get a list of taxes
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetStateTaxesForCountries(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/tax/states";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (order != null)
            {
                mWebCallEvent.QueryParams["order"] = KnetikClient.ParameterToString(order);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetStateTaxesForCountriesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetStateTaxesForCountriesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetStateTaxesForCountriesStartTime, "GetStateTaxesForCountries", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetStateTaxesForCountriesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetStateTaxesForCountries: " + response.Error);
            }

            GetStateTaxesForCountriesData = (PageResourceStateTaxResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceStateTaxResource), response.Headers);
            KnetikLogger.LogResponse(mGetStateTaxesForCountriesStartTime, "GetStateTaxesForCountries", string.Format("Response received successfully:\n{0}", GetStateTaxesForCountriesData));

            if (GetStateTaxesForCountriesComplete != null)
            {
                GetStateTaxesForCountriesComplete(response.ResponseCode, GetStateTaxesForCountriesData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/tax/countries/{country_code_iso3}/states";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (order != null)
            {
                mWebCallEvent.QueryParams["order"] = KnetikClient.ParameterToString(order);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetStateTaxesForCountryStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetStateTaxesForCountryResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetStateTaxesForCountryStartTime, "GetStateTaxesForCountry", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetStateTaxesForCountryResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetStateTaxesForCountry: " + response.Error);
            }

            GetStateTaxesForCountryData = (PageResourceStateTaxResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceStateTaxResource), response.Headers);
            KnetikLogger.LogResponse(mGetStateTaxesForCountryStartTime, "GetStateTaxesForCountry", string.Format("Response received successfully:\n{0}", GetStateTaxesForCountryData));

            if (GetStateTaxesForCountryComplete != null)
            {
                GetStateTaxesForCountryComplete(response.ResponseCode, GetStateTaxesForCountryData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/tax/countries/{country_code_iso3}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(taxResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateCountryTaxStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateCountryTaxResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateCountryTaxStartTime, "UpdateCountryTax", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateCountryTaxResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateCountryTax: " + response.Error);
            }

            UpdateCountryTaxData = (CountryTaxResource) KnetikClient.Deserialize(response.Content, typeof(CountryTaxResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateCountryTaxStartTime, "UpdateCountryTax", string.Format("Response received successfully:\n{0}", UpdateCountryTaxData));

            if (UpdateCountryTaxComplete != null)
            {
                UpdateCountryTaxComplete(response.ResponseCode, UpdateCountryTaxData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/tax/countries/{country_code_iso3}/states/{state_code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "country_code_iso3" + "}", KnetikClient.ParameterToString(countryCodeIso3));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "state_code" + "}", KnetikClient.ParameterToString(stateCode));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(taxResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateStateTaxStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateStateTaxResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateStateTaxStartTime, "UpdateStateTax", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateStateTaxResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateStateTax: " + response.Error);
            }

            UpdateStateTaxData = (StateTaxResource) KnetikClient.Deserialize(response.Content, typeof(StateTaxResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateStateTaxStartTime, "UpdateStateTax", string.Format("Response received successfully:\n{0}", UpdateStateTaxData));

            if (UpdateStateTaxComplete != null)
            {
                UpdateStateTaxComplete(response.ResponseCode, UpdateStateTaxData);
            }
        }

    }
}
