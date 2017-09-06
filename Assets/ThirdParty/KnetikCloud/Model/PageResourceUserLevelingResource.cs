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
    public class PageResourceUserLevelingResource
    {
        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public List<UserLevelingResource> Content { get; set; }

        /// <summary>
        /// Gets or Sets First
        /// </summary>
        [JsonProperty(PropertyName = "first")]
        public bool? First { get; set; }

        /// <summary>
        /// Gets or Sets Last
        /// </summary>
        [JsonProperty(PropertyName = "last")]
        public bool? Last { get; set; }

        /// <summary>
        /// Gets or Sets Number
        /// </summary>
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        /// <summary>
        /// Gets or Sets NumberOfElements
        /// </summary>
        [JsonProperty(PropertyName = "number_of_elements")]
        public int? NumberOfElements { get; set; }

        /// <summary>
        /// Gets or Sets Size
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public int? Size { get; set; }

        /// <summary>
        /// Gets or Sets Sort
        /// </summary>
        [JsonProperty(PropertyName = "sort")]
        public List<Order> Sort { get; set; }

        /// <summary>
        /// Gets or Sets TotalElements
        /// </summary>
        [JsonProperty(PropertyName = "total_elements")]
        public long? TotalElements { get; set; }

        /// <summary>
        /// Gets or Sets TotalPages
        /// </summary>
        [JsonProperty(PropertyName = "total_pages")]
        public int? TotalPages { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PageResourceUserLevelingResource {\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  First: ").Append(First).Append("\n");
            sb.Append("  Last: ").Append(Last).Append("\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  NumberOfElements: ").Append(NumberOfElements).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
            sb.Append("  Sort: ").Append(Sort).Append("\n");
            sb.Append("  TotalElements: ").Append(TotalElements).Append("\n");
            sb.Append("  TotalPages: ").Append(TotalPages).Append("\n");
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
