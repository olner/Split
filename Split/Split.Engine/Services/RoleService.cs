using Split.Engine.Repositories.Interfaces;
using Split.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Split.Engine.Exceptions;
using Split.DbContexts.Tables;
using Split.Engine.Repositories;
using Microsoft.Extensions.Logging;

namespace Split.Engine.Services
{
    public class RoleService
    {
        private readonly ILogger<RoleService> logger;
        private readonly IRoleRepository roleRepository;
        private readonly IUserRepository userRepository;

        public RoleService(
            ILogger<RoleService> logger, 
            IRoleRepository roleRepository,IUserRepository userRepository)
        {
            this.logger = logger;
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
        }

        public List<Role>? GetRoles()
        {
            logger.LogDebug("get all roles");
            try
            {
                var roles = roleRepository
                .GetRoles()
                .Select(role => new Role
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                }).ToList();
                return roles;
            }
            catch (RoleNotFoundException e)
            {
                logger.LogError(e, "get all roles error");
                return null;
            }
        }
        public Role? GetRole(string roleName)
        {
            try
            {
                return roleRepository.GetRole(roleName);
            } 
            catch (RoleNotFoundException)
            {
                return null;
            }
        }
        public Role? AddRole(string name, string description)
        {
            if(roleRepository.IsRoleExists(name)) throw new ServiceException("Такая роль уже есть");

            try
            {
                return roleRepository.AddRole(name, description);
            }
            catch (RoleNotFoundException)
            {
                return null;
            }
        }
        public void DeleteRole(string name)
        {
            try
            {
                roleRepository.DeleteRole(name);
            }
            catch (RoleNotFoundException)
            {

            }
        }
        public void SetRole(int userId, string roleName, Guid groupId)
        {
            var roles = userRepository.GetUserRoles(userId);
            foreach (var role in roles)
            {
                if (role == roleName) throw new ServiceException("User already have this role");
            }
            try
            {
                roleRepository.SetRole(roleRepository.GetRoleId(roleName), userId,groupId);
            }
            catch (RoleNotFoundException)
            {

            }
        }

        public void RemoveRole(int userId, string roleName, Guid groupId)
        {
            //var role = roleRepository.GetRole(roleName) ?? throw new RoleNotFoundException();
            try
            {
                var id = roleRepository.GetRoleId(roleName);
                roleRepository.RemoveRole(id, userId,groupId);
            }
            catch (RoleNotFoundException)
            {

            }
        }
    }
}
