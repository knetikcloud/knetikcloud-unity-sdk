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
    public class PaymentMethodTypeResource
    {
        /// <summary>
        /// The id of the payment method type
        /// </summary>
        /// <value>The id of the payment method type</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The maximum timelimit in hours for an invoice in the processing status while waiting on this payment method type. Defaults to the global config invoice.processing_expiration_hours if null
        /// </summary>
        /// <value>The maximum timelimit in hours for an invoice in the processing status while waiting on this payment method type. Defaults to the global config invoice.processing_expiration_hours if null</value>
        [JsonProperty(PropertyName = "invoice_processing_hours")]
        public int? InvoiceProcessingHours { get; set; }

        /// <summary>
        /// The name of the payment method type
        /// </summary>
        /// <value>The name of the payment method type</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Whether the payment handler supports the authorize and capture flow
        /// </summary>
        /// <value>Whether the payment handler supports the authorize and capture flow</value>
        [JsonProperty(PropertyName = "supports_capture")]
        public bool? SupportsCapture { get; set; }

        /// <summary>
        /// Whether the payment handler supports paying for part of an invoice, rather than the full grand_total
        /// </summary>
        /// <value>Whether the payment handler supports paying for part of an invoice, rather than the full grand_total</value>
        [JsonProperty(PropertyName = "supports_partial")]
        public bool? SupportsPartial { get; set; }

        /// <summary>
        /// Whether the payment handler supports rebilling the method later (for saved payments or subscriptions)
        /// </summary>
        /// <value>Whether the payment handler supports rebilling the method later (for saved payments or subscriptions)</value>
        [JsonProperty(PropertyName = "supports_rebill")]
        public bool? SupportsRebill { get; set; }

        /// <summary>
        /// Whether the payment handler supports refunding
        /// </summary>
        /// <value>Whether the payment handler supports refunding</value>
        [JsonProperty(PropertyName = "supports_refunds")]
        public bool? SupportsRefunds { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PaymentMethodTypeResource {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InvoiceProcessingHours: ").Append(InvoiceProcessingHours).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  SupportsCapture: ").Append(SupportsCapture).Append("\n");
            sb.Append("  SupportsPartial: ").Append(SupportsPartial).Append("\n");
            sb.Append("  SupportsRebill: ").Append(SupportsRebill).Append("\n");
            sb.Append("  SupportsRefunds: ").Append(SupportsRefunds).Append("\n");
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
