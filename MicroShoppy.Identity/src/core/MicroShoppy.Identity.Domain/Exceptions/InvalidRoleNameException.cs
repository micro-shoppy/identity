using System;
using MicroShoppy.Identity.Domain.Common;

namespace MicroShoppy.Identity.Domain.Exceptions
{
    public class InvalidRoleNameException : DomainException
    {
        public InvalidRoleNameException(string roleName, Exception ex) : base($"Role name \"{roleName}\" is invalid.", ex)
        {
        }

        public InvalidRoleNameException(string roleName) : base($"Role name \"{roleName}\" is invalid.")
        {
        }
    }
}