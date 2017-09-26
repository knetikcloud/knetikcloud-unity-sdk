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
    public class RefundResource
    {
        /// <summary>
        /// The amount refunded
        /// </summary>
        /// <value>The amount refunded</value>
        [JsonProperty(PropertyName = "amount")]
        public double? Amount { get; set; }

        /// <summary>
        /// The id of the refund transaction
        /// </summary>
        /// <value>The id of the refund transaction</value>
        [JsonProperty(PropertyName = "refund_transaction_id")]
        public int? RefundTransactionId { get; set; }

        /// <summary>
        /// The id of the original transaction
        /// </summary>
        /// <value>The id of the original transaction</value>
        [JsonProperty(PropertyName = "transaction_id")]
        public int? TransactionId { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RefundResource {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  RefundTransactionId: ").Append(RefundTransactionId).Append("\n");
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
