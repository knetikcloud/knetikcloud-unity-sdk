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
    public class PollAnswerResource
    {
        /// <summary>
        /// The number of users that selected this answer
        /// </summary>
        /// <value>The number of users that selected this answer</value>
        [JsonProperty(PropertyName = "count")]
        public int? Count;

        /// <summary>
        /// The key to the answer (for code reference)
        /// </summary>
        /// <value>The key to the answer (for code reference)</value>
        [JsonProperty(PropertyName = "key")]
        public string Key;

        /// <summary>
        /// The text of the answer (for user display)
        /// </summary>
        /// <value>The text of the answer (for user display)</value>
        [JsonProperty(PropertyName = "text")]
        public string Text;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PollAnswerResource {\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
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
