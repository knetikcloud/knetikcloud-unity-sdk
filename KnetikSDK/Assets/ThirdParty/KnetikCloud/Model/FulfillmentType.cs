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
    public class FulfillmentType
    {
        /// <summary>
        /// Whether the type is core and cannot be altered/deleted, read-only
        /// </summary>
        /// <value>Whether the type is core and cannot be altered/deleted, read-only</value>
        [JsonProperty(PropertyName = "core")]
        public bool? Core { get; set; }

        /// <summary>
        /// A description of the type
        /// </summary>
        /// <value>A description of the type</value>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The unique id of the type, read-only
        /// </summary>
        /// <value>The unique id of the type, read-only</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The name of the type
        /// </summary>
        /// <value>The name of the type</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FulfillmentType {\n");
            sb.Append("  Core: ").Append(Core).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
