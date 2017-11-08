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
    
    
    public class FinalizeBillingAgreementRequest
    {
        /// <summary>
        /// The ID of the invoice being paid along with the creation of this agreement
        /// </summary>
        /// <value>The ID of the invoice being paid along with the creation of this agreement</value>
        [JsonProperty(PropertyName = "invoice_id")]
        public int? InvoiceId;

        /// <summary>
        /// Whether the new payment method created should be the user's default
        /// </summary>
        /// <value>Whether the new payment method created should be the user's default</value>
        [JsonProperty(PropertyName = "new_default")]
        public bool? NewDefault;

        /// <summary>
        /// The payer ID from PayPal (passed as a parameter in the return URL). Only required if an invoice ID was included
        /// </summary>
        /// <value>The payer ID from PayPal (passed as a parameter in the return URL). Only required if an invoice ID was included</value>
        [JsonProperty(PropertyName = "payer_id")]
        public string PayerId;

        /// <summary>
        /// The token from PayPal (passed as a parameter in the return URL)
        /// </summary>
        /// <value>The token from PayPal (passed as a parameter in the return URL)</value>
        [JsonProperty(PropertyName = "token")]
        public string Token;

        /// <summary>
        /// The ID of the user. Defaults to the logged in user
        /// </summary>
        /// <value>The ID of the user. Defaults to the logged in user</value>
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
            sb.Append("class FinalizeBillingAgreementRequest {\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
            sb.Append("  NewDefault: ").Append(NewDefault).Append("\n");
            sb.Append("  PayerId: ").Append(PayerId).Append("\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
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
