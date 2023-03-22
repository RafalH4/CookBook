using CookBook.Domain.Entities;
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

        public async Task<Result> AddProductAsync(NewProductModel model)
        {
            var mainProduct = new MainProduct
            {
                Id = Guid.NewGuid(),
                Energy = 23,
                Name = model.Name,
                CreatedBy = "XYZ",
                Description = "ASD",
                LastModifiedBy = "XYZ",
            };
            
            var result = new Result();
            var listOfMessages = new List<string>();
            try
            {
                await _repository.MainProducts.Add(mainProduct);
                await _repository.SaveAsync();
                listOfMessages.Add("Obiekt został dodany pomyśnie");
                result.Success = true;
            }catch (Exception ex)
            {
                result.Success = false;
            }
            result.Messages = listOfMessages;
            return await Task.FromResult(result);
        }

        public async Task<Result<IEnumerable<MainProduct>>> AllProducts()
        {
            var products = await _repository.MainProducts.GetAll();
            var messages = new List<string>();
            messages.Add("Dane zwrócono poprawnie");
            var result = new Result<IEnumerable<MainProduct>>()
            {
                Data = products,
                Success = true,
                Messages = messages
            };
            return result;
        }

        public Task<Result<NewProductModel>> GetProduct(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
