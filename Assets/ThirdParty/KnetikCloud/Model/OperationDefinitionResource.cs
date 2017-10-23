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
    public class OperationDefinitionResource
    {
        /// <summary>
        /// Gets or Sets Arguments
        /// </summary>
        [JsonProperty(PropertyName = "arguments")]
        public List<ArgumentResource> Arguments { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets _Operator
        /// </summary>
        [JsonProperty(PropertyName = "operator")]
        public ModelOperator _Operator { get; set; }

        /// <summary>
        /// Gets or Sets ReturnType
        /// </summary>
        [JsonProperty(PropertyName = "return_type")]
        public string ReturnType { get; set; }

        /// <summary>
        /// Gets or Sets Template
        /// </summary>
        [JsonProperty(PropertyName = "template")]
        public string Template { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OperationDefinitionResource {\n");
            sb.Append("  Arguments: ").Append(Arguments).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  _Operator: ").Append(_Operator).Append("\n");
            sb.Append("  ReturnType: ").Append(ReturnType).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
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
