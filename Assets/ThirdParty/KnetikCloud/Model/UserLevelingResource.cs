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
    public class UserLevelingResource
    {
        /// <summary>
        /// The name of the last tier the user has qualified for
        /// </summary>
        /// <value>The name of the last tier the user has qualified for</value>
        [JsonProperty(PropertyName = "last_tier_name")]
        public string LastTierName;

        /// <summary>
        /// The progress level of the last tier the user has qualified for
        /// </summary>
        /// <value>The progress level of the last tier the user has qualified for</value>
        [JsonProperty(PropertyName = "last_tier_progress")]
        public int? LastTierProgress;

        /// <summary>
        /// The name of the level schema
        /// </summary>
        /// <value>The name of the level schema</value>
        [JsonProperty(PropertyName = "level_name")]
        public string LevelName;

        /// <summary>
        /// The name of the next tier the user can qualify for
        /// </summary>
        /// <value>The name of the next tier the user can qualify for</value>
        [JsonProperty(PropertyName = "next_tier_name")]
        public string NextTierName;

        /// <summary>
        /// The progress needed to qualify for the next tier
        /// </summary>
        /// <value>The progress needed to qualify for the next tier</value>
        [JsonProperty(PropertyName = "next_tier_progress")]
        public int? NextTierProgress;

        /// <summary>
        /// The amount of progress the user has
        /// </summary>
        /// <value>The amount of progress the user has</value>
        [JsonProperty(PropertyName = "progress")]
        public int? Progress;

        /// <summary>
        /// The names of the tiers the user has qualified for
        /// </summary>
        /// <value>The names of the tiers the user has qualified for</value>
        [JsonProperty(PropertyName = "tier_names")]
        public List<string> TierNames;

        /// <summary>
        /// The ID of the user
        /// </summary>
        /// <value>The ID of the user</value>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserLevelingResource {\n");
            sb.Append("  LastTierName: ").Append(LastTierName).Append("\n");
            sb.Append("  LastTierProgress: ").Append(LastTierProgress).Append("\n");
            sb.Append("  LevelName: ").Append(LevelName).Append("\n");
            sb.Append("  NextTierName: ").Append(NextTierName).Append("\n");
            sb.Append("  NextTierProgress: ").Append(NextTierProgress).Append("\n");
            sb.Append("  Progress: ").Append(Progress).Append("\n");
            sb.Append("  TierNames: ").Append(TierNames).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
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
