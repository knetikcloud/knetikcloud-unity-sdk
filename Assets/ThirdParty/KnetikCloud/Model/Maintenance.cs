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
    public class Maintenance
    {
        /// <summary>
        /// Whether access to the system has been locked
        /// </summary>
        /// <value>Whether access to the system has been locked</value>
        [JsonProperty(PropertyName = "access_locked")]
        public bool? AccessLocked { get; set; }

        /// <summary>
        /// A simple object of any schema for client side use and processing
        /// </summary>
        /// <value>A simple object of any schema for client side use and processing</value>
        [JsonProperty(PropertyName = "details")]
        public Object Details { get; set; }

        /// <summary>
        /// User displayable message about the maintenance
        /// </summary>
        /// <value>User displayable message about the maintenance</value>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Maintenance {\n");
            sb.Append("  AccessLocked: ").Append(AccessLocked).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
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
