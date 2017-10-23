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
    public interface ICampaignsChallengesApi
    {
        ChallengeResource CreateChallengeData { get; }

        ChallengeActivityResource CreateChallengeActivityData { get; }

        TemplateResource CreateChallengeActivityTemplateData { get; }

        TemplateResource CreateChallengeTemplateData { get; }

        ChallengeResource GetChallengeData { get; }

        PageResourceBareChallengeActivityResource GetChallengeActivitiesData { get; }

        ChallengeActivityResource GetChallengeActivityData { get; }

        TemplateResource GetChallengeActivityTemplateData { get; }

        PageResourceTemplateResource GetChallengeActivityTemplatesData { get; }

        ChallengeEventResource GetChallengeEventData { get; }

        PageResourceChallengeEventResource GetChallengeEventsData { get; }

        TemplateResource GetChallengeTemplateData { get; }

        PageResourceTemplateResource GetChallengeTemplatesData { get; }

        PageResourceChallengeResource GetChallengesData { get; }

        ChallengeResource UpdateChallengeData { get; }

        ChallengeActivityResource UpdateChallengeActivityData { get; }

        TemplateResource UpdateChallengeActivityTemplateData { get; }

        TemplateResource UpdateChallengeTemplateData { get; }

        
        /// <summary>
        /// Create a challenge Challenges do not run on their own.  They must be added to a campaign before events will spawn.
        /// </summary>
        /// <param name="challengeResource">The challenge resource object</param>
        void CreateChallenge(ChallengeResource challengeResource);

        /// <summary>
        /// Create a challenge activity 
        /// </summary>
        /// <param name="challengeId">The challenge id</param>
        /// <param name="challengeActivityResource">The challenge activity resource object</param>
        /// <param name="validateSettings">Whether to validate the settings being sent against the available settings on the base activity.</param>
        void CreateChallengeActivity(long? challengeId, ChallengeActivityResource challengeActivityResource, bool? validateSettings);

        /// <summary>
        /// Create a challenge activity template Challenge Activity Templates define a type of challenge activity and the properties they have
        /// </summary>
        /// <param name="challengeActivityTemplateResource">The challengeActivity template resource object</param>
        void CreateChallengeActivityTemplate(TemplateResource challengeActivityTemplateResource);

        /// <summary>
        /// Create a challenge template Challenge Templates define a type of challenge and the properties they have
        /// </summary>
        /// <param name="challengeTemplateResource">The challenge template resource object</param>
        void CreateChallengeTemplate(TemplateResource challengeTemplateResource);

        /// <summary>
        /// Delete a challenge 
        /// </summary>
        /// <param name="id">The challenge id</param>
        void DeleteChallenge(long? id);

        /// <summary>
        /// Delete a challenge activity A challenge can have multiple instances of the same activity and thus the id used is of the specific entry within the challenge
        /// </summary>
        /// <param name="id">The challenge_activity id</param>
        /// <param name="challengeId">The challenge id</param>
        void DeleteChallengeActivity(long? id, long? challengeId);

        /// <summary>
        /// Delete a challenge activity template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteChallengeActivityTemplate(string id, string cascade);

        /// <summary>
        /// Delete a challenge event 
        /// </summary>
        /// <param name="id">The challenge event id</param>
        void DeleteChallengeEvent(long? id);

        /// <summary>
        /// Delete a challenge template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteChallengeTemplate(string id, string cascade);

        /// <summary>
        /// Retrieve a challenge 
        /// </summary>
        /// <param name="id">The challenge id</param>
        void GetChallenge(long? id);

        /// <summary>
        /// List and search challenge activities 
        /// </summary>
        /// <param name="challengeId">The challenge id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetChallengeActivities(long? challengeId, int? size, int? page, string order);

        /// <summary>
        /// Get a single challenge activity A challenge can have multiple instances of the same activity and thus the id used is of the specific entry within the challenge
        /// </summary>
        /// <param name="id">The challenge_activity id</param>
        /// <param name="challengeId">The challenge id</param>
        void GetChallengeActivity(long? id, long? challengeId);

        /// <summary>
        /// Get a single challenge activity template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetChallengeActivityTemplate(string id);

        /// <summary>
        /// List and search challenge activity templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetChallengeActivityTemplates(int? size, int? page, string order);

        /// <summary>
        /// Retrieve a single challenge event details 
        /// </summary>
        /// <param name="id">The challenge event id</param>
        void GetChallengeEvent(long? id);

        /// <summary>
        /// Retrieve a list of challenge events 
        /// </summary>
        /// <param name="filterStartDate">A comma separated string without spaces.  First value is the operator to search on, second value is the event start date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterEndDate">A comma separated string without spaces.  First value is the operator to search on, second value is the event end date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterCampaigns">check only for events from currently running campaigns</param>
        /// <param name="filterChallenge">check only for events from the challenge specified by id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetChallengeEvents(string filterStartDate, string filterEndDate, bool? filterCampaigns, long? filterChallenge, int? size, int? page, string order);

        /// <summary>
        /// Get a single challenge template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetChallengeTemplate(string id);

        /// <summary>
        /// List and search challenge templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetChallengeTemplates(int? size, int? page, string order);

        /// <summary>
        /// Retrieve a list of challenges 
        /// </summary>
        /// <param name="filterActiveCampaign">Filter for challenges that are tied to active campaigns</param>
        /// <param name="filterStartDate">A comma separated string without spaces.  First value is the operator to search on, second value is the challenge start date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterEndDate">A comma separated string without spaces.  First value is the operator to search on, second value is the challenge end date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetChallenges(bool? filterActiveCampaign, string filterStartDate, string filterEndDate, int? size, int? page, string order);

        /// <summary>
        /// Update a challenge If the challenge is a copy, changes will propagate to all the related challenges
        /// </summary>
        /// <param name="id">The challenge id</param>
        /// <param name="challengeResource">The challenge resource object</param>
        void UpdateChallenge(long? id, ChallengeResource challengeResource);

        /// <summary>
        /// Update a challenge activity A challenge can have multiple instances of the same activity and thus the id used is of the specific entry within the challenge
        /// </summary>
        /// <param name="id">The challenge_activity id</param>
        /// <param name="challengeId">The challenge id</param>
        /// <param name="challengeActivityResource">The challenge activity resource object</param>
        void UpdateChallengeActivity(long? id, long? challengeId, ChallengeActivityResource challengeActivityResource);

        /// <summary>
        /// Update an challenge activity template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="challengeActivityTemplateResource">The challengeActivity template resource object</param>
        void UpdateChallengeActivityTemplate(string id, TemplateResource challengeActivityTemplateResource);

        /// <summary>
        /// Update a challenge template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="challengeTemplateResource">The challenge template resource object</param>
        void UpdateChallengeTemplate(string id, TemplateResource challengeTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class CampaignsChallengesApi : ICampaignsChallengesApi
    {
        private readonly KnetikCoroutine mCreateChallengeCoroutine;
        private DateTime mCreateChallengeStartTime;
        private string mCreateChallengePath;
        private readonly KnetikCoroutine mCreateChallengeActivityCoroutine;
        private DateTime mCreateChallengeActivityStartTime;
        private string mCreateChallengeActivityPath;
        private readonly KnetikCoroutine mCreateChallengeActivityTemplateCoroutine;
        private DateTime mCreateChallengeActivityTemplateStartTime;
        private string mCreateChallengeActivityTemplatePath;
        private readonly KnetikCoroutine mCreateChallengeTemplateCoroutine;
        private DateTime mCreateChallengeTemplateStartTime;
        private string mCreateChallengeTemplatePath;
        private readonly KnetikCoroutine mDeleteChallengeCoroutine;
        private DateTime mDeleteChallengeStartTime;
        private string mDeleteChallengePath;
        private readonly KnetikCoroutine mDeleteChallengeActivityCoroutine;
        private DateTime mDeleteChallengeActivityStartTime;
        private string mDeleteChallengeActivityPath;
        private readonly KnetikCoroutine mDeleteChallengeActivityTemplateCoroutine;
        private DateTime mDeleteChallengeActivityTemplateStartTime;
        private string mDeleteChallengeActivityTemplatePath;
        private readonly KnetikCoroutine mDeleteChallengeEventCoroutine;
        private DateTime mDeleteChallengeEventStartTime;
        private string mDeleteChallengeEventPath;
        private readonly KnetikCoroutine mDeleteChallengeTemplateCoroutine;
        private DateTime mDeleteChallengeTemplateStartTime;
        private string mDeleteChallengeTemplatePath;
        private readonly KnetikCoroutine mGetChallengeCoroutine;
        private DateTime mGetChallengeStartTime;
        private string mGetChallengePath;
        private readonly KnetikCoroutine mGetChallengeActivitiesCoroutine;
        private DateTime mGetChallengeActivitiesStartTime;
        private string mGetChallengeActivitiesPath;
        private readonly KnetikCoroutine mGetChallengeActivityCoroutine;
        private DateTime mGetChallengeActivityStartTime;
        private string mGetChallengeActivityPath;
        private readonly KnetikCoroutine mGetChallengeActivityTemplateCoroutine;
        private DateTime mGetChallengeActivityTemplateStartTime;
        private string mGetChallengeActivityTemplatePath;
        private readonly KnetikCoroutine mGetChallengeActivityTemplatesCoroutine;
        private DateTime mGetChallengeActivityTemplatesStartTime;
        private string mGetChallengeActivityTemplatesPath;
        private readonly KnetikCoroutine mGetChallengeEventCoroutine;
        private DateTime mGetChallengeEventStartTime;
        private string mGetChallengeEventPath;
        private readonly KnetikCoroutine mGetChallengeEventsCoroutine;
        private DateTime mGetChallengeEventsStartTime;
        private string mGetChallengeEventsPath;
        private readonly KnetikCoroutine mGetChallengeTemplateCoroutine;
        private DateTime mGetChallengeTemplateStartTime;
        private string mGetChallengeTemplatePath;
        private readonly KnetikCoroutine mGetChallengeTemplatesCoroutine;
        private DateTime mGetChallengeTemplatesStartTime;
        private string mGetChallengeTemplatesPath;
        private readonly KnetikCoroutine mGetChallengesCoroutine;
        private DateTime mGetChallengesStartTime;
        private string mGetChallengesPath;
        private readonly KnetikCoroutine mUpdateChallengeCoroutine;
        private DateTime mUpdateChallengeStartTime;
        private string mUpdateChallengePath;
        private readonly KnetikCoroutine mUpdateChallengeActivityCoroutine;
        private DateTime mUpdateChallengeActivityStartTime;
        private string mUpdateChallengeActivityPath;
        private readonly KnetikCoroutine mUpdateChallengeActivityTemplateCoroutine;
        private DateTime mUpdateChallengeActivityTemplateStartTime;
        private string mUpdateChallengeActivityTemplatePath;
        private readonly KnetikCoroutine mUpdateChallengeTemplateCoroutine;
        private DateTime mUpdateChallengeTemplateStartTime;
        private string mUpdateChallengeTemplatePath;

        public ChallengeResource CreateChallengeData { get; private set; }
        public delegate void CreateChallengeCompleteDelegate(ChallengeResource response);
        public CreateChallengeCompleteDelegate CreateChallengeComplete;

        public ChallengeActivityResource CreateChallengeActivityData { get; private set; }
        public delegate void CreateChallengeActivityCompleteDelegate(ChallengeActivityResource response);
        public CreateChallengeActivityCompleteDelegate CreateChallengeActivityComplete;

        public TemplateResource CreateChallengeActivityTemplateData { get; private set; }
        public delegate void CreateChallengeActivityTemplateCompleteDelegate(TemplateResource response);
        public CreateChallengeActivityTemplateCompleteDelegate CreateChallengeActivityTemplateComplete;

        public TemplateResource CreateChallengeTemplateData { get; private set; }
        public delegate void CreateChallengeTemplateCompleteDelegate(TemplateResource response);
        public CreateChallengeTemplateCompleteDelegate CreateChallengeTemplateComplete;

        public delegate void DeleteChallengeCompleteDelegate();
        public DeleteChallengeCompleteDelegate DeleteChallengeComplete;

        public delegate void DeleteChallengeActivityCompleteDelegate();
        public DeleteChallengeActivityCompleteDelegate DeleteChallengeActivityComplete;

        public delegate void DeleteChallengeActivityTemplateCompleteDelegate();
        public DeleteChallengeActivityTemplateCompleteDelegate DeleteChallengeActivityTemplateComplete;

        public delegate void DeleteChallengeEventCompleteDelegate();
        public DeleteChallengeEventCompleteDelegate DeleteChallengeEventComplete;

        public delegate void DeleteChallengeTemplateCompleteDelegate();
        public DeleteChallengeTemplateCompleteDelegate DeleteChallengeTemplateComplete;

        public ChallengeResource GetChallengeData { get; private set; }
        public delegate void GetChallengeCompleteDelegate(ChallengeResource response);
        public GetChallengeCompleteDelegate GetChallengeComplete;

        public PageResourceBareChallengeActivityResource GetChallengeActivitiesData { get; private set; }
        public delegate void GetChallengeActivitiesCompleteDelegate(PageResourceBareChallengeActivityResource response);
        public GetChallengeActivitiesCompleteDelegate GetChallengeActivitiesComplete;

        public ChallengeActivityResource GetChallengeActivityData { get; private set; }
        public delegate void GetChallengeActivityCompleteDelegate(ChallengeActivityResource response);
        public GetChallengeActivityCompleteDelegate GetChallengeActivityComplete;

        public TemplateResource GetChallengeActivityTemplateData { get; private set; }
        public delegate void GetChallengeActivityTemplateCompleteDelegate(TemplateResource response);
        public GetChallengeActivityTemplateCompleteDelegate GetChallengeActivityTemplateComplete;

        public PageResourceTemplateResource GetChallengeActivityTemplatesData { get; private set; }
        public delegate void GetChallengeActivityTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetChallengeActivityTemplatesCompleteDelegate GetChallengeActivityTemplatesComplete;

        public ChallengeEventResource GetChallengeEventData { get; private set; }
        public delegate void GetChallengeEventCompleteDelegate(ChallengeEventResource response);
        public GetChallengeEventCompleteDelegate GetChallengeEventComplete;

        public PageResourceChallengeEventResource GetChallengeEventsData { get; private set; }
        public delegate void GetChallengeEventsCompleteDelegate(PageResourceChallengeEventResource response);
        public GetChallengeEventsCompleteDelegate GetChallengeEventsComplete;

        public TemplateResource GetChallengeTemplateData { get; private set; }
        public delegate void GetChallengeTemplateCompleteDelegate(TemplateResource response);
        public GetChallengeTemplateCompleteDelegate GetChallengeTemplateComplete;

        public PageResourceTemplateResource GetChallengeTemplatesData { get; private set; }
        public delegate void GetChallengeTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetChallengeTemplatesCompleteDelegate GetChallengeTemplatesComplete;

        public PageResourceChallengeResource GetChallengesData { get; private set; }
        public delegate void GetChallengesCompleteDelegate(PageResourceChallengeResource response);
        public GetChallengesCompleteDelegate GetChallengesComplete;

        public ChallengeResource UpdateChallengeData { get; private set; }
        public delegate void UpdateChallengeCompleteDelegate(ChallengeResource response);
        public UpdateChallengeCompleteDelegate UpdateChallengeComplete;

        public ChallengeActivityResource UpdateChallengeActivityData { get; private set; }
        public delegate void UpdateChallengeActivityCompleteDelegate(ChallengeActivityResource response);
        public UpdateChallengeActivityCompleteDelegate UpdateChallengeActivityComplete;

        public TemplateResource UpdateChallengeActivityTemplateData { get; private set; }
        public delegate void UpdateChallengeActivityTemplateCompleteDelegate(TemplateResource response);
        public UpdateChallengeActivityTemplateCompleteDelegate UpdateChallengeActivityTemplateComplete;

        public TemplateResource UpdateChallengeTemplateData { get; private set; }
        public delegate void UpdateChallengeTemplateCompleteDelegate(TemplateResource response);
        public UpdateChallengeTemplateCompleteDelegate UpdateChallengeTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignsChallengesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CampaignsChallengesApi()
        {
            mCreateChallengeCoroutine = new KnetikCoroutine();
            mCreateChallengeActivityCoroutine = new KnetikCoroutine();
            mCreateChallengeActivityTemplateCoroutine = new KnetikCoroutine();
            mCreateChallengeTemplateCoroutine = new KnetikCoroutine();
            mDeleteChallengeCoroutine = new KnetikCoroutine();
            mDeleteChallengeActivityCoroutine = new KnetikCoroutine();
            mDeleteChallengeActivityTemplateCoroutine = new KnetikCoroutine();
            mDeleteChallengeEventCoroutine = new KnetikCoroutine();
            mDeleteChallengeTemplateCoroutine = new KnetikCoroutine();
            mGetChallengeCoroutine = new KnetikCoroutine();
            mGetChallengeActivitiesCoroutine = new KnetikCoroutine();
            mGetChallengeActivityCoroutine = new KnetikCoroutine();
            mGetChallengeActivityTemplateCoroutine = new KnetikCoroutine();
            mGetChallengeActivityTemplatesCoroutine = new KnetikCoroutine();
            mGetChallengeEventCoroutine = new KnetikCoroutine();
            mGetChallengeEventsCoroutine = new KnetikCoroutine();
            mGetChallengeTemplateCoroutine = new KnetikCoroutine();
            mGetChallengeTemplatesCoroutine = new KnetikCoroutine();
            mGetChallengesCoroutine = new KnetikCoroutine();
            mUpdateChallengeCoroutine = new KnetikCoroutine();
            mUpdateChallengeActivityCoroutine = new KnetikCoroutine();
            mUpdateChallengeActivityTemplateCoroutine = new KnetikCoroutine();
            mUpdateChallengeTemplateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a challenge Challenges do not run on their own.  They must be added to a campaign before events will spawn.
        /// </summary>
        /// <param name="challengeResource">The challenge resource object</param>
        public void CreateChallenge(ChallengeResource challengeResource)
        {
            
            mCreateChallengePath = "/challenges";
            if (!string.IsNullOrEmpty(mCreateChallengePath))
            {
                mCreateChallengePath = mCreateChallengePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(challengeResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateChallengeStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateChallengeStartTime, mCreateChallengePath, "Sending server request...");

            // make the HTTP request
            mCreateChallengeCoroutine.ResponseReceived += CreateChallengeCallback;
            mCreateChallengeCoroutine.Start(mCreateChallengePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateChallengeCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateChallenge: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateChallenge: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateChallengeData = (ChallengeResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ChallengeResource), response.Headers);
            KnetikLogger.LogResponse(mCreateChallengeStartTime, mCreateChallengePath, string.Format("Response received successfully:\n{0}", CreateChallengeData.ToString()));

            if (CreateChallengeComplete != null)
            {
                CreateChallengeComplete(CreateChallengeData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a challenge activity 
        /// </summary>
        /// <param name="challengeId">The challenge id</param>
        /// <param name="challengeActivityResource">The challenge activity resource object</param>
        /// <param name="validateSettings">Whether to validate the settings being sent against the available settings on the base activity.</param>
        public void CreateChallengeActivity(long? challengeId, ChallengeActivityResource challengeActivityResource, bool? validateSettings)
        {
            // verify the required parameter 'challengeId' is set
            if (challengeId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'challengeId' when calling CreateChallengeActivity");
            }
            
            mCreateChallengeActivityPath = "/challenges/{challenge_id}/activities";
            if (!string.IsNullOrEmpty(mCreateChallengeActivityPath))
            {
                mCreateChallengeActivityPath = mCreateChallengeActivityPath.Replace("{format}", "json");
            }
            mCreateChallengeActivityPath = mCreateChallengeActivityPath.Replace("{" + "challenge_id" + "}", KnetikClient.DefaultClient.ParameterToString(challengeId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (validateSettings != null)
            {
                queryParams.Add("validateSettings", KnetikClient.DefaultClient.ParameterToString(validateSettings));
            }

            postBody = KnetikClient.DefaultClient.Serialize(challengeActivityResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateChallengeActivityStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateChallengeActivityStartTime, mCreateChallengeActivityPath, "Sending server request...");

            // make the HTTP request
            mCreateChallengeActivityCoroutine.ResponseReceived += CreateChallengeActivityCallback;
            mCreateChallengeActivityCoroutine.Start(mCreateChallengeActivityPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateChallengeActivityCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateChallengeActivity: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateChallengeActivity: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateChallengeActivityData = (ChallengeActivityResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ChallengeActivityResource), response.Headers);
            KnetikLogger.LogResponse(mCreateChallengeActivityStartTime, mCreateChallengeActivityPath, string.Format("Response received successfully:\n{0}", CreateChallengeActivityData.ToString()));

            if (CreateChallengeActivityComplete != null)
            {
                CreateChallengeActivityComplete(CreateChallengeActivityData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a challenge activity template Challenge Activity Templates define a type of challenge activity and the properties they have
        /// </summary>
        /// <param name="challengeActivityTemplateResource">The challengeActivity template resource object</param>
        public void CreateChallengeActivityTemplate(TemplateResource challengeActivityTemplateResource)
        {
            
            mCreateChallengeActivityTemplatePath = "/challenge-activities/templates";
            if (!string.IsNullOrEmpty(mCreateChallengeActivityTemplatePath))
            {
                mCreateChallengeActivityTemplatePath = mCreateChallengeActivityTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(challengeActivityTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateChallengeActivityTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateChallengeActivityTemplateStartTime, mCreateChallengeActivityTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateChallengeActivityTemplateCoroutine.ResponseReceived += CreateChallengeActivityTemplateCallback;
            mCreateChallengeActivityTemplateCoroutine.Start(mCreateChallengeActivityTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateChallengeActivityTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateChallengeActivityTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateChallengeActivityTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateChallengeActivityTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateChallengeActivityTemplateStartTime, mCreateChallengeActivityTemplatePath, string.Format("Response received successfully:\n{0}", CreateChallengeActivityTemplateData.ToString()));

            if (CreateChallengeActivityTemplateComplete != null)
            {
                CreateChallengeActivityTemplateComplete(CreateChallengeActivityTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a challenge template Challenge Templates define a type of challenge and the properties they have
        /// </summary>
        /// <param name="challengeTemplateResource">The challenge template resource object</param>
        public void CreateChallengeTemplate(TemplateResource challengeTemplateResource)
        {
            
            mCreateChallengeTemplatePath = "/challenges/templates";
            if (!string.IsNullOrEmpty(mCreateChallengeTemplatePath))
            {
                mCreateChallengeTemplatePath = mCreateChallengeTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(challengeTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateChallengeTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateChallengeTemplateStartTime, mCreateChallengeTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateChallengeTemplateCoroutine.ResponseReceived += CreateChallengeTemplateCallback;
            mCreateChallengeTemplateCoroutine.Start(mCreateChallengeTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateChallengeTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateChallengeTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateChallengeTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateChallengeTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateChallengeTemplateStartTime, mCreateChallengeTemplatePath, string.Format("Response received successfully:\n{0}", CreateChallengeTemplateData.ToString()));

            if (CreateChallengeTemplateComplete != null)
            {
                CreateChallengeTemplateComplete(CreateChallengeTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a challenge 
        /// </summary>
        /// <param name="id">The challenge id</param>
        public void DeleteChallenge(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteChallenge");
            }
            
            mDeleteChallengePath = "/challenges/{id}";
            if (!string.IsNullOrEmpty(mDeleteChallengePath))
            {
                mDeleteChallengePath = mDeleteChallengePath.Replace("{format}", "json");
            }
            mDeleteChallengePath = mDeleteChallengePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteChallengeStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteChallengeStartTime, mDeleteChallengePath, "Sending server request...");

            // make the HTTP request
            mDeleteChallengeCoroutine.ResponseReceived += DeleteChallengeCallback;
            mDeleteChallengeCoroutine.Start(mDeleteChallengePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteChallengeCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteChallenge: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteChallenge: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteChallengeStartTime, mDeleteChallengePath, "Response received successfully.");
            if (DeleteChallengeComplete != null)
            {
                DeleteChallengeComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a challenge activity A challenge can have multiple instances of the same activity and thus the id used is of the specific entry within the challenge
        /// </summary>
        /// <param name="id">The challenge_activity id</param>
        /// <param name="challengeId">The challenge id</param>
        public void DeleteChallengeActivity(long? id, long? challengeId)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteChallengeActivity");
            }
            // verify the required parameter 'challengeId' is set
            if (challengeId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'challengeId' when calling DeleteChallengeActivity");
            }
            
            mDeleteChallengeActivityPath = "/challenges/{challenge_id}/activities/{id}";
            if (!string.IsNullOrEmpty(mDeleteChallengeActivityPath))
            {
                mDeleteChallengeActivityPath = mDeleteChallengeActivityPath.Replace("{format}", "json");
            }
            mDeleteChallengeActivityPath = mDeleteChallengeActivityPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));
mDeleteChallengeActivityPath = mDeleteChallengeActivityPath.Replace("{" + "challenge_id" + "}", KnetikClient.DefaultClient.ParameterToString(challengeId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteChallengeActivityStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteChallengeActivityStartTime, mDeleteChallengeActivityPath, "Sending server request...");

            // make the HTTP request
            mDeleteChallengeActivityCoroutine.ResponseReceived += DeleteChallengeActivityCallback;
            mDeleteChallengeActivityCoroutine.Start(mDeleteChallengeActivityPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteChallengeActivityCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteChallengeActivity: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteChallengeActivity: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteChallengeActivityStartTime, mDeleteChallengeActivityPath, "Response received successfully.");
            if (DeleteChallengeActivityComplete != null)
            {
                DeleteChallengeActivityComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a challenge activity template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteChallengeActivityTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteChallengeActivityTemplate");
            }
            
            mDeleteChallengeActivityTemplatePath = "/challenge-activities/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteChallengeActivityTemplatePath))
            {
                mDeleteChallengeActivityTemplatePath = mDeleteChallengeActivityTemplatePath.Replace("{format}", "json");
            }
            mDeleteChallengeActivityTemplatePath = mDeleteChallengeActivityTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mDeleteChallengeActivityTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteChallengeActivityTemplateStartTime, mDeleteChallengeActivityTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteChallengeActivityTemplateCoroutine.ResponseReceived += DeleteChallengeActivityTemplateCallback;
            mDeleteChallengeActivityTemplateCoroutine.Start(mDeleteChallengeActivityTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteChallengeActivityTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteChallengeActivityTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteChallengeActivityTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteChallengeActivityTemplateStartTime, mDeleteChallengeActivityTemplatePath, "Response received successfully.");
            if (DeleteChallengeActivityTemplateComplete != null)
            {
                DeleteChallengeActivityTemplateComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a challenge event 
        /// </summary>
        /// <param name="id">The challenge event id</param>
        public void DeleteChallengeEvent(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteChallengeEvent");
            }
            
            mDeleteChallengeEventPath = "/challenges/events/{id}";
            if (!string.IsNullOrEmpty(mDeleteChallengeEventPath))
            {
                mDeleteChallengeEventPath = mDeleteChallengeEventPath.Replace("{format}", "json");
            }
            mDeleteChallengeEventPath = mDeleteChallengeEventPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteChallengeEventStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteChallengeEventStartTime, mDeleteChallengeEventPath, "Sending server request...");

            // make the HTTP request
            mDeleteChallengeEventCoroutine.ResponseReceived += DeleteChallengeEventCallback;
            mDeleteChallengeEventCoroutine.Start(mDeleteChallengeEventPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteChallengeEventCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteChallengeEvent: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteChallengeEvent: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteChallengeEventStartTime, mDeleteChallengeEventPath, "Response received successfully.");
            if (DeleteChallengeEventComplete != null)
            {
                DeleteChallengeEventComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a challenge template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteChallengeTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteChallengeTemplate");
            }
            
            mDeleteChallengeTemplatePath = "/challenges/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteChallengeTemplatePath))
            {
                mDeleteChallengeTemplatePath = mDeleteChallengeTemplatePath.Replace("{format}", "json");
            }
            mDeleteChallengeTemplatePath = mDeleteChallengeTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mDeleteChallengeTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteChallengeTemplateStartTime, mDeleteChallengeTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteChallengeTemplateCoroutine.ResponseReceived += DeleteChallengeTemplateCallback;
            mDeleteChallengeTemplateCoroutine.Start(mDeleteChallengeTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteChallengeTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteChallengeTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteChallengeTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteChallengeTemplateStartTime, mDeleteChallengeTemplatePath, "Response received successfully.");
            if (DeleteChallengeTemplateComplete != null)
            {
                DeleteChallengeTemplateComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve a challenge 
        /// </summary>
        /// <param name="id">The challenge id</param>
        public void GetChallenge(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetChallenge");
            }
            
            mGetChallengePath = "/challenges/{id}";
            if (!string.IsNullOrEmpty(mGetChallengePath))
            {
                mGetChallengePath = mGetChallengePath.Replace("{format}", "json");
            }
            mGetChallengePath = mGetChallengePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetChallengeStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetChallengeStartTime, mGetChallengePath, "Sending server request...");

            // make the HTTP request
            mGetChallengeCoroutine.ResponseReceived += GetChallengeCallback;
            mGetChallengeCoroutine.Start(mGetChallengePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetChallengeCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallenge: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallenge: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetChallengeData = (ChallengeResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ChallengeResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeStartTime, mGetChallengePath, string.Format("Response received successfully:\n{0}", GetChallengeData.ToString()));

            if (GetChallengeComplete != null)
            {
                GetChallengeComplete(GetChallengeData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search challenge activities 
        /// </summary>
        /// <param name="challengeId">The challenge id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetChallengeActivities(long? challengeId, int? size, int? page, string order)
        {
            // verify the required parameter 'challengeId' is set
            if (challengeId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'challengeId' when calling GetChallengeActivities");
            }
            
            mGetChallengeActivitiesPath = "/challenges/{challenge_id}/activities";
            if (!string.IsNullOrEmpty(mGetChallengeActivitiesPath))
            {
                mGetChallengeActivitiesPath = mGetChallengeActivitiesPath.Replace("{format}", "json");
            }
            mGetChallengeActivitiesPath = mGetChallengeActivitiesPath.Replace("{" + "challenge_id" + "}", KnetikClient.DefaultClient.ParameterToString(challengeId));

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
            string[] authSettings = new string[] {  };

            mGetChallengeActivitiesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetChallengeActivitiesStartTime, mGetChallengeActivitiesPath, "Sending server request...");

            // make the HTTP request
            mGetChallengeActivitiesCoroutine.ResponseReceived += GetChallengeActivitiesCallback;
            mGetChallengeActivitiesCoroutine.Start(mGetChallengeActivitiesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetChallengeActivitiesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeActivities: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeActivities: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetChallengeActivitiesData = (PageResourceBareChallengeActivityResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceBareChallengeActivityResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeActivitiesStartTime, mGetChallengeActivitiesPath, string.Format("Response received successfully:\n{0}", GetChallengeActivitiesData.ToString()));

            if (GetChallengeActivitiesComplete != null)
            {
                GetChallengeActivitiesComplete(GetChallengeActivitiesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single challenge activity A challenge can have multiple instances of the same activity and thus the id used is of the specific entry within the challenge
        /// </summary>
        /// <param name="id">The challenge_activity id</param>
        /// <param name="challengeId">The challenge id</param>
        public void GetChallengeActivity(long? id, long? challengeId)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetChallengeActivity");
            }
            // verify the required parameter 'challengeId' is set
            if (challengeId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'challengeId' when calling GetChallengeActivity");
            }
            
            mGetChallengeActivityPath = "/challenges/{challenge_id}/activities/{id}";
            if (!string.IsNullOrEmpty(mGetChallengeActivityPath))
            {
                mGetChallengeActivityPath = mGetChallengeActivityPath.Replace("{format}", "json");
            }
            mGetChallengeActivityPath = mGetChallengeActivityPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));
mGetChallengeActivityPath = mGetChallengeActivityPath.Replace("{" + "challenge_id" + "}", KnetikClient.DefaultClient.ParameterToString(challengeId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetChallengeActivityStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetChallengeActivityStartTime, mGetChallengeActivityPath, "Sending server request...");

            // make the HTTP request
            mGetChallengeActivityCoroutine.ResponseReceived += GetChallengeActivityCallback;
            mGetChallengeActivityCoroutine.Start(mGetChallengeActivityPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetChallengeActivityCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeActivity: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeActivity: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetChallengeActivityData = (ChallengeActivityResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ChallengeActivityResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeActivityStartTime, mGetChallengeActivityPath, string.Format("Response received successfully:\n{0}", GetChallengeActivityData.ToString()));

            if (GetChallengeActivityComplete != null)
            {
                GetChallengeActivityComplete(GetChallengeActivityData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single challenge activity template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetChallengeActivityTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetChallengeActivityTemplate");
            }
            
            mGetChallengeActivityTemplatePath = "/challenge-activities/templates/{id}";
            if (!string.IsNullOrEmpty(mGetChallengeActivityTemplatePath))
            {
                mGetChallengeActivityTemplatePath = mGetChallengeActivityTemplatePath.Replace("{format}", "json");
            }
            mGetChallengeActivityTemplatePath = mGetChallengeActivityTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetChallengeActivityTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetChallengeActivityTemplateStartTime, mGetChallengeActivityTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetChallengeActivityTemplateCoroutine.ResponseReceived += GetChallengeActivityTemplateCallback;
            mGetChallengeActivityTemplateCoroutine.Start(mGetChallengeActivityTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetChallengeActivityTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeActivityTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeActivityTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetChallengeActivityTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeActivityTemplateStartTime, mGetChallengeActivityTemplatePath, string.Format("Response received successfully:\n{0}", GetChallengeActivityTemplateData.ToString()));

            if (GetChallengeActivityTemplateComplete != null)
            {
                GetChallengeActivityTemplateComplete(GetChallengeActivityTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search challenge activity templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetChallengeActivityTemplates(int? size, int? page, string order)
        {
            
            mGetChallengeActivityTemplatesPath = "/challenge-activities/templates";
            if (!string.IsNullOrEmpty(mGetChallengeActivityTemplatesPath))
            {
                mGetChallengeActivityTemplatesPath = mGetChallengeActivityTemplatesPath.Replace("{format}", "json");
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

            mGetChallengeActivityTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetChallengeActivityTemplatesStartTime, mGetChallengeActivityTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetChallengeActivityTemplatesCoroutine.ResponseReceived += GetChallengeActivityTemplatesCallback;
            mGetChallengeActivityTemplatesCoroutine.Start(mGetChallengeActivityTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetChallengeActivityTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeActivityTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeActivityTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetChallengeActivityTemplatesData = (PageResourceTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeActivityTemplatesStartTime, mGetChallengeActivityTemplatesPath, string.Format("Response received successfully:\n{0}", GetChallengeActivityTemplatesData.ToString()));

            if (GetChallengeActivityTemplatesComplete != null)
            {
                GetChallengeActivityTemplatesComplete(GetChallengeActivityTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve a single challenge event details 
        /// </summary>
        /// <param name="id">The challenge event id</param>
        public void GetChallengeEvent(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetChallengeEvent");
            }
            
            mGetChallengeEventPath = "/challenges/events/{id}";
            if (!string.IsNullOrEmpty(mGetChallengeEventPath))
            {
                mGetChallengeEventPath = mGetChallengeEventPath.Replace("{format}", "json");
            }
            mGetChallengeEventPath = mGetChallengeEventPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetChallengeEventStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetChallengeEventStartTime, mGetChallengeEventPath, "Sending server request...");

            // make the HTTP request
            mGetChallengeEventCoroutine.ResponseReceived += GetChallengeEventCallback;
            mGetChallengeEventCoroutine.Start(mGetChallengeEventPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetChallengeEventCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeEvent: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeEvent: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetChallengeEventData = (ChallengeEventResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ChallengeEventResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeEventStartTime, mGetChallengeEventPath, string.Format("Response received successfully:\n{0}", GetChallengeEventData.ToString()));

            if (GetChallengeEventComplete != null)
            {
                GetChallengeEventComplete(GetChallengeEventData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve a list of challenge events 
        /// </summary>
        /// <param name="filterStartDate">A comma separated string without spaces.  First value is the operator to search on, second value is the event start date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterEndDate">A comma separated string without spaces.  First value is the operator to search on, second value is the event end date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterCampaigns">check only for events from currently running campaigns</param>
        /// <param name="filterChallenge">check only for events from the challenge specified by id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetChallengeEvents(string filterStartDate, string filterEndDate, bool? filterCampaigns, long? filterChallenge, int? size, int? page, string order)
        {
            
            mGetChallengeEventsPath = "/challenges/events";
            if (!string.IsNullOrEmpty(mGetChallengeEventsPath))
            {
                mGetChallengeEventsPath = mGetChallengeEventsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterStartDate != null)
            {
                queryParams.Add("filter_start_date", KnetikClient.DefaultClient.ParameterToString(filterStartDate));
            }

            if (filterEndDate != null)
            {
                queryParams.Add("filter_end_date", KnetikClient.DefaultClient.ParameterToString(filterEndDate));
            }

            if (filterCampaigns != null)
            {
                queryParams.Add("filter_campaigns", KnetikClient.DefaultClient.ParameterToString(filterCampaigns));
            }

            if (filterChallenge != null)
            {
                queryParams.Add("filter_challenge", KnetikClient.DefaultClient.ParameterToString(filterChallenge));
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

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetChallengeEventsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetChallengeEventsStartTime, mGetChallengeEventsPath, "Sending server request...");

            // make the HTTP request
            mGetChallengeEventsCoroutine.ResponseReceived += GetChallengeEventsCallback;
            mGetChallengeEventsCoroutine.Start(mGetChallengeEventsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetChallengeEventsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeEvents: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeEvents: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetChallengeEventsData = (PageResourceChallengeEventResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceChallengeEventResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeEventsStartTime, mGetChallengeEventsPath, string.Format("Response received successfully:\n{0}", GetChallengeEventsData.ToString()));

            if (GetChallengeEventsComplete != null)
            {
                GetChallengeEventsComplete(GetChallengeEventsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single challenge template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetChallengeTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetChallengeTemplate");
            }
            
            mGetChallengeTemplatePath = "/challenges/templates/{id}";
            if (!string.IsNullOrEmpty(mGetChallengeTemplatePath))
            {
                mGetChallengeTemplatePath = mGetChallengeTemplatePath.Replace("{format}", "json");
            }
            mGetChallengeTemplatePath = mGetChallengeTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetChallengeTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetChallengeTemplateStartTime, mGetChallengeTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetChallengeTemplateCoroutine.ResponseReceived += GetChallengeTemplateCallback;
            mGetChallengeTemplateCoroutine.Start(mGetChallengeTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetChallengeTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetChallengeTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeTemplateStartTime, mGetChallengeTemplatePath, string.Format("Response received successfully:\n{0}", GetChallengeTemplateData.ToString()));

            if (GetChallengeTemplateComplete != null)
            {
                GetChallengeTemplateComplete(GetChallengeTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search challenge templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetChallengeTemplates(int? size, int? page, string order)
        {
            
            mGetChallengeTemplatesPath = "/challenges/templates";
            if (!string.IsNullOrEmpty(mGetChallengeTemplatesPath))
            {
                mGetChallengeTemplatesPath = mGetChallengeTemplatesPath.Replace("{format}", "json");
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

            mGetChallengeTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetChallengeTemplatesStartTime, mGetChallengeTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetChallengeTemplatesCoroutine.ResponseReceived += GetChallengeTemplatesCallback;
            mGetChallengeTemplatesCoroutine.Start(mGetChallengeTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetChallengeTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallengeTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetChallengeTemplatesData = (PageResourceTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeTemplatesStartTime, mGetChallengeTemplatesPath, string.Format("Response received successfully:\n{0}", GetChallengeTemplatesData.ToString()));

            if (GetChallengeTemplatesComplete != null)
            {
                GetChallengeTemplatesComplete(GetChallengeTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve a list of challenges 
        /// </summary>
        /// <param name="filterActiveCampaign">Filter for challenges that are tied to active campaigns</param>
        /// <param name="filterStartDate">A comma separated string without spaces.  First value is the operator to search on, second value is the challenge start date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterEndDate">A comma separated string without spaces.  First value is the operator to search on, second value is the challenge end date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetChallenges(bool? filterActiveCampaign, string filterStartDate, string filterEndDate, int? size, int? page, string order)
        {
            
            mGetChallengesPath = "/challenges";
            if (!string.IsNullOrEmpty(mGetChallengesPath))
            {
                mGetChallengesPath = mGetChallengesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterActiveCampaign != null)
            {
                queryParams.Add("filter_active_campaign", KnetikClient.DefaultClient.ParameterToString(filterActiveCampaign));
            }

            if (filterStartDate != null)
            {
                queryParams.Add("filter_start_date", KnetikClient.DefaultClient.ParameterToString(filterStartDate));
            }

            if (filterEndDate != null)
            {
                queryParams.Add("filter_end_date", KnetikClient.DefaultClient.ParameterToString(filterEndDate));
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

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetChallengesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetChallengesStartTime, mGetChallengesPath, "Sending server request...");

            // make the HTTP request
            mGetChallengesCoroutine.ResponseReceived += GetChallengesCallback;
            mGetChallengesCoroutine.Start(mGetChallengesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetChallengesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallenges: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetChallenges: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetChallengesData = (PageResourceChallengeResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceChallengeResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengesStartTime, mGetChallengesPath, string.Format("Response received successfully:\n{0}", GetChallengesData.ToString()));

            if (GetChallengesComplete != null)
            {
                GetChallengesComplete(GetChallengesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a challenge If the challenge is a copy, changes will propagate to all the related challenges
        /// </summary>
        /// <param name="id">The challenge id</param>
        /// <param name="challengeResource">The challenge resource object</param>
        public void UpdateChallenge(long? id, ChallengeResource challengeResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateChallenge");
            }
            
            mUpdateChallengePath = "/challenges/{id}";
            if (!string.IsNullOrEmpty(mUpdateChallengePath))
            {
                mUpdateChallengePath = mUpdateChallengePath.Replace("{format}", "json");
            }
            mUpdateChallengePath = mUpdateChallengePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(challengeResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateChallengeStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateChallengeStartTime, mUpdateChallengePath, "Sending server request...");

            // make the HTTP request
            mUpdateChallengeCoroutine.ResponseReceived += UpdateChallengeCallback;
            mUpdateChallengeCoroutine.Start(mUpdateChallengePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateChallengeCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateChallenge: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateChallenge: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateChallengeData = (ChallengeResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ChallengeResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateChallengeStartTime, mUpdateChallengePath, string.Format("Response received successfully:\n{0}", UpdateChallengeData.ToString()));

            if (UpdateChallengeComplete != null)
            {
                UpdateChallengeComplete(UpdateChallengeData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a challenge activity A challenge can have multiple instances of the same activity and thus the id used is of the specific entry within the challenge
        /// </summary>
        /// <param name="id">The challenge_activity id</param>
        /// <param name="challengeId">The challenge id</param>
        /// <param name="challengeActivityResource">The challenge activity resource object</param>
        public void UpdateChallengeActivity(long? id, long? challengeId, ChallengeActivityResource challengeActivityResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateChallengeActivity");
            }
            // verify the required parameter 'challengeId' is set
            if (challengeId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'challengeId' when calling UpdateChallengeActivity");
            }
            
            mUpdateChallengeActivityPath = "/challenges/{challenge_id}/activities/{id}";
            if (!string.IsNullOrEmpty(mUpdateChallengeActivityPath))
            {
                mUpdateChallengeActivityPath = mUpdateChallengeActivityPath.Replace("{format}", "json");
            }
            mUpdateChallengeActivityPath = mUpdateChallengeActivityPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));
mUpdateChallengeActivityPath = mUpdateChallengeActivityPath.Replace("{" + "challenge_id" + "}", KnetikClient.DefaultClient.ParameterToString(challengeId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(challengeActivityResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateChallengeActivityStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateChallengeActivityStartTime, mUpdateChallengeActivityPath, "Sending server request...");

            // make the HTTP request
            mUpdateChallengeActivityCoroutine.ResponseReceived += UpdateChallengeActivityCallback;
            mUpdateChallengeActivityCoroutine.Start(mUpdateChallengeActivityPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateChallengeActivityCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateChallengeActivity: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateChallengeActivity: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateChallengeActivityData = (ChallengeActivityResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ChallengeActivityResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateChallengeActivityStartTime, mUpdateChallengeActivityPath, string.Format("Response received successfully:\n{0}", UpdateChallengeActivityData.ToString()));

            if (UpdateChallengeActivityComplete != null)
            {
                UpdateChallengeActivityComplete(UpdateChallengeActivityData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an challenge activity template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="challengeActivityTemplateResource">The challengeActivity template resource object</param>
        public void UpdateChallengeActivityTemplate(string id, TemplateResource challengeActivityTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateChallengeActivityTemplate");
            }
            
            mUpdateChallengeActivityTemplatePath = "/challenge-activities/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateChallengeActivityTemplatePath))
            {
                mUpdateChallengeActivityTemplatePath = mUpdateChallengeActivityTemplatePath.Replace("{format}", "json");
            }
            mUpdateChallengeActivityTemplatePath = mUpdateChallengeActivityTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(challengeActivityTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateChallengeActivityTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateChallengeActivityTemplateStartTime, mUpdateChallengeActivityTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateChallengeActivityTemplateCoroutine.ResponseReceived += UpdateChallengeActivityTemplateCallback;
            mUpdateChallengeActivityTemplateCoroutine.Start(mUpdateChallengeActivityTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateChallengeActivityTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateChallengeActivityTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateChallengeActivityTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateChallengeActivityTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateChallengeActivityTemplateStartTime, mUpdateChallengeActivityTemplatePath, string.Format("Response received successfully:\n{0}", UpdateChallengeActivityTemplateData.ToString()));

            if (UpdateChallengeActivityTemplateComplete != null)
            {
                UpdateChallengeActivityTemplateComplete(UpdateChallengeActivityTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a challenge template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="challengeTemplateResource">The challenge template resource object</param>
        public void UpdateChallengeTemplate(string id, TemplateResource challengeTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateChallengeTemplate");
            }
            
            mUpdateChallengeTemplatePath = "/challenges/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateChallengeTemplatePath))
            {
                mUpdateChallengeTemplatePath = mUpdateChallengeTemplatePath.Replace("{format}", "json");
            }
            mUpdateChallengeTemplatePath = mUpdateChallengeTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(challengeTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateChallengeTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateChallengeTemplateStartTime, mUpdateChallengeTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateChallengeTemplateCoroutine.ResponseReceived += UpdateChallengeTemplateCallback;
            mUpdateChallengeTemplateCoroutine.Start(mUpdateChallengeTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateChallengeTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateChallengeTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateChallengeTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateChallengeTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateChallengeTemplateStartTime, mUpdateChallengeTemplatePath, string.Format("Response received successfully:\n{0}", UpdateChallengeTemplateData.ToString()));

            if (UpdateChallengeTemplateComplete != null)
            {
                UpdateChallengeTemplateComplete(UpdateChallengeTemplateData);
            }
        }

    }
}
