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
    
    
    public class PollResponseResource
    {
        /// <summary>
        /// The answer to the poll
        /// </summary>
        /// <value>The answer to the poll</value>
        [JsonProperty(PropertyName = "answer")]
        public string Answer;

        /// <summary>
        /// The date the poll was answered, in seconds since unix epoc
        /// </summary>
        /// <value>The date the poll was answered, in seconds since unix epoc</value>
        [JsonProperty(PropertyName = "answered_date")]
        public long? AnsweredDate;

        /// <summary>
        /// The id of the poll response
        /// </summary>
        /// <value>The id of the poll response</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// The id of the poll
        /// </summary>
        /// <value>The id of the poll</value>
        [JsonProperty(PropertyName = "poll_id")]
        public string PollId;

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
            sb.Append("class PollResponseResource {\n");
            sb.Append("  Answer: ").Append(Answer).Append("\n");
            sb.Append("  AnsweredDate: ").Append(AnsweredDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  PollId: ").Append(PollId).Append("\n");
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
