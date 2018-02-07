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
    public interface IMediaVideosApi
    {
        

        /// <summary>
        /// Adds a user to a video&#39;s whitelist Whitelisted users can view video regardless of privacy setting.
        /// </summary>
        /// <param name="id">The video id</param>
        /// <param name="userId">The user id</param>
        void AddUserToVideoWhitelist(long? id, IntWrapper userId);

        VideoResource AddVideoData { get; }

        /// <summary>
        /// Adds a new video in the system 
        /// </summary>
        /// <param name="videoResource">The video object</param>
        void AddVideo(VideoResource videoResource);

        CommentResource AddVideoCommentData { get; }

        /// <summary>
        /// Add a new video comment 
        /// </summary>
        /// <param name="videoId">The video id </param>
        /// <param name="commentResource">The comment object</param>
        void AddVideoComment(int? videoId, CommentResource commentResource);

        

        /// <summary>
        /// Adds a contributor to a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="contributionResource">The contribution object</param>
        void AddVideoContributor(long? videoId, ContributionResource contributionResource);

        FlagResource AddVideoFlagData { get; }

        /// <summary>
        /// Add a new flag 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="reason">The flag reason</param>
        void AddVideoFlag(long? videoId, StringWrapper reason);

        VideoRelationshipResource AddVideoRelationshipsData { get; }

        /// <summary>
        /// Adds one or more existing videos as related to this one 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="videoRelationshipResource">The video relationship object </param>
        void AddVideoRelationships(long? videoId, VideoRelationshipResource videoRelationshipResource);

        DispositionResource CreateVideoDispositionData { get; }

        /// <summary>
        /// Create a video disposition 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="dispositionResource">The disposition object</param>
        void CreateVideoDisposition(int? videoId, DispositionResource dispositionResource);

        TemplateResource CreateVideoTemplateData { get; }

        /// <summary>
        /// Create a video template Video Templates define a type of video and the properties they have
        /// </summary>
        /// <param name="videoTemplateResource">The video template resource object</param>
        void CreateVideoTemplate(TemplateResource videoTemplateResource);

        

        /// <summary>
        /// Deletes a video from the system if no resources are attached to it 
        /// </summary>
        /// <param name="id">The video id</param>
        void DeleteVideo(long? id);

        

        /// <summary>
        /// Delete a video comment 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The comment id</param>
        void DeleteVideoComment(long? videoId, long? id);

        

        /// <summary>
        /// Delete a video disposition 
        /// </summary>
        /// <param name="dispositionId">The disposition id</param>
        void DeleteVideoDisposition(long? dispositionId);

        

        /// <summary>
        /// Delete a flag 
        /// </summary>
        /// <param name="videoId">The video id</param>
        void DeleteVideoFlag(long? videoId);

        

        /// <summary>
        /// Delete a video&#39;s relationship 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The relationship id</param>
        void DeleteVideoRelationship(long? videoId, long? id);

        

        /// <summary>
        /// Delete a video template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteVideoTemplate(string id, string cascade);

        PageResourceVideoResource GetUserVideosData { get; }

        /// <summary>
        /// Get user videos 
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="excludeFlagged">Skip videos that have been flagged by the current user</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUserVideos(int? userId, bool? excludeFlagged, int? size, int? page);

        VideoResource GetVideoData { get; }

        /// <summary>
        /// Loads a specific video details 
        /// </summary>
        /// <param name="id">The video id</param>
        void GetVideo(long? id);

        PageResourceCommentResource GetVideoCommentsData { get; }

        /// <summary>
        /// Returns a page of comments for a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetVideoComments(int? videoId, int? size, int? page);

        PageResourceDispositionResource GetVideoDispositionsData { get; }

        /// <summary>
        /// Returns a page of dispositions for a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetVideoDispositions(int? videoId, int? size, int? page);

        PageResourceVideoRelationshipResource GetVideoRelationshipsData { get; }

        /// <summary>
        /// Returns a page of video relationships 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetVideoRelationships(long? videoId, int? size, int? page);

        TemplateResource GetVideoTemplateData { get; }

        /// <summary>
        /// Get a single video template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetVideoTemplate(string id);

        PageResourceTemplateResource GetVideoTemplatesData { get; }

        /// <summary>
        /// List and search video templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetVideoTemplates(int? size, int? page, string order);

        PageResourceVideoResource GetVideosData { get; }

        /// <summary>
        /// Search videos using the documented filters 
        /// </summary>
        /// <param name="excludeFlagged">Skip videos that have been flagged by the current user</param>
        /// <param name="filterVideosByUploader">Filter for videos by uploader id</param>
        /// <param name="filterCategory">Filter for videos from a specific category by id</param>
        /// <param name="filterTagset">Filter for videos with specified tags (separated by comma)</param>
        /// <param name="filterVideosByName">Filter for videos which name *STARTS* with the given string</param>
        /// <param name="filterVideosByContributor">Filter for videos with contribution from the artist specified by ID</param>
        /// <param name="filterVideosByAuthor">Filter for videos with an artist as author specified by ID</param>
        /// <param name="filterHasAuthor">Filter for videos that have an author set if true, or that have no author if false</param>
        /// <param name="filterHasUploader">Filter for videos that have an uploader set if true, or that have no uploader if false</param>
        /// <param name="filterRelatedTo">Filter for videos that have designated a particular video as the TO of a relationship. Pattern should match VIDEO_ID or VIDEO_ID:DETAILS to match with a specific details string as well</param>
        /// <param name="filterFriends">Filter for videos uploaded by friends. &#39;true&#39; for friends of the caller (requires user token) or a user id for a specific user&#39;s friends (requires VIDEOS_ADMIN permission)</param>
        /// <param name="filterDisposition">Filter for videos a given user has a given disposition towards. USER_ID:DISPOSITION where USER_ID is the id of the user who has this disposition or &#39;me&#39; for the caller (requires user token for &#39;me&#39;) and DISPOSITION is the name of the disposition. E.G. filter_disposition&#x3D;123:like or filter_disposition&#x3D;me:favorite</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetVideos(bool? excludeFlagged, int? filterVideosByUploader, string filterCategory, string filterTagset, string filterVideosByName, int? filterVideosByContributor, int? filterVideosByAuthor, bool? filterHasAuthor, bool? filterHasUploader, string filterRelatedTo, bool? filterFriends, string filterDisposition, int? size, int? page, string order);

        

        /// <summary>
        /// Removes a user from a video&#39;s whitelist Remove the user with the id given in the path from the whitelist of users that can view this video regardless of privacy setting.
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The user id</param>
        void RemoveUserFromVideoWhitelist(long? videoId, int? id);

        

        /// <summary>
        /// Removes a contributor from a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The contributor id</param>
        void RemoveVideoContributor(long? videoId, int? id);

        

        /// <summary>
        /// Modifies a video&#39;s details 
        /// </summary>
        /// <param name="id">The video id</param>
        /// <param name="videoResource">The video object</param>
        void UpdateVideo(long? id, VideoResource videoResource);

        

        /// <summary>
        /// Update a video comment 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The comment id</param>
        /// <param name="content">The comment content</param>
        void UpdateVideoComment(long? videoId, long? id, StringWrapper content);

        

        /// <summary>
        /// Update a video&#39;s relationship details 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="relationshipId">The relationship id</param>
        /// <param name="details">The video relationship details</param>
        void UpdateVideoRelationship(long? videoId, long? relationshipId, StringWrapper details);

        TemplateResource UpdateVideoTemplateData { get; }

        /// <summary>
        /// Update a video template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="videoTemplateResource">The video template resource object</param>
        void UpdateVideoTemplate(string id, TemplateResource videoTemplateResource);

        

        /// <summary>
        /// Increment a video&#39;s view count 
        /// </summary>
        /// <param name="id">The video id</param>
        void ViewVideo(long? id);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class MediaVideosApi : IMediaVideosApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddUserToVideoWhitelistResponseContext;
        private DateTime mAddUserToVideoWhitelistStartTime;
        private readonly KnetikResponseContext mAddVideoResponseContext;
        private DateTime mAddVideoStartTime;
        private readonly KnetikResponseContext mAddVideoCommentResponseContext;
        private DateTime mAddVideoCommentStartTime;
        private readonly KnetikResponseContext mAddVideoContributorResponseContext;
        private DateTime mAddVideoContributorStartTime;
        private readonly KnetikResponseContext mAddVideoFlagResponseContext;
        private DateTime mAddVideoFlagStartTime;
        private readonly KnetikResponseContext mAddVideoRelationshipsResponseContext;
        private DateTime mAddVideoRelationshipsStartTime;
        private readonly KnetikResponseContext mCreateVideoDispositionResponseContext;
        private DateTime mCreateVideoDispositionStartTime;
        private readonly KnetikResponseContext mCreateVideoTemplateResponseContext;
        private DateTime mCreateVideoTemplateStartTime;
        private readonly KnetikResponseContext mDeleteVideoResponseContext;
        private DateTime mDeleteVideoStartTime;
        private readonly KnetikResponseContext mDeleteVideoCommentResponseContext;
        private DateTime mDeleteVideoCommentStartTime;
        private readonly KnetikResponseContext mDeleteVideoDispositionResponseContext;
        private DateTime mDeleteVideoDispositionStartTime;
        private readonly KnetikResponseContext mDeleteVideoFlagResponseContext;
        private DateTime mDeleteVideoFlagStartTime;
        private readonly KnetikResponseContext mDeleteVideoRelationshipResponseContext;
        private DateTime mDeleteVideoRelationshipStartTime;
        private readonly KnetikResponseContext mDeleteVideoTemplateResponseContext;
        private DateTime mDeleteVideoTemplateStartTime;
        private readonly KnetikResponseContext mGetUserVideosResponseContext;
        private DateTime mGetUserVideosStartTime;
        private readonly KnetikResponseContext mGetVideoResponseContext;
        private DateTime mGetVideoStartTime;
        private readonly KnetikResponseContext mGetVideoCommentsResponseContext;
        private DateTime mGetVideoCommentsStartTime;
        private readonly KnetikResponseContext mGetVideoDispositionsResponseContext;
        private DateTime mGetVideoDispositionsStartTime;
        private readonly KnetikResponseContext mGetVideoRelationshipsResponseContext;
        private DateTime mGetVideoRelationshipsStartTime;
        private readonly KnetikResponseContext mGetVideoTemplateResponseContext;
        private DateTime mGetVideoTemplateStartTime;
        private readonly KnetikResponseContext mGetVideoTemplatesResponseContext;
        private DateTime mGetVideoTemplatesStartTime;
        private readonly KnetikResponseContext mGetVideosResponseContext;
        private DateTime mGetVideosStartTime;
        private readonly KnetikResponseContext mRemoveUserFromVideoWhitelistResponseContext;
        private DateTime mRemoveUserFromVideoWhitelistStartTime;
        private readonly KnetikResponseContext mRemoveVideoContributorResponseContext;
        private DateTime mRemoveVideoContributorStartTime;
        private readonly KnetikResponseContext mUpdateVideoResponseContext;
        private DateTime mUpdateVideoStartTime;
        private readonly KnetikResponseContext mUpdateVideoCommentResponseContext;
        private DateTime mUpdateVideoCommentStartTime;
        private readonly KnetikResponseContext mUpdateVideoRelationshipResponseContext;
        private DateTime mUpdateVideoRelationshipStartTime;
        private readonly KnetikResponseContext mUpdateVideoTemplateResponseContext;
        private DateTime mUpdateVideoTemplateStartTime;
        private readonly KnetikResponseContext mViewVideoResponseContext;
        private DateTime mViewVideoStartTime;

        public delegate void AddUserToVideoWhitelistCompleteDelegate(long responseCode);
        public AddUserToVideoWhitelistCompleteDelegate AddUserToVideoWhitelistComplete;

        public VideoResource AddVideoData { get; private set; }
        public delegate void AddVideoCompleteDelegate(long responseCode, VideoResource response);
        public AddVideoCompleteDelegate AddVideoComplete;

        public CommentResource AddVideoCommentData { get; private set; }
        public delegate void AddVideoCommentCompleteDelegate(long responseCode, CommentResource response);
        public AddVideoCommentCompleteDelegate AddVideoCommentComplete;

        public delegate void AddVideoContributorCompleteDelegate(long responseCode);
        public AddVideoContributorCompleteDelegate AddVideoContributorComplete;

        public FlagResource AddVideoFlagData { get; private set; }
        public delegate void AddVideoFlagCompleteDelegate(long responseCode, FlagResource response);
        public AddVideoFlagCompleteDelegate AddVideoFlagComplete;

        public VideoRelationshipResource AddVideoRelationshipsData { get; private set; }
        public delegate void AddVideoRelationshipsCompleteDelegate(long responseCode, VideoRelationshipResource response);
        public AddVideoRelationshipsCompleteDelegate AddVideoRelationshipsComplete;

        public DispositionResource CreateVideoDispositionData { get; private set; }
        public delegate void CreateVideoDispositionCompleteDelegate(long responseCode, DispositionResource response);
        public CreateVideoDispositionCompleteDelegate CreateVideoDispositionComplete;

        public TemplateResource CreateVideoTemplateData { get; private set; }
        public delegate void CreateVideoTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateVideoTemplateCompleteDelegate CreateVideoTemplateComplete;

        public delegate void DeleteVideoCompleteDelegate(long responseCode);
        public DeleteVideoCompleteDelegate DeleteVideoComplete;

        public delegate void DeleteVideoCommentCompleteDelegate(long responseCode);
        public DeleteVideoCommentCompleteDelegate DeleteVideoCommentComplete;

        public delegate void DeleteVideoDispositionCompleteDelegate(long responseCode);
        public DeleteVideoDispositionCompleteDelegate DeleteVideoDispositionComplete;

        public delegate void DeleteVideoFlagCompleteDelegate(long responseCode);
        public DeleteVideoFlagCompleteDelegate DeleteVideoFlagComplete;

        public delegate void DeleteVideoRelationshipCompleteDelegate(long responseCode);
        public DeleteVideoRelationshipCompleteDelegate DeleteVideoRelationshipComplete;

        public delegate void DeleteVideoTemplateCompleteDelegate(long responseCode);
        public DeleteVideoTemplateCompleteDelegate DeleteVideoTemplateComplete;

        public PageResourceVideoResource GetUserVideosData { get; private set; }
        public delegate void GetUserVideosCompleteDelegate(long responseCode, PageResourceVideoResource response);
        public GetUserVideosCompleteDelegate GetUserVideosComplete;

        public VideoResource GetVideoData { get; private set; }
        public delegate void GetVideoCompleteDelegate(long responseCode, VideoResource response);
        public GetVideoCompleteDelegate GetVideoComplete;

        public PageResourceCommentResource GetVideoCommentsData { get; private set; }
        public delegate void GetVideoCommentsCompleteDelegate(long responseCode, PageResourceCommentResource response);
        public GetVideoCommentsCompleteDelegate GetVideoCommentsComplete;

        public PageResourceDispositionResource GetVideoDispositionsData { get; private set; }
        public delegate void GetVideoDispositionsCompleteDelegate(long responseCode, PageResourceDispositionResource response);
        public GetVideoDispositionsCompleteDelegate GetVideoDispositionsComplete;

        public PageResourceVideoRelationshipResource GetVideoRelationshipsData { get; private set; }
        public delegate void GetVideoRelationshipsCompleteDelegate(long responseCode, PageResourceVideoRelationshipResource response);
        public GetVideoRelationshipsCompleteDelegate GetVideoRelationshipsComplete;

        public TemplateResource GetVideoTemplateData { get; private set; }
        public delegate void GetVideoTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetVideoTemplateCompleteDelegate GetVideoTemplateComplete;

        public PageResourceTemplateResource GetVideoTemplatesData { get; private set; }
        public delegate void GetVideoTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetVideoTemplatesCompleteDelegate GetVideoTemplatesComplete;

        public PageResourceVideoResource GetVideosData { get; private set; }
        public delegate void GetVideosCompleteDelegate(long responseCode, PageResourceVideoResource response);
        public GetVideosCompleteDelegate GetVideosComplete;

        public delegate void RemoveUserFromVideoWhitelistCompleteDelegate(long responseCode);
        public RemoveUserFromVideoWhitelistCompleteDelegate RemoveUserFromVideoWhitelistComplete;

        public delegate void RemoveVideoContributorCompleteDelegate(long responseCode);
        public RemoveVideoContributorCompleteDelegate RemoveVideoContributorComplete;

        public delegate void UpdateVideoCompleteDelegate(long responseCode);
        public UpdateVideoCompleteDelegate UpdateVideoComplete;

        public delegate void UpdateVideoCommentCompleteDelegate(long responseCode);
        public UpdateVideoCommentCompleteDelegate UpdateVideoCommentComplete;

        public delegate void UpdateVideoRelationshipCompleteDelegate(long responseCode);
        public UpdateVideoRelationshipCompleteDelegate UpdateVideoRelationshipComplete;

        public TemplateResource UpdateVideoTemplateData { get; private set; }
        public delegate void UpdateVideoTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateVideoTemplateCompleteDelegate UpdateVideoTemplateComplete;

        public delegate void ViewVideoCompleteDelegate(long responseCode);
        public ViewVideoCompleteDelegate ViewVideoComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaVideosApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MediaVideosApi()
        {
            mAddUserToVideoWhitelistResponseContext = new KnetikResponseContext();
            mAddUserToVideoWhitelistResponseContext.ResponseReceived += OnAddUserToVideoWhitelistResponse;
            mAddVideoResponseContext = new KnetikResponseContext();
            mAddVideoResponseContext.ResponseReceived += OnAddVideoResponse;
            mAddVideoCommentResponseContext = new KnetikResponseContext();
            mAddVideoCommentResponseContext.ResponseReceived += OnAddVideoCommentResponse;
            mAddVideoContributorResponseContext = new KnetikResponseContext();
            mAddVideoContributorResponseContext.ResponseReceived += OnAddVideoContributorResponse;
            mAddVideoFlagResponseContext = new KnetikResponseContext();
            mAddVideoFlagResponseContext.ResponseReceived += OnAddVideoFlagResponse;
            mAddVideoRelationshipsResponseContext = new KnetikResponseContext();
            mAddVideoRelationshipsResponseContext.ResponseReceived += OnAddVideoRelationshipsResponse;
            mCreateVideoDispositionResponseContext = new KnetikResponseContext();
            mCreateVideoDispositionResponseContext.ResponseReceived += OnCreateVideoDispositionResponse;
            mCreateVideoTemplateResponseContext = new KnetikResponseContext();
            mCreateVideoTemplateResponseContext.ResponseReceived += OnCreateVideoTemplateResponse;
            mDeleteVideoResponseContext = new KnetikResponseContext();
            mDeleteVideoResponseContext.ResponseReceived += OnDeleteVideoResponse;
            mDeleteVideoCommentResponseContext = new KnetikResponseContext();
            mDeleteVideoCommentResponseContext.ResponseReceived += OnDeleteVideoCommentResponse;
            mDeleteVideoDispositionResponseContext = new KnetikResponseContext();
            mDeleteVideoDispositionResponseContext.ResponseReceived += OnDeleteVideoDispositionResponse;
            mDeleteVideoFlagResponseContext = new KnetikResponseContext();
            mDeleteVideoFlagResponseContext.ResponseReceived += OnDeleteVideoFlagResponse;
            mDeleteVideoRelationshipResponseContext = new KnetikResponseContext();
            mDeleteVideoRelationshipResponseContext.ResponseReceived += OnDeleteVideoRelationshipResponse;
            mDeleteVideoTemplateResponseContext = new KnetikResponseContext();
            mDeleteVideoTemplateResponseContext.ResponseReceived += OnDeleteVideoTemplateResponse;
            mGetUserVideosResponseContext = new KnetikResponseContext();
            mGetUserVideosResponseContext.ResponseReceived += OnGetUserVideosResponse;
            mGetVideoResponseContext = new KnetikResponseContext();
            mGetVideoResponseContext.ResponseReceived += OnGetVideoResponse;
            mGetVideoCommentsResponseContext = new KnetikResponseContext();
            mGetVideoCommentsResponseContext.ResponseReceived += OnGetVideoCommentsResponse;
            mGetVideoDispositionsResponseContext = new KnetikResponseContext();
            mGetVideoDispositionsResponseContext.ResponseReceived += OnGetVideoDispositionsResponse;
            mGetVideoRelationshipsResponseContext = new KnetikResponseContext();
            mGetVideoRelationshipsResponseContext.ResponseReceived += OnGetVideoRelationshipsResponse;
            mGetVideoTemplateResponseContext = new KnetikResponseContext();
            mGetVideoTemplateResponseContext.ResponseReceived += OnGetVideoTemplateResponse;
            mGetVideoTemplatesResponseContext = new KnetikResponseContext();
            mGetVideoTemplatesResponseContext.ResponseReceived += OnGetVideoTemplatesResponse;
            mGetVideosResponseContext = new KnetikResponseContext();
            mGetVideosResponseContext.ResponseReceived += OnGetVideosResponse;
            mRemoveUserFromVideoWhitelistResponseContext = new KnetikResponseContext();
            mRemoveUserFromVideoWhitelistResponseContext.ResponseReceived += OnRemoveUserFromVideoWhitelistResponse;
            mRemoveVideoContributorResponseContext = new KnetikResponseContext();
            mRemoveVideoContributorResponseContext.ResponseReceived += OnRemoveVideoContributorResponse;
            mUpdateVideoResponseContext = new KnetikResponseContext();
            mUpdateVideoResponseContext.ResponseReceived += OnUpdateVideoResponse;
            mUpdateVideoCommentResponseContext = new KnetikResponseContext();
            mUpdateVideoCommentResponseContext.ResponseReceived += OnUpdateVideoCommentResponse;
            mUpdateVideoRelationshipResponseContext = new KnetikResponseContext();
            mUpdateVideoRelationshipResponseContext.ResponseReceived += OnUpdateVideoRelationshipResponse;
            mUpdateVideoTemplateResponseContext = new KnetikResponseContext();
            mUpdateVideoTemplateResponseContext.ResponseReceived += OnUpdateVideoTemplateResponse;
            mViewVideoResponseContext = new KnetikResponseContext();
            mViewVideoResponseContext.ResponseReceived += OnViewVideoResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Adds a user to a video&#39;s whitelist Whitelisted users can view video regardless of privacy setting.
        /// </summary>
        /// <param name="id">The video id</param>
        /// <param name="userId">The user id</param>
        public void AddUserToVideoWhitelist(long? id, IntWrapper userId)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddUserToVideoWhitelist");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{id}/whitelist";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(userId); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddUserToVideoWhitelistStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddUserToVideoWhitelistResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddUserToVideoWhitelistStartTime, "AddUserToVideoWhitelist", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddUserToVideoWhitelistResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddUserToVideoWhitelist: " + response.Error);
            }

            KnetikLogger.LogResponse(mAddUserToVideoWhitelistStartTime, "AddUserToVideoWhitelist", "Response received successfully.");
            if (AddUserToVideoWhitelistComplete != null)
            {
                AddUserToVideoWhitelistComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds a new video in the system 
        /// </summary>
        /// <param name="videoResource">The video object</param>
        public void AddVideo(VideoResource videoResource)
        {
            
            mWebCallEvent.WebPath = "/media/videos";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(videoResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddVideoStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddVideoResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddVideoStartTime, "AddVideo", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddVideoResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddVideo: " + response.Error);
            }

            AddVideoData = (VideoResource) KnetikClient.Deserialize(response.Content, typeof(VideoResource), response.Headers);
            KnetikLogger.LogResponse(mAddVideoStartTime, "AddVideo", string.Format("Response received successfully:\n{0}", AddVideoData));

            if (AddVideoComplete != null)
            {
                AddVideoComplete(response.ResponseCode, AddVideoData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Add a new video comment 
        /// </summary>
        /// <param name="videoId">The video id </param>
        /// <param name="commentResource">The comment object</param>
        public void AddVideoComment(int? videoId, CommentResource commentResource)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling AddVideoComment");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/comments";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(commentResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddVideoCommentStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddVideoCommentResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddVideoCommentStartTime, "AddVideoComment", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddVideoCommentResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddVideoComment: " + response.Error);
            }

            AddVideoCommentData = (CommentResource) KnetikClient.Deserialize(response.Content, typeof(CommentResource), response.Headers);
            KnetikLogger.LogResponse(mAddVideoCommentStartTime, "AddVideoComment", string.Format("Response received successfully:\n{0}", AddVideoCommentData));

            if (AddVideoCommentComplete != null)
            {
                AddVideoCommentComplete(response.ResponseCode, AddVideoCommentData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds a contributor to a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="contributionResource">The contribution object</param>
        public void AddVideoContributor(long? videoId, ContributionResource contributionResource)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling AddVideoContributor");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/contributors";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(contributionResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddVideoContributorStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddVideoContributorResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddVideoContributorStartTime, "AddVideoContributor", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddVideoContributorResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddVideoContributor: " + response.Error);
            }

            KnetikLogger.LogResponse(mAddVideoContributorStartTime, "AddVideoContributor", "Response received successfully.");
            if (AddVideoContributorComplete != null)
            {
                AddVideoContributorComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Add a new flag 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="reason">The flag reason</param>
        public void AddVideoFlag(long? videoId, StringWrapper reason)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling AddVideoFlag");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/moderation";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(reason); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddVideoFlagStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddVideoFlagResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddVideoFlagStartTime, "AddVideoFlag", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddVideoFlagResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddVideoFlag: " + response.Error);
            }

            AddVideoFlagData = (FlagResource) KnetikClient.Deserialize(response.Content, typeof(FlagResource), response.Headers);
            KnetikLogger.LogResponse(mAddVideoFlagStartTime, "AddVideoFlag", string.Format("Response received successfully:\n{0}", AddVideoFlagData));

            if (AddVideoFlagComplete != null)
            {
                AddVideoFlagComplete(response.ResponseCode, AddVideoFlagData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds one or more existing videos as related to this one 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="videoRelationshipResource">The video relationship object </param>
        public void AddVideoRelationships(long? videoId, VideoRelationshipResource videoRelationshipResource)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling AddVideoRelationships");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/related";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(videoRelationshipResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddVideoRelationshipsStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddVideoRelationshipsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddVideoRelationshipsStartTime, "AddVideoRelationships", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddVideoRelationshipsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddVideoRelationships: " + response.Error);
            }

            AddVideoRelationshipsData = (VideoRelationshipResource) KnetikClient.Deserialize(response.Content, typeof(VideoRelationshipResource), response.Headers);
            KnetikLogger.LogResponse(mAddVideoRelationshipsStartTime, "AddVideoRelationships", string.Format("Response received successfully:\n{0}", AddVideoRelationshipsData));

            if (AddVideoRelationshipsComplete != null)
            {
                AddVideoRelationshipsComplete(response.ResponseCode, AddVideoRelationshipsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a video disposition 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="dispositionResource">The disposition object</param>
        public void CreateVideoDisposition(int? videoId, DispositionResource dispositionResource)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling CreateVideoDisposition");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/dispositions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(dispositionResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateVideoDispositionStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateVideoDispositionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateVideoDispositionStartTime, "CreateVideoDisposition", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateVideoDispositionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateVideoDisposition: " + response.Error);
            }

            CreateVideoDispositionData = (DispositionResource) KnetikClient.Deserialize(response.Content, typeof(DispositionResource), response.Headers);
            KnetikLogger.LogResponse(mCreateVideoDispositionStartTime, "CreateVideoDisposition", string.Format("Response received successfully:\n{0}", CreateVideoDispositionData));

            if (CreateVideoDispositionComplete != null)
            {
                CreateVideoDispositionComplete(response.ResponseCode, CreateVideoDispositionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a video template Video Templates define a type of video and the properties they have
        /// </summary>
        /// <param name="videoTemplateResource">The video template resource object</param>
        public void CreateVideoTemplate(TemplateResource videoTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/media/videos/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(videoTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateVideoTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateVideoTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateVideoTemplateStartTime, "CreateVideoTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateVideoTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateVideoTemplate: " + response.Error);
            }

            CreateVideoTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateVideoTemplateStartTime, "CreateVideoTemplate", string.Format("Response received successfully:\n{0}", CreateVideoTemplateData));

            if (CreateVideoTemplateComplete != null)
            {
                CreateVideoTemplateComplete(response.ResponseCode, CreateVideoTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Deletes a video from the system if no resources are attached to it 
        /// </summary>
        /// <param name="id">The video id</param>
        public void DeleteVideo(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteVideo");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{id}";
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
            mDeleteVideoStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteVideoResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteVideoStartTime, "DeleteVideo", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteVideoResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteVideo: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteVideoStartTime, "DeleteVideo", "Response received successfully.");
            if (DeleteVideoComplete != null)
            {
                DeleteVideoComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a video comment 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The comment id</param>
        public void DeleteVideoComment(long? videoId, long? id)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling DeleteVideoComment");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteVideoComment");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/comments/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
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
            mDeleteVideoCommentStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteVideoCommentResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteVideoCommentStartTime, "DeleteVideoComment", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteVideoCommentResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteVideoComment: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteVideoCommentStartTime, "DeleteVideoComment", "Response received successfully.");
            if (DeleteVideoCommentComplete != null)
            {
                DeleteVideoCommentComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a video disposition 
        /// </summary>
        /// <param name="dispositionId">The disposition id</param>
        public void DeleteVideoDisposition(long? dispositionId)
        {
            // verify the required parameter 'dispositionId' is set
            if (dispositionId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'dispositionId' when calling DeleteVideoDisposition");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/dispositions/{disposition_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "disposition_id" + "}", KnetikClient.ParameterToString(dispositionId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteVideoDispositionStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteVideoDispositionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteVideoDispositionStartTime, "DeleteVideoDisposition", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteVideoDispositionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteVideoDisposition: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteVideoDispositionStartTime, "DeleteVideoDisposition", "Response received successfully.");
            if (DeleteVideoDispositionComplete != null)
            {
                DeleteVideoDispositionComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a flag 
        /// </summary>
        /// <param name="videoId">The video id</param>
        public void DeleteVideoFlag(long? videoId)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling DeleteVideoFlag");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/moderation";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteVideoFlagStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteVideoFlagResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteVideoFlagStartTime, "DeleteVideoFlag", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteVideoFlagResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteVideoFlag: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteVideoFlagStartTime, "DeleteVideoFlag", "Response received successfully.");
            if (DeleteVideoFlagComplete != null)
            {
                DeleteVideoFlagComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a video&#39;s relationship 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The relationship id</param>
        public void DeleteVideoRelationship(long? videoId, long? id)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling DeleteVideoRelationship");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteVideoRelationship");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/related/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
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
            mDeleteVideoRelationshipStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteVideoRelationshipResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteVideoRelationshipStartTime, "DeleteVideoRelationship", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteVideoRelationshipResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteVideoRelationship: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteVideoRelationshipStartTime, "DeleteVideoRelationship", "Response received successfully.");
            if (DeleteVideoRelationshipComplete != null)
            {
                DeleteVideoRelationshipComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a video template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteVideoTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteVideoTemplate");
            }
            
            mWebCallEvent.WebPath = "/media/videos/templates/{id}";
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
            mDeleteVideoTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteVideoTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteVideoTemplateStartTime, "DeleteVideoTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteVideoTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteVideoTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteVideoTemplateStartTime, "DeleteVideoTemplate", "Response received successfully.");
            if (DeleteVideoTemplateComplete != null)
            {
                DeleteVideoTemplateComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get user videos 
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="excludeFlagged">Skip videos that have been flagged by the current user</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetUserVideos(int? userId, bool? excludeFlagged, int? size, int? page)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserVideos");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/videos";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (excludeFlagged != null)
            {
                mWebCallEvent.QueryParams["exclude_flagged"] = KnetikClient.ParameterToString(excludeFlagged);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetUserVideosStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetUserVideosResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetUserVideosStartTime, "GetUserVideos", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetUserVideosResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetUserVideos: " + response.Error);
            }

            GetUserVideosData = (PageResourceVideoResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceVideoResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserVideosStartTime, "GetUserVideos", string.Format("Response received successfully:\n{0}", GetUserVideosData));

            if (GetUserVideosComplete != null)
            {
                GetUserVideosComplete(response.ResponseCode, GetUserVideosData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Loads a specific video details 
        /// </summary>
        /// <param name="id">The video id</param>
        public void GetVideo(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetVideo");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{id}";
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
            mGetVideoStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetVideoResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetVideoStartTime, "GetVideo", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetVideoResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetVideo: " + response.Error);
            }

            GetVideoData = (VideoResource) KnetikClient.Deserialize(response.Content, typeof(VideoResource), response.Headers);
            KnetikLogger.LogResponse(mGetVideoStartTime, "GetVideo", string.Format("Response received successfully:\n{0}", GetVideoData));

            if (GetVideoComplete != null)
            {
                GetVideoComplete(response.ResponseCode, GetVideoData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a page of comments for a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetVideoComments(int? videoId, int? size, int? page)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling GetVideoComments");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/comments";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));

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

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetVideoCommentsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetVideoCommentsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetVideoCommentsStartTime, "GetVideoComments", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetVideoCommentsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetVideoComments: " + response.Error);
            }

            GetVideoCommentsData = (PageResourceCommentResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceCommentResource), response.Headers);
            KnetikLogger.LogResponse(mGetVideoCommentsStartTime, "GetVideoComments", string.Format("Response received successfully:\n{0}", GetVideoCommentsData));

            if (GetVideoCommentsComplete != null)
            {
                GetVideoCommentsComplete(response.ResponseCode, GetVideoCommentsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a page of dispositions for a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetVideoDispositions(int? videoId, int? size, int? page)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling GetVideoDispositions");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/dispositions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));

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

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetVideoDispositionsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetVideoDispositionsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetVideoDispositionsStartTime, "GetVideoDispositions", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetVideoDispositionsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetVideoDispositions: " + response.Error);
            }

            GetVideoDispositionsData = (PageResourceDispositionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceDispositionResource), response.Headers);
            KnetikLogger.LogResponse(mGetVideoDispositionsStartTime, "GetVideoDispositions", string.Format("Response received successfully:\n{0}", GetVideoDispositionsData));

            if (GetVideoDispositionsComplete != null)
            {
                GetVideoDispositionsComplete(response.ResponseCode, GetVideoDispositionsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a page of video relationships 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetVideoRelationships(long? videoId, int? size, int? page)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling GetVideoRelationships");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/related";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));

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

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetVideoRelationshipsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetVideoRelationshipsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetVideoRelationshipsStartTime, "GetVideoRelationships", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetVideoRelationshipsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetVideoRelationships: " + response.Error);
            }

            GetVideoRelationshipsData = (PageResourceVideoRelationshipResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceVideoRelationshipResource), response.Headers);
            KnetikLogger.LogResponse(mGetVideoRelationshipsStartTime, "GetVideoRelationships", string.Format("Response received successfully:\n{0}", GetVideoRelationshipsData));

            if (GetVideoRelationshipsComplete != null)
            {
                GetVideoRelationshipsComplete(response.ResponseCode, GetVideoRelationshipsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single video template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetVideoTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetVideoTemplate");
            }
            
            mWebCallEvent.WebPath = "/media/videos/templates/{id}";
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
            mGetVideoTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetVideoTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetVideoTemplateStartTime, "GetVideoTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetVideoTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetVideoTemplate: " + response.Error);
            }

            GetVideoTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetVideoTemplateStartTime, "GetVideoTemplate", string.Format("Response received successfully:\n{0}", GetVideoTemplateData));

            if (GetVideoTemplateComplete != null)
            {
                GetVideoTemplateComplete(response.ResponseCode, GetVideoTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search video templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetVideoTemplates(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/media/videos/templates";
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
            mGetVideoTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetVideoTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetVideoTemplatesStartTime, "GetVideoTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetVideoTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetVideoTemplates: " + response.Error);
            }

            GetVideoTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetVideoTemplatesStartTime, "GetVideoTemplates", string.Format("Response received successfully:\n{0}", GetVideoTemplatesData));

            if (GetVideoTemplatesComplete != null)
            {
                GetVideoTemplatesComplete(response.ResponseCode, GetVideoTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Search videos using the documented filters 
        /// </summary>
        /// <param name="excludeFlagged">Skip videos that have been flagged by the current user</param>
        /// <param name="filterVideosByUploader">Filter for videos by uploader id</param>
        /// <param name="filterCategory">Filter for videos from a specific category by id</param>
        /// <param name="filterTagset">Filter for videos with specified tags (separated by comma)</param>
        /// <param name="filterVideosByName">Filter for videos which name *STARTS* with the given string</param>
        /// <param name="filterVideosByContributor">Filter for videos with contribution from the artist specified by ID</param>
        /// <param name="filterVideosByAuthor">Filter for videos with an artist as author specified by ID</param>
        /// <param name="filterHasAuthor">Filter for videos that have an author set if true, or that have no author if false</param>
        /// <param name="filterHasUploader">Filter for videos that have an uploader set if true, or that have no uploader if false</param>
        /// <param name="filterRelatedTo">Filter for videos that have designated a particular video as the TO of a relationship. Pattern should match VIDEO_ID or VIDEO_ID:DETAILS to match with a specific details string as well</param>
        /// <param name="filterFriends">Filter for videos uploaded by friends. &#39;true&#39; for friends of the caller (requires user token) or a user id for a specific user&#39;s friends (requires VIDEOS_ADMIN permission)</param>
        /// <param name="filterDisposition">Filter for videos a given user has a given disposition towards. USER_ID:DISPOSITION where USER_ID is the id of the user who has this disposition or &#39;me&#39; for the caller (requires user token for &#39;me&#39;) and DISPOSITION is the name of the disposition. E.G. filter_disposition&#x3D;123:like or filter_disposition&#x3D;me:favorite</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetVideos(bool? excludeFlagged, int? filterVideosByUploader, string filterCategory, string filterTagset, string filterVideosByName, int? filterVideosByContributor, int? filterVideosByAuthor, bool? filterHasAuthor, bool? filterHasUploader, string filterRelatedTo, bool? filterFriends, string filterDisposition, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/media/videos";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (excludeFlagged != null)
            {
                mWebCallEvent.QueryParams["exclude_flagged"] = KnetikClient.ParameterToString(excludeFlagged);
            }

            if (filterVideosByUploader != null)
            {
                mWebCallEvent.QueryParams["filter_videos_by_uploader"] = KnetikClient.ParameterToString(filterVideosByUploader);
            }

            if (filterCategory != null)
            {
                mWebCallEvent.QueryParams["filter_category"] = KnetikClient.ParameterToString(filterCategory);
            }

            if (filterTagset != null)
            {
                mWebCallEvent.QueryParams["filter_tagset"] = KnetikClient.ParameterToString(filterTagset);
            }

            if (filterVideosByName != null)
            {
                mWebCallEvent.QueryParams["filter_videos_by_name"] = KnetikClient.ParameterToString(filterVideosByName);
            }

            if (filterVideosByContributor != null)
            {
                mWebCallEvent.QueryParams["filter_videos_by_contributor"] = KnetikClient.ParameterToString(filterVideosByContributor);
            }

            if (filterVideosByAuthor != null)
            {
                mWebCallEvent.QueryParams["filter_videos_by_author"] = KnetikClient.ParameterToString(filterVideosByAuthor);
            }

            if (filterHasAuthor != null)
            {
                mWebCallEvent.QueryParams["filter_has_author"] = KnetikClient.ParameterToString(filterHasAuthor);
            }

            if (filterHasUploader != null)
            {
                mWebCallEvent.QueryParams["filter_has_uploader"] = KnetikClient.ParameterToString(filterHasUploader);
            }

            if (filterRelatedTo != null)
            {
                mWebCallEvent.QueryParams["filter_related_to"] = KnetikClient.ParameterToString(filterRelatedTo);
            }

            if (filterFriends != null)
            {
                mWebCallEvent.QueryParams["filter_friends"] = KnetikClient.ParameterToString(filterFriends);
            }

            if (filterDisposition != null)
            {
                mWebCallEvent.QueryParams["filter_disposition"] = KnetikClient.ParameterToString(filterDisposition);
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
            mGetVideosStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetVideosResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetVideosStartTime, "GetVideos", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetVideosResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetVideos: " + response.Error);
            }

            GetVideosData = (PageResourceVideoResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceVideoResource), response.Headers);
            KnetikLogger.LogResponse(mGetVideosStartTime, "GetVideos", string.Format("Response received successfully:\n{0}", GetVideosData));

            if (GetVideosComplete != null)
            {
                GetVideosComplete(response.ResponseCode, GetVideosData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Removes a user from a video&#39;s whitelist Remove the user with the id given in the path from the whitelist of users that can view this video regardless of privacy setting.
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The user id</param>
        public void RemoveUserFromVideoWhitelist(long? videoId, int? id)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling RemoveUserFromVideoWhitelist");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling RemoveUserFromVideoWhitelist");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/whitelist/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
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
            mRemoveUserFromVideoWhitelistStartTime = DateTime.Now;
            mWebCallEvent.Context = mRemoveUserFromVideoWhitelistResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mRemoveUserFromVideoWhitelistStartTime, "RemoveUserFromVideoWhitelist", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnRemoveUserFromVideoWhitelistResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling RemoveUserFromVideoWhitelist: " + response.Error);
            }

            KnetikLogger.LogResponse(mRemoveUserFromVideoWhitelistStartTime, "RemoveUserFromVideoWhitelist", "Response received successfully.");
            if (RemoveUserFromVideoWhitelistComplete != null)
            {
                RemoveUserFromVideoWhitelistComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Removes a contributor from a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The contributor id</param>
        public void RemoveVideoContributor(long? videoId, int? id)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling RemoveVideoContributor");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling RemoveVideoContributor");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/contributors/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
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
            mRemoveVideoContributorStartTime = DateTime.Now;
            mWebCallEvent.Context = mRemoveVideoContributorResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mRemoveVideoContributorStartTime, "RemoveVideoContributor", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnRemoveVideoContributorResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling RemoveVideoContributor: " + response.Error);
            }

            KnetikLogger.LogResponse(mRemoveVideoContributorStartTime, "RemoveVideoContributor", "Response received successfully.");
            if (RemoveVideoContributorComplete != null)
            {
                RemoveVideoContributorComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Modifies a video&#39;s details 
        /// </summary>
        /// <param name="id">The video id</param>
        /// <param name="videoResource">The video object</param>
        public void UpdateVideo(long? id, VideoResource videoResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateVideo");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(videoResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateVideoStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateVideoResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateVideoStartTime, "UpdateVideo", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateVideoResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateVideo: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateVideoStartTime, "UpdateVideo", "Response received successfully.");
            if (UpdateVideoComplete != null)
            {
                UpdateVideoComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a video comment 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The comment id</param>
        /// <param name="content">The comment content</param>
        public void UpdateVideoComment(long? videoId, long? id, StringWrapper content)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling UpdateVideoComment");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateVideoComment");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/comments/{id}/content";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(content); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateVideoCommentStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateVideoCommentResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateVideoCommentStartTime, "UpdateVideoComment", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateVideoCommentResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateVideoComment: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateVideoCommentStartTime, "UpdateVideoComment", "Response received successfully.");
            if (UpdateVideoCommentComplete != null)
            {
                UpdateVideoCommentComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a video&#39;s relationship details 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="relationshipId">The relationship id</param>
        /// <param name="details">The video relationship details</param>
        public void UpdateVideoRelationship(long? videoId, long? relationshipId, StringWrapper details)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling UpdateVideoRelationship");
            }
            // verify the required parameter 'relationshipId' is set
            if (relationshipId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'relationshipId' when calling UpdateVideoRelationship");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{video_id}/related/{id}/relationship_details";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "relationship_id" + "}", KnetikClient.ParameterToString(relationshipId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(details); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateVideoRelationshipStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateVideoRelationshipResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateVideoRelationshipStartTime, "UpdateVideoRelationship", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateVideoRelationshipResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateVideoRelationship: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateVideoRelationshipStartTime, "UpdateVideoRelationship", "Response received successfully.");
            if (UpdateVideoRelationshipComplete != null)
            {
                UpdateVideoRelationshipComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a video template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="videoTemplateResource">The video template resource object</param>
        public void UpdateVideoTemplate(string id, TemplateResource videoTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateVideoTemplate");
            }
            
            mWebCallEvent.WebPath = "/media/videos/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(videoTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateVideoTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateVideoTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateVideoTemplateStartTime, "UpdateVideoTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateVideoTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateVideoTemplate: " + response.Error);
            }

            UpdateVideoTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateVideoTemplateStartTime, "UpdateVideoTemplate", string.Format("Response received successfully:\n{0}", UpdateVideoTemplateData));

            if (UpdateVideoTemplateComplete != null)
            {
                UpdateVideoTemplateComplete(response.ResponseCode, UpdateVideoTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Increment a video&#39;s view count 
        /// </summary>
        /// <param name="id">The video id</param>
        public void ViewVideo(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling ViewVideo");
            }
            
            mWebCallEvent.WebPath = "/media/videos/{id}/views";
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
            mViewVideoStartTime = DateTime.Now;
            mWebCallEvent.Context = mViewVideoResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mViewVideoStartTime, "ViewVideo", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnViewVideoResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling ViewVideo: " + response.Error);
            }

            KnetikLogger.LogResponse(mViewVideoStartTime, "ViewVideo", "Response received successfully.");
            if (ViewVideoComplete != null)
            {
                ViewVideoComplete(response.ResponseCode);
            }
        }

    }
}
