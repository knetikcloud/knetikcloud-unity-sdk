using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    public class RawSMSResource
    {
        /// <summary>
        /// The phone number to attribute the outgoing message to. Optional if the config text.out_number is set.
        /// </summary>
        /// <value>The phone number to attribute the outgoing message to. Optional if the config text.out_number is set.</value>
        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }

        /// <summary>
        /// A list of user ids to send the message to.
        /// </summary>
        /// <value>A list of user ids to send the message to.</value>
        [JsonProperty(PropertyName = "recipients")]
        public List<int?> Recipients { get; set; }

        /// <summary>
        /// The body of the outgoing text message.
        /// </summary>
        /// <value>The body of the outgoing text message.</value>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RawSMSResource {\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  Recipients: ").Append(Recipients).Append("\n");
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
