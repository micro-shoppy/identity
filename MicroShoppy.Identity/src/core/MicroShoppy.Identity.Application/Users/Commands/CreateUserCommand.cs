using System;
using MediatR;
using MicroShoppy.Identity.Application.Services;

namespace MicroShoppy.Identity.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}