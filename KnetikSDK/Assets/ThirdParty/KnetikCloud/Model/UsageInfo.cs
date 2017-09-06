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
    public class UsageInfo
    {
        /// <summary>
        /// The number of requests within the range
        /// </summary>
        /// <value>The number of requests within the range</value>
        [JsonProperty(PropertyName = "count")]
        public long? Count { get; set; }

        /// <summary>
        /// The date at the start of the range (see granularity)
        /// </summary>
        /// <value>The date at the start of the range (see granularity)</value>
        [JsonProperty(PropertyName = "date")]
        public long? Date { get; set; }

        /// <summary>
        /// The http method
        /// </summary>
        /// <value>The http method</value>
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        /// <summary>
        /// The url path
        /// </summary>
        /// <value>The url path</value>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UsageInfo {\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Method: ").Append(Method).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
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
