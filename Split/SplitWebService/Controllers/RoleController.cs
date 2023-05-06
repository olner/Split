using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("SetRole{userId:int}/{roleName}", Name = "SetRole")]
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
    }
}
