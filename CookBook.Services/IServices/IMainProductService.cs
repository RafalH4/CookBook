using CookBook.Domain.Entities;
using CookBook.Models;
using CookBook.Models.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Services.IServices
{
    public interface IMainProductService
    {
        Task<Result> AddProductAsync(NewProductModel model);
        Task<Result<NewProductModel>> GetProduct(Guid id);
        Task<Result<IEnumerable<MainProduct>>> AllProducts();
    }
}
