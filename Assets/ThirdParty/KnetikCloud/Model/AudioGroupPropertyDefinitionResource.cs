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
    [KnetikFactory ("audio_group")]
    
    public class AudioGroupPropertyDefinitionResource : FileGroupPropertyDefinitionResource
    {
        /// <summary>
        /// If provided, the maximum length of the audio
        /// </summary>
        /// <value>If provided, the maximum length of the audio</value>
        [JsonProperty(PropertyName = "max_length")]
        public int? MaxLength;

        /// <summary>
        /// If provided, the minimum length of the audio
        /// </summary>
        /// <value>If provided, the minimum length of the audio</value>
        [JsonProperty(PropertyName = "min_length")]
        public int? MinLength;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AudioGroupPropertyDefinitionResource {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  FieldList: ").Append(FieldList).Append("\n");
            sb.Append("  FriendlyName: ").Append(FriendlyName).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OptionLabelPath: ").Append(OptionLabelPath).Append("\n");
            sb.Append("  OptionValuePath: ").Append(OptionValuePath).Append("\n");
            sb.Append("  OptionsUrl: ").Append(OptionsUrl).Append("\n");
            sb.Append("  Required: ").Append(Required).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  FileType: ").Append(FileType).Append("\n");
            sb.Append("  MaxCount: ").Append(MaxCount).Append("\n");
            sb.Append("  MaxFileSize: ").Append(MaxFileSize).Append("\n");
            sb.Append("  MinCount: ").Append(MinCount).Append("\n");
            sb.Append("  MaxLength: ").Append(MaxLength).Append("\n");
            sb.Append("  MinLength: ").Append(MinLength).Append("\n");
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
