
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


        public IEnumerable<Furniture> GetFilterFurniture(
            int skip = 0,
            int take = 10,
            EnumCategory? category = null,
            int? minPrice = null,
            int? maxPrice = null,
            string containPart = "")
        {
            return _unitOfWork.Furnitures.GetFilterEntity(skip,
                                                          take,
                                                          category,
                                                          minPrice,
                                                          maxPrice,
                                                          containPart);
        }

    }
}
