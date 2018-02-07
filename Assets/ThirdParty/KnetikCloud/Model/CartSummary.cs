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
    
    
    public class CartSummary
    {
        /// <summary>
        /// The date/time this resource was created in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The unique id code for the currency used in the cart
        /// </summary>
        /// <value>The unique id code for the currency used in the cart</value>
        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode;

        /// <summary>
        /// The grand total for the cart
        /// </summary>
        /// <value>The grand total for the cart</value>
        [JsonProperty(PropertyName = "grand_total")]
        public decimal? GrandTotal;

        /// <summary>
        /// The unique ID for the cart
        /// </summary>
        /// <value>The unique ID for the cart</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// The ID of the invoice associated with this cart
        /// </summary>
        /// <value>The ID of the invoice associated with this cart</value>
        [JsonProperty(PropertyName = "invoice_id")]
        public decimal? InvoiceId;

        /// <summary>
        /// The number of items in the cart
        /// </summary>
        /// <value>The number of items in the cart</value>
        [JsonProperty(PropertyName = "items_in_cart")]
        public int? ItemsInCart;

        /// <summary>
        /// The status of the cart
        /// </summary>
        /// <value>The status of the cart</value>
        [JsonProperty(PropertyName = "status")]
        public string Status;

        /// <summary>
        /// The subtotal of all items in the cart
        /// </summary>
        /// <value>The subtotal of all items in the cart</value>
        [JsonProperty(PropertyName = "subtotal")]
        public decimal? Subtotal;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CartSummary {\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  GrandTotal: ").Append(GrandTotal).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
            sb.Append("  ItemsInCart: ").Append(ItemsInCart).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Subtotal: ").Append(Subtotal).Append("\n");
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
