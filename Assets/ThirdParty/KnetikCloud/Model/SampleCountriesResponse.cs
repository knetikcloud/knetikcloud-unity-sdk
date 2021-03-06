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
    
    
    public class SampleCountriesResponse
    {
        /// <summary>
        /// Gets or Sets VendorId1
        /// </summary>
        [JsonProperty(PropertyName = "vendor_id1")]
        public List<Country> VendorId1;

        /// <summary>
        /// Gets or Sets VendorId2
        /// </summary>
        [JsonProperty(PropertyName = "vendor_id2")]
        public List<Country> VendorId2;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SampleCountriesResponse {\n");
            sb.Append("  VendorId1: ").Append(VendorId1).Append("\n");
            sb.Append("  VendorId2: ").Append(VendorId2).Append("\n");
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
