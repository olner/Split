using Microsoft.AspNetCore.Mvc;
using Split.Engine.Services;

namespace SplitWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILogger<UserController> logger;
        private readonly UserService userService;

        public UserController(
            ILogger<UserController> logger,
            UserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }
        [HttpGet(Name = "GetUserData")]
        public IEnumerable<WeatherForecast> GetUserData()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
