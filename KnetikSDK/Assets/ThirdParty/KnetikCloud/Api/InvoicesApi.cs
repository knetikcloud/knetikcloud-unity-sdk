using System;
using System.Collections.Generic;
using RestSharp;
using com.knetikcloud.Client;
using com.knetikcloud.Model;
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
        /// <summary>
        /// Create an invoice Create an invoice(s) by providing a cart GUID. Note that there may be multiple invoices created, one per vendor.
        /// </summary>
        /// <param name="req">Invoice to be created</param>
        /// <returns>List&lt;InvoiceResource&gt;</returns>
        List<InvoiceResource> CreateInvoice (InvoiceCreateRequest req);
        /// <summary>
        /// Lists available fulfillment statuses 
        /// </summary>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetFulFillmentStatuses ();
        /// <summary>
        /// Retrieve an invoice 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <returns>InvoiceResource</returns>
        InvoiceResource GetInvoice (int? id);
        /// <summary>
        /// List invoice logs 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceInvoiceLogEntry</returns>
        PageResourceInvoiceLogEntry GetInvoiceLogs (int? id, int? size, int? page);
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
        /// <returns>PageResourceInvoiceResource</returns>
        PageResourceInvoiceResource GetInvoices (int? filterUser, string filterEmail, string filterFulfillmentStatus, string filterPaymentStatus, string filterItemName, string filterExternalRef, string filterCreatedDate, string filterVendorIds, string filterCurrency, string filterShippingStateName, string filterShippingCountryName, string filterShipping, string filterVendorName, string filterSku, int? size, int? page, string order);
        /// <summary>
        /// Lists available payment statuses 
        /// </summary>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetPaymentStatuses ();
        /// <summary>
        /// Pay an invoice using a saved payment method 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="request">The payment method details. Will default to the appropriate user&#39;s wallet in the invoice currency if ommited.</param>
        /// <returns></returns>
        void PayInvoice (int? id, PayBySavedMethodRequest request);
        /// <summary>
        /// Set the fulfillment status of a bundled invoice item This allows external fulfillment systems to report success or failure. Fulfillment status changes are restricted by a specific flow determining which status can lead to which.
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="bundleSku">The sku of the bundle in the invoice that contains the given target</param>
        /// <param name="sku">The sku of an item in the bundle in the invoice</param>
        /// <param name="status">The new fulfillment status for the item. Additional options may be available based on configuration.  Allowable values:  &#39;unfulfilled&#39;, &#39;fulfilled&#39;, &#39;not fulfillable&#39;, &#39;failed&#39;, &#39;processing&#39;, &#39;failed_permanent&#39;, &#39;delayed&#39;</param>
        /// <returns></returns>
        void SetBundledInvoiceItemFulfillmentStatus (int? id, string bundleSku, string sku, StringWrapper status);
        /// <summary>
        /// Set the external reference of an invoice 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="externalRef">External reference info</param>
        /// <returns></returns>
        void SetExternalRef (int? id, StringWrapper externalRef);
        /// <summary>
        /// Set the fulfillment status of an invoice item This allows external fulfillment systems to report success or failure. Fulfillment status changes are restricted by a specific flow determining which status can lead to which.
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="sku">The sku of an item in the invoice</param>
        /// <param name="status">The new fulfillment status for the item. Additional options may be available based on configuration.  Allowable values:  &#39;unfulfilled&#39;, &#39;fulfilled&#39;, &#39;not fulfillable&#39;, &#39;failed&#39;, &#39;processing&#39;, &#39;failed_permanent&#39;, &#39;delayed&#39;</param>
        /// <returns></returns>
        void SetInvoiceItemFulfillmentStatus (int? id, string sku, StringWrapper status);
        /// <summary>
        /// Set the order notes of an invoice 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="orderNotes">Payment status info</param>
        /// <returns></returns>
        void SetOrderNotes (int? id, StringWrapper orderNotes);
        /// <summary>
        /// Set the payment status of an invoice This may trigger fulfillment if setting the status to &#39;paid&#39;. This is mainly intended to support external payment systems that cannot be incorporated into the payment method system. Payment status changes are restricted by a specific flow determining which status can lead to which.
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="request">Payment status info</param>
        /// <returns></returns>
        void SetPaymentStatus (int? id, InvoicePaymentStatusRequest request);
        /// <summary>
        /// Set or update billing info 
        /// </summary>
        /// <param name="id">The id of the invoice</param>
        /// <param name="billingInfoRequest">Address info</param>
        /// <returns></returns>
        void UpdateBillingInfo (int? id, AddressResource billingInfoRequest);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class InvoicesApi : IInvoicesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public InvoicesApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create an invoice Create an invoice(s) by providing a cart GUID. Note that there may be multiple invoices created, one per vendor.
        /// </summary>
        /// <param name="req">Invoice to be created</param> 
        /// <returns>List&lt;InvoiceResource&gt;</returns>            
        public List<InvoiceResource> CreateInvoice(InvoiceCreateRequest req)
        {
            
            string urlPath = "/invoices";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(req); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateInvoice: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateInvoice: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<InvoiceResource>) KnetikClient.Deserialize(response.Content, typeof(List<InvoiceResource>), response.Headers);
        }
        /// <summary>
        /// Lists available fulfillment statuses 
        /// </summary>
        /// <returns>List&lt;string&gt;</returns>            
        public List<string> GetFulFillmentStatuses()
        {
            
            string urlPath = "/invoices/fulfillment-statuses";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetFulFillmentStatuses: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetFulFillmentStatuses: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
        }
        /// <summary>
        /// Retrieve an invoice 
        /// </summary>
        /// <param name="id">The id of the invoice</param> 
        /// <returns>InvoiceResource</returns>            
        public InvoiceResource GetInvoice(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetInvoice");
            }
            
            
            string urlPath = "/invoices/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetInvoice: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetInvoice: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (InvoiceResource) KnetikClient.Deserialize(response.Content, typeof(InvoiceResource), response.Headers);
        }
        /// <summary>
        /// List invoice logs 
        /// </summary>
        /// <param name="id">The id of the invoice</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceInvoiceLogEntry</returns>            
        public PageResourceInvoiceLogEntry GetInvoiceLogs(int? id, int? size, int? page)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetInvoiceLogs");
            }
            
            
            string urlPath = "/invoices/{id}/logs";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetInvoiceLogs: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetInvoiceLogs: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceInvoiceLogEntry) KnetikClient.Deserialize(response.Content, typeof(PageResourceInvoiceLogEntry), response.Headers);
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
        /// <returns>PageResourceInvoiceResource</returns>            
        public PageResourceInvoiceResource GetInvoices(int? filterUser, string filterEmail, string filterFulfillmentStatus, string filterPaymentStatus, string filterItemName, string filterExternalRef, string filterCreatedDate, string filterVendorIds, string filterCurrency, string filterShippingStateName, string filterShippingCountryName, string filterShipping, string filterVendorName, string filterSku, int? size, int? page, string order)
        {
            
            string urlPath = "/invoices";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

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
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetInvoices: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetInvoices: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceInvoiceResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceInvoiceResource), response.Headers);
        }
        /// <summary>
        /// Lists available payment statuses 
        /// </summary>
        /// <returns>List&lt;string&gt;</returns>            
        public List<string> GetPaymentStatuses()
        {
            
            string urlPath = "/invoices/payment-statuses";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPaymentStatuses: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetPaymentStatuses: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
        }
        /// <summary>
        /// Pay an invoice using a saved payment method 
        /// </summary>
        /// <param name="id">The id of the invoice</param> 
        /// <param name="request">The payment method details. Will default to the appropriate user&#39;s wallet in the invoice currency if ommited.</param> 
        /// <returns></returns>            
        public void PayInvoice(int? id, PayBySavedMethodRequest request)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling PayInvoice");
            }
            
            
            string urlPath = "/invoices/{id}/payments";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling PayInvoice: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling PayInvoice: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Set the fulfillment status of a bundled invoice item This allows external fulfillment systems to report success or failure. Fulfillment status changes are restricted by a specific flow determining which status can lead to which.
        /// </summary>
        /// <param name="id">The id of the invoice</param> 
        /// <param name="bundleSku">The sku of the bundle in the invoice that contains the given target</param> 
        /// <param name="sku">The sku of an item in the bundle in the invoice</param> 
        /// <param name="status">The new fulfillment status for the item. Additional options may be available based on configuration.  Allowable values:  &#39;unfulfilled&#39;, &#39;fulfilled&#39;, &#39;not fulfillable&#39;, &#39;failed&#39;, &#39;processing&#39;, &#39;failed_permanent&#39;, &#39;delayed&#39;</param> 
        /// <returns></returns>            
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
            
            
            string urlPath = "/invoices/{id}/items/{bundleSku}/bundled-skus/{sku}/fulfillment-status";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
urlPath = urlPath.Replace("{" + "bundleSku" + "}", KnetikClient.ParameterToString(bundleSku));
urlPath = urlPath.Replace("{" + "sku" + "}", KnetikClient.ParameterToString(sku));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(status); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetBundledInvoiceItemFulfillmentStatus: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetBundledInvoiceItemFulfillmentStatus: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Set the external reference of an invoice 
        /// </summary>
        /// <param name="id">The id of the invoice</param> 
        /// <param name="externalRef">External reference info</param> 
        /// <returns></returns>            
        public void SetExternalRef(int? id, StringWrapper externalRef)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SetExternalRef");
            }
            
            
            string urlPath = "/invoices/{id}/external-ref";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(externalRef); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetExternalRef: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetExternalRef: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Set the fulfillment status of an invoice item This allows external fulfillment systems to report success or failure. Fulfillment status changes are restricted by a specific flow determining which status can lead to which.
        /// </summary>
        /// <param name="id">The id of the invoice</param> 
        /// <param name="sku">The sku of an item in the invoice</param> 
        /// <param name="status">The new fulfillment status for the item. Additional options may be available based on configuration.  Allowable values:  &#39;unfulfilled&#39;, &#39;fulfilled&#39;, &#39;not fulfillable&#39;, &#39;failed&#39;, &#39;processing&#39;, &#39;failed_permanent&#39;, &#39;delayed&#39;</param> 
        /// <returns></returns>            
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
            
            
            string urlPath = "/invoices/{id}/items/{sku}/fulfillment-status";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
urlPath = urlPath.Replace("{" + "sku" + "}", KnetikClient.ParameterToString(sku));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(status); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetInvoiceItemFulfillmentStatus: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetInvoiceItemFulfillmentStatus: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Set the order notes of an invoice 
        /// </summary>
        /// <param name="id">The id of the invoice</param> 
        /// <param name="orderNotes">Payment status info</param> 
        /// <returns></returns>            
        public void SetOrderNotes(int? id, StringWrapper orderNotes)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SetOrderNotes");
            }
            
            
            string urlPath = "/invoices/{id}/order-notes";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(orderNotes); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetOrderNotes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetOrderNotes: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Set the payment status of an invoice This may trigger fulfillment if setting the status to &#39;paid&#39;. This is mainly intended to support external payment systems that cannot be incorporated into the payment method system. Payment status changes are restricted by a specific flow determining which status can lead to which.
        /// </summary>
        /// <param name="id">The id of the invoice</param> 
        /// <param name="request">Payment status info</param> 
        /// <returns></returns>            
        public void SetPaymentStatus(int? id, InvoicePaymentStatusRequest request)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SetPaymentStatus");
            }
            
            
            string urlPath = "/invoices/{id}/payment-status";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetPaymentStatus: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetPaymentStatus: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Set or update billing info 
        /// </summary>
        /// <param name="id">The id of the invoice</param> 
        /// <param name="billingInfoRequest">Address info</param> 
        /// <returns></returns>            
        public void UpdateBillingInfo(int? id, AddressResource billingInfoRequest)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateBillingInfo");
            }
            
            
            string urlPath = "/invoices/{id}/billing-address";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(billingInfoRequest); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateBillingInfo: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateBillingInfo: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
    }
}
