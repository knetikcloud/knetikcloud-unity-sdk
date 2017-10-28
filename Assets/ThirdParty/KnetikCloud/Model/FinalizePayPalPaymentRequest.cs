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
    public class FinalizePayPalPaymentRequest
    {
        /// <summary>
        /// The ID of the invoice that is being paid. Must match the invoice sent in originally
        /// </summary>
        /// <value>The ID of the invoice that is being paid. Must match the invoice sent in originally</value>
        [JsonProperty(PropertyName = "invoice_id")]
        public int? InvoiceId;

        /// <summary>
        /// The ID of the payer that PayPal returned with the user at the return URL
        /// </summary>
        /// <value>The ID of the payer that PayPal returned with the user at the return URL</value>
        [JsonProperty(PropertyName = "payer_id")]
        public string PayerId;

        /// <summary>
        /// The token that PayPal returned with the user in the return URL
        /// </summary>
        /// <value>The token that PayPal returned with the user in the return URL</value>
        [JsonProperty(PropertyName = "token")]
        public string Token;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FinalizePayPalPaymentRequest {\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
            sb.Append("  PayerId: ").Append(PayerId).Append("\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
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
