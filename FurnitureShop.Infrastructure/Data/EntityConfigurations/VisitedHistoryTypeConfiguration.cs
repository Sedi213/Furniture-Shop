using FurnitureShop.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Infrastructure.Data.EntityConfigurations
{
    internal class VisitedHistoryTypeConfiguration : IEntityTypeConfiguration<VisitedHistory>
    {
        public void Configure(EntityTypeBuilder<VisitedHistory> builder)
        {
            //TODO add limit 7
        }
    }
}
