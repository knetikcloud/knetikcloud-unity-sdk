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
    public interface IPaymentsXsollaApi
    {
        /// <summary>
        /// Create a payment token that should be used to forward the user to Xsolla so they can complete payment 
        /// </summary>
        /// <param name="request">The payment request to be sent to XSolla</param>
        /// <returns>string</returns>
        string CreateXsollaTokenUrl (XsollaPaymentRequest request);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsXsollaApi : IPaymentsXsollaApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsXsollaApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsXsollaApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a payment token that should be used to forward the user to Xsolla so they can complete payment 
        /// </summary>
        /// <param name="request">The payment request to be sent to XSolla</param> 
        /// <returns>string</returns>            
        public string CreateXsollaTokenUrl(XsollaPaymentRequest request)
        {
            
            string urlPath = "/payment/provider/xsolla/payment";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateXsollaTokenUrl: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateXsollaTokenUrl: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
        }
    }
}
