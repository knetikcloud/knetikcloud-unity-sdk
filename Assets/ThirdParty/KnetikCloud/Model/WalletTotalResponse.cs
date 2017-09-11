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
    public class WalletTotalResponse
    {
        /// <summary>
        /// The currency code
        /// </summary>
        /// <value>The currency code</value>
        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The sum of all wallets in the system for this currency
        /// </summary>
        /// <value>The sum of all wallets in the system for this currency</value>
        [JsonProperty(PropertyName = "total")]
        public decimal? Total { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WalletTotalResponse {\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
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
