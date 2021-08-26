using System;
using MicroShoppy.Identity.Domain.Common;

namespace MicroShoppy.Identity.Application.Extensions
{
    public static class ExceptionExtensions
    {
        public static bool IsDomainException(this Exception ex)
        {
            return ex is DomainException;
        }

        public static bool IsNotFoundDomainException(this Exception ex)
        {
            return ex is NotFoundDomainException;
        }
    }
}