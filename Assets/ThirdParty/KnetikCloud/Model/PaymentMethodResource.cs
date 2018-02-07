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
    
    
    public class PaymentMethodResource
    {
        /// <summary>
        /// The date/time this resource was created in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// Gets or Sets _Default
        /// </summary>
        [JsonProperty(PropertyName = "default")]
        public bool? _Default;

        /// <summary>
        /// Whether this payment method is disabled or not
        /// </summary>
        /// <value>Whether this payment method is disabled or not</value>
        [JsonProperty(PropertyName = "disabled")]
        public bool? Disabled;

        /// <summary>
        /// The expiration date for the payment method, expressed as seconds since epoch. Typically used for credit card payment methods
        /// </summary>
        /// <value>The expiration date for the payment method, expressed as seconds since epoch. Typically used for credit card payment methods</value>
        [JsonProperty(PropertyName = "expiration_date")]
        public long? ExpirationDate;

        /// <summary>
        /// The expiration month (1 - 12) for the payment method. Typically used for credit card payment methods
        /// </summary>
        /// <value>The expiration month (1 - 12) for the payment method. Typically used for credit card payment methods</value>
        [JsonProperty(PropertyName = "expiration_month")]
        public int? ExpirationMonth;

        /// <summary>
        /// The expiration year for the payment method. Typically used for credit card payment methods
        /// </summary>
        /// <value>The expiration year for the payment method. Typically used for credit card payment methods</value>
        [JsonProperty(PropertyName = "expiration_year")]
        public int? ExpirationYear;

        /// <summary>
        /// The unique ID of the resource
        /// </summary>
        /// <value>The unique ID of the resource</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

        /// <summary>
        /// The last 4 digits of the account number for the payment method. Typically used for credit card payment methods
        /// </summary>
        /// <value>The last 4 digits of the account number for the payment method. Typically used for credit card payment methods</value>
        [JsonProperty(PropertyName = "last4")]
        public string Last4;

        /// <summary>
        /// The user friendly name of the resource
        /// </summary>
        /// <value>The user friendly name of the resource</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The type of payment method. Must be a pre-existing value
        /// </summary>
        /// <value>The type of payment method. Must be a pre-existing value</value>
        [JsonProperty(PropertyName = "payment_method_type")]
        public PaymentMethodTypeResource PaymentMethodType;

        /// <summary>
        /// The generic payment type. Default is card
        /// </summary>
        /// <value>The generic payment type. Default is card</value>
        [JsonProperty(PropertyName = "payment_type")]
        public string PaymentType;

        /// <summary>
        /// The sort value for the payment method
        /// </summary>
        /// <value>The sort value for the payment method</value>
        [JsonProperty(PropertyName = "sort")]
        public int? Sort;

        /// <summary>
        /// The unique token for the payment method
        /// </summary>
        /// <value>The unique token for the payment method</value>
        [JsonProperty(PropertyName = "token")]
        public string Token;

        /// <summary>
        /// An optional unique identifier
        /// </summary>
        /// <value>An optional unique identifier</value>
        [JsonProperty(PropertyName = "unique_key")]
        public string UniqueKey;

        /// <summary>
        /// The date/time this resource was last updated in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was last updated in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <summary>
        /// The user's id. If null, indicates a shared payment method that any user can use (i.e., 'wallet')
        /// </summary>
        /// <value>The user's id. If null, indicates a shared payment method that any user can use (i.e., 'wallet')</value>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId;

        /// <summary>
        /// Gets or Sets Verified
        /// </summary>
        [JsonProperty(PropertyName = "verified")]
        public bool? Verified;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PaymentMethodResource {\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  _Default: ").Append(_Default).Append("\n");
            sb.Append("  Disabled: ").Append(Disabled).Append("\n");
            sb.Append("  ExpirationDate: ").Append(ExpirationDate).Append("\n");
            sb.Append("  ExpirationMonth: ").Append(ExpirationMonth).Append("\n");
            sb.Append("  ExpirationYear: ").Append(ExpirationYear).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Last4: ").Append(Last4).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PaymentMethodType: ").Append(PaymentMethodType).Append("\n");
            sb.Append("  PaymentType: ").Append(PaymentType).Append("\n");
            sb.Append("  Sort: ").Append(Sort).Append("\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
            sb.Append("  UniqueKey: ").Append(UniqueKey).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  Verified: ").Append(Verified).Append("\n");
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
