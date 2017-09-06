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
    public class TimePeriodGettable : Behavior
    {
        /// <summary>
        /// The time period limit
        /// </summary>
        /// <value>The time period limit</value>
        [JsonProperty(PropertyName = "get_limit")]
        public int? GetLimit { get; set; }

        /// <summary>
        /// The name of a group of items. Multiple items with the same group name will be limited together, leave null to be assigned a random unique name. It is typical that the other properties here will be the same for all, but this is not enforced and the item being recieved will use its settings.
        /// </summary>
        /// <value>The name of a group of items. Multiple items with the same group name will be limited together, leave null to be assigned a random unique name. It is typical that the other properties here will be the same for all, but this is not enforced and the item being recieved will use its settings.</value>
        [JsonProperty(PropertyName = "group_name")]
        public string GroupName { get; set; }

        /// <summary>
        /// The length of time
        /// </summary>
        /// <value>The length of time</value>
        [JsonProperty(PropertyName = "time_length")]
        public int? TimeLength { get; set; }

        /// <summary>
        /// The unit of time
        /// </summary>
        /// <value>The unit of time</value>
        [JsonProperty(PropertyName = "unit_of_time")]
        public string UnitOfTime { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TimePeriodGettable {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  TypeHint: ").Append(TypeHint).Append("\n");
            sb.Append("  GetLimit: ").Append(GetLimit).Append("\n");
            sb.Append("  GroupName: ").Append(GroupName).Append("\n");
            sb.Append("  TimeLength: ").Append(TimeLength).Append("\n");
            sb.Append("  UnitOfTime: ").Append(UnitOfTime).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public  new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}