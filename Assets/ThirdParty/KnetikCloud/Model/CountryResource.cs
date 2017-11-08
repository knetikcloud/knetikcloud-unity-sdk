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
    
    
    public class CountryResource
    {
        /// <summary>
        /// The iso2 of the country
        /// </summary>
        /// <value>The iso2 of the country</value>
        [JsonProperty(PropertyName = "iso2")]
        public string Iso2;

        /// <summary>
        /// The iso3 of the country
        /// </summary>
        /// <value>The iso3 of the country</value>
        [JsonProperty(PropertyName = "iso3")]
        public string Iso3;

        /// <summary>
        /// The name of the country resource
        /// </summary>
        /// <value>The name of the country resource</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CountryResource {\n");
            sb.Append("  Iso2: ").Append(Iso2).Append("\n");
            sb.Append("  Iso3: ").Append(Iso3).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
