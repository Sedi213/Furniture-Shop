using FurnitureShop.Core.Models;
using FurnitureShop.Core.Interface.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace FurnitureShop.Infrastructure.Data.Repositories
{
    public class FurnitureRepository : BaseRepository<Furniture>, IFurnitureRepository
    {
        public FurnitureRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {

        }

        public IEnumerable<Furniture> GetFurnitureEntityByFilter(
            int skip = 0,
            int take = 10,
            EnumCategory? category = null,
            int? minPrice = null,
            int? maxPrice = null,
            string containPart = "")
        {
            int ActualMinPrice = minPrice ?? 0;
            int ActualMaxPrice = maxPrice ?? ApplicationDbContext.Furnitures.Max(x => x.Price);

            if (ActualMinPrice > ActualMaxPrice)
                return Enumerable.Empty<Furniture>();
            IEnumerable<Furniture> entities = null;
            if (category == null)
                entities = ApplicationDbContext.Furnitures.Where(x => x.Name.Contains(containPart) &&
                                                        x.Price >= ActualMinPrice &&
                                                        x.Price <= ActualMaxPrice);
            else entities = ApplicationDbContext.Furnitures.Where(x => x.Name.Contains(containPart) &&
                                                        x.Price >= ActualMinPrice &&
                                                        x.Price <= ActualMaxPrice &&
                                                        x.Category == category);
            if (entities.Count() > skip)
                entities = entities.Skip(skip);
            if (entities.Count() > take)
                entities = entities.Take(take);
            return entities;
        }

        public int GetCountFurnitureEntityByFilter(
            EnumCategory? category = null,
            int? minPrice = null,
            int? maxPrice = null,
            string containPart = "")
        {
            int ActualMinPrice = minPrice ?? 0;
            int ActualMaxPrice = maxPrice ?? ApplicationDbContext.Furnitures.Max(x => x.Price);

            if (ActualMinPrice > ActualMaxPrice)
                return 0;
            IEnumerable<Furniture> entities = null;
            if (category == null)
                entities = ApplicationDbContext.Furnitures.Where(x => x.Name.Contains(containPart) &&
                                                        x.Price >= ActualMinPrice &&
                                                        x.Price <= ActualMaxPrice);
            else entities = ApplicationDbContext.Furnitures.Where(x => x.Name.Contains(containPart) &&
                                                        x.Price >= ActualMinPrice &&
                                                        x.Price <= ActualMaxPrice &&
                                                        x.Category == category);
            return entities.Count();
        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _dbContext as ApplicationDbContext; }
        }
    }
}
