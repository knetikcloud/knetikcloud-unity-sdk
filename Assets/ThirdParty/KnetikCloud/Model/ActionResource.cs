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
    
    
    public class ActionResource
    {
        /// <summary>
        /// The category the action is in. All customer specific actions are in the 'custom' category
        /// </summary>
        /// <value>The category the action is in. All customer specific actions are in the 'custom' category</value>
        [JsonProperty(PropertyName = "category")]
        public string Category;

        /// <summary>
        /// The description of the action
        /// </summary>
        /// <value>The description of the action</value>
        [JsonProperty(PropertyName = "description")]
        public string Description;

        /// <summary>
        /// The name of the action. Used as the unique id for reference
        /// </summary>
        /// <value>The name of the action. Used as the unique id for reference</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// A list of tags for searching
        /// </summary>
        /// <value>A list of tags for searching</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags;

        /// <summary>
        /// The variables required for the action
        /// </summary>
        /// <value>The variables required for the action</value>
        [JsonProperty(PropertyName = "variables")]
        public List<ActionVariableResource> Variables;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ActionResource {\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Variables: ").Append(Variables).Append("\n");
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
