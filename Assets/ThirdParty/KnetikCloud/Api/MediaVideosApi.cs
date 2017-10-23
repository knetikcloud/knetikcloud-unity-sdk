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
    public interface IMediaVideosApi
    {
        VideoResource AddVideoData { get; }

        CommentResource AddVideoCommentData { get; }

        FlagResource AddVideoFlagData { get; }

        VideoRelationshipResource AddVideoRelationshipsData { get; }

        DispositionResource CreateVideoDispositionData { get; }

        PageResourceVideoResource GetUserVideosData { get; }

        VideoResource GetVideoData { get; }

        PageResourceCommentResource GetVideoCommentsData { get; }

        PageResourceDispositionResource GetVideoDispositionsData { get; }

        PageResourceVideoRelationshipResource GetVideoRelationshipsData { get; }

        PageResourceVideoResource GetVideosData { get; }

        
        /// <summary>
        /// Adds a user to a video&#39;s whitelist Whitelisted users can view video regardless of privacy setting.
        /// </summary>
        /// <param name="id">The video id</param>
        /// <param name="userId">The user id</param>
        void AddUserToVideoWhitelist(long? id, IntWrapper userId);

        /// <summary>
        /// Adds a new video in the system 
        /// </summary>
        /// <param name="videoResource">The video object</param>
        void AddVideo(VideoResource videoResource);

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

        /// <summary>
        /// Add a new flag 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="reason">The flag reason</param>
        void AddVideoFlag(long? videoId, StringWrapper reason);

        /// <summary>
        /// Adds one or more existing videos as related to this one 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="videoRelationshipResource">The video relationship object </param>
        void AddVideoRelationships(long? videoId, VideoRelationshipResource videoRelationshipResource);

        /// <summary>
        /// Create a video disposition 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="dispositionResource">The disposition object</param>
        void CreateVideoDisposition(int? videoId, DispositionResource dispositionResource);

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
        /// Get user videos 
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="excludeFlagged">Skip videos that have been flagged by the current user</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetUserVideos(int? userId, bool? excludeFlagged, int? size, int? page);

        /// <summary>
        /// Loads a specific video details 
        /// </summary>
        /// <param name="id">The video id</param>
        void GetVideo(long? id);

        /// <summary>
        /// Returns a page of comments for a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetVideoComments(int? videoId, int? size, int? page);

        /// <summary>
        /// Returns a page of dispositions for a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetVideoDispositions(int? videoId, int? size, int? page);

        /// <summary>
        /// Returns a page of video relationships 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetVideoRelationships(long? videoId, int? size, int? page);

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
        private readonly KnetikCoroutine mAddUserToVideoWhitelistCoroutine;
        private DateTime mAddUserToVideoWhitelistStartTime;
        private string mAddUserToVideoWhitelistPath;
        private readonly KnetikCoroutine mAddVideoCoroutine;
        private DateTime mAddVideoStartTime;
        private string mAddVideoPath;
        private readonly KnetikCoroutine mAddVideoCommentCoroutine;
        private DateTime mAddVideoCommentStartTime;
        private string mAddVideoCommentPath;
        private readonly KnetikCoroutine mAddVideoContributorCoroutine;
        private DateTime mAddVideoContributorStartTime;
        private string mAddVideoContributorPath;
        private readonly KnetikCoroutine mAddVideoFlagCoroutine;
        private DateTime mAddVideoFlagStartTime;
        private string mAddVideoFlagPath;
        private readonly KnetikCoroutine mAddVideoRelationshipsCoroutine;
        private DateTime mAddVideoRelationshipsStartTime;
        private string mAddVideoRelationshipsPath;
        private readonly KnetikCoroutine mCreateVideoDispositionCoroutine;
        private DateTime mCreateVideoDispositionStartTime;
        private string mCreateVideoDispositionPath;
        private readonly KnetikCoroutine mDeleteVideoCoroutine;
        private DateTime mDeleteVideoStartTime;
        private string mDeleteVideoPath;
        private readonly KnetikCoroutine mDeleteVideoCommentCoroutine;
        private DateTime mDeleteVideoCommentStartTime;
        private string mDeleteVideoCommentPath;
        private readonly KnetikCoroutine mDeleteVideoDispositionCoroutine;
        private DateTime mDeleteVideoDispositionStartTime;
        private string mDeleteVideoDispositionPath;
        private readonly KnetikCoroutine mDeleteVideoFlagCoroutine;
        private DateTime mDeleteVideoFlagStartTime;
        private string mDeleteVideoFlagPath;
        private readonly KnetikCoroutine mDeleteVideoRelationshipCoroutine;
        private DateTime mDeleteVideoRelationshipStartTime;
        private string mDeleteVideoRelationshipPath;
        private readonly KnetikCoroutine mGetUserVideosCoroutine;
        private DateTime mGetUserVideosStartTime;
        private string mGetUserVideosPath;
        private readonly KnetikCoroutine mGetVideoCoroutine;
        private DateTime mGetVideoStartTime;
        private string mGetVideoPath;
        private readonly KnetikCoroutine mGetVideoCommentsCoroutine;
        private DateTime mGetVideoCommentsStartTime;
        private string mGetVideoCommentsPath;
        private readonly KnetikCoroutine mGetVideoDispositionsCoroutine;
        private DateTime mGetVideoDispositionsStartTime;
        private string mGetVideoDispositionsPath;
        private readonly KnetikCoroutine mGetVideoRelationshipsCoroutine;
        private DateTime mGetVideoRelationshipsStartTime;
        private string mGetVideoRelationshipsPath;
        private readonly KnetikCoroutine mGetVideosCoroutine;
        private DateTime mGetVideosStartTime;
        private string mGetVideosPath;
        private readonly KnetikCoroutine mRemoveUserFromVideoWhitelistCoroutine;
        private DateTime mRemoveUserFromVideoWhitelistStartTime;
        private string mRemoveUserFromVideoWhitelistPath;
        private readonly KnetikCoroutine mRemoveVideoContributorCoroutine;
        private DateTime mRemoveVideoContributorStartTime;
        private string mRemoveVideoContributorPath;
        private readonly KnetikCoroutine mUpdateVideoCoroutine;
        private DateTime mUpdateVideoStartTime;
        private string mUpdateVideoPath;
        private readonly KnetikCoroutine mUpdateVideoCommentCoroutine;
        private DateTime mUpdateVideoCommentStartTime;
        private string mUpdateVideoCommentPath;
        private readonly KnetikCoroutine mUpdateVideoRelationshipCoroutine;
        private DateTime mUpdateVideoRelationshipStartTime;
        private string mUpdateVideoRelationshipPath;
        private readonly KnetikCoroutine mViewVideoCoroutine;
        private DateTime mViewVideoStartTime;
        private string mViewVideoPath;

        public delegate void AddUserToVideoWhitelistCompleteDelegate();
        public AddUserToVideoWhitelistCompleteDelegate AddUserToVideoWhitelistComplete;

        public VideoResource AddVideoData { get; private set; }
        public delegate void AddVideoCompleteDelegate(VideoResource response);
        public AddVideoCompleteDelegate AddVideoComplete;

        public CommentResource AddVideoCommentData { get; private set; }
        public delegate void AddVideoCommentCompleteDelegate(CommentResource response);
        public AddVideoCommentCompleteDelegate AddVideoCommentComplete;

        public delegate void AddVideoContributorCompleteDelegate();
        public AddVideoContributorCompleteDelegate AddVideoContributorComplete;

        public FlagResource AddVideoFlagData { get; private set; }
        public delegate void AddVideoFlagCompleteDelegate(FlagResource response);
        public AddVideoFlagCompleteDelegate AddVideoFlagComplete;

        public VideoRelationshipResource AddVideoRelationshipsData { get; private set; }
        public delegate void AddVideoRelationshipsCompleteDelegate(VideoRelationshipResource response);
        public AddVideoRelationshipsCompleteDelegate AddVideoRelationshipsComplete;

        public DispositionResource CreateVideoDispositionData { get; private set; }
        public delegate void CreateVideoDispositionCompleteDelegate(DispositionResource response);
        public CreateVideoDispositionCompleteDelegate CreateVideoDispositionComplete;

        public delegate void DeleteVideoCompleteDelegate();
        public DeleteVideoCompleteDelegate DeleteVideoComplete;

        public delegate void DeleteVideoCommentCompleteDelegate();
        public DeleteVideoCommentCompleteDelegate DeleteVideoCommentComplete;

        public delegate void DeleteVideoDispositionCompleteDelegate();
        public DeleteVideoDispositionCompleteDelegate DeleteVideoDispositionComplete;

        public delegate void DeleteVideoFlagCompleteDelegate();
        public DeleteVideoFlagCompleteDelegate DeleteVideoFlagComplete;

        public delegate void DeleteVideoRelationshipCompleteDelegate();
        public DeleteVideoRelationshipCompleteDelegate DeleteVideoRelationshipComplete;

        public PageResourceVideoResource GetUserVideosData { get; private set; }
        public delegate void GetUserVideosCompleteDelegate(PageResourceVideoResource response);
        public GetUserVideosCompleteDelegate GetUserVideosComplete;

        public VideoResource GetVideoData { get; private set; }
        public delegate void GetVideoCompleteDelegate(VideoResource response);
        public GetVideoCompleteDelegate GetVideoComplete;

        public PageResourceCommentResource GetVideoCommentsData { get; private set; }
        public delegate void GetVideoCommentsCompleteDelegate(PageResourceCommentResource response);
        public GetVideoCommentsCompleteDelegate GetVideoCommentsComplete;

        public PageResourceDispositionResource GetVideoDispositionsData { get; private set; }
        public delegate void GetVideoDispositionsCompleteDelegate(PageResourceDispositionResource response);
        public GetVideoDispositionsCompleteDelegate GetVideoDispositionsComplete;

        public PageResourceVideoRelationshipResource GetVideoRelationshipsData { get; private set; }
        public delegate void GetVideoRelationshipsCompleteDelegate(PageResourceVideoRelationshipResource response);
        public GetVideoRelationshipsCompleteDelegate GetVideoRelationshipsComplete;

        public PageResourceVideoResource GetVideosData { get; private set; }
        public delegate void GetVideosCompleteDelegate(PageResourceVideoResource response);
        public GetVideosCompleteDelegate GetVideosComplete;

        public delegate void RemoveUserFromVideoWhitelistCompleteDelegate();
        public RemoveUserFromVideoWhitelistCompleteDelegate RemoveUserFromVideoWhitelistComplete;

        public delegate void RemoveVideoContributorCompleteDelegate();
        public RemoveVideoContributorCompleteDelegate RemoveVideoContributorComplete;

        public delegate void UpdateVideoCompleteDelegate();
        public UpdateVideoCompleteDelegate UpdateVideoComplete;

        public delegate void UpdateVideoCommentCompleteDelegate();
        public UpdateVideoCommentCompleteDelegate UpdateVideoCommentComplete;

        public delegate void UpdateVideoRelationshipCompleteDelegate();
        public UpdateVideoRelationshipCompleteDelegate UpdateVideoRelationshipComplete;

        public delegate void ViewVideoCompleteDelegate();
        public ViewVideoCompleteDelegate ViewVideoComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaVideosApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MediaVideosApi()
        {
            mAddUserToVideoWhitelistCoroutine = new KnetikCoroutine();
            mAddVideoCoroutine = new KnetikCoroutine();
            mAddVideoCommentCoroutine = new KnetikCoroutine();
            mAddVideoContributorCoroutine = new KnetikCoroutine();
            mAddVideoFlagCoroutine = new KnetikCoroutine();
            mAddVideoRelationshipsCoroutine = new KnetikCoroutine();
            mCreateVideoDispositionCoroutine = new KnetikCoroutine();
            mDeleteVideoCoroutine = new KnetikCoroutine();
            mDeleteVideoCommentCoroutine = new KnetikCoroutine();
            mDeleteVideoDispositionCoroutine = new KnetikCoroutine();
            mDeleteVideoFlagCoroutine = new KnetikCoroutine();
            mDeleteVideoRelationshipCoroutine = new KnetikCoroutine();
            mGetUserVideosCoroutine = new KnetikCoroutine();
            mGetVideoCoroutine = new KnetikCoroutine();
            mGetVideoCommentsCoroutine = new KnetikCoroutine();
            mGetVideoDispositionsCoroutine = new KnetikCoroutine();
            mGetVideoRelationshipsCoroutine = new KnetikCoroutine();
            mGetVideosCoroutine = new KnetikCoroutine();
            mRemoveUserFromVideoWhitelistCoroutine = new KnetikCoroutine();
            mRemoveVideoContributorCoroutine = new KnetikCoroutine();
            mUpdateVideoCoroutine = new KnetikCoroutine();
            mUpdateVideoCommentCoroutine = new KnetikCoroutine();
            mUpdateVideoRelationshipCoroutine = new KnetikCoroutine();
            mViewVideoCoroutine = new KnetikCoroutine();
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
            
            mAddUserToVideoWhitelistPath = "/media/videos/{id}/whitelist";
            if (!string.IsNullOrEmpty(mAddUserToVideoWhitelistPath))
            {
                mAddUserToVideoWhitelistPath = mAddUserToVideoWhitelistPath.Replace("{format}", "json");
            }
            mAddUserToVideoWhitelistPath = mAddUserToVideoWhitelistPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(userId); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddUserToVideoWhitelistStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddUserToVideoWhitelistStartTime, mAddUserToVideoWhitelistPath, "Sending server request...");

            // make the HTTP request
            mAddUserToVideoWhitelistCoroutine.ResponseReceived += AddUserToVideoWhitelistCallback;
            mAddUserToVideoWhitelistCoroutine.Start(mAddUserToVideoWhitelistPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddUserToVideoWhitelistCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddUserToVideoWhitelist: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddUserToVideoWhitelist: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mAddUserToVideoWhitelistStartTime, mAddUserToVideoWhitelistPath, "Response received successfully.");
            if (AddUserToVideoWhitelistComplete != null)
            {
                AddUserToVideoWhitelistComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds a new video in the system 
        /// </summary>
        /// <param name="videoResource">The video object</param>
        public void AddVideo(VideoResource videoResource)
        {
            
            mAddVideoPath = "/media/videos";
            if (!string.IsNullOrEmpty(mAddVideoPath))
            {
                mAddVideoPath = mAddVideoPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(videoResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddVideoStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddVideoStartTime, mAddVideoPath, "Sending server request...");

            // make the HTTP request
            mAddVideoCoroutine.ResponseReceived += AddVideoCallback;
            mAddVideoCoroutine.Start(mAddVideoPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddVideoCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddVideo: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddVideo: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddVideoData = (VideoResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(VideoResource), response.Headers);
            KnetikLogger.LogResponse(mAddVideoStartTime, mAddVideoPath, string.Format("Response received successfully:\n{0}", AddVideoData.ToString()));

            if (AddVideoComplete != null)
            {
                AddVideoComplete(AddVideoData);
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
            
            mAddVideoCommentPath = "/media/videos/{video_id}/comments";
            if (!string.IsNullOrEmpty(mAddVideoCommentPath))
            {
                mAddVideoCommentPath = mAddVideoCommentPath.Replace("{format}", "json");
            }
            mAddVideoCommentPath = mAddVideoCommentPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(commentResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddVideoCommentStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddVideoCommentStartTime, mAddVideoCommentPath, "Sending server request...");

            // make the HTTP request
            mAddVideoCommentCoroutine.ResponseReceived += AddVideoCommentCallback;
            mAddVideoCommentCoroutine.Start(mAddVideoCommentPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddVideoCommentCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddVideoComment: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddVideoComment: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddVideoCommentData = (CommentResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(CommentResource), response.Headers);
            KnetikLogger.LogResponse(mAddVideoCommentStartTime, mAddVideoCommentPath, string.Format("Response received successfully:\n{0}", AddVideoCommentData.ToString()));

            if (AddVideoCommentComplete != null)
            {
                AddVideoCommentComplete(AddVideoCommentData);
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
            
            mAddVideoContributorPath = "/media/videos/{video_id}/contributors";
            if (!string.IsNullOrEmpty(mAddVideoContributorPath))
            {
                mAddVideoContributorPath = mAddVideoContributorPath.Replace("{format}", "json");
            }
            mAddVideoContributorPath = mAddVideoContributorPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(contributionResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddVideoContributorStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddVideoContributorStartTime, mAddVideoContributorPath, "Sending server request...");

            // make the HTTP request
            mAddVideoContributorCoroutine.ResponseReceived += AddVideoContributorCallback;
            mAddVideoContributorCoroutine.Start(mAddVideoContributorPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddVideoContributorCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddVideoContributor: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddVideoContributor: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mAddVideoContributorStartTime, mAddVideoContributorPath, "Response received successfully.");
            if (AddVideoContributorComplete != null)
            {
                AddVideoContributorComplete();
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
            
            mAddVideoFlagPath = "/media/videos/{video_id}/moderation";
            if (!string.IsNullOrEmpty(mAddVideoFlagPath))
            {
                mAddVideoFlagPath = mAddVideoFlagPath.Replace("{format}", "json");
            }
            mAddVideoFlagPath = mAddVideoFlagPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(reason); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddVideoFlagStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddVideoFlagStartTime, mAddVideoFlagPath, "Sending server request...");

            // make the HTTP request
            mAddVideoFlagCoroutine.ResponseReceived += AddVideoFlagCallback;
            mAddVideoFlagCoroutine.Start(mAddVideoFlagPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddVideoFlagCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddVideoFlag: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddVideoFlag: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddVideoFlagData = (FlagResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(FlagResource), response.Headers);
            KnetikLogger.LogResponse(mAddVideoFlagStartTime, mAddVideoFlagPath, string.Format("Response received successfully:\n{0}", AddVideoFlagData.ToString()));

            if (AddVideoFlagComplete != null)
            {
                AddVideoFlagComplete(AddVideoFlagData);
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
            
            mAddVideoRelationshipsPath = "/media/videos/{video_id}/related";
            if (!string.IsNullOrEmpty(mAddVideoRelationshipsPath))
            {
                mAddVideoRelationshipsPath = mAddVideoRelationshipsPath.Replace("{format}", "json");
            }
            mAddVideoRelationshipsPath = mAddVideoRelationshipsPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(videoRelationshipResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddVideoRelationshipsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddVideoRelationshipsStartTime, mAddVideoRelationshipsPath, "Sending server request...");

            // make the HTTP request
            mAddVideoRelationshipsCoroutine.ResponseReceived += AddVideoRelationshipsCallback;
            mAddVideoRelationshipsCoroutine.Start(mAddVideoRelationshipsPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddVideoRelationshipsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddVideoRelationships: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddVideoRelationships: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddVideoRelationshipsData = (VideoRelationshipResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(VideoRelationshipResource), response.Headers);
            KnetikLogger.LogResponse(mAddVideoRelationshipsStartTime, mAddVideoRelationshipsPath, string.Format("Response received successfully:\n{0}", AddVideoRelationshipsData.ToString()));

            if (AddVideoRelationshipsComplete != null)
            {
                AddVideoRelationshipsComplete(AddVideoRelationshipsData);
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
            
            mCreateVideoDispositionPath = "/media/videos/{video_id}/dispositions";
            if (!string.IsNullOrEmpty(mCreateVideoDispositionPath))
            {
                mCreateVideoDispositionPath = mCreateVideoDispositionPath.Replace("{format}", "json");
            }
            mCreateVideoDispositionPath = mCreateVideoDispositionPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(dispositionResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateVideoDispositionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateVideoDispositionStartTime, mCreateVideoDispositionPath, "Sending server request...");

            // make the HTTP request
            mCreateVideoDispositionCoroutine.ResponseReceived += CreateVideoDispositionCallback;
            mCreateVideoDispositionCoroutine.Start(mCreateVideoDispositionPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateVideoDispositionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateVideoDisposition: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateVideoDisposition: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateVideoDispositionData = (DispositionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(DispositionResource), response.Headers);
            KnetikLogger.LogResponse(mCreateVideoDispositionStartTime, mCreateVideoDispositionPath, string.Format("Response received successfully:\n{0}", CreateVideoDispositionData.ToString()));

            if (CreateVideoDispositionComplete != null)
            {
                CreateVideoDispositionComplete(CreateVideoDispositionData);
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
            
            mDeleteVideoPath = "/media/videos/{id}";
            if (!string.IsNullOrEmpty(mDeleteVideoPath))
            {
                mDeleteVideoPath = mDeleteVideoPath.Replace("{format}", "json");
            }
            mDeleteVideoPath = mDeleteVideoPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteVideoStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteVideoStartTime, mDeleteVideoPath, "Sending server request...");

            // make the HTTP request
            mDeleteVideoCoroutine.ResponseReceived += DeleteVideoCallback;
            mDeleteVideoCoroutine.Start(mDeleteVideoPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteVideoCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVideo: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVideo: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteVideoStartTime, mDeleteVideoPath, "Response received successfully.");
            if (DeleteVideoComplete != null)
            {
                DeleteVideoComplete();
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
            
            mDeleteVideoCommentPath = "/media/videos/{video_id}/comments/{id}";
            if (!string.IsNullOrEmpty(mDeleteVideoCommentPath))
            {
                mDeleteVideoCommentPath = mDeleteVideoCommentPath.Replace("{format}", "json");
            }
            mDeleteVideoCommentPath = mDeleteVideoCommentPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));
mDeleteVideoCommentPath = mDeleteVideoCommentPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteVideoCommentStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteVideoCommentStartTime, mDeleteVideoCommentPath, "Sending server request...");

            // make the HTTP request
            mDeleteVideoCommentCoroutine.ResponseReceived += DeleteVideoCommentCallback;
            mDeleteVideoCommentCoroutine.Start(mDeleteVideoCommentPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteVideoCommentCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVideoComment: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVideoComment: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteVideoCommentStartTime, mDeleteVideoCommentPath, "Response received successfully.");
            if (DeleteVideoCommentComplete != null)
            {
                DeleteVideoCommentComplete();
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
            
            mDeleteVideoDispositionPath = "/media/videos/{video_id}/dispositions/{disposition_id}";
            if (!string.IsNullOrEmpty(mDeleteVideoDispositionPath))
            {
                mDeleteVideoDispositionPath = mDeleteVideoDispositionPath.Replace("{format}", "json");
            }
            mDeleteVideoDispositionPath = mDeleteVideoDispositionPath.Replace("{" + "disposition_id" + "}", KnetikClient.DefaultClient.ParameterToString(dispositionId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteVideoDispositionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteVideoDispositionStartTime, mDeleteVideoDispositionPath, "Sending server request...");

            // make the HTTP request
            mDeleteVideoDispositionCoroutine.ResponseReceived += DeleteVideoDispositionCallback;
            mDeleteVideoDispositionCoroutine.Start(mDeleteVideoDispositionPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteVideoDispositionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVideoDisposition: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVideoDisposition: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteVideoDispositionStartTime, mDeleteVideoDispositionPath, "Response received successfully.");
            if (DeleteVideoDispositionComplete != null)
            {
                DeleteVideoDispositionComplete();
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
            
            mDeleteVideoFlagPath = "/media/videos/{video_id}/moderation";
            if (!string.IsNullOrEmpty(mDeleteVideoFlagPath))
            {
                mDeleteVideoFlagPath = mDeleteVideoFlagPath.Replace("{format}", "json");
            }
            mDeleteVideoFlagPath = mDeleteVideoFlagPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteVideoFlagStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteVideoFlagStartTime, mDeleteVideoFlagPath, "Sending server request...");

            // make the HTTP request
            mDeleteVideoFlagCoroutine.ResponseReceived += DeleteVideoFlagCallback;
            mDeleteVideoFlagCoroutine.Start(mDeleteVideoFlagPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteVideoFlagCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVideoFlag: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVideoFlag: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteVideoFlagStartTime, mDeleteVideoFlagPath, "Response received successfully.");
            if (DeleteVideoFlagComplete != null)
            {
                DeleteVideoFlagComplete();
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
            
            mDeleteVideoRelationshipPath = "/media/videos/{video_id}/related/{id}";
            if (!string.IsNullOrEmpty(mDeleteVideoRelationshipPath))
            {
                mDeleteVideoRelationshipPath = mDeleteVideoRelationshipPath.Replace("{format}", "json");
            }
            mDeleteVideoRelationshipPath = mDeleteVideoRelationshipPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));
mDeleteVideoRelationshipPath = mDeleteVideoRelationshipPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteVideoRelationshipStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteVideoRelationshipStartTime, mDeleteVideoRelationshipPath, "Sending server request...");

            // make the HTTP request
            mDeleteVideoRelationshipCoroutine.ResponseReceived += DeleteVideoRelationshipCallback;
            mDeleteVideoRelationshipCoroutine.Start(mDeleteVideoRelationshipPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteVideoRelationshipCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVideoRelationship: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteVideoRelationship: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteVideoRelationshipStartTime, mDeleteVideoRelationshipPath, "Response received successfully.");
            if (DeleteVideoRelationshipComplete != null)
            {
                DeleteVideoRelationshipComplete();
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
            
            mGetUserVideosPath = "/users/{user_id}/videos";
            if (!string.IsNullOrEmpty(mGetUserVideosPath))
            {
                mGetUserVideosPath = mGetUserVideosPath.Replace("{format}", "json");
            }
            mGetUserVideosPath = mGetUserVideosPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (excludeFlagged != null)
            {
                queryParams.Add("exclude_flagged", KnetikClient.DefaultClient.ParameterToString(excludeFlagged));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetUserVideosStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetUserVideosStartTime, mGetUserVideosPath, "Sending server request...");

            // make the HTTP request
            mGetUserVideosCoroutine.ResponseReceived += GetUserVideosCallback;
            mGetUserVideosCoroutine.Start(mGetUserVideosPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetUserVideosCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserVideos: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetUserVideos: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetUserVideosData = (PageResourceVideoResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceVideoResource), response.Headers);
            KnetikLogger.LogResponse(mGetUserVideosStartTime, mGetUserVideosPath, string.Format("Response received successfully:\n{0}", GetUserVideosData.ToString()));

            if (GetUserVideosComplete != null)
            {
                GetUserVideosComplete(GetUserVideosData);
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
            
            mGetVideoPath = "/media/videos/{id}";
            if (!string.IsNullOrEmpty(mGetVideoPath))
            {
                mGetVideoPath = mGetVideoPath.Replace("{format}", "json");
            }
            mGetVideoPath = mGetVideoPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetVideoStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetVideoStartTime, mGetVideoPath, "Sending server request...");

            // make the HTTP request
            mGetVideoCoroutine.ResponseReceived += GetVideoCallback;
            mGetVideoCoroutine.Start(mGetVideoPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetVideoCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVideo: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVideo: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetVideoData = (VideoResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(VideoResource), response.Headers);
            KnetikLogger.LogResponse(mGetVideoStartTime, mGetVideoPath, string.Format("Response received successfully:\n{0}", GetVideoData.ToString()));

            if (GetVideoComplete != null)
            {
                GetVideoComplete(GetVideoData);
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
            
            mGetVideoCommentsPath = "/media/videos/{video_id}/comments";
            if (!string.IsNullOrEmpty(mGetVideoCommentsPath))
            {
                mGetVideoCommentsPath = mGetVideoCommentsPath.Replace("{format}", "json");
            }
            mGetVideoCommentsPath = mGetVideoCommentsPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));

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

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetVideoCommentsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetVideoCommentsStartTime, mGetVideoCommentsPath, "Sending server request...");

            // make the HTTP request
            mGetVideoCommentsCoroutine.ResponseReceived += GetVideoCommentsCallback;
            mGetVideoCommentsCoroutine.Start(mGetVideoCommentsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetVideoCommentsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVideoComments: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVideoComments: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetVideoCommentsData = (PageResourceCommentResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceCommentResource), response.Headers);
            KnetikLogger.LogResponse(mGetVideoCommentsStartTime, mGetVideoCommentsPath, string.Format("Response received successfully:\n{0}", GetVideoCommentsData.ToString()));

            if (GetVideoCommentsComplete != null)
            {
                GetVideoCommentsComplete(GetVideoCommentsData);
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
            
            mGetVideoDispositionsPath = "/media/videos/{video_id}/dispositions";
            if (!string.IsNullOrEmpty(mGetVideoDispositionsPath))
            {
                mGetVideoDispositionsPath = mGetVideoDispositionsPath.Replace("{format}", "json");
            }
            mGetVideoDispositionsPath = mGetVideoDispositionsPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));

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

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetVideoDispositionsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetVideoDispositionsStartTime, mGetVideoDispositionsPath, "Sending server request...");

            // make the HTTP request
            mGetVideoDispositionsCoroutine.ResponseReceived += GetVideoDispositionsCallback;
            mGetVideoDispositionsCoroutine.Start(mGetVideoDispositionsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetVideoDispositionsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVideoDispositions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVideoDispositions: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetVideoDispositionsData = (PageResourceDispositionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceDispositionResource), response.Headers);
            KnetikLogger.LogResponse(mGetVideoDispositionsStartTime, mGetVideoDispositionsPath, string.Format("Response received successfully:\n{0}", GetVideoDispositionsData.ToString()));

            if (GetVideoDispositionsComplete != null)
            {
                GetVideoDispositionsComplete(GetVideoDispositionsData);
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
            
            mGetVideoRelationshipsPath = "/media/videos/{video_id}/related";
            if (!string.IsNullOrEmpty(mGetVideoRelationshipsPath))
            {
                mGetVideoRelationshipsPath = mGetVideoRelationshipsPath.Replace("{format}", "json");
            }
            mGetVideoRelationshipsPath = mGetVideoRelationshipsPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));

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

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetVideoRelationshipsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetVideoRelationshipsStartTime, mGetVideoRelationshipsPath, "Sending server request...");

            // make the HTTP request
            mGetVideoRelationshipsCoroutine.ResponseReceived += GetVideoRelationshipsCallback;
            mGetVideoRelationshipsCoroutine.Start(mGetVideoRelationshipsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetVideoRelationshipsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVideoRelationships: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVideoRelationships: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetVideoRelationshipsData = (PageResourceVideoRelationshipResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceVideoRelationshipResource), response.Headers);
            KnetikLogger.LogResponse(mGetVideoRelationshipsStartTime, mGetVideoRelationshipsPath, string.Format("Response received successfully:\n{0}", GetVideoRelationshipsData.ToString()));

            if (GetVideoRelationshipsComplete != null)
            {
                GetVideoRelationshipsComplete(GetVideoRelationshipsData);
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
            
            mGetVideosPath = "/media/videos";
            if (!string.IsNullOrEmpty(mGetVideosPath))
            {
                mGetVideosPath = mGetVideosPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (excludeFlagged != null)
            {
                queryParams.Add("exclude_flagged", KnetikClient.DefaultClient.ParameterToString(excludeFlagged));
            }

            if (filterVideosByUploader != null)
            {
                queryParams.Add("filter_videos_by_uploader", KnetikClient.DefaultClient.ParameterToString(filterVideosByUploader));
            }

            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.DefaultClient.ParameterToString(filterCategory));
            }

            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.DefaultClient.ParameterToString(filterTagset));
            }

            if (filterVideosByName != null)
            {
                queryParams.Add("filter_videos_by_name", KnetikClient.DefaultClient.ParameterToString(filterVideosByName));
            }

            if (filterVideosByContributor != null)
            {
                queryParams.Add("filter_videos_by_contributor", KnetikClient.DefaultClient.ParameterToString(filterVideosByContributor));
            }

            if (filterVideosByAuthor != null)
            {
                queryParams.Add("filter_videos_by_author", KnetikClient.DefaultClient.ParameterToString(filterVideosByAuthor));
            }

            if (filterHasAuthor != null)
            {
                queryParams.Add("filter_has_author", KnetikClient.DefaultClient.ParameterToString(filterHasAuthor));
            }

            if (filterHasUploader != null)
            {
                queryParams.Add("filter_has_uploader", KnetikClient.DefaultClient.ParameterToString(filterHasUploader));
            }

            if (filterRelatedTo != null)
            {
                queryParams.Add("filter_related_to", KnetikClient.DefaultClient.ParameterToString(filterRelatedTo));
            }

            if (filterFriends != null)
            {
                queryParams.Add("filter_friends", KnetikClient.DefaultClient.ParameterToString(filterFriends));
            }

            if (filterDisposition != null)
            {
                queryParams.Add("filter_disposition", KnetikClient.DefaultClient.ParameterToString(filterDisposition));
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
            string[] authSettings = new string[] {  };

            mGetVideosStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetVideosStartTime, mGetVideosPath, "Sending server request...");

            // make the HTTP request
            mGetVideosCoroutine.ResponseReceived += GetVideosCallback;
            mGetVideosCoroutine.Start(mGetVideosPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetVideosCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVideos: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetVideos: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetVideosData = (PageResourceVideoResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceVideoResource), response.Headers);
            KnetikLogger.LogResponse(mGetVideosStartTime, mGetVideosPath, string.Format("Response received successfully:\n{0}", GetVideosData.ToString()));

            if (GetVideosComplete != null)
            {
                GetVideosComplete(GetVideosData);
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
            
            mRemoveUserFromVideoWhitelistPath = "/media/videos/{video_id}/whitelist/{id}";
            if (!string.IsNullOrEmpty(mRemoveUserFromVideoWhitelistPath))
            {
                mRemoveUserFromVideoWhitelistPath = mRemoveUserFromVideoWhitelistPath.Replace("{format}", "json");
            }
            mRemoveUserFromVideoWhitelistPath = mRemoveUserFromVideoWhitelistPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));
mRemoveUserFromVideoWhitelistPath = mRemoveUserFromVideoWhitelistPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mRemoveUserFromVideoWhitelistStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mRemoveUserFromVideoWhitelistStartTime, mRemoveUserFromVideoWhitelistPath, "Sending server request...");

            // make the HTTP request
            mRemoveUserFromVideoWhitelistCoroutine.ResponseReceived += RemoveUserFromVideoWhitelistCallback;
            mRemoveUserFromVideoWhitelistCoroutine.Start(mRemoveUserFromVideoWhitelistPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void RemoveUserFromVideoWhitelistCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveUserFromVideoWhitelist: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveUserFromVideoWhitelist: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mRemoveUserFromVideoWhitelistStartTime, mRemoveUserFromVideoWhitelistPath, "Response received successfully.");
            if (RemoveUserFromVideoWhitelistComplete != null)
            {
                RemoveUserFromVideoWhitelistComplete();
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
            
            mRemoveVideoContributorPath = "/media/videos/{video_id}/contributors/{id}";
            if (!string.IsNullOrEmpty(mRemoveVideoContributorPath))
            {
                mRemoveVideoContributorPath = mRemoveVideoContributorPath.Replace("{format}", "json");
            }
            mRemoveVideoContributorPath = mRemoveVideoContributorPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));
mRemoveVideoContributorPath = mRemoveVideoContributorPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mRemoveVideoContributorStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mRemoveVideoContributorStartTime, mRemoveVideoContributorPath, "Sending server request...");

            // make the HTTP request
            mRemoveVideoContributorCoroutine.ResponseReceived += RemoveVideoContributorCallback;
            mRemoveVideoContributorCoroutine.Start(mRemoveVideoContributorPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void RemoveVideoContributorCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveVideoContributor: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveVideoContributor: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mRemoveVideoContributorStartTime, mRemoveVideoContributorPath, "Response received successfully.");
            if (RemoveVideoContributorComplete != null)
            {
                RemoveVideoContributorComplete();
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
            
            mUpdateVideoPath = "/media/videos/{id}";
            if (!string.IsNullOrEmpty(mUpdateVideoPath))
            {
                mUpdateVideoPath = mUpdateVideoPath.Replace("{format}", "json");
            }
            mUpdateVideoPath = mUpdateVideoPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(videoResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateVideoStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateVideoStartTime, mUpdateVideoPath, "Sending server request...");

            // make the HTTP request
            mUpdateVideoCoroutine.ResponseReceived += UpdateVideoCallback;
            mUpdateVideoCoroutine.Start(mUpdateVideoPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateVideoCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateVideo: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateVideo: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateVideoStartTime, mUpdateVideoPath, "Response received successfully.");
            if (UpdateVideoComplete != null)
            {
                UpdateVideoComplete();
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
            
            mUpdateVideoCommentPath = "/media/videos/{video_id}/comments/{id}/content";
            if (!string.IsNullOrEmpty(mUpdateVideoCommentPath))
            {
                mUpdateVideoCommentPath = mUpdateVideoCommentPath.Replace("{format}", "json");
            }
            mUpdateVideoCommentPath = mUpdateVideoCommentPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));
mUpdateVideoCommentPath = mUpdateVideoCommentPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(content); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateVideoCommentStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateVideoCommentStartTime, mUpdateVideoCommentPath, "Sending server request...");

            // make the HTTP request
            mUpdateVideoCommentCoroutine.ResponseReceived += UpdateVideoCommentCallback;
            mUpdateVideoCommentCoroutine.Start(mUpdateVideoCommentPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateVideoCommentCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateVideoComment: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateVideoComment: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateVideoCommentStartTime, mUpdateVideoCommentPath, "Response received successfully.");
            if (UpdateVideoCommentComplete != null)
            {
                UpdateVideoCommentComplete();
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
            
            mUpdateVideoRelationshipPath = "/media/videos/{video_id}/related/{id}/relationship_details";
            if (!string.IsNullOrEmpty(mUpdateVideoRelationshipPath))
            {
                mUpdateVideoRelationshipPath = mUpdateVideoRelationshipPath.Replace("{format}", "json");
            }
            mUpdateVideoRelationshipPath = mUpdateVideoRelationshipPath.Replace("{" + "video_id" + "}", KnetikClient.DefaultClient.ParameterToString(videoId));
mUpdateVideoRelationshipPath = mUpdateVideoRelationshipPath.Replace("{" + "relationship_id" + "}", KnetikClient.DefaultClient.ParameterToString(relationshipId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(details); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateVideoRelationshipStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateVideoRelationshipStartTime, mUpdateVideoRelationshipPath, "Sending server request...");

            // make the HTTP request
            mUpdateVideoRelationshipCoroutine.ResponseReceived += UpdateVideoRelationshipCallback;
            mUpdateVideoRelationshipCoroutine.Start(mUpdateVideoRelationshipPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateVideoRelationshipCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateVideoRelationship: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateVideoRelationship: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateVideoRelationshipStartTime, mUpdateVideoRelationshipPath, "Response received successfully.");
            if (UpdateVideoRelationshipComplete != null)
            {
                UpdateVideoRelationshipComplete();
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
            
            mViewVideoPath = "/media/videos/{id}/views";
            if (!string.IsNullOrEmpty(mViewVideoPath))
            {
                mViewVideoPath = mViewVideoPath.Replace("{format}", "json");
            }
            mViewVideoPath = mViewVideoPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mViewVideoStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mViewVideoStartTime, mViewVideoPath, "Sending server request...");

            // make the HTTP request
            mViewVideoCoroutine.ResponseReceived += ViewVideoCallback;
            mViewVideoCoroutine.Start(mViewVideoPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void ViewVideoCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling ViewVideo: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling ViewVideo: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mViewVideoStartTime, mViewVideoPath, "Response received successfully.");
            if (ViewVideoComplete != null)
            {
                ViewVideoComplete();
            }
        }

    }
}
