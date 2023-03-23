using CookBook.Domain.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace CookBook.Services.Helpers
{
    public static class AuthHelper
    {
        public static void CreateHashPasswordForUser(this User user, string clearPasswordText)
        {
            user.PasswordSalt = RandomNumberGenerator.GetBytes(128 / 8);
            user.PasswordHash = GeneratePasswordHash(user, clearPasswordText);
        }
        public static byte[] GeneratePasswordHash(User user, string clearPasswordText)
        {
            return KeyDerivation.Pbkdf2(clearPasswordText, user.PasswordSalt, KeyDerivationPrf.HMACSHA512, 10, 64);
        }
        
        public static bool CheckPassword(User user, string clearPasswordText)
        {
            var generatedPasswordHash = GeneratePasswordHash(user, clearPasswordText);
            if (user.PasswordHash.SequenceEqual(generatedPasswordHash))
                return true;
            else
                return false;
        }
    }
}
