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
    
    
    public class S3Config
    {
        /// <summary>
        /// Gets or Sets BucketName
        /// </summary>
        [JsonProperty(PropertyName = "bucket_name")]
        public string BucketName;

        /// <summary>
        /// Gets or Sets CdnUrl
        /// </summary>
        [JsonProperty(PropertyName = "cdn_url")]
        public string CdnUrl;

        /// <summary>
        /// Gets or Sets Region
        /// </summary>
        [JsonProperty(PropertyName = "region")]
        public string Region;

        /// <summary>
        /// Gets or Sets UploadPrefix
        /// </summary>
        [JsonProperty(PropertyName = "upload_prefix")]
        public string UploadPrefix;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class S3Config {\n");
            sb.Append("  BucketName: ").Append(BucketName).Append("\n");
            sb.Append("  CdnUrl: ").Append(CdnUrl).Append("\n");
            sb.Append("  Region: ").Append(Region).Append("\n");
            sb.Append("  UploadPrefix: ").Append(UploadPrefix).Append("\n");
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
