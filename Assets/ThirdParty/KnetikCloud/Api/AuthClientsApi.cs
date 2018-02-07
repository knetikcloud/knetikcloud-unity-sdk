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
    public interface IAuthClientsApi
    {
        ClientResource CreateClientData { get; }

        /// <summary>
        /// Create a new client 
        /// </summary>
        /// <param name="clientResource">The client resource object</param>
        void CreateClient(ClientResource clientResource);

        

        /// <summary>
        /// Delete a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        void DeleteClient(string clientKey);

        ClientResource GetClientData { get; }

        /// <summary>
        /// Get a single client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        void GetClient(string clientKey);

        List<GrantTypeResource> GetClientGrantTypesData { get; }

        /// <summary>
        /// List available client grant types 
        /// </summary>
        void GetClientGrantTypes();

        PageResourceClientResource GetClientsData { get; }

        /// <summary>
        /// List and search clients 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetClients(int? size, int? page, string order);

        

        /// <summary>
        /// Set grant types for a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        /// <param name="grantList">A list of unique grant types</param>
        void SetClientGrantTypes(string clientKey, List<string> grantList);

        

        /// <summary>
        /// Set redirect uris for a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        /// <param name="redirectList">A list of unique redirect uris</param>
        void SetClientRedirectUris(string clientKey, List<string> redirectList);

        ClientResource UpdateClientData { get; }

        /// <summary>
        /// Update a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        /// <param name="clientResource">The client resource object</param>
        void UpdateClient(string clientKey, ClientResource clientResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthClientsApi : IAuthClientsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateClientResponseContext;
        private DateTime mCreateClientStartTime;
        private readonly KnetikResponseContext mDeleteClientResponseContext;
        private DateTime mDeleteClientStartTime;
        private readonly KnetikResponseContext mGetClientResponseContext;
        private DateTime mGetClientStartTime;
        private readonly KnetikResponseContext mGetClientGrantTypesResponseContext;
        private DateTime mGetClientGrantTypesStartTime;
        private readonly KnetikResponseContext mGetClientsResponseContext;
        private DateTime mGetClientsStartTime;
        private readonly KnetikResponseContext mSetClientGrantTypesResponseContext;
        private DateTime mSetClientGrantTypesStartTime;
        private readonly KnetikResponseContext mSetClientRedirectUrisResponseContext;
        private DateTime mSetClientRedirectUrisStartTime;
        private readonly KnetikResponseContext mUpdateClientResponseContext;
        private DateTime mUpdateClientStartTime;

        public ClientResource CreateClientData { get; private set; }
        public delegate void CreateClientCompleteDelegate(long responseCode, ClientResource response);
        public CreateClientCompleteDelegate CreateClientComplete;

        public delegate void DeleteClientCompleteDelegate(long responseCode);
        public DeleteClientCompleteDelegate DeleteClientComplete;

        public ClientResource GetClientData { get; private set; }
        public delegate void GetClientCompleteDelegate(long responseCode, ClientResource response);
        public GetClientCompleteDelegate GetClientComplete;

        public List<GrantTypeResource> GetClientGrantTypesData { get; private set; }
        public delegate void GetClientGrantTypesCompleteDelegate(long responseCode, List<GrantTypeResource> response);
        public GetClientGrantTypesCompleteDelegate GetClientGrantTypesComplete;

        public PageResourceClientResource GetClientsData { get; private set; }
        public delegate void GetClientsCompleteDelegate(long responseCode, PageResourceClientResource response);
        public GetClientsCompleteDelegate GetClientsComplete;

        public delegate void SetClientGrantTypesCompleteDelegate(long responseCode);
        public SetClientGrantTypesCompleteDelegate SetClientGrantTypesComplete;

        public delegate void SetClientRedirectUrisCompleteDelegate(long responseCode);
        public SetClientRedirectUrisCompleteDelegate SetClientRedirectUrisComplete;

        public ClientResource UpdateClientData { get; private set; }
        public delegate void UpdateClientCompleteDelegate(long responseCode, ClientResource response);
        public UpdateClientCompleteDelegate UpdateClientComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthClientsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthClientsApi()
        {
            mCreateClientResponseContext = new KnetikResponseContext();
            mCreateClientResponseContext.ResponseReceived += OnCreateClientResponse;
            mDeleteClientResponseContext = new KnetikResponseContext();
            mDeleteClientResponseContext.ResponseReceived += OnDeleteClientResponse;
            mGetClientResponseContext = new KnetikResponseContext();
            mGetClientResponseContext.ResponseReceived += OnGetClientResponse;
            mGetClientGrantTypesResponseContext = new KnetikResponseContext();
            mGetClientGrantTypesResponseContext.ResponseReceived += OnGetClientGrantTypesResponse;
            mGetClientsResponseContext = new KnetikResponseContext();
            mGetClientsResponseContext.ResponseReceived += OnGetClientsResponse;
            mSetClientGrantTypesResponseContext = new KnetikResponseContext();
            mSetClientGrantTypesResponseContext.ResponseReceived += OnSetClientGrantTypesResponse;
            mSetClientRedirectUrisResponseContext = new KnetikResponseContext();
            mSetClientRedirectUrisResponseContext.ResponseReceived += OnSetClientRedirectUrisResponse;
            mUpdateClientResponseContext = new KnetikResponseContext();
            mUpdateClientResponseContext.ResponseReceived += OnUpdateClientResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a new client 
        /// </summary>
        /// <param name="clientResource">The client resource object</param>
        public void CreateClient(ClientResource clientResource)
        {
            
            mWebCallEvent.WebPath = "/auth/clients";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(clientResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateClientStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateClientResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateClientStartTime, "CreateClient", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateClientResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateClient: " + response.Error);
            }

            CreateClientData = (ClientResource) KnetikClient.Deserialize(response.Content, typeof(ClientResource), response.Headers);
            KnetikLogger.LogResponse(mCreateClientStartTime, "CreateClient", string.Format("Response received successfully:\n{0}", CreateClientData));

            if (CreateClientComplete != null)
            {
                CreateClientComplete(response.ResponseCode, CreateClientData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        public void DeleteClient(string clientKey)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling DeleteClient");
            }
            
            mWebCallEvent.WebPath = "/auth/clients/{client_key}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteClientStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteClientResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteClientStartTime, "DeleteClient", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteClientResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteClient: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteClientStartTime, "DeleteClient", "Response received successfully.");
            if (DeleteClientComplete != null)
            {
                DeleteClientComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        public void GetClient(string clientKey)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling GetClient");
            }
            
            mWebCallEvent.WebPath = "/auth/clients/{client_key}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetClientStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetClientResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetClientStartTime, "GetClient", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetClientResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetClient: " + response.Error);
            }

            GetClientData = (ClientResource) KnetikClient.Deserialize(response.Content, typeof(ClientResource), response.Headers);
            KnetikLogger.LogResponse(mGetClientStartTime, "GetClient", string.Format("Response received successfully:\n{0}", GetClientData));

            if (GetClientComplete != null)
            {
                GetClientComplete(response.ResponseCode, GetClientData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List available client grant types 
        /// </summary>
        public void GetClientGrantTypes()
        {
            
            mWebCallEvent.WebPath = "/auth/clients/grant-types";
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
            mGetClientGrantTypesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetClientGrantTypesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetClientGrantTypesStartTime, "GetClientGrantTypes", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetClientGrantTypesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetClientGrantTypes: " + response.Error);
            }

            GetClientGrantTypesData = (List<GrantTypeResource>) KnetikClient.Deserialize(response.Content, typeof(List<GrantTypeResource>), response.Headers);
            KnetikLogger.LogResponse(mGetClientGrantTypesStartTime, "GetClientGrantTypes", string.Format("Response received successfully:\n{0}", GetClientGrantTypesData));

            if (GetClientGrantTypesComplete != null)
            {
                GetClientGrantTypesComplete(response.ResponseCode, GetClientGrantTypesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search clients 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetClients(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/auth/clients";
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
            mGetClientsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetClientsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetClientsStartTime, "GetClients", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetClientsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetClients: " + response.Error);
            }

            GetClientsData = (PageResourceClientResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceClientResource), response.Headers);
            KnetikLogger.LogResponse(mGetClientsStartTime, "GetClients", string.Format("Response received successfully:\n{0}", GetClientsData));

            if (GetClientsComplete != null)
            {
                GetClientsComplete(response.ResponseCode, GetClientsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set grant types for a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        /// <param name="grantList">A list of unique grant types</param>
        public void SetClientGrantTypes(string clientKey, List<string> grantList)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling SetClientGrantTypes");
            }
            
            mWebCallEvent.WebPath = "/auth/clients/{client_key}/grant-types";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(grantList); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetClientGrantTypesStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetClientGrantTypesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetClientGrantTypesStartTime, "SetClientGrantTypes", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetClientGrantTypesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetClientGrantTypes: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetClientGrantTypesStartTime, "SetClientGrantTypes", "Response received successfully.");
            if (SetClientGrantTypesComplete != null)
            {
                SetClientGrantTypesComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Set redirect uris for a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        /// <param name="redirectList">A list of unique redirect uris</param>
        public void SetClientRedirectUris(string clientKey, List<string> redirectList)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling SetClientRedirectUris");
            }
            
            mWebCallEvent.WebPath = "/auth/clients/{client_key}/redirect-uris";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(redirectList); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSetClientRedirectUrisStartTime = DateTime.Now;
            mWebCallEvent.Context = mSetClientRedirectUrisResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mSetClientRedirectUrisStartTime, "SetClientRedirectUris", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSetClientRedirectUrisResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SetClientRedirectUris: " + response.Error);
            }

            KnetikLogger.LogResponse(mSetClientRedirectUrisStartTime, "SetClientRedirectUris", "Response received successfully.");
            if (SetClientRedirectUrisComplete != null)
            {
                SetClientRedirectUrisComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        /// <param name="clientResource">The client resource object</param>
        public void UpdateClient(string clientKey, ClientResource clientResource)
        {
            // verify the required parameter 'clientKey' is set
            if (clientKey == null)
            {
                throw new KnetikException(400, "Missing required parameter 'clientKey' when calling UpdateClient");
            }
            
            mWebCallEvent.WebPath = "/auth/clients/{client_key}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "client_key" + "}", KnetikClient.ParameterToString(clientKey));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(clientResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateClientStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateClientResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateClientStartTime, "UpdateClient", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateClientResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateClient: " + response.Error);
            }

            UpdateClientData = (ClientResource) KnetikClient.Deserialize(response.Content, typeof(ClientResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateClientStartTime, "UpdateClient", string.Format("Response received successfully:\n{0}", UpdateClientData));

            if (UpdateClientComplete != null)
            {
                UpdateClientComplete(response.ResponseCode, UpdateClientData);
            }
        }

    }
}
