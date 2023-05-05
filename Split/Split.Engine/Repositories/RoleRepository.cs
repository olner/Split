using Split.DbContexts.Tables;
using Split.DbContexts;
using Split.Engine.Exceptions;
using Split.Engine.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Split.Engine.Models;

namespace Split.Engine.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContextFactory<SplitDbContext> contextFactory;

        public RoleRepository(IDbContextFactory<SplitDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public List<Role> GetRoles()
        {
            using var context = contextFactory.CreateDbContext();
        }
        public void AddRole(int roleId, int userId)
        {
            using var context = contextFactory.CreateDbContext();
            UserRoles userRole = new UserRoles
            {
                RoleId = roleId,
                UserId = userId
            };
            context.UserRoles.Add(userRole);
            context.SaveChanges();
        }
        public void RemoveRole(int roleId, int userId)
        {
            using var context = contextFactory.CreateDbContext();
            var userRole = context.UserRoles.Where(p => p.UserId == userId && p.RoleId == roleId).FirstOrDefault();
            if (userRole == null)
            {
                throw new UserRoleNotFoundException();
            }
            context.UserRoles.Remove(userRole);
            context.SaveChanges();
        }
        public int GetRoleId(string roleName)
        {
            using var context = contextFactory.CreateDbContext();
            var role = context.Roles.Where(x=>x.Name == roleName).Select(x=>x.Id).FirstOrDefault();
            if (role == null) 
            {
                throw new RoleNotFoundException();
            }
            return role;
        }
    }
}
