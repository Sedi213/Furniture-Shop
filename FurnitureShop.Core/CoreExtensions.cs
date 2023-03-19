using FurnitureShop.Core.Helper;
using FurnitureShop.Core.Interface;
using FurnitureShop.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
