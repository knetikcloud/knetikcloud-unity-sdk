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
    
    
    public class ChallengeActivityResource
    {
        /// <summary>
        /// The id of the activity
        /// </summary>
        /// <value>The id of the activity</value>
        [JsonProperty(PropertyName = "activity_id")]
        public long? ActivityId;

        /// <summary>
        /// A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type
        /// </summary>
        /// <value>A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties;

        /// <summary>
        /// The id of the challenge
        /// </summary>
        /// <value>The id of the challenge</value>
        [JsonProperty(PropertyName = "challenge_id")]
        public long? ChallengeId;

        /// <summary>
        /// The entitlement item needed to participate in the activity as part of this event. Null indicates free entry. When creating/updating only id is used. Item must be pre-existing
        /// </summary>
        /// <value>The entitlement item needed to participate in the activity as part of this event. Null indicates free entry. When creating/updating only id is used. Item must be pre-existing</value>
        [JsonProperty(PropertyName = "entitlement")]
        public ActivityEntitlementResource Entitlement;

        /// <summary>
        /// The unique ID for this resource
        /// </summary>
        /// <value>The unique ID for this resource</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

        /// <summary>
        /// The rewards to give at the end of each occurence of the activity. When creating/updating only id is used. Reward set must be pre-existing
        /// </summary>
        /// <value>The rewards to give at the end of each occurence of the activity. When creating/updating only id is used. Reward set must be pre-existing</value>
        [JsonProperty(PropertyName = "reward_set")]
        public RewardSetResource RewardSet;

        /// <summary>
        /// The list of settings and the select options
        /// </summary>
        /// <value>The list of settings and the select options</value>
        [JsonProperty(PropertyName = "settings")]
        public List<SelectedSettingResource> Settings;

        /// <summary>
        /// A challenge activity template this challenge activity is validated against (private). May be null and no validation of additional_properties will be done
        /// </summary>
        /// <value>A challenge activity template this challenge activity is validated against (private). May be null and no validation of additional_properties will be done</value>
        [JsonProperty(PropertyName = "template")]
        public string Template;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ChallengeActivityResource {\n");
            sb.Append("  ActivityId: ").Append(ActivityId).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  ChallengeId: ").Append(ChallengeId).Append("\n");
            sb.Append("  Entitlement: ").Append(Entitlement).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  RewardSet: ").Append(RewardSet).Append("\n");
            sb.Append("  Settings: ").Append(Settings).Append("\n");
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
