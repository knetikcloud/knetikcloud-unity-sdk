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
    
    
    public class MongoDatabaseConfig
    {
        /// <summary>
        /// Gets or Sets DbName
        /// </summary>
        [JsonProperty(PropertyName = "db_name")]
        public string DbName;

        /// <summary>
        /// Gets or Sets Options
        /// </summary>
        [JsonProperty(PropertyName = "options")]
        public string Options;

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password;

        /// <summary>
        /// Gets or Sets Servers
        /// </summary>
        [JsonProperty(PropertyName = "servers")]
        public string Servers;

        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MongoDatabaseConfig {\n");
            sb.Append("  DbName: ").Append(DbName).Append("\n");
            sb.Append("  Options: ").Append(Options).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Servers: ").Append(Servers).Append("\n");
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
