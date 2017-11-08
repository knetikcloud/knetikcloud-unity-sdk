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
    
    
    public class AddressResource
    {
        /// <summary>
        /// The first line of the address
        /// </summary>
        /// <value>The first line of the address</value>
        [JsonProperty(PropertyName = "address1")]
        public string Address1;

        /// <summary>
        /// A second line of the address
        /// </summary>
        /// <value>A second line of the address</value>
        [JsonProperty(PropertyName = "address2")]
        public string Address2;

        /// <summary>
        /// The city
        /// </summary>
        /// <value>The city</value>
        [JsonProperty(PropertyName = "city")]
        public string City;

        /// <summary>
        /// The iso3 code for the country
        /// </summary>
        /// <value>The iso3 code for the country</value>
        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode;

        /// <summary>
        /// The postal code
        /// </summary>
        /// <value>The postal code</value>
        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode;

        /// <summary>
        /// The code for the state. Required if the country has states/provinces/equivalent
        /// </summary>
        /// <value>The code for the state. Required if the country has states/provinces/equivalent</value>
        [JsonProperty(PropertyName = "state_code")]
        public string StateCode;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AddressResource {\n");
            sb.Append("  Address1: ").Append(Address1).Append("\n");
            sb.Append("  Address2: ").Append(Address2).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  CountryCode: ").Append(CountryCode).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  StateCode: ").Append(StateCode).Append("\n");
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
