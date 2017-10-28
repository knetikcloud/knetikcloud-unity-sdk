using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using com.knetikcloud.Attributes;
using com.knetikcloud.Serialization;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    [KnetikFactory ("file")]
    public class FilePropertyDefinitionResource : PropertyDefinitionResource
    {
        /// <summary>
        /// If provided, a file type that the property must match
        /// </summary>
        /// <value>If provided, a file type that the property must match</value>
        [JsonProperty(PropertyName = "file_type")]
        public string FileType;

        /// <summary>
        /// If provided, the maximum allowed file size in bytes
        /// </summary>
        /// <value>If provided, the maximum allowed file size in bytes</value>
        [JsonProperty(PropertyName = "max_file_size")]
        public long? MaxFileSize;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FilePropertyDefinitionResource {\n");
            sb.Append("  FieldList: ").Append(FieldList).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Required: ").Append(Required).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  FileType: ").Append(FileType).Append("\n");
            sb.Append("  MaxFileSize: ").Append(MaxFileSize).Append("\n");
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
