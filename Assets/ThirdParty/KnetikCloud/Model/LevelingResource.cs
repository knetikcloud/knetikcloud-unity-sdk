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
    public class LevelingResource
    {
        /// <summary>
        /// A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type
        /// </summary>
        /// <value>A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties { get; set; }

        /// <summary>
        /// The date the leveling schema was created
        /// </summary>
        /// <value>The date the leveling schema was created</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate { get; set; }

        /// <summary>
        /// The description of the leveling schema
        /// </summary>
        /// <value>The description of the leveling schema</value>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The name of the leveling schema.  IMMUTABLE
        /// </summary>
        /// <value>The name of the leveling schema.  IMMUTABLE</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A set of tiers that contain experience boundaries
        /// </summary>
        /// <value>A set of tiers that contain experience boundaries</value>
        [JsonProperty(PropertyName = "tiers")]
        public List<TierResource> Tiers { get; set; }

        /// <summary>
        /// The name of an event that will add one progress to this level when fired
        /// </summary>
        /// <value>The name of an event that will add one progress to this level when fired</value>
        [JsonProperty(PropertyName = "trigger_event_name")]
        public string TriggerEventName { get; set; }

        /// <summary>
        /// The date the leveling schema was updated
        /// </summary>
        /// <value>The date the leveling schema was updated</value>
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
            sb.Append("class LevelingResource {\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Tiers: ").Append(Tiers).Append("\n");
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
