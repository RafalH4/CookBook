using CookBook.Infrastructure.Repositories;
using CookBook.Interfaces.IRepositories;

namespace CookBook.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IDishRepository, DishRepository>();
            service.AddScoped<IMainProductRepository, MainProductRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
