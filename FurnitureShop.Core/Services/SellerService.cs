using FurnitureShop.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Services
{
    public class SellerService
    {
        private readonly IFurnitureDbContext _dbContext;
        public SellerService(IFurnitureDbContext dbContext)
        {
            _dbContext=dbContext;
        }
    }
}
