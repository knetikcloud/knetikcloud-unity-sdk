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
    
    
    public class RoleResource
    {
        /// <summary>
        /// The number of clients this role is assigned to
        /// </summary>
        /// <value>The number of clients this role is assigned to</value>
        [JsonProperty(PropertyName = "client_count")]
        public int? ClientCount;

        /// <summary>
        /// The date the role was added. Unix timestamp in seconds
        /// </summary>
        /// <value>The date the role was added. Unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// Whether a role is locked from being deleted
        /// </summary>
        /// <value>Whether a role is locked from being deleted</value>
        [JsonProperty(PropertyName = "locked")]
        public bool? Locked;

        /// <summary>
        /// The name of the role used for display purposes
        /// </summary>
        /// <value>The name of the role used for display purposes</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The keyword that defines the role
        /// </summary>
        /// <value>The keyword that defines the role</value>
        [JsonProperty(PropertyName = "role")]
        public string Role;

        /// <summary>
        /// The list of permissions this role has
        /// </summary>
        /// <value>The list of permissions this role has</value>
        [JsonProperty(PropertyName = "role_permission")]
        public List<PermissionResource> RolePermission;

        /// <summary>
        /// The number of users this role is assigned to
        /// </summary>
        /// <value>The number of users this role is assigned to</value>
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
            sb.Append("class RoleResource {\n");
            sb.Append("  ClientCount: ").Append(ClientCount).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Locked: ").Append(Locked).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  RolePermission: ").Append(RolePermission).Append("\n");
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
