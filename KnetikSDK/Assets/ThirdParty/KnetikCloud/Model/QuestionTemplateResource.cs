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
    public class QuestionTemplateResource
    {
        /// <summary>
        /// Whether to allow additional properties beyond those specified or not
        /// </summary>
        /// <value>Whether to allow additional properties beyond those specified or not</value>
        [JsonProperty(PropertyName = "allow_additional")]
        public bool? AllowAdditional { get; set; }

        /// <summary>
        /// A property definition for all answers. If included each answer must match this definition's type and be valid
        /// </summary>
        /// <value>A property definition for all answers. If included each answer must match this definition's type and be valid</value>
        [JsonProperty(PropertyName = "answer_property")]
        public PropertyDefinitionResource AnswerProperty { get; set; }

        /// <summary>
        /// The date/time this resource was created in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate { get; set; }

        /// <summary>
        /// The id of the template
        /// </summary>
        /// <value>The id of the template</value>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the template
        /// </summary>
        /// <value>The name of the template</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The customized properties that are present
        /// </summary>
        /// <value>The customized properties that are present</value>
        [JsonProperty(PropertyName = "properties")]
        public List<PropertyDefinitionResource> Properties { get; set; }

        /// <summary>
        /// A property definition for the question itself. If included the answer must match this definition's type and be valid
        /// </summary>
        /// <value>A property definition for the question itself. If included the answer must match this definition's type and be valid</value>
        [JsonProperty(PropertyName = "question_property")]
        public PropertyDefinitionResource QuestionProperty { get; set; }

        /// <summary>
        /// The date/time this resource was last updated in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was last updated in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class QuestionTemplateResource {\n");
            sb.Append("  AllowAdditional: ").Append(AllowAdditional).Append("\n");
            sb.Append("  AnswerProperty: ").Append(AnswerProperty).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
            sb.Append("  QuestionProperty: ").Append(QuestionProperty).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
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
