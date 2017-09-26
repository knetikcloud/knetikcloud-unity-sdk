using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    public class QuickBuyRequest
    {
        /// <summary>
        /// SKU of item being purchased
        /// </summary>
        /// <value>SKU of item being purchased</value>
        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

        /// <summary>
        /// ID of the user making the purchase. If null, currently logged in user will be used.
        /// </summary>
        /// <value>ID of the user making the purchase. If null, currently logged in user will be used.</value>
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
            sb.Append("class QuickBuyRequest {\n");
            sb.Append("  Sku: ").Append(Sku).Append("\n");
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
