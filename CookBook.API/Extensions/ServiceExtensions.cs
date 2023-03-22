using CookBook.Infrastructure;
using CookBook.Infrastructure.Repositories;
using CookBook.Interfaces.IRepositories;
using CookBook.Services.IServices;
using CookBook.Services.Services;
using Microsoft.EntityFrameworkCore;

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
            service.AddScoped<IDishService, DishService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IMainProductService, MainProductService>();
        }

        public static void ConfigureDbConnection(this IServiceCollection service, IConfiguration config)
        {
            var connectionString = config["dbConnection:connectionString"];
            service.AddDbContext<DataContext>(opt => 
                opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("CookBook.Infrastructure")));
        }
    }
}
