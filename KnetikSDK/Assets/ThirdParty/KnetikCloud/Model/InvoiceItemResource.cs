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
    public class InvoiceItemResource
    {
        /// <summary>
        /// Gets or Sets BundleSku
        /// </summary>
        [JsonProperty(PropertyName = "bundle_sku")]
        public string BundleSku { get; set; }

        /// <summary>
        /// Gets or Sets CurrentFulfillmentStatus
        /// </summary>
        [JsonProperty(PropertyName = "current_fulfillment_status")]
        public string CurrentFulfillmentStatus { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets InvoiceId
        /// </summary>
        [JsonProperty(PropertyName = "invoice_id")]
        public int? InvoiceId { get; set; }

        /// <summary>
        /// Gets or Sets ItemId
        /// </summary>
        [JsonProperty(PropertyName = "item_id")]
        public int? ItemId { get; set; }

        /// <summary>
        /// Gets or Sets ItemName
        /// </summary>
        [JsonProperty(PropertyName = "item_name")]
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or Sets OriginalTotalPrice
        /// </summary>
        [JsonProperty(PropertyName = "original_total_price")]
        public double? OriginalTotalPrice { get; set; }

        /// <summary>
        /// Gets or Sets OriginalUnitPrice
        /// </summary>
        [JsonProperty(PropertyName = "original_unit_price")]
        public double? OriginalUnitPrice { get; set; }

        /// <summary>
        /// Gets or Sets Qty
        /// </summary>
        [JsonProperty(PropertyName = "qty")]
        public int? Qty { get; set; }

        /// <summary>
        /// Gets or Sets SaleName
        /// </summary>
        [JsonProperty(PropertyName = "sale_name")]
        public string SaleName { get; set; }

        /// <summary>
        /// Gets or Sets Sku
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Gets or Sets SkuDescription
        /// </summary>
        [JsonProperty(PropertyName = "sku_description")]
        public string SkuDescription { get; set; }

        /// <summary>
        /// Gets or Sets SystemPrice
        /// </summary>
        [JsonProperty(PropertyName = "system_price")]
        public double? SystemPrice { get; set; }

        /// <summary>
        /// Gets or Sets TotalPrice
        /// </summary>
        [JsonProperty(PropertyName = "total_price")]
        public double? TotalPrice { get; set; }

        /// <summary>
        /// Gets or Sets TypeHint
        /// </summary>
        [JsonProperty(PropertyName = "type_hint")]
        public string TypeHint { get; set; }

        /// <summary>
        /// Gets or Sets UnitPrice
        /// </summary>
        [JsonProperty(PropertyName = "unit_price")]
        public double? UnitPrice { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class InvoiceItemResource {\n");
            sb.Append("  BundleSku: ").Append(BundleSku).Append("\n");
            sb.Append("  CurrentFulfillmentStatus: ").Append(CurrentFulfillmentStatus).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
            sb.Append("  ItemName: ").Append(ItemName).Append("\n");
            sb.Append("  OriginalTotalPrice: ").Append(OriginalTotalPrice).Append("\n");
            sb.Append("  OriginalUnitPrice: ").Append(OriginalUnitPrice).Append("\n");
            sb.Append("  Qty: ").Append(Qty).Append("\n");
            sb.Append("  SaleName: ").Append(SaleName).Append("\n");
            sb.Append("  Sku: ").Append(Sku).Append("\n");
            sb.Append("  SkuDescription: ").Append(SkuDescription).Append("\n");
            sb.Append("  SystemPrice: ").Append(SystemPrice).Append("\n");
            sb.Append("  TotalPrice: ").Append(TotalPrice).Append("\n");
            sb.Append("  TypeHint: ").Append(TypeHint).Append("\n");
            sb.Append("  UnitPrice: ").Append(UnitPrice).Append("\n");
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