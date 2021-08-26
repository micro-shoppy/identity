using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MicroShoppy.Identity.Application.DTOs;
using MicroShoppy.Identity.Application.Repositories;
using MicroShoppy.Identity.Application.Services;
using MicroShoppy.Identity.Domain.Exceptions;
using MicroShoppy.Identity.Domain.ValueObjects;

namespace MicroShoppy.Identity.Application.Users.Queries
{
    public class GetUserTokenQueryHandler : IRequestHandler<GetUserTokenQuery, TokenDto>
    {
        private readonly IUserRepository _repository;
        private readonly IJwtHandler _jwtHandler;

        public GetUserTokenQueryHandler(IUserRepository repository, IJwtHandler jwtHandler)
        {
            _repository = repository;
            _jwtHandler = jwtHandler;
        }

        public async Task<TokenDto> Handle(GetUserTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAsync(Email.For(request.Email));

            if (user == null || (user != null && !user.UserPassword.VerifyPassword(request.Password)))
            {
                throw new InvalidCredentialsException();
            }

            return _jwtHandler.CreateToken(user);
        }
    }
}