using CookBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Interfaces.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Get(string login);
    }
}
