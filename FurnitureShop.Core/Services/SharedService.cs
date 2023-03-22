
using FurnitureShop.Core.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        public SharedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<Furniture> GetFurnitureByFilter(
            int skip = 0,
            int take = 10,
            EnumCategory? category = null,
            int? minPrice = null,
            int? maxPrice = null,
            string containPart = "")
        {
            return _unitOfWork.Furnitures.GetFurnitureEntityByFilter(skip,
                                                          take,
                                                          category,
                                                          minPrice,
                                                          maxPrice,
                                                          containPart);
        }


        public async Task AddToBasket(Furniture furniture, User user)
        {
            var entity = _unitOfWork.Baskets.Find(x => x.User.Id == user.Id);
            if (entity.Count() != 0)
            {
                entity.First().UserBasket.Append(furniture);
            }
            else
            {
                _unitOfWork.Baskets.Add(new Basket
                {
                    Id = Guid.NewGuid(),
                    User = user,
                    UserBasket = new List<Furniture>() { furniture }
                });
            }
            await _unitOfWork.SaveAsync();
        }
    }
}
