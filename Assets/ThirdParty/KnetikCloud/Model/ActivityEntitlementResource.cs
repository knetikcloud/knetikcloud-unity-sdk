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
    public class ActivityEntitlementResource
    {
        /// <summary>
        /// The ISO3 currency code the price is in, if available
        /// </summary>
        /// <value>The ISO3 currency code the price is in, if available</value>
        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode;

        /// <summary>
        /// The id of the entitlement item
        /// </summary>
        /// <value>The id of the entitlement item</value>
        [JsonProperty(PropertyName = "item_id")]
        public int? ItemId;

        /// <summary>
        /// The name of the entitlement item
        /// </summary>
        /// <value>The name of the entitlement item</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The price of the sku, if available
        /// </summary>
        /// <value>The price of the sku, if available</value>
        [JsonProperty(PropertyName = "price")]
        public decimal? Price;

        /// <summary>
        /// The sku id, if available. If multiple are available, then first one is returned
        /// </summary>
        /// <value>The sku id, if available. If multiple are available, then first one is returned</value>
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
            sb.Append("class ActivityEntitlementResource {\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
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
