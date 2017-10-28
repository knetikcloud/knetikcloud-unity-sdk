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
    public class MetricResource
    {
        /// <summary>
        /// The id of the activity occurence where this score/metric occurred
        /// </summary>
        /// <value>The id of the activity occurence where this score/metric occurred</value>
        [JsonProperty(PropertyName = "activity_occurence_id")]
        public long? ActivityOccurenceId;

        /// <summary>
        /// Any tags for the metric. Each unique tag will translate into a unique leaderboard. Maximum 5 tags and 50 characters each
        /// </summary>
        /// <value>Any tags for the metric. Each unique tag will translate into a unique leaderboard. Maximum 5 tags and 50 characters each</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags;

        /// <summary>
        /// The id of the user this metric is for. Default to caller and requires METRICS_ADMIN permission to specify another
        /// </summary>
        /// <value>The id of the user this metric is for. Default to caller and requires METRICS_ADMIN permission to specify another</value>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId;

        /// <summary>
        /// The value/score of the metric
        /// </summary>
        /// <value>The value/score of the metric</value>
        [JsonProperty(PropertyName = "value")]
        public long? Value;

        /// <inheritdoc />
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
            sb.Append("  UserId: ").Append(UserId).Append("\n");
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
