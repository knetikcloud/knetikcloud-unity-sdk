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
    public class ListPropertyDefinitionResource : PropertyDefinitionResource
    {
        /// <summary>
        /// A list of the fields on both the property definition and property of this type
        /// </summary>
        /// <value>A list of the fields on both the property definition and property of this type</value>
        [JsonProperty(PropertyName = "field_list")]
        public PropertyFieldListResource FieldList { get; set; }

        /// <summary>
        /// The name of the property
        /// </summary>
        /// <value>The name of the property</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Whether the property is required
        /// </summary>
        /// <value>Whether the property is required</value>
        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        /// <summary>
        /// The type of the property. Used for polymorphic type recognition and thus must match an expected type with additional properties.
        /// </summary>
        /// <value>The type of the property. Used for polymorphic type recognition and thus must match an expected type with additional properties.</value>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// If provided, the maximum number of files in the group
        /// </summary>
        /// <value>If provided, the maximum number of files in the group</value>
        [JsonProperty(PropertyName = "max_count")]
        public int? MaxCount { get; set; }

        /// <summary>
        /// If provided, the minimum number of files in the group
        /// </summary>
        /// <value>If provided, the minimum number of files in the group</value>
        [JsonProperty(PropertyName = "min_count")]
        public int? MinCount { get; set; }

        /// <summary>
        /// If provided, a property definition for validating values within list
        /// </summary>
        /// <value>If provided, a property definition for validating values within list</value>
        [JsonProperty(PropertyName = "value_definition")]
        public PropertyDefinitionResource ValueDefinition { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ListPropertyDefinitionResource {\n");
            sb.Append("  FieldList: ").Append(FieldList).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Required: ").Append(Required).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  MaxCount: ").Append(MaxCount).Append("\n");
            sb.Append("  MinCount: ").Append(MinCount).Append("\n");
            sb.Append("  ValueDefinition: ").Append(ValueDefinition).Append("\n");
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
