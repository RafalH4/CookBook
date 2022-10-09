using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Services.IServices
{
    internal interface IServiceManager
    {
        IDishService DishService { get; }
        IMainProductService ProductService { get; }
        IUserService UserService { get; }
    }
}
