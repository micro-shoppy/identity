using System;
using System.Collections.Generic;
using MicroShoppy.Identity.Domain.Common;
using MicroShoppy.Identity.Domain.Exceptions;

namespace MicroShoppy.Identity.Domain.ValueObjects
{
    public class UserPassword : ValueObject
    {
        public static Func<string, string> HashFunction { get; set; }
        public static Func<string, string, bool> VerifyPasswordFunction { get; set; }
        public string Password { get; protected set; }

        protected UserPassword()
        {

        }

        public UserPassword(string password)
        {
            if (HashFunction == null)
            {
                throw new NullReferenceException("Password value object's HashFunction is not set.");
            }

            if (string.IsNullOrWhiteSpace(password) || password.Contains(" "))
            {
                throw new InvalidUserPasswordException(password);
            }

            Password = HashFunction(password);
        }

        public static UserPassword For(string password)
        {
            return new UserPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            if (VerifyPasswordFunction == null)
            {
                throw new NullReferenceException("Password value object's VerifyPasswordFunction is not set.");
            }

            if (password == null)
            {
                return false;
            }

            return VerifyPasswordFunction(Password, password);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Password;
        }
    }
}