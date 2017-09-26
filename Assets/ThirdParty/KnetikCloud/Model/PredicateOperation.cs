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
    public class PredicateOperation
    {
        /// <summary>
        /// Gets or Sets Args
        /// </summary>
        [JsonProperty(PropertyName = "args")]
        public List<Expressionobject> Args { get; set; }

        /// <summary>
        /// Gets or Sets _Operator
        /// </summary>
        [JsonProperty(PropertyName = "operator")]
        public ModelOperator _Operator { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PredicateOperation {\n");
            sb.Append("  Args: ").Append(Args).Append("\n");
            sb.Append("  _Operator: ").Append(_Operator).Append("\n");
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
