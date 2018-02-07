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
    public interface IMediaArtistsApi
    {
        ArtistResource AddArtistData { get; }

        /// <summary>
        /// Adds a new artist in the system Adds a new artist in the system. Use specific media contributions endpoint to add contributions
        /// </summary>
        /// <param name="artistResource">The new artist</param>
        void AddArtist(ArtistResource artistResource);

        TemplateResource CreateArtistTemplateData { get; }

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

        ArtistResource GetArtistData { get; }

        /// <summary>
        /// Loads a specific artist details 
        /// </summary>
        /// <param name="id">The artist id</param>
        /// <param name="showContributions">The number of contributions to show fetch</param>
        void GetArtist(long? id, int? showContributions);

        TemplateResource GetArtistTemplateData { get; }

        /// <summary>
        /// Get a single artist template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetArtistTemplate(string id);

        PageResourceTemplateResource GetArtistTemplatesData { get; }

        /// <summary>
        /// List and search artist templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetArtistTemplates(int? size, int? page, string order);

        PageResourceArtistResource GetArtistsData { get; }

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

        TemplateResource UpdateArtistTemplateData { get; }

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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddArtistResponseContext;
        private DateTime mAddArtistStartTime;
        private readonly KnetikResponseContext mCreateArtistTemplateResponseContext;
        private DateTime mCreateArtistTemplateStartTime;
        private readonly KnetikResponseContext mDeleteArtistResponseContext;
        private DateTime mDeleteArtistStartTime;
        private readonly KnetikResponseContext mDeleteArtistTemplateResponseContext;
        private DateTime mDeleteArtistTemplateStartTime;
        private readonly KnetikResponseContext mGetArtistResponseContext;
        private DateTime mGetArtistStartTime;
        private readonly KnetikResponseContext mGetArtistTemplateResponseContext;
        private DateTime mGetArtistTemplateStartTime;
        private readonly KnetikResponseContext mGetArtistTemplatesResponseContext;
        private DateTime mGetArtistTemplatesStartTime;
        private readonly KnetikResponseContext mGetArtistsResponseContext;
        private DateTime mGetArtistsStartTime;
        private readonly KnetikResponseContext mUpdateArtistResponseContext;
        private DateTime mUpdateArtistStartTime;
        private readonly KnetikResponseContext mUpdateArtistTemplateResponseContext;
        private DateTime mUpdateArtistTemplateStartTime;

        public ArtistResource AddArtistData { get; private set; }
        public delegate void AddArtistCompleteDelegate(long responseCode, ArtistResource response);
        public AddArtistCompleteDelegate AddArtistComplete;

        public TemplateResource CreateArtistTemplateData { get; private set; }
        public delegate void CreateArtistTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateArtistTemplateCompleteDelegate CreateArtistTemplateComplete;

        public delegate void DeleteArtistCompleteDelegate(long responseCode);
        public DeleteArtistCompleteDelegate DeleteArtistComplete;

        public delegate void DeleteArtistTemplateCompleteDelegate(long responseCode);
        public DeleteArtistTemplateCompleteDelegate DeleteArtistTemplateComplete;

        public ArtistResource GetArtistData { get; private set; }
        public delegate void GetArtistCompleteDelegate(long responseCode, ArtistResource response);
        public GetArtistCompleteDelegate GetArtistComplete;

        public TemplateResource GetArtistTemplateData { get; private set; }
        public delegate void GetArtistTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetArtistTemplateCompleteDelegate GetArtistTemplateComplete;

        public PageResourceTemplateResource GetArtistTemplatesData { get; private set; }
        public delegate void GetArtistTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetArtistTemplatesCompleteDelegate GetArtistTemplatesComplete;

        public PageResourceArtistResource GetArtistsData { get; private set; }
        public delegate void GetArtistsCompleteDelegate(long responseCode, PageResourceArtistResource response);
        public GetArtistsCompleteDelegate GetArtistsComplete;

        public delegate void UpdateArtistCompleteDelegate(long responseCode);
        public UpdateArtistCompleteDelegate UpdateArtistComplete;

        public TemplateResource UpdateArtistTemplateData { get; private set; }
        public delegate void UpdateArtistTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateArtistTemplateCompleteDelegate UpdateArtistTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaArtistsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MediaArtistsApi()
        {
            mAddArtistResponseContext = new KnetikResponseContext();
            mAddArtistResponseContext.ResponseReceived += OnAddArtistResponse;
            mCreateArtistTemplateResponseContext = new KnetikResponseContext();
            mCreateArtistTemplateResponseContext.ResponseReceived += OnCreateArtistTemplateResponse;
            mDeleteArtistResponseContext = new KnetikResponseContext();
            mDeleteArtistResponseContext.ResponseReceived += OnDeleteArtistResponse;
            mDeleteArtistTemplateResponseContext = new KnetikResponseContext();
            mDeleteArtistTemplateResponseContext.ResponseReceived += OnDeleteArtistTemplateResponse;
            mGetArtistResponseContext = new KnetikResponseContext();
            mGetArtistResponseContext.ResponseReceived += OnGetArtistResponse;
            mGetArtistTemplateResponseContext = new KnetikResponseContext();
            mGetArtistTemplateResponseContext.ResponseReceived += OnGetArtistTemplateResponse;
            mGetArtistTemplatesResponseContext = new KnetikResponseContext();
            mGetArtistTemplatesResponseContext.ResponseReceived += OnGetArtistTemplatesResponse;
            mGetArtistsResponseContext = new KnetikResponseContext();
            mGetArtistsResponseContext.ResponseReceived += OnGetArtistsResponse;
            mUpdateArtistResponseContext = new KnetikResponseContext();
            mUpdateArtistResponseContext.ResponseReceived += OnUpdateArtistResponse;
            mUpdateArtistTemplateResponseContext = new KnetikResponseContext();
            mUpdateArtistTemplateResponseContext.ResponseReceived += OnUpdateArtistTemplateResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Adds a new artist in the system Adds a new artist in the system. Use specific media contributions endpoint to add contributions
        /// </summary>
        /// <param name="artistResource">The new artist</param>
        public void AddArtist(ArtistResource artistResource)
        {
            
            mWebCallEvent.WebPath = "/media/artists";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(artistResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddArtistStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddArtistResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddArtistStartTime, "AddArtist", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddArtistResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddArtist: " + response.Error);
            }

            AddArtistData = (ArtistResource) KnetikClient.Deserialize(response.Content, typeof(ArtistResource), response.Headers);
            KnetikLogger.LogResponse(mAddArtistStartTime, "AddArtist", string.Format("Response received successfully:\n{0}", AddArtistData));

            if (AddArtistComplete != null)
            {
                AddArtistComplete(response.ResponseCode, AddArtistData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create an artist template Artist Templates define a type of artist and the properties they have
        /// </summary>
        /// <param name="artistTemplateResource">The artist template resource object</param>
        public void CreateArtistTemplate(TemplateResource artistTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/media/artists/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(artistTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateArtistTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateArtistTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateArtistTemplateStartTime, "CreateArtistTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateArtistTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateArtistTemplate: " + response.Error);
            }

            CreateArtistTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateArtistTemplateStartTime, "CreateArtistTemplate", string.Format("Response received successfully:\n{0}", CreateArtistTemplateData));

            if (CreateArtistTemplateComplete != null)
            {
                CreateArtistTemplateComplete(response.ResponseCode, CreateArtistTemplateData);
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
            
            mWebCallEvent.WebPath = "/media/artists/{id}";
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
            mDeleteArtistStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteArtistResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteArtistStartTime, "DeleteArtist", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteArtistResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteArtist: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteArtistStartTime, "DeleteArtist", "Response received successfully.");
            if (DeleteArtistComplete != null)
            {
                DeleteArtistComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/media/artists/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (cascade != null)
            {
                mWebCallEvent.QueryParams["cascade"] = KnetikClient.ParameterToString(cascade);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteArtistTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteArtistTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteArtistTemplateStartTime, "DeleteArtistTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteArtistTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteArtistTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteArtistTemplateStartTime, "DeleteArtistTemplate", "Response received successfully.");
            if (DeleteArtistTemplateComplete != null)
            {
                DeleteArtistTemplateComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/media/artists/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (showContributions != null)
            {
                mWebCallEvent.QueryParams["show_contributions"] = KnetikClient.ParameterToString(showContributions);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetArtistStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetArtistResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetArtistStartTime, "GetArtist", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetArtistResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetArtist: " + response.Error);
            }

            GetArtistData = (ArtistResource) KnetikClient.Deserialize(response.Content, typeof(ArtistResource), response.Headers);
            KnetikLogger.LogResponse(mGetArtistStartTime, "GetArtist", string.Format("Response received successfully:\n{0}", GetArtistData));

            if (GetArtistComplete != null)
            {
                GetArtistComplete(response.ResponseCode, GetArtistData);
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
            
            mWebCallEvent.WebPath = "/media/artists/templates/{id}";
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
            mGetArtistTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetArtistTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetArtistTemplateStartTime, "GetArtistTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetArtistTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetArtistTemplate: " + response.Error);
            }

            GetArtistTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetArtistTemplateStartTime, "GetArtistTemplate", string.Format("Response received successfully:\n{0}", GetArtistTemplateData));

            if (GetArtistTemplateComplete != null)
            {
                GetArtistTemplateComplete(response.ResponseCode, GetArtistTemplateData);
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
            
            mWebCallEvent.WebPath = "/media/artists/templates";
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
            mGetArtistTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetArtistTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetArtistTemplatesStartTime, "GetArtistTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetArtistTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetArtistTemplates: " + response.Error);
            }

            GetArtistTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetArtistTemplatesStartTime, "GetArtistTemplates", string.Format("Response received successfully:\n{0}", GetArtistTemplatesData));

            if (GetArtistTemplatesComplete != null)
            {
                GetArtistTemplatesComplete(response.ResponseCode, GetArtistTemplatesData);
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
            
            mWebCallEvent.WebPath = "/media/artists";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterArtistsByName != null)
            {
                mWebCallEvent.QueryParams["filter_artists_by_name"] = KnetikClient.ParameterToString(filterArtistsByName);
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
            mGetArtistsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetArtistsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetArtistsStartTime, "GetArtists", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetArtistsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetArtists: " + response.Error);
            }

            GetArtistsData = (PageResourceArtistResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceArtistResource), response.Headers);
            KnetikLogger.LogResponse(mGetArtistsStartTime, "GetArtists", string.Format("Response received successfully:\n{0}", GetArtistsData));

            if (GetArtistsComplete != null)
            {
                GetArtistsComplete(response.ResponseCode, GetArtistsData);
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
            
            mWebCallEvent.WebPath = "/media/artists/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(artistResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateArtistStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateArtistResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateArtistStartTime, "UpdateArtist", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateArtistResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateArtist: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateArtistStartTime, "UpdateArtist", "Response received successfully.");
            if (UpdateArtistComplete != null)
            {
                UpdateArtistComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/media/artists/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(artistTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateArtistTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateArtistTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateArtistTemplateStartTime, "UpdateArtistTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateArtistTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateArtistTemplate: " + response.Error);
            }

            UpdateArtistTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateArtistTemplateStartTime, "UpdateArtistTemplate", string.Format("Response received successfully:\n{0}", UpdateArtistTemplateData));

            if (UpdateArtistTemplateComplete != null)
            {
                UpdateArtistTemplateComplete(response.ResponseCode, UpdateArtistTemplateData);
            }
        }

    }
}
