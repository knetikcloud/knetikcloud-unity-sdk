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
    public class SubscriptionResource
    {
        /// <summary>
        /// The additional properties for the subscription
        /// </summary>
        /// <value>The additional properties for the subscription</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties { get; set; }

        /// <summary>
        /// Who can purchase this subscription
        /// </summary>
        /// <value>Who can purchase this subscription</value>
        [JsonProperty(PropertyName = "availability")]
        public string Availability { get; set; }

        /// <summary>
        /// The behaviors linked to the item, describing various options and interactions. May not be included in item lists
        /// </summary>
        /// <value>The behaviors linked to the item, describing various options and interactions. May not be included in item lists</value>
        [JsonProperty(PropertyName = "behaviors")]
        public List<Behavior> Behaviors { get; set; }

        /// <summary>
        /// The category of the subscription
        /// </summary>
        /// <value>The category of the subscription</value>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        /// <summary>
        /// The day of the month 1..31 this subscription will renew
        /// </summary>
        /// <value>The day of the month 1..31 this subscription will renew</value>
        [JsonProperty(PropertyName = "consolidation_day_of_month")]
        public int? ConsolidationDayOfMonth { get; set; }

        /// <summary>
        /// The date the item was created, unix timestamp in seconds
        /// </summary>
        /// <value>The date the item was created, unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate { get; set; }

        /// <summary>
        /// The geo country list for the subscription
        /// </summary>
        /// <value>The geo country list for the subscription</value>
        [JsonProperty(PropertyName = "geo_country_list")]
        public List<string> GeoCountryList { get; set; }

        /// <summary>
        /// The geo policy type for the subscription
        /// </summary>
        /// <value>The geo policy type for the subscription</value>
        [JsonProperty(PropertyName = "geo_policy_type")]
        public string GeoPolicyType { get; set; }

        /// <summary>
        /// The id of the item
        /// </summary>
        /// <value>The id of the item</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// A long description of the subscription
        /// </summary>
        /// <value>A long description of the subscription</value>
        [JsonProperty(PropertyName = "long_description")]
        public string LongDescription { get; set; }

        /// <summary>
        /// The name of the item
        /// </summary>
        /// <value>The name of the item</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The billing options for this subscription
        /// </summary>
        /// <value>The billing options for this subscription</value>
        [JsonProperty(PropertyName = "plans")]
        public List<SubscriptionPlanResource> Plans { get; set; }

        /// <summary>
        /// A short description of the subscription.  Max 255 characters
        /// </summary>
        /// <value>A short description of the subscription.  Max 255 characters</value>
        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// A number to use in sorting items.  Default 500
        /// </summary>
        /// <value>A number to use in sorting items.  Default 500</value>
        [JsonProperty(PropertyName = "sort")]
        public int? Sort { get; set; }

        /// <summary>
        /// Used to schedule removal from store.  Null means the subscription will never be removed
        /// </summary>
        /// <value>Used to schedule removal from store.  Null means the subscription will never be removed</value>
        [JsonProperty(PropertyName = "store_end")]
        public long? StoreEnd { get; set; }

        /// <summary>
        /// Used to schedule appearance in store.  Null means the subscription will appear now
        /// </summary>
        /// <value>Used to schedule appearance in store.  Null means the subscription will appear now</value>
        [JsonProperty(PropertyName = "store_start")]
        public long? StoreStart { get; set; }

        /// <summary>
        /// The tags for the subscription
        /// </summary>
        /// <value>The tags for the subscription</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// The template being used
        /// </summary>
        /// <value>The template being used</value>
        [JsonProperty(PropertyName = "template")]
        public string Template { get; set; }

        /// <summary>
        /// The unique key of the subscription
        /// </summary>
        /// <value>The unique key of the subscription</value>
        [JsonProperty(PropertyName = "unique_key")]
        public string UniqueKey { get; set; }

        /// <summary>
        /// The date the item was last updated
        /// </summary>
        /// <value>The date the item was last updated</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate { get; set; }

        /// <summary>
        /// The id of the vendor
        /// </summary>
        /// <value>The id of the vendor</value>
        [JsonProperty(PropertyName = "vendor_id")]
        public int? VendorId { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SubscriptionResource {\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  Availability: ").Append(Availability).Append("\n");
            sb.Append("  Behaviors: ").Append(Behaviors).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  ConsolidationDayOfMonth: ").Append(ConsolidationDayOfMonth).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  GeoCountryList: ").Append(GeoCountryList).Append("\n");
            sb.Append("  GeoPolicyType: ").Append(GeoPolicyType).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LongDescription: ").Append(LongDescription).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Plans: ").Append(Plans).Append("\n");
            sb.Append("  ShortDescription: ").Append(ShortDescription).Append("\n");
            sb.Append("  Sort: ").Append(Sort).Append("\n");
            sb.Append("  StoreEnd: ").Append(StoreEnd).Append("\n");
            sb.Append("  StoreStart: ").Append(StoreStart).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
            sb.Append("  UniqueKey: ").Append(UniqueKey).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  VendorId: ").Append(VendorId).Append("\n");
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