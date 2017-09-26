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
    public interface IUtilMaintenanceApi
    {
        Maintenance GetMaintenanceData { get; }

        
        /// <summary>
        /// Delete maintenance info 
        /// </summary>
        void DeleteMaintenance();

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
        private readonly KnetikCoroutine mDeleteMaintenanceCoroutine;
        private DateTime mDeleteMaintenanceStartTime;
        private string mDeleteMaintenancePath;
        private readonly KnetikCoroutine mGetMaintenanceCoroutine;
        private DateTime mGetMaintenanceStartTime;
        private string mGetMaintenancePath;
        private readonly KnetikCoroutine mSetMaintenanceCoroutine;
        private DateTime mSetMaintenanceStartTime;
        private string mSetMaintenancePath;
        private readonly KnetikCoroutine mUpdateMaintenanceCoroutine;
        private DateTime mUpdateMaintenanceStartTime;
        private string mUpdateMaintenancePath;

        public delegate void DeleteMaintenanceCompleteDelegate();
        public DeleteMaintenanceCompleteDelegate DeleteMaintenanceComplete;

        public Maintenance GetMaintenanceData { get; private set; }
        public delegate void GetMaintenanceCompleteDelegate(Maintenance response);
        public GetMaintenanceCompleteDelegate GetMaintenanceComplete;

        public delegate void SetMaintenanceCompleteDelegate();
        public SetMaintenanceCompleteDelegate SetMaintenanceComplete;

        public delegate void UpdateMaintenanceCompleteDelegate();
        public UpdateMaintenanceCompleteDelegate UpdateMaintenanceComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilMaintenanceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UtilMaintenanceApi()
        {
            mDeleteMaintenanceCoroutine = new KnetikCoroutine();
            mGetMaintenanceCoroutine = new KnetikCoroutine();
            mSetMaintenanceCoroutine = new KnetikCoroutine();
            mUpdateMaintenanceCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Delete maintenance info 
        /// </summary>
        public void DeleteMaintenance()
        {
            
            mDeleteMaintenancePath = "/maintenance";
            if (!string.IsNullOrEmpty(mDeleteMaintenancePath))
            {
                mDeleteMaintenancePath = mDeleteMaintenancePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteMaintenanceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteMaintenanceStartTime, mDeleteMaintenancePath, "Sending server request...");

            // make the HTTP request
            mDeleteMaintenanceCoroutine.ResponseReceived += DeleteMaintenanceCallback;
            mDeleteMaintenanceCoroutine.Start(mDeleteMaintenancePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteMaintenanceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteMaintenance: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteMaintenance: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteMaintenanceStartTime, mDeleteMaintenancePath, "Response received successfully.");
            if (DeleteMaintenanceComplete != null)
            {
                DeleteMaintenanceComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Get current maintenance info Get current maintenance info. 404 if no maintenance.
        /// </summary>
        public void GetMaintenance()
        {
            
            mGetMaintenancePath = "/maintenance";
            if (!string.IsNullOrEmpty(mGetMaintenancePath))
            {
                mGetMaintenancePath = mGetMaintenancePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetMaintenanceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetMaintenanceStartTime, mGetMaintenancePath, "Sending server request...");

            // make the HTTP request
            mGetMaintenanceCoroutine.ResponseReceived += GetMaintenanceCallback;
            mGetMaintenanceCoroutine.Start(mGetMaintenancePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetMaintenanceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetMaintenance: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetMaintenance: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetMaintenanceData = (Maintenance) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(Maintenance), response.Headers);
            KnetikLogger.LogResponse(mGetMaintenanceStartTime, mGetMaintenancePath, string.Format("Response received successfully:\n{0}", GetMaintenanceData.ToString()));

            if (GetMaintenanceComplete != null)
            {
                GetMaintenanceComplete(GetMaintenanceData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Set current maintenance info 
        /// </summary>
        /// <param name="maintenance">The maintenance object</param>
        public void SetMaintenance(Maintenance maintenance)
        {
            
            mSetMaintenancePath = "/maintenance";
            if (!string.IsNullOrEmpty(mSetMaintenancePath))
            {
                mSetMaintenancePath = mSetMaintenancePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(maintenance); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetMaintenanceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetMaintenanceStartTime, mSetMaintenancePath, "Sending server request...");

            // make the HTTP request
            mSetMaintenanceCoroutine.ResponseReceived += SetMaintenanceCallback;
            mSetMaintenanceCoroutine.Start(mSetMaintenancePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetMaintenanceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetMaintenance: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetMaintenance: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetMaintenanceStartTime, mSetMaintenancePath, "Response received successfully.");
            if (SetMaintenanceComplete != null)
            {
                SetMaintenanceComplete();
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Update current maintenance info 
        /// </summary>
        /// <param name="maintenance">The maintenance object</param>
        public void UpdateMaintenance(Maintenance maintenance)
        {
            
            mUpdateMaintenancePath = "/maintenance";
            if (!string.IsNullOrEmpty(mUpdateMaintenancePath))
            {
                mUpdateMaintenancePath = mUpdateMaintenancePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(maintenance); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateMaintenanceStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateMaintenanceStartTime, mUpdateMaintenancePath, "Sending server request...");

            // make the HTTP request
            mUpdateMaintenanceCoroutine.ResponseReceived += UpdateMaintenanceCallback;
            mUpdateMaintenanceCoroutine.Start(mUpdateMaintenancePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateMaintenanceCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateMaintenance: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateMaintenance: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateMaintenanceStartTime, mUpdateMaintenancePath, "Response received successfully.");
            if (UpdateMaintenanceComplete != null)
            {
                UpdateMaintenanceComplete();
            }
        }
    }
}
