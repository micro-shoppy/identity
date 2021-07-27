using System;
using MicroShoppy.Identity.Domain.Common;
using MicroShoppy.Identity.Domain.ValueObjects;

namespace MicroShoppy.Identity.Domain.Exceptions
{
    public class UserNotFoundDomainException : NotFoundDomainException
    {
        public UserNotFoundDomainException(UserName userName, Exception ex) : base($"User with name \"{userName.Name}\" not found.", ex)
        {
        }

        public UserNotFoundDomainException(UserName userName) : base($"User with name \"{userName.Name}\" not found.")
        {
        }

        public UserNotFoundDomainException(Email email) : base($"User with email \"{email.FullEmail}\" not found.")
        {
        }

        public UserNotFoundDomainException(Guid id) : base($"User with ID \"{id}\" not found.")
        {
        }
    }
}