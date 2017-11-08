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
    
    
    public class NestedCategory
    {
        /// <summary>
        /// Whether the category is active
        /// </summary>
        /// <value>Whether the category is active</value>
        [JsonProperty(PropertyName = "active")]
        public bool? Active;

        /// <summary>
        /// The id of the category
        /// </summary>
        /// <value>The id of the category</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// The name of the category
        /// </summary>
        /// <value>The name of the category</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class NestedCategory {\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
