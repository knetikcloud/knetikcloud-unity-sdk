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
    public interface IStoreSalesApi
    {
        CatalogSale CreateCatalogSaleData { get; }

        CatalogSale GetCatalogSaleData { get; }

        PageResourceCatalogSale GetCatalogSalesData { get; }

        CatalogSale UpdateCatalogSaleData { get; }

        
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

        /// <summary>
        /// Get a single sale 
        /// </summary>
        /// <param name="id">The id of the sale</param>
        void GetCatalogSale(int? id);

        /// <summary>
        /// List and search sales 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCatalogSales(int? size, int? page, string order);

        /// <summary>
        /// Update a sale 
        /// </summary>
        /// <param name="id">The id of the sale</param>
        /// <param name="catalogSale">The catalog sale object</param>
        void UpdateCatalogSale(int? id, CatalogSale catalogSale);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StoreSalesApi : IStoreSalesApi
    {
        private readonly KnetikCoroutine mCreateCatalogSaleCoroutine;
        private DateTime mCreateCatalogSaleStartTime;
        private string mCreateCatalogSalePath;
        private readonly KnetikCoroutine mDeleteCatalogSaleCoroutine;
        private DateTime mDeleteCatalogSaleStartTime;
        private string mDeleteCatalogSalePath;
        private readonly KnetikCoroutine mGetCatalogSaleCoroutine;
        private DateTime mGetCatalogSaleStartTime;
        private string mGetCatalogSalePath;
        private readonly KnetikCoroutine mGetCatalogSalesCoroutine;
        private DateTime mGetCatalogSalesStartTime;
        private string mGetCatalogSalesPath;
        private readonly KnetikCoroutine mUpdateCatalogSaleCoroutine;
        private DateTime mUpdateCatalogSaleStartTime;
        private string mUpdateCatalogSalePath;

        public CatalogSale CreateCatalogSaleData { get; private set; }
        public delegate void CreateCatalogSaleCompleteDelegate(CatalogSale response);
        public CreateCatalogSaleCompleteDelegate CreateCatalogSaleComplete;

        public delegate void DeleteCatalogSaleCompleteDelegate();
        public DeleteCatalogSaleCompleteDelegate DeleteCatalogSaleComplete;

        public CatalogSale GetCatalogSaleData { get; private set; }
        public delegate void GetCatalogSaleCompleteDelegate(CatalogSale response);
        public GetCatalogSaleCompleteDelegate GetCatalogSaleComplete;

        public PageResourceCatalogSale GetCatalogSalesData { get; private set; }
        public delegate void GetCatalogSalesCompleteDelegate(PageResourceCatalogSale response);
        public GetCatalogSalesCompleteDelegate GetCatalogSalesComplete;

        public CatalogSale UpdateCatalogSaleData { get; private set; }
        public delegate void UpdateCatalogSaleCompleteDelegate(CatalogSale response);
        public UpdateCatalogSaleCompleteDelegate UpdateCatalogSaleComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreSalesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreSalesApi()
        {
            mCreateCatalogSaleCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mDeleteCatalogSaleCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetCatalogSaleCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetCatalogSalesCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateCatalogSaleCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
        /// <summary>
        /// Create a sale 
        /// </summary>
        /// <param name="catalogSale">The catalog sale object</param>
        public void CreateCatalogSale(CatalogSale catalogSale)
        {
            
            mCreateCatalogSalePath = "/store/sales";
            if (!string.IsNullOrEmpty(mCreateCatalogSalePath))
            {
                mCreateCatalogSalePath = mCreateCatalogSalePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(catalogSale); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateCatalogSaleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateCatalogSaleStartTime, mCreateCatalogSalePath, "Sending server request...");

            // make the HTTP request
            mCreateCatalogSaleCoroutine.ResponseReceived += CreateCatalogSaleCallback;
            mCreateCatalogSaleCoroutine.Start(mCreateCatalogSalePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateCatalogSaleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCatalogSale: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCatalogSale: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateCatalogSaleData = (CatalogSale) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CatalogSale), response.Headers);
            KnetikLogger.LogResponse(mCreateCatalogSaleStartTime, mCreateCatalogSalePath, string.Format("Response received successfully:\n{0}", CreateCatalogSaleData.ToString()));

            if (CreateCatalogSaleComplete != null)
            {
                CreateCatalogSaleComplete(CreateCatalogSaleData);
            }
        }
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
            
            mDeleteCatalogSalePath = "/store/sales/{id}";
            if (!string.IsNullOrEmpty(mDeleteCatalogSalePath))
            {
                mDeleteCatalogSalePath = mDeleteCatalogSalePath.Replace("{format}", "json");
            }
            mDeleteCatalogSalePath = mDeleteCatalogSalePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteCatalogSaleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteCatalogSaleStartTime, mDeleteCatalogSalePath, "Sending server request...");

            // make the HTTP request
            mDeleteCatalogSaleCoroutine.ResponseReceived += DeleteCatalogSaleCallback;
            mDeleteCatalogSaleCoroutine.Start(mDeleteCatalogSalePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteCatalogSaleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCatalogSale: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCatalogSale: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteCatalogSaleStartTime, mDeleteCatalogSalePath, "Response received successfully.");
            if (DeleteCatalogSaleComplete != null)
            {
                DeleteCatalogSaleComplete();
            }
        }
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
            
            mGetCatalogSalePath = "/store/sales/{id}";
            if (!string.IsNullOrEmpty(mGetCatalogSalePath))
            {
                mGetCatalogSalePath = mGetCatalogSalePath.Replace("{format}", "json");
            }
            mGetCatalogSalePath = mGetCatalogSalePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetCatalogSaleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCatalogSaleStartTime, mGetCatalogSalePath, "Sending server request...");

            // make the HTTP request
            mGetCatalogSaleCoroutine.ResponseReceived += GetCatalogSaleCallback;
            mGetCatalogSaleCoroutine.Start(mGetCatalogSalePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCatalogSaleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCatalogSale: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCatalogSale: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCatalogSaleData = (CatalogSale) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CatalogSale), response.Headers);
            KnetikLogger.LogResponse(mGetCatalogSaleStartTime, mGetCatalogSalePath, string.Format("Response received successfully:\n{0}", GetCatalogSaleData.ToString()));

            if (GetCatalogSaleComplete != null)
            {
                GetCatalogSaleComplete(GetCatalogSaleData);
            }
        }
        /// <summary>
        /// List and search sales 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCatalogSales(int? size, int? page, string order)
        {
            
            mGetCatalogSalesPath = "/store/sales";
            if (!string.IsNullOrEmpty(mGetCatalogSalesPath))
            {
                mGetCatalogSalesPath = mGetCatalogSalesPath.Replace("{format}", "json");
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

            mGetCatalogSalesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCatalogSalesStartTime, mGetCatalogSalesPath, "Sending server request...");

            // make the HTTP request
            mGetCatalogSalesCoroutine.ResponseReceived += GetCatalogSalesCallback;
            mGetCatalogSalesCoroutine.Start(mGetCatalogSalesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCatalogSalesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCatalogSales: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCatalogSales: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCatalogSalesData = (PageResourceCatalogSale) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceCatalogSale), response.Headers);
            KnetikLogger.LogResponse(mGetCatalogSalesStartTime, mGetCatalogSalesPath, string.Format("Response received successfully:\n{0}", GetCatalogSalesData.ToString()));

            if (GetCatalogSalesComplete != null)
            {
                GetCatalogSalesComplete(GetCatalogSalesData);
            }
        }
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
            
            mUpdateCatalogSalePath = "/store/sales/{id}";
            if (!string.IsNullOrEmpty(mUpdateCatalogSalePath))
            {
                mUpdateCatalogSalePath = mUpdateCatalogSalePath.Replace("{format}", "json");
            }
            mUpdateCatalogSalePath = mUpdateCatalogSalePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(catalogSale); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateCatalogSaleStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateCatalogSaleStartTime, mUpdateCatalogSalePath, "Sending server request...");

            // make the HTTP request
            mUpdateCatalogSaleCoroutine.ResponseReceived += UpdateCatalogSaleCallback;
            mUpdateCatalogSaleCoroutine.Start(mUpdateCatalogSalePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateCatalogSaleCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCatalogSale: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCatalogSale: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateCatalogSaleData = (CatalogSale) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CatalogSale), response.Headers);
            KnetikLogger.LogResponse(mUpdateCatalogSaleStartTime, mUpdateCatalogSalePath, string.Format("Response received successfully:\n{0}", UpdateCatalogSaleData.ToString()));

            if (UpdateCatalogSaleComplete != null)
            {
                UpdateCatalogSaleComplete(UpdateCatalogSaleData);
            }
        }
    }
}
