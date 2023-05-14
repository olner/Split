using Microsoft.AspNetCore.Mvc;
using Split.Engine.Models;
using Split.Engine.Repositories.Interfaces;
using Split.Engine.Services;
using SplitWebService.Models;

namespace SplitWebService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly GroupService groupService;

        public GroupController(GroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpGet("", Name = "GetAllGroups")]
        public List<Group>? GetGroups() => groupService.GetGroups();

        [HttpPost("AddGroup", Name = "AddGroup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest, "application/json")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError, "application/json")]
        public IActionResult AddGroup(string name)
        {
            groupService.AddGroup(name);
            return NoContent();
        }

        [HttpDelete("DeleteGroup/{groupId}", Name = "DeleteGroup")]
        public void DeleteGroup(Guid groupId)
        {
            groupService.RemoveGroup(groupId);
        }

        [HttpPost("AddUserToGroup", Name = "AddUserToGroup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest, "application/json")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError, "application/json")]
        public IActionResult AddUserToGroup(Guid groupId,int userId)
        {
            groupService.AddGroupMember(groupId,userId);
            return NoContent();
        }

        [HttpDelete("DeleteGroupMember/{groupId}/{userId}", Name = "DeleteGroupMember")]
        public void RemoveGroupMember(Guid groupId, int userId)
        {
            groupService.RemoveGroupMember(groupId, userId);
        }
    }
}
