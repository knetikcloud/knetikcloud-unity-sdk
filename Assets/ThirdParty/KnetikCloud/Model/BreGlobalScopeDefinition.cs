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
    
    
    public class BreGlobalScopeDefinition
    {
        /// <summary>
        /// The name of the scoping parameter. This is used as the unique identifier of this scope
        /// </summary>
        /// <value>The name of the scoping parameter. This is used as the unique identifier of this scope</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The variable type of this scoping parameter. See Bre Variables endpoint for list
        /// </summary>
        /// <value>The variable type of this scoping parameter. See Bre Variables endpoint for list</value>
        [JsonProperty(PropertyName = "type")]
        public string Type;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BreGlobalScopeDefinition {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
