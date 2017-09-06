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
    public class VideoGroupPropertyDefinitionResource : FileGroupPropertyDefinitionResource
    {
        /// <summary>
        /// If provided, the maximum height of each video
        /// </summary>
        /// <value>If provided, the maximum height of each video</value>
        [JsonProperty(PropertyName = "max_height")]
        public int? MaxHeight { get; set; }

        /// <summary>
        /// If provided, the maximum length of each video
        /// </summary>
        /// <value>If provided, the maximum length of each video</value>
        [JsonProperty(PropertyName = "max_length")]
        public int? MaxLength { get; set; }

        /// <summary>
        /// If provided, the maximum width of each video
        /// </summary>
        /// <value>If provided, the maximum width of each video</value>
        [JsonProperty(PropertyName = "max_width")]
        public int? MaxWidth { get; set; }

        /// <summary>
        /// If provided, the minimum height of each video
        /// </summary>
        /// <value>If provided, the minimum height of each video</value>
        [JsonProperty(PropertyName = "min_height")]
        public int? MinHeight { get; set; }

        /// <summary>
        /// If provided, the minimum length of each video
        /// </summary>
        /// <value>If provided, the minimum length of each video</value>
        [JsonProperty(PropertyName = "min_length")]
        public int? MinLength { get; set; }

        /// <summary>
        /// If provided, the minimum width of each video
        /// </summary>
        /// <value>If provided, the minimum width of each video</value>
        [JsonProperty(PropertyName = "min_width")]
        public int? MinWidth { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class VideoGroupPropertyDefinitionResource {\n");
            sb.Append("  FieldList: ").Append(FieldList).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Required: ").Append(Required).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  FileType: ").Append(FileType).Append("\n");
            sb.Append("  MaxCount: ").Append(MaxCount).Append("\n");
            sb.Append("  MaxFileSize: ").Append(MaxFileSize).Append("\n");
            sb.Append("  MinCount: ").Append(MinCount).Append("\n");
            sb.Append("  MaxHeight: ").Append(MaxHeight).Append("\n");
            sb.Append("  MaxLength: ").Append(MaxLength).Append("\n");
            sb.Append("  MaxWidth: ").Append(MaxWidth).Append("\n");
            sb.Append("  MinHeight: ").Append(MinHeight).Append("\n");
            sb.Append("  MinLength: ").Append(MinLength).Append("\n");
            sb.Append("  MinWidth: ").Append(MinWidth).Append("\n");
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