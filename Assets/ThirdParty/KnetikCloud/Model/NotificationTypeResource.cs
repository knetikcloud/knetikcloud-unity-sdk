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
    
    
    public class NotificationTypeResource
    {
        /// <summary>
        /// The date the type was created, as a unix timestamp in seconds
        /// </summary>
        /// <value>The date the type was created, as a unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// Whether the email body should be resolved. If true, the external email delivery system will be expected to handle the templating (Mandrill/Mailchimp). default: false
        /// </summary>
        /// <value>Whether the email body should be resolved. If true, the external email delivery system will be expected to handle the templating (Mandrill/Mailchimp). default: false</value>
        [JsonProperty(PropertyName = "email_body_template_external")]
        public bool? EmailBodyTemplateExternal;

        /// <summary>
        /// The id of a message template to resolve the email body. If null, no websocket message wil be sent
        /// </summary>
        /// <value>The id of a message template to resolve the email body. If null, no websocket message wil be sent</value>
        [JsonProperty(PropertyName = "email_body_template_id")]
        public string EmailBodyTemplateId;

        /// <summary>
        /// The id of a message template to resolve the email subject. If null, no websocket message wil be sent
        /// </summary>
        /// <value>The id of a message template to resolve the email subject. If null, no websocket message wil be sent</value>
        [JsonProperty(PropertyName = "email_subject_template_id")]
        public string EmailSubjectTemplateId;

        /// <summary>
        /// The id of the notification type. Default: random
        /// </summary>
        /// <value>The id of the notification type. Default: random</value>
        [JsonProperty(PropertyName = "id")]
        public string Id;

        /// <summary>
        /// The name of the notification type
        /// </summary>
        /// <value>The name of the notification type</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The id of a message template to resolve the SMS message. If null, no sms message wil be sent
        /// </summary>
        /// <value>The id of a message template to resolve the SMS message. If null, no sms message wil be sent</value>
        [JsonProperty(PropertyName = "sms_template_id")]
        public string SmsTemplateId;

        /// <summary>
        /// The date the type was last updated, as a unix timestamp in seconds
        /// </summary>
        /// <value>The date the type was last updated, as a unix timestamp in seconds</value>
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
            sb.Append("class NotificationTypeResource {\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  EmailBodyTemplateExternal: ").Append(EmailBodyTemplateExternal).Append("\n");
            sb.Append("  EmailBodyTemplateId: ").Append(EmailBodyTemplateId).Append("\n");
            sb.Append("  EmailSubjectTemplateId: ").Append(EmailSubjectTemplateId).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  SmsTemplateId: ").Append(SmsTemplateId).Append("\n");
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
