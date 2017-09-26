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
    public class RawEmailResource
    {
        /// <summary>
        /// The body of the outgoing message.
        /// </summary>
        /// <value>The body of the outgoing message.</value>
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        /// <summary>
        /// Address to attribute the outgoing message to. Optional if the config email.out_address is set.
        /// </summary>
        /// <value>Address to attribute the outgoing message to. Optional if the config email.out_address is set.</value>
        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }

        /// <summary>
        /// Whether the body is to be treated as html. Default false.
        /// </summary>
        /// <value>Whether the body is to be treated as html. Default false.</value>
        [JsonProperty(PropertyName = "html")]
        public bool? Html { get; set; }

        /// <summary>
        /// A list of user ids to send the message to.
        /// </summary>
        /// <value>A list of user ids to send the message to.</value>
        [JsonProperty(PropertyName = "recipients")]
        public List<int?> Recipients { get; set; }

        /// <summary>
        /// The subject of the outgoing message.
        /// </summary>
        /// <value>The subject of the outgoing message.</value>
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RawEmailResource {\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  Html: ").Append(Html).Append("\n");
            sb.Append("  Recipients: ").Append(Recipients).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
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
