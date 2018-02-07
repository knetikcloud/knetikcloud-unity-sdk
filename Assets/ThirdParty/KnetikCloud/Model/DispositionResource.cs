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
    
    
    public class DispositionResource
    {
        /// <summary>
        /// The context of that resource. Required when passed to /dispositions rather than context specific endpoint
        /// </summary>
        /// <value>The context of that resource. Required when passed to /dispositions rather than context specific endpoint</value>
        [JsonProperty(PropertyName = "context")]
        public string Context;

        /// <summary>
        /// The context_id of that resource. Required when passed to /dispositions rather than context specific endpoint
        /// </summary>
        /// <value>The context_id of that resource. Required when passed to /dispositions rather than context specific endpoint</value>
        [JsonProperty(PropertyName = "context_id")]
        public string ContextId;

        /// <summary>
        /// The date/time this resource was created in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The unique ID for that resource
        /// </summary>
        /// <value>The unique ID for that resource</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

        /// <summary>
        /// The name of the disposition, 1-20 characters. (ex: like/dislike/favorite, etc)
        /// </summary>
        /// <value>The name of the disposition, 1-20 characters. (ex: like/dislike/favorite, etc)</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The user
        /// </summary>
        /// <value>The user</value>
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
            sb.Append("class DispositionResource {\n");
            sb.Append("  Context: ").Append(Context).Append("\n");
            sb.Append("  ContextId: ").Append(ContextId).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
