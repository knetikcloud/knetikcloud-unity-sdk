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
    public class ActionVariableResource
    {
        /// <summary>
        /// The name of the variable
        /// </summary>
        /// <value>The name of the variable</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Whether this variable is optional and can be left out/null
        /// </summary>
        /// <value>Whether this variable is optional and can be left out/null</value>
        [JsonProperty(PropertyName = "optional")]
        public bool? Optional { get; set; }

        /// <summary>
        /// The type of the variable (see variable type endpoint for list)
        /// </summary>
        /// <value>The type of the variable (see variable type endpoint for list)</value>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ActionVariableResource {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Optional: ").Append(Optional).Append("\n");
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
