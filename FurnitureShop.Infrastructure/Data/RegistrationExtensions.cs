using FurnitureShop.Core.Interfaces;
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
        }
    }
}
