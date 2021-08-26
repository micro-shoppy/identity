using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MicroShoppy.Identity.Application.DTOs;
using MicroShoppy.Identity.Application.Repositories;
using MicroShoppy.Identity.Domain.Entities;

namespace MicroShoppy.Identity.Application.Users.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserProfileDto>
    {
        private readonly IUserRepository _repository;

        public GetUserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserProfileDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAsync(request.Id);

            return new UserProfileDto
            {
                Email = user.Email.FullEmail,
                UserName = user.UserName.Name,
                Roles = user.Roles.Select(x => x.RoleName.Name)
            };
        }
    }
}