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
    
    
    public class OAuth2Resource
    {
        /// <summary>
        /// The access token issued by the authorization server
        /// </summary>
        /// <value>The access token issued by the authorization server</value>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken;

        /// <summary>
        /// The lifetime in seconds of the access token
        /// </summary>
        /// <value>The lifetime in seconds of the access token</value>
        [JsonProperty(PropertyName = "expires_in")]
        public string ExpiresIn;

        /// <summary>
        /// The refresh token issued by the authorization server
        /// </summary>
        /// <value>The refresh token issued by the authorization server</value>
        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken;

        /// <summary>
        /// The scope of the access token. Currently these values can be ignored, as security defaults to roles and permissions
        /// </summary>
        /// <value>The scope of the access token. Currently these values can be ignored, as security defaults to roles and permissions</value>
        [JsonProperty(PropertyName = "scope")]
        public string Scope;

        /// <summary>
        /// The type of the token issued
        /// </summary>
        /// <value>The type of the token issued</value>
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OAuth2Resource {\n");
            sb.Append("  AccessToken: ").Append(AccessToken).Append("\n");
            sb.Append("  ExpiresIn: ").Append(ExpiresIn).Append("\n");
            sb.Append("  RefreshToken: ").Append(RefreshToken).Append("\n");
            sb.Append("  Scope: ").Append(Scope).Append("\n");
            sb.Append("  TokenType: ").Append(TokenType).Append("\n");
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
