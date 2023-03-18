using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Infrastructure.Data
{
    public static class RegistrationExtensions
    {
        public static void AddStorage(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //serviceCollection.AddDbContext<EducationCodeFirstDbContext>(options =>
            //{
            //    options.UseSqlServer(configuration["ConnectionStrings:LocalDbSqlServer"]);
            //});

            //serviceCollection.AddScoped<IEducationDbContext, EducationCodeFirstDbContext>();
        }
    }
}
