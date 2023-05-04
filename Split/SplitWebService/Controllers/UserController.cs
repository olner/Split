using Microsoft.AspNetCore.Mvc;
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
        [HttpGet(Name = "GetUsers")]
        public List<User> GetUsers()
        {
            var tmp = userService.GetUsers();
            return tmp;
        }
        [HttpGet(Name = "GetUser")]
        public User GetUser()
        {
            return userRepository.GetUser(1);
        }
    }
}
