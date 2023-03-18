using FurnitureShop.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Infrastructure.Data.Interfaces
{
    public interface IUnitOfWork
    {
        BasketRepository Baskets { get;  }

        void Save();
    }
}
