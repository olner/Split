using Microsoft.AspNetCore.Mvc;
using Split.Engine.Exceptions;
using Split.Engine.Models;
using Split.Engine.Repositories.Interfaces;
using Split.Engine.Services;

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

        [HttpGet("", Name = "GetAllUsers")]
        public List<User> GetUsers() => userService.GetUsers();

        [HttpGet("{id:int}", Name = "GetUserById")]
        public User? GetUser(int id) => userService.GetUserById(id);

        [HttpGet("/GetByLogin", Name = "GetUserByLogin")]
        public User? GetUserByLogin(string login) => userService.GetUserByLogin(login);

        [HttpGet("/auth", Name = "Authorize")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<User>))]
        public IActionResult Authorize(string login, string password) 
        {
            var user = userService.Authorize(login, password);
            return Ok(new ResponseResult<User> { Result = user});
        }
        public class ResponseResult<T>
        {
            public T Result { get; set; }
        }

        [HttpPost("/reg", Name = "Register")]
        public User? Register(string login, string password, string email)
        {
            try
            {
                return userService.Register(login, password, email);
            }
            catch (ServiceException)
            {
                return null;
            }            
        }

        [HttpPatch("/updUserData", Name = "UpdateUserData")]
        public User? UpdateUserData(int id, string login, string email, string password) => userService.UpdateUserData(id, login, email, password);

        [HttpDelete("/delete", Name = "Delete")]
        public void Delete(int id) => userService.DeleteUser(id);

        [HttpGet("/Friend", Name = "GetFriend")]
        public Friend? GetFriend(int userId, int friendId) => userService.GetFriend(userId, friendId);

        [HttpPost("/AddFriend", Name = "AddFriend")]
        public Friend? AddFriend(int userId, int friendId, bool request) => userService.AddFriend(userId,friendId,request);

        [HttpDelete("/DeleteFriend", Name = "DeleteFriend")]
        public void DeleteFriend(Guid id) => userService.DeleteFriend(id);

        [HttpGet("/Friends", Name = "GetFriends")]
        public List<Friend>? GetFriends(int userId) => userService.GetFriends(userId);
    }
}
