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
    public class CurrencyResource
    {
        /// <summary>
        /// Whether the currency is active. Default true
        /// </summary>
        /// <value>Whether the currency is active. Default true</value>
        [JsonProperty(PropertyName = "active")]
        public bool? Active { get; set; }

        /// <summary>
        /// The unique id code for the currency. Maximum 5 characters
        /// </summary>
        /// <value>The unique id code for the currency. Maximum 5 characters</value>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// The unix timestamp in seconds the currency was added to the system
        /// </summary>
        /// <value>The unix timestamp in seconds the currency was added to the system</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate { get; set; }

        /// <summary>
        /// The decimal to multiply the system base currency (from config 'currency') to localize to this one. Should be 1 for the base currency itself.
        /// </summary>
        /// <value>The decimal to multiply the system base currency (from config 'currency') to localize to this one. Should be 1 for the base currency itself.</value>
        [JsonProperty(PropertyName = "factor")]
        public double? Factor { get; set; }

        /// <summary>
        /// The url for an icon of the currency
        /// </summary>
        /// <value>The url for an icon of the currency</value>
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// The name of the currency
        /// </summary>
        /// <value>The name of the currency</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The type of currency. Default 'real'
        /// </summary>
        /// <value>The type of currency. Default 'real'</value>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The unix timestamp in seconds the currency was last updated in the system.
        /// </summary>
        /// <value>The unix timestamp in seconds the currency was last updated in the system.</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CurrencyResource {\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Factor: ").Append(Factor).Append("\n");
            sb.Append("  Icon: ").Append(Icon).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
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
