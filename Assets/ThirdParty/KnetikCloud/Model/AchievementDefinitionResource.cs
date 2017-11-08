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
    
    
    public class AchievementDefinitionResource
    {
        /// <summary>
        /// A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this resource type
        /// </summary>
        /// <value>A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this resource type</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties;

        /// <summary>
        /// The date/time this resource was created in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The description of the achievement. Must be at least 2 characters in length.
        /// </summary>
        /// <value>The description of the achievement. Must be at least 2 characters in length.</value>
        [JsonProperty(PropertyName = "description")]
        public string Description;

        /// <summary>
        /// Whether the achievement is hidden from the user
        /// </summary>
        /// <value>Whether the achievement is hidden from the user</value>
        [JsonProperty(PropertyName = "hidden")]
        public bool? Hidden;

        /// <summary>
        /// The name of the achievement. Must be at least 6 characters in length. IMMUTABLE
        /// </summary>
        /// <value>The name of the achievement. Must be at least 6 characters in length. IMMUTABLE</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The required progress for the achievement definition
        /// </summary>
        /// <value>The required progress for the achievement definition</value>
        [JsonProperty(PropertyName = "required_progress")]
        public int? RequiredProgress;

        /// <summary>
        /// The id of the rule generated for this achievement
        /// </summary>
        /// <value>The id of the rule generated for this achievement</value>
        [JsonProperty(PropertyName = "rule_id")]
        public string RuleId;

        /// <summary>
        /// The tags for the achievement definition
        /// </summary>
        /// <value>The tags for the achievement definition</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags;

        /// <summary>
        /// An achievement template this achievement is validated against (private). May be null and no validation of additional_properties will be done
        /// </summary>
        /// <value>An achievement template this achievement is validated against (private). May be null and no validation of additional_properties will be done</value>
        [JsonProperty(PropertyName = "template")]
        public string Template;

        /// <summary>
        /// The name of the trigger event associated with this achievement
        /// </summary>
        /// <value>The name of the trigger event associated with this achievement</value>
        [JsonProperty(PropertyName = "trigger_event_name")]
        public string TriggerEventName;

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
            sb.Append("class AchievementDefinitionResource {\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Hidden: ").Append(Hidden).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  RequiredProgress: ").Append(RequiredProgress).Append("\n");
            sb.Append("  RuleId: ").Append(RuleId).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
            sb.Append("  TriggerEventName: ").Append(TriggerEventName).Append("\n");
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
