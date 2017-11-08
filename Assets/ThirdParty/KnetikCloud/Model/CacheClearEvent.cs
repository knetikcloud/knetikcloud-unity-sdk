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
    [KnetikFactory ("cache_clear")]
    
    public class CacheClearEvent : BroadcastableEvent
    {
        /// <summary>
        /// Gets or Sets CustomerSetup
        /// </summary>
        [JsonProperty(PropertyName = "customer_setup")]
        public bool? CustomerSetup;

        /// <summary>
        /// Gets or Sets CustomerTeardown
        /// </summary>
        [JsonProperty(PropertyName = "customer_teardown")]
        public bool? CustomerTeardown;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CacheClearEvent {\n");
            sb.Append("  _Client: ").Append(_Client).Append("\n");
            sb.Append("  Customer: ").Append(Customer).Append("\n");
            sb.Append("  DoNotBroadcast: ").Append(DoNotBroadcast).Append("\n");
            sb.Append("  Section: ").Append(Section).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  Specifics: ").Append(Specifics).Append("\n");
            sb.Append("  Synchronous: ").Append(Synchronous).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  CustomerSetup: ").Append(CustomerSetup).Append("\n");
            sb.Append("  CustomerTeardown: ").Append(CustomerTeardown).Append("\n");
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
