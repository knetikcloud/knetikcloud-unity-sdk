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
    [KnetikFactory ("item")]
    public class StoreItem : Item
    {
        /// <summary>
        /// Whether or not the item is currently visible to users. Does not block purchase; Use store_start or store_end to block purchase.  Default = true
        /// </summary>
        /// <value>Whether or not the item is currently visible to users. Does not block purchase; Use store_start or store_end to block purchase.  Default = true</value>
        [JsonProperty(PropertyName = "displayable")]
        public bool? Displayable;

        /// <summary>
        /// A list of country ID to include in the blacklist/whitelist geo policy
        /// </summary>
        /// <value>A list of country ID to include in the blacklist/whitelist geo policy</value>
        [JsonProperty(PropertyName = "geo_country_list")]
        public List<string> GeoCountryList;

        /// <summary>
        /// Whether to use the geo_country_list as a black list or white list for item geographical availability
        /// </summary>
        /// <value>Whether to use the geo_country_list as a black list or white list for item geographical availability</value>
        [JsonProperty(PropertyName = "geo_policy_type")]
        public string GeoPolicyType;

        /// <summary>
        /// Provides the abstract shipping needs if this item is physical and can be shipped.  A value of zero means no shipping needed.  Default = 0
        /// </summary>
        /// <value>Provides the abstract shipping needs if this item is physical and can be shipped.  A value of zero means no shipping needed.  Default = 0</value>
        [JsonProperty(PropertyName = "shipping_tier")]
        public int? ShippingTier;

        /// <summary>
        /// The skus for the item. Each defines a unique configuration for the item to be purchased (Large-Blue, Small-Green, etc). These are what is ultimately selected in the store and added to the cart
        /// </summary>
        /// <value>The skus for the item. Each defines a unique configuration for the item to be purchased (Large-Blue, Small-Green, etc). These are what is ultimately selected in the store and added to the cart</value>
        [JsonProperty(PropertyName = "skus")]
        public List<Sku> Skus;

        /// <summary>
        /// The date the item will become hidden and unavailable for purchase, unix timestamp in seconds.  If set to null, item will never leave the store
        /// </summary>
        /// <value>The date the item will become hidden and unavailable for purchase, unix timestamp in seconds.  If set to null, item will never leave the store</value>
        [JsonProperty(PropertyName = "store_end")]
        public long? StoreEnd;

        /// <summary>
        /// The date the item will become visible (if displayable) and available for purchase, unix timestamp in seconds.  If set to null, item will appear in store immediately
        /// </summary>
        /// <value>The date the item will become visible (if displayable) and available for purchase, unix timestamp in seconds.  If set to null, item will appear in store immediately</value>
        [JsonProperty(PropertyName = "store_start")]
        public long? StoreStart;

        /// <summary>
        /// The vendor who provides the item
        /// </summary>
        /// <value>The vendor who provides the item</value>
        [JsonProperty(PropertyName = "vendor_id")]
        public int? VendorId;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class StoreItem {\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  Behaviors: ").Append(Behaviors).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LongDescription: ").Append(LongDescription).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ShortDescription: ").Append(ShortDescription).Append("\n");
            sb.Append("  Sort: ").Append(Sort).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
            sb.Append("  TypeHint: ").Append(TypeHint).Append("\n");
            sb.Append("  UniqueKey: ").Append(UniqueKey).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  Displayable: ").Append(Displayable).Append("\n");
            sb.Append("  GeoCountryList: ").Append(GeoCountryList).Append("\n");
            sb.Append("  GeoPolicyType: ").Append(GeoPolicyType).Append("\n");
            sb.Append("  ShippingTier: ").Append(ShippingTier).Append("\n");
            sb.Append("  Skus: ").Append(Skus).Append("\n");
            sb.Append("  StoreEnd: ").Append(StoreEnd).Append("\n");
            sb.Append("  StoreStart: ").Append(StoreStart).Append("\n");
            sb.Append("  VendorId: ").Append(VendorId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
