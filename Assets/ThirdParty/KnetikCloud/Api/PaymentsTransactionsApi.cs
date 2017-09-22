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
    public interface IPaymentsTransactionsApi
    {
        TransactionResource GetTransactionData { get; }

        PageResourceTransactionResource GetTransactionsData { get; }

        RefundResource RefundTransactionData { get; }

        
        /// <summary>
        /// Get the details for a single transaction 
        /// </summary>
        /// <param name="id">id</param>
        void GetTransaction(int? id);

        /// <summary>
        /// List and search transactions 
        /// </summary>
        /// <param name="filterInvoice">Filter for transactions from a specific invoice</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetTransactions(int? filterInvoice, int? size, int? page, string order);

        /// <summary>
        /// Refund a payment transaction, in full or in part Will not allow for refunding more than the full amount even with multiple partial refunds. Money is refunded to the payment method used to make the original payment. Payment method must support refunds.
        /// </summary>
        /// <param name="id">The id of the transaction to refund</param>
        /// <param name="request">Request containing refund details</param>
        void RefundTransaction(int? id, RefundRequest request);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsTransactionsApi : IPaymentsTransactionsApi
    {
        private readonly KnetikCoroutine mGetTransactionCoroutine;
        private DateTime mGetTransactionStartTime;
        private string mGetTransactionPath;
        private readonly KnetikCoroutine mGetTransactionsCoroutine;
        private DateTime mGetTransactionsStartTime;
        private string mGetTransactionsPath;
        private readonly KnetikCoroutine mRefundTransactionCoroutine;
        private DateTime mRefundTransactionStartTime;
        private string mRefundTransactionPath;

        public TransactionResource GetTransactionData { get; private set; }
        public delegate void GetTransactionCompleteDelegate(TransactionResource response);
        public GetTransactionCompleteDelegate GetTransactionComplete;

        public PageResourceTransactionResource GetTransactionsData { get; private set; }
        public delegate void GetTransactionsCompleteDelegate(PageResourceTransactionResource response);
        public GetTransactionsCompleteDelegate GetTransactionsComplete;

        public RefundResource RefundTransactionData { get; private set; }
        public delegate void RefundTransactionCompleteDelegate(RefundResource response);
        public RefundTransactionCompleteDelegate RefundTransactionComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsTransactionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsTransactionsApi()
        {
            mGetTransactionCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetTransactionsCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mRefundTransactionCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
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
            
            mGetTransactionPath = "/transactions/{id}";
            if (!string.IsNullOrEmpty(mGetTransactionPath))
            {
                mGetTransactionPath = mGetTransactionPath.Replace("{format}", "json");
            }
            mGetTransactionPath = mGetTransactionPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetTransactionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetTransactionStartTime, mGetTransactionPath, "Sending server request...");

            // make the HTTP request
            mGetTransactionCoroutine.ResponseReceived += GetTransactionCallback;
            mGetTransactionCoroutine.Start(mGetTransactionPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetTransactionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetTransaction: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetTransaction: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetTransactionData = (TransactionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TransactionResource), response.Headers);
            KnetikLogger.LogResponse(mGetTransactionStartTime, mGetTransactionPath, string.Format("Response received successfully:\n{0}", GetTransactionData.ToString()));

            if (GetTransactionComplete != null)
            {
                GetTransactionComplete(GetTransactionData);
            }
        }
        /// <summary>
        /// List and search transactions 
        /// </summary>
        /// <param name="filterInvoice">Filter for transactions from a specific invoice</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetTransactions(int? filterInvoice, int? size, int? page, string order)
        {
            
            mGetTransactionsPath = "/transactions";
            if (!string.IsNullOrEmpty(mGetTransactionsPath))
            {
                mGetTransactionsPath = mGetTransactionsPath.Replace("{format}", "json");
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

            mGetTransactionsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetTransactionsStartTime, mGetTransactionsPath, "Sending server request...");

            // make the HTTP request
            mGetTransactionsCoroutine.ResponseReceived += GetTransactionsCallback;
            mGetTransactionsCoroutine.Start(mGetTransactionsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetTransactionsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetTransactions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetTransactions: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetTransactionsData = (PageResourceTransactionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTransactionResource), response.Headers);
            KnetikLogger.LogResponse(mGetTransactionsStartTime, mGetTransactionsPath, string.Format("Response received successfully:\n{0}", GetTransactionsData.ToString()));

            if (GetTransactionsComplete != null)
            {
                GetTransactionsComplete(GetTransactionsData);
            }
        }
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
            
            mRefundTransactionPath = "/transactions/{id}/refunds";
            if (!string.IsNullOrEmpty(mRefundTransactionPath))
            {
                mRefundTransactionPath = mRefundTransactionPath.Replace("{format}", "json");
            }
            mRefundTransactionPath = mRefundTransactionPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mRefundTransactionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mRefundTransactionStartTime, mRefundTransactionPath, "Sending server request...");

            // make the HTTP request
            mRefundTransactionCoroutine.ResponseReceived += RefundTransactionCallback;
            mRefundTransactionCoroutine.Start(mRefundTransactionPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void RefundTransactionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RefundTransaction: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RefundTransaction: " + response.ErrorMessage, response.ErrorMessage);
            }

            RefundTransactionData = (RefundResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(RefundResource), response.Headers);
            KnetikLogger.LogResponse(mRefundTransactionStartTime, mRefundTransactionPath, string.Format("Response received successfully:\n{0}", RefundTransactionData.ToString()));

            if (RefundTransactionComplete != null)
            {
                RefundTransactionComplete(RefundTransactionData);
            }
        }
    }
}
