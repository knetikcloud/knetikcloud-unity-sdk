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
    
    
    public class MessageResource
    {
        /// <summary>
        /// The content of the message in various formats
        /// </summary>
        /// <value>The content of the message in various formats</value>
        [JsonProperty(PropertyName = "content")]
        public MessageContentResource Content;

        /// <summary>
        /// The id of the recipient, dependent on the recipient_type. The user's id or the topic's id. Required if sending directly to messaging service
        /// </summary>
        /// <value>The id of the recipient, dependent on the recipient_type. The user's id or the topic's id. Required if sending directly to messaging service</value>
        [JsonProperty(PropertyName = "recipient")]
        public string Recipient;

        /// <summary>
        /// The type of recipient for the message. Either a user, or all users in a topic. Required if sending directly to messaging service
        /// </summary>
        /// <value>The type of recipient for the message. Either a user, or all users in a topic. Required if sending directly to messaging service</value>
        [JsonProperty(PropertyName = "recipient_type")]
        public string RecipientType;

        /// <summary>
        /// The subject of the message. Required for email messages
        /// </summary>
        /// <value>The subject of the message. Required for email messages</value>
        [JsonProperty(PropertyName = "subject")]
        public string Subject;

        /// <summary>
        /// The type of message for websocket type hinting. will be added to the payload with the key _type
        /// </summary>
        /// <value>The type of message for websocket type hinting. will be added to the payload with the key _type</value>
        [JsonProperty(PropertyName = "type")]
        public string Type;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MessageResource {\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  Recipient: ").Append(Recipient).Append("\n");
            sb.Append("  RecipientType: ").Append(RecipientType).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
