using API.Application.Commands.UserCommands;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _bus;
        private readonly IConfiguration _configuration;
        private readonly DeliveryContext _deliveryContext;

        public AccountController(IMediator bus, DeliveryContext deliveryContext, IConfiguration configuration)
        {
            _bus = bus;
            _deliveryContext = deliveryContext;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("user")]
        public IActionResult Create(CreateUserCommand request)
        {
            //var resurlt = _bus.Send(request).Result;

            //if(resurlt) return Ok(resurlt);

            //return BadRequest();

            string? a;

#if DEBUG
            a = _configuration.GetConnectionString("Delivery_Connection_String");
#else 
            a = _configuration["Delivery_Connection_String"];
#endif

            return Ok(a);
        }

    }
}
