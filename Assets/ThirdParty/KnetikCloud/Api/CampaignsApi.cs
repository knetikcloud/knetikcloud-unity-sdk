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
    public interface ICampaignsApi
    {
        CampaignResource CreateCampaignData { get; }

        TemplateResource CreateCampaignTemplateData { get; }

        CampaignResource GetCampaignData { get; }

        PageResourceChallengeResource GetCampaignChallengesData { get; }

        TemplateResource GetCampaignTemplateData { get; }

        PageResourceTemplateResource GetCampaignTemplatesData { get; }

        PageResourceCampaignResource GetCampaignsData { get; }

        CampaignResource UpdateCampaignData { get; }

        TemplateResource UpdateCampaignTemplateData { get; }

        
        /// <summary>
        /// Add a challenge to a campaign 
        /// </summary>
        /// <param name="id">The id of the campaign</param>
        /// <param name="challengeId">The id of the challenge</param>
        void AddChallengeToCampaign(long? id, long? challengeId);

        /// <summary>
        /// Create a campaign 
        /// </summary>
        /// <param name="campaignResource">The campaign resource object</param>
        void CreateCampaign(CampaignResource campaignResource);

        /// <summary>
        /// Create a campaign template Campaign Templates define a type of campaign and the properties they have
        /// </summary>
        /// <param name="campaignTemplateResource">The campaign template resource object</param>
        void CreateCampaignTemplate(TemplateResource campaignTemplateResource);

        /// <summary>
        /// Delete a campaign 
        /// </summary>
        /// <param name="id">The campaign id</param>
        void DeleteCampaign(long? id);

        /// <summary>
        /// Delete a campaign template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteCampaignTemplate(string id, string cascade);

        /// <summary>
        /// Returns a single campaign 
        /// </summary>
        /// <param name="id">The campaign id</param>
        void GetCampaign(long? id);

        /// <summary>
        /// List the challenges associated with a campaign 
        /// </summary>
        /// <param name="id">The campaign id</param>
        /// <param name="filterStartDate">A comma separated string without spaces.  First value is the operator to search on, second value is the challenge start date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterEndDate">A comma separated string without spaces.  First value is the operator to search on, second value is the challenge end date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCampaignChallenges(long? id, string filterStartDate, string filterEndDate, int? size, int? page, string order);

        /// <summary>
        /// Get a single campaign template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetCampaignTemplate(string id);

        /// <summary>
        /// List and search campaign templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCampaignTemplates(int? size, int? page, string order);

        /// <summary>
        /// List and search campaigns 
        /// </summary>
        /// <param name="filterActive">Filter for campaigns that are active</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetCampaigns(bool? filterActive, int? size, int? page, string order);

        /// <summary>
        /// Remove a challenge from a campaign 
        /// </summary>
        /// <param name="campaignId">The campaign id</param>
        /// <param name="id">The challenge id</param>
        void RemoveChallengeFromCampaign(long? campaignId, long? id);

        /// <summary>
        /// Update a campaign 
        /// </summary>
        /// <param name="id">The campaign id</param>
        /// <param name="campaignResource">The campaign resource object</param>
        void UpdateCampaign(long? id, CampaignResource campaignResource);

        /// <summary>
        /// Update an campaign template 
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
        private readonly KnetikCoroutine mAddChallengeToCampaignCoroutine;
        private DateTime mAddChallengeToCampaignStartTime;
        private string mAddChallengeToCampaignPath;
        private readonly KnetikCoroutine mCreateCampaignCoroutine;
        private DateTime mCreateCampaignStartTime;
        private string mCreateCampaignPath;
        private readonly KnetikCoroutine mCreateCampaignTemplateCoroutine;
        private DateTime mCreateCampaignTemplateStartTime;
        private string mCreateCampaignTemplatePath;
        private readonly KnetikCoroutine mDeleteCampaignCoroutine;
        private DateTime mDeleteCampaignStartTime;
        private string mDeleteCampaignPath;
        private readonly KnetikCoroutine mDeleteCampaignTemplateCoroutine;
        private DateTime mDeleteCampaignTemplateStartTime;
        private string mDeleteCampaignTemplatePath;
        private readonly KnetikCoroutine mGetCampaignCoroutine;
        private DateTime mGetCampaignStartTime;
        private string mGetCampaignPath;
        private readonly KnetikCoroutine mGetCampaignChallengesCoroutine;
        private DateTime mGetCampaignChallengesStartTime;
        private string mGetCampaignChallengesPath;
        private readonly KnetikCoroutine mGetCampaignTemplateCoroutine;
        private DateTime mGetCampaignTemplateStartTime;
        private string mGetCampaignTemplatePath;
        private readonly KnetikCoroutine mGetCampaignTemplatesCoroutine;
        private DateTime mGetCampaignTemplatesStartTime;
        private string mGetCampaignTemplatesPath;
        private readonly KnetikCoroutine mGetCampaignsCoroutine;
        private DateTime mGetCampaignsStartTime;
        private string mGetCampaignsPath;
        private readonly KnetikCoroutine mRemoveChallengeFromCampaignCoroutine;
        private DateTime mRemoveChallengeFromCampaignStartTime;
        private string mRemoveChallengeFromCampaignPath;
        private readonly KnetikCoroutine mUpdateCampaignCoroutine;
        private DateTime mUpdateCampaignStartTime;
        private string mUpdateCampaignPath;
        private readonly KnetikCoroutine mUpdateCampaignTemplateCoroutine;
        private DateTime mUpdateCampaignTemplateStartTime;
        private string mUpdateCampaignTemplatePath;

        public delegate void AddChallengeToCampaignCompleteDelegate();
        public AddChallengeToCampaignCompleteDelegate AddChallengeToCampaignComplete;

        public CampaignResource CreateCampaignData { get; private set; }
        public delegate void CreateCampaignCompleteDelegate(CampaignResource response);
        public CreateCampaignCompleteDelegate CreateCampaignComplete;

        public TemplateResource CreateCampaignTemplateData { get; private set; }
        public delegate void CreateCampaignTemplateCompleteDelegate(TemplateResource response);
        public CreateCampaignTemplateCompleteDelegate CreateCampaignTemplateComplete;

        public delegate void DeleteCampaignCompleteDelegate();
        public DeleteCampaignCompleteDelegate DeleteCampaignComplete;

        public delegate void DeleteCampaignTemplateCompleteDelegate();
        public DeleteCampaignTemplateCompleteDelegate DeleteCampaignTemplateComplete;

        public CampaignResource GetCampaignData { get; private set; }
        public delegate void GetCampaignCompleteDelegate(CampaignResource response);
        public GetCampaignCompleteDelegate GetCampaignComplete;

        public PageResourceChallengeResource GetCampaignChallengesData { get; private set; }
        public delegate void GetCampaignChallengesCompleteDelegate(PageResourceChallengeResource response);
        public GetCampaignChallengesCompleteDelegate GetCampaignChallengesComplete;

        public TemplateResource GetCampaignTemplateData { get; private set; }
        public delegate void GetCampaignTemplateCompleteDelegate(TemplateResource response);
        public GetCampaignTemplateCompleteDelegate GetCampaignTemplateComplete;

        public PageResourceTemplateResource GetCampaignTemplatesData { get; private set; }
        public delegate void GetCampaignTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetCampaignTemplatesCompleteDelegate GetCampaignTemplatesComplete;

        public PageResourceCampaignResource GetCampaignsData { get; private set; }
        public delegate void GetCampaignsCompleteDelegate(PageResourceCampaignResource response);
        public GetCampaignsCompleteDelegate GetCampaignsComplete;

        public delegate void RemoveChallengeFromCampaignCompleteDelegate();
        public RemoveChallengeFromCampaignCompleteDelegate RemoveChallengeFromCampaignComplete;

        public CampaignResource UpdateCampaignData { get; private set; }
        public delegate void UpdateCampaignCompleteDelegate(CampaignResource response);
        public UpdateCampaignCompleteDelegate UpdateCampaignComplete;

        public TemplateResource UpdateCampaignTemplateData { get; private set; }
        public delegate void UpdateCampaignTemplateCompleteDelegate(TemplateResource response);
        public UpdateCampaignTemplateCompleteDelegate UpdateCampaignTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CampaignsApi()
        {
            mAddChallengeToCampaignCoroutine = new KnetikCoroutine();
            mCreateCampaignCoroutine = new KnetikCoroutine();
            mCreateCampaignTemplateCoroutine = new KnetikCoroutine();
            mDeleteCampaignCoroutine = new KnetikCoroutine();
            mDeleteCampaignTemplateCoroutine = new KnetikCoroutine();
            mGetCampaignCoroutine = new KnetikCoroutine();
            mGetCampaignChallengesCoroutine = new KnetikCoroutine();
            mGetCampaignTemplateCoroutine = new KnetikCoroutine();
            mGetCampaignTemplatesCoroutine = new KnetikCoroutine();
            mGetCampaignsCoroutine = new KnetikCoroutine();
            mRemoveChallengeFromCampaignCoroutine = new KnetikCoroutine();
            mUpdateCampaignCoroutine = new KnetikCoroutine();
            mUpdateCampaignTemplateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a challenge to a campaign 
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
            
            mAddChallengeToCampaignPath = "/campaigns/{id}/challenges";
            if (!string.IsNullOrEmpty(mAddChallengeToCampaignPath))
            {
                mAddChallengeToCampaignPath = mAddChallengeToCampaignPath.Replace("{format}", "json");
            }
            mAddChallengeToCampaignPath = mAddChallengeToCampaignPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(challengeId); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddChallengeToCampaignStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddChallengeToCampaignStartTime, mAddChallengeToCampaignPath, "Sending server request...");

            // make the HTTP request
            mAddChallengeToCampaignCoroutine.ResponseReceived += AddChallengeToCampaignCallback;
            mAddChallengeToCampaignCoroutine.Start(mAddChallengeToCampaignPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddChallengeToCampaignCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddChallengeToCampaign: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddChallengeToCampaign: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mAddChallengeToCampaignStartTime, mAddChallengeToCampaignPath, "Response received successfully.");
            if (AddChallengeToCampaignComplete != null)
            {
                AddChallengeToCampaignComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Create a campaign 
        /// </summary>
        /// <param name="campaignResource">The campaign resource object</param>
        public void CreateCampaign(CampaignResource campaignResource)
        {
            
            mCreateCampaignPath = "/campaigns";
            if (!string.IsNullOrEmpty(mCreateCampaignPath))
            {
                mCreateCampaignPath = mCreateCampaignPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(campaignResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateCampaignStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateCampaignStartTime, mCreateCampaignPath, "Sending server request...");

            // make the HTTP request
            mCreateCampaignCoroutine.ResponseReceived += CreateCampaignCallback;
            mCreateCampaignCoroutine.Start(mCreateCampaignPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateCampaignCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCampaign: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCampaign: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateCampaignData = (CampaignResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CampaignResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCampaignStartTime, mCreateCampaignPath, string.Format("Response received successfully:\n{0}", CreateCampaignData.ToString()));

            if (CreateCampaignComplete != null)
            {
                CreateCampaignComplete(CreateCampaignData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Create a campaign template Campaign Templates define a type of campaign and the properties they have
        /// </summary>
        /// <param name="campaignTemplateResource">The campaign template resource object</param>
        public void CreateCampaignTemplate(TemplateResource campaignTemplateResource)
        {
            
            mCreateCampaignTemplatePath = "/campaigns/templates";
            if (!string.IsNullOrEmpty(mCreateCampaignTemplatePath))
            {
                mCreateCampaignTemplatePath = mCreateCampaignTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(campaignTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateCampaignTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateCampaignTemplateStartTime, mCreateCampaignTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateCampaignTemplateCoroutine.ResponseReceived += CreateCampaignTemplateCallback;
            mCreateCampaignTemplateCoroutine.Start(mCreateCampaignTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateCampaignTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCampaignTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateCampaignTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateCampaignTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateCampaignTemplateStartTime, mCreateCampaignTemplatePath, string.Format("Response received successfully:\n{0}", CreateCampaignTemplateData.ToString()));

            if (CreateCampaignTemplateComplete != null)
            {
                CreateCampaignTemplateComplete(CreateCampaignTemplateData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Delete a campaign 
        /// </summary>
        /// <param name="id">The campaign id</param>
        public void DeleteCampaign(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteCampaign");
            }
            
            mDeleteCampaignPath = "/campaigns/{id}";
            if (!string.IsNullOrEmpty(mDeleteCampaignPath))
            {
                mDeleteCampaignPath = mDeleteCampaignPath.Replace("{format}", "json");
            }
            mDeleteCampaignPath = mDeleteCampaignPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteCampaignStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteCampaignStartTime, mDeleteCampaignPath, "Sending server request...");

            // make the HTTP request
            mDeleteCampaignCoroutine.ResponseReceived += DeleteCampaignCallback;
            mDeleteCampaignCoroutine.Start(mDeleteCampaignPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteCampaignCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCampaign: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCampaign: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteCampaignStartTime, mDeleteCampaignPath, "Response received successfully.");
            if (DeleteCampaignComplete != null)
            {
                DeleteCampaignComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Delete a campaign template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
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
            
            mDeleteCampaignTemplatePath = "/campaigns/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteCampaignTemplatePath))
            {
                mDeleteCampaignTemplatePath = mDeleteCampaignTemplatePath.Replace("{format}", "json");
            }
            mDeleteCampaignTemplatePath = mDeleteCampaignTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mDeleteCampaignTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteCampaignTemplateStartTime, mDeleteCampaignTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteCampaignTemplateCoroutine.ResponseReceived += DeleteCampaignTemplateCallback;
            mDeleteCampaignTemplateCoroutine.Start(mDeleteCampaignTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteCampaignTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCampaignTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteCampaignTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteCampaignTemplateStartTime, mDeleteCampaignTemplatePath, "Response received successfully.");
            if (DeleteCampaignTemplateComplete != null)
            {
                DeleteCampaignTemplateComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Returns a single campaign 
        /// </summary>
        /// <param name="id">The campaign id</param>
        public void GetCampaign(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCampaign");
            }
            
            mGetCampaignPath = "/campaigns/{id}";
            if (!string.IsNullOrEmpty(mGetCampaignPath))
            {
                mGetCampaignPath = mGetCampaignPath.Replace("{format}", "json");
            }
            mGetCampaignPath = mGetCampaignPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetCampaignStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCampaignStartTime, mGetCampaignPath, "Sending server request...");

            // make the HTTP request
            mGetCampaignCoroutine.ResponseReceived += GetCampaignCallback;
            mGetCampaignCoroutine.Start(mGetCampaignPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCampaignCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCampaign: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCampaign: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCampaignData = (CampaignResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CampaignResource), response.Headers);
            KnetikLogger.LogResponse(mGetCampaignStartTime, mGetCampaignPath, string.Format("Response received successfully:\n{0}", GetCampaignData.ToString()));

            if (GetCampaignComplete != null)
            {
                GetCampaignComplete(GetCampaignData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// List the challenges associated with a campaign 
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
            
            mGetCampaignChallengesPath = "/campaigns/{id}/challenges";
            if (!string.IsNullOrEmpty(mGetCampaignChallengesPath))
            {
                mGetCampaignChallengesPath = mGetCampaignChallengesPath.Replace("{format}", "json");
            }
            mGetCampaignChallengesPath = mGetCampaignChallengesPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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

            mGetCampaignChallengesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCampaignChallengesStartTime, mGetCampaignChallengesPath, "Sending server request...");

            // make the HTTP request
            mGetCampaignChallengesCoroutine.ResponseReceived += GetCampaignChallengesCallback;
            mGetCampaignChallengesCoroutine.Start(mGetCampaignChallengesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCampaignChallengesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCampaignChallenges: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCampaignChallenges: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCampaignChallengesData = (PageResourceChallengeResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceChallengeResource), response.Headers);
            KnetikLogger.LogResponse(mGetCampaignChallengesStartTime, mGetCampaignChallengesPath, string.Format("Response received successfully:\n{0}", GetCampaignChallengesData.ToString()));

            if (GetCampaignChallengesComplete != null)
            {
                GetCampaignChallengesComplete(GetCampaignChallengesData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Get a single campaign template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetCampaignTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetCampaignTemplate");
            }
            
            mGetCampaignTemplatePath = "/campaigns/templates/{id}";
            if (!string.IsNullOrEmpty(mGetCampaignTemplatePath))
            {
                mGetCampaignTemplatePath = mGetCampaignTemplatePath.Replace("{format}", "json");
            }
            mGetCampaignTemplatePath = mGetCampaignTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetCampaignTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCampaignTemplateStartTime, mGetCampaignTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetCampaignTemplateCoroutine.ResponseReceived += GetCampaignTemplateCallback;
            mGetCampaignTemplateCoroutine.Start(mGetCampaignTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCampaignTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCampaignTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCampaignTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCampaignTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetCampaignTemplateStartTime, mGetCampaignTemplatePath, string.Format("Response received successfully:\n{0}", GetCampaignTemplateData.ToString()));

            if (GetCampaignTemplateComplete != null)
            {
                GetCampaignTemplateComplete(GetCampaignTemplateData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// List and search campaign templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCampaignTemplates(int? size, int? page, string order)
        {
            
            mGetCampaignTemplatesPath = "/campaigns/templates";
            if (!string.IsNullOrEmpty(mGetCampaignTemplatesPath))
            {
                mGetCampaignTemplatesPath = mGetCampaignTemplatesPath.Replace("{format}", "json");
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

            mGetCampaignTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCampaignTemplatesStartTime, mGetCampaignTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetCampaignTemplatesCoroutine.ResponseReceived += GetCampaignTemplatesCallback;
            mGetCampaignTemplatesCoroutine.Start(mGetCampaignTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCampaignTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCampaignTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCampaignTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCampaignTemplatesData = (PageResourceTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetCampaignTemplatesStartTime, mGetCampaignTemplatesPath, string.Format("Response received successfully:\n{0}", GetCampaignTemplatesData.ToString()));

            if (GetCampaignTemplatesComplete != null)
            {
                GetCampaignTemplatesComplete(GetCampaignTemplatesData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// List and search campaigns 
        /// </summary>
        /// <param name="filterActive">Filter for campaigns that are active</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetCampaigns(bool? filterActive, int? size, int? page, string order)
        {
            
            mGetCampaignsPath = "/campaigns";
            if (!string.IsNullOrEmpty(mGetCampaignsPath))
            {
                mGetCampaignsPath = mGetCampaignsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterActive != null)
            {
                queryParams.Add("filter_active", KnetikClient.DefaultClient.ParameterToString(filterActive));
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

            mGetCampaignsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetCampaignsStartTime, mGetCampaignsPath, "Sending server request...");

            // make the HTTP request
            mGetCampaignsCoroutine.ResponseReceived += GetCampaignsCallback;
            mGetCampaignsCoroutine.Start(mGetCampaignsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetCampaignsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCampaigns: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetCampaigns: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetCampaignsData = (PageResourceCampaignResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceCampaignResource), response.Headers);
            KnetikLogger.LogResponse(mGetCampaignsStartTime, mGetCampaignsPath, string.Format("Response received successfully:\n{0}", GetCampaignsData.ToString()));

            if (GetCampaignsComplete != null)
            {
                GetCampaignsComplete(GetCampaignsData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Remove a challenge from a campaign 
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
            
            mRemoveChallengeFromCampaignPath = "/campaigns/{campaign_id}/challenges/{id}";
            if (!string.IsNullOrEmpty(mRemoveChallengeFromCampaignPath))
            {
                mRemoveChallengeFromCampaignPath = mRemoveChallengeFromCampaignPath.Replace("{format}", "json");
            }
            mRemoveChallengeFromCampaignPath = mRemoveChallengeFromCampaignPath.Replace("{" + "campaign_id" + "}", KnetikClient.DefaultClient.ParameterToString(campaignId));
mRemoveChallengeFromCampaignPath = mRemoveChallengeFromCampaignPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mRemoveChallengeFromCampaignStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mRemoveChallengeFromCampaignStartTime, mRemoveChallengeFromCampaignPath, "Sending server request...");

            // make the HTTP request
            mRemoveChallengeFromCampaignCoroutine.ResponseReceived += RemoveChallengeFromCampaignCallback;
            mRemoveChallengeFromCampaignCoroutine.Start(mRemoveChallengeFromCampaignPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void RemoveChallengeFromCampaignCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveChallengeFromCampaign: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveChallengeFromCampaign: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mRemoveChallengeFromCampaignStartTime, mRemoveChallengeFromCampaignPath, "Response received successfully.");
            if (RemoveChallengeFromCampaignComplete != null)
            {
                RemoveChallengeFromCampaignComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Update a campaign 
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
            
            mUpdateCampaignPath = "/campaigns/{id}";
            if (!string.IsNullOrEmpty(mUpdateCampaignPath))
            {
                mUpdateCampaignPath = mUpdateCampaignPath.Replace("{format}", "json");
            }
            mUpdateCampaignPath = mUpdateCampaignPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(campaignResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateCampaignStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateCampaignStartTime, mUpdateCampaignPath, "Sending server request...");

            // make the HTTP request
            mUpdateCampaignCoroutine.ResponseReceived += UpdateCampaignCallback;
            mUpdateCampaignCoroutine.Start(mUpdateCampaignPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateCampaignCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCampaign: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCampaign: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateCampaignData = (CampaignResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CampaignResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateCampaignStartTime, mUpdateCampaignPath, string.Format("Response received successfully:\n{0}", UpdateCampaignData.ToString()));

            if (UpdateCampaignComplete != null)
            {
                UpdateCampaignComplete(UpdateCampaignData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Update an campaign template 
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
            
            mUpdateCampaignTemplatePath = "/campaigns/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateCampaignTemplatePath))
            {
                mUpdateCampaignTemplatePath = mUpdateCampaignTemplatePath.Replace("{format}", "json");
            }
            mUpdateCampaignTemplatePath = mUpdateCampaignTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(campaignTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateCampaignTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateCampaignTemplateStartTime, mUpdateCampaignTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateCampaignTemplateCoroutine.ResponseReceived += UpdateCampaignTemplateCallback;
            mUpdateCampaignTemplateCoroutine.Start(mUpdateCampaignTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateCampaignTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCampaignTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateCampaignTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateCampaignTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateCampaignTemplateStartTime, mUpdateCampaignTemplatePath, string.Format("Response received successfully:\n{0}", UpdateCampaignTemplateData.ToString()));

            if (UpdateCampaignTemplateComplete != null)
            {
                UpdateCampaignTemplateComplete(UpdateCampaignTemplateData);
            }
        }
    }
}
