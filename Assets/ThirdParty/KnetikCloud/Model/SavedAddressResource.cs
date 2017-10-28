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
    public class SavedAddressResource
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
        /// Gets or Sets _Default
        /// </summary>
        [JsonProperty(PropertyName = "default")]
        public bool? _Default;

        /// <summary>
        /// The first name of the user
        /// </summary>
        /// <value>The first name of the user</value>
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName;

        /// <summary>
        /// The id of the address
        /// </summary>
        /// <value>The id of the address</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id;

        /// <summary>
        /// The last name of the user
        /// </summary>
        /// <value>The last name of the user</value>
        [JsonProperty(PropertyName = "last_name")]
        public string LastName;

        /// <summary>
        /// The name of the address
        /// </summary>
        /// <value>The name of the address</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The first phone number of the user
        /// </summary>
        /// <value>The first phone number of the user</value>
        [JsonProperty(PropertyName = "phone1")]
        public string Phone1;

        /// <summary>
        /// The second phone number of the user
        /// </summary>
        /// <value>The second phone number of the user</value>
        [JsonProperty(PropertyName = "phone2")]
        public string Phone2;

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
            sb.Append("class SavedAddressResource {\n");
            sb.Append("  Address1: ").Append(Address1).Append("\n");
            sb.Append("  Address2: ").Append(Address2).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  CountryCode: ").Append(CountryCode).Append("\n");
            sb.Append("  _Default: ").Append(_Default).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Phone1: ").Append(Phone1).Append("\n");
            sb.Append("  Phone2: ").Append(Phone2).Append("\n");
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
