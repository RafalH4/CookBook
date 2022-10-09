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
        public IDishRepository Dishes => throw new NotImplementedException();

        public IMainProductRepository MainProducts => throw new NotImplementedException();

        public IUserRepository Users => throw new NotImplementedException();

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
