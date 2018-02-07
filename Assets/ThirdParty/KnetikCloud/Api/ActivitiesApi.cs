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
    public interface IActivitiesApi
    {
        ActivityResource CreateActivityData { get; }

        /// <summary>
        /// Create an activity 
        /// </summary>
        /// <param name="activityResource">The activity resource object</param>
        void CreateActivity(ActivityResource activityResource);

        ActivityOccurrenceResource CreateActivityOccurrenceData { get; }

        /// <summary>
        /// Create a new activity occurrence. Ex: start a game Has to enforce extra rules if not used as an admin
        /// </summary>
        /// <param name="test">if true, indicates that the occurrence should NOT be created. This can be used to test for eligibility and valid settings</param>
        /// <param name="activityOccurrenceResource">The activity occurrence object</param>
        void CreateActivityOccurrence(bool? test, CreateActivityOccurrenceRequest activityOccurrenceResource);

        TemplateResource CreateActivityTemplateData { get; }

        /// <summary>
        /// Create a activity template Activity Templates define a type of activity and the properties they have
        /// </summary>
        /// <param name="activityTemplateResource">The activity template resource object</param>
        void CreateActivityTemplate(TemplateResource activityTemplateResource);

        

        /// <summary>
        /// Delete an activity 
        /// </summary>
        /// <param name="id">The id of the activity</param>
        void DeleteActivity(long? id);

        

        /// <summary>
        /// Delete a activity template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteActivityTemplate(string id, string cascade);

        PageResourceBareActivityResource GetActivitiesData { get; }

        /// <summary>
        /// List activity definitions 
        /// </summary>
        /// <param name="filterTemplate">Filter for activities that are templates, or specifically not if false</param>
        /// <param name="filterName">Filter for activities that have a name starting with specified string</param>
        /// <param name="filterId">Filter for activities with an id in the given comma separated list of ids</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetActivities(bool? filterTemplate, string filterName, string filterId, int? size, int? page, string order);

        ActivityResource GetActivityData { get; }

        /// <summary>
        /// Get a single activity 
        /// </summary>
        /// <param name="id">The id of the activity</param>
        void GetActivity(long? id);

        ActivityOccurrenceResource GetActivityOccurrenceDetailsData { get; }

        /// <summary>
        /// Load a single activity occurrence details 
        /// </summary>
        /// <param name="activityOccurrenceId">The id of the activity occurrence</param>
        void GetActivityOccurrenceDetails(long? activityOccurrenceId);

        TemplateResource GetActivityTemplateData { get; }

        /// <summary>
        /// Get a single activity template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetActivityTemplate(string id);

        PageResourceTemplateResource GetActivityTemplatesData { get; }

        /// <summary>
        /// List and search activity templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetActivityTemplates(int? size, int? page, string order);

        PageResourceActivityOccurrenceResource ListActivityOccurrencesData { get; }

        /// <summary>
        /// List activity occurrences 
        /// </summary>
        /// <param name="filterActivity">Filter for occurrences of the given activity ID</param>
        /// <param name="filterStatus">Filter for occurrences of the given activity ID</param>
        /// <param name="filterEvent">Filter for occurrences played during the given event</param>
        /// <param name="filterChallenge">Filter for occurrences played within the given challenge</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void ListActivityOccurrences(string filterActivity, string filterStatus, int? filterEvent, int? filterChallenge, int? size, int? page, string order);

        ActivityOccurrenceResults SetActivityOccurrenceResultsData { get; }

        /// <summary>
        /// Sets the status of an activity occurrence to FINISHED and logs metrics 
        /// </summary>
        /// <param name="activityOccurrenceId">The id of the activity occurrence</param>
        /// <param name="activityOccurrenceResults">The activity occurrence object</param>
        void SetActivityOccurrenceResults(long? activityOccurrenceId, ActivityOccurrenceResultsResource activityOccurrenceResults);

        ActivityResource UpdateActivityData { get; }

        /// <summary>
        /// Update an activity 
        /// </summary>
        /// <param name="id">The id of the activity</param>
        /// <param name="activityResource">The activity resource object</param>
        void UpdateActivity(long? id, ActivityResource activityResource);

        

        /// <summary>
        /// Updated the status of an activity occurrence If setting to &#39;FINISHED&#39; reward will be run based on current metrics that have been recorded already. Aternatively, see results endpoint to finish and record all metrics at once.
        /// </summary>
        /// <param name="activityOccurrenceId">The id of the activity occurrence</param>
        /// <param name="activityOccurrenceStatus">The activity occurrence status object</param>
        void UpdateActivityOccurrence(long? activityOccurrenceId, string activityOccurrenceStatus);

        TemplateResource UpdateActivityTemplateData { get; }

        /// <summary>
        /// Update an activity template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="activityTemplateResource">The activity template resource object</param>
        void UpdateActivityTemplate(string id, TemplateResource activityTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ActivitiesApi : IActivitiesApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateActivityResponseContext;
        private DateTime mCreateActivityStartTime;
        private readonly KnetikResponseContext mCreateActivityOccurrenceResponseContext;
        private DateTime mCreateActivityOccurrenceStartTime;
        private readonly KnetikResponseContext mCreateActivityTemplateResponseContext;
        private DateTime mCreateActivityTemplateStartTime;
        private readonly KnetikResponseContext mDeleteActivityResponseContext;
        private DateTime mDeleteActivityStartTime;
        private readonly KnetikResponseContext mDeleteActivityTemplateResponseContext;
        private DateTime mDeleteActivityTemplateStartTime;
        private readonly KnetikResponseContext mGetActivitiesResponseContext;
        private DateTime mGetActivitiesStartTime;
        private readonly KnetikResponseContext mGetActivityResponseContext;
        private DateTime mGetActivityStartTime;
        private readonly KnetikResponseContext mGetActivityOccurrenceDetailsResponseContext;
        private DateTime mGetActivityOccurrenceDetailsStartTime;
        private readonly KnetikResponseContext mGetActivityTemplateResponseContext;
        private DateTime mGetActivityTemplateStartTime;
        private readonly KnetikResponseContext mGetActivityTemplatesResponseContext;
        private DateTime mGetActivityTemplatesStartTime;
        private readonly KnetikResponseContext mListActivityOccurrencesResponseContext;
        private DateTime mListActivityOccurrencesStartTime;
        private readonly KnetikResponseContext mSetActivityOccurrenceResultsResponseContext;
        private DateTime mSetActivityOccurrenceResultsStartTime;
        private readonly KnetikResponseContext mUpdateActivityResponseContext;
        private DateTime mUpdateActivityStartTime;
        private readonly KnetikResponseContext mUpdateActivityOccurrenceResponseContext;
        private DateTime mUpdateActivityOccurrenceStartTime;
        private readonly KnetikResponseContext mUpdateActivityTemplateResponseContext;
        private DateTime mUpdateActivityTemplateStartTime;

        public ActivityResource CreateActivityData { get; private set; }
        public delegate void CreateActivityCompleteDelegate(long responseCode, ActivityResource response);
        public CreateActivityCompleteDelegate CreateActivityComplete;

        public ActivityOccurrenceResource CreateActivityOccurrenceData { get; private set; }
        public delegate void CreateActivityOccurrenceCompleteDelegate(long responseCode, ActivityOccurrenceResource response);
        public CreateActivityOccurrenceCompleteDelegate CreateActivityOccurrenceComplete;

        public TemplateResource CreateActivityTemplateData { get; private set; }
        public delegate void CreateActivityTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateActivityTemplateCompleteDelegate CreateActivityTemplateComplete;

        public delegate void DeleteActivityCompleteDelegate(long responseCode);
        public DeleteActivityCompleteDelegate DeleteActivityComplete;

        public delegate void DeleteActivityTemplateCompleteDelegate(long responseCode);
        public DeleteActivityTemplateCompleteDelegate DeleteActivityTemplateComplete;

        public PageResourceBareActivityResource GetActivitiesData { get; private set; }
        public delegate void GetActivitiesCompleteDelegate(long responseCode, PageResourceBareActivityResource response);
        public GetActivitiesCompleteDelegate GetActivitiesComplete;

        public ActivityResource GetActivityData { get; private set; }
        public delegate void GetActivityCompleteDelegate(long responseCode, ActivityResource response);
        public GetActivityCompleteDelegate GetActivityComplete;

        public ActivityOccurrenceResource GetActivityOccurrenceDetailsData { get; private set; }
        public delegate void GetActivityOccurrenceDetailsCompleteDelegate(long responseCode, ActivityOccurrenceResource response);
        public GetActivityOccurrenceDetailsCompleteDelegate GetActivityOccurrenceDetailsComplete;

        public TemplateResource GetActivityTemplateData { get; private set; }
        public delegate void GetActivityTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetActivityTemplateCompleteDelegate GetActivityTemplateComplete;

        public PageResourceTemplateResource GetActivityTemplatesData { get; private set; }
        public delegate void GetActivityTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetActivityTemplatesCompleteDelegate GetActivityTemplatesComplete;

        public PageResourceActivityOccurrenceResource ListActivityOccurrencesData { get; private set; }
        public delegate void ListActivityOccurrencesCompleteDelegate(long responseCode, PageResourceActivityOccurrenceResource response);
        public ListActivityOccurrencesCompleteDelegate ListActivityOccurrencesComplete;

        public ActivityOccurrenceResults SetActivityOccurrenceResultsData { get; private set; }
        public delegate void SetActivityOccurrenceResultsCompleteDelegate(long responseCode, ActivityOccurrenceResults response);
        public SetActivityOccurrenceResultsCompleteDelegate SetActivityOccurrenceResultsComplete;

        public ActivityResource UpdateActivityData { get; private set; }
        public delegate void UpdateActivityCompleteDelegate(long responseCode, ActivityResource response);
        public UpdateActivityCompleteDelegate UpdateActivityComplete;

        public delegate void UpdateActivityOccurrenceCompleteDelegate(long responseCode);
        public UpdateActivityOccurrenceCompleteDelegate UpdateActivityOccurrenceComplete;

        public TemplateResource UpdateActivityTemplateData { get; private set; }
        public delegate void UpdateActivityTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateActivityTemplateCompleteDelegate UpdateActivityTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivitiesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ActivitiesApi()
        {
            mCreateActivityResponseContext = new KnetikResponseContext();
            mCreateActivityResponseContext.ResponseReceived += OnCreateActivityResponse;
            mCreateActivityOccurrenceResponseContext = new KnetikResponseContext();
            mCreateActivityOccurrenceResponseContext.ResponseReceived += OnCreateActivityOccurrenceResponse;
            mCreateActivityTemplateResponseContext = new KnetikResponseContext();
            mCreateActivityTemplateResponseContext.ResponseReceived += OnCreateActivityTemplateResponse;
            mDeleteActivityResponseContext = new KnetikResponseContext();
            mDeleteActivityResponseContext.ResponseReceived += OnDeleteActivityResponse;
            mDeleteActivityTemplateResponseContext = new KnetikResponseContext();
            mDeleteActivityTemplateResponseContext.ResponseReceived += OnDeleteActivityTemplateResponse;
            mGetActivitiesResponseContext = new KnetikResponseContext();
            mGetActivitiesResponseContext.ResponseReceived += OnGetActivitiesResponse;
            mGetActivityResponseContext = new KnetikResponseContext();
            mGetActivityResponseContext.ResponseReceived += OnGetActivityResponse;
            mGetActivityOccurrenceDetailsResponseContext = new KnetikResponseContext();
            mGetActivityOccurrenceDetailsResponseContext.ResponseReceived += OnGetActivityOccurrenceDetailsResponse;
            mGetActivityTemplateResponseContext = new KnetikResponseContext();
            mGetActivityTemplateResponseContext.ResponseReceived += OnGetActivityTemplateResponse;
            mGetActivityTemplatesResponseContext = new KnetikResponseContext();
            mGetActivityTemplatesResponseContext.ResponseReceived += OnGetActivityTemplatesResponse;
            mListActivityOccurrencesResponseContext = new KnetikResponseContext();
            mListActivityOccurrencesResponseContext.ResponseReceived += OnListActivityOccurrencesResponse;
            mSetActivityOccurrenceResultsResponseContext = new KnetikResponseContext();
            mSetActivityOccurrenceResultsResponseContext.ResponseReceived += OnSetActivityOccurrenceResultsResponse;
            mUpdateActivityResponseContext = new KnetikResponseContext();
            mUpdateActivityResponseContext.ResponseReceived += OnUpdateActivityResponse;
            mUpdateActivityOccurrenceResponseContext = new KnetikResponseContext();
            mUpdateActivityOccurrenceResponseContext.ResponseReceived += OnUpdateActivityOccurrenceResponse;
            mUpdateActivityTemplateResponseContext = new KnetikResponseContext();
            mUpdateActivityTemplateResponseContext.ResponseReceived += OnUpdateActivityTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create an activity 
        /// </summary>
        /// <param name="activityResource">The activity resource object</param>
        public void CreateActivity(ActivityResource activityResource)
        {
            
            mWebCallEvent.WebPath = "/activities";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(activityResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateActivityStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateActivityResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateActivityStartTime, "CreateActivity", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateActivityResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateActivity: " + response.Error);
            }

            CreateActivityData = (ActivityResource) KnetikClient.Deserialize(response.Content, typeof(ActivityResource), response.Headers);
            KnetikLogger.LogResponse(mCreateActivityStartTime, "CreateActivity", string.Format("Response received successfully:\n{0}", CreateActivityData));

            if (CreateActivityComplete != null)
            {
                CreateActivityComplete(response.ResponseCode, CreateActivityData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a new activity occurrence. Ex: start a game Has to enforce extra rules if not used as an admin
        /// </summary>
        /// <param name="test">if true, indicates that the occurrence should NOT be created. This can be used to test for eligibility and valid settings</param>
        /// <param name="activityOccurrenceResource">The activity occurrence object</param>
        public void CreateActivityOccurrence(bool? test, CreateActivityOccurrenceRequest activityOccurrenceResource)
        {
            
            mWebCallEvent.WebPath = "/activity-occurrences";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (test != null)
            {
                mWebCallEvent.QueryParams["test"] = KnetikClient.ParameterToString(test);
            }

            mWebCallEvent.PostBody = KnetikClient.Serialize(activityOccurrenceResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateActivityOccurrenceStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateActivityOccurrenceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateActivityOccurrenceStartTime, "CreateActivityOccurrence", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateActivityOccurrenceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateActivityOccurrence: " + response.Error);
            }

            CreateActivityOccurrenceData = (ActivityOccurrenceResource) KnetikClient.Deserialize(response.Content, typeof(ActivityOccurrenceResource), response.Headers);
            KnetikLogger.LogResponse(mCreateActivityOccurrenceStartTime, "CreateActivityOccurrence", string.Format("Response received successfully:\n{0}", CreateActivityOccurrenceData));

            if (CreateActivityOccurrenceComplete != null)
            {
                CreateActivityOccurrenceComplete(response.ResponseCode, CreateActivityOccurrenceData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a activity template Activity Templates define a type of activity and the properties they have
        /// </summary>
        /// <param name="activityTemplateResource">The activity template resource object</param>
        public void CreateActivityTemplate(TemplateResource activityTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/activities/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(activityTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateActivityTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateActivityTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateActivityTemplateStartTime, "CreateActivityTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateActivityTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateActivityTemplate: " + response.Error);
            }

            CreateActivityTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateActivityTemplateStartTime, "CreateActivityTemplate", string.Format("Response received successfully:\n{0}", CreateActivityTemplateData));

            if (CreateActivityTemplateComplete != null)
            {
                CreateActivityTemplateComplete(response.ResponseCode, CreateActivityTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an activity 
        /// </summary>
        /// <param name="id">The id of the activity</param>
        public void DeleteActivity(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteActivity");
            }
            
            mWebCallEvent.WebPath = "/activities/{id}";
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
            mDeleteActivityStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteActivityResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteActivityStartTime, "DeleteActivity", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteActivityResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteActivity: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteActivityStartTime, "DeleteActivity", "Response received successfully.");
            if (DeleteActivityComplete != null)
            {
                DeleteActivityComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a activity template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteActivityTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteActivityTemplate");
            }
            
            mWebCallEvent.WebPath = "/activities/templates/{id}";
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
            mDeleteActivityTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteActivityTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteActivityTemplateStartTime, "DeleteActivityTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteActivityTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteActivityTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteActivityTemplateStartTime, "DeleteActivityTemplate", "Response received successfully.");
            if (DeleteActivityTemplateComplete != null)
            {
                DeleteActivityTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List activity definitions 
        /// </summary>
        /// <param name="filterTemplate">Filter for activities that are templates, or specifically not if false</param>
        /// <param name="filterName">Filter for activities that have a name starting with specified string</param>
        /// <param name="filterId">Filter for activities with an id in the given comma separated list of ids</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetActivities(bool? filterTemplate, string filterName, string filterId, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/activities";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterTemplate != null)
            {
                mWebCallEvent.QueryParams["filter_template"] = KnetikClient.ParameterToString(filterTemplate);
            }

            if (filterName != null)
            {
                mWebCallEvent.QueryParams["filter_name"] = KnetikClient.ParameterToString(filterName);
            }

            if (filterId != null)
            {
                mWebCallEvent.QueryParams["filter_id"] = KnetikClient.ParameterToString(filterId);
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
            mGetActivitiesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetActivitiesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetActivitiesStartTime, "GetActivities", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetActivitiesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetActivities: " + response.Error);
            }

            GetActivitiesData = (PageResourceBareActivityResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceBareActivityResource), response.Headers);
            KnetikLogger.LogResponse(mGetActivitiesStartTime, "GetActivities", string.Format("Response received successfully:\n{0}", GetActivitiesData));

            if (GetActivitiesComplete != null)
            {
                GetActivitiesComplete(response.ResponseCode, GetActivitiesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single activity 
        /// </summary>
        /// <param name="id">The id of the activity</param>
        public void GetActivity(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetActivity");
            }
            
            mWebCallEvent.WebPath = "/activities/{id}";
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
            mGetActivityStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetActivityResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetActivityStartTime, "GetActivity", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetActivityResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetActivity: " + response.Error);
            }

            GetActivityData = (ActivityResource) KnetikClient.Deserialize(response.Content, typeof(ActivityResource), response.Headers);
            KnetikLogger.LogResponse(mGetActivityStartTime, "GetActivity", string.Format("Response received successfully:\n{0}", GetActivityData));

            if (GetActivityComplete != null)
            {
                GetActivityComplete(response.ResponseCode, GetActivityData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Load a single activity occurrence details 
        /// </summary>
        /// <param name="activityOccurrenceId">The id of the activity occurrence</param>
        public void GetActivityOccurrenceDetails(long? activityOccurrenceId)
        {
            // verify the required parameter 'activityOccurrenceId' is set
            if (activityOccurrenceId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'activityOccurrenceId' when calling GetActivityOccurrenceDetails");
            }
            
            mWebCallEvent.WebPath = "/activity-occurrences/{activity_occurrence_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "activity_occurrence_id" + "}", KnetikClient.ParameterToString(activityOccurrenceId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetActivityOccurrenceDetailsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetActivityOccurrenceDetailsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetActivityOccurrenceDetailsStartTime, "GetActivityOccurrenceDetails", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetActivityOccurrenceDetailsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetActivityOccurrenceDetails: " + response.Error);
            }

            GetActivityOccurrenceDetailsData = (ActivityOccurrenceResource) KnetikClient.Deserialize(response.Content, typeof(ActivityOccurrenceResource), response.Headers);
            KnetikLogger.LogResponse(mGetActivityOccurrenceDetailsStartTime, "GetActivityOccurrenceDetails", string.Format("Response received successfully:\n{0}", GetActivityOccurrenceDetailsData));

            if (GetActivityOccurrenceDetailsComplete != null)
            {
                GetActivityOccurrenceDetailsComplete(response.ResponseCode, GetActivityOccurrenceDetailsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single activity template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetActivityTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetActivityTemplate");
            }
            
            mWebCallEvent.WebPath = "/activities/templates/{id}";
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
            mGetActivityTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetActivityTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetActivityTemplateStartTime, "GetActivityTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetActivityTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetActivityTemplate: " + response.Error);
            }

            GetActivityTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetActivityTemplateStartTime, "GetActivityTemplate", string.Format("Response received successfully:\n{0}", GetActivityTemplateData));

            if (GetActivityTemplateComplete != null)
            {
                GetActivityTemplateComplete(response.ResponseCode, GetActivityTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search activity templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetActivityTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/activities/templates";
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
            mGetActivityTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetActivityTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetActivityTemplatesStartTime, "GetActivityTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetActivityTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetActivityTemplates: " + response.Error);
            }

            GetActivityTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetActivityTemplatesStartTime, "GetActivityTemplates", string.Format("Response received successfully:\n{0}", GetActivityTemplatesData));

            if (GetActivityTemplatesComplete != null)
            {
                GetActivityTemplatesComplete(response.ResponseCode, GetActivityTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List activity occurrences 
        /// </summary>
        /// <param name="filterActivity">Filter for occurrences of the given activity ID</param>
        /// <param name="filterStatus">Filter for occurrences of the given activity ID</param>
        /// <param name="filterEvent">Filter for occurrences played during the given event</param>
        /// <param name="filterChallenge">Filter for occurrences played within the given challenge</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void ListActivityOccurrences(string filterActivity, string filterStatus, int? filterEvent, int? filterChallenge, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/activity-occurrences";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterActivity != null)
            {
                mWebCallEvent.QueryParams["filter_activity"] = KnetikClient.ParameterToString(filterActivity);
            }

            if (filterStatus != null)
            {
                mWebCallEvent.QueryParams["filter_status"] = KnetikClient.ParameterToString(filterStatus);
            }

            if (filterEvent != null)
            {
                mWebCallEvent.QueryParams["filter_event"] = KnetikClient.ParameterToString(filterEvent);
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
            mListActivityOccurrencesStartTime = DateTime.Now;
            mWebCallEvent.Context = mListActivityOccurrencesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mListActivityOccurrencesStartTime, "ListActivityOccurrences", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnListActivityOccurrencesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling ListActivityOccurrences: " + response.Error);
            }

            ListActivityOccurrencesData = (PageResourceActivityOccurrenceResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceActivityOccurrenceResource), response.Headers);
            KnetikLogger.LogResponse(mListActivityOccurrencesStartTime, "ListActivityOccurrences", string.Format("Response received successfully:\n{0}", ListActivityOccurrencesData));

            if (ListActivityOccurrencesComplete != null)
            {
                ListActivityOccurrencesComplete(response.ResponseCode, ListActivityOccurrencesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Sets the status of an activity occurrence to FINISHED and logs metrics 
        /// </summary>
        /// <param name="activityOccurrenceId">The id of the activity occurrence</param>
        /// <param name="activityOccurrenceResults">The activity occurrence object</param>
        public void SetActivityOccurrenceResults(long? activityOccurrenceId, ActivityOccurrenceResultsResource activityOccurrenceResults)
        {
            // verify the required parameter 'activityOccurrenceId' is set
            if (activityOccurrenceId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'activityOccurrenceId' when calling SetActivityOccurrenceResults");
            }
            
            mWebCallEvent.WebPath = "/activity-occurrences/{activity_occurrence_id}/results";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "activity_occurrence_id" + "}", KnetikClient.ParameterToString(activityOccurrenceId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(activityOccurrenceResults); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetActivityOccurrenceResultsStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetActivityOccurrenceResultsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSetActivityOccurrenceResultsStartTime, "SetActivityOccurrenceResults", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetActivityOccurrenceResultsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetActivityOccurrenceResults: " + response.Error);
            }

            SetActivityOccurrenceResultsData = (ActivityOccurrenceResults) KnetikClient.Deserialize(response.Content, typeof(ActivityOccurrenceResults), response.Headers);
            KnetikLogger.LogResponse(mSetActivityOccurrenceResultsStartTime, "SetActivityOccurrenceResults", string.Format("Response received successfully:\n{0}", SetActivityOccurrenceResultsData));

            if (SetActivityOccurrenceResultsComplete != null)
            {
                SetActivityOccurrenceResultsComplete(response.ResponseCode, SetActivityOccurrenceResultsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an activity 
        /// </summary>
        /// <param name="id">The id of the activity</param>
        /// <param name="activityResource">The activity resource object</param>
        public void UpdateActivity(long? id, ActivityResource activityResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateActivity");
            }
            
            mWebCallEvent.WebPath = "/activities/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(activityResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateActivityStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateActivityResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateActivityStartTime, "UpdateActivity", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateActivityResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateActivity: " + response.Error);
            }

            UpdateActivityData = (ActivityResource) KnetikClient.Deserialize(response.Content, typeof(ActivityResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateActivityStartTime, "UpdateActivity", string.Format("Response received successfully:\n{0}", UpdateActivityData));

            if (UpdateActivityComplete != null)
            {
                UpdateActivityComplete(response.ResponseCode, UpdateActivityData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Updated the status of an activity occurrence If setting to &#39;FINISHED&#39; reward will be run based on current metrics that have been recorded already. Aternatively, see results endpoint to finish and record all metrics at once.
        /// </summary>
        /// <param name="activityOccurrenceId">The id of the activity occurrence</param>
        /// <param name="activityOccurrenceStatus">The activity occurrence status object</param>
        public void UpdateActivityOccurrence(long? activityOccurrenceId, string activityOccurrenceStatus)
        {
            // verify the required parameter 'activityOccurrenceId' is set
            if (activityOccurrenceId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'activityOccurrenceId' when calling UpdateActivityOccurrence");
            }
            
            mWebCallEvent.WebPath = "/activity-occurrences/{activity_occurrence_id}/status";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "activity_occurrence_id" + "}", KnetikClient.ParameterToString(activityOccurrenceId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(activityOccurrenceStatus); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateActivityOccurrenceStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateActivityOccurrenceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateActivityOccurrenceStartTime, "UpdateActivityOccurrence", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateActivityOccurrenceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateActivityOccurrence: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateActivityOccurrenceStartTime, "UpdateActivityOccurrence", "Response received successfully.");
            if (UpdateActivityOccurrenceComplete != null)
            {
                UpdateActivityOccurrenceComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an activity template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="activityTemplateResource">The activity template resource object</param>
        public void UpdateActivityTemplate(string id, TemplateResource activityTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateActivityTemplate");
            }
            
            mWebCallEvent.WebPath = "/activities/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(activityTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateActivityTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateActivityTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateActivityTemplateStartTime, "UpdateActivityTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateActivityTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateActivityTemplate: " + response.Error);
            }

            UpdateActivityTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateActivityTemplateStartTime, "UpdateActivityTemplate", string.Format("Response received successfully:\n{0}", UpdateActivityTemplateData));

            if (UpdateActivityTemplateComplete != null)
            {
                UpdateActivityTemplateComplete(response.ResponseCode, UpdateActivityTemplateData);
            }
        }

    }
}
