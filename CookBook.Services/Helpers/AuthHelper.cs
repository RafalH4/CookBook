using CookBook.Domain.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
        public static string GenerateToken(User user, string role, IConfiguration config)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var keyToCredentials = config["AppSettings:SecurityKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyToCredentials));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var securityTokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credentials,
                
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(securityTokenDescription);
            return tokenHandler.WriteToken(securityToken);
        }
        public static JwtSecurityToken ValidateToken(string token, IConfiguration config)
        {
            //TO DO
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyToCredentials = config["AppSettings:SecurityKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyToCredentials));
            var validationParams = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
            };
            tokenHandler.ValidateToken(token, validationParams, out SecurityToken validatedToken);
            return (JwtSecurityToken)validatedToken;
        }
    }
}
