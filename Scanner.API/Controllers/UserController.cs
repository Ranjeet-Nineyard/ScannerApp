using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scanner.API.Models;
using Scanner.Data.Model;
using Scanner.MediatR.Users;
using System.Diagnostics;

namespace Scanner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator mediat;

        public UserController(ILogger<UserController> logger, IMediator mediat)
        {
            _logger = logger;
            this.mediat = mediat;
        }

        [HttpGet]
        [Route("Register")]
        public Task<Response<bool>> Register([FromBody] Register.Request r) => mediat.Send(r);


        [HttpGet]
        [Route("UpdateUser")]
        public Task<string> UpdateUser() => mediat.Send(new UpdateUser.Request());

    }
}
