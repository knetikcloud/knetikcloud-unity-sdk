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
    
    
    public class UserRelationshipResource
    {
        /// <summary>
        /// The child in the relationship
        /// </summary>
        /// <value>The child in the relationship</value>
        [JsonProperty(PropertyName = "child")]
        public SimpleUserResource Child;

        /// <summary>
        /// Context about the relationship or its type
        /// </summary>
        /// <value>Context about the relationship or its type</value>
        [JsonProperty(PropertyName = "context")]
        public string Context;

        /// <summary>
        /// A generated unique id. Read-Only
        /// </summary>
        /// <value>A generated unique id. Read-Only</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

        /// <summary>
        /// The parent in the relationship
        /// </summary>
        /// <value>The parent in the relationship</value>
        [JsonProperty(PropertyName = "parent")]
        public SimpleUserResource Parent;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserRelationshipResource {\n");
            sb.Append("  Child: ").Append(Child).Append("\n");
            sb.Append("  Context: ").Append(Context).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Parent: ").Append(Parent).Append("\n");
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
