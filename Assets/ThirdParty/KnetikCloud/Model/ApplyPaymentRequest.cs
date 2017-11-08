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
    
    
    public class ApplyPaymentRequest
    {
        /// <summary>
        /// The id of the local invoice being paid.
        /// </summary>
        /// <value>The id of the local invoice being paid.</value>
        [JsonProperty(PropertyName = "invoice_id")]
        public int? InvoiceId;

        /// <summary>
        /// The encoded receipt string from Apple's services.
        /// </summary>
        /// <value>The encoded receipt string from Apple's services.</value>
        [JsonProperty(PropertyName = "receipt")]
        public string Receipt;

        /// <summary>
        /// The id of the specific transaction from Apple's services.
        /// </summary>
        /// <value>The id of the specific transaction from Apple's services.</value>
        [JsonProperty(PropertyName = "transaction_id")]
        public string TransactionId;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ApplyPaymentRequest {\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
            sb.Append("  Receipt: ").Append(Receipt).Append("\n");
            sb.Append("  TransactionId: ").Append(TransactionId).Append("\n");
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
