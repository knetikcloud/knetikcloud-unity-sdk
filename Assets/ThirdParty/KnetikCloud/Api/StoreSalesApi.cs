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
    public interface IStoreSalesApi
    {
        CatalogSale CreateCatalogSaleData { get; }

        /// <summary>
        /// Create a sale 
        /// </summary>
        /// <param name="catalogSale">The catalog sale object</param>
        void CreateCatalogSale(CatalogSale catalogSale);

        

        /// <summary>
        /// Delete a sale 
        /// </summary>
        /// <param name="id">The id of the sale</param>
        void DeleteCatalogSale(int? id);

        CatalogSale GetCatalogSaleData { get; }

        /// <summary>
        /// Get a single sale 
        /// </summary>
        /// <param name="id">The id of the sale</param>
        void GetCatalogSale(int? id);

        PageResourceCatalogSale GetCatalogSalesData { get; }

        /// <summary>
        /// List and search sales 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCatalogSales(int? size, int? page, string order);

        CatalogSale UpdateCatalogSaleData { get; }

        /// <summary>
        /// Update a sale 
        /// </summary>
        /// <param name="id">The id of the sale</param>
        /// <param name="catalogSale">The catalog sale object</param>
        void UpdateCatalogSale(int? id, CatalogSale catalogSale);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StoreSalesApi : IStoreSalesApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateCatalogSaleResponseContext;
        private DateTime mCreateCatalogSaleStartTime;
        private readonly KnetikResponseContext mDeleteCatalogSaleResponseContext;
        private DateTime mDeleteCatalogSaleStartTime;
        private readonly KnetikResponseContext mGetCatalogSaleResponseContext;
        private DateTime mGetCatalogSaleStartTime;
        private readonly KnetikResponseContext mGetCatalogSalesResponseContext;
        private DateTime mGetCatalogSalesStartTime;
        private readonly KnetikResponseContext mUpdateCatalogSaleResponseContext;
        private DateTime mUpdateCatalogSaleStartTime;

        public CatalogSale CreateCatalogSaleData { get; private set; }
        public delegate void CreateCatalogSaleCompleteDelegate(long responseCode, CatalogSale response);
        public CreateCatalogSaleCompleteDelegate CreateCatalogSaleComplete;

        public delegate void DeleteCatalogSaleCompleteDelegate(long responseCode);
        public DeleteCatalogSaleCompleteDelegate DeleteCatalogSaleComplete;

        public CatalogSale GetCatalogSaleData { get; private set; }
        public delegate void GetCatalogSaleCompleteDelegate(long responseCode, CatalogSale response);
        public GetCatalogSaleCompleteDelegate GetCatalogSaleComplete;

        public PageResourceCatalogSale GetCatalogSalesData { get; private set; }
        public delegate void GetCatalogSalesCompleteDelegate(long responseCode, PageResourceCatalogSale response);
        public GetCatalogSalesCompleteDelegate GetCatalogSalesComplete;

        public CatalogSale UpdateCatalogSaleData { get; private set; }
        public delegate void UpdateCatalogSaleCompleteDelegate(long responseCode, CatalogSale response);
        public UpdateCatalogSaleCompleteDelegate UpdateCatalogSaleComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreSalesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreSalesApi()
        {
            mCreateCatalogSaleResponseContext = new KnetikResponseContext();
            mCreateCatalogSaleResponseContext.ResponseReceived += OnCreateCatalogSaleResponse;
            mDeleteCatalogSaleResponseContext = new KnetikResponseContext();
            mDeleteCatalogSaleResponseContext.ResponseReceived += OnDeleteCatalogSaleResponse;
            mGetCatalogSaleResponseContext = new KnetikResponseContext();
            mGetCatalogSaleResponseContext.ResponseReceived += OnGetCatalogSaleResponse;
            mGetCatalogSalesResponseContext = new KnetikResponseContext();
            mGetCatalogSalesResponseContext.ResponseReceived += OnGetCatalogSalesResponse;
            mUpdateCatalogSaleResponseContext = new KnetikResponseContext();
            mUpdateCatalogSaleResponseContext.ResponseReceived += OnUpdateCatalogSaleResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a sale 
        /// </summary>
        /// <param name="catalogSale">The catalog sale object</param>
        public void CreateCatalogSale(CatalogSale catalogSale)
        {
            
            mWebCallEvent.WebPath = "/store/sales";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(catalogSale); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateCatalogSaleStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateCatalogSaleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateCatalogSaleStartTime, "CreateCatalogSale", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateCatalogSaleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateCatalogSale: " + response.Error);
            }

            CreateCatalogSaleData = (CatalogSale) KnetikClient.Deserialize(response.Content, typeof(CatalogSale), response.Headers);
            KnetikLogger.LogResponse(mCreateCatalogSaleStartTime, "CreateCatalogSale", string.Format("Response received successfully:\n{0}", CreateCatalogSaleData));

            if (CreateCatalogSaleComplete != null)
            {
                CreateCatalogSaleComplete(response.ResponseCode, CreateCatalogSaleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a sale 
        /// </summary>
        /// <param name="id">The id of the sale</param>
        public void DeleteCatalogSale(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteCatalogSale");
            }
            
            mWebCallEvent.WebPath = "/store/sales/{id}";
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
            mDeleteCatalogSaleStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteCatalogSaleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteCatalogSaleStartTime, "DeleteCatalogSale", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteCatalogSaleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteCatalogSale: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteCatalogSaleStartTime, "DeleteCatalogSale", "Response received successfully.");
            if (DeleteCatalogSaleComplete != null)
            {
                DeleteCatalogSaleComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single sale 
        /// </summary>
        /// <param name="id">The id of the sale</param>
        public void GetCatalogSale(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCatalogSale");
            }
            
            mWebCallEvent.WebPath = "/store/sales/{id}";
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
            mGetCatalogSaleStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCatalogSaleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCatalogSaleStartTime, "GetCatalogSale", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCatalogSaleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCatalogSale: " + response.Error);
            }

            GetCatalogSaleData = (CatalogSale) KnetikClient.Deserialize(response.Content, typeof(CatalogSale), response.Headers);
            KnetikLogger.LogResponse(mGetCatalogSaleStartTime, "GetCatalogSale", string.Format("Response received successfully:\n{0}", GetCatalogSaleData));

            if (GetCatalogSaleComplete != null)
            {
                GetCatalogSaleComplete(response.ResponseCode, GetCatalogSaleData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search sales 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCatalogSales(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/store/sales";
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
            mGetCatalogSalesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCatalogSalesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCatalogSalesStartTime, "GetCatalogSales", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCatalogSalesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCatalogSales: " + response.Error);
            }

            GetCatalogSalesData = (PageResourceCatalogSale) KnetikClient.Deserialize(response.Content, typeof(PageResourceCatalogSale), response.Headers);
            KnetikLogger.LogResponse(mGetCatalogSalesStartTime, "GetCatalogSales", string.Format("Response received successfully:\n{0}", GetCatalogSalesData));

            if (GetCatalogSalesComplete != null)
            {
                GetCatalogSalesComplete(response.ResponseCode, GetCatalogSalesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a sale 
        /// </summary>
        /// <param name="id">The id of the sale</param>
        /// <param name="catalogSale">The catalog sale object</param>
        public void UpdateCatalogSale(int? id, CatalogSale catalogSale)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateCatalogSale");
            }
            
            mWebCallEvent.WebPath = "/store/sales/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(catalogSale); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateCatalogSaleStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateCatalogSaleResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateCatalogSaleStartTime, "UpdateCatalogSale", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateCatalogSaleResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateCatalogSale: " + response.Error);
            }

            UpdateCatalogSaleData = (CatalogSale) KnetikClient.Deserialize(response.Content, typeof(CatalogSale), response.Headers);
            KnetikLogger.LogResponse(mUpdateCatalogSaleStartTime, "UpdateCatalogSale", string.Format("Response received successfully:\n{0}", UpdateCatalogSaleData));

            if (UpdateCatalogSaleComplete != null)
            {
                UpdateCatalogSaleComplete(response.ResponseCode, UpdateCatalogSaleData);
            }
        }

    }
}
