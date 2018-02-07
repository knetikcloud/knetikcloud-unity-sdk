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
    public interface IUtilMaintenanceApi
    {
        

        /// <summary>
        /// Delete maintenance info 
        /// </summary>
        void DeleteMaintenance();

        Maintenance GetMaintenanceData { get; }

        /// <summary>
        /// Get current maintenance info Get current maintenance info. 404 if no maintenance.
        /// </summary>
        void GetMaintenance();

        

        /// <summary>
        /// Set current maintenance info 
        /// </summary>
        /// <param name="maintenance">The maintenance object</param>
        void SetMaintenance(Maintenance maintenance);

        

        /// <summary>
        /// Update current maintenance info 
        /// </summary>
        /// <param name="maintenance">The maintenance object</param>
        void UpdateMaintenance(Maintenance maintenance);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UtilMaintenanceApi : IUtilMaintenanceApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mDeleteMaintenanceResponseContext;
        private DateTime mDeleteMaintenanceStartTime;
        private readonly KnetikResponseContext mGetMaintenanceResponseContext;
        private DateTime mGetMaintenanceStartTime;
        private readonly KnetikResponseContext mSetMaintenanceResponseContext;
        private DateTime mSetMaintenanceStartTime;
        private readonly KnetikResponseContext mUpdateMaintenanceResponseContext;
        private DateTime mUpdateMaintenanceStartTime;

        public delegate void DeleteMaintenanceCompleteDelegate(long responseCode);
        public DeleteMaintenanceCompleteDelegate DeleteMaintenanceComplete;

        public Maintenance GetMaintenanceData { get; private set; }
        public delegate void GetMaintenanceCompleteDelegate(long responseCode, Maintenance response);
        public GetMaintenanceCompleteDelegate GetMaintenanceComplete;

        public delegate void SetMaintenanceCompleteDelegate(long responseCode);
        public SetMaintenanceCompleteDelegate SetMaintenanceComplete;

        public delegate void UpdateMaintenanceCompleteDelegate(long responseCode);
        public UpdateMaintenanceCompleteDelegate UpdateMaintenanceComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilMaintenanceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UtilMaintenanceApi()
        {
            mDeleteMaintenanceResponseContext = new KnetikResponseContext();
            mDeleteMaintenanceResponseContext.ResponseReceived += OnDeleteMaintenanceResponse;
            mGetMaintenanceResponseContext = new KnetikResponseContext();
            mGetMaintenanceResponseContext.ResponseReceived += OnGetMaintenanceResponse;
            mSetMaintenanceResponseContext = new KnetikResponseContext();
            mSetMaintenanceResponseContext.ResponseReceived += OnSetMaintenanceResponse;
            mUpdateMaintenanceResponseContext = new KnetikResponseContext();
            mUpdateMaintenanceResponseContext.ResponseReceived += OnUpdateMaintenanceResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Delete maintenance info 
        /// </summary>
        public void DeleteMaintenance()
        {
            
            mWebCallEvent.WebPath = "/maintenance";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteMaintenanceStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteMaintenanceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteMaintenanceStartTime, "DeleteMaintenance", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteMaintenanceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteMaintenance: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteMaintenanceStartTime, "DeleteMaintenance", "Response received successfully.");
            if (DeleteMaintenanceComplete != null)
            {
                DeleteMaintenanceComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get current maintenance info Get current maintenance info. 404 if no maintenance.
        /// </summary>
        public void GetMaintenance()
        {
            
            mWebCallEvent.WebPath = "/maintenance";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetMaintenanceStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetMaintenanceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetMaintenanceStartTime, "GetMaintenance", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetMaintenanceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetMaintenance: " + response.Error);
            }

            GetMaintenanceData = (Maintenance) KnetikClient.Deserialize(response.Content, typeof(Maintenance), response.Headers);
            KnetikLogger.LogResponse(mGetMaintenanceStartTime, "GetMaintenance", string.Format("Response received successfully:\n{0}", GetMaintenanceData));

            if (GetMaintenanceComplete != null)
            {
                GetMaintenanceComplete(response.ResponseCode, GetMaintenanceData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set current maintenance info 
        /// </summary>
        /// <param name="maintenance">The maintenance object</param>
        public void SetMaintenance(Maintenance maintenance)
        {
            
            mWebCallEvent.WebPath = "/maintenance";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(maintenance); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetMaintenanceStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetMaintenanceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mSetMaintenanceStartTime, "SetMaintenance", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetMaintenanceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetMaintenance: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetMaintenanceStartTime, "SetMaintenance", "Response received successfully.");
            if (SetMaintenanceComplete != null)
            {
                SetMaintenanceComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update current maintenance info 
        /// </summary>
        /// <param name="maintenance">The maintenance object</param>
        public void UpdateMaintenance(Maintenance maintenance)
        {
            
            mWebCallEvent.WebPath = "/maintenance";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(maintenance); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateMaintenanceStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateMaintenanceResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateMaintenanceStartTime, "UpdateMaintenance", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateMaintenanceResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateMaintenance: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateMaintenanceStartTime, "UpdateMaintenance", "Response received successfully.");
            if (UpdateMaintenanceComplete != null)
            {
                UpdateMaintenanceComplete(response.ResponseCode);
            }
        }

    }
}
