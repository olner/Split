using Split.DbContexts.Tables;
using Split.DbContexts;
using Split.Engine.Exceptions;
using Split.Engine.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split.Engine.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public void AddRole(int roleId, int userId)
        {
            using var context = new SplitDbContextFactory().CreateDbContext(null);
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
            using var context = new SplitDbContextFactory().CreateDbContext(null);
            var userRole = context.UserRoles.Where(p => p.UserId == userId && p.RoleId == roleId).FirstOrDefault();
            if (userRole == null)
            {
                throw new UserRoleNotFoundException();
            }
            context.UserRoles.Remove(userRole);
            context.SaveChanges();
        }
        public List<string> GetUserRoles(int userId)
        {
            using var context = new SplitDbContextFactory().CreateDbContext(null);
            var roles = context.UserRoles.Where(p => p.UserId == userId).Select(p => p.Roles.Name).ToList();
            if (roles == null)
            {
                throw new UserNotFoundException();
            }
            return roles;
        }
        public int GetRoleId(string roleName)
        {
            using var context = new SplitDbContextFactory().CreateDbContext(null);
            var role = context.Roles.Where(x=>x.Name == roleName).Select(x=>x.Id).FirstOrDefault();
            if (role == null) 
            {
                throw new RoleNotFoundException();
            }
            return role;
        }
    }
}
