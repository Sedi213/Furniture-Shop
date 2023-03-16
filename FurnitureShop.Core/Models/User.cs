using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
    }
}
