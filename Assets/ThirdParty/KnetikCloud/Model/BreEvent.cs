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
    public class BreEvent
    {
        /// <summary>
        /// The event name of the trigger to be fired
        /// </summary>
        /// <value>The event name of the trigger to be fired</value>
        [JsonProperty(PropertyName = "event_name")]
        public string EventName;

        /// <summary>
        /// The parameters to the event. A Map (assosiative array) with a key for each trigger parameter name and a corrosponding value.
        /// </summary>
        /// <value>The parameters to the event. A Map (assosiative array) with a key for each trigger parameter name and a corrosponding value.</value>
        [JsonProperty(PropertyName = "params")]
        public Object _Params;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BreEvent {\n");
            sb.Append("  EventName: ").Append(EventName).Append("\n");
            sb.Append("  _Params: ").Append(_Params).Append("\n");
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
