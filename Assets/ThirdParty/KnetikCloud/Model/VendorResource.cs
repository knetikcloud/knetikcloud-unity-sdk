using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class VendorResource
    {
        /// <summary>
        /// Whether the vendor is active.  Default = true
        /// </summary>
        /// <value>Whether the vendor is active.  Default = true</value>
        [JsonProperty(PropertyName = "active")]
        public bool? Active { get; set; }

        /// <summary>
        /// A map of additional properties, keyed on the property name (private). Must match the names and types defined in the template for this user type, or be an extra not from the template
        /// </summary>
        /// <value>A map of additional properties, keyed on the property name (private). Must match the names and types defined in the template for this user type, or be an extra not from the template</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties { get; set; }

        /// <summary>
        /// The date the vendor was added. Unix timestamp in seconds
        /// </summary>
        /// <value>The date the vendor was added. Unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "create_date")]
        public long? CreateDate { get; set; }

        /// <summary>
        /// A description of the vendor
        /// </summary>
        /// <value>A description of the vendor</value>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The id of the vendor
        /// </summary>
        /// <value>The id of the vendor</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The url of an image for the vendor
        /// </summary>
        /// <value>The url of an image for the vendor</value>
        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Whether the vendor needs to manually approve invoices before they are paid.  A separate checkout flow is required in this case.  Default: false
        /// </summary>
        /// <value>Whether the vendor needs to manually approve invoices before they are paid.  A separate checkout flow is required in this case.  Default: false</value>
        [JsonProperty(PropertyName = "manual_approval")]
        public bool? ManualApproval { get; set; }

        /// <summary>
        /// The name of the vendor
        /// </summary>
        /// <value>The name of the vendor</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The primary email address for the vendor
        /// </summary>
        /// <value>The primary email address for the vendor</value>
        [JsonProperty(PropertyName = "primary_contact_email")]
        public string PrimaryContactEmail { get; set; }

        /// <summary>
        /// The name of the primary contact for the vendor
        /// </summary>
        /// <value>The name of the primary contact for the vendor</value>
        [JsonProperty(PropertyName = "primary_contact_name")]
        public string PrimaryContactName { get; set; }

        /// <summary>
        /// The primary phone number for the vendor
        /// </summary>
        /// <value>The primary phone number for the vendor</value>
        [JsonProperty(PropertyName = "primary_contact_phone")]
        public string PrimaryContactPhone { get; set; }

        /// <summary>
        /// The email address for sale inquiries for the vendor
        /// </summary>
        /// <value>The email address for sale inquiries for the vendor</value>
        [JsonProperty(PropertyName = "sales_email")]
        public string SalesEmail { get; set; }

        /// <summary>
        /// The email address for support inquiries for the vendor
        /// </summary>
        /// <value>The email address for support inquiries for the vendor</value>
        [JsonProperty(PropertyName = "support_email")]
        public string SupportEmail { get; set; }

        /// <summary>
        /// A user template this user is validated against (private). May be null and no validation of properties will be done
        /// </summary>
        /// <value>A user template this user is validated against (private). May be null and no validation of properties will be done</value>
        [JsonProperty(PropertyName = "template")]
        public string Template { get; set; }

        /// <summary>
        /// The date the vendor was last updated. Unix timestamp in seconds
        /// </summary>
        /// <value>The date the vendor was last updated. Unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "update_date")]
        public long? UpdateDate { get; set; }

        /// <summary>
        /// The url for the vendor's site
        /// </summary>
        /// <value>The url for the vendor's site</value>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class VendorResource {\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  CreateDate: ").Append(CreateDate).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ImageUrl: ").Append(ImageUrl).Append("\n");
            sb.Append("  ManualApproval: ").Append(ManualApproval).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PrimaryContactEmail: ").Append(PrimaryContactEmail).Append("\n");
            sb.Append("  PrimaryContactName: ").Append(PrimaryContactName).Append("\n");
            sb.Append("  PrimaryContactPhone: ").Append(PrimaryContactPhone).Append("\n");
            sb.Append("  SalesEmail: ").Append(SalesEmail).Append("\n");
            sb.Append("  SupportEmail: ").Append(SupportEmail).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
            sb.Append("  UpdateDate: ").Append(UpdateDate).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
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
