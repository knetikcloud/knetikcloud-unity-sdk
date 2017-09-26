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
    public class StoreItemTemplateResource
    {
        /// <summary>
        /// Whether to allow additional properties beyond those specified or not
        /// </summary>
        /// <value>Whether to allow additional properties beyond those specified or not</value>
        [JsonProperty(PropertyName = "allow_additional")]
        public bool? AllowAdditional { get; set; }

        /// <summary>
        /// The customized behaviors that are required or default for this type of item
        /// </summary>
        /// <value>The customized behaviors that are required or default for this type of item</value>
        [JsonProperty(PropertyName = "behaviors")]
        public List<ItemBehaviorDefinitionResource> Behaviors { get; set; }

        /// <summary>
        /// The date/time this resource was created in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate { get; set; }

        /// <summary>
        /// The id of the template
        /// </summary>
        /// <value>The id of the template</value>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the template
        /// </summary>
        /// <value>The name of the template</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The customized properties that are present
        /// </summary>
        /// <value>The customized properties that are present</value>
        [JsonProperty(PropertyName = "properties")]
        public List<PropertyDefinitionResource> Properties { get; set; }

        /// <summary>
        /// A template to apply to all skus on an item using this template
        /// </summary>
        /// <value>A template to apply to all skus on an item using this template</value>
        [JsonProperty(PropertyName = "sku_template")]
        public TemplateResource SkuTemplate { get; set; }

        /// <summary>
        /// The date/time this resource was last updated in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was last updated in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class StoreItemTemplateResource {\n");
            sb.Append("  AllowAdditional: ").Append(AllowAdditional).Append("\n");
            sb.Append("  Behaviors: ").Append(Behaviors).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
            sb.Append("  SkuTemplate: ").Append(SkuTemplate).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
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
