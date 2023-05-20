using Microsoft.AspNetCore.Mvc;
using Split.Engine.Models;
using Split.Engine.Services;
using SplitWebService.Models;

namespace SplitWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService roleService;

        public RoleController(
            ILogger<UserController> logger,
            RoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet("/Roles", Name = "GetAllRoles")]
        public List<Role>? GetRoles() => roleService.GetRoles();

        [HttpPost("/SetRole", Name = "SetRole")]
        public void SetRole(int userId, string roleName, Guid groupId)
        {
                roleService.SetRole(userId, roleName, groupId);
        }

        [HttpDelete("/RemoveRole", Name = "RemoveRole")]
        public void RemoveRole(int userId, string roleName, Guid groupId)
        {
                roleService.RemoveRole(userId, roleName, groupId);
        }

        [HttpPost("/AddRole", Name = "AddRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest, "application/json")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError, "application/json")]
        public IActionResult AddRole(AddRoleRequest request)
        {
            roleService.AddRole(request.RoleName, request.Description);
            return NoContent();
        }

        [HttpDelete("/DeleteRole", Name = "DeleteRole")]        
        public void DeleteRole(string roleName)
        {
            roleService.DeleteRole(roleName);
        }
    }
}
