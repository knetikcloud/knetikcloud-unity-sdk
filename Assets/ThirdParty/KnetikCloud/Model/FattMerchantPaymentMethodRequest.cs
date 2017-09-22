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
    public class FattMerchantPaymentMethodRequest
    {
        /// <summary>
        /// The FattMerchant payment method being created/updated
        /// </summary>
        /// <value>The FattMerchant payment method being created/updated</value>
        [JsonProperty(PropertyName = "method")]
        public FattMerchantPaymentMethod Method { get; set; }

        /// <summary>
        /// ID of the JSAPI user for whom the payment method is being created/updated. If ID is not that of the currently logged in user, FATMMERCHANT_ADMIN privilege is required. If ID is null, will use the currently logged in user's ID.
        /// </summary>
        /// <value>ID of the JSAPI user for whom the payment method is being created/updated. If ID is not that of the currently logged in user, FATMMERCHANT_ADMIN privilege is required. If ID is null, will use the currently logged in user's ID.</value>
        [JsonProperty(PropertyName = "user_id")]
        public int? UserId { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FattMerchantPaymentMethodRequest {\n");
            sb.Append("  Method: ").Append(Method).Append("\n");
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
