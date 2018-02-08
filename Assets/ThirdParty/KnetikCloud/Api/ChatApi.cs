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
    public interface IChatApi
    {
        

        /// <summary>
        /// Acknowledge number of messages in a thread &lt;b&gt;Permissions Needed:&lt;/b&gt; owner
        /// </summary>
        /// <param name="id">The thread id</param>
        /// <param name="readCount">The amount of messages read</param>
        void AcknowledgeChatMessage(string id, int? readCount);

        

        /// <summary>
        /// Add a user to a chat message blacklist &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="blacklistedUserId">The user id to blacklist</param>
        /// <param name="id">The user id or &#39;me&#39;</param>
        void AddChatMessageBlacklist(int? blacklistedUserId, string id);

        

        /// <summary>
        /// Delete a message &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="id">The message id</param>
        void DeleteChatMessage(string id);

        

        /// <summary>
        /// Edit your message &lt;b&gt;Permissions Needed:&lt;/b&gt; owner
        /// </summary>
        /// <param name="id">The message id</param>
        /// <param name="chatMessageResource">The chat message resource</param>
        void EditChatMessage(string id, ChatMessageResource chatMessageResource);

        ChatMessageResource GetChatMessageData { get; }

        /// <summary>
        /// Get a message &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="id">The message id</param>
        void GetChatMessage(string id);

        List<ChatBlacklistResource> GetChatMessageBlacklistData { get; }

        /// <summary>
        /// Get a list of blocked users for chat messaging &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="id">The user id or &#39;me&#39;</param>
        void GetChatMessageBlacklist(string id);

        PageResourceChatUserThreadResource GetChatThreadsData { get; }

        /// <summary>
        /// List your threads &lt;b&gt;Permissions Needed:&lt;/b&gt; owner
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetChatThreads(int? size, int? page, string order);

        PageResourceChatMessageResource GetDirectMessagesData { get; }

        /// <summary>
        /// List messages with a user &lt;b&gt;Permissions Needed:&lt;/b&gt; owner
        /// </summary>
        /// <param name="id">The user id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetDirectMessages(int? id, int? size, int? page, string order);

        PageResourceChatMessageResource GetThreadMessagesData { get; }

        /// <summary>
        /// List messages in a thread &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="id">The thread id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetThreadMessages(string id, int? size, int? page, string order);

        PageResourceChatMessageResource GetTopicMessagesData { get; }

        /// <summary>
        /// List messages in a topic &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="id">The topic id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetTopicMessages(string id, int? size, int? page, string order);

        

        /// <summary>
        /// Remove a user from a blacklist &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="blacklistedUserId">The user id to blacklist</param>
        /// <param name="id">The user id or &#39;me&#39;</param>
        void RemoveChatBlacklist(int? blacklistedUserId, string id);

        ChatMessageResource SendMessageData { get; }

        /// <summary>
        /// Send a message &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="chatMessageResource">The chat message resource</param>
        void SendMessage(ChatMessageResource chatMessageResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ChatApi : IChatApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAcknowledgeChatMessageResponseContext;
        private DateTime mAcknowledgeChatMessageStartTime;
        private readonly KnetikResponseContext mAddChatMessageBlacklistResponseContext;
        private DateTime mAddChatMessageBlacklistStartTime;
        private readonly KnetikResponseContext mDeleteChatMessageResponseContext;
        private DateTime mDeleteChatMessageStartTime;
        private readonly KnetikResponseContext mEditChatMessageResponseContext;
        private DateTime mEditChatMessageStartTime;
        private readonly KnetikResponseContext mGetChatMessageResponseContext;
        private DateTime mGetChatMessageStartTime;
        private readonly KnetikResponseContext mGetChatMessageBlacklistResponseContext;
        private DateTime mGetChatMessageBlacklistStartTime;
        private readonly KnetikResponseContext mGetChatThreadsResponseContext;
        private DateTime mGetChatThreadsStartTime;
        private readonly KnetikResponseContext mGetDirectMessagesResponseContext;
        private DateTime mGetDirectMessagesStartTime;
        private readonly KnetikResponseContext mGetThreadMessagesResponseContext;
        private DateTime mGetThreadMessagesStartTime;
        private readonly KnetikResponseContext mGetTopicMessagesResponseContext;
        private DateTime mGetTopicMessagesStartTime;
        private readonly KnetikResponseContext mRemoveChatBlacklistResponseContext;
        private DateTime mRemoveChatBlacklistStartTime;
        private readonly KnetikResponseContext mSendMessageResponseContext;
        private DateTime mSendMessageStartTime;

        public delegate void AcknowledgeChatMessageCompleteDelegate(long responseCode);
        public AcknowledgeChatMessageCompleteDelegate AcknowledgeChatMessageComplete;

        public delegate void AddChatMessageBlacklistCompleteDelegate(long responseCode);
        public AddChatMessageBlacklistCompleteDelegate AddChatMessageBlacklistComplete;

        public delegate void DeleteChatMessageCompleteDelegate(long responseCode);
        public DeleteChatMessageCompleteDelegate DeleteChatMessageComplete;

        public delegate void EditChatMessageCompleteDelegate(long responseCode);
        public EditChatMessageCompleteDelegate EditChatMessageComplete;

        public ChatMessageResource GetChatMessageData { get; private set; }
        public delegate void GetChatMessageCompleteDelegate(long responseCode, ChatMessageResource response);
        public GetChatMessageCompleteDelegate GetChatMessageComplete;

        public List<ChatBlacklistResource> GetChatMessageBlacklistData { get; private set; }
        public delegate void GetChatMessageBlacklistCompleteDelegate(long responseCode, List<ChatBlacklistResource> response);
        public GetChatMessageBlacklistCompleteDelegate GetChatMessageBlacklistComplete;

        public PageResourceChatUserThreadResource GetChatThreadsData { get; private set; }
        public delegate void GetChatThreadsCompleteDelegate(long responseCode, PageResourceChatUserThreadResource response);
        public GetChatThreadsCompleteDelegate GetChatThreadsComplete;

        public PageResourceChatMessageResource GetDirectMessagesData { get; private set; }
        public delegate void GetDirectMessagesCompleteDelegate(long responseCode, PageResourceChatMessageResource response);
        public GetDirectMessagesCompleteDelegate GetDirectMessagesComplete;

        public PageResourceChatMessageResource GetThreadMessagesData { get; private set; }
        public delegate void GetThreadMessagesCompleteDelegate(long responseCode, PageResourceChatMessageResource response);
        public GetThreadMessagesCompleteDelegate GetThreadMessagesComplete;

        public PageResourceChatMessageResource GetTopicMessagesData { get; private set; }
        public delegate void GetTopicMessagesCompleteDelegate(long responseCode, PageResourceChatMessageResource response);
        public GetTopicMessagesCompleteDelegate GetTopicMessagesComplete;

        public delegate void RemoveChatBlacklistCompleteDelegate(long responseCode);
        public RemoveChatBlacklistCompleteDelegate RemoveChatBlacklistComplete;

        public ChatMessageResource SendMessageData { get; private set; }
        public delegate void SendMessageCompleteDelegate(long responseCode, ChatMessageResource response);
        public SendMessageCompleteDelegate SendMessageComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ChatApi()
        {
            mAcknowledgeChatMessageResponseContext = new KnetikResponseContext();
            mAcknowledgeChatMessageResponseContext.ResponseReceived += OnAcknowledgeChatMessageResponse;
            mAddChatMessageBlacklistResponseContext = new KnetikResponseContext();
            mAddChatMessageBlacklistResponseContext.ResponseReceived += OnAddChatMessageBlacklistResponse;
            mDeleteChatMessageResponseContext = new KnetikResponseContext();
            mDeleteChatMessageResponseContext.ResponseReceived += OnDeleteChatMessageResponse;
            mEditChatMessageResponseContext = new KnetikResponseContext();
            mEditChatMessageResponseContext.ResponseReceived += OnEditChatMessageResponse;
            mGetChatMessageResponseContext = new KnetikResponseContext();
            mGetChatMessageResponseContext.ResponseReceived += OnGetChatMessageResponse;
            mGetChatMessageBlacklistResponseContext = new KnetikResponseContext();
            mGetChatMessageBlacklistResponseContext.ResponseReceived += OnGetChatMessageBlacklistResponse;
            mGetChatThreadsResponseContext = new KnetikResponseContext();
            mGetChatThreadsResponseContext.ResponseReceived += OnGetChatThreadsResponse;
            mGetDirectMessagesResponseContext = new KnetikResponseContext();
            mGetDirectMessagesResponseContext.ResponseReceived += OnGetDirectMessagesResponse;
            mGetThreadMessagesResponseContext = new KnetikResponseContext();
            mGetThreadMessagesResponseContext.ResponseReceived += OnGetThreadMessagesResponse;
            mGetTopicMessagesResponseContext = new KnetikResponseContext();
            mGetTopicMessagesResponseContext.ResponseReceived += OnGetTopicMessagesResponse;
            mRemoveChatBlacklistResponseContext = new KnetikResponseContext();
            mRemoveChatBlacklistResponseContext.ResponseReceived += OnRemoveChatBlacklistResponse;
            mSendMessageResponseContext = new KnetikResponseContext();
            mSendMessageResponseContext.ResponseReceived += OnSendMessageResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Acknowledge number of messages in a thread &lt;b&gt;Permissions Needed:&lt;/b&gt; owner
        /// </summary>
        /// <param name="id">The thread id</param>
        /// <param name="readCount">The amount of messages read</param>
        public void AcknowledgeChatMessage(string id, int? readCount)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AcknowledgeChatMessage");
            }
            
            mWebCallEvent.WebPath = "/chat/threads/{id}/acknowledge";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(readCount); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAcknowledgeChatMessageStartTime = DateTime.Now;
            mWebCallEvent.Context = mAcknowledgeChatMessageResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mAcknowledgeChatMessageStartTime, "AcknowledgeChatMessage", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAcknowledgeChatMessageResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AcknowledgeChatMessage: " + response.Error);
            }

            KnetikLogger.LogResponse(mAcknowledgeChatMessageStartTime, "AcknowledgeChatMessage", "Response received successfully.");
            if (AcknowledgeChatMessageComplete != null)
            {
                AcknowledgeChatMessageComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Add a user to a chat message blacklist &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="blacklistedUserId">The user id to blacklist</param>
        /// <param name="id">The user id or &#39;me&#39;</param>
        public void AddChatMessageBlacklist(int? blacklistedUserId, string id)
        {
            // verify the required parameter 'blacklistedUserId' is set
            if (blacklistedUserId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'blacklistedUserId' when calling AddChatMessageBlacklist");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddChatMessageBlacklist");
            }
            
            mWebCallEvent.WebPath = "/chat/users/{id}/blacklist/{blacklisted_user_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "blacklisted_user_id" + "}", KnetikClient.ParameterToString(blacklistedUserId));
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
            mAddChatMessageBlacklistStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddChatMessageBlacklistResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddChatMessageBlacklistStartTime, "AddChatMessageBlacklist", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddChatMessageBlacklistResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddChatMessageBlacklist: " + response.Error);
            }

            KnetikLogger.LogResponse(mAddChatMessageBlacklistStartTime, "AddChatMessageBlacklist", "Response received successfully.");
            if (AddChatMessageBlacklistComplete != null)
            {
                AddChatMessageBlacklistComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a message &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="id">The message id</param>
        public void DeleteChatMessage(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteChatMessage");
            }
            
            mWebCallEvent.WebPath = "/chat/messages/{id}";
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
            mDeleteChatMessageStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteChatMessageResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteChatMessageStartTime, "DeleteChatMessage", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteChatMessageResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteChatMessage: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteChatMessageStartTime, "DeleteChatMessage", "Response received successfully.");
            if (DeleteChatMessageComplete != null)
            {
                DeleteChatMessageComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Edit your message &lt;b&gt;Permissions Needed:&lt;/b&gt; owner
        /// </summary>
        /// <param name="id">The message id</param>
        /// <param name="chatMessageResource">The chat message resource</param>
        public void EditChatMessage(string id, ChatMessageResource chatMessageResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling EditChatMessage");
            }
            
            mWebCallEvent.WebPath = "/chat/messages/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(chatMessageResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mEditChatMessageStartTime = DateTime.Now;
            mWebCallEvent.Context = mEditChatMessageResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mEditChatMessageStartTime, "EditChatMessage", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnEditChatMessageResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling EditChatMessage: " + response.Error);
            }

            KnetikLogger.LogResponse(mEditChatMessageStartTime, "EditChatMessage", "Response received successfully.");
            if (EditChatMessageComplete != null)
            {
                EditChatMessageComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a message &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="id">The message id</param>
        public void GetChatMessage(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetChatMessage");
            }
            
            mWebCallEvent.WebPath = "/chat/messages/{id}";
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
            mGetChatMessageStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChatMessageResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChatMessageStartTime, "GetChatMessage", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChatMessageResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChatMessage: " + response.Error);
            }

            GetChatMessageData = (ChatMessageResource) KnetikClient.Deserialize(response.Content, typeof(ChatMessageResource), response.Headers);
            KnetikLogger.LogResponse(mGetChatMessageStartTime, "GetChatMessage", string.Format("Response received successfully:\n{0}", GetChatMessageData));

            if (GetChatMessageComplete != null)
            {
                GetChatMessageComplete(response.ResponseCode, GetChatMessageData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a list of blocked users for chat messaging &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="id">The user id or &#39;me&#39;</param>
        public void GetChatMessageBlacklist(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetChatMessageBlacklist");
            }
            
            mWebCallEvent.WebPath = "/chat/users/{id}/blacklist";
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
            mGetChatMessageBlacklistStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChatMessageBlacklistResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChatMessageBlacklistStartTime, "GetChatMessageBlacklist", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChatMessageBlacklistResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChatMessageBlacklist: " + response.Error);
            }

            GetChatMessageBlacklistData = (List<ChatBlacklistResource>) KnetikClient.Deserialize(response.Content, typeof(List<ChatBlacklistResource>), response.Headers);
            KnetikLogger.LogResponse(mGetChatMessageBlacklistStartTime, "GetChatMessageBlacklist", string.Format("Response received successfully:\n{0}", GetChatMessageBlacklistData));

            if (GetChatMessageBlacklistComplete != null)
            {
                GetChatMessageBlacklistComplete(response.ResponseCode, GetChatMessageBlacklistData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List your threads &lt;b&gt;Permissions Needed:&lt;/b&gt; owner
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetChatThreads(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/chat/threads";
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
            mGetChatThreadsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetChatThreadsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetChatThreadsStartTime, "GetChatThreads", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetChatThreadsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetChatThreads: " + response.Error);
            }

            GetChatThreadsData = (PageResourceChatUserThreadResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceChatUserThreadResource), response.Headers);
            KnetikLogger.LogResponse(mGetChatThreadsStartTime, "GetChatThreads", string.Format("Response received successfully:\n{0}", GetChatThreadsData));

            if (GetChatThreadsComplete != null)
            {
                GetChatThreadsComplete(response.ResponseCode, GetChatThreadsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List messages with a user &lt;b&gt;Permissions Needed:&lt;/b&gt; owner
        /// </summary>
        /// <param name="id">The user id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetDirectMessages(int? id, int? size, int? page, string order)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetDirectMessages");
            }
            
            mWebCallEvent.WebPath = "/chat/users/{id}/messages";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

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
            mGetDirectMessagesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetDirectMessagesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetDirectMessagesStartTime, "GetDirectMessages", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetDirectMessagesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetDirectMessages: " + response.Error);
            }

            GetDirectMessagesData = (PageResourceChatMessageResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceChatMessageResource), response.Headers);
            KnetikLogger.LogResponse(mGetDirectMessagesStartTime, "GetDirectMessages", string.Format("Response received successfully:\n{0}", GetDirectMessagesData));

            if (GetDirectMessagesComplete != null)
            {
                GetDirectMessagesComplete(response.ResponseCode, GetDirectMessagesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List messages in a thread &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="id">The thread id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetThreadMessages(string id, int? size, int? page, string order)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetThreadMessages");
            }
            
            mWebCallEvent.WebPath = "/chat/threads/{id}/messages";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

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
            mGetThreadMessagesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetThreadMessagesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetThreadMessagesStartTime, "GetThreadMessages", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetThreadMessagesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetThreadMessages: " + response.Error);
            }

            GetThreadMessagesData = (PageResourceChatMessageResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceChatMessageResource), response.Headers);
            KnetikLogger.LogResponse(mGetThreadMessagesStartTime, "GetThreadMessages", string.Format("Response received successfully:\n{0}", GetThreadMessagesData));

            if (GetThreadMessagesComplete != null)
            {
                GetThreadMessagesComplete(response.ResponseCode, GetThreadMessagesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List messages in a topic &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="id">The topic id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetTopicMessages(string id, int? size, int? page, string order)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetTopicMessages");
            }
            
            mWebCallEvent.WebPath = "/chat/topics/{id}/messages";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

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
            mGetTopicMessagesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetTopicMessagesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetTopicMessagesStartTime, "GetTopicMessages", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetTopicMessagesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetTopicMessages: " + response.Error);
            }

            GetTopicMessagesData = (PageResourceChatMessageResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceChatMessageResource), response.Headers);
            KnetikLogger.LogResponse(mGetTopicMessagesStartTime, "GetTopicMessages", string.Format("Response received successfully:\n{0}", GetTopicMessagesData));

            if (GetTopicMessagesComplete != null)
            {
                GetTopicMessagesComplete(response.ResponseCode, GetTopicMessagesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Remove a user from a blacklist &lt;b&gt;Permissions Needed:&lt;/b&gt; CHAT_ADMIN or owner
        /// </summary>
        /// <param name="blacklistedUserId">The user id to blacklist</param>
        /// <param name="id">The user id or &#39;me&#39;</param>
        public void RemoveChatBlacklist(int? blacklistedUserId, string id)
        {
            // verify the required parameter 'blacklistedUserId' is set
            if (blacklistedUserId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'blacklistedUserId' when calling RemoveChatBlacklist");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling RemoveChatBlacklist");
            }
            
            mWebCallEvent.WebPath = "/chat/users/{id}/blacklist/{blacklisted_user_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "blacklisted_user_id" + "}", KnetikClient.ParameterToString(blacklistedUserId));
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
            mRemoveChatBlacklistStartTime = DateTime.Now;
            mWebCallEvent.Context = mRemoveChatBlacklistResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mRemoveChatBlacklistStartTime, "RemoveChatBlacklist", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnRemoveChatBlacklistResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling RemoveChatBlacklist: " + response.Error);
            }

            KnetikLogger.LogResponse(mRemoveChatBlacklistStartTime, "RemoveChatBlacklist", "Response received successfully.");
            if (RemoveChatBlacklistComplete != null)
            {
                RemoveChatBlacklistComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a message &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="chatMessageResource">The chat message resource</param>
        public void SendMessage(ChatMessageResource chatMessageResource)
        {
            
            mWebCallEvent.WebPath = "/chat/messages";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(chatMessageResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendMessageStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendMessageResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendMessageStartTime, "SendMessage", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendMessageResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendMessage: " + response.Error);
            }

            SendMessageData = (ChatMessageResource) KnetikClient.Deserialize(response.Content, typeof(ChatMessageResource), response.Headers);
            KnetikLogger.LogResponse(mSendMessageStartTime, "SendMessage", string.Format("Response received successfully:\n{0}", SendMessageData));

            if (SendMessageComplete != null)
            {
                SendMessageComplete(response.ResponseCode, SendMessageData);
            }
        }

    }
}
