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
    public interface ICampaignsRewardsApi
    {
        RewardSetResource CreateRewardSetData { get; }

        /// <summary>
        /// Create a reward set 
        /// </summary>
        /// <param name="rewardSetResource">The reward set resource object</param>
        void CreateRewardSet(RewardSetResource rewardSetResource);

        

        /// <summary>
        /// Delete a reward set 
        /// </summary>
        /// <param name="id">The reward id</param>
        void DeleteRewardSet(int? id);

        RewardSetResource GetRewardSetData { get; }

        /// <summary>
        /// Get a single reward set 
        /// </summary>
        /// <param name="id">The reward id</param>
        void GetRewardSet(int? id);

        PageResourceRewardSetResource GetRewardSetsData { get; }

        /// <summary>
        /// List and search reward sets 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetRewardSets(int? size, int? page, string order);

        RewardSetResource UpdateRewardSetData { get; }

        /// <summary>
        /// Update a reward set 
        /// </summary>
        /// <param name="id">The reward id</param>
        /// <param name="rewardSetResource">The reward set resource object</param>
        void UpdateRewardSet(int? id, RewardSetResource rewardSetResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class CampaignsRewardsApi : ICampaignsRewardsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mCreateRewardSetResponseContext;
        private DateTime mCreateRewardSetStartTime;
        private readonly KnetikResponseContext mDeleteRewardSetResponseContext;
        private DateTime mDeleteRewardSetStartTime;
        private readonly KnetikResponseContext mGetRewardSetResponseContext;
        private DateTime mGetRewardSetStartTime;
        private readonly KnetikResponseContext mGetRewardSetsResponseContext;
        private DateTime mGetRewardSetsStartTime;
        private readonly KnetikResponseContext mUpdateRewardSetResponseContext;
        private DateTime mUpdateRewardSetStartTime;

        public RewardSetResource CreateRewardSetData { get; private set; }
        public delegate void CreateRewardSetCompleteDelegate(long responseCode, RewardSetResource response);
        public CreateRewardSetCompleteDelegate CreateRewardSetComplete;

        public delegate void DeleteRewardSetCompleteDelegate(long responseCode);
        public DeleteRewardSetCompleteDelegate DeleteRewardSetComplete;

        public RewardSetResource GetRewardSetData { get; private set; }
        public delegate void GetRewardSetCompleteDelegate(long responseCode, RewardSetResource response);
        public GetRewardSetCompleteDelegate GetRewardSetComplete;

        public PageResourceRewardSetResource GetRewardSetsData { get; private set; }
        public delegate void GetRewardSetsCompleteDelegate(long responseCode, PageResourceRewardSetResource response);
        public GetRewardSetsCompleteDelegate GetRewardSetsComplete;

        public RewardSetResource UpdateRewardSetData { get; private set; }
        public delegate void UpdateRewardSetCompleteDelegate(long responseCode, RewardSetResource response);
        public UpdateRewardSetCompleteDelegate UpdateRewardSetComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignsRewardsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CampaignsRewardsApi()
        {
            mCreateRewardSetResponseContext = new KnetikResponseContext();
            mCreateRewardSetResponseContext.ResponseReceived += OnCreateRewardSetResponse;
            mDeleteRewardSetResponseContext = new KnetikResponseContext();
            mDeleteRewardSetResponseContext.ResponseReceived += OnDeleteRewardSetResponse;
            mGetRewardSetResponseContext = new KnetikResponseContext();
            mGetRewardSetResponseContext.ResponseReceived += OnGetRewardSetResponse;
            mGetRewardSetsResponseContext = new KnetikResponseContext();
            mGetRewardSetsResponseContext.ResponseReceived += OnGetRewardSetsResponse;
            mUpdateRewardSetResponseContext = new KnetikResponseContext();
            mUpdateRewardSetResponseContext.ResponseReceived += OnUpdateRewardSetResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a reward set 
        /// </summary>
        /// <param name="rewardSetResource">The reward set resource object</param>
        public void CreateRewardSet(RewardSetResource rewardSetResource)
        {
            
            mWebCallEvent.WebPath = "/rewards";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(rewardSetResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateRewardSetStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateRewardSetResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateRewardSetStartTime, "CreateRewardSet", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateRewardSetResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateRewardSet: " + response.Error);
            }

            CreateRewardSetData = (RewardSetResource) KnetikClient.Deserialize(response.Content, typeof(RewardSetResource), response.Headers);
            KnetikLogger.LogResponse(mCreateRewardSetStartTime, "CreateRewardSet", string.Format("Response received successfully:\n{0}", CreateRewardSetData));

            if (CreateRewardSetComplete != null)
            {
                CreateRewardSetComplete(response.ResponseCode, CreateRewardSetData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a reward set 
        /// </summary>
        /// <param name="id">The reward id</param>
        public void DeleteRewardSet(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteRewardSet");
            }
            
            mWebCallEvent.WebPath = "/rewards/{id}";
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
            mDeleteRewardSetStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteRewardSetResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteRewardSetStartTime, "DeleteRewardSet", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteRewardSetResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteRewardSet: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteRewardSetStartTime, "DeleteRewardSet", "Response received successfully.");
            if (DeleteRewardSetComplete != null)
            {
                DeleteRewardSetComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single reward set 
        /// </summary>
        /// <param name="id">The reward id</param>
        public void GetRewardSet(int? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetRewardSet");
            }
            
            mWebCallEvent.WebPath = "/rewards/{id}";
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
            mGetRewardSetStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetRewardSetResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetRewardSetStartTime, "GetRewardSet", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetRewardSetResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetRewardSet: " + response.Error);
            }

            GetRewardSetData = (RewardSetResource) KnetikClient.Deserialize(response.Content, typeof(RewardSetResource), response.Headers);
            KnetikLogger.LogResponse(mGetRewardSetStartTime, "GetRewardSet", string.Format("Response received successfully:\n{0}", GetRewardSetData));

            if (GetRewardSetComplete != null)
            {
                GetRewardSetComplete(response.ResponseCode, GetRewardSetData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search reward sets 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetRewardSets(int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/rewards";
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
            mGetRewardSetsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetRewardSetsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetRewardSetsStartTime, "GetRewardSets", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetRewardSetsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetRewardSets: " + response.Error);
            }

            GetRewardSetsData = (PageResourceRewardSetResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceRewardSetResource), response.Headers);
            KnetikLogger.LogResponse(mGetRewardSetsStartTime, "GetRewardSets", string.Format("Response received successfully:\n{0}", GetRewardSetsData));

            if (GetRewardSetsComplete != null)
            {
                GetRewardSetsComplete(response.ResponseCode, GetRewardSetsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a reward set 
        /// </summary>
        /// <param name="id">The reward id</param>
        /// <param name="rewardSetResource">The reward set resource object</param>
        public void UpdateRewardSet(int? id, RewardSetResource rewardSetResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateRewardSet");
            }
            
            mWebCallEvent.WebPath = "/rewards/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(rewardSetResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateRewardSetStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateRewardSetResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateRewardSetStartTime, "UpdateRewardSet", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateRewardSetResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateRewardSet: " + response.Error);
            }

            UpdateRewardSetData = (RewardSetResource) KnetikClient.Deserialize(response.Content, typeof(RewardSetResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateRewardSetStartTime, "UpdateRewardSet", string.Format("Response received successfully:\n{0}", UpdateRewardSetData));

            if (UpdateRewardSetComplete != null)
            {
                UpdateRewardSetComplete(response.ResponseCode, UpdateRewardSetData);
            }
        }

    }
}
