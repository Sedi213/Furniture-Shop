using FurnitureShop.Core.Interfaces;
using FurnitureShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Interface.RepositoryInterfaces
{
    public interface IFurnitureRepository : IBaseRepository<Furniture>
    {
        IEnumerable<Furniture> GetFurnitureEntityByFilter(
            int skip = 0,
            int take = 10,
            EnumCategory? category = null,
            int? minPrice = null,
            int? maxPrice = null,
            string containPart = "");
        public int GetCountFurnitureEntityByFilter(
            EnumCategory? category = null,
            int? minPrice = null,
            int? maxPrice = null,
            string containPart = "");

    }
}
