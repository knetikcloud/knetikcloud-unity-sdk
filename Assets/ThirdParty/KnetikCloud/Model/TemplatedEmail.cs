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
    
    
    public class TemplatedEmail
    {
        /// <summary>
        /// The external template ID used by the email provider
        /// </summary>
        /// <value>The external template ID used by the email provider</value>
        [JsonProperty(PropertyName = "external_template_id")]
        public string ExternalTemplateId;

        /// <summary>
        /// The map of data used by the template
        /// </summary>
        /// <value>The map of data used by the template</value>
        [JsonProperty(PropertyName = "template_data")]
        public Object TemplateData;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TemplatedEmail {\n");
            sb.Append("  ExternalTemplateId: ").Append(ExternalTemplateId).Append("\n");
            sb.Append("  TemplateData: ").Append(TemplateData).Append("\n");
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
