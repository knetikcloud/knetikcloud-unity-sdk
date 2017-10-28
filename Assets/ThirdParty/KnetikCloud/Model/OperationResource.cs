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
    /// Expressions are instructions for the rule engine to resolve certain values. For example instead of &#x60;user 1&#x60; it&#39;d state &#x60;user provided by the event&#x60;. Full list and definitions available at GET /bre/expressions.
    /// </summary>
    public class OperationResource
    {
        /// <summary>
        /// The arguments the operator apply to. See notes for details.
        /// </summary>
        /// <value>The arguments the operator apply to. See notes for details.</value>
        [JsonProperty(PropertyName = "args")]
        public List<ExpressionResource> Args;

        /// <summary>
        /// Gets or Sets Definition
        /// </summary>
        [JsonProperty(PropertyName = "definition")]
        public string Definition;

        /// <summary>
        /// The operator to be used in this predicate. See notes for details.
        /// </summary>
        /// <value>The operator to be used in this predicate. See notes for details.</value>
        [JsonProperty(PropertyName = "op")]
        public string Op;

        /// <summary>
        /// Gets or Sets ReturnType
        /// </summary>
        [JsonProperty(PropertyName = "return_type")]
        public string ReturnType;

        /// <summary>
        /// The operators supported by this expression
        /// </summary>
        /// <value>The operators supported by this expression</value>
        [JsonProperty(PropertyName = "supported_operators")]
        public List<OperationDefinitionResource> SupportedOperators;

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
            sb.Append("class OperationResource {\n");
            sb.Append("  Args: ").Append(Args).Append("\n");
            sb.Append("  Definition: ").Append(Definition).Append("\n");
            sb.Append("  Op: ").Append(Op).Append("\n");
            sb.Append("  ReturnType: ").Append(ReturnType).Append("\n");
            sb.Append("  SupportedOperators: ").Append(SupportedOperators).Append("\n");
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
