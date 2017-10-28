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
    public class Order
    {
        /// <summary>
        /// Gets or Sets Ascending
        /// </summary>
        [JsonProperty(PropertyName = "ascending")]
        public bool? Ascending;

        /// <summary>
        /// Gets or Sets Descending
        /// </summary>
        [JsonProperty(PropertyName = "descending")]
        public bool? Descending;

        /// <summary>
        /// Gets or Sets Direction
        /// </summary>
        [JsonProperty(PropertyName = "direction")]
        public string Direction;

        /// <summary>
        /// Gets or Sets IgnoreCase
        /// </summary>
        [JsonProperty(PropertyName = "ignore_case")]
        public bool? IgnoreCase;

        /// <summary>
        /// Gets or Sets NullHandling
        /// </summary>
        [JsonProperty(PropertyName = "null_handling")]
        public string NullHandling;

        /// <summary>
        /// Gets or Sets Property
        /// </summary>
        [JsonProperty(PropertyName = "property")]
        public string Property;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Order {\n");
            sb.Append("  Ascending: ").Append(Ascending).Append("\n");
            sb.Append("  Descending: ").Append(Descending).Append("\n");
            sb.Append("  Direction: ").Append(Direction).Append("\n");
            sb.Append("  IgnoreCase: ").Append(IgnoreCase).Append("\n");
            sb.Append("  NullHandling: ").Append(NullHandling).Append("\n");
            sb.Append("  Property: ").Append(Property).Append("\n");
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
