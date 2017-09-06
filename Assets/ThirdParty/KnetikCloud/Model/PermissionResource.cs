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
    public class PermissionResource
    {
        /// <summary>
        /// The date the permission was added. Unix timestamp in seconds
        /// </summary>
        /// <value>The date the permission was added. Unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate { get; set; }

        /// <summary>
        /// The description of the permission
        /// </summary>
        /// <value>The description of the permission</value>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Whether a permission is locked from being deleted
        /// </summary>
        /// <value>Whether a permission is locked from being deleted</value>
        [JsonProperty(PropertyName = "locked")]
        public bool? Locked { get; set; }

        /// <summary>
        /// The name of the permission used for display purposes
        /// </summary>
        /// <value>The name of the permission used for display purposes</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The name of the parent of the permission
        /// </summary>
        /// <value>The name of the parent of the permission</value>
        [JsonProperty(PropertyName = "parent")]
        public string Parent { get; set; }

        /// <summary>
        /// The keyword that defines the permission
        /// </summary>
        /// <value>The keyword that defines the permission</value>
        [JsonProperty(PropertyName = "permission")]
        public string Permission { get; set; }

        /// <summary>
        /// The date the permission was updated. Unix timestamp in seconds
        /// </summary>
        /// <value>The date the permission was updated. Unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PermissionResource {\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Locked: ").Append(Locked).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Parent: ").Append(Parent).Append("\n");
            sb.Append("  Permission: ").Append(Permission).Append("\n");
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
