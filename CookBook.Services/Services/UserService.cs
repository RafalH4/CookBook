using CookBook.Domain.Entities;
using CookBook.Interfaces.IRepositories;
using CookBook.Models;
using CookBook.Models.DTO.Product;
using CookBook.Models.DTO.User;
using CookBook.Services.Helpers;
using CookBook.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _repository;
        public UserService(IUnitOfWork repository) => _repository = repository;

        public async Task<Result> NewUser(NewUser model)
        {
            var listOfMessages = new List<string>();
            var existingUser = await _repository.Users.Get(model.Email);
            if (existingUser != null)
            {
                listOfMessages.Add("Taki email już istnieje w bazie danych");
                return new Result()
                {
                    Success = false,
                    Messages = listOfMessages
                };
            }
            var currentDate = DateTime.Now;
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CreatedDate = currentDate,
            };
            user.CreateHashPasswordForUser(model.Password);
            try
            {
                await _repository.Users.Add(user);
                await _repository.SaveAsync();
                listOfMessages.Add("Poprawnie utworzono konto użytkownika");
                return new Result()
                {
                    Success = true,
                    Messages = listOfMessages,
                };
            }catch(Exception ex)
            {
                listOfMessages.Add("Nie udało się utworzyć konta użytkownika");
                return new Result()
                {
                    Success = false,
                    Messages = listOfMessages,
                };
            }
            

        }
    }
}
