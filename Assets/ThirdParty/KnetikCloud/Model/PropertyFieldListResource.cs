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
    
    
    public class PropertyFieldListResource
    {
        /// <summary>
        /// A list of fields for the property definition.
        /// </summary>
        /// <value>A list of fields for the property definition.</value>
        [JsonProperty(PropertyName = "property_definition_fields")]
        public List<PropertyFieldResource> PropertyDefinitionFields;

        /// <summary>
        /// A list of fields for the property.
        /// </summary>
        /// <value>A list of fields for the property.</value>
        [JsonProperty(PropertyName = "property_fields")]
        public List<PropertyFieldResource> PropertyFields;

        /// <summary>
        /// The type for the property this describes.
        /// </summary>
        /// <value>The type for the property this describes.</value>
        [JsonProperty(PropertyName = "property_type")]
        public string PropertyType;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PropertyFieldListResource {\n");
            sb.Append("  PropertyDefinitionFields: ").Append(PropertyDefinitionFields).Append("\n");
            sb.Append("  PropertyFields: ").Append(PropertyFields).Append("\n");
            sb.Append("  PropertyType: ").Append(PropertyType).Append("\n");
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
