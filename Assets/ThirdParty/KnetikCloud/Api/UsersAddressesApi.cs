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
    public interface IUsersAddressesApi
    {
        SavedAddressResource CreateAddressData { get; }

        SavedAddressResource GetAddressData { get; }

        PageResourceSavedAddressResource GetAddressesData { get; }

        SavedAddressResource UpdateAddressData { get; }

        
        /// <summary>
        /// Create a new address 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="savedAddressResource">The new address</param>
        void CreateAddress(string userId, SavedAddressResource savedAddressResource);

        /// <summary>
        /// Delete an address 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the address</param>
        void DeleteAddress(string userId, int? id);

        /// <summary>
        /// Get a single address 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the address</param>
        void GetAddress(string userId, int? id);

        /// <summary>
        /// List and search addresses 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetAddresses(string userId, int? size, int? page, string order);

        /// <summary>
        /// Update an address 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the address</param>
        /// <param name="savedAddressResource">The saved address resource object</param>
        void UpdateAddress(string userId, int? id, SavedAddressResource savedAddressResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UsersAddressesApi : IUsersAddressesApi
    {
        private readonly KnetikCoroutine mCreateAddressCoroutine;
        private DateTime mCreateAddressStartTime;
        private string mCreateAddressPath;
        private readonly KnetikCoroutine mDeleteAddressCoroutine;
        private DateTime mDeleteAddressStartTime;
        private string mDeleteAddressPath;
        private readonly KnetikCoroutine mGetAddressCoroutine;
        private DateTime mGetAddressStartTime;
        private string mGetAddressPath;
        private readonly KnetikCoroutine mGetAddressesCoroutine;
        private DateTime mGetAddressesStartTime;
        private string mGetAddressesPath;
        private readonly KnetikCoroutine mUpdateAddressCoroutine;
        private DateTime mUpdateAddressStartTime;
        private string mUpdateAddressPath;

        public SavedAddressResource CreateAddressData { get; private set; }
        public delegate void CreateAddressCompleteDelegate(SavedAddressResource response);
        public CreateAddressCompleteDelegate CreateAddressComplete;

        public delegate void DeleteAddressCompleteDelegate();
        public DeleteAddressCompleteDelegate DeleteAddressComplete;

        public SavedAddressResource GetAddressData { get; private set; }
        public delegate void GetAddressCompleteDelegate(SavedAddressResource response);
        public GetAddressCompleteDelegate GetAddressComplete;

        public PageResourceSavedAddressResource GetAddressesData { get; private set; }
        public delegate void GetAddressesCompleteDelegate(PageResourceSavedAddressResource response);
        public GetAddressesCompleteDelegate GetAddressesComplete;

        public SavedAddressResource UpdateAddressData { get; private set; }
        public delegate void UpdateAddressCompleteDelegate(SavedAddressResource response);
        public UpdateAddressCompleteDelegate UpdateAddressComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersAddressesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersAddressesApi()
        {
            mCreateAddressCoroutine = new KnetikCoroutine();
            mDeleteAddressCoroutine = new KnetikCoroutine();
            mGetAddressCoroutine = new KnetikCoroutine();
            mGetAddressesCoroutine = new KnetikCoroutine();
            mUpdateAddressCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a new address 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="savedAddressResource">The new address</param>
        public void CreateAddress(string userId, SavedAddressResource savedAddressResource)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling CreateAddress");
            }
            
            mCreateAddressPath = "/users/{user_id}/addresses";
            if (!string.IsNullOrEmpty(mCreateAddressPath))
            {
                mCreateAddressPath = mCreateAddressPath.Replace("{format}", "json");
            }
            mCreateAddressPath = mCreateAddressPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(savedAddressResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateAddressStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateAddressStartTime, mCreateAddressPath, "Sending server request...");

            // make the HTTP request
            mCreateAddressCoroutine.ResponseReceived += CreateAddressCallback;
            mCreateAddressCoroutine.Start(mCreateAddressPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateAddressCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateAddress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateAddress: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateAddressData = (SavedAddressResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(SavedAddressResource), response.Headers);
            KnetikLogger.LogResponse(mCreateAddressStartTime, mCreateAddressPath, string.Format("Response received successfully:\n{0}", CreateAddressData.ToString()));

            if (CreateAddressComplete != null)
            {
                CreateAddressComplete(CreateAddressData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an address 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the address</param>
        public void DeleteAddress(string userId, int? id)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling DeleteAddress");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteAddress");
            }
            
            mDeleteAddressPath = "/users/{user_id}/addresses/{id}";
            if (!string.IsNullOrEmpty(mDeleteAddressPath))
            {
                mDeleteAddressPath = mDeleteAddressPath.Replace("{format}", "json");
            }
            mDeleteAddressPath = mDeleteAddressPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mDeleteAddressPath = mDeleteAddressPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteAddressStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteAddressStartTime, mDeleteAddressPath, "Sending server request...");

            // make the HTTP request
            mDeleteAddressCoroutine.ResponseReceived += DeleteAddressCallback;
            mDeleteAddressCoroutine.Start(mDeleteAddressPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteAddressCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteAddress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteAddress: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteAddressStartTime, mDeleteAddressPath, "Response received successfully.");
            if (DeleteAddressComplete != null)
            {
                DeleteAddressComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single address 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the address</param>
        public void GetAddress(string userId, int? id)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetAddress");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetAddress");
            }
            
            mGetAddressPath = "/users/{user_id}/addresses/{id}";
            if (!string.IsNullOrEmpty(mGetAddressPath))
            {
                mGetAddressPath = mGetAddressPath.Replace("{format}", "json");
            }
            mGetAddressPath = mGetAddressPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mGetAddressPath = mGetAddressPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetAddressStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetAddressStartTime, mGetAddressPath, "Sending server request...");

            // make the HTTP request
            mGetAddressCoroutine.ResponseReceived += GetAddressCallback;
            mGetAddressCoroutine.Start(mGetAddressPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetAddressCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAddress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAddress: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetAddressData = (SavedAddressResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(SavedAddressResource), response.Headers);
            KnetikLogger.LogResponse(mGetAddressStartTime, mGetAddressPath, string.Format("Response received successfully:\n{0}", GetAddressData.ToString()));

            if (GetAddressComplete != null)
            {
                GetAddressComplete(GetAddressData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search addresses 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetAddresses(string userId, int? size, int? page, string order)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetAddresses");
            }
            
            mGetAddressesPath = "/users/{user_id}/addresses";
            if (!string.IsNullOrEmpty(mGetAddressesPath))
            {
                mGetAddressesPath = mGetAddressesPath.Replace("{format}", "json");
            }
            mGetAddressesPath = mGetAddressesPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetAddressesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetAddressesStartTime, mGetAddressesPath, "Sending server request...");

            // make the HTTP request
            mGetAddressesCoroutine.ResponseReceived += GetAddressesCallback;
            mGetAddressesCoroutine.Start(mGetAddressesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetAddressesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAddresses: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetAddresses: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetAddressesData = (PageResourceSavedAddressResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceSavedAddressResource), response.Headers);
            KnetikLogger.LogResponse(mGetAddressesStartTime, mGetAddressesPath, string.Format("Response received successfully:\n{0}", GetAddressesData.ToString()));

            if (GetAddressesComplete != null)
            {
                GetAddressesComplete(GetAddressesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an address 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the address</param>
        /// <param name="savedAddressResource">The saved address resource object</param>
        public void UpdateAddress(string userId, int? id, SavedAddressResource savedAddressResource)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling UpdateAddress");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateAddress");
            }
            
            mUpdateAddressPath = "/users/{user_id}/addresses/{id}";
            if (!string.IsNullOrEmpty(mUpdateAddressPath))
            {
                mUpdateAddressPath = mUpdateAddressPath.Replace("{format}", "json");
            }
            mUpdateAddressPath = mUpdateAddressPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mUpdateAddressPath = mUpdateAddressPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(savedAddressResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateAddressStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateAddressStartTime, mUpdateAddressPath, "Sending server request...");

            // make the HTTP request
            mUpdateAddressCoroutine.ResponseReceived += UpdateAddressCallback;
            mUpdateAddressCoroutine.Start(mUpdateAddressPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateAddressCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateAddress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateAddress: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateAddressData = (SavedAddressResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(SavedAddressResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateAddressStartTime, mUpdateAddressPath, string.Format("Response received successfully:\n{0}", UpdateAddressData.ToString()));

            if (UpdateAddressComplete != null)
            {
                UpdateAddressComplete(UpdateAddressData);
            }
        }

    }
}
