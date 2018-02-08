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
    
    
    public class ChatMessageResource
    {
        /// <summary>
        /// The content of the message
        /// </summary>
        /// <value>The content of the message</value>
        [JsonProperty(PropertyName = "content")]
        public Object Content;

        /// <summary>
        /// The date the chat message was created
        /// </summary>
        /// <value>The date the chat message was created</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// Whether the message has been edited
        /// </summary>
        /// <value>Whether the message has been edited</value>
        [JsonProperty(PropertyName = "edited")]
        public bool? Edited;

        /// <summary>
        /// The id for this message
        /// </summary>
        /// <value>The id for this message</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// The type of the message set by the client
        /// </summary>
        /// <value>The type of the message set by the client</value>
        [JsonProperty(PropertyName = "message_type")]
        public string MessageType;

        /// <summary>
        /// The id of the recipient: user id or topic id
        /// </summary>
        /// <value>The id of the recipient: user id or topic id</value>
        [JsonProperty(PropertyName = "recipient_id")]
        public string RecipientId;

        /// <summary>
        /// The recipient type of the message
        /// </summary>
        /// <value>The recipient type of the message</value>
        [JsonProperty(PropertyName = "recipient_type")]
        public string RecipientType;

        /// <summary>
        /// The id of the sender
        /// </summary>
        /// <value>The id of the sender</value>
        [JsonProperty(PropertyName = "sender_id")]
        public int? SenderId;

        /// <summary>
        /// The id of the thread
        /// </summary>
        /// <value>The id of the thread</value>
        [JsonProperty(PropertyName = "thread_id")]
        public string ThreadId;

        /// <summary>
        /// The date the chat message was updated
        /// </summary>
        /// <value>The date the chat message was updated</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ChatMessageResource {\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Edited: ").Append(Edited).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  MessageType: ").Append(MessageType).Append("\n");
            sb.Append("  RecipientId: ").Append(RecipientId).Append("\n");
            sb.Append("  RecipientType: ").Append(RecipientType).Append("\n");
            sb.Append("  SenderId: ").Append(SenderId).Append("\n");
            sb.Append("  ThreadId: ").Append(ThreadId).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
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
