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
    public class AnswerResource
    {
        /// <summary>
        /// The answer to the question. Different 'type' values indicate different structures as the answer may be test, image, etc. See information on additional properties for the list and their structures
        /// </summary>
        /// <value>The answer to the question. Different 'type' values indicate different structures as the answer may be test, image, etc. See information on additional properties for the list and their structures</value>
        [JsonProperty(PropertyName = "answer")]
        public Property Answer;

        /// <summary>
        /// Whether the answer is correct or not
        /// </summary>
        /// <value>Whether the answer is correct or not</value>
        [JsonProperty(PropertyName = "correct")]
        public bool? Correct;

        /// <summary>
        /// The unique ID for that resource
        /// </summary>
        /// <value>The unique ID for that resource</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AnswerResource {\n");
            sb.Append("  Answer: ").Append(Answer).Append("\n");
            sb.Append("  Correct: ").Append(Correct).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
