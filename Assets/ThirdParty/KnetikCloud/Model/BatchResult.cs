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
    public class BatchResult
    {
        /// <summary>
        /// List of batch responses.  Returns in the order requested
        /// </summary>
        /// <value>List of batch responses.  Returns in the order requested</value>
        [JsonProperty(PropertyName = "batch_return")]
        public List<BatchReturn> BatchReturn;

        /// <summary>
        /// The date the batch call started processing
        /// </summary>
        /// <value>The date the batch call started processing</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The token to use at the /batch/{token} endpoint if the request times out
        /// </summary>
        /// <value>The token to use at the /batch/{token} endpoint if the request times out</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// The date the batch call finished processing
        /// </summary>
        /// <value>The date the batch call finished processing</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BatchResult {\n");
            sb.Append("  BatchReturn: ").Append(BatchReturn).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
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
