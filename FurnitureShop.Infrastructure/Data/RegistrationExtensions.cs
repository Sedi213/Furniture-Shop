using FurnitureShop.Core.Interface.RepositoryInterfaces;
using FurnitureShop.Core.Interfaces;
using FurnitureShop.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FurnitureShop.Infrastructure.Data
{
    public static class RegistrationExtensions
    {
        public static void AddStorage(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            }); 

            serviceCollection.AddScoped<ApplicationDbContext>();
            serviceCollection.AddScoped<IUnitOfWork,UnitOfWork>();
            //repository for lazy init
            serviceCollection.AddScoped<IBasketRepository,BasketRepository>();
            serviceCollection.AddScoped<IFurnitureRepository, FurnitureRepository>();
            serviceCollection.AddScoped<IVisitedHistoryRepository, VisitedHistoryRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
