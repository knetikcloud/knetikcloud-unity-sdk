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
    public interface ICurrenciesApi
    {
        CurrencyResource CreateCurrencyData { get; }

        /// <summary>
        /// Create a currency &lt;b&gt;Permissions Needed:&lt;/b&gt; CURRENCIES_ADMIN
        /// </summary>
        /// <param name="currency">The currency object</param>
        void CreateCurrency(CurrencyResource currency);

        

        /// <summary>
        /// Delete a currency &lt;b&gt;Permissions Needed:&lt;/b&gt; CURRENCIES_ADMIN
        /// </summary>
        /// <param name="code">The currency code</param>
        void DeleteCurrency(string code);

        PageResourceCurrencyResource GetCurrenciesData { get; }

        /// <summary>
        /// List and search currencies &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterDefault">Filter for the one currency that is set as default (true), or all that are not (false)</param>
        /// <param name="filterEnabledCurrencies">Filter for alternate currencies setup explicitely in system config</param>
        /// <param name="filterType">Filter currencies by type.  Allowable values: (&#39;virtual&#39;, &#39;real&#39;)</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCurrencies(bool? filterDefault, bool? filterEnabledCurrencies, string filterType, int? size, int? page, string order);

        CurrencyResource GetCurrencyData { get; }

        /// <summary>
        /// Get a single currency &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="code">The currency code</param>
        void GetCurrency(string code);

        

        /// <summary>
        /// Update a currency &lt;b&gt;Permissions Needed:&lt;/b&gt; CURRENCIES_ADMIN
        /// </summary>
        /// <param name="code">The currency code</param>
        /// <param name="currency">The currency object</param>
        void UpdateCurrency(string code, CurrencyResource currency);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class CurrenciesApi : ICurrenciesApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateCurrencyResponseContext;
        private DateTime mCreateCurrencyStartTime;
        private readonly KnetikResponseContext mDeleteCurrencyResponseContext;
        private DateTime mDeleteCurrencyStartTime;
        private readonly KnetikResponseContext mGetCurrenciesResponseContext;
        private DateTime mGetCurrenciesStartTime;
        private readonly KnetikResponseContext mGetCurrencyResponseContext;
        private DateTime mGetCurrencyStartTime;
        private readonly KnetikResponseContext mUpdateCurrencyResponseContext;
        private DateTime mUpdateCurrencyStartTime;

        public CurrencyResource CreateCurrencyData { get; private set; }
        public delegate void CreateCurrencyCompleteDelegate(long responseCode, CurrencyResource response);
        public CreateCurrencyCompleteDelegate CreateCurrencyComplete;

        public delegate void DeleteCurrencyCompleteDelegate(long responseCode);
        public DeleteCurrencyCompleteDelegate DeleteCurrencyComplete;

        public PageResourceCurrencyResource GetCurrenciesData { get; private set; }
        public delegate void GetCurrenciesCompleteDelegate(long responseCode, PageResourceCurrencyResource response);
        public GetCurrenciesCompleteDelegate GetCurrenciesComplete;

        public CurrencyResource GetCurrencyData { get; private set; }
        public delegate void GetCurrencyCompleteDelegate(long responseCode, CurrencyResource response);
        public GetCurrencyCompleteDelegate GetCurrencyComplete;

        public delegate void UpdateCurrencyCompleteDelegate(long responseCode);
        public UpdateCurrencyCompleteDelegate UpdateCurrencyComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrenciesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CurrenciesApi()
        {
            mCreateCurrencyResponseContext = new KnetikResponseContext();
            mCreateCurrencyResponseContext.ResponseReceived += OnCreateCurrencyResponse;
            mDeleteCurrencyResponseContext = new KnetikResponseContext();
            mDeleteCurrencyResponseContext.ResponseReceived += OnDeleteCurrencyResponse;
            mGetCurrenciesResponseContext = new KnetikResponseContext();
            mGetCurrenciesResponseContext.ResponseReceived += OnGetCurrenciesResponse;
            mGetCurrencyResponseContext = new KnetikResponseContext();
            mGetCurrencyResponseContext.ResponseReceived += OnGetCurrencyResponse;
            mUpdateCurrencyResponseContext = new KnetikResponseContext();
            mUpdateCurrencyResponseContext.ResponseReceived += OnUpdateCurrencyResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a currency &lt;b&gt;Permissions Needed:&lt;/b&gt; CURRENCIES_ADMIN
        /// </summary>
        /// <param name="currency">The currency object</param>
        public void CreateCurrency(CurrencyResource currency)
        {
            
            mWebCallEvent.WebPath = "/currencies";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(currency); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateCurrencyStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateCurrencyResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateCurrencyStartTime, "CreateCurrency", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateCurrencyResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateCurrency: " + response.Error);
            }

            CreateCurrencyData = (CurrencyResource) KnetikClient.Deserialize(response.Content, typeof(CurrencyResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCurrencyStartTime, "CreateCurrency", string.Format("Response received successfully:\n{0}", CreateCurrencyData));

            if (CreateCurrencyComplete != null)
            {
                CreateCurrencyComplete(response.ResponseCode, CreateCurrencyData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a currency &lt;b&gt;Permissions Needed:&lt;/b&gt; CURRENCIES_ADMIN
        /// </summary>
        /// <param name="code">The currency code</param>
        public void DeleteCurrency(string code)
        {
            // verify the required parameter 'code' is set
            if (code == null)
            {
                throw new KnetikException(400, "Missing required parameter 'code' when calling DeleteCurrency");
            }
            
            mWebCallEvent.WebPath = "/currencies/{code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "code" + "}", KnetikClient.ParameterToString(code));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteCurrencyStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteCurrencyResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteCurrencyStartTime, "DeleteCurrency", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteCurrencyResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteCurrency: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteCurrencyStartTime, "DeleteCurrency", "Response received successfully.");
            if (DeleteCurrencyComplete != null)
            {
                DeleteCurrencyComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search currencies &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterDefault">Filter for the one currency that is set as default (true), or all that are not (false)</param>
        /// <param name="filterEnabledCurrencies">Filter for alternate currencies setup explicitely in system config</param>
        /// <param name="filterType">Filter currencies by type.  Allowable values: (&#39;virtual&#39;, &#39;real&#39;)</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCurrencies(bool? filterDefault, bool? filterEnabledCurrencies, string filterType, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/currencies";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterDefault != null)
            {
                mWebCallEvent.QueryParams["filter_default"] = KnetikClient.ParameterToString(filterDefault);
            }

            if (filterEnabledCurrencies != null)
            {
                mWebCallEvent.QueryParams["filter_enabled_currencies"] = KnetikClient.ParameterToString(filterEnabledCurrencies);
            }

            if (filterType != null)
            {
                mWebCallEvent.QueryParams["filter_type"] = KnetikClient.ParameterToString(filterType);
            }

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
            mGetCurrenciesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCurrenciesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCurrenciesStartTime, "GetCurrencies", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCurrenciesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCurrencies: " + response.Error);
            }

            GetCurrenciesData = (PageResourceCurrencyResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceCurrencyResource), response.Headers);
            KnetikLogger.LogResponse(mGetCurrenciesStartTime, "GetCurrencies", string.Format("Response received successfully:\n{0}", GetCurrenciesData));

            if (GetCurrenciesComplete != null)
            {
                GetCurrenciesComplete(response.ResponseCode, GetCurrenciesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single currency &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="code">The currency code</param>
        public void GetCurrency(string code)
        {
            // verify the required parameter 'code' is set
            if (code == null)
            {
                throw new KnetikException(400, "Missing required parameter 'code' when calling GetCurrency");
            }
            
            mWebCallEvent.WebPath = "/currencies/{code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "code" + "}", KnetikClient.ParameterToString(code));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetCurrencyStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCurrencyResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCurrencyStartTime, "GetCurrency", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCurrencyResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCurrency: " + response.Error);
            }

            GetCurrencyData = (CurrencyResource) KnetikClient.Deserialize(response.Content, typeof(CurrencyResource), response.Headers);
            KnetikLogger.LogResponse(mGetCurrencyStartTime, "GetCurrency", string.Format("Response received successfully:\n{0}", GetCurrencyData));

            if (GetCurrencyComplete != null)
            {
                GetCurrencyComplete(response.ResponseCode, GetCurrencyData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a currency &lt;b&gt;Permissions Needed:&lt;/b&gt; CURRENCIES_ADMIN
        /// </summary>
        /// <param name="code">The currency code</param>
        /// <param name="currency">The currency object</param>
        public void UpdateCurrency(string code, CurrencyResource currency)
        {
            // verify the required parameter 'code' is set
            if (code == null)
            {
                throw new KnetikException(400, "Missing required parameter 'code' when calling UpdateCurrency");
            }
            
            mWebCallEvent.WebPath = "/currencies/{code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "code" + "}", KnetikClient.ParameterToString(code));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(currency); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateCurrencyStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateCurrencyResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateCurrencyStartTime, "UpdateCurrency", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateCurrencyResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateCurrency: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateCurrencyStartTime, "UpdateCurrency", "Response received successfully.");
            if (UpdateCurrencyComplete != null)
            {
                UpdateCurrencyComplete(response.ResponseCode);
            }
        }

    }
}
