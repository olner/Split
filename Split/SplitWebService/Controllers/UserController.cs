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
        private readonly ILogger<UserController> logger;
        private readonly UserService userService;
        private readonly IUserRepository userRepository;

        public UserController(
            ILogger<UserController> logger,
            UserService userService,
            IUserRepository userRepository)
        {
            this.logger = logger;
            this.userService = userService;
            this.userRepository = userRepository;
        }

        [HttpGet("", Name = "GetAllUsers")]
        public List<User> GetUsers() => userService.GetUsers();

        [HttpGet("{id:int}", Name = "GetUserById")]
        public User? GetUser(int id) => userService.GetUserById(id);

        [HttpGet("{login}&{password}", Name = "Authorize")]
        public User? Authorize(string login, string password) => userService.Authorize(login, password);

        [HttpGet("Register{login}&{password}", Name = "Register")]
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

        [HttpPost("SetRole{userId:int}/{roleName}",Name = "SetRole")]
        public void SetRole(int userId, string roleName)
        {
            try
            {
                userService.SetRole(userId, roleName);
            }
            catch (ServiceException)
            {

            }
        }
    }
}
