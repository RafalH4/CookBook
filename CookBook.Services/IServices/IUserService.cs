
using CookBook.Models;
using CookBook.Models.DTO.Product;
using CookBook.Models.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Services.IServices
{
    public interface IUserService
    {
        Task<Result> NewUser(NewUser model);
        
    }
}
