using API.Application.Commands.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _bus;

        public AccountController(IMediator bus)
        {
            _bus = bus;
        }


        [HttpPost]
        [Route("user")]
        public IActionResult Create(CreateUserCommand request)
        {
            var resurlt = _bus.Send(request).Result;

            if(resurlt) return Ok(resurlt);

            return BadRequest();
        }

    }
}
