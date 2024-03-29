﻿using Split.DbContexts.Tables;
using Split.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        List<Groups> GetGroups();
        Group GetGroup(Guid id);
        Group AddGroup(string name, int adminId, string description);
        void RemoveGroup(Guid groupId);
        Group UpdateGroupName(Guid groupId, string name);
        GroupsMembers AddGroupMember(Guid groupId, int userId);
        List<GroupsMembers> GetGroupMembers(Guid groupId);
        void RemoveGroupMember(Guid groupId, int userId);
        void RemoveAllMembers(Guid groupId);
        bool IsUserInGroup(Guid groupId, int userId);
        List<Groups> GetUserGroups(int userId);
        Group UpdateGroupDescription(Guid groupId, string description);
        void DeleteGroupExpenses(Guid groupId);
    }
}
