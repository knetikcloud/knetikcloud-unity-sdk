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
    
    
    public class UserResource
    {
        /// <summary>
        /// A map of additional properties, keyed on the property name (private). Must match the names and types defined in the template for this user type, or be an extra not from the template
        /// </summary>
        /// <value>A map of additional properties, keyed on the property name (private). Must match the names and types defined in the template for this user type, or be an extra not from the template</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties;

        /// <summary>
        /// The first line of the user's address (private)
        /// </summary>
        /// <value>The first line of the user's address (private)</value>
        [JsonProperty(PropertyName = "address")]
        public string Address;

        /// <summary>
        /// The second line of user's address (private)
        /// </summary>
        /// <value>The second line of user's address (private)</value>
        [JsonProperty(PropertyName = "address2")]
        public string Address2;

        /// <summary>
        /// The url of the user's avatar image
        /// </summary>
        /// <value>The url of the user's avatar image</value>
        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl;

        /// <summary>
        /// Relationships where this user is the parent. Read-Only, manage through separate endpoints
        /// </summary>
        /// <value>Relationships where this user is the parent. Read-Only, manage through separate endpoints</value>
        [JsonProperty(PropertyName = "children")]
        public List<UserRelationshipReferenceResource> Children;

        /// <summary>
        /// The user's city (private)
        /// </summary>
        /// <value>The user's city (private)</value>
        [JsonProperty(PropertyName = "city")]
        public string City;

        /// <summary>
        /// The ISO3 code for the country from the user's address (private). Will be filled in based on GeoIP country at registration if not provided.
        /// </summary>
        /// <value>The ISO3 code for the country from the user's address (private). Will be filled in based on GeoIP country at registration if not provided.</value>
        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode;

        /// <summary>
        /// The code for the user's real money currency (private)
        /// </summary>
        /// <value>The code for the user's real money currency (private)</value>
        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode;

        /// <summary>
        /// The user's date of birth (private) as a unix timestamp
        /// </summary>
        /// <value>The user's date of birth (private) as a unix timestamp</value>
        [JsonProperty(PropertyName = "date_of_birth")]
        public long? DateOfBirth;

        /// <summary>
        /// The user's self description (private)
        /// </summary>
        /// <value>The user's self description (private)</value>
        [JsonProperty(PropertyName = "description")]
        public string Description;

        /// <summary>
        /// The chosen display name of the user, defaults to username if not present
        /// </summary>
        /// <value>The chosen display name of the user, defaults to username if not present</value>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName;

        /// <summary>
        /// The user's email address (private). May be required and/or unique depending on system configuration (both on by default). Must match standard email requirements if provided (RFC 2822)
        /// </summary>
        /// <value>The user's email address (private). May be required and/or unique depending on system configuration (both on by default). Must match standard email requirements if provided (RFC 2822)</value>
        [JsonProperty(PropertyName = "email")]
        public string Email;

        /// <summary>
        /// The user's first name (private)
        /// </summary>
        /// <value>The user's first name (private)</value>
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName;

        /// <summary>
        /// The user's full name (private)
        /// </summary>
        /// <value>The user's full name (private)</value>
        [JsonProperty(PropertyName = "fullname")]
        public string Fullname;

        /// <summary>
        /// The user's gender (private)
        /// </summary>
        /// <value>The user's gender (private)</value>
        [JsonProperty(PropertyName = "gender")]
        public string Gender;

        /// <summary>
        /// The id of the user
        /// </summary>
        /// <value>The id of the user</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id;

        /// <summary>
        /// The ISO3 code for the user's currency (private)
        /// </summary>
        /// <value>The ISO3 code for the user's currency (private)</value>
        [JsonProperty(PropertyName = "language_code")]
        public string LanguageCode;

        /// <summary>
        /// The date the user last interacted with the API (private)
        /// </summary>
        /// <value>The date the user last interacted with the API (private)</value>
        [JsonProperty(PropertyName = "last_activity")]
        public long? LastActivity;

        /// <summary>
        /// The user's last name (private)
        /// </summary>
        /// <value>The user's last name (private)</value>
        [JsonProperty(PropertyName = "last_name")]
        public string LastName;

        /// <summary>
        /// The date the user's info was last updated as a unix timestamp
        /// </summary>
        /// <value>The date the user's info was last updated as a unix timestamp</value>
        [JsonProperty(PropertyName = "last_updated")]
        public long? LastUpdated;

        /// <summary>
        /// The user's date of registration as a unix timestamp
        /// </summary>
        /// <value>The user's date of registration as a unix timestamp</value>
        [JsonProperty(PropertyName = "member_since")]
        public long? MemberSince;

        /// <summary>
        /// The user's mobile phone number (private)
        /// </summary>
        /// <value>The user's mobile phone number (private)</value>
        [JsonProperty(PropertyName = "mobile_number")]
        public string MobileNumber;

        /// <summary>
        /// Relationships where this user is the child. Read-Only, manage through separate endpoints
        /// </summary>
        /// <value>Relationships where this user is the child. Read-Only, manage through separate endpoints</value>
        [JsonProperty(PropertyName = "parents")]
        public List<UserRelationshipReferenceResource> Parents;

        /// <summary>
        /// The plain text password for the new user account. Required for registration; ignored on profile update.  Use password specific endpoints for editing
        /// </summary>
        /// <value>The plain text password for the new user account. Required for registration; ignored on profile update.  Use password specific endpoints for editing</value>
        [JsonProperty(PropertyName = "password")]
        public string Password;

        /// <summary>
        /// The user's postal code (private)
        /// </summary>
        /// <value>The user's postal code (private)</value>
        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode;

        /// <summary>
        /// The user's state (private)
        /// </summary>
        /// <value>The user's state (private)</value>
        [JsonProperty(PropertyName = "state")]
        public string State;

        /// <summary>
        /// Tags on the user. Can only be set by admin. Max length per tag is 64 characters
        /// </summary>
        /// <value>Tags on the user. Can only be set by admin. Max length per tag is 64 characters</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags;

        /// <summary>
        /// A user template this user is validated against (private). May be null and no validation of properties will be done
        /// </summary>
        /// <value>A user template this user is validated against (private). May be null and no validation of properties will be done</value>
        [JsonProperty(PropertyName = "template")]
        public string Template;

        /// <summary>
        /// The code for the user's timezone (private)
        /// </summary>
        /// <value>The code for the user's timezone (private)</value>
        [JsonProperty(PropertyName = "timezone_code")]
        public string TimezoneCode;

        /// <summary>
        /// The login username for the user (private). May be set to match email if system does not require usernames separately.
        /// </summary>
        /// <value>The login username for the user (private). May be set to match email if system does not require usernames separately.</value>
        [JsonProperty(PropertyName = "username")]
        public string Username;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserResource {\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Address2: ").Append(Address2).Append("\n");
            sb.Append("  AvatarUrl: ").Append(AvatarUrl).Append("\n");
            sb.Append("  Children: ").Append(Children).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  CountryCode: ").Append(CountryCode).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  DateOfBirth: ").Append(DateOfBirth).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  Fullname: ").Append(Fullname).Append("\n");
            sb.Append("  Gender: ").Append(Gender).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LanguageCode: ").Append(LanguageCode).Append("\n");
            sb.Append("  LastActivity: ").Append(LastActivity).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  LastUpdated: ").Append(LastUpdated).Append("\n");
            sb.Append("  MemberSince: ").Append(MemberSince).Append("\n");
            sb.Append("  MobileNumber: ").Append(MobileNumber).Append("\n");
            sb.Append("  Parents: ").Append(Parents).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
            sb.Append("  TimezoneCode: ").Append(TimezoneCode).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
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
