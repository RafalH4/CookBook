using CookBook.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public IDishRepository Dishes { get; }

        public IMainProductRepository MainProducts { get; }

        public IUserRepository Users { get; }
        public UnitOfWork(DataContext dataContext, IDishRepository dishes, IMainProductRepository mainProducts, IUserRepository users)
        {
            _dataContext = dataContext;
            Dishes = dishes;
            MainProducts = mainProducts;
            Users = users;
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
