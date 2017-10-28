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
    [KnetikFactory ("time_period_usable")]
    public class TimePeriodUsable : Behavior
    {
        /// <summary>
        /// The amount of times it can be used
        /// </summary>
        /// <value>The amount of times it can be used</value>
        [JsonProperty(PropertyName = "max_use")]
        public int? MaxUse;

        /// <summary>
        /// The length of time
        /// </summary>
        /// <value>The length of time</value>
        [JsonProperty(PropertyName = "time_length")]
        public int? TimeLength;

        /// <summary>
        /// The unit of time
        /// </summary>
        /// <value>The unit of time</value>
        [JsonProperty(PropertyName = "unit_of_time")]
        public string UnitOfTime;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TimePeriodUsable {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  TypeHint: ").Append(TypeHint).Append("\n");
            sb.Append("  MaxUse: ").Append(MaxUse).Append("\n");
            sb.Append("  TimeLength: ").Append(TimeLength).Append("\n");
            sb.Append("  UnitOfTime: ").Append(UnitOfTime).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
