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
    
    
    public class PaymentAuthorizationResource
    {
        /// <summary>
        /// Whether this authorization has been captured
        /// </summary>
        /// <value>Whether this authorization has been captured</value>
        [JsonProperty(PropertyName = "captured")]
        public bool? Captured;

        /// <summary>
        /// The date this authorization was received, unix timestamp in seconds
        /// </summary>
        /// <value>The date this authorization was received, unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "created")]
        public long? Created;

        /// <summary>
        /// The details for this authorization. Format dependent on payment provider
        /// </summary>
        /// <value>The details for this authorization. Format dependent on payment provider</value>
        [JsonProperty(PropertyName = "details")]
        public Object Details;

        /// <summary>
        /// The id of the authorization
        /// </summary>
        /// <value>The id of the authorization</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id;

        /// <summary>
        /// The invoice this authorization is intended to pay
        /// </summary>
        /// <value>The invoice this authorization is intended to pay</value>
        [JsonProperty(PropertyName = "invoice")]
        public int? Invoice;

        /// <summary>
        /// The payment type (which provider) this payment is through
        /// </summary>
        /// <value>The payment type (which provider) this payment is through</value>
        [JsonProperty(PropertyName = "payment_type")]
        public SimpleReferenceResourceint PaymentType;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PaymentAuthorizationResource {\n");
            sb.Append("  Captured: ").Append(Captured).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Invoice: ").Append(Invoice).Append("\n");
            sb.Append("  PaymentType: ").Append(PaymentType).Append("\n");
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
