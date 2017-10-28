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
    public class VariableTypeResource
    {
        /// <summary>
        /// The base class of the type
        /// </summary>
        /// <value>The base class of the type</value>
        [JsonProperty(PropertyName = "base")]
        public string _Base;

        /// <summary>
        /// Whether the type comes from a set of valid values that the system can provided (such as users)
        /// </summary>
        /// <value>Whether the type comes from a set of valid values that the system can provided (such as users)</value>
        [JsonProperty(PropertyName = "enumerable")]
        public bool? Enumerable;

        /// <summary>
        /// The name of the variable type. Used as the unique id
        /// </summary>
        /// <value>The name of the variable type. Used as the unique id</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class VariableTypeResource {\n");
            sb.Append("  _Base: ").Append(_Base).Append("\n");
            sb.Append("  Enumerable: ").Append(Enumerable).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
