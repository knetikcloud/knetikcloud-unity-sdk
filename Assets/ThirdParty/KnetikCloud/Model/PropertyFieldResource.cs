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
    
    
    public class PropertyFieldResource
    {
        /// <summary>
        /// A description of the field
        /// </summary>
        /// <value>A description of the field</value>
        [JsonProperty(PropertyName = "description")]
        public string Description;

        /// <summary>
        /// The type of values within a 'list' type field
        /// </summary>
        /// <value>The type of values within a 'list' type field</value>
        [JsonProperty(PropertyName = "inner_type")]
        public string InnerType;

        /// <summary>
        /// A description of fields within objects within a 'list' type field, when inner_type is 'object'
        /// </summary>
        /// <value>A description of fields within objects within a 'list' type field, when inner_type is 'object'</value>
        [JsonProperty(PropertyName = "inner_type_fields")]
        public List<PropertyFieldResource> InnerTypeFields;

        /// <summary>
        /// The name of the field
        /// </summary>
        /// <value>The name of the field</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// Whether the field is required
        /// </summary>
        /// <value>Whether the field is required</value>
        [JsonProperty(PropertyName = "required")]
        public bool? Required;

        /// <summary>
        /// The type of the field
        /// </summary>
        /// <value>The type of the field</value>
        [JsonProperty(PropertyName = "type")]
        public string Type;

        /// <summary>
        /// A list of valid values for 'enum' type fields
        /// </summary>
        /// <value>A list of valid values for 'enum' type fields</value>
        [JsonProperty(PropertyName = "valid_values")]
        public List<string> ValidValues;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PropertyFieldResource {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  InnerType: ").Append(InnerType).Append("\n");
            sb.Append("  InnerTypeFields: ").Append(InnerTypeFields).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Required: ").Append(Required).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  ValidValues: ").Append(ValidValues).Append("\n");
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
