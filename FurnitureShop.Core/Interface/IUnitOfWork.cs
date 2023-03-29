using FurnitureShop.Core.Interface.RepositoryInterfaces;
using FurnitureShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBasketRepository Baskets { get;  }
        IFurnitureRepository Furnitures { get;  }
        IUserRepository Users { get;  }
        IVisitedHistoryRepository VisitedHistories { get;  }
        Task<int> SaveAsync();
    }
}
