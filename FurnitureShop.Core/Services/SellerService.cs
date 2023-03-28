using FurnitureShop.Core.Interfaces;
using FurnitureShop.Core.Models;

namespace FurnitureShop.Core.Services
{
    public class SellerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SellerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task AddNewFurniture(
            string Name,
            int Category,
            int Price,
            string ImgUrl,
            Guid userid)
        {

            var fr = new Furniture();
            fr.Name = Name == string.Empty ? "None" : Name;
            fr.Category = (EnumCategory)Category;
            fr.Price = Price;
            fr.ImgUrl = ImgUrl == string.Empty ? "None" : ImgUrl;

            //var user = _unitOfWork.Users.Find(x => x.Id == userid && user.Role==EnumRole.Seller).FirstOrDefault();
            var user = _unitOfWork.Users.Find(x => x.Role == EnumRole.Seller).First();//TODO IS4 real user
            if (user != null)
                fr.Owner = user;
            else
                throw new Exception($"User not find by id {userid}");
            _unitOfWork.Furnitures.Add(fr);
            await _unitOfWork.SaveAsync();
        }


        public IEnumerable<Furniture> GetSellerFurnitures(Guid id)
        {
            return _unitOfWork.Furnitures.Find(f => f.Id == id);
        }
    }
}
