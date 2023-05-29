using Microsoft.AspNetCore.Mvc;
using Split.Engine.Models;
using Split.Engine.Services;
using SplitWebService.Models;
using System.Xml.Linq;

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

        public class ServiceResponse<T>
        {
            public T? Response { get; set; }
        }

        [HttpGet("/Groups", Name = "GetAllGroups")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<Group>>))]
        public IActionResult GetGroups()
        {
            var result = groupService.GetGroups();

            return Ok(new ServiceResponse<List<Group>> { Response = result });
        }

        [HttpGet("/Group", Name = "GetGroup")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<Group>))]
        public IActionResult GetGroup(Guid groupId)
        {
            var result = groupService.GetGroup(groupId);
            return Ok(new ServiceResponse<Group> { Response = result });
        }

        [HttpPost("/AddGroup", Name = "AddGroup")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<Group>))]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest, "application/json")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError, "application/json")]
        public IActionResult AddGroup(string name, int adminId, string description)
        {
            var result = groupService.AddGroup(name, adminId, description);
            return Ok(new ServiceResponse<Group> { Response = result });
        }

        [HttpDelete("/DeleteGroup", Name = "DeleteGroup")]
        public void DeleteGroup(Guid groupId)
        {
            groupService.RemoveGroup(groupId);
        }

        [HttpPatch("/UpdateName", Name = "UpdateName")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<Group>))]
        public IActionResult UpdateGroupName(Guid groupId, string name)
        {
            var result = groupService.UpdateGroupName(groupId, name);
            return Ok(new ServiceResponse<Group> { Response = result });
        }

        [HttpPatch("/UpdateDescription", Name = "UpdateDescription")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<Group>))]
        public IActionResult UpdateGroupDescription(Guid groupId, string description)
        {
            var result = groupService.UpdateGroupDescription(groupId, description);
            return Ok(new ServiceResponse<Group> { Response = result });
        }

        [HttpGet("/Members", Name = "GetGroupMembers")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<GroupMember>>))]
        public IActionResult GetGroupMembers(Guid groupId)
        {
            var result = groupService.GetGroupMembers(groupId);
            return Ok(new ServiceResponse<List<GroupMember>> { Response = result });
        }

        [HttpPost("/AddUserToGroup", Name = "AddUserToGroup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest, "application/json")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError, "application/json")]
        public IActionResult AddUserToGroup(Guid groupId,int userId)
        {
            groupService.AddGroupMember(groupId,userId);
            return Ok();
        }

        [HttpDelete("/DeleteGroupMember", Name = "DeleteGroupMember")]
        public void RemoveGroupMember(Guid groupId, int userId)
        {
            groupService.RemoveGroupMember(groupId, userId);
        }

        [HttpGet("/UserGroups", Name = "GetUserGroups")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<Group>>))]
        public IActionResult GetUserGroups(int userId)
        {
            var result = groupService.GetUserGroups(userId);
            return Ok(new ServiceResponse<List<Group>> { Response = result });
        }
    }
}
