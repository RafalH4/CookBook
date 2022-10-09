using CookBook.Interfaces.IRepositories;
using CookBook.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Services.Services
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork _repository;
        public DishService(IUnitOfWork repository) => _repository = repository;


    }
}
