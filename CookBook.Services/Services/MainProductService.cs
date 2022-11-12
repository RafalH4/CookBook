using CookBook.Interfaces.IRepositories;
using CookBook.Models;
using CookBook.Models.DTO.Product;
using CookBook.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Services.Services
{
    public class MainProductService : IMainProductService
    {
        private readonly IUnitOfWork _repository;
        public MainProductService(IUnitOfWork repository) => _repository = repository;

        public Task<IResult> AddProductAsync(NewProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
