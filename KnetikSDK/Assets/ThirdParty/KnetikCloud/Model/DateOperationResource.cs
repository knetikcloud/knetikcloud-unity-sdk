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
    public class DateOperationResource
    {
        /// <summary>
        /// Gets or Sets Args
        /// </summary>
        [JsonProperty(PropertyName = "args")]
        public List<ExpressionResource> Args { get; set; }

        /// <summary>
        /// Gets or Sets Op
        /// </summary>
        [JsonProperty(PropertyName = "op")]
        public string Op { get; set; }

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
            sb.Append("class DateOperationResource {\n");
            sb.Append("  Args: ").Append(Args).Append("\n");
            sb.Append("  Op: ").Append(Op).Append("\n");
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
