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
    
    
    public class UserItemLogResource
    {
        /// <summary>
        /// The log entry id
        /// </summary>
        /// <value>The log entry id</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id;

        /// <summary>
        /// Additional information defined by the type
        /// </summary>
        /// <value>Additional information defined by the type</value>
        [JsonProperty(PropertyName = "info")]
        public string Info;

        /// <summary>
        /// The item interacted with
        /// </summary>
        /// <value>The item interacted with</value>
        [JsonProperty(PropertyName = "item")]
        public SimpleReferenceResourceint Item;

        /// <summary>
        /// The date/time this event occurred in seconds since epoch
        /// </summary>
        /// <value>The date/time this event occurred in seconds since epoch</value>
        [JsonProperty(PropertyName = "log_date")]
        public long? LogDate;

        /// <summary>
        /// The type of event
        /// </summary>
        /// <value>The type of event</value>
        [JsonProperty(PropertyName = "type")]
        public string Type;

        /// <summary>
        /// The user making the interaction
        /// </summary>
        /// <value>The user making the interaction</value>
        [JsonProperty(PropertyName = "user")]
        public SimpleUserResource User;

        /// <summary>
        /// The id of the inventory entry this event is related to, if any
        /// </summary>
        /// <value>The id of the inventory entry this event is related to, if any</value>
        [JsonProperty(PropertyName = "user_inventory")]
        public int? UserInventory;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UserItemLogResource {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Info: ").Append(Info).Append("\n");
            sb.Append("  Item: ").Append(Item).Append("\n");
            sb.Append("  LogDate: ").Append(LogDate).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
            sb.Append("  UserInventory: ").Append(UserInventory).Append("\n");
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
