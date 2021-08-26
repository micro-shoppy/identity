using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using MicroShoppy.Identity.Application.Users.Commands;
using MicroShoppy.Identity.Application.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace MicroShoppy.Identity.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateUserCommand command)
        {
            await _mediator.Send(command);

            return StatusCode(201);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(GetUserTokenQuery query)
        {
            var tokenDto = await _mediator.Send(query);

            return Ok(tokenDto);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProfileAsync()
        {
            var user = await _mediator.Send(new GetUserQuery
            {
                Id = Guid.Parse(HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Sub))
            });

            return Ok(user);
        }
    }
}