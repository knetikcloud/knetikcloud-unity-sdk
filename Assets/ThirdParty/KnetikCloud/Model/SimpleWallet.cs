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
    
    
    public class SimpleWallet
    {
        /// <summary>
        /// The current balance of the wallet
        /// </summary>
        /// <value>The current balance of the wallet</value>
        [JsonProperty(PropertyName = "balance")]
        public decimal? Balance;

        /// <summary>
        /// The ISO currency code for the wallet
        /// </summary>
        /// <value>The ISO currency code for the wallet</value>
        [JsonProperty(PropertyName = "code")]
        public string Code;

        /// <summary>
        /// The name of the currency stored in the wallet
        /// </summary>
        /// <value>The name of the currency stored in the wallet</value>
        [JsonProperty(PropertyName = "currency_name")]
        public string CurrencyName;

        /// <summary>
        /// The unique ID of the wallet
        /// </summary>
        /// <value>The unique ID of the wallet</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id;

        /// <summary>
        /// The ID of the user to whom the wallet belongs
        /// </summary>
        /// <value>The ID of the user to whom the wallet belongs</value>
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
            sb.Append("class SimpleWallet {\n");
            sb.Append("  Balance: ").Append(Balance).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  CurrencyName: ").Append(CurrencyName).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
