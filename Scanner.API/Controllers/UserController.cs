using Microsoft.AspNetCore.Mvc;
using Scanner.API.Models;
using System.Diagnostics;

namespace Scanner.API.Controllers
{
    [ApiController]
    [Route("api/Home")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Index")]
        public string Index()
        {
            return "fdfsd";
        }

    }
}
