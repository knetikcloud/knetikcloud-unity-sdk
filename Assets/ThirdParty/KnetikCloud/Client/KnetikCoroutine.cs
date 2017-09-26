using System;
using RestSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.knetikcloud.Client
{
    /// <summary>
    /// Performs an asynchronous API call via Unity co-routines
    /// </summary>
    public class KnetikCoroutine : IDisposable
    {
        public delegate void ResponseReceivedCallback(IRestResponse response);

        /// <summary>
        /// Called when the API call returns.
        /// </summary>
        public ResponseReceivedCallback ResponseReceived;

        /// <summary>
        /// The API response data.  Will be NULL until the call finishes.
        /// </summary>
        public IRestResponse Response { get; private set; }

        /// <summary>
        /// Callers can poll this field until the API call returns
        /// </summary>
        public bool HasFinished { get { return (Response != null); } }

        ~KnetikCoroutine()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            ResponseReceived = null;
        }

        public void OnEnable()
        {
        }

        public void OnDisable()
        {
            ResponseReceived = null;
        }

        public void Start(string url, Method method, Dictionary<string, string> queryParams, string postBody, Dictionary<string, string> headerParams, Dictionary<string, string> formParams, Dictionary<string, FileParameter> fileParams, string[] authSettings)
        {
            KnetikClient.DefaultClient.StartCoroutine(HandleCoroutine(url, method, queryParams, postBody, headerParams, formParams, fileParams, authSettings));
        }

        private IEnumerator HandleCoroutine(string url, Method method, Dictionary<string, string> queryParams, string postBody, Dictionary<string, string> headerParams, Dictionary<string, string> formParams, Dictionary<string, FileParameter> fileParams, string[] authSettings)
        {
            yield return new WaitForEndOfFrame();

            Response = (IRestResponse)KnetikClient.DefaultClient.CallApi(url, method, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
            if (ResponseReceived != null)
            {
                ResponseReceived(Response);
            }

            yield break;
        }
    }
}
