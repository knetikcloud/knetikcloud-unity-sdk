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
    /// Expressions are instructions for the rule engine to resolve certain values. For example instead of &#x60;user 1&#x60; it&#39;d state &#x60;user provided by the event&#x60;. Full list and definitions available at GET /bre/expressions.
    /// </summary>
    
    
    public class GlobalCheckAndIncrementResource
    {
        /// <summary>
        /// Gets or Sets CheckValueResource
        /// </summary>
        [JsonProperty(PropertyName = "check_value_resource")]
        public ExpressionResource CheckValueResource;

        /// <summary>
        /// Gets or Sets Definition
        /// </summary>
        [JsonProperty(PropertyName = "definition")]
        public string Definition;

        /// <summary>
        /// Gets or Sets GlobalResource
        /// </summary>
        [JsonProperty(PropertyName = "global_resource")]
        public ExpressionResource GlobalResource;

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GlobalCheckAndIncrementResource {\n");
            sb.Append("  CheckValueResource: ").Append(CheckValueResource).Append("\n");
            sb.Append("  Definition: ").Append(Definition).Append("\n");
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
