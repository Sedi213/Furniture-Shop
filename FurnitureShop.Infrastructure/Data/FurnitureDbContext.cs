﻿using FurnitureShop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Infrastructure.Data
{
    internal class FurnitureDbContext:DbContext
    {

        public FurnitureDbContext(DbContextOptions options) : base(options) { 
            Database.EnsureCreated();
        }

        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VisitedHistory> VisitedHistories { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FurnitureDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}