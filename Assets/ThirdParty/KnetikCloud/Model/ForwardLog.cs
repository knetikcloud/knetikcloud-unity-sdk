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
    
    
    public class ForwardLog
    {
        /// <summary>
        /// The end date of the forward log entry
        /// </summary>
        /// <value>The end date of the forward log entry</value>
        [JsonProperty(PropertyName = "end_date")]
        public long? EndDate;

        /// <summary>
        /// Gets or Sets ErrorMsg
        /// </summary>
        [JsonProperty(PropertyName = "error_msg")]
        public string ErrorMsg;

        /// <summary>
        /// The http status code the forward log entry
        /// </summary>
        /// <value>The http status code the forward log entry</value>
        [JsonProperty(PropertyName = "http_status_code")]
        public int? HttpStatusCode;

        /// <summary>
        /// The id of the forward log entry
        /// </summary>
        /// <value>The id of the forward log entry</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// The payload of the forward log entry
        /// </summary>
        /// <value>The payload of the forward log entry</value>
        [JsonProperty(PropertyName = "payload")]
        public Object Payload;

        /// <summary>
        /// The response string of the forward log entry
        /// </summary>
        /// <value>The response string of the forward log entry</value>
        [JsonProperty(PropertyName = "response")]
        public string Response;

        /// <summary>
        /// The retry count of the forward log entry
        /// </summary>
        /// <value>The retry count of the forward log entry</value>
        [JsonProperty(PropertyName = "retry_count")]
        public int? RetryCount;

        /// <summary>
        /// The start date of the forward log entry
        /// </summary>
        /// <value>The start date of the forward log entry</value>
        [JsonProperty(PropertyName = "start_date")]
        public long? StartDate;

        /// <summary>
        /// The endpoint url of the forward log entry
        /// </summary>
        /// <value>The endpoint url of the forward log entry</value>
        [JsonProperty(PropertyName = "url")]
        public string Url;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ForwardLog {\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
            sb.Append("  ErrorMsg: ").Append(ErrorMsg).Append("\n");
            sb.Append("  HttpStatusCode: ").Append(HttpStatusCode).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Payload: ").Append(Payload).Append("\n");
            sb.Append("  Response: ").Append(Response).Append("\n");
            sb.Append("  RetryCount: ").Append(RetryCount).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
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
