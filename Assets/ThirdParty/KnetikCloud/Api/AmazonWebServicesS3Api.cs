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
    public interface IAmazonWebServicesS3Api
    {
        string GetDownloadURLData { get; }

        /// <summary>
        /// Get a temporary signed S3 URL for download To give access to files in your own S3 account, you will need to grant KnetikcCloud access to the file by adjusting your bucket policy accordingly. See S3 documentation for details. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; S3_ADMIN
        /// </summary>
        /// <param name="bucket">S3 bucket name</param>
        /// <param name="path">The path to the file relative the bucket (the s3 object key)</param>
        /// <param name="expiration">The number of seconds this URL will be valid. Default to 60</param>
        void GetDownloadURL(string bucket, string path, int? expiration);

        AmazonS3Activity GetSignedS3URLData { get; }

        /// <summary>
        /// Get a signed S3 URL for upload Requires the file name and file content type (i.e., &#39;video/mpeg&#39;). Make a PUT to the resulting url to upload the file and use the cdn_url to retrieve it after. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; S3_USER or S3_ADMIN
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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mGetDownloadURLResponseContext;
        private DateTime mGetDownloadURLStartTime;
        private readonly KnetikResponseContext mGetSignedS3URLResponseContext;
        private DateTime mGetSignedS3URLStartTime;

        public string GetDownloadURLData { get; private set; }
        public delegate void GetDownloadURLCompleteDelegate(long responseCode, string response);
        public GetDownloadURLCompleteDelegate GetDownloadURLComplete;

        public AmazonS3Activity GetSignedS3URLData { get; private set; }
        public delegate void GetSignedS3URLCompleteDelegate(long responseCode, AmazonS3Activity response);
        public GetSignedS3URLCompleteDelegate GetSignedS3URLComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="AmazonWebServicesS3Api"/> class.
        /// </summary>
        /// <returns></returns>
        public AmazonWebServicesS3Api()
        {
            mGetDownloadURLResponseContext = new KnetikResponseContext();
            mGetDownloadURLResponseContext.ResponseReceived += OnGetDownloadURLResponse;
            mGetSignedS3URLResponseContext = new KnetikResponseContext();
            mGetSignedS3URLResponseContext.ResponseReceived += OnGetSignedS3URLResponse;
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Get a temporary signed S3 URL for download To give access to files in your own S3 account, you will need to grant KnetikcCloud access to the file by adjusting your bucket policy accordingly. See S3 documentation for details. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; S3_ADMIN
        /// </summary>
        /// <param name="bucket">S3 bucket name</param>
        /// <param name="path">The path to the file relative the bucket (the s3 object key)</param>
        /// <param name="expiration">The number of seconds this URL will be valid. Default to 60</param>
        public void GetDownloadURL(string bucket, string path, int? expiration)
        {
            
            mWebCallEvent.WebPath = "/amazon/s3/downloadurl";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (bucket != null)
            {
                mWebCallEvent.QueryParams["bucket"] = KnetikClient.ParameterToString(bucket);
            }

            if (path != null)
            {
                mWebCallEvent.QueryParams["path"] = KnetikClient.ParameterToString(path);
            }

            if (expiration != null)
            {
                mWebCallEvent.QueryParams["expiration"] = KnetikClient.ParameterToString(expiration);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetDownloadURLStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetDownloadURLResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetDownloadURLStartTime, "GetDownloadURL", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetDownloadURLResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetDownloadURL: " + response.Error);
            }

            GetDownloadURLData = (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
            KnetikLogger.LogResponse(mGetDownloadURLStartTime, "GetDownloadURL", string.Format("Response received successfully:\n{0}", GetDownloadURLData));

            if (GetDownloadURLComplete != null)
            {
                GetDownloadURLComplete(response.ResponseCode, GetDownloadURLData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a signed S3 URL for upload Requires the file name and file content type (i.e., &#39;video/mpeg&#39;). Make a PUT to the resulting url to upload the file and use the cdn_url to retrieve it after. &lt;br&gt;&lt;br&gt;&lt;b&gt;Permissions Needed:&lt;/b&gt; S3_USER or S3_ADMIN
        /// </summary>
        /// <param name="filename">The file name</param>
        /// <param name="contentType">The content type</param>
        public void GetSignedS3URL(string filename, string contentType)
        {
            
            mWebCallEvent.WebPath = "/amazon/s3/signedposturl";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filename != null)
            {
                mWebCallEvent.QueryParams["filename"] = KnetikClient.ParameterToString(filename);
            }

            if (contentType != null)
            {
                mWebCallEvent.QueryParams["content_type"] = KnetikClient.ParameterToString(contentType);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetSignedS3URLStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetSignedS3URLResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetSignedS3URLStartTime, "GetSignedS3URL", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetSignedS3URLResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetSignedS3URL: " + response.Error);
            }

            GetSignedS3URLData = (AmazonS3Activity) KnetikClient.Deserialize(response.Content, typeof(AmazonS3Activity), response.Headers);
            KnetikLogger.LogResponse(mGetSignedS3URLStartTime, "GetSignedS3URL", string.Format("Response received successfully:\n{0}", GetSignedS3URLData));

            if (GetSignedS3URLComplete != null)
            {
                GetSignedS3URLComplete(response.ResponseCode, GetSignedS3URLData);
            }
        }

    }
}
