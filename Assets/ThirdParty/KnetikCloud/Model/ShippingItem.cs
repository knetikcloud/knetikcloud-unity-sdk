using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    public class ShippingItem : StoreItem
    {
        /// <summary>
        /// A unique list of country iso3 codes that allow the shipping option
        /// </summary>
        /// <value>A unique list of country iso3 codes that allow the shipping option</value>
        [JsonProperty(PropertyName = "countries")]
        public List<string> Countries { get; set; }

        /// <summary>
        /// An abstract max value that the values of item's shipping_tier work against to decide whether an order can be fulfilled
        /// </summary>
        /// <value>An abstract max value that the values of item's shipping_tier work against to decide whether an order can be fulfilled</value>
        [JsonProperty(PropertyName = "max_tier_total")]
        public int? MaxTierTotal { get; set; }

        /// <summary>
        /// Whether tax should be applied to the shipping price.  Default = false
        /// </summary>
        /// <value>Whether tax should be applied to the shipping price.  Default = false</value>
        [JsonProperty(PropertyName = "taxable")]
        public bool? Taxable { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ShippingItem {\n");
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
            sb.Append("  Countries: ").Append(Countries).Append("\n");
            sb.Append("  MaxTierTotal: ").Append(MaxTierTotal).Append("\n");
            sb.Append("  Taxable: ").Append(Taxable).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public  new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
