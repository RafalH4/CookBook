using CookBook.Domain.Entities;
using CookBook.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _db;

        public UserRepository(DataContext data) : base(data)
        {
            _db = data.Users;
        }

        public async Task<User> Get(string login)
        {
            return await _db.SingleOrDefaultAsync(x => x.Email == login);
        }
    }
}
