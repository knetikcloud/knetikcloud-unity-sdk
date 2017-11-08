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
    
    
    public class PollResource
    {
        /// <summary>
        /// Whether the poll is active
        /// </summary>
        /// <value>Whether the poll is active</value>
        [JsonProperty(PropertyName = "active")]
        public bool? Active;

        /// <summary>
        /// A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type
        /// </summary>
        /// <value>A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties;

        /// <summary>
        /// The answers to the poll
        /// </summary>
        /// <value>The answers to the poll</value>
        [JsonProperty(PropertyName = "answers")]
        public List<PollAnswerResource> Answers;

        /// <summary>
        /// The category for the poll
        /// </summary>
        /// <value>The category for the poll</value>
        [JsonProperty(PropertyName = "category")]
        public NestedCategory Category;

        /// <summary>
        /// The date/time this resource was created in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The id of the poll
        /// </summary>
        /// <value>The id of the poll</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// The tags for the poll
        /// </summary>
        /// <value>The tags for the poll</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags;

        /// <summary>
        /// A poll template this poll is validated against (private). May be null and no validation of additional_properties will be done
        /// </summary>
        /// <value>A poll template this poll is validated against (private). May be null and no validation of additional_properties will be done</value>
        [JsonProperty(PropertyName = "template")]
        public string Template;

        /// <summary>
        /// The text of the poll
        /// </summary>
        /// <value>The text of the poll</value>
        [JsonProperty(PropertyName = "text")]
        public string Text;

        /// <summary>
        /// The media type of the poll
        /// </summary>
        /// <value>The media type of the poll</value>
        [JsonProperty(PropertyName = "type")]
        public string Type;

        /// <summary>
        /// The date/time this resource was last updated in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was last updated in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PollResource {\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  Answers: ").Append(Answers).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
