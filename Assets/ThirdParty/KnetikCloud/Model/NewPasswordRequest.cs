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
    public class NewPasswordRequest
    {
        /// <summary>
        /// The new password in plain text
        /// </summary>
        /// <value>The new password in plain text</value>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        /// <summary>
        /// The secret provided after the password reset
        /// </summary>
        /// <value>The secret provided after the password reset</value>
        [JsonProperty(PropertyName = "secret")]
        public string Secret { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class NewPasswordRequest {\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Secret: ").Append(Secret).Append("\n");
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
