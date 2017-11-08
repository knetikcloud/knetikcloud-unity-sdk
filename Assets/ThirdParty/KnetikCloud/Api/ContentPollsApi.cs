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
    public interface IContentPollsApi
    {
        PollResponseResource AnswerPollData { get; }

        PollResource CreatePollData { get; }

        TemplateResource CreatePollTemplateData { get; }

        PollResource GetPollData { get; }

        PollResponseResource GetPollAnswerData { get; }

        TemplateResource GetPollTemplateData { get; }

        PageResourceTemplateResource GetPollTemplatesData { get; }

        PageResourcePollResource GetPollsData { get; }

        PollResource UpdatePollData { get; }

        TemplateResource UpdatePollTemplateData { get; }

        
        /// <summary>
        /// Add your vote to a poll 
        /// </summary>
        /// <param name="id">The poll id</param>
        /// <param name="answerKey">The answer key</param>
        void AnswerPoll(string id, StringWrapper answerKey);

        /// <summary>
        /// Create a new poll Polls are blobs of text with titles, a category and assets. Formatting and display of the text is in the hands of the front end.
        /// </summary>
        /// <param name="pollResource">The poll object</param>
        void CreatePoll(PollResource pollResource);

        /// <summary>
        /// Create a poll template Poll templates define a type of poll and the properties they have
        /// </summary>
        /// <param name="pollTemplateResource">The poll template resource object</param>
        void CreatePollTemplate(TemplateResource pollTemplateResource);

        /// <summary>
        /// Delete an existing poll 
        /// </summary>
        /// <param name="id">The poll id</param>
        void DeletePoll(string id);

        /// <summary>
        /// Delete a poll template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeletePollTemplate(string id, string cascade);

        /// <summary>
        /// Get a single poll 
        /// </summary>
        /// <param name="id">The poll id</param>
        void GetPoll(string id);

        /// <summary>
        /// Get poll answer 
        /// </summary>
        /// <param name="id">The poll id</param>
        void GetPollAnswer(string id);

        /// <summary>
        /// Get a single poll template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetPollTemplate(string id);

        /// <summary>
        /// List and search poll templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetPollTemplates(int? size, int? page, string order);

        /// <summary>
        /// List and search polls Get a list of polls with optional filtering. Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed.
        /// </summary>
        /// <param name="filterCategory">Filter for polls from a specific category by id</param>
        /// <param name="filterTagset">Filter for polls with specified tags (separated by comma)</param>
        /// <param name="filterText">Filter for polls whose text contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetPolls(string filterCategory, string filterTagset, string filterText, int? size, int? page, string order);

        /// <summary>
        /// Update an existing poll 
        /// </summary>
        /// <param name="id">The poll id</param>
        /// <param name="pollResource">The poll object</param>
        void UpdatePoll(string id, PollResource pollResource);

        /// <summary>
        /// Update a poll template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="pollTemplateResource">The poll template resource object</param>
        void UpdatePollTemplate(string id, TemplateResource pollTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ContentPollsApi : IContentPollsApi
    {
        private readonly KnetikCoroutine mAnswerPollCoroutine;
        private DateTime mAnswerPollStartTime;
        private string mAnswerPollPath;
        private readonly KnetikCoroutine mCreatePollCoroutine;
        private DateTime mCreatePollStartTime;
        private string mCreatePollPath;
        private readonly KnetikCoroutine mCreatePollTemplateCoroutine;
        private DateTime mCreatePollTemplateStartTime;
        private string mCreatePollTemplatePath;
        private readonly KnetikCoroutine mDeletePollCoroutine;
        private DateTime mDeletePollStartTime;
        private string mDeletePollPath;
        private readonly KnetikCoroutine mDeletePollTemplateCoroutine;
        private DateTime mDeletePollTemplateStartTime;
        private string mDeletePollTemplatePath;
        private readonly KnetikCoroutine mGetPollCoroutine;
        private DateTime mGetPollStartTime;
        private string mGetPollPath;
        private readonly KnetikCoroutine mGetPollAnswerCoroutine;
        private DateTime mGetPollAnswerStartTime;
        private string mGetPollAnswerPath;
        private readonly KnetikCoroutine mGetPollTemplateCoroutine;
        private DateTime mGetPollTemplateStartTime;
        private string mGetPollTemplatePath;
        private readonly KnetikCoroutine mGetPollTemplatesCoroutine;
        private DateTime mGetPollTemplatesStartTime;
        private string mGetPollTemplatesPath;
        private readonly KnetikCoroutine mGetPollsCoroutine;
        private DateTime mGetPollsStartTime;
        private string mGetPollsPath;
        private readonly KnetikCoroutine mUpdatePollCoroutine;
        private DateTime mUpdatePollStartTime;
        private string mUpdatePollPath;
        private readonly KnetikCoroutine mUpdatePollTemplateCoroutine;
        private DateTime mUpdatePollTemplateStartTime;
        private string mUpdatePollTemplatePath;

        public PollResponseResource AnswerPollData { get; private set; }
        public delegate void AnswerPollCompleteDelegate(PollResponseResource response);
        public AnswerPollCompleteDelegate AnswerPollComplete;

        public PollResource CreatePollData { get; private set; }
        public delegate void CreatePollCompleteDelegate(PollResource response);
        public CreatePollCompleteDelegate CreatePollComplete;

        public TemplateResource CreatePollTemplateData { get; private set; }
        public delegate void CreatePollTemplateCompleteDelegate(TemplateResource response);
        public CreatePollTemplateCompleteDelegate CreatePollTemplateComplete;

        public delegate void DeletePollCompleteDelegate();
        public DeletePollCompleteDelegate DeletePollComplete;

        public delegate void DeletePollTemplateCompleteDelegate();
        public DeletePollTemplateCompleteDelegate DeletePollTemplateComplete;

        public PollResource GetPollData { get; private set; }
        public delegate void GetPollCompleteDelegate(PollResource response);
        public GetPollCompleteDelegate GetPollComplete;

        public PollResponseResource GetPollAnswerData { get; private set; }
        public delegate void GetPollAnswerCompleteDelegate(PollResponseResource response);
        public GetPollAnswerCompleteDelegate GetPollAnswerComplete;

        public TemplateResource GetPollTemplateData { get; private set; }
        public delegate void GetPollTemplateCompleteDelegate(TemplateResource response);
        public GetPollTemplateCompleteDelegate GetPollTemplateComplete;

        public PageResourceTemplateResource GetPollTemplatesData { get; private set; }
        public delegate void GetPollTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetPollTemplatesCompleteDelegate GetPollTemplatesComplete;

        public PageResourcePollResource GetPollsData { get; private set; }
        public delegate void GetPollsCompleteDelegate(PageResourcePollResource response);
        public GetPollsCompleteDelegate GetPollsComplete;

        public PollResource UpdatePollData { get; private set; }
        public delegate void UpdatePollCompleteDelegate(PollResource response);
        public UpdatePollCompleteDelegate UpdatePollComplete;

        public TemplateResource UpdatePollTemplateData { get; private set; }
        public delegate void UpdatePollTemplateCompleteDelegate(TemplateResource response);
        public UpdatePollTemplateCompleteDelegate UpdatePollTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentPollsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ContentPollsApi()
        {
            mAnswerPollCoroutine = new KnetikCoroutine();
            mCreatePollCoroutine = new KnetikCoroutine();
            mCreatePollTemplateCoroutine = new KnetikCoroutine();
            mDeletePollCoroutine = new KnetikCoroutine();
            mDeletePollTemplateCoroutine = new KnetikCoroutine();
            mGetPollCoroutine = new KnetikCoroutine();
            mGetPollAnswerCoroutine = new KnetikCoroutine();
            mGetPollTemplateCoroutine = new KnetikCoroutine();
            mGetPollTemplatesCoroutine = new KnetikCoroutine();
            mGetPollsCoroutine = new KnetikCoroutine();
            mUpdatePollCoroutine = new KnetikCoroutine();
            mUpdatePollTemplateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add your vote to a poll 
        /// </summary>
        /// <param name="id">The poll id</param>
        /// <param name="answerKey">The answer key</param>
        public void AnswerPoll(string id, StringWrapper answerKey)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AnswerPoll");
            }
            
            mAnswerPollPath = "/media/polls/{id}/response";
            if (!string.IsNullOrEmpty(mAnswerPollPath))
            {
                mAnswerPollPath = mAnswerPollPath.Replace("{format}", "json");
            }
            mAnswerPollPath = mAnswerPollPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(answerKey); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAnswerPollStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAnswerPollStartTime, mAnswerPollPath, "Sending server request...");

            // make the HTTP request
            mAnswerPollCoroutine.ResponseReceived += AnswerPollCallback;
            mAnswerPollCoroutine.Start(mAnswerPollPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AnswerPollCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AnswerPoll: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AnswerPoll: " + response.ErrorMessage, response.ErrorMessage);
            }

            AnswerPollData = (PollResponseResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PollResponseResource), response.Headers);
            KnetikLogger.LogResponse(mAnswerPollStartTime, mAnswerPollPath, string.Format("Response received successfully:\n{0}", AnswerPollData.ToString()));

            if (AnswerPollComplete != null)
            {
                AnswerPollComplete(AnswerPollData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a new poll Polls are blobs of text with titles, a category and assets. Formatting and display of the text is in the hands of the front end.
        /// </summary>
        /// <param name="pollResource">The poll object</param>
        public void CreatePoll(PollResource pollResource)
        {
            
            mCreatePollPath = "/media/polls";
            if (!string.IsNullOrEmpty(mCreatePollPath))
            {
                mCreatePollPath = mCreatePollPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(pollResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreatePollStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreatePollStartTime, mCreatePollPath, "Sending server request...");

            // make the HTTP request
            mCreatePollCoroutine.ResponseReceived += CreatePollCallback;
            mCreatePollCoroutine.Start(mCreatePollPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreatePollCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreatePoll: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreatePoll: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreatePollData = (PollResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PollResource), response.Headers);
            KnetikLogger.LogResponse(mCreatePollStartTime, mCreatePollPath, string.Format("Response received successfully:\n{0}", CreatePollData.ToString()));

            if (CreatePollComplete != null)
            {
                CreatePollComplete(CreatePollData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a poll template Poll templates define a type of poll and the properties they have
        /// </summary>
        /// <param name="pollTemplateResource">The poll template resource object</param>
        public void CreatePollTemplate(TemplateResource pollTemplateResource)
        {
            
            mCreatePollTemplatePath = "/media/polls/templates";
            if (!string.IsNullOrEmpty(mCreatePollTemplatePath))
            {
                mCreatePollTemplatePath = mCreatePollTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(pollTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreatePollTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreatePollTemplateStartTime, mCreatePollTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreatePollTemplateCoroutine.ResponseReceived += CreatePollTemplateCallback;
            mCreatePollTemplateCoroutine.Start(mCreatePollTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreatePollTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreatePollTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreatePollTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreatePollTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreatePollTemplateStartTime, mCreatePollTemplatePath, string.Format("Response received successfully:\n{0}", CreatePollTemplateData.ToString()));

            if (CreatePollTemplateComplete != null)
            {
                CreatePollTemplateComplete(CreatePollTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an existing poll 
        /// </summary>
        /// <param name="id">The poll id</param>
        public void DeletePoll(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeletePoll");
            }
            
            mDeletePollPath = "/media/polls/{id}";
            if (!string.IsNullOrEmpty(mDeletePollPath))
            {
                mDeletePollPath = mDeletePollPath.Replace("{format}", "json");
            }
            mDeletePollPath = mDeletePollPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeletePollStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeletePollStartTime, mDeletePollPath, "Sending server request...");

            // make the HTTP request
            mDeletePollCoroutine.ResponseReceived += DeletePollCallback;
            mDeletePollCoroutine.Start(mDeletePollPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeletePollCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeletePoll: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeletePoll: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeletePollStartTime, mDeletePollPath, "Response received successfully.");
            if (DeletePollComplete != null)
            {
                DeletePollComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a poll template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeletePollTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeletePollTemplate");
            }
            
            mDeletePollTemplatePath = "/media/polls/templates/{id}";
            if (!string.IsNullOrEmpty(mDeletePollTemplatePath))
            {
                mDeletePollTemplatePath = mDeletePollTemplatePath.Replace("{format}", "json");
            }
            mDeletePollTemplatePath = mDeletePollTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

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
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeletePollTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeletePollTemplateStartTime, mDeletePollTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeletePollTemplateCoroutine.ResponseReceived += DeletePollTemplateCallback;
            mDeletePollTemplateCoroutine.Start(mDeletePollTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeletePollTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeletePollTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeletePollTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeletePollTemplateStartTime, mDeletePollTemplatePath, "Response received successfully.");
            if (DeletePollTemplateComplete != null)
            {
                DeletePollTemplateComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single poll 
        /// </summary>
        /// <param name="id">The poll id</param>
        public void GetPoll(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetPoll");
            }
            
            mGetPollPath = "/media/polls/{id}";
            if (!string.IsNullOrEmpty(mGetPollPath))
            {
                mGetPollPath = mGetPollPath.Replace("{format}", "json");
            }
            mGetPollPath = mGetPollPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetPollStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetPollStartTime, mGetPollPath, "Sending server request...");

            // make the HTTP request
            mGetPollCoroutine.ResponseReceived += GetPollCallback;
            mGetPollCoroutine.Start(mGetPollPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetPollCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPoll: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPoll: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetPollData = (PollResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PollResource), response.Headers);
            KnetikLogger.LogResponse(mGetPollStartTime, mGetPollPath, string.Format("Response received successfully:\n{0}", GetPollData.ToString()));

            if (GetPollComplete != null)
            {
                GetPollComplete(GetPollData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get poll answer 
        /// </summary>
        /// <param name="id">The poll id</param>
        public void GetPollAnswer(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetPollAnswer");
            }
            
            mGetPollAnswerPath = "/media/polls/{id}/response";
            if (!string.IsNullOrEmpty(mGetPollAnswerPath))
            {
                mGetPollAnswerPath = mGetPollAnswerPath.Replace("{format}", "json");
            }
            mGetPollAnswerPath = mGetPollAnswerPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetPollAnswerStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetPollAnswerStartTime, mGetPollAnswerPath, "Sending server request...");

            // make the HTTP request
            mGetPollAnswerCoroutine.ResponseReceived += GetPollAnswerCallback;
            mGetPollAnswerCoroutine.Start(mGetPollAnswerPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetPollAnswerCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPollAnswer: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPollAnswer: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetPollAnswerData = (PollResponseResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PollResponseResource), response.Headers);
            KnetikLogger.LogResponse(mGetPollAnswerStartTime, mGetPollAnswerPath, string.Format("Response received successfully:\n{0}", GetPollAnswerData.ToString()));

            if (GetPollAnswerComplete != null)
            {
                GetPollAnswerComplete(GetPollAnswerData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single poll template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetPollTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetPollTemplate");
            }
            
            mGetPollTemplatePath = "/media/polls/templates/{id}";
            if (!string.IsNullOrEmpty(mGetPollTemplatePath))
            {
                mGetPollTemplatePath = mGetPollTemplatePath.Replace("{format}", "json");
            }
            mGetPollTemplatePath = mGetPollTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetPollTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetPollTemplateStartTime, mGetPollTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetPollTemplateCoroutine.ResponseReceived += GetPollTemplateCallback;
            mGetPollTemplateCoroutine.Start(mGetPollTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetPollTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPollTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPollTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetPollTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetPollTemplateStartTime, mGetPollTemplatePath, string.Format("Response received successfully:\n{0}", GetPollTemplateData.ToString()));

            if (GetPollTemplateComplete != null)
            {
                GetPollTemplateComplete(GetPollTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search poll templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetPollTemplates(int? size, int? page, string order)
        {
            
            mGetPollTemplatesPath = "/media/polls/templates";
            if (!string.IsNullOrEmpty(mGetPollTemplatesPath))
            {
                mGetPollTemplatesPath = mGetPollTemplatesPath.Replace("{format}", "json");
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
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetPollTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetPollTemplatesStartTime, mGetPollTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetPollTemplatesCoroutine.ResponseReceived += GetPollTemplatesCallback;
            mGetPollTemplatesCoroutine.Start(mGetPollTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetPollTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPollTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPollTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetPollTemplatesData = (PageResourceTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetPollTemplatesStartTime, mGetPollTemplatesPath, string.Format("Response received successfully:\n{0}", GetPollTemplatesData.ToString()));

            if (GetPollTemplatesComplete != null)
            {
                GetPollTemplatesComplete(GetPollTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search polls Get a list of polls with optional filtering. Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed.
        /// </summary>
        /// <param name="filterCategory">Filter for polls from a specific category by id</param>
        /// <param name="filterTagset">Filter for polls with specified tags (separated by comma)</param>
        /// <param name="filterText">Filter for polls whose text contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetPolls(string filterCategory, string filterTagset, string filterText, int? size, int? page, string order)
        {
            
            mGetPollsPath = "/media/polls";
            if (!string.IsNullOrEmpty(mGetPollsPath))
            {
                mGetPollsPath = mGetPollsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.DefaultClient.ParameterToString(filterCategory));
            }

            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.DefaultClient.ParameterToString(filterTagset));
            }

            if (filterText != null)
            {
                queryParams.Add("filter_text", KnetikClient.DefaultClient.ParameterToString(filterText));
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
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetPollsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetPollsStartTime, mGetPollsPath, "Sending server request...");

            // make the HTTP request
            mGetPollsCoroutine.ResponseReceived += GetPollsCallback;
            mGetPollsCoroutine.Start(mGetPollsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetPollsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPolls: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetPolls: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetPollsData = (PageResourcePollResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourcePollResource), response.Headers);
            KnetikLogger.LogResponse(mGetPollsStartTime, mGetPollsPath, string.Format("Response received successfully:\n{0}", GetPollsData.ToString()));

            if (GetPollsComplete != null)
            {
                GetPollsComplete(GetPollsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an existing poll 
        /// </summary>
        /// <param name="id">The poll id</param>
        /// <param name="pollResource">The poll object</param>
        public void UpdatePoll(string id, PollResource pollResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdatePoll");
            }
            
            mUpdatePollPath = "/media/polls/{id}";
            if (!string.IsNullOrEmpty(mUpdatePollPath))
            {
                mUpdatePollPath = mUpdatePollPath.Replace("{format}", "json");
            }
            mUpdatePollPath = mUpdatePollPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(pollResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdatePollStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdatePollStartTime, mUpdatePollPath, "Sending server request...");

            // make the HTTP request
            mUpdatePollCoroutine.ResponseReceived += UpdatePollCallback;
            mUpdatePollCoroutine.Start(mUpdatePollPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdatePollCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdatePoll: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdatePoll: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdatePollData = (PollResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PollResource), response.Headers);
            KnetikLogger.LogResponse(mUpdatePollStartTime, mUpdatePollPath, string.Format("Response received successfully:\n{0}", UpdatePollData.ToString()));

            if (UpdatePollComplete != null)
            {
                UpdatePollComplete(UpdatePollData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a poll template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="pollTemplateResource">The poll template resource object</param>
        public void UpdatePollTemplate(string id, TemplateResource pollTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdatePollTemplate");
            }
            
            mUpdatePollTemplatePath = "/media/polls/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdatePollTemplatePath))
            {
                mUpdatePollTemplatePath = mUpdatePollTemplatePath.Replace("{format}", "json");
            }
            mUpdatePollTemplatePath = mUpdatePollTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(pollTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdatePollTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdatePollTemplateStartTime, mUpdatePollTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdatePollTemplateCoroutine.ResponseReceived += UpdatePollTemplateCallback;
            mUpdatePollTemplateCoroutine.Start(mUpdatePollTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdatePollTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdatePollTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdatePollTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdatePollTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdatePollTemplateStartTime, mUpdatePollTemplatePath, string.Format("Response received successfully:\n{0}", UpdatePollTemplateData.ToString()));

            if (UpdatePollTemplateComplete != null)
            {
                UpdatePollTemplateComplete(UpdatePollTemplateData);
            }
        }

    }
}
