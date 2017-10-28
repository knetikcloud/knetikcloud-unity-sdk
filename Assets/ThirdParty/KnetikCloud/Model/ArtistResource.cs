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
    public class ArtistResource
    {
        /// <summary>
        /// A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type
        /// </summary>
        /// <value>A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties;

        /// <summary>
        /// YYYY/MM/DD when this artist was born
        /// </summary>
        /// <value>YYYY/MM/DD when this artist was born</value>
        [JsonProperty(PropertyName = "born")]
        public string Born;

        /// <summary>
        /// The current number of contributions the artist has made
        /// </summary>
        /// <value>The current number of contributions the artist has made</value>
        [JsonProperty(PropertyName = "contribution_count")]
        public int? ContributionCount;

        /// <summary>
        /// The list of media this artist has contributed to as well as role(s) during contribution.  Use media endpoint to add contributions
        /// </summary>
        /// <value>The list of media this artist has contributed to as well as role(s) during contribution.  Use media endpoint to add contributions</value>
        [JsonProperty(PropertyName = "contributions")]
        public List<ContributionResource> Contributions;

        /// <summary>
        /// The date/time this resource was created in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// YYYY/MM/DD when this artist died
        /// </summary>
        /// <value>YYYY/MM/DD when this artist died</value>
        [JsonProperty(PropertyName = "died")]
        public string Died;

        /// <summary>
        /// The unique ID for that resource
        /// </summary>
        /// <value>The unique ID for that resource</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

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
        /// The sort order priority ofr the artist.  Default 100
        /// </summary>
        /// <value>The sort order priority ofr the artist.  Default 100</value>
        [JsonProperty(PropertyName = "priority")]
        public int? Priority;

        /// <summary>
        /// The user friendly name of that resource. Defaults to blank string
        /// </summary>
        /// <value>The user friendly name of that resource. Defaults to blank string</value>
        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription;

        /// <summary>
        /// An artist template this artist is validated against (private). May be null and no validation of additional_properties will be done
        /// </summary>
        /// <value>An artist template this artist is validated against (private). May be null and no validation of additional_properties will be done</value>
        [JsonProperty(PropertyName = "template")]
        public string Template;

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
            sb.Append("class ArtistResource {\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  Born: ").Append(Born).Append("\n");
            sb.Append("  ContributionCount: ").Append(ContributionCount).Append("\n");
            sb.Append("  Contributions: ").Append(Contributions).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Died: ").Append(Died).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LongDescription: ").Append(LongDescription).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  ShortDescription: ").Append(ShortDescription).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
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
