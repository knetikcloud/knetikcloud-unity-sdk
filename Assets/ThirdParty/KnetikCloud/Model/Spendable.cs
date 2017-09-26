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
    public class Spendable : Behavior
    {
        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Used for polymorphic type recognition and thus must match an expected type with additional properties
        /// </summary>
        /// <value>Used for polymorphic type recognition and thus must match an expected type with additional properties</value>
        [JsonProperty(PropertyName = "type_hint")]
        public string TypeHint { get; set; }

        /// <summary>
        /// The code of the currency
        /// </summary>
        /// <value>The code of the currency</value>
        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The spendable value
        /// </summary>
        /// <value>The spendable value</value>
        [JsonProperty(PropertyName = "value")]
        public int? Value { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Spendable {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  TypeHint: ").Append(TypeHint).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public  new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
