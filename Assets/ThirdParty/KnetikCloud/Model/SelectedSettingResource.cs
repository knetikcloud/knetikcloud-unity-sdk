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
    public class SelectedSettingResource
    {
        /// <summary>
        /// The unique ID for the setting
        /// </summary>
        /// <value>The unique ID for the setting</value>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// The textual name of the setting
        /// </summary>
        /// <value>The textual name of the setting</value>
        [JsonProperty(PropertyName = "key_name")]
        public string KeyName { get; set; }

        /// <summary>
        /// The unique ID for the option. Must match one of the options from this setting in the activity, if not part of a challenge
        /// </summary>
        /// <value>The unique ID for the option. Must match one of the options from this setting in the activity, if not part of a challenge</value>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// The textual name of the option
        /// </summary>
        /// <value>The textual name of the option</value>
        [JsonProperty(PropertyName = "value_name")]
        public string ValueName { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SelectedSettingResource {\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  KeyName: ").Append(KeyName).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  ValueName: ").Append(ValueName).Append("\n");
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
