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
    
    
    public class RewardCurrencyResource
    {
        /// <summary>
        /// The code of the currency type to give
        /// </summary>
        /// <value>The code of the currency type to give</value>
        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode;

        /// <summary>
        /// The name of the currency reward to give.  Set by currency_code)
        /// </summary>
        /// <value>The name of the currency reward to give.  Set by currency_code)</value>
        [JsonProperty(PropertyName = "currency_name")]
        public string CurrencyName;

        /// <summary>
        /// The highest number (worst) rank to give the reward to. Must be greater than or equal to minRank
        /// </summary>
        /// <value>The highest number (worst) rank to give the reward to. Must be greater than or equal to minRank</value>
        [JsonProperty(PropertyName = "max_rank")]
        public int? MaxRank;

        /// <summary>
        /// The lowest number (best) rank to give the reward to. Must be greater than zero
        /// </summary>
        /// <value>The lowest number (best) rank to give the reward to. Must be greater than zero</value>
        [JsonProperty(PropertyName = "min_rank")]
        public int? MinRank;

        /// <summary>
        /// True if the value is actually a percentage of the intake
        /// </summary>
        /// <value>True if the value is actually a percentage of the intake</value>
        [JsonProperty(PropertyName = "percent")]
        public bool? Percent;

        /// <summary>
        /// The amount of currency to give. For percentage values, 0.5 is 50%
        /// </summary>
        /// <value>The amount of currency to give. For percentage values, 0.5 is 50%</value>
        [JsonProperty(PropertyName = "value")]
        public double? Value;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RewardCurrencyResource {\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  CurrencyName: ").Append(CurrencyName).Append("\n");
            sb.Append("  MaxRank: ").Append(MaxRank).Append("\n");
            sb.Append("  MinRank: ").Append(MinRank).Append("\n");
            sb.Append("  Percent: ").Append(Percent).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
