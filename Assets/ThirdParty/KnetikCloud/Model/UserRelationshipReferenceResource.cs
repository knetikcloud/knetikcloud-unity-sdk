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
    
    
    public class UserRelationshipReferenceResource
    {
        /// <summary>
        /// The url of the user's avatar image
        /// </summary>
        /// <value>The url of the user's avatar image</value>
        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl;

        /// <summary>
        /// The context of the relationship
        /// </summary>
        /// <value>The context of the relationship</value>
        [JsonProperty(PropertyName = "context")]
        public string Context;

        /// <summary>
        /// The public username of the user
        /// </summary>
        /// <value>The public username of the user</value>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName;

        /// <summary>
        /// The id of the user
        /// </summary>
        /// <value>The id of the user</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id;

        /// <summary>
        /// The id of the relationship
        /// </summary>
        /// <value>The id of the relationship</value>
        [JsonProperty(PropertyName = "relationship_id")]
        public long? RelationshipId;

        /// <summary>
        /// The username of the user
        /// </summary>
        /// <value>The username of the user</value>
        [JsonProperty(PropertyName = "username")]
        public string Username;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserRelationshipReferenceResource {\n");
            sb.Append("  AvatarUrl: ").Append(AvatarUrl).Append("\n");
            sb.Append("  Context: ").Append(Context).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  RelationshipId: ").Append(RelationshipId).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
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
