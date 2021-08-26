using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MicroShoppy.Identity.Application.Repositories;
using MicroShoppy.Identity.Domain.Entities;
using MicroShoppy.Identity.Domain.Exceptions;
using MicroShoppy.Identity.Domain.ValueObjects;

namespace MicroShoppy.Identity.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.UserExists(UserName.For(request.UserName), Email.For(request.Email)))
            {
                throw new UserAlreadyExistsDomainException();
            }

            var user = new User(
                Guid.NewGuid(),
                DateTime.UtcNow,
                Email.For(request.Email),
                UserName.For(request.UserName),
                UserPassword.For(request.Password),
                await _repository.GetDefaultRoleAsync());

            await _repository.AddAsync(user);

            return user.Id;
        }
    }
}