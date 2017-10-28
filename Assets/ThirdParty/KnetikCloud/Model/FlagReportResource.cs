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
    public class FlagReportResource
    {
        /// <summary>
        /// The context of that resource 
        /// </summary>
        /// <value>The context of that resource </value>
        [JsonProperty(PropertyName = "context")]
        public string Context;

        /// <summary>
        /// The context ID of that resource
        /// </summary>
        /// <value>The context ID of that resource</value>
        [JsonProperty(PropertyName = "context_id")]
        public string ContextId;

        /// <summary>
        /// The date/time this resource was created in seconds since epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The unique ID for that resource
        /// </summary>
        /// <value>The unique ID for that resource</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

        /// <summary>
        /// The reason of that resource required only in case of active resolution
        /// </summary>
        /// <value>The reason of that resource required only in case of active resolution</value>
        [JsonProperty(PropertyName = "reason")]
        public string Reason;

        /// <summary>
        /// The resolution of that resource
        /// </summary>
        /// <value>The resolution of that resource</value>
        [JsonProperty(PropertyName = "resolution")]
        public string Resolution;

        /// <summary>
        /// The date/time this report was resolved in seconds since epoch. Null if not resolved yet
        /// </summary>
        /// <value>The date/time this report was resolved in seconds since epoch. Null if not resolved yet</value>
        [JsonProperty(PropertyName = "resolved")]
        public long? Resolved;

        /// <summary>
        /// The date/time this resource was last updated in seconds since epoch
        /// </summary>
        /// <value>The date/time this resource was last updated in seconds since epoch</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FlagReportResource {\n");
            sb.Append("  Context: ").Append(Context).Append("\n");
            sb.Append("  ContextId: ").Append(ContextId).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  Resolution: ").Append(Resolution).Append("\n");
            sb.Append("  Resolved: ").Append(Resolved).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
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
