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
    /// 
    /// </summary>
    [KnetikFactory ("map")]
    
    public class MapPropertyDefinitionResource : PropertyDefinitionResource
    {
        /// <summary>
        /// Whether to allow additional properties beyond those specified or not
        /// </summary>
        /// <value>Whether to allow additional properties beyond those specified or not</value>
        [JsonProperty(PropertyName = "allow_additional")]
        public bool? AllowAdditional;

        /// <summary>
        /// If provided, a list of property definitions for each map entry
        /// </summary>
        /// <value>If provided, a list of property definitions for each map entry</value>
        [JsonProperty(PropertyName = "properties")]
        public List<PropertyDefinitionResource> Properties;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MapPropertyDefinitionResource {\n");
            sb.Append("  FieldList: ").Append(FieldList).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Required: ").Append(Required).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  AllowAdditional: ").Append(AllowAdditional).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
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
