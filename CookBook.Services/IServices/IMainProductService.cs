using CookBook.Models;
using CookBook.Models.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Services.IServices
{
    public interface IMainProductService
    {
        Task<IResult> AddProductAsync(NewProductModel model);
    }
}
