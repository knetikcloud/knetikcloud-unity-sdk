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
    
    
    public class MessageContentResource
    {
        /// <summary>
        /// The content of the email
        /// </summary>
        /// <value>The content of the email</value>
        [JsonProperty(PropertyName = "email")]
        public string Email;

        /// <summary>
        /// The content of the mobile app push notification
        /// </summary>
        /// <value>The content of the mobile app push notification</value>
        [JsonProperty(PropertyName = "push")]
        public string Push;

        /// <summary>
        /// The content of the sms
        /// </summary>
        /// <value>The content of the sms</value>
        [JsonProperty(PropertyName = "sms")]
        public string Sms;

        /// <summary>
        /// The content of the templated email
        /// </summary>
        /// <value>The content of the templated email</value>
        [JsonProperty(PropertyName = "templated_email")]
        public TemplatedEmail TemplatedEmail;

        /// <summary>
        /// The content of the websocket message
        /// </summary>
        /// <value>The content of the websocket message</value>
        [JsonProperty(PropertyName = "websocket")]
        public Object Websocket;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MessageContentResource {\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Push: ").Append(Push).Append("\n");
            sb.Append("  Sms: ").Append(Sms).Append("\n");
            sb.Append("  TemplatedEmail: ").Append(TemplatedEmail).Append("\n");
            sb.Append("  Websocket: ").Append(Websocket).Append("\n");
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
