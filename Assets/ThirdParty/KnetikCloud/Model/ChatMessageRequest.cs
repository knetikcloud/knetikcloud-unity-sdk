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
    
    
    public class ChatMessageRequest
    {
        /// <summary>
        /// The content of the message
        /// </summary>
        /// <value>The content of the message</value>
        [JsonProperty(PropertyName = "content")]
        public Object Content;

        /// <summary>
        /// The type of the message set by the client
        /// </summary>
        /// <value>The type of the message set by the client</value>
        [JsonProperty(PropertyName = "message_type")]
        public string MessageType;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ChatMessageRequest {\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  MessageType: ").Append(MessageType).Append("\n");
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
