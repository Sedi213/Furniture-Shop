using FurnitureShop.Core.Interface.RepositoryInterfaces;
using FurnitureShop.Core.Interfaces;
using FurnitureShop.Infrastructure.Data.Repositories;

namespace FurnitureShop.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Baskets = new BasketRepository(_dbContext);
            Furnitures = new FurnitureRepository(_dbContext);
            Users = new UserRepository(_dbContext);
            VisitedHistories = new VisitedHistoryRepository(_dbContext);
        }
        public IBasketRepository Baskets { get; private set; }
        public IFurnitureRepository Furnitures { get; private set; }
        public IUserRepository Users { get; private set; }
        public IVisitedHistoryRepository VisitedHistories { get; private set; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
