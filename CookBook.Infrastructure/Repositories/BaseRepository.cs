using CookBook.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
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
        private DbSet<T> _entity;
        public BaseRepository(DataContext data)
        {
            _data = data;
            _entity = _data.Set<T>();
        }
        public Task Add(T entity)
        {
            _data.Set<T>().Add(entity);
            return Task.CompletedTask;
        }

        public async Task<T> Get(Guid id)
        {
            return await _entity.FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entity
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Remove(T entity)
        {
            _entity.Remove(entity);
        }

        public async Task Update(T entity)
        {
            _entity.Update(entity);
        }
    }
}
