using CookBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Domain.Entities
{
    public class Ingredient : BaseEntity
    {
        public Dish Dish { get; set; }
        public Guid DishId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public double Scale { get; set; }
    }
}
