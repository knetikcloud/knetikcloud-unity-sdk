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
    
    
    public class ContributionResource
    {
        /// <summary>
        /// A reference to the contributing artist
        /// </summary>
        /// <value>A reference to the contributing artist</value>
        [JsonProperty(PropertyName = "artist")]
        public SimpleReferenceResourcelong Artist;

        /// <summary>
        /// A reference to the media being contributed to
        /// </summary>
        /// <value>A reference to the media being contributed to</value>
        [JsonProperty(PropertyName = "media")]
        public SimpleReferenceResourcelong Media;

        /// <summary>
        /// The nature of the contribution (role of the artist as in 'producer', 'performer', etc)
        /// </summary>
        /// <value>The nature of the contribution (role of the artist as in 'producer', 'performer', etc)</value>
        [JsonProperty(PropertyName = "role")]
        public string Role;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ContributionResource {\n");
            sb.Append("  Artist: ").Append(Artist).Append("\n");
            sb.Append("  Media: ").Append(Media).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
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
