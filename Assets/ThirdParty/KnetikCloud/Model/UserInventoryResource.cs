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
    
    
    public class UserInventoryResource
    {
        /// <summary>
        /// A map of data for behaviors
        /// </summary>
        /// <value>A map of data for behaviors</value>
        [JsonProperty(PropertyName = "behavior_data")]
        public Object BehaviorData;

        /// <summary>
        /// The date/time this resource was created in seconds since epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The date/time this resource exires in seconds since epoch. Null for no expiration. For subscriptions, this is the end of the 'grace period' if left unpaid
        /// </summary>
        /// <value>The date/time this resource exires in seconds since epoch. Null for no expiration. For subscriptions, this is the end of the 'grace period' if left unpaid</value>
        [JsonProperty(PropertyName = "expires")]
        public long? Expires;

        /// <summary>
        /// The id of the inventory
        /// </summary>
        /// <value>The id of the inventory</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id;

        /// <summary>
        /// The id of the invoice that resulted in this inventory, if any
        /// </summary>
        /// <value>The id of the invoice that resulted in this inventory, if any</value>
        [JsonProperty(PropertyName = "invoice_id")]
        public int? InvoiceId;

        /// <summary>
        /// The id of the item
        /// </summary>
        /// <value>The id of the item</value>
        [JsonProperty(PropertyName = "item_id")]
        public int? ItemId;

        /// <summary>
        /// The name of the item
        /// </summary>
        /// <value>The name of the item</value>
        [JsonProperty(PropertyName = "item_name")]
        public string ItemName;

        /// <summary>
        /// The type hint of the item
        /// </summary>
        /// <value>The type hint of the item</value>
        [JsonProperty(PropertyName = "item_type_hint")]
        public string ItemTypeHint;

        /// <summary>
        /// The status of the inventory. Pending inventory is not yet ready for use. Inactive inventory has expired or been used up
        /// </summary>
        /// <value>The status of the inventory. Pending inventory is not yet ready for use. Inactive inventory has expired or been used up</value>
        [JsonProperty(PropertyName = "status")]
        public string Status;

        /// <summary>
        /// The date/time this resource was last updated in seconds since epoch
        /// </summary>
        /// <value>The date/time this resource was last updated in seconds since epoch</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <summary>
        /// The id of the user this inventory belongs to
        /// </summary>
        /// <value>The id of the user this inventory belongs to</value>
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
            sb.Append("class UserInventoryResource {\n");
            sb.Append("  BehaviorData: ").Append(BehaviorData).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Expires: ").Append(Expires).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
            sb.Append("  ItemName: ").Append(ItemName).Append("\n");
            sb.Append("  ItemTypeHint: ").Append(ItemTypeHint).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
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
