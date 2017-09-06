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
    public class BreRule
    {
        /// <summary>
        /// A list of actions to execute, and the mapping for their parameters, when the rule runs. Minimum 1
        /// </summary>
        /// <value>A list of actions to execute, and the mapping for their parameters, when the rule runs. Minimum 1</value>
        [JsonProperty(PropertyName = "actions")]
        public List<ActionContextobject> Actions { get; set; }

        /// <summary>
        /// A condition expression that must be met in a given event for the rule to run. Empty to always run
        /// </summary>
        /// <value>A condition expression that must be met in a given event for the rule to run. Empty to always run</value>
        [JsonProperty(PropertyName = "condition")]
        public PredicateOperation Condition { get; set; }

        /// <summary>
        /// The condition as a readable string. Filled in by the system from the condition
        /// </summary>
        /// <value>The condition as a readable string. Filled in by the system from the condition</value>
        [JsonProperty(PropertyName = "condition_text")]
        public string ConditionText { get; set; }

        /// <summary>
        /// The human readable description of the rule
        /// </summary>
        /// <value>The human readable description of the rule</value>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Whether the rule is enabled to run (in conjunction with dates). Default true
        /// </summary>
        /// <value>Whether the rule is enabled to run (in conjunction with dates). Default true</value>
        [JsonProperty(PropertyName = "enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// The date the rule ceases to take effect, or null if never. Unix timestamp in seconds
        /// </summary>
        /// <value>The date the rule ceases to take effect, or null if never. Unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "end_date")]
        public long? EndDate { get; set; }

        /// <summary>
        /// The event name of the trigger this rule runs for. Affects which parameters are available
        /// </summary>
        /// <value>The event name of the trigger this rule runs for. Affects which parameters are available</value>
        [JsonProperty(PropertyName = "event_name")]
        public string EventName { get; set; }

        /// <summary>
        /// The id of the rule for later references. If left null a random guid will be generated. Must be unique. Cannot be changed
        /// </summary>
        /// <value>The id of the rule for later references. If left null a random guid will be generated. Must be unique. Cannot be changed</value>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The human readable name of the rule
        /// </summary>
        /// <value>The human readable name of the rule</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Used to sort rules to control the order they run in. Larger numbered sort values run first.  Default 500
        /// </summary>
        /// <value>Used to sort rules to control the order they run in. Larger numbered sort values run first.  Default 500</value>
        [JsonProperty(PropertyName = "sort")]
        public int? Sort { get; set; }

        /// <summary>
        /// The date the rule begins to take effect, or null if always. Unix timestamp in seconds
        /// </summary>
        /// <value>The date the rule begins to take effect, or null if always. Unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "start_date")]
        public long? StartDate { get; set; }

        /// <summary>
        /// Whether the rule is a default part of the system. System rules cannot be edited or deleted, but may be disabled
        /// </summary>
        /// <value>Whether the rule is a default part of the system. System rules cannot be edited or deleted, but may be disabled</value>
        [JsonProperty(PropertyName = "system_rule")]
        public bool? SystemRule { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BreRule {\n");
            sb.Append("  Actions: ").Append(Actions).Append("\n");
            sb.Append("  Condition: ").Append(Condition).Append("\n");
            sb.Append("  ConditionText: ").Append(ConditionText).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Enabled: ").Append(Enabled).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
            sb.Append("  EventName: ").Append(EventName).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Sort: ").Append(Sort).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  SystemRule: ").Append(SystemRule).Append("\n");
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
