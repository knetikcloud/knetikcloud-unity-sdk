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
    public class BatchRequest
    {
        /// <summary>
        /// The request body as would be passed to the URI
        /// </summary>
        /// <value>The request body as would be passed to the URI</value>
        [JsonProperty(PropertyName = "body")]
        public Object Body { get; set; }

        /// <summary>
        /// Content type used, Ex:(application/json)
        /// </summary>
        /// <value>Content type used, Ex:(application/json)</value>
        [JsonProperty(PropertyName = "content_type")]
        public string ContentType { get; set; }

        /// <summary>
        /// The HTTP method used, Ex: (GET)
        /// </summary>
        /// <value>The HTTP method used, Ex: (GET)</value>
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        /// <summary>
        /// Time in seconds before process will timeout.  Default is 60.  Range is 1-300
        /// </summary>
        /// <value>Time in seconds before process will timeout.  Default is 60.  Range is 1-300</value>
        [JsonProperty(PropertyName = "timeout")]
        public int? Timeout { get; set; }

        /// <summary>
        /// The oauth token only
        /// </summary>
        /// <value>The oauth token only</value>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        /// <summary>
        /// Full URI of REST call
        /// </summary>
        /// <value>Full URI of REST call</value>
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BatchRequest {\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("  ContentType: ").Append(ContentType).Append("\n");
            sb.Append("  Method: ").Append(Method).Append("\n");
            sb.Append("  Timeout: ").Append(Timeout).Append("\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
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
