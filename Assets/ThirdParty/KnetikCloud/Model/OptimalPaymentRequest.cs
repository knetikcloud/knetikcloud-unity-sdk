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
    public class OptimalPaymentRequest
    {
        /// <summary>
        /// The email address of the user
        /// </summary>
        /// <value>The email address of the user</value>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// The first name of the user
        /// </summary>
        /// <value>The first name of the user</value>
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The id of the invoice to pay
        /// </summary>
        /// <value>The id of the invoice to pay</value>
        [JsonProperty(PropertyName = "invoice_id")]
        public int? InvoiceId { get; set; }

        /// <summary>
        /// The last name of the user
        /// </summary>
        /// <value>The last name of the user</value>
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// The url to redirect the user to after declining payment
        /// </summary>
        /// <value>The url to redirect the user to after declining payment</value>
        [JsonProperty(PropertyName = "on_decline")]
        public string OnDecline { get; set; }

        /// <summary>
        /// The url to redirect the user to after an error in payment
        /// </summary>
        /// <value>The url to redirect the user to after an error in payment</value>
        [JsonProperty(PropertyName = "on_error")]
        public string OnError { get; set; }

        /// <summary>
        /// The url to redirect the user to after successful payment
        /// </summary>
        /// <value>The url to redirect the user to after successful payment</value>
        [JsonProperty(PropertyName = "on_success")]
        public string OnSuccess { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OptimalPaymentRequest {\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  OnDecline: ").Append(OnDecline).Append("\n");
            sb.Append("  OnError: ").Append(OnError).Append("\n");
            sb.Append("  OnSuccess: ").Append(OnSuccess).Append("\n");
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
