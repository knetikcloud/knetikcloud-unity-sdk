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
    public interface IInvoicesApi
    {
        List<InvoiceResource> CreateInvoiceData { get; }

        List<string> GetFulFillmentStatusesData { get; }

        InvoiceResource GetInvoiceData { get; }

        PageResourceInvoiceLogEntry GetInvoiceLogsData { get; }

        PageResourceInvoiceResource GetInvoicesData { get; }

        List<string> GetPaymentStatusesData { get; }

        
        /// <summary>
        /// Create an invoice Create an invoice(s) by providing a cart GUID. Note that there may be multiple invoices created, one per vendor.
        /// </summary>
        /// <param name="req">Invoice to be created</param>
        void CreateInvoice(InvoiceCreateRequest req);

        /// <summary>
        /// Lists available fulfillment statuses 
        /// </summary>
        void GetFulFillmentStatuses();

        /// <summary>
        /// Retrieve an invoice 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        void GetInvoice(int? id);

        /// <summary>
        /// List invoice logs 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetInvoiceLogs(int? id, int? size, int? page);

        /// <summary>
        /// Retrieve invoices Without INVOICES_ADMIN permission the results are automatically filtered for only the logged in user&#39;s invoices. It is recomended however that filter_user be added to avoid issues for admin users accidentally getting additional invoices.
        /// </summary>
        /// <param name="filterUser">The id of a user to get invoices for. Automtically added if not being called with admin permissions.</param>
        /// <param name="filterEmail">Filters invoices by customer&#39;s email. Admins only.</param>
        /// <param name="filterFulfillmentStatus">Filters invoices by fulfillment status type. Can be a comma separated list of statuses</param>
        /// <param name="filterPaymentStatus">Filters invoices by payment status type. Can be a comma separated list of statuses</param>
        /// <param name="filterItemName">Filters invoices by item name containing the given string</param>
        /// <param name="filterExternalRef">Filters invoices by external reference.</param>
        /// <param name="filterCreatedDate">Filters invoices by creation date. Multiple values possible for range search. Format: filter_created_date&#x3D;OP,ts&amp;... where OP in (GT, LT, GOE, LOE, EQ) and ts is a unix timestamp in seconds. Ex: filter_created_date&#x3D;GT,1452154258,LT,1554254874</param>
        /// <param name="filterVendorIds">Filters invoices for ones from one of the vendors whose id is in the given comma separated list</param>
        /// <param name="filterCurrency">Filters invoices by currency. ISO3 currency code</param>
        /// <param name="filterShippingStateName">Filters invoices by shipping address: Exact match state name</param>
        /// <param name="filterShippingCountryName">Filters invoices by shipping address: Exact match country name</param>
        /// <param name="filterShipping">Filters invoices by shipping price. Multiple values possible for range search. Format: filter_shipping&#x3D;OP,ts&amp;... where OP in (GT, LT, GOE, LOE, EQ). Ex: filter_shipping&#x3D;GT,14.58,LT,15.54</param>
        /// <param name="filterVendorName">Filters invoices by vendor name starting with given string</param>
        /// <param name="filterSku">Filters invoices by item sku</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetInvoices(int? filterUser, string filterEmail, string filterFulfillmentStatus, string filterPaymentStatus, string filterItemName, string filterExternalRef, string filterCreatedDate, string filterVendorIds, string filterCurrency, string filterShippingStateName, string filterShippingCountryName, string filterShipping, string filterVendorName, string filterSku, int? size, int? page, string order);

        /// <summary>
        /// Lists available payment statuses 
        /// </summary>
        void GetPaymentStatuses();

        /// <summary>
        /// Pay an invoice using a saved payment method 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="request">The payment method details. Will default to the appropriate user&#39;s wallet in the invoice currency if ommited.</param>
        void PayInvoice(int? id, PayBySavedMethodRequest request);

        /// <summary>
        /// Set the fulfillment status of a bundled invoice item This allows external fulfillment systems to report success or failure. Fulfillment status changes are restricted by a specific flow determining which status can lead to which.
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="bundleSku">The sku of the bundle in the invoice that contains the given target</param>
        /// <param name="sku">The sku of an item in the bundle in the invoice</param>
        /// <param name="status">The new fulfillment status for the item. Additional options may be available based on configuration.  Allowable values:  &#39;unfulfilled&#39;, &#39;fulfilled&#39;, &#39;not fulfillable&#39;, &#39;failed&#39;, &#39;processing&#39;, &#39;failed_permanent&#39;, &#39;delayed&#39;</param>
        void SetBundledInvoiceItemFulfillmentStatus(int? id, string bundleSku, string sku, StringWrapper status);

        /// <summary>
        /// Set the external reference of an invoice 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="externalRef">External reference info</param>
        void SetExternalRef(int? id, StringWrapper externalRef);

        /// <summary>
        /// Set the fulfillment status of an invoice item This allows external fulfillment systems to report success or failure. Fulfillment status changes are restricted by a specific flow determining which status can lead to which.
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="sku">The sku of an item in the invoice</param>
        /// <param name="status">The new fulfillment status for the item. Additional options may be available based on configuration.  Allowable values:  &#39;unfulfilled&#39;, &#39;fulfilled&#39;, &#39;not fulfillable&#39;, &#39;failed&#39;, &#39;processing&#39;, &#39;failed_permanent&#39;, &#39;delayed&#39;</param>
        void SetInvoiceItemFulfillmentStatus(int? id, string sku, StringWrapper status);

        /// <summary>
        /// Set the order notes of an invoice 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="orderNotes">Payment status info</param>
        void SetOrderNotes(int? id, StringWrapper orderNotes);

        /// <summary>
        /// Set the payment status of an invoice This may trigger fulfillment if setting the status to &#39;paid&#39;. This is mainly intended to support external payment systems that cannot be incorporated into the payment method system. Payment status changes are restricted by a specific flow determining which status can lead to which.
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="request">Payment status info</param>
        void SetPaymentStatus(int? id, InvoicePaymentStatusRequest request);

        /// <summary>
        /// Set or update billing info 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="billingInfoRequest">Address info</param>
        void UpdateBillingInfo(int? id, AddressResource billingInfoRequest);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class InvoicesApi : IInvoicesApi
    {
        private readonly KnetikCoroutine mCreateInvoiceCoroutine;
        private DateTime mCreateInvoiceStartTime;
        private string mCreateInvoicePath;
        private readonly KnetikCoroutine mGetFulFillmentStatusesCoroutine;
        private DateTime mGetFulFillmentStatusesStartTime;
        private string mGetFulFillmentStatusesPath;
        private readonly KnetikCoroutine mGetInvoiceCoroutine;
        private DateTime mGetInvoiceStartTime;
        private string mGetInvoicePath;
        private readonly KnetikCoroutine mGetInvoiceLogsCoroutine;
        private DateTime mGetInvoiceLogsStartTime;
        private string mGetInvoiceLogsPath;
        private readonly KnetikCoroutine mGetInvoicesCoroutine;
        private DateTime mGetInvoicesStartTime;
        private string mGetInvoicesPath;
        private readonly KnetikCoroutine mGetPaymentStatusesCoroutine;
        private DateTime mGetPaymentStatusesStartTime;
        private string mGetPaymentStatusesPath;
        private readonly KnetikCoroutine mPayInvoiceCoroutine;
        private DateTime mPayInvoiceStartTime;
        private string mPayInvoicePath;
        private readonly KnetikCoroutine mSetBundledInvoiceItemFulfillmentStatusCoroutine;
        private DateTime mSetBundledInvoiceItemFulfillmentStatusStartTime;
        private string mSetBundledInvoiceItemFulfillmentStatusPath;
        private readonly KnetikCoroutine mSetExternalRefCoroutine;
        private DateTime mSetExternalRefStartTime;
        private string mSetExternalRefPath;
        private readonly KnetikCoroutine mSetInvoiceItemFulfillmentStatusCoroutine;
        private DateTime mSetInvoiceItemFulfillmentStatusStartTime;
        private string mSetInvoiceItemFulfillmentStatusPath;
        private readonly KnetikCoroutine mSetOrderNotesCoroutine;
        private DateTime mSetOrderNotesStartTime;
        private string mSetOrderNotesPath;
        private readonly KnetikCoroutine mSetPaymentStatusCoroutine;
        private DateTime mSetPaymentStatusStartTime;
        private string mSetPaymentStatusPath;
        private readonly KnetikCoroutine mUpdateBillingInfoCoroutine;
        private DateTime mUpdateBillingInfoStartTime;
        private string mUpdateBillingInfoPath;

        public List<InvoiceResource> CreateInvoiceData { get; private set; }
        public delegate void CreateInvoiceCompleteDelegate(List<InvoiceResource> response);
        public CreateInvoiceCompleteDelegate CreateInvoiceComplete;

        public List<string> GetFulFillmentStatusesData { get; private set; }
        public delegate void GetFulFillmentStatusesCompleteDelegate(List<string> response);
        public GetFulFillmentStatusesCompleteDelegate GetFulFillmentStatusesComplete;

        public InvoiceResource GetInvoiceData { get; private set; }
        public delegate void GetInvoiceCompleteDelegate(InvoiceResource response);
        public GetInvoiceCompleteDelegate GetInvoiceComplete;

        public PageResourceInvoiceLogEntry GetInvoiceLogsData { get; private set; }
        public delegate void GetInvoiceLogsCompleteDelegate(PageResourceInvoiceLogEntry response);
        public GetInvoiceLogsCompleteDelegate GetInvoiceLogsComplete;

        public PageResourceInvoiceResource GetInvoicesData { get; private set; }
        public delegate void GetInvoicesCompleteDelegate(PageResourceInvoiceResource response);
        public GetInvoicesCompleteDelegate GetInvoicesComplete;

        public List<string> GetPaymentStatusesData { get; private set; }
        public delegate void GetPaymentStatusesCompleteDelegate(List<string> response);
        public GetPaymentStatusesCompleteDelegate GetPaymentStatusesComplete;

        public delegate void PayInvoiceCompleteDelegate();
        public PayInvoiceCompleteDelegate PayInvoiceComplete;

        public delegate void SetBundledInvoiceItemFulfillmentStatusCompleteDelegate();
        public SetBundledInvoiceItemFulfillmentStatusCompleteDelegate SetBundledInvoiceItemFulfillmentStatusComplete;

        public delegate void SetExternalRefCompleteDelegate();
        public SetExternalRefCompleteDelegate SetExternalRefComplete;

        public delegate void SetInvoiceItemFulfillmentStatusCompleteDelegate();
        public SetInvoiceItemFulfillmentStatusCompleteDelegate SetInvoiceItemFulfillmentStatusComplete;

        public delegate void SetOrderNotesCompleteDelegate();
        public SetOrderNotesCompleteDelegate SetOrderNotesComplete;

        public delegate void SetPaymentStatusCompleteDelegate();
        public SetPaymentStatusCompleteDelegate SetPaymentStatusComplete;

        public delegate void UpdateBillingInfoCompleteDelegate();
        public UpdateBillingInfoCompleteDelegate UpdateBillingInfoComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public InvoicesApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
            mCreateInvoiceCoroutine = new KnetikCoroutine(KnetikClient);
            mGetFulFillmentStatusesCoroutine = new KnetikCoroutine(KnetikClient);
            mGetInvoiceCoroutine = new KnetikCoroutine(KnetikClient);
            mGetInvoiceLogsCoroutine = new KnetikCoroutine(KnetikClient);
            mGetInvoicesCoroutine = new KnetikCoroutine(KnetikClient);
            mGetPaymentStatusesCoroutine = new KnetikCoroutine(KnetikClient);
            mPayInvoiceCoroutine = new KnetikCoroutine(KnetikClient);
            mSetBundledInvoiceItemFulfillmentStatusCoroutine = new KnetikCoroutine(KnetikClient);
            mSetExternalRefCoroutine = new KnetikCoroutine(KnetikClient);
            mSetInvoiceItemFulfillmentStatusCoroutine = new KnetikCoroutine(KnetikClient);
            mSetOrderNotesCoroutine = new KnetikCoroutine(KnetikClient);
            mSetPaymentStatusCoroutine = new KnetikCoroutine(KnetikClient);
            mUpdateBillingInfoCoroutine = new KnetikCoroutine(KnetikClient);
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient { get; private set; }

        /// <summary>
        /// Create an invoice Create an invoice(s) by providing a cart GUID. Note that there may be multiple invoices created, one per vendor.
        /// </summary>
        /// <param name="req">Invoice to be created</param>
        public void CreateInvoice(InvoiceCreateRequest req)
        {
            
            mCreateInvoicePath = "/invoices";
            if (!string.IsNullOrEmpty(mCreateInvoicePath))
            {
                mCreateInvoicePath = mCreateInvoicePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(req); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateInvoiceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateInvoiceStartTime, mCreateInvoicePath, "Sending server request...");

            // make the HTTP request
            mCreateInvoiceCoroutine.ResponseReceived += CreateInvoiceCallback;
            mCreateInvoiceCoroutine.Start(mCreateInvoicePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateInvoiceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateInvoice: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateInvoice: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateInvoiceData = (List<InvoiceResource>) KnetikClient.Deserialize(response.Content, typeof(List<InvoiceResource>), response.Headers);
            KnetikLogger.LogResponse(mCreateInvoiceStartTime, mCreateInvoicePath, string.Format("Response received successfully:\n{0}", CreateInvoiceData.ToString()));

            if (CreateInvoiceComplete != null)
            {
                CreateInvoiceComplete(CreateInvoiceData);
            }
        }
        /// <summary>
        /// Lists available fulfillment statuses 
        /// </summary>
        public void GetFulFillmentStatuses()
        {
            
            mGetFulFillmentStatusesPath = "/invoices/fulfillment-statuses";
            if (!string.IsNullOrEmpty(mGetFulFillmentStatusesPath))
            {
                mGetFulFillmentStatusesPath = mGetFulFillmentStatusesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetFulFillmentStatusesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetFulFillmentStatusesStartTime, mGetFulFillmentStatusesPath, "Sending server request...");

            // make the HTTP request
            mGetFulFillmentStatusesCoroutine.ResponseReceived += GetFulFillmentStatusesCallback;
            mGetFulFillmentStatusesCoroutine.Start(mGetFulFillmentStatusesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetFulFillmentStatusesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetFulFillmentStatuses: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetFulFillmentStatuses: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetFulFillmentStatusesData = (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetFulFillmentStatusesStartTime, mGetFulFillmentStatusesPath, string.Format("Response received successfully:\n{0}", GetFulFillmentStatusesData.ToString()));

            if (GetFulFillmentStatusesComplete != null)
            {
                GetFulFillmentStatusesComplete(GetFulFillmentStatusesData);
            }
        }
        /// <summary>
        /// Retrieve an invoice 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        public void GetInvoice(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetInvoice");
            }
            
            mGetInvoicePath = "/invoices/{id}";
            if (!string.IsNullOrEmpty(mGetInvoicePath))
            {
                mGetInvoicePath = mGetInvoicePath.Replace("{format}", "json");
            }
            mGetInvoicePath = mGetInvoicePath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetInvoiceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetInvoiceStartTime, mGetInvoicePath, "Sending server request...");

            // make the HTTP request
            mGetInvoiceCoroutine.ResponseReceived += GetInvoiceCallback;
            mGetInvoiceCoroutine.Start(mGetInvoicePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetInvoiceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetInvoice: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetInvoice: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetInvoiceData = (InvoiceResource) KnetikClient.Deserialize(response.Content, typeof(InvoiceResource), response.Headers);
            KnetikLogger.LogResponse(mGetInvoiceStartTime, mGetInvoicePath, string.Format("Response received successfully:\n{0}", GetInvoiceData.ToString()));

            if (GetInvoiceComplete != null)
            {
                GetInvoiceComplete(GetInvoiceData);
            }
        }
        /// <summary>
        /// List invoice logs 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetInvoiceLogs(int? id, int? size, int? page)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetInvoiceLogs");
            }
            
            mGetInvoiceLogsPath = "/invoices/{id}/logs";
            if (!string.IsNullOrEmpty(mGetInvoiceLogsPath))
            {
                mGetInvoiceLogsPath = mGetInvoiceLogsPath.Replace("{format}", "json");
            }
            mGetInvoiceLogsPath = mGetInvoiceLogsPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

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

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetInvoiceLogsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetInvoiceLogsStartTime, mGetInvoiceLogsPath, "Sending server request...");

            // make the HTTP request
            mGetInvoiceLogsCoroutine.ResponseReceived += GetInvoiceLogsCallback;
            mGetInvoiceLogsCoroutine.Start(mGetInvoiceLogsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetInvoiceLogsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetInvoiceLogs: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetInvoiceLogs: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetInvoiceLogsData = (PageResourceInvoiceLogEntry) KnetikClient.Deserialize(response.Content, typeof(PageResourceInvoiceLogEntry), response.Headers);
            KnetikLogger.LogResponse(mGetInvoiceLogsStartTime, mGetInvoiceLogsPath, string.Format("Response received successfully:\n{0}", GetInvoiceLogsData.ToString()));

            if (GetInvoiceLogsComplete != null)
            {
                GetInvoiceLogsComplete(GetInvoiceLogsData);
            }
        }
        /// <summary>
        /// Retrieve invoices Without INVOICES_ADMIN permission the results are automatically filtered for only the logged in user&#39;s invoices. It is recomended however that filter_user be added to avoid issues for admin users accidentally getting additional invoices.
        /// </summary>
        /// <param name="filterUser">The id of a user to get invoices for. Automtically added if not being called with admin permissions.</param>
        /// <param name="filterEmail">Filters invoices by customer&#39;s email. Admins only.</param>
        /// <param name="filterFulfillmentStatus">Filters invoices by fulfillment status type. Can be a comma separated list of statuses</param>
        /// <param name="filterPaymentStatus">Filters invoices by payment status type. Can be a comma separated list of statuses</param>
        /// <param name="filterItemName">Filters invoices by item name containing the given string</param>
        /// <param name="filterExternalRef">Filters invoices by external reference.</param>
        /// <param name="filterCreatedDate">Filters invoices by creation date. Multiple values possible for range search. Format: filter_created_date&#x3D;OP,ts&amp;... where OP in (GT, LT, GOE, LOE, EQ) and ts is a unix timestamp in seconds. Ex: filter_created_date&#x3D;GT,1452154258,LT,1554254874</param>
        /// <param name="filterVendorIds">Filters invoices for ones from one of the vendors whose id is in the given comma separated list</param>
        /// <param name="filterCurrency">Filters invoices by currency. ISO3 currency code</param>
        /// <param name="filterShippingStateName">Filters invoices by shipping address: Exact match state name</param>
        /// <param name="filterShippingCountryName">Filters invoices by shipping address: Exact match country name</param>
        /// <param name="filterShipping">Filters invoices by shipping price. Multiple values possible for range search. Format: filter_shipping&#x3D;OP,ts&amp;... where OP in (GT, LT, GOE, LOE, EQ). Ex: filter_shipping&#x3D;GT,14.58,LT,15.54</param>
        /// <param name="filterVendorName">Filters invoices by vendor name starting with given string</param>
        /// <param name="filterSku">Filters invoices by item sku</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetInvoices(int? filterUser, string filterEmail, string filterFulfillmentStatus, string filterPaymentStatus, string filterItemName, string filterExternalRef, string filterCreatedDate, string filterVendorIds, string filterCurrency, string filterShippingStateName, string filterShippingCountryName, string filterShipping, string filterVendorName, string filterSku, int? size, int? page, string order)
        {
            
            mGetInvoicesPath = "/invoices";
            if (!string.IsNullOrEmpty(mGetInvoicesPath))
            {
                mGetInvoicesPath = mGetInvoicesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterUser != null)
            {
                queryParams.Add("filter_user", KnetikClient.ParameterToString(filterUser));
            }

            if (filterEmail != null)
            {
                queryParams.Add("filter_email", KnetikClient.ParameterToString(filterEmail));
            }

            if (filterFulfillmentStatus != null)
            {
                queryParams.Add("filter_fulfillment_status", KnetikClient.ParameterToString(filterFulfillmentStatus));
            }

            if (filterPaymentStatus != null)
            {
                queryParams.Add("filter_payment_status", KnetikClient.ParameterToString(filterPaymentStatus));
            }

            if (filterItemName != null)
            {
                queryParams.Add("filter_item_name", KnetikClient.ParameterToString(filterItemName));
            }

            if (filterExternalRef != null)
            {
                queryParams.Add("filter_external_ref", KnetikClient.ParameterToString(filterExternalRef));
            }

            if (filterCreatedDate != null)
            {
                queryParams.Add("filter_created_date", KnetikClient.ParameterToString(filterCreatedDate));
            }

            if (filterVendorIds != null)
            {
                queryParams.Add("filter_vendor_ids", KnetikClient.ParameterToString(filterVendorIds));
            }

            if (filterCurrency != null)
            {
                queryParams.Add("filter_currency", KnetikClient.ParameterToString(filterCurrency));
            }

            if (filterShippingStateName != null)
            {
                queryParams.Add("filter_shipping_state_name", KnetikClient.ParameterToString(filterShippingStateName));
            }

            if (filterShippingCountryName != null)
            {
                queryParams.Add("filter_shipping_country_name", KnetikClient.ParameterToString(filterShippingCountryName));
            }

            if (filterShipping != null)
            {
                queryParams.Add("filter_shipping", KnetikClient.ParameterToString(filterShipping));
            }

            if (filterVendorName != null)
            {
                queryParams.Add("filter_vendor_name", KnetikClient.ParameterToString(filterVendorName));
            }

            if (filterSku != null)
            {
                queryParams.Add("filter_sku", KnetikClient.ParameterToString(filterSku));
            }

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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetInvoicesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetInvoicesStartTime, mGetInvoicesPath, "Sending server request...");

            // make the HTTP request
            mGetInvoicesCoroutine.ResponseReceived += GetInvoicesCallback;
            mGetInvoicesCoroutine.Start(mGetInvoicesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetInvoicesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetInvoices: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetInvoices: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetInvoicesData = (PageResourceInvoiceResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceInvoiceResource), response.Headers);
            KnetikLogger.LogResponse(mGetInvoicesStartTime, mGetInvoicesPath, string.Format("Response received successfully:\n{0}", GetInvoicesData.ToString()));

            if (GetInvoicesComplete != null)
            {
                GetInvoicesComplete(GetInvoicesData);
            }
        }
        /// <summary>
        /// Lists available payment statuses 
        /// </summary>
        public void GetPaymentStatuses()
        {
            
            mGetPaymentStatusesPath = "/invoices/payment-statuses";
            if (!string.IsNullOrEmpty(mGetPaymentStatusesPath))
            {
                mGetPaymentStatusesPath = mGetPaymentStatusesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetPaymentStatusesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetPaymentStatusesStartTime, mGetPaymentStatusesPath, "Sending server request...");

            // make the HTTP request
            mGetPaymentStatusesCoroutine.ResponseReceived += GetPaymentStatusesCallback;
            mGetPaymentStatusesCoroutine.Start(mGetPaymentStatusesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetPaymentStatusesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPaymentStatuses: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPaymentStatuses: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetPaymentStatusesData = (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetPaymentStatusesStartTime, mGetPaymentStatusesPath, string.Format("Response received successfully:\n{0}", GetPaymentStatusesData.ToString()));

            if (GetPaymentStatusesComplete != null)
            {
                GetPaymentStatusesComplete(GetPaymentStatusesData);
            }
        }
        /// <summary>
        /// Pay an invoice using a saved payment method 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="request">The payment method details. Will default to the appropriate user&#39;s wallet in the invoice currency if ommited.</param>
        public void PayInvoice(int? id, PayBySavedMethodRequest request)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling PayInvoice");
            }
            
            mPayInvoicePath = "/invoices/{id}/payments";
            if (!string.IsNullOrEmpty(mPayInvoicePath))
            {
                mPayInvoicePath = mPayInvoicePath.Replace("{format}", "json");
            }
            mPayInvoicePath = mPayInvoicePath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mPayInvoiceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mPayInvoiceStartTime, mPayInvoicePath, "Sending server request...");

            // make the HTTP request
            mPayInvoiceCoroutine.ResponseReceived += PayInvoiceCallback;
            mPayInvoiceCoroutine.Start(mPayInvoicePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void PayInvoiceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling PayInvoice: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling PayInvoice: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mPayInvoiceStartTime, mPayInvoicePath, "Response received successfully.");
            if (PayInvoiceComplete != null)
            {
                PayInvoiceComplete();
            }
        }
        /// <summary>
        /// Set the fulfillment status of a bundled invoice item This allows external fulfillment systems to report success or failure. Fulfillment status changes are restricted by a specific flow determining which status can lead to which.
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="bundleSku">The sku of the bundle in the invoice that contains the given target</param>
        /// <param name="sku">The sku of an item in the bundle in the invoice</param>
        /// <param name="status">The new fulfillment status for the item. Additional options may be available based on configuration.  Allowable values:  &#39;unfulfilled&#39;, &#39;fulfilled&#39;, &#39;not fulfillable&#39;, &#39;failed&#39;, &#39;processing&#39;, &#39;failed_permanent&#39;, &#39;delayed&#39;</param>
        public void SetBundledInvoiceItemFulfillmentStatus(int? id, string bundleSku, string sku, StringWrapper status)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SetBundledInvoiceItemFulfillmentStatus");
            }
            // verify the required parameter 'bundleSku' is set
            if (bundleSku == null)
            {
                throw new KnetikException(400, "Missing required parameter 'bundleSku' when calling SetBundledInvoiceItemFulfillmentStatus");
            }
            // verify the required parameter 'sku' is set
            if (sku == null)
            {
                throw new KnetikException(400, "Missing required parameter 'sku' when calling SetBundledInvoiceItemFulfillmentStatus");
            }
            // verify the required parameter 'status' is set
            if (status == null)
            {
                throw new KnetikException(400, "Missing required parameter 'status' when calling SetBundledInvoiceItemFulfillmentStatus");
            }
            
            mSetBundledInvoiceItemFulfillmentStatusPath = "/invoices/{id}/items/{bundleSku}/bundled-skus/{sku}/fulfillment-status";
            if (!string.IsNullOrEmpty(mSetBundledInvoiceItemFulfillmentStatusPath))
            {
                mSetBundledInvoiceItemFulfillmentStatusPath = mSetBundledInvoiceItemFulfillmentStatusPath.Replace("{format}", "json");
            }
            mSetBundledInvoiceItemFulfillmentStatusPath = mSetBundledInvoiceItemFulfillmentStatusPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mSetBundledInvoiceItemFulfillmentStatusPath = mSetBundledInvoiceItemFulfillmentStatusPath.Replace("{" + "bundleSku" + "}", KnetikClient.ParameterToString(bundleSku));
mSetBundledInvoiceItemFulfillmentStatusPath = mSetBundledInvoiceItemFulfillmentStatusPath.Replace("{" + "sku" + "}", KnetikClient.ParameterToString(sku));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(status); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetBundledInvoiceItemFulfillmentStatusStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetBundledInvoiceItemFulfillmentStatusStartTime, mSetBundledInvoiceItemFulfillmentStatusPath, "Sending server request...");

            // make the HTTP request
            mSetBundledInvoiceItemFulfillmentStatusCoroutine.ResponseReceived += SetBundledInvoiceItemFulfillmentStatusCallback;
            mSetBundledInvoiceItemFulfillmentStatusCoroutine.Start(mSetBundledInvoiceItemFulfillmentStatusPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetBundledInvoiceItemFulfillmentStatusCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetBundledInvoiceItemFulfillmentStatus: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetBundledInvoiceItemFulfillmentStatus: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetBundledInvoiceItemFulfillmentStatusStartTime, mSetBundledInvoiceItemFulfillmentStatusPath, "Response received successfully.");
            if (SetBundledInvoiceItemFulfillmentStatusComplete != null)
            {
                SetBundledInvoiceItemFulfillmentStatusComplete();
            }
        }
        /// <summary>
        /// Set the external reference of an invoice 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="externalRef">External reference info</param>
        public void SetExternalRef(int? id, StringWrapper externalRef)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SetExternalRef");
            }
            
            mSetExternalRefPath = "/invoices/{id}/external-ref";
            if (!string.IsNullOrEmpty(mSetExternalRefPath))
            {
                mSetExternalRefPath = mSetExternalRefPath.Replace("{format}", "json");
            }
            mSetExternalRefPath = mSetExternalRefPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(externalRef); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetExternalRefStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetExternalRefStartTime, mSetExternalRefPath, "Sending server request...");

            // make the HTTP request
            mSetExternalRefCoroutine.ResponseReceived += SetExternalRefCallback;
            mSetExternalRefCoroutine.Start(mSetExternalRefPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetExternalRefCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetExternalRef: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetExternalRef: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetExternalRefStartTime, mSetExternalRefPath, "Response received successfully.");
            if (SetExternalRefComplete != null)
            {
                SetExternalRefComplete();
            }
        }
        /// <summary>
        /// Set the fulfillment status of an invoice item This allows external fulfillment systems to report success or failure. Fulfillment status changes are restricted by a specific flow determining which status can lead to which.
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="sku">The sku of an item in the invoice</param>
        /// <param name="status">The new fulfillment status for the item. Additional options may be available based on configuration.  Allowable values:  &#39;unfulfilled&#39;, &#39;fulfilled&#39;, &#39;not fulfillable&#39;, &#39;failed&#39;, &#39;processing&#39;, &#39;failed_permanent&#39;, &#39;delayed&#39;</param>
        public void SetInvoiceItemFulfillmentStatus(int? id, string sku, StringWrapper status)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SetInvoiceItemFulfillmentStatus");
            }
            // verify the required parameter 'sku' is set
            if (sku == null)
            {
                throw new KnetikException(400, "Missing required parameter 'sku' when calling SetInvoiceItemFulfillmentStatus");
            }
            // verify the required parameter 'status' is set
            if (status == null)
            {
                throw new KnetikException(400, "Missing required parameter 'status' when calling SetInvoiceItemFulfillmentStatus");
            }
            
            mSetInvoiceItemFulfillmentStatusPath = "/invoices/{id}/items/{sku}/fulfillment-status";
            if (!string.IsNullOrEmpty(mSetInvoiceItemFulfillmentStatusPath))
            {
                mSetInvoiceItemFulfillmentStatusPath = mSetInvoiceItemFulfillmentStatusPath.Replace("{format}", "json");
            }
            mSetInvoiceItemFulfillmentStatusPath = mSetInvoiceItemFulfillmentStatusPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mSetInvoiceItemFulfillmentStatusPath = mSetInvoiceItemFulfillmentStatusPath.Replace("{" + "sku" + "}", KnetikClient.ParameterToString(sku));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(status); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetInvoiceItemFulfillmentStatusStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetInvoiceItemFulfillmentStatusStartTime, mSetInvoiceItemFulfillmentStatusPath, "Sending server request...");

            // make the HTTP request
            mSetInvoiceItemFulfillmentStatusCoroutine.ResponseReceived += SetInvoiceItemFulfillmentStatusCallback;
            mSetInvoiceItemFulfillmentStatusCoroutine.Start(mSetInvoiceItemFulfillmentStatusPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetInvoiceItemFulfillmentStatusCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetInvoiceItemFulfillmentStatus: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetInvoiceItemFulfillmentStatus: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetInvoiceItemFulfillmentStatusStartTime, mSetInvoiceItemFulfillmentStatusPath, "Response received successfully.");
            if (SetInvoiceItemFulfillmentStatusComplete != null)
            {
                SetInvoiceItemFulfillmentStatusComplete();
            }
        }
        /// <summary>
        /// Set the order notes of an invoice 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="orderNotes">Payment status info</param>
        public void SetOrderNotes(int? id, StringWrapper orderNotes)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SetOrderNotes");
            }
            
            mSetOrderNotesPath = "/invoices/{id}/order-notes";
            if (!string.IsNullOrEmpty(mSetOrderNotesPath))
            {
                mSetOrderNotesPath = mSetOrderNotesPath.Replace("{format}", "json");
            }
            mSetOrderNotesPath = mSetOrderNotesPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(orderNotes); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetOrderNotesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetOrderNotesStartTime, mSetOrderNotesPath, "Sending server request...");

            // make the HTTP request
            mSetOrderNotesCoroutine.ResponseReceived += SetOrderNotesCallback;
            mSetOrderNotesCoroutine.Start(mSetOrderNotesPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetOrderNotesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetOrderNotes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetOrderNotes: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetOrderNotesStartTime, mSetOrderNotesPath, "Response received successfully.");
            if (SetOrderNotesComplete != null)
            {
                SetOrderNotesComplete();
            }
        }
        /// <summary>
        /// Set the payment status of an invoice This may trigger fulfillment if setting the status to &#39;paid&#39;. This is mainly intended to support external payment systems that cannot be incorporated into the payment method system. Payment status changes are restricted by a specific flow determining which status can lead to which.
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="request">Payment status info</param>
        public void SetPaymentStatus(int? id, InvoicePaymentStatusRequest request)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SetPaymentStatus");
            }
            
            mSetPaymentStatusPath = "/invoices/{id}/payment-status";
            if (!string.IsNullOrEmpty(mSetPaymentStatusPath))
            {
                mSetPaymentStatusPath = mSetPaymentStatusPath.Replace("{format}", "json");
            }
            mSetPaymentStatusPath = mSetPaymentStatusPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetPaymentStatusStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetPaymentStatusStartTime, mSetPaymentStatusPath, "Sending server request...");

            // make the HTTP request
            mSetPaymentStatusCoroutine.ResponseReceived += SetPaymentStatusCallback;
            mSetPaymentStatusCoroutine.Start(mSetPaymentStatusPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetPaymentStatusCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetPaymentStatus: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetPaymentStatus: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetPaymentStatusStartTime, mSetPaymentStatusPath, "Response received successfully.");
            if (SetPaymentStatusComplete != null)
            {
                SetPaymentStatusComplete();
            }
        }
        /// <summary>
        /// Set or update billing info 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="billingInfoRequest">Address info</param>
        public void UpdateBillingInfo(int? id, AddressResource billingInfoRequest)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateBillingInfo");
            }
            
            mUpdateBillingInfoPath = "/invoices/{id}/billing-address";
            if (!string.IsNullOrEmpty(mUpdateBillingInfoPath))
            {
                mUpdateBillingInfoPath = mUpdateBillingInfoPath.Replace("{format}", "json");
            }
            mUpdateBillingInfoPath = mUpdateBillingInfoPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.Serialize(billingInfoRequest); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateBillingInfoStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateBillingInfoStartTime, mUpdateBillingInfoPath, "Sending server request...");

            // make the HTTP request
            mUpdateBillingInfoCoroutine.ResponseReceived += UpdateBillingInfoCallback;
            mUpdateBillingInfoCoroutine.Start(mUpdateBillingInfoPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateBillingInfoCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBillingInfo: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateBillingInfo: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateBillingInfoStartTime, mUpdateBillingInfoPath, "Response received successfully.");
            if (UpdateBillingInfoComplete != null)
            {
                UpdateBillingInfoComplete();
            }
        }
    }
}
