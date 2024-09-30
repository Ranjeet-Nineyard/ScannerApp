using Microsoft.AspNetCore.Mvc;
using Scanner.API.Models;
using System.Diagnostics;

namespace Scanner.API.Controllers
{
    [ApiController]
    [Route("api/Home")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
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
