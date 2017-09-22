using System;
using System.Collections.Generic;
using RestSharp;
using com.knetikcloud.Client;
using com.knetikcloud.Model;
using com.knetikcloud.Utils;
using UnityEngine;

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

        TemplateResource CreateAchievementTemplateData { get; }

        AchievementDefinitionResource GetAchievementData { get; }

        TemplateResource GetAchievementTemplateData { get; }

        PageResourceTemplateResource GetAchievementTemplatesData { get; }

        List<BreTriggerResource> GetAchievementTriggersData { get; }

        PageResourceAchievementDefinitionResource GetAchievementsData { get; }

        List<AchievementDefinitionResource> GetDerivedAchievementsData { get; }

        UserAchievementGroupResource GetUserAchievementProgressData { get; }

        PageResourceUserAchievementGroupResource GetUserAchievementsProgressData { get; }

        PageResourceUserAchievementGroupResource GetUsersAchievementProgressData { get; }

        PageResourceUserAchievementGroupResource GetUsersAchievementsProgressData { get; }

        UserAchievementGroupResource IncrementAchievementProgressData { get; }

        UserAchievementGroupResource SetAchievementProgressData { get; }

        AchievementDefinitionResource UpdateAchievementData { get; }

        TemplateResource UpdateAchievementTemplateData { get; }

        
        /// <summary>
        /// Create a new achievement definition If the definition contains a trigger event name, a BRE rule is created, so that tracking logic is executed when the triggering event occurs. If no trigger event name is specified, the user&#39;s achievement status must manually be updated via the API.
        /// </summary>
        /// <param name="achievement">The achievement definition</param>
        void CreateAchievement(AchievementDefinitionResource achievement);

        /// <summary>
        /// Create an achievement template Achievement templates define a type of achievement and the properties they have
        /// </summary>
        /// <param name="template">The achievement template to be created</param>
        void CreateAchievementTemplate(TemplateResource template);

        /// <summary>
        /// Delete an achievement definition Will also disable the associated generated rule, if any.
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        void DeleteAchievement(string name);

        /// <summary>
        /// Delete an achievement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteAchievementTemplate(string id, string cascade);

        /// <summary>
        /// Get a single achievement definition 
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        void GetAchievement(string name);

        /// <summary>
        /// Get a single achievement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetAchievementTemplate(string id);

        /// <summary>
        /// List and search achievement templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetAchievementTemplates(int? size, int? page, string order);

        /// <summary>
        /// Get the list of triggers that can be used to trigger an achievement progress update 
        /// </summary>
        void GetAchievementTriggers();

        /// <summary>
        /// Get all achievement definitions in the system 
        /// </summary>
        /// <param name="filterTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterName">Filter for achievements whose name contains a string</param>
        /// <param name="filterHidden">Filter for achievements that are hidden or not</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <param name="filterDerived">Filter for achievements that are derived from other services</param>
        void GetAchievements(string filterTagset, string filterName, bool? filterHidden, int? size, int? page, string order, bool? filterDerived);

        /// <summary>
        /// Get a list of derived achievements Used by other services that depend on achievements
        /// </summary>
        /// <param name="name">The name of the derived achievement</param>
        void GetDerivedAchievements(string name);

        /// <summary>
        /// Retrieve progress on a given achievement for a given user Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed.
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="achievementName">The achievement&#39;s name</param>
        void GetUserAchievementProgress(int? userId, string achievementName);

        /// <summary>
        /// Retrieve progress on achievements for a given user Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed.
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param>
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUserAchievementsProgress(int? userId, bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page);

        /// <summary>
        /// Retrieve progress on a given achievement for all users Assets will not be filled in on the resources returned. Use &#39;Get single achievement progress for user&#39; to retrieve the full resource with assets for a given user as needed.
        /// </summary>
        /// <param name="achievementName">The achievement&#39;s name</param>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param>
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsersAchievementProgress(string achievementName, bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page);

        /// <summary>
        /// Retrieve progress on achievements for all users Assets will not be filled in on the resources returned. Use &#39;Get single achievement progress for user&#39; to retrieve the full resource with assets for a given user as needed.
        /// </summary>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param>
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUsersAchievementsProgress(bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page);

        /// <summary>
        /// Increment an achievement progress record for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated and the provided value added to the existing progress. May be negative. If progress meets or exceeds the achievement&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;.
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="achievementName">The achievement&#39;s name</param>
        /// <param name="progress">The amount to add to the progress value</param>
        void IncrementAchievementProgress(int? userId, string achievementName, IntWrapper progress);

        /// <summary>
        /// Set an achievement progress record for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated and progress set to the provided value. If progress meets or exceeds the achievement&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;.
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="achievementName">The achievement&#39;s name</param>
        /// <param name="progress">The new progress value</param>
        void SetAchievementProgress(int? userId, string achievementName, IntWrapper progress);

        /// <summary>
        /// Update an achievement definition The existing generated rule, if any, will be deleted. A new rule will be created if a trigger event name is specified in the new version.
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        /// <param name="achievement">The achievement definition</param>
        void UpdateAchievement(string name, AchievementDefinitionResource achievement);

        /// <summary>
        /// Update an achievement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template</param>
        void UpdateAchievementTemplate(string id, TemplateResource template);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class GamificationAchievementsApi : IGamificationAchievementsApi
    {
        private readonly KnetikCoroutine mCreateAchievementCoroutine;
        private DateTime mCreateAchievementStartTime;
        private string mCreateAchievementPath;
        private readonly KnetikCoroutine mCreateAchievementTemplateCoroutine;
        private DateTime mCreateAchievementTemplateStartTime;
        private string mCreateAchievementTemplatePath;
        private readonly KnetikCoroutine mDeleteAchievementCoroutine;
        private DateTime mDeleteAchievementStartTime;
        private string mDeleteAchievementPath;
        private readonly KnetikCoroutine mDeleteAchievementTemplateCoroutine;
        private DateTime mDeleteAchievementTemplateStartTime;
        private string mDeleteAchievementTemplatePath;
        private readonly KnetikCoroutine mGetAchievementCoroutine;
        private DateTime mGetAchievementStartTime;
        private string mGetAchievementPath;
        private readonly KnetikCoroutine mGetAchievementTemplateCoroutine;
        private DateTime mGetAchievementTemplateStartTime;
        private string mGetAchievementTemplatePath;
        private readonly KnetikCoroutine mGetAchievementTemplatesCoroutine;
        private DateTime mGetAchievementTemplatesStartTime;
        private string mGetAchievementTemplatesPath;
        private readonly KnetikCoroutine mGetAchievementTriggersCoroutine;
        private DateTime mGetAchievementTriggersStartTime;
        private string mGetAchievementTriggersPath;
        private readonly KnetikCoroutine mGetAchievementsCoroutine;
        private DateTime mGetAchievementsStartTime;
        private string mGetAchievementsPath;
        private readonly KnetikCoroutine mGetDerivedAchievementsCoroutine;
        private DateTime mGetDerivedAchievementsStartTime;
        private string mGetDerivedAchievementsPath;
        private readonly KnetikCoroutine mGetUserAchievementProgressCoroutine;
        private DateTime mGetUserAchievementProgressStartTime;
        private string mGetUserAchievementProgressPath;
        private readonly KnetikCoroutine mGetUserAchievementsProgressCoroutine;
        private DateTime mGetUserAchievementsProgressStartTime;
        private string mGetUserAchievementsProgressPath;
        private readonly KnetikCoroutine mGetUsersAchievementProgressCoroutine;
        private DateTime mGetUsersAchievementProgressStartTime;
        private string mGetUsersAchievementProgressPath;
        private readonly KnetikCoroutine mGetUsersAchievementsProgressCoroutine;
        private DateTime mGetUsersAchievementsProgressStartTime;
        private string mGetUsersAchievementsProgressPath;
        private readonly KnetikCoroutine mIncrementAchievementProgressCoroutine;
        private DateTime mIncrementAchievementProgressStartTime;
        private string mIncrementAchievementProgressPath;
        private readonly KnetikCoroutine mSetAchievementProgressCoroutine;
        private DateTime mSetAchievementProgressStartTime;
        private string mSetAchievementProgressPath;
        private readonly KnetikCoroutine mUpdateAchievementCoroutine;
        private DateTime mUpdateAchievementStartTime;
        private string mUpdateAchievementPath;
        private readonly KnetikCoroutine mUpdateAchievementTemplateCoroutine;
        private DateTime mUpdateAchievementTemplateStartTime;
        private string mUpdateAchievementTemplatePath;

        public AchievementDefinitionResource CreateAchievementData { get; private set; }
        public delegate void CreateAchievementCompleteDelegate(AchievementDefinitionResource response);
        public CreateAchievementCompleteDelegate CreateAchievementComplete;

        public TemplateResource CreateAchievementTemplateData { get; private set; }
        public delegate void CreateAchievementTemplateCompleteDelegate(TemplateResource response);
        public CreateAchievementTemplateCompleteDelegate CreateAchievementTemplateComplete;

        public delegate void DeleteAchievementCompleteDelegate();
        public DeleteAchievementCompleteDelegate DeleteAchievementComplete;

        public delegate void DeleteAchievementTemplateCompleteDelegate();
        public DeleteAchievementTemplateCompleteDelegate DeleteAchievementTemplateComplete;

        public AchievementDefinitionResource GetAchievementData { get; private set; }
        public delegate void GetAchievementCompleteDelegate(AchievementDefinitionResource response);
        public GetAchievementCompleteDelegate GetAchievementComplete;

        public TemplateResource GetAchievementTemplateData { get; private set; }
        public delegate void GetAchievementTemplateCompleteDelegate(TemplateResource response);
        public GetAchievementTemplateCompleteDelegate GetAchievementTemplateComplete;

        public PageResourceTemplateResource GetAchievementTemplatesData { get; private set; }
        public delegate void GetAchievementTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetAchievementTemplatesCompleteDelegate GetAchievementTemplatesComplete;

        public List<BreTriggerResource> GetAchievementTriggersData { get; private set; }
        public delegate void GetAchievementTriggersCompleteDelegate(List<BreTriggerResource> response);
        public GetAchievementTriggersCompleteDelegate GetAchievementTriggersComplete;

        public PageResourceAchievementDefinitionResource GetAchievementsData { get; private set; }
        public delegate void GetAchievementsCompleteDelegate(PageResourceAchievementDefinitionResource response);
        public GetAchievementsCompleteDelegate GetAchievementsComplete;

        public List<AchievementDefinitionResource> GetDerivedAchievementsData { get; private set; }
        public delegate void GetDerivedAchievementsCompleteDelegate(List<AchievementDefinitionResource> response);
        public GetDerivedAchievementsCompleteDelegate GetDerivedAchievementsComplete;

        public UserAchievementGroupResource GetUserAchievementProgressData { get; private set; }
        public delegate void GetUserAchievementProgressCompleteDelegate(UserAchievementGroupResource response);
        public GetUserAchievementProgressCompleteDelegate GetUserAchievementProgressComplete;

        public PageResourceUserAchievementGroupResource GetUserAchievementsProgressData { get; private set; }
        public delegate void GetUserAchievementsProgressCompleteDelegate(PageResourceUserAchievementGroupResource response);
        public GetUserAchievementsProgressCompleteDelegate GetUserAchievementsProgressComplete;

        public PageResourceUserAchievementGroupResource GetUsersAchievementProgressData { get; private set; }
        public delegate void GetUsersAchievementProgressCompleteDelegate(PageResourceUserAchievementGroupResource response);
        public GetUsersAchievementProgressCompleteDelegate GetUsersAchievementProgressComplete;

        public PageResourceUserAchievementGroupResource GetUsersAchievementsProgressData { get; private set; }
        public delegate void GetUsersAchievementsProgressCompleteDelegate(PageResourceUserAchievementGroupResource response);
        public GetUsersAchievementsProgressCompleteDelegate GetUsersAchievementsProgressComplete;

        public UserAchievementGroupResource IncrementAchievementProgressData { get; private set; }
        public delegate void IncrementAchievementProgressCompleteDelegate(UserAchievementGroupResource response);
        public IncrementAchievementProgressCompleteDelegate IncrementAchievementProgressComplete;

        public UserAchievementGroupResource SetAchievementProgressData { get; private set; }
        public delegate void SetAchievementProgressCompleteDelegate(UserAchievementGroupResource response);
        public SetAchievementProgressCompleteDelegate SetAchievementProgressComplete;

        public AchievementDefinitionResource UpdateAchievementData { get; private set; }
        public delegate void UpdateAchievementCompleteDelegate(AchievementDefinitionResource response);
        public UpdateAchievementCompleteDelegate UpdateAchievementComplete;

        public TemplateResource UpdateAchievementTemplateData { get; private set; }
        public delegate void UpdateAchievementTemplateCompleteDelegate(TemplateResource response);
        public UpdateAchievementTemplateCompleteDelegate UpdateAchievementTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamificationAchievementsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GamificationAchievementsApi()
        {
            mCreateAchievementCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mCreateAchievementTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mDeleteAchievementCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mDeleteAchievementTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetAchievementCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetAchievementTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetAchievementTemplatesCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetAchievementTriggersCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetAchievementsCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetDerivedAchievementsCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetUserAchievementProgressCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetUserAchievementsProgressCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetUsersAchievementProgressCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetUsersAchievementsProgressCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mIncrementAchievementProgressCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mSetAchievementProgressCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateAchievementCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateAchievementTemplateCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
        /// <summary>
        /// Create a new achievement definition If the definition contains a trigger event name, a BRE rule is created, so that tracking logic is executed when the triggering event occurs. If no trigger event name is specified, the user&#39;s achievement status must manually be updated via the API.
        /// </summary>
        /// <param name="achievement">The achievement definition</param>
        public void CreateAchievement(AchievementDefinitionResource achievement)
        {
            
            mCreateAchievementPath = "/achievements";
            if (!string.IsNullOrEmpty(mCreateAchievementPath))
            {
                mCreateAchievementPath = mCreateAchievementPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(achievement); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateAchievementStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateAchievementStartTime, mCreateAchievementPath, "Sending server request...");

            // make the HTTP request
            mCreateAchievementCoroutine.ResponseReceived += CreateAchievementCallback;
            mCreateAchievementCoroutine.Start(mCreateAchievementPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateAchievementCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateAchievement: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateAchievement: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateAchievementData = (AchievementDefinitionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(AchievementDefinitionResource), response.Headers);
            KnetikLogger.LogResponse(mCreateAchievementStartTime, mCreateAchievementPath, string.Format("Response received successfully:\n{0}", CreateAchievementData.ToString()));

            if (CreateAchievementComplete != null)
            {
                CreateAchievementComplete(CreateAchievementData);
            }
        }
        /// <summary>
        /// Create an achievement template Achievement templates define a type of achievement and the properties they have
        /// </summary>
        /// <param name="template">The achievement template to be created</param>
        public void CreateAchievementTemplate(TemplateResource template)
        {
            
            mCreateAchievementTemplatePath = "/achievements/templates";
            if (!string.IsNullOrEmpty(mCreateAchievementTemplatePath))
            {
                mCreateAchievementTemplatePath = mCreateAchievementTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateAchievementTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateAchievementTemplateStartTime, mCreateAchievementTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateAchievementTemplateCoroutine.ResponseReceived += CreateAchievementTemplateCallback;
            mCreateAchievementTemplateCoroutine.Start(mCreateAchievementTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateAchievementTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateAchievementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateAchievementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateAchievementTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateAchievementTemplateStartTime, mCreateAchievementTemplatePath, string.Format("Response received successfully:\n{0}", CreateAchievementTemplateData.ToString()));

            if (CreateAchievementTemplateComplete != null)
            {
                CreateAchievementTemplateComplete(CreateAchievementTemplateData);
            }
        }
        /// <summary>
        /// Delete an achievement definition Will also disable the associated generated rule, if any.
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        public void DeleteAchievement(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling DeleteAchievement");
            }
            
            mDeleteAchievementPath = "/achievements/{name}";
            if (!string.IsNullOrEmpty(mDeleteAchievementPath))
            {
                mDeleteAchievementPath = mDeleteAchievementPath.Replace("{format}", "json");
            }
            mDeleteAchievementPath = mDeleteAchievementPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteAchievementStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteAchievementStartTime, mDeleteAchievementPath, "Sending server request...");

            // make the HTTP request
            mDeleteAchievementCoroutine.ResponseReceived += DeleteAchievementCallback;
            mDeleteAchievementCoroutine.Start(mDeleteAchievementPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteAchievementCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteAchievement: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteAchievement: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteAchievementStartTime, mDeleteAchievementPath, "Response received successfully.");
            if (DeleteAchievementComplete != null)
            {
                DeleteAchievementComplete();
            }
        }
        /// <summary>
        /// Delete an achievement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
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
            
            mDeleteAchievementTemplatePath = "/achievements/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteAchievementTemplatePath))
            {
                mDeleteAchievementTemplatePath = mDeleteAchievementTemplatePath.Replace("{format}", "json");
            }
            mDeleteAchievementTemplatePath = mDeleteAchievementTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteAchievementTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteAchievementTemplateStartTime, mDeleteAchievementTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteAchievementTemplateCoroutine.ResponseReceived += DeleteAchievementTemplateCallback;
            mDeleteAchievementTemplateCoroutine.Start(mDeleteAchievementTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteAchievementTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteAchievementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteAchievementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteAchievementTemplateStartTime, mDeleteAchievementTemplatePath, "Response received successfully.");
            if (DeleteAchievementTemplateComplete != null)
            {
                DeleteAchievementTemplateComplete();
            }
        }
        /// <summary>
        /// Get a single achievement definition 
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        public void GetAchievement(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetAchievement");
            }
            
            mGetAchievementPath = "/achievements/{name}";
            if (!string.IsNullOrEmpty(mGetAchievementPath))
            {
                mGetAchievementPath = mGetAchievementPath.Replace("{format}", "json");
            }
            mGetAchievementPath = mGetAchievementPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetAchievementStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetAchievementStartTime, mGetAchievementPath, "Sending server request...");

            // make the HTTP request
            mGetAchievementCoroutine.ResponseReceived += GetAchievementCallback;
            mGetAchievementCoroutine.Start(mGetAchievementPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetAchievementCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAchievement: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAchievement: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetAchievementData = (AchievementDefinitionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(AchievementDefinitionResource), response.Headers);
            KnetikLogger.LogResponse(mGetAchievementStartTime, mGetAchievementPath, string.Format("Response received successfully:\n{0}", GetAchievementData.ToString()));

            if (GetAchievementComplete != null)
            {
                GetAchievementComplete(GetAchievementData);
            }
        }
        /// <summary>
        /// Get a single achievement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetAchievementTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetAchievementTemplate");
            }
            
            mGetAchievementTemplatePath = "/achievements/templates/{id}";
            if (!string.IsNullOrEmpty(mGetAchievementTemplatePath))
            {
                mGetAchievementTemplatePath = mGetAchievementTemplatePath.Replace("{format}", "json");
            }
            mGetAchievementTemplatePath = mGetAchievementTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetAchievementTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetAchievementTemplateStartTime, mGetAchievementTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetAchievementTemplateCoroutine.ResponseReceived += GetAchievementTemplateCallback;
            mGetAchievementTemplateCoroutine.Start(mGetAchievementTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetAchievementTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAchievementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAchievementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetAchievementTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetAchievementTemplateStartTime, mGetAchievementTemplatePath, string.Format("Response received successfully:\n{0}", GetAchievementTemplateData.ToString()));

            if (GetAchievementTemplateComplete != null)
            {
                GetAchievementTemplateComplete(GetAchievementTemplateData);
            }
        }
        /// <summary>
        /// List and search achievement templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetAchievementTemplates(int? size, int? page, string order)
        {
            
            mGetAchievementTemplatesPath = "/achievements/templates";
            if (!string.IsNullOrEmpty(mGetAchievementTemplatesPath))
            {
                mGetAchievementTemplatesPath = mGetAchievementTemplatesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.DefaultClient.ParameterToString(order));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetAchievementTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetAchievementTemplatesStartTime, mGetAchievementTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetAchievementTemplatesCoroutine.ResponseReceived += GetAchievementTemplatesCallback;
            mGetAchievementTemplatesCoroutine.Start(mGetAchievementTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetAchievementTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAchievementTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAchievementTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetAchievementTemplatesData = (PageResourceTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetAchievementTemplatesStartTime, mGetAchievementTemplatesPath, string.Format("Response received successfully:\n{0}", GetAchievementTemplatesData.ToString()));

            if (GetAchievementTemplatesComplete != null)
            {
                GetAchievementTemplatesComplete(GetAchievementTemplatesData);
            }
        }
        /// <summary>
        /// Get the list of triggers that can be used to trigger an achievement progress update 
        /// </summary>
        public void GetAchievementTriggers()
        {
            
            mGetAchievementTriggersPath = "/achievements/triggers";
            if (!string.IsNullOrEmpty(mGetAchievementTriggersPath))
            {
                mGetAchievementTriggersPath = mGetAchievementTriggersPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetAchievementTriggersStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetAchievementTriggersStartTime, mGetAchievementTriggersPath, "Sending server request...");

            // make the HTTP request
            mGetAchievementTriggersCoroutine.ResponseReceived += GetAchievementTriggersCallback;
            mGetAchievementTriggersCoroutine.Start(mGetAchievementTriggersPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetAchievementTriggersCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAchievementTriggers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAchievementTriggers: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetAchievementTriggersData = (List<BreTriggerResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<BreTriggerResource>), response.Headers);
            KnetikLogger.LogResponse(mGetAchievementTriggersStartTime, mGetAchievementTriggersPath, string.Format("Response received successfully:\n{0}", GetAchievementTriggersData.ToString()));

            if (GetAchievementTriggersComplete != null)
            {
                GetAchievementTriggersComplete(GetAchievementTriggersData);
            }
        }
        /// <summary>
        /// Get all achievement definitions in the system 
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
            
            mGetAchievementsPath = "/achievements";
            if (!string.IsNullOrEmpty(mGetAchievementsPath))
            {
                mGetAchievementsPath = mGetAchievementsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.DefaultClient.ParameterToString(filterTagset));
            }

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.DefaultClient.ParameterToString(filterName));
            }

            if (filterHidden != null)
            {
                queryParams.Add("filter_hidden", KnetikClient.DefaultClient.ParameterToString(filterHidden));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.DefaultClient.ParameterToString(order));
            }

            if (filterDerived != null)
            {
                queryParams.Add("filter_derived", KnetikClient.DefaultClient.ParameterToString(filterDerived));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetAchievementsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetAchievementsStartTime, mGetAchievementsPath, "Sending server request...");

            // make the HTTP request
            mGetAchievementsCoroutine.ResponseReceived += GetAchievementsCallback;
            mGetAchievementsCoroutine.Start(mGetAchievementsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetAchievementsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAchievements: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAchievements: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetAchievementsData = (PageResourceAchievementDefinitionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceAchievementDefinitionResource), response.Headers);
            KnetikLogger.LogResponse(mGetAchievementsStartTime, mGetAchievementsPath, string.Format("Response received successfully:\n{0}", GetAchievementsData.ToString()));

            if (GetAchievementsComplete != null)
            {
                GetAchievementsComplete(GetAchievementsData);
            }
        }
        /// <summary>
        /// Get a list of derived achievements Used by other services that depend on achievements
        /// </summary>
        /// <param name="name">The name of the derived achievement</param>
        public void GetDerivedAchievements(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetDerivedAchievements");
            }
            
            mGetDerivedAchievementsPath = "/achievements/derived/{name}";
            if (!string.IsNullOrEmpty(mGetDerivedAchievementsPath))
            {
                mGetDerivedAchievementsPath = mGetDerivedAchievementsPath.Replace("{format}", "json");
            }
            mGetDerivedAchievementsPath = mGetDerivedAchievementsPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetDerivedAchievementsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetDerivedAchievementsStartTime, mGetDerivedAchievementsPath, "Sending server request...");

            // make the HTTP request
            mGetDerivedAchievementsCoroutine.ResponseReceived += GetDerivedAchievementsCallback;
            mGetDerivedAchievementsCoroutine.Start(mGetDerivedAchievementsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetDerivedAchievementsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDerivedAchievements: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDerivedAchievements: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetDerivedAchievementsData = (List<AchievementDefinitionResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<AchievementDefinitionResource>), response.Headers);
            KnetikLogger.LogResponse(mGetDerivedAchievementsStartTime, mGetDerivedAchievementsPath, string.Format("Response received successfully:\n{0}", GetDerivedAchievementsData.ToString()));

            if (GetDerivedAchievementsComplete != null)
            {
                GetDerivedAchievementsComplete(GetDerivedAchievementsData);
            }
        }
        /// <summary>
        /// Retrieve progress on a given achievement for a given user Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed.
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
            
            mGetUserAchievementProgressPath = "/users/{user_id}/achievements/{achievement_name}";
            if (!string.IsNullOrEmpty(mGetUserAchievementProgressPath))
            {
                mGetUserAchievementProgressPath = mGetUserAchievementProgressPath.Replace("{format}", "json");
            }
            mGetUserAchievementProgressPath = mGetUserAchievementProgressPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mGetUserAchievementProgressPath = mGetUserAchievementProgressPath.Replace("{" + "achievement_name" + "}", KnetikClient.DefaultClient.ParameterToString(achievementName));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserAchievementProgressStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserAchievementProgressStartTime, mGetUserAchievementProgressPath, "Sending server request...");

            // make the HTTP request
            mGetUserAchievementProgressCoroutine.ResponseReceived += GetUserAchievementProgressCallback;
            mGetUserAchievementProgressCoroutine.Start(mGetUserAchievementProgressPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserAchievementProgressCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserAchievementProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserAchievementProgress: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserAchievementProgressData = (UserAchievementGroupResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(UserAchievementGroupResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserAchievementProgressStartTime, mGetUserAchievementProgressPath, string.Format("Response received successfully:\n{0}", GetUserAchievementProgressData.ToString()));

            if (GetUserAchievementProgressComplete != null)
            {
                GetUserAchievementProgressComplete(GetUserAchievementProgressData);
            }
        }
        /// <summary>
        /// Retrieve progress on achievements for a given user Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed.
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
            
            mGetUserAchievementsProgressPath = "/users/{user_id}/achievements";
            if (!string.IsNullOrEmpty(mGetUserAchievementsProgressPath))
            {
                mGetUserAchievementsProgressPath = mGetUserAchievementsProgressPath.Replace("{format}", "json");
            }
            mGetUserAchievementsProgressPath = mGetUserAchievementsProgressPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterAchievementDerived != null)
            {
                queryParams.Add("filter_achievement_derived", KnetikClient.DefaultClient.ParameterToString(filterAchievementDerived));
            }

            if (filterAchievementTagset != null)
            {
                queryParams.Add("filter_achievement_tagset", KnetikClient.DefaultClient.ParameterToString(filterAchievementTagset));
            }

            if (filterAchievementName != null)
            {
                queryParams.Add("filter_achievement_name", KnetikClient.DefaultClient.ParameterToString(filterAchievementName));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserAchievementsProgressStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserAchievementsProgressStartTime, mGetUserAchievementsProgressPath, "Sending server request...");

            // make the HTTP request
            mGetUserAchievementsProgressCoroutine.ResponseReceived += GetUserAchievementsProgressCallback;
            mGetUserAchievementsProgressCoroutine.Start(mGetUserAchievementsProgressPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserAchievementsProgressCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserAchievementsProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserAchievementsProgress: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserAchievementsProgressData = (PageResourceUserAchievementGroupResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUserAchievementGroupResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserAchievementsProgressStartTime, mGetUserAchievementsProgressPath, string.Format("Response received successfully:\n{0}", GetUserAchievementsProgressData.ToString()));

            if (GetUserAchievementsProgressComplete != null)
            {
                GetUserAchievementsProgressComplete(GetUserAchievementsProgressData);
            }
        }
        /// <summary>
        /// Retrieve progress on a given achievement for all users Assets will not be filled in on the resources returned. Use &#39;Get single achievement progress for user&#39; to retrieve the full resource with assets for a given user as needed.
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
            
            mGetUsersAchievementProgressPath = "/users/achievements/{achievement_name}";
            if (!string.IsNullOrEmpty(mGetUsersAchievementProgressPath))
            {
                mGetUsersAchievementProgressPath = mGetUsersAchievementProgressPath.Replace("{format}", "json");
            }
            mGetUsersAchievementProgressPath = mGetUsersAchievementProgressPath.Replace("{" + "achievement_name" + "}", KnetikClient.DefaultClient.ParameterToString(achievementName));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterAchievementDerived != null)
            {
                queryParams.Add("filter_achievement_derived", KnetikClient.DefaultClient.ParameterToString(filterAchievementDerived));
            }

            if (filterAchievementTagset != null)
            {
                queryParams.Add("filter_achievement_tagset", KnetikClient.DefaultClient.ParameterToString(filterAchievementTagset));
            }

            if (filterAchievementName != null)
            {
                queryParams.Add("filter_achievement_name", KnetikClient.DefaultClient.ParameterToString(filterAchievementName));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUsersAchievementProgressStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUsersAchievementProgressStartTime, mGetUsersAchievementProgressPath, "Sending server request...");

            // make the HTTP request
            mGetUsersAchievementProgressCoroutine.ResponseReceived += GetUsersAchievementProgressCallback;
            mGetUsersAchievementProgressCoroutine.Start(mGetUsersAchievementProgressPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUsersAchievementProgressCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsersAchievementProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsersAchievementProgress: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUsersAchievementProgressData = (PageResourceUserAchievementGroupResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUserAchievementGroupResource), response.Headers);
            KnetikLogger.LogResponse(mGetUsersAchievementProgressStartTime, mGetUsersAchievementProgressPath, string.Format("Response received successfully:\n{0}", GetUsersAchievementProgressData.ToString()));

            if (GetUsersAchievementProgressComplete != null)
            {
                GetUsersAchievementProgressComplete(GetUsersAchievementProgressData);
            }
        }
        /// <summary>
        /// Retrieve progress on achievements for all users Assets will not be filled in on the resources returned. Use &#39;Get single achievement progress for user&#39; to retrieve the full resource with assets for a given user as needed.
        /// </summary>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param>
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetUsersAchievementsProgress(bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page)
        {
            
            mGetUsersAchievementsProgressPath = "/users/achievements";
            if (!string.IsNullOrEmpty(mGetUsersAchievementsProgressPath))
            {
                mGetUsersAchievementsProgressPath = mGetUsersAchievementsProgressPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterAchievementDerived != null)
            {
                queryParams.Add("filter_achievement_derived", KnetikClient.DefaultClient.ParameterToString(filterAchievementDerived));
            }

            if (filterAchievementTagset != null)
            {
                queryParams.Add("filter_achievement_tagset", KnetikClient.DefaultClient.ParameterToString(filterAchievementTagset));
            }

            if (filterAchievementName != null)
            {
                queryParams.Add("filter_achievement_name", KnetikClient.DefaultClient.ParameterToString(filterAchievementName));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUsersAchievementsProgressStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUsersAchievementsProgressStartTime, mGetUsersAchievementsProgressPath, "Sending server request...");

            // make the HTTP request
            mGetUsersAchievementsProgressCoroutine.ResponseReceived += GetUsersAchievementsProgressCallback;
            mGetUsersAchievementsProgressCoroutine.Start(mGetUsersAchievementsProgressPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUsersAchievementsProgressCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsersAchievementsProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUsersAchievementsProgress: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUsersAchievementsProgressData = (PageResourceUserAchievementGroupResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUserAchievementGroupResource), response.Headers);
            KnetikLogger.LogResponse(mGetUsersAchievementsProgressStartTime, mGetUsersAchievementsProgressPath, string.Format("Response received successfully:\n{0}", GetUsersAchievementsProgressData.ToString()));

            if (GetUsersAchievementsProgressComplete != null)
            {
                GetUsersAchievementsProgressComplete(GetUsersAchievementsProgressData);
            }
        }
        /// <summary>
        /// Increment an achievement progress record for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated and the provided value added to the existing progress. May be negative. If progress meets or exceeds the achievement&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;.
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
            
            mIncrementAchievementProgressPath = "/users/{user_id}/achievements/{achievement_name}/progress";
            if (!string.IsNullOrEmpty(mIncrementAchievementProgressPath))
            {
                mIncrementAchievementProgressPath = mIncrementAchievementProgressPath.Replace("{format}", "json");
            }
            mIncrementAchievementProgressPath = mIncrementAchievementProgressPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mIncrementAchievementProgressPath = mIncrementAchievementProgressPath.Replace("{" + "achievement_name" + "}", KnetikClient.DefaultClient.ParameterToString(achievementName));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(progress); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mIncrementAchievementProgressStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mIncrementAchievementProgressStartTime, mIncrementAchievementProgressPath, "Sending server request...");

            // make the HTTP request
            mIncrementAchievementProgressCoroutine.ResponseReceived += IncrementAchievementProgressCallback;
            mIncrementAchievementProgressCoroutine.Start(mIncrementAchievementProgressPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void IncrementAchievementProgressCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling IncrementAchievementProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling IncrementAchievementProgress: " + response.ErrorMessage, response.ErrorMessage);
            }

            IncrementAchievementProgressData = (UserAchievementGroupResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(UserAchievementGroupResource), response.Headers);
            KnetikLogger.LogResponse(mIncrementAchievementProgressStartTime, mIncrementAchievementProgressPath, string.Format("Response received successfully:\n{0}", IncrementAchievementProgressData.ToString()));

            if (IncrementAchievementProgressComplete != null)
            {
                IncrementAchievementProgressComplete(IncrementAchievementProgressData);
            }
        }
        /// <summary>
        /// Set an achievement progress record for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated and progress set to the provided value. If progress meets or exceeds the achievement&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;.
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
            
            mSetAchievementProgressPath = "/users/{user_id}/achievements/{achievement_name}/progress";
            if (!string.IsNullOrEmpty(mSetAchievementProgressPath))
            {
                mSetAchievementProgressPath = mSetAchievementProgressPath.Replace("{format}", "json");
            }
            mSetAchievementProgressPath = mSetAchievementProgressPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mSetAchievementProgressPath = mSetAchievementProgressPath.Replace("{" + "achievement_name" + "}", KnetikClient.DefaultClient.ParameterToString(achievementName));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(progress); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetAchievementProgressStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetAchievementProgressStartTime, mSetAchievementProgressPath, "Sending server request...");

            // make the HTTP request
            mSetAchievementProgressCoroutine.ResponseReceived += SetAchievementProgressCallback;
            mSetAchievementProgressCoroutine.Start(mSetAchievementProgressPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetAchievementProgressCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetAchievementProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetAchievementProgress: " + response.ErrorMessage, response.ErrorMessage);
            }

            SetAchievementProgressData = (UserAchievementGroupResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(UserAchievementGroupResource), response.Headers);
            KnetikLogger.LogResponse(mSetAchievementProgressStartTime, mSetAchievementProgressPath, string.Format("Response received successfully:\n{0}", SetAchievementProgressData.ToString()));

            if (SetAchievementProgressComplete != null)
            {
                SetAchievementProgressComplete(SetAchievementProgressData);
            }
        }
        /// <summary>
        /// Update an achievement definition The existing generated rule, if any, will be deleted. A new rule will be created if a trigger event name is specified in the new version.
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
            
            mUpdateAchievementPath = "/achievements/{name}";
            if (!string.IsNullOrEmpty(mUpdateAchievementPath))
            {
                mUpdateAchievementPath = mUpdateAchievementPath.Replace("{format}", "json");
            }
            mUpdateAchievementPath = mUpdateAchievementPath.Replace("{" + "name" + "}", KnetikClient.DefaultClient.ParameterToString(name));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(achievement); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateAchievementStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateAchievementStartTime, mUpdateAchievementPath, "Sending server request...");

            // make the HTTP request
            mUpdateAchievementCoroutine.ResponseReceived += UpdateAchievementCallback;
            mUpdateAchievementCoroutine.Start(mUpdateAchievementPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateAchievementCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateAchievement: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateAchievement: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateAchievementData = (AchievementDefinitionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(AchievementDefinitionResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateAchievementStartTime, mUpdateAchievementPath, string.Format("Response received successfully:\n{0}", UpdateAchievementData.ToString()));

            if (UpdateAchievementComplete != null)
            {
                UpdateAchievementComplete(UpdateAchievementData);
            }
        }
        /// <summary>
        /// Update an achievement template 
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
            
            mUpdateAchievementTemplatePath = "/achievements/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateAchievementTemplatePath))
            {
                mUpdateAchievementTemplatePath = mUpdateAchievementTemplatePath.Replace("{format}", "json");
            }
            mUpdateAchievementTemplatePath = mUpdateAchievementTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateAchievementTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateAchievementTemplateStartTime, mUpdateAchievementTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateAchievementTemplateCoroutine.ResponseReceived += UpdateAchievementTemplateCallback;
            mUpdateAchievementTemplateCoroutine.Start(mUpdateAchievementTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateAchievementTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateAchievementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateAchievementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateAchievementTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateAchievementTemplateStartTime, mUpdateAchievementTemplatePath, string.Format("Response received successfully:\n{0}", UpdateAchievementTemplateData.ToString()));

            if (UpdateAchievementTemplateComplete != null)
            {
                UpdateAchievementTemplateComplete(UpdateAchievementTemplateData);
            }
        }
    }
}
