using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Split.DbContexts;
using Split.DbContexts.Tables;
using Split.Engine.Exceptions;
using Split.Engine.Models;
using Split.Engine.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return groups;
        }
        //TODO: Не по name должно быть. Придумать что делать с ID (может в guid переделать)
        public Group GetGroup(string name)
        {
            using var context = contextFactory.CreateDbContext();
            var groups = context.Groups.Where(x => x.Name == name).FirstOrDefault() ?? throw new GroupNotFoundException();

            var group = new Group
            {
                Id = groups.Id,
                Name = groups.Name,
                Members = null
            };

            return group;
        }

        public Group AddGroup(string name)
        {
            using var context = contextFactory.CreateDbContext();
            Groups group = new Groups
            {
                Name = name
            };
            context.Groups.Add(group);
            context.SaveChanges();

            return GetGroup(name);
        }

    }
}
