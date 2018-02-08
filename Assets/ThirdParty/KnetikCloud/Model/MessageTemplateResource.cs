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
    
    
    public class MessageTemplateResource
    {
        /// <summary>
        /// The content of the template. See Apache Velocity documentation for formatting
        /// </summary>
        /// <value>The content of the template. See Apache Velocity documentation for formatting</value>
        [JsonProperty(PropertyName = "content")]
        public string Content;

        /// <summary>
        /// The id of the template. Cannot be changed after creation. default: auto generated
        /// </summary>
        /// <value>The id of the template. Cannot be changed after creation. default: auto generated</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// The name of the template
        /// </summary>
        /// <value>The name of the template</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// A list of tags for search purposes. Will be converted to lower case
        /// </summary>
        /// <value>A list of tags for search purposes. Will be converted to lower case</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MessageTemplateResource {\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
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
