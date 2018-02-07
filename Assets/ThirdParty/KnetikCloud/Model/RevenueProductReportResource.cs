using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using KnetikUnity.Attributes;
using KnetikUnity.Serialization;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    
    
    public class RevenueProductReportResource
    {
        /// <summary>
        /// Gets or Sets ItemId
        /// </summary>
        [JsonProperty(PropertyName = "item_id")]
        public int? ItemId;

        /// <summary>
        /// Gets or Sets ItemName
        /// </summary>
        [JsonProperty(PropertyName = "item_name")]
        public string ItemName;

        /// <summary>
        /// Gets or Sets Revenue
        /// </summary>
        [JsonProperty(PropertyName = "revenue")]
        public decimal? Revenue;

        /// <summary>
        /// Gets or Sets Volume
        /// </summary>
        [JsonProperty(PropertyName = "volume")]
        public long? Volume;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RevenueProductReportResource {\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
            sb.Append("  ItemName: ").Append(ItemName).Append("\n");
            sb.Append("  Revenue: ").Append(Revenue).Append("\n");
            sb.Append("  Volume: ").Append(Volume).Append("\n");
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
