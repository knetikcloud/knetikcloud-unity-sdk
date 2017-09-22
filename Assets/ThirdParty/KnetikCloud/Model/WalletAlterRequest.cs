using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class WalletAlterRequest
    {
        /// <summary>
        /// The amount of currency to add/remove. positive to add, negative to remove
        /// </summary>
        /// <value>The amount of currency to add/remove. positive to add, negative to remove</value>
        [JsonProperty(PropertyName = "delta")]
        public double? Delta { get; set; }

        /// <summary>
        /// The id of an invoice to attribute the transaction to
        /// </summary>
        /// <value>The id of an invoice to attribute the transaction to</value>
        [JsonProperty(PropertyName = "invoice_id")]
        public int? InvoiceId { get; set; }

        /// <summary>
        /// The admin entered or system generated reason
        /// </summary>
        /// <value>The admin entered or system generated reason</value>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        /// The transaction type to allow for search/etc
        /// </summary>
        /// <value>The transaction type to allow for search/etc</value>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WalletAlterRequest {\n");
            sb.Append("  Delta: ").Append(Delta).Append("\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
