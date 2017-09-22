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
    public class MobileDeviceResource : DeviceResource
    {
        /// <summary>
        /// A map of additional properties, keyed on the property name.  Must match the names and types defined in the template if one is specified
        /// </summary>
        /// <value>A map of additional properties, keyed on the property name.  Must match the names and types defined in the template if one is specified</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties { get; set; }

        /// <summary>
        /// The date the device log was created
        /// </summary>
        /// <value>The date the device log was created</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate { get; set; }

        /// <summary>
        /// The description of the device
        /// </summary>
        /// <value>The description of the device</value>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The type of device. Use mobile to specifically register mobile devices. This particular type will be used to send and receive notifications
        /// </summary>
        /// <value>The type of device. Use mobile to specifically register mobile devices. This particular type will be used to send and receive notifications</value>
        [JsonProperty(PropertyName = "device_type")]
        public string DeviceType { get; set; }

        /// <summary>
        /// The unique ID for this device
        /// </summary>
        /// <value>The unique ID for this device</value>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The physical location of the device, coordinates or named place (office, living room, etc)
        /// </summary>
        /// <value>The physical location of the device, coordinates or named place (office, living room, etc)</value>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// The MAC (media access control) address of the device
        /// </summary>
        /// <value>The MAC (media access control) address of the device</value>
        [JsonProperty(PropertyName = "mac_address")]
        public string MacAddress { get; set; }

        /// <summary>
        /// The make of the device
        /// </summary>
        /// <value>The make of the device</value>
        [JsonProperty(PropertyName = "make")]
        public string Make { get; set; }

        /// <summary>
        /// The model of the device
        /// </summary>
        /// <value>The model of the device</value>
        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        /// <summary>
        /// The name of the device
        /// </summary>
        /// <value>The name of the device</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The OS (operating system) on the device
        /// </summary>
        /// <value>The OS (operating system) on the device</value>
        [JsonProperty(PropertyName = "os")]
        public string Os { get; set; }

        /// <summary>
        /// The user that owns the device
        /// </summary>
        /// <value>The user that owns the device</value>
        [JsonProperty(PropertyName = "owner")]
        public SimpleUserResource Owner { get; set; }

        /// <summary>
        /// The serial number of the device
        /// </summary>
        /// <value>The serial number of the device</value>
        [JsonProperty(PropertyName = "serial")]
        public string Serial { get; set; }

        /// <summary>
        /// Random tags to facilitate search
        /// </summary>
        /// <value>Random tags to facilitate search</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Use to describe and validate custom properties (custom schema). May be null and no validation of additional_properties will be done
        /// </summary>
        /// <value>Use to describe and validate custom properties (custom schema). May be null and no validation of additional_properties will be done</value>
        [JsonProperty(PropertyName = "template")]
        public string Template { get; set; }

        /// <summary>
        /// The date the device log was updated
        /// </summary>
        /// <value>The date the device log was updated</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate { get; set; }

        /// <summary>
        /// The users currently using the device
        /// </summary>
        /// <value>The users currently using the device</value>
        [JsonProperty(PropertyName = "users")]
        public List<SimpleUserResource> Users { get; set; }

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
