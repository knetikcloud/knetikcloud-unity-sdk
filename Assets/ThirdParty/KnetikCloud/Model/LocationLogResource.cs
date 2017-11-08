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
    
    
    public class LocationLogResource
    {
        /// <summary>
        /// Gets or Sets Country
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country;

        /// <summary>
        /// Gets or Sets Ip
        /// </summary>
        [JsonProperty(PropertyName = "ip")]
        public string Ip;

        /// <summary>
        /// Gets or Sets Time
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public long? Time;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LocationLogResource {\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  Ip: ").Append(Ip).Append("\n");
            sb.Append("  Time: ").Append(Time).Append("\n");
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
