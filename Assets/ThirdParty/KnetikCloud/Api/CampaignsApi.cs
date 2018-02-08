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
    public interface ICampaignsApi
    {
        

        /// <summary>
        /// Add a challenge to a campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="id">The id of the campaign</param>
        /// <param name="challengeId">The id of the challenge</param>
        void AddChallengeToCampaign(long? id, long? challengeId);

        CampaignResource CreateCampaignData { get; }

        /// <summary>
        /// Create a campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="campaignResource">The campaign resource object</param>
        void CreateCampaign(CampaignResource campaignResource);

        TemplateResource CreateCampaignTemplateData { get; }

        /// <summary>
        /// Create a campaign template Campaign Templates define a type of campaign and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="campaignTemplateResource">The campaign template resource object</param>
        void CreateCampaignTemplate(TemplateResource campaignTemplateResource);

        

        /// <summary>
        /// Delete a campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="id">The campaign id</param>
        void DeleteCampaign(long? id);

        

        /// <summary>
        /// Delete a campaign template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteCampaignTemplate(string id, string cascade);

        CampaignResource GetCampaignData { get; }

        /// <summary>
        /// Returns a single campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The campaign id</param>
        void GetCampaign(long? id);

        PageResourceChallengeResource GetCampaignChallengesData { get; }

        /// <summary>
        /// List the challenges associated with a campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The campaign id</param>
        /// <param name="filterStartDate">A comma separated string without spaces.  First value is the operator to search on, second value is the challenge start date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterEndDate">A comma separated string without spaces.  First value is the operator to search on, second value is the challenge end date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCampaignChallenges(long? id, string filterStartDate, string filterEndDate, int? size, int? page, string order);

        TemplateResource GetCampaignTemplateData { get; }

        /// <summary>
        /// Get a single campaign template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetCampaignTemplate(string id);

        PageResourceTemplateResource GetCampaignTemplatesData { get; }

        /// <summary>
        /// List and search campaign templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCampaignTemplates(int? size, int? page, string order);

        PageResourceCampaignResource GetCampaignsData { get; }

        /// <summary>
        /// List and search campaigns &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterActive">Filter for campaigns that are active</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCampaigns(bool? filterActive, int? size, int? page, string order);

        

        /// <summary>
        /// Remove a challenge from a campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <param name="id">The challenge id</param>
        void RemoveChallengeFromCampaign(long? campaignId, long? id);

        CampaignResource UpdateCampaignData { get; }

        /// <summary>
        /// Update a campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="id">The campaign id</param>
        /// <param name="campaignResource">The campaign resource object</param>
        void UpdateCampaign(long? id, CampaignResource campaignResource);

        TemplateResource UpdateCampaignTemplateData { get; }

        /// <summary>
        /// Update an campaign template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="campaignTemplateResource">The campaign template resource object</param>
        void UpdateCampaignTemplate(string id, TemplateResource campaignTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class CampaignsApi : ICampaignsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddChallengeToCampaignResponseContext;
        private DateTime mAddChallengeToCampaignStartTime;
        private readonly KnetikResponseContext mCreateCampaignResponseContext;
        private DateTime mCreateCampaignStartTime;
        private readonly KnetikResponseContext mCreateCampaignTemplateResponseContext;
        private DateTime mCreateCampaignTemplateStartTime;
        private readonly KnetikResponseContext mDeleteCampaignResponseContext;
        private DateTime mDeleteCampaignStartTime;
        private readonly KnetikResponseContext mDeleteCampaignTemplateResponseContext;
        private DateTime mDeleteCampaignTemplateStartTime;
        private readonly KnetikResponseContext mGetCampaignResponseContext;
        private DateTime mGetCampaignStartTime;
        private readonly KnetikResponseContext mGetCampaignChallengesResponseContext;
        private DateTime mGetCampaignChallengesStartTime;
        private readonly KnetikResponseContext mGetCampaignTemplateResponseContext;
        private DateTime mGetCampaignTemplateStartTime;
        private readonly KnetikResponseContext mGetCampaignTemplatesResponseContext;
        private DateTime mGetCampaignTemplatesStartTime;
        private readonly KnetikResponseContext mGetCampaignsResponseContext;
        private DateTime mGetCampaignsStartTime;
        private readonly KnetikResponseContext mRemoveChallengeFromCampaignResponseContext;
        private DateTime mRemoveChallengeFromCampaignStartTime;
        private readonly KnetikResponseContext mUpdateCampaignResponseContext;
        private DateTime mUpdateCampaignStartTime;
        private readonly KnetikResponseContext mUpdateCampaignTemplateResponseContext;
        private DateTime mUpdateCampaignTemplateStartTime;

        public delegate void AddChallengeToCampaignCompleteDelegate(long responseCode);
        public AddChallengeToCampaignCompleteDelegate AddChallengeToCampaignComplete;

        public CampaignResource CreateCampaignData { get; private set; }
        public delegate void CreateCampaignCompleteDelegate(long responseCode, CampaignResource response);
        public CreateCampaignCompleteDelegate CreateCampaignComplete;

        public TemplateResource CreateCampaignTemplateData { get; private set; }
        public delegate void CreateCampaignTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateCampaignTemplateCompleteDelegate CreateCampaignTemplateComplete;

        public delegate void DeleteCampaignCompleteDelegate(long responseCode);
        public DeleteCampaignCompleteDelegate DeleteCampaignComplete;

        public delegate void DeleteCampaignTemplateCompleteDelegate(long responseCode);
        public DeleteCampaignTemplateCompleteDelegate DeleteCampaignTemplateComplete;

        public CampaignResource GetCampaignData { get; private set; }
        public delegate void GetCampaignCompleteDelegate(long responseCode, CampaignResource response);
        public GetCampaignCompleteDelegate GetCampaignComplete;

        public PageResourceChallengeResource GetCampaignChallengesData { get; private set; }
        public delegate void GetCampaignChallengesCompleteDelegate(long responseCode, PageResourceChallengeResource response);
        public GetCampaignChallengesCompleteDelegate GetCampaignChallengesComplete;

        public TemplateResource GetCampaignTemplateData { get; private set; }
        public delegate void GetCampaignTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetCampaignTemplateCompleteDelegate GetCampaignTemplateComplete;

        public PageResourceTemplateResource GetCampaignTemplatesData { get; private set; }
        public delegate void GetCampaignTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetCampaignTemplatesCompleteDelegate GetCampaignTemplatesComplete;

        public PageResourceCampaignResource GetCampaignsData { get; private set; }
        public delegate void GetCampaignsCompleteDelegate(long responseCode, PageResourceCampaignResource response);
        public GetCampaignsCompleteDelegate GetCampaignsComplete;

        public delegate void RemoveChallengeFromCampaignCompleteDelegate(long responseCode);
        public RemoveChallengeFromCampaignCompleteDelegate RemoveChallengeFromCampaignComplete;

        public CampaignResource UpdateCampaignData { get; private set; }
        public delegate void UpdateCampaignCompleteDelegate(long responseCode, CampaignResource response);
        public UpdateCampaignCompleteDelegate UpdateCampaignComplete;

        public TemplateResource UpdateCampaignTemplateData { get; private set; }
        public delegate void UpdateCampaignTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateCampaignTemplateCompleteDelegate UpdateCampaignTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CampaignsApi()
        {
            mAddChallengeToCampaignResponseContext = new KnetikResponseContext();
            mAddChallengeToCampaignResponseContext.ResponseReceived += OnAddChallengeToCampaignResponse;
            mCreateCampaignResponseContext = new KnetikResponseContext();
            mCreateCampaignResponseContext.ResponseReceived += OnCreateCampaignResponse;
            mCreateCampaignTemplateResponseContext = new KnetikResponseContext();
            mCreateCampaignTemplateResponseContext.ResponseReceived += OnCreateCampaignTemplateResponse;
            mDeleteCampaignResponseContext = new KnetikResponseContext();
            mDeleteCampaignResponseContext.ResponseReceived += OnDeleteCampaignResponse;
            mDeleteCampaignTemplateResponseContext = new KnetikResponseContext();
            mDeleteCampaignTemplateResponseContext.ResponseReceived += OnDeleteCampaignTemplateResponse;
            mGetCampaignResponseContext = new KnetikResponseContext();
            mGetCampaignResponseContext.ResponseReceived += OnGetCampaignResponse;
            mGetCampaignChallengesResponseContext = new KnetikResponseContext();
            mGetCampaignChallengesResponseContext.ResponseReceived += OnGetCampaignChallengesResponse;
            mGetCampaignTemplateResponseContext = new KnetikResponseContext();
            mGetCampaignTemplateResponseContext.ResponseReceived += OnGetCampaignTemplateResponse;
            mGetCampaignTemplatesResponseContext = new KnetikResponseContext();
            mGetCampaignTemplatesResponseContext.ResponseReceived += OnGetCampaignTemplatesResponse;
            mGetCampaignsResponseContext = new KnetikResponseContext();
            mGetCampaignsResponseContext.ResponseReceived += OnGetCampaignsResponse;
            mRemoveChallengeFromCampaignResponseContext = new KnetikResponseContext();
            mRemoveChallengeFromCampaignResponseContext.ResponseReceived += OnRemoveChallengeFromCampaignResponse;
            mUpdateCampaignResponseContext = new KnetikResponseContext();
            mUpdateCampaignResponseContext.ResponseReceived += OnUpdateCampaignResponse;
            mUpdateCampaignTemplateResponseContext = new KnetikResponseContext();
            mUpdateCampaignTemplateResponseContext.ResponseReceived += OnUpdateCampaignTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a challenge to a campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="id">The id of the campaign</param>
        /// <param name="challengeId">The id of the challenge</param>
        public void AddChallengeToCampaign(long? id, long? challengeId)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddChallengeToCampaign");
            }
            
            mWebCallEvent.WebPath = "/campaigns/{id}/challenges";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(challengeId); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddChallengeToCampaignStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddChallengeToCampaignResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddChallengeToCampaignStartTime, "AddChallengeToCampaign", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddChallengeToCampaignResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddChallengeToCampaign: " + response.Error);
            }

            KnetikLogger.LogResponse(mAddChallengeToCampaignStartTime, "AddChallengeToCampaign", "Response received successfully.");
            if (AddChallengeToCampaignComplete != null)
            {
                AddChallengeToCampaignComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="campaignResource">The campaign resource object</param>
        public void CreateCampaign(CampaignResource campaignResource)
        {
            
            mWebCallEvent.WebPath = "/campaigns";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(campaignResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateCampaignStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateCampaignResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateCampaignStartTime, "CreateCampaign", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateCampaignResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateCampaign: " + response.Error);
            }

            CreateCampaignData = (CampaignResource) KnetikClient.Deserialize(response.Content, typeof(CampaignResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCampaignStartTime, "CreateCampaign", string.Format("Response received successfully:\n{0}", CreateCampaignData));

            if (CreateCampaignComplete != null)
            {
                CreateCampaignComplete(response.ResponseCode, CreateCampaignData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a campaign template Campaign Templates define a type of campaign and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="campaignTemplateResource">The campaign template resource object</param>
        public void CreateCampaignTemplate(TemplateResource campaignTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/campaigns/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(campaignTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateCampaignTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateCampaignTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateCampaignTemplateStartTime, "CreateCampaignTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateCampaignTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateCampaignTemplate: " + response.Error);
            }

            CreateCampaignTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCampaignTemplateStartTime, "CreateCampaignTemplate", string.Format("Response received successfully:\n{0}", CreateCampaignTemplateData));

            if (CreateCampaignTemplateComplete != null)
            {
                CreateCampaignTemplateComplete(response.ResponseCode, CreateCampaignTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="id">The campaign id</param>
        public void DeleteCampaign(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteCampaign");
            }
            
            mWebCallEvent.WebPath = "/campaigns/{id}";
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
            mDeleteCampaignStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteCampaignResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteCampaignStartTime, "DeleteCampaign", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteCampaignResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteCampaign: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteCampaignStartTime, "DeleteCampaign", "Response received successfully.");
            if (DeleteCampaignComplete != null)
            {
                DeleteCampaignComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a campaign template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteCampaignTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteCampaignTemplate");
            }
            
            mWebCallEvent.WebPath = "/campaigns/templates/{id}";
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
            mDeleteCampaignTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteCampaignTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteCampaignTemplateStartTime, "DeleteCampaignTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteCampaignTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteCampaignTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteCampaignTemplateStartTime, "DeleteCampaignTemplate", "Response received successfully.");
            if (DeleteCampaignTemplateComplete != null)
            {
                DeleteCampaignTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a single campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The campaign id</param>
        public void GetCampaign(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCampaign");
            }
            
            mWebCallEvent.WebPath = "/campaigns/{id}";
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
            mGetCampaignStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCampaignResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCampaignStartTime, "GetCampaign", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCampaignResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCampaign: " + response.Error);
            }

            GetCampaignData = (CampaignResource) KnetikClient.Deserialize(response.Content, typeof(CampaignResource), response.Headers);
            KnetikLogger.LogResponse(mGetCampaignStartTime, "GetCampaign", string.Format("Response received successfully:\n{0}", GetCampaignData));

            if (GetCampaignComplete != null)
            {
                GetCampaignComplete(response.ResponseCode, GetCampaignData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List the challenges associated with a campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The campaign id</param>
        /// <param name="filterStartDate">A comma separated string without spaces.  First value is the operator to search on, second value is the challenge start date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterEndDate">A comma separated string without spaces.  First value is the operator to search on, second value is the challenge end date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCampaignChallenges(long? id, string filterStartDate, string filterEndDate, int? size, int? page, string order)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCampaignChallenges");
            }
            
            mWebCallEvent.WebPath = "/campaigns/{id}/challenges";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

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
            mGetCampaignChallengesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCampaignChallengesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCampaignChallengesStartTime, "GetCampaignChallenges", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCampaignChallengesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCampaignChallenges: " + response.Error);
            }

            GetCampaignChallengesData = (PageResourceChallengeResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceChallengeResource), response.Headers);
            KnetikLogger.LogResponse(mGetCampaignChallengesStartTime, "GetCampaignChallenges", string.Format("Response received successfully:\n{0}", GetCampaignChallengesData));

            if (GetCampaignChallengesComplete != null)
            {
                GetCampaignChallengesComplete(response.ResponseCode, GetCampaignChallengesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single campaign template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetCampaignTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCampaignTemplate");
            }
            
            mWebCallEvent.WebPath = "/campaigns/templates/{id}";
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
            mGetCampaignTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCampaignTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCampaignTemplateStartTime, "GetCampaignTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCampaignTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCampaignTemplate: " + response.Error);
            }

            GetCampaignTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetCampaignTemplateStartTime, "GetCampaignTemplate", string.Format("Response received successfully:\n{0}", GetCampaignTemplateData));

            if (GetCampaignTemplateComplete != null)
            {
                GetCampaignTemplateComplete(response.ResponseCode, GetCampaignTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search campaign templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCampaignTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/campaigns/templates";
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
            mGetCampaignTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCampaignTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCampaignTemplatesStartTime, "GetCampaignTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCampaignTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCampaignTemplates: " + response.Error);
            }

            GetCampaignTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetCampaignTemplatesStartTime, "GetCampaignTemplates", string.Format("Response received successfully:\n{0}", GetCampaignTemplatesData));

            if (GetCampaignTemplatesComplete != null)
            {
                GetCampaignTemplatesComplete(response.ResponseCode, GetCampaignTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search campaigns &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterActive">Filter for campaigns that are active</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCampaigns(bool? filterActive, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/campaigns";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterActive != null)
            {
                mWebCallEvent.QueryParams["filter_active"] = KnetikClient.ParameterToString(filterActive);
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
            mGetCampaignsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetCampaignsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetCampaignsStartTime, "GetCampaigns", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetCampaignsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetCampaigns: " + response.Error);
            }

            GetCampaignsData = (PageResourceCampaignResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceCampaignResource), response.Headers);
            KnetikLogger.LogResponse(mGetCampaignsStartTime, "GetCampaigns", string.Format("Response received successfully:\n{0}", GetCampaignsData));

            if (GetCampaignsComplete != null)
            {
                GetCampaignsComplete(response.ResponseCode, GetCampaignsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Remove a challenge from a campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <param name="id">The challenge id</param>
        public void RemoveChallengeFromCampaign(long? campaignId, long? id)
        {
            // verify the required parameter 'campaignId' is set
            if (campaignId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'campaignId' when calling RemoveChallengeFromCampaign");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling RemoveChallengeFromCampaign");
            }
            
            mWebCallEvent.WebPath = "/campaigns/{campaign_id}/challenges/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "campaign_id" + "}", KnetikClient.ParameterToString(campaignId));
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
            mRemoveChallengeFromCampaignStartTime = DateTime.Now;
            mWebCallEvent.Context = mRemoveChallengeFromCampaignResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mRemoveChallengeFromCampaignStartTime, "RemoveChallengeFromCampaign", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnRemoveChallengeFromCampaignResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling RemoveChallengeFromCampaign: " + response.Error);
            }

            KnetikLogger.LogResponse(mRemoveChallengeFromCampaignStartTime, "RemoveChallengeFromCampaign", "Response received successfully.");
            if (RemoveChallengeFromCampaignComplete != null)
            {
                RemoveChallengeFromCampaignComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a campaign &lt;b&gt;Permissions Needed:&lt;/b&gt; CAMPAIGNS_ADMIN
        /// </summary>
        /// <param name="id">The campaign id</param>
        /// <param name="campaignResource">The campaign resource object</param>
        public void UpdateCampaign(long? id, CampaignResource campaignResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateCampaign");
            }
            
            mWebCallEvent.WebPath = "/campaigns/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(campaignResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateCampaignStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateCampaignResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateCampaignStartTime, "UpdateCampaign", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateCampaignResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateCampaign: " + response.Error);
            }

            UpdateCampaignData = (CampaignResource) KnetikClient.Deserialize(response.Content, typeof(CampaignResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateCampaignStartTime, "UpdateCampaign", string.Format("Response received successfully:\n{0}", UpdateCampaignData));

            if (UpdateCampaignComplete != null)
            {
                UpdateCampaignComplete(response.ResponseCode, UpdateCampaignData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an campaign template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="campaignTemplateResource">The campaign template resource object</param>
        public void UpdateCampaignTemplate(string id, TemplateResource campaignTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateCampaignTemplate");
            }
            
            mWebCallEvent.WebPath = "/campaigns/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(campaignTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateCampaignTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateCampaignTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateCampaignTemplateStartTime, "UpdateCampaignTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateCampaignTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateCampaignTemplate: " + response.Error);
            }

            UpdateCampaignTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateCampaignTemplateStartTime, "UpdateCampaignTemplate", string.Format("Response received successfully:\n{0}", UpdateCampaignTemplateData));

            if (UpdateCampaignTemplateComplete != null)
            {
                UpdateCampaignTemplateComplete(response.ResponseCode, UpdateCampaignTemplateData);
            }
        }

    }
}
