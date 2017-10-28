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
    public interface IMediaArtistsApi
    {
        ArtistResource AddArtistData { get; }

        TemplateResource CreateArtistTemplateData { get; }

        ArtistResource GetArtistData { get; }

        TemplateResource GetArtistTemplateData { get; }

        PageResourceTemplateResource GetArtistTemplatesData { get; }

        PageResourceArtistResource GetArtistsData { get; }

        TemplateResource UpdateArtistTemplateData { get; }

        
        /// <summary>
        /// Adds a new artist in the system Adds a new artist in the system. Use specific media contributions endpoint to add contributions
        /// </summary>
        /// <param name="artistResource">The new artist</param>
        void AddArtist(ArtistResource artistResource);

        /// <summary>
        /// Create an artist template Artist Templates define a type of artist and the properties they have
        /// </summary>
        /// <param name="artistTemplateResource">The artist template resource object</param>
        void CreateArtistTemplate(TemplateResource artistTemplateResource);

        /// <summary>
        /// Removes an artist from the system IF no resources are attached to it 
        /// </summary>
        /// <param name="id">The artist id</param>
        void DeleteArtist(long? id);

        /// <summary>
        /// Delete an artist template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteArtistTemplate(string id, string cascade);

        /// <summary>
        /// Loads a specific artist details 
        /// </summary>
        /// <param name="id">The artist id</param>
        /// <param name="showContributions">The number of contributions to show fetch</param>
        void GetArtist(long? id, int? showContributions);

        /// <summary>
        /// Get a single artist template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetArtistTemplate(string id);

        /// <summary>
        /// List and search artist templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetArtistTemplates(int? size, int? page, string order);

        /// <summary>
        /// Search for artists 
        /// </summary>
        /// <param name="filterArtistsByName">Filter for artists which name *STARTS* with the given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetArtists(string filterArtistsByName, int? size, int? page, string order);

        /// <summary>
        /// Modifies an artist details 
        /// </summary>
        /// <param name="id">The artist id</param>
        /// <param name="artistResource">The new artist</param>
        void UpdateArtist(long? id, ArtistResource artistResource);

        /// <summary>
        /// Update an artist template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="artistTemplateResource">The artist template resource object</param>
        void UpdateArtistTemplate(string id, TemplateResource artistTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class MediaArtistsApi : IMediaArtistsApi
    {
        private readonly KnetikCoroutine mAddArtistCoroutine;
        private DateTime mAddArtistStartTime;
        private string mAddArtistPath;
        private readonly KnetikCoroutine mCreateArtistTemplateCoroutine;
        private DateTime mCreateArtistTemplateStartTime;
        private string mCreateArtistTemplatePath;
        private readonly KnetikCoroutine mDeleteArtistCoroutine;
        private DateTime mDeleteArtistStartTime;
        private string mDeleteArtistPath;
        private readonly KnetikCoroutine mDeleteArtistTemplateCoroutine;
        private DateTime mDeleteArtistTemplateStartTime;
        private string mDeleteArtistTemplatePath;
        private readonly KnetikCoroutine mGetArtistCoroutine;
        private DateTime mGetArtistStartTime;
        private string mGetArtistPath;
        private readonly KnetikCoroutine mGetArtistTemplateCoroutine;
        private DateTime mGetArtistTemplateStartTime;
        private string mGetArtistTemplatePath;
        private readonly KnetikCoroutine mGetArtistTemplatesCoroutine;
        private DateTime mGetArtistTemplatesStartTime;
        private string mGetArtistTemplatesPath;
        private readonly KnetikCoroutine mGetArtistsCoroutine;
        private DateTime mGetArtistsStartTime;
        private string mGetArtistsPath;
        private readonly KnetikCoroutine mUpdateArtistCoroutine;
        private DateTime mUpdateArtistStartTime;
        private string mUpdateArtistPath;
        private readonly KnetikCoroutine mUpdateArtistTemplateCoroutine;
        private DateTime mUpdateArtistTemplateStartTime;
        private string mUpdateArtistTemplatePath;

        public ArtistResource AddArtistData { get; private set; }
        public delegate void AddArtistCompleteDelegate(ArtistResource response);
        public AddArtistCompleteDelegate AddArtistComplete;

        public TemplateResource CreateArtistTemplateData { get; private set; }
        public delegate void CreateArtistTemplateCompleteDelegate(TemplateResource response);
        public CreateArtistTemplateCompleteDelegate CreateArtistTemplateComplete;

        public delegate void DeleteArtistCompleteDelegate();
        public DeleteArtistCompleteDelegate DeleteArtistComplete;

        public delegate void DeleteArtistTemplateCompleteDelegate();
        public DeleteArtistTemplateCompleteDelegate DeleteArtistTemplateComplete;

        public ArtistResource GetArtistData { get; private set; }
        public delegate void GetArtistCompleteDelegate(ArtistResource response);
        public GetArtistCompleteDelegate GetArtistComplete;

        public TemplateResource GetArtistTemplateData { get; private set; }
        public delegate void GetArtistTemplateCompleteDelegate(TemplateResource response);
        public GetArtistTemplateCompleteDelegate GetArtistTemplateComplete;

        public PageResourceTemplateResource GetArtistTemplatesData { get; private set; }
        public delegate void GetArtistTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetArtistTemplatesCompleteDelegate GetArtistTemplatesComplete;

        public PageResourceArtistResource GetArtistsData { get; private set; }
        public delegate void GetArtistsCompleteDelegate(PageResourceArtistResource response);
        public GetArtistsCompleteDelegate GetArtistsComplete;

        public delegate void UpdateArtistCompleteDelegate();
        public UpdateArtistCompleteDelegate UpdateArtistComplete;

        public TemplateResource UpdateArtistTemplateData { get; private set; }
        public delegate void UpdateArtistTemplateCompleteDelegate(TemplateResource response);
        public UpdateArtistTemplateCompleteDelegate UpdateArtistTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaArtistsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MediaArtistsApi()
        {
            mAddArtistCoroutine = new KnetikCoroutine();
            mCreateArtistTemplateCoroutine = new KnetikCoroutine();
            mDeleteArtistCoroutine = new KnetikCoroutine();
            mDeleteArtistTemplateCoroutine = new KnetikCoroutine();
            mGetArtistCoroutine = new KnetikCoroutine();
            mGetArtistTemplateCoroutine = new KnetikCoroutine();
            mGetArtistTemplatesCoroutine = new KnetikCoroutine();
            mGetArtistsCoroutine = new KnetikCoroutine();
            mUpdateArtistCoroutine = new KnetikCoroutine();
            mUpdateArtistTemplateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Adds a new artist in the system Adds a new artist in the system. Use specific media contributions endpoint to add contributions
        /// </summary>
        /// <param name="artistResource">The new artist</param>
        public void AddArtist(ArtistResource artistResource)
        {
            
            mAddArtistPath = "/media/artists";
            if (!string.IsNullOrEmpty(mAddArtistPath))
            {
                mAddArtistPath = mAddArtistPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(artistResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddArtistStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddArtistStartTime, mAddArtistPath, "Sending server request...");

            // make the HTTP request
            mAddArtistCoroutine.ResponseReceived += AddArtistCallback;
            mAddArtistCoroutine.Start(mAddArtistPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddArtistCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddArtist: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddArtist: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddArtistData = (ArtistResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ArtistResource), response.Headers);
            KnetikLogger.LogResponse(mAddArtistStartTime, mAddArtistPath, string.Format("Response received successfully:\n{0}", AddArtistData.ToString()));

            if (AddArtistComplete != null)
            {
                AddArtistComplete(AddArtistData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create an artist template Artist Templates define a type of artist and the properties they have
        /// </summary>
        /// <param name="artistTemplateResource">The artist template resource object</param>
        public void CreateArtistTemplate(TemplateResource artistTemplateResource)
        {
            
            mCreateArtistTemplatePath = "/media/artists/templates";
            if (!string.IsNullOrEmpty(mCreateArtistTemplatePath))
            {
                mCreateArtistTemplatePath = mCreateArtistTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(artistTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateArtistTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateArtistTemplateStartTime, mCreateArtistTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateArtistTemplateCoroutine.ResponseReceived += CreateArtistTemplateCallback;
            mCreateArtistTemplateCoroutine.Start(mCreateArtistTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateArtistTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateArtistTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateArtistTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateArtistTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateArtistTemplateStartTime, mCreateArtistTemplatePath, string.Format("Response received successfully:\n{0}", CreateArtistTemplateData.ToString()));

            if (CreateArtistTemplateComplete != null)
            {
                CreateArtistTemplateComplete(CreateArtistTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Removes an artist from the system IF no resources are attached to it 
        /// </summary>
        /// <param name="id">The artist id</param>
        public void DeleteArtist(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteArtist");
            }
            
            mDeleteArtistPath = "/media/artists/{id}";
            if (!string.IsNullOrEmpty(mDeleteArtistPath))
            {
                mDeleteArtistPath = mDeleteArtistPath.Replace("{format}", "json");
            }
            mDeleteArtistPath = mDeleteArtistPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteArtistStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteArtistStartTime, mDeleteArtistPath, "Sending server request...");

            // make the HTTP request
            mDeleteArtistCoroutine.ResponseReceived += DeleteArtistCallback;
            mDeleteArtistCoroutine.Start(mDeleteArtistPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteArtistCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteArtist: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteArtist: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteArtistStartTime, mDeleteArtistPath, "Response received successfully.");
            if (DeleteArtistComplete != null)
            {
                DeleteArtistComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an artist template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteArtistTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteArtistTemplate");
            }
            
            mDeleteArtistTemplatePath = "/media/artists/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteArtistTemplatePath))
            {
                mDeleteArtistTemplatePath = mDeleteArtistTemplatePath.Replace("{format}", "json");
            }
            mDeleteArtistTemplatePath = mDeleteArtistTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteArtistTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteArtistTemplateStartTime, mDeleteArtistTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteArtistTemplateCoroutine.ResponseReceived += DeleteArtistTemplateCallback;
            mDeleteArtistTemplateCoroutine.Start(mDeleteArtistTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteArtistTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteArtistTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteArtistTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteArtistTemplateStartTime, mDeleteArtistTemplatePath, "Response received successfully.");
            if (DeleteArtistTemplateComplete != null)
            {
                DeleteArtistTemplateComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Loads a specific artist details 
        /// </summary>
        /// <param name="id">The artist id</param>
        /// <param name="showContributions">The number of contributions to show fetch</param>
        public void GetArtist(long? id, int? showContributions)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetArtist");
            }
            
            mGetArtistPath = "/media/artists/{id}";
            if (!string.IsNullOrEmpty(mGetArtistPath))
            {
                mGetArtistPath = mGetArtistPath.Replace("{format}", "json");
            }
            mGetArtistPath = mGetArtistPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (showContributions != null)
            {
                queryParams.Add("show_contributions", KnetikClient.DefaultClient.ParameterToString(showContributions));
            }

            // authentication setting, if any
            List<string> authSettings = new List<string> {  };

            mGetArtistStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetArtistStartTime, mGetArtistPath, "Sending server request...");

            // make the HTTP request
            mGetArtistCoroutine.ResponseReceived += GetArtistCallback;
            mGetArtistCoroutine.Start(mGetArtistPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetArtistCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArtist: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArtist: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetArtistData = (ArtistResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ArtistResource), response.Headers);
            KnetikLogger.LogResponse(mGetArtistStartTime, mGetArtistPath, string.Format("Response received successfully:\n{0}", GetArtistData.ToString()));

            if (GetArtistComplete != null)
            {
                GetArtistComplete(GetArtistData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single artist template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetArtistTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetArtistTemplate");
            }
            
            mGetArtistTemplatePath = "/media/artists/templates/{id}";
            if (!string.IsNullOrEmpty(mGetArtistTemplatePath))
            {
                mGetArtistTemplatePath = mGetArtistTemplatePath.Replace("{format}", "json");
            }
            mGetArtistTemplatePath = mGetArtistTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetArtistTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetArtistTemplateStartTime, mGetArtistTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetArtistTemplateCoroutine.ResponseReceived += GetArtistTemplateCallback;
            mGetArtistTemplateCoroutine.Start(mGetArtistTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetArtistTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArtistTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArtistTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetArtistTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetArtistTemplateStartTime, mGetArtistTemplatePath, string.Format("Response received successfully:\n{0}", GetArtistTemplateData.ToString()));

            if (GetArtistTemplateComplete != null)
            {
                GetArtistTemplateComplete(GetArtistTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search artist templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetArtistTemplates(int? size, int? page, string order)
        {
            
            mGetArtistTemplatesPath = "/media/artists/templates";
            if (!string.IsNullOrEmpty(mGetArtistTemplatesPath))
            {
                mGetArtistTemplatesPath = mGetArtistTemplatesPath.Replace("{format}", "json");
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
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetArtistTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetArtistTemplatesStartTime, mGetArtistTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetArtistTemplatesCoroutine.ResponseReceived += GetArtistTemplatesCallback;
            mGetArtistTemplatesCoroutine.Start(mGetArtistTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetArtistTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArtistTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArtistTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetArtistTemplatesData = (PageResourceTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetArtistTemplatesStartTime, mGetArtistTemplatesPath, string.Format("Response received successfully:\n{0}", GetArtistTemplatesData.ToString()));

            if (GetArtistTemplatesComplete != null)
            {
                GetArtistTemplatesComplete(GetArtistTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Search for artists 
        /// </summary>
        /// <param name="filterArtistsByName">Filter for artists which name *STARTS* with the given string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetArtists(string filterArtistsByName, int? size, int? page, string order)
        {
            
            mGetArtistsPath = "/media/artists";
            if (!string.IsNullOrEmpty(mGetArtistsPath))
            {
                mGetArtistsPath = mGetArtistsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterArtistsByName != null)
            {
                queryParams.Add("filter_artists_by_name", KnetikClient.DefaultClient.ParameterToString(filterArtistsByName));
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
            List<string> authSettings = new List<string> {  };

            mGetArtistsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetArtistsStartTime, mGetArtistsPath, "Sending server request...");

            // make the HTTP request
            mGetArtistsCoroutine.ResponseReceived += GetArtistsCallback;
            mGetArtistsCoroutine.Start(mGetArtistsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetArtistsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArtists: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetArtists: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetArtistsData = (PageResourceArtistResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceArtistResource), response.Headers);
            KnetikLogger.LogResponse(mGetArtistsStartTime, mGetArtistsPath, string.Format("Response received successfully:\n{0}", GetArtistsData.ToString()));

            if (GetArtistsComplete != null)
            {
                GetArtistsComplete(GetArtistsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Modifies an artist details 
        /// </summary>
        /// <param name="id">The artist id</param>
        /// <param name="artistResource">The new artist</param>
        public void UpdateArtist(long? id, ArtistResource artistResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateArtist");
            }
            
            mUpdateArtistPath = "/media/artists/{id}";
            if (!string.IsNullOrEmpty(mUpdateArtistPath))
            {
                mUpdateArtistPath = mUpdateArtistPath.Replace("{format}", "json");
            }
            mUpdateArtistPath = mUpdateArtistPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(artistResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateArtistStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateArtistStartTime, mUpdateArtistPath, "Sending server request...");

            // make the HTTP request
            mUpdateArtistCoroutine.ResponseReceived += UpdateArtistCallback;
            mUpdateArtistCoroutine.Start(mUpdateArtistPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateArtistCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateArtist: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateArtist: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateArtistStartTime, mUpdateArtistPath, "Response received successfully.");
            if (UpdateArtistComplete != null)
            {
                UpdateArtistComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an artist template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="artistTemplateResource">The artist template resource object</param>
        public void UpdateArtistTemplate(string id, TemplateResource artistTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateArtistTemplate");
            }
            
            mUpdateArtistTemplatePath = "/media/artists/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateArtistTemplatePath))
            {
                mUpdateArtistTemplatePath = mUpdateArtistTemplatePath.Replace("{format}", "json");
            }
            mUpdateArtistTemplatePath = mUpdateArtistTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(artistTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateArtistTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateArtistTemplateStartTime, mUpdateArtistTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateArtistTemplateCoroutine.ResponseReceived += UpdateArtistTemplateCallback;
            mUpdateArtistTemplateCoroutine.Start(mUpdateArtistTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateArtistTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateArtistTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateArtistTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateArtistTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateArtistTemplateStartTime, mUpdateArtistTemplatePath, string.Format("Response received successfully:\n{0}", UpdateArtistTemplateData.ToString()));

            if (UpdateArtistTemplateComplete != null)
            {
                UpdateArtistTemplateComplete(UpdateArtistTemplateData);
            }
        }

    }
}
