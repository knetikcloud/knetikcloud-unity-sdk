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
    public class ActivityOccurrenceCreationFailure
    {
        /// <summary>
        /// The details of each user's entry, or just the current user's if not run with ACTIVITIES_ADMIN permission
        /// </summary>
        /// <value>The details of each user's entry, or just the current user's if not run with ACTIVITIES_ADMIN permission</value>
        [JsonProperty(PropertyName = "user_results")]
        public List<ActivityOccurrenceJoinResult> UserResults { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ActivityOccurrenceCreationFailure {\n");
            sb.Append("  UserResults: ").Append(UserResults).Append("\n");
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
