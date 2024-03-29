﻿using Microsoft.EntityFrameworkCore;
using Split.DbContexts;
using Split.DbContexts.Tables;
using Split.Engine.Exceptions;
using Split.Engine.Models;
using Split.Engine.Repositories.Interfaces;

namespace Split.Engine.Repositories
{

    public class GroupRepository : IGroupRepository
    {
        private readonly IDbContextFactory<SplitDbContext> contextFactory;

        public GroupRepository(IDbContextFactory<SplitDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public List<Groups> GetGroups()
        {
            using var context = contextFactory.CreateDbContext();
            var groups = context.Groups.ToList() ?? throw new GroupNotFoundException();
            if (groups.Count == 0) throw new GroupNotFoundException();
            return groups;
        }

        public Group GetGroup(Guid id)
        {
            using var context = contextFactory.CreateDbContext();
            var groups = context.Groups.Where(x => x.Id == id).FirstOrDefault() ?? throw new GroupNotFoundException();

            var group = new Group
            {
                Id = groups.Id,
                Name = groups.Name,
                Date = groups.Date,
                Admin = groups.Admin,
                Description = groups.Description,
                Members = null
            };

            return group;
        }

        public Group AddGroup(string name, int adminId, string description)
        {
            using var context = contextFactory.CreateDbContext();
            Groups group = new Groups
            {
                Id = new Guid(),
                Name = name,
                Date = DateTime.Now,
                Admin = adminId,
                Description = description
            };
            context.Groups.Add(group);
            context.SaveChanges();

            return GetGroup(group.Id);
        }

        public void RemoveGroup(Guid groupId)
        {
            using var context = contextFactory.CreateDbContext();
            var group = context.Groups.Where(x => x.Id == groupId).FirstOrDefault() ?? throw new GroupNotFoundException();

            context.Groups.Remove(group);
            context.SaveChanges();
        }

        public Group UpdateGroupName(Guid groupId, string name)
        {
            using var context = contextFactory.CreateDbContext();
            var group = context.Groups.Where(x => x.Id == groupId).FirstOrDefault() ?? throw new GroupNotFoundException();

            group.Name = name;

            context.Groups.Update(group);
            context.SaveChanges();

            return GetGroup(groupId);
        }

        public Group UpdateGroupDescription(Guid groupId, string description)
        {
            using var context = contextFactory.CreateDbContext();
            var group = context.Groups.Where(x => x.Id == groupId).FirstOrDefault() ?? throw new GroupNotFoundException();

            group.Description = description;

            context.Groups.Update(group);
            context.SaveChanges();

            return GetGroup(groupId);
        }

        public GroupsMembers GetGroupMember(Guid groupId, int userId)
        {
            using var context = contextFactory.CreateDbContext();
            var member = context.GroupsMembers.Where(x => x.GroupId == groupId && x.UserID == userId).FirstOrDefault()
                ?? throw new GroupMembersNotFoundException();
            return member;
        }

        public GroupsMembers AddGroupMember(Guid groupId, int userId)
        {
            using var context = contextFactory.CreateDbContext();
            GroupsMembers groupsMembers = new GroupsMembers
            {
                UserID = userId,
                GroupId = groupId
            };
            context.GroupsMembers.Add(groupsMembers);
            context.SaveChanges();
            return GetGroupMember(groupId,userId);
        }

        public void RemoveGroupMember(Guid groupId, int userId)
        {
            using var context = contextFactory.CreateDbContext();
            var member = context.GroupsMembers.Where(x => x.GroupId == groupId && x.UserID == userId).FirstOrDefault()
                ?? throw new GroupMembersNotFoundException();
            context.GroupsMembers.Remove(member);
            context.SaveChanges();
        }

        public void RemoveAllMembers(Guid groupId)
        {
            using var context = contextFactory.CreateDbContext();
            var members = context.GroupsMembers.Where(x => x.GroupId == groupId).ToList()
                ?? throw new GroupMembersNotFoundException();
            if (members.Count == 0) throw new GroupMembersNotFoundException();

            context.GroupsMembers.RemoveRange(members);
            context.SaveChanges();
        }

        public bool IsUserInGroup(Guid groupId, int userId)
        {
            using var context = contextFactory.CreateDbContext();
            var memberExists = context.GroupsMembers.Any(x => x.UserID == userId && x.GroupId == groupId);
            return memberExists;
        }
        public List<GroupsMembers> GetGroupMembers(Guid groupId)
        {
            using var context = contextFactory.CreateDbContext();
            var groupMembers = context.GroupsMembers.Where(x => x.GroupId == groupId).ToList();
            if(groupMembers == null)
            {
                throw new GroupNotFoundException();
            }
            return groupMembers;
        }
        
        public List<Groups> GetUserGroups(int userId)
        {
            using var context = contextFactory.CreateDbContext();

            var groups = context.Groups.Where(x => x.groupsMembers.Any(z => z.UserID == userId)).ToList();
            if (groups.Count == 0) throw new GroupNotFoundException();

            return groups;
        }

        public void DeleteGroupExpenses(Guid groupId)
        {
            using var context = contextFactory.CreateDbContext();
            var expenses = context.Expenses.Where(x => x.GroupId == groupId).ToList() ?? throw new ExpenseNotFoundException();
            context.Expenses.RemoveRange(expenses);
            context.SaveChanges();
        }

    }
}
