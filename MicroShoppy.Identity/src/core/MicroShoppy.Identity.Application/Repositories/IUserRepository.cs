using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroShoppy.Identity.Domain.Entities;
using MicroShoppy.Identity.Domain.ValueObjects;

namespace MicroShoppy.Identity.Application.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<Role> GetDefaultRoleAsync();
        Task<bool> UserExists(UserName userName, Email email);
        Task<bool> UserExists(UserName userName);
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(UserName userName);
        Task<User> GetAsync(Email email);
    }
}