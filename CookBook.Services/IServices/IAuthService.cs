using CookBook.Domain.Entities;
using CookBook.Models;
using CookBook.Models.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Services.IServices
{
    public interface IAuthService
    {
        Task<Result<string>> Authenticate(UserLogin userLogin);
        Result<string> GenerateToken(User user, string role);
        Task<Result<string>> SwitchRole(string token, string role);
    }
}
