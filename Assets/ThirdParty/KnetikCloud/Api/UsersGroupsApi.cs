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
    public interface IUsersGroupsApi
    {
        GroupMemberResource AddMemberToGroupData { get; }

        List<GroupMemberResource> AddMembersToGroupData { get; }

        GroupResource CreateGroupData { get; }

        TemplateResource CreateGroupMemberTemplateData { get; }

        TemplateResource CreateGroupTemplateData { get; }

        GroupResource GetGroupData { get; }

        GroupMemberResource GetGroupMemberData { get; }

        TemplateResource GetGroupMemberTemplateData { get; }

        PageResourceTemplateResource GetGroupMemberTemplatesData { get; }

        PageResourceGroupMemberResource GetGroupMembersData { get; }

        TemplateResource GetGroupTemplateData { get; }

        PageResourceTemplateResource GetGroupTemplatesData { get; }

        List<string> GetGroupsForUserData { get; }

        PageResourceGroupResource ListGroupsData { get; }

        TemplateResource UpdateGroupMemberTemplateData { get; }

        TemplateResource UpdateGroupTemplateData { get; }

        
        /// <summary>
        /// Adds a new member to the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="user">The id and status for a user to add to the group</param>
        void AddMemberToGroup(string uniqueName, GroupMemberResource user);

        /// <summary>
        /// Adds multiple members to the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="users">The id and status for a list of users to add to the group</param>
        void AddMembersToGroup(string uniqueName, List<GroupMemberResource> users);

        /// <summary>
        /// Create a group 
        /// </summary>
        /// <param name="groupResource">The new group</param>
        void CreateGroup(GroupResource groupResource);

        /// <summary>
        /// Create an group member template GroupMember Templates define a type of group member and the properties they have
        /// </summary>
        /// <param name="groupMemberTemplateResource">The group member template resource object</param>
        void CreateGroupMemberTemplate(TemplateResource groupMemberTemplateResource);

        /// <summary>
        /// Create a group template Group Templates define a type of group and the properties they have
        /// </summary>
        /// <param name="groupTemplateResource">The group template resource object</param>
        void CreateGroupTemplate(TemplateResource groupTemplateResource);

        /// <summary>
        /// Removes a group from the system IF no resources are attached to it 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        void DeleteGroup(string uniqueName);

        /// <summary>
        /// Delete an group member template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteGroupMemberTemplate(string id, string cascade);

        /// <summary>
        /// Delete a group template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteGroupTemplate(string id, string cascade);

        /// <summary>
        /// Loads a specific group&#39;s details 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        void GetGroup(string uniqueName);

        /// <summary>
        /// Get a user from a group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The id of the user</param>
        void GetGroupMember(string uniqueName, int? userId);

        /// <summary>
        /// Get a single group member template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetGroupMemberTemplate(string id);

        /// <summary>
        /// List and search group member templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetGroupMemberTemplates(int? size, int? page, string order);

        /// <summary>
        /// Lists members of the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetGroupMembers(string uniqueName, int? size, int? page, string order);

        /// <summary>
        /// Get a single group template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetGroupTemplate(string id);

        /// <summary>
        /// List and search group templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">a comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetGroupTemplates(int? size, int? page, string order);

        /// <summary>
        /// List groups a user is in 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="filterChildren">Whether to limit group list to children of groups only. If true, shows only groups with parents. If false, shows only groups with no parent.</param>
        void GetGroupsForUser(int? userId, bool? filterChildren);

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
        void ListGroups(string filterTemplate, string filterMemberCount, string filterName, string filterUniqueName, string filterParent, string filterStatus, int? size, int? page, string order);

        /// <summary>
        /// Removes a user from a group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The id of the user to remove</param>
        void RemoveGroupMember(string uniqueName, int? userId);

        /// <summary>
        /// Update a group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="groupResource">The updated group</param>
        void UpdateGroup(string uniqueName, GroupResource groupResource);

        /// <summary>
        /// Change a user&#39;s order 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The user id of the member to modify</param>
        /// <param name="order">The new order for the membership</param>
        void UpdateGroupMemberProperties(string uniqueName, int? userId, StringWrapper order);

        /// <summary>
        /// Change a user&#39;s membership properties 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The user id of the member to modify</param>
        /// <param name="properties">The new properties for the membership</param>
        void UpdateGroupMemberProperties1(string uniqueName, int? userId, Object properties);

        /// <summary>
        /// Change a user&#39;s status 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The user id of the member to modify</param>
        /// <param name="status">The new status for the user</param>
        void UpdateGroupMemberStatus(string uniqueName, int? userId, string status);

        /// <summary>
        /// Update an group member template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="groupMemberTemplateResource">The group member template resource object</param>
        void UpdateGroupMemberTemplate(string id, TemplateResource groupMemberTemplateResource);

        /// <summary>
        /// Update a group template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="groupTemplateResource">The group template resource object</param>
        void UpdateGroupTemplate(string id, TemplateResource groupTemplateResource);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class UsersGroupsApi : IUsersGroupsApi
    {
        private readonly KnetikCoroutine mAddMemberToGroupCoroutine;
        private DateTime mAddMemberToGroupStartTime;
        private string mAddMemberToGroupPath;
        private readonly KnetikCoroutine mAddMembersToGroupCoroutine;
        private DateTime mAddMembersToGroupStartTime;
        private string mAddMembersToGroupPath;
        private readonly KnetikCoroutine mCreateGroupCoroutine;
        private DateTime mCreateGroupStartTime;
        private string mCreateGroupPath;
        private readonly KnetikCoroutine mCreateGroupMemberTemplateCoroutine;
        private DateTime mCreateGroupMemberTemplateStartTime;
        private string mCreateGroupMemberTemplatePath;
        private readonly KnetikCoroutine mCreateGroupTemplateCoroutine;
        private DateTime mCreateGroupTemplateStartTime;
        private string mCreateGroupTemplatePath;
        private readonly KnetikCoroutine mDeleteGroupCoroutine;
        private DateTime mDeleteGroupStartTime;
        private string mDeleteGroupPath;
        private readonly KnetikCoroutine mDeleteGroupMemberTemplateCoroutine;
        private DateTime mDeleteGroupMemberTemplateStartTime;
        private string mDeleteGroupMemberTemplatePath;
        private readonly KnetikCoroutine mDeleteGroupTemplateCoroutine;
        private DateTime mDeleteGroupTemplateStartTime;
        private string mDeleteGroupTemplatePath;
        private readonly KnetikCoroutine mGetGroupCoroutine;
        private DateTime mGetGroupStartTime;
        private string mGetGroupPath;
        private readonly KnetikCoroutine mGetGroupMemberCoroutine;
        private DateTime mGetGroupMemberStartTime;
        private string mGetGroupMemberPath;
        private readonly KnetikCoroutine mGetGroupMemberTemplateCoroutine;
        private DateTime mGetGroupMemberTemplateStartTime;
        private string mGetGroupMemberTemplatePath;
        private readonly KnetikCoroutine mGetGroupMemberTemplatesCoroutine;
        private DateTime mGetGroupMemberTemplatesStartTime;
        private string mGetGroupMemberTemplatesPath;
        private readonly KnetikCoroutine mGetGroupMembersCoroutine;
        private DateTime mGetGroupMembersStartTime;
        private string mGetGroupMembersPath;
        private readonly KnetikCoroutine mGetGroupTemplateCoroutine;
        private DateTime mGetGroupTemplateStartTime;
        private string mGetGroupTemplatePath;
        private readonly KnetikCoroutine mGetGroupTemplatesCoroutine;
        private DateTime mGetGroupTemplatesStartTime;
        private string mGetGroupTemplatesPath;
        private readonly KnetikCoroutine mGetGroupsForUserCoroutine;
        private DateTime mGetGroupsForUserStartTime;
        private string mGetGroupsForUserPath;
        private readonly KnetikCoroutine mListGroupsCoroutine;
        private DateTime mListGroupsStartTime;
        private string mListGroupsPath;
        private readonly KnetikCoroutine mRemoveGroupMemberCoroutine;
        private DateTime mRemoveGroupMemberStartTime;
        private string mRemoveGroupMemberPath;
        private readonly KnetikCoroutine mUpdateGroupCoroutine;
        private DateTime mUpdateGroupStartTime;
        private string mUpdateGroupPath;
        private readonly KnetikCoroutine mUpdateGroupMemberPropertiesCoroutine;
        private DateTime mUpdateGroupMemberPropertiesStartTime;
        private string mUpdateGroupMemberPropertiesPath;
        private readonly KnetikCoroutine mUpdateGroupMemberProperties1Coroutine;
        private DateTime mUpdateGroupMemberProperties1StartTime;
        private string mUpdateGroupMemberProperties1Path;
        private readonly KnetikCoroutine mUpdateGroupMemberStatusCoroutine;
        private DateTime mUpdateGroupMemberStatusStartTime;
        private string mUpdateGroupMemberStatusPath;
        private readonly KnetikCoroutine mUpdateGroupMemberTemplateCoroutine;
        private DateTime mUpdateGroupMemberTemplateStartTime;
        private string mUpdateGroupMemberTemplatePath;
        private readonly KnetikCoroutine mUpdateGroupTemplateCoroutine;
        private DateTime mUpdateGroupTemplateStartTime;
        private string mUpdateGroupTemplatePath;

        public GroupMemberResource AddMemberToGroupData { get; private set; }
        public delegate void AddMemberToGroupCompleteDelegate(GroupMemberResource response);
        public AddMemberToGroupCompleteDelegate AddMemberToGroupComplete;

        public List<GroupMemberResource> AddMembersToGroupData { get; private set; }
        public delegate void AddMembersToGroupCompleteDelegate(List<GroupMemberResource> response);
        public AddMembersToGroupCompleteDelegate AddMembersToGroupComplete;

        public GroupResource CreateGroupData { get; private set; }
        public delegate void CreateGroupCompleteDelegate(GroupResource response);
        public CreateGroupCompleteDelegate CreateGroupComplete;

        public TemplateResource CreateGroupMemberTemplateData { get; private set; }
        public delegate void CreateGroupMemberTemplateCompleteDelegate(TemplateResource response);
        public CreateGroupMemberTemplateCompleteDelegate CreateGroupMemberTemplateComplete;

        public TemplateResource CreateGroupTemplateData { get; private set; }
        public delegate void CreateGroupTemplateCompleteDelegate(TemplateResource response);
        public CreateGroupTemplateCompleteDelegate CreateGroupTemplateComplete;

        public delegate void DeleteGroupCompleteDelegate();
        public DeleteGroupCompleteDelegate DeleteGroupComplete;

        public delegate void DeleteGroupMemberTemplateCompleteDelegate();
        public DeleteGroupMemberTemplateCompleteDelegate DeleteGroupMemberTemplateComplete;

        public delegate void DeleteGroupTemplateCompleteDelegate();
        public DeleteGroupTemplateCompleteDelegate DeleteGroupTemplateComplete;

        public GroupResource GetGroupData { get; private set; }
        public delegate void GetGroupCompleteDelegate(GroupResource response);
        public GetGroupCompleteDelegate GetGroupComplete;

        public GroupMemberResource GetGroupMemberData { get; private set; }
        public delegate void GetGroupMemberCompleteDelegate(GroupMemberResource response);
        public GetGroupMemberCompleteDelegate GetGroupMemberComplete;

        public TemplateResource GetGroupMemberTemplateData { get; private set; }
        public delegate void GetGroupMemberTemplateCompleteDelegate(TemplateResource response);
        public GetGroupMemberTemplateCompleteDelegate GetGroupMemberTemplateComplete;

        public PageResourceTemplateResource GetGroupMemberTemplatesData { get; private set; }
        public delegate void GetGroupMemberTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetGroupMemberTemplatesCompleteDelegate GetGroupMemberTemplatesComplete;

        public PageResourceGroupMemberResource GetGroupMembersData { get; private set; }
        public delegate void GetGroupMembersCompleteDelegate(PageResourceGroupMemberResource response);
        public GetGroupMembersCompleteDelegate GetGroupMembersComplete;

        public TemplateResource GetGroupTemplateData { get; private set; }
        public delegate void GetGroupTemplateCompleteDelegate(TemplateResource response);
        public GetGroupTemplateCompleteDelegate GetGroupTemplateComplete;

        public PageResourceTemplateResource GetGroupTemplatesData { get; private set; }
        public delegate void GetGroupTemplatesCompleteDelegate(PageResourceTemplateResource response);
        public GetGroupTemplatesCompleteDelegate GetGroupTemplatesComplete;

        public List<string> GetGroupsForUserData { get; private set; }
        public delegate void GetGroupsForUserCompleteDelegate(List<string> response);
        public GetGroupsForUserCompleteDelegate GetGroupsForUserComplete;

        public PageResourceGroupResource ListGroupsData { get; private set; }
        public delegate void ListGroupsCompleteDelegate(PageResourceGroupResource response);
        public ListGroupsCompleteDelegate ListGroupsComplete;

        public delegate void RemoveGroupMemberCompleteDelegate();
        public RemoveGroupMemberCompleteDelegate RemoveGroupMemberComplete;

        public delegate void UpdateGroupCompleteDelegate();
        public UpdateGroupCompleteDelegate UpdateGroupComplete;

        public delegate void UpdateGroupMemberPropertiesCompleteDelegate();
        public UpdateGroupMemberPropertiesCompleteDelegate UpdateGroupMemberPropertiesComplete;

        public delegate void UpdateGroupMemberProperties1CompleteDelegate();
        public UpdateGroupMemberProperties1CompleteDelegate UpdateGroupMemberProperties1Complete;

        public delegate void UpdateGroupMemberStatusCompleteDelegate();
        public UpdateGroupMemberStatusCompleteDelegate UpdateGroupMemberStatusComplete;

        public TemplateResource UpdateGroupMemberTemplateData { get; private set; }
        public delegate void UpdateGroupMemberTemplateCompleteDelegate(TemplateResource response);
        public UpdateGroupMemberTemplateCompleteDelegate UpdateGroupMemberTemplateComplete;

        public TemplateResource UpdateGroupTemplateData { get; private set; }
        public delegate void UpdateGroupTemplateCompleteDelegate(TemplateResource response);
        public UpdateGroupTemplateCompleteDelegate UpdateGroupTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersGroupsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersGroupsApi()
        {
            mAddMemberToGroupCoroutine = new KnetikCoroutine();
            mAddMembersToGroupCoroutine = new KnetikCoroutine();
            mCreateGroupCoroutine = new KnetikCoroutine();
            mCreateGroupMemberTemplateCoroutine = new KnetikCoroutine();
            mCreateGroupTemplateCoroutine = new KnetikCoroutine();
            mDeleteGroupCoroutine = new KnetikCoroutine();
            mDeleteGroupMemberTemplateCoroutine = new KnetikCoroutine();
            mDeleteGroupTemplateCoroutine = new KnetikCoroutine();
            mGetGroupCoroutine = new KnetikCoroutine();
            mGetGroupMemberCoroutine = new KnetikCoroutine();
            mGetGroupMemberTemplateCoroutine = new KnetikCoroutine();
            mGetGroupMemberTemplatesCoroutine = new KnetikCoroutine();
            mGetGroupMembersCoroutine = new KnetikCoroutine();
            mGetGroupTemplateCoroutine = new KnetikCoroutine();
            mGetGroupTemplatesCoroutine = new KnetikCoroutine();
            mGetGroupsForUserCoroutine = new KnetikCoroutine();
            mListGroupsCoroutine = new KnetikCoroutine();
            mRemoveGroupMemberCoroutine = new KnetikCoroutine();
            mUpdateGroupCoroutine = new KnetikCoroutine();
            mUpdateGroupMemberPropertiesCoroutine = new KnetikCoroutine();
            mUpdateGroupMemberProperties1Coroutine = new KnetikCoroutine();
            mUpdateGroupMemberStatusCoroutine = new KnetikCoroutine();
            mUpdateGroupMemberTemplateCoroutine = new KnetikCoroutine();
            mUpdateGroupTemplateCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Adds a new member to the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="user">The id and status for a user to add to the group</param>
        public void AddMemberToGroup(string uniqueName, GroupMemberResource user)
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
            
            mAddMemberToGroupPath = "/users/groups/{unique_name}/members";
            if (!string.IsNullOrEmpty(mAddMemberToGroupPath))
            {
                mAddMemberToGroupPath = mAddMemberToGroupPath.Replace("{format}", "json");
            }
            mAddMemberToGroupPath = mAddMemberToGroupPath.Replace("{" + "unique_name" + "}", KnetikClient.DefaultClient.ParameterToString(uniqueName));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(user); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddMemberToGroupStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddMemberToGroupStartTime, mAddMemberToGroupPath, "Sending server request...");

            // make the HTTP request
            mAddMemberToGroupCoroutine.ResponseReceived += AddMemberToGroupCallback;
            mAddMemberToGroupCoroutine.Start(mAddMemberToGroupPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddMemberToGroupCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddMemberToGroup: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddMemberToGroup: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddMemberToGroupData = (GroupMemberResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(GroupMemberResource), response.Headers);
            KnetikLogger.LogResponse(mAddMemberToGroupStartTime, mAddMemberToGroupPath, string.Format("Response received successfully:\n{0}", AddMemberToGroupData.ToString()));

            if (AddMemberToGroupComplete != null)
            {
                AddMemberToGroupComplete(AddMemberToGroupData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Adds multiple members to the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="users">The id and status for a list of users to add to the group</param>
        public void AddMembersToGroup(string uniqueName, List<GroupMemberResource> users)
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
            
            mAddMembersToGroupPath = "/users/groups/{unique_name}/members/batch-add";
            if (!string.IsNullOrEmpty(mAddMembersToGroupPath))
            {
                mAddMembersToGroupPath = mAddMembersToGroupPath.Replace("{format}", "json");
            }
            mAddMembersToGroupPath = mAddMembersToGroupPath.Replace("{" + "unique_name" + "}", KnetikClient.DefaultClient.ParameterToString(uniqueName));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(users); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddMembersToGroupStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddMembersToGroupStartTime, mAddMembersToGroupPath, "Sending server request...");

            // make the HTTP request
            mAddMembersToGroupCoroutine.ResponseReceived += AddMembersToGroupCallback;
            mAddMembersToGroupCoroutine.Start(mAddMembersToGroupPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddMembersToGroupCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddMembersToGroup: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddMembersToGroup: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddMembersToGroupData = (List<GroupMemberResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<GroupMemberResource>), response.Headers);
            KnetikLogger.LogResponse(mAddMembersToGroupStartTime, mAddMembersToGroupPath, string.Format("Response received successfully:\n{0}", AddMembersToGroupData.ToString()));

            if (AddMembersToGroupComplete != null)
            {
                AddMembersToGroupComplete(AddMembersToGroupData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a group 
        /// </summary>
        /// <param name="groupResource">The new group</param>
        public void CreateGroup(GroupResource groupResource)
        {
            
            mCreateGroupPath = "/users/groups";
            if (!string.IsNullOrEmpty(mCreateGroupPath))
            {
                mCreateGroupPath = mCreateGroupPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(groupResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateGroupStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateGroupStartTime, mCreateGroupPath, "Sending server request...");

            // make the HTTP request
            mCreateGroupCoroutine.ResponseReceived += CreateGroupCallback;
            mCreateGroupCoroutine.Start(mCreateGroupPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateGroupCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateGroup: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateGroup: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateGroupData = (GroupResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(GroupResource), response.Headers);
            KnetikLogger.LogResponse(mCreateGroupStartTime, mCreateGroupPath, string.Format("Response received successfully:\n{0}", CreateGroupData.ToString()));

            if (CreateGroupComplete != null)
            {
                CreateGroupComplete(CreateGroupData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create an group member template GroupMember Templates define a type of group member and the properties they have
        /// </summary>
        /// <param name="groupMemberTemplateResource">The group member template resource object</param>
        public void CreateGroupMemberTemplate(TemplateResource groupMemberTemplateResource)
        {
            
            mCreateGroupMemberTemplatePath = "/users/groups/members/templates";
            if (!string.IsNullOrEmpty(mCreateGroupMemberTemplatePath))
            {
                mCreateGroupMemberTemplatePath = mCreateGroupMemberTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(groupMemberTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateGroupMemberTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateGroupMemberTemplateStartTime, mCreateGroupMemberTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateGroupMemberTemplateCoroutine.ResponseReceived += CreateGroupMemberTemplateCallback;
            mCreateGroupMemberTemplateCoroutine.Start(mCreateGroupMemberTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateGroupMemberTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateGroupMemberTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateGroupMemberTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateGroupMemberTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateGroupMemberTemplateStartTime, mCreateGroupMemberTemplatePath, string.Format("Response received successfully:\n{0}", CreateGroupMemberTemplateData.ToString()));

            if (CreateGroupMemberTemplateComplete != null)
            {
                CreateGroupMemberTemplateComplete(CreateGroupMemberTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a group template Group Templates define a type of group and the properties they have
        /// </summary>
        /// <param name="groupTemplateResource">The group template resource object</param>
        public void CreateGroupTemplate(TemplateResource groupTemplateResource)
        {
            
            mCreateGroupTemplatePath = "/users/groups/templates";
            if (!string.IsNullOrEmpty(mCreateGroupTemplatePath))
            {
                mCreateGroupTemplatePath = mCreateGroupTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(groupTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateGroupTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateGroupTemplateStartTime, mCreateGroupTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateGroupTemplateCoroutine.ResponseReceived += CreateGroupTemplateCallback;
            mCreateGroupTemplateCoroutine.Start(mCreateGroupTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateGroupTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateGroupTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateGroupTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateGroupTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateGroupTemplateStartTime, mCreateGroupTemplatePath, string.Format("Response received successfully:\n{0}", CreateGroupTemplateData.ToString()));

            if (CreateGroupTemplateComplete != null)
            {
                CreateGroupTemplateComplete(CreateGroupTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Removes a group from the system IF no resources are attached to it 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        public void DeleteGroup(string uniqueName)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling DeleteGroup");
            }
            
            mDeleteGroupPath = "/users/groups/{unique_name}";
            if (!string.IsNullOrEmpty(mDeleteGroupPath))
            {
                mDeleteGroupPath = mDeleteGroupPath.Replace("{format}", "json");
            }
            mDeleteGroupPath = mDeleteGroupPath.Replace("{" + "unique_name" + "}", KnetikClient.DefaultClient.ParameterToString(uniqueName));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteGroupStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteGroupStartTime, mDeleteGroupPath, "Sending server request...");

            // make the HTTP request
            mDeleteGroupCoroutine.ResponseReceived += DeleteGroupCallback;
            mDeleteGroupCoroutine.Start(mDeleteGroupPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteGroupCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteGroup: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteGroup: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteGroupStartTime, mDeleteGroupPath, "Response received successfully.");
            if (DeleteGroupComplete != null)
            {
                DeleteGroupComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an group member template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteGroupMemberTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteGroupMemberTemplate");
            }
            
            mDeleteGroupMemberTemplatePath = "/users/groups/members/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteGroupMemberTemplatePath))
            {
                mDeleteGroupMemberTemplatePath = mDeleteGroupMemberTemplatePath.Replace("{format}", "json");
            }
            mDeleteGroupMemberTemplatePath = mDeleteGroupMemberTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteGroupMemberTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteGroupMemberTemplateStartTime, mDeleteGroupMemberTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteGroupMemberTemplateCoroutine.ResponseReceived += DeleteGroupMemberTemplateCallback;
            mDeleteGroupMemberTemplateCoroutine.Start(mDeleteGroupMemberTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteGroupMemberTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteGroupMemberTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteGroupMemberTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteGroupMemberTemplateStartTime, mDeleteGroupMemberTemplatePath, "Response received successfully.");
            if (DeleteGroupMemberTemplateComplete != null)
            {
                DeleteGroupMemberTemplateComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a group template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteGroupTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteGroupTemplate");
            }
            
            mDeleteGroupTemplatePath = "/users/groups/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteGroupTemplatePath))
            {
                mDeleteGroupTemplatePath = mDeleteGroupTemplatePath.Replace("{format}", "json");
            }
            mDeleteGroupTemplatePath = mDeleteGroupTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteGroupTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteGroupTemplateStartTime, mDeleteGroupTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteGroupTemplateCoroutine.ResponseReceived += DeleteGroupTemplateCallback;
            mDeleteGroupTemplateCoroutine.Start(mDeleteGroupTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteGroupTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteGroupTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteGroupTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteGroupTemplateStartTime, mDeleteGroupTemplatePath, "Response received successfully.");
            if (DeleteGroupTemplateComplete != null)
            {
                DeleteGroupTemplateComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Loads a specific group&#39;s details 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        public void GetGroup(string uniqueName)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling GetGroup");
            }
            
            mGetGroupPath = "/users/groups/{unique_name}";
            if (!string.IsNullOrEmpty(mGetGroupPath))
            {
                mGetGroupPath = mGetGroupPath.Replace("{format}", "json");
            }
            mGetGroupPath = mGetGroupPath.Replace("{" + "unique_name" + "}", KnetikClient.DefaultClient.ParameterToString(uniqueName));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetGroupStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetGroupStartTime, mGetGroupPath, "Sending server request...");

            // make the HTTP request
            mGetGroupCoroutine.ResponseReceived += GetGroupCallback;
            mGetGroupCoroutine.Start(mGetGroupPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetGroupCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroup: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroup: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetGroupData = (GroupResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(GroupResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupStartTime, mGetGroupPath, string.Format("Response received successfully:\n{0}", GetGroupData.ToString()));

            if (GetGroupComplete != null)
            {
                GetGroupComplete(GetGroupData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a user from a group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The id of the user</param>
        public void GetGroupMember(string uniqueName, int? userId)
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
            
            mGetGroupMemberPath = "/users/groups/{unique_name}/members/{user_id}";
            if (!string.IsNullOrEmpty(mGetGroupMemberPath))
            {
                mGetGroupMemberPath = mGetGroupMemberPath.Replace("{format}", "json");
            }
            mGetGroupMemberPath = mGetGroupMemberPath.Replace("{" + "unique_name" + "}", KnetikClient.DefaultClient.ParameterToString(uniqueName));
mGetGroupMemberPath = mGetGroupMemberPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetGroupMemberStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetGroupMemberStartTime, mGetGroupMemberPath, "Sending server request...");

            // make the HTTP request
            mGetGroupMemberCoroutine.ResponseReceived += GetGroupMemberCallback;
            mGetGroupMemberCoroutine.Start(mGetGroupMemberPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetGroupMemberCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupMember: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupMember: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetGroupMemberData = (GroupMemberResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(GroupMemberResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupMemberStartTime, mGetGroupMemberPath, string.Format("Response received successfully:\n{0}", GetGroupMemberData.ToString()));

            if (GetGroupMemberComplete != null)
            {
                GetGroupMemberComplete(GetGroupMemberData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single group member template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetGroupMemberTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetGroupMemberTemplate");
            }
            
            mGetGroupMemberTemplatePath = "/users/groups/members/templates/{id}";
            if (!string.IsNullOrEmpty(mGetGroupMemberTemplatePath))
            {
                mGetGroupMemberTemplatePath = mGetGroupMemberTemplatePath.Replace("{format}", "json");
            }
            mGetGroupMemberTemplatePath = mGetGroupMemberTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetGroupMemberTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetGroupMemberTemplateStartTime, mGetGroupMemberTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetGroupMemberTemplateCoroutine.ResponseReceived += GetGroupMemberTemplateCallback;
            mGetGroupMemberTemplateCoroutine.Start(mGetGroupMemberTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetGroupMemberTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupMemberTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupMemberTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetGroupMemberTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupMemberTemplateStartTime, mGetGroupMemberTemplatePath, string.Format("Response received successfully:\n{0}", GetGroupMemberTemplateData.ToString()));

            if (GetGroupMemberTemplateComplete != null)
            {
                GetGroupMemberTemplateComplete(GetGroupMemberTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search group member templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetGroupMemberTemplates(int? size, int? page, string order)
        {
            
            mGetGroupMemberTemplatesPath = "/users/groups/members/templates";
            if (!string.IsNullOrEmpty(mGetGroupMemberTemplatesPath))
            {
                mGetGroupMemberTemplatesPath = mGetGroupMemberTemplatesPath.Replace("{format}", "json");
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetGroupMemberTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetGroupMemberTemplatesStartTime, mGetGroupMemberTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetGroupMemberTemplatesCoroutine.ResponseReceived += GetGroupMemberTemplatesCallback;
            mGetGroupMemberTemplatesCoroutine.Start(mGetGroupMemberTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetGroupMemberTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupMemberTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupMemberTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetGroupMemberTemplatesData = (PageResourceTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupMemberTemplatesStartTime, mGetGroupMemberTemplatesPath, string.Format("Response received successfully:\n{0}", GetGroupMemberTemplatesData.ToString()));

            if (GetGroupMemberTemplatesComplete != null)
            {
                GetGroupMemberTemplatesComplete(GetGroupMemberTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Lists members of the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetGroupMembers(string uniqueName, int? size, int? page, string order)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling GetGroupMembers");
            }
            
            mGetGroupMembersPath = "/users/groups/{unique_name}/members";
            if (!string.IsNullOrEmpty(mGetGroupMembersPath))
            {
                mGetGroupMembersPath = mGetGroupMembersPath.Replace("{format}", "json");
            }
            mGetGroupMembersPath = mGetGroupMembersPath.Replace("{" + "unique_name" + "}", KnetikClient.DefaultClient.ParameterToString(uniqueName));

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
            string[] authSettings = new string[] {  };

            mGetGroupMembersStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetGroupMembersStartTime, mGetGroupMembersPath, "Sending server request...");

            // make the HTTP request
            mGetGroupMembersCoroutine.ResponseReceived += GetGroupMembersCallback;
            mGetGroupMembersCoroutine.Start(mGetGroupMembersPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetGroupMembersCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupMembers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupMembers: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetGroupMembersData = (PageResourceGroupMemberResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceGroupMemberResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupMembersStartTime, mGetGroupMembersPath, string.Format("Response received successfully:\n{0}", GetGroupMembersData.ToString()));

            if (GetGroupMembersComplete != null)
            {
                GetGroupMembersComplete(GetGroupMembersData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single group template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetGroupTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetGroupTemplate");
            }
            
            mGetGroupTemplatePath = "/users/groups/templates/{id}";
            if (!string.IsNullOrEmpty(mGetGroupTemplatePath))
            {
                mGetGroupTemplatePath = mGetGroupTemplatePath.Replace("{format}", "json");
            }
            mGetGroupTemplatePath = mGetGroupTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetGroupTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetGroupTemplateStartTime, mGetGroupTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetGroupTemplateCoroutine.ResponseReceived += GetGroupTemplateCallback;
            mGetGroupTemplateCoroutine.Start(mGetGroupTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetGroupTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetGroupTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupTemplateStartTime, mGetGroupTemplatePath, string.Format("Response received successfully:\n{0}", GetGroupTemplateData.ToString()));

            if (GetGroupTemplateComplete != null)
            {
                GetGroupTemplateComplete(GetGroupTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search group templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">a comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetGroupTemplates(int? size, int? page, string order)
        {
            
            mGetGroupTemplatesPath = "/users/groups/templates";
            if (!string.IsNullOrEmpty(mGetGroupTemplatesPath))
            {
                mGetGroupTemplatesPath = mGetGroupTemplatesPath.Replace("{format}", "json");
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
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetGroupTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetGroupTemplatesStartTime, mGetGroupTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetGroupTemplatesCoroutine.ResponseReceived += GetGroupTemplatesCallback;
            mGetGroupTemplatesCoroutine.Start(mGetGroupTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetGroupTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetGroupTemplatesData = (PageResourceTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupTemplatesStartTime, mGetGroupTemplatesPath, string.Format("Response received successfully:\n{0}", GetGroupTemplatesData.ToString()));

            if (GetGroupTemplatesComplete != null)
            {
                GetGroupTemplatesComplete(GetGroupTemplatesData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List groups a user is in 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="filterChildren">Whether to limit group list to children of groups only. If true, shows only groups with parents. If false, shows only groups with no parent.</param>
        public void GetGroupsForUser(int? userId, bool? filterChildren)
        {
            // verify the required parameter 'userId' is set
            if (userId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'userId' when calling GetGroupsForUser");
            }
            
            mGetGroupsForUserPath = "/users/{user_id}/groups";
            if (!string.IsNullOrEmpty(mGetGroupsForUserPath))
            {
                mGetGroupsForUserPath = mGetGroupsForUserPath.Replace("{format}", "json");
            }
            mGetGroupsForUserPath = mGetGroupsForUserPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterChildren != null)
            {
                queryParams.Add("filter_children", KnetikClient.DefaultClient.ParameterToString(filterChildren));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  };

            mGetGroupsForUserStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetGroupsForUserStartTime, mGetGroupsForUserPath, "Sending server request...");

            // make the HTTP request
            mGetGroupsForUserCoroutine.ResponseReceived += GetGroupsForUserCallback;
            mGetGroupsForUserCoroutine.Start(mGetGroupsForUserPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetGroupsForUserCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupsForUser: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetGroupsForUser: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetGroupsForUserData = (List<string>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetGroupsForUserStartTime, mGetGroupsForUserPath, string.Format("Response received successfully:\n{0}", GetGroupsForUserData.ToString()));

            if (GetGroupsForUserComplete != null)
            {
                GetGroupsForUserComplete(GetGroupsForUserData);
            }
        }

        /// <inheritdoc />
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
        public void ListGroups(string filterTemplate, string filterMemberCount, string filterName, string filterUniqueName, string filterParent, string filterStatus, int? size, int? page, string order)
        {
            
            mListGroupsPath = "/users/groups";
            if (!string.IsNullOrEmpty(mListGroupsPath))
            {
                mListGroupsPath = mListGroupsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterTemplate != null)
            {
                queryParams.Add("filter_template", KnetikClient.DefaultClient.ParameterToString(filterTemplate));
            }

            if (filterMemberCount != null)
            {
                queryParams.Add("filter_member_count", KnetikClient.DefaultClient.ParameterToString(filterMemberCount));
            }

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.DefaultClient.ParameterToString(filterName));
            }

            if (filterUniqueName != null)
            {
                queryParams.Add("filter_unique_name", KnetikClient.DefaultClient.ParameterToString(filterUniqueName));
            }

            if (filterParent != null)
            {
                queryParams.Add("filter_parent", KnetikClient.DefaultClient.ParameterToString(filterParent));
            }

            if (filterStatus != null)
            {
                queryParams.Add("filter_status", KnetikClient.DefaultClient.ParameterToString(filterStatus));
            }

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
            string[] authSettings = new string[] {  };

            mListGroupsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mListGroupsStartTime, mListGroupsPath, "Sending server request...");

            // make the HTTP request
            mListGroupsCoroutine.ResponseReceived += ListGroupsCallback;
            mListGroupsCoroutine.Start(mListGroupsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void ListGroupsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling ListGroups: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling ListGroups: " + response.ErrorMessage, response.ErrorMessage);
            }

            ListGroupsData = (PageResourceGroupResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceGroupResource), response.Headers);
            KnetikLogger.LogResponse(mListGroupsStartTime, mListGroupsPath, string.Format("Response received successfully:\n{0}", ListGroupsData.ToString()));

            if (ListGroupsComplete != null)
            {
                ListGroupsComplete(ListGroupsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Removes a user from a group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The id of the user to remove</param>
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
            
            mRemoveGroupMemberPath = "/users/groups/{unique_name}/members/{user_id}";
            if (!string.IsNullOrEmpty(mRemoveGroupMemberPath))
            {
                mRemoveGroupMemberPath = mRemoveGroupMemberPath.Replace("{format}", "json");
            }
            mRemoveGroupMemberPath = mRemoveGroupMemberPath.Replace("{" + "unique_name" + "}", KnetikClient.DefaultClient.ParameterToString(uniqueName));
mRemoveGroupMemberPath = mRemoveGroupMemberPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mRemoveGroupMemberStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mRemoveGroupMemberStartTime, mRemoveGroupMemberPath, "Sending server request...");

            // make the HTTP request
            mRemoveGroupMemberCoroutine.ResponseReceived += RemoveGroupMemberCallback;
            mRemoveGroupMemberCoroutine.Start(mRemoveGroupMemberPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void RemoveGroupMemberCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveGroupMember: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveGroupMember: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mRemoveGroupMemberStartTime, mRemoveGroupMemberPath, "Response received successfully.");
            if (RemoveGroupMemberComplete != null)
            {
                RemoveGroupMemberComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="groupResource">The updated group</param>
        public void UpdateGroup(string uniqueName, GroupResource groupResource)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling UpdateGroup");
            }
            
            mUpdateGroupPath = "/users/groups/{unique_name}";
            if (!string.IsNullOrEmpty(mUpdateGroupPath))
            {
                mUpdateGroupPath = mUpdateGroupPath.Replace("{format}", "json");
            }
            mUpdateGroupPath = mUpdateGroupPath.Replace("{" + "unique_name" + "}", KnetikClient.DefaultClient.ParameterToString(uniqueName));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(groupResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateGroupStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateGroupStartTime, mUpdateGroupPath, "Sending server request...");

            // make the HTTP request
            mUpdateGroupCoroutine.ResponseReceived += UpdateGroupCallback;
            mUpdateGroupCoroutine.Start(mUpdateGroupPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateGroupCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateGroup: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateGroup: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateGroupStartTime, mUpdateGroupPath, "Response received successfully.");
            if (UpdateGroupComplete != null)
            {
                UpdateGroupComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Change a user&#39;s order 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The user id of the member to modify</param>
        /// <param name="order">The new order for the membership</param>
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
            
            mUpdateGroupMemberPropertiesPath = "/users/groups/{unique_name}/members/{user_id}/order";
            if (!string.IsNullOrEmpty(mUpdateGroupMemberPropertiesPath))
            {
                mUpdateGroupMemberPropertiesPath = mUpdateGroupMemberPropertiesPath.Replace("{format}", "json");
            }
            mUpdateGroupMemberPropertiesPath = mUpdateGroupMemberPropertiesPath.Replace("{" + "unique_name" + "}", KnetikClient.DefaultClient.ParameterToString(uniqueName));
mUpdateGroupMemberPropertiesPath = mUpdateGroupMemberPropertiesPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(order); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateGroupMemberPropertiesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateGroupMemberPropertiesStartTime, mUpdateGroupMemberPropertiesPath, "Sending server request...");

            // make the HTTP request
            mUpdateGroupMemberPropertiesCoroutine.ResponseReceived += UpdateGroupMemberPropertiesCallback;
            mUpdateGroupMemberPropertiesCoroutine.Start(mUpdateGroupMemberPropertiesPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateGroupMemberPropertiesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateGroupMemberProperties: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateGroupMemberProperties: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateGroupMemberPropertiesStartTime, mUpdateGroupMemberPropertiesPath, "Response received successfully.");
            if (UpdateGroupMemberPropertiesComplete != null)
            {
                UpdateGroupMemberPropertiesComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Change a user&#39;s membership properties 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The user id of the member to modify</param>
        /// <param name="properties">The new properties for the membership</param>
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
            
            mUpdateGroupMemberProperties1Path = "/users/groups/{unique_name}/members/{user_id}/properties";
            if (!string.IsNullOrEmpty(mUpdateGroupMemberProperties1Path))
            {
                mUpdateGroupMemberProperties1Path = mUpdateGroupMemberProperties1Path.Replace("{format}", "json");
            }
            mUpdateGroupMemberProperties1Path = mUpdateGroupMemberProperties1Path.Replace("{" + "unique_name" + "}", KnetikClient.DefaultClient.ParameterToString(uniqueName));
mUpdateGroupMemberProperties1Path = mUpdateGroupMemberProperties1Path.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(properties); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateGroupMemberProperties1StartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateGroupMemberProperties1StartTime, mUpdateGroupMemberProperties1Path, "Sending server request...");

            // make the HTTP request
            mUpdateGroupMemberProperties1Coroutine.ResponseReceived += UpdateGroupMemberProperties1Callback;
            mUpdateGroupMemberProperties1Coroutine.Start(mUpdateGroupMemberProperties1Path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateGroupMemberProperties1Callback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateGroupMemberProperties1: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateGroupMemberProperties1: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateGroupMemberProperties1StartTime, mUpdateGroupMemberProperties1Path, "Response received successfully.");
            if (UpdateGroupMemberProperties1Complete != null)
            {
                UpdateGroupMemberProperties1Complete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Change a user&#39;s status 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The user id of the member to modify</param>
        /// <param name="status">The new status for the user</param>
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
            
            mUpdateGroupMemberStatusPath = "/users/groups/{unique_name}/members/{user_id}/status";
            if (!string.IsNullOrEmpty(mUpdateGroupMemberStatusPath))
            {
                mUpdateGroupMemberStatusPath = mUpdateGroupMemberStatusPath.Replace("{format}", "json");
            }
            mUpdateGroupMemberStatusPath = mUpdateGroupMemberStatusPath.Replace("{" + "unique_name" + "}", KnetikClient.DefaultClient.ParameterToString(uniqueName));
mUpdateGroupMemberStatusPath = mUpdateGroupMemberStatusPath.Replace("{" + "user_id" + "}", KnetikClient.DefaultClient.ParameterToString(userId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(status); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateGroupMemberStatusStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateGroupMemberStatusStartTime, mUpdateGroupMemberStatusPath, "Sending server request...");

            // make the HTTP request
            mUpdateGroupMemberStatusCoroutine.ResponseReceived += UpdateGroupMemberStatusCallback;
            mUpdateGroupMemberStatusCoroutine.Start(mUpdateGroupMemberStatusPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateGroupMemberStatusCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateGroupMemberStatus: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateGroupMemberStatus: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateGroupMemberStatusStartTime, mUpdateGroupMemberStatusPath, "Response received successfully.");
            if (UpdateGroupMemberStatusComplete != null)
            {
                UpdateGroupMemberStatusComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an group member template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="groupMemberTemplateResource">The group member template resource object</param>
        public void UpdateGroupMemberTemplate(string id, TemplateResource groupMemberTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateGroupMemberTemplate");
            }
            
            mUpdateGroupMemberTemplatePath = "/users/groups/members/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateGroupMemberTemplatePath))
            {
                mUpdateGroupMemberTemplatePath = mUpdateGroupMemberTemplatePath.Replace("{format}", "json");
            }
            mUpdateGroupMemberTemplatePath = mUpdateGroupMemberTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(groupMemberTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateGroupMemberTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateGroupMemberTemplateStartTime, mUpdateGroupMemberTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateGroupMemberTemplateCoroutine.ResponseReceived += UpdateGroupMemberTemplateCallback;
            mUpdateGroupMemberTemplateCoroutine.Start(mUpdateGroupMemberTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateGroupMemberTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateGroupMemberTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateGroupMemberTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateGroupMemberTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateGroupMemberTemplateStartTime, mUpdateGroupMemberTemplatePath, string.Format("Response received successfully:\n{0}", UpdateGroupMemberTemplateData.ToString()));

            if (UpdateGroupMemberTemplateComplete != null)
            {
                UpdateGroupMemberTemplateComplete(UpdateGroupMemberTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a group template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="groupTemplateResource">The group template resource object</param>
        public void UpdateGroupTemplate(string id, TemplateResource groupTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateGroupTemplate");
            }
            
            mUpdateGroupTemplatePath = "/users/groups/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateGroupTemplatePath))
            {
                mUpdateGroupTemplatePath = mUpdateGroupTemplatePath.Replace("{format}", "json");
            }
            mUpdateGroupTemplatePath = mUpdateGroupTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(groupTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateGroupTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateGroupTemplateStartTime, mUpdateGroupTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateGroupTemplateCoroutine.ResponseReceived += UpdateGroupTemplateCallback;
            mUpdateGroupTemplateCoroutine.Start(mUpdateGroupTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateGroupTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateGroupTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateGroupTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateGroupTemplateData = (TemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateGroupTemplateStartTime, mUpdateGroupTemplatePath, string.Format("Response received successfully:\n{0}", UpdateGroupTemplateData.ToString()));

            if (UpdateGroupTemplateComplete != null)
            {
                UpdateGroupTemplateComplete(UpdateGroupTemplateData);
            }
        }

    }
}
