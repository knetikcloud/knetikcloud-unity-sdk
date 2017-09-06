using System;
using System.Collections.Generic;
using RestSharp;
using com.knetikcloud.Client;
using com.knetikcloud.Model;
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
        /// <summary>
        /// Adds a user to a video&#39;s whitelist Whitelisted users can view video regardless of privacy setting.
        /// </summary>
        /// <param name="id">The video id</param>
        /// <param name="userId">The user id</param>
        /// <returns></returns>
        void AddUserToVideoWhitelist (long? id, IntWrapper userId);
        /// <summary>
        /// Adds a new video in the system 
        /// </summary>
        /// <param name="videoResource">The video object</param>
        /// <returns>VideoResource</returns>
        VideoResource AddVideo (VideoResource videoResource);
        /// <summary>
        /// Add a new video comment 
        /// </summary>
        /// <param name="videoId">The video id </param>
        /// <param name="commentResource">The comment object</param>
        /// <returns>CommentResource</returns>
        CommentResource AddVideoComment (int? videoId, CommentResource commentResource);
        /// <summary>
        /// Adds a contributor to a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="contributionResource">The contribution object</param>
        /// <returns></returns>
        void AddVideoContributor (long? videoId, ContributionResource contributionResource);
        /// <summary>
        /// Add a new flag 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="reason">The flag reason</param>
        /// <returns>FlagResource</returns>
        FlagResource AddVideoFlag (long? videoId, StringWrapper reason);
        /// <summary>
        /// Adds one or more existing videos as related to this one 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="videoRelationshipResource">The video relationship object </param>
        /// <returns>VideoRelationshipResource</returns>
        VideoRelationshipResource AddVideoRelationships (long? videoId, VideoRelationshipResource videoRelationshipResource);
        /// <summary>
        /// Create a video disposition 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="dispositionResource">The disposition object</param>
        /// <returns>DispositionResource</returns>
        DispositionResource CreateVideoDisposition (int? videoId, DispositionResource dispositionResource);
        /// <summary>
        /// Deletes a video from the system if no resources are attached to it 
        /// </summary>
        /// <param name="id">The video id</param>
        /// <returns></returns>
        void DeleteVideo (long? id);
        /// <summary>
        /// Delete a video comment 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The comment id</param>
        /// <returns></returns>
        void DeleteVideoComment (long? videoId, long? id);
        /// <summary>
        /// Delete a video disposition 
        /// </summary>
        /// <param name="dispositionId">The disposition id</param>
        /// <returns></returns>
        void DeleteVideoDisposition (long? dispositionId);
        /// <summary>
        /// Delete a flag 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <returns></returns>
        void DeleteVideoFlag (long? videoId);
        /// <summary>
        /// Delete a video&#39;s relationship 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The relationship id</param>
        /// <returns></returns>
        void DeleteVideoRelationship (long? videoId, long? id);
        /// <summary>
        /// Get user videos 
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="excludeFlagged">Skip videos that have been flagged by the current user</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceVideoResource</returns>
        PageResourceVideoResource GetUserVideos (int? userId, bool? excludeFlagged, int? size, int? page);
        /// <summary>
        /// Loads a specific video details 
        /// </summary>
        /// <param name="id">The video id</param>
        /// <returns>VideoResource</returns>
        VideoResource GetVideo (long? id);
        /// <summary>
        /// Returns a page of comments for a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceCommentResource</returns>
        PageResourceCommentResource GetVideoComments (int? videoId, int? size, int? page);
        /// <summary>
        /// Returns a page of dispositions for a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceDispositionResource</returns>
        PageResourceDispositionResource GetVideoDispositions (int? videoId, int? size, int? page);
        /// <summary>
        /// Returns a page of video relationships 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceVideoRelationshipResource</returns>
        PageResourceVideoRelationshipResource GetVideoRelationships (long? videoId, int? size, int? page);
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
        /// <returns>PageResourceVideoResource</returns>
        PageResourceVideoResource GetVideos (bool? excludeFlagged, int? filterVideosByUploader, string filterCategory, string filterTagset, string filterVideosByName, int? filterVideosByContributor, int? filterVideosByAuthor, bool? filterHasAuthor, bool? filterHasUploader, string filterRelatedTo, bool? filterFriends, string filterDisposition, int? size, int? page, string order);
        /// <summary>
        /// Removes a user from a video&#39;s whitelist Remove the user with the id given in the path from the whitelist of users that can view this video regardless of privacy setting.
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The user id</param>
        /// <returns></returns>
        void RemoveUserFromVideoWhitelist (long? videoId, int? id);
        /// <summary>
        /// Removes a contributor from a video 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The contributor id</param>
        /// <returns></returns>
        void RemoveVideoContributor (long? videoId, int? id);
        /// <summary>
        /// Modifies a video&#39;s details 
        /// </summary>
        /// <param name="id">The video id</param>
        /// <param name="videoResource">The video object</param>
        /// <returns></returns>
        void UpdateVideo (long? id, VideoResource videoResource);
        /// <summary>
        /// Update a video comment 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="id">The comment id</param>
        /// <param name="content">The comment content</param>
        /// <returns></returns>
        void UpdateVideoComment (long? videoId, long? id, StringWrapper content);
        /// <summary>
        /// Update a video&#39;s relationship details 
        /// </summary>
        /// <param name="videoId">The video id</param>
        /// <param name="relationshipId">The relationship id</param>
        /// <param name="details">The video relationship details</param>
        /// <returns></returns>
        void UpdateVideoRelationship (long? videoId, long? relationshipId, StringWrapper details);
        /// <summary>
        /// Increment a video&#39;s view count 
        /// </summary>
        /// <param name="id">The video id</param>
        /// <returns></returns>
        void ViewVideo (long? id);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class MediaVideosApi : IMediaVideosApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaVideosApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MediaVideosApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Adds a user to a video&#39;s whitelist Whitelisted users can view video regardless of privacy setting.
        /// </summary>
        /// <param name="id">The video id</param> 
        /// <param name="userId">The user id</param> 
        /// <returns></returns>            
        public void AddUserToVideoWhitelist(long? id, IntWrapper userId)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddUserToVideoWhitelist");
            }
            
            
            string urlPath = "/media/videos/{id}/whitelist";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(userId); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddUserToVideoWhitelist: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddUserToVideoWhitelist: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Adds a new video in the system 
        /// </summary>
        /// <param name="videoResource">The video object</param> 
        /// <returns>VideoResource</returns>            
        public VideoResource AddVideo(VideoResource videoResource)
        {
            
            string urlPath = "/media/videos";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(videoResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddVideo: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddVideo: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (VideoResource) KnetikClient.Deserialize(response.Content, typeof(VideoResource), response.Headers);
        }
        /// <summary>
        /// Add a new video comment 
        /// </summary>
        /// <param name="videoId">The video id </param> 
        /// <param name="commentResource">The comment object</param> 
        /// <returns>CommentResource</returns>            
        public CommentResource AddVideoComment(int? videoId, CommentResource commentResource)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling AddVideoComment");
            }
            
            
            string urlPath = "/media/videos/{video_id}/comments";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(commentResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddVideoComment: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddVideoComment: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (CommentResource) KnetikClient.Deserialize(response.Content, typeof(CommentResource), response.Headers);
        }
        /// <summary>
        /// Adds a contributor to a video 
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <param name="contributionResource">The contribution object</param> 
        /// <returns></returns>            
        public void AddVideoContributor(long? videoId, ContributionResource contributionResource)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling AddVideoContributor");
            }
            
            
            string urlPath = "/media/videos/{video_id}/contributors";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(contributionResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddVideoContributor: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddVideoContributor: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Add a new flag 
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <param name="reason">The flag reason</param> 
        /// <returns>FlagResource</returns>            
        public FlagResource AddVideoFlag(long? videoId, StringWrapper reason)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling AddVideoFlag");
            }
            
            
            string urlPath = "/media/videos/{video_id}/moderation";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(reason); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddVideoFlag: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddVideoFlag: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (FlagResource) KnetikClient.Deserialize(response.Content, typeof(FlagResource), response.Headers);
        }
        /// <summary>
        /// Adds one or more existing videos as related to this one 
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <param name="videoRelationshipResource">The video relationship object </param> 
        /// <returns>VideoRelationshipResource</returns>            
        public VideoRelationshipResource AddVideoRelationships(long? videoId, VideoRelationshipResource videoRelationshipResource)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling AddVideoRelationships");
            }
            
            
            string urlPath = "/media/videos/{video_id}/related";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(videoRelationshipResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddVideoRelationships: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddVideoRelationships: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (VideoRelationshipResource) KnetikClient.Deserialize(response.Content, typeof(VideoRelationshipResource), response.Headers);
        }
        /// <summary>
        /// Create a video disposition 
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <param name="dispositionResource">The disposition object</param> 
        /// <returns>DispositionResource</returns>            
        public DispositionResource CreateVideoDisposition(int? videoId, DispositionResource dispositionResource)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling CreateVideoDisposition");
            }
            
            
            string urlPath = "/media/videos/{video_id}/dispositions";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(dispositionResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateVideoDisposition: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateVideoDisposition: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (DispositionResource) KnetikClient.Deserialize(response.Content, typeof(DispositionResource), response.Headers);
        }
        /// <summary>
        /// Deletes a video from the system if no resources are attached to it 
        /// </summary>
        /// <param name="id">The video id</param> 
        /// <returns></returns>            
        public void DeleteVideo(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteVideo");
            }
            
            
            string urlPath = "/media/videos/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVideo: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVideo: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete a video comment 
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <param name="id">The comment id</param> 
        /// <returns></returns>            
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
            
            
            string urlPath = "/media/videos/{video_id}/comments/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVideoComment: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVideoComment: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete a video disposition 
        /// </summary>
        /// <param name="dispositionId">The disposition id</param> 
        /// <returns></returns>            
        public void DeleteVideoDisposition(long? dispositionId)
        {
            // verify the required parameter 'dispositionId' is set
            if (dispositionId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'dispositionId' when calling DeleteVideoDisposition");
            }
            
            
            string urlPath = "/media/videos/{video_id}/dispositions/{disposition_id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "disposition_id" + "}", KnetikClient.ParameterToString(dispositionId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVideoDisposition: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVideoDisposition: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete a flag 
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <returns></returns>            
        public void DeleteVideoFlag(long? videoId)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling DeleteVideoFlag");
            }
            
            
            string urlPath = "/media/videos/{video_id}/moderation";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVideoFlag: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVideoFlag: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete a video&#39;s relationship 
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <param name="id">The relationship id</param> 
        /// <returns></returns>            
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
            
            
            string urlPath = "/media/videos/{video_id}/related/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVideoRelationship: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteVideoRelationship: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get user videos 
        /// </summary>
        /// <param name="userId">The user id</param> 
        /// <param name="excludeFlagged">Skip videos that have been flagged by the current user</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceVideoResource</returns>            
        public PageResourceVideoResource GetUserVideos(int? userId, bool? excludeFlagged, int? size, int? page)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserVideos");
            }
            
            
            string urlPath = "/users/{user_id}/videos";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (excludeFlagged != null)
            {
                queryParams.Add("exclude_flagged", KnetikClient.ParameterToString(excludeFlagged));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserVideos: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserVideos: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceVideoResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceVideoResource), response.Headers);
        }
        /// <summary>
        /// Loads a specific video details 
        /// </summary>
        /// <param name="id">The video id</param> 
        /// <returns>VideoResource</returns>            
        public VideoResource GetVideo(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetVideo");
            }
            
            
            string urlPath = "/media/videos/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVideo: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVideo: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (VideoResource) KnetikClient.Deserialize(response.Content, typeof(VideoResource), response.Headers);
        }
        /// <summary>
        /// Returns a page of comments for a video 
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceCommentResource</returns>            
        public PageResourceCommentResource GetVideoComments(int? videoId, int? size, int? page)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling GetVideoComments");
            }
            
            
            string urlPath = "/media/videos/{video_id}/comments";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVideoComments: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVideoComments: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceCommentResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceCommentResource), response.Headers);
        }
        /// <summary>
        /// Returns a page of dispositions for a video 
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceDispositionResource</returns>            
        public PageResourceDispositionResource GetVideoDispositions(int? videoId, int? size, int? page)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling GetVideoDispositions");
            }
            
            
            string urlPath = "/media/videos/{video_id}/dispositions";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVideoDispositions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVideoDispositions: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceDispositionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceDispositionResource), response.Headers);
        }
        /// <summary>
        /// Returns a page of video relationships 
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceVideoRelationshipResource</returns>            
        public PageResourceVideoRelationshipResource GetVideoRelationships(long? videoId, int? size, int? page)
        {
            // verify the required parameter 'videoId' is set
            if (videoId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'videoId' when calling GetVideoRelationships");
            }
            
            
            string urlPath = "/media/videos/{video_id}/related";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVideoRelationships: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVideoRelationships: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceVideoRelationshipResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceVideoRelationshipResource), response.Headers);
        }
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
        /// <returns>PageResourceVideoResource</returns>            
        public PageResourceVideoResource GetVideos(bool? excludeFlagged, int? filterVideosByUploader, string filterCategory, string filterTagset, string filterVideosByName, int? filterVideosByContributor, int? filterVideosByAuthor, bool? filterHasAuthor, bool? filterHasUploader, string filterRelatedTo, bool? filterFriends, string filterDisposition, int? size, int? page, string order)
        {
            
            string urlPath = "/media/videos";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (excludeFlagged != null)
            {
                queryParams.Add("exclude_flagged", KnetikClient.ParameterToString(excludeFlagged));
            }
            
            if (filterVideosByUploader != null)
            {
                queryParams.Add("filter_videos_by_uploader", KnetikClient.ParameterToString(filterVideosByUploader));
            }
            
            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.ParameterToString(filterCategory));
            }
            
            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.ParameterToString(filterTagset));
            }
            
            if (filterVideosByName != null)
            {
                queryParams.Add("filter_videos_by_name", KnetikClient.ParameterToString(filterVideosByName));
            }
            
            if (filterVideosByContributor != null)
            {
                queryParams.Add("filter_videos_by_contributor", KnetikClient.ParameterToString(filterVideosByContributor));
            }
            
            if (filterVideosByAuthor != null)
            {
                queryParams.Add("filter_videos_by_author", KnetikClient.ParameterToString(filterVideosByAuthor));
            }
            
            if (filterHasAuthor != null)
            {
                queryParams.Add("filter_has_author", KnetikClient.ParameterToString(filterHasAuthor));
            }
            
            if (filterHasUploader != null)
            {
                queryParams.Add("filter_has_uploader", KnetikClient.ParameterToString(filterHasUploader));
            }
            
            if (filterRelatedTo != null)
            {
                queryParams.Add("filter_related_to", KnetikClient.ParameterToString(filterRelatedTo));
            }
            
            if (filterFriends != null)
            {
                queryParams.Add("filter_friends", KnetikClient.ParameterToString(filterFriends));
            }
            
            if (filterDisposition != null)
            {
                queryParams.Add("filter_disposition", KnetikClient.ParameterToString(filterDisposition));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVideos: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetVideos: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceVideoResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceVideoResource), response.Headers);
        }
        /// <summary>
        /// Removes a user from a video&#39;s whitelist Remove the user with the id given in the path from the whitelist of users that can view this video regardless of privacy setting.
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <param name="id">The user id</param> 
        /// <returns></returns>            
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
            
            
            string urlPath = "/media/videos/{video_id}/whitelist/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling RemoveUserFromVideoWhitelist: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling RemoveUserFromVideoWhitelist: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Removes a contributor from a video 
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <param name="id">The contributor id</param> 
        /// <returns></returns>            
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
            
            
            string urlPath = "/media/videos/{video_id}/contributors/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling RemoveVideoContributor: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling RemoveVideoContributor: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Modifies a video&#39;s details 
        /// </summary>
        /// <param name="id">The video id</param> 
        /// <param name="videoResource">The video object</param> 
        /// <returns></returns>            
        public void UpdateVideo(long? id, VideoResource videoResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateVideo");
            }
            
            
            string urlPath = "/media/videos/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(videoResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateVideo: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateVideo: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Update a video comment 
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <param name="id">The comment id</param> 
        /// <param name="content">The comment content</param> 
        /// <returns></returns>            
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
            
            
            string urlPath = "/media/videos/{video_id}/comments/{id}/content";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(content); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateVideoComment: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateVideoComment: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Update a video&#39;s relationship details 
        /// </summary>
        /// <param name="videoId">The video id</param> 
        /// <param name="relationshipId">The relationship id</param> 
        /// <param name="details">The video relationship details</param> 
        /// <returns></returns>            
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
            
            
            string urlPath = "/media/videos/{video_id}/related/{id}/relationship_details";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "video_id" + "}", KnetikClient.ParameterToString(videoId));
urlPath = urlPath.Replace("{" + "relationship_id" + "}", KnetikClient.ParameterToString(relationshipId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(details); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateVideoRelationship: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateVideoRelationship: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Increment a video&#39;s view count 
        /// </summary>
        /// <param name="id">The video id</param> 
        /// <returns></returns>            
        public void ViewVideo(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling ViewVideo");
            }
            
            
            string urlPath = "/media/videos/{id}/views";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling ViewVideo: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling ViewVideo: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
    }
}
