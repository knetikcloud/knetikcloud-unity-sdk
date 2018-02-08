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
    public interface IUsersFriendshipsApi
    {
        

        /// <summary>
        /// Add a friend As a user, either creates or confirm a pending request. As an admin, call this endpoint twice while inverting the IDs to create a confirmed friendship. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; FRIENDSHIPS_ADMIN or (FRIENDSHIPS_USER and owner)
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39; if logged in</param>
        /// <param name="id">The id of the user to befriend</param>
        void AddFriend(string userId, int? id);

        PageResourceSimpleUserResource GetFriendsData { get; }

        /// <summary>
        /// Get friends list &lt;b&gt;Permissions Needed:&lt;/b&gt; FRIENDSHIPS_ADMIN or (FRIENDSHIPS_USER and owner)
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39;</param>
        /// <param name="filterUsername">Filter for friends with the given username</param>
        /// <param name="filterUserId">Filter for friends by user id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetFriends(string userId, string filterUsername, int? filterUserId, int? size, int? page);

        string GetInviteTokenData { get; }

        /// <summary>
        /// Returns the invite token This is a unique invite token that allows direct connection to the request user.  Exposing that token presents privacy issues if the token is leaked. Use friend request. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; FRIENDSHIPS_ADMIN or (FRIENDSHIPS_USER and owner)flow instead if confirmation is required
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39; if logged in</param>
        void GetInviteToken(string userId);

        PageResourceSimpleUserResource GetInvitesData { get; }

        /// <summary>
        /// Get pending invites Invites that the specified user received. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; FRIENDSHIPS_ADMIN or (FRIENDSHIPS_USER and owner)
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39;</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetInvites(string userId, int? size, int? page);

        

        /// <summary>
        /// Redeem friendship token Immediately connects the requested user with the user mapped by the provided invite token. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; FRIENDSHIPS_ADMIN or (FRIENDSHIPS_USER and owner)
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39; if logged in</param>
        /// <param name="token">The invite token</param>
        void RedeemFriendshipToken(string userId, StringWrapper token);

        

        /// <summary>
        /// Remove or decline a friend &lt;b&gt;Permissions Needed:&lt;/b&gt; FRIENDSHIPS_ADMIN or (FRIENDSHIPS_USER and owner)
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39; if logged in</param>
        /// <param name="id">The id of the user to befriend</param>
        void RemoveOrDeclineFriend(string userId, int? id);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UsersFriendshipsApi : IUsersFriendshipsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddFriendResponseContext;
        private DateTime mAddFriendStartTime;
        private readonly KnetikResponseContext mGetFriendsResponseContext;
        private DateTime mGetFriendsStartTime;
        private readonly KnetikResponseContext mGetInviteTokenResponseContext;
        private DateTime mGetInviteTokenStartTime;
        private readonly KnetikResponseContext mGetInvitesResponseContext;
        private DateTime mGetInvitesStartTime;
        private readonly KnetikResponseContext mRedeemFriendshipTokenResponseContext;
        private DateTime mRedeemFriendshipTokenStartTime;
        private readonly KnetikResponseContext mRemoveOrDeclineFriendResponseContext;
        private DateTime mRemoveOrDeclineFriendStartTime;

        public delegate void AddFriendCompleteDelegate(long responseCode);
        public AddFriendCompleteDelegate AddFriendComplete;

        public PageResourceSimpleUserResource GetFriendsData { get; private set; }
        public delegate void GetFriendsCompleteDelegate(long responseCode, PageResourceSimpleUserResource response);
        public GetFriendsCompleteDelegate GetFriendsComplete;

        public string GetInviteTokenData { get; private set; }
        public delegate void GetInviteTokenCompleteDelegate(long responseCode, string response);
        public GetInviteTokenCompleteDelegate GetInviteTokenComplete;

        public PageResourceSimpleUserResource GetInvitesData { get; private set; }
        public delegate void GetInvitesCompleteDelegate(long responseCode, PageResourceSimpleUserResource response);
        public GetInvitesCompleteDelegate GetInvitesComplete;

        public delegate void RedeemFriendshipTokenCompleteDelegate(long responseCode);
        public RedeemFriendshipTokenCompleteDelegate RedeemFriendshipTokenComplete;

        public delegate void RemoveOrDeclineFriendCompleteDelegate(long responseCode);
        public RemoveOrDeclineFriendCompleteDelegate RemoveOrDeclineFriendComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersFriendshipsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersFriendshipsApi()
        {
            mAddFriendResponseContext = new KnetikResponseContext();
            mAddFriendResponseContext.ResponseReceived += OnAddFriendResponse;
            mGetFriendsResponseContext = new KnetikResponseContext();
            mGetFriendsResponseContext.ResponseReceived += OnGetFriendsResponse;
            mGetInviteTokenResponseContext = new KnetikResponseContext();
            mGetInviteTokenResponseContext.ResponseReceived += OnGetInviteTokenResponse;
            mGetInvitesResponseContext = new KnetikResponseContext();
            mGetInvitesResponseContext.ResponseReceived += OnGetInvitesResponse;
            mRedeemFriendshipTokenResponseContext = new KnetikResponseContext();
            mRedeemFriendshipTokenResponseContext.ResponseReceived += OnRedeemFriendshipTokenResponse;
            mRemoveOrDeclineFriendResponseContext = new KnetikResponseContext();
            mRemoveOrDeclineFriendResponseContext.ResponseReceived += OnRemoveOrDeclineFriendResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a friend As a user, either creates or confirm a pending request. As an admin, call this endpoint twice while inverting the IDs to create a confirmed friendship. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; FRIENDSHIPS_ADMIN or (FRIENDSHIPS_USER and owner)
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39; if logged in</param>
        /// <param name="id">The id of the user to befriend</param>
        public void AddFriend(string userId, int? id)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling AddFriend");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddFriend");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/friends/{id}";
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
            mAddFriendStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddFriendResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddFriendStartTime, "AddFriend", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddFriendResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddFriend: " + response.Error);
            }

            KnetikLogger.LogResponse(mAddFriendStartTime, "AddFriend", "Response received successfully.");
            if (AddFriendComplete != null)
            {
                AddFriendComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get friends list &lt;b&gt;Permissions Needed:&lt;/b&gt; FRIENDSHIPS_ADMIN or (FRIENDSHIPS_USER and owner)
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39;</param>
        /// <param name="filterUsername">Filter for friends with the given username</param>
        /// <param name="filterUserId">Filter for friends by user id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetFriends(string userId, string filterUsername, int? filterUserId, int? size, int? page)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetFriends");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/friends";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterUsername != null)
            {
                mWebCallEvent.QueryParams["filter_username"] = KnetikClient.ParameterToString(filterUsername);
            }

            if (filterUserId != null)
            {
                mWebCallEvent.QueryParams["filter_user_id"] = KnetikClient.ParameterToString(filterUserId);
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
            mGetFriendsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetFriendsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetFriendsStartTime, "GetFriends", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetFriendsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetFriends: " + response.Error);
            }

            GetFriendsData = (PageResourceSimpleUserResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceSimpleUserResource), response.Headers);
            KnetikLogger.LogResponse(mGetFriendsStartTime, "GetFriends", string.Format("Response received successfully:\n{0}", GetFriendsData));

            if (GetFriendsComplete != null)
            {
                GetFriendsComplete(response.ResponseCode, GetFriendsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the invite token This is a unique invite token that allows direct connection to the request user.  Exposing that token presents privacy issues if the token is leaked. Use friend request. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; FRIENDSHIPS_ADMIN or (FRIENDSHIPS_USER and owner)flow instead if confirmation is required
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39; if logged in</param>
        public void GetInviteToken(string userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetInviteToken");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/invite-token";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetInviteTokenStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetInviteTokenResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetInviteTokenStartTime, "GetInviteToken", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetInviteTokenResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetInviteToken: " + response.Error);
            }

            GetInviteTokenData = (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mGetInviteTokenStartTime, "GetInviteToken", string.Format("Response received successfully:\n{0}", GetInviteTokenData));

            if (GetInviteTokenComplete != null)
            {
                GetInviteTokenComplete(response.ResponseCode, GetInviteTokenData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get pending invites Invites that the specified user received. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; FRIENDSHIPS_ADMIN or (FRIENDSHIPS_USER and owner)
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39;</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        public void GetInvites(string userId, int? size, int? page)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetInvites");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/invites";
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

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetInvitesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetInvitesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetInvitesStartTime, "GetInvites", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetInvitesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetInvites: " + response.Error);
            }

            GetInvitesData = (PageResourceSimpleUserResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceSimpleUserResource), response.Headers);
            KnetikLogger.LogResponse(mGetInvitesStartTime, "GetInvites", string.Format("Response received successfully:\n{0}", GetInvitesData));

            if (GetInvitesComplete != null)
            {
                GetInvitesComplete(response.ResponseCode, GetInvitesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Redeem friendship token Immediately connects the requested user with the user mapped by the provided invite token. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; FRIENDSHIPS_ADMIN or (FRIENDSHIPS_USER and owner)
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39; if logged in</param>
        /// <param name="token">The invite token</param>
        public void RedeemFriendshipToken(string userId, StringWrapper token)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling RedeemFriendshipToken");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/friends/tokens";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(token); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mRedeemFriendshipTokenStartTime = DateTime.Now;
            mWebCallEvent.Context = mRedeemFriendshipTokenResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mRedeemFriendshipTokenStartTime, "RedeemFriendshipToken", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnRedeemFriendshipTokenResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling RedeemFriendshipToken: " + response.Error);
            }

            KnetikLogger.LogResponse(mRedeemFriendshipTokenStartTime, "RedeemFriendshipToken", "Response received successfully.");
            if (RedeemFriendshipTokenComplete != null)
            {
                RedeemFriendshipTokenComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Remove or decline a friend &lt;b&gt;Permissions Needed:&lt;/b&gt; FRIENDSHIPS_ADMIN or (FRIENDSHIPS_USER and owner)
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39; if logged in</param>
        /// <param name="id">The id of the user to befriend</param>
        public void RemoveOrDeclineFriend(string userId, int? id)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling RemoveOrDeclineFriend");
            }
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling RemoveOrDeclineFriend");
            }
            
            mWebCallEvent.WebPath = "/users/{user_id}/friends/{id}";
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
            mRemoveOrDeclineFriendStartTime = DateTime.Now;
            mWebCallEvent.Context = mRemoveOrDeclineFriendResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mRemoveOrDeclineFriendStartTime, "RemoveOrDeclineFriend", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnRemoveOrDeclineFriendResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling RemoveOrDeclineFriend: " + response.Error);
            }

            KnetikLogger.LogResponse(mRemoveOrDeclineFriendStartTime, "RemoveOrDeclineFriend", "Response received successfully.");
            if (RemoveOrDeclineFriendComplete != null)
            {
                RemoveOrDeclineFriendComplete(response.ResponseCode);
            }
        }

    }
}
