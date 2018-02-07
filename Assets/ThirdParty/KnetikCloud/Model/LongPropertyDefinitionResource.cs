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
    /// 
    /// </summary>
    [KnetikFactory ("long")]
    
    public class LongPropertyDefinitionResource : PropertyDefinitionResource
    {
        /// <summary>
        /// If provided, the maximum value
        /// </summary>
        /// <value>If provided, the maximum value</value>
        [JsonProperty(PropertyName = "max")]
        public long? Max;

        /// <summary>
        /// If provided, the minimum value
        /// </summary>
        /// <value>If provided, the minimum value</value>
        [JsonProperty(PropertyName = "min")]
        public long? Min;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LongPropertyDefinitionResource {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  FieldList: ").Append(FieldList).Append("\n");
            sb.Append("  FriendlyName: ").Append(FriendlyName).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OptionLabelPath: ").Append(OptionLabelPath).Append("\n");
            sb.Append("  OptionValuePath: ").Append(OptionValuePath).Append("\n");
            sb.Append("  OptionsUrl: ").Append(OptionsUrl).Append("\n");
            sb.Append("  Required: ").Append(Required).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Max: ").Append(Max).Append("\n");
            sb.Append("  Min: ").Append(Min).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
