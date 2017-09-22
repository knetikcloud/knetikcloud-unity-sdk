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
    public class BreRuleLog
    {
        /// <summary>
        /// Whether the rule ran
        /// </summary>
        /// <value>Whether the rule ran</value>
        [JsonProperty(PropertyName = "ran")]
        public bool? Ran { get; set; }

        /// <summary>
        /// The reason for the rule
        /// </summary>
        /// <value>The reason for the rule</value>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        /// The end date of the rule in seconds
        /// </summary>
        /// <value>The end date of the rule in seconds</value>
        [JsonProperty(PropertyName = "rule_end_date")]
        public long? RuleEndDate { get; set; }

        /// <summary>
        /// The id of the rule
        /// </summary>
        /// <value>The id of the rule</value>
        [JsonProperty(PropertyName = "rule_id")]
        public string RuleId { get; set; }

        /// <summary>
        /// The name of the rule
        /// </summary>
        /// <value>The name of the rule</value>
        [JsonProperty(PropertyName = "rule_name")]
        public string RuleName { get; set; }

        /// <summary>
        /// The start date of the rule in seconds
        /// </summary>
        /// <value>The start date of the rule in seconds</value>
        [JsonProperty(PropertyName = "rule_start_date")]
        public long? RuleStartDate { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BreRuleLog {\n");
            sb.Append("  Ran: ").Append(Ran).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  RuleEndDate: ").Append(RuleEndDate).Append("\n");
            sb.Append("  RuleId: ").Append(RuleId).Append("\n");
            sb.Append("  RuleName: ").Append(RuleName).Append("\n");
            sb.Append("  RuleStartDate: ").Append(RuleStartDate).Append("\n");
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
