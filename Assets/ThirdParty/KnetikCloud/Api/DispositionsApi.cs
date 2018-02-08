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
    public interface IDispositionsApi
    {
        DispositionResource AddDispositionData { get; }

        /// <summary>
        /// Add a new disposition &lt;b&gt;Permissions Needed:&lt;/b&gt; DISPOSITIONS_USER and user, or DISPOSITIONS_ADMIN
        /// </summary>
        /// <param name="disposition">The new disposition record</param>
        void AddDisposition(DispositionResource disposition);

        

        /// <summary>
        /// Delete a disposition &lt;b&gt;Permissions Needed:&lt;/b&gt; DISPOSITIONS_USER and owner, or DISPOSITIONS_ADMIN
        /// </summary>
        /// <param name="id">The id of the disposition record</param>
        void DeleteDisposition(long? id);

        DispositionResource GetDispositionData { get; }

        /// <summary>
        /// Returns a disposition &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id of the disposition record</param>
        void GetDisposition(long? id);

        List<DispositionCount> GetDispositionCountsData { get; }

        /// <summary>
        /// Returns a list of disposition counts &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterContext">Filter for dispositions within a context type (games, articles, polls, etc). Optionally with a specific id like filter_context&#x3D;video:47</param>
        /// <param name="filterOwner">Filter for dispositions from a specific user by id or &#39;me&#39;</param>
        void GetDispositionCounts(string filterContext, string filterOwner);

        PageResourceDispositionResource GetDispositionsData { get; }

        /// <summary>
        /// Returns a page of dispositions &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterContext">Filter for dispositions within a context type (games, articles, polls, etc). Optionally with a specific id like filter_context&#x3D;video:47</param>
        /// <param name="filterOwner">Filter for dispositions from a specific user by id or &#39;me&#39;</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetDispositions(string filterContext, string filterOwner, int? size, int? page, string order);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DispositionsApi : IDispositionsApi
    {
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddDispositionResponseContext;
        private DateTime mAddDispositionStartTime;
        private readonly KnetikResponseContext mDeleteDispositionResponseContext;
        private DateTime mDeleteDispositionStartTime;
        private readonly KnetikResponseContext mGetDispositionResponseContext;
        private DateTime mGetDispositionStartTime;
        private readonly KnetikResponseContext mGetDispositionCountsResponseContext;
        private DateTime mGetDispositionCountsStartTime;
        private readonly KnetikResponseContext mGetDispositionsResponseContext;
        private DateTime mGetDispositionsStartTime;

        public DispositionResource AddDispositionData { get; private set; }
        public delegate void AddDispositionCompleteDelegate(long responseCode, DispositionResource response);
        public AddDispositionCompleteDelegate AddDispositionComplete;

        public delegate void DeleteDispositionCompleteDelegate(long responseCode);
        public DeleteDispositionCompleteDelegate DeleteDispositionComplete;

        public DispositionResource GetDispositionData { get; private set; }
        public delegate void GetDispositionCompleteDelegate(long responseCode, DispositionResource response);
        public GetDispositionCompleteDelegate GetDispositionComplete;

        public List<DispositionCount> GetDispositionCountsData { get; private set; }
        public delegate void GetDispositionCountsCompleteDelegate(long responseCode, List<DispositionCount> response);
        public GetDispositionCountsCompleteDelegate GetDispositionCountsComplete;

        public PageResourceDispositionResource GetDispositionsData { get; private set; }
        public delegate void GetDispositionsCompleteDelegate(long responseCode, PageResourceDispositionResource response);
        public GetDispositionsCompleteDelegate GetDispositionsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="DispositionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DispositionsApi()
        {
            mAddDispositionResponseContext = new KnetikResponseContext();
            mAddDispositionResponseContext.ResponseReceived += OnAddDispositionResponse;
            mDeleteDispositionResponseContext = new KnetikResponseContext();
            mDeleteDispositionResponseContext.ResponseReceived += OnDeleteDispositionResponse;
            mGetDispositionResponseContext = new KnetikResponseContext();
            mGetDispositionResponseContext.ResponseReceived += OnGetDispositionResponse;
            mGetDispositionCountsResponseContext = new KnetikResponseContext();
            mGetDispositionCountsResponseContext.ResponseReceived += OnGetDispositionCountsResponse;
            mGetDispositionsResponseContext = new KnetikResponseContext();
            mGetDispositionsResponseContext.ResponseReceived += OnGetDispositionsResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add a new disposition &lt;b&gt;Permissions Needed:&lt;/b&gt; DISPOSITIONS_USER and user, or DISPOSITIONS_ADMIN
        /// </summary>
        /// <param name="disposition">The new disposition record</param>
        public void AddDisposition(DispositionResource disposition)
        {
            
            mWebCallEvent.WebPath = "/dispositions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(disposition); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddDispositionStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddDispositionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddDispositionStartTime, "AddDisposition", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddDispositionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddDisposition: " + response.Error);
            }

            AddDispositionData = (DispositionResource) KnetikClient.Deserialize(response.Content, typeof(DispositionResource), response.Headers);
            KnetikLogger.LogResponse(mAddDispositionStartTime, "AddDisposition", string.Format("Response received successfully:\n{0}", AddDispositionData));

            if (AddDispositionComplete != null)
            {
                AddDispositionComplete(response.ResponseCode, AddDispositionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a disposition &lt;b&gt;Permissions Needed:&lt;/b&gt; DISPOSITIONS_USER and owner, or DISPOSITIONS_ADMIN
        /// </summary>
        /// <param name="id">The id of the disposition record</param>
        public void DeleteDisposition(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteDisposition");
            }
            
            mWebCallEvent.WebPath = "/dispositions/{id}";
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
            mDeleteDispositionStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteDispositionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteDispositionStartTime, "DeleteDisposition", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteDispositionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteDisposition: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteDispositionStartTime, "DeleteDisposition", "Response received successfully.");
            if (DeleteDispositionComplete != null)
            {
                DeleteDispositionComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a disposition &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="id">The id of the disposition record</param>
        public void GetDisposition(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetDisposition");
            }
            
            mWebCallEvent.WebPath = "/dispositions/{id}";
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
            mGetDispositionStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetDispositionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetDispositionStartTime, "GetDisposition", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetDispositionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetDisposition: " + response.Error);
            }

            GetDispositionData = (DispositionResource) KnetikClient.Deserialize(response.Content, typeof(DispositionResource), response.Headers);
            KnetikLogger.LogResponse(mGetDispositionStartTime, "GetDisposition", string.Format("Response received successfully:\n{0}", GetDispositionData));

            if (GetDispositionComplete != null)
            {
                GetDispositionComplete(response.ResponseCode, GetDispositionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a list of disposition counts &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterContext">Filter for dispositions within a context type (games, articles, polls, etc). Optionally with a specific id like filter_context&#x3D;video:47</param>
        /// <param name="filterOwner">Filter for dispositions from a specific user by id or &#39;me&#39;</param>
        public void GetDispositionCounts(string filterContext, string filterOwner)
        {
            
            mWebCallEvent.WebPath = "/dispositions/count";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterContext != null)
            {
                mWebCallEvent.QueryParams["filter_context"] = KnetikClient.ParameterToString(filterContext);
            }

            if (filterOwner != null)
            {
                mWebCallEvent.QueryParams["filter_owner"] = KnetikClient.ParameterToString(filterOwner);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetDispositionCountsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetDispositionCountsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetDispositionCountsStartTime, "GetDispositionCounts", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetDispositionCountsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetDispositionCounts: " + response.Error);
            }

            GetDispositionCountsData = (List<DispositionCount>) KnetikClient.Deserialize(response.Content, typeof(List<DispositionCount>), response.Headers);
            KnetikLogger.LogResponse(mGetDispositionCountsStartTime, "GetDispositionCounts", string.Format("Response received successfully:\n{0}", GetDispositionCountsData));

            if (GetDispositionCountsComplete != null)
            {
                GetDispositionCountsComplete(response.ResponseCode, GetDispositionCountsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns a page of dispositions &lt;b&gt;Permissions Needed:&lt;/b&gt; ANY
        /// </summary>
        /// <param name="filterContext">Filter for dispositions within a context type (games, articles, polls, etc). Optionally with a specific id like filter_context&#x3D;video:47</param>
        /// <param name="filterOwner">Filter for dispositions from a specific user by id or &#39;me&#39;</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetDispositions(string filterContext, string filterOwner, int? size, int? page, string order)
        {
            
            mWebCallEvent.WebPath = "/dispositions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterContext != null)
            {
                mWebCallEvent.QueryParams["filter_context"] = KnetikClient.ParameterToString(filterContext);
            }

            if (filterOwner != null)
            {
                mWebCallEvent.QueryParams["filter_owner"] = KnetikClient.ParameterToString(filterOwner);
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
            mGetDispositionsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetDispositionsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetDispositionsStartTime, "GetDispositions", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetDispositionsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetDispositions: " + response.Error);
            }

            GetDispositionsData = (PageResourceDispositionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceDispositionResource), response.Headers);
            KnetikLogger.LogResponse(mGetDispositionsStartTime, "GetDispositions", string.Format("Response received successfully:\n{0}", GetDispositionsData));

            if (GetDispositionsComplete != null)
            {
                GetDispositionsComplete(response.ResponseCode, GetDispositionsData);
            }
        }

    }
}
