using CookBook.Interfaces.IRepositories;
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
    }
}
