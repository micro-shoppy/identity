using System;
using MicroShoppy.Identity.Domain.Common;

namespace MicroShoppy.Identity.Domain.Exceptions
{
    public class InvalidUserPasswordException : DomainException
    {
        public InvalidUserPasswordException(string userPassword, Exception ex) : base($"UserPassword \"{userPassword}\" is invalid.", ex)
        {
        }

        public InvalidUserPasswordException(string userPassword) : base($"UserPassword \"{userPassword}\" is invalid.")
        {
        }
    }
}