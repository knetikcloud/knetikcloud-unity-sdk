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
    public class VideoRelationshipResource
    {
        /// <summary>
        /// The owner of the relationship
        /// </summary>
        /// <value>The owner of the relationship</value>
        [JsonProperty(PropertyName = "from")]
        public SimpleReferenceResourcelong From { get; set; }

        /// <summary>
        /// The id of the relationship
        /// </summary>
        /// <value>The id of the relationship</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

        /// <summary>
        /// Details about the relationship such as type or other information. Max length 10 characters
        /// </summary>
        /// <value>Details about the relationship such as type or other information. Max length 10 characters</value>
        [JsonProperty(PropertyName = "relationship_details")]
        public string RelationshipDetails { get; set; }

        /// <summary>
        /// The target of the relationship.
        /// </summary>
        /// <value>The target of the relationship.</value>
        [JsonProperty(PropertyName = "to")]
        public SimpleReferenceResourcelong To { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class VideoRelationshipResource {\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  RelationshipDetails: ").Append(RelationshipDetails).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
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
