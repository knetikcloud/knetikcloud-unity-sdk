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
    
    
    public class SimpleGroupResource
    {
        /// <summary>
        /// The name of the group. Max 50 characters
        /// </summary>
        /// <value>The name of the group. Max 50 characters</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// Unique name used in url and references. Uppercase, lowercase, numbers and hyphens only. Max 50 characters. Cannot be altered once created. Default: random UUID
        /// </summary>
        /// <value>Unique name used in url and references. Uppercase, lowercase, numbers and hyphens only. Max 50 characters. Cannot be altered once created. Default: random UUID</value>
        [JsonProperty(PropertyName = "unique_name")]
        public string UniqueName;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SimpleGroupResource {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  UniqueName: ").Append(UniqueName).Append("\n");
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
