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
    
    
    public class RewardSetResource
    {
        /// <summary>
        /// The date/time this resource was created in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The currency to give as rewards
        /// </summary>
        /// <value>The currency to give as rewards</value>
        [JsonProperty(PropertyName = "currency_rewards")]
        public List<RewardCurrencyResource> CurrencyRewards;

        /// <summary>
        /// The assigned unique ID for this reward set
        /// </summary>
        /// <value>The assigned unique ID for this reward set</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id;

        /// <summary>
        /// The items to give as rewards
        /// </summary>
        /// <value>The items to give as rewards</value>
        [JsonProperty(PropertyName = "item_rewards")]
        public List<RewardItemResource> ItemRewards;

        /// <summary>
        /// A longer describe the reward set, usually included in details
        /// </summary>
        /// <value>A longer describe the reward set, usually included in details</value>
        [JsonProperty(PropertyName = "long_description")]
        public string LongDescription;

        /// <summary>
        /// The maximum placing that will receive a reward
        /// </summary>
        /// <value>The maximum placing that will receive a reward</value>
        [JsonProperty(PropertyName = "max_placing")]
        public int? MaxPlacing;

        /// <summary>
        /// The user friendly name for this reward set
        /// </summary>
        /// <value>The user friendly name for this reward set</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// A short paragraph to describe the reward set, usually included in listings.  Max 255 characters
        /// </summary>
        /// <value>A short paragraph to describe the reward set, usually included in listings.  Max 255 characters</value>
        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription;

        /// <summary>
        /// A provided unique key for this reward set
        /// </summary>
        /// <value>A provided unique key for this reward set</value>
        [JsonProperty(PropertyName = "unique_key")]
        public string UniqueKey;

        /// <summary>
        /// The date/time this resource was last updated in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was last updated in seconds since unix epoch</value>
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
            sb.Append("class RewardSetResource {\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  CurrencyRewards: ").Append(CurrencyRewards).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ItemRewards: ").Append(ItemRewards).Append("\n");
            sb.Append("  LongDescription: ").Append(LongDescription).Append("\n");
            sb.Append("  MaxPlacing: ").Append(MaxPlacing).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ShortDescription: ").Append(ShortDescription).Append("\n");
            sb.Append("  UniqueKey: ").Append(UniqueKey).Append("\n");
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
