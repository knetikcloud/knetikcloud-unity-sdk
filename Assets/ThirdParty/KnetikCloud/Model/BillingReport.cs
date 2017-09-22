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
    public class BillingReport
    {
        /// <summary>
        /// Gets or Sets Created
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public long? Created { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets LastKnownFailures
        /// </summary>
        [JsonProperty(PropertyName = "last_known_failures")]
        public List<string> LastKnownFailures { get; set; }

        /// <summary>
        /// Gets or Sets Statistics
        /// </summary>
        [JsonProperty(PropertyName = "statistics")]
        public Dictionary<string, int?> Statistics { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BillingReport {\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastKnownFailures: ").Append(LastKnownFailures).Append("\n");
            sb.Append("  Statistics: ").Append(Statistics).Append("\n");
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
