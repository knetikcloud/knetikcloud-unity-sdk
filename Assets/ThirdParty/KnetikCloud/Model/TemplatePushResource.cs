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
    
    
    public class TemplatePushResource
    {
        /// <summary>
        /// A list of user ids to send the message to.
        /// </summary>
        /// <value>A list of user ids to send the message to.</value>
        [JsonProperty(PropertyName = "recipients")]
        public List<int?> Recipients;

        /// <summary>
        /// A mustache template
        /// </summary>
        /// <value>A mustache template</value>
        [JsonProperty(PropertyName = "template")]
        public string Template;

        /// <summary>
        /// A map of values to fill in the template
        /// </summary>
        /// <value>A map of values to fill in the template</value>
        [JsonProperty(PropertyName = "template_vars")]
        public Object TemplateVars;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TemplatePushResource {\n");
            sb.Append("  Recipients: ").Append(Recipients).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
            sb.Append("  TemplateVars: ").Append(TemplateVars).Append("\n");
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
