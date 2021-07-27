using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MicroShoppy.Identity.Domain.Common;
using MicroShoppy.Identity.Domain.Exceptions;

namespace MicroShoppy.Identity.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        private static readonly Regex _mailRegex = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
        public string UserName { get; protected set; }
        public string DomainName { get; protected set; }

        public string FullEmail => $"{UserName}@{DomainName}";

        protected Email()
        {

        }
        public Email(string email)
        {
            if (!_mailRegex.IsMatch(email))
            {
                throw new InvalidEmailException(email);
            }
            var index = email.IndexOf("@", StringComparison.Ordinal);
            UserName = email.Substring(0, index);
            DomainName = email.Substring(index + 1);
        }

        public static Email For(string email)
        {
            return new Email(email);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserName;
            yield return DomainName;
        }
    }
}
