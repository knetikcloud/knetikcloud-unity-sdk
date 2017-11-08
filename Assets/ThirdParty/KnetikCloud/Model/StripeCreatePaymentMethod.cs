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
    
    
    public class StripeCreatePaymentMethod
    {
        /// <summary>
        /// Additional optional details to store on the payment method. If included, all fields in the details will override any defaults
        /// </summary>
        /// <value>Additional optional details to store on the payment method. If included, all fields in the details will override any defaults</value>
        [JsonProperty(PropertyName = "details")]
        public PaymentMethodDetails Details;

        /// <summary>
        /// A token from Stripe to identify payment info to be tied to the customer
        /// </summary>
        /// <value>A token from Stripe to identify payment info to be tied to the customer</value>
        [JsonProperty(PropertyName = "token")]
        public string Token;

        /// <summary>
        /// The id of the user, if null the logged in user is used. Admin privilege need to specify other users
        /// </summary>
        /// <value>The id of the user, if null the logged in user is used. Admin privilege need to specify other users</value>
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
            sb.Append("class StripeCreatePaymentMethod {\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
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
