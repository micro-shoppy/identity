using System.Collections.Generic;
using MicroShoppy.Identity.Domain.Common;
using MicroShoppy.Identity.Domain.Exceptions;

namespace MicroShoppy.Identity.Domain.ValueObjects
{
    public class RoleName : ValueObject
    {
        public string Name { get; protected set; }

        protected RoleName()
        {

        }
        public RoleName(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new InvalidRoleNameException(roleName);
            }

            Name = roleName;
        }

        public static RoleName For(string roleName)
        {
            return new RoleName(roleName);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}