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
    [KnetikFactory ("guest_playable")]
    public class GuestPlayable : Behavior
    {
        /// <summary>
        /// Whether guests are allowed to use items
        /// </summary>
        /// <value>Whether guests are allowed to use items</value>
        [JsonProperty(PropertyName = "allowed")]
        public bool? Allowed;

        /// <summary>
        /// Whether guests are allowed on the leaderboard
        /// </summary>
        /// <value>Whether guests are allowed on the leaderboard</value>
        [JsonProperty(PropertyName = "leaderboard")]
        public bool? Leaderboard;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GuestPlayable {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  TypeHint: ").Append(TypeHint).Append("\n");
            sb.Append("  Allowed: ").Append(Allowed).Append("\n");
            sb.Append("  Leaderboard: ").Append(Leaderboard).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
