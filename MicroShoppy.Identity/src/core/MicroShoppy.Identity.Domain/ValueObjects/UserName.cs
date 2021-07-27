using System.Collections.Generic;
using MicroShoppy.Identity.Domain.Common;
using MicroShoppy.Identity.Domain.Exceptions;

namespace MicroShoppy.Identity.Domain.ValueObjects
{
    public class UserName : ValueObject
    {
        public string Name { get; protected set; }

        protected UserName()
        {

        }
        public UserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName) || userName.Contains(" "))
            {
                throw new InvalidUserNameException(userName);
            }

            Name = userName;
        }

        public static UserName For(string userName)
        {
            return new UserName(userName);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}