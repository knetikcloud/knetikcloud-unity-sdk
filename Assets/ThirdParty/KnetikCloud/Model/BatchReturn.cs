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
    
    
    public class BatchReturn
    {
        /// <summary>
        /// The result body
        /// </summary>
        /// <value>The result body</value>
        [JsonProperty(PropertyName = "body")]
        public Object Body;

        /// <summary>
        /// The HTTP response code
        /// </summary>
        /// <value>The HTTP response code</value>
        [JsonProperty(PropertyName = "code")]
        public int? Code;

        /// <summary>
        /// Full URI of REST call
        /// </summary>
        /// <value>Full URI of REST call</value>
        [JsonProperty(PropertyName = "uri")]
        public string Uri;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BatchReturn {\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Uri: ").Append(Uri).Append("\n");
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
