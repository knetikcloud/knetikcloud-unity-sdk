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
    public class GlobalResource
    {
        /// <summary>
        /// Gets or Sets GlobalDefId
        /// </summary>
        [JsonProperty(PropertyName = "global_def_id")]
        public string GlobalDefId { get; set; }

        /// <summary>
        /// Gets or Sets Scopes
        /// </summary>
        [JsonProperty(PropertyName = "scopes")]
        public Dictionary<string, ExpressionResource> Scopes { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GlobalResource {\n");
            sb.Append("  GlobalDefId: ").Append(GlobalDefId).Append("\n");
            sb.Append("  Scopes: ").Append(Scopes).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
