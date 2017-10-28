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
    public class CampaignResource
    {
        /// <summary>
        /// Whether the campaign is active or not.  Defaults to false
        /// </summary>
        /// <value>Whether the campaign is active or not.  Defaults to false</value>
        [JsonProperty(PropertyName = "active")]
        public bool? Active;

        /// <summary>
        /// A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type
        /// </summary>
        /// <value>A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties;

        /// <summary>
        /// The date/time this resource was created in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The unique ID for that resource
        /// </summary>
        /// <value>The unique ID for that resource</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

        /// <summary>
        /// The strategy for calculating the leaderboard. Defaults to highest score. Value MUST come from the list of available strategies from the Leaderboard Service
        /// </summary>
        /// <value>The strategy for calculating the leaderboard. Defaults to highest score. Value MUST come from the list of available strategies from the Leaderboard Service</value>
        [JsonProperty(PropertyName = "leaderboard_strategy")]
        public string LeaderboardStrategy;

        /// <summary>
        /// The user friendly name of that resource. Defaults to blank string
        /// </summary>
        /// <value>The user friendly name of that resource. Defaults to blank string</value>
        [JsonProperty(PropertyName = "long_description")]
        public string LongDescription;

        /// <summary>
        /// The user friendly name of that resource
        /// </summary>
        /// <value>The user friendly name of that resource</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The name of the next challenge coming up
        /// </summary>
        /// <value>The name of the next challenge coming up</value>
        [JsonProperty(PropertyName = "next_challenge")]
        public string NextChallenge;

        /// <summary>
        /// The date/time of the next challenge coming up
        /// </summary>
        /// <value>The date/time of the next challenge coming up</value>
        [JsonProperty(PropertyName = "next_challenge_date")]
        public long? NextChallengeDate;

        /// <summary>
        /// The rewards to give at the end of the campaign. When creating/updating only id is used. Reward set must be pre-existing
        /// </summary>
        /// <value>The rewards to give at the end of the campaign. When creating/updating only id is used. Reward set must be pre-existing</value>
        [JsonProperty(PropertyName = "reward_set")]
        public RewardSetResource RewardSet;

        /// <summary>
        /// Indicate if the rewards have been given out already
        /// </summary>
        /// <value>Indicate if the rewards have been given out already</value>
        [JsonProperty(PropertyName = "reward_status")]
        public string RewardStatus;

        /// <summary>
        /// The user friendly name of that resource. Defaults to blank string
        /// </summary>
        /// <value>The user friendly name of that resource. Defaults to blank string</value>
        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription;

        /// <summary>
        /// A campaign template this campaign is validated against (private). May be null and no validation of additional_properties will be done
        /// </summary>
        /// <value>A campaign template this campaign is validated against (private). May be null and no validation of additional_properties will be done</value>
        [JsonProperty(PropertyName = "template")]
        public string Template;

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
            sb.Append("class CampaignResource {\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LeaderboardStrategy: ").Append(LeaderboardStrategy).Append("\n");
            sb.Append("  LongDescription: ").Append(LongDescription).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  NextChallenge: ").Append(NextChallenge).Append("\n");
            sb.Append("  NextChallengeDate: ").Append(NextChallengeDate).Append("\n");
            sb.Append("  RewardSet: ").Append(RewardSet).Append("\n");
            sb.Append("  RewardStatus: ").Append(RewardStatus).Append("\n");
            sb.Append("  ShortDescription: ").Append(ShortDescription).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
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
