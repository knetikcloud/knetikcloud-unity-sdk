using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    public class IOConfig
    {
        /// <summary>
        /// Gets or Sets Customer
        /// </summary>
        [JsonProperty(PropertyName = "customer")]
        public string Customer { get; set; }

        /// <summary>
        /// Gets or Sets Enabled
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or Sets Environment
        /// </summary>
        [JsonProperty(PropertyName = "environment")]
        public string Environment { get; set; }

        /// <summary>
        /// Gets or Sets Product
        /// </summary>
        [JsonProperty(PropertyName = "product")]
        public string Product { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class IOConfig {\n");
            sb.Append("  Customer: ").Append(Customer).Append("\n");
            sb.Append("  Enabled: ").Append(Enabled).Append("\n");
            sb.Append("  Environment: ").Append(Environment).Append("\n");
            sb.Append("  Product: ").Append(Product).Append("\n");
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
