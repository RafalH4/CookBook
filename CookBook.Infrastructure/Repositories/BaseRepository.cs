using CookBook.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _data;
        public BaseRepository(DataContext data)
        {
            _data = data;
        }
        public Task Add(T entity)
        {
            _data.Set<T>().Add(entity);
            return Task.CompletedTask;
        }

        public async Task<T> Get(Guid id)
        {
            return await _data.Set<T>().FindAsync(id);
        }
        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
