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
    public interface ILogsApi
    {
        

        /// <summary>
        /// Add a user log entry 
        /// </summary>
        /// <param name="logEntry">The user log entry to be added</param>
        void AddUserLog(UserActionLog logEntry);

        BreEventLog GetBREEventLogData { get; }

        /// <summary>
        /// Get an existing BRE event log entry by id 
        /// </summary>
        /// <param name="id">The BRE event log entry id</param>
        void GetBREEventLog(string id);

        PageResourceBreEventLog GetBREEventLogsData { get; }

        /// <summary>
        /// Returns a list of BRE event log entries 
        /// </summary>
        /// <param name="filterStartDate">A comma separated string without spaces.  First value is the operator to search on, second value is the event log start date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterEventName">Filter event logs by event name</param>
        /// <param name="filterEventId">Filter event logs by request id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetBREEventLogs(string filterStartDate, string filterEventName, string filterEventId, int? size, int? page, string order);

        ForwardLog GetBREForwardLogData { get; }

        /// <summary>
        /// Get an existing forward log entry by id 
        /// </summary>
        /// <param name="id">The forward log entry id</param>
        void GetBREForwardLog(string id);

        PageResourceForwardLog GetBREForwardLogsData { get; }

        /// <summary>
        /// Returns a list of forward log entries 
        /// </summary>
        /// <param name="filterStartDate">A comma separated string without spaces.  First value is the operator to search on, second value is the log start date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterEndDate">A comma separated string without spaces.  First value is the operator to search on, second value is the log end date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterStatusCode">Filter forward logs by http status code</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetBREForwardLogs(string filterStartDate, string filterEndDate, int? filterStatusCode, int? size, int? page, string order);

        UserActionLog GetUserLogData { get; }

        /// <summary>
        /// Returns a user log entry by id 
        /// </summary>
        /// <param name="id">The user log entry id</param>
        void GetUserLog(string id);

        PageResourceUserActionLog GetUserLogsData { get; }

        /// <summary>
        /// Returns a page of user logs entries 
        /// </summary>
        /// <param name="filterUser">Filter for actions taken by a specific user by id</param>
        /// <param name="filterActionName">Filter for actions of a specific name</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetUserLogs(int? filterUser, string filterActionName, int? size, int? page, string order);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class LogsApi : ILogsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddUserLogResponseContext;
        private DateTime mAddUserLogStartTime;
        private readonly KnetikResponseContext mGetBREEventLogResponseContext;
        private DateTime mGetBREEventLogStartTime;
        private readonly KnetikResponseContext mGetBREEventLogsResponseContext;
        private DateTime mGetBREEventLogsStartTime;
        private readonly KnetikResponseContext mGetBREForwardLogResponseContext;
        private DateTime mGetBREForwardLogStartTime;
        private readonly KnetikResponseContext mGetBREForwardLogsResponseContext;
        private DateTime mGetBREForwardLogsStartTime;
        private readonly KnetikResponseContext mGetUserLogResponseContext;
        private DateTime mGetUserLogStartTime;
        private readonly KnetikResponseContext mGetUserLogsResponseContext;
        private DateTime mGetUserLogsStartTime;

        public delegate void AddUserLogCompleteDelegate(long responseCode);
        public AddUserLogCompleteDelegate AddUserLogComplete;

        public BreEventLog GetBREEventLogData { get; private set; }
        public delegate void GetBREEventLogCompleteDelegate(long responseCode, BreEventLog response);
        public GetBREEventLogCompleteDelegate GetBREEventLogComplete;

        public PageResourceBreEventLog GetBREEventLogsData { get; private set; }
        public delegate void GetBREEventLogsCompleteDelegate(long responseCode, PageResourceBreEventLog response);
        public GetBREEventLogsCompleteDelegate GetBREEventLogsComplete;

        public ForwardLog GetBREForwardLogData { get; private set; }
        public delegate void GetBREForwardLogCompleteDelegate(long responseCode, ForwardLog response);
        public GetBREForwardLogCompleteDelegate GetBREForwardLogComplete;

        public PageResourceForwardLog GetBREForwardLogsData { get; private set; }
        public delegate void GetBREForwardLogsCompleteDelegate(long responseCode, PageResourceForwardLog response);
        public GetBREForwardLogsCompleteDelegate GetBREForwardLogsComplete;

        public UserActionLog GetUserLogData { get; private set; }
        public delegate void GetUserLogCompleteDelegate(long responseCode, UserActionLog response);
        public GetUserLogCompleteDelegate GetUserLogComplete;

        public PageResourceUserActionLog GetUserLogsData { get; private set; }
        public delegate void GetUserLogsCompleteDelegate(long responseCode, PageResourceUserActionLog response);
        public GetUserLogsCompleteDelegate GetUserLogsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LogsApi()
        {
            mAddUserLogResponseContext = new KnetikResponseContext();
            mAddUserLogResponseContext.ResponseReceived += OnAddUserLogResponse;
            mGetBREEventLogResponseContext = new KnetikResponseContext();
            mGetBREEventLogResponseContext.ResponseReceived += OnGetBREEventLogResponse;
            mGetBREEventLogsResponseContext = new KnetikResponseContext();
            mGetBREEventLogsResponseContext.ResponseReceived += OnGetBREEventLogsResponse;
            mGetBREForwardLogResponseContext = new KnetikResponseContext();
            mGetBREForwardLogResponseContext.ResponseReceived += OnGetBREForwardLogResponse;
            mGetBREForwardLogsResponseContext = new KnetikResponseContext();
            mGetBREForwardLogsResponseContext.ResponseReceived += OnGetBREForwardLogsResponse;
            mGetUserLogResponseContext = new KnetikResponseContext();
            mGetUserLogResponseContext.ResponseReceived += OnGetUserLogResponse;
            mGetUserLogsResponseContext = new KnetikResponseContext();
            mGetUserLogsResponseContext.ResponseReceived += OnGetUserLogsResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a user log entry 
        /// </summary>
        /// <param name="logEntry">The user log entry to be added</param>
        public void AddUserLog(UserActionLog logEntry)
        {
            
            mWebCallEvent.WebPath = "/audit/logs";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(logEntry); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddUserLogStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddUserLogResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddUserLogStartTime, "AddUserLog", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddUserLogResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddUserLog: " + response.Error);
            }

            KnetikLogger.LogResponse(mAddUserLogStartTime, "AddUserLog", "Response received successfully.");
            if (AddUserLogComplete != null)
            {
                AddUserLogComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get an existing BRE event log entry by id 
        /// </summary>
        /// <param name="id">The BRE event log entry id</param>
        public void GetBREEventLog(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBREEventLog");
            }
            
            mWebCallEvent.WebPath = "/bre/logs/event-log/{id}";
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
            mGetBREEventLogStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBREEventLogResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBREEventLogStartTime, "GetBREEventLog", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBREEventLogResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBREEventLog: " + response.Error);
            }

            GetBREEventLogData = (BreEventLog) KnetikClient.Deserialize(response.Content, typeof(BreEventLog), response.Headers);
            KnetikLogger.LogResponse(mGetBREEventLogStartTime, "GetBREEventLog", string.Format("Response received successfully:\n{0}", GetBREEventLogData));

            if (GetBREEventLogComplete != null)
            {
                GetBREEventLogComplete(response.ResponseCode, GetBREEventLogData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a list of BRE event log entries 
        /// </summary>
        /// <param name="filterStartDate">A comma separated string without spaces.  First value is the operator to search on, second value is the event log start date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterEventName">Filter event logs by event name</param>
        /// <param name="filterEventId">Filter event logs by request id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetBREEventLogs(string filterStartDate, string filterEventName, string filterEventId, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/bre/logs/event-log";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterStartDate != null)
            {
                mWebCallEvent.QueryParams["filter_start_date"] = KnetikClient.ParameterToString(filterStartDate);
            }

            if (filterEventName != null)
            {
                mWebCallEvent.QueryParams["filter_event_name"] = KnetikClient.ParameterToString(filterEventName);
            }

            if (filterEventId != null)
            {
                mWebCallEvent.QueryParams["filter_event_id"] = KnetikClient.ParameterToString(filterEventId);
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
            mGetBREEventLogsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBREEventLogsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBREEventLogsStartTime, "GetBREEventLogs", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBREEventLogsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBREEventLogs: " + response.Error);
            }

            GetBREEventLogsData = (PageResourceBreEventLog) KnetikClient.Deserialize(response.Content, typeof(PageResourceBreEventLog), response.Headers);
            KnetikLogger.LogResponse(mGetBREEventLogsStartTime, "GetBREEventLogs", string.Format("Response received successfully:\n{0}", GetBREEventLogsData));

            if (GetBREEventLogsComplete != null)
            {
                GetBREEventLogsComplete(response.ResponseCode, GetBREEventLogsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get an existing forward log entry by id 
        /// </summary>
        /// <param name="id">The forward log entry id</param>
        public void GetBREForwardLog(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetBREForwardLog");
            }
            
            mWebCallEvent.WebPath = "/bre/logs/forward-log/{id}";
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
            mGetBREForwardLogStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBREForwardLogResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBREForwardLogStartTime, "GetBREForwardLog", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBREForwardLogResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBREForwardLog: " + response.Error);
            }

            GetBREForwardLogData = (ForwardLog) KnetikClient.Deserialize(response.Content, typeof(ForwardLog), response.Headers);
            KnetikLogger.LogResponse(mGetBREForwardLogStartTime, "GetBREForwardLog", string.Format("Response received successfully:\n{0}", GetBREForwardLogData));

            if (GetBREForwardLogComplete != null)
            {
                GetBREForwardLogComplete(response.ResponseCode, GetBREForwardLogData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a list of forward log entries 
        /// </summary>
        /// <param name="filterStartDate">A comma separated string without spaces.  First value is the operator to search on, second value is the log start date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterEndDate">A comma separated string without spaces.  First value is the operator to search on, second value is the log end date, a unix timestamp in seconds.  Allowed operators: (GT, LT, EQ, GOE, LOE).</param>
        /// <param name="filterStatusCode">Filter forward logs by http status code</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetBREForwardLogs(string filterStartDate, string filterEndDate, int? filterStatusCode, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/bre/logs/forward-log";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
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

            if (filterStatusCode != null)
            {
                mWebCallEvent.QueryParams["filter_status_code"] = KnetikClient.ParameterToString(filterStatusCode);
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
            mGetBREForwardLogsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetBREForwardLogsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetBREForwardLogsStartTime, "GetBREForwardLogs", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetBREForwardLogsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetBREForwardLogs: " + response.Error);
            }

            GetBREForwardLogsData = (PageResourceForwardLog) KnetikClient.Deserialize(response.Content, typeof(PageResourceForwardLog), response.Headers);
            KnetikLogger.LogResponse(mGetBREForwardLogsStartTime, "GetBREForwardLogs", string.Format("Response received successfully:\n{0}", GetBREForwardLogsData));

            if (GetBREForwardLogsComplete != null)
            {
                GetBREForwardLogsComplete(response.ResponseCode, GetBREForwardLogsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a user log entry by id 
        /// </summary>
        /// <param name="id">The user log entry id</param>
        public void GetUserLog(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetUserLog");
            }
            
            mWebCallEvent.WebPath = "/audit/logs/{id}";
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
            mGetUserLogStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserLogResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserLogStartTime, "GetUserLog", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserLogResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserLog: " + response.Error);
            }

            GetUserLogData = (UserActionLog) KnetikClient.Deserialize(response.Content, typeof(UserActionLog), response.Headers);
            KnetikLogger.LogResponse(mGetUserLogStartTime, "GetUserLog", string.Format("Response received successfully:\n{0}", GetUserLogData));

            if (GetUserLogComplete != null)
            {
                GetUserLogComplete(response.ResponseCode, GetUserLogData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a page of user logs entries 
        /// </summary>
        /// <param name="filterUser">Filter for actions taken by a specific user by id</param>
        /// <param name="filterActionName">Filter for actions of a specific name</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetUserLogs(int? filterUser, string filterActionName, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/audit/logs";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterUser != null)
            {
                mWebCallEvent.QueryParams["filter_user"] = KnetikClient.ParameterToString(filterUser);
            }

            if (filterActionName != null)
            {
                mWebCallEvent.QueryParams["filter_action_name"] = KnetikClient.ParameterToString(filterActionName);
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
            mGetUserLogsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserLogsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserLogsStartTime, "GetUserLogs", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserLogsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserLogs: " + response.Error);
            }

            GetUserLogsData = (PageResourceUserActionLog) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserActionLog), response.Headers);
            KnetikLogger.LogResponse(mGetUserLogsStartTime, "GetUserLogs", string.Format("Response received successfully:\n{0}", GetUserLogsData));

            if (GetUserLogsComplete != null)
            {
                GetUserLogsComplete(response.ResponseCode, GetUserLogsData);
            }
        }

    }
}
