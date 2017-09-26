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
    public class Consumable : Behavior
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
        /// The maximum number of times an item can be used
        /// </summary>
        /// <value>The maximum number of times an item can be used</value>
        [JsonProperty(PropertyName = "max_use")]
        public int? MaxUse { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Consumable {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  TypeHint: ").Append(TypeHint).Append("\n");
            sb.Append("  MaxUse: ").Append(MaxUse).Append("\n");
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
