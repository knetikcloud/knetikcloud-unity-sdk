using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using KnetikUnity.Attributes;
using KnetikUnity.Serialization;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    
    
    public class BreActionLog
    {
        /// <summary>
        /// The name of the action
        /// </summary>
        /// <value>The name of the action</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The runtime of the action in milliseconds
        /// </summary>
        /// <value>The runtime of the action in milliseconds</value>
        [JsonProperty(PropertyName = "runtime")]
        public long? Runtime;

        /// <summary>
        /// The status of the action (ran, failed)
        /// </summary>
        /// <value>The status of the action (ran, failed)</value>
        [JsonProperty(PropertyName = "status")]
        public string Status;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BreActionLog {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Runtime: ").Append(Runtime).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
