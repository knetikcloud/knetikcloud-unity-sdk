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
    
    
    public class ActivityOccurrenceJoinResult
    {
        /// <summary>
        /// The details on the entitlement object needed to enter the occurrence (if any)
        /// </summary>
        /// <value>The details on the entitlement object needed to enter the occurrence (if any)</value>
        [JsonProperty(PropertyName = "entitlement")]
        public ActivityEntitlementResource Entitlement;

        /// <summary>
        /// Zero if the user was/could be added to the occurrence. Jsapi error code indicating the reason of the failure otherwise
        /// </summary>
        /// <value>Zero if the user was/could be added to the occurrence. Jsapi error code indicating the reason of the failure otherwise</value>
        [JsonProperty(PropertyName = "error_code")]
        public int? ErrorCode;

        /// <summary>
        /// An error message if failure
        /// </summary>
        /// <value>An error message if failure</value>
        [JsonProperty(PropertyName = "message")]
        public string Message;

        /// <summary>
        /// The user's id
        /// </summary>
        /// <value>The user's id</value>
        [JsonProperty(PropertyName = "user_id")]
        public long? UserId;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ActivityOccurrenceJoinResult {\n");
            sb.Append("  Entitlement: ").Append(Entitlement).Append("\n");
            sb.Append("  ErrorCode: ").Append(ErrorCode).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
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
