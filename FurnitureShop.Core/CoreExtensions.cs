using FurnitureShop.Core.Helper;
using FurnitureShop.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FurnitureShop.Core
{
    public static class CoreExtensions
    {
        public static void AddCore(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<SharedService>();
            serviceCollection.AddScoped<SellerService>();
            serviceCollection.AddScoped<DataHelper>();//only for dev 
        }
    }
}
