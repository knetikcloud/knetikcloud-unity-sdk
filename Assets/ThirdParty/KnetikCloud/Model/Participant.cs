using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Participant
    {
        /// <summary>
        /// Whether this user is the 'host' of the occurrence and has increased access to settings/etc (default: false)
        /// </summary>
        /// <value>Whether this user is the 'host' of the occurrence and has increased access to settings/etc (default: false)</value>
        [JsonProperty(PropertyName = "host")]
        public bool? Host { get; set; }

        /// <summary>
        /// The current status of the user in the occurrence (default: present)
        /// </summary>
        /// <value>The current status of the user in the occurrence (default: present)</value>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The user
        /// </summary>
        /// <value>The user</value>
        [JsonProperty(PropertyName = "user")]
        public IdRef User { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Participant {\n");
            sb.Append("  Host: ").Append(Host).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
