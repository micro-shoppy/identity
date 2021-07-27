using System;
using MicroShoppy.Identity.Domain.Common;
using MicroShoppy.Identity.Domain.ValueObjects;

namespace MicroShoppy.Identity.Domain.Exceptions
{
    public class RoleNotFoundDomainException : NotFoundDomainException
    {
        public RoleNotFoundDomainException(RoleName roleName, Exception ex) : base($"Role with name \"{roleName.Name}\" not found.", ex)
        {
        }

        public RoleNotFoundDomainException(RoleName roleName) : base($"Role with name \"{roleName.Name}\" not found.")
        {
        }

        public RoleNotFoundDomainException(Guid id) : base($"Role with ID \"{id}\" not found.")
        {
        }
    }
}