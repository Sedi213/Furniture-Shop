using FurnitureShop.Core.Models;
using FurnitureShop.Infrastructure.Data.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Infrastructure.Data.Repositories
{
    public class FurnitureRepository : BaseRepository<Furniture>, IFurnitureRepository
    {
        public FurnitureRepository(FurnitureDbContext dbContext) : base(dbContext) 
        {

        }
        public IEnumerable<Furniture> GetFilterFurniture(int category)
        {
            throw new NotImplementedException();
        }
    }
}
