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
    
    
    public class ChatThreadResource
    {
        /// <summary>
        /// The number of active users in the thread
        /// </summary>
        /// <value>The number of active users in the thread</value>
        [JsonProperty(PropertyName = "active_users")]
        public int? ActiveUsers;

        /// <summary>
        /// The number of messages in the thread
        /// </summary>
        /// <value>The number of messages in the thread</value>
        [JsonProperty(PropertyName = "count")]
        public int? Count;

        /// <summary>
        /// The date the thread was created
        /// </summary>
        /// <value>The date the thread was created</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The id for this thread
        /// </summary>
        /// <value>The id for this thread</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// The id of the recipient
        /// </summary>
        /// <value>The id of the recipient</value>
        [JsonProperty(PropertyName = "recipient_id")]
        public string RecipientId;

        /// <summary>
        /// The recipient type of the thread
        /// </summary>
        /// <value>The recipient type of the thread</value>
        [JsonProperty(PropertyName = "recipient_type")]
        public string RecipientType;

        /// <summary>
        /// The subject of the thread
        /// </summary>
        /// <value>The subject of the thread</value>
        [JsonProperty(PropertyName = "subject")]
        public string Subject;

        /// <summary>
        /// The date the thread was updated
        /// </summary>
        /// <value>The date the thread was updated</value>
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
            sb.Append("class ChatThreadResource {\n");
            sb.Append("  ActiveUsers: ").Append(ActiveUsers).Append("\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  RecipientId: ").Append(RecipientId).Append("\n");
            sb.Append("  RecipientType: ").Append(RecipientType).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
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
