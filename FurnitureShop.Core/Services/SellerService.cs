using FurnitureShop.Core.Interfaces;

namespace FurnitureShop.Core.Services
{
    public class SellerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SellerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
    }
}
