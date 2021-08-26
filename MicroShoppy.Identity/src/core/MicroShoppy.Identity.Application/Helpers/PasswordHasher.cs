using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace MicroShoppy.Identity.Application.Helpers
{
    public static class PasswordHasher
    {
        public static string CalculateHash(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                var salt = GenerateSalt(16);

                var bytes = KeyDerivation.Pbkdf2(input, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);

                return $"{ Convert.ToBase64String(salt) }:{ Convert.ToBase64String(bytes) }";
            }

            return "";
        }

        private static byte[] GenerateSalt(int length)
        {
            var salt = new byte[length];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            return salt;
        }

        public static bool VerifyPassword(string hash, string input)
        {
            try
            {
                var parts = hash.Split(':');

                var salt = Convert.FromBase64String(parts[0]);

                var bytes = KeyDerivation.Pbkdf2(input, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);

                return parts[1].Equals(Convert.ToBase64String(bytes));
            }
            catch
            {
                return false;
            }
        }
    }
}