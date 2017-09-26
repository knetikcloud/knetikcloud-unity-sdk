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
    public class SqlDatabaseConfig
    {
        /// <summary>
        /// Gets or Sets ConnectionPoolSize
        /// </summary>
        [JsonProperty(PropertyName = "connection_pool_size")]
        public int? ConnectionPoolSize { get; set; }

        /// <summary>
        /// Gets or Sets DbName
        /// </summary>
        [JsonProperty(PropertyName = "db_name")]
        public string DbName { get; set; }

        /// <summary>
        /// Gets or Sets Hostname
        /// </summary>
        [JsonProperty(PropertyName = "hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets Port
        /// </summary>
        [JsonProperty(PropertyName = "port")]
        public int? Port { get; set; }

        /// <summary>
        /// Gets or Sets Username
        /// </summary>
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
            sb.Append("class SqlDatabaseConfig {\n");
            sb.Append("  ConnectionPoolSize: ").Append(ConnectionPoolSize).Append("\n");
            sb.Append("  DbName: ").Append(DbName).Append("\n");
            sb.Append("  Hostname: ").Append(Hostname).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Port: ").Append(Port).Append("\n");
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
