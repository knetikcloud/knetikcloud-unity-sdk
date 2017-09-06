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
    public interface IAmazonWebServicesS3Api
    {
        /// <summary>
        /// Get a temporary signed S3 URL for download To give access to files in your own S3 account, you will need to grant KnetikcCloud access to the file by adjusting your bucket policy accordingly. See S3 documentation for details.
        /// </summary>
        /// <param name="bucket">S3 bucket name</param>
        /// <param name="path">The path to the file relative the bucket (the s3 object key)</param>
        /// <param name="expiration">The number of seconds this URL will be valid. Default to 60</param>
        /// <returns>string</returns>
        string GetDownloadURL (string bucket, string path, int? expiration);
        /// <summary>
        /// Get a signed S3 URL for upload Requires the file name and file content type (i.e., &#39;video/mpeg&#39;). Make a PUT to the resulting url to upload the file and use the cdn_url to retrieve it after.
        /// </summary>
        /// <param name="filename">The file name</param>
        /// <param name="contentType">The content type</param>
        /// <returns>AmazonS3Activity</returns>
        AmazonS3Activity GetSignedS3URL (string filename, string contentType);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AmazonWebServicesS3Api : IAmazonWebServicesS3Api
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AmazonWebServicesS3Api"/> class.
        /// </summary>
        /// <returns></returns>
        public AmazonWebServicesS3Api()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Get a temporary signed S3 URL for download To give access to files in your own S3 account, you will need to grant KnetikcCloud access to the file by adjusting your bucket policy accordingly. See S3 documentation for details.
        /// </summary>
        /// <param name="bucket">S3 bucket name</param> 
        /// <param name="path">The path to the file relative the bucket (the s3 object key)</param> 
        /// <param name="expiration">The number of seconds this URL will be valid. Default to 60</param> 
        /// <returns>string</returns>            
        public string GetDownloadURL(string bucket, string path, int? expiration)
        {
            
            string urlPath = "/amazon/s3/downloadurl";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (bucket != null)
            {
                queryParams.Add("bucket", KnetikClient.ParameterToString(bucket));
            }
            
            if (path != null)
            {
                queryParams.Add("path", KnetikClient.ParameterToString(path));
            }
            
            if (expiration != null)
            {
                queryParams.Add("expiration", KnetikClient.ParameterToString(expiration));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetDownloadURL: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetDownloadURL: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
        }
        /// <summary>
        /// Get a signed S3 URL for upload Requires the file name and file content type (i.e., &#39;video/mpeg&#39;). Make a PUT to the resulting url to upload the file and use the cdn_url to retrieve it after.
        /// </summary>
        /// <param name="filename">The file name</param> 
        /// <param name="contentType">The content type</param> 
        /// <returns>AmazonS3Activity</returns>            
        public AmazonS3Activity GetSignedS3URL(string filename, string contentType)
        {
            
            string urlPath = "/amazon/s3/signedposturl";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filename != null)
            {
                queryParams.Add("filename", KnetikClient.ParameterToString(filename));
            }
            
            if (contentType != null)
            {
                queryParams.Add("content_type", KnetikClient.ParameterToString(contentType));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetSignedS3URL: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetSignedS3URL: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (AmazonS3Activity) KnetikClient.Deserialize(response.Content, typeof(AmazonS3Activity), response.Headers);
        }
    }
}
