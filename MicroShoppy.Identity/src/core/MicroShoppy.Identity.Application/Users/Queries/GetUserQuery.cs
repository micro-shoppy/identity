using System;
using MediatR;
using MicroShoppy.Identity.Application.DTOs;
using MicroShoppy.Identity.Domain.Entities;

namespace MicroShoppy.Identity.Application.Users.Queries
{
    public class GetUserQuery : IRequest<UserProfileDto>
    {
        public Guid Id { get; set; }
    }
}