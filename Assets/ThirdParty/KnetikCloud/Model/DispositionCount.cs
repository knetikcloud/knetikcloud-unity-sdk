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
    
    
    public class DispositionCount
    {
        /// <summary>
        /// The number of users that have expressed this disposition
        /// </summary>
        /// <value>The number of users that have expressed this disposition</value>
        [JsonProperty(PropertyName = "count")]
        public long? Count;

        /// <summary>
        /// The name of the disposition this count is for
        /// </summary>
        /// <value>The name of the disposition this count is for</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DispositionCount {\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
