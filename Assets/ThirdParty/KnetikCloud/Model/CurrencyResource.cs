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
    
    
    public class CurrencyResource
    {
        /// <summary>
        /// Whether the currency is active. Default true
        /// </summary>
        /// <value>Whether the currency is active. Default true</value>
        [JsonProperty(PropertyName = "active")]
        public bool? Active;

        /// <summary>
        /// The unique id code for the currency. Maximum 5 characters
        /// </summary>
        /// <value>The unique id code for the currency. Maximum 5 characters</value>
        [JsonProperty(PropertyName = "code")]
        public string Code;

        /// <summary>
        /// The unix timestamp in seconds the currency was added to the system
        /// </summary>
        /// <value>The unix timestamp in seconds the currency was added to the system</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// Whether this is the default currency. All real money wallets will be in this currency, and the 'factor' on each currency is in relation to the default. There must be one default currency and the current will be changed if you set another as the default. Cannot be combined with virtual currency. Take extreme caution when changing
        /// </summary>
        /// <value>Whether this is the default currency. All real money wallets will be in this currency, and the 'factor' on each currency is in relation to the default. There must be one default currency and the current will be changed if you set another as the default. Cannot be combined with virtual currency. Take extreme caution when changing</value>
        [JsonProperty(PropertyName = "default_currency")]
        public bool? DefaultCurrency;

        /// <summary>
        /// The decimal to multiply the default currency to localize to this one. Should be 1 for the default currency itself.
        /// </summary>
        /// <value>The decimal to multiply the default currency to localize to this one. Should be 1 for the default currency itself.</value>
        [JsonProperty(PropertyName = "factor")]
        public decimal? Factor;

        /// <summary>
        /// The url for an icon of the currency
        /// </summary>
        /// <value>The url for an icon of the currency</value>
        [JsonProperty(PropertyName = "icon")]
        public string Icon;

        /// <summary>
        /// The name of the currency
        /// </summary>
        /// <value>The name of the currency</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The type of currency. Default 'real'
        /// </summary>
        /// <value>The type of currency. Default 'real'</value>
        [JsonProperty(PropertyName = "type")]
        public string Type;

        /// <summary>
        /// The unix timestamp in seconds the currency was last updated in the system.
        /// </summary>
        /// <value>The unix timestamp in seconds the currency was last updated in the system.</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CurrencyResource {\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  DefaultCurrency: ").Append(DefaultCurrency).Append("\n");
            sb.Append("  Factor: ").Append(Factor).Append("\n");
            sb.Append("  Icon: ").Append(Icon).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
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
