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
    public class RevenueReportResource
    {
        /// <summary>
        /// Gets or Sets CustomerCount
        /// </summary>
        [JsonProperty(PropertyName = "customer_count")]
        public long? CustomerCount { get; set; }

        /// <summary>
        /// Gets or Sets SaleCount
        /// </summary>
        [JsonProperty(PropertyName = "sale_count")]
        public long? SaleCount { get; set; }

        /// <summary>
        /// Gets or Sets SalesAverage
        /// </summary>
        [JsonProperty(PropertyName = "sales_average")]
        public decimal? SalesAverage { get; set; }

        /// <summary>
        /// Gets or Sets SalesTotal
        /// </summary>
        [JsonProperty(PropertyName = "sales_total")]
        public decimal? SalesTotal { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RevenueReportResource {\n");
            sb.Append("  CustomerCount: ").Append(CustomerCount).Append("\n");
            sb.Append("  SaleCount: ").Append(SaleCount).Append("\n");
            sb.Append("  SalesAverage: ").Append(SalesAverage).Append("\n");
            sb.Append("  SalesTotal: ").Append(SalesTotal).Append("\n");
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
