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
    public interface IUsersAddressesApi
    {
        SavedAddressResource CreateAddressData { get; }

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

        SavedAddressResource GetAddressData { get; }

        /// <summary>
        /// Get a single address 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="id">The id of the address</param>
        void GetAddress(string userId, int? id);

        PageResourceSavedAddressResource GetAddressesData { get; }

        /// <summary>
        /// List and search addresses 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetAddresses(string userId, int? size, int? page, string order);

        SavedAddressResource UpdateAddressData { get; }

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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateAddressResponseContext;
        private DateTime mCreateAddressStartTime;
        private readonly KnetikResponseContext mDeleteAddressResponseContext;
        private DateTime mDeleteAddressStartTime;
        private readonly KnetikResponseContext mGetAddressResponseContext;
        private DateTime mGetAddressStartTime;
        private readonly KnetikResponseContext mGetAddressesResponseContext;
        private DateTime mGetAddressesStartTime;
        private readonly KnetikResponseContext mUpdateAddressResponseContext;
        private DateTime mUpdateAddressStartTime;

        public SavedAddressResource CreateAddressData { get; private set; }
        public delegate void CreateAddressCompleteDelegate(long responseCode, SavedAddressResource response);
        public CreateAddressCompleteDelegate CreateAddressComplete;

        public delegate void DeleteAddressCompleteDelegate(long responseCode);
        public DeleteAddressCompleteDelegate DeleteAddressComplete;

        public SavedAddressResource GetAddressData { get; private set; }
        public delegate void GetAddressCompleteDelegate(long responseCode, SavedAddressResource response);
        public GetAddressCompleteDelegate GetAddressComplete;

        public PageResourceSavedAddressResource GetAddressesData { get; private set; }
        public delegate void GetAddressesCompleteDelegate(long responseCode, PageResourceSavedAddressResource response);
        public GetAddressesCompleteDelegate GetAddressesComplete;

        public SavedAddressResource UpdateAddressData { get; private set; }
        public delegate void UpdateAddressCompleteDelegate(long responseCode, SavedAddressResource response);
        public UpdateAddressCompleteDelegate UpdateAddressComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersAddressesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersAddressesApi()
        {
            mCreateAddressResponseContext = new KnetikResponseContext();
            mCreateAddressResponseContext.ResponseReceived += OnCreateAddressResponse;
            mDeleteAddressResponseContext = new KnetikResponseContext();
            mDeleteAddressResponseContext.ResponseReceived += OnDeleteAddressResponse;
            mGetAddressResponseContext = new KnetikResponseContext();
            mGetAddressResponseContext.ResponseReceived += OnGetAddressResponse;
            mGetAddressesResponseContext = new KnetikResponseContext();
            mGetAddressesResponseContext.ResponseReceived += OnGetAddressesResponse;
            mUpdateAddressResponseContext = new KnetikResponseContext();
            mUpdateAddressResponseContext.ResponseReceived += OnUpdateAddressResponse;
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/addresses";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(savedAddressResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateAddressStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateAddressResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateAddressStartTime, "CreateAddress", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateAddressResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateAddress: " + response.Error);
            }

            CreateAddressData = (SavedAddressResource) KnetikClient.Deserialize(response.Content, typeof(SavedAddressResource), response.Headers);
            KnetikLogger.LogResponse(mCreateAddressStartTime, "CreateAddress", string.Format("Response received successfully:\n{0}", CreateAddressData));

            if (CreateAddressComplete != null)
            {
                CreateAddressComplete(response.ResponseCode, CreateAddressData);
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/addresses/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
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
            mDeleteAddressStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteAddressResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteAddressStartTime, "DeleteAddress", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteAddressResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteAddress: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteAddressStartTime, "DeleteAddress", "Response received successfully.");
            if (DeleteAddressComplete != null)
            {
                DeleteAddressComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/addresses/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
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
            mGetAddressStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetAddressResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetAddressStartTime, "GetAddress", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetAddressResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetAddress: " + response.Error);
            }

            GetAddressData = (SavedAddressResource) KnetikClient.Deserialize(response.Content, typeof(SavedAddressResource), response.Headers);
            KnetikLogger.LogResponse(mGetAddressStartTime, "GetAddress", string.Format("Response received successfully:\n{0}", GetAddressData));

            if (GetAddressComplete != null)
            {
                GetAddressComplete(response.ResponseCode, GetAddressData);
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/addresses";
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
            mGetAddressesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetAddressesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetAddressesStartTime, "GetAddresses", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetAddressesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetAddresses: " + response.Error);
            }

            GetAddressesData = (PageResourceSavedAddressResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceSavedAddressResource), response.Headers);
            KnetikLogger.LogResponse(mGetAddressesStartTime, "GetAddresses", string.Format("Response received successfully:\n{0}", GetAddressesData));

            if (GetAddressesComplete != null)
            {
                GetAddressesComplete(response.ResponseCode, GetAddressesData);
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/addresses/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(savedAddressResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateAddressStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateAddressResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateAddressStartTime, "UpdateAddress", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateAddressResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateAddress: " + response.Error);
            }

            UpdateAddressData = (SavedAddressResource) KnetikClient.Deserialize(response.Content, typeof(SavedAddressResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateAddressStartTime, "UpdateAddress", string.Format("Response received successfully:\n{0}", UpdateAddressData));

            if (UpdateAddressComplete != null)
            {
                UpdateAddressComplete(response.ResponseCode, UpdateAddressData);
            }
        }

    }
}
