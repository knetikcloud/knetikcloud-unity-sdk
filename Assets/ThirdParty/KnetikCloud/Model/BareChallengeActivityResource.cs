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
    public class BareChallengeActivityResource
    {
        /// <summary>
        /// The id of the activity
        /// </summary>
        /// <value>The id of the activity</value>
        [JsonProperty(PropertyName = "activity_id")]
        public long? ActivityId;

        /// <summary>
        /// The id of the challenge
        /// </summary>
        /// <value>The id of the challenge</value>
        [JsonProperty(PropertyName = "challenge_id")]
        public long? ChallengeId;

        /// <summary>
        /// The unique ID for this resource
        /// </summary>
        /// <value>The unique ID for this resource</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BareChallengeActivityResource {\n");
            sb.Append("  ActivityId: ").Append(ActivityId).Append("\n");
            sb.Append("  ChallengeId: ").Append(ChallengeId).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
