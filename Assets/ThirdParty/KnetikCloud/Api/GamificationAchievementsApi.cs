using System;
using System.Collections.Generic;
using com.knetikcloud.Model;
using KnetikUnity.Client;
using KnetikUnity.Events;
using KnetikUnity.Exceptions;
using KnetikUnity.Utils;

using Object = System.Object;
using Version = com.knetikcloud.Model.Version;

namespace com.knetikcloud.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IGamificationAchievementsApi
    {
        AchievementDefinitionResource CreateAchievementData { get; }

        /// <summary>
        /// Create a new achievement definition If the definition contains a trigger event name, a BRE rule is created, so that tracking logic is executed when the triggering event occurs. If no trigger event name is specified, the user&#39;s achievement status must manually be updated via the API. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="achievement">The achievement definition</param>
        void CreateAchievement(AchievementDefinitionResource achievement);

        TemplateResource CreateAchievementTemplateData { get; }

        /// <summary>
        /// Create an achievement template Achievement templates define a type of achievement and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="template">The achievement template to be created</param>
        void CreateAchievementTemplate(TemplateResource template);

        

        /// <summary>
        /// Delete an achievement definition Will also disable the associated generated rule, if any. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        void DeleteAchievement(string name);

        

        /// <summary>
        /// Delete an achievement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteAchievementTemplate(string id, string cascade);

        AchievementDefinitionResource GetAchievementData { get; }

        /// <summary>
        /// Get a single achievement definition &lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN or ACHIEVEMENTS_USER
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        void GetAchievement(string name);

        TemplateResource GetAchievementTemplateData { get; }

        /// <summary>
        /// Get a single achievement template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetAchievementTemplate(string id);

        PageResourceTemplateResource GetAchievementTemplatesData { get; }

        /// <summary>
        /// List and search achievement templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetAchievementTemplates(int? size, int? page, string order);

        List<BreTriggerResource> GetAchievementTriggersData { get; }

        /// <summary>
        /// Get the list of triggers that can be used to trigger an achievement progress update &lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        void GetAchievementTriggers();

        PageResourceAchievementDefinitionResource GetAchievementsData { get; }

        /// <summary>
        /// Get all achievement definitions in the system &lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN or ACHIEVEMENTS_USER
        /// </summary>
        /// <param name="filterTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterName">Filter for achievements whose name contains a string</param>
        /// <param name="filterHidden">Filter for achievements that are hidden or not</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <param name="filterDerived">Filter for achievements that are derived from other services</param>
        void GetAchievements(string filterTagset, string filterName, bool? filterHidden, int? size, int? page, string order, bool? filterDerived);

        List<AchievementDefinitionResource> GetDerivedAchievementsData { get; }

        /// <summary>
        /// Get a list of derived achievements Used by other services that depend on achievements.  &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="name">The name of the derived achievement</param>
        void GetDerivedAchievements(string name);

        UserAchievementGroupResource GetUserAchievementProgressData { get; }

        /// <summary>
        /// Retrieve progress on a given achievement for a given user Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="achievementName">The achievement&#39;s name</param>
        void GetUserAchievementProgress(int? userId, string achievementName);

        PageResourceUserAchievementGroupResource GetUserAchievementsProgressData { get; }

        /// <summary>
        /// Retrieve progress on achievements for a given user Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param>
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUserAchievementsProgress(int? userId, bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page);

        PageResourceUserAchievementGroupResource GetUsersAchievementProgressData { get; }

        /// <summary>
        /// Retrieve progress on a given achievement for all users Assets will not be filled in on the resources returned. Use &#39;Get single achievement progress for user&#39; to retrieve the full resource with assets for a given user as needed. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="achievementName">The achievement&#39;s name</param>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param>
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsersAchievementProgress(string achievementName, bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page);

        PageResourceUserAchievementGroupResource GetUsersAchievementsProgressData { get; }

        /// <summary>
        /// Retrieve progress on achievements for all users Assets will not be filled in on the resources returned. Use &#39;Get single achievement progress for user&#39; to retrieve the full resource with assets for a given user as needed. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param>
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsersAchievementsProgress(bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page);

        UserAchievementGroupResource IncrementAchievementProgressData { get; }

        /// <summary>
        /// Increment an achievement progress record for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated and the provided value added to the existing progress. May be negative. If progress meets or exceeds the achievement&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="achievementName">The achievement&#39;s name</param>
        /// <param name="progress">The amount to add to the progress value</param>
        void IncrementAchievementProgress(int? userId, string achievementName, IntWrapper progress);

        UserAchievementGroupResource SetAchievementProgressData { get; }

        /// <summary>
        /// Set an achievement progress record for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated and progress set to the provided value. If progress meets or exceeds the achievement&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="achievementName">The achievement&#39;s name</param>
        /// <param name="progress">The new progress value</param>
        void SetAchievementProgress(int? userId, string achievementName, IntWrapper progress);

        AchievementDefinitionResource UpdateAchievementData { get; }

        /// <summary>
        /// Update an achievement definition The existing generated rule, if any, will be deleted. A new rule will be created if a trigger event name is specified in the new version. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        /// <param name="achievement">The achievement definition</param>
        void UpdateAchievement(string name, AchievementDefinitionResource achievement);

        TemplateResource UpdateAchievementTemplateData { get; }

        /// <summary>
        /// Update an achievement template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template</param>
        void UpdateAchievementTemplate(string id, TemplateResource template);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class GamificationAchievementsApi : IGamificationAchievementsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateAchievementResponseContext;
        private DateTime mCreateAchievementStartTime;
        private readonly KnetikResponseContext mCreateAchievementTemplateResponseContext;
        private DateTime mCreateAchievementTemplateStartTime;
        private readonly KnetikResponseContext mDeleteAchievementResponseContext;
        private DateTime mDeleteAchievementStartTime;
        private readonly KnetikResponseContext mDeleteAchievementTemplateResponseContext;
        private DateTime mDeleteAchievementTemplateStartTime;
        private readonly KnetikResponseContext mGetAchievementResponseContext;
        private DateTime mGetAchievementStartTime;
        private readonly KnetikResponseContext mGetAchievementTemplateResponseContext;
        private DateTime mGetAchievementTemplateStartTime;
        private readonly KnetikResponseContext mGetAchievementTemplatesResponseContext;
        private DateTime mGetAchievementTemplatesStartTime;
        private readonly KnetikResponseContext mGetAchievementTriggersResponseContext;
        private DateTime mGetAchievementTriggersStartTime;
        private readonly KnetikResponseContext mGetAchievementsResponseContext;
        private DateTime mGetAchievementsStartTime;
        private readonly KnetikResponseContext mGetDerivedAchievementsResponseContext;
        private DateTime mGetDerivedAchievementsStartTime;
        private readonly KnetikResponseContext mGetUserAchievementProgressResponseContext;
        private DateTime mGetUserAchievementProgressStartTime;
        private readonly KnetikResponseContext mGetUserAchievementsProgressResponseContext;
        private DateTime mGetUserAchievementsProgressStartTime;
        private readonly KnetikResponseContext mGetUsersAchievementProgressResponseContext;
        private DateTime mGetUsersAchievementProgressStartTime;
        private readonly KnetikResponseContext mGetUsersAchievementsProgressResponseContext;
        private DateTime mGetUsersAchievementsProgressStartTime;
        private readonly KnetikResponseContext mIncrementAchievementProgressResponseContext;
        private DateTime mIncrementAchievementProgressStartTime;
        private readonly KnetikResponseContext mSetAchievementProgressResponseContext;
        private DateTime mSetAchievementProgressStartTime;
        private readonly KnetikResponseContext mUpdateAchievementResponseContext;
        private DateTime mUpdateAchievementStartTime;
        private readonly KnetikResponseContext mUpdateAchievementTemplateResponseContext;
        private DateTime mUpdateAchievementTemplateStartTime;

        public AchievementDefinitionResource CreateAchievementData { get; private set; }
        public delegate void CreateAchievementCompleteDelegate(long responseCode, AchievementDefinitionResource response);
        public CreateAchievementCompleteDelegate CreateAchievementComplete;

        public TemplateResource CreateAchievementTemplateData { get; private set; }
        public delegate void CreateAchievementTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateAchievementTemplateCompleteDelegate CreateAchievementTemplateComplete;

        public delegate void DeleteAchievementCompleteDelegate(long responseCode);
        public DeleteAchievementCompleteDelegate DeleteAchievementComplete;

        public delegate void DeleteAchievementTemplateCompleteDelegate(long responseCode);
        public DeleteAchievementTemplateCompleteDelegate DeleteAchievementTemplateComplete;

        public AchievementDefinitionResource GetAchievementData { get; private set; }
        public delegate void GetAchievementCompleteDelegate(long responseCode, AchievementDefinitionResource response);
        public GetAchievementCompleteDelegate GetAchievementComplete;

        public TemplateResource GetAchievementTemplateData { get; private set; }
        public delegate void GetAchievementTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetAchievementTemplateCompleteDelegate GetAchievementTemplateComplete;

        public PageResourceTemplateResource GetAchievementTemplatesData { get; private set; }
        public delegate void GetAchievementTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetAchievementTemplatesCompleteDelegate GetAchievementTemplatesComplete;

        public List<BreTriggerResource> GetAchievementTriggersData { get; private set; }
        public delegate void GetAchievementTriggersCompleteDelegate(long responseCode, List<BreTriggerResource> response);
        public GetAchievementTriggersCompleteDelegate GetAchievementTriggersComplete;

        public PageResourceAchievementDefinitionResource GetAchievementsData { get; private set; }
        public delegate void GetAchievementsCompleteDelegate(long responseCode, PageResourceAchievementDefinitionResource response);
        public GetAchievementsCompleteDelegate GetAchievementsComplete;

        public List<AchievementDefinitionResource> GetDerivedAchievementsData { get; private set; }
        public delegate void GetDerivedAchievementsCompleteDelegate(long responseCode, List<AchievementDefinitionResource> response);
        public GetDerivedAchievementsCompleteDelegate GetDerivedAchievementsComplete;

        public UserAchievementGroupResource GetUserAchievementProgressData { get; private set; }
        public delegate void GetUserAchievementProgressCompleteDelegate(long responseCode, UserAchievementGroupResource response);
        public GetUserAchievementProgressCompleteDelegate GetUserAchievementProgressComplete;

        public PageResourceUserAchievementGroupResource GetUserAchievementsProgressData { get; private set; }
        public delegate void GetUserAchievementsProgressCompleteDelegate(long responseCode, PageResourceUserAchievementGroupResource response);
        public GetUserAchievementsProgressCompleteDelegate GetUserAchievementsProgressComplete;

        public PageResourceUserAchievementGroupResource GetUsersAchievementProgressData { get; private set; }
        public delegate void GetUsersAchievementProgressCompleteDelegate(long responseCode, PageResourceUserAchievementGroupResource response);
        public GetUsersAchievementProgressCompleteDelegate GetUsersAchievementProgressComplete;

        public PageResourceUserAchievementGroupResource GetUsersAchievementsProgressData { get; private set; }
        public delegate void GetUsersAchievementsProgressCompleteDelegate(long responseCode, PageResourceUserAchievementGroupResource response);
        public GetUsersAchievementsProgressCompleteDelegate GetUsersAchievementsProgressComplete;

        public UserAchievementGroupResource IncrementAchievementProgressData { get; private set; }
        public delegate void IncrementAchievementProgressCompleteDelegate(long responseCode, UserAchievementGroupResource response);
        public IncrementAchievementProgressCompleteDelegate IncrementAchievementProgressComplete;

        public UserAchievementGroupResource SetAchievementProgressData { get; private set; }
        public delegate void SetAchievementProgressCompleteDelegate(long responseCode, UserAchievementGroupResource response);
        public SetAchievementProgressCompleteDelegate SetAchievementProgressComplete;

        public AchievementDefinitionResource UpdateAchievementData { get; private set; }
        public delegate void UpdateAchievementCompleteDelegate(long responseCode, AchievementDefinitionResource response);
        public UpdateAchievementCompleteDelegate UpdateAchievementComplete;

        public TemplateResource UpdateAchievementTemplateData { get; private set; }
        public delegate void UpdateAchievementTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateAchievementTemplateCompleteDelegate UpdateAchievementTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamificationAchievementsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GamificationAchievementsApi()
        {
            mCreateAchievementResponseContext = new KnetikResponseContext();
            mCreateAchievementResponseContext.ResponseReceived += OnCreateAchievementResponse;
            mCreateAchievementTemplateResponseContext = new KnetikResponseContext();
            mCreateAchievementTemplateResponseContext.ResponseReceived += OnCreateAchievementTemplateResponse;
            mDeleteAchievementResponseContext = new KnetikResponseContext();
            mDeleteAchievementResponseContext.ResponseReceived += OnDeleteAchievementResponse;
            mDeleteAchievementTemplateResponseContext = new KnetikResponseContext();
            mDeleteAchievementTemplateResponseContext.ResponseReceived += OnDeleteAchievementTemplateResponse;
            mGetAchievementResponseContext = new KnetikResponseContext();
            mGetAchievementResponseContext.ResponseReceived += OnGetAchievementResponse;
            mGetAchievementTemplateResponseContext = new KnetikResponseContext();
            mGetAchievementTemplateResponseContext.ResponseReceived += OnGetAchievementTemplateResponse;
            mGetAchievementTemplatesResponseContext = new KnetikResponseContext();
            mGetAchievementTemplatesResponseContext.ResponseReceived += OnGetAchievementTemplatesResponse;
            mGetAchievementTriggersResponseContext = new KnetikResponseContext();
            mGetAchievementTriggersResponseContext.ResponseReceived += OnGetAchievementTriggersResponse;
            mGetAchievementsResponseContext = new KnetikResponseContext();
            mGetAchievementsResponseContext.ResponseReceived += OnGetAchievementsResponse;
            mGetDerivedAchievementsResponseContext = new KnetikResponseContext();
            mGetDerivedAchievementsResponseContext.ResponseReceived += OnGetDerivedAchievementsResponse;
            mGetUserAchievementProgressResponseContext = new KnetikResponseContext();
            mGetUserAchievementProgressResponseContext.ResponseReceived += OnGetUserAchievementProgressResponse;
            mGetUserAchievementsProgressResponseContext = new KnetikResponseContext();
            mGetUserAchievementsProgressResponseContext.ResponseReceived += OnGetUserAchievementsProgressResponse;
            mGetUsersAchievementProgressResponseContext = new KnetikResponseContext();
            mGetUsersAchievementProgressResponseContext.ResponseReceived += OnGetUsersAchievementProgressResponse;
            mGetUsersAchievementsProgressResponseContext = new KnetikResponseContext();
            mGetUsersAchievementsProgressResponseContext.ResponseReceived += OnGetUsersAchievementsProgressResponse;
            mIncrementAchievementProgressResponseContext = new KnetikResponseContext();
            mIncrementAchievementProgressResponseContext.ResponseReceived += OnIncrementAchievementProgressResponse;
            mSetAchievementProgressResponseContext = new KnetikResponseContext();
            mSetAchievementProgressResponseContext.ResponseReceived += OnSetAchievementProgressResponse;
            mUpdateAchievementResponseContext = new KnetikResponseContext();
            mUpdateAchievementResponseContext.ResponseReceived += OnUpdateAchievementResponse;
            mUpdateAchievementTemplateResponseContext = new KnetikResponseContext();
            mUpdateAchievementTemplateResponseContext.ResponseReceived += OnUpdateAchievementTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a new achievement definition If the definition contains a trigger event name, a BRE rule is created, so that tracking logic is executed when the triggering event occurs. If no trigger event name is specified, the user&#39;s achievement status must manually be updated via the API. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="achievement">The achievement definition</param>
        public void CreateAchievement(AchievementDefinitionResource achievement)
        {
            
            mWebCallEvent.WebPath = "/achievements";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(achievement); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateAchievementStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateAchievementResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateAchievementStartTime, "CreateAchievement", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateAchievementResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateAchievement: " + response.Error);
            }

            CreateAchievementData = (AchievementDefinitionResource) KnetikClient.Deserialize(response.Content, typeof(AchievementDefinitionResource), response.Headers);
            KnetikLogger.LogResponse(mCreateAchievementStartTime, "CreateAchievement", string.Format("Response received successfully:\n{0}", CreateAchievementData));

            if (CreateAchievementComplete != null)
            {
                CreateAchievementComplete(response.ResponseCode, CreateAchievementData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create an achievement template Achievement templates define a type of achievement and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="template">The achievement template to be created</param>
        public void CreateAchievementTemplate(TemplateResource template)
        {
            
            mWebCallEvent.WebPath = "/achievements/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(template); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateAchievementTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateAchievementTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateAchievementTemplateStartTime, "CreateAchievementTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateAchievementTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateAchievementTemplate: " + response.Error);
            }

            CreateAchievementTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateAchievementTemplateStartTime, "CreateAchievementTemplate", string.Format("Response received successfully:\n{0}", CreateAchievementTemplateData));

            if (CreateAchievementTemplateComplete != null)
            {
                CreateAchievementTemplateComplete(response.ResponseCode, CreateAchievementTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an achievement definition Will also disable the associated generated rule, if any. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        public void DeleteAchievement(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling DeleteAchievement");
            }
            
            mWebCallEvent.WebPath = "/achievements/{name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteAchievementStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteAchievementResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteAchievementStartTime, "DeleteAchievement", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteAchievementResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteAchievement: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteAchievementStartTime, "DeleteAchievement", "Response received successfully.");
            if (DeleteAchievementComplete != null)
            {
                DeleteAchievementComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an achievement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteAchievementTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteAchievementTemplate");
            }
            
            mWebCallEvent.WebPath = "/achievements/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (cascade != null)
            {
                mWebCallEvent.QueryParams["cascade"] = KnetikClient.ParameterToString(cascade);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteAchievementTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteAchievementTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteAchievementTemplateStartTime, "DeleteAchievementTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteAchievementTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteAchievementTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteAchievementTemplateStartTime, "DeleteAchievementTemplate", "Response received successfully.");
            if (DeleteAchievementTemplateComplete != null)
            {
                DeleteAchievementTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single achievement definition &lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN or ACHIEVEMENTS_USER
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        public void GetAchievement(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetAchievement");
            }
            
            mWebCallEvent.WebPath = "/achievements/{name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetAchievementStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetAchievementResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetAchievementStartTime, "GetAchievement", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetAchievementResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetAchievement: " + response.Error);
            }

            GetAchievementData = (AchievementDefinitionResource) KnetikClient.Deserialize(response.Content, typeof(AchievementDefinitionResource), response.Headers);
            KnetikLogger.LogResponse(mGetAchievementStartTime, "GetAchievement", string.Format("Response received successfully:\n{0}", GetAchievementData));

            if (GetAchievementComplete != null)
            {
                GetAchievementComplete(response.ResponseCode, GetAchievementData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single achievement template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetAchievementTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetAchievementTemplate");
            }
            
            mWebCallEvent.WebPath = "/achievements/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetAchievementTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetAchievementTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetAchievementTemplateStartTime, "GetAchievementTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetAchievementTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetAchievementTemplate: " + response.Error);
            }

            GetAchievementTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetAchievementTemplateStartTime, "GetAchievementTemplate", string.Format("Response received successfully:\n{0}", GetAchievementTemplateData));

            if (GetAchievementTemplateComplete != null)
            {
                GetAchievementTemplateComplete(response.ResponseCode, GetAchievementTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search achievement templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetAchievementTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/achievements/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (order != null)
            {
                mWebCallEvent.QueryParams["order"] = KnetikClient.ParameterToString(order);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetAchievementTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetAchievementTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetAchievementTemplatesStartTime, "GetAchievementTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetAchievementTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetAchievementTemplates: " + response.Error);
            }

            GetAchievementTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetAchievementTemplatesStartTime, "GetAchievementTemplates", string.Format("Response received successfully:\n{0}", GetAchievementTemplatesData));

            if (GetAchievementTemplatesComplete != null)
            {
                GetAchievementTemplatesComplete(response.ResponseCode, GetAchievementTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get the list of triggers that can be used to trigger an achievement progress update &lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        public void GetAchievementTriggers()
        {
            
            mWebCallEvent.WebPath = "/achievements/triggers";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetAchievementTriggersStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetAchievementTriggersResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetAchievementTriggersStartTime, "GetAchievementTriggers", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetAchievementTriggersResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetAchievementTriggers: " + response.Error);
            }

            GetAchievementTriggersData = (List<BreTriggerResource>) KnetikClient.Deserialize(response.Content, typeof(List<BreTriggerResource>), response.Headers);
            KnetikLogger.LogResponse(mGetAchievementTriggersStartTime, "GetAchievementTriggers", string.Format("Response received successfully:\n{0}", GetAchievementTriggersData));

            if (GetAchievementTriggersComplete != null)
            {
                GetAchievementTriggersComplete(response.ResponseCode, GetAchievementTriggersData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get all achievement definitions in the system &lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN or ACHIEVEMENTS_USER
        /// </summary>
        /// <param name="filterTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterName">Filter for achievements whose name contains a string</param>
        /// <param name="filterHidden">Filter for achievements that are hidden or not</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <param name="filterDerived">Filter for achievements that are derived from other services</param>
        public void GetAchievements(string filterTagset, string filterName, bool? filterHidden, int? size, int? page, string order, bool? filterDerived)
        {
            
            mWebCallEvent.WebPath = "/achievements";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterTagset != null)
            {
                mWebCallEvent.QueryParams["filter_tagset"] = KnetikClient.ParameterToString(filterTagset);
            }

            if (filterName != null)
            {
                mWebCallEvent.QueryParams["filter_name"] = KnetikClient.ParameterToString(filterName);
            }

            if (filterHidden != null)
            {
                mWebCallEvent.QueryParams["filter_hidden"] = KnetikClient.ParameterToString(filterHidden);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (order != null)
            {
                mWebCallEvent.QueryParams["order"] = KnetikClient.ParameterToString(order);
            }

            if (filterDerived != null)
            {
                mWebCallEvent.QueryParams["filter_derived"] = KnetikClient.ParameterToString(filterDerived);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetAchievementsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetAchievementsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetAchievementsStartTime, "GetAchievements", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetAchievementsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetAchievements: " + response.Error);
            }

            GetAchievementsData = (PageResourceAchievementDefinitionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceAchievementDefinitionResource), response.Headers);
            KnetikLogger.LogResponse(mGetAchievementsStartTime, "GetAchievements", string.Format("Response received successfully:\n{0}", GetAchievementsData));

            if (GetAchievementsComplete != null)
            {
                GetAchievementsComplete(response.ResponseCode, GetAchievementsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a list of derived achievements Used by other services that depend on achievements.  &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="name">The name of the derived achievement</param>
        public void GetDerivedAchievements(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetDerivedAchievements");
            }
            
            mWebCallEvent.WebPath = "/achievements/derived/{name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetDerivedAchievementsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetDerivedAchievementsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetDerivedAchievementsStartTime, "GetDerivedAchievements", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetDerivedAchievementsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetDerivedAchievements: " + response.Error);
            }

            GetDerivedAchievementsData = (List<AchievementDefinitionResource>) KnetikClient.Deserialize(response.Content, typeof(List<AchievementDefinitionResource>), response.Headers);
            KnetikLogger.LogResponse(mGetDerivedAchievementsStartTime, "GetDerivedAchievements", string.Format("Response received successfully:\n{0}", GetDerivedAchievementsData));

            if (GetDerivedAchievementsComplete != null)
            {
                GetDerivedAchievementsComplete(response.ResponseCode, GetDerivedAchievementsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve progress on a given achievement for a given user Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="achievementName">The achievement&#39;s name</param>
        public void GetUserAchievementProgress(int? userId, string achievementName)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserAchievementProgress");
            }
            // verify the required parameter 'achievementName' is set
            if (achievementName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'achievementName' when calling GetUserAchievementProgress");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/achievements/{achievement_name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "achievement_name" + "}", KnetikClient.ParameterToString(achievementName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUserAchievementProgressStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserAchievementProgressResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserAchievementProgressStartTime, "GetUserAchievementProgress", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserAchievementProgressResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserAchievementProgress: " + response.Error);
            }

            GetUserAchievementProgressData = (UserAchievementGroupResource) KnetikClient.Deserialize(response.Content, typeof(UserAchievementGroupResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserAchievementProgressStartTime, "GetUserAchievementProgress", string.Format("Response received successfully:\n{0}", GetUserAchievementProgressData));

            if (GetUserAchievementProgressComplete != null)
            {
                GetUserAchievementProgressComplete(response.ResponseCode, GetUserAchievementProgressData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve progress on achievements for a given user Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param>
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetUserAchievementsProgress(int? userId, bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserAchievementsProgress");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/achievements";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterAchievementDerived != null)
            {
                mWebCallEvent.QueryParams["filter_achievement_derived"] = KnetikClient.ParameterToString(filterAchievementDerived);
            }

            if (filterAchievementTagset != null)
            {
                mWebCallEvent.QueryParams["filter_achievement_tagset"] = KnetikClient.ParameterToString(filterAchievementTagset);
            }

            if (filterAchievementName != null)
            {
                mWebCallEvent.QueryParams["filter_achievement_name"] = KnetikClient.ParameterToString(filterAchievementName);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUserAchievementsProgressStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserAchievementsProgressResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserAchievementsProgressStartTime, "GetUserAchievementsProgress", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserAchievementsProgressResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserAchievementsProgress: " + response.Error);
            }

            GetUserAchievementsProgressData = (PageResourceUserAchievementGroupResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserAchievementGroupResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserAchievementsProgressStartTime, "GetUserAchievementsProgress", string.Format("Response received successfully:\n{0}", GetUserAchievementsProgressData));

            if (GetUserAchievementsProgressComplete != null)
            {
                GetUserAchievementsProgressComplete(response.ResponseCode, GetUserAchievementsProgressData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve progress on a given achievement for all users Assets will not be filled in on the resources returned. Use &#39;Get single achievement progress for user&#39; to retrieve the full resource with assets for a given user as needed. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="achievementName">The achievement&#39;s name</param>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param>
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetUsersAchievementProgress(string achievementName, bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page)
        {
            // verify the required parameter 'achievementName' is set
            if (achievementName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'achievementName' when calling GetUsersAchievementProgress");
            }
            
            mWebCallEvent.WebPath = "/users/achievements/{achievement_name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "achievement_name" + "}", KnetikClient.ParameterToString(achievementName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterAchievementDerived != null)
            {
                mWebCallEvent.QueryParams["filter_achievement_derived"] = KnetikClient.ParameterToString(filterAchievementDerived);
            }

            if (filterAchievementTagset != null)
            {
                mWebCallEvent.QueryParams["filter_achievement_tagset"] = KnetikClient.ParameterToString(filterAchievementTagset);
            }

            if (filterAchievementName != null)
            {
                mWebCallEvent.QueryParams["filter_achievement_name"] = KnetikClient.ParameterToString(filterAchievementName);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUsersAchievementProgressStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUsersAchievementProgressResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUsersAchievementProgressStartTime, "GetUsersAchievementProgress", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUsersAchievementProgressResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUsersAchievementProgress: " + response.Error);
            }

            GetUsersAchievementProgressData = (PageResourceUserAchievementGroupResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserAchievementGroupResource), response.Headers);
            KnetikLogger.LogResponse(mGetUsersAchievementProgressStartTime, "GetUsersAchievementProgress", string.Format("Response received successfully:\n{0}", GetUsersAchievementProgressData));

            if (GetUsersAchievementProgressComplete != null)
            {
                GetUsersAchievementProgressComplete(response.ResponseCode, GetUsersAchievementProgressData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve progress on achievements for all users Assets will not be filled in on the resources returned. Use &#39;Get single achievement progress for user&#39; to retrieve the full resource with assets for a given user as needed. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param>
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetUsersAchievementsProgress(bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page)
        {
            
            mWebCallEvent.WebPath = "/users/achievements";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterAchievementDerived != null)
            {
                mWebCallEvent.QueryParams["filter_achievement_derived"] = KnetikClient.ParameterToString(filterAchievementDerived);
            }

            if (filterAchievementTagset != null)
            {
                mWebCallEvent.QueryParams["filter_achievement_tagset"] = KnetikClient.ParameterToString(filterAchievementTagset);
            }

            if (filterAchievementName != null)
            {
                mWebCallEvent.QueryParams["filter_achievement_name"] = KnetikClient.ParameterToString(filterAchievementName);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUsersAchievementsProgressStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUsersAchievementsProgressResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUsersAchievementsProgressStartTime, "GetUsersAchievementsProgress", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUsersAchievementsProgressResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUsersAchievementsProgress: " + response.Error);
            }

            GetUsersAchievementsProgressData = (PageResourceUserAchievementGroupResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserAchievementGroupResource), response.Headers);
            KnetikLogger.LogResponse(mGetUsersAchievementsProgressStartTime, "GetUsersAchievementsProgress", string.Format("Response received successfully:\n{0}", GetUsersAchievementsProgressData));

            if (GetUsersAchievementsProgressComplete != null)
            {
                GetUsersAchievementsProgressComplete(response.ResponseCode, GetUsersAchievementsProgressData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Increment an achievement progress record for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated and the provided value added to the existing progress. May be negative. If progress meets or exceeds the achievement&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="achievementName">The achievement&#39;s name</param>
        /// <param name="progress">The amount to add to the progress value</param>
        public void IncrementAchievementProgress(int? userId, string achievementName, IntWrapper progress)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling IncrementAchievementProgress");
            }
            // verify the required parameter 'achievementName' is set
            if (achievementName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'achievementName' when calling IncrementAchievementProgress");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/achievements/{achievement_name}/progress";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "achievement_name" + "}", KnetikClient.ParameterToString(achievementName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(progress); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mIncrementAchievementProgressStartTime = DateTime.Now;
            mWebCallEvent.Context = mIncrementAchievementProgressResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mIncrementAchievementProgressStartTime, "IncrementAchievementProgress", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnIncrementAchievementProgressResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling IncrementAchievementProgress: " + response.Error);
            }

            IncrementAchievementProgressData = (UserAchievementGroupResource) KnetikClient.Deserialize(response.Content, typeof(UserAchievementGroupResource), response.Headers);
            KnetikLogger.LogResponse(mIncrementAchievementProgressStartTime, "IncrementAchievementProgress", string.Format("Response received successfully:\n{0}", IncrementAchievementProgressData));

            if (IncrementAchievementProgressComplete != null)
            {
                IncrementAchievementProgressComplete(response.ResponseCode, IncrementAchievementProgressData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set an achievement progress record for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated and progress set to the provided value. If progress meets or exceeds the achievement&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="achievementName">The achievement&#39;s name</param>
        /// <param name="progress">The new progress value</param>
        public void SetAchievementProgress(int? userId, string achievementName, IntWrapper progress)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling SetAchievementProgress");
            }
            // verify the required parameter 'achievementName' is set
            if (achievementName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'achievementName' when calling SetAchievementProgress");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/achievements/{achievement_name}/progress";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "achievement_name" + "}", KnetikClient.ParameterToString(achievementName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(progress); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetAchievementProgressStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetAchievementProgressResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetAchievementProgressStartTime, "SetAchievementProgress", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetAchievementProgressResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetAchievementProgress: " + response.Error);
            }

            SetAchievementProgressData = (UserAchievementGroupResource) KnetikClient.Deserialize(response.Content, typeof(UserAchievementGroupResource), response.Headers);
            KnetikLogger.LogResponse(mSetAchievementProgressStartTime, "SetAchievementProgress", string.Format("Response received successfully:\n{0}", SetAchievementProgressData));

            if (SetAchievementProgressComplete != null)
            {
                SetAchievementProgressComplete(response.ResponseCode, SetAchievementProgressData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an achievement definition The existing generated rule, if any, will be deleted. A new rule will be created if a trigger event name is specified in the new version. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ACHIEVEMENTS_ADMIN
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        /// <param name="achievement">The achievement definition</param>
        public void UpdateAchievement(string name, AchievementDefinitionResource achievement)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling UpdateAchievement");
            }
            
            mWebCallEvent.WebPath = "/achievements/{name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(achievement); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateAchievementStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateAchievementResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateAchievementStartTime, "UpdateAchievement", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateAchievementResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateAchievement: " + response.Error);
            }

            UpdateAchievementData = (AchievementDefinitionResource) KnetikClient.Deserialize(response.Content, typeof(AchievementDefinitionResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateAchievementStartTime, "UpdateAchievement", string.Format("Response received successfully:\n{0}", UpdateAchievementData));

            if (UpdateAchievementComplete != null)
            {
                UpdateAchievementComplete(response.ResponseCode, UpdateAchievementData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an achievement template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template</param>
        public void UpdateAchievementTemplate(string id, TemplateResource template)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateAchievementTemplate");
            }
            
            mWebCallEvent.WebPath = "/achievements/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(template); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateAchievementTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateAchievementTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateAchievementTemplateStartTime, "UpdateAchievementTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateAchievementTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateAchievementTemplate: " + response.Error);
            }

            UpdateAchievementTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateAchievementTemplateStartTime, "UpdateAchievementTemplate", string.Format("Response received successfully:\n{0}", UpdateAchievementTemplateData));

            if (UpdateAchievementTemplateComplete != null)
            {
                UpdateAchievementTemplateComplete(response.ResponseCode, UpdateAchievementTemplateData);
            }
        }

    }
}
