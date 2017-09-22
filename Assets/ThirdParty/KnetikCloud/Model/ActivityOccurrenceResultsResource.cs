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
    public class ActivityOccurrenceResultsResource
    {
        /// <summary>
        /// The game results for each user. Include all users that played (paid to get in) even if they were eliminated without a result. A null metric is allowed
        /// </summary>
        /// <value>The game results for each user. Include all users that played (paid to get in) even if they were eliminated without a result. A null metric is allowed</value>
        [JsonProperty(PropertyName = "users")]
        public List<UserActivityResultsResource> Users { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ActivityOccurrenceResultsResource {\n");
            sb.Append("  Users: ").Append(Users).Append("\n");
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
