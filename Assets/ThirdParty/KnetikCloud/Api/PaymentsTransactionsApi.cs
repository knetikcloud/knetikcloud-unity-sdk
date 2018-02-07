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
    public interface IPaymentsTransactionsApi
    {
        TransactionResource GetTransactionData { get; }

        /// <summary>
        /// Get the details for a single transaction 
        /// </summary>
        /// <param name="id">id</param>
        void GetTransaction(int? id);

        PageResourceTransactionResource GetTransactionsData { get; }

        /// <summary>
        /// List and search transactions 
        /// </summary>
        /// <param name="filterInvoice">Filter for transactions from a specific invoice</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetTransactions(int? filterInvoice, int? size, int? page, string order);

        RefundResource RefundTransactionData { get; }

        /// <summary>
        /// Refund a payment transaction, in full or in part Will not allow for refunding more than the full amount even with multiple partial refunds. Money is refunded to the payment method used to make the original payment. Payment method must support refunds.
        /// </summary>
        /// <param name="id">The id of the transaction to refund</param>
        /// <param name="request">Request containing refund details</param>
        void RefundTransaction(int? id, RefundRequest request);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsTransactionsApi : IPaymentsTransactionsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetTransactionResponseContext;
        private DateTime mGetTransactionStartTime;
        private readonly KnetikResponseContext mGetTransactionsResponseContext;
        private DateTime mGetTransactionsStartTime;
        private readonly KnetikResponseContext mRefundTransactionResponseContext;
        private DateTime mRefundTransactionStartTime;

        public TransactionResource GetTransactionData { get; private set; }
        public delegate void GetTransactionCompleteDelegate(long responseCode, TransactionResource response);
        public GetTransactionCompleteDelegate GetTransactionComplete;

        public PageResourceTransactionResource GetTransactionsData { get; private set; }
        public delegate void GetTransactionsCompleteDelegate(long responseCode, PageResourceTransactionResource response);
        public GetTransactionsCompleteDelegate GetTransactionsComplete;

        public RefundResource RefundTransactionData { get; private set; }
        public delegate void RefundTransactionCompleteDelegate(long responseCode, RefundResource response);
        public RefundTransactionCompleteDelegate RefundTransactionComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsTransactionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsTransactionsApi()
        {
            mGetTransactionResponseContext = new KnetikResponseContext();
            mGetTransactionResponseContext.ResponseReceived += OnGetTransactionResponse;
            mGetTransactionsResponseContext = new KnetikResponseContext();
            mGetTransactionsResponseContext.ResponseReceived += OnGetTransactionsResponse;
            mRefundTransactionResponseContext = new KnetikResponseContext();
            mRefundTransactionResponseContext.ResponseReceived += OnRefundTransactionResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get the details for a single transaction 
        /// </summary>
        /// <param name="id">id</param>
        public void GetTransaction(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetTransaction");
            }
            
            mWebCallEvent.WebPath = "/transactions/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetTransactionStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetTransactionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetTransactionStartTime, "GetTransaction", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetTransactionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetTransaction: " + response.Error);
            }

            GetTransactionData = (TransactionResource) KnetikClient.Deserialize(response.Content, typeof(TransactionResource), response.Headers);
            KnetikLogger.LogResponse(mGetTransactionStartTime, "GetTransaction", string.Format("Response received successfully:\n{0}", GetTransactionData));

            if (GetTransactionComplete != null)
            {
                GetTransactionComplete(response.ResponseCode, GetTransactionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search transactions 
        /// </summary>
        /// <param name="filterInvoice">Filter for transactions from a specific invoice</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetTransactions(int? filterInvoice, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/transactions";
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
            mGetTransactionsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetTransactionsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetTransactionsStartTime, "GetTransactions", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetTransactionsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetTransactions: " + response.Error);
            }

            GetTransactionsData = (PageResourceTransactionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTransactionResource), response.Headers);
            KnetikLogger.LogResponse(mGetTransactionsStartTime, "GetTransactions", string.Format("Response received successfully:\n{0}", GetTransactionsData));

            if (GetTransactionsComplete != null)
            {
                GetTransactionsComplete(response.ResponseCode, GetTransactionsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Refund a payment transaction, in full or in part Will not allow for refunding more than the full amount even with multiple partial refunds. Money is refunded to the payment method used to make the original payment. Payment method must support refunds.
        /// </summary>
        /// <param name="id">The id of the transaction to refund</param>
        /// <param name="request">Request containing refund details</param>
        public void RefundTransaction(int? id, RefundRequest request)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling RefundTransaction");
            }
            
            mWebCallEvent.WebPath = "/transactions/{id}/refunds";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

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
            mRefundTransactionStartTime = DateTime.Now;
            mWebCallEvent.Context = mRefundTransactionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mRefundTransactionStartTime, "RefundTransaction", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnRefundTransactionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling RefundTransaction: " + response.Error);
            }

            RefundTransactionData = (RefundResource) KnetikClient.Deserialize(response.Content, typeof(RefundResource), response.Headers);
            KnetikLogger.LogResponse(mRefundTransactionStartTime, "RefundTransaction", string.Format("Response received successfully:\n{0}", RefundTransactionData));

            if (RefundTransactionComplete != null)
            {
                RefundTransactionComplete(response.ResponseCode, RefundTransactionData);
            }
        }

    }
}
