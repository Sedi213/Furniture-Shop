using FurnitureShop.Core.Interface.RepositoryInterfaces;
using FurnitureShop.Core.Models;

namespace FurnitureShop.Infrastructure.Data.Repositories
{
    public class BasketRepository : BaseRepository<Basket>,IBasketRepository
    {
        public BasketRepository(ApplicationDbContext dbContext):base(dbContext) 
        {

        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _dbContext as ApplicationDbContext; }
        }
    }
}
