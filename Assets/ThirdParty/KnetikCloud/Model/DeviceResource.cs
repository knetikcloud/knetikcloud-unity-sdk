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
    
    [JsonConverter(typeof(KnetikJsonConverter<DeviceResource>))]
    public class DeviceResource
    {
        /// <summary>
        /// A map of additional properties, keyed on the property name.  Must match the names and types defined in the template if one is specified
        /// </summary>
        /// <value>A map of additional properties, keyed on the property name.  Must match the names and types defined in the template if one is specified</value>
        [JsonProperty(PropertyName = "additional_properties")]
        public Dictionary<string, Property> AdditionalProperties;

        /// <summary>
        /// The date the device log was created
        /// </summary>
        /// <value>The date the device log was created</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The description of the device
        /// </summary>
        /// <value>The description of the device</value>
        [JsonProperty(PropertyName = "description")]
        public string Description;

        /// <summary>
        /// The type of device. Use mobile to specifically register mobile devices. This particular type will be used to send and receive notifications
        /// </summary>
        /// <value>The type of device. Use mobile to specifically register mobile devices. This particular type will be used to send and receive notifications</value>
        [JsonProperty(PropertyName = "device_type")]
        public string DeviceType;

        /// <summary>
        /// The unique ID for this device
        /// </summary>
        /// <value>The unique ID for this device</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// The physical location of the device, coordinates or named place (office, living room, etc)
        /// </summary>
        /// <value>The physical location of the device, coordinates or named place (office, living room, etc)</value>
        [JsonProperty(PropertyName = "location")]
        public string Location;

        /// <summary>
        /// The MAC (media access control) address of the device
        /// </summary>
        /// <value>The MAC (media access control) address of the device</value>
        [JsonProperty(PropertyName = "mac_address")]
        public string MacAddress;

        /// <summary>
        /// The make of the device
        /// </summary>
        /// <value>The make of the device</value>
        [JsonProperty(PropertyName = "make")]
        public string Make;

        /// <summary>
        /// The model of the device
        /// </summary>
        /// <value>The model of the device</value>
        [JsonProperty(PropertyName = "model")]
        public string Model;

        /// <summary>
        /// The name of the device
        /// </summary>
        /// <value>The name of the device</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The OS (operating system) on the device
        /// </summary>
        /// <value>The OS (operating system) on the device</value>
        [JsonProperty(PropertyName = "os")]
        public string Os;

        /// <summary>
        /// The user that owns the device
        /// </summary>
        /// <value>The user that owns the device</value>
        [JsonProperty(PropertyName = "owner")]
        public SimpleUserResource Owner;

        /// <summary>
        /// The serial number of the device
        /// </summary>
        /// <value>The serial number of the device</value>
        [JsonProperty(PropertyName = "serial")]
        public string Serial;

        /// <summary>
        /// Random tags to facilitate search
        /// </summary>
        /// <value>Random tags to facilitate search</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags;

        /// <summary>
        /// Use to describe and validate custom properties (custom schema). May be null and no validation of additional_properties will be done
        /// </summary>
        /// <value>Use to describe and validate custom properties (custom schema). May be null and no validation of additional_properties will be done</value>
        [JsonProperty(PropertyName = "template")]
        public string Template;

        /// <summary>
        /// The date the device log was updated
        /// </summary>
        /// <value>The date the device log was updated</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <summary>
        /// The users currently using the device
        /// </summary>
        /// <value>The users currently using the device</value>
        [JsonProperty(PropertyName = "users")]
        public List<SimpleUserResource> Users;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DeviceResource {\n");
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
