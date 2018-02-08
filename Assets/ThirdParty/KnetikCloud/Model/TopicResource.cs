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
    
    
    public class TopicResource
    {
        /// <summary>
        /// The created date of the topic
        /// </summary>
        /// <value>The created date of the topic</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The display name of the topic
        /// </summary>
        /// <value>The display name of the topic</value>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName;

        /// <summary>
        /// The unique ID for this topic
        /// </summary>
        /// <value>The unique ID for this topic</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// Whether this topic is locked or not.
        /// </summary>
        /// <value>Whether this topic is locked or not.</value>
        [JsonProperty(PropertyName = "locked")]
        public bool? Locked;

        /// <summary>
        /// Random tags to facilitate search
        /// </summary>
        /// <value>Random tags to facilitate search</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags;

        /// <summary>
        /// The last time the topic was updated
        /// </summary>
        /// <value>The last time the topic was updated</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <summary>
        /// The subscribed user count of the topic
        /// </summary>
        /// <value>The subscribed user count of the topic</value>
        [JsonProperty(PropertyName = "user_count")]
        public int? UserCount;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TopicResource {\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Locked: ").Append(Locked).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  UserCount: ").Append(UserCount).Append("\n");
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
