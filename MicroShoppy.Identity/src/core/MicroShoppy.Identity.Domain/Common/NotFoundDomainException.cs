using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShoppy.Identity.Domain.Common
{
    public class NotFoundDomainException : DomainException
    {
        public NotFoundDomainException(string message) : base(message)
        {
        }

        public NotFoundDomainException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
