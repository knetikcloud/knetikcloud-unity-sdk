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
    
    
    public class CommentResource
    {
        /// <summary>
        /// The comment content of that resource
        /// </summary>
        /// <value>The comment content of that resource</value>
        [JsonProperty(PropertyName = "content")]
        public string Content;

        /// <summary>
        /// The type of object this comment applies to (ex: video, article, etc). Required when passed to /comments
        /// </summary>
        /// <value>The type of object this comment applies to (ex: video, article, etc). Required when passed to /comments</value>
        [JsonProperty(PropertyName = "context")]
        public string Context;

        /// <summary>
        /// The id of the object this comment applies to.  Required when passed to /comments
        /// </summary>
        /// <value>The id of the object this comment applies to.  Required when passed to /comments</value>
        [JsonProperty(PropertyName = "context_id")]
        public int? ContextId;

        /// <summary>
        /// The date/time this resource was created in seconds since epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The unique ID for that resource
        /// </summary>
        /// <value>The unique ID for that resource</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

        /// <summary>
        /// The summary of that resource
        /// </summary>
        /// <value>The summary of that resource</value>
        [JsonProperty(PropertyName = "summary")]
        public string Summary;

        /// <summary>
        /// The date/time this resource was last updated in seconds since epoch
        /// </summary>
        /// <value>The date/time this resource was last updated in seconds since epoch</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <summary>
        /// The user who created the comment
        /// </summary>
        /// <value>The user who created the comment</value>
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
            sb.Append("class CommentResource {\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  Context: ").Append(Context).Append("\n");
            sb.Append("  ContextId: ").Append(ContextId).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Summary: ").Append(Summary).Append("\n");
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
