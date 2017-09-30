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
    public class MobileDeviceResource : DeviceResource
    {
        /// <summary>
        /// The authorization code for push notifications provided by the provider platform (APNS, GCM, etc).
        /// </summary>
        /// <value>The authorization code for push notifications provided by the provider platform (APNS, GCM, etc).</value>
        [JsonProperty(PropertyName = "authorization")]
        public string Authorization { get; set; }

        /// <summary>
        /// Gets or Sets Imei
        /// </summary>
        [JsonProperty(PropertyName = "imei")]
        public string Imei { get; set; }

        /// <summary>
        /// The platform used for push notifications. Only Apple and Android are supported at the moment.
        /// </summary>
        /// <value>The platform used for push notifications. Only Apple and Android are supported at the moment.</value>
        [JsonProperty(PropertyName = "notification_platform")]
        public string NotificationPlatform { get; set; }

        /// <summary>
        /// The phone number associated with this device if applicable, in international format
        /// </summary>
        /// <value>The phone number associated with this device if applicable, in international format</value>
        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MobileDeviceResource {\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DeviceType: ").Append(DeviceType).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  MacAddress: ").Append(MacAddress).Append("\n");
            sb.Append("  Make: ").Append(Make).Append("\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Os: ").Append(Os).Append("\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  Serial: ").Append(Serial).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  Users: ").Append(Users).Append("\n");
            sb.Append("  Authorization: ").Append(Authorization).Append("\n");
            sb.Append("  Imei: ").Append(Imei).Append("\n");
            sb.Append("  NotificationPlatform: ").Append(NotificationPlatform).Append("\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
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
