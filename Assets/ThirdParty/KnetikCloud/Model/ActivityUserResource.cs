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
    public class ActivityUserResource
    {
        /// <summary>
        /// Whether this user is the 'host' of the occurrence and has increased access to settings/etc (default: false)
        /// </summary>
        /// <value>Whether this user is the 'host' of the occurrence and has increased access to settings/etc (default: false)</value>
        [JsonProperty(PropertyName = "host")]
        public bool? Host;

        /// <summary>
        /// The id of the activity user entry
        /// </summary>
        /// <value>The id of the activity user entry</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

        /// <summary>
        /// The date this user last joined the occurrence, unix timestamp in seconds
        /// </summary>
        /// <value>The date this user last joined the occurrence, unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "joined_date")]
        public long? JoinedDate;

        /// <summary>
        /// The date this user last left the occurrence, unix timestamp in seconds. Null if still present
        /// </summary>
        /// <value>The date this user last left the occurrence, unix timestamp in seconds. Null if still present</value>
        [JsonProperty(PropertyName = "left_date")]
        public long? LeftDate;

        /// <summary>
        /// The metric for the user's results, after the game is over
        /// </summary>
        /// <value>The metric for the user's results, after the game is over</value>
        [JsonProperty(PropertyName = "metric")]
        public MetricResource Metric;

        /// <summary>
        /// The current status of the user in the occurrence (default: present)
        /// </summary>
        /// <value>The current status of the user in the occurrence (default: present)</value>
        [JsonProperty(PropertyName = "status")]
        public string Status;

        /// <summary>
        /// The user
        /// </summary>
        /// <value>The user</value>
        [JsonProperty(PropertyName = "user")]
        public SimpleUserResource User;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ActivityUserResource {\n");
            sb.Append("  Host: ").Append(Host).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  JoinedDate: ").Append(JoinedDate).Append("\n");
            sb.Append("  LeftDate: ").Append(LeftDate).Append("\n");
            sb.Append("  Metric: ").Append(Metric).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
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
