using FurnitureShop.Core.Interface;
using FurnitureShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Services
{
    public class SharedService
    {
        private readonly IFurnitureDbContext _dbContext;
        public SharedService(IFurnitureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Furniture> GetFilterFurniture(
            int skip = 0,
            int take = 10,
            int? category = null,
            int? minPrice = null,
            int? maxPrice = null,
            string containPart = "")
        {
            int ActualMinPrice = minPrice ?? 0;
            int ActualMaxPrice = maxPrice ?? _dbContext.Furnitures.Max(x => x.Price);

            if (ActualMinPrice > ActualMaxPrice)
                return Enumerable.Empty<Furniture>();
            IEnumerable<Furniture> entities = null;
            if (category == null)
                entities = _dbContext.Furnitures.Where(x => x.Name.Contains(containPart) &&
                                                        x.Price >= ActualMinPrice &&
                                                        x.Price <= ActualMaxPrice);
            else entities = _dbContext.Furnitures.Where(x => x.Name.Contains(containPart) &&
                                                        x.Price >= ActualMinPrice &&
                                                        x.Price <= ActualMaxPrice &&
                                                        x.Category == category);
            if (entities.Count() > skip)
                entities = entities.Skip(skip);
            if (entities.Count() > take)
                entities = entities.Take(take);
            return entities;
        }

    }
}
