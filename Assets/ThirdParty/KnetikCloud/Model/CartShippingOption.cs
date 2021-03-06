using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using KnetikUnity.Attributes;
using KnetikUnity.Serialization;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    
    
    public class CartShippingOption
    {
        /// <summary>
        /// Gets or Sets CurrencyCode
        /// </summary>
        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode;

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description;

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// Gets or Sets OriginalPrice
        /// </summary>
        [JsonProperty(PropertyName = "original_price")]
        public decimal? OriginalPrice;

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public decimal? Price;

        /// <summary>
        /// Gets or Sets ShippingItemId
        /// </summary>
        [JsonProperty(PropertyName = "shipping_item_id")]
        public int? ShippingItemId;

        /// <summary>
        /// Gets or Sets Sku
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public string Sku;

        /// <summary>
        /// Gets or Sets Taxable
        /// </summary>
        [JsonProperty(PropertyName = "taxable")]
        public bool? Taxable;

        /// <summary>
        /// Gets or Sets VendorId
        /// </summary>
        [JsonProperty(PropertyName = "vendor_id")]
        public int? VendorId;

        /// <summary>
        /// Gets or Sets VendorName
        /// </summary>
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
            sb.Append("class CartShippingOption {\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OriginalPrice: ").Append(OriginalPrice).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  ShippingItemId: ").Append(ShippingItemId).Append("\n");
            sb.Append("  Sku: ").Append(Sku).Append("\n");
            sb.Append("  Taxable: ").Append(Taxable).Append("\n");
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
