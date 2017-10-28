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
    public class LimitedGettableGroup
    {
        /// <summary>
        /// Whether to get active items only
        /// </summary>
        /// <value>Whether to get active items only</value>
        [JsonProperty(PropertyName = "active_only")]
        public bool? ActiveOnly;

        /// <summary>
        /// The name of the group. Multiple items with the same group name will be limited together, leave null to be assigned a random unique name. It is typical that owned_limit and active_only will be the same for all, but this is not enforced and the item being recieved will use its settings.
        /// </summary>
        /// <value>The name of the group. Multiple items with the same group name will be limited together, leave null to be assigned a random unique name. It is typical that owned_limit and active_only will be the same for all, but this is not enforced and the item being recieved will use its settings.</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The max number of items that can be purchased
        /// </summary>
        /// <value>The max number of items that can be purchased</value>
        [JsonProperty(PropertyName = "owned_limit")]
        public int? OwnedLimit;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class LimitedGettableGroup {\n");
            sb.Append("  ActiveOnly: ").Append(ActiveOnly).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OwnedLimit: ").Append(OwnedLimit).Append("\n");
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
