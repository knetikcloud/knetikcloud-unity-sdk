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
    public interface ICurrenciesApi
    {
        CurrencyResource CreateCurrencyData { get; }

        PageResourceCurrencyResource GetCurrenciesData { get; }

        CurrencyResource GetCurrencyData { get; }

        
        /// <summary>
        /// Create a currency 
        /// </summary>
        /// <param name="currency">The currency object</param>
        void CreateCurrency(CurrencyResource currency);

        /// <summary>
        /// Delete a currency 
        /// </summary>
        /// <param name="code">The currency code</param>
        void DeleteCurrency(string code);

        /// <summary>
        /// List and search currencies 
        /// </summary>
        /// <param name="filterEnabledCurrencies">Filter for alternate currencies setup explicitely in system config</param>
        /// <param name="filterType">Filter currencies by type.  Allowable values: (&#39;virtual&#39;, &#39;real&#39;)</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCurrencies(bool? filterEnabledCurrencies, string filterType, int? size, int? page, string order);

        /// <summary>
        /// Get a single currency 
        /// </summary>
        /// <param name="code">The currency code</param>
        void GetCurrency(string code);

        /// <summary>
        /// Update a currency 
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
        private readonly KnetikCoroutine mCreateCurrencyCoroutine;
        private DateTime mCreateCurrencyStartTime;
        private string mCreateCurrencyPath;
        private readonly KnetikCoroutine mDeleteCurrencyCoroutine;
        private DateTime mDeleteCurrencyStartTime;
        private string mDeleteCurrencyPath;
        private readonly KnetikCoroutine mGetCurrenciesCoroutine;
        private DateTime mGetCurrenciesStartTime;
        private string mGetCurrenciesPath;
        private readonly KnetikCoroutine mGetCurrencyCoroutine;
        private DateTime mGetCurrencyStartTime;
        private string mGetCurrencyPath;
        private readonly KnetikCoroutine mUpdateCurrencyCoroutine;
        private DateTime mUpdateCurrencyStartTime;
        private string mUpdateCurrencyPath;

        public CurrencyResource CreateCurrencyData { get; private set; }
        public delegate void CreateCurrencyCompleteDelegate(CurrencyResource response);
        public CreateCurrencyCompleteDelegate CreateCurrencyComplete;

        public delegate void DeleteCurrencyCompleteDelegate();
        public DeleteCurrencyCompleteDelegate DeleteCurrencyComplete;

        public PageResourceCurrencyResource GetCurrenciesData { get; private set; }
        public delegate void GetCurrenciesCompleteDelegate(PageResourceCurrencyResource response);
        public GetCurrenciesCompleteDelegate GetCurrenciesComplete;

        public CurrencyResource GetCurrencyData { get; private set; }
        public delegate void GetCurrencyCompleteDelegate(CurrencyResource response);
        public GetCurrencyCompleteDelegate GetCurrencyComplete;

        public delegate void UpdateCurrencyCompleteDelegate();
        public UpdateCurrencyCompleteDelegate UpdateCurrencyComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrenciesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CurrenciesApi()
        {
            mCreateCurrencyCoroutine = new KnetikCoroutine();
            mDeleteCurrencyCoroutine = new KnetikCoroutine();
            mGetCurrenciesCoroutine = new KnetikCoroutine();
            mGetCurrencyCoroutine = new KnetikCoroutine();
            mUpdateCurrencyCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a currency 
        /// </summary>
        /// <param name="currency">The currency object</param>
        public void CreateCurrency(CurrencyResource currency)
        {
            
            mCreateCurrencyPath = "/currencies";
            if (!string.IsNullOrEmpty(mCreateCurrencyPath))
            {
                mCreateCurrencyPath = mCreateCurrencyPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(currency); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateCurrencyStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateCurrencyStartTime, mCreateCurrencyPath, "Sending server request...");

            // make the HTTP request
            mCreateCurrencyCoroutine.ResponseReceived += CreateCurrencyCallback;
            mCreateCurrencyCoroutine.Start(mCreateCurrencyPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateCurrencyCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCurrency: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCurrency: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateCurrencyData = (CurrencyResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CurrencyResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCurrencyStartTime, mCreateCurrencyPath, string.Format("Response received successfully:\n{0}", CreateCurrencyData.ToString()));

            if (CreateCurrencyComplete != null)
            {
                CreateCurrencyComplete(CreateCurrencyData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a currency 
        /// </summary>
        /// <param name="code">The currency code</param>
        public void DeleteCurrency(string code)
        {
            // verify the required parameter 'code' is set
            if (code == null)
            {
                throw new KnetikException(400, "Missing required parameter 'code' when calling DeleteCurrency");
            }
            
            mDeleteCurrencyPath = "/currencies/{code}";
            if (!string.IsNullOrEmpty(mDeleteCurrencyPath))
            {
                mDeleteCurrencyPath = mDeleteCurrencyPath.Replace("{format}", "json");
            }
            mDeleteCurrencyPath = mDeleteCurrencyPath.Replace("{" + "code" + "}", KnetikClient.DefaultClient.ParameterToString(code));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteCurrencyStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteCurrencyStartTime, mDeleteCurrencyPath, "Sending server request...");

            // make the HTTP request
            mDeleteCurrencyCoroutine.ResponseReceived += DeleteCurrencyCallback;
            mDeleteCurrencyCoroutine.Start(mDeleteCurrencyPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteCurrencyCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCurrency: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCurrency: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteCurrencyStartTime, mDeleteCurrencyPath, "Response received successfully.");
            if (DeleteCurrencyComplete != null)
            {
                DeleteCurrencyComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search currencies 
        /// </summary>
        /// <param name="filterEnabledCurrencies">Filter for alternate currencies setup explicitely in system config</param>
        /// <param name="filterType">Filter currencies by type.  Allowable values: (&#39;virtual&#39;, &#39;real&#39;)</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCurrencies(bool? filterEnabledCurrencies, string filterType, int? size, int? page, string order)
        {
            
            mGetCurrenciesPath = "/currencies";
            if (!string.IsNullOrEmpty(mGetCurrenciesPath))
            {
                mGetCurrenciesPath = mGetCurrenciesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterEnabledCurrencies != null)
            {
                queryParams.Add("filter_enabled_currencies", KnetikClient.DefaultClient.ParameterToString(filterEnabledCurrencies));
            }

            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.DefaultClient.ParameterToString(filterType));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.DefaultClient.ParameterToString(order));
            }

            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mGetCurrenciesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCurrenciesStartTime, mGetCurrenciesPath, "Sending server request...");

            // make the HTTP request
            mGetCurrenciesCoroutine.ResponseReceived += GetCurrenciesCallback;
            mGetCurrenciesCoroutine.Start(mGetCurrenciesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCurrenciesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCurrencies: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCurrencies: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCurrenciesData = (PageResourceCurrencyResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceCurrencyResource), response.Headers);
            KnetikLogger.LogResponse(mGetCurrenciesStartTime, mGetCurrenciesPath, string.Format("Response received successfully:\n{0}", GetCurrenciesData.ToString()));

            if (GetCurrenciesComplete != null)
            {
                GetCurrenciesComplete(GetCurrenciesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single currency 
        /// </summary>
        /// <param name="code">The currency code</param>
        public void GetCurrency(string code)
        {
            // verify the required parameter 'code' is set
            if (code == null)
            {
                throw new KnetikException(400, "Missing required parameter 'code' when calling GetCurrency");
            }
            
            mGetCurrencyPath = "/currencies/{code}";
            if (!string.IsNullOrEmpty(mGetCurrencyPath))
            {
                mGetCurrencyPath = mGetCurrencyPath.Replace("{format}", "json");
            }
            mGetCurrencyPath = mGetCurrencyPath.Replace("{" + "code" + "}", KnetikClient.DefaultClient.ParameterToString(code));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mGetCurrencyStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCurrencyStartTime, mGetCurrencyPath, "Sending server request...");

            // make the HTTP request
            mGetCurrencyCoroutine.ResponseReceived += GetCurrencyCallback;
            mGetCurrencyCoroutine.Start(mGetCurrencyPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCurrencyCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCurrency: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCurrency: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCurrencyData = (CurrencyResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CurrencyResource), response.Headers);
            KnetikLogger.LogResponse(mGetCurrencyStartTime, mGetCurrencyPath, string.Format("Response received successfully:\n{0}", GetCurrencyData.ToString()));

            if (GetCurrencyComplete != null)
            {
                GetCurrencyComplete(GetCurrencyData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a currency 
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
            
            mUpdateCurrencyPath = "/currencies/{code}";
            if (!string.IsNullOrEmpty(mUpdateCurrencyPath))
            {
                mUpdateCurrencyPath = mUpdateCurrencyPath.Replace("{format}", "json");
            }
            mUpdateCurrencyPath = mUpdateCurrencyPath.Replace("{" + "code" + "}", KnetikClient.DefaultClient.ParameterToString(code));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(currency); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateCurrencyStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateCurrencyStartTime, mUpdateCurrencyPath, "Sending server request...");

            // make the HTTP request
            mUpdateCurrencyCoroutine.ResponseReceived += UpdateCurrencyCallback;
            mUpdateCurrencyCoroutine.Start(mUpdateCurrencyPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateCurrencyCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCurrency: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCurrency: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateCurrencyStartTime, mUpdateCurrencyPath, "Response received successfully.");
            if (UpdateCurrencyComplete != null)
            {
                UpdateCurrencyComplete();
            }
        }

    }
}
