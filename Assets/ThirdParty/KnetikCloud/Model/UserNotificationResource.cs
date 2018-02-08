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
    
    
    public class UserNotificationResource
    {
        /// <summary>
        /// The data to send and fill templates
        /// </summary>
        /// <value>The data to send and fill templates</value>
        [JsonProperty(PropertyName = "data")]
        public Object Data;

        /// <summary>
        /// The id of the notification
        /// </summary>
        /// <value>The id of the notification</value>
        [JsonProperty(PropertyName = "notification_id")]
        public string NotificationId;

        /// <summary>
        /// The id of the notification type
        /// </summary>
        /// <value>The id of the notification type</value>
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
        /// The date this notification was first retrieved
        /// </summary>
        /// <value>The date this notification was first retrieved</value>
        [JsonProperty(PropertyName = "retrieve_date")]
        public long? RetrieveDate;

        /// <summary>
        /// The date this notification was sent
        /// </summary>
        /// <value>The date this notification was sent</value>
        [JsonProperty(PropertyName = "send_date")]
        public long? SendDate;

        /// <summary>
        /// The user's status for this notification
        /// </summary>
        /// <value>The user's status for this notification</value>
        [JsonProperty(PropertyName = "status")]
        public string Status;

        /// <summary>
        /// The id of the user
        /// </summary>
        /// <value>The id of the user</value>
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
            sb.Append("class UserNotificationResource {\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  NotificationId: ").Append(NotificationId).Append("\n");
            sb.Append("  NotificationTypeId: ").Append(NotificationTypeId).Append("\n");
            sb.Append("  Recipient: ").Append(Recipient).Append("\n");
            sb.Append("  RecipientType: ").Append(RecipientType).Append("\n");
            sb.Append("  RetrieveDate: ").Append(RetrieveDate).Append("\n");
            sb.Append("  SendDate: ").Append(SendDate).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
