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
    
    
    public class AmazonS3Activity
    {
        /// <summary>
        /// S3 action (i.e., 'PUT') associated with the activity
        /// </summary>
        /// <value>S3 action (i.e., 'PUT') associated with the activity</value>
        [JsonProperty(PropertyName = "action")]
        public string Action;

        /// <summary>
        /// URL for accessing the resource. Will use a CDN if configured, or direct to S3 if not
        /// </summary>
        /// <value>URL for accessing the resource. Will use a CDN if configured, or direct to S3 if not</value>
        [JsonProperty(PropertyName = "cdn_url")]
        public string CdnUrl;

        /// <summary>
        /// Date the resource was created in S3
        /// </summary>
        /// <value>Date the resource was created in S3</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// Name of the file being processed as a resource in S3
        /// </summary>
        /// <value>Name of the file being processed as a resource in S3</value>
        [JsonProperty(PropertyName = "filename")]
        public string Filename;

        /// <summary>
        /// Unique id of the S3 activity
        /// </summary>
        /// <value>Unique id of the S3 activity</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

        /// <summary>
        /// S3 object key for the resource
        /// </summary>
        /// <value>S3 object key for the resource</value>
        [JsonProperty(PropertyName = "object_key")]
        public string ObjectKey;

        /// <summary>
        /// URL that one can PUT the file to, to upload it to S3
        /// </summary>
        /// <value>URL that one can PUT the file to, to upload it to S3</value>
        [JsonProperty(PropertyName = "url")]
        public string Url;

        /// <summary>
        /// The id of the user that created this S3 activity
        /// </summary>
        /// <value>The id of the user that created this S3 activity</value>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AmazonS3Activity {\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("  CdnUrl: ").Append(CdnUrl).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Filename: ").Append(Filename).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ObjectKey: ").Append(ObjectKey).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
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
