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
    
    
    public class ReactivateSubscriptionRequest
    {
        /// <summary>
        /// The inventory to reactivate. Only required if using the deprecated subscriptions service
        /// </summary>
        /// <value>The inventory to reactivate. Only required if using the deprecated subscriptions service</value>
        [JsonProperty(PropertyName = "inventory_id")]
        public int? InventoryId;

        /// <summary>
        /// Whether to add the additional reactivation fee in addition to the recurring fee
        /// </summary>
        /// <value>Whether to add the additional reactivation fee in addition to the recurring fee</value>
        [JsonProperty(PropertyName = "reactivation_fee")]
        public bool? ReactivationFee;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ReactivateSubscriptionRequest {\n");
            sb.Append("  InventoryId: ").Append(InventoryId).Append("\n");
            sb.Append("  ReactivationFee: ").Append(ReactivationFee).Append("\n");
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
