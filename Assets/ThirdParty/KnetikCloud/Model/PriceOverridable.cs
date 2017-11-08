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
    [KnetikFactory ("price_overridable")]
    
    public class PriceOverridable : Behavior
    {
        /// <summary>
        /// The maximum price allowed
        /// </summary>
        /// <value>The maximum price allowed</value>
        [JsonProperty(PropertyName = "max_price")]
        public decimal? MaxPrice;

        /// <summary>
        /// The minimum price allowed
        /// </summary>
        /// <value>The minimum price allowed</value>
        [JsonProperty(PropertyName = "min_price")]
        public decimal? MinPrice;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PriceOverridable {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  TypeHint: ").Append(TypeHint).Append("\n");
            sb.Append("  MaxPrice: ").Append(MaxPrice).Append("\n");
            sb.Append("  MinPrice: ").Append(MinPrice).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
