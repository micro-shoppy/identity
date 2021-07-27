using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroShoppy.Identity.Domain.Common;

namespace MicroShoppy.Identity.Domain.Exceptions
{
    public class InvalidCredentialsException : DomainException
    {
        public InvalidCredentialsException() : base("Invalid credentials.")
        {
        }

        public InvalidCredentialsException(Exception ex) : base("Invalid credentials.", ex)
        {
        }
    }
}
