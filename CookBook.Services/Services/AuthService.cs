using CookBook.Domain.Entities;
using CookBook.Interfaces.IRepositories;
using CookBook.Models;
using CookBook.Models.DTO.User;
using CookBook.Services.Helpers;
using CookBook.Services.IServices;
using Microsoft.Extensions.Configuration;

namespace CookBook.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _repository;
        private readonly IConfiguration _config;
        public AuthService(IUnitOfWork repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }
        public async Task<Result<string>> Authenticate(UserLogin userLogin)
        {
            var user = await _repository.Users.Get(userLogin.Login);
            var returnMessages = new List<string>();
            if(user == null)
            {
                returnMessages.Add("Użytkownik o wskazanym adresie email nie istnieje");
                return new Result<string>()
                {
                    Success = false,
                    Messages = returnMessages
                };
            }
            if(!AuthHelper.CheckPassword(user, userLogin.Password))
            {
                returnMessages.Add("Błędny login i\\lub hasło");
                return new Result<string>()
                {
                    Success = false,
                    Messages = returnMessages,
                };
            }
            //generate token
            var token = "example token";
            returnMessages.Add($"Poprawnie wygenerowano token dla użytkownika o adresie email {user.Email}");
            
            return new Result<string>()
            {
                Success = true,
                Messages = returnMessages,
                Data = token,
            };
        }

        public Result<string> GenerateToken(User user, string role)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> SwitchRole(string token, string role)
        {
            throw new NotImplementedException();
        }
    }
}
