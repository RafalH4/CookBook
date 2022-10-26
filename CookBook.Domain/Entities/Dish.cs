﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Domain.Entities
{
    public class Dish : Product
    {
        public ICollection<Ingredient> Ingredients { get; set; }
        public string Description { get; set; }
    }
}
