using CookBook.Models.DTO.Product;

namespace CookBook.App.Services
{
    public interface IProductDataService
    {
        Task AddMainProduct(NewProductModel product);
    }
}
