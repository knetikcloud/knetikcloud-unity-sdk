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
    public class RemoveCustomerEvent : BroadcastableEvent
    {
        /// <summary>
        /// Gets or Sets _Client
        /// </summary>
        [JsonProperty(PropertyName = "client")]
        public string _Client { get; set; }

        /// <summary>
        /// Gets or Sets Customer
        /// </summary>
        [JsonProperty(PropertyName = "customer")]
        public string Customer { get; set; }

        /// <summary>
        /// Gets or Sets DoNotBroadcast
        /// </summary>
        [JsonProperty(PropertyName = "do_not_broadcast")]
        public bool? DoNotBroadcast { get; set; }

        /// <summary>
        /// Gets or Sets Section
        /// </summary>
        [JsonProperty(PropertyName = "section")]
        public string Section { get; set; }

        /// <summary>
        /// Gets or Sets Source
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public Object Source { get; set; }

        /// <summary>
        /// Gets or Sets Specifics
        /// </summary>
        [JsonProperty(PropertyName = "specifics")]
        public string Specifics { get; set; }

        /// <summary>
        /// Gets or Sets Synchronous
        /// </summary>
        [JsonProperty(PropertyName = "synchronous")]
        public bool? Synchronous { get; set; }

        /// <summary>
        /// Gets or Sets Timestamp
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public long? Timestamp { get; set; }

        /// <summary>
        /// The type of the event. Used for polymorphic type recognition and thus must match an expected type
        /// </summary>
        /// <value>The type of the event. Used for polymorphic type recognition and thus must match an expected type</value>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets CustomerConfig
        /// </summary>
        [JsonProperty(PropertyName = "customer_config")]
        public CustomerConfig CustomerConfig { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RemoveCustomerEvent {\n");
            sb.Append("  _Client: ").Append(_Client).Append("\n");
            sb.Append("  Customer: ").Append(Customer).Append("\n");
            sb.Append("  DoNotBroadcast: ").Append(DoNotBroadcast).Append("\n");
            sb.Append("  Section: ").Append(Section).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  Specifics: ").Append(Specifics).Append("\n");
            sb.Append("  Synchronous: ").Append(Synchronous).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  CustomerConfig: ").Append(CustomerConfig).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public  new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
