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
    public interface IMessagingApi
    {
        Dictionary<string, string> CompileMessageTemplateData { get; }

        /// <summary>
        /// Compile a message template Processes a set of input data against the template and returnes the compiled result. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="request">request</param>
        void CompileMessageTemplate(MessageTemplateBulkRequest request);

        MessageTemplateResource CreateMessageTemplateData { get; }

        /// <summary>
        /// Create a message template &lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="messageTemplate">The new template email to be sent</param>
        void CreateMessageTemplate(MessageTemplateResource messageTemplate);

        

        /// <summary>
        /// Delete an existing message template &lt;b&gt;Permissions Needed:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="id">The message_template id</param>
        void DeleteMessageTemplate(string id);

        MessageTemplateResource GetMessageTemplateData { get; }

        /// <summary>
        /// Get a single message template &lt;b&gt;Permissions Needed:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="id">The message_template id</param>
        void GetMessageTemplate(string id);

        PageResourceMessageTemplateResource GetMessageTemplatesData { get; }

        /// <summary>
        /// List and search message templates Get a list of message templates with optional filtering. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="filterTagset">Filter for message templates with at least one of a specified set of tags (separated by comma)</param>
        /// <param name="filterTagIntersection">Filter for message templates with all of a specified set of tags (separated by comma)</param>
        /// <param name="filterTagExclusion">Filter for message templates with none of a specified set of tags (separated by comma)</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetMessageTemplates(string filterTagset, string filterTagIntersection, string filterTagExclusion, int? size, int? page, string order);

        

        /// <summary>
        /// Send a message Sends a message with one or more formats to one or more users. Fill in any message formats desired (email, sms, websockets) and each user will recieve all valid formats. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="messageResource">The message to be sent</param>
        void SendMessage1(MessageResource messageResource);

        

        /// <summary>
        /// Send a raw email to one or more users &lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="rawEmailResource">The new raw email to be sent</param>
        void SendRawEmail(RawEmailResource rawEmailResource);

        

        /// <summary>
        /// Send a raw push notification Sends a raw push notification message to one or more users. User&#39;s without registered mobile device for the application will be skipped. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="rawPushResource">The new raw push notification to be sent</param>
        void SendRawPush(RawPushResource rawPushResource);

        

        /// <summary>
        /// Send a raw SMS Sends a raw SMS text message to one or more users. User&#39;s without registered mobile numbers will be skipped. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="rawSMSResource">The new raw SMS to be sent</param>
        void SendRawSMS(RawSMSResource rawSMSResource);

        

        /// <summary>
        /// Send a templated email to one or more users &lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="messageResource">The new template email to be sent</param>
        void SendTemplatedEmail(TemplateEmailResource messageResource);

        

        /// <summary>
        /// Send a templated push notification Sends a templated push notification message to one or more users. User&#39;s without registered mobile device for the application will be skipped. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="templatePushResource">The new templated push notification to be sent</param>
        void SendTemplatedPush(TemplatePushResource templatePushResource);

        

        /// <summary>
        /// Send a new templated SMS Sends a templated SMS text message to one or more users. User&#39;s without registered mobile numbers will be skipped. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="templateSMSResource">The new template SMS to be sent</param>
        void SendTemplatedSMS(TemplateSMSResource templateSMSResource);

        

        /// <summary>
        /// Send a websocket message Sends a websocket message to one or more users. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="websocketResource">The new websocket message to be sent</param>
        void SendWebsocket(WebsocketMessageResource websocketResource);

        MessageTemplateResource UpdateMessageTemplateData { get; }

        /// <summary>
        /// Update an existing message template &lt;b&gt;Permissions Needed:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="id">The message_template id</param>
        /// <param name="messageTemplateResource">The message template</param>
        void UpdateMessageTemplate(string id, MessageTemplateResource messageTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class MessagingApi : IMessagingApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCompileMessageTemplateResponseContext;
        private DateTime mCompileMessageTemplateStartTime;
        private readonly KnetikResponseContext mCreateMessageTemplateResponseContext;
        private DateTime mCreateMessageTemplateStartTime;
        private readonly KnetikResponseContext mDeleteMessageTemplateResponseContext;
        private DateTime mDeleteMessageTemplateStartTime;
        private readonly KnetikResponseContext mGetMessageTemplateResponseContext;
        private DateTime mGetMessageTemplateStartTime;
        private readonly KnetikResponseContext mGetMessageTemplatesResponseContext;
        private DateTime mGetMessageTemplatesStartTime;
        private readonly KnetikResponseContext mSendMessage1ResponseContext;
        private DateTime mSendMessage1StartTime;
        private readonly KnetikResponseContext mSendRawEmailResponseContext;
        private DateTime mSendRawEmailStartTime;
        private readonly KnetikResponseContext mSendRawPushResponseContext;
        private DateTime mSendRawPushStartTime;
        private readonly KnetikResponseContext mSendRawSMSResponseContext;
        private DateTime mSendRawSMSStartTime;
        private readonly KnetikResponseContext mSendTemplatedEmailResponseContext;
        private DateTime mSendTemplatedEmailStartTime;
        private readonly KnetikResponseContext mSendTemplatedPushResponseContext;
        private DateTime mSendTemplatedPushStartTime;
        private readonly KnetikResponseContext mSendTemplatedSMSResponseContext;
        private DateTime mSendTemplatedSMSStartTime;
        private readonly KnetikResponseContext mSendWebsocketResponseContext;
        private DateTime mSendWebsocketStartTime;
        private readonly KnetikResponseContext mUpdateMessageTemplateResponseContext;
        private DateTime mUpdateMessageTemplateStartTime;

        public Dictionary<string, string> CompileMessageTemplateData { get; private set; }
        public delegate void CompileMessageTemplateCompleteDelegate(long responseCode, Dictionary<string, string> response);
        public CompileMessageTemplateCompleteDelegate CompileMessageTemplateComplete;

        public MessageTemplateResource CreateMessageTemplateData { get; private set; }
        public delegate void CreateMessageTemplateCompleteDelegate(long responseCode, MessageTemplateResource response);
        public CreateMessageTemplateCompleteDelegate CreateMessageTemplateComplete;

        public delegate void DeleteMessageTemplateCompleteDelegate(long responseCode);
        public DeleteMessageTemplateCompleteDelegate DeleteMessageTemplateComplete;

        public MessageTemplateResource GetMessageTemplateData { get; private set; }
        public delegate void GetMessageTemplateCompleteDelegate(long responseCode, MessageTemplateResource response);
        public GetMessageTemplateCompleteDelegate GetMessageTemplateComplete;

        public PageResourceMessageTemplateResource GetMessageTemplatesData { get; private set; }
        public delegate void GetMessageTemplatesCompleteDelegate(long responseCode, PageResourceMessageTemplateResource response);
        public GetMessageTemplatesCompleteDelegate GetMessageTemplatesComplete;

        public delegate void SendMessage1CompleteDelegate(long responseCode);
        public SendMessage1CompleteDelegate SendMessage1Complete;

        public delegate void SendRawEmailCompleteDelegate(long responseCode);
        public SendRawEmailCompleteDelegate SendRawEmailComplete;

        public delegate void SendRawPushCompleteDelegate(long responseCode);
        public SendRawPushCompleteDelegate SendRawPushComplete;

        public delegate void SendRawSMSCompleteDelegate(long responseCode);
        public SendRawSMSCompleteDelegate SendRawSMSComplete;

        public delegate void SendTemplatedEmailCompleteDelegate(long responseCode);
        public SendTemplatedEmailCompleteDelegate SendTemplatedEmailComplete;

        public delegate void SendTemplatedPushCompleteDelegate(long responseCode);
        public SendTemplatedPushCompleteDelegate SendTemplatedPushComplete;

        public delegate void SendTemplatedSMSCompleteDelegate(long responseCode);
        public SendTemplatedSMSCompleteDelegate SendTemplatedSMSComplete;

        public delegate void SendWebsocketCompleteDelegate(long responseCode);
        public SendWebsocketCompleteDelegate SendWebsocketComplete;

        public MessageTemplateResource UpdateMessageTemplateData { get; private set; }
        public delegate void UpdateMessageTemplateCompleteDelegate(long responseCode, MessageTemplateResource response);
        public UpdateMessageTemplateCompleteDelegate UpdateMessageTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MessagingApi()
        {
            mCompileMessageTemplateResponseContext = new KnetikResponseContext();
            mCompileMessageTemplateResponseContext.ResponseReceived += OnCompileMessageTemplateResponse;
            mCreateMessageTemplateResponseContext = new KnetikResponseContext();
            mCreateMessageTemplateResponseContext.ResponseReceived += OnCreateMessageTemplateResponse;
            mDeleteMessageTemplateResponseContext = new KnetikResponseContext();
            mDeleteMessageTemplateResponseContext.ResponseReceived += OnDeleteMessageTemplateResponse;
            mGetMessageTemplateResponseContext = new KnetikResponseContext();
            mGetMessageTemplateResponseContext.ResponseReceived += OnGetMessageTemplateResponse;
            mGetMessageTemplatesResponseContext = new KnetikResponseContext();
            mGetMessageTemplatesResponseContext.ResponseReceived += OnGetMessageTemplatesResponse;
            mSendMessage1ResponseContext = new KnetikResponseContext();
            mSendMessage1ResponseContext.ResponseReceived += OnSendMessage1Response;
            mSendRawEmailResponseContext = new KnetikResponseContext();
            mSendRawEmailResponseContext.ResponseReceived += OnSendRawEmailResponse;
            mSendRawPushResponseContext = new KnetikResponseContext();
            mSendRawPushResponseContext.ResponseReceived += OnSendRawPushResponse;
            mSendRawSMSResponseContext = new KnetikResponseContext();
            mSendRawSMSResponseContext.ResponseReceived += OnSendRawSMSResponse;
            mSendTemplatedEmailResponseContext = new KnetikResponseContext();
            mSendTemplatedEmailResponseContext.ResponseReceived += OnSendTemplatedEmailResponse;
            mSendTemplatedPushResponseContext = new KnetikResponseContext();
            mSendTemplatedPushResponseContext.ResponseReceived += OnSendTemplatedPushResponse;
            mSendTemplatedSMSResponseContext = new KnetikResponseContext();
            mSendTemplatedSMSResponseContext.ResponseReceived += OnSendTemplatedSMSResponse;
            mSendWebsocketResponseContext = new KnetikResponseContext();
            mSendWebsocketResponseContext.ResponseReceived += OnSendWebsocketResponse;
            mUpdateMessageTemplateResponseContext = new KnetikResponseContext();
            mUpdateMessageTemplateResponseContext.ResponseReceived += OnUpdateMessageTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Compile a message template Processes a set of input data against the template and returnes the compiled result. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="request">request</param>
        public void CompileMessageTemplate(MessageTemplateBulkRequest request)
        {
            
            mWebCallEvent.WebPath = "/messaging/templates/compilations";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(request); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCompileMessageTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCompileMessageTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCompileMessageTemplateStartTime, "CompileMessageTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCompileMessageTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CompileMessageTemplate: " + response.Error);
            }

            CompileMessageTemplateData = (Dictionary<string, string>) KnetikClient.Deserialize(response.Content, typeof(Dictionary<string, string>), response.Headers);
            KnetikLogger.LogResponse(mCompileMessageTemplateStartTime, "CompileMessageTemplate", string.Format("Response received successfully:\n{0}", CompileMessageTemplateData));

            if (CompileMessageTemplateComplete != null)
            {
                CompileMessageTemplateComplete(response.ResponseCode, CompileMessageTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a message template &lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="messageTemplate">The new template email to be sent</param>
        public void CreateMessageTemplate(MessageTemplateResource messageTemplate)
        {
            
            mWebCallEvent.WebPath = "/messaging/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(messageTemplate); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateMessageTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateMessageTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateMessageTemplateStartTime, "CreateMessageTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateMessageTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateMessageTemplate: " + response.Error);
            }

            CreateMessageTemplateData = (MessageTemplateResource) KnetikClient.Deserialize(response.Content, typeof(MessageTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateMessageTemplateStartTime, "CreateMessageTemplate", string.Format("Response received successfully:\n{0}", CreateMessageTemplateData));

            if (CreateMessageTemplateComplete != null)
            {
                CreateMessageTemplateComplete(response.ResponseCode, CreateMessageTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an existing message template &lt;b&gt;Permissions Needed:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="id">The message_template id</param>
        public void DeleteMessageTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteMessageTemplate");
            }
            
            mWebCallEvent.WebPath = "/messaging/templates/{id}";
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
            mDeleteMessageTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteMessageTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteMessageTemplateStartTime, "DeleteMessageTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteMessageTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteMessageTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteMessageTemplateStartTime, "DeleteMessageTemplate", "Response received successfully.");
            if (DeleteMessageTemplateComplete != null)
            {
                DeleteMessageTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single message template &lt;b&gt;Permissions Needed:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="id">The message_template id</param>
        public void GetMessageTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetMessageTemplate");
            }
            
            mWebCallEvent.WebPath = "/messaging/templates/{id}";
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
            mGetMessageTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetMessageTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetMessageTemplateStartTime, "GetMessageTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetMessageTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetMessageTemplate: " + response.Error);
            }

            GetMessageTemplateData = (MessageTemplateResource) KnetikClient.Deserialize(response.Content, typeof(MessageTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetMessageTemplateStartTime, "GetMessageTemplate", string.Format("Response received successfully:\n{0}", GetMessageTemplateData));

            if (GetMessageTemplateComplete != null)
            {
                GetMessageTemplateComplete(response.ResponseCode, GetMessageTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search message templates Get a list of message templates with optional filtering. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="filterTagset">Filter for message templates with at least one of a specified set of tags (separated by comma)</param>
        /// <param name="filterTagIntersection">Filter for message templates with all of a specified set of tags (separated by comma)</param>
        /// <param name="filterTagExclusion">Filter for message templates with none of a specified set of tags (separated by comma)</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetMessageTemplates(string filterTagset, string filterTagIntersection, string filterTagExclusion, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/messaging/templates";
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

            if (filterTagIntersection != null)
            {
                mWebCallEvent.QueryParams["filter_tag_intersection"] = KnetikClient.ParameterToString(filterTagIntersection);
            }

            if (filterTagExclusion != null)
            {
                mWebCallEvent.QueryParams["filter_tag_exclusion"] = KnetikClient.ParameterToString(filterTagExclusion);
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
            mGetMessageTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetMessageTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetMessageTemplatesStartTime, "GetMessageTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetMessageTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetMessageTemplates: " + response.Error);
            }

            GetMessageTemplatesData = (PageResourceMessageTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceMessageTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetMessageTemplatesStartTime, "GetMessageTemplates", string.Format("Response received successfully:\n{0}", GetMessageTemplatesData));

            if (GetMessageTemplatesComplete != null)
            {
                GetMessageTemplatesComplete(response.ResponseCode, GetMessageTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a message Sends a message with one or more formats to one or more users. Fill in any message formats desired (email, sms, websockets) and each user will recieve all valid formats. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="messageResource">The message to be sent</param>
        public void SendMessage1(MessageResource messageResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/message";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(messageResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendMessage1StartTime = DateTime.Now;
            mWebCallEvent.Context = mSendMessage1ResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendMessage1StartTime, "SendMessage1", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendMessage1Response(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendMessage1: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendMessage1StartTime, "SendMessage1", "Response received successfully.");
            if (SendMessage1Complete != null)
            {
                SendMessage1Complete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a raw email to one or more users &lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="rawEmailResource">The new raw email to be sent</param>
        public void SendRawEmail(RawEmailResource rawEmailResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/raw-email";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(rawEmailResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendRawEmailStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendRawEmailResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendRawEmailStartTime, "SendRawEmail", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendRawEmailResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendRawEmail: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendRawEmailStartTime, "SendRawEmail", "Response received successfully.");
            if (SendRawEmailComplete != null)
            {
                SendRawEmailComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a raw push notification Sends a raw push notification message to one or more users. User&#39;s without registered mobile device for the application will be skipped. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="rawPushResource">The new raw push notification to be sent</param>
        public void SendRawPush(RawPushResource rawPushResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/raw-push";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(rawPushResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendRawPushStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendRawPushResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendRawPushStartTime, "SendRawPush", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendRawPushResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendRawPush: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendRawPushStartTime, "SendRawPush", "Response received successfully.");
            if (SendRawPushComplete != null)
            {
                SendRawPushComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a raw SMS Sends a raw SMS text message to one or more users. User&#39;s without registered mobile numbers will be skipped. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="rawSMSResource">The new raw SMS to be sent</param>
        public void SendRawSMS(RawSMSResource rawSMSResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/raw-sms";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(rawSMSResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendRawSMSStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendRawSMSResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendRawSMSStartTime, "SendRawSMS", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendRawSMSResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendRawSMS: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendRawSMSStartTime, "SendRawSMS", "Response received successfully.");
            if (SendRawSMSComplete != null)
            {
                SendRawSMSComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a templated email to one or more users &lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="messageResource">The new template email to be sent</param>
        public void SendTemplatedEmail(TemplateEmailResource messageResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/templated-email";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(messageResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendTemplatedEmailStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendTemplatedEmailResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendTemplatedEmailStartTime, "SendTemplatedEmail", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendTemplatedEmailResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendTemplatedEmail: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendTemplatedEmailStartTime, "SendTemplatedEmail", "Response received successfully.");
            if (SendTemplatedEmailComplete != null)
            {
                SendTemplatedEmailComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a templated push notification Sends a templated push notification message to one or more users. User&#39;s without registered mobile device for the application will be skipped. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="templatePushResource">The new templated push notification to be sent</param>
        public void SendTemplatedPush(TemplatePushResource templatePushResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/templated-push";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(templatePushResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendTemplatedPushStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendTemplatedPushResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendTemplatedPushStartTime, "SendTemplatedPush", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendTemplatedPushResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendTemplatedPush: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendTemplatedPushStartTime, "SendTemplatedPush", "Response received successfully.");
            if (SendTemplatedPushComplete != null)
            {
                SendTemplatedPushComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a new templated SMS Sends a templated SMS text message to one or more users. User&#39;s without registered mobile numbers will be skipped. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="templateSMSResource">The new template SMS to be sent</param>
        public void SendTemplatedSMS(TemplateSMSResource templateSMSResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/templated-sms";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(templateSMSResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendTemplatedSMSStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendTemplatedSMSResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendTemplatedSMSStartTime, "SendTemplatedSMS", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendTemplatedSMSResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendTemplatedSMS: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendTemplatedSMSStartTime, "SendTemplatedSMS", "Response received successfully.");
            if (SendTemplatedSMSComplete != null)
            {
                SendTemplatedSMSComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a websocket message Sends a websocket message to one or more users. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; MESSAGING_ADMIN
        /// </summary>
        /// <param name="websocketResource">The new websocket message to be sent</param>
        public void SendWebsocket(WebsocketMessageResource websocketResource)
        {
            
            mWebCallEvent.WebPath = "/messaging/websocket-message";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(websocketResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendWebsocketStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendWebsocketResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendWebsocketStartTime, "SendWebsocket", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendWebsocketResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendWebsocket: " + response.Error);
            }

            KnetikLogger.LogResponse(mSendWebsocketStartTime, "SendWebsocket", "Response received successfully.");
            if (SendWebsocketComplete != null)
            {
                SendWebsocketComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an existing message template &lt;b&gt;Permissions Needed:&lt;/b&gt; ARTICLES_ADMIN
        /// </summary>
        /// <param name="id">The message_template id</param>
        /// <param name="messageTemplateResource">The message template</param>
        public void UpdateMessageTemplate(string id, MessageTemplateResource messageTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateMessageTemplate");
            }
            
            mWebCallEvent.WebPath = "/messaging/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(messageTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateMessageTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateMessageTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateMessageTemplateStartTime, "UpdateMessageTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateMessageTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateMessageTemplate: " + response.Error);
            }

            UpdateMessageTemplateData = (MessageTemplateResource) KnetikClient.Deserialize(response.Content, typeof(MessageTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateMessageTemplateStartTime, "UpdateMessageTemplate", string.Format("Response received successfully:\n{0}", UpdateMessageTemplateData));

            if (UpdateMessageTemplateComplete != null)
            {
                UpdateMessageTemplateComplete(response.ResponseCode, UpdateMessageTemplateData);
            }
        }

    }
}
