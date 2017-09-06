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
    public class BreGlobalResource
    {
        /// <summary>
        /// A human readable description for display in admin pages
        /// </summary>
        /// <value>A human readable description for display in admin pages</value>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The id of the global definition. Default is a random guid. Cannot be updated
        /// </summary>
        /// <value>The id of the global definition. Default is a random guid. Cannot be updated</value>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The key for the global. Must be unique when combined with scope names. Usually a single descriptive word like 'purchases' or 'logins'
        /// </summary>
        /// <value>The key for the global. Must be unique when combined with scope names. Usually a single descriptive word like 'purchases' or 'logins'</value>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// A human readable name for display in admin pages
        /// </summary>
        /// <value>A human readable name for display in admin pages</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A list of scoping parameters. Allows the global to have a different value in different context such as a count of purchases for each user (by putting a 'user' scope in this list). When using this global in a rule these scopes will need to be mapped with an expression to provide a value, similar to the parameters in an action
        /// </summary>
        /// <value>A list of scoping parameters. Allows the global to have a different value in different context such as a count of purchases for each user (by putting a 'user' scope in this list). When using this global in a rule these scopes will need to be mapped with an expression to provide a value, similar to the parameters in an action</value>
        [JsonProperty(PropertyName = "scopes")]
        public List<BreGlobalScopeDefinition> Scopes { get; set; }

        /// <summary>
        /// Where this global came from. System globals cannot be removed or updated
        /// </summary>
        /// <value>Where this global came from. System globals cannot be removed or updated</value>
        [JsonProperty(PropertyName = "system_global")]
        public bool? SystemGlobal { get; set; }

        /// <summary>
        /// The variable type the global stores. See the See Bre Variables enpoint for list
        /// </summary>
        /// <value>The variable type the global stores. See the See Bre Variables enpoint for list</value>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BreGlobalResource {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Scopes: ").Append(Scopes).Append("\n");
            sb.Append("  SystemGlobal: ").Append(SystemGlobal).Append("\n");
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
