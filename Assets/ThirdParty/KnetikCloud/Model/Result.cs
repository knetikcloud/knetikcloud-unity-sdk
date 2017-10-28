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
    public class Result
    {
        /// <summary>
        /// The JSAPI error code
        /// </summary>
        /// <value>The JSAPI error code</value>
        [JsonProperty(PropertyName = "code")]
        public int? Code;

        /// <summary>
        /// The id used for debugging lookup
        /// </summary>
        /// <value>The id used for debugging lookup</value>
        [JsonProperty(PropertyName = "request_id")]
        public string RequestId;

        /// <summary>
        /// The error object
        /// </summary>
        /// <value>The error object</value>
        [JsonProperty(PropertyName = "result")]
        public List<ErrorResource> _Result;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Result {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  RequestId: ").Append(RequestId).Append("\n");
            sb.Append("  _Result: ").Append(_Result).Append("\n");
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
