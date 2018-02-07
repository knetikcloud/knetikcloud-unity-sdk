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
    public interface IUsersGroupsApi
    {
        GroupMemberResource AddMemberToGroupData { get; }

        /// <summary>
        /// Adds a new member to the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="user">The id and status for a user to add to the group</param>
        void AddMemberToGroup(string uniqueName, GroupMemberResource user);

        List<GroupMemberResource> AddMembersToGroupData { get; }

        /// <summary>
        /// Adds multiple members to the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="users">The id and status for a list of users to add to the group</param>
        void AddMembersToGroup(string uniqueName, List<GroupMemberResource> users);

        GroupResource CreateGroupData { get; }

        /// <summary>
        /// Create a group 
        /// </summary>
        /// <param name="groupResource">The new group</param>
        void CreateGroup(GroupResource groupResource);

        TemplateResource CreateGroupMemberTemplateData { get; }

        /// <summary>
        /// Create an group member template GroupMember Templates define a type of group member and the properties they have
        /// </summary>
        /// <param name="groupMemberTemplateResource">The group member template resource object</param>
        void CreateGroupMemberTemplate(TemplateResource groupMemberTemplateResource);

        TemplateResource CreateGroupTemplateData { get; }

        /// <summary>
        /// Create a group template Group Templates define a type of group and the properties they have
        /// </summary>
        /// <param name="groupTemplateResource">The group template resource object</param>
        void CreateGroupTemplate(TemplateResource groupTemplateResource);

        

        /// <summary>
        /// Removes a group from the system All groups listing this as the parent are also removed and users are in turn removed from this and those groups. This may result in users no longer being in this group&#39;s parent if they were not added to it directly as well.
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

        GroupResource GetGroupData { get; }

        /// <summary>
        /// Loads a specific group&#39;s details 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        void GetGroup(string uniqueName);

        List<GroupResource> GetGroupAncestorsData { get; }

        /// <summary>
        /// Get group ancestors Returns a list of ancestor groups in reverse order (parent, then grandparent, etc
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        void GetGroupAncestors(string uniqueName);

        GroupMemberResource GetGroupMemberData { get; }

        /// <summary>
        /// Get a user from a group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="userId">The id of the user</param>
        void GetGroupMember(string uniqueName, int? userId);

        TemplateResource GetGroupMemberTemplateData { get; }

        /// <summary>
        /// Get a single group member template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetGroupMemberTemplate(string id);

        PageResourceTemplateResource GetGroupMemberTemplatesData { get; }

        /// <summary>
        /// List and search group member templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetGroupMemberTemplates(int? size, int? page, string order);

        PageResourceGroupMemberResource GetGroupMembersData { get; }

        /// <summary>
        /// Lists members of the group 
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetGroupMembers(string uniqueName, int? size, int? page, string order);

        TemplateResource GetGroupTemplateData { get; }

        /// <summary>
        /// Get a single group template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetGroupTemplate(string id);

        PageResourceTemplateResource GetGroupTemplatesData { get; }

        /// <summary>
        /// List and search group templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">a comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetGroupTemplates(int? size, int? page, string order);

        List<string> GetGroupsForUserData { get; }

        /// <summary>
        /// List groups a user is in 
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="filterChildren">Whether to limit group list to children of groups only. If true, shows only groups with parents. If false, shows only groups with no parent.</param>
        void GetGroupsForUser(int? userId, bool? filterChildren);

        PageResourceGroupResource ListGroupsData { get; }

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
        /// Update a group If adding/removing/changing parent, user membership in group/new parent groups may be modified. The parent being removed will remove members from this sub group unless they were added explicitly to the parent and the new parent will gain members unless they were already a part of it.
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

        TemplateResource UpdateGroupMemberTemplateData { get; }

        /// <summary>
        /// Update an group member template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="groupMemberTemplateResource">The group member template resource object</param>
        void UpdateGroupMemberTemplate(string id, TemplateResource groupMemberTemplateResource);

        TemplateResource UpdateGroupTemplateData { get; }

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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddMemberToGroupResponseContext;
        private DateTime mAddMemberToGroupStartTime;
        private readonly KnetikResponseContext mAddMembersToGroupResponseContext;
        private DateTime mAddMembersToGroupStartTime;
        private readonly KnetikResponseContext mCreateGroupResponseContext;
        private DateTime mCreateGroupStartTime;
        private readonly KnetikResponseContext mCreateGroupMemberTemplateResponseContext;
        private DateTime mCreateGroupMemberTemplateStartTime;
        private readonly KnetikResponseContext mCreateGroupTemplateResponseContext;
        private DateTime mCreateGroupTemplateStartTime;
        private readonly KnetikResponseContext mDeleteGroupResponseContext;
        private DateTime mDeleteGroupStartTime;
        private readonly KnetikResponseContext mDeleteGroupMemberTemplateResponseContext;
        private DateTime mDeleteGroupMemberTemplateStartTime;
        private readonly KnetikResponseContext mDeleteGroupTemplateResponseContext;
        private DateTime mDeleteGroupTemplateStartTime;
        private readonly KnetikResponseContext mGetGroupResponseContext;
        private DateTime mGetGroupStartTime;
        private readonly KnetikResponseContext mGetGroupAncestorsResponseContext;
        private DateTime mGetGroupAncestorsStartTime;
        private readonly KnetikResponseContext mGetGroupMemberResponseContext;
        private DateTime mGetGroupMemberStartTime;
        private readonly KnetikResponseContext mGetGroupMemberTemplateResponseContext;
        private DateTime mGetGroupMemberTemplateStartTime;
        private readonly KnetikResponseContext mGetGroupMemberTemplatesResponseContext;
        private DateTime mGetGroupMemberTemplatesStartTime;
        private readonly KnetikResponseContext mGetGroupMembersResponseContext;
        private DateTime mGetGroupMembersStartTime;
        private readonly KnetikResponseContext mGetGroupTemplateResponseContext;
        private DateTime mGetGroupTemplateStartTime;
        private readonly KnetikResponseContext mGetGroupTemplatesResponseContext;
        private DateTime mGetGroupTemplatesStartTime;
        private readonly KnetikResponseContext mGetGroupsForUserResponseContext;
        private DateTime mGetGroupsForUserStartTime;
        private readonly KnetikResponseContext mListGroupsResponseContext;
        private DateTime mListGroupsStartTime;
        private readonly KnetikResponseContext mRemoveGroupMemberResponseContext;
        private DateTime mRemoveGroupMemberStartTime;
        private readonly KnetikResponseContext mUpdateGroupResponseContext;
        private DateTime mUpdateGroupStartTime;
        private readonly KnetikResponseContext mUpdateGroupMemberPropertiesResponseContext;
        private DateTime mUpdateGroupMemberPropertiesStartTime;
        private readonly KnetikResponseContext mUpdateGroupMemberProperties1ResponseContext;
        private DateTime mUpdateGroupMemberProperties1StartTime;
        private readonly KnetikResponseContext mUpdateGroupMemberStatusResponseContext;
        private DateTime mUpdateGroupMemberStatusStartTime;
        private readonly KnetikResponseContext mUpdateGroupMemberTemplateResponseContext;
        private DateTime mUpdateGroupMemberTemplateStartTime;
        private readonly KnetikResponseContext mUpdateGroupTemplateResponseContext;
        private DateTime mUpdateGroupTemplateStartTime;

        public GroupMemberResource AddMemberToGroupData { get; private set; }
        public delegate void AddMemberToGroupCompleteDelegate(long responseCode, GroupMemberResource response);
        public AddMemberToGroupCompleteDelegate AddMemberToGroupComplete;

        public List<GroupMemberResource> AddMembersToGroupData { get; private set; }
        public delegate void AddMembersToGroupCompleteDelegate(long responseCode, List<GroupMemberResource> response);
        public AddMembersToGroupCompleteDelegate AddMembersToGroupComplete;

        public GroupResource CreateGroupData { get; private set; }
        public delegate void CreateGroupCompleteDelegate(long responseCode, GroupResource response);
        public CreateGroupCompleteDelegate CreateGroupComplete;

        public TemplateResource CreateGroupMemberTemplateData { get; private set; }
        public delegate void CreateGroupMemberTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateGroupMemberTemplateCompleteDelegate CreateGroupMemberTemplateComplete;

        public TemplateResource CreateGroupTemplateData { get; private set; }
        public delegate void CreateGroupTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public CreateGroupTemplateCompleteDelegate CreateGroupTemplateComplete;

        public delegate void DeleteGroupCompleteDelegate(long responseCode);
        public DeleteGroupCompleteDelegate DeleteGroupComplete;

        public delegate void DeleteGroupMemberTemplateCompleteDelegate(long responseCode);
        public DeleteGroupMemberTemplateCompleteDelegate DeleteGroupMemberTemplateComplete;

        public delegate void DeleteGroupTemplateCompleteDelegate(long responseCode);
        public DeleteGroupTemplateCompleteDelegate DeleteGroupTemplateComplete;

        public GroupResource GetGroupData { get; private set; }
        public delegate void GetGroupCompleteDelegate(long responseCode, GroupResource response);
        public GetGroupCompleteDelegate GetGroupComplete;

        public List<GroupResource> GetGroupAncestorsData { get; private set; }
        public delegate void GetGroupAncestorsCompleteDelegate(long responseCode, List<GroupResource> response);
        public GetGroupAncestorsCompleteDelegate GetGroupAncestorsComplete;

        public GroupMemberResource GetGroupMemberData { get; private set; }
        public delegate void GetGroupMemberCompleteDelegate(long responseCode, GroupMemberResource response);
        public GetGroupMemberCompleteDelegate GetGroupMemberComplete;

        public TemplateResource GetGroupMemberTemplateData { get; private set; }
        public delegate void GetGroupMemberTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetGroupMemberTemplateCompleteDelegate GetGroupMemberTemplateComplete;

        public PageResourceTemplateResource GetGroupMemberTemplatesData { get; private set; }
        public delegate void GetGroupMemberTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetGroupMemberTemplatesCompleteDelegate GetGroupMemberTemplatesComplete;

        public PageResourceGroupMemberResource GetGroupMembersData { get; private set; }
        public delegate void GetGroupMembersCompleteDelegate(long responseCode, PageResourceGroupMemberResource response);
        public GetGroupMembersCompleteDelegate GetGroupMembersComplete;

        public TemplateResource GetGroupTemplateData { get; private set; }
        public delegate void GetGroupTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public GetGroupTemplateCompleteDelegate GetGroupTemplateComplete;

        public PageResourceTemplateResource GetGroupTemplatesData { get; private set; }
        public delegate void GetGroupTemplatesCompleteDelegate(long responseCode, PageResourceTemplateResource response);
        public GetGroupTemplatesCompleteDelegate GetGroupTemplatesComplete;

        public List<string> GetGroupsForUserData { get; private set; }
        public delegate void GetGroupsForUserCompleteDelegate(long responseCode, List<string> response);
        public GetGroupsForUserCompleteDelegate GetGroupsForUserComplete;

        public PageResourceGroupResource ListGroupsData { get; private set; }
        public delegate void ListGroupsCompleteDelegate(long responseCode, PageResourceGroupResource response);
        public ListGroupsCompleteDelegate ListGroupsComplete;

        public delegate void RemoveGroupMemberCompleteDelegate(long responseCode);
        public RemoveGroupMemberCompleteDelegate RemoveGroupMemberComplete;

        public delegate void UpdateGroupCompleteDelegate(long responseCode);
        public UpdateGroupCompleteDelegate UpdateGroupComplete;

        public delegate void UpdateGroupMemberPropertiesCompleteDelegate(long responseCode);
        public UpdateGroupMemberPropertiesCompleteDelegate UpdateGroupMemberPropertiesComplete;

        public delegate void UpdateGroupMemberProperties1CompleteDelegate(long responseCode);
        public UpdateGroupMemberProperties1CompleteDelegate UpdateGroupMemberProperties1Complete;

        public delegate void UpdateGroupMemberStatusCompleteDelegate(long responseCode);
        public UpdateGroupMemberStatusCompleteDelegate UpdateGroupMemberStatusComplete;

        public TemplateResource UpdateGroupMemberTemplateData { get; private set; }
        public delegate void UpdateGroupMemberTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateGroupMemberTemplateCompleteDelegate UpdateGroupMemberTemplateComplete;

        public TemplateResource UpdateGroupTemplateData { get; private set; }
        public delegate void UpdateGroupTemplateCompleteDelegate(long responseCode, TemplateResource response);
        public UpdateGroupTemplateCompleteDelegate UpdateGroupTemplateComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersGroupsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public UsersGroupsApi()
        {
            mAddMemberToGroupResponseContext = new KnetikResponseContext();
            mAddMemberToGroupResponseContext.ResponseReceived += OnAddMemberToGroupResponse;
            mAddMembersToGroupResponseContext = new KnetikResponseContext();
            mAddMembersToGroupResponseContext.ResponseReceived += OnAddMembersToGroupResponse;
            mCreateGroupResponseContext = new KnetikResponseContext();
            mCreateGroupResponseContext.ResponseReceived += OnCreateGroupResponse;
            mCreateGroupMemberTemplateResponseContext = new KnetikResponseContext();
            mCreateGroupMemberTemplateResponseContext.ResponseReceived += OnCreateGroupMemberTemplateResponse;
            mCreateGroupTemplateResponseContext = new KnetikResponseContext();
            mCreateGroupTemplateResponseContext.ResponseReceived += OnCreateGroupTemplateResponse;
            mDeleteGroupResponseContext = new KnetikResponseContext();
            mDeleteGroupResponseContext.ResponseReceived += OnDeleteGroupResponse;
            mDeleteGroupMemberTemplateResponseContext = new KnetikResponseContext();
            mDeleteGroupMemberTemplateResponseContext.ResponseReceived += OnDeleteGroupMemberTemplateResponse;
            mDeleteGroupTemplateResponseContext = new KnetikResponseContext();
            mDeleteGroupTemplateResponseContext.ResponseReceived += OnDeleteGroupTemplateResponse;
            mGetGroupResponseContext = new KnetikResponseContext();
            mGetGroupResponseContext.ResponseReceived += OnGetGroupResponse;
            mGetGroupAncestorsResponseContext = new KnetikResponseContext();
            mGetGroupAncestorsResponseContext.ResponseReceived += OnGetGroupAncestorsResponse;
            mGetGroupMemberResponseContext = new KnetikResponseContext();
            mGetGroupMemberResponseContext.ResponseReceived += OnGetGroupMemberResponse;
            mGetGroupMemberTemplateResponseContext = new KnetikResponseContext();
            mGetGroupMemberTemplateResponseContext.ResponseReceived += OnGetGroupMemberTemplateResponse;
            mGetGroupMemberTemplatesResponseContext = new KnetikResponseContext();
            mGetGroupMemberTemplatesResponseContext.ResponseReceived += OnGetGroupMemberTemplatesResponse;
            mGetGroupMembersResponseContext = new KnetikResponseContext();
            mGetGroupMembersResponseContext.ResponseReceived += OnGetGroupMembersResponse;
            mGetGroupTemplateResponseContext = new KnetikResponseContext();
            mGetGroupTemplateResponseContext.ResponseReceived += OnGetGroupTemplateResponse;
            mGetGroupTemplatesResponseContext = new KnetikResponseContext();
            mGetGroupTemplatesResponseContext.ResponseReceived += OnGetGroupTemplatesResponse;
            mGetGroupsForUserResponseContext = new KnetikResponseContext();
            mGetGroupsForUserResponseContext.ResponseReceived += OnGetGroupsForUserResponse;
            mListGroupsResponseContext = new KnetikResponseContext();
            mListGroupsResponseContext.ResponseReceived += OnListGroupsResponse;
            mRemoveGroupMemberResponseContext = new KnetikResponseContext();
            mRemoveGroupMemberResponseContext.ResponseReceived += OnRemoveGroupMemberResponse;
            mUpdateGroupResponseContext = new KnetikResponseContext();
            mUpdateGroupResponseContext.ResponseReceived += OnUpdateGroupResponse;
            mUpdateGroupMemberPropertiesResponseContext = new KnetikResponseContext();
            mUpdateGroupMemberPropertiesResponseContext.ResponseReceived += OnUpdateGroupMemberPropertiesResponse;
            mUpdateGroupMemberProperties1ResponseContext = new KnetikResponseContext();
            mUpdateGroupMemberProperties1ResponseContext.ResponseReceived += OnUpdateGroupMemberProperties1Response;
            mUpdateGroupMemberStatusResponseContext = new KnetikResponseContext();
            mUpdateGroupMemberStatusResponseContext.ResponseReceived += OnUpdateGroupMemberStatusResponse;
            mUpdateGroupMemberTemplateResponseContext = new KnetikResponseContext();
            mUpdateGroupMemberTemplateResponseContext.ResponseReceived += OnUpdateGroupMemberTemplateResponse;
            mUpdateGroupTemplateResponseContext = new KnetikResponseContext();
            mUpdateGroupTemplateResponseContext.ResponseReceived += OnUpdateGroupTemplateResponse;
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
            
            mWebCallEvent.WebPath = "/users/groups/{unique_name}/members";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(user); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddMemberToGroupStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddMemberToGroupResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddMemberToGroupStartTime, "AddMemberToGroup", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddMemberToGroupResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddMemberToGroup: " + response.Error);
            }

            AddMemberToGroupData = (GroupMemberResource) KnetikClient.Deserialize(response.Content, typeof(GroupMemberResource), response.Headers);
            KnetikLogger.LogResponse(mAddMemberToGroupStartTime, "AddMemberToGroup", string.Format("Response received successfully:\n{0}", AddMemberToGroupData));

            if (AddMemberToGroupComplete != null)
            {
                AddMemberToGroupComplete(response.ResponseCode, AddMemberToGroupData);
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
            
            mWebCallEvent.WebPath = "/users/groups/{unique_name}/members/batch-add";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(users); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddMembersToGroupStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddMembersToGroupResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddMembersToGroupStartTime, "AddMembersToGroup", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddMembersToGroupResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddMembersToGroup: " + response.Error);
            }

            AddMembersToGroupData = (List<GroupMemberResource>) KnetikClient.Deserialize(response.Content, typeof(List<GroupMemberResource>), response.Headers);
            KnetikLogger.LogResponse(mAddMembersToGroupStartTime, "AddMembersToGroup", string.Format("Response received successfully:\n{0}", AddMembersToGroupData));

            if (AddMembersToGroupComplete != null)
            {
                AddMembersToGroupComplete(response.ResponseCode, AddMembersToGroupData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a group 
        /// </summary>
        /// <param name="groupResource">The new group</param>
        public void CreateGroup(GroupResource groupResource)
        {
            
            mWebCallEvent.WebPath = "/users/groups";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(groupResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateGroupStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateGroupResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateGroupStartTime, "CreateGroup", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateGroupResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateGroup: " + response.Error);
            }

            CreateGroupData = (GroupResource) KnetikClient.Deserialize(response.Content, typeof(GroupResource), response.Headers);
            KnetikLogger.LogResponse(mCreateGroupStartTime, "CreateGroup", string.Format("Response received successfully:\n{0}", CreateGroupData));

            if (CreateGroupComplete != null)
            {
                CreateGroupComplete(response.ResponseCode, CreateGroupData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create an group member template GroupMember Templates define a type of group member and the properties they have
        /// </summary>
        /// <param name="groupMemberTemplateResource">The group member template resource object</param>
        public void CreateGroupMemberTemplate(TemplateResource groupMemberTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/users/groups/members/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(groupMemberTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateGroupMemberTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateGroupMemberTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateGroupMemberTemplateStartTime, "CreateGroupMemberTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateGroupMemberTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateGroupMemberTemplate: " + response.Error);
            }

            CreateGroupMemberTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateGroupMemberTemplateStartTime, "CreateGroupMemberTemplate", string.Format("Response received successfully:\n{0}", CreateGroupMemberTemplateData));

            if (CreateGroupMemberTemplateComplete != null)
            {
                CreateGroupMemberTemplateComplete(response.ResponseCode, CreateGroupMemberTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a group template Group Templates define a type of group and the properties they have
        /// </summary>
        /// <param name="groupTemplateResource">The group template resource object</param>
        public void CreateGroupTemplate(TemplateResource groupTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/users/groups/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(groupTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateGroupTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateGroupTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateGroupTemplateStartTime, "CreateGroupTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateGroupTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateGroupTemplate: " + response.Error);
            }

            CreateGroupTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateGroupTemplateStartTime, "CreateGroupTemplate", string.Format("Response received successfully:\n{0}", CreateGroupTemplateData));

            if (CreateGroupTemplateComplete != null)
            {
                CreateGroupTemplateComplete(response.ResponseCode, CreateGroupTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Removes a group from the system All groups listing this as the parent are also removed and users are in turn removed from this and those groups. This may result in users no longer being in this group&#39;s parent if they were not added to it directly as well.
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        public void DeleteGroup(string uniqueName)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling DeleteGroup");
            }
            
            mWebCallEvent.WebPath = "/users/groups/{unique_name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteGroupStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteGroupResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteGroupStartTime, "DeleteGroup", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteGroupResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteGroup: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteGroupStartTime, "DeleteGroup", "Response received successfully.");
            if (DeleteGroupComplete != null)
            {
                DeleteGroupComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/users/groups/members/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (cascade != null)
            {
                mWebCallEvent.QueryParams["cascade"] = KnetikClient.ParameterToString(cascade);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteGroupMemberTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteGroupMemberTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteGroupMemberTemplateStartTime, "DeleteGroupMemberTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteGroupMemberTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteGroupMemberTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteGroupMemberTemplateStartTime, "DeleteGroupMemberTemplate", "Response received successfully.");
            if (DeleteGroupMemberTemplateComplete != null)
            {
                DeleteGroupMemberTemplateComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/users/groups/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (cascade != null)
            {
                mWebCallEvent.QueryParams["cascade"] = KnetikClient.ParameterToString(cascade);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteGroupTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteGroupTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteGroupTemplateStartTime, "DeleteGroupTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteGroupTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteGroupTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteGroupTemplateStartTime, "DeleteGroupTemplate", "Response received successfully.");
            if (DeleteGroupTemplateComplete != null)
            {
                DeleteGroupTemplateComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/users/groups/{unique_name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetGroupStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetGroupResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetGroupStartTime, "GetGroup", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetGroupResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetGroup: " + response.Error);
            }

            GetGroupData = (GroupResource) KnetikClient.Deserialize(response.Content, typeof(GroupResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupStartTime, "GetGroup", string.Format("Response received successfully:\n{0}", GetGroupData));

            if (GetGroupComplete != null)
            {
                GetGroupComplete(response.ResponseCode, GetGroupData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get group ancestors Returns a list of ancestor groups in reverse order (parent, then grandparent, etc
        /// </summary>
        /// <param name="uniqueName">The group unique name</param>
        public void GetGroupAncestors(string uniqueName)
        {
            // verify the required parameter 'uniqueName' is set
            if (uniqueName == null)
            {
                throw new KnetikException(400, "Missing required parameter 'uniqueName' when calling GetGroupAncestors");
            }
            
            mWebCallEvent.WebPath = "/users/groups/{unique_name}/ancestors";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // make the HTTP request
            mGetGroupAncestorsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetGroupAncestorsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetGroupAncestorsStartTime, "GetGroupAncestors", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetGroupAncestorsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetGroupAncestors: " + response.Error);
            }

            GetGroupAncestorsData = (List<GroupResource>) KnetikClient.Deserialize(response.Content, typeof(List<GroupResource>), response.Headers);
            KnetikLogger.LogResponse(mGetGroupAncestorsStartTime, "GetGroupAncestors", string.Format("Response received successfully:\n{0}", GetGroupAncestorsData));

            if (GetGroupAncestorsComplete != null)
            {
                GetGroupAncestorsComplete(response.ResponseCode, GetGroupAncestorsData);
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
            
            mWebCallEvent.WebPath = "/users/groups/{unique_name}/members/{user_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetGroupMemberStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetGroupMemberResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetGroupMemberStartTime, "GetGroupMember", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetGroupMemberResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetGroupMember: " + response.Error);
            }

            GetGroupMemberData = (GroupMemberResource) KnetikClient.Deserialize(response.Content, typeof(GroupMemberResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupMemberStartTime, "GetGroupMember", string.Format("Response received successfully:\n{0}", GetGroupMemberData));

            if (GetGroupMemberComplete != null)
            {
                GetGroupMemberComplete(response.ResponseCode, GetGroupMemberData);
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
            
            mWebCallEvent.WebPath = "/users/groups/members/templates/{id}";
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
            mGetGroupMemberTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetGroupMemberTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetGroupMemberTemplateStartTime, "GetGroupMemberTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetGroupMemberTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetGroupMemberTemplate: " + response.Error);
            }

            GetGroupMemberTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupMemberTemplateStartTime, "GetGroupMemberTemplate", string.Format("Response received successfully:\n{0}", GetGroupMemberTemplateData));

            if (GetGroupMemberTemplateComplete != null)
            {
                GetGroupMemberTemplateComplete(response.ResponseCode, GetGroupMemberTemplateData);
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
            
            mWebCallEvent.WebPath = "/users/groups/members/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

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
            mGetGroupMemberTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetGroupMemberTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetGroupMemberTemplatesStartTime, "GetGroupMemberTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetGroupMemberTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetGroupMemberTemplates: " + response.Error);
            }

            GetGroupMemberTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupMemberTemplatesStartTime, "GetGroupMemberTemplates", string.Format("Response received successfully:\n{0}", GetGroupMemberTemplatesData));

            if (GetGroupMemberTemplatesComplete != null)
            {
                GetGroupMemberTemplatesComplete(response.ResponseCode, GetGroupMemberTemplatesData);
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
            
            mWebCallEvent.WebPath = "/users/groups/{unique_name}/members";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

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
            mGetGroupMembersStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetGroupMembersResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetGroupMembersStartTime, "GetGroupMembers", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetGroupMembersResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetGroupMembers: " + response.Error);
            }

            GetGroupMembersData = (PageResourceGroupMemberResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceGroupMemberResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupMembersStartTime, "GetGroupMembers", string.Format("Response received successfully:\n{0}", GetGroupMembersData));

            if (GetGroupMembersComplete != null)
            {
                GetGroupMembersComplete(response.ResponseCode, GetGroupMembersData);
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
            
            mWebCallEvent.WebPath = "/users/groups/templates/{id}";
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
            mGetGroupTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetGroupTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetGroupTemplateStartTime, "GetGroupTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetGroupTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetGroupTemplate: " + response.Error);
            }

            GetGroupTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupTemplateStartTime, "GetGroupTemplate", string.Format("Response received successfully:\n{0}", GetGroupTemplateData));

            if (GetGroupTemplateComplete != null)
            {
                GetGroupTemplateComplete(response.ResponseCode, GetGroupTemplateData);
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
            
            mWebCallEvent.WebPath = "/users/groups/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

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
            mGetGroupTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetGroupTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetGroupTemplatesStartTime, "GetGroupTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetGroupTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetGroupTemplates: " + response.Error);
            }

            GetGroupTemplatesData = (PageResourceTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetGroupTemplatesStartTime, "GetGroupTemplates", string.Format("Response received successfully:\n{0}", GetGroupTemplatesData));

            if (GetGroupTemplatesComplete != null)
            {
                GetGroupTemplatesComplete(response.ResponseCode, GetGroupTemplatesData);
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
            
            mWebCallEvent.WebPath = "/users/{user_id}/groups";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterChildren != null)
            {
                mWebCallEvent.QueryParams["filter_children"] = KnetikClient.ParameterToString(filterChildren);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetGroupsForUserStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetGroupsForUserResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetGroupsForUserStartTime, "GetGroupsForUser", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetGroupsForUserResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetGroupsForUser: " + response.Error);
            }

            GetGroupsForUserData = (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetGroupsForUserStartTime, "GetGroupsForUser", string.Format("Response received successfully:\n{0}", GetGroupsForUserData));

            if (GetGroupsForUserComplete != null)
            {
                GetGroupsForUserComplete(response.ResponseCode, GetGroupsForUserData);
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
            
            mWebCallEvent.WebPath = "/users/groups";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterTemplate != null)
            {
                mWebCallEvent.QueryParams["filter_template"] = KnetikClient.ParameterToString(filterTemplate);
            }

            if (filterMemberCount != null)
            {
                mWebCallEvent.QueryParams["filter_member_count"] = KnetikClient.ParameterToString(filterMemberCount);
            }

            if (filterName != null)
            {
                mWebCallEvent.QueryParams["filter_name"] = KnetikClient.ParameterToString(filterName);
            }

            if (filterUniqueName != null)
            {
                mWebCallEvent.QueryParams["filter_unique_name"] = KnetikClient.ParameterToString(filterUniqueName);
            }

            if (filterParent != null)
            {
                mWebCallEvent.QueryParams["filter_parent"] = KnetikClient.ParameterToString(filterParent);
            }

            if (filterStatus != null)
            {
                mWebCallEvent.QueryParams["filter_status"] = KnetikClient.ParameterToString(filterStatus);
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
            mListGroupsStartTime = DateTime.Now;
            mWebCallEvent.Context = mListGroupsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mListGroupsStartTime, "ListGroups", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnListGroupsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling ListGroups: " + response.Error);
            }

            ListGroupsData = (PageResourceGroupResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceGroupResource), response.Headers);
            KnetikLogger.LogResponse(mListGroupsStartTime, "ListGroups", string.Format("Response received successfully:\n{0}", ListGroupsData));

            if (ListGroupsComplete != null)
            {
                ListGroupsComplete(response.ResponseCode, ListGroupsData);
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
            
            mWebCallEvent.WebPath = "/users/groups/{unique_name}/members/{user_id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mRemoveGroupMemberStartTime = DateTime.Now;
            mWebCallEvent.Context = mRemoveGroupMemberResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mRemoveGroupMemberStartTime, "RemoveGroupMember", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnRemoveGroupMemberResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling RemoveGroupMember: " + response.Error);
            }

            KnetikLogger.LogResponse(mRemoveGroupMemberStartTime, "RemoveGroupMember", "Response received successfully.");
            if (RemoveGroupMemberComplete != null)
            {
                RemoveGroupMemberComplete(response.ResponseCode);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a group If adding/removing/changing parent, user membership in group/new parent groups may be modified. The parent being removed will remove members from this sub group unless they were added explicitly to the parent and the new parent will gain members unless they were already a part of it.
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
            
            mWebCallEvent.WebPath = "/users/groups/{unique_name}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(groupResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateGroupStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateGroupResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateGroupStartTime, "UpdateGroup", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateGroupResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateGroup: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateGroupStartTime, "UpdateGroup", "Response received successfully.");
            if (UpdateGroupComplete != null)
            {
                UpdateGroupComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/users/groups/{unique_name}/members/{user_id}/order";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(order); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateGroupMemberPropertiesStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateGroupMemberPropertiesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateGroupMemberPropertiesStartTime, "UpdateGroupMemberProperties", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateGroupMemberPropertiesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateGroupMemberProperties: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateGroupMemberPropertiesStartTime, "UpdateGroupMemberProperties", "Response received successfully.");
            if (UpdateGroupMemberPropertiesComplete != null)
            {
                UpdateGroupMemberPropertiesComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/users/groups/{unique_name}/members/{user_id}/properties";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(properties); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateGroupMemberProperties1StartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateGroupMemberProperties1ResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateGroupMemberProperties1StartTime, "UpdateGroupMemberProperties1", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateGroupMemberProperties1Response(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateGroupMemberProperties1: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateGroupMemberProperties1StartTime, "UpdateGroupMemberProperties1", "Response received successfully.");
            if (UpdateGroupMemberProperties1Complete != null)
            {
                UpdateGroupMemberProperties1Complete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/users/groups/{unique_name}/members/{user_id}/status";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "unique_name" + "}", KnetikClient.ParameterToString(uniqueName));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "user_id" + "}", KnetikClient.ParameterToString(userId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(status); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateGroupMemberStatusStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateGroupMemberStatusResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateGroupMemberStatusStartTime, "UpdateGroupMemberStatus", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateGroupMemberStatusResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateGroupMemberStatus: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateGroupMemberStatusStartTime, "UpdateGroupMemberStatus", "Response received successfully.");
            if (UpdateGroupMemberStatusComplete != null)
            {
                UpdateGroupMemberStatusComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/users/groups/members/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(groupMemberTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateGroupMemberTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateGroupMemberTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateGroupMemberTemplateStartTime, "UpdateGroupMemberTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateGroupMemberTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateGroupMemberTemplate: " + response.Error);
            }

            UpdateGroupMemberTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateGroupMemberTemplateStartTime, "UpdateGroupMemberTemplate", string.Format("Response received successfully:\n{0}", UpdateGroupMemberTemplateData));

            if (UpdateGroupMemberTemplateComplete != null)
            {
                UpdateGroupMemberTemplateComplete(response.ResponseCode, UpdateGroupMemberTemplateData);
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
            
            mWebCallEvent.WebPath = "/users/groups/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(groupTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateGroupTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateGroupTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateGroupTemplateStartTime, "UpdateGroupTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateGroupTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateGroupTemplate: " + response.Error);
            }

            UpdateGroupTemplateData = (TemplateResource) KnetikClient.Deserialize(response.Content, typeof(TemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateGroupTemplateStartTime, "UpdateGroupTemplate", string.Format("Response received successfully:\n{0}", UpdateGroupTemplateData));

            if (UpdateGroupTemplateComplete != null)
            {
                UpdateGroupTemplateComplete(response.ResponseCode, UpdateGroupTemplateData);
            }
        }

    }
}
