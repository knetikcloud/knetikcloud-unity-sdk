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
    public class CustomerConfig
    {
        /// <summary>
        /// Gets or Sets Aliases
        /// </summary>
        [JsonProperty(PropertyName = "aliases")]
        public string Aliases;

        /// <summary>
        /// Gets or Sets Database
        /// </summary>
        [JsonProperty(PropertyName = "database")]
        public DatabaseConfig Database;

        /// <summary>
        /// Gets or Sets Io
        /// </summary>
        [JsonProperty(PropertyName = "io")]
        public IOConfig Io;

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// Gets or Sets S3Config
        /// </summary>
        [JsonProperty(PropertyName = "s3_config")]
        public S3Config S3Config;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CustomerConfig {\n");
            sb.Append("  Aliases: ").Append(Aliases).Append("\n");
            sb.Append("  Database: ").Append(Database).Append("\n");
            sb.Append("  Io: ").Append(Io).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  S3Config: ").Append(S3Config).Append("\n");
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
