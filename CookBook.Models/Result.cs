﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Models
{
    public class Result : IResult
    {
        public List<string> Messages { get ; set ; }
        public bool Success { get; set; }
    }
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}
