using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Gets or Sets AvailableShippingOptions
        /// </summary>
        [JsonProperty(PropertyName = "available_shipping_options")]
        public List<CartShippingOption> AvailableShippingOptions { get; set; }

        /// <summary>
        /// Gets or Sets CountryTax
        /// </summary>
        [JsonProperty(PropertyName = "country_tax")]
        public decimal? CountryTax { get; set; }

        /// <summary>
        /// Gets or Sets Coupons
        /// </summary>
        [JsonProperty(PropertyName = "coupons")]
        public List<CouponDefinition> Coupons { get; set; }

        /// <summary>
        /// Gets or Sets Created
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public long? Created { get; set; }

        /// <summary>
        /// Gets or Sets CurrencyCode
        /// </summary>
        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or Sets DiscountTotal
        /// </summary>
        [JsonProperty(PropertyName = "discount_total")]
        public decimal? DiscountTotal { get; set; }

        /// <summary>
        /// Gets or Sets ErrorCode
        /// </summary>
        [JsonProperty(PropertyName = "error_code")]
        public int? ErrorCode { get; set; }

        /// <summary>
        /// Gets or Sets ErrorMessage
        /// </summary>
        [JsonProperty(PropertyName = "error_message")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or Sets GrandTotal
        /// </summary>
        [JsonProperty(PropertyName = "grand_total")]
        public decimal? GrandTotal { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets InvoiceId
        /// </summary>
        [JsonProperty(PropertyName = "invoice_id")]
        public decimal? InvoiceId { get; set; }

        /// <summary>
        /// Gets or Sets Items
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public List<CartLineItem> Items { get; set; }

        /// <summary>
        /// Gets or Sets Owner
        /// </summary>
        [JsonProperty(PropertyName = "owner")]
        public int? Owner { get; set; }

        /// <summary>
        /// Gets or Sets SelectedShippingOptions
        /// </summary>
        [JsonProperty(PropertyName = "selected_shipping_options")]
        public List<CartShippingOption> SelectedShippingOptions { get; set; }

        /// <summary>
        /// Gets or Sets Shippable
        /// </summary>
        [JsonProperty(PropertyName = "shippable")]
        public bool? Shippable { get; set; }

        /// <summary>
        /// Gets or Sets ShippingAddress
        /// </summary>
        [JsonProperty(PropertyName = "shipping_address")]
        public CartShippingAddressRequest ShippingAddress { get; set; }

        /// <summary>
        /// Gets or Sets ShippingCost
        /// </summary>
        [JsonProperty(PropertyName = "shipping_cost")]
        public decimal? ShippingCost { get; set; }

        /// <summary>
        /// Gets or Sets StateTax
        /// </summary>
        [JsonProperty(PropertyName = "state_tax")]
        public decimal? StateTax { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets Subtotal
        /// </summary>
        [JsonProperty(PropertyName = "subtotal")]
        public decimal? Subtotal { get; set; }

        /// <summary>
        /// Gets or Sets Updated
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public long? Updated { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Cart {\n");
            sb.Append("  AvailableShippingOptions: ").Append(AvailableShippingOptions).Append("\n");
            sb.Append("  CountryTax: ").Append(CountryTax).Append("\n");
            sb.Append("  Coupons: ").Append(Coupons).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  DiscountTotal: ").Append(DiscountTotal).Append("\n");
            sb.Append("  ErrorCode: ").Append(ErrorCode).Append("\n");
            sb.Append("  ErrorMessage: ").Append(ErrorMessage).Append("\n");
            sb.Append("  GrandTotal: ").Append(GrandTotal).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  SelectedShippingOptions: ").Append(SelectedShippingOptions).Append("\n");
            sb.Append("  Shippable: ").Append(Shippable).Append("\n");
            sb.Append("  ShippingAddress: ").Append(ShippingAddress).Append("\n");
            sb.Append("  ShippingCost: ").Append(ShippingCost).Append("\n");
            sb.Append("  StateTax: ").Append(StateTax).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Subtotal: ").Append(Subtotal).Append("\n");
            sb.Append("  Updated: ").Append(Updated).Append("\n");
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
