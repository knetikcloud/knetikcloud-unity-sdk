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
    public interface ICampaignsChallengesApi
    {
        ChallengeResource CreateChallengeData { get; }

        /// <summary>
        /// Create a challenge Challenges do not run on their own.  They must be added to a campaign before events will spawn.
        /// </summary>
        /// <param name="challengeResource">The challenge resource object</param>
        void CreateChallenge(ChallengeResource challengeResource);

        ChallengeActivityResource CreateChallengeActivityData { get; }

        /// <summary>
        /// Create a challenge activity 
        /// </summary>
        /// <param name="challengeId">The challenge id</param>
        /// <param name="challengeActivityResource">The challenge activity resource object</param>
        /// <param name="validateSettings">Whether to validate the settings being sent against the available settings on the base activity.</param>
        void CreateChallengeActivity(long? challengeId, ChallengeActivityResource challengeActivityResource, bool? validateSettings);

        TemplateResource CreateChallengeActivityTemplateData { get; }

        /// <summary>
        /// Create a challenge activity template Challenge Activity Templates define a type of challenge activity and the properties they have
        /// </summary>
        /// <param name="challengeActivityTemplateResource">The challengeActivity template resource object</param>
        void CreateChallengeActivityTemplate(TemplateResource challengeActivityTemplateResource);

        TemplateResource CreateChallengeTemplateData { get; }

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

        ChallengeResource GetChallengeData { get; }

        /// <summary>
        /// Retrieve a challenge 
        /// </summary>
        /// <param name="id">The challenge id</param>
        void GetChallenge(long? id);

        PageResourceBareChallengeActivityResource GetChallengeActivitiesData { get; }

        /// <summary>
        /// List and search challenge activities 
        /// </summary>
        /// <param name="challengeId">The challenge id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetChallengeActivities(long? challengeId, int? size, int? page, string order);

        ChallengeActivityResource GetChallengeActivityData { get; }

        /// <summary>
        /// Get a single challenge activity A challenge can have multiple instances of the same activity and thus the id used is of the specific entry within the challenge
        /// </summary>
        /// <param name="id">The challenge_activity id</param>
        /// <param name="challengeId">The challenge id</param>
        void GetChallengeActivity(long? id, long? challengeId);

        TemplateResource GetChallengeActivityTemplateData { get; }

        /// <summary>
        /// Get a single challenge activity template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetChallengeActivityTemplate(string id);

        PageResourceTemplateResource GetChallengeActivityTemplatesData { get; }

        /// <summary>
        /// List and search challenge activity templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetChallengeActivityTemplates(int? size, int? page, string order);

        ChallengeEventResource GetChallengeEventData { get; }

        /// <summary>
        /// Retrieve a single challenge event details 
        /// </summary>
        /// <param name="id">The challenge event id</param>
        void GetChallengeEvent(long? id);

        PageResourceChallengeEventResource GetChallengeEventsData { get; }

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

        TemplateResource GetChallengeTemplateData { get; }

        /// <summary>
        /// Get a single challenge template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetChallengeTemplate(string id);

        PageResourceTemplateResource GetChallengeTemplatesData { get; }

        /// <summary>
        /// List and search challenge templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetChallengeTemplates(int? size, int? page, string order);

        PageResourceChallengeResource GetChallengesData { get; }

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

        ChallengeResource UpdateChallengeData { get; }

        /// <summary>
        /// Update a challenge If the challenge is a copy, changes will propagate to all the related challenges
        /// </summary>
        /// <param name="id">The challenge id</param>
        /// <param name="challengeResource">The challenge resource object</param>
        void UpdateChallenge(long? id, ChallengeResource challengeResource);

        ChallengeActivityResource UpdateChallengeActivityData { get; }

        /// <summary>
        /// Update a challenge activity A challenge can have multiple instances of the same activity and thus the id used is of the specific entry within the challenge
        /// </summary>
        /// <param name="id">The challenge_activity id</param>
        /// <param name="challengeId">The challenge id</param>
        /// <param name="challengeActivityResource">The challenge activity resource object</param>
        /// <param name="validateSettings">Whether to validate the settings being sent against the available settings on the base activity.</param>
        void UpdateChallengeActivity(long? id, long? challengeId, ChallengeActivityResource challengeActivityResource, bool? validateSettings);

        TemplateResource UpdateChallengeActivityTemplateData { get; }

        /// <summary>
        /// Update an challenge activity template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="challengeActivityTemplateResource">The challengeActivity template resource object</param>
        void UpdateChallengeActivityTemplate(string id, TemplateResource challengeActivityTemplateResource);

        TemplateResource UpdateChallengeTemplateData { get; }

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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateChallengeResponseContext;
        private DateTime mCreateChallengeStartTime;
        private readonly KnetikResponseContext mCreateChallengeActivityResponseContext;
        private DateTime mCreateChallengeActivityStartTime;
        private readonly KnetikResponseContext mCreateChallengeActivityTemplateResponseContext;
        private DateTime mCreateChallengeActivityTemplateStartTime;
        private readonly KnetikResponseContext mCreateChallengeTemplateResponseContext;
        private DateTime mCreateChallengeTemplateStartTime;
        private readonly KnetikResponseContext mDeleteChallengeResponseContext;
        private DateTime mDeleteChallengeStartTime;
        private readonly KnetikResponseContext mDeleteChallengeActivityResponseContext;
        private DateTime mDeleteChallengeActivityStartTime;
        private readonly KnetikResponseContext mDeleteChallengeActivityTemplateResponseContext;
        private DateTime mDeleteChallengeActivityTemplateStartTime;
        private readonly KnetikResponseContext mDeleteChallengeEventResponseContext;
        private DateTime mDeleteChallengeEventStartTime;
        private readonly KnetikResponseContext mDeleteChallengeTemplateResponseContext;
        private DateTime mDeleteChallengeTemplateStartTime;
        private readonly KnetikResponseContext mGetChallengeResponseContext;
        private DateTime mGetChallengeStartTime;
        private readonly KnetikResponseContext mGetChallengeActivitiesResponseContext;
        private DateTime mGetChallengeActivitiesStartTime;
        private readonly KnetikResponseContext mGetChallengeActivityResponseContext;
        private DateTime mGetChallengeActivityStartTime;
        private readonly KnetikResponseContext mGetChallengeActivityTemplateResponseContext;
        private DateTime mGetChallengeActivityTemplateStartTime;
        private readonly KnetikResponseContext mGetChallengeActivityTemplatesResponseContext;
        private DateTime mGetChallengeActivityTemplatesStartTime;
        private readonly KnetikResponseContext mGetChallengeEventResponseContext;
        private DateTime mGetChallengeEventStartTime;
        private readonly KnetikResponseContext mGetChallengeEventsResponseContext;
        private DateTime mGetChallengeEventsStartTime;
        private readonly KnetikResponseContext mGetChallengeTemplateResponseContext;
        private DateTime mGetChallengeTemplateStartTime;
        private readonly KnetikResponseContext mGetChallengeTemplatesResponseContext;
        private DateTime mGetChallengeTemplatesStartTime;
        private readonly KnetikResponseContext mGetChallengesResponseContext;
        private DateTime mGetChallengesStartTime;
        private readonly KnetikResponseContext mUpdateChallengeResponseContext;
        private DateTime mUpdateChallengeStartTime;
        private readonly KnetikResponseContext mUpdateChallengeActivityResponseContext;
        private DateTime mUpdateChallengeActivityStartTime;
        private readonly KnetikResponseContext mUpdateChallengeActivityTemplateResponseContext;
        private DateTime mUpdateChallengeActivityTemplateStartTime;
        private readonly KnetikResponseContext mUpdateChallengeTemplateResponseContext;
        private DateTime mUpdateChallengeTemplateStartTime;

        public ChallengeResource CreateChallengeData { get; private set; }
        public delegate void CreateChallengeCompleteDelegate(long responseCode, ChallengeResource response);
        public CreateChallengeCompleteDelegate CreateChallengeComplete;

        public ChallengeActivityResource CreateChallengeActivityData { get; private set; }
        public delegate void CreateChallengeActivityCompleteDelegate(long responseCode, ChallengeActivityResource response);
        public CreateChallengeActivityCompleteDelegate CreateChallengeActivityComplete;

        public TemplateResource CreateChallengeActivityTemplateData { get; private set; }
        public delegate void CreateChallengeActivityTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateChallengeActivityTemplateCompleteDelegate CreateChallengeActivityTemplateComplete;

        public TemplateResource CreateChallengeTemplateData { get; private set; }
        public delegate void CreateChallengeTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateChallengeTemplateCompleteDelegate CreateChallengeTemplateComplete;

        public delegate void DeleteChallengeCompleteDelegate(long responseCode);
        public DeleteChallengeCompleteDelegate DeleteChallengeComplete;

        public delegate void DeleteChallengeActivityCompleteDelegate(long responseCode);
        public DeleteChallengeActivityCompleteDelegate DeleteChallengeActivityComplete;

        public delegate void DeleteChallengeActivityTemplateCompleteDelegate(long responseCode);
        public DeleteChallengeActivityTemplateCompleteDelegate DeleteChallengeActivityTemplateComplete;

        public delegate void DeleteChallengeEventCompleteDelegate(long responseCode);
        public DeleteChallengeEventCompleteDelegate DeleteChallengeEventComplete;

        public delegate void DeleteChallengeTemplateCompleteDelegate(long responseCode);
        public DeleteChallengeTemplateCompleteDelegate DeleteChallengeTemplateComplete;

        public ChallengeResource GetChallengeData { get; private set; }
        public delegate void GetChallengeCompleteDelegate(long responseCode, ChallengeResource response);
        public GetChallengeCompleteDelegate GetChallengeComplete;

        public PageResourceBareChallengeActivityResource GetChallengeActivitiesData { get; private set; }
        public delegate void GetChallengeActivitiesCompleteDelegate(long responseCode, PageResourceBareChallengeActivityResource response);
        public GetChallengeActivitiesCompleteDelegate GetChallengeActivitiesComplete;

        public ChallengeActivityResource GetChallengeActivityData { get; private set; }
        public delegate void GetChallengeActivityCompleteDelegate(long responseCode, ChallengeActivityResource response);
        public GetChallengeActivityCompleteDelegate GetChallengeActivityComplete;

        public TemplateResource GetChallengeActivityTemplateData { get; private set; }
        public delegate void GetChallengeActivityTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetChallengeActivityTemplateCompleteDelegate GetChallengeActivityTemplateComplete;

        public PageResourceTemplateResource GetChallengeActivityTemplatesData { get; private set; }
        public delegate void GetChallengeActivityTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetChallengeActivityTemplatesCompleteDelegate GetChallengeActivityTemplatesComplete;

        public ChallengeEventResource GetChallengeEventData { get; private set; }
        public delegate void GetChallengeEventCompleteDelegate(long responseCode, ChallengeEventResource response);
        public GetChallengeEventCompleteDelegate GetChallengeEventComplete;

        public PageResourceChallengeEventResource GetChallengeEventsData { get; private set; }
        public delegate void GetChallengeEventsCompleteDelegate(long responseCode, PageResourceChallengeEventResource response);
        public GetChallengeEventsCompleteDelegate GetChallengeEventsComplete;

        public TemplateResource GetChallengeTemplateData { get; private set; }
        public delegate void GetChallengeTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetChallengeTemplateCompleteDelegate GetChallengeTemplateComplete;

        public PageResourceTemplateResource GetChallengeTemplatesData { get; private set; }
        public delegate void GetChallengeTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetChallengeTemplatesCompleteDelegate GetChallengeTemplatesComplete;

        public PageResourceChallengeResource GetChallengesData { get; private set; }
        public delegate void GetChallengesCompleteDelegate(long responseCode, PageResourceChallengeResource response);
        public GetChallengesCompleteDelegate GetChallengesComplete;

        public ChallengeResource UpdateChallengeData { get; private set; }
        public delegate void UpdateChallengeCompleteDelegate(long responseCode, ChallengeResource response);
        public UpdateChallengeCompleteDelegate UpdateChallengeComplete;

        public ChallengeActivityResource UpdateChallengeActivityData { get; private set; }
        public delegate void UpdateChallengeActivityCompleteDelegate(long responseCode, ChallengeActivityResource response);
        public UpdateChallengeActivityCompleteDelegate UpdateChallengeActivityComplete;

        public TemplateResource UpdateChallengeActivityTemplateData { get; private set; }
        public delegate void UpdateChallengeActivityTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateChallengeActivityTemplateCompleteDelegate UpdateChallengeActivityTemplateComplete;

        public TemplateResource UpdateChallengeTemplateData { get; private set; }
        public delegate void UpdateChallengeTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateChallengeTemplateCompleteDelegate UpdateChallengeTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignsChallengesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CampaignsChallengesApi()
        {
            mCreateChallengeResponseContext = new KnetikResponseContext();
            mCreateChallengeResponseContext.ResponseReceived += OnCreateChallengeResponse;
            mCreateChallengeActivityResponseContext = new KnetikResponseContext();
            mCreateChallengeActivityResponseContext.ResponseReceived += OnCreateChallengeActivityResponse;
            mCreateChallengeActivityTemplateResponseContext = new KnetikResponseContext();
            mCreateChallengeActivityTemplateResponseContext.ResponseReceived += OnCreateChallengeActivityTemplateResponse;
            mCreateChallengeTemplateResponseContext = new KnetikResponseContext();
            mCreateChallengeTemplateResponseContext.ResponseReceived += OnCreateChallengeTemplateResponse;
            mDeleteChallengeResponseContext = new KnetikResponseContext();
            mDeleteChallengeResponseContext.ResponseReceived += OnDeleteChallengeResponse;
            mDeleteChallengeActivityResponseContext = new KnetikResponseContext();
            mDeleteChallengeActivityResponseContext.ResponseReceived += OnDeleteChallengeActivityResponse;
            mDeleteChallengeActivityTemplateResponseContext = new KnetikResponseContext();
            mDeleteChallengeActivityTemplateResponseContext.ResponseReceived += OnDeleteChallengeActivityTemplateResponse;
            mDeleteChallengeEventResponseContext = new KnetikResponseContext();
            mDeleteChallengeEventResponseContext.ResponseReceived += OnDeleteChallengeEventResponse;
            mDeleteChallengeTemplateResponseContext = new KnetikResponseContext();
            mDeleteChallengeTemplateResponseContext.ResponseReceived += OnDeleteChallengeTemplateResponse;
            mGetChallengeResponseContext = new KnetikResponseContext();
            mGetChallengeResponseContext.ResponseReceived += OnGetChallengeResponse;
            mGetChallengeActivitiesResponseContext = new KnetikResponseContext();
            mGetChallengeActivitiesResponseContext.ResponseReceived += OnGetChallengeActivitiesResponse;
            mGetChallengeActivityResponseContext = new KnetikResponseContext();
            mGetChallengeActivityResponseContext.ResponseReceived += OnGetChallengeActivityResponse;
            mGetChallengeActivityTemplateResponseContext = new KnetikResponseContext();
            mGetChallengeActivityTemplateResponseContext.ResponseReceived += OnGetChallengeActivityTemplateResponse;
            mGetChallengeActivityTemplatesResponseContext = new KnetikResponseContext();
            mGetChallengeActivityTemplatesResponseContext.ResponseReceived += OnGetChallengeActivityTemplatesResponse;
            mGetChallengeEventResponseContext = new KnetikResponseContext();
            mGetChallengeEventResponseContext.ResponseReceived += OnGetChallengeEventResponse;
            mGetChallengeEventsResponseContext = new KnetikResponseContext();
            mGetChallengeEventsResponseContext.ResponseReceived += OnGetChallengeEventsResponse;
            mGetChallengeTemplateResponseContext = new KnetikResponseContext();
            mGetChallengeTemplateResponseContext.ResponseReceived += OnGetChallengeTemplateResponse;
            mGetChallengeTemplatesResponseContext = new KnetikResponseContext();
            mGetChallengeTemplatesResponseContext.ResponseReceived += OnGetChallengeTemplatesResponse;
            mGetChallengesResponseContext = new KnetikResponseContext();
            mGetChallengesResponseContext.ResponseReceived += OnGetChallengesResponse;
            mUpdateChallengeResponseContext = new KnetikResponseContext();
            mUpdateChallengeResponseContext.ResponseReceived += OnUpdateChallengeResponse;
            mUpdateChallengeActivityResponseContext = new KnetikResponseContext();
            mUpdateChallengeActivityResponseContext.ResponseReceived += OnUpdateChallengeActivityResponse;
            mUpdateChallengeActivityTemplateResponseContext = new KnetikResponseContext();
            mUpdateChallengeActivityTemplateResponseContext.ResponseReceived += OnUpdateChallengeActivityTemplateResponse;
            mUpdateChallengeTemplateResponseContext = new KnetikResponseContext();
            mUpdateChallengeTemplateResponseContext.ResponseReceived += OnUpdateChallengeTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a challenge Challenges do not run on their own.  They must be added to a campaign before events will spawn.
        /// </summary>
        /// <param name="challengeResource">The challenge resource object</param>
        public void CreateChallenge(ChallengeResource challengeResource)
        {
            
            mWebCallEvent.WebPath = "/challenges";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(challengeResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateChallengeStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateChallengeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateChallengeStartTime, "CreateChallenge", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateChallengeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateChallenge: " + response.Error);
            }

            CreateChallengeData = (ChallengeResource) KnetikClient.Deserialize(response.Content, typeof(ChallengeResource), response.Headers);
            KnetikLogger.LogResponse(mCreateChallengeStartTime, "CreateChallenge", string.Format("Response received successfully:\n{0}", CreateChallengeData));

            if (CreateChallengeComplete != null)
            {
                CreateChallengeComplete(response.ResponseCode, CreateChallengeData);
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
            
            mWebCallEvent.WebPath = "/challenges/{challenge_id}/activities";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "challenge_id" + "}", KnetikClient.ParameterToString(challengeId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (validateSettings != null)
            {
                mWebCallEvent.QueryParams["validate_settings"] = KnetikClient.ParameterToString(validateSettings);
            }

            mWebCallEvent.PostBody = KnetikClient.Serialize(challengeActivityResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateChallengeActivityStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateChallengeActivityResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateChallengeActivityStartTime, "CreateChallengeActivity", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateChallengeActivityResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateChallengeActivity: " + response.Error);
            }

            CreateChallengeActivityData = (ChallengeActivityResource) KnetikClient.Deserialize(response.Content, typeof(ChallengeActivityResource), response.Headers);
            KnetikLogger.LogResponse(mCreateChallengeActivityStartTime, "CreateChallengeActivity", string.Format("Response received successfully:\n{0}", CreateChallengeActivityData));

            if (CreateChallengeActivityComplete != null)
            {
                CreateChallengeActivityComplete(response.ResponseCode, CreateChallengeActivityData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a challenge activity template Challenge Activity Templates define a type of challenge activity and the properties they have
        /// </summary>
        /// <param name="challengeActivityTemplateResource">The challengeActivity template resource object</param>
        public void CreateChallengeActivityTemplate(TemplateResource challengeActivityTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/challenge-activities/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(challengeActivityTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateChallengeActivityTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateChallengeActivityTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateChallengeActivityTemplateStartTime, "CreateChallengeActivityTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateChallengeActivityTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateChallengeActivityTemplate: " + response.Error);
            }

            CreateChallengeActivityTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateChallengeActivityTemplateStartTime, "CreateChallengeActivityTemplate", string.Format("Response received successfully:\n{0}", CreateChallengeActivityTemplateData));

            if (CreateChallengeActivityTemplateComplete != null)
            {
                CreateChallengeActivityTemplateComplete(response.ResponseCode, CreateChallengeActivityTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a challenge template Challenge Templates define a type of challenge and the properties they have
        /// </summary>
        /// <param name="challengeTemplateResource">The challenge template resource object</param>
        public void CreateChallengeTemplate(TemplateResource challengeTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/challenges/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(challengeTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateChallengeTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateChallengeTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateChallengeTemplateStartTime, "CreateChallengeTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateChallengeTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateChallengeTemplate: " + response.Error);
            }

            CreateChallengeTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateChallengeTemplateStartTime, "CreateChallengeTemplate", string.Format("Response received successfully:\n{0}", CreateChallengeTemplateData));

            if (CreateChallengeTemplateComplete != null)
            {
                CreateChallengeTemplateComplete(response.ResponseCode, CreateChallengeTemplateData);
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
            
            mWebCallEvent.WebPath = "/challenges/{id}";
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
            mDeleteChallengeStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteChallengeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteChallengeStartTime, "DeleteChallenge", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteChallengeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteChallenge: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteChallengeStartTime, "DeleteChallenge", "Response received successfully.");
            if (DeleteChallengeComplete != null)
            {
                DeleteChallengeComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/challenges/{challenge_id}/activities/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "challenge_id" + "}", KnetikClient.ParameterToString(challengeId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteChallengeActivityStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteChallengeActivityResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteChallengeActivityStartTime, "DeleteChallengeActivity", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteChallengeActivityResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteChallengeActivity: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteChallengeActivityStartTime, "DeleteChallengeActivity", "Response received successfully.");
            if (DeleteChallengeActivityComplete != null)
            {
                DeleteChallengeActivityComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/challenge-activities/templates/{id}";
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
            mDeleteChallengeActivityTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteChallengeActivityTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteChallengeActivityTemplateStartTime, "DeleteChallengeActivityTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteChallengeActivityTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteChallengeActivityTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteChallengeActivityTemplateStartTime, "DeleteChallengeActivityTemplate", "Response received successfully.");
            if (DeleteChallengeActivityTemplateComplete != null)
            {
                DeleteChallengeActivityTemplateComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/challenges/events/{id}";
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
            mDeleteChallengeEventStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteChallengeEventResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteChallengeEventStartTime, "DeleteChallengeEvent", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteChallengeEventResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteChallengeEvent: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteChallengeEventStartTime, "DeleteChallengeEvent", "Response received successfully.");
            if (DeleteChallengeEventComplete != null)
            {
                DeleteChallengeEventComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/challenges/templates/{id}";
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
            mDeleteChallengeTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteChallengeTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteChallengeTemplateStartTime, "DeleteChallengeTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteChallengeTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteChallengeTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteChallengeTemplateStartTime, "DeleteChallengeTemplate", "Response received successfully.");
            if (DeleteChallengeTemplateComplete != null)
            {
                DeleteChallengeTemplateComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/challenges/{id}";
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
            mGetChallengeStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChallengeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChallengeStartTime, "GetChallenge", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChallengeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChallenge: " + response.Error);
            }

            GetChallengeData = (ChallengeResource) KnetikClient.Deserialize(response.Content, typeof(ChallengeResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeStartTime, "GetChallenge", string.Format("Response received successfully:\n{0}", GetChallengeData));

            if (GetChallengeComplete != null)
            {
                GetChallengeComplete(response.ResponseCode, GetChallengeData);
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
            
            mWebCallEvent.WebPath = "/challenges/{challenge_id}/activities";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "challenge_id" + "}", KnetikClient.ParameterToString(challengeId));

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
            mGetChallengeActivitiesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChallengeActivitiesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChallengeActivitiesStartTime, "GetChallengeActivities", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChallengeActivitiesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChallengeActivities: " + response.Error);
            }

            GetChallengeActivitiesData = (PageResourceBareChallengeActivityResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceBareChallengeActivityResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeActivitiesStartTime, "GetChallengeActivities", string.Format("Response received successfully:\n{0}", GetChallengeActivitiesData));

            if (GetChallengeActivitiesComplete != null)
            {
                GetChallengeActivitiesComplete(response.ResponseCode, GetChallengeActivitiesData);
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
            
            mWebCallEvent.WebPath = "/challenges/{challenge_id}/activities/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "challenge_id" + "}", KnetikClient.ParameterToString(challengeId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetChallengeActivityStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChallengeActivityResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChallengeActivityStartTime, "GetChallengeActivity", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChallengeActivityResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChallengeActivity: " + response.Error);
            }

            GetChallengeActivityData = (ChallengeActivityResource) KnetikClient.Deserialize(response.Content, typeof(ChallengeActivityResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeActivityStartTime, "GetChallengeActivity", string.Format("Response received successfully:\n{0}", GetChallengeActivityData));

            if (GetChallengeActivityComplete != null)
            {
                GetChallengeActivityComplete(response.ResponseCode, GetChallengeActivityData);
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
            
            mWebCallEvent.WebPath = "/challenge-activities/templates/{id}";
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
            mGetChallengeActivityTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChallengeActivityTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChallengeActivityTemplateStartTime, "GetChallengeActivityTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChallengeActivityTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChallengeActivityTemplate: " + response.Error);
            }

            GetChallengeActivityTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeActivityTemplateStartTime, "GetChallengeActivityTemplate", string.Format("Response received successfully:\n{0}", GetChallengeActivityTemplateData));

            if (GetChallengeActivityTemplateComplete != null)
            {
                GetChallengeActivityTemplateComplete(response.ResponseCode, GetChallengeActivityTemplateData);
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
            
            mWebCallEvent.WebPath = "/challenge-activities/templates";
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
            mGetChallengeActivityTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChallengeActivityTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChallengeActivityTemplatesStartTime, "GetChallengeActivityTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChallengeActivityTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChallengeActivityTemplates: " + response.Error);
            }

            GetChallengeActivityTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeActivityTemplatesStartTime, "GetChallengeActivityTemplates", string.Format("Response received successfully:\n{0}", GetChallengeActivityTemplatesData));

            if (GetChallengeActivityTemplatesComplete != null)
            {
                GetChallengeActivityTemplatesComplete(response.ResponseCode, GetChallengeActivityTemplatesData);
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
            
            mWebCallEvent.WebPath = "/challenges/events/{id}";
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
            mGetChallengeEventStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChallengeEventResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChallengeEventStartTime, "GetChallengeEvent", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChallengeEventResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChallengeEvent: " + response.Error);
            }

            GetChallengeEventData = (ChallengeEventResource) KnetikClient.Deserialize(response.Content, typeof(ChallengeEventResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeEventStartTime, "GetChallengeEvent", string.Format("Response received successfully:\n{0}", GetChallengeEventData));

            if (GetChallengeEventComplete != null)
            {
                GetChallengeEventComplete(response.ResponseCode, GetChallengeEventData);
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
            
            mWebCallEvent.WebPath = "/challenges/events";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterStartDate != null)
            {
                mWebCallEvent.QueryParams["filter_start_date"] = KnetikClient.ParameterToString(filterStartDate);
            }

            if (filterEndDate != null)
            {
                mWebCallEvent.QueryParams["filter_end_date"] = KnetikClient.ParameterToString(filterEndDate);
            }

            if (filterCampaigns != null)
            {
                mWebCallEvent.QueryParams["filter_campaigns"] = KnetikClient.ParameterToString(filterCampaigns);
            }

            if (filterChallenge != null)
            {
                mWebCallEvent.QueryParams["filter_challenge"] = KnetikClient.ParameterToString(filterChallenge);
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

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetChallengeEventsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChallengeEventsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChallengeEventsStartTime, "GetChallengeEvents", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChallengeEventsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChallengeEvents: " + response.Error);
            }

            GetChallengeEventsData = (PageResourceChallengeEventResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceChallengeEventResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeEventsStartTime, "GetChallengeEvents", string.Format("Response received successfully:\n{0}", GetChallengeEventsData));

            if (GetChallengeEventsComplete != null)
            {
                GetChallengeEventsComplete(response.ResponseCode, GetChallengeEventsData);
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
            
            mWebCallEvent.WebPath = "/challenges/templates/{id}";
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
            mGetChallengeTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChallengeTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChallengeTemplateStartTime, "GetChallengeTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChallengeTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChallengeTemplate: " + response.Error);
            }

            GetChallengeTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeTemplateStartTime, "GetChallengeTemplate", string.Format("Response received successfully:\n{0}", GetChallengeTemplateData));

            if (GetChallengeTemplateComplete != null)
            {
                GetChallengeTemplateComplete(response.ResponseCode, GetChallengeTemplateData);
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
            
            mWebCallEvent.WebPath = "/challenges/templates";
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
            mGetChallengeTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChallengeTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChallengeTemplatesStartTime, "GetChallengeTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChallengeTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChallengeTemplates: " + response.Error);
            }

            GetChallengeTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengeTemplatesStartTime, "GetChallengeTemplates", string.Format("Response received successfully:\n{0}", GetChallengeTemplatesData));

            if (GetChallengeTemplatesComplete != null)
            {
                GetChallengeTemplatesComplete(response.ResponseCode, GetChallengeTemplatesData);
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
            
            mWebCallEvent.WebPath = "/challenges";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterActiveCampaign != null)
            {
                mWebCallEvent.QueryParams["filter_active_campaign"] = KnetikClient.ParameterToString(filterActiveCampaign);
            }

            if (filterStartDate != null)
            {
                mWebCallEvent.QueryParams["filter_start_date"] = KnetikClient.ParameterToString(filterStartDate);
            }

            if (filterEndDate != null)
            {
                mWebCallEvent.QueryParams["filter_end_date"] = KnetikClient.ParameterToString(filterEndDate);
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

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetChallengesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChallengesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChallengesStartTime, "GetChallenges", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChallengesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChallenges: " + response.Error);
            }

            GetChallengesData = (PageResourceChallengeResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceChallengeResource), response.Headers);
            KnetikLogger.LogResponse(mGetChallengesStartTime, "GetChallenges", string.Format("Response received successfully:\n{0}", GetChallengesData));

            if (GetChallengesComplete != null)
            {
                GetChallengesComplete(response.ResponseCode, GetChallengesData);
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
            
            mWebCallEvent.WebPath = "/challenges/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(challengeResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateChallengeStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateChallengeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateChallengeStartTime, "UpdateChallenge", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateChallengeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateChallenge: " + response.Error);
            }

            UpdateChallengeData = (ChallengeResource) KnetikClient.Deserialize(response.Content, typeof(ChallengeResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateChallengeStartTime, "UpdateChallenge", string.Format("Response received successfully:\n{0}", UpdateChallengeData));

            if (UpdateChallengeComplete != null)
            {
                UpdateChallengeComplete(response.ResponseCode, UpdateChallengeData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a challenge activity A challenge can have multiple instances of the same activity and thus the id used is of the specific entry within the challenge
        /// </summary>
        /// <param name="id">The challenge_activity id</param>
        /// <param name="challengeId">The challenge id</param>
        /// <param name="challengeActivityResource">The challenge activity resource object</param>
        /// <param name="validateSettings">Whether to validate the settings being sent against the available settings on the base activity.</param>
        public void UpdateChallengeActivity(long? id, long? challengeId, ChallengeActivityResource challengeActivityResource, bool? validateSettings)
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
            
            mWebCallEvent.WebPath = "/challenges/{challenge_id}/activities/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "challenge_id" + "}", KnetikClient.ParameterToString(challengeId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (validateSettings != null)
            {
                mWebCallEvent.QueryParams["validateSettings"] = KnetikClient.ParameterToString(validateSettings);
            }

            mWebCallEvent.PostBody = KnetikClient.Serialize(challengeActivityResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateChallengeActivityStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateChallengeActivityResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateChallengeActivityStartTime, "UpdateChallengeActivity", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateChallengeActivityResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateChallengeActivity: " + response.Error);
            }

            UpdateChallengeActivityData = (ChallengeActivityResource) KnetikClient.Deserialize(response.Content, typeof(ChallengeActivityResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateChallengeActivityStartTime, "UpdateChallengeActivity", string.Format("Response received successfully:\n{0}", UpdateChallengeActivityData));

            if (UpdateChallengeActivityComplete != null)
            {
                UpdateChallengeActivityComplete(response.ResponseCode, UpdateChallengeActivityData);
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
            
            mWebCallEvent.WebPath = "/challenge-activities/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(challengeActivityTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateChallengeActivityTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateChallengeActivityTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateChallengeActivityTemplateStartTime, "UpdateChallengeActivityTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateChallengeActivityTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateChallengeActivityTemplate: " + response.Error);
            }

            UpdateChallengeActivityTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateChallengeActivityTemplateStartTime, "UpdateChallengeActivityTemplate", string.Format("Response received successfully:\n{0}", UpdateChallengeActivityTemplateData));

            if (UpdateChallengeActivityTemplateComplete != null)
            {
                UpdateChallengeActivityTemplateComplete(response.ResponseCode, UpdateChallengeActivityTemplateData);
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
            
            mWebCallEvent.WebPath = "/challenges/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(challengeTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateChallengeTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateChallengeTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateChallengeTemplateStartTime, "UpdateChallengeTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateChallengeTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateChallengeTemplate: " + response.Error);
            }

            UpdateChallengeTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateChallengeTemplateStartTime, "UpdateChallengeTemplate", string.Format("Response received successfully:\n{0}", UpdateChallengeTemplateData));

            if (UpdateChallengeTemplateComplete != null)
            {
                UpdateChallengeTemplateComplete(response.ResponseCode, UpdateChallengeTemplateData);
            }
        }

    }
}
