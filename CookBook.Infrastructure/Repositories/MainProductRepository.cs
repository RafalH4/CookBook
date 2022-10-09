using CookBook.Domain.Entities;
using CookBook.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Infrastructure.Repositories
{
    public class MainProductRepository : BaseRepository<MainProduct>, IMainProductRepository
    {
        public MainProductRepository(DataContext data) : base(data)
        {
        }
    }
}
