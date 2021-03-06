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
    
    
    public class SubscriptionPlan
    {
        /// <summary>
        /// Gets or Sets AdditionalProperties
        /// </summary>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties;

        /// <summary>
        /// Gets or Sets Availability
        /// </summary>
        [JsonProperty(PropertyName = "availability")]
        public string Availability;

        /// <summary>
        /// Gets or Sets BillGraceDays
        /// </summary>
        [JsonProperty(PropertyName = "bill_grace_days")]
        public int? BillGraceDays;

        /// <summary>
        /// Gets or Sets Consolidated
        /// </summary>
        [JsonProperty(PropertyName = "consolidated")]
        public bool? Consolidated;

        /// <summary>
        /// Gets or Sets FirstBill
        /// </summary>
        [JsonProperty(PropertyName = "first_bill")]
        public int? FirstBill;

        /// <summary>
        /// Gets or Sets FirstBillUnitOfTime
        /// </summary>
        [JsonProperty(PropertyName = "first_bill_unit_of_time")]
        public string FirstBillUnitOfTime;

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// Gets or Sets LatePaymentSku
        /// </summary>
        [JsonProperty(PropertyName = "late_payment_sku")]
        public string LatePaymentSku;

        /// <summary>
        /// Gets or Sets Locked
        /// </summary>
        [JsonProperty(PropertyName = "locked")]
        public bool? Locked;

        /// <summary>
        /// Gets or Sets MaxAutoRenew
        /// </summary>
        [JsonProperty(PropertyName = "max_auto_renew")]
        public int? MaxAutoRenew;

        /// <summary>
        /// Gets or Sets MaxBillAttempts
        /// </summary>
        [JsonProperty(PropertyName = "max_bill_attempts")]
        public int? MaxBillAttempts;

        /// <summary>
        /// Gets or Sets MigrationPlan
        /// </summary>
        [JsonProperty(PropertyName = "migration_plan")]
        public string MigrationPlan;

        /// <summary>
        /// Gets or Sets MinimumTerm
        /// </summary>
        [JsonProperty(PropertyName = "minimum_term")]
        public int? MinimumTerm;

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// Gets or Sets PrimarySku
        /// </summary>
        [JsonProperty(PropertyName = "primary_sku")]
        public string PrimarySku;

        /// <summary>
        /// Gets or Sets ReactivationSku
        /// </summary>
        [JsonProperty(PropertyName = "reactivation_sku")]
        public string ReactivationSku;

        /// <summary>
        /// Gets or Sets RecurringSku
        /// </summary>
        [JsonProperty(PropertyName = "recurring_sku")]
        public string RecurringSku;

        /// <summary>
        /// Gets or Sets RenewPeriod
        /// </summary>
        [JsonProperty(PropertyName = "renew_period")]
        public int? RenewPeriod;

        /// <summary>
        /// Gets or Sets RenewPeriodUnitOfTime
        /// </summary>
        [JsonProperty(PropertyName = "renew_period_unit_of_time")]
        public string RenewPeriodUnitOfTime;

        /// <summary>
        /// Gets or Sets SubscriptionId
        /// </summary>
        [JsonProperty(PropertyName = "subscription_id")]
        public int? SubscriptionId;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SubscriptionPlan {\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  Availability: ").Append(Availability).Append("\n");
            sb.Append("  BillGraceDays: ").Append(BillGraceDays).Append("\n");
            sb.Append("  Consolidated: ").Append(Consolidated).Append("\n");
            sb.Append("  FirstBill: ").Append(FirstBill).Append("\n");
            sb.Append("  FirstBillUnitOfTime: ").Append(FirstBillUnitOfTime).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LatePaymentSku: ").Append(LatePaymentSku).Append("\n");
            sb.Append("  Locked: ").Append(Locked).Append("\n");
            sb.Append("  MaxAutoRenew: ").Append(MaxAutoRenew).Append("\n");
            sb.Append("  MaxBillAttempts: ").Append(MaxBillAttempts).Append("\n");
            sb.Append("  MigrationPlan: ").Append(MigrationPlan).Append("\n");
            sb.Append("  MinimumTerm: ").Append(MinimumTerm).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PrimarySku: ").Append(PrimarySku).Append("\n");
            sb.Append("  ReactivationSku: ").Append(ReactivationSku).Append("\n");
            sb.Append("  RecurringSku: ").Append(RecurringSku).Append("\n");
            sb.Append("  RenewPeriod: ").Append(RenewPeriod).Append("\n");
            sb.Append("  RenewPeriodUnitOfTime: ").Append(RenewPeriodUnitOfTime).Append("\n");
            sb.Append("  SubscriptionId: ").Append(SubscriptionId).Append("\n");
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
