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
    public interface ICampaignsRewardsApi
    {
        RewardSetResource CreateRewardSetData { get; }

        RewardSetResource GetRewardSetData { get; }

        PageResourceRewardSetResource GetRewardSetsData { get; }

        RewardSetResource UpdateRewardSetData { get; }

        
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

        /// <summary>
        /// Get a single reward set 
        /// </summary>
        /// <param name="id">The reward id</param>
        void GetRewardSet(int? id);

        /// <summary>
        /// List and search reward sets 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetRewardSets(int? size, int? page, string order);

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
        private readonly KnetikCoroutine mCreateRewardSetCoroutine;
        private DateTime mCreateRewardSetStartTime;
        private string mCreateRewardSetPath;
        private readonly KnetikCoroutine mDeleteRewardSetCoroutine;
        private DateTime mDeleteRewardSetStartTime;
        private string mDeleteRewardSetPath;
        private readonly KnetikCoroutine mGetRewardSetCoroutine;
        private DateTime mGetRewardSetStartTime;
        private string mGetRewardSetPath;
        private readonly KnetikCoroutine mGetRewardSetsCoroutine;
        private DateTime mGetRewardSetsStartTime;
        private string mGetRewardSetsPath;
        private readonly KnetikCoroutine mUpdateRewardSetCoroutine;
        private DateTime mUpdateRewardSetStartTime;
        private string mUpdateRewardSetPath;

        public RewardSetResource CreateRewardSetData { get; private set; }
        public delegate void CreateRewardSetCompleteDelegate(RewardSetResource response);
        public CreateRewardSetCompleteDelegate CreateRewardSetComplete;

        public delegate void DeleteRewardSetCompleteDelegate();
        public DeleteRewardSetCompleteDelegate DeleteRewardSetComplete;

        public RewardSetResource GetRewardSetData { get; private set; }
        public delegate void GetRewardSetCompleteDelegate(RewardSetResource response);
        public GetRewardSetCompleteDelegate GetRewardSetComplete;

        public PageResourceRewardSetResource GetRewardSetsData { get; private set; }
        public delegate void GetRewardSetsCompleteDelegate(PageResourceRewardSetResource response);
        public GetRewardSetsCompleteDelegate GetRewardSetsComplete;

        public RewardSetResource UpdateRewardSetData { get; private set; }
        public delegate void UpdateRewardSetCompleteDelegate(RewardSetResource response);
        public UpdateRewardSetCompleteDelegate UpdateRewardSetComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignsRewardsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CampaignsRewardsApi()
        {
            mCreateRewardSetCoroutine = new KnetikCoroutine();
            mDeleteRewardSetCoroutine = new KnetikCoroutine();
            mGetRewardSetCoroutine = new KnetikCoroutine();
            mGetRewardSetsCoroutine = new KnetikCoroutine();
            mUpdateRewardSetCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Create a reward set 
        /// </summary>
        /// <param name="rewardSetResource">The reward set resource object</param>
        public void CreateRewardSet(RewardSetResource rewardSetResource)
        {
            
            mCreateRewardSetPath = "/rewards";
            if (!string.IsNullOrEmpty(mCreateRewardSetPath))
            {
                mCreateRewardSetPath = mCreateRewardSetPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(rewardSetResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateRewardSetStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateRewardSetStartTime, mCreateRewardSetPath, "Sending server request...");

            // make the HTTP request
            mCreateRewardSetCoroutine.ResponseReceived += CreateRewardSetCallback;
            mCreateRewardSetCoroutine.Start(mCreateRewardSetPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateRewardSetCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateRewardSet: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateRewardSet: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateRewardSetData = (RewardSetResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(RewardSetResource), response.Headers);
            KnetikLogger.LogResponse(mCreateRewardSetStartTime, mCreateRewardSetPath, string.Format("Response received successfully:\n{0}", CreateRewardSetData.ToString()));

            if (CreateRewardSetComplete != null)
            {
                CreateRewardSetComplete(CreateRewardSetData);
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
            
            mDeleteRewardSetPath = "/rewards/{id}";
            if (!string.IsNullOrEmpty(mDeleteRewardSetPath))
            {
                mDeleteRewardSetPath = mDeleteRewardSetPath.Replace("{format}", "json");
            }
            mDeleteRewardSetPath = mDeleteRewardSetPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteRewardSetStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteRewardSetStartTime, mDeleteRewardSetPath, "Sending server request...");

            // make the HTTP request
            mDeleteRewardSetCoroutine.ResponseReceived += DeleteRewardSetCallback;
            mDeleteRewardSetCoroutine.Start(mDeleteRewardSetPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteRewardSetCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteRewardSet: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteRewardSet: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteRewardSetStartTime, mDeleteRewardSetPath, "Response received successfully.");
            if (DeleteRewardSetComplete != null)
            {
                DeleteRewardSetComplete();
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
            
            mGetRewardSetPath = "/rewards/{id}";
            if (!string.IsNullOrEmpty(mGetRewardSetPath))
            {
                mGetRewardSetPath = mGetRewardSetPath.Replace("{format}", "json");
            }
            mGetRewardSetPath = mGetRewardSetPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetRewardSetStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetRewardSetStartTime, mGetRewardSetPath, "Sending server request...");

            // make the HTTP request
            mGetRewardSetCoroutine.ResponseReceived += GetRewardSetCallback;
            mGetRewardSetCoroutine.Start(mGetRewardSetPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetRewardSetCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRewardSet: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRewardSet: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetRewardSetData = (RewardSetResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(RewardSetResource), response.Headers);
            KnetikLogger.LogResponse(mGetRewardSetStartTime, mGetRewardSetPath, string.Format("Response received successfully:\n{0}", GetRewardSetData.ToString()));

            if (GetRewardSetComplete != null)
            {
                GetRewardSetComplete(GetRewardSetData);
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
            
            mGetRewardSetsPath = "/rewards";
            if (!string.IsNullOrEmpty(mGetRewardSetsPath))
            {
                mGetRewardSetsPath = mGetRewardSetsPath.Replace("{format}", "json");
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

            mGetRewardSetsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetRewardSetsStartTime, mGetRewardSetsPath, "Sending server request...");

            // make the HTTP request
            mGetRewardSetsCoroutine.ResponseReceived += GetRewardSetsCallback;
            mGetRewardSetsCoroutine.Start(mGetRewardSetsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetRewardSetsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRewardSets: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetRewardSets: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetRewardSetsData = (PageResourceRewardSetResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceRewardSetResource), response.Headers);
            KnetikLogger.LogResponse(mGetRewardSetsStartTime, mGetRewardSetsPath, string.Format("Response received successfully:\n{0}", GetRewardSetsData.ToString()));

            if (GetRewardSetsComplete != null)
            {
                GetRewardSetsComplete(GetRewardSetsData);
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
            
            mUpdateRewardSetPath = "/rewards/{id}";
            if (!string.IsNullOrEmpty(mUpdateRewardSetPath))
            {
                mUpdateRewardSetPath = mUpdateRewardSetPath.Replace("{format}", "json");
            }
            mUpdateRewardSetPath = mUpdateRewardSetPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(rewardSetResource); // http body (model) parameter
 
            // authentication setting, if any
            List<string> authSettings = new List<string> { "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateRewardSetStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateRewardSetStartTime, mUpdateRewardSetPath, "Sending server request...");

            // make the HTTP request
            mUpdateRewardSetCoroutine.ResponseReceived += UpdateRewardSetCallback;
            mUpdateRewardSetCoroutine.Start(mUpdateRewardSetPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateRewardSetCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateRewardSet: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateRewardSet: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateRewardSetData = (RewardSetResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(RewardSetResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateRewardSetStartTime, mUpdateRewardSetPath, string.Format("Response received successfully:\n{0}", UpdateRewardSetData.ToString()));

            if (UpdateRewardSetComplete != null)
            {
                UpdateRewardSetComplete(UpdateRewardSetData);
            }
        }

    }
}
