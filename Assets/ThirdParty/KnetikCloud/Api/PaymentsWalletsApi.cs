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
    public interface IPaymentsWalletsApi
    {
        SimpleWallet GetUserWalletData { get; }

        PageResourceWalletTransactionResource GetUserWalletTransactionsData { get; }

        List<SimpleWallet> GetUserWalletsData { get; }

        PageResourceWalletTotalResponse GetWalletBalancesData { get; }

        PageResourceWalletTransactionResource GetWalletTransactionsData { get; }

        PageResourceSimpleWallet GetWalletsData { get; }

        WalletTransactionResource UpdateWalletBalanceData { get; }

        
        /// <summary>
        /// Returns the user&#39;s wallet for the given currency code 
        /// </summary>
        /// <param name="userId">The ID of the user for whom wallet is being retrieved</param>
        /// <param name="currencyCode">Currency code of the user&#39;s wallet</param>
        void GetUserWallet(int? userId, string currencyCode);

        /// <summary>
        /// Retrieve a user&#39;s wallet transactions 
        /// </summary>
        /// <param name="userId">The ID of the user for whom wallet transactions are being retrieved</param>
        /// <param name="currencyCode">Currency code of the user&#39;s wallet</param>
        /// <param name="filterType">Filter for transactions with specified type</param>
        /// <param name="filterMaxDate">Filter for transactions from no earlier than the specified date as a unix timestamp in seconds</param>
        /// <param name="filterMinDate">Filter for transactions from no later than the specified date as a unix timestamp in seconds</param>
        /// <param name="filterSign">Filter for transactions with amount with the given sign.  Allowable values: (&#39;positive&#39;, &#39;negative&#39;)</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetUserWalletTransactions(int? userId, string currencyCode, string filterType, long? filterMaxDate, long? filterMinDate, string filterSign, int? size, int? page, string order);

        /// <summary>
        /// List all of a user&#39;s wallets 
        /// </summary>
        /// <param name="userId">The ID of the user for whom wallets are being retrieved</param>
        void GetUserWallets(int? userId);

        /// <summary>
        /// Retrieves a summation of wallet balances by currency code 
        /// </summary>
        void GetWalletBalances();

        /// <summary>
        /// Retrieve wallet transactions across the system 
        /// </summary>
        /// <param name="filterInvoice">Filter for transactions from a specific invoice</param>
        /// <param name="filterType">Filter for transactions with specified type</param>
        /// <param name="filterDate">A comma separated string without spaces.  First value is the operator to search on, second value is the log start date, a unix timestamp in seconds. Can be repeated for a range, eg: GT,123,LT,456  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterSign">Filter for transactions with amount with the given sign</param>
        /// <param name="filterUserId">Filter for transactions for specific userId</param>
        /// <param name="filterUsername">Filter for transactions for specific username that start with the given string</param>
        /// <param name="filterDetails">Filter for transactions for specific details that start with the given string</param>
        /// <param name="filterCurrencyCode">Filter for transactions for specific currency code</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetWalletTransactions(int? filterInvoice, string filterType, string filterDate, string filterSign, int? filterUserId, string filterUsername, string filterDetails, string filterCurrencyCode, int? size, int? page, string order);

        /// <summary>
        /// Retrieve a list of wallets across the system 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetWallets(int? size, int? page, string order);

        /// <summary>
        /// Updates the balance for a user&#39;s wallet 
        /// </summary>
        /// <param name="userId">The ID of the user for whom wallet is being modified</param>
        /// <param name="currencyCode">Currency code of the user&#39;s wallet</param>
        /// <param name="request">The requested balance modification to be made to the user&#39;s wallet</param>
        void UpdateWalletBalance(int? userId, string currencyCode, WalletAlterRequest request);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsWalletsApi : IPaymentsWalletsApi
    {
        private readonly KnetikCoroutine mGetUserWalletCoroutine;
        private DateTime mGetUserWalletStartTime;
        private string mGetUserWalletPath;
        private readonly KnetikCoroutine mGetUserWalletTransactionsCoroutine;
        private DateTime mGetUserWalletTransactionsStartTime;
        private string mGetUserWalletTransactionsPath;
        private readonly KnetikCoroutine mGetUserWalletsCoroutine;
        private DateTime mGetUserWalletsStartTime;
        private string mGetUserWalletsPath;
        private readonly KnetikCoroutine mGetWalletBalancesCoroutine;
        private DateTime mGetWalletBalancesStartTime;
        private string mGetWalletBalancesPath;
        private readonly KnetikCoroutine mGetWalletTransactionsCoroutine;
        private DateTime mGetWalletTransactionsStartTime;
        private string mGetWalletTransactionsPath;
        private readonly KnetikCoroutine mGetWalletsCoroutine;
        private DateTime mGetWalletsStartTime;
        private string mGetWalletsPath;
        private readonly KnetikCoroutine mUpdateWalletBalanceCoroutine;
        private DateTime mUpdateWalletBalanceStartTime;
        private string mUpdateWalletBalancePath;

        public SimpleWallet GetUserWalletData { get; private set; }
        public delegate void GetUserWalletCompleteDelegate(SimpleWallet response);
        public GetUserWalletCompleteDelegate GetUserWalletComplete;

        public PageResourceWalletTransactionResource GetUserWalletTransactionsData { get; private set; }
        public delegate void GetUserWalletTransactionsCompleteDelegate(PageResourceWalletTransactionResource response);
        public GetUserWalletTransactionsCompleteDelegate GetUserWalletTransactionsComplete;

        public List<SimpleWallet> GetUserWalletsData { get; private set; }
        public delegate void GetUserWalletsCompleteDelegate(List<SimpleWallet> response);
        public GetUserWalletsCompleteDelegate GetUserWalletsComplete;

        public PageResourceWalletTotalResponse GetWalletBalancesData { get; private set; }
        public delegate void GetWalletBalancesCompleteDelegate(PageResourceWalletTotalResponse response);
        public GetWalletBalancesCompleteDelegate GetWalletBalancesComplete;

        public PageResourceWalletTransactionResource GetWalletTransactionsData { get; private set; }
        public delegate void GetWalletTransactionsCompleteDelegate(PageResourceWalletTransactionResource response);
        public GetWalletTransactionsCompleteDelegate GetWalletTransactionsComplete;

        public PageResourceSimpleWallet GetWalletsData { get; private set; }
        public delegate void GetWalletsCompleteDelegate(PageResourceSimpleWallet response);
        public GetWalletsCompleteDelegate GetWalletsComplete;

        public WalletTransactionResource UpdateWalletBalanceData { get; private set; }
        public delegate void UpdateWalletBalanceCompleteDelegate(WalletTransactionResource response);
        public UpdateWalletBalanceCompleteDelegate UpdateWalletBalanceComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsWalletsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsWalletsApi()
        {
            mGetUserWalletCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetUserWalletTransactionsCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetUserWalletsCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetWalletBalancesCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetWalletTransactionsCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetWalletsCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateWalletBalanceCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
        /// <summary>
        /// Returns the user&#39;s wallet for the given currency code 
        /// </summary>
        /// <param name="userId">The ID of the user for whom wallet is being retrieved</param>
        /// <param name="currencyCode">Currency code of the user&#39;s wallet</param>
        public void GetUserWallet(int? userId, string currencyCode)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserWallet");
            }
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetUserWallet");
            }
            
            mGetUserWalletPath = "/users/{user_id}/wallets/{currency_code}";
            if (!string.IsNullOrEmpty(mGetUserWalletPath))
            {
                mGetUserWalletPath = mGetUserWalletPath.Replace("{format}", "json");
            }
            mGetUserWalletPath = mGetUserWalletPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mGetUserWalletPath = mGetUserWalletPath.Replace("{" + "currency_code" + "}", KnetikClient.DefaultClient.ParameterToString(currencyCode));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserWalletStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserWalletStartTime, mGetUserWalletPath, "Sending server request...");

            // make the HTTP request
            mGetUserWalletCoroutine.ResponseReceived += GetUserWalletCallback;
            mGetUserWalletCoroutine.Start(mGetUserWalletPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserWalletCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserWallet: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserWallet: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserWalletData = (SimpleWallet) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(SimpleWallet), response.Headers);
            KnetikLogger.LogResponse(mGetUserWalletStartTime, mGetUserWalletPath, string.Format("Response received successfully:\n{0}", GetUserWalletData.ToString()));

            if (GetUserWalletComplete != null)
            {
                GetUserWalletComplete(GetUserWalletData);
            }
        }
        /// <summary>
        /// Retrieve a user&#39;s wallet transactions 
        /// </summary>
        /// <param name="userId">The ID of the user for whom wallet transactions are being retrieved</param>
        /// <param name="currencyCode">Currency code of the user&#39;s wallet</param>
        /// <param name="filterType">Filter for transactions with specified type</param>
        /// <param name="filterMaxDate">Filter for transactions from no earlier than the specified date as a unix timestamp in seconds</param>
        /// <param name="filterMinDate">Filter for transactions from no later than the specified date as a unix timestamp in seconds</param>
        /// <param name="filterSign">Filter for transactions with amount with the given sign.  Allowable values: (&#39;positive&#39;, &#39;negative&#39;)</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetUserWalletTransactions(int? userId, string currencyCode, string filterType, long? filterMaxDate, long? filterMinDate, string filterSign, int? size, int? page, string order)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserWalletTransactions");
            }
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling GetUserWalletTransactions");
            }
            
            mGetUserWalletTransactionsPath = "/users/{user_id}/wallets/{currency_code}/transactions";
            if (!string.IsNullOrEmpty(mGetUserWalletTransactionsPath))
            {
                mGetUserWalletTransactionsPath = mGetUserWalletTransactionsPath.Replace("{format}", "json");
            }
            mGetUserWalletTransactionsPath = mGetUserWalletTransactionsPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mGetUserWalletTransactionsPath = mGetUserWalletTransactionsPath.Replace("{" + "currency_code" + "}", KnetikClient.DefaultClient.ParameterToString(currencyCode));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.DefaultClient.ParameterToString(filterType));
            }

            if (filterMaxDate != null)
            {
                queryParams.Add("filter_max_date", KnetikClient.DefaultClient.ParameterToString(filterMaxDate));
            }

            if (filterMinDate != null)
            {
                queryParams.Add("filter_min_date", KnetikClient.DefaultClient.ParameterToString(filterMinDate));
            }

            if (filterSign != null)
            {
                queryParams.Add("filter_sign", KnetikClient.DefaultClient.ParameterToString(filterSign));
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserWalletTransactionsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserWalletTransactionsStartTime, mGetUserWalletTransactionsPath, "Sending server request...");

            // make the HTTP request
            mGetUserWalletTransactionsCoroutine.ResponseReceived += GetUserWalletTransactionsCallback;
            mGetUserWalletTransactionsCoroutine.Start(mGetUserWalletTransactionsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserWalletTransactionsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserWalletTransactions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserWalletTransactions: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserWalletTransactionsData = (PageResourceWalletTransactionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceWalletTransactionResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserWalletTransactionsStartTime, mGetUserWalletTransactionsPath, string.Format("Response received successfully:\n{0}", GetUserWalletTransactionsData.ToString()));

            if (GetUserWalletTransactionsComplete != null)
            {
                GetUserWalletTransactionsComplete(GetUserWalletTransactionsData);
            }
        }
        /// <summary>
        /// List all of a user&#39;s wallets 
        /// </summary>
        /// <param name="userId">The ID of the user for whom wallets are being retrieved</param>
        public void GetUserWallets(int? userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserWallets");
            }
            
            mGetUserWalletsPath = "/users/{user_id}/wallets";
            if (!string.IsNullOrEmpty(mGetUserWalletsPath))
            {
                mGetUserWalletsPath = mGetUserWalletsPath.Replace("{format}", "json");
            }
            mGetUserWalletsPath = mGetUserWalletsPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserWalletsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserWalletsStartTime, mGetUserWalletsPath, "Sending server request...");

            // make the HTTP request
            mGetUserWalletsCoroutine.ResponseReceived += GetUserWalletsCallback;
            mGetUserWalletsCoroutine.Start(mGetUserWalletsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserWalletsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserWallets: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserWallets: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserWalletsData = (List<SimpleWallet>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<SimpleWallet>), response.Headers);
            KnetikLogger.LogResponse(mGetUserWalletsStartTime, mGetUserWalletsPath, string.Format("Response received successfully:\n{0}", GetUserWalletsData.ToString()));

            if (GetUserWalletsComplete != null)
            {
                GetUserWalletsComplete(GetUserWalletsData);
            }
        }
        /// <summary>
        /// Retrieves a summation of wallet balances by currency code 
        /// </summary>
        public void GetWalletBalances()
        {
            
            mGetWalletBalancesPath = "/wallets/totals";
            if (!string.IsNullOrEmpty(mGetWalletBalancesPath))
            {
                mGetWalletBalancesPath = mGetWalletBalancesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetWalletBalancesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetWalletBalancesStartTime, mGetWalletBalancesPath, "Sending server request...");

            // make the HTTP request
            mGetWalletBalancesCoroutine.ResponseReceived += GetWalletBalancesCallback;
            mGetWalletBalancesCoroutine.Start(mGetWalletBalancesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetWalletBalancesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetWalletBalances: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetWalletBalances: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetWalletBalancesData = (PageResourceWalletTotalResponse) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceWalletTotalResponse), response.Headers);
            KnetikLogger.LogResponse(mGetWalletBalancesStartTime, mGetWalletBalancesPath, string.Format("Response received successfully:\n{0}", GetWalletBalancesData.ToString()));

            if (GetWalletBalancesComplete != null)
            {
                GetWalletBalancesComplete(GetWalletBalancesData);
            }
        }
        /// <summary>
        /// Retrieve wallet transactions across the system 
        /// </summary>
        /// <param name="filterInvoice">Filter for transactions from a specific invoice</param>
        /// <param name="filterType">Filter for transactions with specified type</param>
        /// <param name="filterDate">A comma separated string without spaces.  First value is the operator to search on, second value is the log start date, a unix timestamp in seconds. Can be repeated for a range, eg: GT,123,LT,456  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterSign">Filter for transactions with amount with the given sign</param>
        /// <param name="filterUserId">Filter for transactions for specific userId</param>
        /// <param name="filterUsername">Filter for transactions for specific username that start with the given string</param>
        /// <param name="filterDetails">Filter for transactions for specific details that start with the given string</param>
        /// <param name="filterCurrencyCode">Filter for transactions for specific currency code</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetWalletTransactions(int? filterInvoice, string filterType, string filterDate, string filterSign, int? filterUserId, string filterUsername, string filterDetails, string filterCurrencyCode, int? size, int? page, string order)
        {
            
            mGetWalletTransactionsPath = "/wallets/transactions";
            if (!string.IsNullOrEmpty(mGetWalletTransactionsPath))
            {
                mGetWalletTransactionsPath = mGetWalletTransactionsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterInvoice != null)
            {
                queryParams.Add("filter_invoice", KnetikClient.DefaultClient.ParameterToString(filterInvoice));
            }

            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.DefaultClient.ParameterToString(filterType));
            }

            if (filterDate != null)
            {
                queryParams.Add("filter_date", KnetikClient.DefaultClient.ParameterToString(filterDate));
            }

            if (filterSign != null)
            {
                queryParams.Add("filter_sign", KnetikClient.DefaultClient.ParameterToString(filterSign));
            }

            if (filterUserId != null)
            {
                queryParams.Add("filter_user_id", KnetikClient.DefaultClient.ParameterToString(filterUserId));
            }

            if (filterUsername != null)
            {
                queryParams.Add("filter_username", KnetikClient.DefaultClient.ParameterToString(filterUsername));
            }

            if (filterDetails != null)
            {
                queryParams.Add("filter_details", KnetikClient.DefaultClient.ParameterToString(filterDetails));
            }

            if (filterCurrencyCode != null)
            {
                queryParams.Add("filter_currency_code", KnetikClient.DefaultClient.ParameterToString(filterCurrencyCode));
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetWalletTransactionsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetWalletTransactionsStartTime, mGetWalletTransactionsPath, "Sending server request...");

            // make the HTTP request
            mGetWalletTransactionsCoroutine.ResponseReceived += GetWalletTransactionsCallback;
            mGetWalletTransactionsCoroutine.Start(mGetWalletTransactionsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetWalletTransactionsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetWalletTransactions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetWalletTransactions: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetWalletTransactionsData = (PageResourceWalletTransactionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceWalletTransactionResource), response.Headers);
            KnetikLogger.LogResponse(mGetWalletTransactionsStartTime, mGetWalletTransactionsPath, string.Format("Response received successfully:\n{0}", GetWalletTransactionsData.ToString()));

            if (GetWalletTransactionsComplete != null)
            {
                GetWalletTransactionsComplete(GetWalletTransactionsData);
            }
        }
        /// <summary>
        /// Retrieve a list of wallets across the system 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetWallets(int? size, int? page, string order)
        {
            
            mGetWalletsPath = "/wallets";
            if (!string.IsNullOrEmpty(mGetWalletsPath))
            {
                mGetWalletsPath = mGetWalletsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetWalletsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetWalletsStartTime, mGetWalletsPath, "Sending server request...");

            // make the HTTP request
            mGetWalletsCoroutine.ResponseReceived += GetWalletsCallback;
            mGetWalletsCoroutine.Start(mGetWalletsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetWalletsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetWallets: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetWallets: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetWalletsData = (PageResourceSimpleWallet) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceSimpleWallet), response.Headers);
            KnetikLogger.LogResponse(mGetWalletsStartTime, mGetWalletsPath, string.Format("Response received successfully:\n{0}", GetWalletsData.ToString()));

            if (GetWalletsComplete != null)
            {
                GetWalletsComplete(GetWalletsData);
            }
        }
        /// <summary>
        /// Updates the balance for a user&#39;s wallet 
        /// </summary>
        /// <param name="userId">The ID of the user for whom wallet is being modified</param>
        /// <param name="currencyCode">Currency code of the user&#39;s wallet</param>
        /// <param name="request">The requested balance modification to be made to the user&#39;s wallet</param>
        public void UpdateWalletBalance(int? userId, string currencyCode, WalletAlterRequest request)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling UpdateWalletBalance");
            }
            // verify the required parameter 'currencyCode' is set
            if (currencyCode == null)
            {
                throw new KnetikException(400, "Missing required parameter 'currencyCode' when calling UpdateWalletBalance");
            }
            
            mUpdateWalletBalancePath = "/users/{user_id}/wallets/{currency_code}/balance";
            if (!string.IsNullOrEmpty(mUpdateWalletBalancePath))
            {
                mUpdateWalletBalancePath = mUpdateWalletBalancePath.Replace("{format}", "json");
            }
            mUpdateWalletBalancePath = mUpdateWalletBalancePath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mUpdateWalletBalancePath = mUpdateWalletBalancePath.Replace("{" + "currency_code" + "}", KnetikClient.DefaultClient.ParameterToString(currencyCode));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateWalletBalanceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateWalletBalanceStartTime, mUpdateWalletBalancePath, "Sending server request...");

            // make the HTTP request
            mUpdateWalletBalanceCoroutine.ResponseReceived += UpdateWalletBalanceCallback;
            mUpdateWalletBalanceCoroutine.Start(mUpdateWalletBalancePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateWalletBalanceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateWalletBalance: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateWalletBalance: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateWalletBalanceData = (WalletTransactionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(WalletTransactionResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateWalletBalanceStartTime, mUpdateWalletBalancePath, string.Format("Response received successfully:\n{0}", UpdateWalletBalanceData.ToString()));

            if (UpdateWalletBalanceComplete != null)
            {
                UpdateWalletBalanceComplete(UpdateWalletBalanceData);
            }
        }
    }
}
