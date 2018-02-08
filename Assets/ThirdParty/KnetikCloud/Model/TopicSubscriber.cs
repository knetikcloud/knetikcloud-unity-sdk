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
    
    
    public class TopicSubscriber
    {
        /// <summary>
        /// Gets or Sets Disabled
        /// </summary>
        [JsonProperty(PropertyName = "disabled")]
        public bool? Disabled;

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email;

        /// <summary>
        /// Gets or Sets JoinDate
        /// </summary>
        [JsonProperty(PropertyName = "join_date")]
        public long? JoinDate;

        /// <summary>
        /// Gets or Sets MobileNumber
        /// </summary>
        [JsonProperty(PropertyName = "mobile_number")]
        public string MobileNumber;

        /// <summary>
        /// Gets or Sets TopicId
        /// </summary>
        [JsonProperty(PropertyName = "topic_id")]
        public string TopicId;

        /// <summary>
        /// Gets or Sets TopicSubscriberMap
        /// </summary>
        [JsonProperty(PropertyName = "topic_subscriber_map")]
        public Object TopicSubscriberMap;

        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId;

        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TopicSubscriber {\n");
            sb.Append("  Disabled: ").Append(Disabled).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  JoinDate: ").Append(JoinDate).Append("\n");
            sb.Append("  MobileNumber: ").Append(MobileNumber).Append("\n");
            sb.Append("  TopicId: ").Append(TopicId).Append("\n");
            sb.Append("  TopicSubscriberMap: ").Append(TopicSubscriberMap).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
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
