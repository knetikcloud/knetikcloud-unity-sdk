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
    
    
    public class RewardItemResource
    {
        /// <summary>
        /// The id of the item to reward
        /// </summary>
        /// <value>The id of the item to reward</value>
        [JsonProperty(PropertyName = "item_id")]
        public int? ItemId;

        /// <summary>
        /// The name of the item to reward (read only, set by id)
        /// </summary>
        /// <value>The name of the item to reward (read only, set by id)</value>
        [JsonProperty(PropertyName = "item_name")]
        public string ItemName;

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
        /// How many copies to give
        /// </summary>
        /// <value>How many copies to give</value>
        [JsonProperty(PropertyName = "quantity")]
        public int? Quantity;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class RewardItemResource {\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
            sb.Append("  ItemName: ").Append(ItemName).Append("\n");
            sb.Append("  MaxRank: ").Append(MaxRank).Append("\n");
            sb.Append("  MinRank: ").Append(MinRank).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
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
