using FurnitureShop.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureShop.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options) { 
            Database.EnsureCreated();
        }

        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VisitedHistory> VisitedHistories { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        public async Task<int> SaveChangesAsync()
        {
           return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
