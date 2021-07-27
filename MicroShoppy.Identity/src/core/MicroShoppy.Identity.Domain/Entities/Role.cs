using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroShoppy.Identity.Domain.Common;
using MicroShoppy.Identity.Domain.ValueObjects;

namespace MicroShoppy.Identity.Domain.Entities
{
    public class Role : AuditableEntity<Guid>
    {
        public RoleName RoleName { get; protected set; }
        public ICollection<User> Users { get; protected set; }
        protected Role()
        {
            Users = new List<User>();
        }
        public Role(Guid id, DateTime createdAt, RoleName roleName) : base(id, createdAt)
        {
            if (roleName == null)
            {
                throw new ArgumentNullException(nameof(roleName), $"{nameof(RoleName)} property in {nameof(Role)} entity must not be null.");
            }

            RoleName = roleName;
            Users = new List<User>();
        }

    }
}
