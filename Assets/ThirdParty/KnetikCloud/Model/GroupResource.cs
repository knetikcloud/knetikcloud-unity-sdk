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
    
    
    public class GroupResource
    {
        /// <summary>
        /// A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type
        /// </summary>
        /// <value>A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties;

        /// <summary>
        /// A description of the group
        /// </summary>
        /// <value>A description of the group</value>
        [JsonProperty(PropertyName = "description")]
        public string Description;

        /// <summary>
        /// The number of users in the group
        /// </summary>
        /// <value>The number of users in the group</value>
        [JsonProperty(PropertyName = "member_count")]
        public int? MemberCount;

        /// <summary>
        /// A message of the day for members of the group
        /// </summary>
        /// <value>A message of the day for members of the group</value>
        [JsonProperty(PropertyName = "message_of_the_day")]
        public string MessageOfTheDay;

        /// <summary>
        /// The name of the group. Max 50 characters
        /// </summary>
        /// <value>The name of the group. Max 50 characters</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The unique name of another group that this group is a subset of
        /// </summary>
        /// <value>The unique name of another group that this group is a subset of</value>
        [JsonProperty(PropertyName = "parent")]
        public string Parent;

        /// <summary>
        /// The status which describes whether other users can freely join the group or not
        /// </summary>
        /// <value>The status which describes whether other users can freely join the group or not</value>
        [JsonProperty(PropertyName = "status")]
        public string Status;

        /// <summary>
        /// The number of users in child groups
        /// </summary>
        /// <value>The number of users in child groups</value>
        [JsonProperty(PropertyName = "sub_member_count")]
        public int? SubMemberCount;

        /// <summary>
        /// Tags for search
        /// </summary>
        /// <value>Tags for search</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags;

        /// <summary>
        /// A group template this group is validated against. May be null and no validation of additional_properties will be done
        /// </summary>
        /// <value>A group template this group is validated against. May be null and no validation of additional_properties will be done</value>
        [JsonProperty(PropertyName = "template")]
        public string Template;

        /// <summary>
        /// Unique name used in url and references. Uppercase, lowercase, numbers and hyphens only. Max 50 characters. Cannot be altered once created. Default: random UUID
        /// </summary>
        /// <value>Unique name used in url and references. Uppercase, lowercase, numbers and hyphens only. Max 50 characters. Cannot be altered once created. Default: random UUID</value>
        [JsonProperty(PropertyName = "unique_name")]
        public string UniqueName;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GroupResource {\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  MemberCount: ").Append(MemberCount).Append("\n");
            sb.Append("  MessageOfTheDay: ").Append(MessageOfTheDay).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Parent: ").Append(Parent).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  SubMemberCount: ").Append(SubMemberCount).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
            sb.Append("  UniqueName: ").Append(UniqueName).Append("\n");
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
