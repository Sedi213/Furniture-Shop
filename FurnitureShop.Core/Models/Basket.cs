using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Models
{
    public class Basket
    {
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public string UserBasketJSONSerializetedFurnitureGuid { get; set; }
    }
}
