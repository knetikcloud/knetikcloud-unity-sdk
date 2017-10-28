using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using com.knetikcloud.Attributes;
using com.knetikcloud.Serialization;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    public class InvoiceResource
    {
        /// <summary>
        /// Line one of the customer's billing address
        /// </summary>
        /// <value>Line one of the customer's billing address</value>
        [JsonProperty(PropertyName = "billing_address1")]
        public string BillingAddress1;

        /// <summary>
        /// Line two of the customer's billing address
        /// </summary>
        /// <value>Line two of the customer's billing address</value>
        [JsonProperty(PropertyName = "billing_address2")]
        public string BillingAddress2;

        /// <summary>
        /// The city for the customer's billing address
        /// </summary>
        /// <value>The city for the customer's billing address</value>
        [JsonProperty(PropertyName = "billing_city_name")]
        public string BillingCityName;

        /// <summary>
        /// The country for the customer's billing address
        /// </summary>
        /// <value>The country for the customer's billing address</value>
        [JsonProperty(PropertyName = "billing_country_name")]
        public string BillingCountryName;

        /// <summary>
        /// The customer's name for the billing address
        /// </summary>
        /// <value>The customer's name for the billing address</value>
        [JsonProperty(PropertyName = "billing_full_name")]
        public string BillingFullName;

        /// <summary>
        /// The postal code for the customer's billing address
        /// </summary>
        /// <value>The postal code for the customer's billing address</value>
        [JsonProperty(PropertyName = "billing_postal_code")]
        public string BillingPostalCode;

        /// <summary>
        /// The state for the customer's billing address
        /// </summary>
        /// <value>The state for the customer's billing address</value>
        [JsonProperty(PropertyName = "billing_state_name")]
        public string BillingStateName;

        /// <summary>
        /// The guid of the cart this invoice came from
        /// </summary>
        /// <value>The guid of the cart this invoice came from</value>
        [JsonProperty(PropertyName = "cart_id")]
        public string CartId;

        /// <summary>
        /// The date the invoice was created, unix timestamp in seconds
        /// </summary>
        /// <value>The date the invoice was created, unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The code for the currency invoice prices are in
        /// </summary>
        /// <value>The code for the currency invoice prices are in</value>
        [JsonProperty(PropertyName = "currency")]
        public string Currency;

        /// <summary>
        /// The fulfillment status of the invoice
        /// </summary>
        /// <value>The fulfillment status of the invoice</value>
        [JsonProperty(PropertyName = "current_fulfillment_status")]
        public string CurrentFulfillmentStatus;

        /// <summary>
        /// The payment status of the invoice
        /// </summary>
        /// <value>The payment status of the invoice</value>
        [JsonProperty(PropertyName = "current_payment_status")]
        public string CurrentPaymentStatus;

        /// <summary>
        /// The amount of money saved through coupons
        /// </summary>
        /// <value>The amount of money saved through coupons</value>
        [JsonProperty(PropertyName = "discount")]
        public decimal? Discount;

        /// <summary>
        /// The customer's email address
        /// </summary>
        /// <value>The customer's email address</value>
        [JsonProperty(PropertyName = "email")]
        public string Email;

        /// <summary>
        /// An external reference to filter on
        /// </summary>
        /// <value>An external reference to filter on</value>
        [JsonProperty(PropertyName = "external_ref")]
        public string ExternalRef;

        /// <summary>
        /// The amount of federal tax added
        /// </summary>
        /// <value>The amount of federal tax added</value>
        [JsonProperty(PropertyName = "fed_tax")]
        public decimal? FedTax;

        /// <summary>
        /// The final price of the invoice
        /// </summary>
        /// <value>The final price of the invoice</value>
        [JsonProperty(PropertyName = "grand_total")]
        public decimal? GrandTotal;

        /// <summary>
        /// The id of the invoice
        /// </summary>
        /// <value>The id of the invoice</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id;

        /// <summary>
        /// A reference number for the invoice
        /// </summary>
        /// <value>A reference number for the invoice</value>
        [JsonProperty(PropertyName = "invoice_number")]
        public string InvoiceNumber;

        /// <summary>
        /// A list of items within the invoice
        /// </summary>
        /// <value>A list of items within the invoice</value>
        [JsonProperty(PropertyName = "items")]
        public List<InvoiceItemResource> Items;

        /// <summary>
        /// The customer's name prefix
        /// </summary>
        /// <value>The customer's name prefix</value>
        [JsonProperty(PropertyName = "name_prefix")]
        public string NamePrefix;

        /// <summary>
        /// Notes about the order
        /// </summary>
        /// <value>Notes about the order</value>
        [JsonProperty(PropertyName = "order_notes")]
        public string OrderNotes;

        /// <summary>
        /// The id of an invoice this is a child of
        /// </summary>
        /// <value>The id of an invoice this is a child of</value>
        [JsonProperty(PropertyName = "parent_invoice_id")]
        public int? ParentInvoiceId;

        /// <summary>
        /// The id of a saved payment method used to pay for the invoice
        /// </summary>
        /// <value>The id of a saved payment method used to pay for the invoice</value>
        [JsonProperty(PropertyName = "payment_method_id")]
        public int? PaymentMethodId;

        /// <summary>
        /// The customer's phone number
        /// </summary>
        /// <value>The customer's phone number</value>
        [JsonProperty(PropertyName = "phone")]
        public string Phone;

        /// <summary>
        /// The customer's phone number
        /// </summary>
        /// <value>The customer's phone number</value>
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber;

        /// <summary>
        /// The remaining price of the invoice (after any payments made so far)
        /// </summary>
        /// <value>The remaining price of the invoice (after any payments made so far)</value>
        [JsonProperty(PropertyName = "remaining_balance")]
        public decimal? RemainingBalance;

        /// <summary>
        /// The shipping cost
        /// </summary>
        /// <value>The shipping cost</value>
        [JsonProperty(PropertyName = "shipping")]
        public decimal? Shipping;

        /// <summary>
        /// Line one of the customer's shipping address
        /// </summary>
        /// <value>Line one of the customer's shipping address</value>
        [JsonProperty(PropertyName = "shipping_address1")]
        public string ShippingAddress1;

        /// <summary>
        /// Line two of the customer's shipping address
        /// </summary>
        /// <value>Line two of the customer's shipping address</value>
        [JsonProperty(PropertyName = "shipping_address2")]
        public string ShippingAddress2;

        /// <summary>
        /// The city for the customer's shipping address
        /// </summary>
        /// <value>The city for the customer's shipping address</value>
        [JsonProperty(PropertyName = "shipping_city_name")]
        public string ShippingCityName;

        /// <summary>
        /// The country for the customer's shipping address
        /// </summary>
        /// <value>The country for the customer's shipping address</value>
        [JsonProperty(PropertyName = "shipping_country_name")]
        public string ShippingCountryName;

        /// <summary>
        /// The customer's name for the shipping address
        /// </summary>
        /// <value>The customer's name for the shipping address</value>
        [JsonProperty(PropertyName = "shipping_full_name")]
        public string ShippingFullName;

        /// <summary>
        /// The postal code for the customer's shipping address
        /// </summary>
        /// <value>The postal code for the customer's shipping address</value>
        [JsonProperty(PropertyName = "shipping_postal_code")]
        public string ShippingPostalCode;

        /// <summary>
        /// The state for the customer's shipping address
        /// </summary>
        /// <value>The state for the customer's shipping address</value>
        [JsonProperty(PropertyName = "shipping_state_name")]
        public string ShippingStateName;

        /// <summary>
        /// A number to use in sorting items. default 500.
        /// </summary>
        /// <value>A number to use in sorting items. default 500.</value>
        [JsonProperty(PropertyName = "sort")]
        public int? Sort;

        /// <summary>
        /// The amount of state tax added
        /// </summary>
        /// <value>The amount of state tax added</value>
        [JsonProperty(PropertyName = "state_tax")]
        public decimal? StateTax;

        /// <summary>
        /// The sum price of all items before shipping, coupons and tax
        /// </summary>
        /// <value>The sum price of all items before shipping, coupons and tax</value>
        [JsonProperty(PropertyName = "subtotal")]
        public decimal? Subtotal;

        /// <summary>
        /// The date the invoice was last updated, unix timestamp in seconds
        /// </summary>
        /// <value>The date the invoice was last updated, unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <summary>
        /// The owner of the invoice
        /// </summary>
        /// <value>The owner of the invoice</value>
        [JsonProperty(PropertyName = "user")]
        public SimpleUserResource User;

        /// <summary>
        /// The id of the vendor
        /// </summary>
        /// <value>The id of the vendor</value>
        [JsonProperty(PropertyName = "vendor_id")]
        public int? VendorId;

        /// <summary>
        /// The name of the invoice
        /// </summary>
        /// <value>The name of the invoice</value>
        [JsonProperty(PropertyName = "vendor_name")]
        public string VendorName;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class InvoiceResource {\n");
            sb.Append("  BillingAddress1: ").Append(BillingAddress1).Append("\n");
            sb.Append("  BillingAddress2: ").Append(BillingAddress2).Append("\n");
            sb.Append("  BillingCityName: ").Append(BillingCityName).Append("\n");
            sb.Append("  BillingCountryName: ").Append(BillingCountryName).Append("\n");
            sb.Append("  BillingFullName: ").Append(BillingFullName).Append("\n");
            sb.Append("  BillingPostalCode: ").Append(BillingPostalCode).Append("\n");
            sb.Append("  BillingStateName: ").Append(BillingStateName).Append("\n");
            sb.Append("  CartId: ").Append(CartId).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  CurrentFulfillmentStatus: ").Append(CurrentFulfillmentStatus).Append("\n");
            sb.Append("  CurrentPaymentStatus: ").Append(CurrentPaymentStatus).Append("\n");
            sb.Append("  Discount: ").Append(Discount).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  ExternalRef: ").Append(ExternalRef).Append("\n");
            sb.Append("  FedTax: ").Append(FedTax).Append("\n");
            sb.Append("  GrandTotal: ").Append(GrandTotal).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InvoiceNumber: ").Append(InvoiceNumber).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("  NamePrefix: ").Append(NamePrefix).Append("\n");
            sb.Append("  OrderNotes: ").Append(OrderNotes).Append("\n");
            sb.Append("  ParentInvoiceId: ").Append(ParentInvoiceId).Append("\n");
            sb.Append("  PaymentMethodId: ").Append(PaymentMethodId).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  RemainingBalance: ").Append(RemainingBalance).Append("\n");
            sb.Append("  Shipping: ").Append(Shipping).Append("\n");
            sb.Append("  ShippingAddress1: ").Append(ShippingAddress1).Append("\n");
            sb.Append("  ShippingAddress2: ").Append(ShippingAddress2).Append("\n");
            sb.Append("  ShippingCityName: ").Append(ShippingCityName).Append("\n");
            sb.Append("  ShippingCountryName: ").Append(ShippingCountryName).Append("\n");
            sb.Append("  ShippingFullName: ").Append(ShippingFullName).Append("\n");
            sb.Append("  ShippingPostalCode: ").Append(ShippingPostalCode).Append("\n");
            sb.Append("  ShippingStateName: ").Append(ShippingStateName).Append("\n");
            sb.Append("  Sort: ").Append(Sort).Append("\n");
            sb.Append("  StateTax: ").Append(StateTax).Append("\n");
            sb.Append("  Subtotal: ").Append(Subtotal).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
            sb.Append("  VendorId: ").Append(VendorId).Append("\n");
            sb.Append("  VendorName: ").Append(VendorName).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
