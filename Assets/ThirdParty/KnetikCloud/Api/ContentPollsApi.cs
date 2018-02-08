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
    public interface IContentPollsApi
    {
        PollResponseResource AnswerPollData { get; }

        /// <summary>
        /// Add your vote to a poll &lt;b&gt;Permissions Needed:&lt;/b&gt; POLLS_ADMIN or POLLS_USER
        /// </summary>
        /// <param name="id">The poll id</param>
        /// <param name="answerKey">The answer key</param>
        void AnswerPoll(string id, StringWrapper answerKey);

        PollResource CreatePollData { get; }

        /// <summary>
        /// Create a new poll Polls are blobs of text with titles, a category and assets. Formatting and display of the text is in the hands of the front end. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; POLLS_ADMIN
        /// </summary>
        /// <param name="pollResource">The poll object</param>
        void CreatePoll(PollResource pollResource);

        TemplateResource CreatePollTemplateData { get; }

        /// <summary>
        /// Create a poll template Poll templates define a type of poll and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="pollTemplateResource">The poll template resource object</param>
        void CreatePollTemplate(TemplateResource pollTemplateResource);

        

        /// <summary>
        /// Delete an existing poll &lt;b&gt;Permissions Needed:&lt;/b&gt; POLLS_ADMIN
        /// </summary>
        /// <param name="id">The poll id</param>
        void DeletePoll(string id);

        

        /// <summary>
        /// Delete a poll template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeletePollTemplate(string id, string cascade);

        PollResource GetPollData { get; }

        /// <summary>
        /// Get a single poll &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The poll id</param>
        void GetPoll(string id);

        PollResponseResource GetPollAnswerData { get; }

        /// <summary>
        /// Get poll answer &lt;b&gt;Permissions Needed:&lt;/b&gt; POLLS_ADMIN or POLLS_USER
        /// </summary>
        /// <param name="id">The poll id</param>
        void GetPollAnswer(string id);

        TemplateResource GetPollTemplateData { get; }

        /// <summary>
        /// Get a single poll template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or POLLS_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetPollTemplate(string id);

        PageResourceTemplateResource GetPollTemplatesData { get; }

        /// <summary>
        /// List and search poll templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or POLLS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetPollTemplates(int? size, int? page, string order);

        PageResourcePollResource GetPollsData { get; }

        /// <summary>
        /// List and search polls Get a list of polls with optional filtering. Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterCategory">Filter for polls from a specific category by id</param>
        /// <param name="filterTagset">Filter for polls with specified tags (separated by comma)</param>
        /// <param name="filterText">Filter for polls whose text contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetPolls(string filterCategory, string filterTagset, string filterText, int? size, int? page, string order);

        PollResource UpdatePollData { get; }

        /// <summary>
        /// Update an existing poll &lt;b&gt;Permissions Needed:&lt;/b&gt; POLLS_ADMIN
        /// </summary>
        /// <param name="id">The poll id</param>
        /// <param name="pollResource">The poll object</param>
        void UpdatePoll(string id, PollResource pollResource);

        TemplateResource UpdatePollTemplateData { get; }

        /// <summary>
        /// Update a poll template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAnswerPollResponseContext;
        private DateTime mAnswerPollStartTime;
        private readonly KnetikResponseContext mCreatePollResponseContext;
        private DateTime mCreatePollStartTime;
        private readonly KnetikResponseContext mCreatePollTemplateResponseContext;
        private DateTime mCreatePollTemplateStartTime;
        private readonly KnetikResponseContext mDeletePollResponseContext;
        private DateTime mDeletePollStartTime;
        private readonly KnetikResponseContext mDeletePollTemplateResponseContext;
        private DateTime mDeletePollTemplateStartTime;
        private readonly KnetikResponseContext mGetPollResponseContext;
        private DateTime mGetPollStartTime;
        private readonly KnetikResponseContext mGetPollAnswerResponseContext;
        private DateTime mGetPollAnswerStartTime;
        private readonly KnetikResponseContext mGetPollTemplateResponseContext;
        private DateTime mGetPollTemplateStartTime;
        private readonly KnetikResponseContext mGetPollTemplatesResponseContext;
        private DateTime mGetPollTemplatesStartTime;
        private readonly KnetikResponseContext mGetPollsResponseContext;
        private DateTime mGetPollsStartTime;
        private readonly KnetikResponseContext mUpdatePollResponseContext;
        private DateTime mUpdatePollStartTime;
        private readonly KnetikResponseContext mUpdatePollTemplateResponseContext;
        private DateTime mUpdatePollTemplateStartTime;

        public PollResponseResource AnswerPollData { get; private set; }
        public delegate void AnswerPollCompleteDelegate(long responseCode, PollResponseResource response);
        public AnswerPollCompleteDelegate AnswerPollComplete;

        public PollResource CreatePollData { get; private set; }
        public delegate void CreatePollCompleteDelegate(long responseCode, PollResource response);
        public CreatePollCompleteDelegate CreatePollComplete;

        public TemplateResource CreatePollTemplateData { get; private set; }
        public delegate void CreatePollTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreatePollTemplateCompleteDelegate CreatePollTemplateComplete;

        public delegate void DeletePollCompleteDelegate(long responseCode);
        public DeletePollCompleteDelegate DeletePollComplete;

        public delegate void DeletePollTemplateCompleteDelegate(long responseCode);
        public DeletePollTemplateCompleteDelegate DeletePollTemplateComplete;

        public PollResource GetPollData { get; private set; }
        public delegate void GetPollCompleteDelegate(long responseCode, PollResource response);
        public GetPollCompleteDelegate GetPollComplete;

        public PollResponseResource GetPollAnswerData { get; private set; }
        public delegate void GetPollAnswerCompleteDelegate(long responseCode, PollResponseResource response);
        public GetPollAnswerCompleteDelegate GetPollAnswerComplete;

        public TemplateResource GetPollTemplateData { get; private set; }
        public delegate void GetPollTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetPollTemplateCompleteDelegate GetPollTemplateComplete;

        public PageResourceTemplateResource GetPollTemplatesData { get; private set; }
        public delegate void GetPollTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetPollTemplatesCompleteDelegate GetPollTemplatesComplete;

        public PageResourcePollResource GetPollsData { get; private set; }
        public delegate void GetPollsCompleteDelegate(long responseCode, PageResourcePollResource response);
        public GetPollsCompleteDelegate GetPollsComplete;

        public PollResource UpdatePollData { get; private set; }
        public delegate void UpdatePollCompleteDelegate(long responseCode, PollResource response);
        public UpdatePollCompleteDelegate UpdatePollComplete;

        public TemplateResource UpdatePollTemplateData { get; private set; }
        public delegate void UpdatePollTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdatePollTemplateCompleteDelegate UpdatePollTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentPollsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ContentPollsApi()
        {
            mAnswerPollResponseContext = new KnetikResponseContext();
            mAnswerPollResponseContext.ResponseReceived += OnAnswerPollResponse;
            mCreatePollResponseContext = new KnetikResponseContext();
            mCreatePollResponseContext.ResponseReceived += OnCreatePollResponse;
            mCreatePollTemplateResponseContext = new KnetikResponseContext();
            mCreatePollTemplateResponseContext.ResponseReceived += OnCreatePollTemplateResponse;
            mDeletePollResponseContext = new KnetikResponseContext();
            mDeletePollResponseContext.ResponseReceived += OnDeletePollResponse;
            mDeletePollTemplateResponseContext = new KnetikResponseContext();
            mDeletePollTemplateResponseContext.ResponseReceived += OnDeletePollTemplateResponse;
            mGetPollResponseContext = new KnetikResponseContext();
            mGetPollResponseContext.ResponseReceived += OnGetPollResponse;
            mGetPollAnswerResponseContext = new KnetikResponseContext();
            mGetPollAnswerResponseContext.ResponseReceived += OnGetPollAnswerResponse;
            mGetPollTemplateResponseContext = new KnetikResponseContext();
            mGetPollTemplateResponseContext.ResponseReceived += OnGetPollTemplateResponse;
            mGetPollTemplatesResponseContext = new KnetikResponseContext();
            mGetPollTemplatesResponseContext.ResponseReceived += OnGetPollTemplatesResponse;
            mGetPollsResponseContext = new KnetikResponseContext();
            mGetPollsResponseContext.ResponseReceived += OnGetPollsResponse;
            mUpdatePollResponseContext = new KnetikResponseContext();
            mUpdatePollResponseContext.ResponseReceived += OnUpdatePollResponse;
            mUpdatePollTemplateResponseContext = new KnetikResponseContext();
            mUpdatePollTemplateResponseContext.ResponseReceived += OnUpdatePollTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add your vote to a poll &lt;b&gt;Permissions Needed:&lt;/b&gt; POLLS_ADMIN or POLLS_USER
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
            
            mWebCallEvent.WebPath = "/media/polls/{id}/response";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(answerKey); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAnswerPollStartTime = DateTime.Now;
            mWebCallEvent.Context = mAnswerPollResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAnswerPollStartTime, "AnswerPoll", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAnswerPollResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AnswerPoll: " + response.Error);
            }

            AnswerPollData = (PollResponseResource) KnetikClient.Deserialize(response.Content, typeof(PollResponseResource), response.Headers);
            KnetikLogger.LogResponse(mAnswerPollStartTime, "AnswerPoll", string.Format("Response received successfully:\n{0}", AnswerPollData));

            if (AnswerPollComplete != null)
            {
                AnswerPollComplete(response.ResponseCode, AnswerPollData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a new poll Polls are blobs of text with titles, a category and assets. Formatting and display of the text is in the hands of the front end. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; POLLS_ADMIN
        /// </summary>
        /// <param name="pollResource">The poll object</param>
        public void CreatePoll(PollResource pollResource)
        {
            
            mWebCallEvent.WebPath = "/media/polls";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(pollResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreatePollStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreatePollResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreatePollStartTime, "CreatePoll", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreatePollResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreatePoll: " + response.Error);
            }

            CreatePollData = (PollResource) KnetikClient.Deserialize(response.Content, typeof(PollResource), response.Headers);
            KnetikLogger.LogResponse(mCreatePollStartTime, "CreatePoll", string.Format("Response received successfully:\n{0}", CreatePollData));

            if (CreatePollComplete != null)
            {
                CreatePollComplete(response.ResponseCode, CreatePollData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a poll template Poll templates define a type of poll and the properties they have. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
        /// </summary>
        /// <param name="pollTemplateResource">The poll template resource object</param>
        public void CreatePollTemplate(TemplateResource pollTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/media/polls/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(pollTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreatePollTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreatePollTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreatePollTemplateStartTime, "CreatePollTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreatePollTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreatePollTemplate: " + response.Error);
            }

            CreatePollTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreatePollTemplateStartTime, "CreatePollTemplate", string.Format("Response received successfully:\n{0}", CreatePollTemplateData));

            if (CreatePollTemplateComplete != null)
            {
                CreatePollTemplateComplete(response.ResponseCode, CreatePollTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an existing poll &lt;b&gt;Permissions Needed:&lt;/b&gt; POLLS_ADMIN
        /// </summary>
        /// <param name="id">The poll id</param>
        public void DeletePoll(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeletePoll");
            }
            
            mWebCallEvent.WebPath = "/media/polls/{id}";
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
            mDeletePollStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeletePollResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeletePollStartTime, "DeletePoll", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeletePollResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeletePoll: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeletePollStartTime, "DeletePoll", "Response received successfully.");
            if (DeletePollComplete != null)
            {
                DeletePollComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a poll template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
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
            
            mWebCallEvent.WebPath = "/media/polls/templates/{id}";
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
            mDeletePollTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeletePollTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeletePollTemplateStartTime, "DeletePollTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeletePollTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeletePollTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeletePollTemplateStartTime, "DeletePollTemplate", "Response received successfully.");
            if (DeletePollTemplateComplete != null)
            {
                DeletePollTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single poll &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The poll id</param>
        public void GetPoll(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetPoll");
            }
            
            mWebCallEvent.WebPath = "/media/polls/{id}";
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
            mGetPollStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetPollResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetPollStartTime, "GetPoll", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetPollResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetPoll: " + response.Error);
            }

            GetPollData = (PollResource) KnetikClient.Deserialize(response.Content, typeof(PollResource), response.Headers);
            KnetikLogger.LogResponse(mGetPollStartTime, "GetPoll", string.Format("Response received successfully:\n{0}", GetPollData));

            if (GetPollComplete != null)
            {
                GetPollComplete(response.ResponseCode, GetPollData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get poll answer &lt;b&gt;Permissions Needed:&lt;/b&gt; POLLS_ADMIN or POLLS_USER
        /// </summary>
        /// <param name="id">The poll id</param>
        public void GetPollAnswer(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetPollAnswer");
            }
            
            mWebCallEvent.WebPath = "/media/polls/{id}/response";
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
            mGetPollAnswerStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetPollAnswerResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetPollAnswerStartTime, "GetPollAnswer", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetPollAnswerResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetPollAnswer: " + response.Error);
            }

            GetPollAnswerData = (PollResponseResource) KnetikClient.Deserialize(response.Content, typeof(PollResponseResource), response.Headers);
            KnetikLogger.LogResponse(mGetPollAnswerStartTime, "GetPollAnswer", string.Format("Response received successfully:\n{0}", GetPollAnswerData));

            if (GetPollAnswerComplete != null)
            {
                GetPollAnswerComplete(response.ResponseCode, GetPollAnswerData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single poll template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or POLLS_ADMIN
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetPollTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetPollTemplate");
            }
            
            mWebCallEvent.WebPath = "/media/polls/templates/{id}";
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
            mGetPollTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetPollTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetPollTemplateStartTime, "GetPollTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetPollTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetPollTemplate: " + response.Error);
            }

            GetPollTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetPollTemplateStartTime, "GetPollTemplate", string.Format("Response received successfully:\n{0}", GetPollTemplateData));

            if (GetPollTemplateComplete != null)
            {
                GetPollTemplateComplete(response.ResponseCode, GetPollTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search poll templates &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN or POLLS_ADMIN
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetPollTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/media/polls/templates";
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
            mGetPollTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetPollTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetPollTemplatesStartTime, "GetPollTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetPollTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetPollTemplates: " + response.Error);
            }

            GetPollTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetPollTemplatesStartTime, "GetPollTemplates", string.Format("Response received successfully:\n{0}", GetPollTemplatesData));

            if (GetPollTemplatesComplete != null)
            {
                GetPollTemplatesComplete(response.ResponseCode, GetPollTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search polls Get a list of polls with optional filtering. Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterCategory">Filter for polls from a specific category by id</param>
        /// <param name="filterTagset">Filter for polls with specified tags (separated by comma)</param>
        /// <param name="filterText">Filter for polls whose text contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetPolls(string filterCategory, string filterTagset, string filterText, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/media/polls";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterCategory != null)
            {
                mWebCallEvent.QueryParams["filter_category"] = KnetikClient.ParameterToString(filterCategory);
            }

            if (filterTagset != null)
            {
                mWebCallEvent.QueryParams["filter_tagset"] = KnetikClient.ParameterToString(filterTagset);
            }

            if (filterText != null)
            {
                mWebCallEvent.QueryParams["filter_text"] = KnetikClient.ParameterToString(filterText);
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
            mGetPollsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetPollsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetPollsStartTime, "GetPolls", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetPollsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetPolls: " + response.Error);
            }

            GetPollsData = (PageResourcePollResource) KnetikClient.Deserialize(response.Content, typeof(PageResourcePollResource), response.Headers);
            KnetikLogger.LogResponse(mGetPollsStartTime, "GetPolls", string.Format("Response received successfully:\n{0}", GetPollsData));

            if (GetPollsComplete != null)
            {
                GetPollsComplete(response.ResponseCode, GetPollsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an existing poll &lt;b&gt;Permissions Needed:&lt;/b&gt; POLLS_ADMIN
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
            
            mWebCallEvent.WebPath = "/media/polls/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(pollResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdatePollStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdatePollResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdatePollStartTime, "UpdatePoll", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdatePollResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdatePoll: " + response.Error);
            }

            UpdatePollData = (PollResource) KnetikClient.Deserialize(response.Content, typeof(PollResource), response.Headers);
            KnetikLogger.LogResponse(mUpdatePollStartTime, "UpdatePoll", string.Format("Response received successfully:\n{0}", UpdatePollData));

            if (UpdatePollComplete != null)
            {
                UpdatePollComplete(response.ResponseCode, UpdatePollData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a poll template &lt;b&gt;Permissions Needed:&lt;/b&gt; TEMPLATE_ADMIN
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
            
            mWebCallEvent.WebPath = "/media/polls/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(pollTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdatePollTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdatePollTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdatePollTemplateStartTime, "UpdatePollTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdatePollTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdatePollTemplate: " + response.Error);
            }

            UpdatePollTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdatePollTemplateStartTime, "UpdatePollTemplate", string.Format("Response received successfully:\n{0}", UpdatePollTemplateData));

            if (UpdatePollTemplateComplete != null)
            {
                UpdatePollTemplateComplete(response.ResponseCode, UpdatePollTemplateData);
            }
        }

    }
}
