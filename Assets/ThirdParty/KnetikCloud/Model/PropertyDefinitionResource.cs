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
    
    [JsonConverter(typeof(KnetikJsonConverter<PropertyDefinitionResource>))]
    public class PropertyDefinitionResource
    {
        /// <summary>
        /// The description of the property
        /// </summary>
        /// <value>The description of the property</value>
        [JsonProperty(PropertyName = "description")]
        public string Description;

        /// <summary>
        /// A list of the fields on both the property definition and property of this type
        /// </summary>
        /// <value>A list of the fields on both the property definition and property of this type</value>
        [JsonProperty(PropertyName = "field_list")]
        public PropertyFieldListResource FieldList;

        /// <summary>
        /// The friendly front-facing name of the property
        /// </summary>
        /// <value>The friendly front-facing name of the property</value>
        [JsonProperty(PropertyName = "friendly_name")]
        public string FriendlyName;

        /// <summary>
        /// The name of the property
        /// </summary>
        /// <value>The name of the property</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The JSON path to the option label
        /// </summary>
        /// <value>The JSON path to the option label</value>
        [JsonProperty(PropertyName = "option_label_path")]
        public string OptionLabelPath;

        /// <summary>
        /// The JSON path to the option value
        /// </summary>
        /// <value>The JSON path to the option value</value>
        [JsonProperty(PropertyName = "option_value_path")]
        public string OptionValuePath;

        /// <summary>
        /// URL of service containing the property options (assumed JSON array)
        /// </summary>
        /// <value>URL of service containing the property options (assumed JSON array)</value>
        [JsonProperty(PropertyName = "options_url")]
        public string OptionsUrl;

        /// <summary>
        /// Whether the property is required
        /// </summary>
        /// <value>Whether the property is required</value>
        [JsonProperty(PropertyName = "required")]
        public bool? Required;

        /// <summary>
        /// The type of the property. Used for polymorphic type recognition and thus must match an expected type with additional properties.
        /// </summary>
        /// <value>The type of the property. Used for polymorphic type recognition and thus must match an expected type with additional properties.</value>
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
            sb.Append("class PropertyDefinitionResource {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  FieldList: ").Append(FieldList).Append("\n");
            sb.Append("  FriendlyName: ").Append(FriendlyName).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OptionLabelPath: ").Append(OptionLabelPath).Append("\n");
            sb.Append("  OptionValuePath: ").Append(OptionValuePath).Append("\n");
            sb.Append("  OptionsUrl: ").Append(OptionsUrl).Append("\n");
            sb.Append("  Required: ").Append(Required).Append("\n");
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
