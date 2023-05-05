using Microsoft.AspNetCore.Mvc;
using Split.Engine.Services;

namespace SplitWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly UserService userService;

        public RoleController(
            ILogger<UserController> logger,
            UserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }


    }
}
