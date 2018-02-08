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
    
    
    public class NotificationResource
    {
        /// <summary>
        /// The data to send to websockets. Also used to fill in the templates
        /// </summary>
        /// <value>The data to send to websockets. Also used to fill in the templates</value>
        [JsonProperty(PropertyName = "data")]
        public Object Data;

        /// <summary>
        /// The id of this individual notification. Default: random
        /// </summary>
        /// <value>The id of this individual notification. Default: random</value>
        [JsonProperty(PropertyName = "notification_id")]
        public string NotificationId;

        /// <summary>
        /// The id of the notification type which will define message templates
        /// </summary>
        /// <value>The id of the notification type which will define message templates</value>
        [JsonProperty(PropertyName = "notification_type_id")]
        public string NotificationTypeId;

        /// <summary>
        /// The id of the recipient, dependent on the recipient_type. The user's id or the topic's id
        /// </summary>
        /// <value>The id of the recipient, dependent on the recipient_type. The user's id or the topic's id</value>
        [JsonProperty(PropertyName = "recipient")]
        public string Recipient;

        /// <summary>
        /// The type of recipient for the notification. Either a user, or all users in a topic
        /// </summary>
        /// <value>The type of recipient for the notification. Either a user, or all users in a topic</value>
        [JsonProperty(PropertyName = "recipient_type")]
        public string RecipientType;

        /// <summary>
        /// The date this notification was sent
        /// </summary>
        /// <value>The date this notification was sent</value>
        [JsonProperty(PropertyName = "send_date")]
        public long? SendDate;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class NotificationResource {\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  NotificationId: ").Append(NotificationId).Append("\n");
            sb.Append("  NotificationTypeId: ").Append(NotificationTypeId).Append("\n");
            sb.Append("  Recipient: ").Append(Recipient).Append("\n");
            sb.Append("  RecipientType: ").Append(RecipientType).Append("\n");
            sb.Append("  SendDate: ").Append(SendDate).Append("\n");
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
