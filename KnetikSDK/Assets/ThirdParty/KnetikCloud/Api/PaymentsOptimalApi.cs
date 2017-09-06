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
    public interface IPaymentsOptimalApi
    {
        /// <summary>
        /// Initiate silent post with Optimal Will return the url for a hosted payment endpoint to post to. See Optimal documentation for details.
        /// </summary>
        /// <param name="request">The payment request to initiate</param>
        /// <returns>string</returns>
        string SilentPostOptimal (OptimalPaymentRequest request);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PaymentsOptimalApi : IPaymentsOptimalApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsOptimalApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PaymentsOptimalApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Initiate silent post with Optimal Will return the url for a hosted payment endpoint to post to. See Optimal documentation for details.
        /// </summary>
        /// <param name="request">The payment request to initiate</param> 
        /// <returns>string</returns>            
        public string SilentPostOptimal(OptimalPaymentRequest request)
        {
            
            string urlPath = "/payment/provider/optimal/silent";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling SilentPostOptimal: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SilentPostOptimal: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (string) KnetikClient.Deserialize(response.Content, typeof(string), response.Headers);
        }
    }
}
