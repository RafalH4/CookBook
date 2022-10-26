using CookBook.Infrastructure;
using CookBook.Infrastructure.Repositories;
using CookBook.Interfaces.IRepositories;
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
        }

        public static void ConfigureDbConnection(this IServiceCollection service, IConfiguration config)
        {
            var connectionString = config["dbConnection:connectionString"];
            service.AddDbContext<DataContext>(opt => 
                opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("CookBook.Infrastructure")));
        }
    }
}
