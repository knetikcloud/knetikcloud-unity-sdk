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
    public class GooglePaymentRequest
    {
        /// <summary>
        /// The json payload exactly as sent from Google
        /// </summary>
        /// <value>The json payload exactly as sent from Google</value>
        [JsonProperty(PropertyName = "json_payload")]
        public string JsonPayload;

        /// <summary>
        /// The signature from Google to verify the payload
        /// </summary>
        /// <value>The signature from Google to verify the payload</value>
        [JsonProperty(PropertyName = "signature")]
        public string Signature;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GooglePaymentRequest {\n");
            sb.Append("  JsonPayload: ").Append(JsonPayload).Append("\n");
            sb.Append("  Signature: ").Append(Signature).Append("\n");
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
