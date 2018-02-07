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
    
    
    public class CartShippableResponse
    {
        /// <summary>
        /// The id of the cart
        /// </summary>
        /// <value>The id of the cart</value>
        [JsonProperty(PropertyName = "cart_id")]
        public int? CartId;

        /// <summary>
        /// Whether the item is shippable
        /// </summary>
        /// <value>Whether the item is shippable</value>
        [JsonProperty(PropertyName = "shippable")]
        public bool? Shippable;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CartShippableResponse {\n");
            sb.Append("  CartId: ").Append(CartId).Append("\n");
            sb.Append("  Shippable: ").Append(Shippable).Append("\n");
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
