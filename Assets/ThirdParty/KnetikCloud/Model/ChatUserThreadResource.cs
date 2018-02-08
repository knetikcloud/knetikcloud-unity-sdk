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
    
    
    public class ChatUserThreadResource
    {
        /// <summary>
        /// The date the user thread was created
        /// </summary>
        /// <value>The date the user thread was created</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The number of messages read in the thread
        /// </summary>
        /// <value>The number of messages read in the thread</value>
        [JsonProperty(PropertyName = "read_count")]
        public int? ReadCount;

        /// <summary>
        /// The details about the thread
        /// </summary>
        /// <value>The details about the thread</value>
        [JsonProperty(PropertyName = "thread")]
        public ChatThreadResource Thread;

        /// <summary>
        /// The id of the thread
        /// </summary>
        /// <value>The id of the thread</value>
        [JsonProperty(PropertyName = "thread_id")]
        public string ThreadId;

        /// <summary>
        /// The date the user thread was updated
        /// </summary>
        /// <value>The date the user thread was updated</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

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
            sb.Append("class ChatUserThreadResource {\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  ReadCount: ").Append(ReadCount).Append("\n");
            sb.Append("  Thread: ").Append(Thread).Append("\n");
            sb.Append("  ThreadId: ").Append(ThreadId).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
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
