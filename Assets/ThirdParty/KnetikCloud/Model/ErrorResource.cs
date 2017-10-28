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
    public class ErrorResource
    {
        /// <summary>
        /// Extra details about the error, if needed
        /// </summary>
        /// <value>Extra details about the error, if needed</value>
        [JsonProperty(PropertyName = "details")]
        public Object Details;

        /// <summary>
        /// The JSON key the message pertains to
        /// </summary>
        /// <value>The JSON key the message pertains to</value>
        [JsonProperty(PropertyName = "field")]
        public Object Field;

        /// <summary>
        /// The message explaining the error
        /// </summary>
        /// <value>The message explaining the error</value>
        [JsonProperty(PropertyName = "message")]
        public string Message;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ErrorResource {\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
            sb.Append("  Field: ").Append(Field).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
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
