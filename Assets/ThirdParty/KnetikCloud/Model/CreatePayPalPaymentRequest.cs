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
    
    
    public class CreatePayPalPaymentRequest
    {
        /// <summary>
        /// The endpoint URL to which PayPal should forward the user to if they cancel the checkout process
        /// </summary>
        /// <value>The endpoint URL to which PayPal should forward the user to if they cancel the checkout process</value>
        [JsonProperty(PropertyName = "cancel_url")]
        public string CancelUrl;

        /// <summary>
        /// The ID of an invoice to pay
        /// </summary>
        /// <value>The ID of an invoice to pay</value>
        [JsonProperty(PropertyName = "invoice_id")]
        public int? InvoiceId;

        /// <summary>
        /// The endpoint URL to which PayPal should forward the user after they accept. This endpoint will receive information needed for the next step
        /// </summary>
        /// <value>The endpoint URL to which PayPal should forward the user after they accept. This endpoint will receive information needed for the next step</value>
        [JsonProperty(PropertyName = "return_url")]
        public string ReturnUrl;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreatePayPalPaymentRequest {\n");
            sb.Append("  CancelUrl: ").Append(CancelUrl).Append("\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
            sb.Append("  ReturnUrl: ").Append(ReturnUrl).Append("\n");
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
