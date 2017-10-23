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
    public interface IActivitiesApi
    {
        ActivityResource CreateActivityData { get; }

        ActivityOccurrenceResource CreateActivityOccurrenceData { get; }

        TemplateResource CreateActivityTemplateData { get; }

        PageResourceBareActivityResource GetActivitiesData { get; }

        ActivityResource GetActivityData { get; }

        ActivityOccurrenceResource GetActivityOccurrenceDetailsData { get; }

        TemplateResource GetActivityTemplateData { get; }

        PageResourceTemplateResource GetActivityTemplatesData { get; }

        PageResourceActivityOccurrenceResource ListActivityOccurrencesData { get; }

        ActivityOccurrenceResults SetActivityOccurrenceResultsData { get; }

        ActivityResource UpdateActivityData { get; }

        TemplateResource UpdateActivityTemplateData { get; }

        
        /// <summary>
        /// Create an activity 
        /// </summary>
        /// <param name="activityResource">The activity resource object</param>
        void CreateActivity(ActivityResource activityResource);

        /// <summary>
        /// Create a new activity occurrence. Ex: start a game Has to enforce extra rules if not used as an admin
        /// </summary>
        /// <param name="test">if true, indicates that the occurrence should NOT be created. This can be used to test for eligibility and valid settings</param>
        /// <param name="activityOccurrenceResource">The activity occurrence object</param>
        void CreateActivityOccurrence(bool? test, CreateActivityOccurrenceRequest activityOccurrenceResource);

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

        /// <summary>
        /// Get a single activity 
        /// </summary>
        /// <param name="id">The id of the activity</param>
        void GetActivity(long? id);

        /// <summary>
        /// Load a single activity occurrence details 
        /// </summary>
        /// <param name="activityOccurrenceId">The id of the activity occurrence</param>
        void GetActivityOccurrenceDetails(long? activityOccurrenceId);

        /// <summary>
        /// Get a single activity template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetActivityTemplate(string id);

        /// <summary>
        /// List and search activity templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetActivityTemplates(int? size, int? page, string order);

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

        /// <summary>
        /// Sets the status of an activity occurrence to FINISHED and logs metrics 
        /// </summary>
        /// <param name="activityOccurrenceId">The id of the activity occurrence</param>
        /// <param name="activityOccurrenceResults">The activity occurrence object</param>
        void SetActivityOccurrenceResults(long? activityOccurrenceId, ActivityOccurrenceResultsResource activityOccurrenceResults);

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
        private readonly KnetikCoroutine mCreateActivityCoroutine;
        private DateTime mCreateActivityStartTime;
        private string mCreateActivityPath;
        private readonly KnetikCoroutine mCreateActivityOccurrenceCoroutine;
        private DateTime mCreateActivityOccurrenceStartTime;
        private string mCreateActivityOccurrencePath;
        private readonly KnetikCoroutine mCreateActivityTemplateCoroutine;
        private DateTime mCreateActivityTemplateStartTime;
        private string mCreateActivityTemplatePath;
        private readonly KnetikCoroutine mDeleteActivityCoroutine;
        private DateTime mDeleteActivityStartTime;
        private string mDeleteActivityPath;
        private readonly KnetikCoroutine mDeleteActivityTemplateCoroutine;
        private DateTime mDeleteActivityTemplateStartTime;
        private string mDeleteActivityTemplatePath;
        private readonly KnetikCoroutine mGetActivitiesCoroutine;
        private DateTime mGetActivitiesStartTime;
        private string mGetActivitiesPath;
        private readonly KnetikCoroutine mGetActivityCoroutine;
        private DateTime mGetActivityStartTime;
        private string mGetActivityPath;
        private readonly KnetikCoroutine mGetActivityOccurrenceDetailsCoroutine;
        private DateTime mGetActivityOccurrenceDetailsStartTime;
        private string mGetActivityOccurrenceDetailsPath;
        private readonly KnetikCoroutine mGetActivityTemplateCoroutine;
        private DateTime mGetActivityTemplateStartTime;
        private string mGetActivityTemplatePath;
        private readonly KnetikCoroutine mGetActivityTemplatesCoroutine;
        private DateTime mGetActivityTemplatesStartTime;
        private string mGetActivityTemplatesPath;
        private readonly KnetikCoroutine mListActivityOccurrencesCoroutine;
        private DateTime mListActivityOccurrencesStartTime;
        private string mListActivityOccurrencesPath;
        private readonly KnetikCoroutine mSetActivityOccurrenceResultsCoroutine;
        private DateTime mSetActivityOccurrenceResultsStartTime;
        private string mSetActivityOccurrenceResultsPath;
        private readonly KnetikCoroutine mUpdateActivityCoroutine;
        private DateTime mUpdateActivityStartTime;
        private string mUpdateActivityPath;
        private readonly KnetikCoroutine mUpdateActivityOccurrenceCoroutine;
        private DateTime mUpdateActivityOccurrenceStartTime;
        private string mUpdateActivityOccurrencePath;
        private readonly KnetikCoroutine mUpdateActivityTemplateCoroutine;
        private DateTime mUpdateActivityTemplateStartTime;
        private string mUpdateActivityTemplatePath;

        public ActivityResource CreateActivityData { get; private set; }
        public delegate void CreateActivityCompleteDelegate(ActivityResource response);
        public CreateActivityCompleteDelegate CreateActivityComplete;

        public ActivityOccurrenceResource CreateActivityOccurrenceData { get; private set; }
        public delegate void CreateActivityOccurrenceCompleteDelegate(ActivityOccurrenceResource response);
        public CreateActivityOccurrenceCompleteDelegate CreateActivityOccurrenceComplete;

        public TemplateResource CreateActivityTemplateData { get; private set; }
        public delegate void CreateActivityTemplateCompleteDelegate(TemplateResource response);
        public CreateActivityTemplateCompleteDelegate CreateActivityTemplateComplete;

        public delegate void DeleteActivityCompleteDelegate();
        public DeleteActivityCompleteDelegate DeleteActivityComplete;

        public delegate void DeleteActivityTemplateCompleteDelegate();
        public DeleteActivityTemplateCompleteDelegate DeleteActivityTemplateComplete;

        public PageResourceBareActivityResource GetActivitiesData { get; private set; }
        public delegate void GetActivitiesCompleteDelegate(PageResourceBareActivityResource response);
        public GetActivitiesCompleteDelegate GetActivitiesComplete;

        public ActivityResource GetActivityData { get; private set; }
        public delegate void GetActivityCompleteDelegate(ActivityResource response);
        public GetActivityCompleteDelegate GetActivityComplete;

        public ActivityOccurrenceResource GetActivityOccurrenceDetailsData { get; private set; }
        public delegate void GetActivityOccurrenceDetailsCompleteDelegate(ActivityOccurrenceResource response);
        public GetActivityOccurrenceDetailsCompleteDelegate GetActivityOccurrenceDetailsComplete;

        public TemplateResource GetActivityTemplateData { get; private set; }
        public delegate void GetActivityTemplateCompleteDelegate(TemplateResource response);
        public GetActivityTemplateCompleteDelegate GetActivityTemplateComplete;

        public PageResourceTemplateResource GetActivityTemplatesData { get; private set; }
        public delegate void GetActivityTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetActivityTemplatesCompleteDelegate GetActivityTemplatesComplete;

        public PageResourceActivityOccurrenceResource ListActivityOccurrencesData { get; private set; }
        public delegate void ListActivityOccurrencesCompleteDelegate(PageResourceActivityOccurrenceResource response);
        public ListActivityOccurrencesCompleteDelegate ListActivityOccurrencesComplete;

        public ActivityOccurrenceResults SetActivityOccurrenceResultsData { get; private set; }
        public delegate void SetActivityOccurrenceResultsCompleteDelegate(ActivityOccurrenceResults response);
        public SetActivityOccurrenceResultsCompleteDelegate SetActivityOccurrenceResultsComplete;

        public ActivityResource UpdateActivityData { get; private set; }
        public delegate void UpdateActivityCompleteDelegate(ActivityResource response);
        public UpdateActivityCompleteDelegate UpdateActivityComplete;

        public delegate void UpdateActivityOccurrenceCompleteDelegate();
        public UpdateActivityOccurrenceCompleteDelegate UpdateActivityOccurrenceComplete;

        public TemplateResource UpdateActivityTemplateData { get; private set; }
        public delegate void UpdateActivityTemplateCompleteDelegate(TemplateResource response);
        public UpdateActivityTemplateCompleteDelegate UpdateActivityTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivitiesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ActivitiesApi()
        {
            mCreateActivityCoroutine = new KnetikCoroutine();
            mCreateActivityOccurrenceCoroutine = new KnetikCoroutine();
            mCreateActivityTemplateCoroutine = new KnetikCoroutine();
            mDeleteActivityCoroutine = new KnetikCoroutine();
            mDeleteActivityTemplateCoroutine = new KnetikCoroutine();
            mGetActivitiesCoroutine = new KnetikCoroutine();
            mGetActivityCoroutine = new KnetikCoroutine();
            mGetActivityOccurrenceDetailsCoroutine = new KnetikCoroutine();
            mGetActivityTemplateCoroutine = new KnetikCoroutine();
            mGetActivityTemplatesCoroutine = new KnetikCoroutine();
            mListActivityOccurrencesCoroutine = new KnetikCoroutine();
            mSetActivityOccurrenceResultsCoroutine = new KnetikCoroutine();
            mUpdateActivityCoroutine = new KnetikCoroutine();
            mUpdateActivityOccurrenceCoroutine = new KnetikCoroutine();
            mUpdateActivityTemplateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create an activity 
        /// </summary>
        /// <param name="activityResource">The activity resource object</param>
        public void CreateActivity(ActivityResource activityResource)
        {
            
            mCreateActivityPath = "/activities";
            if (!string.IsNullOrEmpty(mCreateActivityPath))
            {
                mCreateActivityPath = mCreateActivityPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(activityResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateActivityStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateActivityStartTime, mCreateActivityPath, "Sending server request...");

            // make the HTTP request
            mCreateActivityCoroutine.ResponseReceived += CreateActivityCallback;
            mCreateActivityCoroutine.Start(mCreateActivityPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateActivityCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateActivity: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateActivity: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateActivityData = (ActivityResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ActivityResource), response.Headers);
            KnetikLogger.LogResponse(mCreateActivityStartTime, mCreateActivityPath, string.Format("Response received successfully:\n{0}", CreateActivityData.ToString()));

            if (CreateActivityComplete != null)
            {
                CreateActivityComplete(CreateActivityData);
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
            
            mCreateActivityOccurrencePath = "/activity-occurrences";
            if (!string.IsNullOrEmpty(mCreateActivityOccurrencePath))
            {
                mCreateActivityOccurrencePath = mCreateActivityOccurrencePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (test != null)
            {
                queryParams.Add("test", KnetikClient.DefaultClient.ParameterToString(test));
            }

            postBody = KnetikClient.DefaultClient.Serialize(activityOccurrenceResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateActivityOccurrenceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateActivityOccurrenceStartTime, mCreateActivityOccurrencePath, "Sending server request...");

            // make the HTTP request
            mCreateActivityOccurrenceCoroutine.ResponseReceived += CreateActivityOccurrenceCallback;
            mCreateActivityOccurrenceCoroutine.Start(mCreateActivityOccurrencePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateActivityOccurrenceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateActivityOccurrence: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateActivityOccurrence: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateActivityOccurrenceData = (ActivityOccurrenceResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ActivityOccurrenceResource), response.Headers);
            KnetikLogger.LogResponse(mCreateActivityOccurrenceStartTime, mCreateActivityOccurrencePath, string.Format("Response received successfully:\n{0}", CreateActivityOccurrenceData.ToString()));

            if (CreateActivityOccurrenceComplete != null)
            {
                CreateActivityOccurrenceComplete(CreateActivityOccurrenceData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a activity template Activity Templates define a type of activity and the properties they have
        /// </summary>
        /// <param name="activityTemplateResource">The activity template resource object</param>
        public void CreateActivityTemplate(TemplateResource activityTemplateResource)
        {
            
            mCreateActivityTemplatePath = "/activities/templates";
            if (!string.IsNullOrEmpty(mCreateActivityTemplatePath))
            {
                mCreateActivityTemplatePath = mCreateActivityTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(activityTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateActivityTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateActivityTemplateStartTime, mCreateActivityTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateActivityTemplateCoroutine.ResponseReceived += CreateActivityTemplateCallback;
            mCreateActivityTemplateCoroutine.Start(mCreateActivityTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateActivityTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateActivityTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateActivityTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateActivityTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateActivityTemplateStartTime, mCreateActivityTemplatePath, string.Format("Response received successfully:\n{0}", CreateActivityTemplateData.ToString()));

            if (CreateActivityTemplateComplete != null)
            {
                CreateActivityTemplateComplete(CreateActivityTemplateData);
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
            
            mDeleteActivityPath = "/activities/{id}";
            if (!string.IsNullOrEmpty(mDeleteActivityPath))
            {
                mDeleteActivityPath = mDeleteActivityPath.Replace("{format}", "json");
            }
            mDeleteActivityPath = mDeleteActivityPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteActivityStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteActivityStartTime, mDeleteActivityPath, "Sending server request...");

            // make the HTTP request
            mDeleteActivityCoroutine.ResponseReceived += DeleteActivityCallback;
            mDeleteActivityCoroutine.Start(mDeleteActivityPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteActivityCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteActivity: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteActivity: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteActivityStartTime, mDeleteActivityPath, "Response received successfully.");
            if (DeleteActivityComplete != null)
            {
                DeleteActivityComplete();
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
            
            mDeleteActivityTemplatePath = "/activities/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteActivityTemplatePath))
            {
                mDeleteActivityTemplatePath = mDeleteActivityTemplatePath.Replace("{format}", "json");
            }
            mDeleteActivityTemplatePath = mDeleteActivityTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mDeleteActivityTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteActivityTemplateStartTime, mDeleteActivityTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteActivityTemplateCoroutine.ResponseReceived += DeleteActivityTemplateCallback;
            mDeleteActivityTemplateCoroutine.Start(mDeleteActivityTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteActivityTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteActivityTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteActivityTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteActivityTemplateStartTime, mDeleteActivityTemplatePath, "Response received successfully.");
            if (DeleteActivityTemplateComplete != null)
            {
                DeleteActivityTemplateComplete();
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
            
            mGetActivitiesPath = "/activities";
            if (!string.IsNullOrEmpty(mGetActivitiesPath))
            {
                mGetActivitiesPath = mGetActivitiesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterTemplate != null)
            {
                queryParams.Add("filter_template", KnetikClient.DefaultClient.ParameterToString(filterTemplate));
            }

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.DefaultClient.ParameterToString(filterName));
            }

            if (filterId != null)
            {
                queryParams.Add("filter_id", KnetikClient.DefaultClient.ParameterToString(filterId));
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

            mGetActivitiesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetActivitiesStartTime, mGetActivitiesPath, "Sending server request...");

            // make the HTTP request
            mGetActivitiesCoroutine.ResponseReceived += GetActivitiesCallback;
            mGetActivitiesCoroutine.Start(mGetActivitiesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetActivitiesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetActivities: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetActivities: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetActivitiesData = (PageResourceBareActivityResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceBareActivityResource), response.Headers);
            KnetikLogger.LogResponse(mGetActivitiesStartTime, mGetActivitiesPath, string.Format("Response received successfully:\n{0}", GetActivitiesData.ToString()));

            if (GetActivitiesComplete != null)
            {
                GetActivitiesComplete(GetActivitiesData);
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
            
            mGetActivityPath = "/activities/{id}";
            if (!string.IsNullOrEmpty(mGetActivityPath))
            {
                mGetActivityPath = mGetActivityPath.Replace("{format}", "json");
            }
            mGetActivityPath = mGetActivityPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetActivityStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetActivityStartTime, mGetActivityPath, "Sending server request...");

            // make the HTTP request
            mGetActivityCoroutine.ResponseReceived += GetActivityCallback;
            mGetActivityCoroutine.Start(mGetActivityPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetActivityCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetActivity: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetActivity: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetActivityData = (ActivityResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ActivityResource), response.Headers);
            KnetikLogger.LogResponse(mGetActivityStartTime, mGetActivityPath, string.Format("Response received successfully:\n{0}", GetActivityData.ToString()));

            if (GetActivityComplete != null)
            {
                GetActivityComplete(GetActivityData);
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
            
            mGetActivityOccurrenceDetailsPath = "/activity-occurrences/{activity_occurrence_id}";
            if (!string.IsNullOrEmpty(mGetActivityOccurrenceDetailsPath))
            {
                mGetActivityOccurrenceDetailsPath = mGetActivityOccurrenceDetailsPath.Replace("{format}", "json");
            }
            mGetActivityOccurrenceDetailsPath = mGetActivityOccurrenceDetailsPath.Replace("{" + "activity_occurrence_id" + "}", KnetikClient.DefaultClient.ParameterToString(activityOccurrenceId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetActivityOccurrenceDetailsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetActivityOccurrenceDetailsStartTime, mGetActivityOccurrenceDetailsPath, "Sending server request...");

            // make the HTTP request
            mGetActivityOccurrenceDetailsCoroutine.ResponseReceived += GetActivityOccurrenceDetailsCallback;
            mGetActivityOccurrenceDetailsCoroutine.Start(mGetActivityOccurrenceDetailsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetActivityOccurrenceDetailsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetActivityOccurrenceDetails: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetActivityOccurrenceDetails: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetActivityOccurrenceDetailsData = (ActivityOccurrenceResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ActivityOccurrenceResource), response.Headers);
            KnetikLogger.LogResponse(mGetActivityOccurrenceDetailsStartTime, mGetActivityOccurrenceDetailsPath, string.Format("Response received successfully:\n{0}", GetActivityOccurrenceDetailsData.ToString()));

            if (GetActivityOccurrenceDetailsComplete != null)
            {
                GetActivityOccurrenceDetailsComplete(GetActivityOccurrenceDetailsData);
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
            
            mGetActivityTemplatePath = "/activities/templates/{id}";
            if (!string.IsNullOrEmpty(mGetActivityTemplatePath))
            {
                mGetActivityTemplatePath = mGetActivityTemplatePath.Replace("{format}", "json");
            }
            mGetActivityTemplatePath = mGetActivityTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetActivityTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetActivityTemplateStartTime, mGetActivityTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetActivityTemplateCoroutine.ResponseReceived += GetActivityTemplateCallback;
            mGetActivityTemplateCoroutine.Start(mGetActivityTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetActivityTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetActivityTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetActivityTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetActivityTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetActivityTemplateStartTime, mGetActivityTemplatePath, string.Format("Response received successfully:\n{0}", GetActivityTemplateData.ToString()));

            if (GetActivityTemplateComplete != null)
            {
                GetActivityTemplateComplete(GetActivityTemplateData);
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
            
            mGetActivityTemplatesPath = "/activities/templates";
            if (!string.IsNullOrEmpty(mGetActivityTemplatesPath))
            {
                mGetActivityTemplatesPath = mGetActivityTemplatesPath.Replace("{format}", "json");
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

            mGetActivityTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetActivityTemplatesStartTime, mGetActivityTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetActivityTemplatesCoroutine.ResponseReceived += GetActivityTemplatesCallback;
            mGetActivityTemplatesCoroutine.Start(mGetActivityTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetActivityTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetActivityTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetActivityTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetActivityTemplatesData = (PageResourceTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetActivityTemplatesStartTime, mGetActivityTemplatesPath, string.Format("Response received successfully:\n{0}", GetActivityTemplatesData.ToString()));

            if (GetActivityTemplatesComplete != null)
            {
                GetActivityTemplatesComplete(GetActivityTemplatesData);
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
            
            mListActivityOccurrencesPath = "/activity-occurrences";
            if (!string.IsNullOrEmpty(mListActivityOccurrencesPath))
            {
                mListActivityOccurrencesPath = mListActivityOccurrencesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterActivity != null)
            {
                queryParams.Add("filter_activity", KnetikClient.DefaultClient.ParameterToString(filterActivity));
            }

            if (filterStatus != null)
            {
                queryParams.Add("filter_status", KnetikClient.DefaultClient.ParameterToString(filterStatus));
            }

            if (filterEvent != null)
            {
                queryParams.Add("filter_event", KnetikClient.DefaultClient.ParameterToString(filterEvent));
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mListActivityOccurrencesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mListActivityOccurrencesStartTime, mListActivityOccurrencesPath, "Sending server request...");

            // make the HTTP request
            mListActivityOccurrencesCoroutine.ResponseReceived += ListActivityOccurrencesCallback;
            mListActivityOccurrencesCoroutine.Start(mListActivityOccurrencesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void ListActivityOccurrencesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling ListActivityOccurrences: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling ListActivityOccurrences: " + response.ErrorMessage, response.ErrorMessage);
            }

            ListActivityOccurrencesData = (PageResourceActivityOccurrenceResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceActivityOccurrenceResource), response.Headers);
            KnetikLogger.LogResponse(mListActivityOccurrencesStartTime, mListActivityOccurrencesPath, string.Format("Response received successfully:\n{0}", ListActivityOccurrencesData.ToString()));

            if (ListActivityOccurrencesComplete != null)
            {
                ListActivityOccurrencesComplete(ListActivityOccurrencesData);
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
            
            mSetActivityOccurrenceResultsPath = "/activity-occurrences/{activity_occurrence_id}/results";
            if (!string.IsNullOrEmpty(mSetActivityOccurrenceResultsPath))
            {
                mSetActivityOccurrenceResultsPath = mSetActivityOccurrenceResultsPath.Replace("{format}", "json");
            }
            mSetActivityOccurrenceResultsPath = mSetActivityOccurrenceResultsPath.Replace("{" + "activity_occurrence_id" + "}", KnetikClient.DefaultClient.ParameterToString(activityOccurrenceId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(activityOccurrenceResults); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetActivityOccurrenceResultsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetActivityOccurrenceResultsStartTime, mSetActivityOccurrenceResultsPath, "Sending server request...");

            // make the HTTP request
            mSetActivityOccurrenceResultsCoroutine.ResponseReceived += SetActivityOccurrenceResultsCallback;
            mSetActivityOccurrenceResultsCoroutine.Start(mSetActivityOccurrenceResultsPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetActivityOccurrenceResultsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetActivityOccurrenceResults: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetActivityOccurrenceResults: " + response.ErrorMessage, response.ErrorMessage);
            }

            SetActivityOccurrenceResultsData = (ActivityOccurrenceResults) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ActivityOccurrenceResults), response.Headers);
            KnetikLogger.LogResponse(mSetActivityOccurrenceResultsStartTime, mSetActivityOccurrenceResultsPath, string.Format("Response received successfully:\n{0}", SetActivityOccurrenceResultsData.ToString()));

            if (SetActivityOccurrenceResultsComplete != null)
            {
                SetActivityOccurrenceResultsComplete(SetActivityOccurrenceResultsData);
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
            
            mUpdateActivityPath = "/activities/{id}";
            if (!string.IsNullOrEmpty(mUpdateActivityPath))
            {
                mUpdateActivityPath = mUpdateActivityPath.Replace("{format}", "json");
            }
            mUpdateActivityPath = mUpdateActivityPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(activityResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateActivityStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateActivityStartTime, mUpdateActivityPath, "Sending server request...");

            // make the HTTP request
            mUpdateActivityCoroutine.ResponseReceived += UpdateActivityCallback;
            mUpdateActivityCoroutine.Start(mUpdateActivityPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateActivityCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateActivity: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateActivity: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateActivityData = (ActivityResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ActivityResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateActivityStartTime, mUpdateActivityPath, string.Format("Response received successfully:\n{0}", UpdateActivityData.ToString()));

            if (UpdateActivityComplete != null)
            {
                UpdateActivityComplete(UpdateActivityData);
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
            
            mUpdateActivityOccurrencePath = "/activity-occurrences/{activity_occurrence_id}/status";
            if (!string.IsNullOrEmpty(mUpdateActivityOccurrencePath))
            {
                mUpdateActivityOccurrencePath = mUpdateActivityOccurrencePath.Replace("{format}", "json");
            }
            mUpdateActivityOccurrencePath = mUpdateActivityOccurrencePath.Replace("{" + "activity_occurrence_id" + "}", KnetikClient.DefaultClient.ParameterToString(activityOccurrenceId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(activityOccurrenceStatus); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateActivityOccurrenceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateActivityOccurrenceStartTime, mUpdateActivityOccurrencePath, "Sending server request...");

            // make the HTTP request
            mUpdateActivityOccurrenceCoroutine.ResponseReceived += UpdateActivityOccurrenceCallback;
            mUpdateActivityOccurrenceCoroutine.Start(mUpdateActivityOccurrencePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateActivityOccurrenceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateActivityOccurrence: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateActivityOccurrence: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateActivityOccurrenceStartTime, mUpdateActivityOccurrencePath, "Response received successfully.");
            if (UpdateActivityOccurrenceComplete != null)
            {
                UpdateActivityOccurrenceComplete();
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
            
            mUpdateActivityTemplatePath = "/activities/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateActivityTemplatePath))
            {
                mUpdateActivityTemplatePath = mUpdateActivityTemplatePath.Replace("{format}", "json");
            }
            mUpdateActivityTemplatePath = mUpdateActivityTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(activityTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateActivityTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateActivityTemplateStartTime, mUpdateActivityTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateActivityTemplateCoroutine.ResponseReceived += UpdateActivityTemplateCallback;
            mUpdateActivityTemplateCoroutine.Start(mUpdateActivityTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateActivityTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateActivityTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateActivityTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateActivityTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateActivityTemplateStartTime, mUpdateActivityTemplatePath, string.Format("Response received successfully:\n{0}", UpdateActivityTemplateData.ToString()));

            if (UpdateActivityTemplateComplete != null)
            {
                UpdateActivityTemplateComplete(UpdateActivityTemplateData);
            }
        }

    }
}
