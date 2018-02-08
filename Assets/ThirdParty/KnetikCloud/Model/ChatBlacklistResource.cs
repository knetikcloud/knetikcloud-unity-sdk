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
    
    
    public class ChatBlacklistResource
    {
        /// <summary>
        /// The user that is blacklisted
        /// </summary>
        /// <value>The user that is blacklisted</value>
        [JsonProperty(PropertyName = "blacklisted_user")]
        public SimpleUserResource BlacklistedUser;

        /// <summary>
        /// The date the user was blacklisted
        /// </summary>
        /// <value>The date the user was blacklisted</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The unique ID for this chat message blacklist
        /// </summary>
        /// <value>The unique ID for this chat message blacklist</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// The user that has blacklisted someone
        /// </summary>
        /// <value>The user that has blacklisted someone</value>
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
            sb.Append("class ChatBlacklistResource {\n");
            sb.Append("  BlacklistedUser: ").Append(BlacklistedUser).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
