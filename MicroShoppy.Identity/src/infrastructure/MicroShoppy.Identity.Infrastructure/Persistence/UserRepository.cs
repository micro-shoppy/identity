using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShoppy.Identity.Application.Repositories;
using MicroShoppy.Identity.Domain.Entities;
using MicroShoppy.Identity.Domain.ValueObjects;

namespace MicroShoppy.Identity.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly ConcurrentDictionary<Guid, User> _users = new ConcurrentDictionary<Guid, User>();
        private readonly ConcurrentDictionary<Guid, Role> _roles = new ConcurrentDictionary<Guid, Role>();
        private readonly Role _defaultRole;

        public UserRepository()
        {
            var userRole = new Role(Guid.NewGuid(), DateTime.UtcNow, RoleName.For("User"));
            var adminRole = new Role(Guid.NewGuid(), DateTime.UtcNow, RoleName.For("Admin"));
            var user = new User(Guid.NewGuid(), DateTime.UtcNow, Email.For("user@domain.com"), UserName.For("User123"),
                UserPassword.For("Password123"), userRole);
            var admin = new User(Guid.NewGuid(), DateTime.UtcNow, Email.For("admin@domain.com"), UserName.For("Admin123"),
                UserPassword.For("Password123"), userRole, adminRole);

            userRole.Users.Add(user);
            userRole.Users.Add(admin);
            adminRole.Users.Add(admin);
            _defaultRole = userRole;
            _roles.TryAdd(userRole.Id, userRole);
            _roles.TryAdd(adminRole.Id, adminRole);
            _users.TryAdd(user.Id, user);
            _users.TryAdd(admin.Id, admin);
        }

        public Task AddAsync(User user)
        {
            _users.TryAdd(user.Id, user);

            return Task.CompletedTask;;
        }

        public Task<Role> GetDefaultRoleAsync()
        {
            return Task.FromResult(_defaultRole);
        }

        public Task<bool> UserExists(UserName userName, Email email)
        {
            return Task.FromResult(_users.Any(x => x.Value.UserName.Equals(userName)) ||
                                   _users.Any(x => x.Value.Email.Equals(email)));
        }

        public Task<bool> UserExists(UserName userName)
        {
            return Task.FromResult(_users.Any(x => x.Value.UserName.Equals(userName)));
        }

        public Task<User> GetAsync(Guid id)
        {
            _users.TryGetValue(id, out var user);
            return Task.FromResult(user);
        }

        public Task<User> GetAsync(UserName userName)
        {
            return Task.FromResult(_users.SingleOrDefault(x => x.Value.UserName.Equals(userName)).Value);
        }

        public Task<User> GetAsync(Email email)
        {
            return Task.FromResult(_users.SingleOrDefault(x => x.Value.Email.Equals(email)).Value);
        }
    }
}