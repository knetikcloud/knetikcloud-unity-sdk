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
    
    
    public class Config
    {
        /// <summary>
        /// The description of the config.  Max 140 characters
        /// </summary>
        /// <value>The description of the config.  Max 140 characters</value>
        [JsonProperty(PropertyName = "description")]
        public string Description;

        /// <summary>
        /// The name of the config
        /// </summary>
        /// <value>The name of the config</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// Whether the config is public for viewing. True means that it can be publicly viewed by all. Default: false
        /// </summary>
        /// <value>Whether the config is public for viewing. True means that it can be publicly viewed by all. Default: false</value>
        [JsonProperty(PropertyName = "public_read")]
        public bool? PublicRead;

        /// <summary>
        /// The value of the config
        /// </summary>
        /// <value>The value of the config</value>
        [JsonProperty(PropertyName = "value")]
        public string Value;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Config {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PublicRead: ").Append(PublicRead).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
