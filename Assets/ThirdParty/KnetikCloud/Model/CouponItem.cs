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
    public class CouponItem : StoreItem
    {
        /// <summary>
        /// The type of coupon
        /// </summary>
        /// <value>The type of coupon</value>
        [JsonProperty(PropertyName = "coupon_type_hint")]
        public string CouponTypeHint { get; set; }

        /// <summary>
        /// The amount this coupon is maxed out at.  Applies if coupon_type_hint is coupon_cart
        /// </summary>
        /// <value>The amount this coupon is maxed out at.  Applies if coupon_type_hint is coupon_cart</value>
        [JsonProperty(PropertyName = "discount_max")]
        public decimal? DiscountMax { get; set; }

        /// <summary>
        /// The minimium amount needed in the cart for the coupon to apply.  Applies if coupon_type_hint is coupon_cart
        /// </summary>
        /// <value>The minimium amount needed in the cart for the coupon to apply.  Applies if coupon_type_hint is coupon_cart</value>
        [JsonProperty(PropertyName = "discount_min_cart_value")]
        public decimal? DiscountMinCartValue { get; set; }

        /// <summary>
        /// The type of discount in terms of how it deducts price. Value based discount not available for coupon_cart type coupons
        /// </summary>
        /// <value>The type of discount in terms of how it deducts price. Value based discount not available for coupon_cart type coupons</value>
        [JsonProperty(PropertyName = "discount_type")]
        public string DiscountType { get; set; }

        /// <summary>
        /// The amount the coupon will discount the item. If discount_type is 'value' this will be a flat amount of currency. If discount type is 'percentage' this will be a fraction (0.2 for 20% off) multiplied by the price of the matching item or items.
        /// </summary>
        /// <value>The amount the coupon will discount the item. If discount_type is 'value' this will be a flat amount of currency. If discount type is 'percentage' this will be a fraction (0.2 for 20% off) multiplied by the price of the matching item or items.</value>
        [JsonProperty(PropertyName = "discount_value")]
        public decimal? DiscountValue { get; set; }

        /// <summary>
        /// Whether this coupon is exclusive or not (true means cannot be in same cart as another).  Default = false
        /// </summary>
        /// <value>Whether this coupon is exclusive or not (true means cannot be in same cart as another).  Default = false</value>
        [JsonProperty(PropertyName = "exclusive")]
        public bool? Exclusive { get; set; }

        /// <summary>
        /// The id of the item the coupon is applied to.  Applies if coupon_type_hint is coupon_single_item or coupon_voucher
        /// </summary>
        /// <value>The id of the item the coupon is applied to.  Applies if coupon_type_hint is coupon_single_item or coupon_voucher</value>
        [JsonProperty(PropertyName = "item_id")]
        public int? ItemId { get; set; }

        /// <summary>
        /// The maximum quantity of items the coupon can apply to, null if no limit and minimum 1 otherwise.  Applies if coupon_type_hint is coupon_single_item or coupon_voucher
        /// </summary>
        /// <value>The maximum quantity of items the coupon can apply to, null if no limit and minimum 1 otherwise.  Applies if coupon_type_hint is coupon_single_item or coupon_voucher</value>
        [JsonProperty(PropertyName = "max_quantity")]
        public int? MaxQuantity { get; set; }

        /// <summary>
        /// Whether this coupon is exclusive to itself or not (true means cannot add two of this same coupon to the same cart).  Default = false
        /// </summary>
        /// <value>Whether this coupon is exclusive to itself or not (true means cannot add two of this same coupon to the same cart).  Default = false</value>
        [JsonProperty(PropertyName = "self_exclusive")]
        public bool? SelfExclusive { get; set; }

        /// <summary>
        /// A list of tags for a coupon.  The coupon can only apply to an item that has at least one of these tags.  Applies if coupon_type_hint is coupon_tag
        /// </summary>
        /// <value>A list of tags for a coupon.  The coupon can only apply to an item that has at least one of these tags.  Applies if coupon_type_hint is coupon_tag</value>
        [JsonProperty(PropertyName = "valid_for_tags")]
        public List<string> ValidForTags { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CouponItem {\n");
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
            sb.Append("  CouponTypeHint: ").Append(CouponTypeHint).Append("\n");
            sb.Append("  DiscountMax: ").Append(DiscountMax).Append("\n");
            sb.Append("  DiscountMinCartValue: ").Append(DiscountMinCartValue).Append("\n");
            sb.Append("  DiscountType: ").Append(DiscountType).Append("\n");
            sb.Append("  DiscountValue: ").Append(DiscountValue).Append("\n");
            sb.Append("  Exclusive: ").Append(Exclusive).Append("\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
            sb.Append("  MaxQuantity: ").Append(MaxQuantity).Append("\n");
            sb.Append("  SelfExclusive: ").Append(SelfExclusive).Append("\n");
            sb.Append("  ValidForTags: ").Append(ValidForTags).Append("\n");
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
