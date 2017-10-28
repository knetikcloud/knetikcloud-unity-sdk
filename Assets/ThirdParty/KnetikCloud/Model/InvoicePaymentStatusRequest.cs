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
    public class InvoicePaymentStatusRequest
    {
        /// <summary>
        /// If included, will set the payment method used on the invoice
        /// </summary>
        /// <value>If included, will set the payment method used on the invoice</value>
        [JsonProperty(PropertyName = "payment_method_id")]
        public int? PaymentMethodId;

        /// <summary>
        /// The new status for the invoice. Additional options may be available based on configuration.  Allowable values: 'new', 'paid', 'hold', 'canceled', 'payment failed', 'partial refund', 'refund'
        /// </summary>
        /// <value>The new status for the invoice. Additional options may be available based on configuration.  Allowable values: 'new', 'paid', 'hold', 'canceled', 'payment failed', 'partial refund', 'refund'</value>
        [JsonProperty(PropertyName = "status")]
        public string Status;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class InvoicePaymentStatusRequest {\n");
            sb.Append("  PaymentMethodId: ").Append(PaymentMethodId).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
