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
    public class MapProperty : Property
    {
        /// <summary>
        /// A map/object of string to sub-property
        /// </summary>
        /// <value>A map/object of string to sub-property</value>
        [JsonProperty(PropertyName = "map")]
        public Dictionary<string, Property> Map { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MapProperty {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Map: ").Append(Map).Append("\n");
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
