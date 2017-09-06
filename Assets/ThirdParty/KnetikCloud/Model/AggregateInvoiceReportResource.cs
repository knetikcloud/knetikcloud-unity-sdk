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
    public class AggregateInvoiceReportResource
    {
        /// <summary>
        /// Gets or Sets Count
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public long? Count { get; set; }

        /// <summary>
        /// Gets or Sets Date
        /// </summary>
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or Sets Revenue
        /// </summary>
        [JsonProperty(PropertyName = "revenue")]
        public double? Revenue { get; set; }

        /// <summary>
        /// Gets or Sets UserCount
        /// </summary>
        [JsonProperty(PropertyName = "user_count")]
        public long? UserCount { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AggregateInvoiceReportResource {\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Revenue: ").Append(Revenue).Append("\n");
            sb.Append("  UserCount: ").Append(UserCount).Append("\n");
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