using Microsoft.AspNetCore.Mvc;
using Split.Engine.Exceptions;
using Split.Engine.Models;
using Split.Engine.Repositories.Interfaces;
using Split.Engine.Services;
using System.Text.Json.Serialization;
using static SplitWebService.Controllers.UserController;

namespace SplitWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        private readonly IUserRepository userRepository;

        public UserController(
            UserService userService,
            IUserRepository userRepository)
        {
            this.userService = userService;
            this.userRepository = userRepository;
        }

        public class ServiceResponse<T>
        {
            public T? Response { get; set; }
        }

        [HttpGet("", Name = "GetAllUsers")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<User>>))]
        public IActionResult GetUsers()
        {
            var result = userService.GetUsers();

            return Ok(new ServiceResponse<List<User>> { Response = result });
        }

        [HttpGet("{id:int}", Name = "GetUserById")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<User>))]
        public IActionResult GetUser(int id)
        {
            var result = userService.GetUserById(id);

            return Ok(new ServiceResponse<User> { Response = result });
        }

        [HttpGet("/GetByLogin", Name = "GetUserByLogin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<User>))]
        public IActionResult GetUserByLogin(string login)
        {
            var result = userService.GetUserByLogin(login);
            return Ok(new ServiceResponse<User> { Response = result });
        }

        [HttpPost("/auth", Name = "Authorize")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<User>))]
        public IActionResult Authorize(string login, string password)
        {
            var result = userService.Authorize(login, password);

            return Ok(new ServiceResponse<User> { Response = result });
        }

        [HttpPost("/reg", Name = "Register")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<User>))]
        public IActionResult Register(string login, string password, string email)
        {
            try
            {
                var result = userService.Register(login, password, email);
                return Ok(new ServiceResponse<User> { Response = result });
            }
            catch (ServiceException)
            {
                return Ok(new ServiceResponse<User> { Response = (User)null });
            }
        }

        [HttpPatch("/updUserData", Name = "UpdateUserData")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<User>))]
        public IActionResult UpdateUserData(int id, string login, string email, string password)
        {
            var result = userService.UpdateUserData(id, login, email, password);

            return Ok(new ServiceResponse<User> { Response = result });
        }

        [HttpDelete("/delete", Name = "Delete")]
        public void Delete(int id) => userService.DeleteUser(id);

        [HttpGet("/Friend", Name = "GetFriend")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<Friend>))]
        public IActionResult GetFriend(int userId, int friendId)
        {
            var result = userService.GetFriend(userId, friendId);
            return Ok(new ServiceResponse<Friend> { Response = result });
        }

        [HttpPost("/AddFriend", Name = "AddFriend")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<Friend>))]
        public IActionResult AddFriend(int userId, int friendId, bool request)
        {
            var result = userService.AddFriend(userId, friendId, request);

            return Ok(new ServiceResponse<Friend> { Response = result });
        }

        [HttpDelete("/DeleteFriend", Name = "DeleteFriend")]
        public void DeleteFriend(Guid id) => userService.DeleteFriend(id);

        [HttpGet("/Friends", Name = "GetFriends")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<List<Friend>>))]
        public IActionResult GetFriends(int userId)
        {
            var result = userService.GetFriends(userId);

            return Ok(new ServiceResponse<List<Friend>> { Response = result });
        }

        [HttpPatch("/ChangeFriendRequest", Name = "ChangeFriendRequest")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<Friend>))]
        public IActionResult ChangeFriendRequest(Guid id)
        {
            var result = userService.ChangeFriendRequest(id);

            return Ok(new ServiceResponse<Friend> { Response = result });
        }
    }
}
