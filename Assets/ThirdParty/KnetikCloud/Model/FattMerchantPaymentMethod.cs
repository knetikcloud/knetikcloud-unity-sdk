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
    public class FattMerchantPaymentMethod
    {
        /// <summary>
        /// Gets or Sets Address1
        /// </summary>
        [JsonProperty(PropertyName = "address1")]
        public string Address1;

        /// <summary>
        /// Gets or Sets Address2
        /// </summary>
        [JsonProperty(PropertyName = "address2")]
        public string Address2;

        /// <summary>
        /// Gets or Sets AddressCity
        /// </summary>
        [JsonProperty(PropertyName = "address_city")]
        public string AddressCity;

        /// <summary>
        /// Gets or Sets AddressCountry
        /// </summary>
        [JsonProperty(PropertyName = "address_country")]
        public string AddressCountry;

        /// <summary>
        /// Gets or Sets AddressState
        /// </summary>
        [JsonProperty(PropertyName = "address_state")]
        public string AddressState;

        /// <summary>
        /// Gets or Sets AddressZip
        /// </summary>
        [JsonProperty(PropertyName = "address_zip")]
        public string AddressZip;

        /// <summary>
        /// Last four digits of the credit card
        /// </summary>
        /// <value>Last four digits of the credit card</value>
        [JsonProperty(PropertyName = "card_last_four")]
        public string CardLastFour;

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt;

        /// <summary>
        /// Unique FattMerchant customer ID
        /// </summary>
        /// <value>Unique FattMerchant customer ID</value>
        [JsonProperty(PropertyName = "customer_id")]
        public string CustomerId;

        /// <summary>
        /// Gets or Sets DeletedAt
        /// </summary>
        [JsonProperty(PropertyName = "deleted_at")]
        public string DeletedAt;

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// Nickname given to the FattMerchant payment method
        /// </summary>
        /// <value>Nickname given to the FattMerchant payment method</value>
        [JsonProperty(PropertyName = "nickname")]
        public string Nickname;

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [JsonProperty(PropertyName = "updated_at")]
        public string UpdatedAt;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FattMerchantPaymentMethod {\n");
            sb.Append("  Address1: ").Append(Address1).Append("\n");
            sb.Append("  Address2: ").Append(Address2).Append("\n");
            sb.Append("  AddressCity: ").Append(AddressCity).Append("\n");
            sb.Append("  AddressCountry: ").Append(AddressCountry).Append("\n");
            sb.Append("  AddressState: ").Append(AddressState).Append("\n");
            sb.Append("  AddressZip: ").Append(AddressZip).Append("\n");
            sb.Append("  CardLastFour: ").Append(CardLastFour).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  CustomerId: ").Append(CustomerId).Append("\n");
            sb.Append("  DeletedAt: ").Append(DeletedAt).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Nickname: ").Append(Nickname).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
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
