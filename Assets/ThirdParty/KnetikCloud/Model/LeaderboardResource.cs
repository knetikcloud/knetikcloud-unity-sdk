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
    
    
    public class LeaderboardResource
    {
        /// <summary>
        /// The paginated list of user results, in order from best to worst
        /// </summary>
        /// <value>The paginated list of user results, in order from best to worst</value>
        [JsonProperty(PropertyName = "entries")]
        public List<LeaderboardEntryResource> Entries;

        /// <summary>
        /// The id of the leaderboard
        /// </summary>
        /// <value>The id of the leaderboard</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

        /// <summary>
        /// The name of the strategy that defines how entries are stored and compared
        /// </summary>
        /// <value>The name of the strategy that defines how entries are stored and compared</value>
        [JsonProperty(PropertyName = "strategy")]
        public string Strategy;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LeaderboardResource {\n");
            sb.Append("  Entries: ").Append(Entries).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Strategy: ").Append(Strategy).Append("\n");
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
