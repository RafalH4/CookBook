using CookBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public User User { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public User CreatedBy { get; set; }
        public Role Role { get; set; }
    }
}
