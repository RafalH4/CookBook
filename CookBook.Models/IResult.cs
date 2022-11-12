using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Models
{
    public interface IResult
    {
        public List<string> Messages { get; set; }
        public bool Success { get; set; }
    }
    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}
