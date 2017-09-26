using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// A request to reset a user&#39;s password by using a known user property
    /// </summary>
    public class PasswordResetRequest
    {
        /// <summary>
        /// The user's email address
        /// </summary>
        /// <value>The user's email address</value>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// The user's mobile phone number
        /// </summary>
        /// <value>The user's mobile phone number</value>
        [JsonProperty(PropertyName = "mobile_number")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// The user's username
        /// </summary>
        /// <value>The user's username</value>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PasswordResetRequest {\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  MobileNumber: ").Append(MobileNumber).Append("\n");
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
