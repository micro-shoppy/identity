using MicroShoppy.Identity.Domain.Common;

namespace MicroShoppy.Identity.Domain.Exceptions
{
    public class UserAlreadyExistsDomainException : DomainException
    {
        public UserAlreadyExistsDomainException() : base("User with this combination of user name and email already exists.")
        {
        }
    }
}