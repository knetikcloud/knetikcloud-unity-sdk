using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ChallengeEventResource
    {
        /// <summary>
        /// The id of the challenge
        /// </summary>
        /// <value>The id of the challenge</value>
        [JsonProperty(PropertyName = "challenge_id")]
        public long? ChallengeId { get; set; }

        /// <summary>
        /// The end date in seconds
        /// </summary>
        /// <value>The end date in seconds</value>
        [JsonProperty(PropertyName = "end_date")]
        public long? EndDate { get; set; }

        /// <summary>
        /// The id of the challenge event
        /// </summary>
        /// <value>The id of the challenge event</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

        /// <summary>
        /// Indicate if the rewards have been given out already 
        /// </summary>
        /// <value>Indicate if the rewards have been given out already </value>
        [JsonProperty(PropertyName = "reward_status")]
        public string RewardStatus { get; set; }

        /// <summary>
        /// The start date in seconds
        /// </summary>
        /// <value>The start date in seconds</value>
        [JsonProperty(PropertyName = "start_date")]
        public long? StartDate { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ChallengeEventResource {\n");
            sb.Append("  ChallengeId: ").Append(ChallengeId).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  RewardStatus: ").Append(RewardStatus).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
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
