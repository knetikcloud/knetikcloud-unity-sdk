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
    public interface IUsersFriendshipsApi
    {
        PageResourceSimpleUserResource GetFriendsData { get; }

        string GetInviteTokenData { get; }

        PageResourceSimpleUserResource GetInvitesData { get; }

        
        /// <summary>
        /// Add a friend As a user, either creates or confirm a pending request. As an admin, call this endpoint twice while inverting the IDs to create a confirmed friendship.
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39; if logged in</param>
        /// <param name="id">The id of the user to befriend</param>
        void AddFriend(string userId, int? id);

        /// <summary>
        /// Get friends list 
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39;</param>
        /// <param name="filterUsername">Filter for friends with the given username</param>
        /// <param name="filterUserId">Filter for friends by user id</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetFriends(string userId, string filterUsername, int? filterUserId, int? size, int? page);

        /// <summary>
        /// Returns the invite token This is a unique invite token that allows direct connection to the request user.  Exposing that token presents privacy issues if the token is leaked. Use friend request flow instead if confirmation is required
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39; if logged in</param>
        void GetInviteToken(string userId);

        /// <summary>
        /// Get pending invites Invites that the specified user received
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39;</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        void GetInvites(string userId, int? size, int? page);

        /// <summary>
        /// Redeem friendship token Immediately connects the requested user with the user mapped by the provided invite token
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39; if logged in</param>
        /// <param name="token">The invite token</param>
        void RedeemFriendshipToken(string userId, StringWrapper token);

        /// <summary>
        /// Remove or decline a friend 
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
        private readonly KnetikCoroutine mAddFriendCoroutine;
        private DateTime mAddFriendStartTime;
        private string mAddFriendPath;
        private readonly KnetikCoroutine mGetFriendsCoroutine;
        private DateTime mGetFriendsStartTime;
        private string mGetFriendsPath;
        private readonly KnetikCoroutine mGetInviteTokenCoroutine;
        private DateTime mGetInviteTokenStartTime;
        private string mGetInviteTokenPath;
        private readonly KnetikCoroutine mGetInvitesCoroutine;
        private DateTime mGetInvitesStartTime;
        private string mGetInvitesPath;
        private readonly KnetikCoroutine mRedeemFriendshipTokenCoroutine;
        private DateTime mRedeemFriendshipTokenStartTime;
        private string mRedeemFriendshipTokenPath;
        private readonly KnetikCoroutine mRemoveOrDeclineFriendCoroutine;
        private DateTime mRemoveOrDeclineFriendStartTime;
        private string mRemoveOrDeclineFriendPath;

        public delegate void AddFriendCompleteDelegate();
        public AddFriendCompleteDelegate AddFriendComplete;

        public PageResourceSimpleUserResource GetFriendsData { get; private set; }
        public delegate void GetFriendsCompleteDelegate(PageResourceSimpleUserResource response);
        public GetFriendsCompleteDelegate GetFriendsComplete;

        public string GetInviteTokenData { get; private set; }
        public delegate void GetInviteTokenCompleteDelegate(string response);
        public GetInviteTokenCompleteDelegate GetInviteTokenComplete;

        public PageResourceSimpleUserResource GetInvitesData { get; private set; }
        public delegate void GetInvitesCompleteDelegate(PageResourceSimpleUserResource response);
        public GetInvitesCompleteDelegate GetInvitesComplete;

        public delegate void RedeemFriendshipTokenCompleteDelegate();
        public RedeemFriendshipTokenCompleteDelegate RedeemFriendshipTokenComplete;

        public delegate void RemoveOrDeclineFriendCompleteDelegate();
        public RemoveOrDeclineFriendCompleteDelegate RemoveOrDeclineFriendComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersFriendshipsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersFriendshipsApi()
        {
            mAddFriendCoroutine = new KnetikCoroutine();
            mGetFriendsCoroutine = new KnetikCoroutine();
            mGetInviteTokenCoroutine = new KnetikCoroutine();
            mGetInvitesCoroutine = new KnetikCoroutine();
            mRedeemFriendshipTokenCoroutine = new KnetikCoroutine();
            mRemoveOrDeclineFriendCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a friend As a user, either creates or confirm a pending request. As an admin, call this endpoint twice while inverting the IDs to create a confirmed friendship.
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
            
            mAddFriendPath = "/users/{user_id}/friends/{id}";
            if (!string.IsNullOrEmpty(mAddFriendPath))
            {
                mAddFriendPath = mAddFriendPath.Replace("{format}", "json");
            }
            mAddFriendPath = mAddFriendPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mAddFriendPath = mAddFriendPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddFriendStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddFriendStartTime, mAddFriendPath, "Sending server request...");

            // make the HTTP request
            mAddFriendCoroutine.ResponseReceived += AddFriendCallback;
            mAddFriendCoroutine.Start(mAddFriendPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddFriendCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddFriend: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddFriend: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mAddFriendStartTime, mAddFriendPath, "Response received successfully.");
            if (AddFriendComplete != null)
            {
                AddFriendComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get friends list 
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
            
            mGetFriendsPath = "/users/{user_id}/friends";
            if (!string.IsNullOrEmpty(mGetFriendsPath))
            {
                mGetFriendsPath = mGetFriendsPath.Replace("{format}", "json");
            }
            mGetFriendsPath = mGetFriendsPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterUsername != null)
            {
                queryParams.Add("filter_username", KnetikClient.DefaultClient.ParameterToString(filterUsername));
            }

            if (filterUserId != null)
            {
                queryParams.Add("filter_user_id", KnetikClient.DefaultClient.ParameterToString(filterUserId));
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

            mGetFriendsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetFriendsStartTime, mGetFriendsPath, "Sending server request...");

            // make the HTTP request
            mGetFriendsCoroutine.ResponseReceived += GetFriendsCallback;
            mGetFriendsCoroutine.Start(mGetFriendsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetFriendsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetFriends: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetFriends: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetFriendsData = (PageResourceSimpleUserResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceSimpleUserResource), response.Headers);
            KnetikLogger.LogResponse(mGetFriendsStartTime, mGetFriendsPath, string.Format("Response received successfully:\n{0}", GetFriendsData.ToString()));

            if (GetFriendsComplete != null)
            {
                GetFriendsComplete(GetFriendsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns the invite token This is a unique invite token that allows direct connection to the request user.  Exposing that token presents privacy issues if the token is leaked. Use friend request flow instead if confirmation is required
        /// </summary>
        /// <param name="userId">The id of the user or &#39;me&#39; if logged in</param>
        public void GetInviteToken(string userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetInviteToken");
            }
            
            mGetInviteTokenPath = "/users/{user_id}/invite-token";
            if (!string.IsNullOrEmpty(mGetInviteTokenPath))
            {
                mGetInviteTokenPath = mGetInviteTokenPath.Replace("{format}", "json");
            }
            mGetInviteTokenPath = mGetInviteTokenPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetInviteTokenStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetInviteTokenStartTime, mGetInviteTokenPath, "Sending server request...");

            // make the HTTP request
            mGetInviteTokenCoroutine.ResponseReceived += GetInviteTokenCallback;
            mGetInviteTokenCoroutine.Start(mGetInviteTokenPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetInviteTokenCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetInviteToken: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetInviteToken: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetInviteTokenData = (string) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mGetInviteTokenStartTime, mGetInviteTokenPath, string.Format("Response received successfully:\n{0}", GetInviteTokenData.ToString()));

            if (GetInviteTokenComplete != null)
            {
                GetInviteTokenComplete(GetInviteTokenData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get pending invites Invites that the specified user received
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
            
            mGetInvitesPath = "/users/{user_id}/invites";
            if (!string.IsNullOrEmpty(mGetInvitesPath))
            {
                mGetInvitesPath = mGetInvitesPath.Replace("{format}", "json");
            }
            mGetInvitesPath = mGetInvitesPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetInvitesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetInvitesStartTime, mGetInvitesPath, "Sending server request...");

            // make the HTTP request
            mGetInvitesCoroutine.ResponseReceived += GetInvitesCallback;
            mGetInvitesCoroutine.Start(mGetInvitesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetInvitesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetInvites: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetInvites: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetInvitesData = (PageResourceSimpleUserResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceSimpleUserResource), response.Headers);
            KnetikLogger.LogResponse(mGetInvitesStartTime, mGetInvitesPath, string.Format("Response received successfully:\n{0}", GetInvitesData.ToString()));

            if (GetInvitesComplete != null)
            {
                GetInvitesComplete(GetInvitesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Redeem friendship token Immediately connects the requested user with the user mapped by the provided invite token
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
            
            mRedeemFriendshipTokenPath = "/users/{user_id}/friends/tokens";
            if (!string.IsNullOrEmpty(mRedeemFriendshipTokenPath))
            {
                mRedeemFriendshipTokenPath = mRedeemFriendshipTokenPath.Replace("{format}", "json");
            }
            mRedeemFriendshipTokenPath = mRedeemFriendshipTokenPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(token); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mRedeemFriendshipTokenStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mRedeemFriendshipTokenStartTime, mRedeemFriendshipTokenPath, "Sending server request...");

            // make the HTTP request
            mRedeemFriendshipTokenCoroutine.ResponseReceived += RedeemFriendshipTokenCallback;
            mRedeemFriendshipTokenCoroutine.Start(mRedeemFriendshipTokenPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void RedeemFriendshipTokenCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RedeemFriendshipToken: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RedeemFriendshipToken: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mRedeemFriendshipTokenStartTime, mRedeemFriendshipTokenPath, "Response received successfully.");
            if (RedeemFriendshipTokenComplete != null)
            {
                RedeemFriendshipTokenComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Remove or decline a friend 
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
            
            mRemoveOrDeclineFriendPath = "/users/{user_id}/friends/{id}";
            if (!string.IsNullOrEmpty(mRemoveOrDeclineFriendPath))
            {
                mRemoveOrDeclineFriendPath = mRemoveOrDeclineFriendPath.Replace("{format}", "json");
            }
            mRemoveOrDeclineFriendPath = mRemoveOrDeclineFriendPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));
mRemoveOrDeclineFriendPath = mRemoveOrDeclineFriendPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mRemoveOrDeclineFriendStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mRemoveOrDeclineFriendStartTime, mRemoveOrDeclineFriendPath, "Sending server request...");

            // make the HTTP request
            mRemoveOrDeclineFriendCoroutine.ResponseReceived += RemoveOrDeclineFriendCallback;
            mRemoveOrDeclineFriendCoroutine.Start(mRemoveOrDeclineFriendPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void RemoveOrDeclineFriendCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveOrDeclineFriend: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveOrDeclineFriend: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mRemoveOrDeclineFriendStartTime, mRemoveOrDeclineFriendPath, "Response received successfully.");
            if (RemoveOrDeclineFriendComplete != null)
            {
                RemoveOrDeclineFriendComplete();
            }
        }

    }
}
