
using FurnitureShop.Core.Interfaces;
using FurnitureShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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


        public async Task AddToBasket(Guid furnitureid, Guid userid)
        {
            //var user = _unitOfWork.Users.Find(x => x.Id == userid).First();
            var user=_unitOfWork.Users.GetAll().First();//For some while , will be changed with identityserver4
            var basket = _unitOfWork.Baskets.Find(x => x.User.Id == user.Id).FirstOrDefault();


            if (basket != null)
            {
                var entities=JsonSerializer.Deserialize<IEnumerable<Guid>>(basket.UserBasketJSONSerializetedFurnitureGuid);
                var newstr = JsonSerializer.Serialize<IEnumerable<Guid>>(entities.Append(furnitureid));
                basket.UserBasketJSONSerializetedFurnitureGuid= newstr;
            }
            else
            {
                _unitOfWork.Baskets.Add(new Basket
                {
                    Id = Guid.NewGuid(),
                    User = user,
                    UserBasketJSONSerializetedFurnitureGuid = JsonSerializer.Serialize<IEnumerable<Guid>>(new List<Guid>() { furnitureid})
                });
            }
            await _unitOfWork.SaveAsync();
        }


        public  Furniture GetFurnitureById(Guid id)
        {
            return  _unitOfWork.Furnitures.Get(id);
        }
    }
}
