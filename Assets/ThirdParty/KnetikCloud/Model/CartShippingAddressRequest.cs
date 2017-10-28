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
    public class CartShippingAddressRequest
    {
        /// <summary>
        /// The city of the user
        /// </summary>
        /// <value>The city of the user</value>
        [JsonProperty(PropertyName = "city")]
        public string City;

        /// <summary>
        /// The country code of the user
        /// </summary>
        /// <value>The country code of the user</value>
        [JsonProperty(PropertyName = "country_code_iso3")]
        public string CountryCodeIso3;

        /// <summary>
        /// The email of the user
        /// </summary>
        /// <value>The email of the user</value>
        [JsonProperty(PropertyName = "email")]
        public string Email;

        /// <summary>
        /// The first name of the user
        /// </summary>
        /// <value>The first name of the user</value>
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName;

        /// <summary>
        /// The last name of the user
        /// </summary>
        /// <value>The last name of the user</value>
        [JsonProperty(PropertyName = "last_name")]
        public string LastName;

        /// <summary>
        /// Gets or Sets NamePrefix
        /// </summary>
        [JsonProperty(PropertyName = "name_prefix")]
        public string NamePrefix;

        /// <summary>
        /// The order notes the user
        /// </summary>
        /// <value>The order notes the user</value>
        [JsonProperty(PropertyName = "order_notes")]
        public string OrderNotes;

        /// <summary>
        /// The phone number of the user
        /// </summary>
        /// <value>The phone number of the user</value>
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber;

        /// <summary>
        /// The postal state code of the user
        /// </summary>
        /// <value>The postal state code of the user</value>
        [JsonProperty(PropertyName = "postal_state_code")]
        public string PostalStateCode;

        /// <summary>
        /// The shipping address of the user, first line
        /// </summary>
        /// <value>The shipping address of the user, first line</value>
        [JsonProperty(PropertyName = "shipping_address_line1")]
        public string ShippingAddressLine1;

        /// <summary>
        /// The shipping address of the user, second line
        /// </summary>
        /// <value>The shipping address of the user, second line</value>
        [JsonProperty(PropertyName = "shipping_address_line2")]
        public string ShippingAddressLine2;

        /// <summary>
        /// The zipcode of the user
        /// </summary>
        /// <value>The zipcode of the user</value>
        [JsonProperty(PropertyName = "zip")]
        public string Zip;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CartShippingAddressRequest {\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  CountryCodeIso3: ").Append(CountryCodeIso3).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  NamePrefix: ").Append(NamePrefix).Append("\n");
            sb.Append("  OrderNotes: ").Append(OrderNotes).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  PostalStateCode: ").Append(PostalStateCode).Append("\n");
            sb.Append("  ShippingAddressLine1: ").Append(ShippingAddressLine1).Append("\n");
            sb.Append("  ShippingAddressLine2: ").Append(ShippingAddressLine2).Append("\n");
            sb.Append("  Zip: ").Append(Zip).Append("\n");
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
