﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Interfaces.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDishRepository Dishes { get; }
        IMainProductRepository MainProducts { get; }
        IUserRepository Users { get; }
        Task SaveAsync();
    }
}
