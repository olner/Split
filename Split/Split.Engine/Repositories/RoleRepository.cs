using Split.DbContexts.Tables;
using Split.DbContexts;
using Split.Engine.Exceptions;
using Split.Engine.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public List<Roles> GetRoles()
        {
            using var context = contextFactory.CreateDbContext();
            var roles = context.Roles.ToList()
                ?? throw new RoleNotFoundException();

            return roles;
        }
        public Role GetRole(string roleName)
        {
            using var context = contextFactory.CreateDbContext();
            var rawRole = context.Roles.Where(x => x.Name == roleName).FirstOrDefault()
                ?? throw new RoleNotFoundException();

            var role = new Role
            {
                Id = rawRole.Id,
                Name = rawRole.Name,
                Description = rawRole.Description
            };
            return role;
        }
        public bool IsRoleExists(string roleName)
        {
            using var context = contextFactory.CreateDbContext();
            try
            {
                var role = context.Roles.Where(x => x.Name == roleName).FirstOrDefault();
                if (role != null) return true;
                return false;
            }
            catch(Exception) { throw new RoleNotFoundException(roleName); }
            
        }
        public void SetRole(int roleId, int userId)
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
            var userRole = context.UserRoles.Where(p => p.UserId == userId && p.RoleId == roleId).FirstOrDefault()
                ?? throw new UserRoleNotFoundException();

            context.UserRoles.Remove(userRole);
            context.SaveChanges();
        }
        public int GetRoleId(string roleName)
        {
            using var context = contextFactory.CreateDbContext();
            var role = context.Roles.Where(x=>x.Name == roleName).FirstOrDefault()
                ?? throw new RoleNotFoundException();

            return role.Id;
        }
        public Role AddRole(string name, string description)
        {
            using var context = contextFactory.CreateDbContext();
            var role = new Roles
            {
                Name = name,
                Description = description
            };
            context.Roles.Add(role);
            context.SaveChanges();
            return GetRole(name);
        }
        public void DeleteRole(string name)
        {
            using var context = contextFactory.CreateDbContext();
            var role = context.Roles.Where(x => x.Name == name).FirstOrDefault() 
                ?? throw new RoleNotFoundException();

            context.Roles.Remove(role);
            context.SaveChanges();
        }
    }
}
