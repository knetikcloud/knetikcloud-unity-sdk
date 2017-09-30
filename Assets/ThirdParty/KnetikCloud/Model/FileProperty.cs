using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    public class FileProperty : Property
    {
        /// <summary>
        /// A crc value for file integrity verification
        /// </summary>
        /// <value>A crc value for file integrity verification</value>
        [JsonProperty(PropertyName = "crc")]
        public string Crc { get; set; }

        /// <summary>
        /// A description of the file
        /// </summary>
        /// <value>A description of the file</value>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The type of file such as txt, mp3, mov or csv
        /// </summary>
        /// <value>The type of file such as txt, mp3, mov or csv</value>
        [JsonProperty(PropertyName = "file_type")]
        public string FileType { get; set; }

        /// <summary>
        /// The url of the file
        /// </summary>
        /// <value>The url of the file</value>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FileProperty {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Crc: ").Append(Crc).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  FileType: ").Append(FileType).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
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
