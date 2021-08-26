using System;
using MediatR;
using MicroShoppy.Identity.Application.DTOs;

namespace MicroShoppy.Identity.Application.Users.Queries
{
    public class GetUserTokenQuery : IRequest<TokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}