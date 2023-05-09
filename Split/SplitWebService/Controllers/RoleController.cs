using Microsoft.AspNetCore.Mvc;
using Split.DbContexts.Tables;
using Split.Engine.Exceptions;
using Split.Engine.Models;
using Split.Engine.Services;

namespace SplitWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly RoleService roleService;

        public RoleController(
            ILogger<UserController> logger,
            RoleService roleService)
        {
            this.logger = logger;
            this.roleService = roleService;
        }

        [HttpGet("", Name = "GetAllRoles")]
        public List<Role>? GetRoles() => roleService.GetRoles();

        [HttpGet("SetRole/{userId:int}/{roleName}", Name = "SetRole")]
        public void SetRole(int userId, string roleName)
        {
            try
            {
                roleService.SetRole(userId, roleName);
            }
            catch (ServiceException)
            {

            }
        }

        [HttpGet("RemoveRole/{userId:int}/{roleName}", Name = "RemoveRole")]
        public void RemoveRole(int userId, string roleName)
        {
            try
            {
                roleService.RemoveRole(userId, roleName);
            }
            catch (RoleNotFoundException)
            {

            }
        }

        [HttpGet("AddRole/{roleName}/{discription}", Name = "AddRole")]
        public void AddRole(string roleName, string discription)
        {
            roleService.AddRole(roleName, discription);
        }

        [HttpGet("DeleteRole/{roleName}", Name = "DeleteRole")]
        public void DeleteRole(string roleName)
        {
            roleService.DeleteRole(roleName);
        }

    }
}
