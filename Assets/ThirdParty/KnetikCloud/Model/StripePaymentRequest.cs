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
    public class StripePaymentRequest
    {
        /// <summary>
        /// The amount to pay, if not the full remaining balance (leave out to pay in full, but be careful no other partial payment has been started)
        /// </summary>
        /// <value>The amount to pay, if not the full remaining balance (leave out to pay in full, but be careful no other partial payment has been started)</value>
        [JsonProperty(PropertyName = "amount")]
        public decimal? Amount;

        /// <summary>
        /// The id of the invoice to pay
        /// </summary>
        /// <value>The id of the invoice to pay</value>
        [JsonProperty(PropertyName = "invoice_id")]
        public int? InvoiceId;

        /// <summary>
        /// A token from Stripe to identify payment info to be tied to the customer
        /// </summary>
        /// <value>A token from Stripe to identify payment info to be tied to the customer</value>
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
            sb.Append("class StripePaymentRequest {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
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
