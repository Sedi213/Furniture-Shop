using FurnitureShop.Core.Interfaces;

namespace FurnitureShop.Core.Services
{
    public class SellerService
    {
        private readonly IUnitOfWork _dbContext;
        public SellerService(IUnitOfWork dbContext)
        {
            _dbContext=dbContext;
        }
    }
}
