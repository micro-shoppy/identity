using System;
using MicroShoppy.Identity.Domain.Common;

namespace MicroShoppy.Identity.Domain.Exceptions
{
    public class InvalidUserNameException : DomainException
    {
        public InvalidUserNameException(string userName, Exception ex) : base($"UserName \"{userName}\" is invalid.", ex)
        {
        }

        public InvalidUserNameException(string userName) : base($"UserName \"{userName}\" is invalid.")
        {
        }
    }
}