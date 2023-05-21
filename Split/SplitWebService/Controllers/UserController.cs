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

        [HttpGet("/auth", Name = "Authorize")]
        public User? Authorize(string login, string password) 
        {
            return userService.Authorize(login, password);
        }

        [HttpPost("/reg", Name = "Register")]
        public User? Register(string login, string password)
        {
            try
            {
                return userService.Register(login, password);
            }
            catch (ServiceException)
            {
                return null;
            }            
        }

        [HttpDelete("/delete", Name = "Delete")]
        public void Delete(int id)
        {
            userService.DeleteUser(id);
        }

        [HttpGet("/Friend", Name = "GetFriend")]
        public Friend? GetFriend(int userId, int friendId) => userService.GetFriend(userId, friendId);

        [HttpPost("/AddFriend", Name = "AddFriend")]
        public Friend AddFriend(int userId, int friendId, bool request) => userService.AddFriend(userId,friendId,request);

        [HttpDelete("/DeleteFriend", Name = "DeleteFriend")]
        public void DeleteFriend(Guid id) => userService.DeleteFriend(id);
    }
}
