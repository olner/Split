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
        public class ServiceResponse<T>
        {
            public T? Response { get; set; }
        }

        [HttpGet("/Roles", Name = "GetAllRoles")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<Role>>))]
        public IActionResult GetRoles()
        {
            var result = roleService.GetRoles();

            return Ok(new ServiceResponse<List<Role>> { Response = result });
        }

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
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<Role>))]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest, "application/json")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError, "application/json")]
        public IActionResult AddRole(AddRoleRequest request)
        {
            var result = roleService.AddRole(request.RoleName, request.Description);

            return Ok(new ServiceResponse<Role> { Response = result });
        }

        [HttpDelete("/DeleteRole", Name = "DeleteRole")]        
        public void DeleteRole(string roleName)
        {
            roleService.DeleteRole(roleName);
        }
    }
}
