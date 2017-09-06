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
    public class Schedule
    {
        /// <summary>
        /// The duration of the repeatable events
        /// </summary>
        /// <value>The duration of the repeatable events</value>
        [JsonProperty(PropertyName = "duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// The unit of time for the duration field
        /// </summary>
        /// <value>The unit of time for the duration field</value>
        [JsonProperty(PropertyName = "duration_unit")]
        public string DurationUnit { get; set; }

        /// <summary>
        /// How often the event is scheduled
        /// </summary>
        /// <value>How often the event is scheduled</value>
        [JsonProperty(PropertyName = "repeat")]
        public string Repeat { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Schedule {\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
            sb.Append("  DurationUnit: ").Append(DurationUnit).Append("\n");
            sb.Append("  Repeat: ").Append(Repeat).Append("\n");
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