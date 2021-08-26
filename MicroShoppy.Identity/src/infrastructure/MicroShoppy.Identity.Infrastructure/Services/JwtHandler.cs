using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using MicroShoppy.Identity.Application.DTOs;
using MicroShoppy.Identity.Application.Services;
using MicroShoppy.Identity.Application.Settings;
using MicroShoppy.Identity.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace MicroShoppy.Identity.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly AuthOptions _options;

        public JwtHandler(IOptions<AuthOptions> options)
        {
            _options = options.Value;
        }

        public TokenDto CreateToken(User user)
        {
            var now = DateTimeOffset.UtcNow;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUnixTimeSeconds().ToString()),
            };

            claims.AddRange(user.Roles.Select(x => new Claim(ClaimTypes.Role, x.RoleName.Name)));

            var expires = now.AddMinutes(_options.ExpiredInMinutes);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.Key)),
                SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: now.UtcDateTime,
                expires: expires.UtcDateTime,
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenDto
            {
                Token = token,
                Expires = expires.ToUnixTimeSeconds().ToString()
            };
        }
    }
}