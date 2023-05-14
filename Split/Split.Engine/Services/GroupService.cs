using Microsoft.Extensions.Logging;
using Split.Engine.Exceptions;
using Split.Engine.Models;
using Split.Engine.Repositories;
using Split.Engine.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Services
{
    public class GroupService
    {
        private readonly ILogger<RoleService> logger;
        private readonly IGroupRepository groupRepository;

        public GroupService(ILogger<RoleService> logger, IGroupRepository groupRepository)
        {
            this.logger = logger;
            this.groupRepository = groupRepository;
        }

        public Group? AddGroup(string name)
        {
            try
            {
                return groupRepository.AddGroup(name);
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
                groupRepository.RemoveAllMembers(groupId);
                groupRepository.RemoveGroup(groupId);
            }
            catch (Exception)
            {

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
                        Members = null
                    }).ToList();
                return groups;
            }
            catch(GroupNotFoundException)
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
    }
}
