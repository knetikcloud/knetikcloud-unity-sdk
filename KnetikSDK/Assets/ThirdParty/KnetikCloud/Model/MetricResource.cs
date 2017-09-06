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
    public class MetricResource
    {
        /// <summary>
        /// The id of the activity occurence where this score/metric occurred
        /// </summary>
        /// <value>The id of the activity occurence where this score/metric occurred</value>
        [JsonProperty(PropertyName = "activity_occurence_id")]
        public long? ActivityOccurenceId { get; set; }

        /// <summary>
        /// Any tags for the metric. Each unique tag will translate into a unique leaderboard. Maximum 5 tags and 50 characters each
        /// </summary>
        /// <value>Any tags for the metric. Each unique tag will translate into a unique leaderboard. Maximum 5 tags and 50 characters each</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// The value/score of the metric
        /// </summary>
        /// <value>The value/score of the metric</value>
        [JsonProperty(PropertyName = "value")]
        public long? Value { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MetricResource {\n");
            sb.Append("  ActivityOccurenceId: ").Append(ActivityOccurenceId).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
