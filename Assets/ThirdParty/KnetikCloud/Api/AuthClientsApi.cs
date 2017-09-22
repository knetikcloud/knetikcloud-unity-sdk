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
    public interface IAuthClientsApi
    {
        ClientResource CreateClientData { get; }

        ClientResource GetClientData { get; }

        List<GrantTypeResource> GetClientGrantTypesData { get; }

        PageResourceClientResource GetClientsData { get; }

        ClientResource UpdateClientData { get; }

        
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

        /// <summary>
        /// Get a single client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        void GetClient(string clientKey);

        /// <summary>
        /// List available client grant types 
        /// </summary>
        void GetClientGrantTypes();

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

        /// <summary>
        /// Update a client 
        /// </summary>
        /// <param name="clientKey">The key of the client</param>
        /// <param name="clientResource">The client resource object</param>
        void UpdateClient(string clientKey, ClientResource clientResource);

    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AuthClientsApi : IAuthClientsApi
    {
        private readonly KnetikCoroutine mCreateClientCoroutine;
        private DateTime mCreateClientStartTime;
        private string mCreateClientPath;
        private readonly KnetikCoroutine mDeleteClientCoroutine;
        private DateTime mDeleteClientStartTime;
        private string mDeleteClientPath;
        private readonly KnetikCoroutine mGetClientCoroutine;
        private DateTime mGetClientStartTime;
        private string mGetClientPath;
        private readonly KnetikCoroutine mGetClientGrantTypesCoroutine;
        private DateTime mGetClientGrantTypesStartTime;
        private string mGetClientGrantTypesPath;
        private readonly KnetikCoroutine mGetClientsCoroutine;
        private DateTime mGetClientsStartTime;
        private string mGetClientsPath;
        private readonly KnetikCoroutine mSetClientGrantTypesCoroutine;
        private DateTime mSetClientGrantTypesStartTime;
        private string mSetClientGrantTypesPath;
        private readonly KnetikCoroutine mSetClientRedirectUrisCoroutine;
        private DateTime mSetClientRedirectUrisStartTime;
        private string mSetClientRedirectUrisPath;
        private readonly KnetikCoroutine mUpdateClientCoroutine;
        private DateTime mUpdateClientStartTime;
        private string mUpdateClientPath;

        public ClientResource CreateClientData { get; private set; }
        public delegate void CreateClientCompleteDelegate(ClientResource response);
        public CreateClientCompleteDelegate CreateClientComplete;

        public delegate void DeleteClientCompleteDelegate();
        public DeleteClientCompleteDelegate DeleteClientComplete;

        public ClientResource GetClientData { get; private set; }
        public delegate void GetClientCompleteDelegate(ClientResource response);
        public GetClientCompleteDelegate GetClientComplete;

        public List<GrantTypeResource> GetClientGrantTypesData { get; private set; }
        public delegate void GetClientGrantTypesCompleteDelegate(List<GrantTypeResource> response);
        public GetClientGrantTypesCompleteDelegate GetClientGrantTypesComplete;

        public PageResourceClientResource GetClientsData { get; private set; }
        public delegate void GetClientsCompleteDelegate(PageResourceClientResource response);
        public GetClientsCompleteDelegate GetClientsComplete;

        public delegate void SetClientGrantTypesCompleteDelegate();
        public SetClientGrantTypesCompleteDelegate SetClientGrantTypesComplete;

        public delegate void SetClientRedirectUrisCompleteDelegate();
        public SetClientRedirectUrisCompleteDelegate SetClientRedirectUrisComplete;

        public ClientResource UpdateClientData { get; private set; }
        public delegate void UpdateClientCompleteDelegate(ClientResource response);
        public UpdateClientCompleteDelegate UpdateClientComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthClientsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AuthClientsApi()
        {
            mCreateClientCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mDeleteClientCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetClientCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetClientGrantTypesCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mGetClientsCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mSetClientGrantTypesCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mSetClientRedirectUrisCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
            mUpdateClientCoroutine = new KnetikCoroutine(KnetikClient.DefaultClient);
        }
    
        /// <summary>
        /// Create a new client 
        /// </summary>
        /// <param name="clientResource">The client resource object</param>
        public void CreateClient(ClientResource clientResource)
        {
            
            mCreateClientPath = "/auth/clients";
            if (!string.IsNullOrEmpty(mCreateClientPath))
            {
                mCreateClientPath = mCreateClientPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(clientResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateClientStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateClientStartTime, mCreateClientPath, "Sending server request...");

            // make the HTTP request
            mCreateClientCoroutine.ResponseReceived += CreateClientCallback;
            mCreateClientCoroutine.Start(mCreateClientPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateClientCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateClient: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateClient: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateClientData = (ClientResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ClientResource), response.Headers);
            KnetikLogger.LogResponse(mCreateClientStartTime, mCreateClientPath, string.Format("Response received successfully:\n{0}", CreateClientData.ToString()));

            if (CreateClientComplete != null)
            {
                CreateClientComplete(CreateClientData);
            }
        }
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
            
            mDeleteClientPath = "/auth/clients/{client_key}";
            if (!string.IsNullOrEmpty(mDeleteClientPath))
            {
                mDeleteClientPath = mDeleteClientPath.Replace("{format}", "json");
            }
            mDeleteClientPath = mDeleteClientPath.Replace("{" + "client_key" + "}", KnetikClient.DefaultClient.ParameterToString(clientKey));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteClientStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteClientStartTime, mDeleteClientPath, "Sending server request...");

            // make the HTTP request
            mDeleteClientCoroutine.ResponseReceived += DeleteClientCallback;
            mDeleteClientCoroutine.Start(mDeleteClientPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteClientCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteClient: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteClient: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteClientStartTime, mDeleteClientPath, "Response received successfully.");
            if (DeleteClientComplete != null)
            {
                DeleteClientComplete();
            }
        }
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
            
            mGetClientPath = "/auth/clients/{client_key}";
            if (!string.IsNullOrEmpty(mGetClientPath))
            {
                mGetClientPath = mGetClientPath.Replace("{format}", "json");
            }
            mGetClientPath = mGetClientPath.Replace("{" + "client_key" + "}", KnetikClient.DefaultClient.ParameterToString(clientKey));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetClientStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetClientStartTime, mGetClientPath, "Sending server request...");

            // make the HTTP request
            mGetClientCoroutine.ResponseReceived += GetClientCallback;
            mGetClientCoroutine.Start(mGetClientPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetClientCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetClient: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetClient: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetClientData = (ClientResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ClientResource), response.Headers);
            KnetikLogger.LogResponse(mGetClientStartTime, mGetClientPath, string.Format("Response received successfully:\n{0}", GetClientData.ToString()));

            if (GetClientComplete != null)
            {
                GetClientComplete(GetClientData);
            }
        }
        /// <summary>
        /// List available client grant types 
        /// </summary>
        public void GetClientGrantTypes()
        {
            
            mGetClientGrantTypesPath = "/auth/clients/grant-types";
            if (!string.IsNullOrEmpty(mGetClientGrantTypesPath))
            {
                mGetClientGrantTypesPath = mGetClientGrantTypesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetClientGrantTypesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetClientGrantTypesStartTime, mGetClientGrantTypesPath, "Sending server request...");

            // make the HTTP request
            mGetClientGrantTypesCoroutine.ResponseReceived += GetClientGrantTypesCallback;
            mGetClientGrantTypesCoroutine.Start(mGetClientGrantTypesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetClientGrantTypesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetClientGrantTypes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetClientGrantTypes: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetClientGrantTypesData = (List<GrantTypeResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<GrantTypeResource>), response.Headers);
            KnetikLogger.LogResponse(mGetClientGrantTypesStartTime, mGetClientGrantTypesPath, string.Format("Response received successfully:\n{0}", GetClientGrantTypesData.ToString()));

            if (GetClientGrantTypesComplete != null)
            {
                GetClientGrantTypesComplete(GetClientGrantTypesData);
            }
        }
        /// <summary>
        /// List and search clients 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetClients(int? size, int? page, string order)
        {
            
            mGetClientsPath = "/auth/clients";
            if (!string.IsNullOrEmpty(mGetClientsPath))
            {
                mGetClientsPath = mGetClientsPath.Replace("{format}", "json");
            }
            
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

            mGetClientsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetClientsStartTime, mGetClientsPath, "Sending server request...");

            // make the HTTP request
            mGetClientsCoroutine.ResponseReceived += GetClientsCallback;
            mGetClientsCoroutine.Start(mGetClientsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetClientsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetClients: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetClients: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetClientsData = (PageResourceClientResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceClientResource), response.Headers);
            KnetikLogger.LogResponse(mGetClientsStartTime, mGetClientsPath, string.Format("Response received successfully:\n{0}", GetClientsData.ToString()));

            if (GetClientsComplete != null)
            {
                GetClientsComplete(GetClientsData);
            }
        }
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
            
            mSetClientGrantTypesPath = "/auth/clients/{client_key}/grant-types";
            if (!string.IsNullOrEmpty(mSetClientGrantTypesPath))
            {
                mSetClientGrantTypesPath = mSetClientGrantTypesPath.Replace("{format}", "json");
            }
            mSetClientGrantTypesPath = mSetClientGrantTypesPath.Replace("{" + "client_key" + "}", KnetikClient.DefaultClient.ParameterToString(clientKey));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(grantList); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetClientGrantTypesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetClientGrantTypesStartTime, mSetClientGrantTypesPath, "Sending server request...");

            // make the HTTP request
            mSetClientGrantTypesCoroutine.ResponseReceived += SetClientGrantTypesCallback;
            mSetClientGrantTypesCoroutine.Start(mSetClientGrantTypesPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetClientGrantTypesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetClientGrantTypes: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetClientGrantTypes: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetClientGrantTypesStartTime, mSetClientGrantTypesPath, "Response received successfully.");
            if (SetClientGrantTypesComplete != null)
            {
                SetClientGrantTypesComplete();
            }
        }
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
            
            mSetClientRedirectUrisPath = "/auth/clients/{client_key}/redirect-uris";
            if (!string.IsNullOrEmpty(mSetClientRedirectUrisPath))
            {
                mSetClientRedirectUrisPath = mSetClientRedirectUrisPath.Replace("{format}", "json");
            }
            mSetClientRedirectUrisPath = mSetClientRedirectUrisPath.Replace("{" + "client_key" + "}", KnetikClient.DefaultClient.ParameterToString(clientKey));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(redirectList); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSetClientRedirectUrisStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSetClientRedirectUrisStartTime, mSetClientRedirectUrisPath, "Sending server request...");

            // make the HTTP request
            mSetClientRedirectUrisCoroutine.ResponseReceived += SetClientRedirectUrisCallback;
            mSetClientRedirectUrisCoroutine.Start(mSetClientRedirectUrisPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SetClientRedirectUrisCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetClientRedirectUris: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SetClientRedirectUris: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mSetClientRedirectUrisStartTime, mSetClientRedirectUrisPath, "Response received successfully.");
            if (SetClientRedirectUrisComplete != null)
            {
                SetClientRedirectUrisComplete();
            }
        }
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
            
            mUpdateClientPath = "/auth/clients/{client_key}";
            if (!string.IsNullOrEmpty(mUpdateClientPath))
            {
                mUpdateClientPath = mUpdateClientPath.Replace("{format}", "json");
            }
            mUpdateClientPath = mUpdateClientPath.Replace("{" + "client_key" + "}", KnetikClient.DefaultClient.ParameterToString(clientKey));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(clientResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateClientStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateClientStartTime, mUpdateClientPath, "Sending server request...");

            // make the HTTP request
            mUpdateClientCoroutine.ResponseReceived += UpdateClientCallback;
            mUpdateClientCoroutine.Start(mUpdateClientPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateClientCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateClient: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateClient: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateClientData = (ClientResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ClientResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateClientStartTime, mUpdateClientPath, string.Format("Response received successfully:\n{0}", UpdateClientData.ToString()));

            if (UpdateClientComplete != null)
            {
                UpdateClientComplete(UpdateClientData);
            }
        }
    }
}
