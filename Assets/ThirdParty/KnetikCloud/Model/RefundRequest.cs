using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using KnetikUnity.Attributes;
using KnetikUnity.Serialization;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    
    
    public class RefundRequest
    {
        /// <summary>
        /// The amount to refund. If left off, will refund the remaining balance of the transaction or specific item balance (if SKU provided), whichever is less.
        /// </summary>
        /// <value>The amount to refund. If left off, will refund the remaining balance of the transaction or specific item balance (if SKU provided), whichever is less.</value>
        [JsonProperty(PropertyName = "amount")]
        public decimal? Amount;

        /// <summary>
        /// The SKU of a bundle item from the invoice that the target item is within.
        /// </summary>
        /// <value>The SKU of a bundle item from the invoice that the target item is within.</value>
        [JsonProperty(PropertyName = "bundle_sku")]
        public string BundleSku;

        /// <summary>
        /// Notes about or reason for the refund
        /// </summary>
        /// <value>Notes about or reason for the refund</value>
        [JsonProperty(PropertyName = "notes")]
        public string Notes;

        /// <summary>
        /// The SKU of a specific item from the invoice to refund. Affects the maximum refund amount (not to exceed the price of this item times quantity on invoice). Transaction must be tied to an invoice if used.
        /// </summary>
        /// <value>The SKU of a specific item from the invoice to refund. Affects the maximum refund amount (not to exceed the price of this item times quantity on invoice). Transaction must be tied to an invoice if used.</value>
        [JsonProperty(PropertyName = "sku")]
        public string Sku;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RefundRequest {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  BundleSku: ").Append(BundleSku).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  Sku: ").Append(Sku).Append("\n");
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
