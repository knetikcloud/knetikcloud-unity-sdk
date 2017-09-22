using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <summary>
    /// A occurrence of an activity (the actual game for example). Used to track scores, participants, and provide settings
    /// </summary>
    public class ActivityOccurrenceResource
    {
        /// <summary>
        /// The id of the activity
        /// </summary>
        /// <value>The id of the activity</value>
        [JsonProperty(PropertyName = "activity_id")]
        public long? ActivityId { get; set; }

        /// <summary>
        /// The id of the challenge activity (as part of the event, required if eventId set)
        /// </summary>
        /// <value>The id of the challenge activity (as part of the event, required if eventId set)</value>
        [JsonProperty(PropertyName = "challenge_activity_id")]
        public long? ChallengeActivityId { get; set; }

        /// <summary>
        /// The date this occurrence was created, unix timestamp in seconds
        /// </summary>
        /// <value>The date this occurrence was created, unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate { get; set; }

        /// <summary>
        /// The entitlement item required to enter the occurrence. Required if not part of an event. Must come from the set of entitlement items listed in the activity
        /// </summary>
        /// <value>The entitlement item required to enter the occurrence. Required if not part of an event. Must come from the set of entitlement items listed in the activity</value>
        [JsonProperty(PropertyName = "entitlement")]
        public ActivityEntitlementResource Entitlement { get; set; }

        /// <summary>
        /// The id of the event
        /// </summary>
        /// <value>The id of the event</value>
        [JsonProperty(PropertyName = "event_id")]
        public long? EventId { get; set; }

        /// <summary>
        /// The id of the activity occurrence
        /// </summary>
        /// <value>The id of the activity occurrence</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

        /// <summary>
        /// Indicate if the rewards have been given out already
        /// </summary>
        /// <value>Indicate if the rewards have been given out already</value>
        [JsonProperty(PropertyName = "reward_status")]
        public string RewardStatus { get; set; }

        /// <summary>
        /// The values selected from the available settings defined for the activity. Ex: difficulty: hard. Can be left out if the activity is played during an event and the settings are already set at the event level. Ex: every monday, difficulty: hard, number of questions: 10, category: sport. Otherwise, the set must exactly match those of the activity.
        /// </summary>
        /// <value>The values selected from the available settings defined for the activity. Ex: difficulty: hard. Can be left out if the activity is played during an event and the settings are already set at the event level. Ex: every monday, difficulty: hard, number of questions: 10, category: sport. Otherwise, the set must exactly match those of the activity.</value>
        [JsonProperty(PropertyName = "settings")]
        public List<SelectedSettingResource> Settings { get; set; }

        /// <summary>
        /// Whether this occurrence will be ran as a simulation. Simulations will not be rewarded. Useful for bot play or trials
        /// </summary>
        /// <value>Whether this occurrence will be ran as a simulation. Simulations will not be rewarded. Useful for bot play or trials</value>
        [JsonProperty(PropertyName = "simulated")]
        public bool? Simulated { get; set; }

        /// <summary>
        /// The date this occurrence was started, unix timestamp in seconds. null if not yet started
        /// </summary>
        /// <value>The date this occurrence was started, unix timestamp in seconds. null if not yet started</value>
        [JsonProperty(PropertyName = "start_date")]
        public long? StartDate { get; set; }

        /// <summary>
        /// The current status of the occurrence (default: OPEN)
        /// </summary>
        /// <value>The current status of the occurrence (default: OPEN)</value>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The date this occurrence was last updated, unix timestamp in seconds
        /// </summary>
        /// <value>The date this occurrence was last updated, unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate { get; set; }

        /// <summary>
        /// The list of users participating in this occurrence. Can only be set directly with ACTIVITIES_ADMIN permission
        /// </summary>
        /// <value>The list of users participating in this occurrence. Can only be set directly with ACTIVITIES_ADMIN permission</value>
        [JsonProperty(PropertyName = "users")]
        public List<ActivityUserResource> Users { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ActivityOccurrenceResource {\n");
            sb.Append("  ActivityId: ").Append(ActivityId).Append("\n");
            sb.Append("  ChallengeActivityId: ").Append(ChallengeActivityId).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Entitlement: ").Append(Entitlement).Append("\n");
            sb.Append("  EventId: ").Append(EventId).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  RewardStatus: ").Append(RewardStatus).Append("\n");
            sb.Append("  Settings: ").Append(Settings).Append("\n");
            sb.Append("  Simulated: ").Append(Simulated).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  Users: ").Append(Users).Append("\n");
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
