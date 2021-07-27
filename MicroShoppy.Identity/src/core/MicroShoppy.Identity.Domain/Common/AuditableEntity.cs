using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShoppy.Identity.Domain.Common
{
    public class AuditableEntity<T>
    {
        public T Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected AuditableEntity()
        {

        }
        public AuditableEntity(T id, DateTime createdAt)
        {
            Id = id;
            CreatedAt = createdAt;
        }
    }
}
