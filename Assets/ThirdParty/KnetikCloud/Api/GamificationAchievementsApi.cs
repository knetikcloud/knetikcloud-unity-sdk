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
    public interface IGamificationAchievementsApi
    {
        /// <summary>
        /// Create a new achievement definition If the definition contains a trigger event name, a BRE rule is created, so that tracking logic is executed when the triggering event occurs. If no trigger event name is specified, the user&#39;s achievement status must manually be updated via the API.
        /// </summary>
        /// <param name="achievement">The achievement definition</param>
        /// <returns>AchievementDefinitionResource</returns>
        AchievementDefinitionResource CreateAchievement (AchievementDefinitionResource achievement);
        /// <summary>
        /// Create an achievement template Achievement templates define a type of achievement and the properties they have
        /// </summary>
        /// <param name="template">The achievement template to be created</param>
        /// <returns>TemplateResource</returns>
        TemplateResource CreateAchievementTemplate (TemplateResource template);
        /// <summary>
        /// Delete an achievement definition Will also disable the associated generated rule, if any.
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        /// <returns></returns>
        void DeleteAchievement (string name);
        /// <summary>
        /// Delete an achievement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        /// <returns></returns>
        void DeleteAchievementTemplate (string id, string cascade);
        /// <summary>
        /// Get a single achievement definition 
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        /// <returns>AchievementDefinitionResource</returns>
        AchievementDefinitionResource GetAchievement (string name);
        /// <summary>
        /// Get a single achievement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <returns>TemplateResource</returns>
        TemplateResource GetAchievementTemplate (string id);
        /// <summary>
        /// List and search achievement templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceTemplateResource</returns>
        PageResourceTemplateResource GetAchievementTemplates (int? size, int? page, string order);
        /// <summary>
        /// Get the list of triggers that can be used to trigger an achievement progress update 
        /// </summary>
        /// <returns>List&lt;BreTriggerResource&gt;</returns>
        List<BreTriggerResource> GetAchievementTriggers ();
        /// <summary>
        /// Get all achievement definitions in the system 
        /// </summary>
        /// <param name="filterTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterName">Filter for achievements whose name contains a string</param>
        /// <param name="filterHidden">Filter for achievements that are hidden or not</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <param name="filterDerived">Filter for achievements that are derived from other services</param>
        /// <returns>PageResourceAchievementDefinitionResource</returns>
        PageResourceAchievementDefinitionResource GetAchievements (string filterTagset, string filterName, bool? filterHidden, int? size, int? page, string order, bool? filterDerived);
        /// <summary>
        /// Get a list of derived achievements Used by other services that depend on achievements
        /// </summary>
        /// <param name="name">The name of the derived achievement</param>
        /// <returns>List&lt;AchievementDefinitionResource&gt;</returns>
        List<AchievementDefinitionResource> GetDerivedAchievements (string name);
        /// <summary>
        /// Retrieve progress on a given achievement for a given user Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed.
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="achievementName">The achievement&#39;s name</param>
        /// <returns>UserAchievementGroupResource</returns>
        UserAchievementGroupResource GetUserAchievementProgress (int? userId, string achievementName);
        /// <summary>
        /// Retrieve progress on achievements for a given user Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed.
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param>
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceUserAchievementGroupResource</returns>
        PageResourceUserAchievementGroupResource GetUserAchievementsProgress (int? userId, bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page);
        /// <summary>
        /// Retrieve progress on a given achievement for all users Assets will not be filled in on the resources returned. Use &#39;Get single achievement progress for user&#39; to retrieve the full resource with assets for a given user as needed.
        /// </summary>
        /// <param name="achievementName">The achievement&#39;s name</param>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param>
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceUserAchievementGroupResource</returns>
        PageResourceUserAchievementGroupResource GetUsersAchievementProgress (string achievementName, bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page);
        /// <summary>
        /// Retrieve progress on achievements for all users Assets will not be filled in on the resources returned. Use &#39;Get single achievement progress for user&#39; to retrieve the full resource with assets for a given user as needed.
        /// </summary>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param>
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param>
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <returns>PageResourceUserAchievementGroupResource</returns>
        PageResourceUserAchievementGroupResource GetUsersAchievementsProgress (bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page);
        /// <summary>
        /// Increment an achievement progress record for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated and the provided value added to the existing progress. May be negative. If progress meets or exceeds the achievement&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;.
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="achievementName">The achievement&#39;s name</param>
        /// <param name="progress">The amount to add to the progress value</param>
        /// <returns>UserAchievementGroupResource</returns>
        UserAchievementGroupResource IncrementAchievementProgress (int? userId, string achievementName, IntWrapper progress);
        /// <summary>
        /// Set an achievement progress record for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated and progress set to the provided value. If progress meets or exceeds the achievement&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;.
        /// </summary>
        /// <param name="userId">The user&#39;s id</param>
        /// <param name="achievementName">The achievement&#39;s name</param>
        /// <param name="progress">The new progress value</param>
        /// <returns>UserAchievementGroupResource</returns>
        UserAchievementGroupResource SetAchievementProgress (int? userId, string achievementName, IntWrapper progress);
        /// <summary>
        /// Update an achievement definition The existing generated rule, if any, will be deleted. A new rule will be created if a trigger event name is specified in the new version.
        /// </summary>
        /// <param name="name">The name of the achievement</param>
        /// <param name="achievement">The achievement definition</param>
        /// <returns>AchievementDefinitionResource</returns>
        AchievementDefinitionResource UpdateAchievement (string name, AchievementDefinitionResource achievement);
        /// <summary>
        /// Update an achievement template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="template">The updated template</param>
        /// <returns>TemplateResource</returns>
        TemplateResource UpdateAchievementTemplate (string id, TemplateResource template);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class GamificationAchievementsApi : IGamificationAchievementsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GamificationAchievementsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GamificationAchievementsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Create a new achievement definition If the definition contains a trigger event name, a BRE rule is created, so that tracking logic is executed when the triggering event occurs. If no trigger event name is specified, the user&#39;s achievement status must manually be updated via the API.
        /// </summary>
        /// <param name="achievement">The achievement definition</param> 
        /// <returns>AchievementDefinitionResource</returns>            
        public AchievementDefinitionResource CreateAchievement(AchievementDefinitionResource achievement)
        {
            
            string urlPath = "/achievements";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(achievement); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateAchievement: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateAchievement: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (AchievementDefinitionResource) KnetikClient.Deserialize(response.Content, typeof(AchievementDefinitionResource), response.Headers);
        }
        /// <summary>
        /// Create an achievement template Achievement templates define a type of achievement and the properties they have
        /// </summary>
        /// <param name="template">The achievement template to be created</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource CreateAchievementTemplate(TemplateResource template)
        {
            
            string urlPath = "/achievements/templates";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateAchievementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateAchievementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
        /// <summary>
        /// Delete an achievement definition Will also disable the associated generated rule, if any.
        /// </summary>
        /// <param name="name">The name of the achievement</param> 
        /// <returns></returns>            
        public void DeleteAchievement(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling DeleteAchievement");
            }
            
            
            string urlPath = "/achievements/{name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteAchievement: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteAchievement: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete an achievement template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="cascade">The value needed to delete used templates</param> 
        /// <returns></returns>            
        public void DeleteAchievementTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteAchievementTemplate");
            }
            
            
            string urlPath = "/achievements/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.ParameterToString(cascade));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteAchievementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteAchievementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get a single achievement definition 
        /// </summary>
        /// <param name="name">The name of the achievement</param> 
        /// <returns>AchievementDefinitionResource</returns>            
        public AchievementDefinitionResource GetAchievement(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetAchievement");
            }
            
            
            string urlPath = "/achievements/{name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetAchievement: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetAchievement: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (AchievementDefinitionResource) KnetikClient.Deserialize(response.Content, typeof(AchievementDefinitionResource), response.Headers);
        }
        /// <summary>
        /// Get a single achievement template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource GetAchievementTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetAchievementTemplate");
            }
            
            
            string urlPath = "/achievements/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetAchievementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetAchievementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
        /// <summary>
        /// List and search achievement templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceTemplateResource</returns>            
        public PageResourceTemplateResource GetAchievementTemplates(int? size, int? page, string order)
        {
            
            string urlPath = "/achievements/templates";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetAchievementTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetAchievementTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
        }
        /// <summary>
        /// Get the list of triggers that can be used to trigger an achievement progress update 
        /// </summary>
        /// <returns>List&lt;BreTriggerResource&gt;</returns>            
        public List<BreTriggerResource> GetAchievementTriggers()
        {
            
            string urlPath = "/achievements/triggers";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetAchievementTriggers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetAchievementTriggers: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<BreTriggerResource>) KnetikClient.Deserialize(response.Content, typeof(List<BreTriggerResource>), response.Headers);
        }
        /// <summary>
        /// Get all achievement definitions in the system 
        /// </summary>
        /// <param name="filterTagset">Filter for achievements with specified tags (separated by comma)</param> 
        /// <param name="filterName">Filter for achievements whose name contains a string</param> 
        /// <param name="filterHidden">Filter for achievements that are hidden or not</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <param name="filterDerived">Filter for achievements that are derived from other services</param> 
        /// <returns>PageResourceAchievementDefinitionResource</returns>            
        public PageResourceAchievementDefinitionResource GetAchievements(string filterTagset, string filterName, bool? filterHidden, int? size, int? page, string order, bool? filterDerived)
        {
            
            string urlPath = "/achievements";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.ParameterToString(filterTagset));
            }
            
            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.ParameterToString(filterName));
            }
            
            if (filterHidden != null)
            {
                queryParams.Add("filter_hidden", KnetikClient.ParameterToString(filterHidden));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }
            
            if (filterDerived != null)
            {
                queryParams.Add("filter_derived", KnetikClient.ParameterToString(filterDerived));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetAchievements: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetAchievements: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceAchievementDefinitionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceAchievementDefinitionResource), response.Headers);
        }
        /// <summary>
        /// Get a list of derived achievements Used by other services that depend on achievements
        /// </summary>
        /// <param name="name">The name of the derived achievement</param> 
        /// <returns>List&lt;AchievementDefinitionResource&gt;</returns>            
        public List<AchievementDefinitionResource> GetDerivedAchievements(string name)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling GetDerivedAchievements");
            }
            
            
            string urlPath = "/achievements/derived/{name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetDerivedAchievements: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetDerivedAchievements: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<AchievementDefinitionResource>) KnetikClient.Deserialize(response.Content, typeof(List<AchievementDefinitionResource>), response.Headers);
        }
        /// <summary>
        /// Retrieve progress on a given achievement for a given user Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed.
        /// </summary>
        /// <param name="userId">The user&#39;s id</param> 
        /// <param name="achievementName">The achievement&#39;s name</param> 
        /// <returns>UserAchievementGroupResource</returns>            
        public UserAchievementGroupResource GetUserAchievementProgress(int? userId, string achievementName)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserAchievementProgress");
            }
            
            // verify the required parameter 'achievementName' is set
            if (achievementName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'achievementName' when calling GetUserAchievementProgress");
            }
            
            
            string urlPath = "/users/{user_id}/achievements/{achievement_name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
urlPath = urlPath.Replace("{" + "achievement_name" + "}", KnetikClient.ParameterToString(achievementName));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserAchievementProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserAchievementProgress: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (UserAchievementGroupResource) KnetikClient.Deserialize(response.Content, typeof(UserAchievementGroupResource), response.Headers);
        }
        /// <summary>
        /// Retrieve progress on achievements for a given user Assets will not be filled in on the resources returned. Use &#39;Get a single poll&#39; to retrieve the full resource with assets for a given item as needed.
        /// </summary>
        /// <param name="userId">The user&#39;s id</param> 
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param> 
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param> 
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceUserAchievementGroupResource</returns>            
        public PageResourceUserAchievementGroupResource GetUserAchievementsProgress(int? userId, bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetUserAchievementsProgress");
            }
            
            
            string urlPath = "/users/{user_id}/achievements";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterAchievementDerived != null)
            {
                queryParams.Add("filter_achievement_derived", KnetikClient.ParameterToString(filterAchievementDerived));
            }
            
            if (filterAchievementTagset != null)
            {
                queryParams.Add("filter_achievement_tagset", KnetikClient.ParameterToString(filterAchievementTagset));
            }
            
            if (filterAchievementName != null)
            {
                queryParams.Add("filter_achievement_name", KnetikClient.ParameterToString(filterAchievementName));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserAchievementsProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUserAchievementsProgress: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceUserAchievementGroupResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserAchievementGroupResource), response.Headers);
        }
        /// <summary>
        /// Retrieve progress on a given achievement for all users Assets will not be filled in on the resources returned. Use &#39;Get single achievement progress for user&#39; to retrieve the full resource with assets for a given user as needed.
        /// </summary>
        /// <param name="achievementName">The achievement&#39;s name</param> 
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param> 
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param> 
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceUserAchievementGroupResource</returns>            
        public PageResourceUserAchievementGroupResource GetUsersAchievementProgress(string achievementName, bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page)
        {
            // verify the required parameter 'achievementName' is set
            if (achievementName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'achievementName' when calling GetUsersAchievementProgress");
            }
            
            
            string urlPath = "/users/achievements/{achievement_name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "achievement_name" + "}", KnetikClient.ParameterToString(achievementName));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterAchievementDerived != null)
            {
                queryParams.Add("filter_achievement_derived", KnetikClient.ParameterToString(filterAchievementDerived));
            }
            
            if (filterAchievementTagset != null)
            {
                queryParams.Add("filter_achievement_tagset", KnetikClient.ParameterToString(filterAchievementTagset));
            }
            
            if (filterAchievementName != null)
            {
                queryParams.Add("filter_achievement_name", KnetikClient.ParameterToString(filterAchievementName));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsersAchievementProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsersAchievementProgress: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceUserAchievementGroupResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserAchievementGroupResource), response.Headers);
        }
        /// <summary>
        /// Retrieve progress on achievements for all users Assets will not be filled in on the resources returned. Use &#39;Get single achievement progress for user&#39; to retrieve the full resource with assets for a given user as needed.
        /// </summary>
        /// <param name="filterAchievementDerived">Filter for achievements that are derived from other services</param> 
        /// <param name="filterAchievementTagset">Filter for achievements with specified tags (separated by comma)</param> 
        /// <param name="filterAchievementName">Filter for achievements whose name contains a string</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <returns>PageResourceUserAchievementGroupResource</returns>            
        public PageResourceUserAchievementGroupResource GetUsersAchievementsProgress(bool? filterAchievementDerived, string filterAchievementTagset, string filterAchievementName, int? size, int? page)
        {
            
            string urlPath = "/users/achievements";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterAchievementDerived != null)
            {
                queryParams.Add("filter_achievement_derived", KnetikClient.ParameterToString(filterAchievementDerived));
            }
            
            if (filterAchievementTagset != null)
            {
                queryParams.Add("filter_achievement_tagset", KnetikClient.ParameterToString(filterAchievementTagset));
            }
            
            if (filterAchievementName != null)
            {
                queryParams.Add("filter_achievement_name", KnetikClient.ParameterToString(filterAchievementName));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsersAchievementsProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetUsersAchievementsProgress: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceUserAchievementGroupResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceUserAchievementGroupResource), response.Headers);
        }
        /// <summary>
        /// Increment an achievement progress record for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated and the provided value added to the existing progress. May be negative. If progress meets or exceeds the achievement&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;.
        /// </summary>
        /// <param name="userId">The user&#39;s id</param> 
        /// <param name="achievementName">The achievement&#39;s name</param> 
        /// <param name="progress">The amount to add to the progress value</param> 
        /// <returns>UserAchievementGroupResource</returns>            
        public UserAchievementGroupResource IncrementAchievementProgress(int? userId, string achievementName, IntWrapper progress)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling IncrementAchievementProgress");
            }
            
            // verify the required parameter 'achievementName' is set
            if (achievementName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'achievementName' when calling IncrementAchievementProgress");
            }
            
            
            string urlPath = "/users/{user_id}/achievements/{achievement_name}/progress";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
urlPath = urlPath.Replace("{" + "achievement_name" + "}", KnetikClient.ParameterToString(achievementName));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(progress); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling IncrementAchievementProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling IncrementAchievementProgress: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (UserAchievementGroupResource) KnetikClient.Deserialize(response.Content, typeof(UserAchievementGroupResource), response.Headers);
        }
        /// <summary>
        /// Set an achievement progress record for a user If no progress record yet exists for the user, it will be created. Otherwise it will be updated and progress set to the provided value. If progress meets or exceeds the achievement&#39;s max_value it will be marked as earned and a BRE event will be triggered for the &lt;code&gt;BreAchievementEarnedTrigger&lt;/code&gt;.
        /// </summary>
        /// <param name="userId">The user&#39;s id</param> 
        /// <param name="achievementName">The achievement&#39;s name</param> 
        /// <param name="progress">The new progress value</param> 
        /// <returns>UserAchievementGroupResource</returns>            
        public UserAchievementGroupResource SetAchievementProgress(int? userId, string achievementName, IntWrapper progress)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling SetAchievementProgress");
            }
            
            // verify the required parameter 'achievementName' is set
            if (achievementName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'achievementName' when calling SetAchievementProgress");
            }
            
            
            string urlPath = "/users/{user_id}/achievements/{achievement_name}/progress";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
urlPath = urlPath.Replace("{" + "achievement_name" + "}", KnetikClient.ParameterToString(achievementName));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(progress); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetAchievementProgress: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SetAchievementProgress: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (UserAchievementGroupResource) KnetikClient.Deserialize(response.Content, typeof(UserAchievementGroupResource), response.Headers);
        }
        /// <summary>
        /// Update an achievement definition The existing generated rule, if any, will be deleted. A new rule will be created if a trigger event name is specified in the new version.
        /// </summary>
        /// <param name="name">The name of the achievement</param> 
        /// <param name="achievement">The achievement definition</param> 
        /// <returns>AchievementDefinitionResource</returns>            
        public AchievementDefinitionResource UpdateAchievement(string name, AchievementDefinitionResource achievement)
        {
            // verify the required parameter 'name' is set
            if (name == null)
            {
                throw new KnetikException(400, "Missing required parameter 'name' when calling UpdateAchievement");
            }
            
            
            string urlPath = "/achievements/{name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "name" + "}", KnetikClient.ParameterToString(name));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(achievement); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateAchievement: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateAchievement: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (AchievementDefinitionResource) KnetikClient.Deserialize(response.Content, typeof(AchievementDefinitionResource), response.Headers);
        }
        /// <summary>
        /// Update an achievement template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="template">The updated template</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource UpdateAchievementTemplate(string id, TemplateResource template)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateAchievementTemplate");
            }
            
            
            string urlPath = "/achievements/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(template); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateAchievementTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateAchievementTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
    }
}
