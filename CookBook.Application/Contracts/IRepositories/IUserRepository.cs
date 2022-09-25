using CookBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.Contracts.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
