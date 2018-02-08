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
    public interface INotificationsApi
    {
        NotificationTypeResource CreateNotificationTypeData { get; }

        /// <summary>
        /// Create a notification type 
        /// </summary>
        /// <param name="notificationType">notificationType</param>
        void CreateNotificationType(NotificationTypeResource notificationType);

        

        /// <summary>
        /// Delete a notification type 
        /// </summary>
        /// <param name="id">id</param>
        void DeleteNotificationType(string id);

        NotificationTypeResource GetNotificationTypeData { get; }

        /// <summary>
        /// Get a single notification type 
        /// </summary>
        /// <param name="id">id</param>
        void GetNotificationType(string id);

        PageResourceNotificationTypeResource GetNotificationTypesData { get; }

        /// <summary>
        /// List and search notification types Get a list of notification type with optional filtering
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetNotificationTypes(int? size, int? page, string order);

        NotificationUserTypeResource GetUserNotificationInfoData { get; }

        /// <summary>
        /// View a user&#39;s notification settings for a type 
        /// </summary>
        /// <param name="typeId">The id of the topic</param>
        /// <param name="userId">The id of the subscriber or &#39;me&#39;</param>
        void GetUserNotificationInfo(string typeId, string userId);

        PageResourceNotificationUserTypeResource GetUserNotificationInfoListData { get; }

        /// <summary>
        /// View a user&#39;s notification settings 
        /// </summary>
        /// <param name="userId">The id of the subscriber or &#39;me&#39;</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetUserNotificationInfoList(string userId, int? size, int? page, string order);

        PageResourceUserNotificationResource GetUserNotificationsData { get; }

        /// <summary>
        /// Get notifications 
        /// </summary>
        /// <param name="id">The id of the user or &#39;me&#39;</param>
        /// <param name="filterStatus">filter for notifications with a given status</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetUserNotifications(string id, string filterStatus, int? size, int? page, string order);

        NotificationResource SendNotificationData { get; }

        /// <summary>
        /// Send a notification 
        /// </summary>
        /// <param name="notification">notification</param>
        void SendNotification(NotificationResource notification);

        

        /// <summary>
        /// Set notification status 
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39;</param>
        /// <param name="notificationId">The id of the notification</param>
        /// <param name="notification">status</param>
        void SetUserNotificationStatus(string userId, string notificationId, ValueWrapperstring notification);

        

        /// <summary>
        /// Enable or disable direct notifications for a user Allows enabling or disabling messages for a given notification type when sent direct to the user. Notifications can still be retrieved by endpoint. For notifications broadcased to a topic, see the topic service to disable messages for the user there.
        /// </summary>
        /// <param name="typeId">The id of the topic</param>
        /// <param name="userId">The id of the subscriber or &#39;me&#39;</param>
        /// <param name="silenced">silenced</param>
        void SilenceDirectNotifications(string typeId, string userId, ValueWrapperboolean silenced);

        NotificationTypeResource UpdateNotificationTypeData { get; }

        /// <summary>
        /// Update a notificationType 
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="notificationType">notificationType</param>
        void UpdateNotificationType(string id, NotificationTypeResource notificationType);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class NotificationsApi : INotificationsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateNotificationTypeResponseContext;
        private DateTime mCreateNotificationTypeStartTime;
        private readonly KnetikResponseContext mDeleteNotificationTypeResponseContext;
        private DateTime mDeleteNotificationTypeStartTime;
        private readonly KnetikResponseContext mGetNotificationTypeResponseContext;
        private DateTime mGetNotificationTypeStartTime;
        private readonly KnetikResponseContext mGetNotificationTypesResponseContext;
        private DateTime mGetNotificationTypesStartTime;
        private readonly KnetikResponseContext mGetUserNotificationInfoResponseContext;
        private DateTime mGetUserNotificationInfoStartTime;
        private readonly KnetikResponseContext mGetUserNotificationInfoListResponseContext;
        private DateTime mGetUserNotificationInfoListStartTime;
        private readonly KnetikResponseContext mGetUserNotificationsResponseContext;
        private DateTime mGetUserNotificationsStartTime;
        private readonly KnetikResponseContext mSendNotificationResponseContext;
        private DateTime mSendNotificationStartTime;
        private readonly KnetikResponseContext mSetUserNotificationStatusResponseContext;
        private DateTime mSetUserNotificationStatusStartTime;
        private readonly KnetikResponseContext mSilenceDirectNotificationsResponseContext;
        private DateTime mSilenceDirectNotificationsStartTime;
        private readonly KnetikResponseContext mUpdateNotificationTypeResponseContext;
        private DateTime mUpdateNotificationTypeStartTime;

        public NotificationTypeResource CreateNotificationTypeData { get; private set; }
        public delegate void CreateNotificationTypeCompleteDelegate(long responseCode, NotificationTypeResource response);
        public CreateNotificationTypeCompleteDelegate CreateNotificationTypeComplete;

        public delegate void DeleteNotificationTypeCompleteDelegate(long responseCode);
        public DeleteNotificationTypeCompleteDelegate DeleteNotificationTypeComplete;

        public NotificationTypeResource GetNotificationTypeData { get; private set; }
        public delegate void GetNotificationTypeCompleteDelegate(long responseCode, NotificationTypeResource response);
        public GetNotificationTypeCompleteDelegate GetNotificationTypeComplete;

        public PageResourceNotificationTypeResource GetNotificationTypesData { get; private set; }
        public delegate void GetNotificationTypesCompleteDelegate(long responseCode, PageResourceNotificationTypeResource response);
        public GetNotificationTypesCompleteDelegate GetNotificationTypesComplete;

        public NotificationUserTypeResource GetUserNotificationInfoData { get; private set; }
        public delegate void GetUserNotificationInfoCompleteDelegate(long responseCode, NotificationUserTypeResource response);
        public GetUserNotificationInfoCompleteDelegate GetUserNotificationInfoComplete;

        public PageResourceNotificationUserTypeResource GetUserNotificationInfoListData { get; private set; }
        public delegate void GetUserNotificationInfoListCompleteDelegate(long responseCode, PageResourceNotificationUserTypeResource response);
        public GetUserNotificationInfoListCompleteDelegate GetUserNotificationInfoListComplete;

        public PageResourceUserNotificationResource GetUserNotificationsData { get; private set; }
        public delegate void GetUserNotificationsCompleteDelegate(long responseCode, PageResourceUserNotificationResource response);
        public GetUserNotificationsCompleteDelegate GetUserNotificationsComplete;

        public NotificationResource SendNotificationData { get; private set; }
        public delegate void SendNotificationCompleteDelegate(long responseCode, NotificationResource response);
        public SendNotificationCompleteDelegate SendNotificationComplete;

        public delegate void SetUserNotificationStatusCompleteDelegate(long responseCode);
        public SetUserNotificationStatusCompleteDelegate SetUserNotificationStatusComplete;

        public delegate void SilenceDirectNotificationsCompleteDelegate(long responseCode);
        public SilenceDirectNotificationsCompleteDelegate SilenceDirectNotificationsComplete;

        public NotificationTypeResource UpdateNotificationTypeData { get; private set; }
        public delegate void UpdateNotificationTypeCompleteDelegate(long responseCode, NotificationTypeResource response);
        public UpdateNotificationTypeCompleteDelegate UpdateNotificationTypeComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public NotificationsApi()
        {
            mCreateNotificationTypeResponseContext = new KnetikResponseContext();
            mCreateNotificationTypeResponseContext.ResponseReceived += OnCreateNotificationTypeResponse;
            mDeleteNotificationTypeResponseContext = new KnetikResponseContext();
            mDeleteNotificationTypeResponseContext.ResponseReceived += OnDeleteNotificationTypeResponse;
            mGetNotificationTypeResponseContext = new KnetikResponseContext();
            mGetNotificationTypeResponseContext.ResponseReceived += OnGetNotificationTypeResponse;
            mGetNotificationTypesResponseContext = new KnetikResponseContext();
            mGetNotificationTypesResponseContext.ResponseReceived += OnGetNotificationTypesResponse;
            mGetUserNotificationInfoResponseContext = new KnetikResponseContext();
            mGetUserNotificationInfoResponseContext.ResponseReceived += OnGetUserNotificationInfoResponse;
            mGetUserNotificationInfoListResponseContext = new KnetikResponseContext();
            mGetUserNotificationInfoListResponseContext.ResponseReceived += OnGetUserNotificationInfoListResponse;
            mGetUserNotificationsResponseContext = new KnetikResponseContext();
            mGetUserNotificationsResponseContext.ResponseReceived += OnGetUserNotificationsResponse;
            mSendNotificationResponseContext = new KnetikResponseContext();
            mSendNotificationResponseContext.ResponseReceived += OnSendNotificationResponse;
            mSetUserNotificationStatusResponseContext = new KnetikResponseContext();
            mSetUserNotificationStatusResponseContext.ResponseReceived += OnSetUserNotificationStatusResponse;
            mSilenceDirectNotificationsResponseContext = new KnetikResponseContext();
            mSilenceDirectNotificationsResponseContext.ResponseReceived += OnSilenceDirectNotificationsResponse;
            mUpdateNotificationTypeResponseContext = new KnetikResponseContext();
            mUpdateNotificationTypeResponseContext.ResponseReceived += OnUpdateNotificationTypeResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a notification type 
        /// </summary>
        /// <param name="notificationType">notificationType</param>
        public void CreateNotificationType(NotificationTypeResource notificationType)
        {
            
            mWebCallEvent.WebPath = "/notifications/types";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(notificationType); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateNotificationTypeStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateNotificationTypeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateNotificationTypeStartTime, "CreateNotificationType", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateNotificationTypeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateNotificationType: " + response.Error);
            }

            CreateNotificationTypeData = (NotificationTypeResource) KnetikClient.Deserialize(response.Content, typeof(NotificationTypeResource), response.Headers);
            KnetikLogger.LogResponse(mCreateNotificationTypeStartTime, "CreateNotificationType", string.Format("Response received successfully:\n{0}", CreateNotificationTypeData));

            if (CreateNotificationTypeComplete != null)
            {
                CreateNotificationTypeComplete(response.ResponseCode, CreateNotificationTypeData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a notification type 
        /// </summary>
        /// <param name="id">id</param>
        public void DeleteNotificationType(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteNotificationType");
            }
            
            mWebCallEvent.WebPath = "/notifications/types/{id}";
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
            mDeleteNotificationTypeStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteNotificationTypeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteNotificationTypeStartTime, "DeleteNotificationType", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteNotificationTypeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteNotificationType: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteNotificationTypeStartTime, "DeleteNotificationType", "Response received successfully.");
            if (DeleteNotificationTypeComplete != null)
            {
                DeleteNotificationTypeComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single notification type 
        /// </summary>
        /// <param name="id">id</param>
        public void GetNotificationType(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetNotificationType");
            }
            
            mWebCallEvent.WebPath = "/notifications/types/{id}";
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
            mGetNotificationTypeStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetNotificationTypeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetNotificationTypeStartTime, "GetNotificationType", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetNotificationTypeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetNotificationType: " + response.Error);
            }

            GetNotificationTypeData = (NotificationTypeResource) KnetikClient.Deserialize(response.Content, typeof(NotificationTypeResource), response.Headers);
            KnetikLogger.LogResponse(mGetNotificationTypeStartTime, "GetNotificationType", string.Format("Response received successfully:\n{0}", GetNotificationTypeData));

            if (GetNotificationTypeComplete != null)
            {
                GetNotificationTypeComplete(response.ResponseCode, GetNotificationTypeData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search notification types Get a list of notification type with optional filtering
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetNotificationTypes(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/notifications/types";
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
            mGetNotificationTypesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetNotificationTypesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetNotificationTypesStartTime, "GetNotificationTypes", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetNotificationTypesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetNotificationTypes: " + response.Error);
            }

            GetNotificationTypesData = (PageResourceNotificationTypeResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceNotificationTypeResource), response.Headers);
            KnetikLogger.LogResponse(mGetNotificationTypesStartTime, "GetNotificationTypes", string.Format("Response received successfully:\n{0}", GetNotificationTypesData));

            if (GetNotificationTypesComplete != null)
            {
                GetNotificationTypesComplete(response.ResponseCode, GetNotificationTypesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// View a user&#39;s notification settings for a type 
        /// </summary>
        /// <param name="typeId">The id of the topic</param>
        /// <param name="userId">The id of the subscriber or &#39;me&#39;</param>
        public void GetUserNotificationInfo(string typeId, string userId)
        {
            // verify the required parameter 'typeId' is set
            if (typeId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'typeId' when calling GetUserNotificationInfo");
            }
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserNotificationInfo");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/notifications/types/{type_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type_id" + "}", KnetikClient.ParameterToString(typeId));
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
            mGetUserNotificationInfoStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserNotificationInfoResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserNotificationInfoStartTime, "GetUserNotificationInfo", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserNotificationInfoResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserNotificationInfo: " + response.Error);
            }

            GetUserNotificationInfoData = (NotificationUserTypeResource) KnetikClient.Deserialize(response.Content, typeof(NotificationUserTypeResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserNotificationInfoStartTime, "GetUserNotificationInfo", string.Format("Response received successfully:\n{0}", GetUserNotificationInfoData));

            if (GetUserNotificationInfoComplete != null)
            {
                GetUserNotificationInfoComplete(response.ResponseCode, GetUserNotificationInfoData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// View a user&#39;s notification settings 
        /// </summary>
        /// <param name="userId">The id of the subscriber or &#39;me&#39;</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetUserNotificationInfoList(string userId, int? size, int? page, string order)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserNotificationInfoList");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/notifications/types";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

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
            mGetUserNotificationInfoListStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserNotificationInfoListResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserNotificationInfoListStartTime, "GetUserNotificationInfoList", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserNotificationInfoListResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserNotificationInfoList: " + response.Error);
            }

            GetUserNotificationInfoListData = (PageResourceNotificationUserTypeResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceNotificationUserTypeResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserNotificationInfoListStartTime, "GetUserNotificationInfoList", string.Format("Response received successfully:\n{0}", GetUserNotificationInfoListData));

            if (GetUserNotificationInfoListComplete != null)
            {
                GetUserNotificationInfoListComplete(response.ResponseCode, GetUserNotificationInfoListData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get notifications 
        /// </summary>
        /// <param name="id">The id of the user or &#39;me&#39;</param>
        /// <param name="filterStatus">filter for notifications with a given status</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetUserNotifications(string id, string filterStatus, int? size, int? page, string order)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetUserNotifications");
            }
            
            mWebCallEvent.WebPath = "/users/{id}/notifications";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterStatus != null)
            {
                mWebCallEvent.QueryParams["filter_status"] = KnetikClient.ParameterToString(filterStatus);
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
            mGetUserNotificationsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserNotificationsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserNotificationsStartTime, "GetUserNotifications", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserNotificationsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserNotifications: " + response.Error);
            }

            GetUserNotificationsData = (PageResourceUserNotificationResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserNotificationResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserNotificationsStartTime, "GetUserNotifications", string.Format("Response received successfully:\n{0}", GetUserNotificationsData));

            if (GetUserNotificationsComplete != null)
            {
                GetUserNotificationsComplete(response.ResponseCode, GetUserNotificationsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Send a notification 
        /// </summary>
        /// <param name="notification">notification</param>
        public void SendNotification(NotificationResource notification)
        {
            
            mWebCallEvent.WebPath = "/notifications";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(notification); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSendNotificationStartTime = DateTime.Now;
            mWebCallEvent.Context = mSendNotificationResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSendNotificationStartTime, "SendNotification", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSendNotificationResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SendNotification: " + response.Error);
            }

            SendNotificationData = (NotificationResource) KnetikClient.Deserialize(response.Content, typeof(NotificationResource), response.Headers);
            KnetikLogger.LogResponse(mSendNotificationStartTime, "SendNotification", string.Format("Response received successfully:\n{0}", SendNotificationData));

            if (SendNotificationComplete != null)
            {
                SendNotificationComplete(response.ResponseCode, SendNotificationData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set notification status 
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39;</param>
        /// <param name="notificationId">The id of the notification</param>
        /// <param name="notification">status</param>
        public void SetUserNotificationStatus(string userId, string notificationId, ValueWrapperstring notification)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling SetUserNotificationStatus");
            }
            // verify the required parameter 'notificationId' is set
            if (notificationId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'notificationId' when calling SetUserNotificationStatus");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/notifications/{notification_id}/status";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "notification_id" + "}", KnetikClient.ParameterToString(notificationId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(notification); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetUserNotificationStatusStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetUserNotificationStatusResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetUserNotificationStatusStartTime, "SetUserNotificationStatus", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetUserNotificationStatusResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetUserNotificationStatus: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetUserNotificationStatusStartTime, "SetUserNotificationStatus", "Response received successfully.");
            if (SetUserNotificationStatusComplete != null)
            {
                SetUserNotificationStatusComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Enable or disable direct notifications for a user Allows enabling or disabling messages for a given notification type when sent direct to the user. Notifications can still be retrieved by endpoint. For notifications broadcased to a topic, see the topic service to disable messages for the user there.
        /// </summary>
        /// <param name="typeId">The id of the topic</param>
        /// <param name="userId">The id of the subscriber or &#39;me&#39;</param>
        /// <param name="silenced">silenced</param>
        public void SilenceDirectNotifications(string typeId, string userId, ValueWrapperboolean silenced)
        {
            // verify the required parameter 'typeId' is set
            if (typeId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'typeId' when calling SilenceDirectNotifications");
            }
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling SilenceDirectNotifications");
            }
            // verify the required parameter 'silenced' is set
            if (silenced == null)
            {
                throw new KnetikException(400, "Missing required parameter 'silenced' when calling SilenceDirectNotifications");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/notifications/types/{type_id}/silenced";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "type_id" + "}", KnetikClient.ParameterToString(typeId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(silenced); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSilenceDirectNotificationsStartTime = DateTime.Now;
            mWebCallEvent.Context = mSilenceDirectNotificationsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSilenceDirectNotificationsStartTime, "SilenceDirectNotifications", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSilenceDirectNotificationsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SilenceDirectNotifications: " + response.Error);
            }

            KnetikLogger.LogResponse(mSilenceDirectNotificationsStartTime, "SilenceDirectNotifications", "Response received successfully.");
            if (SilenceDirectNotificationsComplete != null)
            {
                SilenceDirectNotificationsComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a notificationType 
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="notificationType">notificationType</param>
        public void UpdateNotificationType(string id, NotificationTypeResource notificationType)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateNotificationType");
            }
            
            mWebCallEvent.WebPath = "/notifications/types/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(notificationType); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateNotificationTypeStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateNotificationTypeResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateNotificationTypeStartTime, "UpdateNotificationType", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateNotificationTypeResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateNotificationType: " + response.Error);
            }

            UpdateNotificationTypeData = (NotificationTypeResource) KnetikClient.Deserialize(response.Content, typeof(NotificationTypeResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateNotificationTypeStartTime, "UpdateNotificationType", string.Format("Response received successfully:\n{0}", UpdateNotificationTypeData));

            if (UpdateNotificationTypeComplete != null)
            {
                UpdateNotificationTypeComplete(response.ResponseCode, UpdateNotificationTypeData);
            }
        }

    }
}
