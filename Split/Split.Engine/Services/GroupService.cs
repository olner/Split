using Microsoft.Extensions.Logging;
using Split.Engine.Exceptions;
using Split.Engine.Models;
using Split.Engine.Repositories.Interfaces;

namespace Split.Engine.Services
{
    public class GroupService
    {
        private readonly ILogger<RoleService> logger;
        private readonly IGroupRepository groupRepository;
        private readonly IExpenseRepository expenseRepository;

        public GroupService(ILogger<RoleService> logger, IGroupRepository groupRepository, IExpenseRepository expenseRepository)
        {
            this.logger = logger;
            this.groupRepository = groupRepository;
            this.expenseRepository = expenseRepository;
        }

        public Group? AddGroup(string name, int adminId, string description)
        {
            try
            {
                return groupRepository.AddGroup(name, adminId, description);
            }
            catch (GroupNotFoundException)
            {
                return null;
            }
        }

        public void RemoveGroup(Guid groupId)
        {
            try
            {
                expenseRepository.DeleteGroupDebgs(groupId);
                groupRepository.DeleteGroupExpenses(groupId);
                groupRepository.RemoveAllMembers(groupId);
                groupRepository.RemoveGroup(groupId);
            }
            catch (GroupMembersNotFoundException)
            {

            }
        }

        public void DeleteGroupExpenses(Guid groupId)
        {
            groupRepository.DeleteGroupExpenses(groupId);   
        }

        public Group? UpdateGroupName(Guid groupId, string name)
        {
            try
            {
                return groupRepository.UpdateGroupName(groupId, name);
            }
            catch(GroupNotFoundException)
            {
                return null;
            }
        }

        public Group? UpdateGroupDescription(Guid groupId, string description)
        {
            try
            {
                return groupRepository.UpdateGroupDescription(groupId, description);
            }
            catch (GroupNotFoundException)
            {
                return null;
            }
        }

        public List<Group>? GetGroups() 
        {
            try
            {
                var groups = groupRepository
                    .GetGroups()
                    .Select(group => new Group
                    {
                        Id = group.Id,
                        Name = group.Name,
                        Date = group.Date,
                        Admin = group.Admin,
                        Description = group.Description,
                        Members = null
                    }).ToList();
                return groups;
            }
            catch(GroupNotFoundException)
            {
                return null;
            }
        }

        public Group? GetGroup(Guid gropId)
        {
            try
            {
                return groupRepository.GetGroup(gropId);
            }
            catch (GroupNotFoundException)
            {
                return null;
            }
        }
        
        public void AddGroupMember(Guid groupId, int userId)
        {
            try
            {
                groupRepository.AddGroupMember(groupId, userId);
            }
            catch (GroupMembersNotFoundException)
            {

            }
        }

        public List<GroupMember>? GetGroupMembers(Guid groupId) 
        {
            try
            {
                var groupMembers = groupRepository
                    .GetGroupMembers(groupId)
                    .Select(member => new GroupMember
                    {
                        Id = member.Id,
                        GroupId = member.GroupId,
                        UserId = member.UserID
                    }).ToList();
                return groupMembers;
            }
            catch (GroupMembersNotFoundException)
            {
                return null;
            }
        }

        public void RemoveGroupMember(Guid groupId, int userId)
        {
            try
            {
                groupRepository.RemoveGroupMember(groupId, userId);
            }
            catch (Exception)
            {

            }
        }

        public List<Group>? GetUserGroups(int userId)
        {
            try
            {
                var groups = groupRepository.GetUserGroups(userId)
                    .Select(x => new Group
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Date = x.Date,
                        Admin = x.Admin,
                        Description = x.Description,
                        Members = null
                    }).ToList();
                return groups;
            }
            catch (GroupNotFoundException)
            {
                return null;
            }
        }
    }
}
