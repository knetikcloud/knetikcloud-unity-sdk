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
    public class UserBaseResource
    {
        /// <summary>
        /// The url of the user's avatar image
        /// </summary>
        /// <value>The url of the user's avatar image</value>
        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// The chosen display name of the user, defaults to username if not present
        /// </summary>
        /// <value>The chosen display name of the user, defaults to username if not present</value>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The user's email address (private). May be required and/or unique depending on system configuration (both on by default). Must match standard email requirements if provided (RFC 2822)
        /// </summary>
        /// <value>The user's email address (private). May be required and/or unique depending on system configuration (both on by default). Must match standard email requirements if provided (RFC 2822)</value>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// The user's full name (private)
        /// </summary>
        /// <value>The user's full name (private)</value>
        [JsonProperty(PropertyName = "fullname")]
        public string Fullname { get; set; }

        /// <summary>
        /// The id of the user
        /// </summary>
        /// <value>The id of the user</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The date the user last interacted with the API (private)
        /// </summary>
        /// <value>The date the user last interacted with the API (private)</value>
        [JsonProperty(PropertyName = "last_activity")]
        public long? LastActivity { get; set; }

        /// <summary>
        /// The date the user's info was last updated as a unix timestamp
        /// </summary>
        /// <value>The date the user's info was last updated as a unix timestamp</value>
        [JsonProperty(PropertyName = "last_updated")]
        public long? LastUpdated { get; set; }

        /// <summary>
        /// The user's date of registration as a unix timestamp
        /// </summary>
        /// <value>The user's date of registration as a unix timestamp</value>
        [JsonProperty(PropertyName = "member_since")]
        public long? MemberSince { get; set; }

        /// <summary>
        /// The login username for the user (private). May be set to match email if system does not require usernames separately.
        /// </summary>
        /// <value>The login username for the user (private). May be set to match email if system does not require usernames separately.</value>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserBaseResource {\n");
            sb.Append("  AvatarUrl: ").Append(AvatarUrl).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Fullname: ").Append(Fullname).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastActivity: ").Append(LastActivity).Append("\n");
            sb.Append("  LastUpdated: ").Append(LastUpdated).Append("\n");
            sb.Append("  MemberSince: ").Append(MemberSince).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
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
