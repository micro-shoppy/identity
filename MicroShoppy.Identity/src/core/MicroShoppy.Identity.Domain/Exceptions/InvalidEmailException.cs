using System;
using MicroShoppy.Identity.Domain.Common;

namespace MicroShoppy.Identity.Domain.Exceptions
{
    public class InvalidEmailException : DomainException
    {
        public InvalidEmailException(string email, Exception ex) : base($"Email \"{email}\" is invalid.", ex)
        {
        }

        public InvalidEmailException(string email) : base($"Email \"{email}\" is invalid.")
        {
        }
    }
}