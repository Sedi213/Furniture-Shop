using FurnitureShop.Core.Interface.RepositoryInterfaces;
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

        public async Task FillTableTestData()
        {
            IFurnitureRepository furnitureRepository = _unitOfWork.Furnitures;
            IUserRepository userRepository = _unitOfWork.Users;
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
            userRepository.Add(customer1);
            userRepository.Add(customer2);
            userRepository.Add(seller1);
            userRepository.Add(seller2);

            var furniture1 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller1,
                ImgUrl = "https://secure.img1-cg.wfcdn.com/im/32274058/compr-r85/1530/153082342/geary-round-dining-table.jpg",
                Name = "FUR1",
                Price = 125,
                Category = EnumCategory.None
            };
            var furniture2 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller1,
                ImgUrl = "https://secure.img1-cg.wfcdn.com/im/32274058/compr-r85/1530/153082342/geary-round-dining-table.jpg",
                Name = "FUR2",
                Price = 25,
                Category = EnumCategory.Table
            };
            var furniture3 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller2,
                ImgUrl = "https://secure.img1-cg.wfcdn.com/im/32274058/compr-r85/1530/153082342/geary-round-dining-table.jpg",
                Name = "FUR3",
                Price = 225,
                Category = EnumCategory.Table
            };
            var furniture4 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller2,
                ImgUrl = "https://secure.img1-cg.wfcdn.com/im/32274058/compr-r85/1530/153082342/geary-round-dining-table.jpg",
                Name = "FUR1",
                Price = 75,
                Category = EnumCategory.None
            };
            var furniture5 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller1,
                ImgUrl = "https://secure.img1-cg.wfcdn.com/im/32274058/compr-r85/1530/153082342/geary-round-dining-table.jpg",
                Name = "FUR56",
                Price = 125,
                Category = EnumCategory.None
            };
            var furniture6 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller1,
                ImgUrl = "https://secure.img1-cg.wfcdn.com/im/32274058/compr-r85/1530/153082342/geary-round-dining-table.jpg",
                Name = "FUR6",
                Price = 25,
                Category = EnumCategory.Table
            };
            var furniture7 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller2,
                ImgUrl = "https://secure.img1-cg.wfcdn.com/im/32274058/compr-r85/1530/153082342/geary-round-dining-table.jpg",
                Name = "FUR7",
                Price = 225,
                Category = EnumCategory.Table
            };
            var furniture8 = new Furniture()
            {
                Id = Guid.NewGuid(),
                Owner = seller2,
                ImgUrl = "https://secure.img1-cg.wfcdn.com/im/32274058/compr-r85/1530/153082342/geary-round-dining-table.jpg",
                Name = "FUR8",
                Price = 75,
                Category = EnumCategory.None
            };
            furnitureRepository.Add(furniture1);
            furnitureRepository.Add(furniture2);
            furnitureRepository.Add(furniture3);
            furnitureRepository.Add(furniture4);
            furnitureRepository.Add(furniture5);
            furnitureRepository.Add(furniture7);
            furnitureRepository.Add(furniture6);
            furnitureRepository.Add(furniture8);
            await _unitOfWork.SaveAsync();
        }
    }
}
