using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Split.DbContexts.Tables;
using Split.Engine.Exceptions;
using Split.Engine.Models;
using Split.Engine.Services;
using SplitWebService.Models;

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

        [HttpPost("AddRole", Name = "AddRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest, "application/json")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError, "application/json")]
        public IActionResult AddRole(AddRoleRequest request)
        {
            roleService.AddRole(request.RoleName, request.Description);
            return NoContent();
        }

        [HttpDelete("DeleteRole/{roleName}", Name = "DeleteRole")]        
        public void DeleteRole(string roleName)
        {
            roleService.DeleteRole(roleName);
        }

    }
}
