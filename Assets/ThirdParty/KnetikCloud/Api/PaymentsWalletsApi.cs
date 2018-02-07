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
    public interface IPaymentsWalletsApi
    {
        SimpleWallet GetUserWalletData { get; }

        /// <summary>
        /// Returns the user&#39;s wallet for the given currency code 
        /// </summary>
        /// <param name="userId">The ID of the user for whom wallet is being retrieved</param>
        /// <param name="currencyCode">Currency code of the user&#39;s wallet</param>
        void GetUserWallet(int? userId, string currencyCode);

        PageResourceWalletTransactionResource GetUserWalletTransactionsData { get; }

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

        List<SimpleWallet> GetUserWalletsData { get; }

        /// <summary>
        /// List all of a user&#39;s wallets 
        /// </summary>
        /// <param name="userId">The ID of the user for whom wallets are being retrieved</param>
        void GetUserWallets(int? userId);

        PageResourceWalletTotalResponse GetWalletBalancesData { get; }

        /// <summary>
        /// Retrieves a summation of wallet balances by currency code 
        /// </summary>
        void GetWalletBalances();

        PageResourceWalletTransactionResource GetWalletTransactionsData { get; }

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

        PageResourceSimpleWallet GetWalletsData { get; }

        /// <summary>
        /// Retrieve a list of wallets across the system 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetWallets(int? size, int? page, string order);

        WalletTransactionResource UpdateWalletBalanceData { get; }

        /// <summary>
        /// Updates the balance for a user&#39;s wallet 
        /// </summary>
        /// <param name="userId">The ID of the user for whom wallet is being modified</param>
        /// <param name="currencyCode">Currency code of the user&#39;s wallet</param>
        /// <param name="request">The requested balance modification to be made to the user&#39;s wallet</param>
        void UpdateWalletBalance(int? userId, string currencyCode, WalletAlterRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsWalletsApi : IPaymentsWalletsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetUserWalletResponseContext;
        private DateTime mGetUserWalletStartTime;
        private readonly KnetikResponseContext mGetUserWalletTransactionsResponseContext;
        private DateTime mGetUserWalletTransactionsStartTime;
        private readonly KnetikResponseContext mGetUserWalletsResponseContext;
        private DateTime mGetUserWalletsStartTime;
        private readonly KnetikResponseContext mGetWalletBalancesResponseContext;
        private DateTime mGetWalletBalancesStartTime;
        private readonly KnetikResponseContext mGetWalletTransactionsResponseContext;
        private DateTime mGetWalletTransactionsStartTime;
        private readonly KnetikResponseContext mGetWalletsResponseContext;
        private DateTime mGetWalletsStartTime;
        private readonly KnetikResponseContext mUpdateWalletBalanceResponseContext;
        private DateTime mUpdateWalletBalanceStartTime;

        public SimpleWallet GetUserWalletData { get; private set; }
        public delegate void GetUserWalletCompleteDelegate(long responseCode, SimpleWallet response);
        public GetUserWalletCompleteDelegate GetUserWalletComplete;

        public PageResourceWalletTransactionResource GetUserWalletTransactionsData { get; private set; }
        public delegate void GetUserWalletTransactionsCompleteDelegate(long responseCode, PageResourceWalletTransactionResource response);
        public GetUserWalletTransactionsCompleteDelegate GetUserWalletTransactionsComplete;

        public List<SimpleWallet> GetUserWalletsData { get; private set; }
        public delegate void GetUserWalletsCompleteDelegate(long responseCode, List<SimpleWallet> response);
        public GetUserWalletsCompleteDelegate GetUserWalletsComplete;

        public PageResourceWalletTotalResponse GetWalletBalancesData { get; private set; }
        public delegate void GetWalletBalancesCompleteDelegate(long responseCode, PageResourceWalletTotalResponse response);
        public GetWalletBalancesCompleteDelegate GetWalletBalancesComplete;

        public PageResourceWalletTransactionResource GetWalletTransactionsData { get; private set; }
        public delegate void GetWalletTransactionsCompleteDelegate(long responseCode, PageResourceWalletTransactionResource response);
        public GetWalletTransactionsCompleteDelegate GetWalletTransactionsComplete;

        public PageResourceSimpleWallet GetWalletsData { get; private set; }
        public delegate void GetWalletsCompleteDelegate(long responseCode, PageResourceSimpleWallet response);
        public GetWalletsCompleteDelegate GetWalletsComplete;

        public WalletTransactionResource UpdateWalletBalanceData { get; private set; }
        public delegate void UpdateWalletBalanceCompleteDelegate(long responseCode, WalletTransactionResource response);
        public UpdateWalletBalanceCompleteDelegate UpdateWalletBalanceComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsWalletsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsWalletsApi()
        {
            mGetUserWalletResponseContext = new KnetikResponseContext();
            mGetUserWalletResponseContext.ResponseReceived += OnGetUserWalletResponse;
            mGetUserWalletTransactionsResponseContext = new KnetikResponseContext();
            mGetUserWalletTransactionsResponseContext.ResponseReceived += OnGetUserWalletTransactionsResponse;
            mGetUserWalletsResponseContext = new KnetikResponseContext();
            mGetUserWalletsResponseContext.ResponseReceived += OnGetUserWalletsResponse;
            mGetWalletBalancesResponseContext = new KnetikResponseContext();
            mGetWalletBalancesResponseContext.ResponseReceived += OnGetWalletBalancesResponse;
            mGetWalletTransactionsResponseContext = new KnetikResponseContext();
            mGetWalletTransactionsResponseContext.ResponseReceived += OnGetWalletTransactionsResponse;
            mGetWalletsResponseContext = new KnetikResponseContext();
            mGetWalletsResponseContext.ResponseReceived += OnGetWalletsResponse;
            mUpdateWalletBalanceResponseContext = new KnetikResponseContext();
            mUpdateWalletBalanceResponseContext.ResponseReceived += OnUpdateWalletBalanceResponse;
        }
    
        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/wallets/{currency_code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUserWalletStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserWalletResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserWalletStartTime, "GetUserWallet", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserWalletResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserWallet: " + response.Error);
            }

            GetUserWalletData = (SimpleWallet) KnetikClient.Deserialize(response.Content, typeof(SimpleWallet), response.Headers);
            KnetikLogger.LogResponse(mGetUserWalletStartTime, "GetUserWallet", string.Format("Response received successfully:\n{0}", GetUserWalletData));

            if (GetUserWalletComplete != null)
            {
                GetUserWalletComplete(response.ResponseCode, GetUserWalletData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/wallets/{currency_code}/transactions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterType != null)
            {
                mWebCallEvent.QueryParams["filter_type"] = KnetikClient.ParameterToString(filterType);
            }

            if (filterMaxDate != null)
            {
                mWebCallEvent.QueryParams["filter_max_date"] = KnetikClient.ParameterToString(filterMaxDate);
            }

            if (filterMinDate != null)
            {
                mWebCallEvent.QueryParams["filter_min_date"] = KnetikClient.ParameterToString(filterMinDate);
            }

            if (filterSign != null)
            {
                mWebCallEvent.QueryParams["filter_sign"] = KnetikClient.ParameterToString(filterSign);
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
            mGetUserWalletTransactionsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserWalletTransactionsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserWalletTransactionsStartTime, "GetUserWalletTransactions", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserWalletTransactionsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserWalletTransactions: " + response.Error);
            }

            GetUserWalletTransactionsData = (PageResourceWalletTransactionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceWalletTransactionResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserWalletTransactionsStartTime, "GetUserWalletTransactions", string.Format("Response received successfully:\n{0}", GetUserWalletTransactionsData));

            if (GetUserWalletTransactionsComplete != null)
            {
                GetUserWalletTransactionsComplete(response.ResponseCode, GetUserWalletTransactionsData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/wallets";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUserWalletsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserWalletsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserWalletsStartTime, "GetUserWallets", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserWalletsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserWallets: " + response.Error);
            }

            GetUserWalletsData = (List<SimpleWallet>) KnetikClient.Deserialize(response.Content, typeof(List<SimpleWallet>), response.Headers);
            KnetikLogger.LogResponse(mGetUserWalletsStartTime, "GetUserWallets", string.Format("Response received successfully:\n{0}", GetUserWalletsData));

            if (GetUserWalletsComplete != null)
            {
                GetUserWalletsComplete(response.ResponseCode, GetUserWalletsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieves a summation of wallet balances by currency code 
        /// </summary>
        public void GetWalletBalances()
        {
            
            mWebCallEvent.WebPath = "/wallets/totals";
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
            mGetWalletBalancesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetWalletBalancesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetWalletBalancesStartTime, "GetWalletBalances", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetWalletBalancesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetWalletBalances: " + response.Error);
            }

            GetWalletBalancesData = (PageResourceWalletTotalResponse) KnetikClient.Deserialize(response.Content, typeof(PageResourceWalletTotalResponse), response.Headers);
            KnetikLogger.LogResponse(mGetWalletBalancesStartTime, "GetWalletBalances", string.Format("Response received successfully:\n{0}", GetWalletBalancesData));

            if (GetWalletBalancesComplete != null)
            {
                GetWalletBalancesComplete(response.ResponseCode, GetWalletBalancesData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/wallets/transactions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterInvoice != null)
            {
                mWebCallEvent.QueryParams["filter_invoice"] = KnetikClient.ParameterToString(filterInvoice);
            }

            if (filterType != null)
            {
                mWebCallEvent.QueryParams["filter_type"] = KnetikClient.ParameterToString(filterType);
            }

            if (filterDate != null)
            {
                mWebCallEvent.QueryParams["filter_date"] = KnetikClient.ParameterToString(filterDate);
            }

            if (filterSign != null)
            {
                mWebCallEvent.QueryParams["filter_sign"] = KnetikClient.ParameterToString(filterSign);
            }

            if (filterUserId != null)
            {
                mWebCallEvent.QueryParams["filter_user_id"] = KnetikClient.ParameterToString(filterUserId);
            }

            if (filterUsername != null)
            {
                mWebCallEvent.QueryParams["filter_username"] = KnetikClient.ParameterToString(filterUsername);
            }

            if (filterDetails != null)
            {
                mWebCallEvent.QueryParams["filter_details"] = KnetikClient.ParameterToString(filterDetails);
            }

            if (filterCurrencyCode != null)
            {
                mWebCallEvent.QueryParams["filter_currency_code"] = KnetikClient.ParameterToString(filterCurrencyCode);
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
            mGetWalletTransactionsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetWalletTransactionsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetWalletTransactionsStartTime, "GetWalletTransactions", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetWalletTransactionsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetWalletTransactions: " + response.Error);
            }

            GetWalletTransactionsData = (PageResourceWalletTransactionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceWalletTransactionResource), response.Headers);
            KnetikLogger.LogResponse(mGetWalletTransactionsStartTime, "GetWalletTransactions", string.Format("Response received successfully:\n{0}", GetWalletTransactionsData));

            if (GetWalletTransactionsComplete != null)
            {
                GetWalletTransactionsComplete(response.ResponseCode, GetWalletTransactionsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve a list of wallets across the system 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetWallets(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/wallets";
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
            mGetWalletsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetWalletsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetWalletsStartTime, "GetWallets", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetWalletsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetWallets: " + response.Error);
            }

            GetWalletsData = (PageResourceSimpleWallet) KnetikClient.Deserialize(response.Content, typeof(PageResourceSimpleWallet), response.Headers);
            KnetikLogger.LogResponse(mGetWalletsStartTime, "GetWallets", string.Format("Response received successfully:\n{0}", GetWalletsData));

            if (GetWalletsComplete != null)
            {
                GetWalletsComplete(response.ResponseCode, GetWalletsData);
            }
        }

        /// <inheritdoc />
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/wallets/{currency_code}/balance";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "currency_code" + "}", KnetikClient.ParameterToString(currencyCode));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(request); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateWalletBalanceStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateWalletBalanceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateWalletBalanceStartTime, "UpdateWalletBalance", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateWalletBalanceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateWalletBalance: " + response.Error);
            }

            UpdateWalletBalanceData = (WalletTransactionResource) KnetikClient.Deserialize(response.Content, typeof(WalletTransactionResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateWalletBalanceStartTime, "UpdateWalletBalance", string.Format("Response received successfully:\n{0}", UpdateWalletBalanceData));

            if (UpdateWalletBalanceComplete != null)
            {
                UpdateWalletBalanceComplete(response.ResponseCode, UpdateWalletBalanceData);
            }
        }

    }
}
