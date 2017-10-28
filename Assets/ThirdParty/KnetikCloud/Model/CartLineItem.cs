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
    public class CartLineItem
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
        /// Gets or Sets Discount
        /// </summary>
        [JsonProperty(PropertyName = "discount")]
        public Discount Discount;

        /// <summary>
        /// Gets or Sets LineTotal
        /// </summary>
        [JsonProperty(PropertyName = "line_total")]
        public decimal? LineTotal;

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// Gets or Sets OriginalLineTotal
        /// </summary>
        [JsonProperty(PropertyName = "original_line_total")]
        public decimal? OriginalLineTotal;

        /// <summary>
        /// Gets or Sets OriginalUnitPrice
        /// </summary>
        [JsonProperty(PropertyName = "original_unit_price")]
        public decimal? OriginalUnitPrice;

        /// <summary>
        /// Gets or Sets Qty
        /// </summary>
        [JsonProperty(PropertyName = "qty")]
        public int? Qty;

        /// <summary>
        /// Gets or Sets SaleName
        /// </summary>
        [JsonProperty(PropertyName = "sale_name")]
        public string SaleName;

        /// <summary>
        /// Gets or Sets Sku
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public string Sku;

        /// <summary>
        /// Gets or Sets SkuDescription
        /// </summary>
        [JsonProperty(PropertyName = "sku_description")]
        public string SkuDescription;

        /// <summary>
        /// Gets or Sets StoreItemId
        /// </summary>
        [JsonProperty(PropertyName = "store_item_id")]
        public int? StoreItemId;

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags;

        /// <summary>
        /// Gets or Sets ThumbUrl
        /// </summary>
        [JsonProperty(PropertyName = "thumb_url")]
        public string ThumbUrl;

        /// <summary>
        /// Gets or Sets UniqueKey
        /// </summary>
        [JsonProperty(PropertyName = "unique_key")]
        public string UniqueKey;

        /// <summary>
        /// Gets or Sets UnitPrice
        /// </summary>
        [JsonProperty(PropertyName = "unit_price")]
        public decimal? UnitPrice;

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
            sb.Append("class CartLineItem {\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Discount: ").Append(Discount).Append("\n");
            sb.Append("  LineTotal: ").Append(LineTotal).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OriginalLineTotal: ").Append(OriginalLineTotal).Append("\n");
            sb.Append("  OriginalUnitPrice: ").Append(OriginalUnitPrice).Append("\n");
            sb.Append("  Qty: ").Append(Qty).Append("\n");
            sb.Append("  SaleName: ").Append(SaleName).Append("\n");
            sb.Append("  Sku: ").Append(Sku).Append("\n");
            sb.Append("  SkuDescription: ").Append(SkuDescription).Append("\n");
            sb.Append("  StoreItemId: ").Append(StoreItemId).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  ThumbUrl: ").Append(ThumbUrl).Append("\n");
            sb.Append("  UniqueKey: ").Append(UniqueKey).Append("\n");
            sb.Append("  UnitPrice: ").Append(UnitPrice).Append("\n");
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
