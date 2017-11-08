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
    
    
    public class BehaviorDefinitionResource
    {
        /// <summary>
        /// Description of the behavior
        /// </summary>
        /// <value>Description of the behavior</value>
        [JsonProperty(PropertyName = "description")]
        public string Description;

        /// <summary>
        /// Pre-requisite behaviors that an item must have in order to also have this behavior
        /// </summary>
        /// <value>Pre-requisite behaviors that an item must have in order to also have this behavior</value>
        [JsonProperty(PropertyName = "prerequisite_behaviors")]
        public List<Behavior> PrerequisiteBehaviors;

        /// <summary>
        /// Configurable properties of the behavior
        /// </summary>
        /// <value>Configurable properties of the behavior</value>
        [JsonProperty(PropertyName = "properties")]
        public List<PropertyFieldResource> Properties;

        /// <summary>
        /// The behavior type
        /// </summary>
        /// <value>The behavior type</value>
        [JsonProperty(PropertyName = "type_hint")]
        public string TypeHint;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BehaviorDefinitionResource {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  PrerequisiteBehaviors: ").Append(PrerequisiteBehaviors).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
            sb.Append("  TypeHint: ").Append(TypeHint).Append("\n");
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
