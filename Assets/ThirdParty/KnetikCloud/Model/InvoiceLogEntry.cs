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
    public class InvoiceLogEntry
    {
        /// <summary>
        /// The date this event occurred as a unix timestamp in seconds
        /// </summary>
        /// <value>The date this event occurred as a unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "date")]
        public long? Date { get; set; }

        /// <summary>
        /// The ID of the invoice
        /// </summary>
        /// <value>The ID of the invoice</value>
        [JsonProperty(PropertyName = "invoice_id")]
        public int? InvoiceId { get; set; }

        /// <summary>
        /// A message describing the event
        /// </summary>
        /// <value>A message describing the event</value>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// The type of event
        /// </summary>
        /// <value>The type of event</value>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class InvoiceLogEntry {\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
