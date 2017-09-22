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
    public class BundledSku
    {
        /// <summary>
        /// The amount this item will cost inside the bundle instead of its regular price
        /// </summary>
        /// <value>The amount this item will cost inside the bundle instead of its regular price</value>
        [JsonProperty(PropertyName = "price_override")]
        public decimal? PriceOverride { get; set; }

        /// <summary>
        /// The quantity of this item within the bundle
        /// </summary>
        /// <value>The quantity of this item within the bundle</value>
        [JsonProperty(PropertyName = "quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// The stock keeping unit (SKU) for an item included in the bundle
        /// </summary>
        /// <value>The stock keeping unit (SKU) for an item included in the bundle</value>
        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BundledSku {\n");
            sb.Append("  PriceOverride: ").Append(PriceOverride).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  Sku: ").Append(Sku).Append("\n");
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
