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
    public interface IUsersGroupsApi
    {
        /// <summary>
        /// Adds a new member to the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="user">The id and status for a user to add to the group</param>
        /// <returns>GroupMemberResource</returns>
        GroupMemberResource AddMemberToGroup (string uniqueName, GroupMemberResource user);
        /// <summary>
        /// Adds multiple members to the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="users">The id and status for a list of users to add to the group</param>
        /// <returns>List&lt;GroupMemberResource&gt;</returns>
        List<GroupMemberResource> AddMembersToGroup (string uniqueName, List<GroupMemberResource> users);
        /// <summary>
        /// Create a group 
        /// </summary>
        /// <param name="groupResource">The new group</param>
        /// <returns>GroupResource</returns>
        GroupResource CreateGroup (GroupResource groupResource);
        /// <summary>
        /// Create an group member template GroupMember Templates define a type of group member and the properties they have
        /// </summary>
        /// <param name="groupMemberTemplateResource">The group member template resource object</param>
        /// <returns>TemplateResource</returns>
        TemplateResource CreateGroupMemberTemplate (TemplateResource groupMemberTemplateResource);
        /// <summary>
        /// Create a group template Group Templates define a type of group and the properties they have
        /// </summary>
        /// <param name="groupTemplateResource">The group template resource object</param>
        /// <returns>TemplateResource</returns>
        TemplateResource CreateGroupTemplate (TemplateResource groupTemplateResource);
        /// <summary>
        /// Removes a group from the system IF no resources are attached to it 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <returns></returns>
        void DeleteGroup (string uniqueName);
        /// <summary>
        /// Delete an group member template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        /// <returns></returns>
        void DeleteGroupMemberTemplate (string id, string cascade);
        /// <summary>
        /// Delete a group template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        /// <returns></returns>
        void DeleteGroupTemplate (string id, string cascade);
        /// <summary>
        /// Loads a specific group&#39;s details 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <returns>GroupResource</returns>
        GroupResource GetGroup (string uniqueName);
        /// <summary>
        /// Get a user from a group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The id of the user</param>
        /// <returns>GroupMemberResource</returns>
        GroupMemberResource GetGroupMember (string uniqueName, int? userId);
        /// <summary>
        /// Get a single group member template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <returns>TemplateResource</returns>
        TemplateResource GetGroupMemberTemplate (string id);
        /// <summary>
        /// List and search group member templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceTemplateResource</returns>
        PageResourceTemplateResource GetGroupMemberTemplates (int? size, int? page, string order);
        /// <summary>
        /// Lists members of the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceGroupMemberResource</returns>
        PageResourceGroupMemberResource GetGroupMembers (string uniqueName, int? size, int? page, string order);
        /// <summary>
        /// Get a single group template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <returns>TemplateResource</returns>
        TemplateResource GetGroupTemplate (string id);
        /// <summary>
        /// List and search group templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">a comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceTemplateResource</returns>
        PageResourceTemplateResource GetGroupTemplates (int? size, int? page, string order);
        /// <summary>
        /// List groups a user is in 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetGroupsForUser (int? userId);
        /// <summary>
        /// List and search groups 
        /// </summary>
        /// <param name="filterTemplate">Filter for groups using a specific template, by id</param>
        /// <param name="filterMemberCount">Filters groups by member count. Multiple values possible for range search. Format: filter_member_count&#x3D;OP,ts&amp;... where OP in (GT, LT, GOE, LOE, EQ). Ex: filter_member_count&#x3D;GT,14,LT,17</param>
        /// <param name="filterName">Filter for groups with names starting with the given string</param>
        /// <param name="filterUniqueName">Filter for groups whose unique_name starts with provided string</param>
        /// <param name="filterParent">Filter for groups with a specific parent, by unique name</param>
        /// <param name="filterStatus">Filter for groups with a certain status</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceGroupResource</returns>
        PageResourceGroupResource ListGroups (string filterTemplate, string filterMemberCount, string filterName, string filterUniqueName, string filterParent, string filterStatus, int? size, int? page, string order);
        /// <summary>
        /// Removes a user from a group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The id of the user to remove</param>
        /// <returns></returns>
        void RemoveGroupMember (string uniqueName, int? userId);
        /// <summary>
        /// Update a group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="groupResource">The updated group</param>
        /// <returns></returns>
        void UpdateGroup (string uniqueName, GroupResource groupResource);
        /// <summary>
        /// Change a user&#39;s order 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The user id of the member to modify</param>
        /// <param name="order">The new order for the membership</param>
        /// <returns></returns>
        void UpdateGroupMemberProperties (string uniqueName, int? userId, StringWrapper order);
        /// <summary>
        /// Change a user&#39;s membership properties 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The user id of the member to modify</param>
        /// <param name="properties">The new properties for the membership</param>
        /// <returns></returns>
        void UpdateGroupMemberProperties1 (string uniqueName, int? userId, Object properties);
        /// <summary>
        /// Change a user&#39;s status 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The user id of the member to modify</param>
        /// <param name="status">The new status for the user</param>
        /// <returns></returns>
        void UpdateGroupMemberStatus (string uniqueName, int? userId, string status);
        /// <summary>
        /// Update an group member template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="groupMemberTemplateResource">The group member template resource object</param>
        /// <returns>TemplateResource</returns>
        TemplateResource UpdateGroupMemberTemplate (string id, TemplateResource groupMemberTemplateResource);
        /// <summary>
        /// Update a group template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="groupTemplateResource">The group template resource object</param>
        /// <returns>TemplateResource</returns>
        TemplateResource UpdateGroupTemplate (string id, TemplateResource groupTemplateResource);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UsersGroupsApi : IUsersGroupsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersGroupsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersGroupsApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Adds a new member to the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param> 
        /// <param name="user">The id and status for a user to add to the group</param> 
        /// <returns>GroupMemberResource</returns>            
        public GroupMemberResource AddMemberToGroup(string uniqueName, GroupMemberResource user)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling AddMemberToGroup");
            }
            
            // verify the required parameter 'user' is set
            if (user == null)
            {
                throw new KnetikException(400, "Missing required parameter 'user' when calling AddMemberToGroup");
            }
            
            
            string urlPath = "/users/groups/{unique_name}/members";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(user); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddMemberToGroup: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddMemberToGroup: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (GroupMemberResource) KnetikClient.Deserialize(response.Content, typeof(GroupMemberResource), response.Headers);
        }
        /// <summary>
        /// Adds multiple members to the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param> 
        /// <param name="users">The id and status for a list of users to add to the group</param> 
        /// <returns>List&lt;GroupMemberResource&gt;</returns>            
        public List<GroupMemberResource> AddMembersToGroup(string uniqueName, List<GroupMemberResource> users)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling AddMembersToGroup");
            }
            
            // verify the required parameter 'users' is set
            if (users == null)
            {
                throw new KnetikException(400, "Missing required parameter 'users' when calling AddMembersToGroup");
            }
            
            
            string urlPath = "/users/groups/{unique_name}/members/batch-add";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(users); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddMembersToGroup: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddMembersToGroup: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<GroupMemberResource>) KnetikClient.Deserialize(response.Content, typeof(List<GroupMemberResource>), response.Headers);
        }
        /// <summary>
        /// Create a group 
        /// </summary>
        /// <param name="groupResource">The new group</param> 
        /// <returns>GroupResource</returns>            
        public GroupResource CreateGroup(GroupResource groupResource)
        {
            
            string urlPath = "/users/groups";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(groupResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateGroup: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateGroup: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (GroupResource) KnetikClient.Deserialize(response.Content, typeof(GroupResource), response.Headers);
        }
        /// <summary>
        /// Create an group member template GroupMember Templates define a type of group member and the properties they have
        /// </summary>
        /// <param name="groupMemberTemplateResource">The group member template resource object</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource CreateGroupMemberTemplate(TemplateResource groupMemberTemplateResource)
        {
            
            string urlPath = "/users/groups/members/templates";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(groupMemberTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateGroupMemberTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateGroupMemberTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
        /// <summary>
        /// Create a group template Group Templates define a type of group and the properties they have
        /// </summary>
        /// <param name="groupTemplateResource">The group template resource object</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource CreateGroupTemplate(TemplateResource groupTemplateResource)
        {
            
            string urlPath = "/users/groups/templates";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(groupTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateGroupTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateGroupTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
        /// <summary>
        /// Removes a group from the system IF no resources are attached to it 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param> 
        /// <returns></returns>            
        public void DeleteGroup(string uniqueName)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling DeleteGroup");
            }
            
            
            string urlPath = "/users/groups/{unique_name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteGroup: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteGroup: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete an group member template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="cascade">The value needed to delete used templates</param> 
        /// <returns></returns>            
        public void DeleteGroupMemberTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteGroupMemberTemplate");
            }
            
            
            string urlPath = "/users/groups/members/templates/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteGroupMemberTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteGroupMemberTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete a group template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="cascade">The value needed to delete used templates</param> 
        /// <returns></returns>            
        public void DeleteGroupTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteGroupTemplate");
            }
            
            
            string urlPath = "/users/groups/templates/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteGroupTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteGroupTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Loads a specific group&#39;s details 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param> 
        /// <returns>GroupResource</returns>            
        public GroupResource GetGroup(string uniqueName)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling GetGroup");
            }
            
            
            string urlPath = "/users/groups/{unique_name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroup: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroup: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (GroupResource) KnetikClient.Deserialize(response.Content, typeof(GroupResource), response.Headers);
        }
        /// <summary>
        /// Get a user from a group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param> 
        /// <param name="userId">The id of the user</param> 
        /// <returns>GroupMemberResource</returns>            
        public GroupMemberResource GetGroupMember(string uniqueName, int? userId)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling GetGroupMember");
            }
            
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetGroupMember");
            }
            
            
            string urlPath = "/users/groups/{unique_name}/members/{user_id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupMember: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupMember: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (GroupMemberResource) KnetikClient.Deserialize(response.Content, typeof(GroupMemberResource), response.Headers);
        }
        /// <summary>
        /// Get a single group member template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource GetGroupMemberTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetGroupMemberTemplate");
            }
            
            
            string urlPath = "/users/groups/members/templates/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupMemberTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupMemberTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
        /// <summary>
        /// List and search group member templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceTemplateResource</returns>            
        public PageResourceTemplateResource GetGroupMemberTemplates(int? size, int? page, string order)
        {
            
            string urlPath = "/users/groups/members/templates";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupMemberTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupMemberTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
        }
        /// <summary>
        /// Lists members of the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceGroupMemberResource</returns>            
        public PageResourceGroupMemberResource GetGroupMembers(string uniqueName, int? size, int? page, string order)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling GetGroupMembers");
            }
            
            
            string urlPath = "/users/groups/{unique_name}/members";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
    
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
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupMembers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupMembers: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceGroupMemberResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceGroupMemberResource), response.Headers);
        }
        /// <summary>
        /// Get a single group template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource GetGroupTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetGroupTemplate");
            }
            
            
            string urlPath = "/users/groups/templates/{id}";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
        /// <summary>
        /// List and search group templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">a comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceTemplateResource</returns>            
        public PageResourceTemplateResource GetGroupTemplates(int? size, int? page, string order)
        {
            
            string urlPath = "/users/groups/templates";
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
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
        }
        /// <summary>
        /// List groups a user is in 
        /// </summary>
        /// <param name="userId">The id of the user</param> 
        /// <returns>List&lt;string&gt;</returns>            
        public List<string> GetGroupsForUser(int? userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetGroupsForUser");
            }
            
            
            string urlPath = "/users/{user_id}/groups";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupsForUser: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetGroupsForUser: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
        }
        /// <summary>
        /// List and search groups 
        /// </summary>
        /// <param name="filterTemplate">Filter for groups using a specific template, by id</param> 
        /// <param name="filterMemberCount">Filters groups by member count. Multiple values possible for range search. Format: filter_member_count&#x3D;OP,ts&amp;... where OP in (GT, LT, GOE, LOE, EQ). Ex: filter_member_count&#x3D;GT,14,LT,17</param> 
        /// <param name="filterName">Filter for groups with names starting with the given string</param> 
        /// <param name="filterUniqueName">Filter for groups whose unique_name starts with provided string</param> 
        /// <param name="filterParent">Filter for groups with a specific parent, by unique name</param> 
        /// <param name="filterStatus">Filter for groups with a certain status</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceGroupResource</returns>            
        public PageResourceGroupResource ListGroups(string filterTemplate, string filterMemberCount, string filterName, string filterUniqueName, string filterParent, string filterStatus, int? size, int? page, string order)
        {
            
            string urlPath = "/users/groups";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterTemplate != null)
            {
                queryParams.Add("filter_template", KnetikClient.ParameterToString(filterTemplate));
            }
            
            if (filterMemberCount != null)
            {
                queryParams.Add("filter_member_count", KnetikClient.ParameterToString(filterMemberCount));
            }
            
            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.ParameterToString(filterName));
            }
            
            if (filterUniqueName != null)
            {
                queryParams.Add("filter_unique_name", KnetikClient.ParameterToString(filterUniqueName));
            }
            
            if (filterParent != null)
            {
                queryParams.Add("filter_parent", KnetikClient.ParameterToString(filterParent));
            }
            
            if (filterStatus != null)
            {
                queryParams.Add("filter_status", KnetikClient.ParameterToString(filterStatus));
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
            
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling ListGroups: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling ListGroups: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceGroupResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceGroupResource), response.Headers);
        }
        /// <summary>
        /// Removes a user from a group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param> 
        /// <param name="userId">The id of the user to remove</param> 
        /// <returns></returns>            
        public void RemoveGroupMember(string uniqueName, int? userId)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling RemoveGroupMember");
            }
            
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling RemoveGroupMember");
            }
            
            
            string urlPath = "/users/groups/{unique_name}/members/{user_id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
    
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
                throw new KnetikException ((int)response.StatusCode, "Error calling RemoveGroupMember: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling RemoveGroupMember: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Update a group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param> 
        /// <param name="groupResource">The updated group</param> 
        /// <returns></returns>            
        public void UpdateGroup(string uniqueName, GroupResource groupResource)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling UpdateGroup");
            }
            
            
            string urlPath = "/users/groups/{unique_name}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(groupResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateGroup: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateGroup: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Change a user&#39;s order 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param> 
        /// <param name="userId">The user id of the member to modify</param> 
        /// <param name="order">The new order for the membership</param> 
        /// <returns></returns>            
        public void UpdateGroupMemberProperties(string uniqueName, int? userId, StringWrapper order)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling UpdateGroupMemberProperties");
            }
            
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling UpdateGroupMemberProperties");
            }
            
            // verify the required parameter 'order' is set
            if (order == null)
            {
                throw new KnetikException(400, "Missing required parameter 'order' when calling UpdateGroupMemberProperties");
            }
            
            
            string urlPath = "/users/groups/{unique_name}/members/{user_id}/order";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(order); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateGroupMemberProperties: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateGroupMemberProperties: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Change a user&#39;s membership properties 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param> 
        /// <param name="userId">The user id of the member to modify</param> 
        /// <param name="properties">The new properties for the membership</param> 
        /// <returns></returns>            
        public void UpdateGroupMemberProperties1(string uniqueName, int? userId, Object properties)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling UpdateGroupMemberProperties1");
            }
            
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling UpdateGroupMemberProperties1");
            }
            
            // verify the required parameter 'properties' is set
            if (properties == null)
            {
                throw new KnetikException(400, "Missing required parameter 'properties' when calling UpdateGroupMemberProperties1");
            }
            
            
            string urlPath = "/users/groups/{unique_name}/members/{user_id}/properties";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(properties); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateGroupMemberProperties1: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateGroupMemberProperties1: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Change a user&#39;s status 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param> 
        /// <param name="userId">The user id of the member to modify</param> 
        /// <param name="status">The new status for the user</param> 
        /// <returns></returns>            
        public void UpdateGroupMemberStatus(string uniqueName, int? userId, string status)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling UpdateGroupMemberStatus");
            }
            
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling UpdateGroupMemberStatus");
            }
            
            // verify the required parameter 'status' is set
            if (status == null)
            {
                throw new KnetikException(400, "Missing required parameter 'status' when calling UpdateGroupMemberStatus");
            }
            
            
            string urlPath = "/users/groups/{unique_name}/members/{user_id}/status";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
urlPath = urlPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(status); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateGroupMemberStatus: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateGroupMemberStatus: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Update an group member template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="groupMemberTemplateResource">The group member template resource object</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource UpdateGroupMemberTemplate(string id, TemplateResource groupMemberTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateGroupMemberTemplate");
            }
            
            
            string urlPath = "/users/groups/members/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(groupMemberTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateGroupMemberTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateGroupMemberTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
        /// <summary>
        /// Update a group template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="groupTemplateResource">The group template resource object</param> 
        /// <returns>TemplateResource</returns>            
        public TemplateResource UpdateGroupTemplate(string id, TemplateResource groupTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateGroupTemplate");
            }
            
            
            string urlPath = "/users/groups/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(groupTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateGroupTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateGroupTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
        }
    }
}
