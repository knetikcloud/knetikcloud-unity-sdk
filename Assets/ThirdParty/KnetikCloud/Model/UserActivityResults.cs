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
    
    
    public class UserActivityResults
    {
        /// <summary>
        /// Any currency rewarded to this user
        /// </summary>
        /// <value>Any currency rewarded to this user</value>
        [JsonProperty(PropertyName = "currency_rewards")]
        public List<RewardCurrencyResource> CurrencyRewards;

        /// <summary>
        /// Any items rewarded to this user
        /// </summary>
        /// <value>Any items rewarded to this user</value>
        [JsonProperty(PropertyName = "item_rewards")]
        public List<RewardItemResource> ItemRewards;

        /// <summary>
        /// The position of the user in the leaderboard. Null means non-compete or disqualification
        /// </summary>
        /// <value>The position of the user in the leaderboard. Null means non-compete or disqualification</value>
        [JsonProperty(PropertyName = "rank")]
        public long? Rank;

        /// <summary>
        /// The raw score in this leaderboard. Null means non-compete or disqualification
        /// </summary>
        /// <value>The raw score in this leaderboard. Null means non-compete or disqualification</value>
        [JsonProperty(PropertyName = "score")]
        public long? Score;

        /// <summary>
        /// Any tags for the metric. Each unique tag will translate into a unique leaderboard. Maximum 5 tags and 50 characters each
        /// </summary>
        /// <value>Any tags for the metric. Each unique tag will translate into a unique leaderboard. Maximum 5 tags and 50 characters each</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags;

        /// <summary>
        /// The number of users tied at this rank, including this user. 1 means no tie
        /// </summary>
        /// <value>The number of users tied at this rank, including this user. 1 means no tie</value>
        [JsonProperty(PropertyName = "ties")]
        public int? Ties;

        /// <summary>
        /// The date this score was recorded or updated. Unix timestamp in seconds
        /// </summary>
        /// <value>The date this score was recorded or updated. Unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <summary>
        /// The player for this entry
        /// </summary>
        /// <value>The player for this entry</value>
        [JsonProperty(PropertyName = "user")]
        public SimpleUserResource User;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserActivityResults {\n");
            sb.Append("  CurrencyRewards: ").Append(CurrencyRewards).Append("\n");
            sb.Append("  ItemRewards: ").Append(ItemRewards).Append("\n");
            sb.Append("  Rank: ").Append(Rank).Append("\n");
            sb.Append("  Score: ").Append(Score).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Ties: ").Append(Ties).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
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
