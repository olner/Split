﻿using Microsoft.AspNetCore.Mvc;
using Split.Engine.Models;
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

        [HttpGet("/Groups", Name = "GetAllGroups")]
        public List<Group>? GetGroups() => groupService.GetGroups();

        [HttpGet("/Group", Name = "GetGroup")]
        public Group? GetGroup(Guid groupId) => groupService.GetGroup(groupId);

        [HttpPost("/AddGroup", Name = "AddGroup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest, "application/json")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError, "application/json")]
        public Group? AddGroup(string name, int adminId)
        {
            return groupService.AddGroup(name, adminId);
        }

        [HttpDelete("/DeleteGroup", Name = "DeleteGroup")]
        public void DeleteGroup(Guid groupId)
        {
            groupService.RemoveGroup(groupId);
        }

        [HttpPatch("/UpdateName", Name = "UpdateName")]
        public Group? UpdateGroupName(Guid groupId, string name) => groupService.UpdateGroupName(groupId, name);

        [HttpGet("/Members", Name = "GetGroupMembers")]
        public List<GroupMember>? GetGroupMembers(Guid groupId) => groupService.GetGroupMembers(groupId);

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
        public List<Group>? GetUserGroups(int userId) => groupService.GetUserGroups(userId);
    }
}
