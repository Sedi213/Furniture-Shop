using FurnitureShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Infrastructure.Data.Interfaces.IRepository
{
    public interface IFurnitureRepository : IBaseRepository<Furniture>
    {
        IEnumerable<Furniture> GetFilterFurniture(int category);
    }
}
