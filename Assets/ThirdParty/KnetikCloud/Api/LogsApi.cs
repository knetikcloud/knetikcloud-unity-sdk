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
    public interface ILogsApi
    {
        BreEventLog GetBREEventLogData { get; }

        PageResourceBreEventLog GetBREEventLogsData { get; }

        ForwardLog GetBREForwardLogData { get; }

        PageResourceForwardLog GetBREForwardLogsData { get; }

        UserActionLog GetUserLogData { get; }

        PageResourceUserActionLog GetUserLogsData { get; }

        
        /// <summary>
        /// Add a user log entry 
        /// </summary>
        /// <param name="logEntry">The user log entry to be added</param>
        void AddUserLog(UserActionLog logEntry);

        /// <summary>
        /// Get an existing BRE event log entry by id 
        /// </summary>
        /// <param name="id">The BRE event log entry id</param>
        void GetBREEventLog(string id);

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

        /// <summary>
        /// Get an existing forward log entry by id 
        /// </summary>
        /// <param name="id">The forward log entry id</param>
        void GetBREForwardLog(string id);

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

        /// <summary>
        /// Returns a user log entry by id 
        /// </summary>
        /// <param name="id">The user log entry id</param>
        void GetUserLog(string id);

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
        private readonly KnetikCoroutine mAddUserLogCoroutine;
        private DateTime mAddUserLogStartTime;
        private string mAddUserLogPath;
        private readonly KnetikCoroutine mGetBREEventLogCoroutine;
        private DateTime mGetBREEventLogStartTime;
        private string mGetBREEventLogPath;
        private readonly KnetikCoroutine mGetBREEventLogsCoroutine;
        private DateTime mGetBREEventLogsStartTime;
        private string mGetBREEventLogsPath;
        private readonly KnetikCoroutine mGetBREForwardLogCoroutine;
        private DateTime mGetBREForwardLogStartTime;
        private string mGetBREForwardLogPath;
        private readonly KnetikCoroutine mGetBREForwardLogsCoroutine;
        private DateTime mGetBREForwardLogsStartTime;
        private string mGetBREForwardLogsPath;
        private readonly KnetikCoroutine mGetUserLogCoroutine;
        private DateTime mGetUserLogStartTime;
        private string mGetUserLogPath;
        private readonly KnetikCoroutine mGetUserLogsCoroutine;
        private DateTime mGetUserLogsStartTime;
        private string mGetUserLogsPath;

        public delegate void AddUserLogCompleteDelegate();
        public AddUserLogCompleteDelegate AddUserLogComplete;

        public BreEventLog GetBREEventLogData { get; private set; }
        public delegate void GetBREEventLogCompleteDelegate(BreEventLog response);
        public GetBREEventLogCompleteDelegate GetBREEventLogComplete;

        public PageResourceBreEventLog GetBREEventLogsData { get; private set; }
        public delegate void GetBREEventLogsCompleteDelegate(PageResourceBreEventLog response);
        public GetBREEventLogsCompleteDelegate GetBREEventLogsComplete;

        public ForwardLog GetBREForwardLogData { get; private set; }
        public delegate void GetBREForwardLogCompleteDelegate(ForwardLog response);
        public GetBREForwardLogCompleteDelegate GetBREForwardLogComplete;

        public PageResourceForwardLog GetBREForwardLogsData { get; private set; }
        public delegate void GetBREForwardLogsCompleteDelegate(PageResourceForwardLog response);
        public GetBREForwardLogsCompleteDelegate GetBREForwardLogsComplete;

        public UserActionLog GetUserLogData { get; private set; }
        public delegate void GetUserLogCompleteDelegate(UserActionLog response);
        public GetUserLogCompleteDelegate GetUserLogComplete;

        public PageResourceUserActionLog GetUserLogsData { get; private set; }
        public delegate void GetUserLogsCompleteDelegate(PageResourceUserActionLog response);
        public GetUserLogsCompleteDelegate GetUserLogsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public LogsApi()
        {
            mAddUserLogCoroutine = new KnetikCoroutine();
            mGetBREEventLogCoroutine = new KnetikCoroutine();
            mGetBREEventLogsCoroutine = new KnetikCoroutine();
            mGetBREForwardLogCoroutine = new KnetikCoroutine();
            mGetBREForwardLogsCoroutine = new KnetikCoroutine();
            mGetUserLogCoroutine = new KnetikCoroutine();
            mGetUserLogsCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a user log entry 
        /// </summary>
        /// <param name="logEntry">The user log entry to be added</param>
        public void AddUserLog(UserActionLog logEntry)
        {
            
            mAddUserLogPath = "/audit/logs";
            if (!string.IsNullOrEmpty(mAddUserLogPath))
            {
                mAddUserLogPath = mAddUserLogPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(logEntry); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddUserLogStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddUserLogStartTime, mAddUserLogPath, "Sending server request...");

            // make the HTTP request
            mAddUserLogCoroutine.ResponseReceived += AddUserLogCallback;
            mAddUserLogCoroutine.Start(mAddUserLogPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddUserLogCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddUserLog: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddUserLog: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mAddUserLogStartTime, mAddUserLogPath, "Response received successfully.");
            if (AddUserLogComplete != null)
            {
                AddUserLogComplete();
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
            
            mGetBREEventLogPath = "/bre/logs/event-log/{id}";
            if (!string.IsNullOrEmpty(mGetBREEventLogPath))
            {
                mGetBREEventLogPath = mGetBREEventLogPath.Replace("{format}", "json");
            }
            mGetBREEventLogPath = mGetBREEventLogPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBREEventLogStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBREEventLogStartTime, mGetBREEventLogPath, "Sending server request...");

            // make the HTTP request
            mGetBREEventLogCoroutine.ResponseReceived += GetBREEventLogCallback;
            mGetBREEventLogCoroutine.Start(mGetBREEventLogPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBREEventLogCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREEventLog: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREEventLog: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBREEventLogData = (BreEventLog) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(BreEventLog), response.Headers);
            KnetikLogger.LogResponse(mGetBREEventLogStartTime, mGetBREEventLogPath, string.Format("Response received successfully:\n{0}", GetBREEventLogData.ToString()));

            if (GetBREEventLogComplete != null)
            {
                GetBREEventLogComplete(GetBREEventLogData);
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
            
            mGetBREEventLogsPath = "/bre/logs/event-log";
            if (!string.IsNullOrEmpty(mGetBREEventLogsPath))
            {
                mGetBREEventLogsPath = mGetBREEventLogsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterStartDate != null)
            {
                queryParams.Add("filter_start_date", KnetikClient.DefaultClient.ParameterToString(filterStartDate));
            }

            if (filterEventName != null)
            {
                queryParams.Add("filter_event_name", KnetikClient.DefaultClient.ParameterToString(filterEventName));
            }

            if (filterEventId != null)
            {
                queryParams.Add("filter_event_id", KnetikClient.DefaultClient.ParameterToString(filterEventId));
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

            mGetBREEventLogsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBREEventLogsStartTime, mGetBREEventLogsPath, "Sending server request...");

            // make the HTTP request
            mGetBREEventLogsCoroutine.ResponseReceived += GetBREEventLogsCallback;
            mGetBREEventLogsCoroutine.Start(mGetBREEventLogsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBREEventLogsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREEventLogs: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREEventLogs: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBREEventLogsData = (PageResourceBreEventLog) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceBreEventLog), response.Headers);
            KnetikLogger.LogResponse(mGetBREEventLogsStartTime, mGetBREEventLogsPath, string.Format("Response received successfully:\n{0}", GetBREEventLogsData.ToString()));

            if (GetBREEventLogsComplete != null)
            {
                GetBREEventLogsComplete(GetBREEventLogsData);
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
            
            mGetBREForwardLogPath = "/bre/logs/forward-log/{id}";
            if (!string.IsNullOrEmpty(mGetBREForwardLogPath))
            {
                mGetBREForwardLogPath = mGetBREForwardLogPath.Replace("{format}", "json");
            }
            mGetBREForwardLogPath = mGetBREForwardLogPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetBREForwardLogStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBREForwardLogStartTime, mGetBREForwardLogPath, "Sending server request...");

            // make the HTTP request
            mGetBREForwardLogCoroutine.ResponseReceived += GetBREForwardLogCallback;
            mGetBREForwardLogCoroutine.Start(mGetBREForwardLogPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBREForwardLogCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREForwardLog: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREForwardLog: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBREForwardLogData = (ForwardLog) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ForwardLog), response.Headers);
            KnetikLogger.LogResponse(mGetBREForwardLogStartTime, mGetBREForwardLogPath, string.Format("Response received successfully:\n{0}", GetBREForwardLogData.ToString()));

            if (GetBREForwardLogComplete != null)
            {
                GetBREForwardLogComplete(GetBREForwardLogData);
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
            
            mGetBREForwardLogsPath = "/bre/logs/forward-log";
            if (!string.IsNullOrEmpty(mGetBREForwardLogsPath))
            {
                mGetBREForwardLogsPath = mGetBREForwardLogsPath.Replace("{format}", "json");
            }
            
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

            if (filterStatusCode != null)
            {
                queryParams.Add("filter_status_code", KnetikClient.DefaultClient.ParameterToString(filterStatusCode));
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

            mGetBREForwardLogsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetBREForwardLogsStartTime, mGetBREForwardLogsPath, "Sending server request...");

            // make the HTTP request
            mGetBREForwardLogsCoroutine.ResponseReceived += GetBREForwardLogsCallback;
            mGetBREForwardLogsCoroutine.Start(mGetBREForwardLogsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetBREForwardLogsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREForwardLogs: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetBREForwardLogs: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetBREForwardLogsData = (PageResourceForwardLog) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceForwardLog), response.Headers);
            KnetikLogger.LogResponse(mGetBREForwardLogsStartTime, mGetBREForwardLogsPath, string.Format("Response received successfully:\n{0}", GetBREForwardLogsData.ToString()));

            if (GetBREForwardLogsComplete != null)
            {
                GetBREForwardLogsComplete(GetBREForwardLogsData);
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
            
            mGetUserLogPath = "/audit/logs/{id}";
            if (!string.IsNullOrEmpty(mGetUserLogPath))
            {
                mGetUserLogPath = mGetUserLogPath.Replace("{format}", "json");
            }
            mGetUserLogPath = mGetUserLogPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserLogStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserLogStartTime, mGetUserLogPath, "Sending server request...");

            // make the HTTP request
            mGetUserLogCoroutine.ResponseReceived += GetUserLogCallback;
            mGetUserLogCoroutine.Start(mGetUserLogPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserLogCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserLog: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserLog: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserLogData = (UserActionLog) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(UserActionLog), response.Headers);
            KnetikLogger.LogResponse(mGetUserLogStartTime, mGetUserLogPath, string.Format("Response received successfully:\n{0}", GetUserLogData.ToString()));

            if (GetUserLogComplete != null)
            {
                GetUserLogComplete(GetUserLogData);
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
            
            mGetUserLogsPath = "/audit/logs";
            if (!string.IsNullOrEmpty(mGetUserLogsPath))
            {
                mGetUserLogsPath = mGetUserLogsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterUser != null)
            {
                queryParams.Add("filter_user", KnetikClient.DefaultClient.ParameterToString(filterUser));
            }

            if (filterActionName != null)
            {
                queryParams.Add("filter_action_name", KnetikClient.DefaultClient.ParameterToString(filterActionName));
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

            mGetUserLogsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserLogsStartTime, mGetUserLogsPath, "Sending server request...");

            // make the HTTP request
            mGetUserLogsCoroutine.ResponseReceived += GetUserLogsCallback;
            mGetUserLogsCoroutine.Start(mGetUserLogsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserLogsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserLogs: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserLogs: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserLogsData = (PageResourceUserActionLog) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceUserActionLog), response.Headers);
            KnetikLogger.LogResponse(mGetUserLogsStartTime, mGetUserLogsPath, string.Format("Response received successfully:\n{0}", GetUserLogsData.ToString()));

            if (GetUserLogsComplete != null)
            {
                GetUserLogsComplete(GetUserLogsData);
            }
        }

    }
}
