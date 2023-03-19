using FurnitureShop.Core.Interfaces;
using FurnitureShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Helper
{
    public class DataHelper//class for test data
    {
        private readonly IUnitOfWork _unitOfWork;

        public DataHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void FillTableTestData()
        {
            var customer1 = new User()
            {
                Id= Guid.NewGuid(),
                Name="First",
                Role=EnumRole.Customer
            };
            var customer2 = new User()
            {
                Id = Guid.NewGuid(),
                Name = "First",
                Role = EnumRole.Customer
            };
            var seller1 = new User()
            {
                Id = Guid.NewGuid(),
                Name = "First",
                Role = EnumRole.Seller
            };
            var seller2 = new User()
            {
                Id = Guid.NewGuid(),
                Name = "First",
                Role = EnumRole.Seller
            };
            _unitOfWork.Users.Add(customer1);
            _unitOfWork.Users.Add(customer2);
            _unitOfWork.Users.Add(seller1);
            _unitOfWork.Users.Add(seller2);

            var furniture1 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller1,
                ImgUrl = "",
                Name = "FUR1",
                Price = 125,
                Category = EnumCategory.None
            };
            var furniture2 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller1,
                ImgUrl = "",
                Name = "FUR2",
                Price = 25,
                Category = EnumCategory.Table
            };
            var furniture3 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller2,
                ImgUrl = "",
                Name = "FUR3",
                Price = 225,
                Category = EnumCategory.Table
            };
            var furniture4 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller2,
                ImgUrl = "",
                Name = "FUR1",
                Price = 75,
                Category = EnumCategory.None
            };
            var furniture5 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller1,
                ImgUrl = "",
                Name = "FUR56",
                Price = 125,
                Category = EnumCategory.None
            };
            var furniture6 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller1,
                ImgUrl = "",
                Name = "FUR6",
                Price = 25,
                Category = EnumCategory.Table
            };
            var furniture7 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller2,
                ImgUrl = "",
                Name = "FUR7",
                Price = 225,
                Category = EnumCategory.Table
            };
            var furniture8 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller2,
                ImgUrl = "",
                Name = "FUR8",
                Price = 75,
                Category = EnumCategory.None
            };
            _unitOfWork.Furnitures.Add(furniture1);
            _unitOfWork.Furnitures.Add(furniture2);
            _unitOfWork.Furnitures.Add(furniture3);
            _unitOfWork.Furnitures.Add(furniture4);
            _unitOfWork.Furnitures.Add(furniture5);
            _unitOfWork.Furnitures.Add(furniture7);
            _unitOfWork.Furnitures.Add(furniture6);
            _unitOfWork.Furnitures.Add(furniture8);
            _unitOfWork.SaveAsync();
        }
    }
}
