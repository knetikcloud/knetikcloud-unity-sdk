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
    
    
    public class UserAchievementGroupResource
    {
        /// <summary>
        /// The list of achievements associated with the group
        /// </summary>
        /// <value>The list of achievements associated with the group</value>
        [JsonProperty(PropertyName = "achievements")]
        public List<UserAchievementResource> Achievements;

        /// <summary>
        /// The name of the group.  If used by Leveling, this will represent the level name
        /// </summary>
        /// <value>The name of the group.  If used by Leveling, this will represent the level name</value>
        [JsonProperty(PropertyName = "group_name")]
        public string GroupName;

        /// <summary>
        /// The id of the achievement progress
        /// </summary>
        /// <value>The id of the achievement progress</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// The current progress of the user on the group
        /// </summary>
        /// <value>The current progress of the user on the group</value>
        [JsonProperty(PropertyName = "progress")]
        public int? Progress;

        /// <summary>
        /// The id of the user whose progress is being tracked
        /// </summary>
        /// <value>The id of the user whose progress is being tracked</value>
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
            sb.Append("class UserAchievementGroupResource {\n");
            sb.Append("  Achievements: ").Append(Achievements).Append("\n");
            sb.Append("  GroupName: ").Append(GroupName).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Progress: ").Append(Progress).Append("\n");
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
