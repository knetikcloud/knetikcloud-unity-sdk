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
    
    
    public class Sku
    {
        /// <summary>
        /// A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type, or be an extra not from the template
        /// </summary>
        /// <value>A map of additional properties, keyed on the property name.  Must match the names and types defined in the template for this item type, or be an extra not from the template</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties;

        /// <summary>
        /// The currency code for the SKU, a three letter string (ISO3)
        /// </summary>
        /// <value>The currency code for the SKU, a three letter string (ISO3)</value>
        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode;

        /// <summary>
        /// The friendly name of the SKU as it will appear on invoices and reports. Typically represents the option name like red, large, etc
        /// </summary>
        /// <value>The friendly name of the SKU as it will appear on invoices and reports. Typically represents the option name like red, large, etc</value>
        [JsonProperty(PropertyName = "description")]
        public string Description;

        /// <summary>
        /// The number of SKUs currently in stock
        /// </summary>
        /// <value>The number of SKUs currently in stock</value>
        [JsonProperty(PropertyName = "inventory")]
        public int? Inventory;

        /// <summary>
        /// Alerts vendor when SKU inventory drops below this value
        /// </summary>
        /// <value>Alerts vendor when SKU inventory drops below this value</value>
        [JsonProperty(PropertyName = "min_inventory_threshold")]
        public int? MinInventoryThreshold;

        /// <summary>
        /// Gets or Sets NotAvailable
        /// </summary>
        [JsonProperty(PropertyName = "not_available")]
        public bool? NotAvailable;

        /// <summary>
        /// Gets or Sets NotDisplayable
        /// </summary>
        [JsonProperty(PropertyName = "not_displayable")]
        public bool? NotDisplayable;

        /// <summary>
        /// The base price before any sale
        /// </summary>
        /// <value>The base price before any sale</value>
        [JsonProperty(PropertyName = "original_price")]
        public decimal? OriginalPrice;

        /// <summary>
        /// The current price of the SKU with sales, if any. Set original_price for the base
        /// </summary>
        /// <value>The current price of the SKU with sales, if any. Set original_price for the base</value>
        [JsonProperty(PropertyName = "price")]
        public decimal? Price;

        /// <summary>
        /// Whether or not the SKU is currently visible to users. This will not block users from purchase. Use start_date or stop_date to prevent purchase. Default: true
        /// </summary>
        /// <value>Whether or not the SKU is currently visible to users. This will not block users from purchase. Use start_date or stop_date to prevent purchase. Default: true</value>
        [JsonProperty(PropertyName = "published")]
        public bool? Published;

        /// <summary>
        /// The id of a sale affecting the price, if any
        /// </summary>
        /// <value>The id of a sale affecting the price, if any</value>
        [JsonProperty(PropertyName = "sale_id")]
        public int? SaleId;

        /// <summary>
        /// The name of a sale affecting the price, if any
        /// </summary>
        /// <value>The name of a sale affecting the price, if any</value>
        [JsonProperty(PropertyName = "sale_name")]
        public string SaleName;

        /// <summary>
        /// The stock keeping unit (SKU), a unique identifier for a given product.  Max 40 characters
        /// </summary>
        /// <value>The stock keeping unit (SKU), a unique identifier for a given product.  Max 40 characters</value>
        [JsonProperty(PropertyName = "sku")]
        public string _Sku;

        /// <summary>
        /// The date the sku becomes visible (if published) and available for purchase, unix timestamp in seconds.  If set to null, sku will become available immediately
        /// </summary>
        /// <value>The date the sku becomes visible (if published) and available for purchase, unix timestamp in seconds.  If set to null, sku will become available immediately</value>
        [JsonProperty(PropertyName = "start_date")]
        public long? StartDate;

        /// <summary>
        /// The date the sku becomes hidden and unavailable for purchase, unix timestamp in seconds.  If set to null, sku is always available
        /// </summary>
        /// <value>The date the sku becomes hidden and unavailable for purchase, unix timestamp in seconds.  If set to null, sku is always available</value>
        [JsonProperty(PropertyName = "stop_date")]
        public long? StopDate;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Sku {\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Inventory: ").Append(Inventory).Append("\n");
            sb.Append("  MinInventoryThreshold: ").Append(MinInventoryThreshold).Append("\n");
            sb.Append("  NotAvailable: ").Append(NotAvailable).Append("\n");
            sb.Append("  NotDisplayable: ").Append(NotDisplayable).Append("\n");
            sb.Append("  OriginalPrice: ").Append(OriginalPrice).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Published: ").Append(Published).Append("\n");
            sb.Append("  SaleId: ").Append(SaleId).Append("\n");
            sb.Append("  SaleName: ").Append(SaleName).Append("\n");
            sb.Append("  _Sku: ").Append(_Sku).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  StopDate: ").Append(StopDate).Append("\n");
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
