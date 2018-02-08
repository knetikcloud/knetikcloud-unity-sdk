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
    public interface IMessagingTopicsApi
    {
        

        /// <summary>
        /// Enable or disable messages for a user Useful for opt-out options on a single topic. Consider multiple topics for multiple opt-out options.
        /// </summary>
        /// <param name="id">The id of the topic</param>
        /// <param name="userId">The id of the subscriber or &#39;me&#39;</param>
        /// <param name="disabled">disabled</param>
        void DisableTopicSubscriber(string id, string userId, ValueWrapperboolean disabled);

        TopicSubscriberResource GetTopicSubscriberData { get; }

        /// <summary>
        /// Get a subscriber to a topic &lt;b&gt;Permissions Needed:&lt;/b&gt; TOPICS_ADMIN
        /// </summary>
        /// <param name="id">The id of the topic</param>
        /// <param name="userId">The id of the subscriber or &#39;me&#39;</param>
        void GetTopicSubscriber(string id, string userId);

        PageResourceTopicSubscriberResource GetTopicSubscribersData { get; }

        /// <summary>
        /// Get all subscribers to a topic &lt;b&gt;Permissions Needed:&lt;/b&gt; TOPICS_ADMIN
        /// </summary>
        /// <param name="id">The id of the topic</param>
        void GetTopicSubscribers(string id);

        PageResourceTopicResource GetUserTopicsData { get; }

        /// <summary>
        /// Get all messaging topics for a given user &lt;b&gt;Permissions Needed:&lt;/b&gt; TOPICS_ADMIN
        /// </summary>
        /// <param name="id">The id of the user or &#39;me&#39;</param>
        void GetUserTopics(string id);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class MessagingTopicsApi : IMessagingTopicsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mDisableTopicSubscriberResponseContext;
        private DateTime mDisableTopicSubscriberStartTime;
        private readonly KnetikResponseContext mGetTopicSubscriberResponseContext;
        private DateTime mGetTopicSubscriberStartTime;
        private readonly KnetikResponseContext mGetTopicSubscribersResponseContext;
        private DateTime mGetTopicSubscribersStartTime;
        private readonly KnetikResponseContext mGetUserTopicsResponseContext;
        private DateTime mGetUserTopicsStartTime;

        public delegate void DisableTopicSubscriberCompleteDelegate(long responseCode);
        public DisableTopicSubscriberCompleteDelegate DisableTopicSubscriberComplete;

        public TopicSubscriberResource GetTopicSubscriberData { get; private set; }
        public delegate void GetTopicSubscriberCompleteDelegate(long responseCode, TopicSubscriberResource response);
        public GetTopicSubscriberCompleteDelegate GetTopicSubscriberComplete;

        public PageResourceTopicSubscriberResource GetTopicSubscribersData { get; private set; }
        public delegate void GetTopicSubscribersCompleteDelegate(long responseCode, PageResourceTopicSubscriberResource response);
        public GetTopicSubscribersCompleteDelegate GetTopicSubscribersComplete;

        public PageResourceTopicResource GetUserTopicsData { get; private set; }
        public delegate void GetUserTopicsCompleteDelegate(long responseCode, PageResourceTopicResource response);
        public GetUserTopicsCompleteDelegate GetUserTopicsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingTopicsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MessagingTopicsApi()
        {
            mDisableTopicSubscriberResponseContext = new KnetikResponseContext();
            mDisableTopicSubscriberResponseContext.ResponseReceived += OnDisableTopicSubscriberResponse;
            mGetTopicSubscriberResponseContext = new KnetikResponseContext();
            mGetTopicSubscriberResponseContext.ResponseReceived += OnGetTopicSubscriberResponse;
            mGetTopicSubscribersResponseContext = new KnetikResponseContext();
            mGetTopicSubscribersResponseContext.ResponseReceived += OnGetTopicSubscribersResponse;
            mGetUserTopicsResponseContext = new KnetikResponseContext();
            mGetUserTopicsResponseContext.ResponseReceived += OnGetUserTopicsResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Enable or disable messages for a user Useful for opt-out options on a single topic. Consider multiple topics for multiple opt-out options.
        /// </summary>
        /// <param name="id">The id of the topic</param>
        /// <param name="userId">The id of the subscriber or &#39;me&#39;</param>
        /// <param name="disabled">disabled</param>
        public void DisableTopicSubscriber(string id, string userId, ValueWrapperboolean disabled)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DisableTopicSubscriber");
            }
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling DisableTopicSubscriber");
            }
            // verify the required parameter 'disabled' is set
            if (disabled == null)
            {
                throw new KnetikException(400, "Missing required parameter 'disabled' when calling DisableTopicSubscriber");
            }
            
            mWebCallEvent.WebPath = "/messaging/topics/{id}/subscribers/{user_id}/disabled";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(disabled); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDisableTopicSubscriberStartTime = DateTime.Now;
            mWebCallEvent.Context = mDisableTopicSubscriberResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mDisableTopicSubscriberStartTime, "DisableTopicSubscriber", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDisableTopicSubscriberResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DisableTopicSubscriber: " + response.Error);
            }

            KnetikLogger.LogResponse(mDisableTopicSubscriberStartTime, "DisableTopicSubscriber", "Response received successfully.");
            if (DisableTopicSubscriberComplete != null)
            {
                DisableTopicSubscriberComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a subscriber to a topic &lt;b&gt;Permissions Needed:&lt;/b&gt; TOPICS_ADMIN
        /// </summary>
        /// <param name="id">The id of the topic</param>
        /// <param name="userId">The id of the subscriber or &#39;me&#39;</param>
        public void GetTopicSubscriber(string id, string userId)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetTopicSubscriber");
            }
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetTopicSubscriber");
            }
            
            mWebCallEvent.WebPath = "/messaging/topics/{id}/subscribers/{user_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetTopicSubscriberStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetTopicSubscriberResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetTopicSubscriberStartTime, "GetTopicSubscriber", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetTopicSubscriberResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetTopicSubscriber: " + response.Error);
            }

            GetTopicSubscriberData = (TopicSubscriberResource) KnetikClient.Deserialize(response.Content, typeof(TopicSubscriberResource), response.Headers);
            KnetikLogger.LogResponse(mGetTopicSubscriberStartTime, "GetTopicSubscriber", string.Format("Response received successfully:\n{0}", GetTopicSubscriberData));

            if (GetTopicSubscriberComplete != null)
            {
                GetTopicSubscriberComplete(response.ResponseCode, GetTopicSubscriberData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get all subscribers to a topic &lt;b&gt;Permissions Needed:&lt;/b&gt; TOPICS_ADMIN
        /// </summary>
        /// <param name="id">The id of the topic</param>
        public void GetTopicSubscribers(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetTopicSubscribers");
            }
            
            mWebCallEvent.WebPath = "/messaging/topics/{id}/subscribers";
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
            mGetTopicSubscribersStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetTopicSubscribersResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetTopicSubscribersStartTime, "GetTopicSubscribers", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetTopicSubscribersResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetTopicSubscribers: " + response.Error);
            }

            GetTopicSubscribersData = (PageResourceTopicSubscriberResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTopicSubscriberResource), response.Headers);
            KnetikLogger.LogResponse(mGetTopicSubscribersStartTime, "GetTopicSubscribers", string.Format("Response received successfully:\n{0}", GetTopicSubscribersData));

            if (GetTopicSubscribersComplete != null)
            {
                GetTopicSubscribersComplete(response.ResponseCode, GetTopicSubscribersData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get all messaging topics for a given user &lt;b&gt;Permissions Needed:&lt;/b&gt; TOPICS_ADMIN
        /// </summary>
        /// <param name="id">The id of the user or &#39;me&#39;</param>
        public void GetUserTopics(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetUserTopics");
            }
            
            mWebCallEvent.WebPath = "/users/{id}/topics";
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
            mGetUserTopicsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserTopicsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserTopicsStartTime, "GetUserTopics", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserTopicsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserTopics: " + response.Error);
            }

            GetUserTopicsData = (PageResourceTopicResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTopicResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserTopicsStartTime, "GetUserTopics", string.Format("Response received successfully:\n{0}", GetUserTopicsData));

            if (GetUserTopicsComplete != null)
            {
                GetUserTopicsComplete(response.ResponseCode, GetUserTopicsData);
            }
        }

    }
}
