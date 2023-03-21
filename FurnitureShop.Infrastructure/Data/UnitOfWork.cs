using FurnitureShop.Core.Interface.RepositoryInterfaces;
using FurnitureShop.Core.Interfaces;
using FurnitureShop.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FurnitureShop.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IServiceProvider _provider;
        private IBasketRepository _basketRepository;
        private IVisitedHistoryRepository _visitedHistorytRepository;
        private IFurnitureRepository _furnitureRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(ApplicationDbContext dbContext, IServiceProvider provider)
        {
            _dbContext = dbContext;
            _provider= provider;
        }
        public IBasketRepository Baskets { get {
                return InitService(ref _basketRepository);
            }  }
        public IFurnitureRepository Furnitures { get
            {
                return InitService(ref _furnitureRepository);
            }
        }
        public IUserRepository Users { get
            {
                return InitService(ref _userRepository);
            }  }
        public IVisitedHistoryRepository VisitedHistories { get
            {
                return InitService(ref _visitedHistorytRepository);
            }
        }


        private T InitService<T>(ref T member)//for lazy init
        {
            return member ??= _provider.GetService<T>();
        }



        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public  Task<int> SaveAsync()
        {
            return  _dbContext.SaveChangesAsync();
        }
    }
}
