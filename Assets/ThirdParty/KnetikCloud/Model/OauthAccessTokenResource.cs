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
    
    
    public class OauthAccessTokenResource
    {
        /// <summary>
        /// The key of the client assosciated with the token
        /// </summary>
        /// <value>The key of the client assosciated with the token</value>
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId;

        /// <summary>
        /// The token.  Not shown in list view
        /// </summary>
        /// <value>The token.  Not shown in list view</value>
        [JsonProperty(PropertyName = "token")]
        public string Token;

        /// <summary>
        /// The username of the user associated with the token
        /// </summary>
        /// <value>The username of the user associated with the token</value>
        [JsonProperty(PropertyName = "username")]
        public string Username;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OauthAccessTokenResource {\n");
            sb.Append("  ClientId: ").Append(ClientId).Append("\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
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
