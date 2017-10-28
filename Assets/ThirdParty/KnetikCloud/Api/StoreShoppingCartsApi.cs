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
    public interface IStoreShoppingCartsApi
    {
        string CreateCartData { get; }

        Cart GetCartData { get; }

        PageResourceCartSummary GetCartsData { get; }

        CartShippableResponse GetShippableData { get; }

        SampleCountriesResponse GetShippingCountriesData { get; }

        
        /// <summary>
        /// Adds a custom discount to the cart 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="customDiscount">The details of the discount to add</param>
        void AddCustomDiscount(string id, CouponDefinition customDiscount);

        /// <summary>
        /// Adds a discount coupon to the cart 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="skuRequest">The request of the sku</param>
        void AddDiscountToCart(string id, SkuRequest skuRequest);

        /// <summary>
        /// Add an item to the cart Currently, carts cannot contain virtual and real currency items at the same time. Furthermore, the API only support a single virtual item at the moment
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="cartItemRequest">The cart item request object</param>
        void AddItemToCart(string id, CartItemRequest cartItemRequest);

        /// <summary>
        /// Create a cart You don&#39;t have to have a user to create a cart but the API requires authentication to checkout
        /// </summary>
        /// <param name="owner">Set the owner of a cart. If not specified, defaults to the calling user&#39;s id. If specified and is not the calling user&#39;s id, SHOPPING_CARTS_ADMIN permission is required</param>
        /// <param name="currencyCode">Set the currency for the cart, by currency code. May be disallowed by site settings.</param>
        void CreateCart(int? owner, string currencyCode);

        /// <summary>
        /// Returns the cart with the given GUID 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        void GetCart(string id);

        /// <summary>
        /// Get a list of carts 
        /// </summary>
        /// <param name="filterOwnerId">Filter by the id of the owner</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCarts(int? filterOwnerId, int? size, int? page, string order);

        /// <summary>
        /// Returns whether a cart requires shipping 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        void GetShippable(string id);

        /// <summary>
        /// Get the list of available shipping countries per vendor Since a cart can have multiple vendors with different shipping options, the countries are broken down by vendors. Please see notes about the response object as the fields are variable.
        /// </summary>
        /// <param name="id">The id of the cart</param>
        void GetShippingCountries(string id);

        /// <summary>
        /// Removes a discount coupon from the cart 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="code">The SKU code of the coupon to remove</param>
        void RemoveDiscountFromCart(string id, string code);

        /// <summary>
        /// Sets the currency to use for the cart May be disallowed by site settings.
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="currencyCode">The code of the currency</param>
        void SetCartCurrency(string id, StringWrapper currencyCode);

        /// <summary>
        /// Sets the owner of a cart if none is set already 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="userId">The id of the user</param>
        void SetCartOwner(string id, IntWrapper userId);

        /// <summary>
        /// Changes the quantity of an item already in the cart A quantity of zero will remove the item from the cart altogether.
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="cartItemRequest">The cart item request object</param>
        void UpdateItemInCart(string id, CartItemRequest cartItemRequest);

        /// <summary>
        /// Modifies or sets the order shipping address 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="cartShippingAddressRequest">The cart shipping address request object</param>
        void UpdateShippingAddress(string id, CartShippingAddressRequest cartShippingAddressRequest);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StoreShoppingCartsApi : IStoreShoppingCartsApi
    {
        private readonly KnetikCoroutine mAddCustomDiscountCoroutine;
        private DateTime mAddCustomDiscountStartTime;
        private string mAddCustomDiscountPath;
        private readonly KnetikCoroutine mAddDiscountToCartCoroutine;
        private DateTime mAddDiscountToCartStartTime;
        private string mAddDiscountToCartPath;
        private readonly KnetikCoroutine mAddItemToCartCoroutine;
        private DateTime mAddItemToCartStartTime;
        private string mAddItemToCartPath;
        private readonly KnetikCoroutine mCreateCartCoroutine;
        private DateTime mCreateCartStartTime;
        private string mCreateCartPath;
        private readonly KnetikCoroutine mGetCartCoroutine;
        private DateTime mGetCartStartTime;
        private string mGetCartPath;
        private readonly KnetikCoroutine mGetCartsCoroutine;
        private DateTime mGetCartsStartTime;
        private string mGetCartsPath;
        private readonly KnetikCoroutine mGetShippableCoroutine;
        private DateTime mGetShippableStartTime;
        private string mGetShippablePath;
        private readonly KnetikCoroutine mGetShippingCountriesCoroutine;
        private DateTime mGetShippingCountriesStartTime;
        private string mGetShippingCountriesPath;
        private readonly KnetikCoroutine mRemoveDiscountFromCartCoroutine;
        private DateTime mRemoveDiscountFromCartStartTime;
        private string mRemoveDiscountFromCartPath;
        private readonly KnetikCoroutine mSetCartCurrencyCoroutine;
        private DateTime mSetCartCurrencyStartTime;
        private string mSetCartCurrencyPath;
        private readonly KnetikCoroutine mSetCartOwnerCoroutine;
        private DateTime mSetCartOwnerStartTime;
        private string mSetCartOwnerPath;
        private readonly KnetikCoroutine mUpdateItemInCartCoroutine;
        private DateTime mUpdateItemInCartStartTime;
        private string mUpdateItemInCartPath;
        private readonly KnetikCoroutine mUpdateShippingAddressCoroutine;
        private DateTime mUpdateShippingAddressStartTime;
        private string mUpdateShippingAddressPath;

        public delegate void AddCustomDiscountCompleteDelegate();
        public AddCustomDiscountCompleteDelegate AddCustomDiscountComplete;

        public delegate void AddDiscountToCartCompleteDelegate();
        public AddDiscountToCartCompleteDelegate AddDiscountToCartComplete;

        public delegate void AddItemToCartCompleteDelegate();
        public AddItemToCartCompleteDelegate AddItemToCartComplete;

        public string CreateCartData { get; private set; }
        public delegate void CreateCartCompleteDelegate(string response);
        public CreateCartCompleteDelegate CreateCartComplete;

        public Cart GetCartData { get; private set; }
        public delegate void GetCartCompleteDelegate(Cart response);
        public GetCartCompleteDelegate GetCartComplete;

        public PageResourceCartSummary GetCartsData { get; private set; }
        public delegate void GetCartsCompleteDelegate(PageResourceCartSummary response);
        public GetCartsCompleteDelegate GetCartsComplete;

        public CartShippableResponse GetShippableData { get; private set; }
        public delegate void GetShippableCompleteDelegate(CartShippableResponse response);
        public GetShippableCompleteDelegate GetShippableComplete;

        public SampleCountriesResponse GetShippingCountriesData { get; private set; }
        public delegate void GetShippingCountriesCompleteDelegate(SampleCountriesResponse response);
        public GetShippingCountriesCompleteDelegate GetShippingCountriesComplete;

        public delegate void RemoveDiscountFromCartCompleteDelegate();
        public RemoveDiscountFromCartCompleteDelegate RemoveDiscountFromCartComplete;

        public delegate void SetCartCurrencyCompleteDelegate();
        public SetCartCurrencyCompleteDelegate SetCartCurrencyComplete;

        public delegate void SetCartOwnerCompleteDelegate();
        public SetCartOwnerCompleteDelegate SetCartOwnerComplete;

        public delegate void UpdateItemInCartCompleteDelegate();
        public UpdateItemInCartCompleteDelegate UpdateItemInCartComplete;

        public delegate void UpdateShippingAddressCompleteDelegate();
        public UpdateShippingAddressCompleteDelegate UpdateShippingAddressComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreShoppingCartsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreShoppingCartsApi()
        {
            mAddCustomDiscountCoroutine = new KnetikCoroutine();
            mAddDiscountToCartCoroutine = new KnetikCoroutine();
            mAddItemToCartCoroutine = new KnetikCoroutine();
            mCreateCartCoroutine = new KnetikCoroutine();
            mGetCartCoroutine = new KnetikCoroutine();
            mGetCartsCoroutine = new KnetikCoroutine();
            mGetShippableCoroutine = new KnetikCoroutine();
            mGetShippingCountriesCoroutine = new KnetikCoroutine();
            mRemoveDiscountFromCartCoroutine = new KnetikCoroutine();
            mSetCartCurrencyCoroutine = new KnetikCoroutine();
            mSetCartOwnerCoroutine = new KnetikCoroutine();
            mUpdateItemInCartCoroutine = new KnetikCoroutine();
            mUpdateShippingAddressCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Adds a custom discount to the cart 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="customDiscount">The details of the discount to add</param>
        public void AddCustomDiscount(string id, CouponDefinition customDiscount)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddCustomDiscount");
            }
            
            mAddCustomDiscountPath = "/carts/{id}/custom-discounts";
            if (!string.IsNullOrEmpty(mAddCustomDiscountPath))
            {
                mAddCustomDiscountPath = mAddCustomDiscountPath.Replace("{format}", "json");
            }
            mAddCustomDiscountPath = mAddCustomDiscountPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(customDiscount); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddCustomDiscountStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddCustomDiscountStartTime, mAddCustomDiscountPath, "Sending server request...");

            // make the HTTP request
            mAddCustomDiscountCoroutine.ResponseReceived += AddCustomDiscountCallback;
            mAddCustomDiscountCoroutine.Start(mAddCustomDiscountPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddCustomDiscountCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddCustomDiscount: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddCustomDiscount: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mAddCustomDiscountStartTime, mAddCustomDiscountPath, "Response received successfully.");
            if (AddCustomDiscountComplete != null)
            {
                AddCustomDiscountComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds a discount coupon to the cart 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="skuRequest">The request of the sku</param>
        public void AddDiscountToCart(string id, SkuRequest skuRequest)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddDiscountToCart");
            }
            
            mAddDiscountToCartPath = "/carts/{id}/discounts";
            if (!string.IsNullOrEmpty(mAddDiscountToCartPath))
            {
                mAddDiscountToCartPath = mAddDiscountToCartPath.Replace("{format}", "json");
            }
            mAddDiscountToCartPath = mAddDiscountToCartPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(skuRequest); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddDiscountToCartStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddDiscountToCartStartTime, mAddDiscountToCartPath, "Sending server request...");

            // make the HTTP request
            mAddDiscountToCartCoroutine.ResponseReceived += AddDiscountToCartCallback;
            mAddDiscountToCartCoroutine.Start(mAddDiscountToCartPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddDiscountToCartCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddDiscountToCart: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddDiscountToCart: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mAddDiscountToCartStartTime, mAddDiscountToCartPath, "Response received successfully.");
            if (AddDiscountToCartComplete != null)
            {
                AddDiscountToCartComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Add an item to the cart Currently, carts cannot contain virtual and real currency items at the same time. Furthermore, the API only support a single virtual item at the moment
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="cartItemRequest">The cart item request object</param>
        public void AddItemToCart(string id, CartItemRequest cartItemRequest)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddItemToCart");
            }
            
            mAddItemToCartPath = "/carts/{id}/items";
            if (!string.IsNullOrEmpty(mAddItemToCartPath))
            {
                mAddItemToCartPath = mAddItemToCartPath.Replace("{format}", "json");
            }
            mAddItemToCartPath = mAddItemToCartPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(cartItemRequest); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddItemToCartStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddItemToCartStartTime, mAddItemToCartPath, "Sending server request...");

            // make the HTTP request
            mAddItemToCartCoroutine.ResponseReceived += AddItemToCartCallback;
            mAddItemToCartCoroutine.Start(mAddItemToCartPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddItemToCartCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddItemToCart: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddItemToCart: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mAddItemToCartStartTime, mAddItemToCartPath, "Response received successfully.");
            if (AddItemToCartComplete != null)
            {
                AddItemToCartComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a cart You don&#39;t have to have a user to create a cart but the API requires authentication to checkout
        /// </summary>
        /// <param name="owner">Set the owner of a cart. If not specified, defaults to the calling user&#39;s id. If specified and is not the calling user&#39;s id, SHOPPING_CARTS_ADMIN permission is required</param>
        /// <param name="currencyCode">Set the currency for the cart, by currency code. May be disallowed by site settings.</param>
        public void CreateCart(int? owner, string currencyCode)
        {
            
            mCreateCartPath = "/carts";
            if (!string.IsNullOrEmpty(mCreateCartPath))
            {
                mCreateCartPath = mCreateCartPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (owner != null)
            {
                queryParams.Add("owner", KnetikClient.DefaultClient.ParameterToString(owner));
            }

            if (currencyCode != null)
            {
                queryParams.Add("currency_code", KnetikClient.DefaultClient.ParameterToString(currencyCode));
            }

            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mCreateCartStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateCartStartTime, mCreateCartPath, "Sending server request...");

            // make the HTTP request
            mCreateCartCoroutine.ResponseReceived += CreateCartCallback;
            mCreateCartCoroutine.Start(mCreateCartPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateCartCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCart: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCart: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateCartData = (string) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mCreateCartStartTime, mCreateCartPath, string.Format("Response received successfully:\n{0}", CreateCartData.ToString()));

            if (CreateCartComplete != null)
            {
                CreateCartComplete(CreateCartData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the cart with the given GUID 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        public void GetCart(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCart");
            }
            
            mGetCartPath = "/carts/{id}";
            if (!string.IsNullOrEmpty(mGetCartPath))
            {
                mGetCartPath = mGetCartPath.Replace("{format}", "json");
            }
            mGetCartPath = mGetCartPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetCartStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCartStartTime, mGetCartPath, "Sending server request...");

            // make the HTTP request
            mGetCartCoroutine.ResponseReceived += GetCartCallback;
            mGetCartCoroutine.Start(mGetCartPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCartCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCart: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCart: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCartData = (Cart) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(Cart), response.Headers);
            KnetikLogger.LogResponse(mGetCartStartTime, mGetCartPath, string.Format("Response received successfully:\n{0}", GetCartData.ToString()));

            if (GetCartComplete != null)
            {
                GetCartComplete(GetCartData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a list of carts 
        /// </summary>
        /// <param name="filterOwnerId">Filter by the id of the owner</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCarts(int? filterOwnerId, int? size, int? page, string order)
        {
            
            mGetCartsPath = "/carts";
            if (!string.IsNullOrEmpty(mGetCartsPath))
            {
                mGetCartsPath = mGetCartsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterOwnerId != null)
            {
                queryParams.Add("filter_owner_id", KnetikClient.DefaultClient.ParameterToString(filterOwnerId));
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
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetCartsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCartsStartTime, mGetCartsPath, "Sending server request...");

            // make the HTTP request
            mGetCartsCoroutine.ResponseReceived += GetCartsCallback;
            mGetCartsCoroutine.Start(mGetCartsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCartsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCarts: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCarts: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCartsData = (PageResourceCartSummary) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceCartSummary), response.Headers);
            KnetikLogger.LogResponse(mGetCartsStartTime, mGetCartsPath, string.Format("Response received successfully:\n{0}", GetCartsData.ToString()));

            if (GetCartsComplete != null)
            {
                GetCartsComplete(GetCartsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns whether a cart requires shipping 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        public void GetShippable(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetShippable");
            }
            
            mGetShippablePath = "/carts/{id}/shippable";
            if (!string.IsNullOrEmpty(mGetShippablePath))
            {
                mGetShippablePath = mGetShippablePath.Replace("{format}", "json");
            }
            mGetShippablePath = mGetShippablePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetShippableStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetShippableStartTime, mGetShippablePath, "Sending server request...");

            // make the HTTP request
            mGetShippableCoroutine.ResponseReceived += GetShippableCallback;
            mGetShippableCoroutine.Start(mGetShippablePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetShippableCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetShippable: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetShippable: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetShippableData = (CartShippableResponse) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CartShippableResponse), response.Headers);
            KnetikLogger.LogResponse(mGetShippableStartTime, mGetShippablePath, string.Format("Response received successfully:\n{0}", GetShippableData.ToString()));

            if (GetShippableComplete != null)
            {
                GetShippableComplete(GetShippableData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get the list of available shipping countries per vendor Since a cart can have multiple vendors with different shipping options, the countries are broken down by vendors. Please see notes about the response object as the fields are variable.
        /// </summary>
        /// <param name="id">The id of the cart</param>
        public void GetShippingCountries(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetShippingCountries");
            }
            
            mGetShippingCountriesPath = "/carts/{id}/countries";
            if (!string.IsNullOrEmpty(mGetShippingCountriesPath))
            {
                mGetShippingCountriesPath = mGetShippingCountriesPath.Replace("{format}", "json");
            }
            mGetShippingCountriesPath = mGetShippingCountriesPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetShippingCountriesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetShippingCountriesStartTime, mGetShippingCountriesPath, "Sending server request...");

            // make the HTTP request
            mGetShippingCountriesCoroutine.ResponseReceived += GetShippingCountriesCallback;
            mGetShippingCountriesCoroutine.Start(mGetShippingCountriesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetShippingCountriesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetShippingCountries: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetShippingCountries: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetShippingCountriesData = (SampleCountriesResponse) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(SampleCountriesResponse), response.Headers);
            KnetikLogger.LogResponse(mGetShippingCountriesStartTime, mGetShippingCountriesPath, string.Format("Response received successfully:\n{0}", GetShippingCountriesData.ToString()));

            if (GetShippingCountriesComplete != null)
            {
                GetShippingCountriesComplete(GetShippingCountriesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Removes a discount coupon from the cart 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="code">The SKU code of the coupon to remove</param>
        public void RemoveDiscountFromCart(string id, string code)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling RemoveDiscountFromCart");
            }
            // verify the required parameter 'code' is set
            if (code == null)
            {
                throw new KnetikException(400, "Missing required parameter 'code' when calling RemoveDiscountFromCart");
            }
            
            mRemoveDiscountFromCartPath = "/carts/{id}/discounts/{code}";
            if (!string.IsNullOrEmpty(mRemoveDiscountFromCartPath))
            {
                mRemoveDiscountFromCartPath = mRemoveDiscountFromCartPath.Replace("{format}", "json");
            }
            mRemoveDiscountFromCartPath = mRemoveDiscountFromCartPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));
mRemoveDiscountFromCartPath = mRemoveDiscountFromCartPath.Replace("{" + "code" + "}", KnetikClient.DefaultClient.ParameterToString(code));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mRemoveDiscountFromCartStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mRemoveDiscountFromCartStartTime, mRemoveDiscountFromCartPath, "Sending server request...");

            // make the HTTP request
            mRemoveDiscountFromCartCoroutine.ResponseReceived += RemoveDiscountFromCartCallback;
            mRemoveDiscountFromCartCoroutine.Start(mRemoveDiscountFromCartPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void RemoveDiscountFromCartCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveDiscountFromCart: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveDiscountFromCart: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mRemoveDiscountFromCartStartTime, mRemoveDiscountFromCartPath, "Response received successfully.");
            if (RemoveDiscountFromCartComplete != null)
            {
                RemoveDiscountFromCartComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Sets the currency to use for the cart May be disallowed by site settings.
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="currencyCode">The code of the currency</param>
        public void SetCartCurrency(string id, StringWrapper currencyCode)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SetCartCurrency");
            }
            
            mSetCartCurrencyPath = "/carts/{id}/currency";
            if (!string.IsNullOrEmpty(mSetCartCurrencyPath))
            {
                mSetCartCurrencyPath = mSetCartCurrencyPath.Replace("{format}", "json");
            }
            mSetCartCurrencyPath = mSetCartCurrencyPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(currencyCode); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetCartCurrencyStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetCartCurrencyStartTime, mSetCartCurrencyPath, "Sending server request...");

            // make the HTTP request
            mSetCartCurrencyCoroutine.ResponseReceived += SetCartCurrencyCallback;
            mSetCartCurrencyCoroutine.Start(mSetCartCurrencyPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetCartCurrencyCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetCartCurrency: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetCartCurrency: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetCartCurrencyStartTime, mSetCartCurrencyPath, "Response received successfully.");
            if (SetCartCurrencyComplete != null)
            {
                SetCartCurrencyComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Sets the owner of a cart if none is set already 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="userId">The id of the user</param>
        public void SetCartOwner(string id, IntWrapper userId)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling SetCartOwner");
            }
            
            mSetCartOwnerPath = "/carts/{id}/owner";
            if (!string.IsNullOrEmpty(mSetCartOwnerPath))
            {
                mSetCartOwnerPath = mSetCartOwnerPath.Replace("{format}", "json");
            }
            mSetCartOwnerPath = mSetCartOwnerPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(userId); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetCartOwnerStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetCartOwnerStartTime, mSetCartOwnerPath, "Sending server request...");

            // make the HTTP request
            mSetCartOwnerCoroutine.ResponseReceived += SetCartOwnerCallback;
            mSetCartOwnerCoroutine.Start(mSetCartOwnerPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetCartOwnerCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetCartOwner: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetCartOwner: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetCartOwnerStartTime, mSetCartOwnerPath, "Response received successfully.");
            if (SetCartOwnerComplete != null)
            {
                SetCartOwnerComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Changes the quantity of an item already in the cart A quantity of zero will remove the item from the cart altogether.
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="cartItemRequest">The cart item request object</param>
        public void UpdateItemInCart(string id, CartItemRequest cartItemRequest)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateItemInCart");
            }
            
            mUpdateItemInCartPath = "/carts/{id}/items";
            if (!string.IsNullOrEmpty(mUpdateItemInCartPath))
            {
                mUpdateItemInCartPath = mUpdateItemInCartPath.Replace("{format}", "json");
            }
            mUpdateItemInCartPath = mUpdateItemInCartPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(cartItemRequest); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateItemInCartStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateItemInCartStartTime, mUpdateItemInCartPath, "Sending server request...");

            // make the HTTP request
            mUpdateItemInCartCoroutine.ResponseReceived += UpdateItemInCartCallback;
            mUpdateItemInCartCoroutine.Start(mUpdateItemInCartPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateItemInCartCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateItemInCart: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateItemInCart: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateItemInCartStartTime, mUpdateItemInCartPath, "Response received successfully.");
            if (UpdateItemInCartComplete != null)
            {
                UpdateItemInCartComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Modifies or sets the order shipping address 
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="cartShippingAddressRequest">The cart shipping address request object</param>
        public void UpdateShippingAddress(string id, CartShippingAddressRequest cartShippingAddressRequest)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateShippingAddress");
            }
            
            mUpdateShippingAddressPath = "/carts/{id}/shipping-address";
            if (!string.IsNullOrEmpty(mUpdateShippingAddressPath))
            {
                mUpdateShippingAddressPath = mUpdateShippingAddressPath.Replace("{format}", "json");
            }
            mUpdateShippingAddressPath = mUpdateShippingAddressPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(cartShippingAddressRequest); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateShippingAddressStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateShippingAddressStartTime, mUpdateShippingAddressPath, "Sending server request...");

            // make the HTTP request
            mUpdateShippingAddressCoroutine.ResponseReceived += UpdateShippingAddressCallback;
            mUpdateShippingAddressCoroutine.Start(mUpdateShippingAddressPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateShippingAddressCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateShippingAddress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateShippingAddress: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateShippingAddressStartTime, mUpdateShippingAddressPath, "Response received successfully.");
            if (UpdateShippingAddressComplete != null)
            {
                UpdateShippingAddressComplete();
            }
        }

    }
}
