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
    public class SubscriptionPriceOverrideRequest
    {
        /// <summary>
        /// The recurring price that has been set to override the base price. Null if not overriding
        /// </summary>
        /// <value>The recurring price that has been set to override the base price. Null if not overriding</value>
        [JsonProperty(PropertyName = "new_price")]
        public decimal? NewPrice { get; set; }

        /// <summary>
        /// An explanation for the reason the price is being overridden
        /// </summary>
        /// <value>An explanation for the reason the price is being overridden</value>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SubscriptionPriceOverrideRequest {\n");
            sb.Append("  NewPrice: ").Append(NewPrice).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
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
