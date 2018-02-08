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
    
    
    public class CoreChallengeActivitySettings
    {
        /// <summary>
        /// Whether the host can boot a user while the status is PLAYING. Null to inherit from activity
        /// </summary>
        /// <value>Whether the host can boot a user while the status is PLAYING. Null to inherit from activity</value>
        [JsonProperty(PropertyName = "boot_in_play")]
        public bool? BootInPlay;

        /// <summary>
        /// A custom address (url, ip or whatever is needed in your game) that users should connect to to play in this challenge rather than the usual game server. Max length: 255
        /// </summary>
        /// <value>A custom address (url, ip or whatever is needed in your game) that users should connect to to play in this challenge rather than the usual game server. Max length: 255</value>
        [JsonProperty(PropertyName = "custom_launch_address")]
        public string CustomLaunchAddress;

        /// <summary>
        /// Restriction for whether the host creating an occurrence can specify a custom launch address (such as their own ip address). Will override the challenge's custom_launch_address if they do. Null to inherit from activity
        /// </summary>
        /// <value>Restriction for whether the host creating an occurrence can specify a custom launch address (such as their own ip address). Will override the challenge's custom_launch_address if they do. Null to inherit from activity</value>
        [JsonProperty(PropertyName = "custom_launch_address_allowed")]
        public bool? CustomLaunchAddressAllowed;

        /// <summary>
        /// Restriction for who can host an occurrence. admin disallows regular users, player means the user must also be a player in the occurrence if not admin, non-player means the user has the option to host without being a player. Null to inherit
        /// </summary>
        /// <value>Restriction for who can host an occurrence. admin disallows regular users, player means the user must also be a player in the occurrence if not admin, non-player means the user has the option to host without being a player. Null to inherit</value>
        [JsonProperty(PropertyName = "host_option")]
        public string HostOption;

        /// <summary>
        /// Restriction for whether the host has control of the status once the game launches. If false they can only manage the game before (when setup and open). Max length: 255. Null to inherit from activity
        /// </summary>
        /// <value>Restriction for whether the host has control of the status once the game launches. If false they can only manage the game before (when setup and open). Max length: 255. Null to inherit from activity</value>
        [JsonProperty(PropertyName = "host_status_control")]
        public bool? HostStatusControl;

        /// <summary>
        /// Whether users can join while the status is PLAYING. Null to inherit from activity
        /// </summary>
        /// <value>Whether users can join while the status is PLAYING. Null to inherit from activity</value>
        [JsonProperty(PropertyName = "join_in_play")]
        public bool? JoinInPlay;

        /// <summary>
        /// Whether users can leave while the status is PLAYING. Null to inherit from activity
        /// </summary>
        /// <value>Whether users can leave while the status is PLAYING. Null to inherit from activity</value>
        [JsonProperty(PropertyName = "leave_in_play")]
        public bool? LeaveInPlay;

        /// <summary>
        /// The maximum number of players the game can hold. Null to inherit from activity
        /// </summary>
        /// <value>The maximum number of players the game can hold. Null to inherit from activity</value>
        [JsonProperty(PropertyName = "max_players")]
        public int? MaxPlayers;

        /// <summary>
        /// The minimum number of players the game can hold. Null to inherit from activity
        /// </summary>
        /// <value>The minimum number of players the game can hold. Null to inherit from activity</value>
        [JsonProperty(PropertyName = "min_players")]
        public int? MinPlayers;

        /// <summary>
        /// Restriction for who is able to report game end and results. Admin is always able to send results as well. Null to inherit from activity
        /// </summary>
        /// <value>Restriction for who is able to report game end and results. Admin is always able to send results as well. Null to inherit from activity</value>
        [JsonProperty(PropertyName = "results_trust")]
        public string ResultsTrust;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CoreChallengeActivitySettings {\n");
            sb.Append("  BootInPlay: ").Append(BootInPlay).Append("\n");
            sb.Append("  CustomLaunchAddress: ").Append(CustomLaunchAddress).Append("\n");
            sb.Append("  CustomLaunchAddressAllowed: ").Append(CustomLaunchAddressAllowed).Append("\n");
            sb.Append("  HostOption: ").Append(HostOption).Append("\n");
            sb.Append("  HostStatusControl: ").Append(HostStatusControl).Append("\n");
            sb.Append("  JoinInPlay: ").Append(JoinInPlay).Append("\n");
            sb.Append("  LeaveInPlay: ").Append(LeaveInPlay).Append("\n");
            sb.Append("  MaxPlayers: ").Append(MaxPlayers).Append("\n");
            sb.Append("  MinPlayers: ").Append(MinPlayers).Append("\n");
            sb.Append("  ResultsTrust: ").Append(ResultsTrust).Append("\n");
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
