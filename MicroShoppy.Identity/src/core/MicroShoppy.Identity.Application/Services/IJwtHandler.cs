using System.Reflection.Metadata;
using MicroShoppy.Identity.Application.DTOs;
using MicroShoppy.Identity.Domain.Entities;

namespace MicroShoppy.Identity.Application.Services
{
    public interface IJwtHandler
    {
        TokenDto CreateToken(User user);
    }
}