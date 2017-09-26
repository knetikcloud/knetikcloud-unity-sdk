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
    public interface IAmazonWebServicesS3Api
    {
        string GetDownloadURLData { get; }

        AmazonS3Activity GetSignedS3URLData { get; }

        
        /// <summary>
        /// Get a temporary signed S3 URL for download To give access to files in your own S3 account, you will need to grant KnetikcCloud access to the file by adjusting your bucket policy accordingly. See S3 documentation for details.
        /// </summary>
        /// <param name="bucket">S3 bucket name</param>
        /// <param name="path">The path to the file relative the bucket (the s3 object key)</param>
        /// <param name="expiration">The number of seconds this URL will be valid. Default to 60</param>
        void GetDownloadURL(string bucket, string path, int? expiration);

        /// <summary>
        /// Get a signed S3 URL for upload Requires the file name and file content type (i.e., &#39;video/mpeg&#39;). Make a PUT to the resulting url to upload the file and use the cdn_url to retrieve it after.
        /// </summary>
        /// <param name="filename">The file name</param>
        /// <param name="contentType">The content type</param>
        void GetSignedS3URL(string filename, string contentType);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AmazonWebServicesS3Api : IAmazonWebServicesS3Api
    {
        private readonly KnetikCoroutine mGetDownloadURLCoroutine;
        private DateTime mGetDownloadURLStartTime;
        private string mGetDownloadURLPath;
        private readonly KnetikCoroutine mGetSignedS3URLCoroutine;
        private DateTime mGetSignedS3URLStartTime;
        private string mGetSignedS3URLPath;

        public string GetDownloadURLData { get; private set; }
        public delegate void GetDownloadURLCompleteDelegate(string response);
        public GetDownloadURLCompleteDelegate GetDownloadURLComplete;

        public AmazonS3Activity GetSignedS3URLData { get; private set; }
        public delegate void GetSignedS3URLCompleteDelegate(AmazonS3Activity response);
        public GetSignedS3URLCompleteDelegate GetSignedS3URLComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="AmazonWebServicesS3Api"/> class.
        /// </summary>
        /// <returns></returns>
        public AmazonWebServicesS3Api()
        {
            mGetDownloadURLCoroutine = new KnetikCoroutine();
            mGetSignedS3URLCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get a temporary signed S3 URL for download To give access to files in your own S3 account, you will need to grant KnetikcCloud access to the file by adjusting your bucket policy accordingly. See S3 documentation for details.
        /// </summary>
        /// <param name="bucket">S3 bucket name</param>
        /// <param name="path">The path to the file relative the bucket (the s3 object key)</param>
        /// <param name="expiration">The number of seconds this URL will be valid. Default to 60</param>
        public void GetDownloadURL(string bucket, string path, int? expiration)
        {
            
            mGetDownloadURLPath = "/amazon/s3/downloadurl";
            if (!string.IsNullOrEmpty(mGetDownloadURLPath))
            {
                mGetDownloadURLPath = mGetDownloadURLPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (bucket != null)
            {
                queryParams.Add("bucket", KnetikClient.DefaultClient.ParameterToString(bucket));
            }

            if (path != null)
            {
                queryParams.Add("path", KnetikClient.DefaultClient.ParameterToString(path));
            }

            if (expiration != null)
            {
                queryParams.Add("expiration", KnetikClient.DefaultClient.ParameterToString(expiration));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetDownloadURLStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetDownloadURLStartTime, mGetDownloadURLPath, "Sending server request...");

            // make the HTTP request
            mGetDownloadURLCoroutine.ResponseReceived += GetDownloadURLCallback;
            mGetDownloadURLCoroutine.Start(mGetDownloadURLPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetDownloadURLCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDownloadURL: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetDownloadURL: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetDownloadURLData = (string) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mGetDownloadURLStartTime, mGetDownloadURLPath, string.Format("Response received successfully:\n{0}", GetDownloadURLData.ToString()));

            if (GetDownloadURLComplete != null)
            {
                GetDownloadURLComplete(GetDownloadURLData);
            }
        }
        /// <inheritdoc />
        /// <summary>
        /// Get a signed S3 URL for upload Requires the file name and file content type (i.e., &#39;video/mpeg&#39;). Make a PUT to the resulting url to upload the file and use the cdn_url to retrieve it after.
        /// </summary>
        /// <param name="filename">The file name</param>
        /// <param name="contentType">The content type</param>
        public void GetSignedS3URL(string filename, string contentType)
        {
            
            mGetSignedS3URLPath = "/amazon/s3/signedposturl";
            if (!string.IsNullOrEmpty(mGetSignedS3URLPath))
            {
                mGetSignedS3URLPath = mGetSignedS3URLPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filename != null)
            {
                queryParams.Add("filename", KnetikClient.DefaultClient.ParameterToString(filename));
            }

            if (contentType != null)
            {
                queryParams.Add("content_type", KnetikClient.DefaultClient.ParameterToString(contentType));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetSignedS3URLStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetSignedS3URLStartTime, mGetSignedS3URLPath, "Sending server request...");

            // make the HTTP request
            mGetSignedS3URLCoroutine.ResponseReceived += GetSignedS3URLCallback;
            mGetSignedS3URLCoroutine.Start(mGetSignedS3URLPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetSignedS3URLCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSignedS3URL: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetSignedS3URL: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetSignedS3URLData = (AmazonS3Activity) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(AmazonS3Activity), response.Headers);
            KnetikLogger.LogResponse(mGetSignedS3URLStartTime, mGetSignedS3URLPath, string.Format("Response received successfully:\n{0}", GetSignedS3URLData.ToString()));

            if (GetSignedS3URLComplete != null)
            {
                GetSignedS3URLComplete(GetSignedS3URLData);
            }
        }
    }
}
