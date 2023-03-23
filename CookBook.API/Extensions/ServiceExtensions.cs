using CookBook.Infrastructure;
using CookBook.Infrastructure.Repositories;
using CookBook.Interfaces.IRepositories;
using CookBook.Services.IServices;
using CookBook.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
            service.AddScoped<IAuthService, AuthService>();
        }
        public static void ConfigureDbConnection(this IServiceCollection service, IConfiguration config)
        {
            var connectionString = config["dbConnection:connectionString"];
            service.AddDbContext<DataContext>(opt => 
                opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("CookBook.Infrastructure")));
        }
    
        public static void ConfigureSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoAppBackend", Version = "v1" });

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };

                c.AddSecurityRequirement(securityRequirement);

            });
        }
    }
}
