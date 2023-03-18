using FurnitureShop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Interface
{
    public interface IFurnitureDbContext
    {
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VisitedHistory> VisitedHistories { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        public Task<int> SaveChangesAsync();
    }
}
