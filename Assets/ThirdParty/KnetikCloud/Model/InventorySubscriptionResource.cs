using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using KnetikUnity.Attributes;
using KnetikUnity.Serialization;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    
    
    public class InventorySubscriptionResource
    {
        /// <summary>
        /// The date the subscription will be billed
        /// </summary>
        /// <value>The date the subscription will be billed</value>
        [JsonProperty(PropertyName = "bill_date")]
        public long? BillDate;

        /// <summary>
        /// A credit of money already applied to a subscription for the next bill, or a debt if negative
        /// </summary>
        /// <value>A credit of money already applied to a subscription for the next bill, or a debt if negative</value>
        [JsonProperty(PropertyName = "credit")]
        public decimal? Credit;

        /// <summary>
        /// A record of past and present credit/debt changes
        /// </summary>
        /// <value>A record of past and present credit/debt changes</value>
        [JsonProperty(PropertyName = "credit_log")]
        public List<SubscriptionCreditResource> CreditLog;

        /// <summary>
        /// The date the grace period ends
        /// </summary>
        /// <value>The date the grace period ends</value>
        [JsonProperty(PropertyName = "grace_end")]
        public long? GraceEnd;

        /// <summary>
        /// The id of the inventory
        /// </summary>
        /// <value>The id of the inventory</value>
        [JsonProperty(PropertyName = "inventory_id")]
        public int? InventoryId;

        /// <summary>
        /// The inventory status object
        /// </summary>
        /// <value>The inventory status object</value>
        [JsonProperty(PropertyName = "inventory_status")]
        public string InventoryStatus;

        /// <summary>
        /// The id of the item
        /// </summary>
        /// <value>The id of the item</value>
        [JsonProperty(PropertyName = "item_id")]
        public int? ItemId;

        /// <summary>
        /// The payment method object
        /// </summary>
        /// <value>The payment method object</value>
        [JsonProperty(PropertyName = "payment_method")]
        public PaymentMethodResource PaymentMethod;

        /// <summary>
        /// The recurring price that has been set to override the base price. Null if not overriding
        /// </summary>
        /// <value>The recurring price that has been set to override the base price. Null if not overriding</value>
        [JsonProperty(PropertyName = "price_override")]
        public decimal? PriceOverride;

        /// <summary>
        /// An explanation for the reason the price is being overridden
        /// </summary>
        /// <value>An explanation for the reason the price is being overridden</value>
        [JsonProperty(PropertyName = "price_override_reason")]
        public string PriceOverrideReason;

        /// <summary>
        /// The default recurring price
        /// </summary>
        /// <value>The default recurring price</value>
        [JsonProperty(PropertyName = "recurring_price")]
        public decimal? RecurringPrice;

        /// <summary>
        /// The recurring sku of the subscription
        /// </summary>
        /// <value>The recurring sku of the subscription</value>
        [JsonProperty(PropertyName = "sku")]
        public string Sku;

        /// <summary>
        /// The date the subscription will start
        /// </summary>
        /// <value>The date the subscription will start</value>
        [JsonProperty(PropertyName = "start_date")]
        public long? StartDate;

        /// <summary>
        /// The status of the subscription
        /// </summary>
        /// <value>The status of the subscription</value>
        [JsonProperty(PropertyName = "subscription_status")]
        public int? SubscriptionStatus;

        /// <summary>
        /// The user
        /// </summary>
        /// <value>The user</value>
        [JsonProperty(PropertyName = "user")]
        public SimpleUserResource User;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class InventorySubscriptionResource {\n");
            sb.Append("  BillDate: ").Append(BillDate).Append("\n");
            sb.Append("  Credit: ").Append(Credit).Append("\n");
            sb.Append("  CreditLog: ").Append(CreditLog).Append("\n");
            sb.Append("  GraceEnd: ").Append(GraceEnd).Append("\n");
            sb.Append("  InventoryId: ").Append(InventoryId).Append("\n");
            sb.Append("  InventoryStatus: ").Append(InventoryStatus).Append("\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
            sb.Append("  PaymentMethod: ").Append(PaymentMethod).Append("\n");
            sb.Append("  PriceOverride: ").Append(PriceOverride).Append("\n");
            sb.Append("  PriceOverrideReason: ").Append(PriceOverrideReason).Append("\n");
            sb.Append("  RecurringPrice: ").Append(RecurringPrice).Append("\n");
            sb.Append("  Sku: ").Append(Sku).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  SubscriptionStatus: ").Append(SubscriptionStatus).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
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
