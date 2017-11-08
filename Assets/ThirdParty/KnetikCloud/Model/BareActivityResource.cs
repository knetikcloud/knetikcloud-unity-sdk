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
    
    
    public class BareActivityResource
    {
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
        /// Details about how to launch the activity
        /// </summary>
        /// <value>Details about how to launch the activity</value>
        [JsonProperty(PropertyName = "launch")]
        public string Launch;

        /// <summary>
        /// The user friendly name of that resource. Defaults to blank string
        /// </summary>
        /// <value>The user friendly name of that resource. Defaults to blank string</value>
        [JsonProperty(PropertyName = "long_description")]
        public string LongDescription;

        /// <summary>
        /// The user friendly name of that resource
        /// </summary>
        /// <value>The user friendly name of that resource</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The user friendly name of that resource. Defaults to blank string
        /// </summary>
        /// <value>The user friendly name of that resource. Defaults to blank string</value>
        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription;

        /// <summary>
        /// Whether this activity is a template for other activities. Default: false
        /// </summary>
        /// <value>Whether this activity is a template for other activities. Default: false</value>
        [JsonProperty(PropertyName = "template")]
        public bool? Template;

        /// <summary>
        /// The type of the activity
        /// </summary>
        /// <value>The type of the activity</value>
        [JsonProperty(PropertyName = "type")]
        public string Type;

        /// <summary>
        /// The unique key (for static reference in code) of the activity
        /// </summary>
        /// <value>The unique key (for static reference in code) of the activity</value>
        [JsonProperty(PropertyName = "unique_key")]
        public string UniqueKey;

        /// <summary>
        /// The date/time this resource was last updated in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was last updated in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BareActivityResource {\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Launch: ").Append(Launch).Append("\n");
            sb.Append("  LongDescription: ").Append(LongDescription).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ShortDescription: ").Append(ShortDescription).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  UniqueKey: ").Append(UniqueKey).Append("\n");
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
