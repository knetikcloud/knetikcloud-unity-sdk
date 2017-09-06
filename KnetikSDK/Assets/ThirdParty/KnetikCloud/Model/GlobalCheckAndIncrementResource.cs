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
    public class GlobalCheckAndIncrementResource
    {
        /// <summary>
        /// Gets or Sets CheckValueResource
        /// </summary>
        [JsonProperty(PropertyName = "check_value_resource")]
        public ExpressionResource CheckValueResource { get; set; }

        /// <summary>
        /// Gets or Sets GlobalResource
        /// </summary>
        [JsonProperty(PropertyName = "global_resource")]
        public ExpressionResource GlobalResource { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GlobalCheckAndIncrementResource {\n");
            sb.Append("  CheckValueResource: ").Append(CheckValueResource).Append("\n");
            sb.Append("  GlobalResource: ").Append(GlobalResource).Append("\n");
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
