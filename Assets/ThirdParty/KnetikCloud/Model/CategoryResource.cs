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
    public class CategoryResource
    {
        /// <summary>
        /// Whether the category is currently active. If not, it and its questions will be filtered out.
        /// </summary>
        /// <value>Whether the category is currently active. If not, it and its questions will be filtered out.</value>
        [JsonProperty(PropertyName = "active")]
        public bool? Active { get; set; }

        /// <summary>
        /// A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type
        /// </summary>
        /// <value>A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties { get; set; }

        /// <summary>
        /// The unique ID for this category
        /// </summary>
        /// <value>The unique ID for this category</value>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of this category. Cannot be blank
        /// </summary>
        /// <value>The name of this category. Cannot be blank</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A category template this category is validated against (private). May be null and no validation of additional_properties will be done
        /// </summary>
        /// <value>A category template this category is validated against (private). May be null and no validation of additional_properties will be done</value>
        [JsonProperty(PropertyName = "template")]
        public string Template { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CategoryResource {\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
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
