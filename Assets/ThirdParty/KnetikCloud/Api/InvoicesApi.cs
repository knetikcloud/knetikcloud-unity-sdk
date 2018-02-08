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
    public interface IInvoicesApi
    {
        List<InvoiceResource> CreateInvoiceData { get; }

        /// <summary>
        /// Create an invoice Create an invoice(s) by providing a cart GUID. Note that there may be multiple invoices created, one per vendor. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_USER or INVOICES_ADMIN
        /// </summary>
        /// <param name="req">Invoice to be created</param>
        void CreateInvoice(InvoiceCreateRequest req);

        List<string> GetFulFillmentStatusesData { get; }

        /// <summary>
        /// Lists available fulfillment statuses &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        void GetFulFillmentStatuses();

        InvoiceResource GetInvoiceData { get; }

        /// <summary>
        /// Retrieve an invoice &lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_USER and owner, or INVOICES_ADMIN
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        void GetInvoice(int? id);

        PageResourceInvoiceLogEntry GetInvoiceLogsData { get; }

        /// <summary>
        /// List invoice logs &lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_USER and owner, or INVOICES_ADMIN
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetInvoiceLogs(int? id, int? size, int? page);

        PageResourceInvoiceResource GetInvoicesData { get; }

        /// <summary>
        /// Retrieve invoices Without INVOICES_ADMIN permission the results are automatically filtered for only the logged in user&#39;s invoices. It is recomended however that filter_user be added to avoid issues for admin users accidentally getting additional invoices. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_USER and owner, or INVOICES_ADMIN
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

        List<string> GetPaymentStatusesData { get; }

        /// <summary>
        /// Lists available payment statuses &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        void GetPaymentStatuses();

        

        /// <summary>
        /// Pay an invoice using a saved payment method &lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_USER and owner, or INVOICES_ADMIN
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="request">The payment method details. Will default to the appropriate user&#39;s wallet in the invoice currency if ommited.</param>
        void PayInvoice(int? id, PayBySavedMethodRequest request);

        

        /// <summary>
        /// Set the fulfillment status of a bundled invoice item This allows external fulfillment systems to report success or failure. Fulfillment status changes are restricted by a specific flow determining which status can lead to which. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_ADMIN
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="bundleSku">The sku of the bundle in the invoice that contains the given target</param>
        /// <param name="sku">The sku of an item in the bundle in the invoice</param>
        /// <param name="status">The new fulfillment status for the item. Additional options may be available based on configuration.  Allowable values:  &#39;unfulfilled&#39;, &#39;fulfilled&#39;, &#39;not fulfillable&#39;, &#39;failed&#39;, &#39;processing&#39;, &#39;failed_permanent&#39;, &#39;delayed&#39;</param>
        void SetBundledInvoiceItemFulfillmentStatus(int? id, string bundleSku, string sku, StringWrapper status);

        

        /// <summary>
        /// Set the external reference of an invoice &lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_ADMIN
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="externalRef">External reference info</param>
        void SetExternalRef(int? id, StringWrapper externalRef);

        

        /// <summary>
        /// Set the fulfillment status of an invoice item This allows external fulfillment systems to report success or failure. Fulfillment status changes are restricted by a specific flow determining which status can lead to which. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_ADMIN
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="sku">The sku of an item in the invoice</param>
        /// <param name="status">The new fulfillment status for the item. Additional options may be available based on configuration.  Allowable values:  &#39;unfulfilled&#39;, &#39;fulfilled&#39;, &#39;not fulfillable&#39;, &#39;failed&#39;, &#39;processing&#39;, &#39;failed_permanent&#39;, &#39;delayed&#39;</param>
        void SetInvoiceItemFulfillmentStatus(int? id, string sku, StringWrapper status);

        

        /// <summary>
        /// Set the order notes of an invoice &lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_ADMIN
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="orderNotes">Payment status info</param>
        void SetOrderNotes(int? id, StringWrapper orderNotes);

        

        /// <summary>
        /// Set the payment status of an invoice This may trigger fulfillment if setting the status to &#39;paid&#39;. This is mainly intended to support external payment systems that cannot be incorporated into the payment method system. Payment status changes are restricted by a specific flow determining which status can lead to which. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_ADMIN
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="request">Payment status info</param>
        void SetPaymentStatus(int? id, InvoicePaymentStatusRequest request);

        

        /// <summary>
        /// Set or update billing info &lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_USER and owner, or INVOICES_ADMIN
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="billingInfoRequest">Address info</param>
        void UpdateBillingInfo(int? id, AddressResource billingInfoRequest);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class InvoicesApi : IInvoicesApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateInvoiceResponseContext;
        private DateTime mCreateInvoiceStartTime;
        private readonly KnetikResponseContext mGetFulFillmentStatusesResponseContext;
        private DateTime mGetFulFillmentStatusesStartTime;
        private readonly KnetikResponseContext mGetInvoiceResponseContext;
        private DateTime mGetInvoiceStartTime;
        private readonly KnetikResponseContext mGetInvoiceLogsResponseContext;
        private DateTime mGetInvoiceLogsStartTime;
        private readonly KnetikResponseContext mGetInvoicesResponseContext;
        private DateTime mGetInvoicesStartTime;
        private readonly KnetikResponseContext mGetPaymentStatusesResponseContext;
        private DateTime mGetPaymentStatusesStartTime;
        private readonly KnetikResponseContext mPayInvoiceResponseContext;
        private DateTime mPayInvoiceStartTime;
        private readonly KnetikResponseContext mSetBundledInvoiceItemFulfillmentStatusResponseContext;
        private DateTime mSetBundledInvoiceItemFulfillmentStatusStartTime;
        private readonly KnetikResponseContext mSetExternalRefResponseContext;
        private DateTime mSetExternalRefStartTime;
        private readonly KnetikResponseContext mSetInvoiceItemFulfillmentStatusResponseContext;
        private DateTime mSetInvoiceItemFulfillmentStatusStartTime;
        private readonly KnetikResponseContext mSetOrderNotesResponseContext;
        private DateTime mSetOrderNotesStartTime;
        private readonly KnetikResponseContext mSetPaymentStatusResponseContext;
        private DateTime mSetPaymentStatusStartTime;
        private readonly KnetikResponseContext mUpdateBillingInfoResponseContext;
        private DateTime mUpdateBillingInfoStartTime;

        public List<InvoiceResource> CreateInvoiceData { get; private set; }
        public delegate void CreateInvoiceCompleteDelegate(long responseCode, List<InvoiceResource> response);
        public CreateInvoiceCompleteDelegate CreateInvoiceComplete;

        public List<string> GetFulFillmentStatusesData { get; private set; }
        public delegate void GetFulFillmentStatusesCompleteDelegate(long responseCode, List<string> response);
        public GetFulFillmentStatusesCompleteDelegate GetFulFillmentStatusesComplete;

        public InvoiceResource GetInvoiceData { get; private set; }
        public delegate void GetInvoiceCompleteDelegate(long responseCode, InvoiceResource response);
        public GetInvoiceCompleteDelegate GetInvoiceComplete;

        public PageResourceInvoiceLogEntry GetInvoiceLogsData { get; private set; }
        public delegate void GetInvoiceLogsCompleteDelegate(long responseCode, PageResourceInvoiceLogEntry response);
        public GetInvoiceLogsCompleteDelegate GetInvoiceLogsComplete;

        public PageResourceInvoiceResource GetInvoicesData { get; private set; }
        public delegate void GetInvoicesCompleteDelegate(long responseCode, PageResourceInvoiceResource response);
        public GetInvoicesCompleteDelegate GetInvoicesComplete;

        public List<string> GetPaymentStatusesData { get; private set; }
        public delegate void GetPaymentStatusesCompleteDelegate(long responseCode, List<string> response);
        public GetPaymentStatusesCompleteDelegate GetPaymentStatusesComplete;

        public delegate void PayInvoiceCompleteDelegate(long responseCode);
        public PayInvoiceCompleteDelegate PayInvoiceComplete;

        public delegate void SetBundledInvoiceItemFulfillmentStatusCompleteDelegate(long responseCode);
        public SetBundledInvoiceItemFulfillmentStatusCompleteDelegate SetBundledInvoiceItemFulfillmentStatusComplete;

        public delegate void SetExternalRefCompleteDelegate(long responseCode);
        public SetExternalRefCompleteDelegate SetExternalRefComplete;

        public delegate void SetInvoiceItemFulfillmentStatusCompleteDelegate(long responseCode);
        public SetInvoiceItemFulfillmentStatusCompleteDelegate SetInvoiceItemFulfillmentStatusComplete;

        public delegate void SetOrderNotesCompleteDelegate(long responseCode);
        public SetOrderNotesCompleteDelegate SetOrderNotesComplete;

        public delegate void SetPaymentStatusCompleteDelegate(long responseCode);
        public SetPaymentStatusCompleteDelegate SetPaymentStatusComplete;

        public delegate void UpdateBillingInfoCompleteDelegate(long responseCode);
        public UpdateBillingInfoCompleteDelegate UpdateBillingInfoComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public InvoicesApi()
        {
            mCreateInvoiceResponseContext = new KnetikResponseContext();
            mCreateInvoiceResponseContext.ResponseReceived += OnCreateInvoiceResponse;
            mGetFulFillmentStatusesResponseContext = new KnetikResponseContext();
            mGetFulFillmentStatusesResponseContext.ResponseReceived += OnGetFulFillmentStatusesResponse;
            mGetInvoiceResponseContext = new KnetikResponseContext();
            mGetInvoiceResponseContext.ResponseReceived += OnGetInvoiceResponse;
            mGetInvoiceLogsResponseContext = new KnetikResponseContext();
            mGetInvoiceLogsResponseContext.ResponseReceived += OnGetInvoiceLogsResponse;
            mGetInvoicesResponseContext = new KnetikResponseContext();
            mGetInvoicesResponseContext.ResponseReceived += OnGetInvoicesResponse;
            mGetPaymentStatusesResponseContext = new KnetikResponseContext();
            mGetPaymentStatusesResponseContext.ResponseReceived += OnGetPaymentStatusesResponse;
            mPayInvoiceResponseContext = new KnetikResponseContext();
            mPayInvoiceResponseContext.ResponseReceived += OnPayInvoiceResponse;
            mSetBundledInvoiceItemFulfillmentStatusResponseContext = new KnetikResponseContext();
            mSetBundledInvoiceItemFulfillmentStatusResponseContext.ResponseReceived += OnSetBundledInvoiceItemFulfillmentStatusResponse;
            mSetExternalRefResponseContext = new KnetikResponseContext();
            mSetExternalRefResponseContext.ResponseReceived += OnSetExternalRefResponse;
            mSetInvoiceItemFulfillmentStatusResponseContext = new KnetikResponseContext();
            mSetInvoiceItemFulfillmentStatusResponseContext.ResponseReceived += OnSetInvoiceItemFulfillmentStatusResponse;
            mSetOrderNotesResponseContext = new KnetikResponseContext();
            mSetOrderNotesResponseContext.ResponseReceived += OnSetOrderNotesResponse;
            mSetPaymentStatusResponseContext = new KnetikResponseContext();
            mSetPaymentStatusResponseContext.ResponseReceived += OnSetPaymentStatusResponse;
            mUpdateBillingInfoResponseContext = new KnetikResponseContext();
            mUpdateBillingInfoResponseContext.ResponseReceived += OnUpdateBillingInfoResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create an invoice Create an invoice(s) by providing a cart GUID. Note that there may be multiple invoices created, one per vendor. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_USER or INVOICES_ADMIN
        /// </summary>
        /// <param name="req">Invoice to be created</param>
        public void CreateInvoice(InvoiceCreateRequest req)
        {
            
            mWebCallEvent.WebPath = "/invoices";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(req); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateInvoiceStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateInvoiceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateInvoiceStartTime, "CreateInvoice", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateInvoiceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateInvoice: " + response.Error);
            }

            CreateInvoiceData = (List<InvoiceResource>) KnetikClient.Deserialize(response.Content, typeof(List<InvoiceResource>), response.Headers);
            KnetikLogger.LogResponse(mCreateInvoiceStartTime, "CreateInvoice", string.Format("Response received successfully:\n{0}", CreateInvoiceData));

            if (CreateInvoiceComplete != null)
            {
                CreateInvoiceComplete(response.ResponseCode, CreateInvoiceData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Lists available fulfillment statuses &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        public void GetFulFillmentStatuses()
        {
            
            mWebCallEvent.WebPath = "/invoices/fulfillment-statuses";
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
            mGetFulFillmentStatusesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetFulFillmentStatusesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetFulFillmentStatusesStartTime, "GetFulFillmentStatuses", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetFulFillmentStatusesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetFulFillmentStatuses: " + response.Error);
            }

            GetFulFillmentStatusesData = (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetFulFillmentStatusesStartTime, "GetFulFillmentStatuses", string.Format("Response received successfully:\n{0}", GetFulFillmentStatusesData));

            if (GetFulFillmentStatusesComplete != null)
            {
                GetFulFillmentStatusesComplete(response.ResponseCode, GetFulFillmentStatusesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve an invoice &lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_USER and owner, or INVOICES_ADMIN
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        public void GetInvoice(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetInvoice");
            }
            
            mWebCallEvent.WebPath = "/invoices/{id}";
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
            mGetInvoiceStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetInvoiceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetInvoiceStartTime, "GetInvoice", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetInvoiceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetInvoice: " + response.Error);
            }

            GetInvoiceData = (InvoiceResource) KnetikClient.Deserialize(response.Content, typeof(InvoiceResource), response.Headers);
            KnetikLogger.LogResponse(mGetInvoiceStartTime, "GetInvoice", string.Format("Response received successfully:\n{0}", GetInvoiceData));

            if (GetInvoiceComplete != null)
            {
                GetInvoiceComplete(response.ResponseCode, GetInvoiceData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List invoice logs &lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_USER and owner, or INVOICES_ADMIN
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
            
            mWebCallEvent.WebPath = "/invoices/{id}/logs";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

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

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetInvoiceLogsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetInvoiceLogsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetInvoiceLogsStartTime, "GetInvoiceLogs", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetInvoiceLogsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetInvoiceLogs: " + response.Error);
            }

            GetInvoiceLogsData = (PageResourceInvoiceLogEntry) KnetikClient.Deserialize(response.Content, typeof(PageResourceInvoiceLogEntry), response.Headers);
            KnetikLogger.LogResponse(mGetInvoiceLogsStartTime, "GetInvoiceLogs", string.Format("Response received successfully:\n{0}", GetInvoiceLogsData));

            if (GetInvoiceLogsComplete != null)
            {
                GetInvoiceLogsComplete(response.ResponseCode, GetInvoiceLogsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve invoices Without INVOICES_ADMIN permission the results are automatically filtered for only the logged in user&#39;s invoices. It is recomended however that filter_user be added to avoid issues for admin users accidentally getting additional invoices. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_USER and owner, or INVOICES_ADMIN
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
            
            mWebCallEvent.WebPath = "/invoices";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterUser != null)
            {
                mWebCallEvent.QueryParams["filter_user"] = KnetikClient.ParameterToString(filterUser);
            }

            if (filterEmail != null)
            {
                mWebCallEvent.QueryParams["filter_email"] = KnetikClient.ParameterToString(filterEmail);
            }

            if (filterFulfillmentStatus != null)
            {
                mWebCallEvent.QueryParams["filter_fulfillment_status"] = KnetikClient.ParameterToString(filterFulfillmentStatus);
            }

            if (filterPaymentStatus != null)
            {
                mWebCallEvent.QueryParams["filter_payment_status"] = KnetikClient.ParameterToString(filterPaymentStatus);
            }

            if (filterItemName != null)
            {
                mWebCallEvent.QueryParams["filter_item_name"] = KnetikClient.ParameterToString(filterItemName);
            }

            if (filterExternalRef != null)
            {
                mWebCallEvent.QueryParams["filter_external_ref"] = KnetikClient.ParameterToString(filterExternalRef);
            }

            if (filterCreatedDate != null)
            {
                mWebCallEvent.QueryParams["filter_created_date"] = KnetikClient.ParameterToString(filterCreatedDate);
            }

            if (filterVendorIds != null)
            {
                mWebCallEvent.QueryParams["filter_vendor_ids"] = KnetikClient.ParameterToString(filterVendorIds);
            }

            if (filterCurrency != null)
            {
                mWebCallEvent.QueryParams["filter_currency"] = KnetikClient.ParameterToString(filterCurrency);
            }

            if (filterShippingStateName != null)
            {
                mWebCallEvent.QueryParams["filter_shipping_state_name"] = KnetikClient.ParameterToString(filterShippingStateName);
            }

            if (filterShippingCountryName != null)
            {
                mWebCallEvent.QueryParams["filter_shipping_country_name"] = KnetikClient.ParameterToString(filterShippingCountryName);
            }

            if (filterShipping != null)
            {
                mWebCallEvent.QueryParams["filter_shipping"] = KnetikClient.ParameterToString(filterShipping);
            }

            if (filterVendorName != null)
            {
                mWebCallEvent.QueryParams["filter_vendor_name"] = KnetikClient.ParameterToString(filterVendorName);
            }

            if (filterSku != null)
            {
                mWebCallEvent.QueryParams["filter_sku"] = KnetikClient.ParameterToString(filterSku);
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
            mGetInvoicesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetInvoicesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetInvoicesStartTime, "GetInvoices", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetInvoicesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetInvoices: " + response.Error);
            }

            GetInvoicesData = (PageResourceInvoiceResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceInvoiceResource), response.Headers);
            KnetikLogger.LogResponse(mGetInvoicesStartTime, "GetInvoices", string.Format("Response received successfully:\n{0}", GetInvoicesData));

            if (GetInvoicesComplete != null)
            {
                GetInvoicesComplete(response.ResponseCode, GetInvoicesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Lists available payment statuses &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        public void GetPaymentStatuses()
        {
            
            mWebCallEvent.WebPath = "/invoices/payment-statuses";
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
            mGetPaymentStatusesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetPaymentStatusesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetPaymentStatusesStartTime, "GetPaymentStatuses", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetPaymentStatusesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetPaymentStatuses: " + response.Error);
            }

            GetPaymentStatusesData = (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetPaymentStatusesStartTime, "GetPaymentStatuses", string.Format("Response received successfully:\n{0}", GetPaymentStatusesData));

            if (GetPaymentStatusesComplete != null)
            {
                GetPaymentStatusesComplete(response.ResponseCode, GetPaymentStatusesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Pay an invoice using a saved payment method &lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_USER and owner, or INVOICES_ADMIN
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
            
            mWebCallEvent.WebPath = "/invoices/{id}/payments";
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
            mPayInvoiceStartTime = DateTime.Now;
            mWebCallEvent.Context = mPayInvoiceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mPayInvoiceStartTime, "PayInvoice", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnPayInvoiceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling PayInvoice: " + response.Error);
            }

            KnetikLogger.LogResponse(mPayInvoiceStartTime, "PayInvoice", "Response received successfully.");
            if (PayInvoiceComplete != null)
            {
                PayInvoiceComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set the fulfillment status of a bundled invoice item This allows external fulfillment systems to report success or failure. Fulfillment status changes are restricted by a specific flow determining which status can lead to which. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_ADMIN
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
            
            mWebCallEvent.WebPath = "/invoices/{id}/items/{bundleSku}/bundled-skus/{sku}/fulfillment-status";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "bundleSku" + "}", KnetikClient.ParameterToString(bundleSku));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "sku" + "}", KnetikClient.ParameterToString(sku));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(status); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetBundledInvoiceItemFulfillmentStatusStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetBundledInvoiceItemFulfillmentStatusResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetBundledInvoiceItemFulfillmentStatusStartTime, "SetBundledInvoiceItemFulfillmentStatus", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetBundledInvoiceItemFulfillmentStatusResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetBundledInvoiceItemFulfillmentStatus: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetBundledInvoiceItemFulfillmentStatusStartTime, "SetBundledInvoiceItemFulfillmentStatus", "Response received successfully.");
            if (SetBundledInvoiceItemFulfillmentStatusComplete != null)
            {
                SetBundledInvoiceItemFulfillmentStatusComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set the external reference of an invoice &lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_ADMIN
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
            
            mWebCallEvent.WebPath = "/invoices/{id}/external-ref";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(externalRef); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetExternalRefStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetExternalRefResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetExternalRefStartTime, "SetExternalRef", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetExternalRefResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetExternalRef: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetExternalRefStartTime, "SetExternalRef", "Response received successfully.");
            if (SetExternalRefComplete != null)
            {
                SetExternalRefComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set the fulfillment status of an invoice item This allows external fulfillment systems to report success or failure. Fulfillment status changes are restricted by a specific flow determining which status can lead to which. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_ADMIN
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
            
            mWebCallEvent.WebPath = "/invoices/{id}/items/{sku}/fulfillment-status";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "sku" + "}", KnetikClient.ParameterToString(sku));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(status); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetInvoiceItemFulfillmentStatusStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetInvoiceItemFulfillmentStatusResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetInvoiceItemFulfillmentStatusStartTime, "SetInvoiceItemFulfillmentStatus", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetInvoiceItemFulfillmentStatusResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetInvoiceItemFulfillmentStatus: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetInvoiceItemFulfillmentStatusStartTime, "SetInvoiceItemFulfillmentStatus", "Response received successfully.");
            if (SetInvoiceItemFulfillmentStatusComplete != null)
            {
                SetInvoiceItemFulfillmentStatusComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set the order notes of an invoice &lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_ADMIN
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
            
            mWebCallEvent.WebPath = "/invoices/{id}/order-notes";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(orderNotes); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetOrderNotesStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetOrderNotesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetOrderNotesStartTime, "SetOrderNotes", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetOrderNotesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetOrderNotes: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetOrderNotesStartTime, "SetOrderNotes", "Response received successfully.");
            if (SetOrderNotesComplete != null)
            {
                SetOrderNotesComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set the payment status of an invoice This may trigger fulfillment if setting the status to &#39;paid&#39;. This is mainly intended to support external payment systems that cannot be incorporated into the payment method system. Payment status changes are restricted by a specific flow determining which status can lead to which. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_ADMIN
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
            
            mWebCallEvent.WebPath = "/invoices/{id}/payment-status";
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
            mSetPaymentStatusStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetPaymentStatusResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetPaymentStatusStartTime, "SetPaymentStatus", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetPaymentStatusResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetPaymentStatus: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetPaymentStatusStartTime, "SetPaymentStatus", "Response received successfully.");
            if (SetPaymentStatusComplete != null)
            {
                SetPaymentStatusComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set or update billing info &lt;b&gt;Permissions Needed:&lt;/b&gt; INVOICES_USER and owner, or INVOICES_ADMIN
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
            
            mWebCallEvent.WebPath = "/invoices/{id}/billing-address";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(billingInfoRequest); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateBillingInfoStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateBillingInfoResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateBillingInfoStartTime, "UpdateBillingInfo", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateBillingInfoResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateBillingInfo: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateBillingInfoStartTime, "UpdateBillingInfo", "Response received successfully.");
            if (UpdateBillingInfoComplete != null)
            {
                UpdateBillingInfoComplete(response.ResponseCode);
            }
        }

    }
}
