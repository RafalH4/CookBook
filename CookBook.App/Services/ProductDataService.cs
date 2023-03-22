using CookBook.Models.DTO.Product;
using System.Text.Json;

namespace CookBook.App.Services
{
    public class ProductDataService : IProductDataService
    {
        private readonly HttpClient _httpClient;
        public ProductDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddMainProduct(NewProductModel product)
        {
            var newProduct = new NewProductModel()
            {
                Name = "Marchewka",
                OtherTempValue = "IDK",
            };
            //var deserialized = JsonSerializer.DeserializeAsync();
            //var myContent = JsonConvert.SerializeObject(data);
            //await _httpClient.PostAsync("api/Product", newProduct);
            //var a = await JsonSerializer.DeserializeAsync<NewProductModel>(
            //    await _httpClient.GetStreamAsync("api/MainProduct"))
        }
    }
}
