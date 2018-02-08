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
    
    
    public class MessageTemplateBulkRequest
    {
        /// <summary>
        /// The data to fill the templates with
        /// </summary>
        /// <value>The data to fill the templates with</value>
        [JsonProperty(PropertyName = "data")]
        public Object Data;

        /// <summary>
        /// A list of message template ids
        /// </summary>
        /// <value>A list of message template ids</value>
        [JsonProperty(PropertyName = "ids")]
        public List<string> Ids;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MessageTemplateBulkRequest {\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Ids: ").Append(Ids).Append("\n");
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
