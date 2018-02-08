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
    
    
    public class NotificationUserTypeResource
    {
        /// <summary>
        /// Whether the user has muted direct notification of this type. Notifications can still be retrieved via the api
        /// </summary>
        /// <value>Whether the user has muted direct notification of this type. Notifications can still be retrieved via the api</value>
        [JsonProperty(PropertyName = "silenced")]
        public bool? Silenced;

        /// <summary>
        /// The notification type id
        /// </summary>
        /// <value>The notification type id</value>
        [JsonProperty(PropertyName = "type")]
        public string Type;

        /// <summary>
        /// The user's id
        /// </summary>
        /// <value>The user's id</value>
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
            sb.Append("class NotificationUserTypeResource {\n");
            sb.Append("  Silenced: ").Append(Silenced).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
