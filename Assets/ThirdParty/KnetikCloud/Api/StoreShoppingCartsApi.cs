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
    public interface IStoreShoppingCartsApi
    {
        

        /// <summary>
        /// Adds a custom discount to the cart &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="customDiscount">The details of the discount to add</param>
        void AddCustomDiscount(string id, CouponDefinition customDiscount);

        

        /// <summary>
        /// Adds a discount coupon to the cart &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="skuRequest">The request of the sku</param>
        void AddDiscountToCart(string id, SkuRequest skuRequest);

        

        /// <summary>
        /// Add an item to the cart Currently, carts cannot contain virtual and real currency items at the same time. Furthermore, the API only support a single virtual item at the moment. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="cartItemRequest">The cart item request object</param>
        void AddItemToCart(string id, CartItemRequest cartItemRequest);

        string CreateCartData { get; }

        /// <summary>
        /// Create a cart You don&#39;t have to have a user to create a cart but the API requires authentication to checkout. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="owner">Set the owner of a cart. If not specified, defaults to the calling user&#39;s id. If specified and is not the calling user&#39;s id, SHOPPING_CARTS_ADMIN permission is required</param>
        /// <param name="currencyCode">Set the currency for the cart, by currency code. May be disallowed by site settings.</param>
        void CreateCart(int? owner, string currencyCode);

        Cart GetCartData { get; }

        /// <summary>
        /// Returns the cart with the given GUID &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="id">The id of the cart</param>
        void GetCart(string id);

        PageResourceCartSummary GetCartsData { get; }

        /// <summary>
        /// Get a list of carts &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="filterOwnerId">Filter by the id of the owner</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCarts(int? filterOwnerId, int? size, int? page, string order);

        CartShippableResponse GetShippableData { get; }

        /// <summary>
        /// Returns whether a cart requires shipping &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="id">The id of the cart</param>
        void GetShippable(string id);

        SampleCountriesResponse GetShippingCountriesData { get; }

        /// <summary>
        /// Get the list of available shipping countries per vendor Since a cart can have multiple vendors with different shipping options, the countries are broken down by vendors. Please see notes about the response object as the fields are variable. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="id">The id of the cart</param>
        void GetShippingCountries(string id);

        

        /// <summary>
        /// Removes a discount coupon from the cart &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="code">The SKU code of the coupon to remove</param>
        void RemoveDiscountFromCart(string id, string code);

        

        /// <summary>
        /// Sets the currency to use for the cart May be disallowed by site settings. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="currencyCode">The code of the currency</param>
        void SetCartCurrency(string id, StringWrapper currencyCode);

        

        /// <summary>
        /// Sets the owner of a cart if none is set already &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="userId">The id of the user</param>
        void SetCartOwner(string id, IntWrapper userId);

        

        /// <summary>
        /// Changes the quantity of an item already in the cart A quantity of zero will remove the item from the cart altogether. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="id">The id of the cart</param>
        /// <param name="cartItemRequest">The cart item request object</param>
        void UpdateItemInCart(string id, CartItemRequest cartItemRequest);

        

        /// <summary>
        /// Modifies or sets the order shipping address &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddCustomDiscountResponseContext;
        private DateTime mAddCustomDiscountStartTime;
        private readonly KnetikResponseContext mAddDiscountToCartResponseContext;
        private DateTime mAddDiscountToCartStartTime;
        private readonly KnetikResponseContext mAddItemToCartResponseContext;
        private DateTime mAddItemToCartStartTime;
        private readonly KnetikResponseContext mCreateCartResponseContext;
        private DateTime mCreateCartStartTime;
        private readonly KnetikResponseContext mGetCartResponseContext;
        private DateTime mGetCartStartTime;
        private readonly KnetikResponseContext mGetCartsResponseContext;
        private DateTime mGetCartsStartTime;
        private readonly KnetikResponseContext mGetShippableResponseContext;
        private DateTime mGetShippableStartTime;
        private readonly KnetikResponseContext mGetShippingCountriesResponseContext;
        private DateTime mGetShippingCountriesStartTime;
        private readonly KnetikResponseContext mRemoveDiscountFromCartResponseContext;
        private DateTime mRemoveDiscountFromCartStartTime;
        private readonly KnetikResponseContext mSetCartCurrencyResponseContext;
        private DateTime mSetCartCurrencyStartTime;
        private readonly KnetikResponseContext mSetCartOwnerResponseContext;
        private DateTime mSetCartOwnerStartTime;
        private readonly KnetikResponseContext mUpdateItemInCartResponseContext;
        private DateTime mUpdateItemInCartStartTime;
        private readonly KnetikResponseContext mUpdateShippingAddressResponseContext;
        private DateTime mUpdateShippingAddressStartTime;

        public delegate void AddCustomDiscountCompleteDelegate(long responseCode);
        public AddCustomDiscountCompleteDelegate AddCustomDiscountComplete;

        public delegate void AddDiscountToCartCompleteDelegate(long responseCode);
        public AddDiscountToCartCompleteDelegate AddDiscountToCartComplete;

        public delegate void AddItemToCartCompleteDelegate(long responseCode);
        public AddItemToCartCompleteDelegate AddItemToCartComplete;

        public string CreateCartData { get; private set; }
        public delegate void CreateCartCompleteDelegate(long responseCode, string response);
        public CreateCartCompleteDelegate CreateCartComplete;

        public Cart GetCartData { get; private set; }
        public delegate void GetCartCompleteDelegate(long responseCode, Cart response);
        public GetCartCompleteDelegate GetCartComplete;

        public PageResourceCartSummary GetCartsData { get; private set; }
        public delegate void GetCartsCompleteDelegate(long responseCode, PageResourceCartSummary response);
        public GetCartsCompleteDelegate GetCartsComplete;

        public CartShippableResponse GetShippableData { get; private set; }
        public delegate void GetShippableCompleteDelegate(long responseCode, CartShippableResponse response);
        public GetShippableCompleteDelegate GetShippableComplete;

        public SampleCountriesResponse GetShippingCountriesData { get; private set; }
        public delegate void GetShippingCountriesCompleteDelegate(long responseCode, SampleCountriesResponse response);
        public GetShippingCountriesCompleteDelegate GetShippingCountriesComplete;

        public delegate void RemoveDiscountFromCartCompleteDelegate(long responseCode);
        public RemoveDiscountFromCartCompleteDelegate RemoveDiscountFromCartComplete;

        public delegate void SetCartCurrencyCompleteDelegate(long responseCode);
        public SetCartCurrencyCompleteDelegate SetCartCurrencyComplete;

        public delegate void SetCartOwnerCompleteDelegate(long responseCode);
        public SetCartOwnerCompleteDelegate SetCartOwnerComplete;

        public delegate void UpdateItemInCartCompleteDelegate(long responseCode);
        public UpdateItemInCartCompleteDelegate UpdateItemInCartComplete;

        public delegate void UpdateShippingAddressCompleteDelegate(long responseCode);
        public UpdateShippingAddressCompleteDelegate UpdateShippingAddressComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreShoppingCartsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StoreShoppingCartsApi()
        {
            mAddCustomDiscountResponseContext = new KnetikResponseContext();
            mAddCustomDiscountResponseContext.ResponseReceived += OnAddCustomDiscountResponse;
            mAddDiscountToCartResponseContext = new KnetikResponseContext();
            mAddDiscountToCartResponseContext.ResponseReceived += OnAddDiscountToCartResponse;
            mAddItemToCartResponseContext = new KnetikResponseContext();
            mAddItemToCartResponseContext.ResponseReceived += OnAddItemToCartResponse;
            mCreateCartResponseContext = new KnetikResponseContext();
            mCreateCartResponseContext.ResponseReceived += OnCreateCartResponse;
            mGetCartResponseContext = new KnetikResponseContext();
            mGetCartResponseContext.ResponseReceived += OnGetCartResponse;
            mGetCartsResponseContext = new KnetikResponseContext();
            mGetCartsResponseContext.ResponseReceived += OnGetCartsResponse;
            mGetShippableResponseContext = new KnetikResponseContext();
            mGetShippableResponseContext.ResponseReceived += OnGetShippableResponse;
            mGetShippingCountriesResponseContext = new KnetikResponseContext();
            mGetShippingCountriesResponseContext.ResponseReceived += OnGetShippingCountriesResponse;
            mRemoveDiscountFromCartResponseContext = new KnetikResponseContext();
            mRemoveDiscountFromCartResponseContext.ResponseReceived += OnRemoveDiscountFromCartResponse;
            mSetCartCurrencyResponseContext = new KnetikResponseContext();
            mSetCartCurrencyResponseContext.ResponseReceived += OnSetCartCurrencyResponse;
            mSetCartOwnerResponseContext = new KnetikResponseContext();
            mSetCartOwnerResponseContext.ResponseReceived += OnSetCartOwnerResponse;
            mUpdateItemInCartResponseContext = new KnetikResponseContext();
            mUpdateItemInCartResponseContext.ResponseReceived += OnUpdateItemInCartResponse;
            mUpdateShippingAddressResponseContext = new KnetikResponseContext();
            mUpdateShippingAddressResponseContext.ResponseReceived += OnUpdateShippingAddressResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Adds a custom discount to the cart &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN
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
            
            mWebCallEvent.WebPath = "/carts/{id}/custom-discounts";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(customDiscount); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddCustomDiscountStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddCustomDiscountResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddCustomDiscountStartTime, "AddCustomDiscount", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddCustomDiscountResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddCustomDiscount: " + response.Error);
            }

            KnetikLogger.LogResponse(mAddCustomDiscountStartTime, "AddCustomDiscount", "Response received successfully.");
            if (AddCustomDiscountComplete != null)
            {
                AddCustomDiscountComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds a discount coupon to the cart &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/carts/{id}/discounts";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(skuRequest); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddDiscountToCartStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddDiscountToCartResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddDiscountToCartStartTime, "AddDiscountToCart", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddDiscountToCartResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddDiscountToCart: " + response.Error);
            }

            KnetikLogger.LogResponse(mAddDiscountToCartStartTime, "AddDiscountToCart", "Response received successfully.");
            if (AddDiscountToCartComplete != null)
            {
                AddDiscountToCartComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Add an item to the cart Currently, carts cannot contain virtual and real currency items at the same time. Furthermore, the API only support a single virtual item at the moment. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/carts/{id}/items";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(cartItemRequest); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddItemToCartStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddItemToCartResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddItemToCartStartTime, "AddItemToCart", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddItemToCartResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddItemToCart: " + response.Error);
            }

            KnetikLogger.LogResponse(mAddItemToCartStartTime, "AddItemToCart", "Response received successfully.");
            if (AddItemToCartComplete != null)
            {
                AddItemToCartComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a cart You don&#39;t have to have a user to create a cart but the API requires authentication to checkout. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="owner">Set the owner of a cart. If not specified, defaults to the calling user&#39;s id. If specified and is not the calling user&#39;s id, SHOPPING_CARTS_ADMIN permission is required</param>
        /// <param name="currencyCode">Set the currency for the cart, by currency code. May be disallowed by site settings.</param>
        public void CreateCart(int? owner, string currencyCode)
        {
            
            mWebCallEvent.WebPath = "/carts";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (owner != null)
            {
                mWebCallEvent.QueryParams["owner"] = KnetikClient.ParameterToString(owner);
            }

            if (currencyCode != null)
            {
                mWebCallEvent.QueryParams["currency_code"] = KnetikClient.ParameterToString(currencyCode);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateCartStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateCartResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateCartStartTime, "CreateCart", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateCartResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateCart: " + response.Error);
            }

            CreateCartData = (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mCreateCartStartTime, "CreateCart", string.Format("Response received successfully:\n{0}", CreateCartData));

            if (CreateCartComplete != null)
            {
                CreateCartComplete(response.ResponseCode, CreateCartData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the cart with the given GUID &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="id">The id of the cart</param>
        public void GetCart(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCart");
            }
            
            mWebCallEvent.WebPath = "/carts/{id}";
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
            mGetCartStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCartResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCartStartTime, "GetCart", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCartResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCart: " + response.Error);
            }

            GetCartData = (Cart) KnetikClient.Deserialize(response.Content, typeof(Cart), response.Headers);
            KnetikLogger.LogResponse(mGetCartStartTime, "GetCart", string.Format("Response received successfully:\n{0}", GetCartData));

            if (GetCartComplete != null)
            {
                GetCartComplete(response.ResponseCode, GetCartData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a list of carts &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="filterOwnerId">Filter by the id of the owner</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCarts(int? filterOwnerId, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/carts";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterOwnerId != null)
            {
                mWebCallEvent.QueryParams["filter_owner_id"] = KnetikClient.ParameterToString(filterOwnerId);
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
            mGetCartsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCartsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCartsStartTime, "GetCarts", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCartsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCarts: " + response.Error);
            }

            GetCartsData = (PageResourceCartSummary) KnetikClient.Deserialize(response.Content, typeof(PageResourceCartSummary), response.Headers);
            KnetikLogger.LogResponse(mGetCartsStartTime, "GetCarts", string.Format("Response received successfully:\n{0}", GetCartsData));

            if (GetCartsComplete != null)
            {
                GetCartsComplete(response.ResponseCode, GetCartsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns whether a cart requires shipping &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="id">The id of the cart</param>
        public void GetShippable(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetShippable");
            }
            
            mWebCallEvent.WebPath = "/carts/{id}/shippable";
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
            mGetShippableStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetShippableResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetShippableStartTime, "GetShippable", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetShippableResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetShippable: " + response.Error);
            }

            GetShippableData = (CartShippableResponse) KnetikClient.Deserialize(response.Content, typeof(CartShippableResponse), response.Headers);
            KnetikLogger.LogResponse(mGetShippableStartTime, "GetShippable", string.Format("Response received successfully:\n{0}", GetShippableData));

            if (GetShippableComplete != null)
            {
                GetShippableComplete(response.ResponseCode, GetShippableData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get the list of available shipping countries per vendor Since a cart can have multiple vendors with different shipping options, the countries are broken down by vendors. Please see notes about the response object as the fields are variable. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
        /// </summary>
        /// <param name="id">The id of the cart</param>
        public void GetShippingCountries(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetShippingCountries");
            }
            
            mWebCallEvent.WebPath = "/carts/{id}/countries";
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
            mGetShippingCountriesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetShippingCountriesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetShippingCountriesStartTime, "GetShippingCountries", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetShippingCountriesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetShippingCountries: " + response.Error);
            }

            GetShippingCountriesData = (SampleCountriesResponse) KnetikClient.Deserialize(response.Content, typeof(SampleCountriesResponse), response.Headers);
            KnetikLogger.LogResponse(mGetShippingCountriesStartTime, "GetShippingCountries", string.Format("Response received successfully:\n{0}", GetShippingCountriesData));

            if (GetShippingCountriesComplete != null)
            {
                GetShippingCountriesComplete(response.ResponseCode, GetShippingCountriesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Removes a discount coupon from the cart &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/carts/{id}/discounts/{code}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "code" + "}", KnetikClient.ParameterToString(code));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mRemoveDiscountFromCartStartTime = DateTime.Now;
            mWebCallEvent.Context = mRemoveDiscountFromCartResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mRemoveDiscountFromCartStartTime, "RemoveDiscountFromCart", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnRemoveDiscountFromCartResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling RemoveDiscountFromCart: " + response.Error);
            }

            KnetikLogger.LogResponse(mRemoveDiscountFromCartStartTime, "RemoveDiscountFromCart", "Response received successfully.");
            if (RemoveDiscountFromCartComplete != null)
            {
                RemoveDiscountFromCartComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Sets the currency to use for the cart May be disallowed by site settings. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/carts/{id}/currency";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(currencyCode); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetCartCurrencyStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetCartCurrencyResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetCartCurrencyStartTime, "SetCartCurrency", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetCartCurrencyResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetCartCurrency: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetCartCurrencyStartTime, "SetCartCurrency", "Response received successfully.");
            if (SetCartCurrencyComplete != null)
            {
                SetCartCurrencyComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Sets the owner of a cart if none is set already &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/carts/{id}/owner";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(userId); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetCartOwnerStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetCartOwnerResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetCartOwnerStartTime, "SetCartOwner", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetCartOwnerResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetCartOwner: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetCartOwnerStartTime, "SetCartOwner", "Response received successfully.");
            if (SetCartOwnerComplete != null)
            {
                SetCartOwnerComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Changes the quantity of an item already in the cart A quantity of zero will remove the item from the cart altogether. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/carts/{id}/items";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(cartItemRequest); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateItemInCartStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateItemInCartResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateItemInCartStartTime, "UpdateItemInCart", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateItemInCartResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateItemInCart: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateItemInCartStartTime, "UpdateItemInCart", "Response received successfully.");
            if (UpdateItemInCartComplete != null)
            {
                UpdateItemInCartComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Modifies or sets the order shipping address &lt;b&gt;Permissions Needed:&lt;/b&gt; SHOPPING_CARTS_ADMIN or owner
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
            
            mWebCallEvent.WebPath = "/carts/{id}/shipping-address";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(cartShippingAddressRequest); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateShippingAddressStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateShippingAddressResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateShippingAddressStartTime, "UpdateShippingAddress", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateShippingAddressResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateShippingAddress: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateShippingAddressStartTime, "UpdateShippingAddress", "Response received successfully.");
            if (UpdateShippingAddressComplete != null)
            {
                UpdateShippingAddressComplete(response.ResponseCode);
            }
        }

    }
}
